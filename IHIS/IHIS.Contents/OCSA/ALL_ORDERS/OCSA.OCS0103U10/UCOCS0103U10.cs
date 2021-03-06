using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;
using IHIS.OCS;
using IHIS.OCSA.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;
using SystemModels = IHIS.CloudConnector.Contracts.Models.System;
using System.Reflection;
using System.Text.RegularExpressions;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Utility;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Results;
using System.Diagnostics;
using IHIS.CloudConnector.Contracts.Arguments.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Results.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Arguments.OcsEmr;
using IHIS.CloudConnector.Contracts.Results.OcsEmr;

namespace IHIS.OCSA
{
    public partial class UCOCS0103U10 : XScreen
    {
        private DataTable grdOutSangDt;
        private XEditGridCell xEditGridCell127;
        private String allWarning = "";
        private bool isOpenPopUp = true;
        private bool isEnableGrd = true;
        private bool isUncheckOutHosp = true;
        private string potionDrugOrder = "";    
        public DataTable GrdOutSangDt
        {
            get { return grdOutSangDt; }
            set { grdOutSangDt = value; }
        }


        #region Auto-gen code

        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCOCS0103U10));
            this.cboInputGubun = new IHIS.Framework.XDictComboBox();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.pnlRight = new IHIS.Framework.XPanel();
            this.pnlSearchOrder = new IHIS.Framework.XPanel();
            this.grdSearchOrder = new IHIS.Framework.XEditGrid();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell120 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell124 = new IHIS.Framework.XEditGridCell();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.grdGeneral = new IHIS.Framework.XEditGrid();
            this.xEditGridCell109 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell110 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell111 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell112 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell113 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell114 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell115 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell116 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell117 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell118 = new IHIS.Framework.XEditGridCell();
            this.tabWonnaeDrg = new IHIS.Framework.XTabControl();
            this.tabpageK9 = new IHIS.X.Magic.Controls.TabPage();
            this.tabpageZ8 = new IHIS.X.Magic.Controls.TabPage();
            this.tabpageT7 = new IHIS.X.Magic.Controls.TabPage();
            this.tabpageY4 = new IHIS.X.Magic.Controls.TabPage();
            this.pnlSangyong = new IHIS.Framework.XPanel();
            this.grdSangyongOrder = new IHIS.Framework.XEditGrid();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell126 = new IHIS.Framework.XEditGridCell();
            this.tabSangyongOrder = new IHIS.Framework.XTabControl();
            this.pnlDrug = new IHIS.Framework.XPanel();
            this.grdDrgOrder = new IHIS.Framework.XEditGrid();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell125 = new IHIS.Framework.XEditGridCell();
            this.tvwDrgBunryu = new IHIS.Framework.XTreeView();
            this.pnlPreview = new IHIS.Framework.XPanel();
            this.grdPreview = new IHIS.Framework.XEditGrid();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.pnlSearchTool = new IHIS.Framework.XPanel();
            this.cboSearchCondition = new IHIS.Framework.XDictComboBox();
            this.grbGeneric = new System.Windows.Forms.GroupBox();
            this.rbtSyouhin = new IHIS.Framework.XFlatRadioButton();
            this.rbtGenericSearch = new IHIS.Framework.XFlatRadioButton();
            this.cboQueryCon = new IHIS.Framework.XComboBox();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.txtSearch = new IHIS.Framework.XTextBox();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.pnlRightBottom = new IHIS.Framework.XPanel();
            this.btnInsert = new IHIS.Framework.XButton();
            this.btnSelect = new IHIS.Framework.XButton();
            this.btnNewSelect = new IHIS.Framework.XButton();
            this.lblInputGubun = new IHIS.Framework.XLabel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnExpandSearch = new IHIS.Framework.XButton();
            this.rbnOrderStatus = new IHIS.Framework.XRadioButton();
            this.rbnDrgOrder = new IHIS.Framework.XRadioButton();
            this.rbnOftenOrder = new IHIS.Framework.XRadioButton();
            this.rbnSearchOrder = new IHIS.Framework.XRadioButton();
            this.pnlOrderInfo = new IHIS.Framework.XPanel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lbStatus = new System.Windows.Forms.Label();
            this.pgbProgress = new IHIS.Framework.XProgressBar();
            this.grdOrder = new IHIS.Framework.XEditGrid();
            this.xEditGridCell351 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell358 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell359 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell360 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell361 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell362 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell363 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell364 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell365 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell366 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell367 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell368 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell369 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell370 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell371 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell372 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell373 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell374 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell375 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell376 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell377 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell378 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell379 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell380 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell384 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell385 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell386 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell387 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell388 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell389 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell390 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell391 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell392 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell393 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell394 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell395 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell396 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell397 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell398 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell399 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell400 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell401 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell402 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell403 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell404 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell405 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell406 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell407 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell408 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell409 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell410 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell411 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell412 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell413 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell414 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell415 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell416 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell417 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell418 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell419 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell420 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell421 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell422 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell423 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell424 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell425 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell426 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell427 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell428 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell429 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell430 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell431 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell432 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell433 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell434 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell435 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell436 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell437 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell438 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell439 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell440 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell441 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell442 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell443 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell444 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell445 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell446 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell447 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell448 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell449 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell450 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell451 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell452 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell453 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell454 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell455 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell456 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell457 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell458 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell459 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell460 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell461 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell464 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell465 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell466 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell467 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell468 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell469 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell470 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell471 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell472 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell473 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell474 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell475 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell476 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell477 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell478 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell479 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell480 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell481 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell482 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell483 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell484 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell485 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell486 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell487 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell488 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell489 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell490 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell491 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell492 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell101 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell102 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell103 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell104 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell105 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell106 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell107 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell108 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell119 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell121 = new IHIS.Framework.XEditGridCell();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xEditGridCell122 = new IHIS.Framework.XEditGridCell();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.xComboItem6 = new IHIS.Framework.XComboItem();
            this.xEditGridCell123 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell128 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell127 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell129 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.pnlOrderDetail = new IHIS.Framework.XPanel();
            this.pbxIsBgtDrg = new System.Windows.Forms.PictureBox();
            this.btnBroughtDrg = new IHIS.Framework.XButton();
            this.btnNalsu = new IHIS.Framework.XButton();
            this.btnJungsiDrug = new IHIS.Framework.XButton();
            this.btnSetOrder = new IHIS.Framework.XButton();
            this.btnDoOrder = new IHIS.Framework.XButton();
            this.btnExtend = new IHIS.Framework.XButton();
            this.dbxBogyongName = new IHIS.Framework.XDisplayBox();
            this.fbxBogyongCode = new IHIS.Framework.XFindBox();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.cboNalsu = new IHIS.Framework.XComboBox();
            this.lblNalsu = new IHIS.Framework.XLabel();
            this.lblInOut = new IHIS.Framework.XLabel();
            this.cbxEmergency = new IHIS.Framework.XCheckBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.cbxWonyoiOrderYN = new IHIS.Framework.XCheckBox();
            this.pnlOrderInput = new IHIS.Framework.XPanel();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.tabGroup = new IHIS.Framework.XTabControl();
            this.grdOutSang = new IHIS.Framework.XEditGrid();
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
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell349 = new IHIS.Framework.XEditGridCell();
            this.imageListPopupMenu = new System.Windows.Forms.ImageList(this.components);
            this.imageListInfo = new System.Windows.Forms.ImageList(this.components);
            this.imageListMixGroup = new System.Windows.Forms.ImageList(this.components);
            this.xEditGridCell493 = new IHIS.Framework.XEditGridCell();
            this.layGroupTab = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.layDrugTree = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.layPreview = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem30 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem31 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem34 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem35 = new IHIS.Framework.MultiLayoutItem();
            this.laySaveLayout = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem25 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem26 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem27 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem28 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem29 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem32 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem33 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem36 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem37 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem38 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem39 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem40 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem41 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem42 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem43 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem44 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem45 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem46 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem47 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem48 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem49 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem50 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem51 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem52 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem53 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem54 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem55 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem56 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem57 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem58 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem59 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem60 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem61 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem62 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem63 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem64 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem65 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem66 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem67 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem68 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem69 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem70 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem71 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem72 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem73 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem74 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem75 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem76 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem77 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem78 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem79 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem80 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem81 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem82 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem83 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem84 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem85 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem86 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem87 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem88 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem89 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem90 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem91 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem92 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem93 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem94 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem95 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem96 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem97 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem98 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem99 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem100 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem101 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem102 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem103 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem104 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem105 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem106 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem107 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem108 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem109 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem110 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem111 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem112 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem113 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem114 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem115 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem116 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem117 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem118 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem119 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem120 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem121 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem122 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem123 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem124 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem125 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem126 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem127 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem128 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem129 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem130 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem131 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem132 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem133 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem134 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem135 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem136 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem137 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem138 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem139 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem140 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem141 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem142 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem143 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem144 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem145 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem146 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem147 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem148 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem149 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem150 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem151 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem152 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem153 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem154 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem155 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem156 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem157 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem158 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem159 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem160 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem161 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem311 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem312 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem313 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem314 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem315 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem316 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem317 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem318 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem319 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem320 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem321 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem322 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem323 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem324 = new IHIS.Framework.MultiLayoutItem();
            this.layDeletedData = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem162 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem163 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem164 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem165 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem166 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem167 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem168 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem169 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem170 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem171 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem172 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem173 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem174 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem175 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem176 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem177 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem178 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem179 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem180 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem181 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem182 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem183 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem184 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem185 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem186 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem187 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem188 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem189 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem190 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem191 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem192 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem193 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem194 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem195 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem196 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem197 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem198 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem199 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem200 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem201 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem202 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem203 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem204 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem205 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem206 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem207 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem208 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem209 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem210 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem211 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem212 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem213 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem214 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem215 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem216 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem217 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem218 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem219 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem220 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem221 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem222 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem223 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem224 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem225 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem226 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem227 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem228 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem229 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem230 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem231 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem232 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem233 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem234 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem235 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem236 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem237 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem238 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem239 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem240 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem241 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem242 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem243 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem244 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem245 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem246 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem247 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem248 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem249 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem250 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem251 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem252 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem253 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem254 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem255 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem256 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem257 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem258 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem259 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem260 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem261 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem262 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem263 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem264 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem265 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem266 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem267 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem268 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem269 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem270 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem271 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem272 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem273 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem274 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem275 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem276 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem277 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem278 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem279 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem280 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem281 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem282 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem283 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem284 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem285 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem286 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem287 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem288 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem289 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem290 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem291 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem292 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem293 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem294 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem295 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem296 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem297 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem298 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem299 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem300 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem301 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem302 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem303 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem304 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem305 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem306 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem307 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem308 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem309 = new IHIS.Framework.MultiLayoutItem();
            this.pnlFill.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlSearchOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchOrder)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGeneral)).BeginInit();
            this.tabWonnaeDrg.SuspendLayout();
            this.pnlSangyong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSangyongOrder)).BeginInit();
            this.pnlDrug.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrgOrder)).BeginInit();
            this.pnlPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPreview)).BeginInit();
            this.pnlSearchTool.SuspendLayout();
            this.grbGeneric.SuspendLayout();
            this.pnlRightBottom.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.pnlOrderInfo.SuspendLayout();
            this.xPanel4.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).BeginInit();
            this.pnlOrderDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIsBgtDrg)).BeginInit();
            this.pnlOrderInput.SuspendLayout();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOutSang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGroupTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDrugTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySaveLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDeletedData)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "YESUP1.ICO");
            this.ImageList.Images.SetKeyName(1, "YESEN1.ICO");
            this.ImageList.Images.SetKeyName(2, "열지우기.ico");
            this.ImageList.Images.SetKeyName(3, "오른쪽_회색.gif");
            this.ImageList.Images.SetKeyName(4, "왼쪽_회색.gif");
            this.ImageList.Images.SetKeyName(5, "닫힌폴더.ico");
            this.ImageList.Images.SetKeyName(6, "열린폴더.ico");
            this.ImageList.Images.SetKeyName(7, "약국정보관리.ico");
            this.ImageList.Images.SetKeyName(8, "진료안내16.ico");
            this.ImageList.Images.SetKeyName(9, "++.gif");
            this.ImageList.Images.SetKeyName(10, "뒤로.gif");
            this.ImageList.Images.SetKeyName(11, "왼쪽_회색1.gif");
            // 
            // cboInputGubun
            // 
            this.cboInputGubun.AccessibleDescription = null;
            this.cboInputGubun.AccessibleName = null;
            resources.ApplyResources(this.cboInputGubun, "cboInputGubun");
            this.cboInputGubun.BackColor = IHIS.Framework.XColor.XCalendarSelectedDateBackColor;
            this.cboInputGubun.BackgroundImage = null;
            this.cboInputGubun.ExecuteQuery = null;
            this.cboInputGubun.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.cboInputGubun.Name = "cboInputGubun";
            this.cboInputGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboInputGubun.ParamList")));
            this.cboInputGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.toolTip1.SetToolTip(this.cboInputGubun, resources.GetString("cboInputGubun.ToolTip"));
            this.cboInputGubun.UserSQL = resources.GetString("cboInputGubun.UserSQL");
            // 
            // pnlFill
            // 
            this.pnlFill.AccessibleDescription = null;
            this.pnlFill.AccessibleName = null;
            resources.ApplyResources(this.pnlFill, "pnlFill");
            this.pnlFill.BackgroundImage = null;
            this.pnlFill.Controls.Add(this.pnlRight);
            this.pnlFill.Controls.Add(this.xPanel2);
            this.pnlFill.Controls.Add(this.pnlOrderInfo);
            this.pnlFill.Font = null;
            this.pnlFill.Name = "pnlFill";
            this.toolTip1.SetToolTip(this.pnlFill, resources.GetString("pnlFill.ToolTip"));
            // 
            // pnlRight
            // 
            this.pnlRight.AccessibleDescription = null;
            this.pnlRight.AccessibleName = null;
            resources.ApplyResources(this.pnlRight, "pnlRight");
            this.pnlRight.BackgroundImage = null;
            this.pnlRight.Controls.Add(this.pnlSearchOrder);
            this.pnlRight.Controls.Add(this.pnlSangyong);
            this.pnlRight.Controls.Add(this.pnlDrug);
            this.pnlRight.Controls.Add(this.pnlPreview);
            this.pnlRight.Controls.Add(this.pnlSearchTool);
            this.pnlRight.Controls.Add(this.pnlRightBottom);
            this.pnlRight.Font = null;
            this.pnlRight.Name = "pnlRight";
            this.toolTip1.SetToolTip(this.pnlRight, resources.GetString("pnlRight.ToolTip"));
            // 
            // pnlSearchOrder
            // 
            this.pnlSearchOrder.AccessibleDescription = null;
            this.pnlSearchOrder.AccessibleName = null;
            resources.ApplyResources(this.pnlSearchOrder, "pnlSearchOrder");
            this.pnlSearchOrder.BackgroundImage = null;
            this.pnlSearchOrder.Controls.Add(this.grdSearchOrder);
            this.pnlSearchOrder.Controls.Add(this.xPanel3);
            this.pnlSearchOrder.Font = null;
            this.pnlSearchOrder.Name = "pnlSearchOrder";
            this.toolTip1.SetToolTip(this.pnlSearchOrder, resources.GetString("pnlSearchOrder.ToolTip"));
            // 
            // grdSearchOrder
            // 
            resources.ApplyResources(this.grdSearchOrder, "grdSearchOrder");
            this.grdSearchOrder.ApplyPaintEventToAllColumn = true;
            this.grdSearchOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell82,
            this.xEditGridCell96,
            this.xEditGridCell97,
            this.xEditGridCell98,
            this.xEditGridCell99,
            this.xEditGridCell120,
            this.xEditGridCell33,
            this.xEditGridCell124});
            this.grdSearchOrder.ColPerLine = 3;
            this.grdSearchOrder.Cols = 3;
            this.grdSearchOrder.ExecuteQuery = null;
            this.grdSearchOrder.FixedRows = 1;
            this.grdSearchOrder.HeaderHeights.Add(28);
            this.grdSearchOrder.Name = "grdSearchOrder";
            this.grdSearchOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSearchOrder.ParamList")));
            this.grdSearchOrder.Rows = 2;
            this.grdSearchOrder.Tag = "1";
            this.toolTip1.SetToolTip(this.grdSearchOrder, resources.GetString("grdSearchOrder.ToolTip"));
            this.grdSearchOrder.ToolTipActive = true;
            this.grdSearchOrder.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdSearchOrder_GiveFeedback);
            this.grdSearchOrder.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdSearchOrder_DragEnter);
            this.grdSearchOrder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdSearchOrder_MouseDown);
            this.grdSearchOrder.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdSearchOrder_RowFocusChanged);
            this.grdSearchOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdSearchOrder_GridCellPainting);
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell28.CellName = "slip_code";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.ExecuteQuery = null;
            this.xEditGridCell28.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsReadOnly = true;
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            this.xEditGridCell28.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell29.CellName = "slip_name";
            this.xEditGridCell29.CellWidth = 100;
            this.xEditGridCell29.ExecuteQuery = null;
            this.xEditGridCell29.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell30.CellName = "hangmog_code";
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.ExecuteQuery = null;
            this.xEditGridCell30.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsReadOnly = true;
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            this.xEditGridCell30.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell31.CellName = "hangmog_name";
            this.xEditGridCell31.CellWidth = 151;
            this.xEditGridCell31.Col = 1;
            this.xEditGridCell31.ExecuteQuery = null;
            this.xEditGridCell31.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsReadOnly = true;
            this.xEditGridCell31.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell82.CellName = "wonnae_drg_yn";
            this.xEditGridCell82.Col = -1;
            this.xEditGridCell82.ExecuteQuery = null;
            this.xEditGridCell82.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell82, "xEditGridCell82");
            this.xEditGridCell82.IsVisible = false;
            this.xEditGridCell82.Row = -1;
            this.xEditGridCell82.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell96.CellName = "generic_name";
            this.xEditGridCell96.CellWidth = 202;
            this.xEditGridCell96.Col = 2;
            this.xEditGridCell96.ExecuteQuery = null;
            this.xEditGridCell96.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell96, "xEditGridCell96");
            this.xEditGridCell96.IsReadOnly = true;
            this.xEditGridCell96.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell97.CellName = "generic_name_inx";
            this.xEditGridCell97.Col = -1;
            this.xEditGridCell97.ExecuteQuery = null;
            this.xEditGridCell97.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell97, "xEditGridCell97");
            this.xEditGridCell97.IsReadOnly = true;
            this.xEditGridCell97.IsVisible = false;
            this.xEditGridCell97.Row = -1;
            this.xEditGridCell97.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell98.CellName = "generic_code";
            this.xEditGridCell98.Col = -1;
            this.xEditGridCell98.ExecuteQuery = null;
            this.xEditGridCell98.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell98, "xEditGridCell98");
            this.xEditGridCell98.IsReadOnly = true;
            this.xEditGridCell98.IsVisible = false;
            this.xEditGridCell98.Row = -1;
            this.xEditGridCell98.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell99.CellName = "generic_code_org";
            this.xEditGridCell99.Col = -1;
            this.xEditGridCell99.ExecuteQuery = null;
            this.xEditGridCell99.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell99, "xEditGridCell99");
            this.xEditGridCell99.IsReadOnly = true;
            this.xEditGridCell99.IsVisible = false;
            this.xEditGridCell99.Row = -1;
            this.xEditGridCell99.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell120
            // 
            this.xEditGridCell120.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell120.CellLen = 13;
            this.xEditGridCell120.CellName = "yak_kijun_code";
            this.xEditGridCell120.Col = -1;
            this.xEditGridCell120.ExecuteQuery = null;
            this.xEditGridCell120.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell120, "xEditGridCell120");
            this.xEditGridCell120.IsReadOnly = true;
            this.xEditGridCell120.IsVisible = false;
            this.xEditGridCell120.Row = -1;
            this.xEditGridCell120.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell33.CellName = "hosp_code";
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            this.xEditGridCell33.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsReadOnly = true;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            this.xEditGridCell33.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell124
            // 
            this.xEditGridCell124.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell124.CellName = "trial_flg";
            this.xEditGridCell124.Col = -1;
            this.xEditGridCell124.ExecuteQuery = null;
            this.xEditGridCell124.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell124, "xEditGridCell124");
            this.xEditGridCell124.IsVisible = false;
            this.xEditGridCell124.Row = -1;
            this.xEditGridCell124.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.grdGeneral);
            this.xPanel3.Controls.Add(this.tabWonnaeDrg);
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            this.toolTip1.SetToolTip(this.xPanel3, resources.GetString("xPanel3.ToolTip"));
            // 
            // grdGeneral
            // 
            resources.ApplyResources(this.grdGeneral, "grdGeneral");
            this.grdGeneral.ApplyPaintEventToAllColumn = true;
            this.grdGeneral.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell109,
            this.xEditGridCell110,
            this.xEditGridCell111,
            this.xEditGridCell112,
            this.xEditGridCell113,
            this.xEditGridCell114,
            this.xEditGridCell115,
            this.xEditGridCell116,
            this.xEditGridCell117,
            this.xEditGridCell118});
            this.grdGeneral.ColPerLine = 2;
            this.grdGeneral.Cols = 2;
            this.grdGeneral.ExecuteQuery = null;
            this.grdGeneral.FixedRows = 1;
            this.grdGeneral.HeaderHeights.Add(19);
            this.grdGeneral.Name = "grdGeneral";
            this.grdGeneral.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdGeneral.ParamList")));
            this.grdGeneral.QuerySQL = resources.GetString("grdGeneral.QuerySQL");
            this.grdGeneral.Rows = 2;
            this.grdGeneral.Tag = "2";
            this.toolTip1.SetToolTip(this.grdGeneral, resources.GetString("grdGeneral.ToolTip"));
            this.grdGeneral.ToolTipActive = true;
            this.grdGeneral.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdSearchOrder_GiveFeedback);
            this.grdGeneral.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdSearchOrder_DragEnter);
            this.grdGeneral.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdSearchOrder_MouseDown);
            this.grdGeneral.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdSearchOrder_GridCellPainting);
            this.grdGeneral.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdGeneral_QueryStarting);
            // 
            // xEditGridCell109
            // 
            this.xEditGridCell109.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell109.CellName = "slip_code";
            this.xEditGridCell109.Col = -1;
            this.xEditGridCell109.ExecuteQuery = null;
            this.xEditGridCell109.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell109, "xEditGridCell109");
            this.xEditGridCell109.IsReadOnly = true;
            this.xEditGridCell109.IsVisible = false;
            this.xEditGridCell109.Row = -1;
            this.xEditGridCell109.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell110
            // 
            this.xEditGridCell110.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell110.CellName = "slip_name";
            this.xEditGridCell110.CellWidth = 92;
            this.xEditGridCell110.ExecuteQuery = null;
            this.xEditGridCell110.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell110, "xEditGridCell110");
            this.xEditGridCell110.IsReadOnly = true;
            this.xEditGridCell110.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell111
            // 
            this.xEditGridCell111.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell111.CellName = "hangmog_code";
            this.xEditGridCell111.Col = -1;
            this.xEditGridCell111.ExecuteQuery = null;
            this.xEditGridCell111.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell111, "xEditGridCell111");
            this.xEditGridCell111.IsReadOnly = true;
            this.xEditGridCell111.IsVisible = false;
            this.xEditGridCell111.Row = -1;
            this.xEditGridCell111.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell112
            // 
            this.xEditGridCell112.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell112.CellName = "hangmog_name";
            this.xEditGridCell112.CellWidth = 357;
            this.xEditGridCell112.Col = 1;
            this.xEditGridCell112.ExecuteQuery = null;
            this.xEditGridCell112.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell112, "xEditGridCell112");
            this.xEditGridCell112.IsReadOnly = true;
            this.xEditGridCell112.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell113
            // 
            this.xEditGridCell113.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell113.CellName = "wonnae_drg_yn";
            this.xEditGridCell113.Col = -1;
            this.xEditGridCell113.ExecuteQuery = null;
            this.xEditGridCell113.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell113, "xEditGridCell113");
            this.xEditGridCell113.IsVisible = false;
            this.xEditGridCell113.Row = -1;
            this.xEditGridCell113.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell114
            // 
            this.xEditGridCell114.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell114.CellName = "generic_name";
            this.xEditGridCell114.CellWidth = 101;
            this.xEditGridCell114.Col = -1;
            this.xEditGridCell114.ExecuteQuery = null;
            this.xEditGridCell114.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell114, "xEditGridCell114");
            this.xEditGridCell114.IsReadOnly = true;
            this.xEditGridCell114.IsVisible = false;
            this.xEditGridCell114.Row = -1;
            this.xEditGridCell114.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell115
            // 
            this.xEditGridCell115.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell115.CellName = "generic_name_inx";
            this.xEditGridCell115.Col = -1;
            this.xEditGridCell115.ExecuteQuery = null;
            this.xEditGridCell115.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell115, "xEditGridCell115");
            this.xEditGridCell115.IsReadOnly = true;
            this.xEditGridCell115.IsVisible = false;
            this.xEditGridCell115.Row = -1;
            this.xEditGridCell115.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell116
            // 
            this.xEditGridCell116.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell116.CellName = "generic_code";
            this.xEditGridCell116.Col = -1;
            this.xEditGridCell116.ExecuteQuery = null;
            this.xEditGridCell116.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell116, "xEditGridCell116");
            this.xEditGridCell116.IsReadOnly = true;
            this.xEditGridCell116.IsVisible = false;
            this.xEditGridCell116.Row = -1;
            this.xEditGridCell116.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell117
            // 
            this.xEditGridCell117.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell117.CellName = "generic_code_org";
            this.xEditGridCell117.Col = -1;
            this.xEditGridCell117.ExecuteQuery = null;
            this.xEditGridCell117.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell117, "xEditGridCell117");
            this.xEditGridCell117.IsReadOnly = true;
            this.xEditGridCell117.IsVisible = false;
            this.xEditGridCell117.Row = -1;
            this.xEditGridCell117.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell118
            // 
            this.xEditGridCell118.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell118.CellName = "hosp_code";
            this.xEditGridCell118.Col = -1;
            this.xEditGridCell118.ExecuteQuery = null;
            this.xEditGridCell118.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell118, "xEditGridCell118");
            this.xEditGridCell118.IsReadOnly = true;
            this.xEditGridCell118.IsVisible = false;
            this.xEditGridCell118.Row = -1;
            this.xEditGridCell118.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // tabWonnaeDrg
            // 
            this.tabWonnaeDrg.AccessibleDescription = null;
            this.tabWonnaeDrg.AccessibleName = null;
            resources.ApplyResources(this.tabWonnaeDrg, "tabWonnaeDrg");
            this.tabWonnaeDrg.BackgroundImage = null;
            this.tabWonnaeDrg.IDEPixelArea = true;
            this.tabWonnaeDrg.IDEPixelBorder = false;
            this.tabWonnaeDrg.Name = "tabWonnaeDrg";
            this.tabWonnaeDrg.SelectedIndex = 0;
            this.tabWonnaeDrg.SelectedTab = this.tabpageK9;
            this.tabWonnaeDrg.TabPages.AddRange(new IHIS.X.Magic.Controls.TabPage[] {
            this.tabpageK9,
            this.tabpageZ8,
            this.tabpageT7,
            this.tabpageY4});
            this.toolTip1.SetToolTip(this.tabWonnaeDrg, resources.GetString("tabWonnaeDrg.ToolTip"));
            this.tabWonnaeDrg.SelectionChanged += new System.EventHandler(this.tabWonnaeDrg_SelectionChanged);
            // 
            // tabpageK9
            // 
            this.tabpageK9.AccessibleDescription = null;
            this.tabpageK9.AccessibleName = null;
            resources.ApplyResources(this.tabpageK9, "tabpageK9");
            this.tabpageK9.BackgroundImage = null;
            this.tabpageK9.Font = null;
            this.tabpageK9.Name = "tabpageK9";
            this.tabpageK9.Tag = "9";
            this.toolTip1.SetToolTip(this.tabpageK9, resources.GetString("tabpageK9.ToolTip"));
            // 
            // tabpageZ8
            // 
            this.tabpageZ8.AccessibleDescription = null;
            this.tabpageZ8.AccessibleName = null;
            resources.ApplyResources(this.tabpageZ8, "tabpageZ8");
            this.tabpageZ8.BackgroundImage = null;
            this.tabpageZ8.Font = null;
            this.tabpageZ8.Name = "tabpageZ8";
            this.tabpageZ8.Selected = false;
            this.tabpageZ8.Tag = "8";
            this.toolTip1.SetToolTip(this.tabpageZ8, resources.GetString("tabpageZ8.ToolTip"));
            // 
            // tabpageT7
            // 
            this.tabpageT7.AccessibleDescription = null;
            this.tabpageT7.AccessibleName = null;
            resources.ApplyResources(this.tabpageT7, "tabpageT7");
            this.tabpageT7.BackgroundImage = null;
            this.tabpageT7.Font = null;
            this.tabpageT7.Name = "tabpageT7";
            this.tabpageT7.Selected = false;
            this.tabpageT7.Tag = "7";
            this.toolTip1.SetToolTip(this.tabpageT7, resources.GetString("tabpageT7.ToolTip"));
            // 
            // tabpageY4
            // 
            this.tabpageY4.AccessibleDescription = null;
            this.tabpageY4.AccessibleName = null;
            resources.ApplyResources(this.tabpageY4, "tabpageY4");
            this.tabpageY4.BackgroundImage = null;
            this.tabpageY4.Font = null;
            this.tabpageY4.Name = "tabpageY4";
            this.tabpageY4.Selected = false;
            this.tabpageY4.Tag = "4";
            this.toolTip1.SetToolTip(this.tabpageY4, resources.GetString("tabpageY4.ToolTip"));
            // 
            // pnlSangyong
            // 
            this.pnlSangyong.AccessibleDescription = null;
            this.pnlSangyong.AccessibleName = null;
            resources.ApplyResources(this.pnlSangyong, "pnlSangyong");
            this.pnlSangyong.BackgroundImage = null;
            this.pnlSangyong.Controls.Add(this.grdSangyongOrder);
            this.pnlSangyong.Controls.Add(this.tabSangyongOrder);
            this.pnlSangyong.Font = null;
            this.pnlSangyong.Name = "pnlSangyong";
            this.toolTip1.SetToolTip(this.pnlSangyong, resources.GetString("pnlSangyong.ToolTip"));
            // 
            // grdSangyongOrder
            // 
            resources.ApplyResources(this.grdSangyongOrder, "grdSangyongOrder");
            this.grdSangyongOrder.ApplyPaintEventToAllColumn = true;
            this.grdSangyongOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell80,
            this.xEditGridCell81,
            this.xEditGridCell83,
            this.xEditGridCell126});
            this.grdSangyongOrder.ColPerLine = 2;
            this.grdSangyongOrder.Cols = 3;
            this.grdSangyongOrder.ExecuteQuery = null;
            this.grdSangyongOrder.FixedCols = 1;
            this.grdSangyongOrder.FixedRows = 1;
            this.grdSangyongOrder.HeaderHeights.Add(28);
            this.grdSangyongOrder.Name = "grdSangyongOrder";
            this.grdSangyongOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSangyongOrder.ParamList")));
            this.grdSangyongOrder.QuerySQL = resources.GetString("grdSangyongOrder.QuerySQL");
            this.grdSangyongOrder.RowHeaderVisible = true;
            this.grdSangyongOrder.Rows = 2;
            this.toolTip1.SetToolTip(this.grdSangyongOrder, resources.GetString("grdSangyongOrder.ToolTip"));
            this.grdSangyongOrder.ToolTipActive = true;
            this.grdSangyongOrder.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdSangyongOrder_GiveFeedback);
            this.grdSangyongOrder.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdSangyongOrder_DragEnter);
            this.grdSangyongOrder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdSangyongOrder_MouseDown);
            this.grdSangyongOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdSangyongOrder_GridCellPainting);
            this.grdSangyongOrder.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdSangyongOrder_QueryStarting);
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell18.CellName = "slip_code";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            this.xEditGridCell18.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            this.xEditGridCell18.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell19.CellName = "slip_name";
            this.xEditGridCell19.CellWidth = 92;
            this.xEditGridCell19.Col = 1;
            this.xEditGridCell19.ExecuteQuery = null;
            this.xEditGridCell19.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell20.CellName = "hangmog_code";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            this.xEditGridCell20.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsNotNull = true;
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            this.xEditGridCell20.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell21.CellName = "hangmog_name";
            this.xEditGridCell21.CellWidth = 319;
            this.xEditGridCell21.Col = 2;
            this.xEditGridCell21.ExecuteQuery = null;
            this.xEditGridCell21.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell22.CellName = "seq";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            this.xEditGridCell22.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            this.xEditGridCell22.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell23.CellName = "hosp_code";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.ExecuteQuery = null;
            this.xEditGridCell23.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsReadOnly = true;
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            this.xEditGridCell23.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell80.CellName = "memb";
            this.xEditGridCell80.Col = -1;
            this.xEditGridCell80.ExecuteQuery = null;
            this.xEditGridCell80.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell80, "xEditGridCell80");
            this.xEditGridCell80.IsVisible = false;
            this.xEditGridCell80.Row = -1;
            this.xEditGridCell80.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell81.CellName = "memb_gubun";
            this.xEditGridCell81.Col = -1;
            this.xEditGridCell81.ExecuteQuery = null;
            this.xEditGridCell81.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell81, "xEditGridCell81");
            this.xEditGridCell81.IsVisible = false;
            this.xEditGridCell81.Row = -1;
            this.xEditGridCell81.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell83.CellName = "wonnae_drg_yn";
            this.xEditGridCell83.Col = -1;
            this.xEditGridCell83.ExecuteQuery = null;
            this.xEditGridCell83.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell83, "xEditGridCell83");
            this.xEditGridCell83.IsVisible = false;
            this.xEditGridCell83.Row = -1;
            this.xEditGridCell83.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell126
            // 
            this.xEditGridCell126.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell126.CellName = "trial_flg";
            this.xEditGridCell126.Col = -1;
            this.xEditGridCell126.ExecuteQuery = null;
            this.xEditGridCell126.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell126, "xEditGridCell126");
            this.xEditGridCell126.IsVisible = false;
            this.xEditGridCell126.Row = -1;
            this.xEditGridCell126.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // tabSangyongOrder
            // 
            this.tabSangyongOrder.AccessibleDescription = null;
            this.tabSangyongOrder.AccessibleName = null;
            resources.ApplyResources(this.tabSangyongOrder, "tabSangyongOrder");
            this.tabSangyongOrder.BackgroundImage = null;
            this.tabSangyongOrder.IDEPixelArea = true;
            this.tabSangyongOrder.IDEPixelBorder = false;
            this.tabSangyongOrder.Name = "tabSangyongOrder";
            this.toolTip1.SetToolTip(this.tabSangyongOrder, resources.GetString("tabSangyongOrder.ToolTip"));
            // 
            // pnlDrug
            // 
            this.pnlDrug.AccessibleDescription = null;
            this.pnlDrug.AccessibleName = null;
            resources.ApplyResources(this.pnlDrug, "pnlDrug");
            this.pnlDrug.BackgroundImage = null;
            this.pnlDrug.Controls.Add(this.grdDrgOrder);
            this.pnlDrug.Controls.Add(this.tvwDrgBunryu);
            this.pnlDrug.Font = null;
            this.pnlDrug.Name = "pnlDrug";
            this.toolTip1.SetToolTip(this.pnlDrug, resources.GetString("pnlDrug.ToolTip"));
            // 
            // grdDrgOrder
            // 
            resources.ApplyResources(this.grdDrgOrder, "grdDrgOrder");
            this.grdDrgOrder.ApplyPaintEventToAllColumn = true;
            this.grdDrgOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell32,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell84,
            this.xEditGridCell125});
            this.grdDrgOrder.ColPerLine = 2;
            this.grdDrgOrder.Cols = 2;
            this.grdDrgOrder.ExecuteQuery = null;
            this.grdDrgOrder.FixedRows = 1;
            this.grdDrgOrder.HeaderHeights.Add(27);
            this.grdDrgOrder.Name = "grdDrgOrder";
            this.grdDrgOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDrgOrder.ParamList")));
            this.grdDrgOrder.QuerySQL = resources.GetString("grdDrgOrder.QuerySQL");
            this.grdDrgOrder.Rows = 2;
            this.toolTip1.SetToolTip(this.grdDrgOrder, resources.GetString("grdDrgOrder.ToolTip"));
            this.grdDrgOrder.ToolTipActive = true;
            this.grdDrgOrder.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdDrgOrder_GiveFeedback);
            this.grdDrgOrder.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdDrgOrder_DragEnter);
            this.grdDrgOrder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdDrgOrder_MouseDown);
            this.grdDrgOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdDrgOrder_GridCellPainting);
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell24.CellName = "hangmog_code";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            this.xEditGridCell24.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            this.xEditGridCell24.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell25.CellName = "hangmog_name";
            this.xEditGridCell25.CellWidth = 253;
            this.xEditGridCell25.Col = 1;
            this.xEditGridCell25.ExecuteQuery = null;
            this.xEditGridCell25.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell26.CellName = "wonyoi_order_cr_yn";
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.ExecuteQuery = null;
            this.xEditGridCell26.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            this.xEditGridCell26.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell27.CellName = "default_wonyoi_order_yn";
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.ExecuteQuery = null;
            this.xEditGridCell27.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            this.xEditGridCell27.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell32.CellName = "code1";
            this.xEditGridCell32.Col = -1;
            this.xEditGridCell32.ExecuteQuery = null;
            this.xEditGridCell32.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsVisible = false;
            this.xEditGridCell32.Row = -1;
            this.xEditGridCell32.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell36.CellName = "drg_info";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            this.xEditGridCell36.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            this.xEditGridCell36.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell37.CellName = "order_gubun";
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.ExecuteQuery = null;
            this.xEditGridCell37.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            this.xEditGridCell37.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell38.CellName = "order_gubun_name";
            this.xEditGridCell38.CellWidth = 90;
            this.xEditGridCell38.ExecuteQuery = null;
            this.xEditGridCell38.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell84.CellName = "wonnae_drg_yn";
            this.xEditGridCell84.Col = -1;
            this.xEditGridCell84.ExecuteQuery = null;
            this.xEditGridCell84.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell84, "xEditGridCell84");
            this.xEditGridCell84.IsVisible = false;
            this.xEditGridCell84.Row = -1;
            this.xEditGridCell84.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell125
            // 
            this.xEditGridCell125.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell125.CellName = "trial_flg";
            this.xEditGridCell125.Col = -1;
            this.xEditGridCell125.ExecuteQuery = null;
            this.xEditGridCell125.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell125, "xEditGridCell125");
            this.xEditGridCell125.IsVisible = false;
            this.xEditGridCell125.Row = -1;
            this.xEditGridCell125.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // tvwDrgBunryu
            // 
            this.tvwDrgBunryu.AccessibleDescription = null;
            this.tvwDrgBunryu.AccessibleName = null;
            resources.ApplyResources(this.tvwDrgBunryu, "tvwDrgBunryu");
            this.tvwDrgBunryu.BackgroundImage = null;
            this.tvwDrgBunryu.HideSelection = false;
            this.tvwDrgBunryu.ImageList = this.ImageList;
            this.tvwDrgBunryu.Name = "tvwDrgBunryu";
            this.tvwDrgBunryu.ShowRootLines = false;
            this.toolTip1.SetToolTip(this.tvwDrgBunryu, resources.GetString("tvwDrgBunryu.ToolTip"));
            this.tvwDrgBunryu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwDrgBunryu_AfterSelect);
            // 
            // pnlPreview
            // 
            this.pnlPreview.AccessibleDescription = null;
            this.pnlPreview.AccessibleName = null;
            resources.ApplyResources(this.pnlPreview, "pnlPreview");
            this.pnlPreview.BackgroundImage = null;
            this.pnlPreview.Controls.Add(this.grdPreview);
            this.pnlPreview.Font = null;
            this.pnlPreview.Name = "pnlPreview";
            this.toolTip1.SetToolTip(this.pnlPreview, resources.GetString("pnlPreview.ToolTip"));
            // 
            // grdPreview
            // 
            resources.ApplyResources(this.grdPreview, "grdPreview");
            this.grdPreview.ApplyPaintEventToAllColumn = true;
            this.grdPreview.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell65,
            this.xEditGridCell66,
            this.xEditGridCell67,
            this.xEditGridCell68,
            this.xEditGridCell69,
            this.xEditGridCell70,
            this.xEditGridCell71,
            this.xEditGridCell72,
            this.xEditGridCell74,
            this.xEditGridCell91,
            this.xEditGridCell92,
            this.xEditGridCell93});
            this.grdPreview.ColPerLine = 6;
            this.grdPreview.Cols = 6;
            this.grdPreview.ExecuteQuery = null;
            this.grdPreview.FixedRows = 1;
            this.grdPreview.HeaderHeights.Add(0);
            this.grdPreview.Name = "grdPreview";
            this.grdPreview.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPreview.ParamList")));
            this.grdPreview.Rows = 2;
            this.grdPreview.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.toolTip1.SetToolTip(this.grdPreview, resources.GetString("grdPreview.ToolTip"));
            this.grdPreview.ToolTipActive = true;
            this.grdPreview.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdPreview_GridColumnChanged);
            this.grdPreview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdPreview_MouseDown);
            this.grdPreview.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdPreview_GridCellPainting);
            this.grdPreview.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdPreview_GridColumnProtectModify);
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell65.CellName = "group_ser";
            this.xEditGridCell65.Col = -1;
            this.xEditGridCell65.ExecuteQuery = null;
            this.xEditGridCell65.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.IsVisible = false;
            this.xEditGridCell65.Row = -1;
            this.xEditGridCell65.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell66.CellName = "order_gubun";
            this.xEditGridCell66.CellWidth = 72;
            this.xEditGridCell66.ExecuteQuery = null;
            this.xEditGridCell66.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.IsReadOnly = true;
            this.xEditGridCell66.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell67.CellName = "hangmog_name";
            this.xEditGridCell67.CellWidth = 167;
            this.xEditGridCell67.Col = 1;
            this.xEditGridCell67.ExecuteQuery = null;
            this.xEditGridCell67.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell67, "xEditGridCell67");
            this.xEditGridCell67.IsReadOnly = true;
            this.xEditGridCell67.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell68.CellName = "suryang";
            this.xEditGridCell68.CellWidth = 58;
            this.xEditGridCell68.Col = 2;
            this.xEditGridCell68.ExecuteQuery = null;
            this.xEditGridCell68.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell68, "xEditGridCell68");
            this.xEditGridCell68.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell68.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell69.CellName = "hoisu";
            this.xEditGridCell69.CellWidth = 36;
            this.xEditGridCell69.Col = 4;
            this.xEditGridCell69.ExecuteQuery = null;
            this.xEditGridCell69.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell69, "xEditGridCell69");
            this.xEditGridCell69.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell70.CellName = "dc_gubun";
            this.xEditGridCell70.Col = -1;
            this.xEditGridCell70.ExecuteQuery = null;
            this.xEditGridCell70.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell70, "xEditGridCell70");
            this.xEditGridCell70.IsVisible = false;
            this.xEditGridCell70.Row = -1;
            this.xEditGridCell70.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell71.CellName = "nalsu";
            this.xEditGridCell71.Col = -1;
            this.xEditGridCell71.ExecuteQuery = null;
            this.xEditGridCell71.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell71, "xEditGridCell71");
            this.xEditGridCell71.IsVisible = false;
            this.xEditGridCell71.Row = -1;
            this.xEditGridCell71.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell72.CellName = "order_data_yn";
            this.xEditGridCell72.Col = -1;
            this.xEditGridCell72.ExecuteQuery = null;
            this.xEditGridCell72.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell72, "xEditGridCell72");
            this.xEditGridCell72.IsVisible = false;
            this.xEditGridCell72.Row = -1;
            this.xEditGridCell72.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell74.CellName = "row_num";
            this.xEditGridCell74.Col = -1;
            this.xEditGridCell74.ExecuteQuery = null;
            this.xEditGridCell74.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell74, "xEditGridCell74");
            this.xEditGridCell74.IsVisible = false;
            this.xEditGridCell74.Row = -1;
            this.xEditGridCell74.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell91.CellName = "danui";
            this.xEditGridCell91.CellWidth = 41;
            this.xEditGridCell91.Col = 3;
            this.xEditGridCell91.ExecuteQuery = null;
            this.xEditGridCell91.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell91, "xEditGridCell91");
            this.xEditGridCell91.IsReadOnly = true;
            this.xEditGridCell91.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell92.CellName = "donbog_yn";
            this.xEditGridCell92.Col = -1;
            this.xEditGridCell92.ExecuteQuery = null;
            this.xEditGridCell92.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell92, "xEditGridCell92");
            this.xEditGridCell92.IsVisible = false;
            this.xEditGridCell92.Row = -1;
            this.xEditGridCell92.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell93.CellName = "hoisu_name";
            this.xEditGridCell93.CellWidth = 33;
            this.xEditGridCell93.Col = 5;
            this.xEditGridCell93.ExecuteQuery = null;
            this.xEditGridCell93.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell93, "xEditGridCell93");
            this.xEditGridCell93.IsReadOnly = true;
            this.xEditGridCell93.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // pnlSearchTool
            // 
            this.pnlSearchTool.AccessibleDescription = null;
            this.pnlSearchTool.AccessibleName = null;
            resources.ApplyResources(this.pnlSearchTool, "pnlSearchTool");
            this.pnlSearchTool.BackgroundImage = null;
            this.pnlSearchTool.Controls.Add(this.cboSearchCondition);
            this.pnlSearchTool.Controls.Add(this.grbGeneric);
            this.pnlSearchTool.Controls.Add(this.cboQueryCon);
            this.pnlSearchTool.Controls.Add(this.xLabel1);
            this.pnlSearchTool.Controls.Add(this.txtSearch);
            this.pnlSearchTool.Controls.Add(this.xLabel5);
            this.pnlSearchTool.Font = null;
            this.pnlSearchTool.Name = "pnlSearchTool";
            this.toolTip1.SetToolTip(this.pnlSearchTool, resources.GetString("pnlSearchTool.ToolTip"));
            // 
            // cboSearchCondition
            // 
            this.cboSearchCondition.AccessibleDescription = null;
            this.cboSearchCondition.AccessibleName = null;
            resources.ApplyResources(this.cboSearchCondition, "cboSearchCondition");
            this.cboSearchCondition.BackgroundImage = null;
            this.cboSearchCondition.ExecuteQuery = null;
            this.cboSearchCondition.Name = "cboSearchCondition";
            this.cboSearchCondition.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboSearchCondition.ParamList")));
            this.cboSearchCondition.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.toolTip1.SetToolTip(this.cboSearchCondition, resources.GetString("cboSearchCondition.ToolTip"));
            this.cboSearchCondition.SelectedValueChanged += new System.EventHandler(this.cboSearchCondition_SelectedValueChanged);
            // 
            // grbGeneric
            // 
            this.grbGeneric.AccessibleDescription = null;
            this.grbGeneric.AccessibleName = null;
            resources.ApplyResources(this.grbGeneric, "grbGeneric");
            this.grbGeneric.BackgroundImage = null;
            this.grbGeneric.Controls.Add(this.rbtSyouhin);
            this.grbGeneric.Controls.Add(this.rbtGenericSearch);
            this.grbGeneric.Font = null;
            this.grbGeneric.Name = "grbGeneric";
            this.grbGeneric.TabStop = false;
            this.toolTip1.SetToolTip(this.grbGeneric, resources.GetString("grbGeneric.ToolTip"));
            // 
            // rbtSyouhin
            // 
            this.rbtSyouhin.AccessibleDescription = null;
            this.rbtSyouhin.AccessibleName = null;
            resources.ApplyResources(this.rbtSyouhin, "rbtSyouhin");
            this.rbtSyouhin.BackgroundImage = null;
            this.rbtSyouhin.Checked = true;
            this.rbtSyouhin.Name = "rbtSyouhin";
            this.rbtSyouhin.TabStop = true;
            this.toolTip1.SetToolTip(this.rbtSyouhin, resources.GetString("rbtSyouhin.ToolTip"));
            this.rbtSyouhin.UseVisualStyleBackColor = true;
            this.rbtSyouhin.CheckedChanged += new System.EventHandler(this.rbtSyouhin_CheckedChanged);
            // 
            // rbtGenericSearch
            // 
            this.rbtGenericSearch.AccessibleDescription = null;
            this.rbtGenericSearch.AccessibleName = null;
            resources.ApplyResources(this.rbtGenericSearch, "rbtGenericSearch");
            this.rbtGenericSearch.BackgroundImage = null;
            this.rbtGenericSearch.Name = "rbtGenericSearch";
            this.toolTip1.SetToolTip(this.rbtGenericSearch, resources.GetString("rbtGenericSearch.ToolTip"));
            this.rbtGenericSearch.UseVisualStyleBackColor = true;
            // 
            // cboQueryCon
            // 
            this.cboQueryCon.AccessibleDescription = null;
            this.cboQueryCon.AccessibleName = null;
            resources.ApplyResources(this.cboQueryCon, "cboQueryCon");
            this.cboQueryCon.BackgroundImage = null;
            this.cboQueryCon.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2});
            this.cboQueryCon.Name = "cboQueryCon";
            this.toolTip1.SetToolTip(this.cboQueryCon, resources.GetString("cboQueryCon.ToolTip"));
            this.cboQueryCon.SelectedValueChanged += new System.EventHandler(this.cboQueryCon_SelectedValueChanged);
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "%";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "Y";
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            this.toolTip1.SetToolTip(this.xLabel1, resources.GetString("xLabel1.ToolTip"));
            // 
            // txtSearch
            // 
            this.txtSearch.AccessibleDescription = null;
            this.txtSearch.AccessibleName = null;
            resources.ApplyResources(this.txtSearch, "txtSearch");
            this.txtSearch.BackgroundImage = null;
            this.txtSearch.EnterKeyToTab = false;
            this.txtSearch.Name = "txtSearch";
            this.toolTip1.SetToolTip(this.txtSearch, resources.GetString("txtSearch.ToolTip"));
            this.txtSearch.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtSearch_DataValidating);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // xLabel5
            // 
            this.xLabel5.AccessibleDescription = null;
            this.xLabel5.AccessibleName = null;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.Image = null;
            this.xLabel5.Name = "xLabel5";
            this.toolTip1.SetToolTip(this.xLabel5, resources.GetString("xLabel5.ToolTip"));
            // 
            // pnlRightBottom
            // 
            this.pnlRightBottom.AccessibleDescription = null;
            this.pnlRightBottom.AccessibleName = null;
            resources.ApplyResources(this.pnlRightBottom, "pnlRightBottom");
            this.pnlRightBottom.BackgroundImage = null;
            this.pnlRightBottom.Controls.Add(this.btnInsert);
            this.pnlRightBottom.Controls.Add(this.cboInputGubun);
            this.pnlRightBottom.Controls.Add(this.btnSelect);
            this.pnlRightBottom.Controls.Add(this.btnNewSelect);
            this.pnlRightBottom.Controls.Add(this.lblInputGubun);
            this.pnlRightBottom.Font = null;
            this.pnlRightBottom.Name = "pnlRightBottom";
            this.toolTip1.SetToolTip(this.pnlRightBottom, resources.GetString("pnlRightBottom.ToolTip"));
            // 
            // btnInsert
            // 
            this.btnInsert.AccessibleDescription = null;
            this.btnInsert.AccessibleName = null;
            resources.ApplyResources(this.btnInsert, "btnInsert");
            this.btnInsert.BackgroundImage = null;
            this.btnInsert.Image = global::IHIS.OCSA.Properties.Resources.Insert;
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.toolTip1.SetToolTip(this.btnInsert, resources.GetString("btnInsert.ToolTip"));
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleDescription = null;
            this.btnSelect.AccessibleName = null;
            resources.ApplyResources(this.btnSelect, "btnSelect");
            this.btnSelect.BackgroundImage = null;
            this.btnSelect.ImageIndex = 10;
            this.btnSelect.ImageList = this.ImageList;
            this.btnSelect.Name = "btnSelect";
            this.toolTip1.SetToolTip(this.btnSelect, resources.GetString("btnSelect.ToolTip"));
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnNewSelect
            // 
            this.btnNewSelect.AccessibleDescription = null;
            this.btnNewSelect.AccessibleName = null;
            resources.ApplyResources(this.btnNewSelect, "btnNewSelect");
            this.btnNewSelect.BackgroundImage = null;
            this.btnNewSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnNewSelect.Image")));
            this.btnNewSelect.Name = "btnNewSelect";
            this.btnNewSelect.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.toolTip1.SetToolTip(this.btnNewSelect, resources.GetString("btnNewSelect.ToolTip"));
            this.btnNewSelect.Click += new System.EventHandler(this.btnNewSelect_Click);
            // 
            // lblInputGubun
            // 
            this.lblInputGubun.AccessibleDescription = null;
            this.lblInputGubun.AccessibleName = null;
            resources.ApplyResources(this.lblInputGubun, "lblInputGubun");
            this.lblInputGubun.BackColor = IHIS.Framework.XColor.XCalendarFullHolidayTextColor;
            this.lblInputGubun.EdgeRounding = false;
            this.lblInputGubun.Image = null;
            this.lblInputGubun.Name = "lblInputGubun";
            this.toolTip1.SetToolTip(this.lblInputGubun, resources.GetString("lblInputGubun.ToolTip"));
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackColor = IHIS.Framework.XColor.XRoundPanelBackColor;
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.btnExpandSearch);
            this.xPanel2.Controls.Add(this.rbnOrderStatus);
            this.xPanel2.Controls.Add(this.rbnDrgOrder);
            this.xPanel2.Controls.Add(this.rbnOftenOrder);
            this.xPanel2.Controls.Add(this.rbnSearchOrder);
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            this.toolTip1.SetToolTip(this.xPanel2, resources.GetString("xPanel2.ToolTip"));
            // 
            // btnExpandSearch
            // 
            this.btnExpandSearch.AccessibleDescription = null;
            this.btnExpandSearch.AccessibleName = null;
            resources.ApplyResources(this.btnExpandSearch, "btnExpandSearch");
            this.btnExpandSearch.BackgroundImage = null;
            this.btnExpandSearch.ImageIndex = 4;
            this.btnExpandSearch.ImageList = this.ImageList;
            this.btnExpandSearch.Name = "btnExpandSearch";
            this.toolTip1.SetToolTip(this.btnExpandSearch, resources.GetString("btnExpandSearch.ToolTip"));
            this.btnExpandSearch.Click += new System.EventHandler(this.btnExpandSearch_Click);
            // 
            // rbnOrderStatus
            // 
            this.rbnOrderStatus.AccessibleDescription = null;
            this.rbnOrderStatus.AccessibleName = null;
            resources.ApplyResources(this.rbnOrderStatus, "rbnOrderStatus");
            this.rbnOrderStatus.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbnOrderStatus.BackgroundImage = null;
            this.rbnOrderStatus.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbnOrderStatus.ImageList = this.ImageList;
            this.rbnOrderStatus.Name = "rbnOrderStatus";
            this.rbnOrderStatus.TabStop = true;
            this.toolTip1.SetToolTip(this.rbnOrderStatus, resources.GetString("rbnOrderStatus.ToolTip"));
            this.rbnOrderStatus.UseVisualStyleBackColor = false;
            this.rbnOrderStatus.CheckedChanged += new System.EventHandler(this.OrderRadio_CheckedChanged);
            // 
            // rbnDrgOrder
            // 
            this.rbnDrgOrder.AccessibleDescription = null;
            this.rbnDrgOrder.AccessibleName = null;
            resources.ApplyResources(this.rbnDrgOrder, "rbnDrgOrder");
            this.rbnDrgOrder.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbnDrgOrder.BackgroundImage = null;
            this.rbnDrgOrder.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbnDrgOrder.ImageList = this.ImageList;
            this.rbnDrgOrder.Name = "rbnDrgOrder";
            this.rbnDrgOrder.TabStop = true;
            this.toolTip1.SetToolTip(this.rbnDrgOrder, resources.GetString("rbnDrgOrder.ToolTip"));
            this.rbnDrgOrder.UseVisualStyleBackColor = false;
            this.rbnDrgOrder.CheckedChanged += new System.EventHandler(this.OrderRadio_CheckedChanged);
            // 
            // rbnOftenOrder
            // 
            this.rbnOftenOrder.AccessibleDescription = null;
            this.rbnOftenOrder.AccessibleName = null;
            resources.ApplyResources(this.rbnOftenOrder, "rbnOftenOrder");
            this.rbnOftenOrder.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbnOftenOrder.BackgroundImage = null;
            this.rbnOftenOrder.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbnOftenOrder.ImageList = this.ImageList;
            this.rbnOftenOrder.Name = "rbnOftenOrder";
            this.rbnOftenOrder.TabStop = true;
            this.toolTip1.SetToolTip(this.rbnOftenOrder, resources.GetString("rbnOftenOrder.ToolTip"));
            this.rbnOftenOrder.UseVisualStyleBackColor = false;
            this.rbnOftenOrder.CheckedChanged += new System.EventHandler(this.OrderRadio_CheckedChanged);
            // 
            // rbnSearchOrder
            // 
            this.rbnSearchOrder.AccessibleDescription = null;
            this.rbnSearchOrder.AccessibleName = null;
            resources.ApplyResources(this.rbnSearchOrder, "rbnSearchOrder");
            this.rbnSearchOrder.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbnSearchOrder.BackgroundImage = null;
            this.rbnSearchOrder.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbnSearchOrder.ImageList = this.ImageList;
            this.rbnSearchOrder.Name = "rbnSearchOrder";
            this.rbnSearchOrder.TabStop = true;
            this.toolTip1.SetToolTip(this.rbnSearchOrder, resources.GetString("rbnSearchOrder.ToolTip"));
            this.rbnSearchOrder.UseVisualStyleBackColor = false;
            this.rbnSearchOrder.CheckedChanged += new System.EventHandler(this.OrderRadio_CheckedChanged);
            // 
            // pnlOrderInfo
            // 
            this.pnlOrderInfo.AccessibleDescription = null;
            this.pnlOrderInfo.AccessibleName = null;
            resources.ApplyResources(this.pnlOrderInfo, "pnlOrderInfo");
            this.pnlOrderInfo.BackgroundImage = null;
            this.pnlOrderInfo.Controls.Add(this.xPanel4);
            this.pnlOrderInfo.Controls.Add(this.pnlOrderDetail);
            this.pnlOrderInfo.Controls.Add(this.pnlOrderInput);
            this.pnlOrderInfo.Controls.Add(this.grdOutSang);
            this.pnlOrderInfo.Font = null;
            this.pnlOrderInfo.Name = "pnlOrderInfo";
            this.toolTip1.SetToolTip(this.pnlOrderInfo, resources.GetString("pnlOrderInfo.ToolTip"));
            // 
            // xPanel4
            // 
            this.xPanel4.AccessibleDescription = null;
            this.xPanel4.AccessibleName = null;
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.BackgroundImage = null;
            this.xPanel4.Controls.Add(this.pnlStatus);
            this.xPanel4.Controls.Add(this.grdOrder);
            this.xPanel4.Font = null;
            this.xPanel4.Name = "xPanel4";
            this.toolTip1.SetToolTip(this.xPanel4, resources.GetString("xPanel4.ToolTip"));
            // 
            // pnlStatus
            // 
            this.pnlStatus.AccessibleDescription = null;
            this.pnlStatus.AccessibleName = null;
            resources.ApplyResources(this.pnlStatus, "pnlStatus");
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.lbStatus);
            this.pnlStatus.Controls.Add(this.pgbProgress);
            this.pnlStatus.Font = null;
            this.pnlStatus.Name = "pnlStatus";
            this.toolTip1.SetToolTip(this.pnlStatus, resources.GetString("pnlStatus.ToolTip"));
            // 
            // lbStatus
            // 
            this.lbStatus.AccessibleDescription = null;
            this.lbStatus.AccessibleName = null;
            resources.ApplyResources(this.lbStatus, "lbStatus");
            this.lbStatus.BackColor = System.Drawing.Color.Transparent;
            this.lbStatus.ForeColor = System.Drawing.Color.Red;
            this.lbStatus.Name = "lbStatus";
            this.toolTip1.SetToolTip(this.lbStatus, resources.GetString("lbStatus.ToolTip"));
            // 
            // pgbProgress
            // 
            this.pgbProgress.AccessibleDescription = null;
            this.pgbProgress.AccessibleName = null;
            resources.ApplyResources(this.pgbProgress, "pgbProgress");
            this.pgbProgress.BackgroundImage = null;
            this.pgbProgress.Name = "pgbProgress";
            this.toolTip1.SetToolTip(this.pgbProgress, resources.GetString("pgbProgress.ToolTip"));
            // 
            // grdOrder
            // 
            this.grdOrder.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdOrder, "grdOrder");
            this.grdOrder.ApplyPaintEventToAllColumn = true;
            this.grdOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell351,
            this.xEditGridCell34,
            this.xEditGridCell35,
            this.xEditGridCell358,
            this.xEditGridCell359,
            this.xEditGridCell360,
            this.xEditGridCell361,
            this.xEditGridCell362,
            this.xEditGridCell363,
            this.xEditGridCell364,
            this.xEditGridCell365,
            this.xEditGridCell366,
            this.xEditGridCell367,
            this.xEditGridCell368,
            this.xEditGridCell369,
            this.xEditGridCell370,
            this.xEditGridCell371,
            this.xEditGridCell372,
            this.xEditGridCell373,
            this.xEditGridCell374,
            this.xEditGridCell375,
            this.xEditGridCell376,
            this.xEditGridCell377,
            this.xEditGridCell378,
            this.xEditGridCell379,
            this.xEditGridCell380,
            this.xEditGridCell384,
            this.xEditGridCell385,
            this.xEditGridCell386,
            this.xEditGridCell387,
            this.xEditGridCell388,
            this.xEditGridCell389,
            this.xEditGridCell390,
            this.xEditGridCell391,
            this.xEditGridCell392,
            this.xEditGridCell393,
            this.xEditGridCell394,
            this.xEditGridCell395,
            this.xEditGridCell396,
            this.xEditGridCell397,
            this.xEditGridCell398,
            this.xEditGridCell399,
            this.xEditGridCell400,
            this.xEditGridCell401,
            this.xEditGridCell402,
            this.xEditGridCell403,
            this.xEditGridCell404,
            this.xEditGridCell405,
            this.xEditGridCell406,
            this.xEditGridCell407,
            this.xEditGridCell408,
            this.xEditGridCell409,
            this.xEditGridCell410,
            this.xEditGridCell411,
            this.xEditGridCell412,
            this.xEditGridCell413,
            this.xEditGridCell414,
            this.xEditGridCell415,
            this.xEditGridCell416,
            this.xEditGridCell417,
            this.xEditGridCell418,
            this.xEditGridCell419,
            this.xEditGridCell420,
            this.xEditGridCell421,
            this.xEditGridCell422,
            this.xEditGridCell423,
            this.xEditGridCell424,
            this.xEditGridCell425,
            this.xEditGridCell426,
            this.xEditGridCell427,
            this.xEditGridCell428,
            this.xEditGridCell429,
            this.xEditGridCell430,
            this.xEditGridCell431,
            this.xEditGridCell432,
            this.xEditGridCell433,
            this.xEditGridCell434,
            this.xEditGridCell435,
            this.xEditGridCell436,
            this.xEditGridCell437,
            this.xEditGridCell438,
            this.xEditGridCell439,
            this.xEditGridCell440,
            this.xEditGridCell441,
            this.xEditGridCell442,
            this.xEditGridCell443,
            this.xEditGridCell444,
            this.xEditGridCell445,
            this.xEditGridCell446,
            this.xEditGridCell447,
            this.xEditGridCell448,
            this.xEditGridCell449,
            this.xEditGridCell450,
            this.xEditGridCell451,
            this.xEditGridCell452,
            this.xEditGridCell453,
            this.xEditGridCell454,
            this.xEditGridCell455,
            this.xEditGridCell456,
            this.xEditGridCell457,
            this.xEditGridCell458,
            this.xEditGridCell459,
            this.xEditGridCell460,
            this.xEditGridCell461,
            this.xEditGridCell464,
            this.xEditGridCell465,
            this.xEditGridCell466,
            this.xEditGridCell467,
            this.xEditGridCell468,
            this.xEditGridCell469,
            this.xEditGridCell470,
            this.xEditGridCell471,
            this.xEditGridCell472,
            this.xEditGridCell473,
            this.xEditGridCell474,
            this.xEditGridCell475,
            this.xEditGridCell476,
            this.xEditGridCell477,
            this.xEditGridCell478,
            this.xEditGridCell479,
            this.xEditGridCell480,
            this.xEditGridCell481,
            this.xEditGridCell482,
            this.xEditGridCell483,
            this.xEditGridCell484,
            this.xEditGridCell485,
            this.xEditGridCell486,
            this.xEditGridCell487,
            this.xEditGridCell488,
            this.xEditGridCell489,
            this.xEditGridCell490,
            this.xEditGridCell491,
            this.xEditGridCell492,
            this.xEditGridCell41,
            this.xEditGridCell42,
            this.xEditGridCell43,
            this.xEditGridCell44,
            this.xEditGridCell39,
            this.xEditGridCell40,
            this.xEditGridCell45,
            this.xEditGridCell46,
            this.xEditGridCell47,
            this.xEditGridCell48,
            this.xEditGridCell49,
            this.xEditGridCell53,
            this.xEditGridCell54,
            this.xEditGridCell55,
            this.xEditGridCell56,
            this.xEditGridCell57,
            this.xEditGridCell58,
            this.xEditGridCell59,
            this.xEditGridCell61,
            this.xEditGridCell62,
            this.xEditGridCell63,
            this.xEditGridCell64,
            this.xEditGridCell73,
            this.xEditGridCell75,
            this.xEditGridCell76,
            this.xEditGridCell77,
            this.xEditGridCell78,
            this.xEditGridCell79,
            this.xEditGridCell85,
            this.xEditGridCell86,
            this.xEditGridCell87,
            this.xEditGridCell88,
            this.xEditGridCell89,
            this.xEditGridCell90,
            this.xEditGridCell94,
            this.xEditGridCell95,
            this.xEditGridCell100,
            this.xEditGridCell101,
            this.xEditGridCell102,
            this.xEditGridCell103,
            this.xEditGridCell104,
            this.xEditGridCell105,
            this.xEditGridCell106,
            this.xEditGridCell107,
            this.xEditGridCell108,
            this.xEditGridCell119,
            this.xEditGridCell121,
            this.xEditGridCell122,
            this.xEditGridCell123,
            this.xEditGridCell128,
            this.xEditGridCell127,
            this.xEditGridCell129});
            this.grdOrder.ColPerLine = 40;
            this.grdOrder.ColResizable = true;
            this.grdOrder.Cols = 41;
            this.grdOrder.EnableMultiSelection = true;
            this.grdOrder.ExecuteQuery = null;
            this.grdOrder.FixedCols = 1;
            this.grdOrder.FixedRows = 2;
            this.grdOrder.HeaderHeights.Add(37);
            this.grdOrder.HeaderHeights.Add(0);
            this.grdOrder.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1,
            this.xGridHeader2});
            this.grdOrder.Name = "grdOrder";
            this.grdOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOrder.ParamList")));
            this.grdOrder.QuerySQL = resources.GetString("grdOrder.QuerySQL");
            this.grdOrder.RowHeaderVisible = true;
            this.grdOrder.RowResizable = true;
            this.grdOrder.Rows = 3;
            this.grdOrder.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOrder.SelectionModeChangeable = true;
            this.grdOrder.ShowNumberAtRowHeader = false;
            this.grdOrder.TogglingRowSelection = true;
            this.toolTip1.SetToolTip(this.grdOrder, resources.GetString("grdOrder.ToolTip"));
            this.grdOrder.ToolTipActive = true;
            this.grdOrder.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdOrder_GiveFeedback);
            this.grdOrder.Click += new System.EventHandler(this.grdOrder_Click);
            this.grdOrder.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOrder_GridColumnChanged);
            this.grdOrder.GridReservedMemoButtonClick += new IHIS.Framework.GridReservedMemoButtonClickEventHandler(this.grdOrder_GridReservedMemoButtonClick);
            this.grdOrder.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdOrder_DragEnter);
            this.grdOrder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOrder_MouseDown);
            this.grdOrder.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdOrder_DragDrop);
            this.grdOrder.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdOrder_GridFindClick);
            this.grdOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOrder_GridCellPainting);
            this.grdOrder.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdOrder_ItemValueChanging);
            this.grdOrder.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOrder_GridColumnProtectModify);
            // 
            // xEditGridCell351
            // 
            this.xEditGridCell351.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell351.CellName = "pkocskey";
            this.xEditGridCell351.Col = -1;
            this.xEditGridCell351.ExecuteQuery = null;
            this.xEditGridCell351.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell351, "xEditGridCell351");
            this.xEditGridCell351.IsVisible = false;
            this.xEditGridCell351.Row = -1;
            this.xEditGridCell351.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell34.CellName = "memb";
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.ExecuteQuery = null;
            this.xEditGridCell34.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            this.xEditGridCell34.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell35.CellName = "yaksok_code";
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.ExecuteQuery = null;
            this.xEditGridCell35.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            this.xEditGridCell35.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell358
            // 
            this.xEditGridCell358.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell358.CellName = "bunho";
            this.xEditGridCell358.Col = -1;
            this.xEditGridCell358.ExecuteQuery = null;
            this.xEditGridCell358.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell358, "xEditGridCell358");
            this.xEditGridCell358.IsVisible = false;
            this.xEditGridCell358.Row = -1;
            this.xEditGridCell358.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell359
            // 
            this.xEditGridCell359.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell359.CellName = "in_out_key";
            this.xEditGridCell359.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell359.Col = -1;
            this.xEditGridCell359.ExecuteQuery = null;
            this.xEditGridCell359.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell359, "xEditGridCell359");
            this.xEditGridCell359.IsVisible = false;
            this.xEditGridCell359.Row = -1;
            this.xEditGridCell359.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell360
            // 
            this.xEditGridCell360.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell360.CellName = "order_date";
            this.xEditGridCell360.Col = -1;
            this.xEditGridCell360.ExecuteQuery = null;
            this.xEditGridCell360.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell360, "xEditGridCell360");
            this.xEditGridCell360.IsVisible = false;
            this.xEditGridCell360.Row = -1;
            this.xEditGridCell360.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell361
            // 
            this.xEditGridCell361.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell361.CellName = "order_time";
            this.xEditGridCell361.Col = -1;
            this.xEditGridCell361.ExecuteQuery = null;
            this.xEditGridCell361.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell361, "xEditGridCell361");
            this.xEditGridCell361.IsVisible = false;
            this.xEditGridCell361.Row = -1;
            this.xEditGridCell361.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell362
            // 
            this.xEditGridCell362.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell362.CellName = "gwa";
            this.xEditGridCell362.Col = -1;
            this.xEditGridCell362.ExecuteQuery = null;
            this.xEditGridCell362.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell362, "xEditGridCell362");
            this.xEditGridCell362.IsVisible = false;
            this.xEditGridCell362.Row = -1;
            this.xEditGridCell362.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell363
            // 
            this.xEditGridCell363.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell363.CellName = "doctor";
            this.xEditGridCell363.Col = -1;
            this.xEditGridCell363.ExecuteQuery = null;
            this.xEditGridCell363.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell363, "xEditGridCell363");
            this.xEditGridCell363.IsVisible = false;
            this.xEditGridCell363.Row = -1;
            this.xEditGridCell363.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell364
            // 
            this.xEditGridCell364.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell364.CellName = "resident";
            this.xEditGridCell364.Col = -1;
            this.xEditGridCell364.ExecuteQuery = null;
            this.xEditGridCell364.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell364, "xEditGridCell364");
            this.xEditGridCell364.IsVisible = false;
            this.xEditGridCell364.Row = -1;
            this.xEditGridCell364.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell365
            // 
            this.xEditGridCell365.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell365.CellName = "naewon_type";
            this.xEditGridCell365.Col = -1;
            this.xEditGridCell365.ExecuteQuery = null;
            this.xEditGridCell365.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell365, "xEditGridCell365");
            this.xEditGridCell365.IsVisible = false;
            this.xEditGridCell365.Row = -1;
            this.xEditGridCell365.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell366
            // 
            this.xEditGridCell366.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell366.CellName = "input_id";
            this.xEditGridCell366.Col = -1;
            this.xEditGridCell366.ExecuteQuery = null;
            this.xEditGridCell366.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell366, "xEditGridCell366");
            this.xEditGridCell366.IsVisible = false;
            this.xEditGridCell366.Row = -1;
            this.xEditGridCell366.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell367
            // 
            this.xEditGridCell367.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell367.CellName = "input_part";
            this.xEditGridCell367.Col = -1;
            this.xEditGridCell367.ExecuteQuery = null;
            this.xEditGridCell367.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell367, "xEditGridCell367");
            this.xEditGridCell367.IsVisible = false;
            this.xEditGridCell367.Row = -1;
            this.xEditGridCell367.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell368
            // 
            this.xEditGridCell368.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell368.CellName = "input_gwa";
            this.xEditGridCell368.Col = -1;
            this.xEditGridCell368.ExecuteQuery = null;
            this.xEditGridCell368.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell368, "xEditGridCell368");
            this.xEditGridCell368.IsVisible = false;
            this.xEditGridCell368.Row = -1;
            this.xEditGridCell368.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell369
            // 
            this.xEditGridCell369.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell369.CellName = "input_doctor";
            this.xEditGridCell369.Col = -1;
            this.xEditGridCell369.ExecuteQuery = null;
            this.xEditGridCell369.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell369, "xEditGridCell369");
            this.xEditGridCell369.IsVisible = false;
            this.xEditGridCell369.Row = -1;
            this.xEditGridCell369.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell370
            // 
            this.xEditGridCell370.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell370.CellName = "input_gubun";
            this.xEditGridCell370.Col = -1;
            this.xEditGridCell370.ExecuteQuery = null;
            this.xEditGridCell370.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell370, "xEditGridCell370");
            this.xEditGridCell370.IsVisible = false;
            this.xEditGridCell370.Row = -1;
            this.xEditGridCell370.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell371
            // 
            this.xEditGridCell371.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell371.CellName = "input_gubun_name";
            this.xEditGridCell371.CellWidth = 85;
            this.xEditGridCell371.Col = 2;
            this.xEditGridCell371.ExecuteQuery = null;
            this.xEditGridCell371.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell371, "xEditGridCell371");
            this.xEditGridCell371.IsReadOnly = true;
            this.xEditGridCell371.IsUpdatable = false;
            this.xEditGridCell371.IsUpdCol = false;
            this.xEditGridCell371.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell371.RowSpan = 2;
            // 
            // xEditGridCell372
            // 
            this.xEditGridCell372.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell372.CellName = "group_ser";
            this.xEditGridCell372.CellWidth = 36;
            this.xEditGridCell372.Col = 3;
            this.xEditGridCell372.ExecuteQuery = null;
            this.xEditGridCell372.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell372, "xEditGridCell372");
            this.xEditGridCell372.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell372.RowSpan = 2;
            this.xEditGridCell372.SuppressRepeating = true;
            // 
            // xEditGridCell373
            // 
            this.xEditGridCell373.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell373.CellName = "input_tab";
            this.xEditGridCell373.Col = -1;
            this.xEditGridCell373.ExecuteQuery = null;
            this.xEditGridCell373.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell373, "xEditGridCell373");
            this.xEditGridCell373.IsVisible = false;
            this.xEditGridCell373.Row = -1;
            this.xEditGridCell373.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell374
            // 
            this.xEditGridCell374.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell374.CellName = "input_tab_name";
            this.xEditGridCell374.Col = -1;
            this.xEditGridCell374.ExecuteQuery = null;
            this.xEditGridCell374.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell374, "xEditGridCell374");
            this.xEditGridCell374.IsReadOnly = true;
            this.xEditGridCell374.IsUpdatable = false;
            this.xEditGridCell374.IsUpdCol = false;
            this.xEditGridCell374.IsVisible = false;
            this.xEditGridCell374.Row = -1;
            this.xEditGridCell374.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell375
            // 
            this.xEditGridCell375.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell375.CellName = "order_gubun";
            this.xEditGridCell375.Col = -1;
            this.xEditGridCell375.ExecuteQuery = null;
            this.xEditGridCell375.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell375, "xEditGridCell375");
            this.xEditGridCell375.IsVisible = false;
            this.xEditGridCell375.Row = -1;
            this.xEditGridCell375.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell376
            // 
            this.xEditGridCell376.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell376.CellName = "order_gubun_name";
            this.xEditGridCell376.CellWidth = 55;
            this.xEditGridCell376.Col = 6;
            this.xEditGridCell376.ExecuteQuery = null;
            this.xEditGridCell376.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell376, "xEditGridCell376");
            this.xEditGridCell376.IsReadOnly = true;
            this.xEditGridCell376.IsUpdatable = false;
            this.xEditGridCell376.IsUpdCol = false;
            this.xEditGridCell376.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell376.RowSpan = 2;
            this.xEditGridCell376.SuppressRepeating = true;
            this.xEditGridCell376.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell377
            // 
            this.xEditGridCell377.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell377.CellName = "group_yn";
            this.xEditGridCell377.Col = -1;
            this.xEditGridCell377.ExecuteQuery = null;
            this.xEditGridCell377.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell377, "xEditGridCell377");
            this.xEditGridCell377.IsVisible = false;
            this.xEditGridCell377.Row = -1;
            this.xEditGridCell377.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell378
            // 
            this.xEditGridCell378.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell378.CellName = "seq";
            this.xEditGridCell378.Col = -1;
            this.xEditGridCell378.ExecuteQuery = null;
            this.xEditGridCell378.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell378, "xEditGridCell378");
            this.xEditGridCell378.IsVisible = false;
            this.xEditGridCell378.Row = -1;
            this.xEditGridCell378.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell379
            // 
            this.xEditGridCell379.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell379.CellName = "slip_code";
            this.xEditGridCell379.Col = -1;
            this.xEditGridCell379.ExecuteQuery = null;
            this.xEditGridCell379.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell379, "xEditGridCell379");
            this.xEditGridCell379.IsVisible = false;
            this.xEditGridCell379.Row = -1;
            this.xEditGridCell379.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell380
            // 
            this.xEditGridCell380.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell380.AutoTabDataSelected = true;
            this.xEditGridCell380.CellName = "hangmog_code";
            this.xEditGridCell380.CellWidth = 70;
            this.xEditGridCell380.Col = 7;
            this.xEditGridCell380.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell380.ExecuteQuery = null;
            this.xEditGridCell380.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell380, "xEditGridCell380");
            this.xEditGridCell380.ImeMode = IHIS.Framework.ColumnImeMode.Katakana;
            this.xEditGridCell380.IsNotNull = true;
            this.xEditGridCell380.IsUpdatable = false;
            this.xEditGridCell380.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell380.RowSpan = 2;
            this.xEditGridCell380.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell384
            // 
            this.xEditGridCell384.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell384.CellName = "hangmog_name";
            this.xEditGridCell384.CellWidth = 170;
            this.xEditGridCell384.Col = 8;
            this.xEditGridCell384.ExecuteQuery = null;
            this.xEditGridCell384.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell384, "xEditGridCell384");
            this.xEditGridCell384.IsNotNull = true;
            this.xEditGridCell384.IsReadOnly = true;
            this.xEditGridCell384.IsUpdatable = false;
            this.xEditGridCell384.IsUpdCol = false;
            this.xEditGridCell384.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell384.RowSpan = 2;
            // 
            // xEditGridCell385
            // 
            this.xEditGridCell385.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell385.CellName = "specimen_code";
            this.xEditGridCell385.CellWidth = 54;
            this.xEditGridCell385.Col = -1;
            this.xEditGridCell385.ExecuteQuery = null;
            this.xEditGridCell385.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell385, "xEditGridCell385");
            this.xEditGridCell385.IsVisible = false;
            this.xEditGridCell385.Row = -1;
            this.xEditGridCell385.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell386
            // 
            this.xEditGridCell386.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell386.CellName = "specimen_name";
            this.xEditGridCell386.CellWidth = 52;
            this.xEditGridCell386.Col = -1;
            this.xEditGridCell386.ExecuteQuery = null;
            this.xEditGridCell386.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell386, "xEditGridCell386");
            this.xEditGridCell386.IsReadOnly = true;
            this.xEditGridCell386.IsUpdatable = false;
            this.xEditGridCell386.IsUpdCol = false;
            this.xEditGridCell386.IsVisible = false;
            this.xEditGridCell386.Row = -1;
            this.xEditGridCell386.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell387
            // 
            this.xEditGridCell387.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell387.CellName = "suryang";
            this.xEditGridCell387.CellWidth = 42;
            this.xEditGridCell387.Col = 11;
            this.xEditGridCell387.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.xEditGridCell387.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell387.ExecuteQuery = null;
            this.xEditGridCell387.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell387, "xEditGridCell387");
            this.xEditGridCell387.IsNotNull = true;
            this.xEditGridCell387.MaxDropDownItems = 9;
            this.xEditGridCell387.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell387.RowSpan = 2;
            this.xEditGridCell387.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell388
            // 
            this.xEditGridCell388.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell388.CellName = "sunab_suryang";
            this.xEditGridCell388.Col = -1;
            this.xEditGridCell388.ExecuteQuery = null;
            this.xEditGridCell388.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell388, "xEditGridCell388");
            this.xEditGridCell388.IsVisible = false;
            this.xEditGridCell388.Row = -1;
            this.xEditGridCell388.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell389
            // 
            this.xEditGridCell389.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell389.CellName = "subul_suryang";
            this.xEditGridCell389.Col = -1;
            this.xEditGridCell389.ExecuteQuery = null;
            this.xEditGridCell389.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell389, "xEditGridCell389");
            this.xEditGridCell389.IsVisible = false;
            this.xEditGridCell389.Row = -1;
            this.xEditGridCell389.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell390
            // 
            this.xEditGridCell390.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell390.CellName = "ord_danui";
            this.xEditGridCell390.Col = -1;
            this.xEditGridCell390.ExecuteQuery = null;
            this.xEditGridCell390.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell390, "xEditGridCell390");
            this.xEditGridCell390.IsVisible = false;
            this.xEditGridCell390.Row = -1;
            this.xEditGridCell390.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell391
            // 
            this.xEditGridCell391.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell391.AutoTabDataSelected = true;
            this.xEditGridCell391.CellName = "ord_danui_name";
            this.xEditGridCell391.CellWidth = 42;
            this.xEditGridCell391.Col = 12;
            this.xEditGridCell391.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell391.ExecuteQuery = null;
            this.xEditGridCell391.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell391, "xEditGridCell391");
            this.xEditGridCell391.IsUpdCol = false;
            this.xEditGridCell391.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell391.RowSpan = 2;
            // 
            // xEditGridCell392
            // 
            this.xEditGridCell392.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell392.CellName = "dv_time";
            this.xEditGridCell392.CellWidth = 18;
            this.xEditGridCell392.Col = 13;
            this.xEditGridCell392.EditorStyle = IHIS.Framework.XCellEditorStyle.ListBox;
            this.xEditGridCell392.ExecuteQuery = null;
            this.xEditGridCell392.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell392, "xEditGridCell392");
            this.xEditGridCell392.Row = 1;
            this.xEditGridCell392.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell392.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell393
            // 
            this.xEditGridCell393.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell393.CellName = "dv";
            this.xEditGridCell393.CellWidth = 30;
            this.xEditGridCell393.Col = 14;
            this.xEditGridCell393.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.xEditGridCell393.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell393.ExecuteQuery = null;
            this.xEditGridCell393.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell393, "xEditGridCell393");
            this.xEditGridCell393.Row = 1;
            this.xEditGridCell393.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell393.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell394
            // 
            this.xEditGridCell394.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell394.CellName = "dv_1";
            this.xEditGridCell394.CellWidth = 101;
            this.xEditGridCell394.Col = 15;
            this.xEditGridCell394.ExecuteQuery = null;
            this.xEditGridCell394.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell394, "xEditGridCell394");
            this.xEditGridCell394.IsReadOnly = true;
            this.xEditGridCell394.Row = 1;
            this.xEditGridCell394.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell394.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell395
            // 
            this.xEditGridCell395.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell395.CellName = "dv_2";
            this.xEditGridCell395.CellWidth = 30;
            this.xEditGridCell395.Col = 16;
            this.xEditGridCell395.ExecuteQuery = null;
            this.xEditGridCell395.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell395, "xEditGridCell395");
            this.xEditGridCell395.IsReadOnly = true;
            this.xEditGridCell395.Row = 1;
            this.xEditGridCell395.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell395.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell396
            // 
            this.xEditGridCell396.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell396.CellName = "dv_3";
            this.xEditGridCell396.CellWidth = 30;
            this.xEditGridCell396.Col = 17;
            this.xEditGridCell396.ExecuteQuery = null;
            this.xEditGridCell396.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell396, "xEditGridCell396");
            this.xEditGridCell396.IsReadOnly = true;
            this.xEditGridCell396.Row = 1;
            this.xEditGridCell396.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell396.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell397
            // 
            this.xEditGridCell397.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell397.CellName = "dv_4";
            this.xEditGridCell397.CellWidth = 30;
            this.xEditGridCell397.Col = 18;
            this.xEditGridCell397.ExecuteQuery = null;
            this.xEditGridCell397.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell397, "xEditGridCell397");
            this.xEditGridCell397.IsReadOnly = true;
            this.xEditGridCell397.Row = 1;
            this.xEditGridCell397.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell397.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell398
            // 
            this.xEditGridCell398.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell398.CellName = "nalsu";
            this.xEditGridCell398.CellWidth = 33;
            this.xEditGridCell398.Col = -1;
            this.xEditGridCell398.ExecuteQuery = null;
            this.xEditGridCell398.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell398, "xEditGridCell398");
            this.xEditGridCell398.IsNotNull = true;
            this.xEditGridCell398.IsVisible = false;
            this.xEditGridCell398.Row = -1;
            this.xEditGridCell398.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell399
            // 
            this.xEditGridCell399.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell399.CellName = "sunab_nalsu";
            this.xEditGridCell399.Col = -1;
            this.xEditGridCell399.ExecuteQuery = null;
            this.xEditGridCell399.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell399, "xEditGridCell399");
            this.xEditGridCell399.IsVisible = false;
            this.xEditGridCell399.Row = -1;
            this.xEditGridCell399.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell400
            // 
            this.xEditGridCell400.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell400.CellName = "jusa";
            this.xEditGridCell400.CellWidth = 38;
            this.xEditGridCell400.Col = -1;
            this.xEditGridCell400.ExecuteQuery = null;
            this.xEditGridCell400.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell400, "xEditGridCell400");
            this.xEditGridCell400.IsVisible = false;
            this.xEditGridCell400.Row = -1;
            this.xEditGridCell400.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell401
            // 
            this.xEditGridCell401.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell401.CellName = "jusa_name";
            this.xEditGridCell401.Col = -1;
            this.xEditGridCell401.ExecuteQuery = null;
            this.xEditGridCell401.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell401, "xEditGridCell401");
            this.xEditGridCell401.IsReadOnly = true;
            this.xEditGridCell401.IsUpdatable = false;
            this.xEditGridCell401.IsUpdCol = false;
            this.xEditGridCell401.IsVisible = false;
            this.xEditGridCell401.Row = -1;
            this.xEditGridCell401.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell402
            // 
            this.xEditGridCell402.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell402.CellName = "jusa_spd_gubun";
            this.xEditGridCell402.CellWidth = 39;
            this.xEditGridCell402.Col = -1;
            this.xEditGridCell402.ExecuteQuery = null;
            this.xEditGridCell402.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell402, "xEditGridCell402");
            this.xEditGridCell402.IsVisible = false;
            this.xEditGridCell402.Row = -1;
            this.xEditGridCell402.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell403
            // 
            this.xEditGridCell403.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell403.CellName = "bogyong_code";
            this.xEditGridCell403.CellWidth = 54;
            this.xEditGridCell403.Col = -1;
            this.xEditGridCell403.ExecuteQuery = null;
            this.xEditGridCell403.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell403, "xEditGridCell403");
            this.xEditGridCell403.IsVisible = false;
            this.xEditGridCell403.Row = -1;
            this.xEditGridCell403.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell404
            // 
            this.xEditGridCell404.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell404.CellName = "bogyong_name";
            this.xEditGridCell404.CellWidth = 109;
            this.xEditGridCell404.Col = -1;
            this.xEditGridCell404.ExecuteQuery = null;
            this.xEditGridCell404.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell404, "xEditGridCell404");
            this.xEditGridCell404.IsReadOnly = true;
            this.xEditGridCell404.IsVisible = false;
            this.xEditGridCell404.Row = -1;
            this.xEditGridCell404.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell405
            // 
            this.xEditGridCell405.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell405.CellName = "emergency";
            this.xEditGridCell405.CellWidth = 26;
            this.xEditGridCell405.Col = -1;
            this.xEditGridCell405.ExecuteQuery = null;
            this.xEditGridCell405.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell405, "xEditGridCell405");
            this.xEditGridCell405.IsVisible = false;
            this.xEditGridCell405.Row = -1;
            this.xEditGridCell405.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell406
            // 
            this.xEditGridCell406.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell406.CellName = "jaeryo_jundal_yn";
            this.xEditGridCell406.Col = -1;
            this.xEditGridCell406.ExecuteQuery = null;
            this.xEditGridCell406.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell406, "xEditGridCell406");
            this.xEditGridCell406.IsVisible = false;
            this.xEditGridCell406.Row = -1;
            this.xEditGridCell406.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell407
            // 
            this.xEditGridCell407.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell407.CellName = "jundal_table";
            this.xEditGridCell407.Col = -1;
            this.xEditGridCell407.ExecuteQuery = null;
            this.xEditGridCell407.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell407, "xEditGridCell407");
            this.xEditGridCell407.IsVisible = false;
            this.xEditGridCell407.Row = -1;
            this.xEditGridCell407.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell408
            // 
            this.xEditGridCell408.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell408.AutoTabDataSelected = true;
            this.xEditGridCell408.CellName = "jundal_part";
            this.xEditGridCell408.CellWidth = 42;
            this.xEditGridCell408.Col = 31;
            this.xEditGridCell408.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell408.ExecuteQuery = null;
            this.xEditGridCell408.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell408, "xEditGridCell408");
            this.xEditGridCell408.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell408.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell408.RowSpan = 2;
            // 
            // xEditGridCell409
            // 
            this.xEditGridCell409.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell409.CellName = "move_part";
            this.xEditGridCell409.Col = -1;
            this.xEditGridCell409.ExecuteQuery = null;
            this.xEditGridCell409.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell409, "xEditGridCell409");
            this.xEditGridCell409.IsVisible = false;
            this.xEditGridCell409.Row = -1;
            this.xEditGridCell409.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell410
            // 
            this.xEditGridCell410.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell410.CellName = "portable_yn";
            this.xEditGridCell410.Col = -1;
            this.xEditGridCell410.ExecuteQuery = null;
            this.xEditGridCell410.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell410, "xEditGridCell410");
            this.xEditGridCell410.IsVisible = false;
            this.xEditGridCell410.Row = -1;
            this.xEditGridCell410.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell411
            // 
            this.xEditGridCell411.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell411.CellName = "powder_yn";
            this.xEditGridCell411.CellWidth = 42;
            this.xEditGridCell411.Col = 28;
            this.xEditGridCell411.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell411.ExecuteQuery = null;
            this.xEditGridCell411.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell411, "xEditGridCell411");
            this.xEditGridCell411.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell411.RowSpan = 2;
            // 
            // xEditGridCell412
            // 
            this.xEditGridCell412.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell412.CellName = "hubal_change_yn";
            this.xEditGridCell412.CellWidth = 41;
            this.xEditGridCell412.Col = 29;
            this.xEditGridCell412.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell412.ExecuteQuery = null;
            this.xEditGridCell412.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell412, "xEditGridCell412");
            this.xEditGridCell412.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell412.RowSpan = 2;
            // 
            // xEditGridCell413
            // 
            this.xEditGridCell413.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell413.CellName = "pharmacy";
            this.xEditGridCell413.CellWidth = 41;
            this.xEditGridCell413.Col = 26;
            this.xEditGridCell413.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell413.ExecuteQuery = null;
            this.xEditGridCell413.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell413, "xEditGridCell413");
            this.xEditGridCell413.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell413.RowSpan = 2;
            // 
            // xEditGridCell414
            // 
            this.xEditGridCell414.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell414.CellName = "drg_pack_yn";
            this.xEditGridCell414.CellWidth = 41;
            this.xEditGridCell414.Col = 23;
            this.xEditGridCell414.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell414.ExecuteQuery = null;
            this.xEditGridCell414.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell414, "xEditGridCell414");
            this.xEditGridCell414.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell414.RowSpan = 2;
            // 
            // xEditGridCell415
            // 
            this.xEditGridCell415.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell415.CellName = "muhyo";
            this.xEditGridCell415.CellWidth = 42;
            this.xEditGridCell415.Col = 24;
            this.xEditGridCell415.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell415.ExecuteQuery = null;
            this.xEditGridCell415.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell415, "xEditGridCell415");
            this.xEditGridCell415.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell415.RowSpan = 2;
            // 
            // xEditGridCell416
            // 
            this.xEditGridCell416.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell416.CellName = "prn_yn";
            this.xEditGridCell416.CellWidth = 29;
            this.xEditGridCell416.Col = -1;
            this.xEditGridCell416.ExecuteQuery = null;
            this.xEditGridCell416.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell416, "xEditGridCell416");
            this.xEditGridCell416.IsVisible = false;
            this.xEditGridCell416.Row = -1;
            this.xEditGridCell416.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell417
            // 
            this.xEditGridCell417.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell417.CellName = "toiwon_drg_yn";
            this.xEditGridCell417.CellWidth = 70;
            this.xEditGridCell417.Col = 27;
            this.xEditGridCell417.EditorStyle = IHIS.Framework.XCellEditorStyle.ListBox;
            this.xEditGridCell417.ExecuteQuery = null;
            this.xEditGridCell417.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell417, "xEditGridCell417");
            this.xEditGridCell417.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell417.RowSpan = 2;
            // 
            // xEditGridCell418
            // 
            this.xEditGridCell418.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell418.CellName = "prn_nurse";
            this.xEditGridCell418.Col = -1;
            this.xEditGridCell418.ExecuteQuery = null;
            this.xEditGridCell418.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell418, "xEditGridCell418");
            this.xEditGridCell418.IsVisible = false;
            this.xEditGridCell418.Row = -1;
            this.xEditGridCell418.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell419
            // 
            this.xEditGridCell419.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell419.CellName = "append_yn";
            this.xEditGridCell419.Col = -1;
            this.xEditGridCell419.ExecuteQuery = null;
            this.xEditGridCell419.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell419, "xEditGridCell419");
            this.xEditGridCell419.IsVisible = false;
            this.xEditGridCell419.Row = -1;
            this.xEditGridCell419.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell420
            // 
            this.xEditGridCell420.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell420.CellLen = 2000;
            this.xEditGridCell420.CellName = "order_remark";
            this.xEditGridCell420.CellWidth = 49;
            this.xEditGridCell420.Col = 9;
            this.xEditGridCell420.DisplayMemoText = true;
            this.xEditGridCell420.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell420.ExecuteQuery = null;
            this.xEditGridCell420.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell420, "xEditGridCell420");
            this.xEditGridCell420.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell420.ReservedMemoClassName = "IHIS.OCS.ReservedComment";
            this.xEditGridCell420.ReservedMemoFileName = Application.StartupPath +"\\OCSA\\OCS.Lib.CommonForms.dll";
            this.xEditGridCell420.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell420.RowSpan = 2;
            this.xEditGridCell420.ShowReservedMemoButton = true;
            // 
            // xEditGridCell421
            // 
            this.xEditGridCell421.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell421.CellLen = 2000;
            this.xEditGridCell421.CellName = "nurse_remark";
            this.xEditGridCell421.CellWidth = 106;
            this.xEditGridCell421.Col = 34;
            this.xEditGridCell421.DisplayMemoText = true;
            this.xEditGridCell421.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell421.ExecuteQuery = null;
            this.xEditGridCell421.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell421, "xEditGridCell421");
            this.xEditGridCell421.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell421.ReservedMemoClassName = "IHIS.OCS.ReservedComment";
            this.xEditGridCell421.ReservedMemoFileName = Application.StartupPath + "\\OCSA\\OCS.Lib.CommonForms.dll";
            this.xEditGridCell421.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell421.RowSpan = 2;
            this.xEditGridCell421.ShowReservedMemoButton = true;
            // 
            // xEditGridCell422
            // 
            this.xEditGridCell422.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell422.CellName = "mix_group";
            this.xEditGridCell422.Col = -1;
            this.xEditGridCell422.ExecuteQuery = null;
            this.xEditGridCell422.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell422, "xEditGridCell422");
            this.xEditGridCell422.IsVisible = false;
            this.xEditGridCell422.Row = -1;
            this.xEditGridCell422.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell423
            // 
            this.xEditGridCell423.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell423.CellName = "amt";
            this.xEditGridCell423.Col = -1;
            this.xEditGridCell423.ExecuteQuery = null;
            this.xEditGridCell423.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell423, "xEditGridCell423");
            this.xEditGridCell423.IsVisible = false;
            this.xEditGridCell423.Row = -1;
            this.xEditGridCell423.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell424
            // 
            this.xEditGridCell424.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell424.CellName = "pay";
            this.xEditGridCell424.CellWidth = 51;
            this.xEditGridCell424.Col = -1;
            this.xEditGridCell424.ExecuteQuery = null;
            this.xEditGridCell424.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell424, "xEditGridCell424");
            this.xEditGridCell424.IsVisible = false;
            this.xEditGridCell424.Row = -1;
            this.xEditGridCell424.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell425
            // 
            this.xEditGridCell425.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell425.CellName = "wonyoi_order_yn";
            this.xEditGridCell425.CellWidth = 29;
            this.xEditGridCell425.Col = -1;
            this.xEditGridCell425.ExecuteQuery = null;
            this.xEditGridCell425.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell425, "xEditGridCell425");
            this.xEditGridCell425.IsVisible = false;
            this.xEditGridCell425.Row = -1;
            this.xEditGridCell425.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell426
            // 
            this.xEditGridCell426.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell426.CellName = "dangil_gumsa_order_yn";
            this.xEditGridCell426.CellWidth = 31;
            this.xEditGridCell426.Col = -1;
            this.xEditGridCell426.ExecuteQuery = null;
            this.xEditGridCell426.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell426, "xEditGridCell426");
            this.xEditGridCell426.IsVisible = false;
            this.xEditGridCell426.Row = -1;
            this.xEditGridCell426.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell427
            // 
            this.xEditGridCell427.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell427.CellName = "dangil_gumsa_result_yn";
            this.xEditGridCell427.CellWidth = 38;
            this.xEditGridCell427.Col = -1;
            this.xEditGridCell427.ExecuteQuery = null;
            this.xEditGridCell427.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell427, "xEditGridCell427");
            this.xEditGridCell427.IsVisible = false;
            this.xEditGridCell427.Row = -1;
            this.xEditGridCell427.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell428
            // 
            this.xEditGridCell428.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell428.CellName = "bom_occur_yn";
            this.xEditGridCell428.Col = -1;
            this.xEditGridCell428.ExecuteQuery = null;
            this.xEditGridCell428.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell428, "xEditGridCell428");
            this.xEditGridCell428.IsVisible = false;
            this.xEditGridCell428.Row = -1;
            this.xEditGridCell428.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell429
            // 
            this.xEditGridCell429.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell429.CellName = "bom_source_key";
            this.xEditGridCell429.Col = -1;
            this.xEditGridCell429.ExecuteQuery = null;
            this.xEditGridCell429.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell429, "xEditGridCell429");
            this.xEditGridCell429.IsVisible = false;
            this.xEditGridCell429.Row = -1;
            this.xEditGridCell429.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell430
            // 
            this.xEditGridCell430.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell430.CellName = "display_yn";
            this.xEditGridCell430.Col = -1;
            this.xEditGridCell430.ExecuteQuery = null;
            this.xEditGridCell430.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell430, "xEditGridCell430");
            this.xEditGridCell430.IsVisible = false;
            this.xEditGridCell430.Row = -1;
            this.xEditGridCell430.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell431
            // 
            this.xEditGridCell431.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell431.CellName = "sunab_yn";
            this.xEditGridCell431.Col = -1;
            this.xEditGridCell431.ExecuteQuery = null;
            this.xEditGridCell431.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell431, "xEditGridCell431");
            this.xEditGridCell431.IsVisible = false;
            this.xEditGridCell431.Row = -1;
            this.xEditGridCell431.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell432
            // 
            this.xEditGridCell432.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell432.CellName = "sunab_date";
            this.xEditGridCell432.Col = -1;
            this.xEditGridCell432.ExecuteQuery = null;
            this.xEditGridCell432.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell432, "xEditGridCell432");
            this.xEditGridCell432.IsVisible = false;
            this.xEditGridCell432.Row = -1;
            this.xEditGridCell432.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell433
            // 
            this.xEditGridCell433.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell433.CellName = "sunab_time";
            this.xEditGridCell433.Col = -1;
            this.xEditGridCell433.ExecuteQuery = null;
            this.xEditGridCell433.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell433, "xEditGridCell433");
            this.xEditGridCell433.IsVisible = false;
            this.xEditGridCell433.Row = -1;
            this.xEditGridCell433.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell434
            // 
            this.xEditGridCell434.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell434.CellName = "hope_date";
            this.xEditGridCell434.CellWidth = 55;
            this.xEditGridCell434.Col = 10;
            this.xEditGridCell434.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell434.ExecuteQuery = null;
            this.xEditGridCell434.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell434, "xEditGridCell434");
            this.xEditGridCell434.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell434.RowSpan = 2;
            // 
            // xEditGridCell435
            // 
            this.xEditGridCell435.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell435.CellName = "hope_time";
            this.xEditGridCell435.Col = -1;
            this.xEditGridCell435.ExecuteQuery = null;
            this.xEditGridCell435.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell435, "xEditGridCell435");
            this.xEditGridCell435.IsVisible = false;
            this.xEditGridCell435.Row = -1;
            this.xEditGridCell435.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell436
            // 
            this.xEditGridCell436.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell436.CellName = "nurse_confirm_user";
            this.xEditGridCell436.Col = -1;
            this.xEditGridCell436.ExecuteQuery = null;
            this.xEditGridCell436.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell436, "xEditGridCell436");
            this.xEditGridCell436.IsVisible = false;
            this.xEditGridCell436.Row = -1;
            this.xEditGridCell436.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell437
            // 
            this.xEditGridCell437.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell437.CellName = "nurse_confirm_date";
            this.xEditGridCell437.Col = -1;
            this.xEditGridCell437.ExecuteQuery = null;
            this.xEditGridCell437.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell437, "xEditGridCell437");
            this.xEditGridCell437.IsVisible = false;
            this.xEditGridCell437.Row = -1;
            this.xEditGridCell437.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell438
            // 
            this.xEditGridCell438.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell438.CellName = "nurse_confirm_time";
            this.xEditGridCell438.Col = -1;
            this.xEditGridCell438.ExecuteQuery = null;
            this.xEditGridCell438.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell438, "xEditGridCell438");
            this.xEditGridCell438.IsVisible = false;
            this.xEditGridCell438.Row = -1;
            this.xEditGridCell438.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell439
            // 
            this.xEditGridCell439.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell439.CellName = "nurse_pickup_user";
            this.xEditGridCell439.Col = -1;
            this.xEditGridCell439.ExecuteQuery = null;
            this.xEditGridCell439.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell439, "xEditGridCell439");
            this.xEditGridCell439.IsVisible = false;
            this.xEditGridCell439.Row = -1;
            this.xEditGridCell439.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell440
            // 
            this.xEditGridCell440.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell440.CellName = "nurse_pickup_date";
            this.xEditGridCell440.Col = -1;
            this.xEditGridCell440.ExecuteQuery = null;
            this.xEditGridCell440.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell440, "xEditGridCell440");
            this.xEditGridCell440.IsVisible = false;
            this.xEditGridCell440.Row = -1;
            this.xEditGridCell440.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell441
            // 
            this.xEditGridCell441.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell441.CellName = "nurse_pickup_time";
            this.xEditGridCell441.Col = -1;
            this.xEditGridCell441.ExecuteQuery = null;
            this.xEditGridCell441.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell441, "xEditGridCell441");
            this.xEditGridCell441.IsVisible = false;
            this.xEditGridCell441.Row = -1;
            this.xEditGridCell441.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell442
            // 
            this.xEditGridCell442.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell442.CellName = "nurse_hold_user";
            this.xEditGridCell442.Col = -1;
            this.xEditGridCell442.ExecuteQuery = null;
            this.xEditGridCell442.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell442, "xEditGridCell442");
            this.xEditGridCell442.IsVisible = false;
            this.xEditGridCell442.Row = -1;
            this.xEditGridCell442.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell443
            // 
            this.xEditGridCell443.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell443.CellName = "nurse_hold_date";
            this.xEditGridCell443.Col = -1;
            this.xEditGridCell443.ExecuteQuery = null;
            this.xEditGridCell443.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell443, "xEditGridCell443");
            this.xEditGridCell443.IsVisible = false;
            this.xEditGridCell443.Row = -1;
            this.xEditGridCell443.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell444
            // 
            this.xEditGridCell444.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell444.CellName = "nurse_hold_time";
            this.xEditGridCell444.Col = -1;
            this.xEditGridCell444.ExecuteQuery = null;
            this.xEditGridCell444.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell444, "xEditGridCell444");
            this.xEditGridCell444.IsVisible = false;
            this.xEditGridCell444.Row = -1;
            this.xEditGridCell444.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell445
            // 
            this.xEditGridCell445.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell445.CellName = "reser_date";
            this.xEditGridCell445.Col = -1;
            this.xEditGridCell445.ExecuteQuery = null;
            this.xEditGridCell445.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell445, "xEditGridCell445");
            this.xEditGridCell445.IsVisible = false;
            this.xEditGridCell445.Row = -1;
            this.xEditGridCell445.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell446
            // 
            this.xEditGridCell446.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell446.CellName = "reser_time";
            this.xEditGridCell446.Col = -1;
            this.xEditGridCell446.ExecuteQuery = null;
            this.xEditGridCell446.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell446, "xEditGridCell446");
            this.xEditGridCell446.IsVisible = false;
            this.xEditGridCell446.Row = -1;
            this.xEditGridCell446.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell447
            // 
            this.xEditGridCell447.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell447.CellName = "jubsu_date";
            this.xEditGridCell447.Col = -1;
            this.xEditGridCell447.ExecuteQuery = null;
            this.xEditGridCell447.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell447, "xEditGridCell447");
            this.xEditGridCell447.IsVisible = false;
            this.xEditGridCell447.Row = -1;
            this.xEditGridCell447.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell448
            // 
            this.xEditGridCell448.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell448.CellName = "jubsu_time";
            this.xEditGridCell448.Col = -1;
            this.xEditGridCell448.ExecuteQuery = null;
            this.xEditGridCell448.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell448, "xEditGridCell448");
            this.xEditGridCell448.IsVisible = false;
            this.xEditGridCell448.Row = -1;
            this.xEditGridCell448.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell449
            // 
            this.xEditGridCell449.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell449.CellName = "acting_date";
            this.xEditGridCell449.Col = -1;
            this.xEditGridCell449.ExecuteQuery = null;
            this.xEditGridCell449.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell449, "xEditGridCell449");
            this.xEditGridCell449.IsVisible = false;
            this.xEditGridCell449.Row = -1;
            this.xEditGridCell449.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell450
            // 
            this.xEditGridCell450.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell450.CellName = "acting_time";
            this.xEditGridCell450.Col = -1;
            this.xEditGridCell450.ExecuteQuery = null;
            this.xEditGridCell450.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell450, "xEditGridCell450");
            this.xEditGridCell450.IsVisible = false;
            this.xEditGridCell450.Row = -1;
            this.xEditGridCell450.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell451
            // 
            this.xEditGridCell451.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell451.CellName = "acting_day";
            this.xEditGridCell451.Col = -1;
            this.xEditGridCell451.ExecuteQuery = null;
            this.xEditGridCell451.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell451, "xEditGridCell451");
            this.xEditGridCell451.IsVisible = false;
            this.xEditGridCell451.Row = -1;
            this.xEditGridCell451.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell452
            // 
            this.xEditGridCell452.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell452.CellName = "result_date";
            this.xEditGridCell452.Col = -1;
            this.xEditGridCell452.ExecuteQuery = null;
            this.xEditGridCell452.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell452, "xEditGridCell452");
            this.xEditGridCell452.IsVisible = false;
            this.xEditGridCell452.Row = -1;
            this.xEditGridCell452.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell453
            // 
            this.xEditGridCell453.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell453.CellName = "dc_gubun";
            this.xEditGridCell453.CellWidth = 84;
            this.xEditGridCell453.Col = 1;
            this.xEditGridCell453.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell453.ExecuteQuery = null;
            this.xEditGridCell453.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell453, "xEditGridCell453");
            this.xEditGridCell453.IsReadOnly = true;
            this.xEditGridCell453.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell453.RowSpan = 2;
            // 
            // xEditGridCell454
            // 
            this.xEditGridCell454.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell454.CellName = "dc_yn";
            this.xEditGridCell454.Col = -1;
            this.xEditGridCell454.ExecuteQuery = null;
            this.xEditGridCell454.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell454, "xEditGridCell454");
            this.xEditGridCell454.IsVisible = false;
            this.xEditGridCell454.Row = -1;
            this.xEditGridCell454.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell455
            // 
            this.xEditGridCell455.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell455.CellName = "bannab_yn";
            this.xEditGridCell455.Col = -1;
            this.xEditGridCell455.ExecuteQuery = null;
            this.xEditGridCell455.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell455, "xEditGridCell455");
            this.xEditGridCell455.IsVisible = false;
            this.xEditGridCell455.Row = -1;
            this.xEditGridCell455.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell456
            // 
            this.xEditGridCell456.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell456.CellName = "bannab_confirm";
            this.xEditGridCell456.Col = -1;
            this.xEditGridCell456.ExecuteQuery = null;
            this.xEditGridCell456.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell456, "xEditGridCell456");
            this.xEditGridCell456.IsVisible = false;
            this.xEditGridCell456.Row = -1;
            this.xEditGridCell456.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell457
            // 
            this.xEditGridCell457.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell457.CellName = "source_ord_key";
            this.xEditGridCell457.Col = -1;
            this.xEditGridCell457.ExecuteQuery = null;
            this.xEditGridCell457.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell457, "xEditGridCell457");
            this.xEditGridCell457.IsVisible = false;
            this.xEditGridCell457.Row = -1;
            this.xEditGridCell457.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell458
            // 
            this.xEditGridCell458.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell458.CellName = "ocs_flag";
            this.xEditGridCell458.Col = -1;
            this.xEditGridCell458.ExecuteQuery = null;
            this.xEditGridCell458.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell458, "xEditGridCell458");
            this.xEditGridCell458.IsVisible = false;
            this.xEditGridCell458.Row = -1;
            this.xEditGridCell458.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell459
            // 
            this.xEditGridCell459.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell459.CellName = "sg_code";
            this.xEditGridCell459.Col = -1;
            this.xEditGridCell459.ExecuteQuery = null;
            this.xEditGridCell459.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell459, "xEditGridCell459");
            this.xEditGridCell459.IsVisible = false;
            this.xEditGridCell459.Row = -1;
            this.xEditGridCell459.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell460
            // 
            this.xEditGridCell460.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell460.CellName = "sg_ymd";
            this.xEditGridCell460.Col = -1;
            this.xEditGridCell460.ExecuteQuery = null;
            this.xEditGridCell460.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell460, "xEditGridCell460");
            this.xEditGridCell460.IsVisible = false;
            this.xEditGridCell460.Row = -1;
            this.xEditGridCell460.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell461
            // 
            this.xEditGridCell461.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell461.CellName = "io_gubun";
            this.xEditGridCell461.Col = -1;
            this.xEditGridCell461.ExecuteQuery = null;
            this.xEditGridCell461.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell461, "xEditGridCell461");
            this.xEditGridCell461.IsVisible = false;
            this.xEditGridCell461.Row = -1;
            this.xEditGridCell461.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell464
            // 
            this.xEditGridCell464.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell464.CellName = "after_act_yn";
            this.xEditGridCell464.Col = -1;
            this.xEditGridCell464.ExecuteQuery = null;
            this.xEditGridCell464.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell464, "xEditGridCell464");
            this.xEditGridCell464.IsVisible = false;
            this.xEditGridCell464.Row = -1;
            this.xEditGridCell464.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell465
            // 
            this.xEditGridCell465.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell465.CellName = "bichi_yn";
            this.xEditGridCell465.CellWidth = 42;
            this.xEditGridCell465.Col = 25;
            this.xEditGridCell465.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell465.ExecuteQuery = null;
            this.xEditGridCell465.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell465, "xEditGridCell465");
            this.xEditGridCell465.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell465.RowSpan = 2;
            // 
            // xEditGridCell466
            // 
            this.xEditGridCell466.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell466.CellName = "drg_bunho";
            this.xEditGridCell466.Col = -1;
            this.xEditGridCell466.ExecuteQuery = null;
            this.xEditGridCell466.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell466, "xEditGridCell466");
            this.xEditGridCell466.IsVisible = false;
            this.xEditGridCell466.Row = -1;
            this.xEditGridCell466.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell467
            // 
            this.xEditGridCell467.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell467.CellName = "sub_susul";
            this.xEditGridCell467.Col = -1;
            this.xEditGridCell467.ExecuteQuery = null;
            this.xEditGridCell467.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell467, "xEditGridCell467");
            this.xEditGridCell467.IsVisible = false;
            this.xEditGridCell467.Row = -1;
            this.xEditGridCell467.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell468
            // 
            this.xEditGridCell468.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell468.CellName = "print_yn";
            this.xEditGridCell468.Col = -1;
            this.xEditGridCell468.ExecuteQuery = null;
            this.xEditGridCell468.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell468, "xEditGridCell468");
            this.xEditGridCell468.IsVisible = false;
            this.xEditGridCell468.Row = -1;
            this.xEditGridCell468.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell469
            // 
            this.xEditGridCell469.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell469.CellName = "chisik";
            this.xEditGridCell469.Col = -1;
            this.xEditGridCell469.ExecuteQuery = null;
            this.xEditGridCell469.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell469, "xEditGridCell469");
            this.xEditGridCell469.IsVisible = false;
            this.xEditGridCell469.Row = -1;
            this.xEditGridCell469.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell470
            // 
            this.xEditGridCell470.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell470.CellName = "sanmo_fkinp1001";
            this.xEditGridCell470.Col = -1;
            this.xEditGridCell470.ExecuteQuery = null;
            this.xEditGridCell470.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell470, "xEditGridCell470");
            this.xEditGridCell470.IsVisible = false;
            this.xEditGridCell470.Row = -1;
            this.xEditGridCell470.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell471
            // 
            this.xEditGridCell471.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell471.CellName = "tel_yn";
            this.xEditGridCell471.Col = -1;
            this.xEditGridCell471.ExecuteQuery = null;
            this.xEditGridCell471.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell471, "xEditGridCell471");
            this.xEditGridCell471.IsVisible = false;
            this.xEditGridCell471.Row = -1;
            this.xEditGridCell471.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell472
            // 
            this.xEditGridCell472.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell472.CellName = "order_gubun_bas";
            this.xEditGridCell472.Col = -1;
            this.xEditGridCell472.ExecuteQuery = null;
            this.xEditGridCell472.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell472, "xEditGridCell472");
            this.xEditGridCell472.IsVisible = false;
            this.xEditGridCell472.Row = -1;
            this.xEditGridCell472.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell473
            // 
            this.xEditGridCell473.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell473.CellName = "input_control";
            this.xEditGridCell473.Col = -1;
            this.xEditGridCell473.ExecuteQuery = null;
            this.xEditGridCell473.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell473, "xEditGridCell473");
            this.xEditGridCell473.IsVisible = false;
            this.xEditGridCell473.Row = -1;
            this.xEditGridCell473.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell474
            // 
            this.xEditGridCell474.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell474.CellName = "suga_yn";
            this.xEditGridCell474.Col = -1;
            this.xEditGridCell474.ExecuteQuery = null;
            this.xEditGridCell474.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell474, "xEditGridCell474");
            this.xEditGridCell474.IsVisible = false;
            this.xEditGridCell474.Row = -1;
            this.xEditGridCell474.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell475
            // 
            this.xEditGridCell475.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell475.CellName = "jaeryo_yn";
            this.xEditGridCell475.Col = -1;
            this.xEditGridCell475.ExecuteQuery = null;
            this.xEditGridCell475.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell475, "xEditGridCell475");
            this.xEditGridCell475.IsVisible = false;
            this.xEditGridCell475.Row = -1;
            this.xEditGridCell475.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell476
            // 
            this.xEditGridCell476.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell476.CellName = "wonyoi_check";
            this.xEditGridCell476.Col = -1;
            this.xEditGridCell476.ExecuteQuery = null;
            this.xEditGridCell476.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell476, "xEditGridCell476");
            this.xEditGridCell476.IsVisible = false;
            this.xEditGridCell476.Row = -1;
            this.xEditGridCell476.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell477
            // 
            this.xEditGridCell477.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell477.CellName = "emergency_check";
            this.xEditGridCell477.Col = -1;
            this.xEditGridCell477.ExecuteQuery = null;
            this.xEditGridCell477.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell477, "xEditGridCell477");
            this.xEditGridCell477.IsVisible = false;
            this.xEditGridCell477.Row = -1;
            this.xEditGridCell477.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell478
            // 
            this.xEditGridCell478.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell478.CellName = "specimen_check";
            this.xEditGridCell478.Col = -1;
            this.xEditGridCell478.ExecuteQuery = null;
            this.xEditGridCell478.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell478, "xEditGridCell478");
            this.xEditGridCell478.IsVisible = false;
            this.xEditGridCell478.Row = -1;
            this.xEditGridCell478.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell479
            // 
            this.xEditGridCell479.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell479.CellName = "portable_check";
            this.xEditGridCell479.Col = -1;
            this.xEditGridCell479.ExecuteQuery = null;
            this.xEditGridCell479.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell479, "xEditGridCell479");
            this.xEditGridCell479.IsVisible = false;
            this.xEditGridCell479.Row = -1;
            this.xEditGridCell479.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell480
            // 
            this.xEditGridCell480.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell480.CellName = "bulyong_check";
            this.xEditGridCell480.Col = -1;
            this.xEditGridCell480.ExecuteQuery = null;
            this.xEditGridCell480.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell480, "xEditGridCell480");
            this.xEditGridCell480.IsVisible = false;
            this.xEditGridCell480.Row = -1;
            this.xEditGridCell480.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell481
            // 
            this.xEditGridCell481.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell481.CellName = "sunab_check";
            this.xEditGridCell481.Col = -1;
            this.xEditGridCell481.ExecuteQuery = null;
            this.xEditGridCell481.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell481, "xEditGridCell481");
            this.xEditGridCell481.IsVisible = false;
            this.xEditGridCell481.Row = -1;
            this.xEditGridCell481.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell482
            // 
            this.xEditGridCell482.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell482.CellName = "dc_check";
            this.xEditGridCell482.Col = -1;
            this.xEditGridCell482.ExecuteQuery = null;
            this.xEditGridCell482.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell482, "xEditGridCell482");
            this.xEditGridCell482.IsVisible = false;
            this.xEditGridCell482.Row = -1;
            this.xEditGridCell482.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell483
            // 
            this.xEditGridCell483.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell483.CellName = "dc_gubun_check";
            this.xEditGridCell483.Col = -1;
            this.xEditGridCell483.ExecuteQuery = null;
            this.xEditGridCell483.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell483, "xEditGridCell483");
            this.xEditGridCell483.IsVisible = false;
            this.xEditGridCell483.Row = -1;
            this.xEditGridCell483.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell484
            // 
            this.xEditGridCell484.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell484.CellName = "confirm_check";
            this.xEditGridCell484.Col = -1;
            this.xEditGridCell484.ExecuteQuery = null;
            this.xEditGridCell484.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell484, "xEditGridCell484");
            this.xEditGridCell484.IsVisible = false;
            this.xEditGridCell484.Row = -1;
            this.xEditGridCell484.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell485
            // 
            this.xEditGridCell485.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell485.CellName = "reser_yn_check";
            this.xEditGridCell485.Col = -1;
            this.xEditGridCell485.ExecuteQuery = null;
            this.xEditGridCell485.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell485, "xEditGridCell485");
            this.xEditGridCell485.IsVisible = false;
            this.xEditGridCell485.Row = -1;
            this.xEditGridCell485.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell486
            // 
            this.xEditGridCell486.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell486.CellName = "chisik_check";
            this.xEditGridCell486.Col = -1;
            this.xEditGridCell486.ExecuteQuery = null;
            this.xEditGridCell486.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell486, "xEditGridCell486");
            this.xEditGridCell486.IsVisible = false;
            this.xEditGridCell486.Row = -1;
            this.xEditGridCell486.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell487
            // 
            this.xEditGridCell487.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell487.CellName = "nday_yn";
            this.xEditGridCell487.Col = -1;
            this.xEditGridCell487.ExecuteQuery = null;
            this.xEditGridCell487.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell487, "xEditGridCell487");
            this.xEditGridCell487.IsVisible = false;
            this.xEditGridCell487.Row = -1;
            this.xEditGridCell487.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell488
            // 
            this.xEditGridCell488.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell488.CellName = "default_jaeryo_jundal_yn";
            this.xEditGridCell488.Col = -1;
            this.xEditGridCell488.ExecuteQuery = null;
            this.xEditGridCell488.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell488, "xEditGridCell488");
            this.xEditGridCell488.IsVisible = false;
            this.xEditGridCell488.Row = -1;
            this.xEditGridCell488.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell489
            // 
            this.xEditGridCell489.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell489.CellName = "default_wonyoi_order_yn";
            this.xEditGridCell489.Col = -1;
            this.xEditGridCell489.ExecuteQuery = null;
            this.xEditGridCell489.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell489, "xEditGridCell489");
            this.xEditGridCell489.IsVisible = false;
            this.xEditGridCell489.Row = -1;
            this.xEditGridCell489.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell490
            // 
            this.xEditGridCell490.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell490.CellName = "specific_comments";
            this.xEditGridCell490.Col = -1;
            this.xEditGridCell490.ExecuteQuery = null;
            this.xEditGridCell490.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell490, "xEditGridCell490");
            this.xEditGridCell490.IsVisible = false;
            this.xEditGridCell490.Row = -1;
            this.xEditGridCell490.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell491
            // 
            this.xEditGridCell491.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell491.CellName = "specific_comment_name";
            this.xEditGridCell491.Col = -1;
            this.xEditGridCell491.ExecuteQuery = null;
            this.xEditGridCell491.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell491, "xEditGridCell491");
            this.xEditGridCell491.IsVisible = false;
            this.xEditGridCell491.Row = -1;
            this.xEditGridCell491.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell492
            // 
            this.xEditGridCell492.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell492.CellName = "specific_comment_sys_id";
            this.xEditGridCell492.Col = -1;
            this.xEditGridCell492.ExecuteQuery = null;
            this.xEditGridCell492.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell492, "xEditGridCell492");
            this.xEditGridCell492.IsVisible = false;
            this.xEditGridCell492.Row = -1;
            this.xEditGridCell492.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell41.CellName = "specific_comment_pgm_id";
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.ExecuteQuery = null;
            this.xEditGridCell41.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            this.xEditGridCell41.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell42.CellName = "specific_comment_not_null";
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.ExecuteQuery = null;
            this.xEditGridCell42.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            this.xEditGridCell42.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell43.CellName = "specific_comment_table_id";
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.ExecuteQuery = null;
            this.xEditGridCell43.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            this.xEditGridCell43.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell44.CellName = "specific_comment_col_id";
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.ExecuteQuery = null;
            this.xEditGridCell44.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            this.xEditGridCell44.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell39.CellName = "donbog_yn";
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.ExecuteQuery = null;
            this.xEditGridCell39.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            this.xEditGridCell39.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell40.CellName = "order_gubun_bas_name";
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.ExecuteQuery = null;
            this.xEditGridCell40.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            this.xEditGridCell40.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell45.CellName = "act_doctor";
            this.xEditGridCell45.Col = -1;
            this.xEditGridCell45.ExecuteQuery = null;
            this.xEditGridCell45.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.IsVisible = false;
            this.xEditGridCell45.Row = -1;
            this.xEditGridCell45.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell46.CellName = "act_buseo";
            this.xEditGridCell46.Col = -1;
            this.xEditGridCell46.ExecuteQuery = null;
            this.xEditGridCell46.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
            this.xEditGridCell46.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell47.CellName = "act_gwa";
            this.xEditGridCell47.Col = -1;
            this.xEditGridCell47.ExecuteQuery = null;
            this.xEditGridCell47.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsVisible = false;
            this.xEditGridCell47.Row = -1;
            this.xEditGridCell47.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell48.CellName = "home_care_yn";
            this.xEditGridCell48.CellWidth = 36;
            this.xEditGridCell48.Col = 35;
            this.xEditGridCell48.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell48.ExecuteQuery = null;
            this.xEditGridCell48.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            this.xEditGridCell48.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell48.RowSpan = 2;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell49.CellName = "regular_yn";
            this.xEditGridCell49.CellWidth = 35;
            this.xEditGridCell49.Col = 4;
            this.xEditGridCell49.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell49.ExecuteQuery = null;
            this.xEditGridCell49.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            this.xEditGridCell49.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell49.RowSpan = 2;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell53.CellName = "sort_fkocskey";
            this.xEditGridCell53.Col = -1;
            this.xEditGridCell53.ExecuteQuery = null;
            this.xEditGridCell53.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            this.xEditGridCell53.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell54.CellName = "jubsu_no";
            this.xEditGridCell54.Col = -1;
            this.xEditGridCell54.ExecuteQuery = null;
            this.xEditGridCell54.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.IsVisible = false;
            this.xEditGridCell54.Row = -1;
            this.xEditGridCell54.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell55.CellName = "ref_fkocs2003";
            this.xEditGridCell55.Col = -1;
            this.xEditGridCell55.ExecuteQuery = null;
            this.xEditGridCell55.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.IsVisible = false;
            this.xEditGridCell55.Row = -1;
            this.xEditGridCell55.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell56.CellName = "jaewonil";
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.ExecuteQuery = null;
            this.xEditGridCell56.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            this.xEditGridCell56.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell57.CellName = "app_yn";
            this.xEditGridCell57.Col = -1;
            this.xEditGridCell57.ExecuteQuery = null;
            this.xEditGridCell57.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell57, "xEditGridCell57");
            this.xEditGridCell57.IsVisible = false;
            this.xEditGridCell57.Row = -1;
            this.xEditGridCell57.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell58.CellName = "order_end_yn";
            this.xEditGridCell58.Col = -1;
            this.xEditGridCell58.ExecuteQuery = null;
            this.xEditGridCell58.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell58, "xEditGridCell58");
            this.xEditGridCell58.IsVisible = false;
            this.xEditGridCell58.Row = -1;
            this.xEditGridCell58.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell59.CellName = "nday_occur_yn";
            this.xEditGridCell59.Col = -1;
            this.xEditGridCell59.ExecuteQuery = null;
            this.xEditGridCell59.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
            this.xEditGridCell59.IsVisible = false;
            this.xEditGridCell59.Row = -1;
            this.xEditGridCell59.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell61.CellName = "bun_code";
            this.xEditGridCell61.Col = -1;
            this.xEditGridCell61.ExecuteQuery = null;
            this.xEditGridCell61.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.IsVisible = false;
            this.xEditGridCell61.Row = -1;
            this.xEditGridCell61.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell62.CellName = "cp_code";
            this.xEditGridCell62.Col = -1;
            this.xEditGridCell62.ExecuteQuery = null;
            this.xEditGridCell62.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.IsVisible = false;
            this.xEditGridCell62.Row = -1;
            this.xEditGridCell62.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell63.CellName = "cp_path_code";
            this.xEditGridCell63.Col = -1;
            this.xEditGridCell63.ExecuteQuery = null;
            this.xEditGridCell63.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsVisible = false;
            this.xEditGridCell63.Row = -1;
            this.xEditGridCell63.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell64.CellName = "memb_gubun";
            this.xEditGridCell64.Col = -1;
            this.xEditGridCell64.ExecuteQuery = null;
            this.xEditGridCell64.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.IsVisible = false;
            this.xEditGridCell64.Row = -1;
            this.xEditGridCell64.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell73.CellName = "wonnae_drg_yn";
            this.xEditGridCell73.Col = -1;
            this.xEditGridCell73.ExecuteQuery = null;
            this.xEditGridCell73.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell73, "xEditGridCell73");
            this.xEditGridCell73.IsVisible = false;
            this.xEditGridCell73.Row = -1;
            this.xEditGridCell73.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell75.CellName = "hubal_change_check";
            this.xEditGridCell75.Col = -1;
            this.xEditGridCell75.ExecuteQuery = null;
            this.xEditGridCell75.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell75, "xEditGridCell75");
            this.xEditGridCell75.IsVisible = false;
            this.xEditGridCell75.Row = -1;
            this.xEditGridCell75.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell76.CellName = "drg_pack_check";
            this.xEditGridCell76.Col = -1;
            this.xEditGridCell76.ExecuteQuery = null;
            this.xEditGridCell76.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell76, "xEditGridCell76");
            this.xEditGridCell76.IsVisible = false;
            this.xEditGridCell76.Row = -1;
            this.xEditGridCell76.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell77.CellName = "pharmacy_check";
            this.xEditGridCell77.Col = -1;
            this.xEditGridCell77.ExecuteQuery = null;
            this.xEditGridCell77.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell77, "xEditGridCell77");
            this.xEditGridCell77.IsVisible = false;
            this.xEditGridCell77.Row = -1;
            this.xEditGridCell77.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell78.CellName = "powder_check";
            this.xEditGridCell78.Col = -1;
            this.xEditGridCell78.ExecuteQuery = null;
            this.xEditGridCell78.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell78, "xEditGridCell78");
            this.xEditGridCell78.IsVisible = false;
            this.xEditGridCell78.Row = -1;
            this.xEditGridCell78.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell79.CellName = "imsi_drug_yn";
            this.xEditGridCell79.CellWidth = 37;
            this.xEditGridCell79.Col = 5;
            this.xEditGridCell79.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell79.ExecuteQuery = null;
            this.xEditGridCell79.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell79, "xEditGridCell79");
            this.xEditGridCell79.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell79.RowSpan = 2;
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell85.CellName = "jundal_table_out";
            this.xEditGridCell85.Col = -1;
            this.xEditGridCell85.ExecuteQuery = null;
            this.xEditGridCell85.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell85, "xEditGridCell85");
            this.xEditGridCell85.IsVisible = false;
            this.xEditGridCell85.Row = -1;
            this.xEditGridCell85.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell86.CellName = "jundal_part_out";
            this.xEditGridCell86.CellWidth = 90;
            this.xEditGridCell86.Col = 32;
            this.xEditGridCell86.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell86.ExecuteQuery = null;
            this.xEditGridCell86.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell86, "xEditGridCell86");
            this.xEditGridCell86.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell86.RowSpan = 2;
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell87.CellName = "jundal_table_inp";
            this.xEditGridCell87.Col = -1;
            this.xEditGridCell87.ExecuteQuery = null;
            this.xEditGridCell87.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell87, "xEditGridCell87");
            this.xEditGridCell87.IsVisible = false;
            this.xEditGridCell87.Row = -1;
            this.xEditGridCell87.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell88.CellName = "jundal_part_inp";
            this.xEditGridCell88.CellWidth = 93;
            this.xEditGridCell88.Col = 33;
            this.xEditGridCell88.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell88.ExecuteQuery = null;
            this.xEditGridCell88.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell88, "xEditGridCell88");
            this.xEditGridCell88.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell88.RowSpan = 2;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell89.CellName = "move_part_out";
            this.xEditGridCell89.Col = -1;
            this.xEditGridCell89.ExecuteQuery = null;
            this.xEditGridCell89.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell89, "xEditGridCell89");
            this.xEditGridCell89.IsVisible = false;
            this.xEditGridCell89.Row = -1;
            this.xEditGridCell89.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell90.CellName = "move_part_inp";
            this.xEditGridCell90.Col = -1;
            this.xEditGridCell90.ExecuteQuery = null;
            this.xEditGridCell90.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell90, "xEditGridCell90");
            this.xEditGridCell90.IsVisible = false;
            this.xEditGridCell90.Row = -1;
            this.xEditGridCell90.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell94.CellName = "limit_nalsu";
            this.xEditGridCell94.Col = -1;
            this.xEditGridCell94.ExecuteQuery = null;
            this.xEditGridCell94.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell94, "xEditGridCell94");
            this.xEditGridCell94.IsUpdatable = false;
            this.xEditGridCell94.IsVisible = false;
            this.xEditGridCell94.Row = -1;
            this.xEditGridCell94.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell95.CellLen = 1;
            this.xEditGridCell95.CellName = "general_disp_yn";
            this.xEditGridCell95.CellWidth = 42;
            this.xEditGridCell95.Col = 30;
            this.xEditGridCell95.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell95.ExecuteQuery = null;
            this.xEditGridCell95.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell95, "xEditGridCell95");
            this.xEditGridCell95.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell95.RowSpan = 2;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell100.CellName = "dv_5";
            this.xEditGridCell100.CellWidth = 30;
            this.xEditGridCell100.Col = 19;
            this.xEditGridCell100.ExecuteQuery = null;
            this.xEditGridCell100.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell100, "xEditGridCell100");
            this.xEditGridCell100.IsReadOnly = true;
            this.xEditGridCell100.Row = 1;
            this.xEditGridCell100.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell100.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell101.CellName = "dv_6";
            this.xEditGridCell101.CellWidth = 30;
            this.xEditGridCell101.Col = 20;
            this.xEditGridCell101.ExecuteQuery = null;
            this.xEditGridCell101.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell101, "xEditGridCell101");
            this.xEditGridCell101.IsReadOnly = true;
            this.xEditGridCell101.Row = 1;
            this.xEditGridCell101.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell101.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell102.CellName = "dv_7";
            this.xEditGridCell102.CellWidth = 30;
            this.xEditGridCell102.Col = 21;
            this.xEditGridCell102.ExecuteQuery = null;
            this.xEditGridCell102.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell102, "xEditGridCell102");
            this.xEditGridCell102.IsReadOnly = true;
            this.xEditGridCell102.Row = 1;
            this.xEditGridCell102.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell102.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell103.CellName = "dv_8";
            this.xEditGridCell103.CellWidth = 19;
            this.xEditGridCell103.Col = 22;
            this.xEditGridCell103.ExecuteQuery = null;
            this.xEditGridCell103.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell103, "xEditGridCell103");
            this.xEditGridCell103.IsReadOnly = true;
            this.xEditGridCell103.Row = 1;
            this.xEditGridCell103.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell103.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell104.CellName = "bogyong_code_sub";
            this.xEditGridCell104.CellWidth = 72;
            this.xEditGridCell104.Col = 36;
            this.xEditGridCell104.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell104.ExecuteQuery = null;
            this.xEditGridCell104.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell104, "xEditGridCell104");
            this.xEditGridCell104.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell104.RowSpan = 2;
            // 
            // xEditGridCell105
            // 
            this.xEditGridCell105.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell105.CellName = "bogyong_name_sub";
            this.xEditGridCell105.CellWidth = 69;
            this.xEditGridCell105.Col = 37;
            this.xEditGridCell105.ExecuteQuery = null;
            this.xEditGridCell105.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell105, "xEditGridCell105");
            this.xEditGridCell105.IsReadOnly = true;
            this.xEditGridCell105.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell105.RowSpan = 2;
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell106.CellName = "limit_suryang";
            this.xEditGridCell106.Col = -1;
            this.xEditGridCell106.ExecuteQuery = null;
            this.xEditGridCell106.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell106, "xEditGridCell106");
            this.xEditGridCell106.IsReadOnly = true;
            this.xEditGridCell106.IsVisible = false;
            this.xEditGridCell106.Row = -1;
            this.xEditGridCell106.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell107
            // 
            this.xEditGridCell107.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell107.CellName = "pkocs1024";
            this.xEditGridCell107.Col = -1;
            this.xEditGridCell107.ExecuteQuery = null;
            this.xEditGridCell107.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell107, "xEditGridCell107");
            this.xEditGridCell107.IsReadOnly = true;
            this.xEditGridCell107.IsVisible = false;
            this.xEditGridCell107.Row = -1;
            this.xEditGridCell107.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell108.CellName = "brought_drg_yn";
            this.xEditGridCell108.CellWidth = 74;
            this.xEditGridCell108.Col = 38;
            this.xEditGridCell108.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell108.ExecuteQuery = null;
            this.xEditGridCell108.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell108, "xEditGridCell108");
            this.xEditGridCell108.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell108.RowSpan = 2;
            // 
            // xEditGridCell119
            // 
            this.xEditGridCell119.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell119.CellName = "jundal_part_name";
            this.xEditGridCell119.CellWidth = 43;
            this.xEditGridCell119.Col = -1;
            this.xEditGridCell119.ExecuteQuery = null;
            this.xEditGridCell119.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell119, "xEditGridCell119");
            this.xEditGridCell119.IsReadOnly = true;
            this.xEditGridCell119.IsVisible = false;
            this.xEditGridCell119.Row = -1;
            this.xEditGridCell119.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell121
            // 
            this.xEditGridCell121.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell121.CellName = "instead_yn";
            this.xEditGridCell121.CellWidth = 44;
            this.xEditGridCell121.Col = 39;
            this.xEditGridCell121.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem3,
            this.xComboItem4});
            this.xEditGridCell121.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell121.ExecuteQuery = null;
            this.xEditGridCell121.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell121, "xEditGridCell121");
            this.xEditGridCell121.IsReadOnly = true;
            this.xEditGridCell121.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell121.RowSpan = 2;
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ValueItem = "Y";
            // 
            // xComboItem4
            // 
            resources.ApplyResources(this.xComboItem4, "xComboItem4");
            this.xComboItem4.ValueItem = "N";
            // 
            // xEditGridCell122
            // 
            this.xEditGridCell122.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell122.CellName = "approve_yn";
            this.xEditGridCell122.CellWidth = 44;
            this.xEditGridCell122.Col = 40;
            this.xEditGridCell122.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem5,
            this.xComboItem6});
            this.xEditGridCell122.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell122.ExecuteQuery = null;
            this.xEditGridCell122.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell122, "xEditGridCell122");
            this.xEditGridCell122.IsReadOnly = true;
            this.xEditGridCell122.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell122.RowSpan = 2;
            // 
            // xComboItem5
            // 
            resources.ApplyResources(this.xComboItem5, "xComboItem5");
            this.xComboItem5.ValueItem = "Y";
            // 
            // xComboItem6
            // 
            resources.ApplyResources(this.xComboItem6, "xComboItem6");
            this.xComboItem6.ValueItem = "N";
            // 
            // xEditGridCell123
            // 
            this.xEditGridCell123.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell123.CellName = "postapprove_yn";
            this.xEditGridCell123.Col = -1;
            this.xEditGridCell123.ExecuteQuery = null;
            this.xEditGridCell123.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell123, "xEditGridCell123");
            this.xEditGridCell123.IsReadOnly = true;
            this.xEditGridCell123.IsVisible = false;
            this.xEditGridCell123.Row = -1;
            this.xEditGridCell123.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell128
            // 
            this.xEditGridCell128.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell128.CellName = "action_do_yn";
            this.xEditGridCell128.Col = -1;
            this.xEditGridCell128.ExecuteQuery = null;
            this.xEditGridCell128.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell128, "xEditGridCell128");
            this.xEditGridCell128.IsVisible = false;
            this.xEditGridCell128.Row = -1;
            this.xEditGridCell128.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell127
            // 
            this.xEditGridCell127.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell127.CellName = "yj_code";
            this.xEditGridCell127.Col = -1;
            this.xEditGridCell127.ExecuteQuery = null;
            this.xEditGridCell127.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell127, "xEditGridCell127");
            this.xEditGridCell127.IsVisible = false;
            this.xEditGridCell127.Row = -1;
            this.xEditGridCell127.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell129
            // 
            this.xEditGridCell129.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell129.CellName = "common_yn";
            this.xEditGridCell129.Col = -1;
            this.xEditGridCell129.ExecuteQuery = null;
            this.xEditGridCell129.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell129, "xEditGridCell129");
            this.xEditGridCell129.IsVisible = false;
            this.xEditGridCell129.Row = -1;
            this.xEditGridCell129.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 13;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 18;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 15;
            this.xGridHeader2.ColSpan = 8;
            this.xGridHeader2.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xGridHeader2, "xGridHeader2");
            this.xGridHeader2.HeaderWidth = 101;
            // 
            // pnlOrderDetail
            // 
            this.pnlOrderDetail.AccessibleDescription = null;
            this.pnlOrderDetail.AccessibleName = null;
            resources.ApplyResources(this.pnlOrderDetail, "pnlOrderDetail");
            this.pnlOrderDetail.Controls.Add(this.pbxIsBgtDrg);
            this.pnlOrderDetail.Controls.Add(this.btnBroughtDrg);
            this.pnlOrderDetail.Controls.Add(this.btnNalsu);
            this.pnlOrderDetail.Controls.Add(this.btnJungsiDrug);
            this.pnlOrderDetail.Controls.Add(this.btnSetOrder);
            this.pnlOrderDetail.Controls.Add(this.btnDoOrder);
            this.pnlOrderDetail.Controls.Add(this.btnExtend);
            this.pnlOrderDetail.Controls.Add(this.dbxBogyongName);
            this.pnlOrderDetail.Controls.Add(this.fbxBogyongCode);
            this.pnlOrderDetail.Controls.Add(this.xLabel8);
            this.pnlOrderDetail.Controls.Add(this.cboNalsu);
            this.pnlOrderDetail.Controls.Add(this.lblNalsu);
            this.pnlOrderDetail.Controls.Add(this.lblInOut);
            this.pnlOrderDetail.Controls.Add(this.cbxEmergency);
            this.pnlOrderDetail.Controls.Add(this.xLabel3);
            this.pnlOrderDetail.Controls.Add(this.cbxWonyoiOrderYN);
            this.pnlOrderDetail.DrawBorder = true;
            this.pnlOrderDetail.Font = null;
            this.pnlOrderDetail.Name = "pnlOrderDetail";
            this.toolTip1.SetToolTip(this.pnlOrderDetail, resources.GetString("pnlOrderDetail.ToolTip"));
            // 
            // pbxIsBgtDrg
            // 
            this.pbxIsBgtDrg.AccessibleDescription = null;
            this.pbxIsBgtDrg.AccessibleName = null;
            resources.ApplyResources(this.pbxIsBgtDrg, "pbxIsBgtDrg");
            this.pbxIsBgtDrg.BackgroundImage = null;
            this.pbxIsBgtDrg.Font = null;
            this.pbxIsBgtDrg.ImageLocation = null;
            this.pbxIsBgtDrg.Name = "pbxIsBgtDrg";
            this.pbxIsBgtDrg.TabStop = false;
            this.toolTip1.SetToolTip(this.pbxIsBgtDrg, resources.GetString("pbxIsBgtDrg.ToolTip"));
            // 
            // btnBroughtDrg
            // 
            this.btnBroughtDrg.AccessibleDescription = null;
            this.btnBroughtDrg.AccessibleName = null;
            resources.ApplyResources(this.btnBroughtDrg, "btnBroughtDrg");
            this.btnBroughtDrg.BackgroundImage = null;
            this.btnBroughtDrg.ImageIndex = 7;
            this.btnBroughtDrg.ImageList = this.ImageList;
            this.btnBroughtDrg.Name = "btnBroughtDrg";
            this.btnBroughtDrg.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.toolTip1.SetToolTip(this.btnBroughtDrg, resources.GetString("btnBroughtDrg.ToolTip"));
            this.btnBroughtDrg.Click += new System.EventHandler(this.btnBroughtDrg_Click);
            // 
            // btnNalsu
            // 
            this.btnNalsu.AccessibleDescription = null;
            this.btnNalsu.AccessibleName = null;
            resources.ApplyResources(this.btnNalsu, "btnNalsu");
            this.btnNalsu.BackgroundImage = null;
            this.btnNalsu.Image = ((System.Drawing.Image)(resources.GetObject("btnNalsu.Image")));
            this.btnNalsu.Name = "btnNalsu";
            this.toolTip1.SetToolTip(this.btnNalsu, resources.GetString("btnNalsu.ToolTip"));
            this.btnNalsu.Click += new System.EventHandler(this.btnNalsu_Click);
            // 
            // btnJungsiDrug
            // 
            this.btnJungsiDrug.AccessibleDescription = null;
            this.btnJungsiDrug.AccessibleName = null;
            resources.ApplyResources(this.btnJungsiDrug, "btnJungsiDrug");
            this.btnJungsiDrug.BackgroundImage = null;
            this.btnJungsiDrug.ImageIndex = 7;
            this.btnJungsiDrug.ImageList = this.ImageList;
            this.btnJungsiDrug.Name = "btnJungsiDrug";
            this.btnJungsiDrug.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.toolTip1.SetToolTip(this.btnJungsiDrug, resources.GetString("btnJungsiDrug.ToolTip"));
            this.btnJungsiDrug.Click += new System.EventHandler(this.btnJungsiDrug_Click);
            // 
            // btnSetOrder
            // 
            this.btnSetOrder.AccessibleDescription = null;
            this.btnSetOrder.AccessibleName = null;
            resources.ApplyResources(this.btnSetOrder, "btnSetOrder");
            this.btnSetOrder.BackgroundImage = null;
            this.btnSetOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnSetOrder.Image")));
            this.btnSetOrder.Name = "btnSetOrder";
            this.btnSetOrder.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.toolTip1.SetToolTip(this.btnSetOrder, resources.GetString("btnSetOrder.ToolTip"));
            this.btnSetOrder.Click += new System.EventHandler(this.btnSetOrder_Click);
            // 
            // btnDoOrder
            // 
            this.btnDoOrder.AccessibleDescription = null;
            this.btnDoOrder.AccessibleName = null;
            resources.ApplyResources(this.btnDoOrder, "btnDoOrder");
            this.btnDoOrder.BackgroundImage = null;
            this.btnDoOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnDoOrder.Image")));
            this.btnDoOrder.Name = "btnDoOrder";
            this.toolTip1.SetToolTip(this.btnDoOrder, resources.GetString("btnDoOrder.ToolTip"));
            this.btnDoOrder.Click += new System.EventHandler(this.btnDoOrder_Click);
            // 
            // btnExtend
            // 
            this.btnExtend.AccessibleDescription = null;
            this.btnExtend.AccessibleName = null;
            resources.ApplyResources(this.btnExtend, "btnExtend");
            this.btnExtend.BackgroundImage = null;
            this.btnExtend.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExtend.ImageIndex = 3;
            this.btnExtend.ImageList = this.ImageList;
            this.btnExtend.Name = "btnExtend";
            this.toolTip1.SetToolTip(this.btnExtend, resources.GetString("btnExtend.ToolTip"));
            this.btnExtend.Click += new System.EventHandler(this.btnExtend_Click);
            // 
            // dbxBogyongName
            // 
            this.dbxBogyongName.AccessibleDescription = null;
            this.dbxBogyongName.AccessibleName = null;
            this.dbxBogyongName.AllowDrop = true;
            resources.ApplyResources(this.dbxBogyongName, "dbxBogyongName");
            this.dbxBogyongName.Image = null;
            this.dbxBogyongName.Name = "dbxBogyongName";
            this.toolTip1.SetToolTip(this.dbxBogyongName, resources.GetString("dbxBogyongName.ToolTip"));
            this.dbxBogyongName.Click += new System.EventHandler(this.dbxBogyongName_Click);
            // 
            // fbxBogyongCode
            // 
            this.fbxBogyongCode.AccessibleDescription = null;
            this.fbxBogyongCode.AccessibleName = null;
            resources.ApplyResources(this.fbxBogyongCode, "fbxBogyongCode");
            this.fbxBogyongCode.AutoTabDataSelected = true;
            this.fbxBogyongCode.BackgroundImage = null;
            this.fbxBogyongCode.Name = "fbxBogyongCode";
            this.toolTip1.SetToolTip(this.fbxBogyongCode, resources.GetString("fbxBogyongCode.ToolTip"));
            this.fbxBogyongCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxBogyongCode_DataValidating);
            this.fbxBogyongCode.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxBogyongCode_FindClick);
            // 
            // xLabel8
            // 
            this.xLabel8.AccessibleDescription = null;
            this.xLabel8.AccessibleName = null;
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.EdgeRounding = false;
            this.xLabel8.Image = null;
            this.xLabel8.Name = "xLabel8";
            this.toolTip1.SetToolTip(this.xLabel8, resources.GetString("xLabel8.ToolTip"));
            this.xLabel8.Click += new System.EventHandler(this.xLabel8_Click);
            // 
            // cboNalsu
            // 
            this.cboNalsu.AccessibleDescription = null;
            this.cboNalsu.AccessibleName = null;
            resources.ApplyResources(this.cboNalsu, "cboNalsu");
            this.cboNalsu.BackgroundImage = null;
            this.cboNalsu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboNalsu.Name = "cboNalsu";
            this.toolTip1.SetToolTip(this.cboNalsu, resources.GetString("cboNalsu.ToolTip"));
            this.cboNalsu.VisibleChanged += new System.EventHandler(this.cboNalsu_VisibleChanged);
            this.cboNalsu.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.cboNalsu_DataValidating);
            // 
            // lblNalsu
            // 
            this.lblNalsu.AccessibleDescription = null;
            this.lblNalsu.AccessibleName = null;
            resources.ApplyResources(this.lblNalsu, "lblNalsu");
            this.lblNalsu.EdgeRounding = false;
            this.lblNalsu.Image = null;
            this.lblNalsu.Name = "lblNalsu";
            this.toolTip1.SetToolTip(this.lblNalsu, resources.GetString("lblNalsu.ToolTip"));
            // 
            // lblInOut
            // 
            this.lblInOut.AccessibleDescription = null;
            this.lblInOut.AccessibleName = null;
            resources.ApplyResources(this.lblInOut, "lblInOut");
            this.lblInOut.BackColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.lblInOut.EdgeRounding = false;
            this.lblInOut.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.lblInOut.Image = null;
            this.lblInOut.Name = "lblInOut";
            this.toolTip1.SetToolTip(this.lblInOut, resources.GetString("lblInOut.ToolTip"));
            // 
            // cbxEmergency
            // 
            this.cbxEmergency.AccessibleDescription = null;
            this.cbxEmergency.AccessibleName = null;
            resources.ApplyResources(this.cbxEmergency, "cbxEmergency");
            this.cbxEmergency.BackgroundImage = null;
            this.cbxEmergency.Name = "cbxEmergency";
            this.toolTip1.SetToolTip(this.cbxEmergency, resources.GetString("cbxEmergency.ToolTip"));
            this.cbxEmergency.UseVisualStyleBackColor = false;
            this.cbxEmergency.CheckedChanged += new System.EventHandler(this.cbxEmergency_CheckedChanged);
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.ForeColor = IHIS.Framework.XColor.XCalendarHeaderTextColor;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            this.toolTip1.SetToolTip(this.xLabel3, resources.GetString("xLabel3.ToolTip"));
            // 
            // cbxWonyoiOrderYN
            // 
            this.cbxWonyoiOrderYN.AccessibleDescription = null;
            this.cbxWonyoiOrderYN.AccessibleName = null;
            resources.ApplyResources(this.cbxWonyoiOrderYN, "cbxWonyoiOrderYN");
            this.cbxWonyoiOrderYN.BackgroundImage = null;
            this.cbxWonyoiOrderYN.Name = "cbxWonyoiOrderYN";
            this.toolTip1.SetToolTip(this.cbxWonyoiOrderYN, resources.GetString("cbxWonyoiOrderYN.ToolTip"));
            this.cbxWonyoiOrderYN.UseVisualStyleBackColor = false;
            this.cbxWonyoiOrderYN.CheckedChanged += new System.EventHandler(this.cbxWonyoiOrderYN_CheckedChanged);
            // 
            // pnlOrderInput
            // 
            this.pnlOrderInput.AccessibleDescription = null;
            this.pnlOrderInput.AccessibleName = null;
            resources.ApplyResources(this.pnlOrderInput, "pnlOrderInput");
            this.pnlOrderInput.BackgroundImage = null;
            this.pnlOrderInput.Controls.Add(this.xPanel1);
            this.pnlOrderInput.Font = null;
            this.pnlOrderInput.Name = "pnlOrderInput";
            this.toolTip1.SetToolTip(this.pnlOrderInput, resources.GetString("pnlOrderInput.ToolTip"));
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackColor = IHIS.Framework.XColor.XRoundPanelBackColor;
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.tabGroup);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            this.toolTip1.SetToolTip(this.xPanel1, resources.GetString("xPanel1.ToolTip"));
            // 
            // tabGroup
            // 
            this.tabGroup.AccessibleDescription = null;
            this.tabGroup.AccessibleName = null;
            resources.ApplyResources(this.tabGroup, "tabGroup");
            this.tabGroup.BackgroundImage = null;
            this.tabGroup.IDEPixelArea = true;
            this.tabGroup.IDEPixelBorder = false;
            this.tabGroup.Name = "tabGroup";
            this.toolTip1.SetToolTip(this.tabGroup, resources.GetString("tabGroup.ToolTip"));
            this.tabGroup.SelectionChanged += new System.EventHandler(this.tabGroup_SelectionChanged);
            this.tabGroup.ClosePressed += new System.EventHandler(this.tabGroup_ClosePressed);
            this.tabGroup.SelectionChanging += new System.EventHandler(this.tabGroup_SelectionChanging);
            // 
            // grdOutSang
            // 
            resources.ApplyResources(this.grdOutSang, "grdOutSang");
            this.grdOutSang.ApplyPaintEventToAllColumn = true;
            this.grdOutSang.AutoSizeHeight = 27;
            this.grdOutSang.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
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
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell349});
            this.grdOutSang.ColPerLine = 7;
            this.grdOutSang.Cols = 8;
            this.grdOutSang.ControlBinding = true;
            this.grdOutSang.EnableMultiSelection = true;
            this.grdOutSang.ExecuteQuery = null;
            this.grdOutSang.FixedCols = 1;
            this.grdOutSang.FixedRows = 1;
            this.grdOutSang.FocusColumnName = "SANG_CODE";
            this.grdOutSang.HeaderHeights.Add(29);
            this.grdOutSang.IsAllDataQuery = true;
            this.grdOutSang.Name = "grdOutSang";
            this.grdOutSang.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOutSang.ParamList")));
            this.grdOutSang.RowHeaderVisible = true;
            this.grdOutSang.Rows = 2;
            this.grdOutSang.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.toolTip1.SetToolTip(this.grdOutSang, resources.GetString("grdOutSang.ToolTip"));
            this.grdOutSang.ToolTipActive = true;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.CellName = "USER_ID";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            this.xEditGridCell1.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell2.CellName = "BUNHO";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            this.xEditGridCell2.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell3.CellName = "ORDER_DATE";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            this.xEditGridCell3.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.CellName = "GWA";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            this.xEditGridCell4.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.CellName = "DOCTOR";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            this.xEditGridCell5.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell6.CellName = "NAEWON_TYPE";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            this.xEditGridCell6.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell7.CellName = "PK_SEQ";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            this.xEditGridCell7.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell8.CellName = "INPUT_ID";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            this.xEditGridCell8.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell9.CellName = "SER";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            this.xEditGridCell9.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell10.CellName = "SANG_CODE";
            this.xEditGridCell10.CellWidth = 470;
            this.xEditGridCell10.Col = 3;
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell10.IsNotNull = true;
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell11.CellName = "SANG_NAME";
            this.xEditGridCell11.CellWidth = 426;
            this.xEditGridCell11.Col = 5;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.IsUpdCol = false;
            this.xEditGridCell11.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell12.CellName = "JU_SANG_YN";
            this.xEditGridCell12.CellWidth = 20;
            this.xEditGridCell12.Col = 1;
            this.xEditGridCell12.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell13.CellName = "CHISIK";
            this.xEditGridCell13.CellWidth = 31;
            this.xEditGridCell13.Col = 7;
            this.xEditGridCell13.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell14.CellName = "PRINT_YN";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsUpdatable = false;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            this.xEditGridCell14.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell15.CellName = "VCODE_YN";
            this.xEditGridCell15.CellWidth = 26;
            this.xEditGridCell15.Col = 2;
            this.xEditGridCell15.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell16.CellName = "SUGA_SANG_CODE";
            this.xEditGridCell16.Col = 6;
            this.xEditGridCell16.ExecuteQuery = null;
            this.xEditGridCell16.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsUpdatable = false;
            this.xEditGridCell16.IsUpdCol = false;
            this.xEditGridCell16.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell17.ButtonImage = ((System.Drawing.Image)(resources.GetObject("xEditGridCell17.ButtonImage")));
            this.xEditGridCell17.CellName = "SANG_BUTTON";
            this.xEditGridCell17.CellWidth = 20;
            this.xEditGridCell17.Col = 4;
            this.xEditGridCell17.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            this.xEditGridCell17.ExecuteQuery = null;
            this.xEditGridCell17.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsUpdatable = false;
            this.xEditGridCell17.IsUpdCol = false;
            this.xEditGridCell17.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell349
            // 
            this.xEditGridCell349.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell349.CellName = "DENT";
            this.xEditGridCell349.Col = -1;
            this.xEditGridCell349.ExecuteQuery = null;
            this.xEditGridCell349.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell349, "xEditGridCell349");
            this.xEditGridCell349.IsUpdatable = false;
            this.xEditGridCell349.IsUpdCol = false;
            this.xEditGridCell349.IsVisible = false;
            this.xEditGridCell349.Row = -1;
            this.xEditGridCell349.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // imageListPopupMenu
            // 
            this.imageListPopupMenu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListPopupMenu.ImageStream")));
            this.imageListPopupMenu.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListPopupMenu.Images.SetKeyName(0, "YESUP1.ICO");
            this.imageListPopupMenu.Images.SetKeyName(1, "YESEN1.ICO");
            this.imageListPopupMenu.Images.SetKeyName(2, "복사.gif");
            this.imageListPopupMenu.Images.SetKeyName(3, "붙여넣기.gif");
            this.imageListPopupMenu.Images.SetKeyName(4, "삭제.gif");
            this.imageListPopupMenu.Images.SetKeyName(5, "+.gif");
            this.imageListPopupMenu.Images.SetKeyName(6, "_.gif");
            this.imageListPopupMenu.Images.SetKeyName(7, "행추가.gif");
            // 
            // imageListInfo
            // 
            this.imageListInfo.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListInfo.ImageStream")));
            this.imageListInfo.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListInfo.Images.SetKeyName(0, "");
            this.imageListInfo.Images.SetKeyName(1, "");
            this.imageListInfo.Images.SetKeyName(2, "");
            this.imageListInfo.Images.SetKeyName(3, "");
            this.imageListInfo.Images.SetKeyName(4, "닫힌폴더.gif");
            this.imageListInfo.Images.SetKeyName(5, "열린폴더.gif");
            this.imageListInfo.Images.SetKeyName(6, "뒤로.gif");
            this.imageListInfo.Images.SetKeyName(7, "앞으로.gif");
            this.imageListInfo.Images.SetKeyName(8, "신규.gif");
            // 
            // imageListMixGroup
            // 
            this.imageListMixGroup.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMixGroup.ImageStream")));
            this.imageListMixGroup.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMixGroup.Images.SetKeyName(0, "20.gif");
            this.imageListMixGroup.Images.SetKeyName(1, "1.gif");
            this.imageListMixGroup.Images.SetKeyName(2, "2.gif");
            this.imageListMixGroup.Images.SetKeyName(3, "3.gif");
            this.imageListMixGroup.Images.SetKeyName(4, "4.gif");
            this.imageListMixGroup.Images.SetKeyName(5, "5.gif");
            this.imageListMixGroup.Images.SetKeyName(6, "6.gif");
            this.imageListMixGroup.Images.SetKeyName(7, "7.gif");
            this.imageListMixGroup.Images.SetKeyName(8, "8.gif");
            this.imageListMixGroup.Images.SetKeyName(9, "9.gif");
            this.imageListMixGroup.Images.SetKeyName(10, "10.gif");
            this.imageListMixGroup.Images.SetKeyName(11, "11.gif");
            this.imageListMixGroup.Images.SetKeyName(12, "12.gif");
            this.imageListMixGroup.Images.SetKeyName(13, "13.gif");
            this.imageListMixGroup.Images.SetKeyName(14, "14.gif");
            this.imageListMixGroup.Images.SetKeyName(15, "15.gif");
            this.imageListMixGroup.Images.SetKeyName(16, "16.gif");
            this.imageListMixGroup.Images.SetKeyName(17, "17.gif");
            this.imageListMixGroup.Images.SetKeyName(18, "18.gif");
            this.imageListMixGroup.Images.SetKeyName(19, "19.gif");
            // 
            // xEditGridCell493
            // 
            this.xEditGridCell493.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell493.CellName = "specific_comment_sys_id";
            this.xEditGridCell493.Col = -1;
            this.xEditGridCell493.ExecuteQuery = null;
            this.xEditGridCell493.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell493, "xEditGridCell493");
            this.xEditGridCell493.IsVisible = false;
            this.xEditGridCell493.Row = -1;
            this.xEditGridCell493.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // layGroupTab
            // 
            this.layGroupTab.ExecuteQuery = null;
            this.layGroupTab.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8});
            this.layGroupTab.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layGroupTab.ParamList")));
            this.layGroupTab.QuerySQL = resources.GetString("layGroupTab.QuerySQL");
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "pk_in_out_key";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "order_gubun";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "group_ser";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "bogyong_code";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "bogyong_name";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "nalsu";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "emergency";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "wonyoi_order_yn";
            // 
            // layDrugTree
            // 
            this.layDrugTree.ExecuteQuery = null;
            this.layDrugTree.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem12});
            this.layDrugTree.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDrugTree.ParamList")));
            this.layDrugTree.QuerySQL = resources.GetString("layDrugTree.QuerySQL");
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "code";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "code_name";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "code1";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "code_name1";
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell50.ExecuteQuery = null;
            this.xEditGridCell50.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            this.xEditGridCell50.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell51.ExecuteQuery = null;
            this.xEditGridCell51.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell52.ExecuteQuery = null;
            this.xEditGridCell52.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell60.CellName = "acting_day";
            this.xEditGridCell60.Col = 28;
            this.xEditGridCell60.ExecuteQuery = null;
            this.xEditGridCell60.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.Row = 1;
            this.xEditGridCell60.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // layPreview
            // 
            this.layPreview.ExecuteQuery = null;
            this.layPreview.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20,
            this.multiLayoutItem30,
            this.multiLayoutItem31,
            this.multiLayoutItem34,
            this.multiLayoutItem35});
            this.layPreview.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layPreview.ParamList")));
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "group_ser";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "order_gubun";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "hangmog_name";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "suryang";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "hoisu";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "dc_gubun";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "nalsu";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "order_data_yn";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "row_num";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "danui";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "donbog_yn";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "hoisu_name";
            // 
            // laySaveLayout
            // 
            this.laySaveLayout.CallerID = '3';
            this.laySaveLayout.ExecuteQuery = null;
            this.laySaveLayout.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem21,
            this.multiLayoutItem22,
            this.multiLayoutItem23,
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem26,
            this.multiLayoutItem27,
            this.multiLayoutItem28,
            this.multiLayoutItem29,
            this.multiLayoutItem32,
            this.multiLayoutItem33,
            this.multiLayoutItem36,
            this.multiLayoutItem37,
            this.multiLayoutItem38,
            this.multiLayoutItem39,
            this.multiLayoutItem40,
            this.multiLayoutItem41,
            this.multiLayoutItem42,
            this.multiLayoutItem43,
            this.multiLayoutItem44,
            this.multiLayoutItem45,
            this.multiLayoutItem46,
            this.multiLayoutItem47,
            this.multiLayoutItem48,
            this.multiLayoutItem49,
            this.multiLayoutItem50,
            this.multiLayoutItem51,
            this.multiLayoutItem52,
            this.multiLayoutItem53,
            this.multiLayoutItem54,
            this.multiLayoutItem55,
            this.multiLayoutItem56,
            this.multiLayoutItem57,
            this.multiLayoutItem58,
            this.multiLayoutItem59,
            this.multiLayoutItem60,
            this.multiLayoutItem61,
            this.multiLayoutItem62,
            this.multiLayoutItem63,
            this.multiLayoutItem64,
            this.multiLayoutItem65,
            this.multiLayoutItem66,
            this.multiLayoutItem67,
            this.multiLayoutItem68,
            this.multiLayoutItem69,
            this.multiLayoutItem70,
            this.multiLayoutItem71,
            this.multiLayoutItem72,
            this.multiLayoutItem73,
            this.multiLayoutItem74,
            this.multiLayoutItem75,
            this.multiLayoutItem76,
            this.multiLayoutItem77,
            this.multiLayoutItem78,
            this.multiLayoutItem79,
            this.multiLayoutItem80,
            this.multiLayoutItem81,
            this.multiLayoutItem82,
            this.multiLayoutItem83,
            this.multiLayoutItem84,
            this.multiLayoutItem85,
            this.multiLayoutItem86,
            this.multiLayoutItem87,
            this.multiLayoutItem88,
            this.multiLayoutItem89,
            this.multiLayoutItem90,
            this.multiLayoutItem91,
            this.multiLayoutItem92,
            this.multiLayoutItem93,
            this.multiLayoutItem94,
            this.multiLayoutItem95,
            this.multiLayoutItem96,
            this.multiLayoutItem97,
            this.multiLayoutItem98,
            this.multiLayoutItem99,
            this.multiLayoutItem100,
            this.multiLayoutItem101,
            this.multiLayoutItem102,
            this.multiLayoutItem103,
            this.multiLayoutItem104,
            this.multiLayoutItem105,
            this.multiLayoutItem106,
            this.multiLayoutItem107,
            this.multiLayoutItem108,
            this.multiLayoutItem109,
            this.multiLayoutItem110,
            this.multiLayoutItem111,
            this.multiLayoutItem112,
            this.multiLayoutItem113,
            this.multiLayoutItem114,
            this.multiLayoutItem115,
            this.multiLayoutItem116,
            this.multiLayoutItem117,
            this.multiLayoutItem118,
            this.multiLayoutItem119,
            this.multiLayoutItem120,
            this.multiLayoutItem121,
            this.multiLayoutItem122,
            this.multiLayoutItem123,
            this.multiLayoutItem124,
            this.multiLayoutItem125,
            this.multiLayoutItem126,
            this.multiLayoutItem127,
            this.multiLayoutItem128,
            this.multiLayoutItem129,
            this.multiLayoutItem130,
            this.multiLayoutItem131,
            this.multiLayoutItem132,
            this.multiLayoutItem133,
            this.multiLayoutItem134,
            this.multiLayoutItem135,
            this.multiLayoutItem136,
            this.multiLayoutItem137,
            this.multiLayoutItem138,
            this.multiLayoutItem139,
            this.multiLayoutItem140,
            this.multiLayoutItem141,
            this.multiLayoutItem142,
            this.multiLayoutItem143,
            this.multiLayoutItem144,
            this.multiLayoutItem145,
            this.multiLayoutItem146,
            this.multiLayoutItem147,
            this.multiLayoutItem148,
            this.multiLayoutItem149,
            this.multiLayoutItem150,
            this.multiLayoutItem151,
            this.multiLayoutItem152,
            this.multiLayoutItem153,
            this.multiLayoutItem154,
            this.multiLayoutItem155,
            this.multiLayoutItem156,
            this.multiLayoutItem157,
            this.multiLayoutItem158,
            this.multiLayoutItem159,
            this.multiLayoutItem160,
            this.multiLayoutItem161,
            this.multiLayoutItem311,
            this.multiLayoutItem312,
            this.multiLayoutItem313,
            this.multiLayoutItem314,
            this.multiLayoutItem315,
            this.multiLayoutItem316,
            this.multiLayoutItem317,
            this.multiLayoutItem318,
            this.multiLayoutItem319,
            this.multiLayoutItem320,
            this.multiLayoutItem321,
            this.multiLayoutItem322,
            this.multiLayoutItem323,
            this.multiLayoutItem324});
            this.laySaveLayout.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySaveLayout.ParamList")));
            this.laySaveLayout.UseDefaultTransaction = false;
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "in_out_key";
            this.multiLayoutItem21.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem21.IsUpdItem = true;
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "pkocskey";
            this.multiLayoutItem22.IsUpdItem = true;
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "bunho";
            this.multiLayoutItem23.IsUpdItem = true;
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "order_date";
            this.multiLayoutItem24.IsUpdItem = true;
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "gwa";
            this.multiLayoutItem25.IsUpdItem = true;
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "doctor";
            this.multiLayoutItem26.IsUpdItem = true;
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "resident";
            this.multiLayoutItem27.IsUpdItem = true;
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "naewon_type";
            this.multiLayoutItem28.IsUpdItem = true;
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "jubsu_no";
            this.multiLayoutItem29.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem29.IsUpdItem = true;
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "input_id";
            this.multiLayoutItem32.IsUpdItem = true;
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "input_part";
            this.multiLayoutItem33.IsUpdItem = true;
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "input_gwa";
            this.multiLayoutItem36.IsUpdItem = true;
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "input_doctor";
            this.multiLayoutItem37.IsUpdItem = true;
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "input_gubun";
            this.multiLayoutItem38.IsUpdItem = true;
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "input_gubun_name";
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "group_ser";
            this.multiLayoutItem40.IsUpdItem = true;
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "input_tab";
            this.multiLayoutItem41.IsUpdItem = true;
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "input_tab_name";
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "order_gubun";
            this.multiLayoutItem43.IsUpdItem = true;
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "order_gubun_name";
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "group_yn";
            this.multiLayoutItem45.IsUpdItem = true;
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "seq";
            this.multiLayoutItem46.IsUpdItem = true;
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "slip_code";
            this.multiLayoutItem47.IsUpdItem = true;
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "hangmog_code";
            this.multiLayoutItem48.IsUpdItem = true;
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "hangmog_name";
            // 
            // multiLayoutItem50
            // 
            this.multiLayoutItem50.DataName = "specimen_code";
            this.multiLayoutItem50.IsUpdItem = true;
            // 
            // multiLayoutItem51
            // 
            this.multiLayoutItem51.DataName = "specimen_name";
            // 
            // multiLayoutItem52
            // 
            this.multiLayoutItem52.DataName = "suryang";
            this.multiLayoutItem52.IsUpdItem = true;
            // 
            // multiLayoutItem53
            // 
            this.multiLayoutItem53.DataName = "sunab_suryang";
            this.multiLayoutItem53.IsUpdItem = true;
            // 
            // multiLayoutItem54
            // 
            this.multiLayoutItem54.DataName = "subul_suryang";
            this.multiLayoutItem54.IsUpdItem = true;
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "ord_danui";
            this.multiLayoutItem55.IsUpdItem = true;
            // 
            // multiLayoutItem56
            // 
            this.multiLayoutItem56.DataName = "ord_danui_name";
            // 
            // multiLayoutItem57
            // 
            this.multiLayoutItem57.DataName = "dv_time";
            this.multiLayoutItem57.IsUpdItem = true;
            // 
            // multiLayoutItem58
            // 
            this.multiLayoutItem58.DataName = "dv";
            this.multiLayoutItem58.IsUpdItem = true;
            // 
            // multiLayoutItem59
            // 
            this.multiLayoutItem59.DataName = "dv_1";
            this.multiLayoutItem59.IsUpdItem = true;
            // 
            // multiLayoutItem60
            // 
            this.multiLayoutItem60.DataName = "dv_2";
            this.multiLayoutItem60.IsUpdItem = true;
            // 
            // multiLayoutItem61
            // 
            this.multiLayoutItem61.DataName = "dv_3";
            this.multiLayoutItem61.IsUpdItem = true;
            // 
            // multiLayoutItem62
            // 
            this.multiLayoutItem62.DataName = "dv_4";
            this.multiLayoutItem62.IsUpdItem = true;
            // 
            // multiLayoutItem63
            // 
            this.multiLayoutItem63.DataName = "nalsu";
            this.multiLayoutItem63.IsUpdItem = true;
            // 
            // multiLayoutItem64
            // 
            this.multiLayoutItem64.DataName = "sunab_nalsu";
            this.multiLayoutItem64.IsUpdItem = true;
            // 
            // multiLayoutItem65
            // 
            this.multiLayoutItem65.DataName = "jusa";
            this.multiLayoutItem65.IsUpdItem = true;
            // 
            // multiLayoutItem66
            // 
            this.multiLayoutItem66.DataName = "jusa_name";
            this.multiLayoutItem66.IsUpdItem = true;
            // 
            // multiLayoutItem67
            // 
            this.multiLayoutItem67.DataName = "jusa_spd_gubun";
            this.multiLayoutItem67.IsUpdItem = true;
            // 
            // multiLayoutItem68
            // 
            this.multiLayoutItem68.DataName = "bogyong_code";
            this.multiLayoutItem68.IsUpdItem = true;
            // 
            // multiLayoutItem69
            // 
            this.multiLayoutItem69.DataName = "bogyong_name";
            this.multiLayoutItem69.IsUpdItem = true;
            // 
            // multiLayoutItem70
            // 
            this.multiLayoutItem70.DataName = "emergency";
            this.multiLayoutItem70.IsUpdItem = true;
            // 
            // multiLayoutItem71
            // 
            this.multiLayoutItem71.DataName = "jaeryo_jundal_yn";
            this.multiLayoutItem71.IsUpdItem = true;
            // 
            // multiLayoutItem72
            // 
            this.multiLayoutItem72.DataName = "jundal_table";
            this.multiLayoutItem72.IsUpdItem = true;
            // 
            // multiLayoutItem73
            // 
            this.multiLayoutItem73.DataName = "jundal_part";
            this.multiLayoutItem73.IsUpdItem = true;
            // 
            // multiLayoutItem74
            // 
            this.multiLayoutItem74.DataName = "move_part";
            this.multiLayoutItem74.IsUpdItem = true;
            // 
            // multiLayoutItem75
            // 
            this.multiLayoutItem75.DataName = "portable_yn";
            this.multiLayoutItem75.IsUpdItem = true;
            // 
            // multiLayoutItem76
            // 
            this.multiLayoutItem76.DataName = "powder_yn";
            this.multiLayoutItem76.IsUpdItem = true;
            // 
            // multiLayoutItem77
            // 
            this.multiLayoutItem77.DataName = "hubal_change_yn";
            this.multiLayoutItem77.IsUpdItem = true;
            // 
            // multiLayoutItem78
            // 
            this.multiLayoutItem78.DataName = "pharmacy";
            this.multiLayoutItem78.IsUpdItem = true;
            // 
            // multiLayoutItem79
            // 
            this.multiLayoutItem79.DataName = "drg_pack_yn";
            this.multiLayoutItem79.IsUpdItem = true;
            // 
            // multiLayoutItem80
            // 
            this.multiLayoutItem80.DataName = "muhyo";
            this.multiLayoutItem80.IsUpdItem = true;
            // 
            // multiLayoutItem81
            // 
            this.multiLayoutItem81.DataName = "prn_yn";
            this.multiLayoutItem81.IsUpdItem = true;
            // 
            // multiLayoutItem82
            // 
            this.multiLayoutItem82.DataName = "toiwon_drg_yn";
            this.multiLayoutItem82.IsUpdItem = true;
            // 
            // multiLayoutItem83
            // 
            this.multiLayoutItem83.DataName = "prn_nurse";
            this.multiLayoutItem83.IsUpdItem = true;
            // 
            // multiLayoutItem84
            // 
            this.multiLayoutItem84.DataName = "append_yn";
            this.multiLayoutItem84.IsUpdItem = true;
            // 
            // multiLayoutItem85
            // 
            this.multiLayoutItem85.DataName = "order_remark";
            this.multiLayoutItem85.IsUpdItem = true;
            // 
            // multiLayoutItem86
            // 
            this.multiLayoutItem86.DataName = "nurse_remark";
            this.multiLayoutItem86.IsUpdItem = true;
            // 
            // multiLayoutItem87
            // 
            this.multiLayoutItem87.DataName = "comment";
            this.multiLayoutItem87.IsUpdItem = true;
            // 
            // multiLayoutItem88
            // 
            this.multiLayoutItem88.DataName = "mix_group";
            this.multiLayoutItem88.IsUpdItem = true;
            // 
            // multiLayoutItem89
            // 
            this.multiLayoutItem89.DataName = "amt";
            this.multiLayoutItem89.IsUpdItem = true;
            // 
            // multiLayoutItem90
            // 
            this.multiLayoutItem90.DataName = "pay";
            this.multiLayoutItem90.IsUpdItem = true;
            // 
            // multiLayoutItem91
            // 
            this.multiLayoutItem91.DataName = "wonyoi_order_yn";
            this.multiLayoutItem91.IsUpdItem = true;
            // 
            // multiLayoutItem92
            // 
            this.multiLayoutItem92.DataName = "dangil_gumsa_order_yn";
            this.multiLayoutItem92.IsUpdItem = true;
            // 
            // multiLayoutItem93
            // 
            this.multiLayoutItem93.DataName = "dangil_gumsa_result_yn";
            this.multiLayoutItem93.IsUpdItem = true;
            // 
            // multiLayoutItem94
            // 
            this.multiLayoutItem94.DataName = "bom_occur_yn";
            this.multiLayoutItem94.IsUpdItem = true;
            // 
            // multiLayoutItem95
            // 
            this.multiLayoutItem95.DataName = "bom_source_key";
            this.multiLayoutItem95.IsUpdItem = true;
            // 
            // multiLayoutItem96
            // 
            this.multiLayoutItem96.DataName = "display_yn";
            this.multiLayoutItem96.IsUpdItem = true;
            // 
            // multiLayoutItem97
            // 
            this.multiLayoutItem97.DataName = "sunab_yn";
            this.multiLayoutItem97.IsUpdItem = true;
            // 
            // multiLayoutItem98
            // 
            this.multiLayoutItem98.DataName = "sunab_date";
            this.multiLayoutItem98.IsUpdItem = true;
            // 
            // multiLayoutItem99
            // 
            this.multiLayoutItem99.DataName = "sunab_time";
            this.multiLayoutItem99.IsUpdItem = true;
            // 
            // multiLayoutItem100
            // 
            this.multiLayoutItem100.DataName = "hope_date";
            this.multiLayoutItem100.IsUpdItem = true;
            // 
            // multiLayoutItem101
            // 
            this.multiLayoutItem101.DataName = "hope_time";
            this.multiLayoutItem101.IsUpdItem = true;
            // 
            // multiLayoutItem102
            // 
            this.multiLayoutItem102.DataName = "nurse_confirm_user";
            this.multiLayoutItem102.IsUpdItem = true;
            // 
            // multiLayoutItem103
            // 
            this.multiLayoutItem103.DataName = "nurse_confirm_date";
            this.multiLayoutItem103.IsUpdItem = true;
            // 
            // multiLayoutItem104
            // 
            this.multiLayoutItem104.DataName = "nurse_confirm_time";
            this.multiLayoutItem104.IsUpdItem = true;
            // 
            // multiLayoutItem105
            // 
            this.multiLayoutItem105.DataName = "nurse_pickup_user";
            this.multiLayoutItem105.IsUpdItem = true;
            // 
            // multiLayoutItem106
            // 
            this.multiLayoutItem106.DataName = "nurse_pickup_date";
            this.multiLayoutItem106.IsUpdItem = true;
            // 
            // multiLayoutItem107
            // 
            this.multiLayoutItem107.DataName = "nurse_pickup_time";
            this.multiLayoutItem107.IsUpdItem = true;
            // 
            // multiLayoutItem108
            // 
            this.multiLayoutItem108.DataName = "nurse_hold_user";
            this.multiLayoutItem108.IsUpdItem = true;
            // 
            // multiLayoutItem109
            // 
            this.multiLayoutItem109.DataName = "nurse_hold_date";
            this.multiLayoutItem109.IsUpdItem = true;
            // 
            // multiLayoutItem110
            // 
            this.multiLayoutItem110.DataName = "nurse_hold_time";
            this.multiLayoutItem110.IsUpdItem = true;
            // 
            // multiLayoutItem111
            // 
            this.multiLayoutItem111.DataName = "reser_date";
            this.multiLayoutItem111.IsUpdItem = true;
            // 
            // multiLayoutItem112
            // 
            this.multiLayoutItem112.DataName = "reser_time";
            this.multiLayoutItem112.IsUpdItem = true;
            // 
            // multiLayoutItem113
            // 
            this.multiLayoutItem113.DataName = "jubsu_date";
            this.multiLayoutItem113.IsUpdItem = true;
            // 
            // multiLayoutItem114
            // 
            this.multiLayoutItem114.DataName = "jubsu_time";
            this.multiLayoutItem114.IsUpdItem = true;
            // 
            // multiLayoutItem115
            // 
            this.multiLayoutItem115.DataName = "acting_date";
            this.multiLayoutItem115.IsUpdItem = true;
            // 
            // multiLayoutItem116
            // 
            this.multiLayoutItem116.DataName = "acting_time";
            this.multiLayoutItem116.IsUpdItem = true;
            // 
            // multiLayoutItem117
            // 
            this.multiLayoutItem117.DataName = "acting_day";
            this.multiLayoutItem117.IsUpdItem = true;
            // 
            // multiLayoutItem118
            // 
            this.multiLayoutItem118.DataName = "result_date";
            this.multiLayoutItem118.IsUpdItem = true;
            // 
            // multiLayoutItem119
            // 
            this.multiLayoutItem119.DataName = "dc_gubun";
            this.multiLayoutItem119.IsUpdItem = true;
            // 
            // multiLayoutItem120
            // 
            this.multiLayoutItem120.DataName = "dc_yn";
            this.multiLayoutItem120.IsUpdItem = true;
            // 
            // multiLayoutItem121
            // 
            this.multiLayoutItem121.DataName = "bannab_yn";
            this.multiLayoutItem121.IsUpdItem = true;
            // 
            // multiLayoutItem122
            // 
            this.multiLayoutItem122.DataName = "bannab_confirm";
            this.multiLayoutItem122.IsUpdItem = true;
            // 
            // multiLayoutItem123
            // 
            this.multiLayoutItem123.DataName = "source_ord_key";
            this.multiLayoutItem123.IsUpdItem = true;
            // 
            // multiLayoutItem124
            // 
            this.multiLayoutItem124.DataName = "ocs_flag";
            this.multiLayoutItem124.IsUpdItem = true;
            // 
            // multiLayoutItem125
            // 
            this.multiLayoutItem125.DataName = "sg_code";
            this.multiLayoutItem125.IsUpdItem = true;
            // 
            // multiLayoutItem126
            // 
            this.multiLayoutItem126.DataName = "sg_ymd";
            this.multiLayoutItem126.IsUpdItem = true;
            // 
            // multiLayoutItem127
            // 
            this.multiLayoutItem127.DataName = "io_gubun";
            this.multiLayoutItem127.IsUpdItem = true;
            // 
            // multiLayoutItem128
            // 
            this.multiLayoutItem128.DataName = "after_act_yn";
            this.multiLayoutItem128.IsUpdItem = true;
            // 
            // multiLayoutItem129
            // 
            this.multiLayoutItem129.DataName = "bichi_yn";
            this.multiLayoutItem129.IsUpdItem = true;
            // 
            // multiLayoutItem130
            // 
            this.multiLayoutItem130.DataName = "drg_bunho";
            this.multiLayoutItem130.IsUpdItem = true;
            // 
            // multiLayoutItem131
            // 
            this.multiLayoutItem131.DataName = "sub_susul";
            this.multiLayoutItem131.IsUpdItem = true;
            // 
            // multiLayoutItem132
            // 
            this.multiLayoutItem132.DataName = "print_yn";
            this.multiLayoutItem132.IsUpdItem = true;
            // 
            // multiLayoutItem133
            // 
            this.multiLayoutItem133.DataName = "chisik";
            this.multiLayoutItem133.IsUpdItem = true;
            // 
            // multiLayoutItem134
            // 
            this.multiLayoutItem134.DataName = "tel_yn";
            this.multiLayoutItem134.IsUpdItem = true;
            // 
            // multiLayoutItem135
            // 
            this.multiLayoutItem135.DataName = "order_gubun_bas";
            this.multiLayoutItem135.IsUpdItem = true;
            // 
            // multiLayoutItem136
            // 
            this.multiLayoutItem136.DataName = "input_control";
            this.multiLayoutItem136.IsUpdItem = true;
            // 
            // multiLayoutItem137
            // 
            this.multiLayoutItem137.DataName = "suga_yn";
            this.multiLayoutItem137.IsUpdItem = true;
            // 
            // multiLayoutItem138
            // 
            this.multiLayoutItem138.DataName = "jaeryo_yn";
            this.multiLayoutItem138.IsUpdItem = true;
            // 
            // multiLayoutItem139
            // 
            this.multiLayoutItem139.DataName = "wonyoi_check";
            this.multiLayoutItem139.IsUpdItem = true;
            // 
            // multiLayoutItem140
            // 
            this.multiLayoutItem140.DataName = "emergency_check";
            this.multiLayoutItem140.IsUpdItem = true;
            // 
            // multiLayoutItem141
            // 
            this.multiLayoutItem141.DataName = "specimen_check";
            // 
            // multiLayoutItem142
            // 
            this.multiLayoutItem142.DataName = "portable_check";
            this.multiLayoutItem142.IsUpdItem = true;
            // 
            // multiLayoutItem143
            // 
            this.multiLayoutItem143.DataName = "bulyong_check";
            this.multiLayoutItem143.IsUpdItem = true;
            // 
            // multiLayoutItem144
            // 
            this.multiLayoutItem144.DataName = "sunab_check";
            // 
            // multiLayoutItem145
            // 
            this.multiLayoutItem145.DataName = "dc_check";
            // 
            // multiLayoutItem146
            // 
            this.multiLayoutItem146.DataName = "dc_gubun_check";
            this.multiLayoutItem146.IsUpdItem = true;
            // 
            // multiLayoutItem147
            // 
            this.multiLayoutItem147.DataName = "confirm_check";
            this.multiLayoutItem147.IsUpdItem = true;
            // 
            // multiLayoutItem148
            // 
            this.multiLayoutItem148.DataName = "reser_yn_check";
            this.multiLayoutItem148.IsUpdItem = true;
            // 
            // multiLayoutItem149
            // 
            this.multiLayoutItem149.DataName = "chisik_check";
            this.multiLayoutItem149.IsUpdItem = true;
            // 
            // multiLayoutItem150
            // 
            this.multiLayoutItem150.DataName = "nday_yn";
            this.multiLayoutItem150.IsUpdItem = true;
            // 
            // multiLayoutItem151
            // 
            this.multiLayoutItem151.DataName = "default_jaeryo_jundal_yn";
            this.multiLayoutItem151.IsUpdItem = true;
            // 
            // multiLayoutItem152
            // 
            this.multiLayoutItem152.DataName = "default_wonyoi_order_yn";
            this.multiLayoutItem152.IsUpdItem = true;
            // 
            // multiLayoutItem153
            // 
            this.multiLayoutItem153.DataName = "specific_comment";
            this.multiLayoutItem153.IsUpdItem = true;
            // 
            // multiLayoutItem154
            // 
            this.multiLayoutItem154.DataName = "specific_comment_name";
            this.multiLayoutItem154.IsUpdItem = true;
            // 
            // multiLayoutItem155
            // 
            this.multiLayoutItem155.DataName = "specific_comment_sys_id";
            this.multiLayoutItem155.IsUpdItem = true;
            // 
            // multiLayoutItem156
            // 
            this.multiLayoutItem156.DataName = "specific_comment_pgm_id";
            this.multiLayoutItem156.IsUpdItem = true;
            // 
            // multiLayoutItem157
            // 
            this.multiLayoutItem157.DataName = "specific_comment_not_null";
            this.multiLayoutItem157.IsUpdItem = true;
            // 
            // multiLayoutItem158
            // 
            this.multiLayoutItem158.DataName = "specific_comment_table_id";
            this.multiLayoutItem158.IsUpdItem = true;
            // 
            // multiLayoutItem159
            // 
            this.multiLayoutItem159.DataName = "specific_comment_col_id";
            this.multiLayoutItem159.IsUpdItem = true;
            // 
            // multiLayoutItem160
            // 
            this.multiLayoutItem160.DataName = "donbog_yn";
            this.multiLayoutItem160.IsUpdItem = true;
            // 
            // multiLayoutItem161
            // 
            this.multiLayoutItem161.DataName = "order_gubun_bas_name";
            this.multiLayoutItem161.IsUpdItem = true;
            // 
            // multiLayoutItem311
            // 
            this.multiLayoutItem311.DataName = "act_doctor";
            this.multiLayoutItem311.IsUpdItem = true;
            // 
            // multiLayoutItem312
            // 
            this.multiLayoutItem312.DataName = "act_buseo";
            this.multiLayoutItem312.IsUpdItem = true;
            // 
            // multiLayoutItem313
            // 
            this.multiLayoutItem313.DataName = "act_gwa";
            this.multiLayoutItem313.IsUpdItem = true;
            // 
            // multiLayoutItem314
            // 
            this.multiLayoutItem314.DataName = "home_care_yn";
            this.multiLayoutItem314.IsUpdItem = true;
            // 
            // multiLayoutItem315
            // 
            this.multiLayoutItem315.DataName = "regular_yn";
            this.multiLayoutItem315.IsUpdItem = true;
            // 
            // multiLayoutItem316
            // 
            this.multiLayoutItem316.DataName = "sort_fkocskey";
            this.multiLayoutItem316.IsUpdItem = true;
            // 
            // multiLayoutItem317
            // 
            this.multiLayoutItem317.DataName = "child_yn";
            this.multiLayoutItem317.IsUpdItem = true;
            // 
            // multiLayoutItem318
            // 
            this.multiLayoutItem318.DataName = "child_exist_yn";
            this.multiLayoutItem318.IsUpdItem = true;
            // 
            // multiLayoutItem319
            // 
            this.multiLayoutItem319.DataName = "dv_5";
            this.multiLayoutItem319.IsUpdItem = true;
            // 
            // multiLayoutItem320
            // 
            this.multiLayoutItem320.DataName = "dv_6";
            this.multiLayoutItem320.IsUpdItem = true;
            // 
            // multiLayoutItem321
            // 
            this.multiLayoutItem321.DataName = "dv_7";
            this.multiLayoutItem321.IsUpdItem = true;
            // 
            // multiLayoutItem322
            // 
            this.multiLayoutItem322.DataName = "dv_8";
            this.multiLayoutItem322.IsUpdItem = true;
            // 
            // multiLayoutItem323
            // 
            this.multiLayoutItem323.DataName = "bogyong_code_sub";
            this.multiLayoutItem323.IsUpdItem = true;
            // 
            // multiLayoutItem324
            // 
            this.multiLayoutItem324.DataName = "bogyong_name_sub";
            this.multiLayoutItem324.IsUpdItem = true;
            // 
            // layDeletedData
            // 
            this.layDeletedData.CallerID = '2';
            this.layDeletedData.ExecuteQuery = null;
            this.layDeletedData.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem162,
            this.multiLayoutItem163,
            this.multiLayoutItem164,
            this.multiLayoutItem165,
            this.multiLayoutItem166,
            this.multiLayoutItem167,
            this.multiLayoutItem168,
            this.multiLayoutItem169,
            this.multiLayoutItem170,
            this.multiLayoutItem171,
            this.multiLayoutItem172,
            this.multiLayoutItem173,
            this.multiLayoutItem174,
            this.multiLayoutItem175,
            this.multiLayoutItem176,
            this.multiLayoutItem177,
            this.multiLayoutItem178,
            this.multiLayoutItem179,
            this.multiLayoutItem180,
            this.multiLayoutItem181,
            this.multiLayoutItem182,
            this.multiLayoutItem183,
            this.multiLayoutItem184,
            this.multiLayoutItem185,
            this.multiLayoutItem186,
            this.multiLayoutItem187,
            this.multiLayoutItem188,
            this.multiLayoutItem189,
            this.multiLayoutItem190,
            this.multiLayoutItem191,
            this.multiLayoutItem192,
            this.multiLayoutItem193,
            this.multiLayoutItem194,
            this.multiLayoutItem195,
            this.multiLayoutItem196,
            this.multiLayoutItem197,
            this.multiLayoutItem198,
            this.multiLayoutItem199,
            this.multiLayoutItem200,
            this.multiLayoutItem201,
            this.multiLayoutItem202,
            this.multiLayoutItem203,
            this.multiLayoutItem204,
            this.multiLayoutItem205,
            this.multiLayoutItem206,
            this.multiLayoutItem207,
            this.multiLayoutItem208,
            this.multiLayoutItem209,
            this.multiLayoutItem210,
            this.multiLayoutItem211,
            this.multiLayoutItem212,
            this.multiLayoutItem213,
            this.multiLayoutItem214,
            this.multiLayoutItem215,
            this.multiLayoutItem216,
            this.multiLayoutItem217,
            this.multiLayoutItem218,
            this.multiLayoutItem219,
            this.multiLayoutItem220,
            this.multiLayoutItem221,
            this.multiLayoutItem222,
            this.multiLayoutItem223,
            this.multiLayoutItem224,
            this.multiLayoutItem225,
            this.multiLayoutItem226,
            this.multiLayoutItem227,
            this.multiLayoutItem228,
            this.multiLayoutItem229,
            this.multiLayoutItem230,
            this.multiLayoutItem231,
            this.multiLayoutItem232,
            this.multiLayoutItem233,
            this.multiLayoutItem234,
            this.multiLayoutItem235,
            this.multiLayoutItem236,
            this.multiLayoutItem237,
            this.multiLayoutItem238,
            this.multiLayoutItem239,
            this.multiLayoutItem240,
            this.multiLayoutItem241,
            this.multiLayoutItem242,
            this.multiLayoutItem243,
            this.multiLayoutItem244,
            this.multiLayoutItem245,
            this.multiLayoutItem246,
            this.multiLayoutItem247,
            this.multiLayoutItem248,
            this.multiLayoutItem249,
            this.multiLayoutItem250,
            this.multiLayoutItem251,
            this.multiLayoutItem252,
            this.multiLayoutItem253,
            this.multiLayoutItem254,
            this.multiLayoutItem255,
            this.multiLayoutItem256,
            this.multiLayoutItem257,
            this.multiLayoutItem258,
            this.multiLayoutItem259,
            this.multiLayoutItem260,
            this.multiLayoutItem261,
            this.multiLayoutItem262,
            this.multiLayoutItem263,
            this.multiLayoutItem264,
            this.multiLayoutItem265,
            this.multiLayoutItem266,
            this.multiLayoutItem267,
            this.multiLayoutItem268,
            this.multiLayoutItem269,
            this.multiLayoutItem270,
            this.multiLayoutItem271,
            this.multiLayoutItem272,
            this.multiLayoutItem273,
            this.multiLayoutItem274,
            this.multiLayoutItem275,
            this.multiLayoutItem276,
            this.multiLayoutItem277,
            this.multiLayoutItem278,
            this.multiLayoutItem279,
            this.multiLayoutItem280,
            this.multiLayoutItem281,
            this.multiLayoutItem282,
            this.multiLayoutItem283,
            this.multiLayoutItem284,
            this.multiLayoutItem285,
            this.multiLayoutItem286,
            this.multiLayoutItem287,
            this.multiLayoutItem288,
            this.multiLayoutItem289,
            this.multiLayoutItem290,
            this.multiLayoutItem291,
            this.multiLayoutItem292,
            this.multiLayoutItem293,
            this.multiLayoutItem294,
            this.multiLayoutItem295,
            this.multiLayoutItem296,
            this.multiLayoutItem297,
            this.multiLayoutItem298,
            this.multiLayoutItem299,
            this.multiLayoutItem300,
            this.multiLayoutItem301,
            this.multiLayoutItem302,
            this.multiLayoutItem303,
            this.multiLayoutItem304,
            this.multiLayoutItem305,
            this.multiLayoutItem306,
            this.multiLayoutItem307,
            this.multiLayoutItem308,
            this.multiLayoutItem309});
            this.layDeletedData.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDeletedData.ParamList")));
            this.layDeletedData.UseDefaultTransaction = false;
            // 
            // multiLayoutItem162
            // 
            this.multiLayoutItem162.DataName = "in_out_key";
            this.multiLayoutItem162.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem162.IsUpdItem = true;
            // 
            // multiLayoutItem163
            // 
            this.multiLayoutItem163.DataName = "pkocskey";
            this.multiLayoutItem163.IsUpdItem = true;
            // 
            // multiLayoutItem164
            // 
            this.multiLayoutItem164.DataName = "bunho";
            this.multiLayoutItem164.IsUpdItem = true;
            // 
            // multiLayoutItem165
            // 
            this.multiLayoutItem165.DataName = "order_date";
            this.multiLayoutItem165.IsUpdItem = true;
            // 
            // multiLayoutItem166
            // 
            this.multiLayoutItem166.DataName = "gwa";
            this.multiLayoutItem166.IsUpdItem = true;
            // 
            // multiLayoutItem167
            // 
            this.multiLayoutItem167.DataName = "doctor";
            this.multiLayoutItem167.IsUpdItem = true;
            // 
            // multiLayoutItem168
            // 
            this.multiLayoutItem168.DataName = "resident";
            this.multiLayoutItem168.IsUpdItem = true;
            // 
            // multiLayoutItem169
            // 
            this.multiLayoutItem169.DataName = "naewon_type";
            this.multiLayoutItem169.IsUpdItem = true;
            // 
            // multiLayoutItem170
            // 
            this.multiLayoutItem170.DataName = "jubsu_no";
            this.multiLayoutItem170.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem170.IsUpdItem = true;
            // 
            // multiLayoutItem171
            // 
            this.multiLayoutItem171.DataName = "input_id";
            this.multiLayoutItem171.IsUpdItem = true;
            // 
            // multiLayoutItem172
            // 
            this.multiLayoutItem172.DataName = "input_part";
            this.multiLayoutItem172.IsUpdItem = true;
            // 
            // multiLayoutItem173
            // 
            this.multiLayoutItem173.DataName = "input_gwa";
            this.multiLayoutItem173.IsUpdItem = true;
            // 
            // multiLayoutItem174
            // 
            this.multiLayoutItem174.DataName = "input_doctor";
            this.multiLayoutItem174.IsUpdItem = true;
            // 
            // multiLayoutItem175
            // 
            this.multiLayoutItem175.DataName = "input_gubun";
            this.multiLayoutItem175.IsUpdItem = true;
            // 
            // multiLayoutItem176
            // 
            this.multiLayoutItem176.DataName = "input_gubun_name";
            // 
            // multiLayoutItem177
            // 
            this.multiLayoutItem177.DataName = "group_ser";
            this.multiLayoutItem177.IsUpdItem = true;
            // 
            // multiLayoutItem178
            // 
            this.multiLayoutItem178.DataName = "input_tab";
            this.multiLayoutItem178.IsUpdItem = true;
            // 
            // multiLayoutItem179
            // 
            this.multiLayoutItem179.DataName = "input_tab_name";
            // 
            // multiLayoutItem180
            // 
            this.multiLayoutItem180.DataName = "order_gubun";
            this.multiLayoutItem180.IsUpdItem = true;
            // 
            // multiLayoutItem181
            // 
            this.multiLayoutItem181.DataName = "order_gubun_name";
            // 
            // multiLayoutItem182
            // 
            this.multiLayoutItem182.DataName = "group_yn";
            this.multiLayoutItem182.IsUpdItem = true;
            // 
            // multiLayoutItem183
            // 
            this.multiLayoutItem183.DataName = "seq";
            this.multiLayoutItem183.IsUpdItem = true;
            // 
            // multiLayoutItem184
            // 
            this.multiLayoutItem184.DataName = "slip_code";
            this.multiLayoutItem184.IsUpdItem = true;
            // 
            // multiLayoutItem185
            // 
            this.multiLayoutItem185.DataName = "hangmog_code";
            this.multiLayoutItem185.IsUpdItem = true;
            // 
            // multiLayoutItem186
            // 
            this.multiLayoutItem186.DataName = "hangmog_name";
            // 
            // multiLayoutItem187
            // 
            this.multiLayoutItem187.DataName = "specimen_code";
            this.multiLayoutItem187.IsUpdItem = true;
            // 
            // multiLayoutItem188
            // 
            this.multiLayoutItem188.DataName = "specimen_name";
            // 
            // multiLayoutItem189
            // 
            this.multiLayoutItem189.DataName = "suryang";
            this.multiLayoutItem189.IsUpdItem = true;
            // 
            // multiLayoutItem190
            // 
            this.multiLayoutItem190.DataName = "sunab_suryang";
            this.multiLayoutItem190.IsUpdItem = true;
            // 
            // multiLayoutItem191
            // 
            this.multiLayoutItem191.DataName = "subul_suryang";
            this.multiLayoutItem191.IsUpdItem = true;
            // 
            // multiLayoutItem192
            // 
            this.multiLayoutItem192.DataName = "ord_danui";
            this.multiLayoutItem192.IsUpdItem = true;
            // 
            // multiLayoutItem193
            // 
            this.multiLayoutItem193.DataName = "ord_danui_name";
            // 
            // multiLayoutItem194
            // 
            this.multiLayoutItem194.DataName = "dv_time";
            this.multiLayoutItem194.IsUpdItem = true;
            // 
            // multiLayoutItem195
            // 
            this.multiLayoutItem195.DataName = "dv";
            this.multiLayoutItem195.IsUpdItem = true;
            // 
            // multiLayoutItem196
            // 
            this.multiLayoutItem196.DataName = "dv_1";
            this.multiLayoutItem196.IsUpdItem = true;
            // 
            // multiLayoutItem197
            // 
            this.multiLayoutItem197.DataName = "dv_2";
            this.multiLayoutItem197.IsUpdItem = true;
            // 
            // multiLayoutItem198
            // 
            this.multiLayoutItem198.DataName = "dv_3";
            this.multiLayoutItem198.IsUpdItem = true;
            // 
            // multiLayoutItem199
            // 
            this.multiLayoutItem199.DataName = "dv_4";
            this.multiLayoutItem199.IsUpdItem = true;
            // 
            // multiLayoutItem200
            // 
            this.multiLayoutItem200.DataName = "nalsu";
            this.multiLayoutItem200.IsUpdItem = true;
            // 
            // multiLayoutItem201
            // 
            this.multiLayoutItem201.DataName = "sunab_nalsu";
            this.multiLayoutItem201.IsUpdItem = true;
            // 
            // multiLayoutItem202
            // 
            this.multiLayoutItem202.DataName = "jusa";
            this.multiLayoutItem202.IsUpdItem = true;
            // 
            // multiLayoutItem203
            // 
            this.multiLayoutItem203.DataName = "jusa_name";
            this.multiLayoutItem203.IsUpdItem = true;
            // 
            // multiLayoutItem204
            // 
            this.multiLayoutItem204.DataName = "jusa_spd_gubun";
            this.multiLayoutItem204.IsUpdItem = true;
            // 
            // multiLayoutItem205
            // 
            this.multiLayoutItem205.DataName = "bogyong_code";
            this.multiLayoutItem205.IsUpdItem = true;
            // 
            // multiLayoutItem206
            // 
            this.multiLayoutItem206.DataName = "bogyong_name";
            this.multiLayoutItem206.IsUpdItem = true;
            // 
            // multiLayoutItem207
            // 
            this.multiLayoutItem207.DataName = "emergency";
            this.multiLayoutItem207.IsUpdItem = true;
            // 
            // multiLayoutItem208
            // 
            this.multiLayoutItem208.DataName = "jaeryo_jundal_yn";
            this.multiLayoutItem208.IsUpdItem = true;
            // 
            // multiLayoutItem209
            // 
            this.multiLayoutItem209.DataName = "jundal_table";
            this.multiLayoutItem209.IsUpdItem = true;
            // 
            // multiLayoutItem210
            // 
            this.multiLayoutItem210.DataName = "jundal_part";
            this.multiLayoutItem210.IsUpdItem = true;
            // 
            // multiLayoutItem211
            // 
            this.multiLayoutItem211.DataName = "move_part";
            this.multiLayoutItem211.IsUpdItem = true;
            // 
            // multiLayoutItem212
            // 
            this.multiLayoutItem212.DataName = "portable_yn";
            this.multiLayoutItem212.IsUpdItem = true;
            // 
            // multiLayoutItem213
            // 
            this.multiLayoutItem213.DataName = "powder_yn";
            this.multiLayoutItem213.IsUpdItem = true;
            // 
            // multiLayoutItem214
            // 
            this.multiLayoutItem214.DataName = "hubal_change_yn";
            this.multiLayoutItem214.IsUpdItem = true;
            // 
            // multiLayoutItem215
            // 
            this.multiLayoutItem215.DataName = "pharmacy";
            this.multiLayoutItem215.IsUpdItem = true;
            // 
            // multiLayoutItem216
            // 
            this.multiLayoutItem216.DataName = "drg_pack_yn";
            this.multiLayoutItem216.IsUpdItem = true;
            // 
            // multiLayoutItem217
            // 
            this.multiLayoutItem217.DataName = "muhyo";
            this.multiLayoutItem217.IsUpdItem = true;
            // 
            // multiLayoutItem218
            // 
            this.multiLayoutItem218.DataName = "prn_yn";
            this.multiLayoutItem218.IsUpdItem = true;
            // 
            // multiLayoutItem219
            // 
            this.multiLayoutItem219.DataName = "toiwon_drg_yn";
            this.multiLayoutItem219.IsUpdItem = true;
            // 
            // multiLayoutItem220
            // 
            this.multiLayoutItem220.DataName = "prn_nurse";
            this.multiLayoutItem220.IsUpdItem = true;
            // 
            // multiLayoutItem221
            // 
            this.multiLayoutItem221.DataName = "append_yn";
            this.multiLayoutItem221.IsUpdItem = true;
            // 
            // multiLayoutItem222
            // 
            this.multiLayoutItem222.DataName = "order_remark";
            this.multiLayoutItem222.IsUpdItem = true;
            // 
            // multiLayoutItem223
            // 
            this.multiLayoutItem223.DataName = "nurse_remark";
            this.multiLayoutItem223.IsUpdItem = true;
            // 
            // multiLayoutItem224
            // 
            this.multiLayoutItem224.DataName = "comment";
            this.multiLayoutItem224.IsUpdItem = true;
            // 
            // multiLayoutItem225
            // 
            this.multiLayoutItem225.DataName = "mix_group";
            this.multiLayoutItem225.IsUpdItem = true;
            // 
            // multiLayoutItem226
            // 
            this.multiLayoutItem226.DataName = "amt";
            this.multiLayoutItem226.IsUpdItem = true;
            // 
            // multiLayoutItem227
            // 
            this.multiLayoutItem227.DataName = "pay";
            this.multiLayoutItem227.IsUpdItem = true;
            // 
            // multiLayoutItem228
            // 
            this.multiLayoutItem228.DataName = "wonyoi_order_yn";
            this.multiLayoutItem228.IsUpdItem = true;
            // 
            // multiLayoutItem229
            // 
            this.multiLayoutItem229.DataName = "dangil_gumsa_order_yn";
            this.multiLayoutItem229.IsUpdItem = true;
            // 
            // multiLayoutItem230
            // 
            this.multiLayoutItem230.DataName = "dangil_gumsa_result_yn";
            this.multiLayoutItem230.IsUpdItem = true;
            // 
            // multiLayoutItem231
            // 
            this.multiLayoutItem231.DataName = "bom_occur_yn";
            this.multiLayoutItem231.IsUpdItem = true;
            // 
            // multiLayoutItem232
            // 
            this.multiLayoutItem232.DataName = "bom_source_key";
            this.multiLayoutItem232.IsUpdItem = true;
            // 
            // multiLayoutItem233
            // 
            this.multiLayoutItem233.DataName = "display_yn";
            this.multiLayoutItem233.IsUpdItem = true;
            // 
            // multiLayoutItem234
            // 
            this.multiLayoutItem234.DataName = "sunab_yn";
            this.multiLayoutItem234.IsUpdItem = true;
            // 
            // multiLayoutItem235
            // 
            this.multiLayoutItem235.DataName = "sunab_date";
            this.multiLayoutItem235.IsUpdItem = true;
            // 
            // multiLayoutItem236
            // 
            this.multiLayoutItem236.DataName = "sunab_time";
            this.multiLayoutItem236.IsUpdItem = true;
            // 
            // multiLayoutItem237
            // 
            this.multiLayoutItem237.DataName = "hope_date";
            this.multiLayoutItem237.IsUpdItem = true;
            // 
            // multiLayoutItem238
            // 
            this.multiLayoutItem238.DataName = "hope_time";
            this.multiLayoutItem238.IsUpdItem = true;
            // 
            // multiLayoutItem239
            // 
            this.multiLayoutItem239.DataName = "nurse_confirm_user";
            this.multiLayoutItem239.IsUpdItem = true;
            // 
            // multiLayoutItem240
            // 
            this.multiLayoutItem240.DataName = "nurse_confirm_date";
            this.multiLayoutItem240.IsUpdItem = true;
            // 
            // multiLayoutItem241
            // 
            this.multiLayoutItem241.DataName = "nurse_confirm_time";
            this.multiLayoutItem241.IsUpdItem = true;
            // 
            // multiLayoutItem242
            // 
            this.multiLayoutItem242.DataName = "nurse_pickup_user";
            this.multiLayoutItem242.IsUpdItem = true;
            // 
            // multiLayoutItem243
            // 
            this.multiLayoutItem243.DataName = "nurse_pickup_date";
            this.multiLayoutItem243.IsUpdItem = true;
            // 
            // multiLayoutItem244
            // 
            this.multiLayoutItem244.DataName = "nurse_pickup_time";
            this.multiLayoutItem244.IsUpdItem = true;
            // 
            // multiLayoutItem245
            // 
            this.multiLayoutItem245.DataName = "nurse_hold_user";
            this.multiLayoutItem245.IsUpdItem = true;
            // 
            // multiLayoutItem246
            // 
            this.multiLayoutItem246.DataName = "nurse_hold_date";
            this.multiLayoutItem246.IsUpdItem = true;
            // 
            // multiLayoutItem247
            // 
            this.multiLayoutItem247.DataName = "nurse_hold_time";
            this.multiLayoutItem247.IsUpdItem = true;
            // 
            // multiLayoutItem248
            // 
            this.multiLayoutItem248.DataName = "reser_date";
            this.multiLayoutItem248.IsUpdItem = true;
            // 
            // multiLayoutItem249
            // 
            this.multiLayoutItem249.DataName = "reser_time";
            this.multiLayoutItem249.IsUpdItem = true;
            // 
            // multiLayoutItem250
            // 
            this.multiLayoutItem250.DataName = "jubsu_date";
            this.multiLayoutItem250.IsUpdItem = true;
            // 
            // multiLayoutItem251
            // 
            this.multiLayoutItem251.DataName = "jubsu_time";
            this.multiLayoutItem251.IsUpdItem = true;
            // 
            // multiLayoutItem252
            // 
            this.multiLayoutItem252.DataName = "acting_date";
            this.multiLayoutItem252.IsUpdItem = true;
            // 
            // multiLayoutItem253
            // 
            this.multiLayoutItem253.DataName = "acting_time";
            this.multiLayoutItem253.IsUpdItem = true;
            // 
            // multiLayoutItem254
            // 
            this.multiLayoutItem254.DataName = "acting_day";
            this.multiLayoutItem254.IsUpdItem = true;
            // 
            // multiLayoutItem255
            // 
            this.multiLayoutItem255.DataName = "result_date";
            this.multiLayoutItem255.IsUpdItem = true;
            // 
            // multiLayoutItem256
            // 
            this.multiLayoutItem256.DataName = "dc_gubun";
            this.multiLayoutItem256.IsUpdItem = true;
            // 
            // multiLayoutItem257
            // 
            this.multiLayoutItem257.DataName = "dc_yn";
            this.multiLayoutItem257.IsUpdItem = true;
            // 
            // multiLayoutItem258
            // 
            this.multiLayoutItem258.DataName = "bannab_yn";
            this.multiLayoutItem258.IsUpdItem = true;
            // 
            // multiLayoutItem259
            // 
            this.multiLayoutItem259.DataName = "bannab_confirm";
            this.multiLayoutItem259.IsUpdItem = true;
            // 
            // multiLayoutItem260
            // 
            this.multiLayoutItem260.DataName = "source_ord_key";
            this.multiLayoutItem260.IsUpdItem = true;
            // 
            // multiLayoutItem261
            // 
            this.multiLayoutItem261.DataName = "ocs_flag";
            this.multiLayoutItem261.IsUpdItem = true;
            // 
            // multiLayoutItem262
            // 
            this.multiLayoutItem262.DataName = "sg_code";
            this.multiLayoutItem262.IsUpdItem = true;
            // 
            // multiLayoutItem263
            // 
            this.multiLayoutItem263.DataName = "sg_ymd";
            this.multiLayoutItem263.IsUpdItem = true;
            // 
            // multiLayoutItem264
            // 
            this.multiLayoutItem264.DataName = "io_gubun";
            this.multiLayoutItem264.IsUpdItem = true;
            // 
            // multiLayoutItem265
            // 
            this.multiLayoutItem265.DataName = "after_act_yn";
            this.multiLayoutItem265.IsUpdItem = true;
            // 
            // multiLayoutItem266
            // 
            this.multiLayoutItem266.DataName = "bichi_yn";
            this.multiLayoutItem266.IsUpdItem = true;
            // 
            // multiLayoutItem267
            // 
            this.multiLayoutItem267.DataName = "drg_bunho";
            this.multiLayoutItem267.IsUpdItem = true;
            // 
            // multiLayoutItem268
            // 
            this.multiLayoutItem268.DataName = "sub_susul";
            this.multiLayoutItem268.IsUpdItem = true;
            // 
            // multiLayoutItem269
            // 
            this.multiLayoutItem269.DataName = "print_yn";
            this.multiLayoutItem269.IsUpdItem = true;
            // 
            // multiLayoutItem270
            // 
            this.multiLayoutItem270.DataName = "chisik";
            this.multiLayoutItem270.IsUpdItem = true;
            // 
            // multiLayoutItem271
            // 
            this.multiLayoutItem271.DataName = "tel_yn";
            this.multiLayoutItem271.IsUpdItem = true;
            // 
            // multiLayoutItem272
            // 
            this.multiLayoutItem272.DataName = "order_gubun_bas";
            this.multiLayoutItem272.IsUpdItem = true;
            // 
            // multiLayoutItem273
            // 
            this.multiLayoutItem273.DataName = "input_control";
            this.multiLayoutItem273.IsUpdItem = true;
            // 
            // multiLayoutItem274
            // 
            this.multiLayoutItem274.DataName = "suga_yn";
            this.multiLayoutItem274.IsUpdItem = true;
            // 
            // multiLayoutItem275
            // 
            this.multiLayoutItem275.DataName = "jaeryo_yn";
            this.multiLayoutItem275.IsUpdItem = true;
            // 
            // multiLayoutItem276
            // 
            this.multiLayoutItem276.DataName = "wonyoi_check";
            this.multiLayoutItem276.IsUpdItem = true;
            // 
            // multiLayoutItem277
            // 
            this.multiLayoutItem277.DataName = "emergency_check";
            this.multiLayoutItem277.IsUpdItem = true;
            // 
            // multiLayoutItem278
            // 
            this.multiLayoutItem278.DataName = "specimen_check";
            // 
            // multiLayoutItem279
            // 
            this.multiLayoutItem279.DataName = "portable_check";
            this.multiLayoutItem279.IsUpdItem = true;
            // 
            // multiLayoutItem280
            // 
            this.multiLayoutItem280.DataName = "bulyong_check";
            this.multiLayoutItem280.IsUpdItem = true;
            // 
            // multiLayoutItem281
            // 
            this.multiLayoutItem281.DataName = "sunab_check";
            // 
            // multiLayoutItem282
            // 
            this.multiLayoutItem282.DataName = "dc_check";
            // 
            // multiLayoutItem283
            // 
            this.multiLayoutItem283.DataName = "dc_gubun_check";
            this.multiLayoutItem283.IsUpdItem = true;
            // 
            // multiLayoutItem284
            // 
            this.multiLayoutItem284.DataName = "confirm_check";
            this.multiLayoutItem284.IsUpdItem = true;
            // 
            // multiLayoutItem285
            // 
            this.multiLayoutItem285.DataName = "reser_yn_check";
            this.multiLayoutItem285.IsUpdItem = true;
            // 
            // multiLayoutItem286
            // 
            this.multiLayoutItem286.DataName = "chisik_check";
            this.multiLayoutItem286.IsUpdItem = true;
            // 
            // multiLayoutItem287
            // 
            this.multiLayoutItem287.DataName = "nday_yn";
            this.multiLayoutItem287.IsUpdItem = true;
            // 
            // multiLayoutItem288
            // 
            this.multiLayoutItem288.DataName = "default_jaeryo_jundal_yn";
            this.multiLayoutItem288.IsUpdItem = true;
            // 
            // multiLayoutItem289
            // 
            this.multiLayoutItem289.DataName = "default_wonyoi_order_yn";
            this.multiLayoutItem289.IsUpdItem = true;
            // 
            // multiLayoutItem290
            // 
            this.multiLayoutItem290.DataName = "specific_comment";
            this.multiLayoutItem290.IsUpdItem = true;
            // 
            // multiLayoutItem291
            // 
            this.multiLayoutItem291.DataName = "specific_comment_name";
            this.multiLayoutItem291.IsUpdItem = true;
            // 
            // multiLayoutItem292
            // 
            this.multiLayoutItem292.DataName = "specific_comment_sys_id";
            this.multiLayoutItem292.IsUpdItem = true;
            // 
            // multiLayoutItem293
            // 
            this.multiLayoutItem293.DataName = "specific_comment_pgm_id";
            this.multiLayoutItem293.IsUpdItem = true;
            // 
            // multiLayoutItem294
            // 
            this.multiLayoutItem294.DataName = "specific_comment_not_null";
            this.multiLayoutItem294.IsUpdItem = true;
            // 
            // multiLayoutItem295
            // 
            this.multiLayoutItem295.DataName = "specific_comment_table_id";
            this.multiLayoutItem295.IsUpdItem = true;
            // 
            // multiLayoutItem296
            // 
            this.multiLayoutItem296.DataName = "specific_comment_col_id";
            this.multiLayoutItem296.IsUpdItem = true;
            // 
            // multiLayoutItem297
            // 
            this.multiLayoutItem297.DataName = "donbog_yn";
            this.multiLayoutItem297.IsUpdItem = true;
            // 
            // multiLayoutItem298
            // 
            this.multiLayoutItem298.DataName = "order_gubun_bas_name";
            this.multiLayoutItem298.IsUpdItem = true;
            // 
            // multiLayoutItem299
            // 
            this.multiLayoutItem299.DataName = "act_doctor";
            this.multiLayoutItem299.IsUpdItem = true;
            // 
            // multiLayoutItem300
            // 
            this.multiLayoutItem300.DataName = "act_buseo";
            this.multiLayoutItem300.IsUpdItem = true;
            // 
            // multiLayoutItem301
            // 
            this.multiLayoutItem301.DataName = "act_gwa";
            this.multiLayoutItem301.IsUpdItem = true;
            // 
            // multiLayoutItem302
            // 
            this.multiLayoutItem302.DataName = "home_care_yn";
            this.multiLayoutItem302.IsUpdItem = true;
            // 
            // multiLayoutItem303
            // 
            this.multiLayoutItem303.DataName = "regular_yn";
            this.multiLayoutItem303.IsUpdItem = true;
            // 
            // multiLayoutItem304
            // 
            this.multiLayoutItem304.DataName = "sort_fkocskey";
            this.multiLayoutItem304.IsUpdItem = true;
            // 
            // multiLayoutItem305
            // 
            this.multiLayoutItem305.DataName = "child_yn";
            this.multiLayoutItem305.IsUpdItem = true;
            // 
            // multiLayoutItem306
            // 
            this.multiLayoutItem306.DataName = "child_exist_yn";
            this.multiLayoutItem306.IsUpdItem = true;
            // 
            // multiLayoutItem307
            // 
            this.multiLayoutItem307.DataName = "dummy";
            // 
            // multiLayoutItem308
            // 
            this.multiLayoutItem308.DataName = "bogyong_code_sub";
            this.multiLayoutItem308.IsUpdItem = true;
            // 
            // multiLayoutItem309
            // 
            this.multiLayoutItem309.DataName = "bogyong_name_sub";
            this.multiLayoutItem309.IsUpdItem = true;
            // 
            // UCOCS0103U10
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlFill);
            this.Name = "UCOCS0103U10";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.pnlFill.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlSearchOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchOrder)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdGeneral)).EndInit();
            this.tabWonnaeDrg.ResumeLayout(false);
            this.pnlSangyong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSangyongOrder)).EndInit();
            this.pnlDrug.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDrgOrder)).EndInit();
            this.pnlPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPreview)).EndInit();
            this.pnlSearchTool.ResumeLayout(false);
            this.pnlSearchTool.PerformLayout();
            this.grbGeneric.ResumeLayout(false);
            this.grbGeneric.PerformLayout();
            this.pnlRightBottom.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            this.pnlOrderInfo.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).EndInit();
            this.pnlOrderDetail.ResumeLayout(false);
            this.pnlOrderDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIsBgtDrg)).EndInit();
            this.pnlOrderInput.ResumeLayout(false);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOutSang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGroupTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDrugTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySaveLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDeletedData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XPanel pnlFill;
        private System.Windows.Forms.ImageList imageListPopupMenu;
        private System.Windows.Forms.ImageList imageListMixGroup;
        //private System.Windows.Forms.ImageList ImageList;
        private IHIS.Framework.XPanel pnlOrderInfo;
        private IHIS.Framework.XPanel pnlOrderInput;
        private IHIS.Framework.XEditGrid grdOutSang;
        private IHIS.Framework.XPanel xPanel1;
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
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell16;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private System.Windows.Forms.ImageList imageListInfo;
        private IHIS.Framework.XEditGridCell xEditGridCell349;
        private IHIS.Framework.XEditGrid grdOrder;
        private IHIS.Framework.XEditGridCell xEditGridCell351;
        private IHIS.Framework.XEditGridCell xEditGridCell358;
        private IHIS.Framework.XEditGridCell xEditGridCell359;
        private IHIS.Framework.XEditGridCell xEditGridCell360;
        private IHIS.Framework.XEditGridCell xEditGridCell361;
        private IHIS.Framework.XEditGridCell xEditGridCell362;
        private IHIS.Framework.XEditGridCell xEditGridCell363;
        private IHIS.Framework.XEditGridCell xEditGridCell364;
        private IHIS.Framework.XEditGridCell xEditGridCell365;
        private IHIS.Framework.XEditGridCell xEditGridCell366;
        private IHIS.Framework.XEditGridCell xEditGridCell367;
        private IHIS.Framework.XEditGridCell xEditGridCell368;
        private IHIS.Framework.XEditGridCell xEditGridCell369;
        private IHIS.Framework.XEditGridCell xEditGridCell370;
        private IHIS.Framework.XEditGridCell xEditGridCell371;
        private IHIS.Framework.XEditGridCell xEditGridCell372;
        private IHIS.Framework.XEditGridCell xEditGridCell373;
        private IHIS.Framework.XEditGridCell xEditGridCell374;
        private IHIS.Framework.XEditGridCell xEditGridCell375;
        private IHIS.Framework.XEditGridCell xEditGridCell376;
        private IHIS.Framework.XEditGridCell xEditGridCell377;
        private IHIS.Framework.XEditGridCell xEditGridCell378;
        private IHIS.Framework.XEditGridCell xEditGridCell379;
        private IHIS.Framework.XEditGridCell xEditGridCell380;
        private IHIS.Framework.XEditGridCell xEditGridCell384;
        private IHIS.Framework.XEditGridCell xEditGridCell385;
        private IHIS.Framework.XEditGridCell xEditGridCell386;
        private IHIS.Framework.XEditGridCell xEditGridCell387;
        private IHIS.Framework.XEditGridCell xEditGridCell388;
        private IHIS.Framework.XEditGridCell xEditGridCell389;
        private IHIS.Framework.XEditGridCell xEditGridCell390;
        private IHIS.Framework.XEditGridCell xEditGridCell391;
        private IHIS.Framework.XEditGridCell xEditGridCell392;
        private IHIS.Framework.XEditGridCell xEditGridCell393;
        private IHIS.Framework.XEditGridCell xEditGridCell394;
        private IHIS.Framework.XEditGridCell xEditGridCell395;
        private IHIS.Framework.XEditGridCell xEditGridCell396;
        private IHIS.Framework.XEditGridCell xEditGridCell397;
        private IHIS.Framework.XEditGridCell xEditGridCell398;
        private IHIS.Framework.XEditGridCell xEditGridCell399;
        private IHIS.Framework.XEditGridCell xEditGridCell400;
        private IHIS.Framework.XEditGridCell xEditGridCell401;
        private IHIS.Framework.XEditGridCell xEditGridCell402;
        private IHIS.Framework.XEditGridCell xEditGridCell403;
        private IHIS.Framework.XEditGridCell xEditGridCell404;
        private IHIS.Framework.XEditGridCell xEditGridCell405;
        private IHIS.Framework.XEditGridCell xEditGridCell406;
        private IHIS.Framework.XEditGridCell xEditGridCell407;
        private IHIS.Framework.XEditGridCell xEditGridCell408;
        private IHIS.Framework.XEditGridCell xEditGridCell409;
        private IHIS.Framework.XEditGridCell xEditGridCell410;
        private IHIS.Framework.XEditGridCell xEditGridCell411;
        private IHIS.Framework.XEditGridCell xEditGridCell412;
        private IHIS.Framework.XEditGridCell xEditGridCell413;
        private IHIS.Framework.XEditGridCell xEditGridCell414;
        private IHIS.Framework.XEditGridCell xEditGridCell415;
        private IHIS.Framework.XEditGridCell xEditGridCell416;
        private IHIS.Framework.XEditGridCell xEditGridCell417;
        private IHIS.Framework.XEditGridCell xEditGridCell418;
        private IHIS.Framework.XEditGridCell xEditGridCell419;
        private IHIS.Framework.XEditGridCell xEditGridCell420;
        private IHIS.Framework.XEditGridCell xEditGridCell421;
        private IHIS.Framework.XEditGridCell xEditGridCell422;
        private IHIS.Framework.XEditGridCell xEditGridCell423;
        private IHIS.Framework.XEditGridCell xEditGridCell424;
        private IHIS.Framework.XEditGridCell xEditGridCell425;
        private IHIS.Framework.XEditGridCell xEditGridCell426;
        private IHIS.Framework.XEditGridCell xEditGridCell427;
        private IHIS.Framework.XEditGridCell xEditGridCell428;
        private IHIS.Framework.XEditGridCell xEditGridCell429;
        private IHIS.Framework.XEditGridCell xEditGridCell430;
        private IHIS.Framework.XEditGridCell xEditGridCell431;
        private IHIS.Framework.XEditGridCell xEditGridCell432;
        private IHIS.Framework.XEditGridCell xEditGridCell433;
        private IHIS.Framework.XEditGridCell xEditGridCell434;
        private IHIS.Framework.XEditGridCell xEditGridCell435;
        private IHIS.Framework.XEditGridCell xEditGridCell436;
        private IHIS.Framework.XEditGridCell xEditGridCell437;
        private IHIS.Framework.XEditGridCell xEditGridCell438;
        private IHIS.Framework.XEditGridCell xEditGridCell439;
        private IHIS.Framework.XEditGridCell xEditGridCell440;
        private IHIS.Framework.XEditGridCell xEditGridCell441;
        private IHIS.Framework.XEditGridCell xEditGridCell442;
        private IHIS.Framework.XEditGridCell xEditGridCell443;
        private IHIS.Framework.XEditGridCell xEditGridCell444;
        private IHIS.Framework.XEditGridCell xEditGridCell445;
        private IHIS.Framework.XEditGridCell xEditGridCell446;
        private IHIS.Framework.XEditGridCell xEditGridCell447;
        private IHIS.Framework.XEditGridCell xEditGridCell448;
        private IHIS.Framework.XEditGridCell xEditGridCell449;
        private IHIS.Framework.XEditGridCell xEditGridCell450;
        private IHIS.Framework.XEditGridCell xEditGridCell451;
        private IHIS.Framework.XEditGridCell xEditGridCell452;
        private IHIS.Framework.XEditGridCell xEditGridCell453;
        private IHIS.Framework.XEditGridCell xEditGridCell454;
        private IHIS.Framework.XEditGridCell xEditGridCell455;
        private IHIS.Framework.XEditGridCell xEditGridCell456;
        private IHIS.Framework.XEditGridCell xEditGridCell457;
        private IHIS.Framework.XEditGridCell xEditGridCell458;
        private IHIS.Framework.XEditGridCell xEditGridCell459;
        private IHIS.Framework.XEditGridCell xEditGridCell460;
        private IHIS.Framework.XEditGridCell xEditGridCell461;
        private IHIS.Framework.XEditGridCell xEditGridCell464;
        private IHIS.Framework.XEditGridCell xEditGridCell465;
        private IHIS.Framework.XEditGridCell xEditGridCell466;
        private IHIS.Framework.XEditGridCell xEditGridCell467;
        private IHIS.Framework.XEditGridCell xEditGridCell468;
        private IHIS.Framework.XEditGridCell xEditGridCell469;
        private IHIS.Framework.XEditGridCell xEditGridCell470;
        private IHIS.Framework.XEditGridCell xEditGridCell471;
        private IHIS.Framework.XEditGridCell xEditGridCell472;
        private IHIS.Framework.XEditGridCell xEditGridCell473;
        private IHIS.Framework.XEditGridCell xEditGridCell474;
        private IHIS.Framework.XEditGridCell xEditGridCell475;
        private IHIS.Framework.XEditGridCell xEditGridCell476;
        private IHIS.Framework.XEditGridCell xEditGridCell477;
        private IHIS.Framework.XEditGridCell xEditGridCell478;
        private IHIS.Framework.XEditGridCell xEditGridCell479;
        private IHIS.Framework.XEditGridCell xEditGridCell480;
        private IHIS.Framework.XEditGridCell xEditGridCell481;
        private IHIS.Framework.XEditGridCell xEditGridCell482;
        private IHIS.Framework.XEditGridCell xEditGridCell483;
        private IHIS.Framework.XEditGridCell xEditGridCell484;
        private IHIS.Framework.XEditGridCell xEditGridCell485;
        private IHIS.Framework.XEditGridCell xEditGridCell486;
        private IHIS.Framework.XEditGridCell xEditGridCell487;
        private IHIS.Framework.XEditGridCell xEditGridCell488;
        private IHIS.Framework.XEditGridCell xEditGridCell489;
        private IHIS.Framework.XEditGridCell xEditGridCell490;
        private IHIS.Framework.XEditGridCell xEditGridCell491;
        private IHIS.Framework.XEditGridCell xEditGridCell492;
        private IHIS.Framework.XEditGridCell xEditGridCell493;
        private IHIS.Framework.XPanel pnlOrderDetail;
        private IHIS.Framework.XCheckBox cbxWonyoiOrderYN;
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XLabel lblInOut;
        private IHIS.Framework.XCheckBox cbxEmergency;
        private IHIS.Framework.XComboBox cboNalsu;
        private IHIS.Framework.XLabel lblNalsu;
        private IHIS.Framework.XPanel xPanel4;
        private IHIS.Framework.XFindBox fbxBogyongCode;
        private IHIS.Framework.XLabel xLabel8;
        private IHIS.Framework.XDisplayBox dbxBogyongName;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XTabControl tabGroup;
        private IHIS.Framework.XRadioButton rbnOftenOrder;
        private IHIS.Framework.XRadioButton rbnDrgOrder;
        private IHIS.Framework.XRadioButton rbnSearchOrder;
        private IHIS.Framework.XPanel pnlDrug;
        private IHIS.Framework.XTreeView tvwDrgBunryu;
        private IHIS.Framework.XPanel pnlSangyong;
        private IHIS.Framework.XEditGrid grdSangyongOrder;
        private IHIS.Framework.XButton btnExtend;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XEditGridCell xEditGridCell20;
        private IHIS.Framework.XEditGridCell xEditGridCell21;
        private IHIS.Framework.XEditGridCell xEditGridCell22;
        private IHIS.Framework.XEditGridCell xEditGridCell23;
        private IHIS.Framework.XPanel pnlSearchOrder;
        private IHIS.Framework.XEditGrid grdSearchOrder;
        private IHIS.Framework.XEditGridCell xEditGridCell28;
        private IHIS.Framework.XEditGridCell xEditGridCell29;
        private IHIS.Framework.XEditGridCell xEditGridCell30;
        private IHIS.Framework.XEditGridCell xEditGridCell31;
        private IHIS.Framework.XEditGridCell xEditGridCell33;
        private IHIS.Framework.XPanel pnlRightBottom;
        private IHIS.Framework.XButton btnSelect;
        private IHIS.Framework.XButton btnNewSelect;
        private IHIS.Framework.MultiLayout layGroupTab;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem1;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem2;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem3;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem4;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem5;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem6;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem7;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem8;
        private IHIS.Framework.XEditGridCell xEditGridCell34;
        private IHIS.Framework.XEditGridCell xEditGridCell35;
        private IHIS.Framework.XTabControl tabSangyongOrder;
        private IHIS.Framework.MultiLayout layDrugTree;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem9;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem10;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem11;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem12;
        private IHIS.Framework.XEditGrid grdDrgOrder;
        private IHIS.Framework.XEditGridCell xEditGridCell24;
        private IHIS.Framework.XEditGridCell xEditGridCell25;
        private IHIS.Framework.XEditGridCell xEditGridCell26;
        private IHIS.Framework.XEditGridCell xEditGridCell27;
        private IHIS.Framework.XEditGridCell xEditGridCell32;
        private IHIS.Framework.XEditGridCell xEditGridCell36;
        private IHIS.Framework.XEditGridCell xEditGridCell37;
        private IHIS.Framework.XEditGridCell xEditGridCell38;
        private IHIS.Framework.XEditGridCell xEditGridCell39;
        private IHIS.Framework.XEditGridCell xEditGridCell40;
        private IHIS.Framework.XButton btnSetOrder;
        private IHIS.Framework.XButton btnDoOrder;
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
        private ToolTip toolTip1;
        private IHIS.Framework.XEditGridCell xEditGridCell54;
        private IHIS.Framework.XEditGridCell xEditGridCell55;
        private IHIS.Framework.XEditGridCell xEditGridCell56;
        private IHIS.Framework.XEditGridCell xEditGridCell57;
        private IHIS.Framework.XEditGridCell xEditGridCell58;
        private IHIS.Framework.XButton btnJungsiDrug;
        private IHIS.Framework.XEditGridCell xEditGridCell59;
        private IHIS.Framework.XEditGridCell xEditGridCell60;
        private IHIS.Framework.XEditGridCell xEditGridCell61;
        private IHIS.Framework.XEditGridCell xEditGridCell62;
        private IHIS.Framework.XEditGridCell xEditGridCell63;
        private IHIS.Framework.XEditGridCell xEditGridCell64;
        private IHIS.Framework.XPanel pnlPreview;
        private IHIS.Framework.MultiLayout layPreview;
        private IHIS.Framework.XEditGrid grdPreview;
        private IHIS.Framework.XEditGridCell xEditGridCell65;
        private IHIS.Framework.XEditGridCell xEditGridCell66;
        private IHIS.Framework.XEditGridCell xEditGridCell67;
        private IHIS.Framework.XEditGridCell xEditGridCell68;
        private IHIS.Framework.XEditGridCell xEditGridCell69;
        private IHIS.Framework.XEditGridCell xEditGridCell70;
        private IHIS.Framework.XEditGridCell xEditGridCell71;
        private IHIS.Framework.XEditGridCell xEditGridCell72;
        private IHIS.Framework.XEditGridCell xEditGridCell73;
        private IHIS.Framework.XRadioButton rbnOrderStatus;
        private IHIS.Framework.XPanel pnlRight;
        private IHIS.Framework.XEditGridCell xEditGridCell74;
        private IHIS.Framework.XEditGridCell xEditGridCell75;
        private IHIS.Framework.XEditGridCell xEditGridCell76;
        private IHIS.Framework.XEditGridCell xEditGridCell77;
        private IHIS.Framework.XEditGridCell xEditGridCell78;
        private IHIS.Framework.XEditGridCell xEditGridCell79;
        private IHIS.Framework.XEditGridCell xEditGridCell80;
        private IHIS.Framework.XEditGridCell xEditGridCell81;
        private IHIS.Framework.XEditGridCell xEditGridCell82;
        private IHIS.Framework.XEditGridCell xEditGridCell83;
        private IHIS.Framework.XEditGridCell xEditGridCell84;
        private IHIS.Framework.XButton btnExpandSearch;
        private IHIS.Framework.XEditGridCell xEditGridCell85;
        private IHIS.Framework.XEditGridCell xEditGridCell86;
        private IHIS.Framework.XEditGridCell xEditGridCell87;
        private IHIS.Framework.XEditGridCell xEditGridCell88;
        private IHIS.Framework.XGridHeader xGridHeader1;
        private IHIS.Framework.XGridHeader xGridHeader2;
        private IHIS.Framework.XEditGridCell xEditGridCell89;
        private IHIS.Framework.XEditGridCell xEditGridCell90;
        private IHIS.Framework.XEditGridCell xEditGridCell91;
        private IHIS.Framework.XEditGridCell xEditGridCell92;
        private IHIS.Framework.XEditGridCell xEditGridCell93;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem13;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem14;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem15;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem16;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem17;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem18;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem19;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem20;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem30;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem31;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem34;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem35;
        private IHIS.Framework.MultiLayout laySaveLayout;
        private IHIS.Framework.MultiLayout layDeletedData;
        private IHIS.Framework.XEditGridCell xEditGridCell94;
        private IHIS.Framework.XEditGridCell xEditGridCell95;
        private IHIS.Framework.XEditGridCell xEditGridCell96;
        private IHIS.Framework.XEditGridCell xEditGridCell97;
        private IHIS.Framework.XEditGridCell xEditGridCell98;
        private IHIS.Framework.XEditGridCell xEditGridCell99;
        private IHIS.Framework.XPanel pnlSearchTool;
        private GroupBox grbGeneric;
        private IHIS.Framework.XFlatRadioButton rbtSyouhin;
        private IHIS.Framework.XFlatRadioButton rbtGenericSearch;
        private IHIS.Framework.XComboBox cboQueryCon;
        private IHIS.Framework.XComboItem xComboItem1;
        private IHIS.Framework.XComboItem xComboItem2;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XTextBox txtSearch;
        private IHIS.Framework.XLabel xLabel5;
        private IHIS.Framework.XDictComboBox cboSearchCondition;
        private IHIS.Framework.XEditGridCell xEditGridCell100;
        private IHIS.Framework.XEditGridCell xEditGridCell101;
        private IHIS.Framework.XEditGridCell xEditGridCell102;
        private IHIS.Framework.XEditGridCell xEditGridCell103;
        private IHIS.Framework.XEditGridCell xEditGridCell104;
        private IHIS.Framework.XEditGridCell xEditGridCell105;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem21;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem22;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem23;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem24;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem25;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem26;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem27;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem28;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem29;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem32;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem33;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem36;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem37;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem38;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem39;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem40;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem41;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem42;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem43;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem44;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem45;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem46;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem47;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem48;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem49;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem50;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem51;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem52;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem53;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem54;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem55;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem56;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem57;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem58;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem59;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem60;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem61;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem62;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem63;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem64;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem65;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem66;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem67;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem68;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem69;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem70;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem71;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem72;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem73;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem74;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem75;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem76;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem77;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem78;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem79;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem80;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem81;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem82;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem83;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem84;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem85;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem86;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem87;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem88;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem89;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem90;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem91;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem92;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem93;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem94;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem95;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem96;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem97;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem98;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem99;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem100;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem101;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem102;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem103;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem104;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem105;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem106;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem107;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem108;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem109;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem110;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem111;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem112;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem113;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem114;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem115;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem116;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem117;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem118;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem119;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem120;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem121;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem122;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem123;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem124;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem125;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem126;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem127;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem128;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem129;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem130;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem131;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem132;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem133;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem134;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem135;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem136;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem137;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem138;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem139;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem140;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem141;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem142;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem143;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem144;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem145;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem146;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem147;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem148;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem149;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem150;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem151;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem152;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem153;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem154;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem155;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem156;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem157;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem158;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem159;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem160;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem161;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem311;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem312;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem313;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem314;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem315;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem316;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem317;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem318;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem319;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem320;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem321;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem322;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem323;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem324;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem162;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem163;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem164;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem165;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem166;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem167;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem168;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem169;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem170;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem171;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem172;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem173;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem174;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem175;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem176;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem177;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem178;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem179;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem180;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem181;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem182;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem183;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem184;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem185;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem186;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem187;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem188;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem189;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem190;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem191;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem192;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem193;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem194;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem195;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem196;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem197;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem198;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem199;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem200;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem201;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem202;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem203;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem204;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem205;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem206;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem207;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem208;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem209;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem210;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem211;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem212;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem213;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem214;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem215;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem216;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem217;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem218;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem219;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem220;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem221;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem222;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem223;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem224;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem225;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem226;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem227;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem228;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem229;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem230;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem231;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem232;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem233;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem234;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem235;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem236;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem237;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem238;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem239;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem240;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem241;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem242;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem243;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem244;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem245;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem246;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem247;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem248;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem249;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem250;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem251;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem252;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem253;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem254;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem255;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem256;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem257;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem258;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem259;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem260;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem261;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem262;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem263;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem264;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem265;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem266;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem267;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem268;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem269;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem270;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem271;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem272;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem273;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem274;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem275;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem276;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem277;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem278;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem279;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem280;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem281;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem282;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem283;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem284;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem285;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem286;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem287;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem288;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem289;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem290;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem291;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem292;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem293;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem294;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem295;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem296;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem297;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem298;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem299;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem300;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem301;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem302;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem303;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem304;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem305;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem306;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem307;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem308;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem309;
        private IHIS.Framework.XEditGridCell xEditGridCell106;
        private IHIS.Framework.XButton btnNalsu;
        private Panel pnlStatus;
        private Label lbStatus;
        private IHIS.Framework.XProgressBar pgbProgress;
        private IHIS.Framework.XDictComboBox cboInputGubun;
        private IHIS.Framework.XLabel lblInputGubun;
        private IHIS.Framework.XButton btnBroughtDrg;
        private IHIS.Framework.XEditGridCell xEditGridCell107;
        private IHIS.Framework.XEditGridCell xEditGridCell108;
        private IHIS.Framework.XEditGrid grdGeneral;
        private IHIS.Framework.XEditGridCell xEditGridCell109;
        private IHIS.Framework.XEditGridCell xEditGridCell110;
        private IHIS.Framework.XEditGridCell xEditGridCell111;
        private IHIS.Framework.XEditGridCell xEditGridCell112;
        private IHIS.Framework.XEditGridCell xEditGridCell113;
        private IHIS.Framework.XEditGridCell xEditGridCell114;
        private IHIS.Framework.XEditGridCell xEditGridCell115;
        private IHIS.Framework.XEditGridCell xEditGridCell116;
        private IHIS.Framework.XEditGridCell xEditGridCell117;
        private IHIS.Framework.XEditGridCell xEditGridCell118;
        private PictureBox pbxIsBgtDrg;
        private IHIS.Framework.XEditGridCell xEditGridCell119;
        private IHIS.Framework.XEditGridCell xEditGridCell120;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XTabControl tabWonnaeDrg;
        private IHIS.X.Magic.Controls.TabPage tabpageK9;
        private IHIS.X.Magic.Controls.TabPage tabpageZ8;
        private IHIS.X.Magic.Controls.TabPage tabpageT7;
        private IHIS.X.Magic.Controls.TabPage tabpageY4;
        private IHIS.Framework.XEditGridCell xEditGridCell121;
        private IHIS.Framework.XEditGridCell xEditGridCell122;
        private IHIS.Framework.XComboItem xComboItem3;
        private IHIS.Framework.XComboItem xComboItem4;
        private IHIS.Framework.XComboItem xComboItem5;
        private IHIS.Framework.XComboItem xComboItem6;
        private IHIS.Framework.XEditGridCell xEditGridCell123;
        private IHIS.Framework.XEditGridCell xEditGridCell124;
        private IHIS.Framework.XEditGridCell xEditGridCell125;
        private XButton btnInsert;
        private IHIS.Framework.XEditGridCell xEditGridCell126;
        private XEditGridCell xEditGridCell128;
        private XEditGridCell xEditGridCell129;
        private OCS0103U10 parentControl;
        public OCS0103U10 ParentControl
        {
            set { parentControl = value; }
            get { return parentControl; }
        }
        #endregion

        #region Constructor
        public UCOCS0103U10()
            : this(true)
        {
            //Add paging number
            //grdSearchOrder.ParamList = new List<string>(new String[] {"f_page_number", "f_offset" });

        }
        public UCOCS0103U10(bool initialize)
        {
            if (initialize) EnsureInitialized();
        }
        private bool _initialized = false;

        public void EnsureInitialized()
        {
            if (!_initialized)
            {
                InitializeComponent();
                ResizeColumnGrd();
                // Cloud updated
                InitItemsControl();
                _initialized = true;
                GetUserOptions();
            }
        }
        #endregion

        #region 2. Form변수를 정의한다

        private XScreen mContainer;
        private XPanel mPnlTop;
        private XScreen mOpener;
        private XButtonList mBtnList;
        private XButton mBtnCopy;
        private XButton mBtnPaste;
        private XButton mBtnMix;
        private XButton mBtnMixCancel;
        private XButton mBtnChangeWonyoi;
        private XDisplayBox mDbxWonyoiOrderYN;
        private PictureBox mPbxCopy;
        private string mBunho;
        private CommonItemCollection _aOpenParam;
        private DataTable mInjectionDt;
        private bool isCheckHospCode = true;

        private string mbxMsg = "", mbxCap = "";

        //insert by jc [一般名検索機能追加] 2012/11/01
        private string mGenericSearchYN = "N";

        private const string EMERGENCY_GWA = "04";
        private const string CREATE_DO = "OCS1003P02";

        //不均等処方
        private ArrayList mUnEvenList = null;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // 라디오 버튼 관련 변수
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private XColor mSelectedForeColor = new XColor(Color.FromName("ActiveCaptionText"));
        private XColor mSelectedBackColor = new XColor(Color.FromName("ActiveCaption"));
        private XColor mUnSelectedForeColor = new XColor(Color.FromName("InactiveCaptionText"));
        private XColor mUnSelectedBackColor = new XColor(Color.FromName("InactiveCaption"));

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // 오더 화면 확장 관련
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //private int OrderExtendWidth = 850;
        /*private int OrderNormalWidth = 762;*/
        private int OrderExtendWidth = 723;
        private int OrderNormalWidth = 718;

        /*private int OrderExtendWidth = 1081;
        private int OrderNormalWidth = 872;*/
        private bool mIsExtended = false;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // 조회부분 화면 확장 관련
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //private int OrderMinWidth = 618;
        //private int OrderMinWidth = 740;
        private int OrderMinWidth = 725;
        private bool mIsSearchExtended = false;

        private int PreviewHangmogMaxWidth = 315;
        private int PreviewHangmogNormalWidth = 179;

        //private int SearchHangmogNameNormalWidth = 304;
        private int SearchHangmogNameNormalWidth = 180;
        //private int SearchHangmogNameMaxWidth = 443;
        private int SearchHangmogNameMaxWidth = 300;

        private int DrgHangmogNameNormalWidth = 152;
        private int DrgHangmogNameMaxWidth = 294;

        private int SangYongHangmogNormalWidth = 305;
        private int SangYongHangmogMaxWidth = 441;

        ///////////// Order 기본값 /////////////////////////////////////////////////////////////////////////
        private const string INPUTTAB = "01"; // 내복약 (01) 
        private string IOEGUBUN = "O";     // 입외구분(외래)
        private string mInputGubun = "D0";    // 입력구분(의사처방)
        private string mInputGubunName = "";  // 입력구분명
        private string mInputPart = "";      // 입력파트
        private string mCallerSysID = "";
        private string mCallerScreenID = "";
        private string protocolId = "";

        private bool mPostApproveYN = false;

        //insert by jc [OCS1003P01のデータウインドウから選択された際、自動ポイント移動に必要な変数]
        private int mCurrentRowNum = -1;
        private XDataWindow mCurrentDataWindow;
        private string mCurrentColName = "";

        //一般名関連
        private string mGeneral_disp_yn = "";


        //공통
        private XEditGrid mSelectedGRD = null;

        private string mOrderDate = "";
        //private MultiLayout mOrderLayout;
        private OrderVariables.OrderMode mOrderMode;
        //입원외래 order
        private string mPkInOutKey = "";
        //private string mOrderGubun = "C"; // 오더구분 (내복약)
        // 셋트오더 관련 _ 키
        private string mMemb = "";
        private string mYaksokCode = "";  // 셋트이면 약속코드, Cp 이면 Cp Code 가 들어감.
        // CP관련 키
        private string mMembGubun = "";
        private string mCpCode = "";
        private string mJaewonil = "";
        private string mCpPathCode = "";
        private string mCpMasterkey = "";

        // 환자정보관련

        private bool mDoctorLogin = false;

        // 오더 정보 관련
        private DataTable mInDataRow;
        //private DataTable mOutDataRow;

        private DataTable mLayDtOrderBuffer = null; // 처방 Copy & Paste용 Buffer DataTable

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ///////////// OCS Library  /////////////////////////////////////////////////////////////////////////
        private IHIS.OCS.OrderBiz mOrderBiz = null;         // OCS 그룹 Business 라이브러리
        private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리
        private IHIS.OCS.PatientInfo mPatientInfo = null;     // OCS 환자정보 그룹 라이브러리 
        private IHIS.OCS.HangmogInfo mHangmogInfo = null;     // OCS 항목정보 그룹 라이브러리 		
        private IHIS.OCS.InputControl mInputControl = null;   // 입력제어 그룹 라이브러리 
        private IHIS.OCS.CommonForms mCommonForms = null;     // OCS 공통Form's 그룹 라이브러리 
        private IHIS.OCS.ColumnControl mColumnControl = null; // OCS 오더별 컬럼 컨트롤 라이브러리
        private IHIS.OCS.OrderInterface mInterface = null;
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////grd Drag //////////////////////////////////////////////////////////////////////////////
        //private bool mIsDrag = false;
        //private int  mDragX = 0;
        //private int  mDragY = 0;
        //private int  mDownY = 0;
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////Popup Menu ////////////////////////////////////////////////////////////////////////////
        private IHIS.X.Magic.Menus.PopupMenu popupOrderMenu = new IHIS.X.Magic.Menus.PopupMenu(); // 처방Grid용
        //private IHIS.X.Magic.Menus.PopupMenu popupOftenUsedMenu = new IHIS.X.Magic.Menus.PopupMenu(); // 상용처방Grid용
        private IHIS.X.Magic.Menus.PopupMenu popupYaksokOrderMenu = new IHIS.X.Magic.Menus.PopupMenu(); // 약속처방Grid용
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //private Hashtable mHtControl = null;        // Control과 연결할 HashTable

        //private bool mIsSuccessBtnList = true;      // 버튼리스트 로직 콜해서 성공여부를 가지고 있는다(PerformClick의 Return값이 없어서)

        //private string mPk_Naewon = ""; // 내원/재원환자List에서 환자 선택한 내원/재원Key

        //private DataTable mDtOrderGubun;

        // 저장을 하기 위한 Layout
        private Hashtable mSaveLayout;

        // Screen Open check
        //private bool mScreenOpen = true;

        // 신규 탭 페이지 
        private IHIS.X.Magic.Controls.TabPage tpgNew = new IHIS.X.Magic.Controls.TabPage();

        // 임시 컬럼
        string mTemp = "";

        // 포커스를 위한 로우 번호
        private int mFocusRow = -1;

        // 원내 원외 디폴트 체크 
        private string mDefaultWonyoiOrder = "Y";

        #endregion

        #region Properties
        public PatientInfo MPatientInfo
        {
            get
            {
                return mPatientInfo;
            }
        }

        public XEditGrid GrdOrder
        {
            get
            {
                return grdOrder;
            }
        }

        public OrderBiz MOrderBiz
        {
            get
            {
                return mOrderBiz;
            }
        }

        public XScreen MContainer
        {
            get
            {
                return mContainer;
            }
            set
            {
                mContainer = value;
            }
        }

        public XPanel MPnlTop
        {
            get
            {
                return mPnlTop;
            }
            set
            {
                mPnlTop = value;
            }
        }

        public XScreen MOpener
        {
            get
            {
                return mOpener;
            }
            set
            {
                mOpener = value;
            }
        }

        public XButtonList MBtnList
        {
            get
            {
                return mBtnList;
            }
            set
            {
                mBtnList = value;
            }
        }

        public XButton MBtnCopy
        {
            get
            {
                return mBtnCopy;
            }
            set
            {
                mBtnCopy = value;
            }
        }

        public XButton MBtnPaste
        {
            get
            {
                return mBtnPaste;
            }
            set
            {
                mBtnPaste = value;
            }
        }

        public XButton MBtnMix
        {
            get
            {
                return mBtnMix;
            }
            set
            {
                mBtnMix = value;
            }
        }

        public XButton MBtnMixCancel
        {
            get
            {
                return mBtnMixCancel;
            }
            set
            {
                mBtnMixCancel = value;
            }
        }

        public XButton MBtnChangeWonyoi
        {
            get
            {
                return mBtnChangeWonyoi;
            }
            set
            {
                mBtnChangeWonyoi = value;
            }
        }

        public XDisplayBox MDbxWonyoiOrderYn
        {
            get
            {
                return mDbxWonyoiOrderYN;
            }
            set
            {
                mDbxWonyoiOrderYN = value;
            }
        }

        public PictureBox MPbxCopy
        {
            get
            {
                return mPbxCopy;
            }
            set
            {
                mPbxCopy = value;
            }
        }

        public string MBunho
        {
            get
            {
                return mBunho;
            }
            set
            {
                mBunho = value;
            }
        }
        #endregion

        #region 3. Properties, fields - Cloud updated

        /// <summary>
        /// OCS0103U13CboListResult
        /// </summary>
        private OCS0103U13CboListResult _cboListItems;
        /// <summary>
        /// OCS0103U13FormLoadResult
        /// </summary>
        private OCS0103U10FormLoadResult _formResult;
        /// <summary>
        /// cbo Search condition
        /// </summary>
        private IList<object[]> _cboSearchCondLstItem;
        /// <summary>
        /// layDrugTree cache key
        /// </summary>
        private const string CACHE_LAY_DRUG_TREE = "OCS0103U10.Cache.LayDrugTree";
        /// <summary>
        /// Cbo input gubun cache key
        /// </summary>
        private const string CACHE_CBO_INPUT_GUBUN = "OCS0103U10.Cache.Cbo.InputGubun";
        /// <summary>
        /// Cbo search condition cache key
        /// </summary>
        private const string CACHE_CBO_SEARCH_CONDITION = "OCS0103U10.Cache.Cbo.SearchCondition";

        /// <summary>
        /// Combobox datasources
        /// </summary>
        private DataTable _dvTimeCbo = new DataTable();
        private DataTable _suryangCbo = new DataTable();
        private DataTable _dvCbo = new DataTable();
        private DataTable _nalsuCbo = new DataTable();
        private bool isSearchFormKeyPress = false;

        #endregion

        #region Methods(private)

        private void ResizeColumnGrd() 
        {
            switch (NetInfo.Language)
            {
                case LangMode.Vi:
                    grdOrder.AutoSizeColumn(6, 76);
                    grdOrder.AutoSizeColumn(11, 62);
                    grdOrder.AutoSizeColumn(12, 44);
                    grdOrder.AutoSizeColumn(31, 73);
                    grdOrder.AutoSizeColumn(28, 53);
                    grdOrder.AutoSizeColumn(29, 88);
                    grdOrder.AutoSizeColumn(26, 63);
                    grdOrder.AutoSizeColumn(23, 53);
                    grdOrder.AutoSizeColumn(24, 81);
                    grdOrder.AutoSizeColumn(27, 112);
                    grdOrder.AutoSizeColumn(9, 62);
                    grdOrder.AutoSizeColumn(10, 81);
                    grdOrder.AutoSizeColumn(25, 46);
                    grdOrder.AutoSizeColumn(35, 41);
                    grdOrder.AutoSizeColumn(4, 62);
                    grdOrder.AutoSizeColumn(5, 61);
                    grdOrder.AutoSizeColumn(32, 124);
                    grdOrder.AutoSizeColumn(33, 117);
                    grdOrder.AutoSizeColumn(30, 87);
                    grdOrder.AutoSizeColumn(36, 86);
                    grdOrder.AutoSizeColumn(37, 84);
                    grdOrder.AutoSizeColumn(39, 62);
                    grdOrder.AutoSizeColumn(40, 62);
                    break;

                case LangMode.Jr:
                    grdOrder.AutoSizeColumn(xEditGridCell371.Col, 30); // 2
                    grdOrder.AutoSizeColumn(xEditGridCell49.Col, 25); // 4
                    grdOrder.AutoSizeColumn(xEditGridCell79.Col, 25); // 5
                    grdOrder.AutoSizeColumn(xEditGridCell376.Col, 50); // 6
                    grdOrder.AutoSizeColumn(xEditGridCell384.Col, 210);
                    grdOrder.AutoSizeColumn(xEditGridCell387.Col, 40);
                    grdOrder.AutoSizeColumn(xEditGridCell391.Col, 56);
                    grdOrder.AutoSizeColumn(xEditGridCell394.Col, 38);

                    grdOrder.AutoSizeColumn(xEditGridCell414.Col, 25);
                    grdOrder.AutoSizeColumn(xEditGridCell415.Col, 25);
                    grdOrder.AutoSizeColumn(xEditGridCell413.Col, 25);
                    grdOrder.AutoSizeColumn(xEditGridCell411.Col, 25);

                    grdOrder.AutoSizeColumn(xEditGridCell121.Col, 25);
                    grdOrder.AutoSizeColumn(xEditGridCell122.Col, 25);
                    break;
            }
        }

        #region MED-6658
        //Warning message func
        private void WarningMessage(XEditGrid xGrd)
        {
            if (xGrd.RowCount == 0 && isSearchFormKeyPress)
            {
                XMessageBox.Show(Resources.UCOCS0103U10_WarningMessage, Resources.Cap_000033, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isSearchFormKeyPress = false;
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        private void PostLoad(CommonItemCollection aOpenParam)
        {
            //MessageBox.Show("PostLoad Start");

            /// 사용자 변경 Event Call /////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

            if (aOpenParam != null) // 다른 화면에서 콜되는 경우
            {
                //HandleBtnListClick(FunctionType.Query);

                this.MakeGroupTabInfo(IOEGUBUN, this.mPkInOutKey, this.mInputGubun, INPUTTAB);
            }

            if (this.grdOrder.RowCount > 0)
            {
                if (aOpenParam.Contains("isOpenPopUp") && aOpenParam["isOpenPopUp"].Equals(true))
                {
                    HandleBtnListClick(FunctionType.Process);
                }
            }


            // 오더가 있는경우는 디폴트가 오더 상황
            // 없는 경우는 디폴트가 오더검색
            //DataRow[] dr = grdOrder.LayoutTable.Select("input_gubun = '" + mInputGubun + "'");

            //if (this.grdOrder.RowCount > 0)
            //if (dr.Length > 0)
            //{
            //    if (this.rbnOrderStatus.Checked == false)
            //    {
            //        this.rbnOrderStatus.Checked = true;
            //    }
            //}
            //else
            //{
            //    if (this.rbnSearchOrder.Checked == false)
            //    {
            //        this.rbnSearchOrder.Checked = true;
            //    }
            //}
            SetTabRbn(aOpenParam);
            this.txtSearch.Focus();
            this.setFocusGotoColumn();

        }

        private void SetTabRbn(CommonItemCollection aOpenParam)
        {
            SetEnableRbn();
            if (aOpenParam != null && !aOpenParam["isOpenPopUp"].Equals(true))
            {
                rbnSearchOrder.Visible = false;
                rbnDrgOrder.Visible = false;
                rbnOrderStatus.Visible = false;

                rbnOftenOrder.Checked = true;
                rbnOftenOrder.Dock = DockStyle.Fill;

                OverrideLookAndFeel();
            }
            else
                this.rbnSearchOrder.Checked = true;
        }

        private void OverrideLookAndFeel()
        {
            rbnOftenOrder.TextAlign = ContentAlignment.MiddleCenter;
            pnlRight.Location = new Point(871, 31);
            xPanel2.Location = new Point(871, 0);
            pbxIsBgtDrg.Location = new Point(423, 7);
            btnBroughtDrg.Location = new Point(420, 3);
            btnNalsu.Location = new Point(333, 4);
            btnJungsiDrug.Location = new Point(400, 32);
            btnSetOrder.Location = new Point(502, 32);
            btnDoOrder.Location = new Point(502, 3);
            dbxBogyongName.Location = new Point(155, 6);
            fbxBogyongCode.Location = new Point(76, 6);
            cboNalsu.Location = new Point(378, 5);
            lblNalsu.Location = new Point(332, 3);
            lblInOut.Location = new Point(245, 33);
            xLabel1.Location = new Point(3, 0);
            xLabel5.Location = new Point(3, 29);
            cbxEmergency.Location = new Point(75, 39);
            cbxWonyoiOrderYN.Location = new Point(315, 38);
            pnlFill.Location = new Point(0, 0);
            pnlSearchOrder.Location = new Point(0, 91);
            xPanel3.Location = new Point(0, 255);
            pnlSangyong.Location = new Point(0, 91);
            pnlDrug.Location = new Point(0, 91);
            pnlPreview.Location = new Point(0, 91);
            cboSearchCondition.Location = new Point(163, 4);
            grbGeneric.Location = new Point(4, 55);
            rbtSyouhin.Location = new Point(29, 9);
            rbtGenericSearch.Location = new Point(159, 9);
            cboQueryCon.Location = new Point(72, 4);
            txtSearch.Location = new Point(72, 30);
            btnInsert.Location = new Point(4, 6);
            btnSelect.Location = new Point(225, 6);
            btnNewSelect.Location = new Point(88, 6);
            rbnOrderStatus.Location = new Point(336, 1);
            rbnDrgOrder.Location = new Point(238, 1);
            lbStatus.Location = new Point(486, 16);
            pnlRight.Size = new Size(429, 500);
            xPanel2.Size = new Size(429, 31);
            xPanel4.Size = new Size(618, 435);
            btnBroughtDrg.Size = new Size(79, 27);
            btnNalsu.Size = new Size(83, 27);
            btnJungsiDrug.Size = new Size(97, 27);
            btnSetOrder.Size = new Size(86, 27);
            btnDoOrder.Size = new Size(86, 27);
            btnExtend.Size = new Size(24, 57);
            dbxBogyongName.Size = new Size(172, 20);
            fbxBogyongCode.Size = new Size(73, 20);
            xLabel8.Size = new Size(63, 25);
            cboNalsu.Size = new Size(38, 21);
            lblNalsu.Size = new Size(44, 26);
            lblInOut.Size = new Size(62, 19);
            xLabel3.Size = new Size(63, 19);
            pnlOrderDetail.Size = new Size(618, 65);
            pnlOrderInput.Size = new Size(618, 31);
            pnlOrderInfo.Size = new Size(618, 531);
            pnlSearchOrder.Size = new Size(429, 367);
            grdSearchOrder.Size = new Size(429, 255);
            xPanel3.Size = new Size(429, 112);
            grdGeneral.Size = new Size(429, 86);
            tabpageK9.Size = new Size(429, 1);
            tabWonnaeDrg.Size = new Size(429, 26);
            tabpageZ8.Size = new Size(429, 1);
            tabpageT7.Size = new Size(429, 1);
            tabpageY4.Size = new Size(429, 1);
            pnlSangyong.Size = new Size(429, 367);
            grdSangyongOrder.Size = new Size(429, 337);
            tabSangyongOrder.Size = new Size(429, 30);
            pnlDrug.Size = new Size(429, 367);
            grdDrgOrder.Size = new Size(262, 367);
            tvwDrgBunryu.Size = new Size(167, 367);
            pnlPreview.Size = new Size(429, 367);
            grdPreview.Size = new Size(429, 367);
            pnlSearchTool.Size = new Size(429, 91);
            cboSearchCondition.Size = new Size(97, 21);
            grbGeneric.Size = new Size(256, 30);
            cboQueryCon.Size = new Size(85, 20);
            xLabel1.Size = new Size(64, 26);
            txtSearch.Size = new Size(188, 20);
            xLabel5.Size = new Size(64, 26);
            pnlRightBottom.Size = new Size(429, 42);
            btnInsert.Size = new Size(80, 29);
            btnSelect.Size = new Size(59, 29);
            btnNewSelect.Size = new Size(135, 29);
            rbnOrderStatus.Size = new Size(93, 28);
            rbnDrgOrder.Size = new Size(96, 28);
            rbnSearchOrder.Size = new Size(101, 28);
            lbStatus.Size = new Size(143, 29);
            grdOrder.Size = new Size(618, 435);
            xPanel1.Size = new Size(618, 32);
            tabGroup.Size = new Size(618, 29);
            this.Size = new Size(1300, 531);
        }

        private void SetEnableRbn()
        {
            rbnSearchOrder.Visible = true;
            rbnDrgOrder.Visible = true;
            rbnOrderStatus.Visible = true;
            rbnOftenOrder.Visible = true;
        }

        #region 定期薬の場合次の定期処方周期日の適用
        //private string GetNextDrugSyohoubi()
        //{
        //    if (this.mInputGubun == "D0")
        //    {
        //        string cmd_cycle_order = @"SELECT FN_DRG_GET_CYCLE_ORD_DATE(:f_hosp_code, :f_order_date, :f_ho_dong) FROM SYS.DUAL";
        //        BindVarCollection bind_cycle_order = new BindVarCollection();
        //        bind_cycle_order.Add("f_hosp_code", EnvironInfo.HospCode);
        //        bind_cycle_order.Add("f_order_date", this.mOrderDate);
        //        bind_cycle_order.Add("f_ho_dong", this.mPatientInfo.GetPatientInfo["ho_dong"].ToString());
        //        object obj = Service.ExecuteScalar(cmd_cycle_order, bind_cycle_order);
        //        if (obj != null)
        //            return DateTime.Parse(obj.ToString()).ToString("yyyy/mm/dd");
        //        else
        //            return null;
        //    }
        //    else
        //        return null;
        //}
        #endregion

        // 持参薬があるかどうかチェックし点滅させる。
        private void setBgtDrgICON()
        {
            //string cmd = @"SELECT FN_OCS_IS_BROUGHT_DRG_YN(:f_hosp_code, :f_bunho, :f_pkinp1001, :f_input_tab) FROM SYS.DUAL";
            //BindVarCollection bind = new BindVarCollection();
            //bind.Add("f_hosp_code", EnvironInfo.HospCode);
            //bind.Add("f_bunho", mPatientInfo.GetPatientInfo["bunho"].ToString());
            //bind.Add("f_pkinp1001", mPatientInfo.GetPatientInfo["naewon_key"].ToString());
            //bind.Add("f_input_tab", INPUTTAB);

            //object obj = Service.ExecuteScalar(cmd, bind);
            //if (obj != null && obj.ToString() != "N" && this.btnBroughtDrg.Visible == true)
            //    this.pbxIsBgtDrg.Visible = true;
            //else
            //    this.pbxIsBgtDrg.Visible = false;

            // Cloud updated
            this.pbxIsBgtDrg.Visible = (_formResult.BroughtDrgYn != "Y" && this.btnBroughtDrg.Visible);
        }
        /// <summary>
        /// 해당 Screen의 각종 Control 관련 Setting
        /// </summary>
        private void InitializeScreen()
        {
            //저장에 필요한 Layout을 정의한다.
            mSaveLayout = new Hashtable();
            mSaveLayout.Add("OCS1003", this.grdOrder);

            // 상용처방을 로드한다.
            if (this.mOrderMode == OrderVariables.OrderMode.SetOrder)
            {
                // 유저별 공통 모드인데 이건 어쩔까...
                //string name = "";
                //this.mOrderBiz.LoadColumnCodeName("gwa_doctor", "%", this.mMemb, EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"), ref name);
                string name = _formResult.Name;

                if (name == "")
                {
                    // 주과의 상용오더를 가져오자.
                    //string mainDoctorCode = this.mOrderBiz.GetMainGwaDoctorCode(this.mMemb);
                    string mainDoctorCode = _formResult.MainDoctorCode;
                    if (mainDoctorCode != "")
                        this.MakeSangyongTab(mainDoctorCode, INPUTTAB);
                    else
                        this.MakeSangyongTab(mMemb, INPUTTAB);
                }
                else
                {
                    this.MakeSangyongTab(mMemb, INPUTTAB);
                }
            }
            else
            {
                // 상용처방을 로드한다.
                if (UserInfo.UserGubun == UserType.Doctor)
                {
                    this.MakeSangyongTab(UserInfo.DoctorID, INPUTTAB);
                }
                else
                    this.MakeSangyongTab(UserInfo.UserID, INPUTTAB);
            }

            //if (this.IOEGUBUN == "I")
            //{
            //    this.btnHopeDateIlgwal.Visible = true;
            //}
            // 약오더를 로드한다.
            this.MakeDrugOrder();


        }

        private bool IsVi() 
        {
            return NetInfo.Language == LangMode.Vi;
        }

        private void InitScreen()
        {
            this.grdOrder.AutoSizeColumn(34, 0); //看護Comment
            this.grdOrder.AutoSizeColumn(36, 0); //部位コード
            this.grdOrder.AutoSizeColumn(37, 0); //部位名称

            this.grdOrder.AutoSizeColumn(3, 0); // GR

            this.grdOrder.AutoSizeColumn(27, 0); // 퇴/외
            this.grdOrder.AutoSizeColumn(25, 0); // 비치

            //this.grdOrder.AutoSizeColumn(29, 0); // 퇴/외
            //this.grdOrder.AutoSizeColumn(27, 0); // 비치

            // 셋트 오더인경우는 정시약, 반납지시 컬럼이 보이면 안됨. 그룹시리얼도, 희망일자, 전달파트 포함
            if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                this.mOrderMode == OrderVariables.OrderMode.CpSetOrder)
            {
                this.grdOrder.AutoSizeColumn(1, 0); // 반납
                this.grdOrder.AutoSizeColumn(3, 0); // GR
                this.grdOrder.AutoSizeColumn(4, 0);
                this.grdOrder.AutoSizeColumn(5, 0); // 임시
                this.grdOrder.AutoSizeColumn(10, 0);
                //this.grdOrder.AutoSizeColumn(12, 0);
                this.grdOrder.AutoSizeColumn(9, 0); // 후발불가
                this.cboInputGubun.Visible = false;
                this.lblInputGubun.Visible = false;
                // add autosizeColumn 
                this.grdOrder.AutoSizeColumn(16, 0); // dv_2
                this.grdOrder.AutoSizeColumn(17, 0); // dv_3
                this.grdOrder.AutoSizeColumn(18, 0); // dv_4
                this.grdOrder.AutoSizeColumn(19, 0); // dv_5
                this.grdOrder.AutoSizeColumn(20, 0); // dv_6
                this.grdOrder.AutoSizeColumn(21, 0); // dv_7
                this.grdOrder.AutoSizeColumn(22, 0); // dv_8

                //this.grdOrder.AutoSizeColumn(18, 0); // dv_2
                //this.grdOrder.AutoSizeColumn(19, 0); // dv_3
                //this.grdOrder.AutoSizeColumn(20, 0); // dv_4
                //this.grdOrder.AutoSizeColumn(21, 0); // dv_5
                //this.grdOrder.AutoSizeColumn(22, 0); // dv_6
                //this.grdOrder.AutoSizeColumn(23, 0); // dv_7
                //this.grdOrder.AutoSizeColumn(24, 0); // dv_8

            }
            // 의사 오더인 경우는 반납지시 컬럼이 보이지 않는다.
            else if (UserInfo.UserGubun == UserType.Doctor)
            {
                this.grdOrder.AutoSizeColumn(1, 0); // 반납

                this.grdOrder.AutoSizeColumn(35, 0);

                this.grdOrder.AutoSizeColumn(16, 0); // dv_2
                this.grdOrder.AutoSizeColumn(17, 0); // dv_3
                this.grdOrder.AutoSizeColumn(18, 0); // dv_4
                this.grdOrder.AutoSizeColumn(19, 0); // dv_5
                this.grdOrder.AutoSizeColumn(20, 0); // dv_6
                this.grdOrder.AutoSizeColumn(21, 0); // dv_7
                this.grdOrder.AutoSizeColumn(22, 0); // dv_8

                //this.grdOrder.AutoSizeColumn(18, 0); // dv_2
                //this.grdOrder.AutoSizeColumn(19, 0); // dv_3
                //this.grdOrder.AutoSizeColumn(20, 0); // dv_4
                //this.grdOrder.AutoSizeColumn(21, 0); // dv_5
                //this.grdOrder.AutoSizeColumn(22, 0); // dv_6
                //this.grdOrder.AutoSizeColumn(23, 0); // dv_7
                //this.grdOrder.AutoSizeColumn(24, 0); // dv_8
            }

            if (this.mOrderMode == OrderVariables.OrderMode.InpOrder)
            {
                // 持参薬があるかどうかチェックし点滅させる。
                setBgtDrgICON();
            }

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder)
            {
                this.grdOrder.AutoSizeColumn(32, 0);  // 외래 행위부서
                this.grdOrder.AutoSizeColumn(33, 0);  // 입원 행위부서
            }
            else
            {
                this.grdOrder.AutoSizeColumn(27, 0);
                //this.grdOrder.AutoSizeColumn(29, 0);
            }

            // 입원 외래에 따른 조회 조건 기본셋팅값
            if (this.IOEGUBUN == "O")
            {
                this.grdOrder.AutoSizeColumn(10, 0); // 희망일
                //this.grdOrder.AutoSizeColumn(12, 0); // 희망일
                this.grdOrder.AutoSizeColumn(38, 0); // 持参薬
                if (this.mPatientInfo.GetPatientInfo != null)
                {
                    if (this.mPatientInfo.GetPatientInfo["gwa"].ToString() == EMERGENCY_GWA || this.mCallerScreenID == CREATE_DO)
                        this.cboQueryCon.SetDataValue("Y"); // 受付した診療科が救急科であれば院内採用薬を基本とする。
                    else
                        this.cboQueryCon.SetDataValue("%"); // 전체 기본
                }
                else
                    this.cboQueryCon.SetDataValue("%"); // 전체 기본

                this.btnBroughtDrg.Visible = false; // 持参薬ボタン
                this.cboInputGubun.Visible = false;
                this.lblInputGubun.Visible = false;
            }
            else
            {
                // 임시약은 입원에서는 의미없음
                this.grdOrder.AutoSizeColumn(4, 0); // 定時
                this.grdOrder.AutoSizeColumn(5, 0); // 臨時
                this.grdOrder.AutoSizeColumn(10, 0); // 一般名
                this.cboQueryCon.SetDataValue("Y"); // 院内採用薬
                this.btnJungsiDrug.Visible = false;
            }

            // 팝업메뉴 초기화
            // 오더 팝업메뉴
            // 처방Grid PopupMenu
            //Todo
            popupOrderMenu.MenuCommands.Clear();
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.Btn_00001, (Image)this.imageListPopupMenu.Images[0],
                new EventHandler(PopUpMenuSelectAll_Click)));
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.Btn_00002, (Image)this.imageListPopupMenu.Images[1],
                new EventHandler(PopUpMenuUnSelectAll_Click)));
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.Btn_00007, (Image)this.imageListPopupMenu.Images[2],
                new EventHandler(PopUpMenuInsert_Click)));
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.Btn_00008, (Image)this.imageListPopupMenu.Images[3],
                new EventHandler(PopUpMenuPaste_Click)));
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.Btn_00003, (Image)this.imageListPopupMenu.Images[4],
                new EventHandler(PopUpMenuDelete_Click)));
            //popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.Btn_00004, (Image)this.imageListPopupMenu.Images[5],
            //    new EventHandler(PopUpMenuMix_Click)));
            //popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.Btn_00006, (Image)this.imageListPopupMenu.Images[6],
            //    new EventHandler(PopUpMenuMixCancel_Click)));
            //popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.Btn_00005, (Image)this.imageListPopupMenu.Images[7],
            //    new EventHandler(PopUpMenuSelectOftenOrder_Click)));

            // 상용오더 팝업메뉴
            //popupOftenUsedMenu.MenuCommands.Clear();
            //popupOftenUsedMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(NetInfo.Language == LangMode.Jr ? "常用オーダ削除" : "상용오더삭제", (Image)this.imageListPopupMenu.Images[4],
            //    new EventHandler(PopUpMenuSelectOftenOrderDelete_Click)));

            // 事後承認がOFFであれば代行入力以外はできない。
            //if (!this.mPostApproveYN && this.mInputGubun != "CK")
            //{
            //    this.pnlRight.Enabled       = this.mPostApproveYN;
            //    this.btnDoOrder.Enabled     = this.mPostApproveYN;
            //    this.btnSetOrder.Enabled    = this.mPostApproveYN;
            //    this.btnJungsiDrug.Enabled  = this.mPostApproveYN;
            //}
        }

        private void SetInitialOrderGridData(DataTable aInData)
        {
            foreach (DataRow dr in this.mInDataRow.Rows)
            {
                this.grdOrder.LayoutTable.ImportRow(dr);
            }

            this.grdOrder.DisplayData();

            this.DisplayMixGroup(this.grdOrder);

            this.SetOrderImage(this.grdOrder);

        }

        private void OpenScreen_CHT0117Q00(string aOrderGubun)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("order_gubun", aOrderGubun);

            XScreen.OpenScreenWithParam(this, "CHTS", "CHT0117Q00", ScreenOpenStyle.ResponseSizable, openParams);
        }

        /// <summary>
        /// 항목코드 파인드 창 오픈
        /// </summary>
        /// <param name="aHangmogCode">검색어</param>
        /// <param name="aMultiSelect">복수선택여부</param>
        private void OpenScreen_OCS0103Q00(string aHangmogCode, bool aMultiSelect)
        {
            /*CommonItemCollection param = new CommonItemCollection();

            param.Add("hangmog_code", aHangmogCode);
            param.Add("multiSelect", true);
            param.Add("input_tab", INPUTTAB);

            XScreen.OpenScreenWithParam(mContainer == null ? this : (object)mContainer, "OCSA", "OCS0103Q00", ScreenOpenStyle.ResponseFixed, param);*/

            CommonItemCollection param = new CommonItemCollection();

            param.Add("hangmog_code", aHangmogCode);
            param.Add("multiSelect", true);
            param.Add("input_tab", INPUTTAB);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103Q00", ScreenOpenStyle.ResponseFixed, param);
        }

        private void OpenScreen_OCS0208Q00()
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("suryang", "");
            openParams.Add("dv", "");
            openParams.Add("dv_time", "");
            openParams.Add("dv_1", "");
            openParams.Add("dv_2", "");
            openParams.Add("dv_3", "");
            openParams.Add("dv_4", "");
            openParams.Add("dv_5", "");

            // 2012/12/10
            openParams.Add("dv_6", "");
            openParams.Add("dv_7", "");
            openParams.Add("dv_8", "");
            openParams.Add("order_remark", "");
            openParams.Add("bogyong_code", "");
            openParams.Add("io_gubun", this.IOEGUBUN);
            openParams.Add("inputgubun", this.mInputGubun);

            /*XScreen.OpenScreenWithParam(mContainer == null ? this : (object)mContainer, "OCSA", "OCS0208Q00", ScreenOpenStyle.ResponseSizable, openParams);*/
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0208Q00", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void OpenScreen_OCS0208Q01(string aOrderRemark, string aBogyongCode, string aHangmogCode)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("order_remark", aOrderRemark);

            openParams.Add("bogyong_code", aBogyongCode);
            openParams.Add("hangmog_code", aHangmogCode);
            openParams.Add("io_gubun", this.IOEGUBUN);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0208Q01", ScreenOpenStyle.ResponseFixed, openParams);
        }

        private void OpenScreen_OCS0301Q09()
        {
            string naewon_date = mOrderDate.PadRight(10).Substring(0, 10).Replace("-", "/");

            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("input_tab", INPUTTAB);
            openParams.Add("input_gubun", this.mInputGubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString().Length > 2)
                {
                    openParams.Add("gwa", this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString().Substring(0, 2));
                }
                else
                {
                    openParams.Add("gwa", this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString());
                }
                openParams.Add("memb", this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString());
            }
            else if (UserInfo.UserGubun == UserType.Doctor)
            {
                openParams.Add("gwa", UserInfo.Gwa);
                openParams.Add("memb", UserInfo.DoctorID);
            }
            else if (UserInfo.UserGubun == UserType.Nurse)
            {
                openParams.Add("gwa", TypeCheck.NVL(UserInfo.HoDong, UserInfo.Gwa));
                openParams.Add("memb", UserInfo.UserID);
            }
            else
            {
                openParams.Add("gwa", TypeCheck.NVL(this.mInputPart, UserInfo.Gwa));
                openParams.Add("memb", UserInfo.UserID);
            }

            openParams.Add("patient_info", this.mPatientInfo);

            //약속코드조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0301Q09", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void OpenScreen_OCS1003Q09(bool aIsAutoClose)
        {
            // 처방 입력 가능 여부

            //해당 내원의 처방정보를 가져온다.
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", mPatientInfo.GetPatientInfo["bunho"].ToString());

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString().Length > 2)
                {
                    openParams.Add("gwa", this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString().Substring(0, 2));
                }
                else
                {
                    openParams.Add("gwa", this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString());
                }
                
                openParams.Add("doctor", this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString());
            }
            else
            {
                openParams.Add("gwa", mPatientInfo.GetPatientInfo["gwa"].ToString());
                openParams.Add("doctor", mPatientInfo.GetPatientInfo["doctor"].ToString());
            }

            openParams.Add("naewon_date", mOrderDate);
            openParams.Add("input_gubun", this.mInputGubun);
            //openParams.Add("tel_yn"     , "N"); // 간호 입력분은 뺀다 
            openParams.Add("tel_yn", "%"); // 약만 타러온 환자건도 있다

            openParams.Add("auto_close", aIsAutoClose);
            openParams.Add("input_tab", INPUTTAB);
            openParams.Add("io_gubun", this.IOEGUBUN);

            openParams.Add("childYN", "N");
            openParams.Add("patient_info", this.mPatientInfo);

            //전처방조회 화면 Open
            //XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003Q00", ScreenOpenStyle.ResponseSizable, openParams);
            try
            {
                XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003Q09", ScreenOpenStyle.ResponseSizable, openParams);
            }
            catch
            {

            }
        }

        private void OpenScreen_OCS1023U00(string aBunho, string aGwa)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", aBunho);
            param.Add("gwa", aGwa);
            param.Add("auto_close_yn", "Y");
            param.Add("input_tab", INPUTTAB);

            XScreen.OpenScreenWithParam(this, "OCSO", "OCS1023U00", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 오더모드에 따른 환자정보 패널 셋팅
        /// </summary>
        private void SetVisiblePatientInfoPanel()
        {
            if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                this.mOrderMode == OrderVariables.OrderMode.CpSetOrder)
            {
                if (this.mPnlTop != null) this.mPnlTop.Visible = false;
                this.btnDoOrder.Visible = false;
                //delete by jc [セットオーダを登録する際にも既存のセットオーダを参考にしたいという要請] 2012/04/24
                //this.btnSetOrder.Visible = false;
                this.btnJungsiDrug.Visible = false;
            }
        }

        private void InvokeReturnSendReturnDataTable()
        {
            CommonItemCollection param = new CommonItemCollection();
            //入院登録画面と以外の画面とのＲＥＴＵＲＮＧＲＤの変更
            param.Add("isOpenPopUp", isOpenPopUp);
            if (this.mOrderMode == OrderVariables.OrderMode.InpOrder && this.mCallerScreenID != "OCS2003P01")
            {
                param.Add("drug_order", this.laySaveLayout);

                // UT
                //param.Add("drug_order", this.grdOrder);
            }
            else
            {
                param.Add("drug_order", this.grdOrder);
            }
            param.Add("allWarning", this.allWarning);

            if (mOpener != null) mOpener.Command("OCS0103U10", param);
        }

        public bool IsUpdateCheck()
        {

            Hashtable groupInfo;
            ArrayList delList = new ArrayList();
            bool isUpdatable = true;
            bool isShowMsg = true;
            string msg = "";
            string cap = "";

            #region 체크전 데이터 확인 ( 빈로우, 빈그룹 삭제 )

            if (mOrderFunc == null) return false;

            this.mOrderFunc.DeleteEmptyNewRow(this.grdOrder);

            // 빈그룹 삭제
            foreach (IHIS.X.Magic.Controls.TabPage delgroup in this.tabGroup.TabPages)
            {
                groupInfo = delgroup.Tag as Hashtable;

                if (this.mOrderFunc.IsEmptyGroup(this.grdOrder, groupInfo["group_ser"].ToString()))
                {
                    delList.Add(delgroup);
                }
            }

            for (int i = 0; i < delList.Count; i++)
            {
                this.tabGroup.TabPages.Remove((X.Magic.Controls.TabPage)delList[i]);
            }

            #endregion

            //#region
            ////院内採用薬チェック
            //// 원내원외 체크 
            //string errMsg = "";
            //string mCap = "test";
            //string mMsg = "test";
            //if (this.mOrderBiz.CheckExistWonnaeWonyoiDrg(this.grdOrder.LayoutTable, ref errMsg) == true)
            //{
            //    //this.mMsg = errMsg + XMsg.GetMsg("M008");
            //    //this.mCap = XMsg.GetField("F001");

            //    MessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    return false;
            //}
            //#endregion

            #region 업데이트 체크
            // 그룹정보 입력체크 
            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroup.TabPages)
            {
                groupInfo = tpg.Tag as Hashtable;

                if (this.mOrderMode != OrderVariables.OrderMode.SetOrder)
                {
                    // 복용코드 체크 
                    ////////////////////////////////////////////////////////////////////////////////////////////
                    if (groupInfo.Contains("bogyong_code"))
                    {
                        if (groupInfo["bogyong_code"].ToString() == "")
                        {
                            msg = XMsg.GetMsg("M005"); //그룹에 대하여 복용코드를 입력해 주세요.
                            isUpdatable = false;
                            this.tabGroup.SelectedTab = tpg;
                            this.fbxBogyongCode.Focus();
                            this.fbxBogyongCode.SelectAll();
                            break;
                        }
                    }
                    else
                    {
                        msg = XMsg.GetMsg("M005"); //그룹에 대하여 복용코드를 입력해 주세요.
                        this.tabGroup.SelectedTab = tpg;
                        isUpdatable = false;

                        break;
                    }

                    // 일수 체크 
                    ////////////////////////////////////////////////////////////////////////////////////////////
                    if (groupInfo.Contains("nalsu"))
                    {
                        if (groupInfo["nalsu"].ToString() == "" || groupInfo["nalsu"].ToString() == "0")
                        {
                            msg = XMsg.GetMsg("M006"); //그룹에 대하여 복용코드를 입력해 주세요.
                            isUpdatable = false;
                            this.tabGroup.SelectedTab = tpg;
                            this.cboNalsu.Focus();
                            this.cboNalsu.SelectAll();
                            break;
                        }

                        if (groupInfo["nalsu"].ToString().Length > 4)
                        {
                            msg = XMsg.GetMsg("M031");
                            isUpdatable = false;
                            this.tabGroup.SelectedTab = tpg;
                        }
                    }
                    else
                    {
                        msg = XMsg.GetMsg("M006"); //그룹에 대하여 복용코드를 입력해 주세요.
                        this.tabGroup.SelectedTab = tpg;
                        isUpdatable = false;
                        break;
                    }

                }

                // 오더에 대한 체크
                foreach (DataRow dr in this.grdOrder.LayoutTable.Select("group_ser=" + groupInfo["group_ser"].ToString()))
                {
                    if (dr.RowState != DataRowState.Unchanged)
                    {
                        // DV 체크 
                        double suryang = 0;
                        double dv1 = 0, dv2 = 0, dv3 = 0, dv4 = 0, dv5 = 0, dv6 = 0, dv7 = 0, dv8 = 0;
                        string dv_time = "";
                        double dv = -1;

                        dv_time = dr["dv_time"].ToString();

                        if (TypeCheck.IsDecimal(dr["dv"].ToString()))
                            dv = double.Parse(dr["dv"].ToString());

                        if (TypeCheck.IsDecimal(dr["suryang"].ToString()))
                            suryang = double.Parse(dr["suryang"].ToString());

                        if (TypeCheck.IsDecimal(dr["dv_1"].ToString()))
                            dv1 = double.Parse(dr["dv_1"].ToString());

                        if (TypeCheck.IsDecimal(dr["dv_2"].ToString()))
                            dv2 = double.Parse(dr["dv_2"].ToString());

                        if (TypeCheck.IsDecimal(dr["dv_3"].ToString()))
                            dv3 = double.Parse(dr["dv_3"].ToString());

                        if (TypeCheck.IsDecimal(dr["dv_4"].ToString()))
                            dv4 = double.Parse(dr["dv_4"].ToString());

                        if (TypeCheck.IsDecimal(dr["dv_5"].ToString()))
                            dv5 = double.Parse(dr["dv_5"].ToString());

                        if (TypeCheck.IsDecimal(dr["dv_6"].ToString()))
                            dv6 = double.Parse(dr["dv_6"].ToString());

                        if (TypeCheck.IsDecimal(dr["dv_7"].ToString()))
                            dv7 = double.Parse(dr["dv_7"].ToString());

                        if (TypeCheck.IsDecimal(dr["dv_8"].ToString()))
                            dv8 = double.Parse(dr["dv_8"].ToString());

                        if (dv1 + dv2 + dv3 + dv4 + dv5 + dv6 + dv7 + dv8 != 0 && suryang != (dv1 + dv2 + dv3 + dv4 + dv5 + dv6 + dv7 + dv8))
                        {
                            MessageBox.Show(dr["hangmog_name"].ToString() + "\n ===> " + XMsg.GetMsg("M030"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                            this.tabGroup.SelectedTab = tpg;

                            isUpdatable = false;
                            isShowMsg = false;
                        }
                    }
                }
            }
            /*
             I_BUNHO        
            ,I_HANGMOG_CODE
            ,I_SURYANG     
            ,I_DV          
            ,I_DV_TIME     
            ,I_NALSU       
             */
            //string cmd_bgt = @"SELECT FN_OCS_INSERT_BGTDRG_YN(:f_bunho, :f_pkocs1024, :f_suryang, :f_dv, :f_dv_time, :f_nalsu) FROM SYS.DUAL";
            BindVarCollection bind_bgt = new BindVarCollection();
            Hashtable ht = new Hashtable();
            ArrayList arr = new ArrayList();
            double bgt_suryang = -1;
            int bgt_dv = -1;
            string bgt_dv_time = "";
            int bgt_nalsu = -1;
            double total_suryang = -1;

            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                if (this.grdOrder.GetItemString(i, "brought_drg_yn") == "Y"
                    && this.grdOrder.GetItemString(i, "acting_date") == ""
                    && (this.grdOrder.GetRowState(i) == DataRowState.Added || this.grdOrder.GetRowState(i) == DataRowState.Modified))
                {
                    bgt_suryang = double.Parse(this.grdOrder.GetItemString(i, "suryang"));
                    bgt_dv = int.Parse(this.grdOrder.GetItemString(i, "dv"));
                    bgt_dv_time = this.grdOrder.GetItemString(i, "dv_time");
                    bgt_nalsu = int.Parse(this.grdOrder.GetItemString(i, "nalsu"));

                    switch (bgt_dv_time)
                    {
                        case "*":
                            total_suryang = bgt_suryang * bgt_dv * bgt_nalsu;
                            break;
                        case "/":
                            total_suryang = bgt_suryang * bgt_nalsu;
                            break;
                    }

                    if (ht.Contains(this.grdOrder.GetItemString(i, "pkocs1024")))
                    {
                        if (this.grdOrder.GetRowState(i) == DataRowState.Modified)
                        {
                            //                            string cmd = @"SELECT A.SURYANG, A.DV, A.DV_TIME, A.NALSU
                            //                                             FROM OCS2003 A
                            //                                            WHERE A.HOSP_CODE = :f_hosp_code
                            //                                              AND A.PKOCS2003 = :f_pkocs2003
                            //                                              ";
                            //                            BindVarCollection bind = new BindVarCollection();
                            //                            bind.Add("f_hosp_code", EnvironInfo.HospCode);
                            //                            bind.Add("f_pkocs2003", this.grdOrder.GetItemString(i, "pkocskey"));

                            // Cloud updated code START
                            OCS0103U12IsUpdateCheckSelectArgs ucsArgs = new OCS0103U12IsUpdateCheckSelectArgs();
                            ucsArgs.Pkocs2003 = this.grdOrder.GetItemString(i, "pkocskey");
                            OCS0103U12IsUpdateCheckSelectResult ucsRes = CloudService.Instance.Submit<OCS0103U12IsUpdateCheckSelectResult,
                                OCS0103U12IsUpdateCheckSelectArgs>(ucsArgs);

                            DataTable dt = new DataTable();
                            if (null != ucsRes)
                            {
                                dt = ConvertToDataTable(ucsRes.SelectInfo);
                            }
                            // Cloud updated code END

                            double a_total_suryang = -1;
                            //DataTable dt = Service.ExecuteDataTable(cmd, bind);
                            if (dt.Rows.Count > 0)
                            {
                                switch (dt.Rows[0]["dv_time"].ToString())
                                {
                                    case "*":
                                        a_total_suryang = double.Parse(dt.Rows[0]["suryang"].ToString()) * int.Parse(dt.Rows[0]["dv"].ToString()) * int.Parse(dt.Rows[0]["nalsu"].ToString());
                                        break;
                                    case "/":
                                        a_total_suryang = double.Parse(dt.Rows[0]["suryang"].ToString()) * int.Parse(dt.Rows[0]["nalsu"].ToString());
                                        break;
                                    case "@":
                                        a_total_suryang = double.Parse(dt.Rows[0]["suryang"].ToString());
                                        break;
                                }

                            }
                            if (a_total_suryang > 0)
                                ht[this.grdOrder.GetItemString(i, "pkocs1024")] = int.Parse(ht[this.grdOrder.GetItemString(i, "pkocs1024")].ToString()) + total_suryang - a_total_suryang;
                            else
                                ht[this.grdOrder.GetItemString(i, "pkocs1024")] = int.Parse(ht[this.grdOrder.GetItemString(i, "pkocs1024")].ToString()) + total_suryang;
                        }
                        else
                            ht[this.grdOrder.GetItemString(i, "pkocs1024")] = int.Parse(ht[this.grdOrder.GetItemString(i, "pkocs1024")].ToString()) + total_suryang;
                    }
                    else
                    {
                        if (this.grdOrder.GetRowState(i) == DataRowState.Modified)
                        {
                            //                            string cmd = @"SELECT A.SURYANG, A.DV, A.DV_TIME, A.NALSU
                            //                                             FROM OCS2003 A
                            //                                            WHERE A.HOSP_CODE = :f_hosp_code
                            //                                              AND A.PKOCS2003 = :f_pkocs2003
                            //                                              ";
                            //                            BindVarCollection bind = new BindVarCollection();
                            //                            bind.Add("f_hosp_code", EnvironInfo.HospCode);
                            //                            bind.Add("f_pkocs2003", this.grdOrder.GetItemString(i, "pkocskey"));

                            // Cloud updated code START
                            OCS0103U12IsUpdateCheckSelectArgs ucsArgs = new OCS0103U12IsUpdateCheckSelectArgs();
                            ucsArgs.Pkocs2003 = this.grdOrder.GetItemString(i, "pkocskey");
                            OCS0103U12IsUpdateCheckSelectResult ucsRes = CloudService.Instance.Submit<OCS0103U12IsUpdateCheckSelectResult,
                                OCS0103U12IsUpdateCheckSelectArgs>(ucsArgs);

                            DataTable dt = new DataTable();
                            if (null != ucsRes)
                            {
                                dt = ConvertToDataTable(ucsRes.SelectInfo);
                            }
                            // Cloud updated code END

                            double a_total_suryang = -1;
                            //DataTable dt = Service.ExecuteDataTable(cmd, bind);
                            if (dt.Rows.Count > 0)
                            {
                                switch (dt.Rows[0]["dv_time"].ToString())
                                {
                                    case "*":
                                        a_total_suryang = double.Parse(dt.Rows[0]["suryang"].ToString()) * int.Parse(dt.Rows[0]["dv"].ToString()) * int.Parse(dt.Rows[0]["nalsu"].ToString());
                                        break;
                                    case "/":
                                        a_total_suryang = double.Parse(dt.Rows[0]["suryang"].ToString()) * int.Parse(dt.Rows[0]["nalsu"].ToString());
                                        break;
                                    case "@":
                                        a_total_suryang = double.Parse(dt.Rows[0]["suryang"].ToString());
                                        break;
                                }

                            }
                            if (a_total_suryang < total_suryang)
                                ht.Add(this.grdOrder.GetItemString(i, "pkocs1024"), total_suryang - a_total_suryang);
                            else
                                continue;
                        }
                        else
                            ht.Add(this.grdOrder.GetItemString(i, "pkocs1024"), total_suryang);

                        //ht.Add(this.grdOrder.GetItemString(i, "hangmog_code"), total_suryang);
                    }

                }
            }

            //foreach (string pkocs1024 in ht.Keys)
            //{
            //    string insert_yn = "0";

            //    bind_bgt.Add("f_bunho",         this.mPatientInfo.GetPatientInfo["bunho"].ToString());
            //    bind_bgt.Add("f_pkocs1024",     pkocs1024);
            //    bind_bgt.Add("f_suryang",       ht[pkocs1024].ToString());
            //    bind_bgt.Add("f_dv",            "1");
            //    bind_bgt.Add("f_dv_time",       "*");
            //    bind_bgt.Add("f_nalsu",         "1");

            //    insert_yn = Service.ExecuteScalar(cmd_bgt, bind_bgt).ToString();

            //    if (insert_yn == "N")
            //    {
            //        MessageBox.Show("現在の持参薬数量が足りません。ご確認ください。", "確認");
            //        return false;
            //    }
            //}

            // Cloud updated code START
            List<OCS0103U12IsUpdateCheckInsertInfo> lstInsertInfo = new List<OCS0103U12IsUpdateCheckInsertInfo>();
            foreach (string pkocs1024 in ht.Keys)
            {
                OCS0103U12IsUpdateCheckInsertInfo item = new OCS0103U12IsUpdateCheckInsertInfo();
                item.Bunho = this.mPatientInfo.GetPatientInfo["bunho"].ToString();
                item.Pkocs1024 = pkocs1024;
                item.Suryang = ht[pkocs1024].ToString();
                item.Dv = "1";
                item.DvTime = "*";
                item.Nalsu = "1";

                lstInsertInfo.Add(item);
            }

            if (lstInsertInfo.Count > 0)
            {
                OCS0103U12IsUpdateCheckInsertArgs args = new OCS0103U12IsUpdateCheckInsertArgs();
                args.InsertInfo = lstInsertInfo;
                UpdateResult res = CloudService.Instance.Submit<UpdateResult, OCS0103U12IsUpdateCheckInsertArgs>(args);

                if (null != res && !res.Result)
                {
                    MessageBox.Show(Resources.XMsg_000001, Resources.XMsg_000002);
                    return false;
                }
            }
            // Cloud updated code END

            //string insert_yn = "0";
            //for(int i = 0; i < this.grdOrder.RowCount; i++)
            //{
            //    if (this.grdOrder.GetItemString(i, "brought_drg_yn") == "Y" && this.grdOrder.GetRowState(i) != DataRowState.Unchanged)
            //    {
            //        bind_bgt.Add("f_bunho",         this.mPatientInfo.GetPatientInfo["bunho"].ToString());
            //        bind_bgt.Add("f_hangmog_code",  this.grdOrder.GetItemString(i, "hangmog_code"));
            //        bind_bgt.Add("f_suryang",       this.grdOrder.GetItemString(i, "suryang"));
            //        bind_bgt.Add("f_dv",            this.grdOrder.GetItemString(i, "dv"));
            //        bind_bgt.Add("f_dv_time",       this.grdOrder.GetItemString(i, "dv_time"));
            //        bind_bgt.Add("f_nalsu",         this.grdOrder.GetItemString(i, "nalsu"));

            //        insert_yn = Service.ExecuteScalar(cmd_bgt, bind_bgt).ToString();

            //        if (insert_yn == "N")
            //        {
            //            if (MessageBox.Show("現在の持参薬数量が足りません。院内処方に変更しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //            {
            //                // update muhyo, brought_drg_yn
            //                this.grdOrder.SetItemValue(i, "muhyo", "N");
            //                this.grdOrder.SetItemValue(i, "brought_drg_yn", "N");
            //            }
            //        }
            //    }
            //}

            ///////////////////////////////////////////////////////////////////////////////////
            if (isUpdatable == false && isShowMsg == true)
            {
                cap = XMsg.GetField("F001"); // 확인

                MessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return isUpdatable;
            }

            #endregion

            #region 업데이트 체크

            string dupGroup = "";
            string dupRow = "";
            string colName = "";

            //modify by jc [オーダ登録画面では重複チェックを行わないようにLib修正後パラメータ追加] 2012/03/30
            //if (this.mOrderBiz.CheckSaveOrder(this.grdOrder.LayoutTable, ref dupGroup, ref dupRow, ref colName) == false)
            if (this.mOrderBiz.CheckSaveOrder(this.grdOrder.LayoutTable, ref dupGroup, ref dupRow, ref colName, false) == false)
            {
                isUpdatable = false;
                foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroup.TabPages)
                {
                    if (((Hashtable)tpg.Tag)["group_ser"].ToString() == dupGroup)
                    {
                        this.tabGroup.SelectedTab = tpg;
                        this.grdOrder.Focus();
                        if (TypeCheck.IsInt(dupRow))
                        {
                            int rowNumber = int.Parse(dupRow);

                            if (rowNumber >= 0)
                            {
                                this.grdOrder.Focus();
                                this.grdOrder.SetFocusToItem(rowNumber, TypeCheck.NVL(colName, "hangmog_code").ToString(), true);
                            }
                        }
                    }
                }
            }

            #endregion

            #region 오더에 대한 체크 및 셋팅 정보

            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                if (this.grdOrder.GetRowState(i) != DataRowState.Unchanged)
                {
                    if (this.grdOrder.GetRowState(i) != DataRowState.Modified)
                    {
                        this.grdOrder.SetItemValue(i, "nday_occur_yn", "U");
                    }
                }
            }

            #endregion


            //inert by jc [制限数量、制限日数のチェック] 2012/09/13
            for (int n = 0; n < grdOrder.RowCount; n++)
            {
                if (this.mHangmogInfo.ProtectedLimitNalsu(grdOrder.LayoutTable.Rows[n]))
                    return false;
            }
            //for (int s = 0; s < grdOrder.RowCount; s++)
            //{
            //    if (this.mHangmogInfo.ProtectedLimitSuryang(grdOrder.LayoutTable.Rows[s]))
            //        return false;
            //}
            string group_ser = "";

            // 同一グループ内頓服回数チェック
            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroup.TabPages)
            {
                if (((Hashtable)tpg.Tag)["donbog_yn"].ToString() == "Y")
                {
                    group_ser = ((Hashtable)tpg.Tag)["group_ser"].ToString();

                    DataRow[] dr = grdOrder.LayoutTable.Select("donbog_yn = 'Y'");
                    if (dr.Length == 0) 
                    {
                        XMessageBox.Show(Resources.XMsg_000028, Resources.XMsg_000002, MessageBoxIcon.Error);
                        return false; 
                    }

                    string dv1th = dr[0]["dv"].ToString();
                    string group_ser1th = dr[0]["group_ser"].ToString();
                    for (int i = 0; i < dr.Length; i++)
                    {
                        if (group_ser1th == dr[i]["group_ser"].ToString()
                            && dv1th != dr[i]["dv"].ToString())
                        {
                            XMessageBox.Show(Resources.XMsg_000003, Resources.XMsg_000002);
                            isUpdatable = false;
                        }
                    }
                }
            }


            for (int i = 0; i < grdOrder.RowCount; i++)
            {
                if (this.grdOrder.GetItemString(i, "order_gubun").Substring(1, 1) == "C")
                {
                    string bangyang = "";
                    string dv = this.mOrderBiz.GetBogyongByDv(grdOrder.GetItemString(i, "bogyong_code"), ref bangyang);

                    if (bangyang != "10" //屯服
                        && bangyang != "11" //その他
                        && bangyang != "00") //空白
                    {
                        if (dv != grdOrder.GetItemString(i, "dv"))
                        {
                            XMessageBox.Show(Resources.XMsg_000003, Resources.XMsg_000002);
                            isUpdatable = false;
                        }
                    }
                }
            }
            return isUpdatable;
        }

        /// <summary>
        /// Mix Group 데이타 Image Display
        /// </summary>
        /// <param name="aGrd"> XEditGrid </param>
        /// <returns> void  </returns>
        private void DisplayMixGroup(XEditGrid aGrd)
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
                    if (aGrd.GetItemString(i, "dc_check") == "Y") continue;

                    // 이미 이미지 세팅이 안된건에 한해서 작업수행
                    if (!TypeCheck.IsNull(aGrd.GetItemValue(i, "mix_group")) && aGrd[i + aGrd.HeaderHeights.Count, 0].Image == null)
                    {
                        //이미수행한건 빼는로직이 있어야함..
                        int count = 0;
                        for (int j = i; j < aGrd.RowCount; j++)
                        {
                            // 동일 group_ser, 동일 mix_group, 동일 희망일자, 동일 OrderGubun가 Mix구별임..
                            if (aGrd.GetItemValue(i, "group_ser").ToString().Trim() == aGrd.GetItemValue(j, "group_ser").ToString().Trim() &&
                                aGrd.GetItemValue(i, "mix_group").ToString().Trim() == aGrd.GetItemValue(j, "mix_group").ToString().Trim() &&
                                aGrd.GetItemValue(i, "hope_date").ToString().Trim() == aGrd.GetItemValue(j, "hope_date").ToString().Trim() &&
                                aGrd.GetItemValue(i, "order_gubun").ToString().Trim().PadRight(2).Substring(1, 1) ==
                                aGrd.GetItemValue(j, "order_gubun").ToString().Trim().PadRight(2).Substring(1, 1))
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
                        if (count > 1) imageCnt = ++imageCnt % this.imageListMixGroup.Images.Count;
                    }
                }
            }
            finally
            {
                //aGrd.Redraw = true; // Grid Display 
            }

        }

        private void SetMixOrderValue(XEditGrid aGrid, int aSourceRowNum, string aColName, string aValue)
        {
            // Mix시 동기화가 필요한 컬럼
            if (aColName != "dv" &&
                aColName != "dv_time" &&
                aColName != "bogyong_code" &&
                aColName != "jusa" &&
                aColName != "jusa_spd_gubun" &&
                aColName != "nalsu" &&
                aColName != "emergency" &&
                aColName != "home_care_yn") return;

            if (this.tabGroup.SelectedTab == null) return;

            // 내복약이고 돈복인경우는 DV 횟수는 동기화 하지 않는다.
            //if (aColName == "dv" &&
            //    aGrid.GetItemString(aSourceRowNum, "order_gubun").PadLeft(2, '0').Substring(1, 1) == "C" &&
            //    aGrid.GetItemString(aSourceRowNum, "donbog_yn") == "Y")
            //{
            //    return;
            //}


            // Mix 기준
            string input_gubun = "", order_gubun = "", group_ser = "", mix_group = "", hope_date = "";

            if (aGrid.CellInfos.Contains("input_gubun")) input_gubun = aGrid.GetItemString(aSourceRowNum, "input_gubun").Trim();
            order_gubun = aGrid.GetItemString(aSourceRowNum, "order_gubun").Trim();
            group_ser = aGrid.GetItemString(aSourceRowNum, "group_ser").Trim();
            mix_group = aGrid.GetItemString(aSourceRowNum, "mix_group").Trim();
            if (aGrid.CellInfos.Contains("hope_date")) hope_date = aGrid.GetItemString(aSourceRowNum, "hope_date").Trim();

            string basic_order_gubun_bas = aGrid.GetItemString(aSourceRowNum, "order_gubun_bas");

            // 해당  항목의 값을 Setting 한다.
            for (int i = 0; i < aGrid.RowCount; i++)
            {
                if (aSourceRowNum != i &&
                    (!aGrid.CellInfos.Contains("input_gubun") || aGrid.GetItemString(i, "input_gubun").Trim() == input_gubun) &&
                    aGrid.GetItemString(i, "order_gubun").Trim() == order_gubun &&
                    aGrid.GetItemString(i, "group_ser").Trim() == group_ser &&
                    aGrid.GetItemString(i, "mix_group").Trim() == mix_group &&
                    (!aGrid.CellInfos.Contains("hope_date") || aGrid.GetItemString(i, "hope_date").Trim() == hope_date))
                {
                    // 수정가능여부 Check
                    if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                        this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
                    {
                        GridColumnProtectModifyEventArgs me = new GridColumnProtectModifyEventArgs(aColName, aSourceRowNum, aGrid.LayoutTable.Rows[aSourceRowNum], false);
                        grdOrder_GridColumnProtectModify(aGrid, me);

                        if (me.Protect) continue;
                    }

                    // 동일 오더인 경우는 기준 오더를 기준으로 데이타를 맞춘다 
                    if (aGrid.GetItemString(i, "order_gubun_bas").Trim() == basic_order_gubun_bas.ToString().Trim())
                    {
                        // N-day관련해서 주사인 경우에는 nalsu는 맞추지 않는다.
                        if (aColName == "nalsu" && this.mOrderBiz.IsDrugJusaCode(aGrid.GetItemString(i, "order_gubun_bas")) && aGrid.GetItemString(i, "home_care_yn") != "Y")
                            continue;

                        aGrid.SetItemValue(i, aColName, aValue);

                        switch (aColName)
                        {
                            case "dv":
                                //내복약인 경우 용법처리
                                if (this.mOrderBiz.IsDrugMediCode(aGrid.GetItemString(i, "order_gubun_bas")))
                                {
                                    aGrid.SetItemValue(i, "bogyong_code", aGrid.GetItemString(aSourceRowNum, "bogyong_code").Trim());
                                    if (aGrid.CellInfos.Contains("bogyong_name")) aGrid.SetItemValue(i, "bogyong_name", aGrid.GetItemString(aSourceRowNum, "bogyong_name").Trim());
                                }

                                break;

                            case "bogyong_code":
                                if (aGrid.CellInfos.Contains("bogyong_name")) aGrid.SetItemValue(i, "bogyong_name", aGrid.GetItemString(aSourceRowNum, "bogyong_name").Trim());

                                //내복약인 경우 DV 처리
                                if (this.mOrderBiz.IsDrugMediCode(aGrid.GetItemString(i, "order_gubun_bas")))
                                {
                                    aGrid.SetItemValue(i, "dv_time", aGrid.GetItemString(aSourceRowNum, "dv_time").Trim());
                                    aGrid.SetItemValue(i, "dv", aGrid.GetItemString(aSourceRowNum, "dv").Trim());
                                    aGrid.SetItemValue(i, "donbog_yn", aGrid.GetItemString(aSourceRowNum, "donbog_yn").Trim());
                                    //돈복인 경우 nalsu도 조정한다.
                                    if (aGrid.GetItemString(aSourceRowNum, "donbog_yn").Trim() == "Y")
                                        aGrid.SetItemValue(i, "nalsu", aGrid.GetItemString(aSourceRowNum, "nalsu").Trim());
                                }

                                break;

                            case "jusa":
                                if (aGrid.CellInfos.Contains("jusa_name")) aGrid.SetItemValue(i, "jusa_name", aGrid.GetItemString(aSourceRowNum, "jusa_name").Trim());
                                break;

                            //case "home_care_yn":

                            //    if (aValue.ToString() == "Y")
                            //    {
                            //        aGrid.SetItemValue(i, "jundal_part", "HOM");
                            //        if (aGrid.LayoutTable.Columns.Contains("jundal_part_name"))
                            //            aGrid.SetItemValue(i, "jundal_part_name", "HOM");
                            //    }
                            //    else
                            //    {
                            //        //aGrid.SetItemValue(i, "nalsu", 1);
                            //        // 날수는 왜 1로 바꿀까....
                            //        this.mOrderBiz.SetOrderGubunDefaultInfo("O", aGrid, i, aGrid.GetItemString(i, "order_gubun").Trim().PadRight(2).Substring(1, 1), this.cbxWonyoiOrderYN.GetDataValue(),"");
                            //    }
                            //    break;
                        }

                        //횟수 및 용법이 변경되는 경우 불균등 dv 수량을 Reset한다.
                        if (aColName == "dv" || aColName == "bogyong_code")
                        {
                            aGrid.SetItemValue(i, "dv_1", "");
                            aGrid.SetItemValue(i, "dv_2", "");
                            aGrid.SetItemValue(i, "dv_3", "");
                            aGrid.SetItemValue(i, "dv_4", "");

                            //2012/12/10
                            aGrid.SetItemValue(i, "dv_5", "");
                            aGrid.SetItemValue(i, "dv_6", "");
                            aGrid.SetItemValue(i, "dv_7", "");
                            aGrid.SetItemValue(i, "dv_8", "");
                        }
                    }

                }
            }
        }

        private void ReGroupingMix(int aStartRow, int aEndRow, bool aIsReCalMix)
        {
            this.mHangmogInfo.SetAlignMixGroup(this.grdOrder, aStartRow, aEndRow, aIsReCalMix);

            this.DisplayMixGroup(this.grdOrder);
        }

        private void ClearBogyongCode(MultiLayout aLayout)
        {
            bool isFindRow = false;

            if (this.tabGroup.SelectedTab == null)
            {
                return;
            }

            Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            if (groupInfo.Contains("group_ser") == false)
            {
                return;
            }

            DataRow[] rows = this.grdOrder.LayoutTable.Select("group_ser=" + groupInfo["group_ser"].ToString());

            foreach (DataRow dr in rows)
            {
                if (dr["hangmog_code"].ToString() != "")
                {
                    isFindRow = true;
                }

                if (isFindRow == true)
                    break;
            }

            if (isFindRow == false)
            {

            }
        }

        private void OrderGridCreateNewRow(int aRowNumber)
        {
            this.grdOrder.InsertRow(aRowNumber);

            // 그룹 기준 셋팅
            this.GridInitValueSetting(this.grdOrder, this.grdOrder.CurrentRowNumber);
        }

        private void GridInitValueSetting(XEditGrid aGrid, int aRowNumber)
        {
            string temp = "";

            if (tabGroup.SelectedTab == null) return;

            Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            // 그룹시리얼 셋팅
            if (groupInfo.Contains("group_ser"))
                aGrid.SetItemValue(aRowNumber, "group_ser", groupInfo["group_ser"].ToString());

            // 복용코드
            if (groupInfo.Contains("bogyong_code"))
                aGrid.SetItemValue(aRowNumber, "bogyong_code", groupInfo["bogyong_code"].ToString());

            // 긴급
            if (groupInfo.Contains("emergency"))
                aGrid.SetItemValue(aRowNumber, "emergency", groupInfo["emergency"].ToString());

            // 원외처방
            if (groupInfo.Contains("wonyoi_order_yn"))
                aGrid.SetItemValue(aRowNumber, "wonyoi_order_yn", groupInfo["wonyoi_order_yn"].ToString());

            // 환자정보
            if ((this.mOrderMode != OrderVariables.OrderMode.SetOrder && this.mOrderMode != OrderVariables.OrderMode.CpSetOrder) && this.mPatientInfo != null)
            {
                aGrid.SetItemValue(aRowNumber, "bunho", this.mPatientInfo.GetPatientInfo["bunho"].ToString());
            }

            // 입력탭 정보
            aGrid.SetItemValue(aRowNumber, "input_tab", INPUTTAB);
            this.mOrderBiz.LoadColumnCodeName("code", "INPUT_TAB", INPUTTAB, ref temp);
            aGrid.SetItemValue(aRowNumber, "input_tab_name", temp);


            aGrid.SetItemValue(aRowNumber, "order_date", mOrderDate);
            aGrid.SetItemValue(aRowNumber, "input_part", this.mInputPart);

            aGrid.SetItemValue(aRowNumber, "input_gubun", this.mInputGubun);
            aGrid.SetItemValue(aRowNumber, "input_gubun_name", this.mInputGubunName);

            // 진료정보 ( 오더일자, 진료과, 의사 )
            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                if (UserInfo.UserGubun == UserType.Doctor)
                {
                    aGrid.SetItemValue(aRowNumber, "input_doctor", UserInfo.DoctorID);
                    aGrid.SetItemValue(aRowNumber, "input_gwa", UserInfo.Gwa);
                }
                else if (UserInfo.Gwa == "CK")
                {
                    aGrid.SetItemValue(aRowNumber, "input_doctor", this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString());
                    if (this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString().Length >2)
                    {
                        aGrid.SetItemValue(aRowNumber, "input_gwa", this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString().Substring(0, 2));
                    }
                    else
                    {
                        aGrid.SetItemValue(aRowNumber, "input_gwa", this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString());
                    }
                }
                else
                {
                    aGrid.SetItemValue(aRowNumber, "input_doctor", this.mPatientInfo.GetPatientInfo["doctor"].ToString());
                    aGrid.SetItemValue(aRowNumber, "input_gwa", this.mPatientInfo.GetPatientInfo["gwa"].ToString());

                    // 간호사인경우는 간호픽업 데이트를 자동입력한다.
                    if (UserInfo.UserGubun == UserType.Nurse)
                    {
                        aGrid.SetItemValue(aRowNumber, "nurse_pickup_user", UserInfo.UserID);
                        aGrid.SetItemValue(aRowNumber, "nurse_pickup_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                        aGrid.SetItemValue(aRowNumber, "nurse_pickup_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));
                    }
                }



                // 입력구분
                aGrid.SetItemValue(aRowNumber, "input_id", UserInfo.UserID);
                //aGrid.SetItemValue(aRowNumber, "input_part", this.mInputPart);

                //aGrid.SetItemValue(aRowNumber, "input_doctor", UserInfo.DoctorID);
                //aGrid.SetItemValue(aRowNumber, "input_gwa", UserInfo.Gwa);

                //aGrid.SetItemValue(aRowNumber, "order_date", mOrderDate);
                aGrid.SetItemValue(aRowNumber, "gwa", this.mPatientInfo.GetPatientInfo["gwa"].ToString());
                aGrid.SetItemValue(aRowNumber, "doctor", this.mPatientInfo.GetPatientInfo["doctor"].ToString());
                aGrid.SetItemValue(aRowNumber, "resident", this.mPatientInfo.GetPatientInfo["doctor"].ToString());

                // 접수및 입원정보
                if (this.IOEGUBUN == "O")
                {
                    aGrid.SetItemValue(aRowNumber, "naewon_type", this.mPatientInfo.GetPatientInfo["naewon_type"].ToString());
                }

                if (this.mOrderMode == OrderVariables.OrderMode.CpOrder)
                {
                    aGrid.SetItemValue(aRowNumber, "cp_code", this.mCpCode);
                    aGrid.SetItemValue(aRowNumber, "cp_path_code", this.mCpPathCode);
                    aGrid.SetItemValue(aRowNumber, "jaewonil", this.mJaewonil);
                    aGrid.SetItemValue(aRowNumber, "in_out_key", this.mCpMasterkey);
                }
                else
                {
                    // 접수 키
                    aGrid.SetItemValue(aRowNumber, "in_out_key", this.mPkInOutKey);
                }

            }
            // 셋트오더인경우
            else
            {
                if (this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
                    aGrid.SetItemValue(aRowNumber, "in_out_key", this.mPkInOutKey);

                aGrid.SetItemValue(aRowNumber, "input_gwa", UserInfo.Gwa);
                aGrid.SetItemValue(aRowNumber, "memb", this.mMemb);
                aGrid.SetItemValue(aRowNumber, "yaksok_code", this.mYaksokCode);

                if (this.mOrderMode == OrderVariables.OrderMode.CpSetOrder)
                {
                    aGrid.SetItemValue(aRowNumber, "memb_gubun", this.mMembGubun);
                    aGrid.SetItemValue(aRowNumber, "cp_code", this.mCpCode);
                    aGrid.SetItemValue(aRowNumber, "cp_path_code", this.mCpPathCode);
                    aGrid.SetItemValue(aRowNumber, "jaewonil", this.mJaewonil);
                }
            }

            // nday occur yn   n데이 오더 발생여부
            aGrid.SetItemValue(aRowNumber, "nday_occur_yn", "N");
        }

        private void ApplyDefaultOrderInfo(IHIS.OCS.HangmogInfo.ExecutiveMode aExecutivemode, MultiLayout aSourceLayout, XEditGrid aDestGrid, int aRowNumber, bool aIsCallCodeInput)
        {
            //string ordergubunname = "";  // 헤더를 붙인 오더구분을 넣는다.
            int currRow = aRowNumber;
            int startRow = aRowNumber;
            Hashtable groupInfo;

            if (this.tabGroup.SelectedTab == null)
                HandleBtnListClick(FunctionType.Process);

            groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            if (aSourceLayout.RowCount <= 0) return;

            // 그리드 상에서 직접 입력할때와 뭔가를 통해 입력할때...
            // 어디다 집어 넣어야 할지에 대한 헷갈림...
            // 직접 넣을 때는 현재 로우에 무조건 넣어야 하는데...
            // 근데... 뭔가를 통해서 넣을때는 현재 로우에 데이터가 있으면 안되거덩...
            // 그래서 저 컬럼을 두고 aIsCallCodeInput 이 true이면 무조건 현재 로우에 넣는거야...
            // 그거는 그리드에서 컬럼 체인지 탈때만...
            if (aIsCallCodeInput == false)
            {
                XCell newCell = this.mOrderFunc.GetEmptyNewRow(aDestGrid);

                if (newCell != null)
                {
                    currRow = newCell.Row;
                    startRow = newCell.Row;
                }
                else
                {
                    this.OrderGridCreateNewRow(-1);
                    currRow = this.grdOrder.CurrentRowNumber;
                    startRow = this.grdOrder.CurrentRowNumber;
                }
            }
            else
            {
                currRow = aRowNumber;
                startRow = aRowNumber;
            }

            for (int i = 0; i < aSourceLayout.RowCount; i++)
            {

                if (i != 0)
                {
                    this.OrderGridCreateNewRow(-1);
                    currRow = this.grdOrder.CurrentRowNumber;
                }

                if (IsExistDifferntDrugGroup(groupInfo["group_ser"].ToString(), aSourceLayout.GetItemString(i, "order_gubun_bas")) == true)
                {
                    //같은그룹에 외용약과 내복약은 혼재할 수 없습니다.
                    MessageBox.Show(XMsg.GetMsg("M009"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //this.grdOrder.DeleteRow(this.grdOrder.CurrentRowNumber);
                    return;
                }

                // 긴급 관련
                if (this.mOrderBiz.IsAbleToCurrentEmergencyGroup(groupInfo, aSourceLayout.LayoutTable.Rows[i]) == false)
                {
                    return;
                }

                if (this.fbxBogyongCode.GetDataValue() == "" && aSourceLayout.LayoutTable.Columns.Contains("default_bogyong_code") && aSourceLayout.GetItemString(i, "default_bogyong_code") != "")
                {
                    this.fbxBogyongCode.SetEditValue(aSourceLayout.GetItemString(i, "default_bogyong_code"));
                    this.fbxBogyongCode.AcceptData();

                    groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;
                }

                foreach (DataColumn cl in this.grdOrder.LayoutTable.Columns)
                {
                    if (aSourceLayout.LayoutTable.Columns.Contains(cl.ColumnName))
                    {
                        this.grdOrder.LayoutTable.Rows[currRow][cl.ColumnName] = aSourceLayout.LayoutTable.Rows[i][cl.ColumnName];
                    }
                }

                // 오더 구분 관련 
                if (aSourceLayout.GetItemString(i, "order_gubun").Length < 2)
                    this.grdOrder.LayoutTable.Rows[currRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, this.grdOrder, currRow) + aSourceLayout.GetItemString(i, "order_gubun");
                else
                    this.grdOrder.LayoutTable.Rows[currRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, this.grdOrder, currRow) + aSourceLayout.GetItemString(i, "order_gubun").Substring(1, 1);

                if (this.mOrderMode == OrderVariables.OrderMode.SetOrder)
                {
                    this.grdOrder.LayoutTable.Rows[currRow]["jundal_table_out"] = aSourceLayout.GetItemString(i, "jundal_table_out");
                    this.grdOrder.LayoutTable.Rows[currRow]["jundal_table_inp"] = aSourceLayout.GetItemString(i, "jundal_table_inp");
                    this.grdOrder.LayoutTable.Rows[currRow]["jundal_part_out"] = aSourceLayout.GetItemString(i, "jundal_part_out");
                    this.grdOrder.LayoutTable.Rows[currRow]["jundal_part_inp"] = aSourceLayout.GetItemString(i, "jundal_part_inp");
                    this.grdOrder.LayoutTable.Rows[currRow]["move_part_out"] = aSourceLayout.GetItemString(i, "move_part");
                    this.grdOrder.LayoutTable.Rows[currRow]["move_part_inp"] = aSourceLayout.GetItemString(i, "move_part");
                }
                else
                {
                    // 외용이냐 내복이냐에 따라 일수표시에 대산 부분이 visible Setting 
                    // 현재 화면이 외래 모드인경우만 인서트     
                    if (IOEGUBUN == "O")
                        this.grdOrder.LayoutTable.Rows[currRow]["jundal_table"] = aSourceLayout.GetItemString(i, "jundal_table_out");
                    else
                        this.grdOrder.LayoutTable.Rows[currRow]["jundal_table"] = aSourceLayout.GetItemString(i, "jundal_table_inp");

                    // 현재 화면이 외래 모드인경우만 인서트
                    if (IOEGUBUN == "O")
                        this.grdOrder.LayoutTable.Rows[currRow]["jundal_part"] = aSourceLayout.GetItemString(i, "jundal_part_out");
                    else
                        this.grdOrder.LayoutTable.Rows[currRow]["jundal_part"] = aSourceLayout.GetItemString(i, "jundal_part_inp");
                }

                if (this.grdOrder.GetItemValue(i, "dv_time").ToString() != "@")
                {
                    if (this.grdOrder.LayoutTable.Rows[currRow]["order_gubun"].ToString().Substring(1, 1) == "C")
                    {                        
                        if (groupInfo.Contains("donbog_yn") && groupInfo["donbog_yn"].ToString() == "Y")
                        {
                            this.grdOrder.LayoutTable.Rows[currRow]["dv_time"] = "*";
                        }
                        else
                        {
                            this.grdOrder.LayoutTable.Rows[currRow]["dv_time"] = "/";
                        }
                        
                    }
                    else
                    {
                        this.grdOrder.LayoutTable.Rows[currRow]["dv_time"] = "*";
                    }
                }


                //this.grdOrder.LayoutTable.Rows[currRow]["hope_date"] = this.GetNextDrugSyohoubi();

                this.grdOrder.DisplayData();

                if (this.tabGroup.SelectedTab.Tag != null)
                    this.ApplyGroupInfoToRow(groupInfo, currRow);

                this.mFocusRow = currRow;
            }

            this.mHangmogInfo.SetAlignMixGroup(this.grdOrder, startRow, currRow);

            this.grdOrder.DisplayData();

            // 외용, 내복에 따른 변경부분셋팅
            this.SetGroupControlVisible(groupInfo["group_ser"].ToString());
        }

        private void ApplyDivideOrderInfo(HangmogInfo.ExecutiveMode aExecutiveMode, MultiLayout aSourceLayout, XEditGrid aDestGrid, int aRowNumber)
        {
            //string ordergubunname = "";  // 헤더를 붙인 오더구분을 넣는다.
            int currRow = aRowNumber;
            int startRow = aRowNumber;
            //Hashtable currGroupInfo;
            //int cnt = 0;

            if (aSourceLayout.RowCount <= 0) return;

            // 먼저 넘어온 데이터에서 그룹정보만을 셋팅 한다.
            #region
            string aCurrBogyongCode = "";
            string aCurrNalsu = "";
            string aCurrEmergency = "";
            string aCurrWonyoiOrderYn = "";
            string aCurrGroupSer = "";

            Hashtable groupInfo;
            ArrayList groupInfoList = new ArrayList();

            foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
            {
                if (dr.Table.Columns.Contains("group_ser") && dr["group_ser"].ToString() != "")
                {
                    if (dr["bogyong_code"].ToString() != aCurrBogyongCode ||
                        dr["nalsu"].ToString() != aCurrNalsu ||
                        dr["emergency"].ToString() != aCurrEmergency ||
                        dr["wonyoi_order_yn"].ToString() != aCurrWonyoiOrderYn ||
                        dr["group_ser"].ToString() != aCurrGroupSer)
                    {
                        groupInfo = new Hashtable();

                        groupInfo.Add("bogyong_code", dr["bogyong_code"].ToString());
                        groupInfo.Add("nalsu", dr["nalsu"].ToString());
                        groupInfo.Add("emergency", dr["emergency"].ToString());
                        groupInfo.Add("wonyoi_order_yn", dr["wonyoi_order_yn"].ToString());
                        groupInfo.Add("group_ser", dr["group_ser"].ToString());

                        groupInfoList.Add(groupInfo);

                        aCurrBogyongCode = dr["bogyong_code"].ToString();
                        aCurrNalsu = dr["nalsu"].ToString();
                        aCurrEmergency = dr["emergency"].ToString();
                        aCurrWonyoiOrderYn = dr["wonyoi_order_yn"].ToString();
                        aCurrGroupSer = dr["group_ser"].ToString();
                    }
                }
                else
                {
                    if (dr["bogyong_code"].ToString() != aCurrBogyongCode ||
                        dr["nalsu"].ToString() != aCurrNalsu ||
                        dr["emergency"].ToString() != aCurrEmergency ||
                        dr["wonyoi_order_yn"].ToString() != aCurrWonyoiOrderYn)
                    {
                        groupInfo = new Hashtable();

                        groupInfo.Add("bogyong_code", dr["bogyong_code"].ToString());
                        groupInfo.Add("nalsu", dr["nalsu"].ToString());
                        groupInfo.Add("emergency", dr["emergency"].ToString());
                        groupInfo.Add("wonyoi_order_yn", dr["wonyoi_order_yn"].ToString());

                        groupInfoList.Add(groupInfo);

                        aCurrBogyongCode = dr["bogyong_code"].ToString();
                        aCurrNalsu = dr["nalsu"].ToString();
                        aCurrEmergency = dr["emergency"].ToString();
                        aCurrWonyoiOrderYn = dr["wonyoi_order_yn"].ToString();
                    }
                }
            }

            #endregion

            #region 그룹 정보를 돌면서 셋팅한다.

            foreach (Hashtable info in groupInfoList)
            {
                string filter = "";
                DataRow[] rows = null;
                if (info.Contains("group_ser"))
                {
                    filter = "bogyong_code='" + info["bogyong_code"].ToString() + "' AND " +
                             "nalsu=" + info["nalsu"].ToString() + " AND " +
                             "emergency='" + info["emergency"].ToString() + "' AND " +
                             "wonyoi_order_yn='" + info["wonyoi_order_yn"].ToString() + "' AND " +
                             "group_ser='" + info["group_ser"].ToString() + "'";

                    rows = aSourceLayout.LayoutTable.Select(filter);

                }
                else
                {
                    filter = "bogyong_code='" + info["bogyong_code"].ToString() + "' AND " +
                             "nalsu=" + info["nalsu"].ToString() + " AND " +
                             "emergency='" + info["emergency"].ToString() + "' AND " +
                             "wonyoi_order_yn='" + info["wonyoi_order_yn"].ToString() + "' AND " +
                             "group_ser is null";

                    rows = aSourceLayout.LayoutTable.Select(filter);

                    for (int i = 0; i < aSourceLayout.RowCount; i++)
                    {
                        if (aSourceLayout.GetItemString(i, "group_ser") == ""
                            && aSourceLayout.GetItemString(i, "bogyong_code") == info["bogyong_code"].ToString()
                            && aSourceLayout.GetItemString(i, "nalsu") == info["nalsu"].ToString()
                            && aSourceLayout.GetItemString(i, "emergency") == info["emergency"].ToString()
                            && aSourceLayout.GetItemString(i, "wonyoi_order_yn") == info["wonyoi_order_yn"].ToString()
                            )
                        {
                            aSourceLayout.SetItemValue(i, "group_ser", 99999);
                        }
                    }
                }

                //持参薬画面で順番通りになっていなくて全部で2つのグループなのに3つのグループになっている時の対策。
                if (rows.Length == 0)
                    continue;
                // 커런트 그룹정보가 동일한지 여부
                //    - 커런트 그룹이 아직 복용코드 정보가 입력되지 않은 경우는 현재 그룹정보를 
                //      지금 그룹으로 변경해 버린다.
                //    - 그렇지 않은 경우는 새 그룹 생성

                if (this.fbxBogyongCode.GetDataValue() == "" && this.mOrderFunc.IsEmptyGroup(this.grdOrder, (((Hashtable)this.tabGroup.SelectedTab.Tag)["group_ser"]).ToString()))
                {
                    // 그룹정보 맞추기
                    this.cboNalsu.SetDataValue(info["nalsu"].ToString());
                    this.cbxEmergency.SetDataValue(info["emergency"].ToString());
                    this.cbxWonyoiOrderYN.SetDataValue(info["wonyoi_order_yn"].ToString());
                    this.fbxBogyongCode.SetEditValue(info["bogyong_code"].ToString());
                    this.fbxBogyongCode.AcceptData();
                }

                //if (this.IsSameCurrentGroupInfo(info["bogyong_code"].ToString(), info["nalsu"].ToString(), info["emergency"].ToString(), info["wonyoi_order_yn"].ToString()) == false)
                //{
                //    // 신규 그룹생성
                //    HandleBtnListClick(FunctionType.Process);
                //    // 그룹정보 맞추기
                //    this.cboNalsu.SetDataValue(info["nalsu"].ToString());
                //    this.cbxEmergency.SetDataValue(info["emergency"].ToString());
                //    this.cbxWonyoiOrderYN.SetDataValue(info["wonyoi_order_yn"].ToString());
                //    this.fbxBogyongCode.SetEditValue(info["bogyong_code"].ToString());
                //    this.fbxBogyongCode.AcceptData();
                //}


                //신규 그룹생성
                HandleBtnListClick(FunctionType.Process);
                //그룹정보 맞추기
                this.cboNalsu.SetDataValue(info["nalsu"].ToString());
                this.cbxEmergency.SetDataValue(info["emergency"].ToString());
                this.cbxWonyoiOrderYN.SetDataValue(info["wonyoi_order_yn"].ToString());
                this.fbxBogyongCode.SetEditValue(info["bogyong_code"].ToString());
                this.fbxBogyongCode.AcceptData();

                groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

                if (currRow < 0)
                {
                    this.OrderGridCreateNewRow(-1);
                    currRow = this.grdOrder.CurrentRowNumber;
                    startRow = this.grdOrder.CurrentRowNumber;
                }
                else
                {
                    XCell newCell = this.mOrderFunc.GetEmptyNewRow(aDestGrid);

                    if (newCell != null)
                    {
                        currRow = newCell.Row;
                        startRow = newCell.Row;
                    }
                    else
                    {
                        this.OrderGridCreateNewRow(-1);
                        currRow = this.grdOrder.CurrentRowNumber;
                        startRow = this.grdOrder.CurrentRowNumber;
                    }
                }

                for (int i = 0; i < rows.Length; i++)
                {

                    if (i != 0)
                    {
                        this.OrderGridCreateNewRow(-1);
                        currRow = this.grdOrder.CurrentRowNumber;
                    }

                    if (IsExistDifferntDrugGroup(((Hashtable)(this.tabGroup.SelectedTab.Tag))["group_ser"].ToString(), rows[i]["order_gubun_bas"].ToString()) == true)
                    {
                        //같은그룹에 외용약과 내복약은 혼재할 수 없습니다.
                        MessageBox.Show(XMsg.GetMsg("M009"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.grdOrder.DeleteRow(this.grdOrder.CurrentRowNumber);
                        return;
                    }

                    // 긴급 관련
                    if (this.mOrderBiz.IsAbleToCurrentEmergencyGroup(groupInfo, aSourceLayout.LayoutTable.Rows[i]) == false)
                    {
                        return;
                    }

                    foreach (DataColumn cl in this.grdOrder.LayoutTable.Columns)
                    {
                        // 그룹정보내의 정보이면 그룹정보에서 가져가고
                        if (cl.ColumnName != "dv" && cl.ColumnName != "dv_time" && ((Hashtable)this.tabGroup.SelectedTab.Tag).Contains(cl.ColumnName))
                        {
                            this.grdOrder.LayoutTable.Rows[currRow][cl.ColumnName] = ((Hashtable)this.tabGroup.SelectedTab.Tag)[cl.ColumnName].ToString();
                        }
                        // 아닌것들은 로우에서 가져간다.
                        else if (aSourceLayout.LayoutTable.Columns.Contains(cl.ColumnName))
                        {
                            this.grdOrder.LayoutTable.Rows[currRow][cl.ColumnName] = rows[i][cl.ColumnName];
                        }
                    }

                    // 입원인경우 nday_yn 셋팅 
                    if (this.IOEGUBUN == "I")
                    {
                        string nalsu = this.grdOrder.LayoutTable.Rows[currRow]["nalsu"].ToString();

                        if (TypeCheck.IsInt(nalsu) && int.Parse(nalsu) > 1)
                        {
                            //NALSUが2以上だとしても入院オーダではNDAY_YNにYを入れてオーダを解けない。
                            //this.grdOrder.LayoutTable.Rows[currRow]["nday_yn"] = "Y";
                            this.grdOrder.LayoutTable.Rows[currRow]["nday_yn"] = "N";
                        }
                        else
                        {
                            this.grdOrder.LayoutTable.Rows[currRow]["nday_yn"] = "N";
                        }
                    }

                    // 오더 구분 관련 
                    if (rows[i]["order_gubun"].ToString().Length < 2)
                        this.grdOrder.LayoutTable.Rows[currRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, this.grdOrder, currRow) + rows[i]["order_gubun"].ToString();
                    else
                        this.grdOrder.LayoutTable.Rows[currRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, this.grdOrder, currRow) + rows[i]["order_gubun"].ToString().Substring(1, 1);

                    // 외용이냐 내복이냐에 따라 일수표시에 대산 부분이 visible Setting 
                    // 현재 화면이 외래 모드인경우만 인서트     
                    if (IOEGUBUN == "O")
                        this.grdOrder.LayoutTable.Rows[currRow]["jundal_table"] = rows[i]["jundal_table_out"].ToString();
                    else
                        this.grdOrder.LayoutTable.Rows[currRow]["jundal_table"] = rows[i]["jundal_table_inp"].ToString();

                    // 현재 화면이 외래 모드인경우만 인서트
                    if (IOEGUBUN == "O")
                        this.grdOrder.LayoutTable.Rows[currRow]["jundal_part"] = rows[i]["jundal_part_out"].ToString();
                    else
                        this.grdOrder.LayoutTable.Rows[currRow]["jundal_part"] = rows[i]["jundal_part_inp"].ToString();

                    // 돈복, 내용, 외용에 따른 dv_time 셋팅 이건 강제 셋팅 하자...
                    if (aExecutiveMode != HangmogInfo.ExecutiveMode.BeforeOrderCopy &&
                        aExecutiveMode != HangmogInfo.ExecutiveMode.YaksokCopy &&
                        aExecutiveMode != HangmogInfo.ExecutiveMode.OrderCopy)
                    {
                        if (this.grdOrder.GetItemValue(i, "dv_time").ToString() != "@")
                        {
                            if (this.grdOrder.LayoutTable.Rows[currRow]["order_gubun"].ToString().Substring(1, 1) == "C")
                            {
                                if (groupInfo.Contains("donbog_yn") && groupInfo["donbog_yn"].ToString() == "Y")
                                {
                                    this.grdOrder.LayoutTable.Rows[currRow]["dv_time"] = "*";
                                }
                                else
                                {
                                    this.grdOrder.LayoutTable.Rows[currRow]["dv_time"] = "/";
                                }
                            }
                            else
                            {
                                this.grdOrder.LayoutTable.Rows[currRow]["dv_time"] = "*";
                            }
                        }
                    }

                    this.grdOrder.DisplayData();

                    //if (this.tabGroup.SelectedTab.Tag != null)
                    //    this.ApplyGroupInfoToRow((Hashtable)this.tabGroup.SelectedTab.Tag, currRow);

                    this.mFocusRow = currRow;
                }

                this.mHangmogInfo.SetAlignMixGroup(this.grdOrder, startRow, currRow);

                this.grdOrder.DisplayData();

                this.SetOrderImage(this.grdOrder);

                // 외용, 내복에 따른 변경부분셋팅
                this.SetGroupControlVisible(((Hashtable)(this.tabGroup.SelectedTab.Tag))["group_ser"].ToString());

            }

            #endregion
        }

        private void ApplyCopyOrderInfo(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aExcutiveMode)
        {
            MultiLayout laySameDrugGroup = new MultiLayout();
            MultiLayout layOtherDrugGroup = new MultiLayout();


            bool isMerge = true;
            Hashtable groupInfo;
            //int focusRow = -1;

            if (this.tabGroup.SelectedTab == null)
                HandleBtnListClick(FunctionType.Process);
            groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.mInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IOEGUBUN;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;

            if (this.mOrderMode == OrderVariables.OrderMode.InpOrder)
                this.mHangmogInfo.Parameter.Ho_dong = this.mPatientInfo.GetPatientInfo["ho_dong"].ToString();

            this.mHangmogInfo.Parameter.Wonyoi_Order_Yn_Wonmu = this.cbxWonyoiOrderYN.GetDataValue();

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                this.mHangmogInfo.Parameter.Bunho = this.mPatientInfo.GetPatientInfo["bunho"].ToString();
                this.mHangmogInfo.Parameter.NaewonKey = this.mPatientInfo.GetPatientInfo["naewon_key"].ToString();
                this.mHangmogInfo.Parameter.Gubun = this.mPatientInfo.GetPatientInfo["gubun"].ToString();
                this.mHangmogInfo.Parameter.Birth_Date = this.mPatientInfo.GetPatientInfo["birth"].ToString();
                this.mHangmogInfo.Parameter.Gwa = this.mPatientInfo.GetPatientInfo["gwa"].ToString();
                this.mHangmogInfo.Parameter.ApproveDoctor = this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString();
            }

            if (this.mHangmogInfo.LoadHangmogInfo(aExcutiveMode, aSourceLayout) == false)
            {
                return;
            }

            MultiLayout layOrderData = this.mHangmogInfo.GetHangmogInfo;



            if (aExcutiveMode == HangmogInfo.ExecutiveMode.BeforeOrderCopy ||
                aExcutiveMode == HangmogInfo.ExecutiveMode.YaksokCopy ||
                aExcutiveMode == HangmogInfo.ExecutiveMode.RegularDrugCopy)
            {
                // 현재 커런트 그룹정보와 동일하지 않은 그룹정보의 오더가 존재 한다면


                // 동일 정보에 복용코드가 틀린 오더가 여러건 존재한다면...
                // 동일 그룹으로 머지 할건지...하니면 다른 그룹으로 분리할건지 결정한다.
                // 만일 멀티가 아니면? 현재그룹으로 강제 셋팅?

                // 정시약 ㅋㅏ피인경우는 정시약 테이블에 긴급여부와 워ㅜㄴ외처방여부 컬럼이 없기에
                // 현재 기준을 따라간다.
                if (aExcutiveMode == HangmogInfo.ExecutiveMode.RegularDrugCopy)
                {
                    //Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

                    for (int row = 0; row < layOrderData.RowCount; row++)
                    {
                        if (groupInfo.Contains("emergency"))
                            layOrderData.SetItemValue(row, "emergency", groupInfo["emergency"].ToString());
                        else
                            layOrderData.SetItemValue(row, "emergency", "N");

                        if (groupInfo.Contains("wonyoi_order_yn"))
                            layOrderData.SetItemValue(row, "wonyoi_order_yn", groupInfo["wonyoi_order_yn"].ToString());
                        else
                            layOrderData.SetItemValue(row, "wonyoi_order_yn", "N");
                    }
                }

                // CP 오더 인경우는 nalsu 가 1로 고정된다.
                //if (this.mOrderMode == OrderVariables.OrderMode.CpOrder )
                //{
                //    for (int row = 0; row < layOrderData.RowCount; row++)
                //    {
                //        if (layOrderData.GetItemString(row, "nalsu") != "1")
                //            layOrderData.SetItemValue(row, "nalsu", "1");
                //    }
                //}

                // Set 오더 인경우는 bogyong_code, nalsu, 긴급, 원외 등의 값이 없는 경우는 현재 그룹에 맞추어 간다.
                if (aExcutiveMode == HangmogInfo.ExecutiveMode.YaksokCopy)
                {
                    for (int row = 0; row < layOrderData.RowCount; row++)
                    {
                        if (layOrderData.GetItemString(row, "bogyong_code") == "" && groupInfo.Contains("bogyong_code"))
                        {
                            layOrderData.SetItemValue(row, "bogyong_code", groupInfo["bogyong_code"]);
                        }

                        if (layOrderData.GetItemString(row, "nalsu") == "" && groupInfo.Contains("nalsu"))
                        {
                            layOrderData.SetItemValue(row, "nalsu", groupInfo["nalsu"]);
                        }

                        if (layOrderData.GetItemString(row, "emergency") == "" && groupInfo.Contains("emergency"))
                        {
                            layOrderData.SetItemValue(row, "emergency", groupInfo["emergency"]);
                        }

                        if (layOrderData.GetItemString(row, "wonyoi_order_yn") == "" && groupInfo.Contains("wonyoi_order_yn"))
                        {
                            layOrderData.SetItemValue(row, "wonyoi_order_yn", groupInfo["wonyoi_order_yn"]);
                        }
                    }
                }

                //if (this.IsExistDifferentGroupInfo(layOrderData) == true)
                //{
                //    if (MessageBox.Show(XMsg.GetMsg("M007"), XMsg.GetField("F002"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //    {
                //        isMerge = true;
                //    }
                //    else
                //    {
                //        isMerge = false;
                //    }
                //}

                if (aExcutiveMode == HangmogInfo.ExecutiveMode.YaksokCopy ||
                    aExcutiveMode == HangmogInfo.ExecutiveMode.BeforeOrderCopy ||
                    aExcutiveMode == HangmogInfo.ExecutiveMode.RegularDrugCopy)
                {
                    isMerge = false;
                }
                else
                {
                    if (MessageBox.Show(XMsg.GetMsg("M007"), XMsg.GetField("F002"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        isMerge = false;
                    }
                    else
                    {
                        isMerge = true;
                    }
                }

            }

            // 머지여부
            if (isMerge == true)
            {

                string sameDrugGroup = "C"; // 내복약;

                if (this.mOrderFunc.IsEmptyGroup(this.grdOrder, ((Hashtable)this.tabGroup.SelectedTab.Tag)["group_ser"].ToString()))
                {
                    sameDrugGroup = layOrderData.GetItemString(0, "order_gubun").PadLeft(2, '0').Substring(1, 1); // 내복약;
                }
                else
                {
                    if (this.IsOutDrugGroup(((Hashtable)this.tabGroup.SelectedTab.Tag)["group_ser"].ToString()))
                    {
                        sameDrugGroup = "D"; // 외용약
                    }
                    else
                    {
                        sameDrugGroup = "C";
                    }
                }

                foreach (MultiLayoutItem item in layOrderData.LayoutItems)
                {
                    laySameDrugGroup.LayoutItems.Add(item);
                    layOtherDrugGroup.LayoutItems.Add(item);
                }
                laySameDrugGroup.InitializeLayoutTable();
                layOtherDrugGroup.InitializeLayoutTable();

                #region 그룹정보 및 항목코드 셋팅

                for (int i = 0; i < layOrderData.RowCount; i++)
                {
                    //// 그룹정보 로드
                    //// 그룹시리얼
                    //if (groupInfo.Contains("group_ser"))
                    //{
                    //    layOrderData.SetItemValue(i, "group_ser", groupInfo["group_ser"].ToString());
                    //}
                    //// 복용코드
                    //if (groupInfo.Contains("bogyong_code"))
                    //{
                    //    layOrderData.SetItemValue(i, "bogyong_code", groupInfo["bogyong_code"].ToString());
                    //}
                    //// DV
                    //if (groupInfo.Contains("dv"))
                    //{
                    //    if (this.mOrderBiz.IsDrugOutCode(layOrderData.GetItemString(i, "order_gubun_bas")) == false)
                    //    {
                    //        if (groupInfo["dv"].ToString() == "")
                    //        {
                    //            if (this.mOrderFunc.IsEmptyGroup(this.grdOrder, groupInfo["group_ser"].ToString()) == false)
                    //            {
                    //                layOrderData.SetItemValue(i, "dv", this.grdOrder.GetItemString(i, "dv"));
                    //            }

                    //        }
                    //        else
                    //        {
                    //            layOrderData.SetItemValue(i, "dv", groupInfo["dv"].ToString());
                    //        }

                    //    }
                    //}
                    //// Emergency
                    //if (groupInfo.Contains("emergency"))
                    //{
                    //    layOrderData.SetItemValue(i, "emergency", groupInfo["emergency"].ToString());
                    //}
                    //// 원외처방여부
                    //if (groupInfo.Contains("wonyoi_order_yn"))
                    //{
                    //    layOrderData.SetItemValue(i, "wonyoi_order_yn", groupInfo["wonyoi_order_yn"].ToString());
                    //}

                    if (sameDrugGroup == layOrderData.GetItemString(i, "order_gubun").PadLeft(2, '0').Substring(1, 1))
                    {
                        // 그룹정보 로드
                        // 그룹시리얼
                        if (groupInfo.Contains("group_ser"))
                        {
                            layOrderData.SetItemValue(i, "group_ser", groupInfo["group_ser"].ToString());
                        }
                        // 복용코드
                        if (groupInfo.Contains("bogyong_code"))
                        {
                            layOrderData.SetItemValue(i, "bogyong_code", groupInfo["bogyong_code"].ToString());
                        }
                        // DV
                        if (groupInfo.Contains("dv"))
                        {
                            if (this.mOrderBiz.IsDrugOutCode(layOrderData.GetItemString(i, "order_gubun_bas")) == false)
                            {
                                if (groupInfo["dv"].ToString() == "")
                                {
                                    if (this.mOrderFunc.IsEmptyGroup(this.grdOrder, groupInfo["group_ser"].ToString()) == false)
                                    {
                                        layOrderData.SetItemValue(i, "dv", this.grdOrder.GetItemString(i, "dv"));
                                    }

                                }
                                else
                                {
                                    layOrderData.SetItemValue(i, "dv", groupInfo["dv"].ToString());
                                }

                            }
                        }
                        // Emergency
                        if (groupInfo.Contains("emergency"))
                        {
                            layOrderData.SetItemValue(i, "emergency", groupInfo["emergency"].ToString());
                        }
                        // 원외처방여부
                        if (groupInfo.Contains("wonyoi_order_yn"))
                        {
                            layOrderData.SetItemValue(i, "wonyoi_order_yn", groupInfo["wonyoi_order_yn"].ToString());
                        }

                        laySameDrugGroup.LayoutTable.ImportRow(layOrderData.LayoutTable.Rows[i]);
                    }
                    else
                    {
                        layOtherDrugGroup.LayoutTable.ImportRow(layOrderData.LayoutTable.Rows[i]);
                    }
                }

                #endregion
            }

            // 인서트 후 포커스 로우
            //focusRow = this.grdOrder.RowCount - 1 + layOrderData.RowCount;
            this.mFocusRow = this.grdOrder.RowCount - 1 + layOrderData.RowCount;

            if (isMerge)
            {
                //this.ApplyDefaultOrderInfo(aExcutiveMode, layOrderData, this.grdOrder, this.grdOrder.CurrentRowNumber, false);
                if (laySameDrugGroup.RowCount > 0)
                    this.ApplyDefaultOrderInfo(aExcutiveMode, laySameDrugGroup, this.grdOrder, this.grdOrder.CurrentRowNumber, false);

                // 다른 약이 존재하면 
                // 새로운 그룹을 만들고 그룹시리얼을 그거에 맞춘다.
                if (layOtherDrugGroup.RowCount > 0)
                {
                    HandleBtnListClick(FunctionType.Process);
                    Hashtable otherGroupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

                    for (int j = 0; j < layOtherDrugGroup.RowCount; j++)
                    {
                        if (otherGroupInfo.Contains("group_ser"))
                        {
                            layOtherDrugGroup.SetItemValue(j, "group_ser", otherGroupInfo["group_ser"].ToString());
                        }

                        if (otherGroupInfo.Contains("bogyong_code"))
                        {
                            layOtherDrugGroup.SetItemValue(j, "bogyong_code", otherGroupInfo["bogyong_code"].ToString());
                        }

                        if (otherGroupInfo.Contains("nalsu"))
                        {
                            layOtherDrugGroup.SetItemValue(j, "nalsu", otherGroupInfo["nalsu"].ToString());
                        }

                        if (otherGroupInfo.Contains("wonyoi_order_yn"))
                        {
                            layOtherDrugGroup.SetItemValue(j, "wonyoi_order_yn", otherGroupInfo["wonyoi_order_yn"].ToString());
                        }

                        if (otherGroupInfo.Contains("emergency"))
                        {
                            layOtherDrugGroup.SetItemValue(j, "emergency", otherGroupInfo["emergency"].ToString());
                        }
                    }

                    this.ApplyDefaultOrderInfo(aExcutiveMode, layOtherDrugGroup, this.grdOrder, this.grdOrder.CurrentRowNumber, false);
                    //this.ApplyDivideOrderInfo(aExcutiveMode, layOtherDrugGroup, this.grdOrder, this.grdOrder.CurrentRowNumber);
                }
            }
            else
            {
                //this.ApplyDivideOrderInfo(this.mHangmogInfo.GetHangmogInfo, this.grdOrder, -1);
                this.ApplyDivideOrderInfo(aExcutiveMode, layOrderData, this.grdOrder, this.grdOrder.CurrentRowNumber);
            }

            // 이거 다 해놓고
            // 그룹이벤트를 다시 태워야 하네...
            if (isMerge == false)
            {
                this.tabGroup_SelectionChanged(this.tabGroup, new EventArgs());
            }
            else
            {
                //this.DisplayOrderGridGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag);
                //PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert));
                this.tabGroup_SelectionChanged(this.tabGroup, new EventArgs());
            }

            this.DisplayMixGroup(this.grdOrder);

            this.SetOrderImage(this.grdOrder);

            this.MakePreviewStatus();

            // 카피한 후에는 오더 상황을 확인할텐데...
            if (this.rbnOrderStatus.Checked == false)
            {
                this.rbnOrderStatus.Checked = true;
            }

        }

        private void ApplySangOrderInfo(string aHangmogCode, int aApplyRow, bool aIsApplyCurrentRow, string aGenericSearchYN)
        {
            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.mInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IOEGUBUN;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;
            this.mHangmogInfo.Parameter.Wonyoi_Order_Yn_Wonmu = this.cbxWonyoiOrderYN.GetDataValue();

            if (this.mOrderMode == OrderVariables.OrderMode.InpOrder)
                this.mHangmogInfo.Parameter.Ho_dong = this.mPatientInfo.GetPatientInfo["ho_dong"].ToString();

            if (this.mGeneral_disp_yn == "Y" && this.mOrderBiz.IsGeneralYN(aHangmogCode) != "")
                this.mHangmogInfo.Parameter.GenericSearchYN = "Y";
            else
                this.mHangmogInfo.Parameter.GenericSearchYN = this.mGenericSearchYN;

            if (this.rbtGenericSearch.Checked == true || this.mHangmogInfo.Parameter.GenericSearchYN == "Y")
                this.mHangmogInfo.Parameter.Generic_name = this.mOrderBiz.IsGeneralYN(aHangmogCode);

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                this.mHangmogInfo.Parameter.Bunho = this.mPatientInfo.GetPatientInfo["bunho"].ToString();
                this.mHangmogInfo.Parameter.NaewonKey = this.mPatientInfo.GetPatientInfo["naewon_key"].ToString();
                this.mHangmogInfo.Parameter.Gubun = this.mPatientInfo.GetPatientInfo["gubun"].ToString();
                this.mHangmogInfo.Parameter.Birth_Date = this.mPatientInfo.GetPatientInfo["birth"].ToString();
                this.mHangmogInfo.Parameter.Gwa = this.mPatientInfo.GetPatientInfo["gwa"].ToString();
                this.mHangmogInfo.Parameter.ApproveDoctor = this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString();
            }

            #region 그룹정보 및 항목코드 셋팅

            MultiLayout loadExtraInfo = new MultiLayout();

            loadExtraInfo.LayoutItems.Add("hangmog_code", DataType.String);
            //insert by jc [一般名検索追加] 2012/11/01
            loadExtraInfo.LayoutItems.Add("hangmog_name", DataType.String);
            loadExtraInfo.LayoutItems.Add("group_ser", DataType.String);
            loadExtraInfo.LayoutItems.Add("bogyong_code", DataType.String);
            loadExtraInfo.LayoutItems.Add("dv", DataType.String);
            loadExtraInfo.LayoutItems.Add("emergency", DataType.String);
            loadExtraInfo.LayoutItems.Add("wonyoi_order_yn", DataType.String);

            loadExtraInfo.InitializeLayoutTable();

            Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            loadExtraInfo.InsertRow(-1);

            // 항목정보
            loadExtraInfo.SetItemValue(0, "hangmog_code", aHangmogCode);
            // 그룹정보 로드
            // 그룹시리얼
            if (groupInfo.Contains("group_ser"))
            {
                loadExtraInfo.SetItemValue(0, "group_ser", groupInfo["group_ser"].ToString());
            }
            // 복용코드
            if (groupInfo.Contains("bogyong_code"))
            {
                loadExtraInfo.SetItemValue(0, "bogyong_code", groupInfo["bogyong_code"].ToString());
            }
            // DV
            if (groupInfo.Contains("dv"))
            {
                //グループが違う場合もあるのでdvを受け継がない。
                //if (groupInfo["dv"].ToString() == "")
                //    loadExtraInfo.SetItemValue(0, "dv", this.grdOrder.GetItemString(grdOrder.CurrentRowNumber, "dv"));
                //else
                if (groupInfo["dv"].ToString() != "")
                    loadExtraInfo.SetItemValue(0, "dv", groupInfo["dv"].ToString());
            }
            else
            {
                if (this.mOrderFunc.IsEmptyGroup(this.grdOrder, groupInfo["group_ser"].ToString()) == false)
                {
                    loadExtraInfo.SetItemValue(0, "dv", this.grdOrder.GetItemString(grdOrder.CurrentRowNumber, "dv"));
                }
            }
            // Emergency
            if (groupInfo.Contains("emergency"))
            {
                loadExtraInfo.SetItemValue(0, "emergency", groupInfo["emergency"].ToString());
            }
            // 원외처방여부
            if (groupInfo.Contains("wonyoi_order_yn"))
            {
                loadExtraInfo.SetItemValue(0, "wonyoi_order_yn", groupInfo["wonyoi_order_yn"].ToString());
            }

            #endregion

            if (this.mHangmogInfo.LoadHangmogInfo(HangmogInfo.ExecutiveMode.CodeInput, loadExtraInfo) == false)
            {
                return;
            }            
            this.ApplyDefaultOrderInfo(HangmogInfo.ExecutiveMode.CodeInput, this.mHangmogInfo.GetHangmogInfo, this.grdOrder, aApplyRow, aIsApplyCurrentRow);
                       
            // 이거 다 해놓고
            // 그룹이벤트를 다시 태워야 하네...
            //this.tabGroup_SelectionChanged(this.tabGroup, new EventArgs());
            //=========================Check Drg IO hosp code========================================
            //for (int i = 0; i < grdDrgOrder.RowCount; i++ )
            //{
            //    if (grdDrgOrder.GetItemString(i,"wonnae_drg_yn") == "Y")
            //    {
            //        cbxWonyoiOrderYN.Checked = false;  
            //    }
            //    else
            //    {

            //    }
            //}
            if (this.grdOrder.GetItemString(grdOrder.CurrentRowNumber, "wonnae_drg_yn") == "Y")
            {
                isCheckHospCode = false;
            }
            ActionCheckOutHosp();
            //=========================Check Drg IO hosp code========================================
            this.DisplayOrderGridGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag);

            this.DisplayMixGroup(this.grdOrder);

            this.SetOrderImage(this.grdOrder);

            PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert));
        }

        private bool IsExistDifferntDrugGroup(string aGroupSer, string aOrderGubunBas)
        {
            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                if (this.grdOrder.GetItemString(i, "order_gubun_bas") != "" &&
                    aOrderGubunBas != this.grdOrder.GetItemString(i, "order_gubun_bas") &&
                    aGroupSer == this.grdOrder.GetItemString(i, "group_ser"))
                {
                    if (i == this.grdOrder.CurrentRowNumber && this.grdOrder.GetItemString(i, "hangmog_code") == "")
                        continue;

                    return true;
                }
            }

            return false;
        }

        private bool IsOutDrugGroup(string aGroupSer)
        {
            DataRow[] rows = this.grdOrder.LayoutTable.Select("group_ser=" + aGroupSer);

            if (rows.Length <= 0) return false;

            foreach (DataRow dr in rows)
            {
                if (dr["order_gubun"].ToString() != "" && dr["order_gubun"].ToString().Substring(1, 1) == "D")
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsDonbokGroup(string aGroupSer)
        {
            //Hashtable groupInfo;

            //foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroup.TabPages)
            //{
            //    groupInfo = tpg.Tag as Hashtable;

            //    if (groupInfo["group_ser"].ToString() == aGroupSer)
            //    {
            //        if (groupInfo.Contains("donbog_yn"))
            //        {
            //            if (groupInfo["donbog_yn"].ToString() == "Y")
            //                return true;
            //        }
            //    }
            //}


            DataRow[] rows = this.grdOrder.LayoutTable.Select("group_ser=" + aGroupSer);

            if (rows.Length <= 0) return false;

            foreach (DataRow dr in rows)
            {
                if (dr["order_gubun"].ToString() != "" && dr["donbog_yn"].ToString() == "Y")
                {
                    return true;
                }
            }


            return false;
        }

        private void SetGroupControlVisible(string aGroupSer)
        {
            if (this.IsOutDrugGroup(aGroupSer))
            {
                this.lblNalsu.Visible = false;
                this.cboNalsu.Visible = false;
                if (this.cboNalsu.GetDataValue() != "1")
                {
                    this.cboNalsu.SetEditValue("1");
                    this.cboNalsu.AcceptData();
                }
            }
            else if (this.IsDonbokGroup(aGroupSer))
            {
                this.lblNalsu.Visible = false;
                this.cboNalsu.Visible = false;
                if (this.cboNalsu.GetDataValue() != "1")
                {
                    this.cboNalsu.SetEditValue("1");
                    this.cboNalsu.AcceptData();
                }
            }
            else
            {
                this.lblNalsu.Visible = true;
                this.cboNalsu.Visible = true;
            }
        }

        private void ShowDcGubun(XEditGrid aGrid, string aGroupSer)
        {
            DataRow[] dr = aGrid.LayoutTable.Select("group_ser=" + aGroupSer + " AND dc_gubun='Y'");

            if (dr != null && dr.Length > 0)
            {
                aGrid.AutoSizeColumn(1, 35);
            }
            else
            {
                aGrid.AutoSizeColumn(1, 0);
            }
        }

        private void SetWonyoiDefault()
        {
            //string cmd = " SELECT FN_DRG_LOAD_CHECK_DRG_TIME( TRUNC(SYSDATE), TO_CHAR(SYSDATE, 'HH24MI') ) FROM SYS.DUAL ";

            if (this.IOEGUBUN == "O" && this.mPatientInfo.GetPatientInfo != null)
            {
                //object defaultwonyoi = Service.ExecuteScalar(cmd);
                string defaultwonyoi = _formResult.CheckDrgTime;

                if (defaultwonyoi == "N"/*(defaultwonyoi != null && defaultwonyoi.ToString() == "N")*/
                    || this.mPatientInfo.GetPatientInfo["gwa"].ToString() == EMERGENCY_GWA || this.mCallerScreenID == CREATE_DO)
                {
                    this.mDefaultWonyoiOrder = "N";
                }
                else
                {
                    this.mDefaultWonyoiOrder = "Y";
                }
            }
            else
            {
                mDefaultWonyoiOrder = "N";
            }
        }

        // 탭정보 
        private void LoadGroupTabData(string aIOGubun, string aFkInOutKey, string aInputGubun, string aInputTab)
        {
            this.layGroupTab.SetBindVarValue("io_gubun", aIOGubun);
            this.layGroupTab.SetBindVarValue("fk_in_out_key", aFkInOutKey);
            this.layGroupTab.SetBindVarValue("input_gubun", aInputGubun);
            this.layGroupTab.SetBindVarValue("input_tab", aInputTab);

            this.layGroupTab.QueryLayout(true);
        }

        private void LoadOrderTable(OrderVariables.OrderMode aOrderMode, string aMemb, string aYaksokCode, string aFkInOutKey, string aInputGubun, string aInputTab, string aOrderGubun)
        {
            this.grdOrder.SetBindVarValue("memb", aMemb);
            this.grdOrder.SetBindVarValue("yaksok_code", aYaksokCode);
            this.grdOrder.SetBindVarValue("fk_in_out_key", aFkInOutKey);
            this.grdOrder.SetBindVarValue("input_tab", aInputTab);
            this.grdOrder.SetBindVarValue("input_gubun", aInputGubun);

            this.grdOrder.QueryLayout(true);
        }

        /// <summary>
        /// 빈그룹이 존재하는지 여부
        /// </summary>
        /// <returns>true, false</returns>
        private bool IsExistEmptyGroup()
        {
            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroup.TabPages)
            {
                Hashtable groupInfo = tpg.Tag as Hashtable;

                if (this.grdOrder.RowCount > 0)
                {
                    DataRow[] dr = grdOrder.LayoutTable.Select("group_ser=" + groupInfo["group_ser"].ToString());
                    if (dr.Length <= 0) return true;
                    else if (dr.Length == 1 && dr[0]["hangmog_code"].ToString() == "")
                    {
                        return true;
                    }
                }
                else
                    return true;
            }

            return false;
        }

        private void setSelectExistEmptyGroup()
        {
            //string emptyGroupSer = "";

            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroup.TabPages)
            {
                Hashtable groupInfo = tpg.Tag as Hashtable;

                if (this.grdOrder.RowCount > 0)
                {
                    DataRow[] dr = grdOrder.LayoutTable.Select("group_ser=" + groupInfo["group_ser"].ToString());
                    if (dr.Length <= 0)
                        this.tabGroup.SelectedTab = tpg;
                    else if (dr.Length == 1 && dr[0]["hangmog_code"].ToString() == "")
                        this.tabGroup.SelectedTab = tpg;
                }
            }
        }

        /// <summary>
        /// 신규그룹페이지 생성하기
        /// </summary>
        private void MakeNewOrderGroup(bool aIsShowFindDlg)
        {
            if (this.IsExistEmptyGroup())
            {
                this.setSelectExistEmptyGroup();
                return;
            }

            IHIS.X.Magic.Controls.TabPage tpg = new IHIS.X.Magic.Controls.TabPage();

            int groupSer = 1;
            if (mPatientInfo.GetPatientInfo != null)
            {
                if (this.IOEGUBUN == "O")
                    //groupSer = (this.mHangmogInfo.GetMaxGroupSer(this.grdOrder) + 1);
                    groupSer = int.Parse(this.mHangmogInfo.GetNextGroupSer(INPUTTAB, this.mPatientInfo.GetPatientInfo["bunho"].ToString(), mPatientInfo.GetPatientInfo["naewon_key"].ToString(), "OCS1003"));
                else
                    groupSer = int.Parse(this.mHangmogInfo.GetNextGroupSer(INPUTTAB, this.mPatientInfo.GetPatientInfo["bunho"].ToString(), mPatientInfo.GetPatientInfo["naewon_key"].ToString(), "OCS2003"));
            }
            else
            {
                if (this.IOEGUBUN == "O")
                {
                    groupSer = int.Parse(this.mHangmogInfo.GetNextGroupSer(INPUTTAB,"","", "OCS1003"));
                }
                else
                {
                    groupSer = int.Parse(this.mHangmogInfo.GetNextGroupSer(INPUTTAB,"","", "OCS2003"));
                }
            }

            if (groupSer == 1 || groupSer == 200)
                groupSer = 101;

            tpg.Title = Resources.groupSer1 + groupSer.ToString() + Resources.groupSer2;
            Hashtable groupInfo = new Hashtable();

            groupInfo.Add("group_ser", groupSer);
            groupInfo.Add("group_name", tpg.Title);
            groupInfo.Add("bogyong_code", "");
            groupInfo.Add("bogyong_name", "");
            groupInfo.Add("emergency", "N");
            groupInfo.Add("nalsu", "0");
            //groupInfo.Add("dv", "1");
            //if (this.IOEGUBUN == "O")
            //    groupInfo.Add("wonyoi_order_yn", "Y");
            //else
            //    groupInfo.Add("wonyoi_order_yn", "N");
            //同じ院外オーダフラグを受け継ぐ
            if (grdOrder.GetItemString(0, "wonyoi_order_yn") != "")
                groupInfo.Add("wonyoi_order_yn", grdOrder.GetItemString(0, "wonyoi_order_yn").ToString());
            else
                groupInfo.Add("wonyoi_order_yn", this.mDefaultWonyoiOrder);



            tpg.Tag = groupInfo;
            tpg.ImageList = this.ImageList;
            tpg.ImageIndex = 1;

            // 이벤트 정지 로직이 들어가야함.
            this.tabGroup.SelectionChanged -= new EventHandler(tabGroup_SelectionChanged);

            this.tabGroup.SuspendLayout();

            // 신규 페이지 작성
            this.tabGroup.TabPages.Add(tpg);

            this.tabGroup.SelectedTab = tpg;

            this.tabGroup.ResumeLayout();

            this.tabGroup.SelectionChanged += new EventHandler(tabGroup_SelectionChanged);

            this.tabGroup_SelectionChanged(this.tabGroup, new EventArgs());
            //this.DisplayOrderGridGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag);

            // 초기값 셋팅
            this.cboNalsu.SetEditValue(""); // 날수는 1로 기본셋팅
            this.cboNalsu.AcceptData();

            // 원외설정
            this.cbxWonyoiOrderYN.CheckedChanged -= new EventHandler(cbxWonyoiOrderYN_CheckedChanged);
            //if (this.IOEGUBUN == "O")
            //    this.cbxWonyoiOrderYN.SetDataValue("Y");
            //else
            //    this.cbxWonyoiOrderYN.SetDataValue("N");

            //同じ院外オーダフラグを受け継ぐ
            if (grdOrder.GetItemString(0, "wonyoi_order_yn") != "")
                this.cbxWonyoiOrderYN.SetDataValue(grdOrder.GetItemString(0, "wonyoi_order_yn").ToString());
            else
                this.cbxWonyoiOrderYN.SetDataValue(this.mDefaultWonyoiOrder);


            this.cbxWonyoiOrderYN.CheckedChanged += new EventHandler(cbxWonyoiOrderYN_CheckedChanged);

            // 
            //if (aIsShowFindDlg)
            //    this.OpenScreen_OCS0208Q00();

        }

        private void MakeGroupTabInfo(string aIOGubun, string aFkInOutKey, string aInputGubun, string aInputTab)
        {
            if (this.grdOrder.RowCount <= 0)
            {
                // 저장된 그룹탭 정보가 없는경우
                // 신규 그룹을 생성한다.
                HandleBtnListClick(FunctionType.Process);
            }
            else
            {
                this.tabGroup.SelectionChanged -= new EventHandler(tabGroup_SelectionChanged);

                try
                {
                    this.tabGroup.TabPages.Clear();
                }
                catch
                {
                    this.tabGroup.Refresh();
                }

                IHIS.X.Magic.Controls.TabPage ldTab;
                Hashtable groupInfo;
                string curGroupSer = "";

                //string curNalsu = "";
                //string curBogyonog_code = "";
                //string curEmegency = "";
                //string curHopeDate = "";
                //string curWonyoiOrderYN = "";

                bool isExist = false;

                foreach (DataRow dr in this.grdOrder.LayoutTable.Rows)
                {
                    // 의사인경우는 넘어온 input_gubun 과 일치하는 입력구분만 보여주고
                    // 의사 이외의 경우는 의사 오더 및 자신의 입력구분에 해당하는 오더를 전부 보여준다.
                    //if (     (this.mInputGubun.Substring(0, 1) == "D" && dr["input_gubun"].ToString() == this.mInputGubun)
                    //      || (this.mInputGubun.Substring(0, 1) != "D" && (dr["input_gubun"].ToString() == this.mInputGubun || dr["input_gubun"].ToString().Substring(0, 1) == "D"))
                    //   )

                    // input_gubunに合うgroup_serタブを作る
                    //if (dr["input_gubun"].ToString() == this.mInputGubun)
                    //{
                    if ((UserInfo.UserGubun == UserType.Doctor && dr["input_gubun"].ToString() == this.mInputGubun)
                       || (UserInfo.UserGubun != UserType.Doctor && UserInfo.Gwa != "CK" && (dr["input_gubun"].ToString() == this.mInputGubun || dr["input_gubun"].ToString().Substring(0, 1) == "D"))
                       || (UserInfo.Gwa == "CK" && (dr["input_gubun"].ToString().Substring(0, 1) == "D" || dr["input_gubun"].ToString() == UserInfo.Gwa))
                      )
                    {


                        if (curGroupSer != dr["group_ser"].ToString())
                        //if (   curNalsu         != dr["nalsu"].ToString()
                        //    || curBogyonog_code != dr["bogyong_code"].ToString()
                        //    || curEmegency      != dr["emergency"].ToString()
                        //    || curWonyoiOrderYN != dr["wonyoi_order_yn"].ToString()
                        //    )
                        {
                            isExist = false;
                            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroup.TabPages)
                            {
                                if (dr["group_ser"].ToString() == ((Hashtable)tpg.Tag)["group_ser"].ToString())
                                {
                                    isExist = true;
                                    break;
                                }
                            }

                            if (isExist == false)
                            {

                                ldTab = new IHIS.X.Magic.Controls.TabPage();

                                ldTab.Title = Resources.groupSer1 + dr["group_ser"].ToString() + Resources.XMsg_000004 + dr["bogyong_name"].ToString();
                                //ldTab.Title = dr["group_ser"].ToString() + " グループ";
                                ldTab.ImageList = this.ImageList;
                                ldTab.ImageIndex = 1;

                                groupInfo = new Hashtable();
                                groupInfo.Add("group_ser", dr["group_ser"]);
                                groupInfo.Add("group_name", Resources.groupSer1 + dr["group_ser"].ToString() + Resources.XMsg_000004 + dr["bogyong_name"].ToString());
                                //groupInfo.Add("group_name", dr["group_ser"].ToString() + " グループ");
                                groupInfo.Add("bogyong_code", dr["bogyong_code"].ToString());
                                groupInfo.Add("bogyong_name", dr["bogyong_name"].ToString());
                                groupInfo.Add("emergency", dr["emergency"].ToString());
                                groupInfo.Add("nalsu", dr["nalsu"].ToString());
                                groupInfo.Add("wonyoi_order_yn", dr["wonyoi_order_yn"].ToString());
                                groupInfo.Add("dv", dr["dv"].ToString());
                                groupInfo.Add("donbog_yn", dr["donbog_yn"].ToString());

                                ldTab.Tag = groupInfo;

                                this.tabGroup.TabPages.Add(ldTab);

                                curGroupSer = dr["group_ser"].ToString();
                                //curNalsu         = dr["nalsu"].ToString();
                                //curBogyonog_code = dr["bogyong_code"].ToString();
                                //curEmegency      = dr["emergency"].ToString();
                                //curHopeDate      = dr["hope_date"].ToString();
                                //curWonyoiOrderYN = dr["wonyoi_order_yn"].ToString();


                            }
                        }
                    }
                }

                if (this.tabGroup.TabPages.Count > 0)
                {
                    this.tabGroup.SelectedTab = this.tabGroup.TabPages[0];

                    this.tabGroup.SelectionChanged += new EventHandler(tabGroup_SelectionChanged);

                    this.tabGroup_SelectionChanged(this, new EventArgs());
                    //this.DisplayOrderGridGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag);
                }
                else
                {
                    HandleBtnListClick(FunctionType.Process);
                }
            }
        }

        private void ApplyGroupInfo(Hashtable aExistGroupInfo, string aType, string aValue1, string aValue2, string aValue3, string aValue4)
        {
            string bogyongCode = "";
            string bogyongName = "";
            string dv = "";
            string nalsu = "";
            string emergency = "";
            string wonyoi_order_yn = "";
            string donbogyn = "";
            string orderRemark = "";

            #region 기존 데이터 셋팅

            if (aExistGroupInfo.Contains("bogyong_code"))
            {
                bogyongCode = aExistGroupInfo["bogyong_code"].ToString();
            }
            if (aExistGroupInfo.Contains("bogyong_name"))
            {
                bogyongName = aExistGroupInfo["bogyong_name"].ToString();
            }
            if (aExistGroupInfo.Contains("dv"))
            {
                dv = aExistGroupInfo["dv"].ToString();
            }
            if (aExistGroupInfo.Contains("nalsu"))
            {
                nalsu = aExistGroupInfo["nalsu"].ToString();
            }
            if (aExistGroupInfo.Contains("emergency"))
            {
                emergency = aExistGroupInfo["emergency"].ToString();
            }
            if (aExistGroupInfo.Contains("wonyoi_order_yn"))
            {
                wonyoi_order_yn = aExistGroupInfo["wonyoi_order_yn"].ToString();
            }
            if (aExistGroupInfo.Contains("donbog_yn"))
            {
                donbogyn = aExistGroupInfo["donbog_yn"].ToString();
            }
            if (aExistGroupInfo.Contains("order_remark"))
            {
                orderRemark = aExistGroupInfo["order_remark"].ToString();
            }

            #endregion

            #region 변경에 따른 데이터 셋팅

            switch (aType)
            {
                case "bogyong_code":

                    bogyongCode = aValue1;
                    bogyongName = aValue2;
                    dv = aValue3;
                    donbogyn = aValue4;

                    break;

                case "nalsu":

                    nalsu = aValue1;

                    break;

                case "emergency":

                    emergency = aValue1;

                    break;

                case "wonyoi_order_yn":

                    wonyoi_order_yn = aValue1;

                    break;
            }

            #endregion

            this.ApplyGroupInfo(bogyongCode, bogyongName, dv, nalsu, emergency, wonyoi_order_yn, donbogyn, orderRemark);
        }

        /// <summary>
        /// 그룹정보 셋팅
        /// </summary>
        /// <param name="aBogyongCode">복용코드</param>
        /// <param name="aBogyongName">복용코드명칭</param>
        /// <param name="aDv">DV</param>
        /// <param name="aNalsu">날수</param>
        /// <param name="aEmergency">긴급</param>
        /// <param name="aWonyoiOrderYN">원외처방여부</param>
        /// <param name="aDonbogYN">돈복YN</param>
        /// <param name="aOrderRemark">오더코맨트</param>
        private void ApplyGroupInfo(string aBogyongCode, string aBogyongName, string aDv
                                   , string aNalsu, string aEmergency, string aWonyoiOrderYN, string aDonbogYN, string aOrderRemark)
        {
            //insert by jc 下のaDvがNULLではない場合はGRIDの値を適用するが、それを防ぐため
            if (aDv == "0")
                aDv = "";

            // 탭인포에 적용
            Hashtable tabInfo = this.tabGroup.SelectedTab.Tag as Hashtable;
            string nalsu = aNalsu;

            this.tabGroup.SelectedTab.Title = Resources.groupSer1 + tabInfo["group_ser"].ToString() + Resources.groupSer2;

            if (aBogyongCode != "")
            {
                this.tabGroup.SelectedTab.Title += ":" + aBogyongName;
            }

            if (tabInfo.Contains("bogyong_code"))
                tabInfo.Remove("bogyong_code");
            tabInfo.Add("bogyong_code", aBogyongCode);

            if (tabInfo.Contains("bogyong_name"))
                tabInfo.Remove("bogyong_name");
            tabInfo.Add("bogyong_name", aBogyongName);

            if (tabInfo.Contains("donbog_yn"))
                tabInfo.Remove("donbog_yn");
            tabInfo.Add("donbog_yn", aDonbogYN);

            if (tabInfo.Contains("donbog_yn") && tabInfo["donbog_yn"].ToString() == "Y" && potionDrugOrder == "Y")
            {
                if (tabInfo.Contains("nalsu") && tabInfo["nalsu"].ToString() != "1")
                {
                    this.mbxMsg = XMsg.GetMsg("M008"); //돈복오더는 일수는 1이고 횟수로 조정합니다.

                    MessageBox.Show(this.mbxMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (tabInfo.Contains("nalsu"))
                    tabInfo.Remove("nalsu");
                tabInfo.Add("nalsu", "1");

                this.cboNalsu.SetDataValue("1");

                nalsu = "1";
            }
            else
            {
                if (tabInfo.Contains("nalsu"))
                    tabInfo.Remove("nalsu");
                tabInfo.Add("nalsu", aNalsu);
            }

            if (tabInfo.Contains("dv"))
                tabInfo.Remove("dv");
            tabInfo.Add("dv", aDv);

            if (tabInfo.Contains("emergency"))
                tabInfo.Remove("emergency");
            tabInfo.Add("emergency", aEmergency);

            if (tabInfo.Contains("wonyoi_order_yn"))
                tabInfo.Remove("wonyoi_order_yn");
            tabInfo.Add("wonyoi_order_yn", aWonyoiOrderYN);



            // 오더에 적용
            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                // 같은 그룹의 오더들은 변경해준다.
                // 복용코드
                // 날수
                // 긴급
                // 원외여부
                if (this.grdOrder.GetItemString(i, "group_ser") == tabInfo["group_ser"].ToString())
                {
                    // 접수하기 전의 오더만 가능
                    // 주사방법을 기준으로 변경 가능한것만 그룹정보 업데이트 한다.
                    if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                        this.mOrderMode == OrderVariables.OrderMode.CpSetOrder ||
                        this.mHangmogInfo.IsOrderDataChagnedEnabled(this.IOEGUBUN, this.grdOrder, i, "bogyong_code", OrderVariables.CheckMode.DataUpdate, OrderVariables.ErrorDisplayMode.NoDisplay))
                    {
                        // 복용코드
                        if (this.grdOrder.GetItemString(i, "bogyong_code") != aBogyongCode)
                        {
                            this.grdOrder.SetItemValue(i, "bogyong_code", aBogyongCode);
                        }

                        // 복용법 명칭
                        if (this.grdOrder.GetItemString(i, "bogyong_name") != aBogyongName)
                        {
                            this.grdOrder.SetItemValue(i, "bogyong_name", aBogyongName);
                        }

                        // DV
                        if (this.IsOutDrugGroup(tabInfo["group_ser"].ToString()) == false)
                        {
                            if (aDv != "" && this.grdOrder.GetItemString(i, "dv") != aDv)
                            {
                                this.grdOrder.SetItemValue(i, "dv", aDv);
                            }
                        }

                        // 날수
                        if (this.grdOrder.GetItemString(i, "nalsu") != nalsu)
                        {
                            this.grdOrder.SetItemValue(i, "nalsu", nalsu);
                        }

                        // 날수 셋팅에 따른 Nday YN 설정
                        if (this.IOEGUBUN == "O")
                        {

                            if (TypeCheck.IsInt(nalsu) && int.Parse(nalsu) > 1)
                            {
                                this.grdOrder.SetItemValue(i, "nday_yn", "Y");
                            }
                            else
                            {
                                this.grdOrder.SetItemValue(i, "nday_yn", "N");
                            }
                        }
                        // 긴급
                        if (this.grdOrder.GetItemString(i, "emergency") != aEmergency)
                        {
                            this.grdOrder.SetItemValue(i, "emergency", aEmergency);
                        }

                        // 원외여부
                        if (this.grdOrder.GetItemString(i, "wonyoi_order_yn") != aWonyoiOrderYN)
                        {
                            this.grdOrder.SetItemValue(i, "wonyoi_order_yn", aWonyoiOrderYN);
                        }

                        // 오더 리마크의 경우는 없는 경우만 넣어준다
                        if (this.grdOrder.GetItemString(i, "order_remark") == "")
                        {
                            this.grdOrder.SetItemValue(i, "order_remark", aOrderRemark);
                        }

                        // 돈복여부
                        if (this.grdOrder.GetItemString(i, "donbog_yn") != aDonbogYN)
                        {
                            this.grdOrder.SetItemValue(i, "donbog_yn", aDonbogYN);
                        }

                        // 돈복인 경우는 dv_time 을 전부 "*" 로 설정
                        if (aDonbogYN == "Y")
                        {
                            //if (this.grdOrder.GetItemValue(i, "dv_time").ToString() == "/")
                            //既に設定されている値があれば「1」に変更させない。
                            if (this.grdOrder.GetItemValue(i, "dv_time").ToString() == "/" && int.Parse(this.grdOrder.GetItemValue(i, "dv").ToString()) < 1)
                                this.grdOrder.SetItemValue(i, "dv", 1);
                            this.grdOrder.SetItemValue(i, "dv_time", "*");
                        }
                        else
                        {
                            //if (this.grdOrder.GetItemString(i, "order_gubun_bas") == "C")
                            //{
                            //    this.grdOrder.SetItemValue(i, "dv_time", "/");
                            //}
                            //else
                            //{
                            //    this.grdOrder.SetItemValue(i, "dv_time", "*");
                            //}
                            if (this.grdOrder.GetItemValue(i, "dv_time").ToString() != "@")
                            {
                                if (this.grdOrder.GetItemString(i, "order_gubun_bas") == "C")
                                {
                                    this.grdOrder.SetItemValue(i, "dv_time", "/");
                                }
                                else
                                {
                                    this.grdOrder.SetItemValue(i, "dv_time", "*");
                                }
                            }
                        }
                    }
                }
            }

            this.MakePreviewStatus();

            if (parentControl != null)
                parentControl.ChangWonyoi(aWonyoiOrderYN);
        }

        private void ApplyGroupInfoToRow(Hashtable aExistGroupInfo, int aSetRowNumber)
        {
            string bogyongCode = "";
            string bogyongName = "";
            string dv = "";
            string nalsu = "";
            string emergency = "N";
            string wonyoi_order_yn = "N";
            string donbog_yn = "N";

            if (aExistGroupInfo.Contains("bogyong_code"))
            {
                bogyongCode = aExistGroupInfo["bogyong_code"].ToString();
            }
            if (aExistGroupInfo.Contains("bogyong_name"))
            {
                bogyongName = aExistGroupInfo["bogyong_name"].ToString();
            }
            if (aExistGroupInfo.Contains("dv"))
            {
                dv = aExistGroupInfo["dv"].ToString();
            }
            if (aExistGroupInfo.Contains("nalsu"))
            {
                nalsu = aExistGroupInfo["nalsu"].ToString();
            }
            if (aExistGroupInfo.Contains("emergency"))
            {
                emergency = aExistGroupInfo["emergency"].ToString();
            }
            if (aExistGroupInfo.Contains("wonyoi_order_yn"))
            {
                wonyoi_order_yn = aExistGroupInfo["wonyoi_order_yn"].ToString();
            }
            if (aExistGroupInfo.Contains("donbog_yn"))
            {
                donbog_yn = aExistGroupInfo["donbog_yn"].ToString();
            }

            // 접수하기 전의 오더만 가능
            // 주사방법을 기준으로 변경 가능한것만 그룹정보 업데이트 한다.
            if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                this.mOrderMode == OrderVariables.OrderMode.CpSetOrder ||
                this.mHangmogInfo.IsOrderDataChagnedEnabled(this.IOEGUBUN, this.grdOrder, aSetRowNumber, "bogyong_code", OrderVariables.CheckMode.DataUpdate, OrderVariables.ErrorDisplayMode.NoDisplay))
            {
                // 복용코드
                if (this.grdOrder.GetItemString(aSetRowNumber, "bogyong_code") != bogyongCode)
                {
                    this.grdOrder.SetItemValue(aSetRowNumber, "bogyong_code", bogyongCode);
                }

                // 복용법 명칭
                if (this.grdOrder.GetItemString(aSetRowNumber, "bogyong_name") != bogyongName)
                {
                    this.grdOrder.SetItemValue(aSetRowNumber, "bogyong_name", bogyongName);
                }

                // DV
                if (this.IsOutDrugGroup(aExistGroupInfo["group_ser"].ToString()) == false)
                {
                    if (dv != "" && this.grdOrder.GetItemString(aSetRowNumber, "dv") != dv)
                    {
                        this.grdOrder.SetItemValue(aSetRowNumber, "dv", dv);
                    }
                }

                // 날수
                if (this.grdOrder.GetItemString(aSetRowNumber, "nalsu") != nalsu)
                {
                    this.grdOrder.SetItemValue(aSetRowNumber, "nalsu", nalsu);
                }

                // 날수 셋팅에 따른 Nday_YN 설정.
                if (this.IOEGUBUN == "O")
                {
                    if (TypeCheck.IsInt(nalsu) && int.Parse(nalsu) > 1)
                    {
                        this.grdOrder.SetItemValue(aSetRowNumber, "nday_yn", "Y");
                    }
                    else
                    {
                        this.grdOrder.SetItemValue(aSetRowNumber, "nday_yn", "N");
                    }
                }
                // 긴급
                if (this.grdOrder.GetItemString(aSetRowNumber, "emergency") != emergency)
                {
                    this.grdOrder.SetItemValue(aSetRowNumber, "emergency", emergency);
                }

                // 원외여부
                if (this.grdOrder.GetItemString(aSetRowNumber, "wonyoi_order_yn") != wonyoi_order_yn)
                {
                    this.grdOrder.SetItemValue(aSetRowNumber, "wonyoi_order_yn", wonyoi_order_yn);
                }

                // 돈복여부
                if (this.grdOrder.GetItemString(aSetRowNumber, "donbog_yn") != donbog_yn)
                {
                    this.grdOrder.SetItemValue(aSetRowNumber, "donbog_yn", donbog_yn);
                }
            }

            this.MakePreviewStatus();
        }

        /// <summary>
        /// 그룹탭 선택시 그룹관련 정보들 셋팅
        /// </summary>
        /// <param name="aGroupInfo">그룹정보</param>
        private void SetGroupControl(Hashtable aGroupInfo)
        {
            // 복용코드
            this.fbxBogyongCode.SetDataValue(aGroupInfo["bogyong_code"].ToString());
            // 복용명칭
            this.dbxBogyongName.SetDataValue(aGroupInfo["bogyong_name"].ToString());
            // 날수
            this.cboNalsu.SetDataValue(aGroupInfo["nalsu"].ToString());
            this.cbxEmergency.CheckedChanged -= new EventHandler(cbxEmergency_CheckedChanged);
            // 긴급여부
            this.cbxEmergency.SetDataValue(aGroupInfo["emergency"].ToString());
            this.cbxEmergency.CheckedChanged += new EventHandler(cbxEmergency_CheckedChanged);
            this.cbxWonyoiOrderYN.CheckedChanged -= new EventHandler(cbxWonyoiOrderYN_CheckedChanged);
            // 원외오더
            this.cbxWonyoiOrderYN.SetDataValue(aGroupInfo["wonyoi_order_yn"].ToString());
            this.cbxWonyoiOrderYN.CheckedChanged += new EventHandler(cbxWonyoiOrderYN_CheckedChanged);
        }

        /// <summary>
        /// 그룹정보 프로텍트 여부 
        /// </summary>
        /// <param name="aGroupSer">그룹시리얼</param>
        private void ProtectGroupControl(string aGroupSer)
        {
            DataRow[] dr = this.grdOrder.LayoutTable.Select("group_ser=" + aGroupSer);
            bool isProtect = false;

            for (int i = 0; i < dr.Length; i++)
            {
                if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                    this.mOrderMode == OrderVariables.OrderMode.CpSetOrder)
                {
                    isProtect = false;
                    break;
                }

                if (UserInfo.Gwa == "CK")
                {
                    if ((dr[i]["input_gubun"].ToString().Substring(0, 1) == "D" && dr[i]["instead_yn"].ToString() == "N")
                        || (dr[i]["input_gubun"].ToString().Substring(0, 1) == "D" && dr[i]["instead_yn"].ToString() == "Y" && dr[i]["approve_yn"].ToString() == "Y"))
                    {
                        isProtect = true;
                    }
                }
                else if (UserInfo.Gwa != "CK" && UserInfo.UserGubun != UserType.Doctor)
                {
                    if (dr[i]["input_gubun"].ToString().Substring(0, 1) == "D")
                    {
                        isProtect = true;
                    }
                }

                //if (dr[i].RowState != DataRowState.Added && dr[i]["ocs_flag"].ToString() != "0" && dr[i]["ocs_flag"].ToString() != "1")
                if (dr[i].RowState != DataRowState.Added && (dr[i]["ocs_flag"].ToString() != "0" && dr[i]["ocs_flag"].ToString() != "1" || dr[i]["sunab_yn"].ToString() == "Y"))
                {
                    isProtect = true;
                    break;
                }
            }

            foreach (Control ctrl in this.pnlOrderDetail.Controls)
            {
                if (ctrl is IDataControl)
                {
                    ((IDataControl)ctrl).Protect = isProtect;
                }
            }
        }

        private bool IsExistDifferentGroupInfo(MultiLayout aLayout)
        {
            foreach (DataRow dr in aLayout.LayoutTable.Rows)
            {
                if (this.IsSameCurrentGroupInfo(dr["bogyong_code"].ToString(), dr["nalsu"].ToString(), dr["emergency"].ToString(), dr["wonyoi_order_yn"].ToString()) == false)
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsSameCurrentGroupInfo(string aBogyongCode, string aNalsu, string aEmergency, string aWonyoiOrderYn)
        {
            Hashtable tabInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            //if (tabInfo["bogyong_code"].ToString() == "")
            //{
            //    //if (this.mOrderFunc.IsEmptyGroup(this.grdOrder, tabInfo["group_ser"].ToString()))
            //    //{

            //    //    return true;
            //    //}

            //    if (tabInfo["nalsu"].ToString() != TypeCheck.NVL(aNalsu, tabInfo["nalsu"].ToString()).ToString() ||
            //        tabInfo["emergency"].ToString() != TypeCheck.NVL(aEmergency, tabInfo["emergency"].ToString()).ToString() ||
            //        tabInfo["wonyoi_order_yn"].ToString() != TypeCheck.NVL(aWonyoiOrderYn, tabInfo["wonyoi_order_yn"].ToString()).ToString())
            //    {
            //        return false;
            //    }
            //    else
            //    {
            //        return true;
            //    }
            //}

            if (tabInfo["bogyong_code"].ToString() != TypeCheck.NVL(aBogyongCode, tabInfo["bogyong_code"].ToString()).ToString() ||
                tabInfo["nalsu"].ToString() != TypeCheck.NVL(aNalsu, tabInfo["nalsu"].ToString()).ToString() ||
                tabInfo["emergency"].ToString() != TypeCheck.NVL(aEmergency, tabInfo["emergency"].ToString()).ToString() ||
                tabInfo["wonyoi_order_yn"].ToString() != TypeCheck.NVL(aWonyoiOrderYn, tabInfo["wonyoi_order_yn"].ToString()).ToString())
            {
                return false;
            }

            return true;
        }

        private bool DeleteCurrentGroupTab(IHIS.X.Magic.Controls.TabPage aDestTabPage)
        {
            Hashtable groupInfo;

            if (MessageBox.Show(XMsg.GetMsg("M011"), XMsg.GetField("F002"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return false;

            if (aDestTabPage == null) return false;

            // 현재 오더 테이블에서 empty row 는 삭제 
            this.mOrderFunc.DeleteEmptyNewRow(this.grdOrder);

            // 현재 탭의 오더가 전부 삭제 가능한지 확인한다.
            bool isExistActingOrder = false;
            ArrayList deletRows = new ArrayList();
            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                if (this.grdOrder.IsVisibleRow(i))
                {
                    if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                        this.mOrderMode == OrderVariables.OrderMode.CpSetOrder ||
                        this.mHangmogInfo.IsOrderDataChagnedEnabled(IOEGUBUN, this.grdOrder, i, "", OrderVariables.CheckMode.RowDelete, OrderVariables.ErrorDisplayMode.MessageBox))
                    {
                        deletRows.Add(i);
                    }
                    else
                    {
                        isExistActingOrder = true;
                        break;
                    }
                }
            }

            if (isExistActingOrder == true)
            {
                return false; ;
            }

            for (int j = 0; j < deletRows.Count; j++)
            {
                this.grdOrder.DeleteRow(((int)deletRows[j]) - j);
            }

            if (this.tabGroup.SelectedTab == null)
            {
                return false;
            }

            groupInfo = aDestTabPage.Tag as Hashtable;

            // 오더가 있는경우와 없는경우로 나눈다.
            // 오더가 있는경우는 삭제 불가
            // 오더가 없는 경우만 삭제가 가능하다
            if (this.grdOrder.LayoutTable.Select("group_ser=" + groupInfo["group_ser"].ToString()).Length <= 0)
            {
                this.tabGroup.TabPages.Remove(aDestTabPage);

            }
            else
            {
                MessageBox.Show(XMsg.GetMsg("M012"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        private void DisplayOrderGridGroupInfo(Hashtable aGroupInfo)
        {
            // 오더그리드의 오더항목 visible setting 
            this.mOrderFunc.SetGridRowVisibleByGroupSer(this.grdOrder, aGroupInfo["group_ser"].ToString(), this.mInputGubun);
            //this.mOrderFunc.SetGridRowVisibleByGroupSer(this.grdOrder, (Hashtable)this.tabGroup.SelectedTab.Tag, this.mInputGubun);

            // 그룹항목셋팅
            this.SetGroupControl(aGroupInfo);

            // 외용 내복에 따른 그룹항목 visible Setting 
            this.SetGroupControlVisible(aGroupInfo["group_ser"].ToString());

            // 그룹항목에 대하여 프로텍트 여부 
            this.ProtectGroupControl(aGroupInfo["group_ser"].ToString());

            // dc 구분관련 보일것인가 말것인가..
            this.ShowDcGubun(this.grdOrder, (aGroupInfo["group_ser"].ToString()));
        }

        private void LoadOftenUseOrder(string aMembGubun, string aMemb, string aOrderGubun, string aWonnaeDrgYn, string aSearchWord)
        {
            this.grdSangyongOrder.Reset();
            this.grdSangyongOrder.QueryLayout(true);
            //insert by jc [検索条件追加] 2012/10/15
            //DataTable dtSangyongData = this.mOrderBiz.LoadOftenUsedInfo(aMembGubun, aMemb, aOrderGubun, aWonnaeDrgYn, TypeCheck.NVL(aSearchWord, "%").ToString(), this.cboSearchCondition.SelectedValue.ToString());

            //if (dtSangyongData != null && dtSangyongData.Rows.Count > 0)
            //{
            //    this.grdSangyongOrder.ImportRowRange(dtSangyongData, 0);
            //    this.grdSangyongOrder.ResetUpdate();
            //    this.grdSangyongOrder.DisplayData();
            //}
        }

        //        private string GetMainGwaDoctorCode(string mMemb)
        //        {
        //            string cmd = @"SELECT A.DOCTOR
        //                             FROM BAS0270 A
        //                            WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + @"'
        //                              AND A.SABUN = :f_memb
        //                              AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND NVL(A.END_DATE,TO_DATE('99981231', 'YYYYMMDD'))
        //                              AND NVL(A.MAIN_GWA_YN, 'N') = 'Y'
        //                              AND A.ROWNUM = 1
        //                            ORDER BY A.DOCTOR ";

        //            BindVarCollection binVar = new BindVarCollection();
        //            binVar.Add("f_memb", mMemb);

        //            object val = Service.ExecuteScalar(cmd, binVar);

        //            if (TypeCheck.IsNull(val))
        //            {
        //                return mMemb;
        //            }
        //            else
        //            {
        //                return val.ToString();
        //            }
        //        }

        private void MakeSangyongTab(string aMemb, string aInputTab)
        {
            //DataTable sangyongTab = this.mOrderBiz.LoadOftenUsedTabInfo(aMemb, aInputTab);
            Hashtable tabInfo;

            this.tabSangyongOrder.SelectionChanged -= new EventHandler(tabSangyongOrder_SelectionChanged);

            try
            {
                this.tabSangyongOrder.TabPages.Clear();
            }
            catch
            {
                this.tabSangyongOrder.Refresh();
            }

            IHIS.X.Magic.Controls.TabPage tpg;

            // Cloud updated code START
            foreach (LoadOftenUsedTabResponseInfo item in _formResult.UsedTabResponseInfo)
            {
                tpg = new IHIS.X.Magic.Controls.TabPage();
                tpg.Title = item.OrderGubunName;
                tpg.ImageList = this.ImageList;
                tpg.ImageIndex = 1;

                tabInfo = new Hashtable();
                tabInfo.Add("order_gubun", item.OrderGubun);
                tabInfo.Add("memb", item.Memb);
                tpg.Tag = tabInfo;

                this.tabSangyongOrder.TabPages.Add(tpg);
            }

            //for (int i = 0; i < sangyongTab.Rows.Count; i++)
            //{
            //    tpg = new IHIS.X.Magic.Controls.TabPage();
            //    tpg.Title = sangyongTab.Rows[i]["order_gubun_name"].ToString();
            //    tpg.ImageList = this.ImageList;
            //    tpg.ImageIndex = 1;

            //    tabInfo = new Hashtable();
            //    tabInfo.Add("order_gubun", sangyongTab.Rows[i]["order_gubun"].ToString());
            //    tabInfo.Add("memb", sangyongTab.Rows[i]["memb"].ToString());
            //    tpg.Tag = tabInfo;

            //    this.tabSangyongOrder.TabPages.Add(tpg);
            //}

            // Cloud updated code END

            this.tabSangyongOrder.SelectionChanged += new EventHandler(tabSangyongOrder_SelectionChanged);

            this.tabSangyongOrder_SelectionChanged(this.tabSangyongOrder, new EventArgs());
        }

        private void LoadSearchOrderInfo(string aSearchWord, string aGijunDate, string aInputTab, string aWonnaeDrgYn)
        {
            if (aSearchWord == "") return; // 검색어가 없으면 검색 안함. 

            this.grdSearchOrder.Reset();
            //inser by jc [検索条件追加] 2012/10/15
            //DataTable dtSearchResult = this.mOrderBiz.LoadSearchOrderInfo(aSearchWord, aGijunDate, aInputTab, aWonnaeDrgYn, this.rbtRandom.Checked);
            //modify by jc [一般名で検索機能追加] 2012/11/01
            //string pageNumber = "1";
            //DataTable dtSearchResult = this.mOrderBiz.LoadSearchOrderInfoDRG(protocolId, aSearchWord, aGijunDate, aInputTab, aWonnaeDrgYn, this.cboSearchCondition.SelectedValue.ToString(), mGenericSearchYN, pageNumber,"200");

            //if (dtSearchResult != null && dtSearchResult.Rows.Count > 0)
            //{
            //    this.grdSearchOrder.ImportRowRange(dtSearchResult, 0);
            //    this.grdSearchOrder.DisplayData();
            //    this.grdSearchOrder.ResetUpdate();
            //}
            //else
            //    this.grdGeneral.Reset();
            
            this.grdSearchOrder.SetBindVarValue("f_search_word", aSearchWord);
            this.grdSearchOrder.SetBindVarValue("f_gijundate", aGijunDate);
            this.grdSearchOrder.SetBindVarValue("f_input_tab", aInputTab);
            this.grdSearchOrder.SetBindVarValue("f_wonnae_drugyn", aWonnaeDrgYn);
            this.grdSearchOrder.SetBindVarValue("f_search_condition", this.cboSearchCondition.SelectedValue.ToString());
            this.grdSearchOrder.SetBindVarValue("f_generic_searchyn", mGenericSearchYN);
            this.grdSearchOrder.ExecuteQuery = ExecuteLoadSearchOrderInfo;
            this.grdSearchOrder.QueryLayout(false);
        }
        #region ExecuteLoadSearchOrderInfo
        private IList<object[]> ExecuteLoadSearchOrderInfo(BindVarCollection bc)
        {
            IList<object[]> lObj = new List<object[]>();

            OBLoadSearchOrderInfoDRGArgs args = new OBLoadSearchOrderInfoDRGArgs();
            args.ProtocolId = protocolId;
            args.GenericSearchYn = bc["f_generic_searchyn"] != null ? bc["f_generic_searchyn"].VarValue : "";
            args.GijunDate = bc["f_gijundate"] != null ? bc["f_gijundate"].VarValue : "";
            args.InputTab = bc["f_input_tab"] != null ? bc["f_input_tab"].VarValue : "";
            args.SearchCondition = bc["f_search_condition"] != null ? bc["f_search_condition"].VarValue : "";
            args.SearchWord = bc["f_search_word"] != null ? bc["f_search_word"].VarValue : "";
            args.WonnaeDrgYn = bc["f_wonnae_drugyn"] != null ? bc["f_wonnae_drugyn"].VarValue : "";
            args.PageNumber = bc["f_page_number"] != null ? bc["f_page_number"].VarValue : "";
            args.OffSet = "200";
            OBLoadSearchOrderInfoDRGResult res = CloudService.Instance.Submit<OBLoadSearchOrderInfoDRGResult,
                OBLoadSearchOrderInfoDRGArgs>(args, true);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {

                foreach (OBLoadSearchOrderInfoDRGInfo itemInfo in res.SearchOrderDrgItem)
                {
                    object[] objects = 
			        { 
			            itemInfo.SlipCode, 
				        itemInfo.SlipName, 
				        itemInfo.HangmogCode, 
				        itemInfo.HangmogName, 
				        itemInfo.WonnaeDrgYn, 
                        itemInfo.GenericName,
                        null,
                        itemInfo.GenericCodeOrg,
                        itemInfo.GenericCodeOrgSubstr,
				        itemInfo.YakKijunCode,
                        null,
                        itemInfo.TrialFlg,
			        };
                    lObj.Add(objects);
                }
                
            }

            return lObj;
        }
        #endregion
        //TreeNode currNode;

        /*//Old code //MED-8893
        private void MakeDrugOrder()
        {
            // 분류 데이터 로드 
            this.LoadDrgBunryu();

            this.tvwDrgBunryu.AfterSelect -= new TreeViewEventHandler(tvwDrgBunryu_AfterSelect);

            this.tvwDrgBunryu.Nodes.Clear();

            TreeNode parentNode = new TreeNode();
            TreeNode childNode;

            string currentParent = "";

            foreach (DataRow dr in this.layDrugTree.LayoutTable.Rows)
            {
                if (currentParent != dr["code"].ToString())
                {
                    if (currentParent != "")
                    {
                        this.tvwDrgBunryu.Nodes.Add(parentNode);
                    }

                    parentNode = new TreeNode(dr["code_name"].ToString(), 5, 6);
                    parentNode.Tag = dr["code"].ToString();

                    childNode = new TreeNode(dr["code_name1"].ToString(), 1, 0);
                    childNode.Tag = dr["code1"].ToString();

                    parentNode.Nodes.Add(childNode);

                    currentParent = dr["code"].ToString();
                }
                else
                {
                    childNode = new TreeNode(dr["code_name1"].ToString(), 1, 0);
                    childNode.Tag = dr["code1"].ToString();

                    parentNode.Nodes.Add(childNode);
                }
            }

            this.tvwDrgBunryu.AfterSelect += new TreeViewEventHandler(tvwDrgBunryu_AfterSelect);

        }*/

        private void MakeDrugOrder()
        {
            try
            {
                // 분류 데이터 로드 
                this.LoadDrgBunryu();

                this.tvwDrgBunryu.AfterSelect -= new TreeViewEventHandler(tvwDrgBunryu_AfterSelect);

                this.tvwDrgBunryu.Nodes.Clear();

                TreeNode parentNode = new TreeNode();
                TreeNode childNode;

                string currentParent = "";

                foreach (DataRow dr in this.layDrugTree.LayoutTable.Rows)
                {
                    if (currentParent != dr["code"].ToString())
                    {
                        //MED-8893
                        if (dr["code"].ToString() != "")
                        {
                            parentNode = new TreeNode(dr["code_name"].ToString(), 5, 6);
                            parentNode.Tag = dr["code"].ToString();

                            childNode = new TreeNode(dr["code_name1"].ToString(), 1, 0);
                            childNode.Tag = dr["code1"].ToString();

                            parentNode.Nodes.Add(childNode);

                            this.tvwDrgBunryu.Nodes.Add(parentNode);
        }

                        currentParent = dr["code"].ToString();
                    }
                    else
                    {
                        childNode = new TreeNode(dr["code_name1"].ToString(), 1, 0);
                        childNode.Tag = dr["code1"].ToString();

                        parentNode.Nodes.Add(childNode);
                    }
                }

                this.tvwDrgBunryu.AfterSelect += new TreeViewEventHandler(tvwDrgBunryu_AfterSelect);
            }
            catch (Exception ex)
            {
                Service.WriteLog("Exception on method MakeDrugOrder(): " + ex.StackTrace);
            }
        }

        private void LoadDrgBunryu()
        {
            this.layDrugTree.QueryLayout(true);
        }

        private void LoadDrgOrder(string aMode, string aCode1, string aWonnaeDrgYn, string aSearchWord)
        {
            string searchword = "";
            //string cmd = " SELECT FN_ADM_CONVERT_KATAKANA_FULL('" + aSearchWord + "' ) " +
            //             "   FROM SYS.DUAL ";

            if (aSearchWord != "%" && aSearchWord != "")
            {
                //object returnVal = Service.ExecuteScalar(cmd);
                if (NetInfo.Language == LangMode.Jr)
                {
                    searchword = GetSearchWordForSpecimen(aSearchWord);
                }
                else
                {
                    searchword = aSearchWord;
                }

                //if (returnVal != null && returnVal.ToString() != "")
                //{
                //    searchword = returnVal.ToString();
                //}
                //insert by jc [検索条件追加] 2012/10/15
                switch (this.cboSearchCondition.SelectedValue.ToString())
                {
                    case "01": //部分一致
                        searchword = "%" + searchword + "%";
                        break;
                    case "02": //前方一致
                        searchword = searchword + "%";
                        break;
                    case "03": //後方一致
                        searchword = "%" + searchword;
                        break;
                    case "04": //完全一致
                        //searchword = searchword;
                        break;
                    default:
                        searchword = "%" + searchword + "%";
                        break;


                }
                //if (this.cbxSentou.Checked == false)
                //    searchword = "%" + searchword + "%";
                //else
                //    searchword = searchword + "%";
            }
            else if (aSearchWord == "")
            {
                searchword = "%";
            }
            this.grdDrgOrder.SetBindVarValue("f_mode", aMode);
            this.grdDrgOrder.SetBindVarValue("f_code1", aCode1);
            this.grdDrgOrder.SetBindVarValue("f_wonnae_drg_yn", aWonnaeDrgYn);
            this.grdDrgOrder.SetBindVarValue("f_search_word", TypeCheck.NVL(searchword, "%").ToString());

            if (this.mOrderMode == OrderVariables.OrderMode.InpOrder || this.mOrderMode == OrderVariables.OrderMode.OutOrder)
                this.grdDrgOrder.SetBindVarValue("f_order_date", mOrderDate);
            else
                this.grdDrgOrder.SetBindVarValue("f_order_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));

            this.grdDrgOrder.QueryLayout(false);
        }

        private void OPEN_DRG0208Q00()
        {
            if (this.tabGroup.SelectedTab == null) return;

            Hashtable tabInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            if (this.mOrderFunc.IsEmptyGroup(this.grdOrder, tabInfo["group_ser"].ToString()))
            {
                MessageBox.Show(XMsg.GetMsg("M010"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IsOutDrugGroup(tabInfo["group_ser"].ToString()))
                this.OpenScreen_OCS0208Q01("", this.fbxBogyongCode.GetDataValue(), "");
            else
                this.OpenScreen_OCS0208Q00();
        }

        private string GetMixGroup(XEditGrid grd)
        {
            int mix = -999;

            for (int i = 0; i < grd.RowCount; i++)
            {
                if (grd.GetItemString(i, "mix_group") != "")
                {
                    if (grd.GetItemInt(i, "mix_group") > mix)
                    {
                        mix = grd.GetItemInt(i, "mix_group");
                    }
                }
            }

            if (mix == -999) return "1";
            else return (mix + 1).ToString();
        }

        private void SetConvertMixInfo(MultiLayout aLay, string aMix, string aCnvMix)
        {
            for (int i = 0; i < aLay.RowCount; i++)
            {
                if (aLay.GetItemString(i, "org_mix") == aMix)
                {
                    aLay.SetItemValue(i, "cnv_mix", aCnvMix);
                }
            }
        }

        private string GetConvertMixInfo(MultiLayout aLay, string aMix)
        {
            for (int i = 0; i < aLay.RowCount; i++)
            {
                if (aLay.GetItemString(i, "org_mix") == aMix)
                {
                    return aLay.GetItemString(i, "cnv_mix");
                }
            }

            return "";
        }

        private void InitStatusBar(int aMaxValue)
        {
            this.pgbProgress.Minimum = 0;
            this.pgbProgress.Maximum = aMaxValue;

            this.lbStatus.Text = "";
        }

        private void SetVisibleStatusBar(bool aIsVisible)
        {
            this.pnlStatus.Visible = aIsVisible;
        }

        private void SetStatusBar(int aCurrentValue)
        {
            this.pgbProgress.Value = aCurrentValue;
            this.pgbProgress.Refresh();

            this.lbStatus.Text = aCurrentValue.ToString() + "/" + this.pgbProgress.Maximum.ToString();
            this.lbStatus.Refresh();
        }

        private bool IsSelectedRowForNalsu()
        {
            int selectRow = 0;
            if (this.grdOrder.RowCount > 0)
            {
                for (int i = 0; i < this.grdOrder.RowCount; i++)
                {
                    if (this.grdOrder.IsSelectedRow(i))
                    {
                        if (this.grdOrder.GetItemString(i, "jundal_part") == "HOM")
                        {
                            MessageBox.Show(Resources.XMsg_000005, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        else
                        {
                            selectRow++;
                            return true;
                        }
                    }
                }

                if (selectRow <= 0)
                {
                    XMessageBox.Show(Resources.XMsg_000006, Resources.XMsg_000002);
                    this.cboNalsu.SetDataValue("1");
                    return false;
                }
            }
            return true;
        }

        private bool IsSelectedDiffHopeDate()
        {
            ArrayList hopeDateList = new ArrayList();
            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                if (this.grdOrder.IsSelectedRow(i))
                {
                    hopeDateList.Add(this.grdOrder.GetItemString(i, "hope_date"));
                }
            }

            for (int j = 0; j < hopeDateList.Count; j++)
            {
                for (int k = j; k < hopeDateList.Count; k++)
                {
                    if (hopeDateList[j].ToString() != hopeDateList[k].ToString())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void PostNalsuValidating()
        {
            // 에러로 취소시 날수는 1로 원상복귀
            this.cboNalsu.SetEditValue("1");
            this.cboNalsu.AcceptData();
        }

        private void PostRadioCheckedChanged()
        {
            this.txtSearch.Focus();
        }

        private void PostTabSelection(int aRowNumber)
        {
            this.grdOrder.SetFocusToItem(aRowNumber, "hangmog_code", false);

        }

        // 同一グループ属性を持っているグループを一つに纏める。
        private void CheckSameGroup_info()
        {
            for (int i = 0; i < this.tabGroup.TabPages.Count; i++)
            {
                for (int ii = 0; ii < this.tabGroup.TabPages.Count; ii++)
                {
                    string group_name = ((Hashtable)this.tabGroup.TabPages[ii].Tag)["group_ser"].ToString();
                    if (i == ii) continue;

                    if (
                        ((Hashtable)this.tabGroup.TabPages[i].Tag)["bogyong_code"].ToString() == ((Hashtable)this.tabGroup.TabPages[ii].Tag)["bogyong_code"].ToString()
                        && ((Hashtable)this.tabGroup.TabPages[i].Tag)["nalsu"].ToString() == ((Hashtable)this.tabGroup.TabPages[ii].Tag)["nalsu"].ToString()
                        && ((Hashtable)this.tabGroup.TabPages[i].Tag)["emergency"].ToString() == ((Hashtable)this.tabGroup.TabPages[ii].Tag)["emergency"].ToString()
                        && ((Hashtable)this.tabGroup.TabPages[i].Tag)["wonyoi_order_yn"].ToString() == ((Hashtable)this.tabGroup.TabPages[ii].Tag)["wonyoi_order_yn"].ToString()
                        && ((Hashtable)this.tabGroup.TabPages[i].Tag)["dv"].ToString() == ((Hashtable)this.tabGroup.TabPages[ii].Tag)["dv"].ToString()
                        )
                    {
                        if (XMessageBox.Show("【" + group_name + Resources.XMsg_000007 + group_name + Resources.XMsg_000008, Resources.XMsg_000009, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            for (int t = 0; t < this.grdOrder.RowCount; t++)
                            {
                                if (this.grdOrder.GetItemString(t, "group_ser") == ((Hashtable)this.tabGroup.TabPages[ii].Tag)["group_ser"].ToString())
                                {
                                    this.grdOrder.SetItemValue(t, "group_ser", ((Hashtable)this.tabGroup.TabPages[i].Tag)["group_ser"].ToString());
                                }
                            }
                            this.tabGroup.TabPages.RemoveAt(ii);
                            i = 0;
                            ii = 0;
                        }
                    }
                }
            }
        }

        private void ChangeInputGubun()
        {
            XEditGrid grd = this.grdOrder;
            string changeInputGubunName = "";
            this.mOrderBiz.LoadColumnCodeName("code", "INPUT_GUBUN", this.cboInputGubun.SelectedValue.ToString(), ref changeInputGubunName);
            for (int i = 0; i < grd.RowCount; i++)
            {
                if (grd.IsVisibleRow(i) == true)
                {
                    if (grd.GetItemString(i, "input_gubun") != this.cboInputGubun.SelectedValue.ToString()
                        && this.mHangmogInfo.IsOrderDataChagnedEnabled(IOEGUBUN, grd, i, "input_gubun", OrderVariables.CheckMode.Protected, OrderVariables.ErrorDisplayMode.MessageBox)

                        )
                    {
                        grd.SetItemValue(i, "input_gubun", this.cboInputGubun.SelectedValue.ToString());
                        grd.SetItemValue(i, "input_gubun_name", changeInputGubunName);
                    }
                }
            }

        }

        private void PostBogyongCodeValidating()
        {
            this.cboNalsu.Focus();
        }

        //-> LIB
        //private bool MergeToSaveLayout()
        //{
        //    this.laySaveLayout.Reset();

        //    // 내복약오더
        //    foreach (DataRow dr in this.grdOrder.LayoutTable.Rows)
        //    {
        //        this.laySaveLayout.LayoutTable.ImportRow(dr);
        //    }

        //    if (this.grdOrder.DeletedRowCount > 0 && this.grdOrder.DeletedRowTable != null)
        //    {
        //        // 삭제된 로우를 셋팅한다.
        //        for (int i = 0; i < this.grdOrder.DeletedRowTable.Rows.Count; i++)
        //        {
        //            if (layDeletedData.LayoutTable.Select("pkocskey=" + this.grdOrder.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

        //            this.layDeletedData.LayoutTable.ImportRow(this.grdOrder.DeletedRowTable.Rows[i]);
        //            this.layDeletedData.SetItemValue(i, "dummy", "Y");
        //        }
        //    }
        //    return true;
        //}
        private void PostCallAfterInsertRow(string aFocusColumn)
        {
            this.grdOrder.Focus();
            this.grdOrder.SetFocusToItem(this.grdOrder.CurrentRowNumber, aFocusColumn, true);
        }

        private void PostCallAfterDeleteRow(int aRowNumber)
        {
            this.grdOrder.Focus();
            this.grdOrder.SetFocusToItem(aRowNumber, "hangmog_code", false);
            this.grdOrder.UnSelectAll();
        }

        private void PostValidationColumn(object aValidInfo)
        {
            Hashtable info = aValidInfo as Hashtable;


        }

        private void PostOrderInsert()
        {
            int focusRow = -1;
            if (this.mFocusRow < 0)
                focusRow = this.grdOrder.RowCount - 1;
            else
                focusRow = mFocusRow;

            this.MakePreviewStatus();
            //this.grdOrder.SetFocusToItem(mFocusRow, "suryang", false);
        }

        private void PostOrderInsert(int aFocusRow)
        {
            int focusRow = -1;
            if (aFocusRow < 0)
                focusRow = this.grdOrder.RowCount - 1;
            else
                focusRow = aFocusRow;

            if (focusRow < 0) return;

            this.MakePreviewStatus();

            //this.grdOrder.SetFocusToItem(focusRow, "hangmog_code", false);
            this.grdOrder.SetFocusToItem(focusRow, "suryang", true);

            //insert by jc [オーダ登録時自動的に選択されるように（施行済み、希望日設定済みオーダは例外とする）]
            //for (int i = 0; i < this.grdOrder.RowCount; i++)
            //{
            //    if (this.grdOrder.GetItemString(i, "hope_date") == "" && this.grdOrder.GetItemString(i, "ocs_flag") != "3")
            //    {
            //        this.grdOrder.SelectRow(i);
            //    }
            //}
        }

        private void MakePreviewStatus()
        {
            if (mOrderBiz != null && this.pnlPreview.Visible == true)
            {
                this.layPreview.Reset();

                //modify by jc 2012/02/17 [既存ではINPUTGUBUNの値がなければOrderBizでデフォルト値としてD0を入れていたので
                //D0以外はPREVIEWのGRIDでオーダが見えなかったのでINPUTGUBNをパラメターとして入力してINPUTGUBUN別にPREVIEWが見えるように修正]
                //this.mOrderBiz.SetPreviewOrderData(INPUTTAB, this.grdOrder, this.layPreview);
                this.mOrderBiz.SetPreviewOrderData(this.IOEGUBUN, this.mInputGubun, INPUTTAB, this.grdOrder, this.layPreview);

                this.grdPreview.Reset();
                foreach (DataRow dr in this.layPreview.LayoutTable.Rows)
                {
                    this.grdPreview.LayoutTable.ImportRow(dr);
                }
                this.grdPreview.DisplayData();

                this.pnlPreview.Visible = true;
            }
        }

        private void setTabReset()
        {
            this.tabpageY4.Title = Resources.XMsg_000010;
            this.tabpageT7.Title = Resources.XMsg_000011;
            this.tabpageZ8.Title = Resources.XMsg_000012;
            this.tabpageK9.Title = Resources.XMsg_000014;
            this.tabpageY4.TitleTextColor = Color.Black;
            this.tabpageT7.TitleTextColor = Color.Black;
            this.tabpageZ8.TitleTextColor = Color.Black;
            this.tabpageK9.TitleTextColor = Color.Black;
        }

        private void SetOrderImage(XEditGrid aGrid)
        {

            for (int i = 0; i < aGrid.RowCount; i++)
            {
                if (aGrid.GetItemString(i, "general_disp_yn") == "Y")
                {
                    //aGrid[i + aGrid.HeaderHeights.Count, 0].ToolTipText = "医師オーダ" + aGrid[i + aGrid.HeaderHeights.Count, 0].ToolTipText;
                    aGrid[i, "hangmog_name"].ToolTipText = Resources.XMsg_000015 + mHangmogInfo.GetHangmogName(aGrid.GetItemString(i, "hangmog_code"));
                }
            }

            // 의사가 입력하는 경우는 스킵
            if (this.mInputGubun.Substring(0, 1) == "D") return;

            for (int i = 0; i < aGrid.RowCount; i++)
            {
                // 의사 오더인경우
                if (aGrid.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                {
                    aGrid[i + aGrid.HeaderHeights.Count, 0].Image = this.ImageList.Images[8];
                    aGrid[i + aGrid.HeaderHeights.Count, 0].ToolTipText = Resources.XMsg_000016 + aGrid[i + aGrid.HeaderHeights.Count, 0].ToolTipText;
                }

            }
        }

        private void PostSearchValidating()
        {
            bool isFocusToTextBox = false;

            if (this.rbnSearchOrder.Checked)
            {
                if (this.grdSearchOrder.RowCount <= 0)
                    isFocusToTextBox = true;
            }
            else if (this.rbnOftenOrder.Checked)
            {
                if (this.grdSangyongOrder.RowCount <= 0)
                    isFocusToTextBox = true;
            }
            else if (this.rbnDrgOrder.Checked)
            {
                if (this.grdDrgOrder.RowCount <= 0)
                    isFocusToTextBox = true;
            }

            if (isFocusToTextBox)
            {
                this.txtSearch.Focus();
                this.txtSearch.SelectAll();
            }
            else
            {
                this.txtSearch.Focus();
                //this.txtSearch.SetDataValue("");
            }
        }

        #region Current code
        /*private void SelectGroupTab(string aGroupSer)
        {
            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroup.TabPages)
            {
                if (((Hashtable)tpg.Tag)["group_ser"].ToString() == aGroupSer)
                {
                    this.tabGroup.SelectedTab = tpg;
                    return;
                }
            }
        }*/
        #endregion

        private void SelectGroupTab(string aGroupSer)
        {
            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroup.TabPages)
            {
                if (((Hashtable)tpg.Tag)["group_ser"].ToString() == aGroupSer)
                {
                    this.tabGroup.SelectedTab = tpg;

                    #region New code check to cbxWonyoiOrderYN
                    DataTable dt = (DataTable)grdOrder.LayoutTable;
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dt.DefaultView.RowFilter = "group_ser = '" + aGroupSer + "'";
                        dt = dt.DefaultView.ToTable();
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["wonyoi_order_yn"].ToString() == "Y")
                            {
                                cbxWonyoiOrderYN.Checked = true;
                            }
                            else
                            {
                                cbxWonyoiOrderYN.Checked = false;
                            }
                        }
                    } 
                    #endregion

                    return;
                }
            }
        }


        public void ActionSelectGroupTab()
        {
            if (mCurrentRowNum > 0)
            {
                //[OCS1003P01のデータウインドウで選択されたgroup_ser取得]
                string currentGroupSer = this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "group_ser_num");
                this.SelectGroupTab(currentGroupSer);
            }
        }

        private void setFocusGotoColumn()
        {
            //insert by jc [OCS1003P01のデータウインドーウで選択されたROWがあった場合の処理]
            //位置検索はすべてhangmog_codeで検索する
            //不均等オーダ、コメントのROWにもOrderBizで該当するHangmog_codeを入れているので検索可能である。
            //カーソルのコントロールの際にはgrdOrder, grdPreviewのグリドを同時に動かす。
            //pkocskeyは使えない。なぜかというとpkocskeyは保存される際、トリガーによって与えられるので保存されてない状態では使えないのだ
            //bogyong_code_ynは服用コードであるROWだけがYである。OrderBizで設定。

            int currentRow = -1;
            int currentPreviewRow = -1;
            if (mCurrentRowNum > 0)
            {
                //[OCS1003P01のデータウインドウで選択されたcolumnのデータ取得]
                string currentData = this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, this.mCurrentColName);

                //[OCS1003P01のデータウインドウで選択されたgroup_ser取得]
                string currentGroupSer = this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "group_ser_num");

                //[該当するGROUPTABに移動]
                this.SelectGroupTab(currentGroupSer);
                //[OCS1003P01のデータウインドウで選択されたデータの位置検索]
                if (this.mCurrentColName == "hangmog_name"
                    || (this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "bogyong_code_yn") == "N" && this.mCurrentColName == "order_detail")
                    || (this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "bogyong_code_yn") == "N" && this.mCurrentColName == "order_info"))
                {
                    //[OCS1003P01のデータウインドウで選択されたhangmog_name取得]
                    string currentHangmogCode = this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "hangmog_code");

                    //オーダ登録グリドから検索
                    for (int i = 0; i < this.grdOrder.RowCount; i++)
                    {
                        if (this.grdOrder.GetItemString(i, "hangmog_code") == currentHangmogCode && this.grdOrder.GetItemString(i, "group_ser") == currentGroupSer)
                        {
                            currentRow = i;
                            break;
                        }
                    }
                    //オーダプリヴューグリドから検索
                    if (this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "input_tab") == "01"
                        || this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "input_tab") == "03")
                    {
                        for (int j = 0; j < this.grdPreview.RowCount; j++)
                        {
                            if (this.grdPreview.GetItemString(j, "row_num") == currentRow.ToString())
                            {
                                currentPreviewRow = j;
                                break;
                            }
                        }
                    }
                }

                //フォーカス設定
                switch (this.mCurrentColName)
                {
                    case "hangmog_name":
                        if (currentPreviewRow >= 0)
                            this.grdPreview.SetFocusToItem(currentPreviewRow, "hangmog_name", true);
                        this.grdOrder.SetFocusToItem(currentRow, "hangmog_code", true);
                        break;
                    case "order_detail":
                        if (this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "bogyong_code_yn") == "Y")
                        {
                            this.cboNalsu.Focus();
                        }
                        else
                        {
                            if (currentPreviewRow >= 0)
                                this.grdPreview.SetFocusToItem(currentPreviewRow, "suryang", true);
                            this.grdOrder.SetFocusToItem(currentRow, "suryang", true);
                        }
                        break;
                    case "order_info":
                        //コメント
                        if (currentData.Substring(0, 1) == Resources.XMsg_000017)
                        {
                            if (currentPreviewRow >= 0)
                                this.grdPreview.SetFocusToItem(currentPreviewRow, "hangmog_name", true);
                            this.grdOrder.SetFocusToItem(currentRow, "order_remark", true);
                        }
                        //不均等オーダ
                        else if (currentData.Substring(1, 1) == Resources.XMsg_000018)
                        {
                            if (currentPreviewRow >= 0)
                                this.grdPreview.SetFocusToItem(currentPreviewRow, "hangmog_name", true);
                            this.grdOrder.SetFocusToItem(currentRow, "dv_1", true);
                        }
                        //希望日
                        else if (currentData.Substring(1, 1) == Resources.XMsg_000019)
                        {
                            if (currentPreviewRow >= 0)
                                this.grdPreview.SetFocusToItem(currentPreviewRow, "hangmog_name", true);
                            this.grdOrder.SetFocusToItem(currentRow, "hope_date", true);
                        }
                        //服用コード
                        else
                            this.fbxBogyongCode.Focus();
                        break;
                }
            }
        }

        private void Search_text()
        {
            if (this.cboSearchCondition.SelectedValue != null)
            {
                string searchText = this.txtSearch.GetDataValue();
                //Implement with bug MED-6542
                if (searchText == "" /*&& this.rbnOftenOrder.Checked*/)
                    searchText = "%";

                if (searchText == "")
                    return;

                string wonnaeDrgYn = "";

                wonnaeDrgYn = this.cboQueryCon.GetDataValue();

                if (this.rbnSearchOrder.Checked)
                {
                    this.LoadSearchOrderInfo(searchText, mOrderDate, INPUTTAB, wonnaeDrgYn);
                    WarningMessage(grdSearchOrder);
                }
                else if (this.rbnOftenOrder.Checked)
                {
                    if (this.tabSangyongOrder.SelectedTab != null)
                    {
                        Hashtable tabInfo = this.tabSangyongOrder.SelectedTab.Tag as Hashtable;

                        this.LoadOftenUseOrder("1", tabInfo["memb"].ToString(), tabInfo["order_gubun"].ToString(), wonnaeDrgYn, searchText);
                        WarningMessage(grdSangyongOrder);
                    }
                }
                else if (this.rbnDrgOrder.Checked)
                {
                    this.LoadDrgOrder("2", "%", wonnaeDrgYn, searchText);
                    WarningMessage(grdDrgOrder);
                }

                PostCallHelper.PostCall(new PostMethod(PostSearchValidating));
            }
        }

        private void SetEnableUcGrid(bool isEnable)
        {
            //tabGroup.Enabled = isEnable;
            grdOrder.Enabled = isEnable;
            grdDrgOrder.Enabled = isEnable;
            grdGeneral.Enabled = isEnable;
            grdOutSang.Enabled = isEnable;
            grdPreview.Enabled = isEnable;
            grdSangyongOrder.Enabled = isEnable;
            grdSearchOrder.Enabled = isEnable;
            fbxBogyongCode.Enabled = isEnable;
            fbxBogyongCode.Enabled = isEnable;
            dbxBogyongName.Enabled = isEnable;
            pnlOrderDetail.Enabled = isEnable;
            cbxEmergency.Enabled = isEnable;
            cboNalsu.Enabled = isEnable;
            cbxWonyoiOrderYN.Enabled = isEnable;
            btnBroughtDrg.Enabled = isEnable;
            btnJungsiDrug.Enabled = isEnable;
            btnDoOrder.Enabled = isEnable;
            btnSetOrder.Enabled = isEnable;
            btnInsert.Enabled = isEnable;
            btnNewSelect.Enabled = isEnable;
            btnSelect.Enabled = isEnable;
            xLabel8.Enabled = isEnable;
            lblNalsu.Enabled = isEnable;
            xLabel3.Enabled = isEnable;

            if(isEnable) fbxBogyongCode.ReadOnly = false;
            else fbxBogyongCode.ReadOnly = true;
            // ? call 2 times event
            //if (isEnable) dbxBogyongName.Click += dbxBogyongName_Click;
            //else dbxBogyongName.Click -= dbxBogyongName_Click;

            if(isEnable) cbxEmergency.CheckedChanged += cbxEmergency_CheckedChanged;
            else cbxEmergency.CheckedChanged -= cbxEmergency_CheckedChanged;

            //if (isEnable) cbxWonyoiOrderYN.CheckedChanged += cbxWonyoiOrderYN_CheckedChanged;
            //else cbxWonyoiOrderYN.CheckedChanged -= cbxWonyoiOrderYN_CheckedChanged;

            if(mBtnCopy != null) mBtnCopy.Enabled = isEnable;
            if (mBtnPaste != null) mBtnPaste.Enabled = isEnable;
            if (mBtnMix != null) mBtnMix.Enabled = isEnable;
            if (mBtnMixCancel != null) mBtnMixCancel.Enabled = isEnable;
            if (mBtnChangeWonyoi != null) mBtnChangeWonyoi.Enabled = isEnable;

            //right
            cboQueryCon.Enabled = isEnable;
            cboSearchCondition.Enabled = isEnable;
            txtSearch.Enabled = isEnable;
        }

        #endregion (methods)

        #region Events

        /// <summary>
        /// Screen Open시 Parameter를 받는다 (등록번호 연계)
        /// </summary>
        /// <remarks>
        /// 해당 등록번호와 내원정보로 외래처방 데이타 조회
        /// </remarks>
        public string ScreenOpen(CommonItemCollection aOpenParam, ref string aInputGubunName)
        {
            this.grdOrder.Reset();
            if (aOpenParam != null && aOpenParam.Contains("caller_screen_id"))
            {
                this.mCallerScreenID = aOpenParam["caller_screen_id"].ToString();
                _aOpenParam = aOpenParam;
            }

            SetEnableUcGrid(true);
            isEnableGrd = true;
            if (aOpenParam != null && aOpenParam.Contains("is_enable_grd") && (bool)aOpenParam["is_enable_grd"].Equals(false))
            {
                SetEnableUcGrid(false);
                isEnableGrd = false;
            }
            if (UserInfo.UserGubun == UserType.Doctor)
            {
                this.mDoctorLogin = true;
            }

            if (aOpenParam != null && aOpenParam.Contains("injection_dt"))
            {
                this.mInjectionDt = aOpenParam["injection_dt"] as DataTable;
            }

            /*//Old code 
            this.mOrderBiz = new IHIS.OCS.OrderBiz(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());             // OCS 그룹 Business 라이브러리
            this.mOrderFunc = new IHIS.OCS.OrderFunc(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());            // OCS 그룹 Function 라이브러리
            this.mPatientInfo = new IHIS.OCS.PatientInfo(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());        // OCS 환자정보 그룹 라이브러리 
            this.mHangmogInfo = new IHIS.OCS.HangmogInfo(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());        // OCS 항목정보 그룹 라이브러리
            this.mInputControl = new IHIS.OCS.InputControl(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());      // 입력제어 그룹 라이브러리 
            this.mCommonForms = new IHIS.OCS.CommonForms();                 // OCS 공통Form's 그룹 라이브러리 
            this.mColumnControl = new ColumnControl(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());      // OCS 컬럼 컨트롤 그룹 라이브러리 
            this.mInterface = new IHIS.OCS.OrderInterface();*/

            this.mOrderBiz = aOpenParam != null && aOpenParam.Contains("mOrderBiz") ? (IHIS.OCS.OrderBiz)aOpenParam["mOrderBiz"] : new IHIS.OCS.OrderBiz(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString()); // OCS 그룹 Business 라이브러리
            this.mOrderFunc = aOpenParam != null && aOpenParam.Contains("mOrderFunc") ? (IHIS.OCS.OrderFunc)aOpenParam["mOrderFunc"] : new IHIS.OCS.OrderFunc(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString()); // OCS 그룹 Function 라이브러리
            this.mPatientInfo = aOpenParam != null && aOpenParam.Contains("mPatientInfo") ? (IHIS.OCS.PatientInfo)aOpenParam["mPatientInfo"] : new IHIS.OCS.PatientInfo(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());
            // OCS 환자정보 그룹 라이브러리 
            this.mHangmogInfo = aOpenParam != null && aOpenParam.Contains("mHangmogInfo") ? (IHIS.OCS.HangmogInfo)aOpenParam["mHangmogInfo"] : new IHIS.OCS.HangmogInfo(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());        // OCS 항목정보 그룹 라이브러리
            this.mInputControl = aOpenParam != null && aOpenParam.Contains("mInputControl") ? (IHIS.OCS.InputControl)aOpenParam["mInputControl"] : new IHIS.OCS.InputControl(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());      // 입력제어 그룹 라이브러리 
            this.mCommonForms = aOpenParam != null && aOpenParam.Contains("mCommonForms") ? (IHIS.OCS.CommonForms)aOpenParam["mCommonForms"] : new IHIS.OCS.CommonForms();                 // OCS 공통Form's 그룹 라이브러리 
            this.mColumnControl = aOpenParam != null && aOpenParam.Contains("mColumnControl") ? (IHIS.OCS.ColumnControl)aOpenParam["mColumnControl"] : new ColumnControl(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());      // OCS 컬럼 컨트롤 그룹 라이브러리 
            this.mInterface = aOpenParam != null && aOpenParam.Contains("mInterface") ? (IHIS.OCS.OrderInterface)aOpenParam["mInterface"] : new IHIS.OCS.OrderInterface();

            //this.layDeletedData.SavePerformer = new XSavePeformer(this);
            //this.laySaveLayout.SavePerformer = this.layDeletedData.SavePerformer;

            if (aOpenParam != null) // 다른 화면에서 콜되는 경우
            {
                #region 파라미터 셋팅

                if (aOpenParam.Contains("caller_sys_id"))
                {
                    this.mCallerSysID = aOpenParam["caller_sys_id"].ToString();
                }

                // 환자번호
                if (aOpenParam.Contains("bunho"))
                {
                    mBunho = aOpenParam["bunho"].ToString();
                }

                // 입원외래 구분
                if (aOpenParam.Contains("io_gubun"))
                {
                    this.IOEGUBUN = aOpenParam["io_gubun"].ToString();
                }

                // 입력구분 셋팅
                if (aOpenParam.Contains("input_gubun"))
                {
                    this.mInputGubun = aOpenParam["input_gubun"].ToString();
                    this.cboInputGubun.SetDataValue(this.mInputGubun);
                    this.mOrderBiz.LoadColumnCodeName("code", "INPUT_GUBUN", this.mInputGubun, ref this.mInputGubunName);
                    aInputGubunName = mInputGubunName;

                    if (UserInfo.Gwa == "CK")
                        this.cboInputGubun.Enabled = false;
                }

                // 
                if (aOpenParam.Contains("postapprove_yn"))
                {
                    if (aOpenParam["postapprove_yn"].ToString() == "Y")
                        this.mPostApproveYN = true;
                    else
                        this.mPostApproveYN = false;
                }

                // 입력파트 셋팅
                if (aOpenParam.Contains("input_part"))
                {
                    this.mInputPart = aOpenParam["input_part"].ToString();

                }
                else
                {
                    this.mInputPart = "*";
                }

                //一般名のユーザーセッティング値を取得。
                //this.mGeneral_disp_yn = this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "GENERAL_DISP_YN", aOpenParam["io_gubun"].ToString());


                //// 입력구분명 셋팅
                //if (aOpenParam.Contains("input_gubun_name"))
                //{
                //    this.mInputGubunName = aOpenParam["input_gubun_name"].ToString();
                //    this.dbxInputGubunName.SetDataValue("【 " + this.mInputGubunName + " 】");
                //}

                // 외래, 혹은 입원 키가ㅄ
                if (aOpenParam.Contains("naewon_key"))
                {
                    this.mPkInOutKey = aOpenParam["naewon_key"].ToString();
                }

                // 환자정보
                if (aOpenParam.Contains("patient_info"))
                {
                    this.mPatientInfo = ((PatientInfo)aOpenParam["patient_info"]);
                }

                // 오더 입력모드 설저ㅓㅇ
                if (aOpenParam.Contains("order_mode"))
                {
                    this.mOrderMode = (OrderVariables.OrderMode)aOpenParam["order_mode"];
                    this.SetVisiblePatientInfoPanel();
                }

                if (aOpenParam != null && aOpenParam.Contains("order_date"))
                {
                    mOrderDate = aOpenParam["order_date"].ToString();
                }
                else
                {
                    mOrderDate = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/");
                }

                // 셋트 키
                if (aOpenParam.Contains("memb"))
                {
                    this.mMemb = aOpenParam["memb"].ToString();
                }

                if (aOpenParam.Contains("yaksok_code"))
                {
                    this.mYaksokCode = aOpenParam["yaksok_code"].ToString();
                }

                // CP 키
                if (aOpenParam.Contains("cp_master_key"))
                {
                    this.mCpMasterkey = aOpenParam["cp_master_key"].ToString();
                }

                if (aOpenParam.Contains("memb_gubun"))
                {
                    this.mMembGubun = aOpenParam["memb_gubun"].ToString();
                }

                if (aOpenParam.Contains("cp_code"))
                {
                    this.mCpCode = aOpenParam["cp_code"].ToString();
                }

                if (aOpenParam.Contains("cp_path_code"))
                {
                    this.mCpPathCode = aOpenParam["cp_path_code"].ToString();
                }

                if (aOpenParam.Contains("jaewonil"))
                {
                    this.mJaewonil = aOpenParam["jaewonil"].ToString();
                }

                // 오더 DataRow 
                if (aOpenParam.Contains("in_data_row"))
                {
                    this.mInDataRow = ((DataTable)aOpenParam["in_data_row"]);

                    SetInitialOrderGridData(this.mInDataRow);

                }

                //[データウインドウからの自動フォーカス]　START
                if (aOpenParam.Contains("currentRowNum"))
                {
                    this.mCurrentRowNum = int.Parse(aOpenParam["currentRowNum"].ToString());
                }

                if (aOpenParam.Contains("currentDataWindow"))
                {
                    this.mCurrentDataWindow = (XDataWindow)aOpenParam["currentDataWindow"];
                }

                if (aOpenParam.Contains("currentColName"))
                {
                    this.mCurrentColName = aOpenParam["currentColName"].ToString();
                }
                if (aOpenParam.Contains("protocol_id"))
                {
                    this.protocolId = aOpenParam["protocol_id"].ToString();
                }
                //[データウインドウからの自動フォーカス]　END

                //his.MakeGroupTabInfo(this.IOEGUBUN, this.mPkInOutKey, this.mInputGubun, INPUTTAB);

                #endregion

                this.Focus();
            }
            else
            {
                //// 이전 스크린의 등록번호를 가져온다
                //XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);

                //if (patientInfo == null || (patientInfo != null && TypeCheck.IsNull(patientInfo.BunHo)))
                //{
                //    // 이전 스크린의 등록번호를 못가지고 온 경우, 열려있는 전체 스크린에서 등록번호를 가져온다
                //    patientInfo = XScreen.GetOtherScreenBunHo(this, true);
                //}

                //if (patientInfo != null && !TypeCheck.IsNull(patientInfo.BunHo))
                //{
                //    this.fbxBunho.Focus();
                //    this.fbxBunho.SetEditValue(patientInfo.BunHo);
                //    this.fbxBunho.AcceptData();
                //}

                //this.Focus();
            }

            // Cloud updated code START
            DoFormLoad(aOpenParam["io_gubun"].ToString());
            this.mGeneral_disp_yn = _formResult.GeneralDispYn;
            string mSentouSearchYN = _formResult.SentouSearchYn;
            // Cloud updated code END

            //insert into [検索語の検索条件初期化] 2012/10/15 
            //Random selected [like %word%]
            //Front selected [like word%]
            //string mSentouSearchYN = this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "SENTOU_SEARCH_YN", this.IOEGUBUN);
            if (mSentouSearchYN == "Y")
                //this.cbxSentou.Checked = true;
                this.cboSearchCondition.SelectedIndex = 1;
            else
                this.cboSearchCondition.SelectedIndex = 0;

            // Default 원내 원외 여부 조회
            this.SetWonyoiDefault();


            //// 신규 탭페이지 설정
            //this.tpgNew.Title = XMsg.GetMsg("M002"); // 신규로 작성
            //this.tpgNew.ImageIndex = 1;
            //Hashtable groupInfo = new Hashtable();
            //groupInfo.Add("group_ser", "0");
            //groupInfo.Add("group_name", "New");

            // 처방구분정보 Load
            //mDtOrderGubun = this.mOrderBiz.LoadComboDataSource("order_gubun_bas").LayoutTable;

            //if (UserInfo.UserGubun != UserType.Doctor)
            //{
            //    this.btnIlgwalChange.Visible = false;
            //}



            this.InitScreen();

            // 각종 콤보 데이터 로드 
            //DataTable dtTemp;

            // dv_time 콤보 구성
            //dtTemp = this.mOrderBiz.LoadComboDataSource("dv_time").LayoutTable;
            //this.grdOrder.SetListItems("dv_time", dtTemp, "code_name", "code");
            this.grdOrder.SetListItems("dv_time", _dvTimeCbo, "code_name", "code");

            //// 수량, 횟수 콤보 구성
            //this.mOrderBiz.SetNumCombo(this.grdOrder, "suryang", true);
            //this.mOrderBiz.SetNumCombo(this.grdOrder, "dv", false);
            // Cloud
            this.mOrderBiz.SetNumCombo(this.grdOrder, "suryang", true, _suryangCbo);
            this.mOrderBiz.SetNumCombo(this.grdOrder, "dv", false, _dvCbo);

            // 횟수(1234) 콤보구성
            //this.mOrderBiz.SetNumCombo(this.grdOrder, "dv_1", true);
            //this.mOrderBiz.SetNumCombo(this.grdOrder, "dv_2", true);
            //this.mOrderBiz.SetNumCombo(this.grdOrder, "dv_3", true);
            //this.mOrderBiz.SetNumCombo(this.grdOrder, "dv_4", true);

            //// 服用コード整理 2012/12/10
            //this.mOrderBiz.SetNumCombo(this.grdOrder, "dv_5", true);
            //this.mOrderBiz.SetNumCombo(this.grdOrder, "dv_6", true);
            //this.mOrderBiz.SetNumCombo(this.grdOrder, "dv_7", true);
            //this.mOrderBiz.SetNumCombo(this.grdOrder, "dv_8", true);

            // 날수 콤보
            //this.mOrderBiz.SetNumCombo(this.cboNalsu, "nalsu", false);
            this.mOrderBiz.SetNumCombo(this.cboNalsu, "nalsu", false, _nalsuCbo);
            //this.cboNalsu.MaxDropDownItems = this.cboNalsu.Items.Count;

            this.ParentForm.KeyPreview = true;
            this.ParentForm.KeyDown += new KeyEventHandler(ParentForm_KeyDown);


            this.InitializeScreen();

            //MessageBox.Show("Onload end");

            PostLoad(aOpenParam);

            this.btnInsert.Visible = true;
            isOpenPopUp = aOpenParam.Contains("isOpenPopUp") ? (bool)aOpenParam["isOpenPopUp"] : true;
            if (aOpenParam.Contains("isOpenPopUp") && aOpenParam["isOpenPopUp"].Equals(true))
            {
                this.btnInsert.Visible = false;
                if (aOpenParam.Contains("dt_grdoutsang"))
                {
                    grdOutSangDt = (DataTable)aOpenParam["dt_grdoutsang"];
                }
            }

            return mDefaultWonyoiOrder;
        }

        private void btnExtend_Click(object sender, EventArgs e)
        {
            if (this.mIsExtended)
            {
                this.pnlOrderInfo.Size = new Size(this.OrderNormalWidth, this.pnlOrderInfo.Size.Height);
                this.btnExtend.ImageIndex = 3;
                this.mIsExtended = false;
            }
            else
            {
                this.pnlOrderInfo.Size = new Size(this.OrderExtendWidth, this.pnlOrderInfo.Size.Height);
                this.btnExtend.ImageIndex = 4;
                this.mIsExtended = true;
            }
            this.grdOrder.Refresh();
        }

        private void btnExpandSearch_Click(object sender, EventArgs e)
        {
            if (this.mIsSearchExtended == false)
            {
                this.btnExpandSearch.ImageIndex = 3;
                this.pnlOrderInfo.Size = new Size(this.OrderMinWidth, this.pnlOrderInfo.Size.Height);

                this.grdDrgOrder.AutoSizeColumn(1, this.DrgHangmogNameMaxWidth);
                this.grdSearchOrder.AutoSizeColumn(1, this.SearchHangmogNameMaxWidth);
                this.grdSearchOrder.AutoSizeColumn(2, this.SearchHangmogNameMaxWidth);
                this.grdSangyongOrder.AutoSizeColumn(1, this.SangYongHangmogMaxWidth);
                this.grdPreview.AutoSizeColumn(1, this.PreviewHangmogMaxWidth);

                this.mIsSearchExtended = true;
            }
            else
            {
                this.btnExpandSearch.ImageIndex = 4;
                this.pnlOrderInfo.Size = new Size(this.OrderNormalWidth, this.pnlOrderInfo.Size.Height);

                this.grdDrgOrder.AutoSizeColumn(1, this.DrgHangmogNameNormalWidth);
                this.grdSearchOrder.AutoSizeColumn(1, this.SearchHangmogNameNormalWidth);
                this.grdSearchOrder.AutoSizeColumn(2, this.SearchHangmogNameNormalWidth);
                this.grdSangyongOrder.AutoSizeColumn(1, this.SangYongHangmogNormalWidth);
                this.grdPreview.AutoSizeColumn(1, this.PreviewHangmogNormalWidth);

                this.mIsSearchExtended = false;
            }
        }

        private void btnSetOrder_Click(object sender, EventArgs e)
        {
            this.OpenScreen_OCS0301Q09();
        }

        private void btnDoOrder_Click(object sender, EventArgs e)
        {
            this.OpenScreen_OCS1003Q09(false);
        }

        public void HandleBtnCopyClick(bool isCut)
        {

            string mbxMsg = "", mbxCap = "";
            string mCopy_gubun = "";

            /*//Old code
            mCopy_gubun = mBtnCopy != null ? mBtnCopy.Tag.ToString() : "1";*/
            mCopy_gubun = isCut ? "0" : "1";

            if (this.grdOrder.LayoutTable == null) return;

            bool isSelectedRow = false; // Select 여부 
            ArrayList selectedRow = new ArrayList();  // Selected Row's

            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                if (this.grdOrder.IsSelectedRow(i) && this.grdOrder.IsVisibleRow(i) && this.mOrderFunc.GetEmptyNewRow(this.grdOrder, i) == null) // Select 여부 체크
                {
                    selectedRow.Add(i);
                    isSelectedRow = true;
                }
            }

            if (!isSelectedRow)
            {
                mbxMsg = Resources.XMsg_000020;

                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
                return;
            }

            if (mPbxCopy != null) this.mPbxCopy.Visible = false; // 디폴트 Copy할 데이타 선택여부 False

            // DataTable 비워 있는 경우 테이블 구조 복제
            if (this.mLayDtOrderBuffer == null) this.mLayDtOrderBuffer = this.grdOrder.LayoutTable.Clone();

            this.mLayDtOrderBuffer.Rows.Clear(); // Buffer DataTable Clear

            for (int i = 0; i < selectedRow.Count; i++)
            {
                this.mLayDtOrderBuffer.ImportRow(this.grdOrder.LayoutTable.Rows[(int)selectedRow[i]]);
            }

            // コピー後削除
            if (mCopy_gubun == "0")
            {
                for (int i = selectedRow.Count - 1; i >= 0; i--)
                    this.grdOrder.DeleteRow((int)selectedRow[i]);
            }

            //this.pbxCopy.Visible = true; // Copy할 데이타 선택여부 true
            this.grdOrder.UnSelectAll();

            if (mCopy_gubun == "0")
            {
                Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;
                this.DisplayOrderGridGroupInfo(groupInfo);
            }
        }

        public void HandleBtnPasteClick()
        {
            string mbxMsg = "", mbxCap = "";

            //this.AcceptData();

            if (this.mLayDtOrderBuffer == null || this.mLayDtOrderBuffer.Rows.Count == 0)
            {
                mbxMsg = Resources.XMsg_000021;

                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
                return;
            }

            // DataTable 데이타를 처방Grid에 카피한다
            MultiLayout lay = this.mOrderFunc.CloneDataLayoutMIO(this.grdOrder);

            foreach (DataRow dRow in this.mLayDtOrderBuffer.Rows) lay.LayoutTable.ImportRow(dRow);

            this.grdOrder.SetFocusToItem(this.grdOrder.RowCount - 1, "hangmog_code", false);

            this.ApplyCopyOrderInfo(lay, HangmogInfo.ExecutiveMode.OrderCopy);
            // 로직 구동후에 사용자 입력 편의를 위해서 맨 마지막 Row로 이동한다
            this.grdOrder.SetFocusToItem(this.grdOrder.RowCount - 1, "hangmog_code");

            this.grdOrder.UnSelectAll();

            ProcessCheckKinki();
            ActionCheckOutHosp();
        }

        public void HandleBtnMixClick()
        {
            this.mHangmogInfo.SetMaxMixGroup(this.grdOrder);

            this.DisplayMixGroup(this.grdOrder); // Mix Group 데이타 Image Display

            //this.mHangmogInfo.SetAlignMixGroup(grdOrder, settingStartRow, settingRow); // Mix Group 정렬

        }

        public void HandleBtnMixCancelClick()
        {
            this.mHangmogInfo.ReSetMixGroup(this.grdOrder);

            this.DisplayMixGroup(this.grdOrder); // Mix Group 데이타 Image Display

            //this.mHangmogInfo.SetAlignMixGroup(grdOrder, settingStartRow, settingRow); // Mix Group 정렬
        }

        private void btnNewSelect_Click(object sender, EventArgs e)
        {
            //XGrid grid;
            //int applyRow = -1;
            //// 신규 그룹 추가
            //this.MakeNewOrderGroup(false);

            //// 현재 선택된 그리드의 항목코드 셋팅
            //if (rbnSearchOrder.Checked == true)
            //{
            //    grid = this.grdSearchOrder as XGrid;
            //}
            //else if (rbnOftenOrder.Checked == true)
            //{
            //    grid = this.grdSangyongOrder as XGrid;
            //}
            //else
            //{
            //    grid = this.grdDrgOrder as XGrid;
            //}

            //if (grid.RowCount <= 0 ||
            //    grid.CurrentRowNumber < 0) return;

            //XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)this.grdOrder);

            //if (emptyNewCell != null)
            //    applyRow = emptyNewCell.Row;
            //else
            //{
            //    applyRow = this.grdOrder.InsertRow();
            //    this.GridInitValueSetting(grdOrder, applyRow);
            //}

            //this.ApplySangOrderInfo(grid.GetItemString(grid.CurrentRowNumber, "hangmog_code"), applyRow, false);

            //insert by jc [空きのグループがあったら空きのグループ情報をリターンして空きのグループにオーダ登録] 2012/04/10
            //if (this.IsExistEmptyGroup())
            //{
            //    IHIS.X.Magic.Controls.TabPage tpg = new IHIS.X.Magic.Controls.TabPage();
            //    tpg = this.mOrderFunc.GetExistEmptyGroup(this.grdOrder, this.tabGroup);
            //    this.tabGroup.TabPages.Remove(tpg);
            //}

            HandleBtnListClick(FunctionType.Process);

            this.btnSelect.PerformClick();


        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            XGrid grid;
            int applyRow = -1;

            if (this.tabGroup.SelectedTab == null)
            {
                HandleBtnListClick(FunctionType.Process);
            }

            // 현재 선택된 그리드의 항목코드 셋팅
            if (rbnSearchOrder.Checked == true)
            {
                grid = mSelectedGRD;
            }
            else if (rbnOftenOrder.Checked == true)
            {
                grid = this.grdSangyongOrder as XGrid;
            }
            else
            {
                grid = this.grdDrgOrder as XGrid;
            }


            if (grid == null)
                return;

            if (grid.RowCount <= 0 ||
                grid.CurrentRowNumber < 0) return;

            XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)this.grdOrder);

            if (emptyNewCell != null)
                applyRow = emptyNewCell.Row;
            else
            {
                applyRow = this.grdOrder.InsertRow(-1);
                this.GridInitValueSetting(grdOrder, applyRow);
                //this.grdOrder.AcceptData();
            }

            //this.ApplySangOrderInfo(grid.GetItemString(grid.CurrentRowNumber, "hangmog_code"), applyRow, false);
            //this.ApplySangOrderInfo(grid.GetItemString(grid.CurrentRowNumber, "hangmog_code"), this.grdOrder.CurrentRowNumber, false);
            // modify by jc [一般名検索追加]
            this.ApplySangOrderInfo(grid.GetItemString(grid.CurrentRowNumber, "hangmog_code"), this.grdOrder.CurrentRowNumber, false, this.mGenericSearchYN);

            PostCallHelper.PostCall(new PostMethodInt(this.PostOrderInsert), applyRow);
            
            ProcessCheckKinki();
            ActionCheckOutHosp();

            //this.MakePreviewStatus();

        }

        public void ProcessCheckKinki()
        {
            Service.WriteLog("Start process check...");
            Service.WriteLog("DoctorDrugCheck: " + UserInfo.DoctorDrugCheck);
            Service.WriteLog("CheckDosage: " + UserInfo.CheckDosage.ToString());
            Service.WriteLog("CheckInteraction: " + UserInfo.CheckInteraction.ToString());
            Service.WriteLog("CheckKinki: " + UserInfo.CheckKinki.ToString());

            DataTable grOrder = grdOrder.LayoutTable;

            DataTable grdOrderN2 = new DataTable();
            grdOrderN2.Columns.Add(new DataColumn("yj_code", typeof(string)));
            grdOrderN2.Columns.Add(new DataColumn("hangmog_code", typeof(string)));
            grdOrderN2.Columns.Add(new DataColumn("hangmog_name", typeof(string)));
            DataTable grdOrderN1 = grdOrderN2.Clone();
            DataTable grdOrderAll = grdOrderN2.Clone();

            if (mInjectionDt != null)
            {
                foreach (DataRow row in mInjectionDt.Rows)
                {
                    if (row["yj_code"].ToString() == "") continue;
                    grdOrderN2.Rows.Add(new object[] { row["yj_code"].ToString(), row["hangmog_code"].ToString(), row["hangmog_name"].ToString() });
                    grdOrderAll.Rows.Add(new object[] { row["yj_code"].ToString(), row["hangmog_code"].ToString(), row["hangmog_name"].ToString() });
                }
            }
            for (int i = 0; i < grOrder.Rows.Count; i++)
            {
                if (grOrder.Rows[i]["yj_code"].ToString() != "")
                {
                    if (i < grOrder.Rows.Count - 1)
                    {
                        grdOrderN2.Rows.Add(new object[] { grOrder.Rows[i]["yj_code"].ToString(), grOrder.Rows[i]["hangmog_code"].ToString(), grOrder.Rows[i]["hangmog_name"].ToString() });
                    }
                    else
                    {
                        grdOrderN1.Rows.Add(new object[] { grOrder.Rows[i]["yj_code"].ToString(), grOrder.Rows[i]["hangmog_code"].ToString(), grOrder.Rows[i]["hangmog_name"].ToString() });
                    }

                    grdOrderAll.Rows.Add(new object[] { grOrder.Rows[i]["yj_code"].ToString(), grOrder.Rows[i]["hangmog_code"].ToString(), grOrder.Rows[i]["hangmog_name"].ToString() });
                }
            }

            DataTable grdOutSangParam;
            grdOutSangParam = grdOutSangDt;
            if (grdOutSang.LayoutTable.Rows.Count > 0)
            {
                grdOutSangParam = null;
                grdOutSangParam = grdOutSang.LayoutTable;
            }

            try
            {
                this.allWarning = HandlingData.ProcessCheck(grdOrderAll, grdOutSangParam, grdOrderN2, grdOrderN1);
                Service.WriteLog("Process check completed!");
            }
            catch (Exception ex)
            {
                Service.WriteLog("Process check error: " + ex.Message);
            }
        }

        private void btnJungsiDrug_Click(object sender, EventArgs e)
        {
            OpenScreen_OCS1023U00(this.mPatientInfo.GetPatientInfo["bunho"].ToString(), this.mPatientInfo.GetPatientInfo["gwa"].ToString());
        }

        private void OrderRadio_CheckedChanged(object sender, EventArgs e)
        {
            XRadioButton control = sender as XRadioButton;
            //insert by jc
            string searchVoc = this.txtSearch.GetDataValue();
            string wonnaeDrgYn = this.cboQueryCon.GetDataValue();

            if (control.Checked)
            {
                control.BackColor = this.mSelectedBackColor;
                control.ForeColor = this.mSelectedForeColor;
                control.ImageIndex = 0;

                // 선택된것에 따른 화면 조정
                switch (control.Name)
                {
                    case "rbnSearchOrder":   // 오더검색
                        this.pnlSearchTool.Visible = true;
                        this.pnlSearchOrder.Visible = true;
                        this.pnlSangyong.Visible = false;
                        this.pnlDrug.Visible = false;
                        this.pnlPreview.Visible = false;
                        if (this.IOEGUBUN == "O")
                            this.grbGeneric.Enabled = true;
                        else
                            this.grbGeneric.Enabled = false;
                        //this.rbtSyouhin.Enabled = true;
                        this.grdSearchOrder.Reset();

                        PostCallHelper.PostCall(new PostMethod(PostRadioCheckedChanged));

                        //insert by jc TABが変わる際に検索語が既にあった場合はその検索語で検索する。
                        if (searchVoc != "")
                        {
                            if (this.rbnSearchOrder.Checked)
                                this.LoadSearchOrderInfo(searchVoc, mOrderDate, INPUTTAB, wonnaeDrgYn);
                        }
                        break;

                    case "rbnOftenOrder":    // 상용오더
                        this.pnlSearchTool.Visible = true;
                        this.pnlSearchOrder.Visible = false;
                        this.pnlSangyong.Visible = true;
                        this.pnlDrug.Visible = false;
                        this.pnlPreview.Visible = false;
                        this.rbtSyouhin.Checked = true;
                        this.grbGeneric.Enabled = false;
                        PostCallHelper.PostCall(new PostMethod(PostRadioCheckedChanged));
                        this.tabSangyongOrder_SelectionChanged(this.tabSangyongOrder, new EventArgs());

                        break;

                    case "rbnDrgOrder":       // 효능별
                        this.pnlSearchTool.Visible = true;
                        this.pnlSearchOrder.Visible = false;
                        this.pnlSangyong.Visible = false;
                        this.pnlDrug.Visible = true;
                        this.pnlPreview.Visible = false;
                        this.rbtSyouhin.Checked = true;
                        this.grbGeneric.Enabled = false;
                        this.grdDrgOrder.Reset();
                        PostCallHelper.PostCall(new PostMethod(PostRadioCheckedChanged));
                        //insert by jc TABが変わる際に検索語が既にあった場合はその検索語で検索する。
                        if (searchVoc != "")
                        {
                            if (this.rbnDrgOrder.Checked)
                                this.LoadDrgOrder("2", "%", wonnaeDrgYn, this.txtSearch.GetDataValue());
                        }

                        break;

                    case "rbnOrderStatus":
                        this.pnlSearchTool.Visible = false;
                        this.pnlSearchOrder.Visible = false;
                        this.pnlSangyong.Visible = false;
                        this.pnlDrug.Visible = false;
                        this.pnlPreview.Visible = true;
                        this.rbtSyouhin.Checked = true;
                        this.grbGeneric.Enabled = false;
                        this.MakePreviewStatus();
                        break;
                }
            }
            else
            {
                control.BackColor = this.mUnSelectedBackColor;
                control.ForeColor = this.mUnSelectedForeColor;
                control.ImageIndex = 1;
            }
        }

        private void tabGroup_ClosePressed(object sender, EventArgs e)
        {
            IHIS.X.Magic.Controls.TabControl control = sender as IHIS.X.Magic.Controls.TabControl;

            this.DeleteCurrentGroupTab(control.SelectedTab);
        }

        private void tabGroup_SelectionChanging(object sender, EventArgs e)
        {
            if (this.tabGroup.SelectedTab == null)
                return;

            Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            if (groupInfo.Contains("nalsu") && groupInfo["nalsu"].ToString() != this.cboNalsu.GetDataValue())
            {
                this.cboNalsu.AcceptData();
            }

            if (groupInfo.Contains("bogyong_code") && groupInfo["bogyong_code"].ToString() != this.fbxBogyongCode.GetDataValue())
            {
                this.fbxBogyongCode.AcceptData();
            }

            if (groupInfo.Contains("emergency") && groupInfo["emergency"].ToString() != this.cbxEmergency.GetDataValue())
            {
                this.cbxEmergency.AcceptData();
            }

            if (groupInfo.Contains("wonyoi_order_yn") && groupInfo["wonyoi_order_yn"].ToString() != this.cbxWonyoiOrderYN.GetDataValue())
            {
                this.cbxWonyoiOrderYN.AcceptData();
            }
        }

        private void tabGroup_SelectionChanged(object sender, EventArgs e)
        {
            //insert by jc [選択されているgroupがない内はInput_gubunによるVisible設定をやり直す。]
            if (tabGroup.SelectedTab == null)
                mOrderFunc.SetGridRowVisibleByNoGroupSer(this.grdOrder, this.mInputGubun);

            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroup.TabPages)
            {
                if (this.tabGroup.SelectedTab == tpg)
                {
                    tpg.ImageIndex = 0;

                    this.mOrderFunc.DeleteEmptyNewRow(this.grdOrder);

                    this.DisplayOrderGridGroupInfo((Hashtable)(tpg.Tag));

                    //Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

                    //if (groupInfo.Contains("wonyoi_order_yn") && groupInfo["wonyoi_order_yn"].ToString() == "Y")
                    //{
                    //    this.mDefaultWonyoiOrder = "Y";
                    //    this.btnChangeWonyoi.Text = "院内に変更";
                    //    this.dbxWonyoiOrderYN.SetDataValue("【院外処方】");
                    //}
                    //else
                    //{
                    //    this.mDefaultWonyoiOrder = "N";
                    //    this.btnChangeWonyoi.Text = "院外に変更";
                    //    this.dbxWonyoiOrderYN.SetDataValue("【院内処方】");
                    //}

                    // 해당 그룹의 젤 마지막 로우로 포커스 이동
                    //PostCallHelper.PostCall(new PostMethodInt(this.PostTabSelection), this.mOrderFunc.GetLastRow(this.grdOrder.LayoutTable, ((Hashtable)tpg.Tag)["group_ser"].ToString()));
                }
                else
                {
                    tpg.ImageIndex = 1;
                }
            }
            if (parentControl != null)
                parentControl.ChangWonyoi(cbxWonyoiOrderYN.GetDataValue());
            //this.setFocusGotoColumn();
        }

        public void HandleBtnListClick(FunctionType type)
        {
            switch (type)
            {
                case FunctionType.Cancel:

                    #region 현재 그룹 탭 삭제

                    this.DeleteCurrentGroupTab(this.tabGroup.SelectedTab);

                    this.MakePreviewStatus();

                    #endregion

                    break;

                case FunctionType.Process:

                    #region 신규 오더 그룹 탭 추가


                    this.MakeNewOrderGroup(true);

                    this.txtSearch.Focus();

                    #endregion

                    break;

                case FunctionType.Insert:

                    #region 신규 오더 입력


                    //if (this.AcceptData() == false) return;

                    if (this.tabGroup.TabPages.Count <= 0)
                        HandleBtnListClick(FunctionType.Process);

                    // Insert한 Row 중에 Not Null필드 미입력 Row Search 하여 해당 Row로 이동
                    XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)this.grdOrder);

                    if (emptyNewCell != null)
                    {
                        //TODO Check again
                        //e.IsSuccess = false;    

                        ((XEditGrid)this.grdOrder).SetFocusToItem(emptyNewCell.Row, emptyNewCell.CellName);
                        break;
                    }

                    this.OrderGridCreateNewRow(-1);

                    if (mContainer != null) this.mContainer.AcceptData();

                    this.DisplayOrderGridGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag);

                    // 포커스를 HANGMOG_CODE로
                    //this.grdOrder.SetFocusToItem(this.grdOrder.CurrentRowNumber, "hangmog_code", true);
                    PostCallHelper.PostCall(new PostMethodStr(PostCallAfterInsertRow), "hangmog_code");

                    #endregion

                    break;

                case FunctionType.Query:

                    if (mContainer != null) this.mContainer.AcceptData();

                    this.LoadOrderTable(this.mOrderMode, this.mMemb, this.mYaksokCode, this.mPkInOutKey, this.mInputGubun, INPUTTAB, "");

                    this.MakeGroupTabInfo(this.IOEGUBUN, this.mPkInOutKey, this.mInputGubun, INPUTTAB);

                    break;

                case FunctionType.Update:

                    #region 저장

                    if (mContainer != null && this.mContainer.AcceptData() == false)
                        return;

                    lblInOut.Focus();
                    //同じグループ情報チェック
                    if (this.IOEGUBUN == "O")
                        this.CheckSameGroup_info();

                    if (this.IsUpdateCheck() == false)
                        return;

                    // 現在選択されているINPUT_GUBUNで変更する。
                    //if(UserInfo.UserGubun == UserType.Doctor)
                    //    this.ChangeInputGubun();


                    //insert by jc START [MIXされたオーダが離れている場合、くっ付けるため]
                    this.grdOrder.Sort("group_ser, hope_date, mix_group");
                    //insert by jc END

                    /* -------------------------------------------------------------------------------------------------- */
                    //inser by jc [詳細画面での保存処理] START 2012/04/17
                    //[Merge : grdOrder -> laySaveLayout] 
                    //入院オーダ登録画面以外で呼び出されて保存されるときはその画面で保存されるように
                    if (this.mOrderMode == OrderVariables.OrderMode.InpOrder && this.mCallerScreenID != "OCS2003P01")
                    {
                        if (this.mOrderBiz.MergeToSaveLayout(this.grdOrder, this.laySaveLayout, this.layDeletedData) == false) return;

                        //[退院予約されてオーダ終了されたのかチェックしてオーダ終了されているなら保存できなくする。]
                        if (this.mOrderBiz.IsToiwonGojiYNandEndOrder(this.mPatientInfo.GetPatientInfo["naewon_key"].ToString()) == false)
                            return;

                        //
                        if (this.mOrderBiz.OrderValidationCheck(this.mDoctorLogin,
                                                                ref this.laySaveLayout,
                                                                this.mPatientInfo.GetPatientInfo["bunho"].ToString(),
                                                                this.mPatientInfo.GetPatientInfo["naewon_key"].ToString(),
                                                                mOrderDate,
                                                                this.mPatientInfo.GetPatientInfo["gwa"].ToString(),
                                                                this.mPatientInfo.GetPatientInfo["doctor"].ToString(),
                                                                this.mPatientInfo.GetPatientInfo["naewon_type"].ToString()) == false)
                        {
                            PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert));
                            return;
                        }

                        //[InterFace]
                        this.mInterface.MakeIFDataLayout("I", this.layDeletedData.LayoutTable, true, false, true);

                        this.mInterface.MakeIFDataLayout("I", this.laySaveLayout.LayoutTable, false, true, false);

                        this.mInterface.MakeIFDataLayout("I", this.laySaveLayout.LayoutTable, false, false, false);

                        // 트랜잭션 시작
                        try
                        {
                            //Service.BeginTransaction();

                            // 삭제시에는 삭제테이블의 데이터를 건드려 줘야 함.
                            for (int i = 0; i < this.layDeletedData.RowCount; i++)
                            {
                                this.layDeletedData.SetItemValue(i, "dummy", "mageshin");
                            }

                            // Cloud updated code START
                            OCS0103U10SaveLayoutArgs args = new OCS0103U10SaveLayoutArgs();
                            args.SaveLayoutItem = GetListDataForSaveLayout();
                            args.InterfaceInsertItem = GetListDataForInterfaceInsert();
                            args.Bunho = mBunho;
                            args.OrderDate = mOrderDate;

                            OCS0103U10SaveLayoutResult res = CloudService.Instance.Submit<OCS0103U10SaveLayoutResult, OCS0103U10SaveLayoutArgs>(args);

                            if (res == null || !res.Success)
                            {

                                this.mbxMsg = XMsg.GetMsg("M005") + " - " + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...

                                MessageBox.Show(this.mbxMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                                return;
                            }

                            if (res.Result != "0")
                            {
                                this.mbxMsg = XMsg.GetMsg("M005") + " - " + res.Result;  // 저장에 실패하였습니다 + 에러메세지...

                                MessageBox.Show(this.mbxMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                                return;
                            }
                            // Cloud updated code END
                        }
                        catch
                        {
                            throw;
                        }

                        #region tobe deleted
                        //try
                        //{
                        //    Service.BeginTransaction();

                        //    // 삭제시에는 삭제테이블의 데이터를 건드려 줘야 함.
                        //    for (int i = 0; i < this.layDeletedData.RowCount; i++)
                        //    {
                        //        this.layDeletedData.SetItemValue(i, "dummy", "mageshin");
                        //    }

                        //    if (this.layDeletedData.SaveLayout() == false)
                        //    {
                        //        Service.RollbackTransaction(); // 롤백

                        //        this.mbxMsg = XMsg.GetMsg("M005") + " - " + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...

                        //        MessageBox.Show(this.mbxMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //        return;
                        //    }

                        //    if (this.mInterface.InsertDeletedDataToTempTable() == false)
                        //    {
                        //    }

                        //    if (this.laySaveLayout.SaveLayout() == false)
                        //    {
                        //        Service.RollbackTransaction();  // 롤백

                        //        this.mbxMsg = XMsg.GetMsg("M005") + " - " + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...

                        //        MessageBox.Show(this.mbxMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //        return;
                        //    }
                        //    else
                        //    {
                        //        // 저장이 완료된 후에 NDAY 건을 처리하기 위하여 NDAY OCCUR YN 프로시져를 호출한다.
                        //        string procName = "PR_OCS_APPLY_NDAY_ORDER";
                        //        ArrayList inList = new ArrayList();
                        //        ArrayList outList = new ArrayList();

                        //        inList.Add(this.fbxBunho.GetDataValue());
                        //        inList.Add(mOrderDate);

                        //        if (Service.ExecuteProcedure(procName, inList, outList) == false)
                        //        {
                        //            Service.RollbackTransaction();  // 롤백

                        //            this.mbxMsg = XMsg.GetMsg("M005") + " - " + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...

                        //            MessageBox.Show(this.mbxMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //            return;
                        //        }
                        //        else
                        //        {
                        //            if (outList[0].ToString() != "0")
                        //            {
                        //                Service.RollbackTransaction();  // 롤백

                        //                this.mbxMsg = XMsg.GetMsg("M005") + " - " + outList[0].ToString();  // 저장에 실패하였습니다 + 에러메세지...

                        //                MessageBox.Show(this.mbxMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //                return;
                        //            }
                        //        }
                        //    }
                        //}
                        //catch
                        //{
                        //    Service.RollbackTransaction();
                        //}

                        //Service.CommitTransaction();  // 커밋
                        #endregion

                        // 삭제는 삭제전 먼저 태워야 한다.
                        if (this.mInterface.SendData(true, false) == false)
                        {
                            // 메세지 처리.
                        }

                        // 업데이트 
                        if (this.mInterface.SendData(false, true) == false)
                        {
                        }

                        if (this.mInterface.SendData(false, false) == false)
                        {
                            // 메세지 처리.
                        }

                        //this.mOrderBiz.PrintCPL(this.laySaveLayout, this.mPatientInfo.GetPatientInfo["bunho"].ToString(), mOrderDate, this.IOEGUBUN, this.mPatientInfo.GetPatientInfo["gwa"].ToString(), this.mPatientInfo.GetPatientInfo["doctor"].ToString());
                    }
                    //inser by jc [詳細画面での保存処理] END 2012/04/17
                    /* -------------------------------------------------------------------------------------------------- */

                    //MED-11162
                    if (!Utilities.CheckInventory(grdOrder.LayoutTable,true))
                    {
                        return;
                    }

                    this.InvokeReturnSendReturnDataTable();

                    if (mContainer != null && mContainer.Name != "OCS2015U00") this.mContainer.Close();

                    #endregion

                    break;

                case FunctionType.Delete:

                    if (mContainer != null) this.mContainer.AcceptData();

                    ArrayList deleteRow = new ArrayList();

                    for (int i = 0; i < this.grdOrder.RowCount; i++)
                    {
                        if (this.grdOrder.IsSelectedRow(i) && this.grdOrder.IsVisibleRow(i))
                        {
                            deleteRow.Add(i);
                        }
                    }

                    if (deleteRow.Count > 0)
                    {
                        for (int j = 0; j < deleteRow.Count; j++)
                        {
                            if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                                this.mOrderMode == OrderVariables.OrderMode.CpSetOrder ||
                                //modify by jc 選択された複数のオーダの削除する際のdeleteRowのインデックスの指定を修正
                                this.mHangmogInfo.IsOrderDataChagnedEnabled(IOEGUBUN, this.grdOrder, (int)deleteRow[j] - j, "", OrderVariables.CheckMode.RowDelete, OrderVariables.ErrorDisplayMode.MessageBox))
                            //this.mHangmogInfo.IsOrderDataChagnedEnabled(IOEGUBUN, this.grdOrder, (int)deleteRow[j], "", OrderVariables.CheckMode.RowDelete, OrderVariables.ErrorDisplayMode.MessageBox))
                            {
                                this.grdOrder.DeleteRow((int)deleteRow[j] - j);
                            }
                        }

                    }
                    else
                    {
                        if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                            this.mOrderMode == OrderVariables.OrderMode.CpSetOrder ||
                            this.mHangmogInfo.IsOrderDataChagnedEnabled(IOEGUBUN, this.grdOrder, this.grdOrder.CurrentRowNumber, "", OrderVariables.CheckMode.RowDelete, OrderVariables.ErrorDisplayMode.MessageBox))
                        {
                            if (this.grdOrder.IsVisibleRow(this.grdOrder.CurrentRowNumber))
                                this.grdOrder.DeleteRow(this.grdOrder.CurrentRowNumber);
                        }
                    }

                    this.grdOrder.UnSelectAll();

                    this.ReGroupingMix(0, this.grdOrder.RowCount - 1, false);

                    //this.tabGroup_SelectionChanged(this.tabGroup, new EventArgs());
                    this.DisplayOrderGridGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag);

                    this.MakePreviewStatus();

                    PostCallHelper.PostCall(new PostMethodInt(PostCallAfterDeleteRow), this.mOrderFunc.GetLastRow(this.grdOrder.LayoutTable, ((Hashtable)this.tabGroup.SelectedTab.Tag)["group_ser"].ToString()));

                    break;

                case FunctionType.Close:

                    if (mContainer != null) this.mContainer.AcceptData();
                    if (this.mOrderBiz.IsCloseOrderScreen(this.grdOrder))
                        if (mContainer != null) this.mContainer.Close();
                        else
                        {
                            return;
                        }
                    break;
            }
        }

        private void fbxBogyongCode_FindClick(object sender, CancelEventArgs e)
        {
            this.OPEN_DRG0208Q00();

            //if (this.tabGroup.SelectedTab == null) return;

            //Hashtable tabInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            //if (this.mOrderFunc.IsEmptyGroup(this.grdOrder, tabInfo["group_ser"].ToString()))
            //{
            //    MessageBox.Show(XMsg.GetMsg("M010"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //if (IsOutDrugGroup(tabInfo["group_ser"].ToString()))
            //    this.OpenScreen_OCS0208Q01("", this.fbxBogyongCode.GetDataValue(), "");
            //else
            //    this.OpenScreen_OCS0208Q00();

        }

        private void fbxBogyongCode_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (this.tabGroup.SelectedTab == null)
            {
                // 현재 선택된 그룹이 없는경우.
                // 그룹을 만들어버리자.

                HandleBtnListClick(FunctionType.Process);
            }

            Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            if (e.DataValue == "")
            {
                this.dbxBogyongName.SetDataValue("");

                this.ApplyGroupInfo("", "", "", this.cboNalsu.GetDataValue(), this.cbxEmergency.GetDataValue()
                                   , this.cbxWonyoiOrderYN.GetDataValue(), "", "");

                if (mContainer != null) this.mContainer.SetMsg("");

                // 외용 내복에 따른 그룹항목 visible Setting 
                this.SetGroupControlVisible(groupInfo["group_ser"].ToString());
                return;
            }

            string bogyongname = "";
            int dv = 0;
            string donbogyn = "";

            if (this.mOrderBiz.GetBogyongInfo(e.DataValue, ref bogyongname, ref dv, ref donbogyn) == false)
            {
                //복용코드가 정확하지 않습니다.
                MessageBox.Show(XMsg.GetMsg("M003"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (mContainer != null) this.mContainer.SetMsg(XMsg.GetMsg("M003"), MsgType.Error);

                e.Cancel = true;
            }
            else
            {
                this.dbxBogyongName.SetDataValue(bogyongname);

                this.ApplyGroupInfo(e.DataValue, bogyongname, dv.ToString(), this.cboNalsu.GetDataValue()
                                   , this.cbxEmergency.GetDataValue(), this.cbxWonyoiOrderYN.GetDataValue(), donbogyn, "");

                if (mContainer != null) this.mContainer.SetMsg("");



                // 외용 내복에 따른 그룹항목 visible Setting 
                this.SetGroupControlVisible(groupInfo["group_ser"].ToString());

                PostCallHelper.PostCall(new PostMethod(PostBogyongCodeValidating));
            }

        }

        private void grdOrder_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;
            string dv = "";

            if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                this.mOrderMode == OrderVariables.OrderMode.CpSetOrder)
            {
                if (!((XEditGridCell)grd.CellInfos[e.ColName]).IsUpdatable &&
                    (grd.GetRowState(e.RowNumber) == DataRowState.Unchanged || grd.GetRowState(e.RowNumber) == DataRowState.Modified) ||
                    (((XEditGridCell)grd.CellInfos[e.ColName]).IsReadOnly) ||
                    (this.mInputControl.IsProtectedColumn(grd.GetItemValue(e.RowNumber, "input_control").ToString(), e.ColName)) ||
                    !this.mHangmogInfo.IsFieldChagnedEnabled(IOEGUBUN, grd, e.RowNumber, e.ColName))
                {
                    e.BackColor = OrderVariables.DisplayFieldColor.Color;
                }
            }
            else
            {
                if (!((XEditGridCell)grd.CellInfos[e.ColName]).IsUpdatable &&
                    (grd.GetRowState(e.RowNumber) == DataRowState.Unchanged || grd.GetRowState(e.RowNumber) == DataRowState.Modified) ||
                    (((XEditGridCell)grd.CellInfos[e.ColName]).IsReadOnly) ||
                    (this.mInputControl.IsProtectedColumn(grd.GetItemValue(e.RowNumber, "input_control").ToString(), e.ColName)) ||
                    !this.mHangmogInfo.IsFieldChagnedEnabled(IOEGUBUN, grd, e.RowNumber, e.ColName) ||
                    !this.mHangmogInfo.IsOrderDataChagnedEnabled(IOEGUBUN, grd, e.RowNumber, e.ColName, OrderVariables.CheckMode.Protected, OrderVariables.ErrorDisplayMode.NoDisplay))
                {
                    e.BackColor = OrderVariables.DisplayFieldColor.Color;
                }
            }

            //画面にオーダ区分カラムを院内採用薬色に変更
            //if (e.ColName == "order_gubun_name" && this.grdOrder.GetItemString(e.RowNumber, "wonnae_drg_yn") == "Y")
            //{
            //    e.BackColor = Color.Khaki;
            //    cbxWonyoiOrderYN.Checked = false;
            //    isUncheckOutHosp = true;
            //}
            //else
            //{
            //    if(!isUncheckOutHosp) cbxWonyoiOrderYN.Checked = true;
            //}
            if (e.ColName == "order_gubun_name" && this.grdOrder.GetItemString(e.RowNumber, "wonnae_drg_yn") == "Y")            
                e.BackColor = Color.Khaki;
            this.mHangmogInfo.ColumnColorForOrderState(IOEGUBUN, grd, e); // 처방상태에 따른 색상 처리

            dv = grd.GetItemString(e.RowNumber, "dv");

            // 공통 이외의 DV 처리
            switch (e.ColName)
            {
                case "dv_1":
                    if (this.IsOutDrugGroup(grd.GetItemString(e.RowNumber, "group_ser")) || grd.GetItemString(e.RowNumber, "donbog_yn") == "Y")
                        e.BackColor = OrderVariables.DisplayFieldColor.Color;
                    break;
                case "dv_2":
                    if (this.IsOutDrugGroup(grd.GetItemString(e.RowNumber, "group_ser")) || grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt(dv) == false)
                    {
                        e.BackColor = OrderVariables.DisplayFieldColor.Color;
                    }
                    else
                    {
                        if (int.Parse(dv) < 2)
                        {
                            e.BackColor = OrderVariables.DisplayFieldColor.Color;
                            if (this.grdOrder.GetItemString(e.RowNumber, e.ColName) != "")
                                this.grdOrder.SetItemValue(e.RowNumber, e.ColName, "");
                        }
                    }
                    break;
                case "dv_3":
                    if (this.IsOutDrugGroup(grd.GetItemString(e.RowNumber, "group_ser")) || grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt(dv) == false)
                    {
                        e.BackColor = OrderVariables.DisplayFieldColor.Color;
                    }
                    else
                    {
                        if (int.Parse(dv) < 3)
                        {
                            e.BackColor = OrderVariables.DisplayFieldColor.Color;
                            if (this.grdOrder.GetItemString(e.RowNumber, e.ColName) != "")
                                this.grdOrder.SetItemValue(e.RowNumber, e.ColName, "");
                        }
                    }
                    break;
                case "dv_4":
                    if (this.IsOutDrugGroup(grd.GetItemString(e.RowNumber, "group_ser")) || grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt(dv) == false)
                    {
                        e.BackColor = OrderVariables.DisplayFieldColor.Color;
                    }
                    else
                    {
                        if (int.Parse(dv) < 4)
                        {
                            e.BackColor = OrderVariables.DisplayFieldColor.Color;
                            if (this.grdOrder.GetItemString(e.RowNumber, e.ColName) != "")
                                this.grdOrder.SetItemValue(e.RowNumber, e.ColName, "");
                        }
                    }
                    break;

                //2012/12/10
                case "dv_5":
                    if (this.IsOutDrugGroup(grd.GetItemString(e.RowNumber, "group_ser")) || grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt(dv) == false)
                    {
                        e.BackColor = OrderVariables.DisplayFieldColor.Color;
                    }
                    else
                    {
                        if (int.Parse(dv) < 5)
                        {
                            e.BackColor = OrderVariables.DisplayFieldColor.Color;
                            if (this.grdOrder.GetItemString(e.RowNumber, e.ColName) != "")
                                this.grdOrder.SetItemValue(e.RowNumber, e.ColName, "");
                        }
                    }
                    break;
                case "dv_6":
                    if (this.IsOutDrugGroup(grd.GetItemString(e.RowNumber, "group_ser")) || grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt(dv) == false)
                    {
                        e.BackColor = OrderVariables.DisplayFieldColor.Color;
                    }
                    else
                    {
                        if (int.Parse(dv) < 6)
                        {
                            e.BackColor = OrderVariables.DisplayFieldColor.Color;
                            if (this.grdOrder.GetItemString(e.RowNumber, e.ColName) != "")
                                this.grdOrder.SetItemValue(e.RowNumber, e.ColName, "");
                        }
                    }
                    break;
                case "dv_7":
                    if (this.IsOutDrugGroup(grd.GetItemString(e.RowNumber, "group_ser")) || grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt(dv) == false)
                    {
                        e.BackColor = OrderVariables.DisplayFieldColor.Color;
                    }
                    else
                    {
                        if (int.Parse(dv) < 7)
                        {
                            e.BackColor = OrderVariables.DisplayFieldColor.Color;
                            if (this.grdOrder.GetItemString(e.RowNumber, e.ColName) != "")
                                this.grdOrder.SetItemValue(e.RowNumber, e.ColName, "");
                        }
                    }
                    break;
                case "dv_8":
                    if (this.IsOutDrugGroup(grd.GetItemString(e.RowNumber, "group_ser")) || grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt(dv) == false)
                    {
                        e.BackColor = OrderVariables.DisplayFieldColor.Color;
                    }
                    else
                    {
                        if (int.Parse(dv) < 8)
                        {
                            e.BackColor = OrderVariables.DisplayFieldColor.Color;
                            if (this.grdOrder.GetItemString(e.RowNumber, e.ColName) != "")
                                this.grdOrder.SetItemValue(e.RowNumber, e.ColName, "");
                        }
                    }
                    break;
                case "jundal_part":
                    //if (e.DataRow["jundal_part"].ToString() != "")
                    //{

                    //    if (this.grdOrder.GetItemString(e.RowNumber, "jundal_part_name") == "")
                    //    {
                    //        string cmd = "SELECT FN_BAS_LOAD_JUNDAL_PART_NAME(:f_io_gubun, :f_gwa, :f_order_date) FROM SYS.DUAL";
                    //        BindVarCollection bind = new BindVarCollection();
                    //        bind.Add("f_io_gubun", IOEGUBUN);
                    //        bind.Add("f_order_date", mOrderDate);
                    //        bind.Add("f_gwa", e.DataRow["jundal_part"].ToString());

                    //        object obj = Service.ExecuteScalar(cmd, bind);

                    //        this.grdOrder.SetItemValue(e.RowNumber, "jundal_part_name", obj.ToString());

                    //    }
                    //}

                    break;

            }

           // if (!isUncheckOutHosp) cbxWonyoiOrderYN.Checked = true;
        }

        private void grdOrder_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            if (e.ColName == "powder_yn")
            {

            }
            // InputControl별 필드 입력불가 제어
            // 처방 Field DataChange 가능여부 체크 입력불가 제어
            if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                this.mOrderMode == OrderVariables.OrderMode.CpSetOrder)
            {
                if (this.mInputControl.IsProtectedColumn(grd.GetItemValue(e.RowNumber, "input_control").ToString(), e.ColName) ||
                    !this.mHangmogInfo.IsFieldChagnedEnabled(IOEGUBUN, grd, e.RowNumber, e.ColName))
                    e.Protect = true;
            }
            else
            {
                if (this.mInputControl.IsProtectedColumn(grd.GetItemValue(e.RowNumber, "input_control").ToString(), e.ColName) ||
                    !this.mHangmogInfo.IsFieldChagnedEnabled(IOEGUBUN, grd, e.RowNumber, e.ColName) ||
                    //!this.mHangmogInfo.IsOrderDataChagnedEnabled(IOEGUBUN, grd, e.RowNumber, e.ColName, OrderVariables.CheckMode.Protected, OrderVariables.ErrorDisplayMode.NoDisplay))
                    !this.mHangmogInfo.IsOrderDataChagnedEnabled(IOEGUBUN, grd, e.RowNumber, e.ColName, OrderVariables.CheckMode.Protected, OrderVariables.ErrorDisplayMode.NoDisplay) ||
                    //insert by jc [CellのWidthが０である場合はProtectを掛けてカーソルが行っても反応しないようにするため] 2012/02/20
                    this.grdOrder[e.RowNumber, e.ColName].AbsoluteRectangle.Width == 0)
                    e.Protect = true;
            }

            string dv = grd.GetItemString(e.RowNumber, "dv");

            // 공통 이외의 DV 처리
            switch (e.ColName)
            {
                case "dv_1":
                    if (this.IsOutDrugGroup(grd.GetItemString(e.RowNumber, "group_ser")) || grd.GetItemString(e.RowNumber, "donbog_yn") == "Y")
                        e.Protect = true;
                    break;
                case "dv_2":
                    if (this.IsOutDrugGroup(grd.GetItemString(e.RowNumber, "group_ser")) || grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt(dv) == false)
                        e.Protect = true;
                    else
                    {
                        if (int.Parse(dv) < 2)
                            e.Protect = true;
                    }
                    break;
                case "dv_3":
                    if (this.IsOutDrugGroup(grd.GetItemString(e.RowNumber, "group_ser")) || grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt(dv) == false)
                        e.Protect = true;
                    else
                    {
                        if (int.Parse(dv) < 3)
                            e.Protect = true;
                    }
                    break;
                case "dv_4":
                    if (this.IsOutDrugGroup(grd.GetItemString(e.RowNumber, "group_ser")) || grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt(dv) == false)
                        e.Protect = true;
                    else
                    {
                        if (int.Parse(dv) < 4)
                            e.Protect = true;
                    }
                    break;

                //2012/12/10
                case "dv_5":
                    if (this.IsOutDrugGroup(grd.GetItemString(e.RowNumber, "group_ser")) || grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt(dv) == false)
                        e.Protect = true;
                    else
                    {
                        if (int.Parse(dv) < 5)
                            e.Protect = true;
                    }
                    break;
                case "dv_6":
                    if (this.IsOutDrugGroup(grd.GetItemString(e.RowNumber, "group_ser")) || grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt(dv) == false)
                        e.Protect = true;
                    else
                    {
                        if (int.Parse(dv) < 6)
                            e.Protect = true;
                    }
                    break;
                case "dv_7":
                    if (this.IsOutDrugGroup(grd.GetItemString(e.RowNumber, "group_ser")) || grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt(dv) == false)
                        e.Protect = true;
                    else
                    {
                        if (int.Parse(dv) < 7)
                            e.Protect = true;
                    }
                    break;
                case "dv_8":
                    if (this.IsOutDrugGroup(grd.GetItemString(e.RowNumber, "group_ser")) || grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt(dv) == false)
                        e.Protect = true;
                    else
                    {
                        if (int.Parse(dv) < 8)
                            e.Protect = true;
                    }
                    break;

            }
        }

        private void grdOrder_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            switch (e.ColName)
            {
                case "hangmog_code":     // 항목코드 

                    e.Cancel = true; // 별도의 화면 오픈 

                    if (mOrderDate == "")
                    {
                        return;
                    }

                    this.OpenScreen_OCS0103Q00(grid.GetItemString(e.RowNumber, e.ColName), true); // 화면오픈
                    
                    ProcessCheckKinki();
                    ActionCheckOutHosp();

                    break;

                case "ord_danui_name":  // 오더단위

                    //((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker(e.ColName, grid.GetItemString(e.RowNumber, "hangmog_code"));

                    // https://sofiamedix.atlassian.net/browse/MED-9500
                    ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker =
                        LoadFindWorker(e.ColName, grid.GetItemString(e.RowNumber, "hangmog_code"));

                    break;

                case "jundal_part": // 전달파트

                    // 외래 전달 파트 
                    if (this.IOEGUBUN == "O")
                    {
                        //((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_out_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                        ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker =
                            LoadFindWorker("jundal_part_out_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));
                    }
                    // 입원 전달파트 
                    else
                    {
                        //((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_inp_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                        ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker =
                            LoadFindWorker("jundal_part_inp_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));
                    }

                    break;

                case "jundal_part_out": // 전달파트 외래

                    // ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_out_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                    ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker =
                        LoadFindWorker("jundal_part_out_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                    break;

                case "jundal_part_inp": // 전달파트 입원

                    // ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_inp_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                    ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker =
                        LoadFindWorker("jundal_part_inp_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                    break;

                case "bogyong_code_sub":

                    e.Cancel = false;

                    //if (grid.GetItemString(e.RowNumber, "hangmog_code") != "" && grid.GetItemString(e.RowNumber, "input_control") == "A")
                    if (grid.GetItemString(e.RowNumber, "hangmog_code") != "")
                    {
                        this.OpenScreen_CHT0117Q00(grid.GetItemString(e.RowNumber, "order_gubun_bas"));
                    }
                    break;
            }
        }

        private XFindWorker LoadFindWorker(string colName, string argu1)
        {
            XFindWorker fdwTemp = new XFindWorker();
            fdwTemp.AutoQuery = true;
            fdwTemp.SearchImeMode = System.Windows.Forms.ImeMode.NoControl;
            fdwTemp.ParamList = new List<string>(new String[] { "colName", "argu1" });
            fdwTemp.SetBindVarValue("colName", colName);
            fdwTemp.SetBindVarValue("argu1", argu1);
            fdwTemp.ExecuteQuery = LoadDataFdwTemp;

            switch (colName)
            {
                case "ord_danui_name":
                    fdwTemp.ColInfos.Add("ord_danui_name", Resources.XMsg_000029, FindColType.String, 100, 0, true, FilterType.Yes);
                    fdwTemp.ColInfos.Add("ord_danui", Resources.XMsg_000030, FindColType.String, 100, 0, true, FilterType.Yes);
                    break;
                case "jundal_part_out_hangmog":
                    fdwTemp.ColInfos.Add("gwa", Resources.XMsg_000031, FindColType.String, 100, 0, true, FilterType.Yes);
                    fdwTemp.ColInfos.Add("gwa_name", Resources.XMsg_000032, FindColType.String, 300, 0, true, FilterType.No);
                    break;
                case "jundal_part_inp_hangmog":
                    fdwTemp.ColInfos.Add("gwa", Resources.XMsg_000031, FindColType.String, 100, 0, true, FilterType.Yes);
                    fdwTemp.ColInfos.Add("gwa_name", Resources.XMsg_000032, FindColType.String, 300, 0, true, FilterType.No);
                    break;
                default:
                    break;
            }

            return fdwTemp;
        }

        private IList<object[]> LoadDataFdwTemp(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            GetFindWorkerArgs args = new GetFindWorkerArgs();
            GetFindWorkerRequestInfo info = new GetFindWorkerRequestInfo(varlist["colName"].VarValue, varlist["argu1"].VarValue, "", "");
            args.Info1 = info;
            GetFindWorkerResult result = CloudService.Instance.Submit<GetFindWorkerResult, GetFindWorkerArgs>(args);
            if (result != null && result.Info1 != null && result.Info1.Count > 0)
            {
                switch (varlist["colName"].VarValue)
                {
                    case "ord_danui_name":
                        foreach (GetFindWorkerResponseInfo infoC1 in result.Info1)
                        {
                            dataList.Add(new object[]
                            {
                                infoC1.Name,
                                infoC1.Code
                            });
                        }
                        break;

                    case "jundal_part_out_hangmog":
                        foreach (GetFindWorkerResponseInfo infoC1 in result.Info1)
                        {
                            dataList.Add(new object[]
                            {
                                infoC1.Code,
                                infoC1.Name
                            });
                        }
                        break;

                    case "jundal_part_inp_hangmog":
                        foreach (GetFindWorkerResponseInfo infoC1 in result.Info1)
                        {
                            dataList.Add(new object[]
                            {
                                infoC1.Code,
                                infoC1.Name
                            });
                        }
                        break;
                }
            }
            return dataList;
        }

        private void grdOrder_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            string hangmog_code = grid.GetItemString(e.RowNumber, "hangmog_code").Trim();  // 항목코드

            // 이전값을 버퍼로 셋팅
            object previousValue = grid.GetItemValue(e.RowNumber, e.ColName, DataBufferType.PreviousBuffer);

            //// 오더가 아닌경우 오더코드가 입력되지 않았다면 메세지 처리
            //if (e.ColName != "hangmog_code" && grid.GetItemString(e.RowNumber, "hangmog_code") == "")
            //{
            //    MessageBox.Show(XMsg.GetMsg("M004"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    this.mOrderFunc.UndoPreviousValue(grid, e.RowNumber, e.ColName, previousValue); // 이전값으로 되돌린다.
            //}

            ////////////////////// 필드 Validation 및 Value Setting 공통모듈 Call ///////////////////
            // 항목을 제외한 다른 컬럼들의 일반적 validation 은 이안에서 기술한다.                 //
            if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                this.mOrderMode == OrderVariables.OrderMode.CpSetOrder)
            {
                if (!this.mHangmogInfo.ColumnChanged(IOEGUBUN, grid, e)) return;
            }
            else
            {
                if (!this.mHangmogInfo.ColumnChanged(IOEGUBUN, this.mPatientInfo.GetPatientInfo["bunho"].ToString(), this.mPatientInfo.GetPatientInfo["naewon_date"].ToString(), grid, e)) return;
            }
            /////////////////////////////////////////////////////////////////////////////////////////

            switch (e.ColName)
            {
                case "hangmog_code":    // 오더코드 

                    #region 오더코드

                    hangmog_code = e.ChangeValue.ToString().TrimEnd();

                    if (TypeCheck.IsNull(hangmog_code))
                    {
                        this.mOrderFunc.UndoPreviousValue(grid, e.RowNumber, e.ColName, previousValue);   // 이전값으로 되돌린다.
                        return;
                    }

                    this.mHangmogInfo.Parameter.Clear();
                    this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
                    this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
                    this.mHangmogInfo.Parameter.InputGubun = this.mInputGubun;
                    this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
                    this.mHangmogInfo.Parameter.IOEGubun = this.IOEGUBUN;
                    this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;

                    if (this.mOrderMode == OrderVariables.OrderMode.InpOrder)
                        this.mHangmogInfo.Parameter.Ho_dong = this.mPatientInfo.GetPatientInfo["ho_dong"].ToString();

                    this.mHangmogInfo.Parameter.Wonyoi_Order_Yn_Wonmu = this.cbxWonyoiOrderYN.GetDataValue();

                    if (this.mGeneral_disp_yn == "Y" && this.mOrderBiz.IsGeneralYN(hangmog_code) != "")
                        this.mHangmogInfo.Parameter.GenericSearchYN = "Y";
                    else
                        this.mHangmogInfo.Parameter.GenericSearchYN = this.mGenericSearchYN;

                    if (this.rbtGenericSearch.Checked == true || this.mHangmogInfo.Parameter.GenericSearchYN == "Y")
                        this.mHangmogInfo.Parameter.Generic_name = this.mOrderBiz.IsGeneralYN(hangmog_code);

                    if (this.mOrderMode != OrderVariables.OrderMode.SetOrder && this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
                    {
                        this.mHangmogInfo.Parameter.Bunho = this.mPatientInfo.GetPatientInfo["bunho"].ToString();
                        this.mHangmogInfo.Parameter.NaewonKey = this.mPatientInfo.GetPatientInfo["naewon_key"].ToString();
                        this.mHangmogInfo.Parameter.Gubun = this.mPatientInfo.GetPatientInfo["gubun"].ToString();
                        this.mHangmogInfo.Parameter.Birth_Date = this.mPatientInfo.GetPatientInfo["birth"].ToString();
                        this.mHangmogInfo.Parameter.Gwa = this.mPatientInfo.GetPatientInfo["gwa"].ToString();
                        this.mHangmogInfo.Parameter.ApproveDoctor = this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString();

                    }

                    #region 그룹정보 및 항목코드 셋팅

                    MultiLayout loadExtraInfo = new MultiLayout();

                    loadExtraInfo.LayoutItems.Add("hangmog_code", DataType.String);
                    loadExtraInfo.LayoutItems.Add("group_ser", DataType.String);
                    loadExtraInfo.LayoutItems.Add("bogyong_code", DataType.String);
                    loadExtraInfo.LayoutItems.Add("dv", DataType.String);
                    loadExtraInfo.LayoutItems.Add("emergency", DataType.String);
                    loadExtraInfo.LayoutItems.Add("wonyoi_order_yn", DataType.String);
                    loadExtraInfo.InitializeLayoutTable();

                    Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

                    loadExtraInfo.InsertRow(-1);
                    // 항목정보
                    loadExtraInfo.SetItemValue(0, "hangmog_code", e.ChangeValue.ToString());
                    // 그룹정보 로드
                    // 그룹시리얼
                    if (groupInfo.Contains("group_ser"))
                    {
                        loadExtraInfo.SetItemValue(0, "group_ser", groupInfo["group_ser"].ToString());
                    }
                    // 복용코드
                    if (groupInfo.Contains("bogyong_code"))
                    {
                        loadExtraInfo.SetItemValue(0, "bogyong_code", groupInfo["bogyong_code"].ToString());
                    }
                    // DV
                    if (groupInfo.Contains("dv"))
                    {
                        loadExtraInfo.SetItemValue(0, "dv", groupInfo["dv"].ToString());
                    }
                    // Emergency
                    if (groupInfo.Contains("emergency"))
                    {
                        loadExtraInfo.SetItemValue(0, "emergency", groupInfo["emergency"].ToString());
                    }
                    // 원외처방여부
                    if (groupInfo.Contains("wonyoi_order_yn"))
                    {
                        loadExtraInfo.SetItemValue(0, "wonyoi_order_yn", groupInfo["wonyoi_order_yn"].ToString());
                    }

                    #endregion

                    if (this.mHangmogInfo.LoadHangmogInfo(HangmogInfo.ExecutiveMode.CodeInput, loadExtraInfo) == false)
                    {
                        this.mOrderFunc.UndoPreviousValue(grid, e.RowNumber, e.ColName, previousValue);
                        //this.grdOrder.SetItemValue(e.RowNumber, "hangmog_name", "");
                        this.OpenScreen_OCS0103Q00(e.ChangeValue.ToString(), true);
                        return;
                    }

                    this.ApplyDefaultOrderInfo(HangmogInfo.ExecutiveMode.CodeInput, this.mHangmogInfo.GetHangmogInfo, grid, e.RowNumber, true);

                    //this.tabGroup_SelectionChanged(this.tabGroup, new EventArgs());
                    this.DisplayOrderGridGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag);

                    this.DisplayMixGroup(this.grdOrder);

                    this.SetOrderImage(this.grdOrder);

                    this.mFocusRow = e.RowNumber;

                    PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert));
                    
                    ProcessCheckKinki();
                    ActionCheckOutHosp();

                    #endregion

                    break;

                case "ord_danui":

                    string code = "";
                    string codename = "";

                    if (e.ChangeValue.ToString() == "")
                    {
                        this.mOrderBiz.GetDefaultOrdDanui(grid.GetItemString(e.RowNumber, "hangmog_code"), ref code, ref codename);

                    }
                    else
                    {
                    }

                    break;

                case "jundal_part":  // 전달 파트 
                case "jundal_part_out":
                case "jundal_part_inp":

                    // 전달 파트에 대한 벨리데이션은 라이브러리에서ㅓ 행하여 지고 여기서는
                    // 전달 파트 변경시 jundal_table과 무브파트를 변경해야 한다.
                    string jundalTable = "";
                    string movePart = "";

                    if (e.ColName == "jundal_part")
                    {
                        //insert by jc [HOMの場合は希望日を入れられない。] 
                        if (grid.GetItemString(e.RowNumber, "jundal_part") == "HOM")
                        {
                            grid.SetItemValue(e.RowNumber, "hope_date", "");
                            grid.SetItemValue(e.RowNumber, "hope_time", "");
                        }
                        //insert by jc MIXされたオーダは行為部署変更が不可能にする。MIX解除してからやり直すようにMSG表示。
                        string current_mix_group = grid.GetItemString(e.RowNumber, "mix_group");
                        if (current_mix_group != "")
                        {
                            XMessageBox.Show(Resources.XMsg_000022);
                            this.mOrderFunc.UndoPreviousValue(grid, e.RowNumber, e.ColName, previousValue);
                            return;
                        }

                        //if (this.mOrderBiz.GetJundaTable(this.IOEGUBUN, hangmog_code, grid.GetItemString(e.RowNumber, "order_date"), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)
                        if (this.mOrderBiz.GetJundaTable(this.IOEGUBUN, hangmog_code, TypeCheck.NVL(grid.GetItemString(e.RowNumber, "order_date"), mOrderDate.ToString()).ToString(), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)
                        {
                            grid.SetItemValue(e.RowNumber, "jundal_table", jundalTable);
                            grid.SetItemValue(e.RowNumber, "move_part", movePart);
                        }
                    }
                    else if (e.ColName == "jundal_part_out")
                    {
                        //if (this.mOrderBiz.GetJundaTable("O", hangmog_code, grid.GetItemString(e.RowNumber, "order_date"), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)
                        if (this.mOrderBiz.GetJundaTable("O", hangmog_code, TypeCheck.NVL(grid.GetItemString(e.RowNumber, "order_date"), mOrderDate.ToString()).ToString(), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)
                        {
                            grid.SetItemValue(e.RowNumber, "jundal_table_out", jundalTable);
                            grid.SetItemValue(e.RowNumber, "move_part_out", movePart);
                        }
                    }
                    else if (e.ColName == "jundal_part_inp")
                    {
                        //if (this.mOrderBiz.GetJundaTable("I", hangmog_code, grid.GetItemString(e.RowNumber, "order_date"), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)
                        if (this.mOrderBiz.GetJundaTable("I", hangmog_code, TypeCheck.NVL(grid.GetItemString(e.RowNumber, "order_date"), mOrderDate.ToString()).ToString(), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)
                        {
                            grid.SetItemValue(e.RowNumber, "jundal_table_inp", jundalTable);
                            grid.SetItemValue(e.RowNumber, "move_part_inp", movePart);
                        }
                    }

                    break;
                //inser by jc [一般名に変更できる項目であれば一般名に変更する。] 2012/11/01

                //case "general_disp_yn":
                //    if (grid.GetItemString(e.RowNumber, "general_disp_yn") == "Y")
                //    {
                //        string generic_name = mHangmogInfo.GetGenericName(grid.GetItemString(e.RowNumber, "hangmog_code"));

                //        if (generic_name != "")
                //        {
                //            grid.SetItemValue(e.RowNumber, "hangmog_name", generic_name);
                //        }
                //    }
                //    else
                //    {
                //        string hangmog_name = mHangmogInfo.GetHangmogName(grid.GetItemString(e.RowNumber, "hangmog_code"));

                //        if (hangmog_name != "")
                //        {
                //            grid.SetItemValue(e.RowNumber, "hangmog_name", hangmog_name);
                //        }
                //    }
                //    break;

                //case "hubal_change_yn":
                //    if (grid.GetItemString(e.RowNumber, "hubal_change_yn") == "Y")
                //    {
                //        grid.SetItemValue(e.RowNumber, "general_disp_yn", "N");

                //        string hangmog_name = mHangmogInfo.GetHangmogName(grid.GetItemString(e.RowNumber, "hangmog_code"));

                //        if (hangmog_name != "")
                //        {
                //            grid.SetItemValue(e.RowNumber, "hangmog_name", hangmog_name);
                //        }
                //    }
                //    break;
                case "dv":
                    if (e.DataRow["donbog_yn"].ToString() == "Y")
                    {
                        Hashtable tabInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

                        if (tabInfo.Contains("dv"))
                            tabInfo.Remove("dv");

                        tabInfo.Add("dv", e.ChangeValue.ToString());

                    }
                    break;

                    //MED-9994
                case "ord_danui_name":
                    //Fix bug MED 9565
                    string order_code = grdOrder.GetItemString(e.RowNumber, "ord_danui_name");
                    GetFindWorkerArgs args = new GetFindWorkerArgs();
                    args.Info1 = new IHIS.CloudConnector.Contracts.Models.Ocs.Lib.GetFindWorkerRequestInfo();
                    args.Info1.Colname = "ord_danui_name";
                    args.Info1.Argu1 = hangmog_code;
                    args.Info1.Argu2 = "";
                    args.Info1.Argu3 = "";
                    GetFindWorkerResult res = CloudService.Instance.Submit<GetFindWorkerResult, GetFindWorkerArgs>(args, true);
                    if (res != null)
                    {
                        foreach (GetFindWorkerResponseInfo item in res.Info1)
                        {
                            if (item.Code != order_code && item.Name != order_code)
                            {
                                XMessageBox.Show(Resources.XMsg_000033, Resources.Cap_000033, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                grdOrder.SetItemValue(e.RowNumber, "ord_danui_name", "");
                            }
                            else if (item.Code == order_code || item.Name == order_code)
                            {
                                grdOrder.SetItemValue(e.RowNumber, "ord_danui_name", item.Name);
                            }
                        }
                    }
                    break;

            }

            //this.ReGroupingMix(0, this.grdOrder.RowCount - 1, false);

            this.SetMixOrderValue(grid, e.RowNumber, e.ColName, e.ChangeValue.ToString());

            this.MakePreviewStatus();
        }

        private void grdOrder_Click(object sender, EventArgs e)
        {
            // 포커스가 왔을때 아무것도 입력이 되어 있지 않다면 
            // 신규로우를 하나 자동으로 생성한다.
            if (this.tabGroup.SelectedTab != null)
            {
                DataRow[] dr = this.grdOrder.LayoutTable.Select("group_ser=" + ((Hashtable)this.tabGroup.SelectedTab.Tag)["group_ser"].ToString());
                if (dr.Length <= 0)
                {
                    HandleBtnListClick(FunctionType.Insert);
                }
            }
        }

        private void grdOrder_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                int columnNumber = -1;
                string columnName = "";
                int curRowIndex = -1;
                XEditGrid grd = sender as XEditGrid;
                this.mUnEvenList = new ArrayList();
                ArrayList aSourceList = new ArrayList();

                curRowIndex = grd.GetHitRowNumber(e.Y);

                if (e.Button == MouseButtons.Right && e.Clicks == 1)
                {
                    this.grdOrder.SetFocusToItem(curRowIndex, "hangmog_name");
                    popupOrderMenu.TrackPopup(grd.PointToScreen(new Point(e.X, e.Y)));
                }
                if (e.Button == MouseButtons.Left && e.Clicks == 1 && curRowIndex >= 0 && grd.GetItemString(curRowIndex, "dv_time") == "/")
                {
                    if (grd.CurrentColName == "dv_1" ||
                        grd.CurrentColName == "dv_2" ||
                        grd.CurrentColName == "dv_3" ||
                        grd.CurrentColName == "dv_4" ||
                        grd.CurrentColName == "dv_5" ||
                        grd.CurrentColName == "dv_6" ||
                        grd.CurrentColName == "dv_7" ||
                        grd.CurrentColName == "dv_8")
                    {
                        int dv = int.Parse(grd.GetItemString(curRowIndex, "dv"));
                        if (dv > 8)
                        {
                            this.grdOrder.SetItemValue(curRowIndex, "dv", 8);
                            dv = int.Parse(grd.GetItemString(curRowIndex, "dv"));
                        }
                        if (grd.GetItemString(curRowIndex, "bogyong_code") != "" && dv > 0)
                        {
                            for (int i = 0; i < dv - 1; i++)
                            {
                                //MED-15013
                                this.grdOrder.AutoSizeColumn(i + 16, 30); // dv_i+2
                                //this.grdOrder.AutoSizeColumn(i + 18, 30); // dv_2                               
                                //this.grdOrder.AutoSizeColumn(17, 30); // dv_2
                                //this.grdOrder.AutoSizeColumn(18, 30); // dv_3
                                //this.grdOrder.AutoSizeColumn(19, 30); // dv_4
                                //this.grdOrder.AutoSizeColumn(20, 30); // dv_5
                                //this.grdOrder.AutoSizeColumn(21, 30); // dv_6
                                //this.grdOrder.AutoSizeColumn(22, 30); // dv_7
                                //this.grdOrder.AutoSizeColumn(23, 30); // dv_8
                            }
                            this.grdOrder.Refresh();

                            if ((grd.GetItemString(curRowIndex, "sunab_yn") != "Y" || grd.GetItemString(curRowIndex, "sunab_date") == ""))
                            {
                                for (int i = 0; i < dv; i++)
                                {
                                    columnNumber = (i + 1);
                                    columnName = "dv_" + columnNumber.ToString();
                                    aSourceList.Add(grd.GetItemString(curRowIndex, columnName));
                                }
                                this.mUnEvenList = this.mCommonForms.FormUnevenPrescribe(grd);
                            }
                            else
                                return;
                        }
                        else
                            XMessageBox.Show(Resources.XMsg_000023);

                        if (this.mUnEvenList != null)
                        {
                            if (this.mUnEvenList.Count > 0)
                            {
                                for (int i = 0; i < this.mUnEvenList.Count - 1; i++) //最後の行に数量が入ってるために（-1）する。
                                {
                                    columnNumber = (i + 1);
                                    columnName = "dv_" + columnNumber.ToString();
                                    grd.SetItemValue(grd.CurrentRowNumber, columnName, this.mUnEvenList[i].ToString());
                                }
                                //数量
                                grd.SetItemValue(grd.CurrentRowNumber, "suryang", this.mUnEvenList[8].ToString());

                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void grdOrder_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            // Drag시에 Cursor 바꿈
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                Cursor.Current = DragHelper.DragCursor;
            }
        }

        private void grdOrder_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;  // Move 표시	
        }

        private void grdOrder_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string data = e.Data.GetData("System.String").ToString();
                string gubun = data.Split('|')[0];
                string sourceRow = data.Split('|')[1];
                string hangmogCode = "";

                int rowNumber = grdOrder.GetHitRowNumber(e.Y);

                if (TypeCheck.IsInt(sourceRow) == false)
                {
                    return;
                }

                if (this.tabGroup.SelectedTab == null)
                {
                    HandleBtnListClick(FunctionType.Process);
                }

                switch (gubun)
                {
                    case "Drug":

                        hangmogCode = this.grdDrgOrder.GetItemString(int.Parse(sourceRow), "hangmog_code");

                        this.ApplySangOrderInfo(hangmogCode, rowNumber, false, mGenericSearchYN);

                        PostCallHelper.PostCall(new PostMethod(PostOrderInsert));

                        break;

                    case "Search":

                        hangmogCode = this.mSelectedGRD.GetItemString(int.Parse(sourceRow), "hangmog_code");

                        this.ApplySangOrderInfo(hangmogCode, rowNumber, false, mGenericSearchYN);

                        PostCallHelper.PostCall(new PostMethod(PostOrderInsert));

                        break;

                    case "SangYong":

                        hangmogCode = this.grdSangyongOrder.GetItemString(int.Parse(sourceRow), "hangmog_code");

                        this.ApplySangOrderInfo(hangmogCode, rowNumber, false, mGenericSearchYN);

                        PostCallHelper.PostCall(new PostMethod(PostOrderInsert));


                        break;
                }

                ProcessCheckKinki();
                ActionCheckOutHosp();
            }
            catch (Exception ex)
            {
                Service.WriteLog("Exception in grdOrder_DragDrop function: " + ex.StackTrace);
            }
        }        
        private void ActionCheckOutHosp()
        {
            string id_groupser = "";

            Hashtable hs = (Hashtable)tabGroup.SelectedTab.Tag;
            id_groupser = hs["group_ser"].ToString();

            DataTable dt = (DataTable)grdOrder.LayoutTable;
            if (dt != null && dt.Rows.Count > 0)
            {
                dt.DefaultView.RowFilter = "group_ser = '" + id_groupser + "'";
                dt = dt.DefaultView.ToTable();
                if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0]["wonnae_drg_yn"].ToString() == "N")
                    {
                        cbxWonyoiOrderYN.Checked = true;
                    }
                    else
                    {
                        cbxWonyoiOrderYN.Checked = false;
                    }
                }
                else
                {
                    dt = dt.DefaultView.ToTable(true, "wonnae_drg_yn");
                    if (dt.Rows.Count == 2)
                    {
                        cbxWonyoiOrderYN.Checked = false;
                    }
                    else
                    {
                        if (dt.Rows[0][0].ToString() == "N")
                        {                            
                             cbxWonyoiOrderYN.Checked = true;
                        }
                        else
                        {
                            cbxWonyoiOrderYN.Checked = false;
                        }
                    }
                }
            }

           



            //if (this.grdOrder.GetItemString(grdOrder.CurrentRowNumber, "wonnae_drg_yn") == "Y")
            //{
            //    cbxWonyoiOrderYN.Checked = false;
            //    //isCheckOut = false;
            //    for (int i = 0; i < grdOrder.RowCount; i++)
            //    {
            //        if (this.grdOrder.GetItemString(i, "wonnae_drg_yn") == "N")
            //        {
            //            cbxWonyoiOrderYN.Checked = false;
            //        }                    
            //    }               
            //}
            //else
            //{
            //    cbxWonyoiOrderYN.Checked = true;
            //    //isCheckOut = true;
            //    for (int i = 0; i < grdOrder.RowCount; i++)
            //    {
            //        if (this.grdOrder.GetItemString(i, "wonnae_drg_yn") == "Y")
            //        {
            //            cbxWonyoiOrderYN.Checked = false;
            //        }                   
            //    }                
            //}

            //if (!isUncheckOutHosp) cbxWonyoiOrderYN.Checked = true;
        }

        private void grdOrder_GridReservedMemoButtonClick(object sender, GridReservedMemoButtonClickEventArgs e)
        {
            if (sender == null) return;

            XEditGrid grd = sender as XEditGrid;

            CommonItemCollection loadParams;

            switch (e.ColName)
            {
                case "order_remark":

                    loadParams = new CommonItemCollection();
                    loadParams.Add("category_gubun", OrderVariables.CATEGORY_COMMENT); // 처방Comment
                    //loadParams.Add("remark_info", this.grdOrder.GetItemString(e.RowNumber, "order_remark")); // 

                    grd.SetReservedMemoControlLoadParam(e.ColName, loadParams);

                    break;
            }
        }

        private void grdSangyongOrder_MouseDown(object sender, MouseEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;
            int rowNumber = -1;
            //int applyRow = -1;

            rowNumber = grid.GetHitRowNumber(e.Y);

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                

                if (rowNumber < 0) return;

                this.btnSelect.PerformClick();

            }
            else if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                //Drag시 show info정보
                string dragInfo = "[" + grid.GetItemString(rowNumber, "hangmog_code") + "]" + grid.GetItemString(rowNumber, "hangmog_name");
                DragHelper.CreateDragCursor(grid, dragInfo, this.Font);
                grid.DoDragDrop("SangYong" + "|" + rowNumber.ToString(), DragDropEffects.Move);
            }
            else if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                if (rowNumber < 0) return;

                if (this.grdSangyongOrder.CurrentRowNumber != rowNumber)
                {
                    this.grdSangyongOrder.SetFocusToItem(rowNumber, 0);
                }

                //this.popupOftenUsedMenu.TrackPopup(grid.PointToScreen(new Point(e.X, e.Y)));
            }

        }

        private void grdSangyongOrder_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void grdSangyongOrder_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            // Drag시에 Cursor 바꿈
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                Cursor.Current = DragHelper.DragCursor;
            }
        }

        private void grdSangyongOrder_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            this.mColumnControl.ColumnColorForCodeQueryGrid(IOEGUBUN, grid, e);
        }

        private void grdDrgOrder_MouseDown(object sender, MouseEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;
            int rowNumber = -1;
            //int applyRow = -1;

            rowNumber = grid.GetHitRowNumber(e.Y);

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (rowNumber < 0) return;

                this.btnSelect.PerformClick();

            }
            else if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                //Drag시 show info정보
                string dragInfo = "[" + grid.GetItemString(rowNumber, "hangmog_code") + "]" + grid.GetItemString(rowNumber, "hangmog_name");
                DragHelper.CreateDragCursor(grid, dragInfo, this.Font);
                grid.DoDragDrop("Drug" + "|" + rowNumber.ToString(), DragDropEffects.Move);
            }
        }

        private void grdDrgOrder_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void grdDrgOrder_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            // Drag시에 Cursor 바꿈
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                Cursor.Current = DragHelper.DragCursor;
            }
        }

        private void grdDrgOrder_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            this.mColumnControl.ColumnColorForCodeQueryGrid(IOEGUBUN, grid, e);
        }

        private void grdSearchOrder_MouseDown(object sender, MouseEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;
            this.mSelectedGRD = grid;
            int rowNumber = -1;
            //int applyRow = -1;

            rowNumber = grid.GetHitRowNumber(e.Y);

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (rowNumber < 0) return;

                this.btnSelect.PerformClick();

            }
            else if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                //Drag시 show info정보
                string dragInfo = "[" + grid.GetItemString(rowNumber, "hangmog_code") + "]" + grid.GetItemString(rowNumber, "hangmog_name");
                DragHelper.CreateDragCursor(grid, dragInfo, this.Font);
                grid.DoDragDrop("Search" + "|" + rowNumber.ToString(), DragDropEffects.Move);
            }
        }

        private void grdSearchOrder_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void grdSearchOrder_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            // Drag시에 Cursor 바꿈
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                Cursor.Current = DragHelper.DragCursor;
            }
        }

        private void grdSearchOrder_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            this.mColumnControl.ColumnColorForCodeQueryGrid(IOEGUBUN, grid, e);
        }

        private void cboNalsu_DataValidating(object sender, DataValidatingEventArgs e)
        {
            string nalsu = e.DataValue;

            if (this.tabGroup.SelectedTab == null) return;

            //if (this.mOrderMode == OrderVariables.OrderMode.CpOrder &&
            //    TypeCheck.IsInt(nalsu) && int.Parse(nalsu) > 1)
            //{
            //    nalsu = "1";
            //    PostCallHelper.PostCall(new PostMethodStr(PostValidating), nalsu);
            //}

            this.ApplyGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag, "nalsu", nalsu, "", "", "");
        }

        private void cboQueryCon_SelectedValueChanged(object sender, EventArgs e)
        {
            this.txtSearch.Focus();
            this.Search_text();
            if (this.rbnOftenOrder.Checked == true)
                this.grdSangyongOrder.QueryLayout(true);
        }

        private void cbxWonyoiOrderYN_CheckedChanged(object sender, EventArgs e)
        {
            if (!isEnableGrd) return;
            //院内､院外処方同時防止機能
            if (this.tabGroup.TabCount > 1)
            {
                string firstGroupWonyoi_Yn = "";

                for (int i = 0; i < this.tabGroup.TabCount; i++)
                {
                    if (this.tabGroup.SelectedIndex != i)
                    {
                        firstGroupWonyoi_Yn = ((Hashtable)this.tabGroup.TabPages[i].Tag)["wonyoi_order_yn"].ToString();
                        break;
                    }
                }

                if (firstGroupWonyoi_Yn != this.cbxWonyoiOrderYN.GetDataValue())
                {
                    if (XMessageBox.Show(XMsg.GetMsg("M036"), XMsg.GetField("F001"), MessageBoxButtons.YesNo) == DialogResult.No)
                    //if (XMessageBox.Show(XMsg.GetMsg("M036"), XMsg.GetField("F001"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //if (this.cbxWonyoiOrderYN.GetDataValue() == "Y")
                        //    this.cbxWonyoiOrderYN.SetDataValue("N");
                        //else
                        //    this.cbxWonyoiOrderYN.SetDataValue("Y");
                        if (this.tabGroup.SelectedTab == null) return;
                        this.ApplyGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag, "wonyoi_order_yn", this.cbxWonyoiOrderYN.GetDataValue(), "", "", "");
                    }
                    else
                        this.HandleBtnChangeWonyoiClick();
                        if (parentControl != null)
                            parentControl.ChangWonyoi(cbxWonyoiOrderYN.GetDataValue());
                    return;
                }
            }
            if (this.tabGroup.SelectedTab == null) return;

            this.ApplyGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag, "wonyoi_order_yn", this.cbxWonyoiOrderYN.GetDataValue(), "", "", "");
        }

        private void cbxEmergency_CheckedChanged(object sender, EventArgs e)
        {
            if (!isEnableGrd) return;
            if (this.tabGroup.SelectedTab == null) return;

            if (this.mOrderBiz.IsAbleEmergencyCheck(this.cbxEmergency.GetDataValue(), ((Hashtable)this.tabGroup.SelectedTab.Tag), this.grdOrder.LayoutTable) == false)
            {
                PostCallHelper.PostCall(new PostMethodStr(this.PostEmergencyCheckedChangeFail), (this.cbxEmergency.GetDataValue() == "Y" ? "N" : "Y"));
            }
            else
            {
                this.ApplyGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag, "emergency", this.cbxEmergency.GetDataValue(), "", "", "");
            }
        }

        private void PostEmergencyCheckedChangeFail(string aOrgCheckedValue)
        {
            this.cbxEmergency.CheckedChanged -= new EventHandler(cbxEmergency_CheckedChanged);

            this.cbxEmergency.SetDataValue(aOrgCheckedValue);

            this.cbxEmergency.CheckedChanged += new EventHandler(cbxEmergency_CheckedChanged);
        }

        private void txtSearch_DataValidating(object sender, DataValidatingEventArgs e)
        {
            //if (e.DataValue == "") return;

            //string wonnaeDrgYn = "";

            //wonnaeDrgYn = this.cboQueryCon.GetDataValue();

            //if (this.rbnSearchOrder.Checked)
            //{
            //    this.LoadSearchOrderInfo(e.DataValue, mOrderDate, INPUTTAB, wonnaeDrgYn);
            //}
            //else if (this.rbnOftenOrder.Checked)
            //{
            //    if (this.tabSangyongOrder.SelectedTab != null)
            //    {
            //        Hashtable tabInfo = this.tabSangyongOrder.SelectedTab.Tag as Hashtable;

            //        this.LoadOftenUseOrder("1", tabInfo["memb"].ToString(), tabInfo["order_gubun"].ToString(), wonnaeDrgYn, e.DataValue);
            //    }
            //}
            //else if (this.rbnDrgOrder.Checked)
            //{
            //    this.LoadDrgOrder("2", "%", wonnaeDrgYn, e.DataValue);
            //}

            //PostCallHelper.PostCall(new PostMethod(PostSearchValidating));

        }

        ////insert by jc

        //private void PostSearchValidating()
        //{
        //    this.txtSearch.SetDataValue("");
        //}

        public override object Command(string command, CommonItemCollection commandParam)
        {
            //this.AcceptData();

            switch (command)
            {
                case "OCS0208Q00":   // 복용코드 정보

                    #region 복용코드 정보

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("order_remark"))
                            this.mTemp = commandParam["order_remark"].ToString();
                        else
                            this.mTemp = "";

                        if (commandParam.Contains("OCS0208"))
                        {
                            this.fbxBogyongCode.SetDataValue(((MultiLayout)commandParam["OCS0208"]).GetItemString(0, "bogyong_code"));
                            this.dbxBogyongName.SetDataValue(((MultiLayout)commandParam["OCS0208"]).GetItemString(0, "bogyong_name"));

                            this.ApplyGroupInfo(((MultiLayout)commandParam["OCS0208"]).GetItemString(0, "bogyong_code")
                                               , ((MultiLayout)commandParam["OCS0208"]).GetItemString(0, "bogyong_name")
                                               , ((MultiLayout)commandParam["OCS0208"]).GetItemString(0, "dv")
                                               , this.cboNalsu.GetDataValue(), this.cbxEmergency.GetDataValue(), this.cbxWonyoiOrderYN.GetDataValue()
                                               , ((MultiLayout)commandParam["OCS0208"]).GetItemString(0, "donbog_yn"), this.mTemp);

                            Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

                            // 외용 내복에 따른 그룹항목 visible Setting 
                            this.SetGroupControlVisible(groupInfo["group_ser"].ToString());

                            PostCallHelper.PostCall(new PostMethod(PostBogyongCodeValidating));
                        }

                        this.mTemp = "";
                    }


                    #endregion

                    break;

                case "OCS0208Q01": //복용코드조회(외용약)

                    #region

                    if (commandParam.Contains("bogyong_code"))
                    {
                        this.fbxBogyongCode.SetEditValue(commandParam["bogyong_code"].ToString());
                        this.fbxBogyongCode.AcceptData();

                    }

                    #endregion
                    break;

                case "OCS0103Q00":            // 항목검색

                    #region 항목검색

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("OCS0103") && ((MultiLayout)commandParam["OCS0103"]).RowCount > 0)
                        {
                            foreach (DataRow dr in ((MultiLayout)commandParam["OCS0103"]).LayoutTable.Rows)
                            {
                                HandleBtnListClick(FunctionType.Insert);
                                this.ApplySangOrderInfo(dr["hangmog_code"].ToString(), this.grdOrder.CurrentRowNumber, true, mGenericSearchYN);
                            }

                        }
                        this.grdOrder.SetFocusToItem(grdOrder.CurrentRowNumber, "hangmog_code", true);
                        this.grdOrder.SetFocusToItem(grdOrder.CurrentRowNumber, "hangmog_name", false);

                    }

                    #endregion

                    break;

                case "OCS0301Q09":  // 셋 처방

                    #region 셋 처방

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("OCS0303"))
                        {
                            this.ApplyCopyOrderInfo((MultiLayout)commandParam["OCS0303"], HangmogInfo.ExecutiveMode.YaksokCopy);
                        }

                        //this.grdOrder.AcceptData();
                    }

                    #endregion

                    break;

                case "OCS1003Q09":  // 전 처방

                    #region 전 처방

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("OCS1003"))
                        {
                            this.ApplyCopyOrderInfo((MultiLayout)commandParam["OCS1003"], HangmogInfo.ExecutiveMode.BeforeOrderCopy);
                            
                            ProcessCheckKinki();
                            ActionCheckOutHosp();
                        }

                        //this.grdOrder.AcceptData();

                    }

                    #endregion

                    break;

                case "OCS1023U00": // 정시약

                    #region 정시약

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("OCS1023"))
                        {
                            this.ApplyCopyOrderInfo((MultiLayout)commandParam["OCS1023"], HangmogInfo.ExecutiveMode.RegularDrugCopy);
                        }

                        //this.grdOrder.AcceptData();

                    }

                    #endregion

                    break;

                case "OCS1024U00": // 持参薬

                    #region 持参薬

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("OCS1024"))
                        {
                            this.ApplyCopyOrderInfo((MultiLayout)commandParam["OCS1024"], HangmogInfo.ExecutiveMode.RegularDrugCopy);
                        }
                    }

                    #endregion

                    break;

                case "CHT0117Q00":  // 부위코드

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("buwi_code"))
                        {
                            this.grdOrder.SetFocusToItem(this.grdOrder.CurrentRowNumber, "bogyong_code_sub");
                            this.grdOrder.SetEditorValue(commandParam["buwi_code"].ToString());
                            this.grdOrder.AcceptData();
                        }
                    }

                    break;

            }

            return null;
        }

        // 처방입력 PopupMenu 클릭시
        // Select All
        private void PopUpMenuSelectAll_Click(object sender, System.EventArgs e)
        {
            if (this.grdOrder == null) return;

            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                if (!this.grdOrder.IsSelectedRow(i)) this.grdOrder.SelectRow(i);
            }
        }
        // UnSelect All
        private void PopUpMenuUnSelectAll_Click(object sender, System.EventArgs e)
        {
            if (this.grdOrder == null) return;

            this.grdOrder.UnSelectAll();
        }
        // 처방행삭제
        private void PopUpMenuDelete_Click(object sender, System.EventArgs e)
        {
            if (this.mBtnList == null || this.mBtnList.Enabled)
            {
                this.grdOrder.Focus();
                HandleBtnListClick(FunctionType.Delete);
                this.grdOrder.UnSelectAll();
            }
        }
        // Copy
        private void PopUpMenuInsert_Click(object sender, System.EventArgs e)
        {
            if (this.mBtnCopy == null || this.mBtnCopy.Enabled) this.HandleBtnCopyClick(false);

            this.grdOrder.UnSelectAll();
        }
        // Paster
        private void PopUpMenuPaste_Click(object sender, System.EventArgs e)
        {
            if (this.mBtnPaste == null || this.mBtnPaste.Enabled) this.HandleBtnPasteClick();
            if (_aOpenParam != null)
                SetTabRbn(_aOpenParam);
            this.grdOrder.UnSelectAll();
        }
        // Mix
        private void PopUpMenuMix_Click(object sender, System.EventArgs e)
        {
            if (this.mBtnMix == null || this.mBtnMix.Enabled) this.HandleBtnMixClick();

            this.grdOrder.UnSelectAll();
        }
        // Mix해제
        private void PopUpMenuMixCancel_Click(object sender, System.EventArgs e)
        {
            if (this.mBtnMixCancel == null || this.mBtnMixCancel.Enabled) this.HandleBtnMixCancelClick();

            this.grdOrder.UnSelectAll();
        }
        // 상용오더등록
        private void PopUpMenuSelectOftenOrder_Click(object sender, System.EventArgs e)
        {
            if (this.grdOrder.CurrentRowNumber >= 0 && !TypeCheck.IsNull(grdOrder.GetItemString(grdOrder.CurrentRowNumber, "hangmog_code")))
            {
                string memb = "";
                string name = "";
                if (this.mOrderMode == OrderVariables.OrderMode.SetOrder)
                {
                    // 유저별 공통 모드인데 이건 어쩔까...

                    this.mOrderBiz.LoadColumnCodeName("gwa_doctor", "%", this.mMemb, EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"), ref name);

                    if (name == "")
                    {
                        // 주과의 상용오더를 가져오자.
                        memb = this.mOrderBiz.GetMainGwaDoctorCode(this.mMemb);
                        if (memb != "")
                            memb = this.mMemb;
                    }
                    else
                    {
                        memb = this.mMemb;
                    }
                }
                else
                {
                    if (UserInfo.UserGubun == UserType.Doctor)
                        memb = UserInfo.DoctorID;
                    else
                        memb = UserInfo.UserID;
                }

                this.mOrderBiz.SaveOfenUsedHangmog("I", "1", memb, grdOrder.GetItemString(grdOrder.CurrentRowNumber, "hangmog_code"), "1", "Y");

                this.tabSangyongOrder_SelectionChanged(this.tabSangyongOrder, new EventArgs());
            }

            this.grdOrder.UnSelectAll();
        }

        // 상용오더 삭제
        private void PopUpMenuSelectOftenOrderDelete_Click(object sender, System.EventArgs e)
        {
            string aMemb = "";
            string aMembGubun = "";
            string aHangmogCode = "";

            aMemb = this.grdSangyongOrder.GetItemString(grdSangyongOrder.CurrentRowNumber, "memb");
            aMembGubun = this.grdSangyongOrder.GetItemString(grdSangyongOrder.CurrentRowNumber, "memb_gubun");
            aHangmogCode = this.grdSangyongOrder.GetItemString(grdSangyongOrder.CurrentRowNumber, "hangmog_code");

            if (this.mOrderBiz.DeleteOftenUsedHangmog(aMembGubun, aMemb, aHangmogCode) == true)
            {
                this.tabSangyongOrder_SelectionChanged(this.tabSangyongOrder, new EventArgs());
            }
        }

        public void btnMakeSet_Click(object sender, EventArgs e)
        {
            MultiLayout selectedData = this.grdOrder.CloneToLayout();

            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                selectedData.LayoutTable.ImportRow(this.grdOrder.LayoutTable.Rows[i]);
            }

            if (selectedData.RowCount <= 0)
            {
                MessageBox.Show(XMsg.GetMsg("M020"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool isDoctorLogin = false;
            if (UserInfo.UserGubun == UserType.Doctor)
                isDoctorLogin = true;

            this.mOrderFunc.SetOrderMake(this.IOEGUBUN, isDoctorLogin, UserInfo.UserID, this.mInputPart, INPUTTAB, selectedData.LayoutTable);
        }

        private void grdPreview_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            if (grid.GetItemString(e.RowNumber, "order_data_yn") != "Y")
            {
                e.BackColor = Color.Khaki;
                e.Font = new Font("MS UI Gothic", (float)10, FontStyle.Italic);
            }

            else
            {
                if (grid.GetItemString(e.RowNumber, "dc_gubun") == "Y" && e.ColName == "hangmog_name")
                {
                    e.Font = new Font(e.Font.FontFamily, e.Font.Size, FontStyle.Strikeout);
                }

                if (grid.GetItemString(e.RowNumber, "nalsu") == "-1")
                {
                    e.BackColor = Color.Red;
                }
            }
        }

        private void grdPreview_MouseDown(object sender, MouseEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            int rowNumber = -1;
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                rowNumber = grd.GetHitRowNumber(e.Y);

                if (rowNumber >= 0)
                {
                    this.SelectGroupTab(grd.GetItemString(rowNumber, "group_ser"));

                    if (TypeCheck.IsInt(grd.GetItemString(rowNumber, "row_num")) && grd.GetItemInt(rowNumber, "row_num") >= 0)
                    {
                        this.grdOrder.SetFocusToItem(grd.GetItemInt(rowNumber, "row_num"), "hangmog_code", false);
                    }
                }
            }
        }

        private void grdPreview_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            //e.Protect = true;

            //return;

            XEditGrid grid = sender as XEditGrid;

            if (e.ColName == "suryang")
            {
                if (grid.GetItemString(e.RowNumber, "order_data_yn") == "Y")
                {
                    if (this.mHangmogInfo.IsOrderDataChagnedEnabled(this.IOEGUBUN, this.grdOrder, this.grdOrder.CurrentRowNumber, "suryang", OrderVariables.CheckMode.DataUpdate, OrderVariables.ErrorDisplayMode.NoDisplay) == false)
                    {
                        e.Protect = true;
                    }
                    else
                    {
                        e.Protect = false;
                    }
                }
                else
                {
                    if (this.cboNalsu.Protect == true)
                    {
                        e.Protect = true;
                    }
                    else
                    {
                        e.Protect = false;
                    }
                }
            }
            else if (e.ColName == "hoisu")
            {
                if (grid.GetItemString(e.RowNumber, "order_data_yn") == "Y" && grid.GetItemString(e.RowNumber, "donbog_yn") == "Y")
                {
                    if (this.mHangmogInfo.IsOrderDataChagnedEnabled(this.IOEGUBUN, this.grdOrder, this.grdOrder.CurrentRowNumber, "hoisu", OrderVariables.CheckMode.DataUpdate, OrderVariables.ErrorDisplayMode.NoDisplay) == false)
                    {
                        e.Protect = true;
                    }
                    else
                    {
                        e.Protect = false;
                    }
                }
                else
                {
                    e.Protect = true;
                }
            }
        }

        private void grdPreview_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;
            int orderRowIndex = -1;

            if (e.ColName == "suryang")
            {
                if (grid.GetItemString(e.RowNumber, "order_data_yn") == "Y")
                {
                    if (TypeCheck.IsDecimal(e.ChangeValue.ToString()))
                    {
                        //PostCallHelper.PostCall(new PostMethodStr(PostPreviewColumnChangedSuryang), e.ChangeValue.ToString());
                        if (TypeCheck.IsInt(grid.GetItemString(e.RowNumber, "row_num")))
                        {
                            orderRowIndex = int.Parse(grid.GetItemString(e.RowNumber, "row_num"));
                        }
                        this.grdOrder.SetItemValue(orderRowIndex, "suryang", e.ChangeValue);
                    }

                }
                else
                {
                    if (TypeCheck.IsDecimal(e.ChangeValue.ToString()))
                    {
                        //PostCallHelper.PostCall(new PostMethodStr(PostPreviewColumnChangedNalsu), e.ChangeValue.ToString());
                        this.cboNalsu.SetEditValue(e.ChangeValue);
                        this.cboNalsu.AcceptData();
                    }

                }

            }
            else if (e.ColName == "hoisu")
            {
                if (grid.GetItemString(e.RowNumber, "order_data_yn") == "Y")
                {
                    if (TypeCheck.IsInt(e.ChangeValue.ToString()))
                    {
                        orderRowIndex = int.Parse(grid.GetItemString(e.RowNumber, "row_num"));
                    }
                    this.grdOrder.SetItemValue(orderRowIndex, "dv", e.ChangeValue);
                }
            }

            this.MakePreviewStatus();
        }        

        public void HandleBtnChangeWonyoiClick()
        {
            //if (this.grdOrder.GetItemString(grdOrder.CurrentRowNumber, "wonnae_drg_yn") == "Y")
            //{
            //    isCheckHospCode = false;
            //}
            //if (this.mDefaultWonyoiOrder == "Y" && !isUncheckOutHosp)
            if (this.mDefaultWonyoiOrder == "Y" && isCheckHospCode)
            {
                this.mDefaultWonyoiOrder = "N";
                if (this.mBtnChangeWonyoi != null) this.mBtnChangeWonyoi.Text = Resources.XMsg_000024;
                if (mDbxWonyoiOrderYN != null) this.mDbxWonyoiOrderYN.SetDataValue(Resources.XMsg_000025);
               
            }
            else
            {
                this.mDefaultWonyoiOrder = "Y";
                if (this.mBtnChangeWonyoi != null) this.mBtnChangeWonyoi.Text = Resources.XMsg_000026;
                if (mDbxWonyoiOrderYN != null) this.mDbxWonyoiOrderYN.SetDataValue(Resources.XMsg_000027);
                isCheckHospCode = true;
            }           
            // 데이터 변경 체크
            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                if (this.mHangmogInfo.IsOrderDataChagnedEnabled(this.IOEGUBUN, this.grdOrder, i, "wonyoi_order_yn", OrderVariables.CheckMode.DataUpdate, OrderVariables.ErrorDisplayMode.MessageBox) == false)
                {
                    return;
                }
            }

            // 데이터에 대한 변경
            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                this.grdOrder.SetItemValue(i, "wonyoi_order_yn", this.mDefaultWonyoiOrder);
            }

            // 그룹정보 변경
            foreach (IHIS.X.Magic.Controls.TabPage groupTab in this.tabGroup.TabPages)
            {
                Hashtable groupInfo = groupTab.Tag as Hashtable;

                if (groupTab == this.tabGroup.SelectedTab)
                {
                    this.cbxWonyoiOrderYN.CheckedChanged -= new EventHandler(cbxWonyoiOrderYN_CheckedChanged);
                    //this.cbxWonyoiOrderYN.Checked = (this.mDefaultWonyoiOrder == "Y" ? false : true);
                    this.cbxWonyoiOrderYN.Checked = (this.mDefaultWonyoiOrder == "Y" ? true : false);
                    this.cbxWonyoiOrderYN.CheckedChanged += new EventHandler(cbxWonyoiOrderYN_CheckedChanged);
                }

                if (groupInfo.Contains("wonyoi_order_yn"))
                {
                    groupInfo.Remove("wonyoi_order_yn");
                }
                groupInfo.Add("wonyoi_order_yn", this.mDefaultWonyoiOrder);

                groupTab.Tag = groupInfo;
            }
            //if (isUncheckOutHosp)
            //{
            //    this.mBtnChangeWonyoi.Text = Resources.XMsg_000024;
            //    cbxWonyoiOrderYN.Checked = true;
            //    isUncheckOutHosp = false;
            //}
            //else
            //{
            //    this.mBtnChangeWonyoi.Text = Resources.XMsg_000026;
            //    cbxWonyoiOrderYN.Checked = false;
            //}
            this.MakePreviewStatus();
        }

        public void btnIlgwalChange_Click(object sender, EventArgs e)
        {
            // 일괄지정은 전체가 변경가능해야 하고
            // 하나라도 실행된 건이 존재 한다면 변경 불가능해야 한다.
            // 만일 선택된 로우가 있다면 그 로우만 체크 한다.

            // 실행전 체크 

            #region 체크 로직

            if (this.grdOrder.RowCount == 0)
            {
                MessageBox.Show(XMsg.GetMsg("M035"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (this.tabGroup.TabPages.Count == 0)
            {
                MessageBox.Show(XMsg.GetMsg("M035"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            Hashtable sGroupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;
            string group_number = "";
            bool IsSelectedOrder = false;
            // 그룹시리얼 셋팅
            if (sGroupInfo.Contains("group_ser"))
                group_number = sGroupInfo["group_ser"].ToString();

            ArrayList selectedIndex = new ArrayList();

            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                if (this.grdOrder.IsSelectedRow(i))
                {
                    selectedIndex.Add(i);
                }
            }

            // 변경할 데이터 체크 
            //if (selectedIndex.Count <= 1)
            //{
            //    for (int i = 0; i < this.grdOrder.RowCount; i++)
            //    {
            //        if (this.mHangmogInfo.IsOrderDataChagnedEnabled(this.IOEGUBUN, this.grdOrder, i, "nalsu", OrderVariables.CheckMode.DataUpdate, OrderVariables.ErrorDisplayMode.NoDisplay) == false)
            //        {
            //            MessageBox.Show(XMsg.GetMsg("M034"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }
            //    }
            //}
            //else 
            //{
            //    IsSelectedOrder = true;
            //    foreach (int row in selectedIndex)
            //    {
            //        if (this.mHangmogInfo.IsOrderDataChagnedEnabled(this.IOEGUBUN, this.grdOrder, row, "nalsu", OrderVariables.CheckMode.DataUpdate, OrderVariables.ErrorDisplayMode.NoDisplay) == false)
            //        {
            //            MessageBox.Show(XMsg.GetMsg("M034"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }
            //    }
            //}

            #endregion

            Hashtable returnValue = this.mCommonForms.ProcessIlgwalChange(0, "OCS0103U10", this.IOEGUBUN, IsSelectedOrder);

            #region 리턴값에 대한 프로세스

            if (returnValue != null)
            {
                string allGroup = returnValue["allGroup"].ToString();

                if (selectedIndex.Count <= 1)
                {
                    for (int i = 0; i < this.grdOrder.RowCount; i++)
                    {
                        foreach (DataColumn cl in this.grdOrder.LayoutTable.Columns)
                        {
                            if (cl.ColumnName == "nalsu" &&
                                (this.grdOrder.GetItemString(i, "order_gubun").PadLeft(2, '0').Substring(1, 1) == "D"
                                  || this.grdOrder.GetItemString(i, "donbog_yn") == "Y")
                                  || this.grdOrder.GetItemString(i, "input_gubun") != this.mInputGubun)
                            {
                                continue;
                            }

                            if (returnValue.Contains(cl.ColumnName))
                            {
                                if (this.mHangmogInfo.IsOrderDataChagnedEnabled(this.IOEGUBUN, this.grdOrder, i, cl.ColumnName, OrderVariables.CheckMode.DataUpdate, OrderVariables.ErrorDisplayMode.NoDisplay))
                                {
                                    if (allGroup == "N" && group_number == this.grdOrder.GetItemString(i, "group_ser"))
                                        this.grdOrder.SetItemValue(i, cl.ColumnName, returnValue[cl.ColumnName]);
                                    else if (allGroup == "Y")
                                        this.grdOrder.SetItemValue(i, cl.ColumnName, returnValue[cl.ColumnName]);
                                }
                            }

                        }
                    }

                    // 그룹인포에 대한 재정의
                    if (returnValue.Contains("nalsu"))
                    {
                        foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroup.TabPages)
                        {
                            Hashtable groupInfo = tpg.Tag as Hashtable;
                            if (allGroup == "N" && group_number == groupInfo["group_ser"].ToString())
                            {
                                if (this.IsOutDrugGroup(groupInfo["group_ser"].ToString()))
                                {
                                    continue;
                                }

                                if (groupInfo.Contains("donbog_yn") &&
                                    groupInfo["donbog_yn"].ToString() == "Y")
                                {
                                    continue;
                                }

                                groupInfo.Remove("nalsu");
                                groupInfo.Add("nalsu", returnValue["nalsu"].ToString());
                            }
                            else if (allGroup == "Y")
                            {
                                if (this.IsOutDrugGroup(groupInfo["group_ser"].ToString()))
                                {
                                    continue;
                                }

                                if (groupInfo.Contains("donbog_yn") &&
                                    groupInfo["donbog_yn"].ToString() == "Y")
                                {
                                    continue;
                                }

                                groupInfo.Remove("nalsu");
                                groupInfo.Add("nalsu", returnValue["nalsu"].ToString());
                            }
                        }

                        if (this.cboNalsu.Protect == false && this.cboNalsu.Visible == true)
                        {
                            this.cboNalsu.SetDataValue(returnValue["nalsu"].ToString());
                        }
                    }
                }
                else
                {
                    foreach (int row in selectedIndex)
                    {
                        foreach (DataColumn cl in this.grdOrder.LayoutTable.Columns)
                        {
                            if (cl.ColumnName == "nalsu" &&
                                (this.grdOrder.GetItemString(row, "order_gubun").PadLeft(2, '0').Substring(1, 1) == "D"
                                  || this.grdOrder.GetItemString(row, "donbog_yn") == "Y")
                                  || this.grdOrder.GetItemString(row, "input_gubun") != this.mInputGubun)
                            {
                                continue;
                            }

                            if (returnValue.Contains(cl.ColumnName))
                            {
                                if (this.mHangmogInfo.IsOrderDataChagnedEnabled(this.IOEGUBUN, this.grdOrder, row, cl.ColumnName, OrderVariables.CheckMode.DataUpdate, OrderVariables.ErrorDisplayMode.NoDisplay))
                                {
                                    this.grdOrder.SetItemValue(row, cl.ColumnName, returnValue[cl.ColumnName]);
                                }
                            }

                        }
                    }
                }


            }

            #endregion

            this.MakePreviewStatus();
        }

        public void btnHopeDateIlgwal_Click(object sender, EventArgs e)
        {
            // 일괄지정은 전체가 변경가능해야 하고
            // 하나라도 실행된 건이 존재 한다면 변경 불가능해야 한다.
            // 만일 선택된 로우가 있다면 그 로우만 체크 한다.

            // 실행전 체크 

            #region 체크 로직

            if (this.grdOrder.RowCount == 0)
            {
                MessageBox.Show(XMsg.GetMsg("M035"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (this.tabGroup.TabPages.Count == 0)
            {
                MessageBox.Show(XMsg.GetMsg("M035"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (tabGroup.SelectedTab == null) return;

            Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;
            string group_number = "";
            // 그룹시리얼 셋팅
            if (groupInfo.Contains("group_ser"))
                group_number = groupInfo["group_ser"].ToString();


            ArrayList selectedIndex = new ArrayList();

            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                if (this.grdOrder.IsSelectedRow(i))
                {
                    selectedIndex.Add(i);
                }
            }
            // 변경할 데이터 체크 
            if (selectedIndex.Count <= 1)
            {
                for (int i = 0; i < this.grdOrder.RowCount; i++)
                {
                    if (this.grdOrder.GetItemValue(i, "group_ser").ToString() == group_number)
                    {
                        if (this.mHangmogInfo.IsOrderDataChagnedEnabled(this.IOEGUBUN, this.grdOrder, i, "hope_date", OrderVariables.CheckMode.DataUpdate, OrderVariables.ErrorDisplayMode.NoDisplay) == false)
                        {
                            MessageBox.Show(XMsg.GetMsg("M034"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                }
            }
            else
            {
                foreach (int row in selectedIndex)
                {
                    if (this.grdOrder.GetItemValue(row, "group_ser").ToString() == group_number)
                    {
                        if (this.mHangmogInfo.IsOrderDataChagnedEnabled(this.IOEGUBUN, this.grdOrder, row, "hope_date", OrderVariables.CheckMode.DataUpdate, OrderVariables.ErrorDisplayMode.NoDisplay) == false)
                        {
                            MessageBox.Show(XMsg.GetMsg("M034"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }

            Hashtable returnValue = mCommonForms.ProcessHopeDateIlgwalChange(1);

            #endregion

            #region リターン値に対するプロセス
            if (returnValue != null)
            {
                if (selectedIndex.Count <= 1)
                {
                    for (int i = 0; i < this.grdOrder.RowCount; i++)
                    {
                        foreach (DataColumn cl in this.grdOrder.LayoutTable.Columns)
                        {
                            if (returnValue.Contains(cl.ColumnName))
                            {
                                if (this.grdOrder.GetItemValue(i, "group_ser").ToString() == group_number && this.mHangmogInfo.IsOrderDataChagnedEnabled(this.IOEGUBUN, this.grdOrder, i, cl.ColumnName, OrderVariables.CheckMode.DataUpdate, OrderVariables.ErrorDisplayMode.NoDisplay))
                                {
                                    if (this.grdOrder.GetItemString(i, "jundal_part") != "HOM") this.grdOrder.SetItemValue(i, cl.ColumnName, returnValue[cl.ColumnName]);
                                    this.grdOrder.SetItemValue(i, "dangil_gumsa_order_yn", returnValue["dangil_gumsa_order_yn"]);
                                    //this.grdOrder.SetItemValue(i, "dangil_gumsa_order_yn", "N");
                                    if (returnValue.Contains("dangil_gumsa_result_yn"))
                                        this.grdOrder.SetItemValue(i, "dangil_gumsa_result_yn", returnValue["dangil_gumsa_result_yn"]);
                                    else
                                        this.grdOrder.SetItemValue(i, "dangil_gumsa_result_yn", "N");
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (int row in selectedIndex)
                    {
                        foreach (DataColumn cl in this.grdOrder.LayoutTable.Columns)
                        {
                            if (returnValue.Contains(cl.ColumnName))
                            {
                                if (this.grdOrder.GetItemValue(row, "group_ser").ToString() == group_number && this.mHangmogInfo.IsOrderDataChagnedEnabled(this.IOEGUBUN, this.grdOrder, row, cl.ColumnName, OrderVariables.CheckMode.DataUpdate, OrderVariables.ErrorDisplayMode.NoDisplay))
                                {
                                    if (this.grdOrder.GetItemString(row, "jundal_part") != "HOM") this.grdOrder.SetItemValue(row, cl.ColumnName, returnValue[cl.ColumnName]);

                                    this.grdOrder.SetItemValue(row, "dangil_gumsa_order_yn", returnValue["dangil_gumsa_order_yn"]);
                                    //this.grdOrder.SetItemValue(row, "dangil_gumsa_order_yn", "N");
                                    if (returnValue.Contains("dangil_gumsa_result_yn"))
                                        this.grdOrder.SetItemValue(row, "dangil_gumsa_result_yn", returnValue["dangil_gumsa_result_yn"]);
                                    else
                                        this.grdOrder.SetItemValue(row, "dangil_gumsa_result_yn", "N");
                                }
                            }

                        }
                    }
                }

            }
            #endregion

            //this.MakePreviewStatus();
        }

        private void rbtSyouhin_CheckedChanged(object sender, EventArgs e)
        {

            if (this.rbtGenericSearch.Checked == true)
                mGenericSearchYN = "Y";
            else
                mGenericSearchYN = "N";

            this.txtSearch.Focus();
            this.Search_text();
        }

        private void grdOrder_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            if (e.ColName != "suryang")
            {
                XEditGrid grid = sender as XEditGrid;
                string changeValue = e.ChangeValue.ToString();
                switch (e.ColName)
                {
                    case "general_disp_yn":
                        if (changeValue == "Y")
                        {
                            string generic_name = mHangmogInfo.GetGenericName(grid.GetItemString(e.RowNumber, "hangmog_code"));

                            if (generic_name != "")
                            {
                                grid.SetItemValue(e.RowNumber, "hangmog_name", generic_name);
                            }
                        }
                        else
                        {
                            string hangmog_name = mHangmogInfo.GetHangmogName(grid.GetItemString(e.RowNumber, "hangmog_code"));

                            if (hangmog_name != "")
                            {
                                grid.SetItemValue(e.RowNumber, "hangmog_name", hangmog_name);
                            }
                        }
                        break;

                    case "hubal_change_yn":
                        if (changeValue == "Y")
                        {
                            grid.SetItemValue(e.RowNumber, "general_disp_yn", "N");

                            string hangmog_name = mHangmogInfo.GetHangmogName(grid.GetItemString(e.RowNumber, "hangmog_code"));

                            if (hangmog_name != "")
                            {
                                grid.SetItemValue(e.RowNumber, "hangmog_name", hangmog_name);
                            }
                        }
                        break;
                }
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                isSearchFormKeyPress = true;
                this.Search_text();
            }
        }

        private void cbxSentou_CheckedChanged(object sender, EventArgs e)
        {
            //this.txtSearch.Focus();
            //this.Search_text();
        }

        private void cboSearchCondition_SelectedValueChanged(object sender, EventArgs e)
        {
            this.txtSearch.Focus();
            this.Search_text();
        }

        private void dbxBogyongName_Click(object sender, EventArgs e)
        {
            if (!isEnableGrd) return;
            this.OPEN_DRG0208Q00();
        }

        private void xLabel8_Click(object sender, EventArgs e)
        {
            this.OPEN_DRG0208Q00();
        }

        private void btnNalsu_Click(object sender, EventArgs e)
        {
            if (this.tabGroup.SelectedTab == null) return;
            if (!this.IsSelectedRowForNalsu()) return;
            Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            // 현재 그리드에 해당 그룹의 오더가 없는경우 
            // 즉 빈 그룹인경우 오더를 입력하라는 메세지
            if (this.mOrderFunc.IsEmptyGroup(this.grdOrder, groupInfo["group_ser"].ToString()))
            {
                //오더코드를 먼저 입력해 주세요.
                MessageBox.Show(XMsg.GetMsg("M004"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PostCallHelper.PostCall(new PostMethod(PostNalsuValidating));
                return;
            }
            if (!this.IsSelectedDiffHopeDate())
            {
                //選択したオーダの中希望日が異なるオーダが存在します。
                MessageBox.Show(XMsg.GetMsg("M014"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PostCallHelper.PostCall(new PostMethod(PostNalsuValidating));
                return;
            }

            // 먼저 주사방법이 결정되어야 한다.
            if (this.fbxBogyongCode.GetDataValue() == "")
            {
                // 먼저 주사방법을 입력해 주세요.
                MessageBox.Show(XMsg.GetMsg("M005"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PostCallHelper.PostCall(new PostMethod(PostNalsuValidating));
                return;
            }
            OrderVariables.Objects objects = new OrderVariables.Objects(this.grdOrder, this.grdOrder.CurrentRowNumber, this.grdOrder.GetItemString(0, "order_date")
                                                                      , 1, this.grdOrder.GetItemString(0, "jundal_table")
                                                                      , this.grdOrder.GetItemString(0, "order_gubun_bas")
                                                                      , this.grdOrder.GetItemString(0, "home_care_yn"));

            PostCallHelper.PostCall(new PostMethodObject(PostNalsuValidating), objects);
            PostCallHelper.PostCall(new PostMethod(PostNalsuValidating));
        }

        private void PostNalsuValidating(object aParam)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                OrderVariables.Objects objects = (OrderVariables.Objects)aParam;

                XEditGrid grd = (XEditGrid)objects.obj1;
                int row = (int)objects.obj2;
                int source_last_row = row;                 // Nday처리할 원데이타의 Row(Mix도 있을수 있으므로 Mix된 Last)
                string naewon_date = (string)objects.obj3;

                int nalsu = int.Parse(objects.obj4.ToString());
                string jundal_table = (string)objects.obj5;
                string order_gubun_bas = (string)objects.obj6;
                string hame_care_yn = (string)objects.obj7;

                if (this.tabGroup.SelectedTab == null ||
                    this.mOrderFunc.IsEmptyGroup(this.grdOrder, ((Hashtable)this.tabGroup.SelectedTab.Tag)["group_ser"].ToString()))
                {
                    return;
                }

                // 기준데이터를 셀렉트 한다
                // N데이를 풀 기준은 현재 그리드에 보이는 데이터를 기준으로 N데이 푼다.
                MultiLayout layGijunData = this.grdOrder.CloneToLayout();
                MultiLayout mixInfo = new MultiLayout();
                mixInfo.LayoutItems.Add("org_mix", DataType.String);
                mixInfo.LayoutItems.Add("cnv_mix", DataType.String);
                mixInfo.InitializeLayoutTable();

                //insert by jc

                ArrayList selectedIndex = new ArrayList();

                for (int i = 0; i < this.grdOrder.RowCount; i++)
                {
                    if (this.grdOrder.IsSelectedRow(i))
                    {
                        selectedIndex.Add(i);
                    }
                }


                if (selectedIndex.Count > 0)
                {
                    foreach (int rows in selectedIndex)
                    {
                        if (this.grdOrder.IsVisibleRow(rows) &&
                            this.grdOrder.GetItemString(rows, "input_gubun") == this.mInputGubun)
                        {
                            layGijunData.LayoutTable.ImportRow(this.grdOrder.LayoutTable.Rows[rows]);

                            if (this.grdOrder.GetItemString(rows, "mix_group") != "")
                            {
                                DataRow[] dr = mixInfo.LayoutTable.Select("org_mix='" + this.grdOrder.GetItemString(rows, "mix_group") + "'");

                                if (dr.Length <= 0)
                                {
                                    int rowNum = mixInfo.InsertRow(-1);
                                    mixInfo.SetItemValue(rowNum, "org_mix", this.grdOrder.GetItemString(rows, "mix_group"));
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < this.grdOrder.RowCount; i++)
                    {
                        if (this.grdOrder.IsVisibleRow(i) &&
                            this.grdOrder.GetItemString(i, "input_gubun") == this.mInputGubun)
                        {
                            layGijunData.LayoutTable.ImportRow(this.grdOrder.LayoutTable.Rows[i]);

                            if (this.grdOrder.GetItemString(i, "mix_group") != "")
                            {
                                DataRow[] dr = mixInfo.LayoutTable.Select("org_mix='" + this.grdOrder.GetItemString(i, "mix_group") + "'");

                                if (dr.Length <= 0)
                                {
                                    int rowNum = mixInfo.InsertRow(-1);
                                    mixInfo.SetItemValue(rowNum, "org_mix", this.grdOrder.GetItemString(i, "mix_group"));
                                }
                            }
                        }
                    }
                }
                if (layGijunData.RowCount <= 0)
                {
                    MessageBox.Show(XMsg.GetMsg("M0113"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (grd == null || this.mOrderFunc.IsEmptyGroup(grd, ((Hashtable)this.tabGroup.SelectedTab.Tag)["group_ser"].ToString())) return;

                // N day 예약일자를 받는다

                // 기존에선택된데이타 선택된것으로 달력표시시에는
                // this.mGetSelectDate.AddInputDate 사용
                //insert by jc

                //FormGetSelectHopeDateに渡す日付の重複除去用変数
                ArrayList insertDateTime = new ArrayList();

                if (selectedIndex.Count > 0)
                {
                    foreach (int rows in selectedIndex)
                    {
                        if (this.grdOrder.GetItemString(rows, "hope_date") != "" && !insertDateTime.Contains(this.grdOrder.GetItemValue(rows, "hope_date")))
                        {
                            this.mCommonForms.AddInputDate(this.grdOrder.GetItemString(rows, "hope_date"));
                            insertDateTime.Add(this.grdOrder.GetItemValue(rows, "hope_date"));
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdOrder.RowCount; i++)
                    {
                        if (this.grdOrder.GetItemString(i, "hope_date") != "" && !insertDateTime.Contains(this.grdOrder.GetItemValue(i, "hope_date")))
                        {
                            this.mCommonForms.AddInputDate(this.grdOrder.GetItemString(i, "hope_date"));
                            insertDateTime.Add(this.grdOrder.GetItemValue(i, "hope_date"));
                        }
                    }
                }

                insertDateTime.Clear();

                //insert by jc
                //[カレンダーOPEN]
                MultiLayout receiveDate = null;

                //insert by jc [入院オーダ時は休日選択可能にさせる] 2012/05/11
                if (IOEGUBUN == "I")
                    receiveDate = this.mCommonForms.SelectHopeDate(this, naewon_date, nalsu, jundal_table, IOEGUBUN);
                else
                    receiveDate = this.mCommonForms.SelectHopeDate(this, naewon_date, nalsu, jundal_table);

                // 그룹의 일수를 1로 다시 변경한다.
                this.cboNalsu.SetDataValue("1");

                // 화면 Clear
                grd.AcceptData();
                this.Parent.Refresh();

                if (receiveDate == null || receiveDate.RowCount == 0) return;

                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

                this.InitStatusBar(receiveDate.RowCount);
                this.SetVisibleStatusBar(true);

                // DataTable 데이타를 담는다(해당 Row와 동일 Mix인 데이타)
                MultiLayout lay = this.mOrderFunc.CloneDataLayoutMIO(grd);

                for (int i = 0; i < receiveDate.RowCount; i++)
                {
                    this.SetStatusBar(i + 1);
                    // Mix 그룹 리셋
                    for (int k = 0; k < mixInfo.RowCount; k++)
                    {
                        mixInfo.SetItemValue(k, "cnv_mix", "");
                    }

                    //modify by jc [修正不可能ない状態のROWには希望日をいれずに飛ばす] 2012/05/02
                    if (i == 0 && this.mHangmogInfo.IsOrderDataChagnedEnabled(this.IOEGUBUN, this.grdOrder, this.grdOrder.CurrentRowNumber, "jusa", OrderVariables.CheckMode.DataUpdate, OrderVariables.ErrorDisplayMode.NoDisplay)) // 초기 1회는 현재 화면의 데이터 즉 기준데이터를 가지고 희망일자만 셋팅하면 된다.
                    {
                        if (selectedIndex.Count > 0)
                        {
                            foreach (int rows in selectedIndex)
                            {
                                if (this.grdOrder.GetItemString(rows, "group_ser") == ((Hashtable)this.tabGroup.SelectedTab.Tag)["group_ser"].ToString()
                                    && this.grdOrder.GetItemString(rows, "input_gubun") == this.mInputGubun)
                                {
                                    this.grdOrder.SetItemValue(rows, "hope_date", receiveDate.GetItemString(i, "day"));
                                }
                            }
                        }
                        else
                        {
                            for (int j = 0; j < this.grdOrder.RowCount; j++)
                            {
                                if (this.grdOrder.GetItemString(j, "group_ser") == ((Hashtable)this.tabGroup.SelectedTab.Tag)["group_ser"].ToString() &&
                                    this.grdOrder.GetItemString(j, "input_gubun") == this.mInputGubun)
                                {
                                    this.grdOrder.SetItemValue(j, "hope_date", receiveDate.GetItemString(i, "day"));
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (DataRow dr in layGijunData.LayoutTable.Rows)
                        {
                            string cnvMix = "";
                            if (dr["mix_group"].ToString() != "")
                            {
                                cnvMix = this.GetConvertMixInfo(mixInfo, dr["mix_group"].ToString());

                                if (cnvMix == "")
                                {
                                    cnvMix = this.GetMixGroup(this.grdOrder);
                                    this.SetConvertMixInfo(mixInfo, dr["mix_group"].ToString(), cnvMix);
                                }
                            }
                            int currentRow = this.grdOrder.RowCount;
                            this.grdOrder.InsertRow(currentRow);
                            foreach (DataColumn cl in this.grdOrder.LayoutTable.Columns)
                            {
                                switch (cl.ColumnName)
                                {
                                    case "pkocskey": break;
                                    case "seq": break;
                                    case "muhyo": break;
                                    case "dc_yn": break;
                                    case "bannab_yn": break;
                                    case "bannab_confirm": break;
                                    case "ocs_flag": break;
                                    case "sg_ymd": break;
                                    case "after_act_yn": break;


                                    case "hope_date":
                                        this.grdOrder.SetItemValue(this.grdOrder.CurrentRowNumber, cl.ColumnName, receiveDate.GetItemString(i, "day"));
                                        break;

                                    case "mix_group":
                                        this.grdOrder.SetItemValue(this.grdOrder.CurrentRowNumber, cl.ColumnName, cnvMix);
                                        break;

                                    default:
                                        this.grdOrder.SetItemValue(this.grdOrder.CurrentRowNumber, cl.ColumnName, dr[cl.ColumnName]);
                                        break;
                                }
                            }
                        }
                    }
                }
                this.grdOrder.DisplayData();
                this.DisplayMixGroup(this.grdOrder);
                this.DisplayOrderGridGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag);

            }
            finally
            {
                this.SetVisibleStatusBar(false);
                this.Cursor = System.Windows.Forms.Cursors.Default;
                this.MakePreviewStatus();
            }
        }

        private void cboNalsu_VisibleChanged(object sender, EventArgs e)
        {
            //if (this.IOEGUBUN == "I")
            //{
            //    if (this.cboNalsu.Visible == true)
            //        this.btnNalsu.Visible = false;
            //    else
            //        this.btnNalsu.Visible = true;
            //}
        }

        private void btnBroughtDrg_Click(object sender, EventArgs e)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", this.mPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("gwa", this.mPatientInfo.GetPatientInfo["gwa"].ToString());
            param.Add("auto_close_yn", "Y");
            param.Add("input_tab", INPUTTAB);
            param.Add("mode", "select");

            XScreen.OpenScreenWithParam(this, "OCSI", "OCS1024U00", ScreenOpenStyle.ResponseFixed, param);
        }

        private void grdSearchOrder_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            tabWonnaeDrg.SelectionChanged -= tabWonnaeDrg_SelectionChanged;

            this.setTabWonnaeDrg(this.grdSearchOrder.GetItemString(this.grdSearchOrder.CurrentRowNumber, "yak_kijun_code"), this.grdSearchOrder.GetItemString(this.grdSearchOrder.CurrentRowNumber, "hangmog_code"));
            this.grdGeneral.QueryLayout(true);

            tabWonnaeDrg.SelectionChanged += tabWonnaeDrg_SelectionChanged;
        }

        private void setTabWonnaeDrg(string aYakKijunCode, string aHangmogCode)
        {
            #region tobe deleted
            //            // change TAb's name
            //            string cmd = @" SELECT '4' FILTER, COUNT(*) CNT, SUBSTR(:f_yak_kijun_code, 1, 4)
            //                              FROM OCS0103 A
            //                                 
            //                             WHERE A.HOSP_CODE = :f_hosp_code
            //                               AND SUBSTR(A.YAK_KIJUN_CODE, 1, 4) = SUBSTR(:f_yak_kijun_code, 1, 4)
            //                               AND A.WONNAE_DRG_YN = 'Y'
            //                               AND NVL(TO_DATE(:f_order_date, 'YYYY/MM/DD'), TRUNC(SYSDATE)) BETWEEN A.START_DATE AND A.END_DATE
            //                               AND A.ORDER_GUBUN IN ('C', 'D')
            //                               AND A.HANGMOG_CODE != :f_hangmog_code
            //                             GROUP BY '4', SUBSTR(:f_yak_kijun_code, 1, 4)
            //                             UNION ALL
            //                            SELECT '7' FILTER, COUNT(*) CNT, SUBSTR(:f_yak_kijun_code, 1, 7)
            //                              FROM OCS0103 A
            //                             WHERE A.HOSP_CODE = :f_hosp_code
            //                               AND SUBSTR(A.YAK_KIJUN_CODE, 1, 7) = SUBSTR(:f_yak_kijun_code, 1, 7)
            //                               AND A.WONNAE_DRG_YN = 'Y'
            //                               AND NVL(TO_DATE(:f_order_date, 'YYYY/MM/DD'), TRUNC(SYSDATE)) BETWEEN A.START_DATE AND A.END_DATE
            //                               AND A.ORDER_GUBUN IN ('C', 'D')
            //                               AND A.HANGMOG_CODE != :f_hangmog_code
            //                             GROUP BY '7', SUBSTR(:f_yak_kijun_code, 1, 7)   
            //                             UNION ALL
            //                            SELECT '8' FILTER, COUNT(*) CNT, SUBSTR(:f_yak_kijun_code, 1, 8)
            //                              FROM OCS0103 A
            //                             WHERE A.HOSP_CODE = :f_hosp_code
            //                               AND SUBSTR(A.YAK_KIJUN_CODE, 1, 8) = SUBSTR(:f_yak_kijun_code, 1, 8)
            //                               AND A.WONNAE_DRG_YN = 'Y'
            //                               AND NVL(TO_DATE(:f_order_date, 'YYYY/MM/DD'), TRUNC(SYSDATE)) BETWEEN A.START_DATE AND A.END_DATE
            //                               AND A.ORDER_GUBUN IN ('C', 'D')
            //                               AND A.HANGMOG_CODE != :f_hangmog_code
            //                             GROUP BY '8', SUBSTR(:f_yak_kijun_code, 1, 8)
            //                             UNION ALL
            //                            SELECT '9' FILTER, COUNT(*) CNT, SUBSTR(:f_yak_kijun_code, 1, 9)
            //                              FROM OCS0103 A
            //                             WHERE A.HOSP_CODE = :f_hosp_code
            //                               AND SUBSTR(A.YAK_KIJUN_CODE, 1, 9) = SUBSTR(:f_yak_kijun_code, 1, 9)
            //                               AND A.WONNAE_DRG_YN = 'Y'
            //                               AND NVL(TO_DATE(:f_order_date, 'YYYY/MM/DD'), TRUNC(SYSDATE)) BETWEEN A.START_DATE AND A.END_DATE
            //                               AND A.ORDER_GUBUN IN ('C', 'D')
            //                               AND A.HANGMOG_CODE != :f_hangmog_code
            //                             GROUP BY '9', SUBSTR(:f_yak_kijun_code, 1, 9)
            //                               ";
            //            BindVarCollection bind = new BindVarCollection();
            //            bind.Add("f_hosp_code", EnvironInfo.HospCode);
            //            bind.Add("f_yak_kijun_code", aYakKijunCode);
            //            bind.Add("f_order_date", mOrderDate);
            //            bind.Add("f_input_tab", INPUTTAB);
            //            bind.Add("f_hangmog_code", aHangmogCode);
            #endregion

            // Cloud connected update code START
            OCS0103U10SetTabWonnaeDrgArgs args = new OCS0103U10SetTabWonnaeDrgArgs();
            args.HangmogCode = aHangmogCode;
            args.InputTab = INPUTTAB;
            args.OrderDate = mOrderDate;
            args.YakKijunCode = aYakKijunCode;
            OCS0103U10SetTabWonnaeDrgResult res = CloudService.Instance.Submit<OCS0103U10SetTabWonnaeDrgResult,
                OCS0103U10SetTabWonnaeDrgArgs>(args);

            DataTable dt = new DataTable();
            if (null != res)
            {
                dt = ConvertToDataTable(res.WonnaeDrgItem);
            }
            // Cloud connected update code END

            //DataTable dt = Service.ExecuteDataTable(cmd, bind);

            this.setTabReset(); //TAB情報初期化
            int Y4_CNT = 0;
            int T7_CNT = 0;
            int Z8_CNT = 0;
            int K9_CNT = 0;

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    switch (dt.Rows[i]["filter"].ToString())
                    {
                        case "4": // 薬効一致
                            this.tabpageY4.Title = this.tabpageY4.Title + " ( " + dt.Rows[i]["cnt"].ToString() + " )";
                            this.tabpageY4.TitleTextColor = Color.Red;
                            Y4_CNT = int.Parse(dt.Rows[i]["cnt"].ToString());
                            break;
                        case "7": // 投与経路一致
                            this.tabpageT7.Title = this.tabpageT7.Title + " ( " + dt.Rows[i]["cnt"].ToString() + " )";
                            this.tabpageT7.TitleTextColor = Color.Red;
                            T7_CNT = int.Parse(dt.Rows[i]["cnt"].ToString());
                            break;
                        case "8": // 剤形一致
                            this.tabpageZ8.Title = this.tabpageZ8.Title + " ( " + dt.Rows[i]["cnt"].ToString() + " )";
                            this.tabpageZ8.TitleTextColor = Color.Red;
                            Z8_CNT = int.Parse(dt.Rows[i]["cnt"].ToString());
                            break;
                        case "9": // 規格一致
                            this.tabpageK9.Title = this.tabpageK9.Title + " ( " + dt.Rows[i]["cnt"].ToString() + " )";
                            this.tabpageK9.TitleTextColor = Color.Red;
                            K9_CNT = int.Parse(dt.Rows[i]["cnt"].ToString());
                            break;
                    }
                }
            }


            if (K9_CNT == 0)
            {
                if (Z8_CNT == 0)
                {
                    if (T7_CNT == 0)
                    {
                        if (Y4_CNT == 0) this.tabWonnaeDrg.SelectedIndex = 0;
                        else this.tabWonnaeDrg.SelectedIndex = 3;
                    }
                    else this.tabWonnaeDrg.SelectedIndex = 2;
                }
                else this.tabWonnaeDrg.SelectedIndex = 1;
            }
            else this.tabWonnaeDrg.SelectedIndex = 0;

            this.grdSearchOrder.Focus();
        }

        private void grdGeneral_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdGeneral.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdGeneral.SetBindVarValue("f_order_date", this.mOrderDate);
            this.grdGeneral.SetBindVarValue("f_input_tab", INPUTTAB);
            this.grdGeneral.SetBindVarValue("f_wonnae_order_yn", this.cboQueryCon.GetDataValue());
            this.grdGeneral.SetBindVarValue("f_yak_kijun_code", this.grdSearchOrder.GetItemString(this.grdSearchOrder.CurrentRowNumber, "yak_kijun_code"));
            this.grdGeneral.SetBindVarValue("f_hangmog_code", this.grdSearchOrder.GetItemString(this.grdSearchOrder.CurrentRowNumber, "hangmog_code"));
            this.grdGeneral.SetBindVarValue("f_filter", this.tabWonnaeDrg.SelectedTab.Tag.ToString());
        }

        private void grdSangyongOrder_QueryStarting(object sender, CancelEventArgs e)
        {
            if (this.mPatientInfo != null)
            {
                this.grdSangyongOrder.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

                if (UserInfo.UserGubun == UserType.Doctor)
                {
                    this.grdSangyongOrder.SetBindVarValue("f_user", UserInfo.UserID);
                }
                else if (this.mPatientInfo.GetPatientInfo != null)
                {
                    if (this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString().Length >= 2)
                    {
                        this.grdSangyongOrder.SetBindVarValue("f_user", this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString().Substring(2));
                    }
                }
                else
                {
                    this.grdSangyongOrder.SetBindVarValue("f_user", UserInfo.UserID);
                }

                this.grdSangyongOrder.SetBindVarValue("f_io_gubun", this.IOEGUBUN);
                this.grdSangyongOrder.SetBindVarValue("f_search_word", this.txtSearch.Text);
                this.grdSangyongOrder.SetBindVarValue("f_order_gubun", ((Hashtable)this.tabSangyongOrder.SelectedTab.Tag)["order_gubun"].ToString());
                this.grdSangyongOrder.SetBindVarValue("f_order_date", mOrderDate);
                this.grdSangyongOrder.SetBindVarValue("f_wonnae_drg_yn", this.cboQueryCon.GetDataValue());
            }
        }

        private void tabWonnaeDrg_SelectionChanged(object sender, EventArgs e)
        {
            this.grdGeneral.QueryLayout(true);
        }

        private void ParentForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F7:  // 오더입력

                    HandleBtnListClick(FunctionType.Insert);

                    break;

                case Keys.F6:  // 신규오더그룹추가

                    HandleBtnListClick(FunctionType.Process);

                    break;

                case Keys.F12: // 저장

                    HandleBtnListClick(FunctionType.Update);

                    break;

                case Keys.F8:  // 오더삭제

                    HandleBtnListClick(FunctionType.Delete);

                    break;

                case Keys.F5:  // 오더그룹삭제

                    HandleBtnListClick(FunctionType.Cancel);

                    break;
            }
        }

        private void tabSangyongOrder_SelectionChanged(object sender, EventArgs e)
        {
            XTabControl control = sender as XTabControl;
            //string memb = "";
            //Hashtable tabInfo;

            this.grdSangyongOrder.Reset();
            this.grdSangyongOrder.QueryLayout(true);

            //foreach (IHIS.X.Magic.Controls.TabPage tpg in control.TabPages)
            //{
            //    if (tpg == control.SelectedTab)
            //    {
            //        tpg.ImageIndex = 0;

            //        tabInfo = tpg.Tag as Hashtable;
            //        memb = tabInfo["memb"].ToString();

            //        string wonnaeDrgYn = this.cboQueryCon.GetDataValue();

            //        this.LoadOftenUseOrder("1", memb, tabInfo["order_gubun"].ToString(), wonnaeDrgYn, this.txtSearch.GetDataValue());
            //    }
            //    else
            //    {
            //        tpg.ImageIndex = 1;
            //    }
            //}
        }

        private void tvwDrgBunryu_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (e.Node.Nodes.Count > 0)
            {
                this.grdDrgOrder.Reset();
            }
            else
            {
                string wonnaeDrgYn = this.cboQueryCon.GetDataValue();

                this.LoadDrgOrder("1", e.Node.Tag.ToString(), wonnaeDrgYn, "%");
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            HandleBtnListClick(FunctionType.Insert);
        }
        #endregion

        #region CloudConnector updated code

        #region ConvertToDataTable
        /// <summary>
        /// ConvertToDataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        private DataTable ConvertToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(Regex.Replace(prop.Name, "(?<=.)([A-Z])", "_$0", RegexOptions.Compiled).ToLower());
            }
            foreach (T item in items)
            {
                object[] values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
        #endregion

        #region InitItemsControl
        /// <summary>
        /// InitItemsControl
        /// </summary>
        private void InitItemsControl()
        {
            #region Layout and XEditGrid
            // grdSpecimen
            //this.grdSpecimen.ParamList = new List<string>(new string[]
            //    {
            //        "f_cpl_code_yn",
            //        "f_mode",
            //        "f_slip_code",
            //        "f_specimen_code",
            //        "f_hosp_code",
            //        "f_input_tab",
            //        "f_search_word",
            //        "f_wonnae_drg_yn",
            //        "f_user",
            //        "f_order_date",
            //    });
            //this.grdSpecimen.ExecuteQuery = GetGrdSpecimenList;

            // grdOrder
            this.grdOrder.ParamList = new List<string>(new string[]
                {
                    "f_memb",
                    "f_yaksok_code",
                    "f_fk_in_out_key",
                    "f_input_tab",
                    "f_input_gubun",
                });
            this.grdOrder.ExecuteQuery = GetGrdOrder;

            // grdSangyongOrder
            this.grdSangyongOrder.ParamList = new List<string>(new string[]
                {
                    "f_user",
                    "f_io_gubun",
                    "f_order_gubun",
                    "f_order_date",
                    "f_search_word",
                    "f_wonnae_drg_yn",
                    "f_page_number",
                });
            this.grdSangyongOrder.ExecuteQuery = GetGrdSangyongOrder;

            // laySpecimenTree
            //this.laySpecimenTree.ParamList = new List<string>(new string[] { "f_user" });
            //this.laySpecimenTree.ExecuteQuery = GetLaySpecimenTree;

            // grdSearchOrder
            //this.grdSearchOrder.ParamList = new List<string>(new string[] { "f_order_date", "f_search_word" });
            //this.grdSearchOrder.ExecuteQuery = GetGrdSearchOrder;

            // grdDrgOrder
            this.grdDrgOrder.ParamList = new List<string>(new string[]
                {
                    "f_mode",
                    "f_code1",
                    "f_wonnae_drg_yn",
                    "f_order_date",
                    "f_search_word",
                    "f_page_number",
                    "f_offset",
                });
            this.grdDrgOrder.ExecuteQuery = GetGrdDrgOrder;

            // grdGeneral
            this.grdGeneral.ParamList = new List<string>(new string[]
                {
                    "f_filter",
                    "f_yak_kijun_code",
                    "f_order_date",
                    "f_hangmog_code",
                });
            this.grdGeneral.ExecuteQuery = GetGrdGeneral;

            // layDrugTree
            this.layDrugTree.ExecuteQuery = GetLayDrugTree;
            //GrdSearchOrder
            this.grdSearchOrder.ParamList = new List<string>(new string[]
                {
                //this.mOrderBiz.LoadSearchOrderInfoDRG(protocolId, aSearchWord, aGijunDate, aInputTab, aWonnaeDrgYn, this.cboSearchCondition.SelectedValue.ToString(), mGenericSearchYN, pageNumber,"200");
                    "f_protocol_id",
                    "f_search_word",
                    "f_gijundate",
                    "f_input_tab",
                    "f_wonnae_drugyn",
                    "f_search_condition",
                    "f_generic_searchyn",
                    "f_page_number",
                    "f_offset",
                });
            this.grdSearchOrder.ExecuteQuery = ExecuteLoadSearchOrderInfo;

            #endregion
        }
        #endregion

        #region GetSearchWordForSpecimen
        /// <summary>
        /// GetSearchWordForSpecimen
        /// </summary>
        /// <param name="aSearchWord"></param>
        /// <returns></returns>
        private string GetSearchWordForSpecimen(string aSearchWord)
        {
            string searchWord = string.Empty;

            OCS0103U13FnAdmConvertKanaFullArgs fnArg = new OCS0103U13FnAdmConvertKanaFullArgs();
            fnArg.SearchWord = aSearchWord;
            OCS0103U13FnAdmConvertKanaFullResult fnRes = CloudService.Instance.Submit<OCS0103U13FnAdmConvertKanaFullResult,
                OCS0103U13FnAdmConvertKanaFullArgs>(fnArg);

            if (null != fnRes)
            {
                searchWord = fnRes.Result;
            }

            return searchWord;
        }
        #endregion

        #region GetGrdSpecimenList
        /// <summary>
        /// GetGrdSpecimenList
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdSpecimenList(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            OCS0103U13GrdSpecimenListArgs args = new OCS0103U13GrdSpecimenListArgs();
            args.CplCodeYn = bvc["f_cpl_code_yn"].VarValue;
            args.Mode = bvc["f_mode"].VarValue;
            args.SlipCode = bvc["f_slip_code"].VarValue;
            args.InputTab = bvc["f_input_tab"].VarValue;
            args.SearchWord = bvc["f_search_word"].VarValue;
            args.WonnaeDrgYn = bvc["f_wonnae_drg_yn"].VarValue;
            args.OrderDate = bvc["f_order_date"].VarValue;
            args.User = bvc["f_user"].VarValue;
            OCS0103U13GrdSpecimenListResult res = CloudService.Instance.Submit<OCS0103U13GrdSpecimenListResult,
                OCS0103U13GrdSpecimenListArgs>(args);

            if (null != res)
            {
                foreach (OCS0103U13GrdSpecimenListInfo item in res.GrdSpecItem)
                {
                    lObj.Add(new object[]
                    {
                        item.SlipCode,
                        item.Position,
                        item.Seq,
                        item.HangmogCode,
                        item.HangmogName1,
                        item.GroupYn,
                        item.BulyongCheck,
                        item.WonnaeDrgYn,
                        item.SelectYn,
                        item.HangmogName2,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #region GetGrdOrder
        /// <summary>
        /// GetGrdOrder
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdOrder(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            OCS0103U13GrdOrderListArgs args = new OCS0103U13GrdOrderListArgs();
            args.FkInOutKey = bvc["fk_in_out_key"].VarValue;
            args.InputTab = bvc["input_tab"].VarValue;
            args.YaksokCode = bvc["yaksok_code"].VarValue;
            args.OrderMode = ((int)this.mOrderMode).ToString();
            args.InputGubun = bvc["input_gubun"].VarValue;
            args.Memb = bvc["memb"].VarValue;
            OCS0103U13GrdOrderListResult res = CloudService.Instance.Submit<OCS0103U13GrdOrderListResult,
                OCS0103U13GrdOrderListArgs>(args);

            // UT
            //OCS0103U13GrdOrderListArgs args = new OCS0103U13GrdOrderListArgs();
            //args.FkInOutKey = "001";
            //args.InputTab = "04";
            //args.YaksokCode = "04/10010/1/204";
            //args.OrderMode = "1";
            //args.InputGubun = "1";
            //args.Memb = "10010";
            //OCS0103U13GrdOrderListResult res = CloudService.Instance.Submit<OCS0103U13GrdOrderListResult,
            //    OCS0103U13GrdOrderListArgs>(args);

            if (null != res)
            {
                foreach (OCS0103U13GrdOrderListInfo item in res.GrdOrderListItem)
                {
                    lObj.Add(new object[]
                    {
                        item.PkOrdKey,
                        item.Memb,
                        item.YaksokCode,
                        item.Bunho,
                        item.IoGubun1,
                        item.OrderDate,
                        item.OrderTime,
                        item.Gwa,
                        item.Doctor,
                        item.Resident,
                        item.NaewonType,
                        item.InputId,
                        item.InputPart,
                        item.InputGwa,
                        item.InputDoctor,
                        item.InputGubun,
                        item.InputGubunName,
                        item.GroupSer,
                        item.InputTab,
                        item.InputTabName,
                        item.OrderGubun,
                        item.OrderGubunName,
                        item.NdayYn1,
                        item.Seq,
                        item.SlipCode,
                        item.HangmogCode,
                        item.HangmogName,
                        item.SpecimenCode,
                        item.SpecimenName,
                        item.Suryang,
                        item.SunabSuryang,
                        item.SubulSuryang,
                        item.OrdDanui,
                        item.OrdDanuiName,
                        item.DvTime,
                        item.Dv,
                        item.Dv1,
                        item.Dv2,
                        item.Dv3,
                        item.Dv4,
                        item.Nalsu,
                        item.SunabNalsu,
                        item.Jusa,
                        item.JusaName,
                        item.JusaSpdGubun,
                        item.BogyongCode,
                        item.BogyongName,
                        item.Emergency,
                        item.JaeryoJundalYn,
                        item.JundalTable,
                        item.JundalPart,
                        item.MovePart,
                        item.PortableYn,
                        item.PowderYn,
                        item.HubalChangeYn,
                        item.Phamacy,
                        item.DrgPackYn,
                        item.Muhyo,
                        item.PrnYn,
                        item.ToiwonDrgYn,
                        item.PrnNurse,
                        item.AppendYn,
                        item.OrderRemark,
                        item.NurseRemark,
                        item.MixGroup,
                        item.Amt,
                        item.Pay,
                        item.WonyoiOrderYn,
                        item.DangilGumsaOrderYn,
                        item.DangilGumsaResultYn,
                        item.BomOccurYn,
                        item.BomSourceKey,
                        item.DisplayYn,
                        item.SunabYn,
                        item.SunabDate,
                        item.SunabTime,
                        item.HopeDate,
                        item.HopeTime,
                        item.NurseConfirmUser,
                        item.NurseConfirmDate,
                        item.NurseConfirmTime,
                        item.NursePickupUser,
                        item.NursePickupDate,
                        item.NursePickupTime,
                        item.NurseHoldUser,
                        item.NurseHoldDate,
                        item.NurseHoldTime,
                        item.ReserDate,
                        item.ReserTime,
                        item.JubsuDate,
                        item.JubsuTime,
                        item.ActingDate,
                        item.ActingTime,
                        item.ActingDay,
                        item.ResultDate,
                        item.DcGubun,
                        item.DcYn,
                        item.BannabYn,
                        item.BannabConfirm,
                        item.SourceOrdKey,
                        item.OcsFlag,
                        item.SgCode,
                        item.SgYmd,
                        item.IoGubun2,
                        item.AfterActYn,
                        item.BichiYn,
                        item.DrgBunho,
                        item.SubSusul,
                        item.PrintYn,
                        item.Chisik,
                        item.TelYn,
                        item.OrderGubunBas,
                        item.InputControl,
                        item.SugaYn,
                        item.JaeryoYn,
                        item.WonyoiCheck,
                        item.EmergencyCheck,
                        item.SpecimenCheck,
                        item.PortableCheck,
                        item.BulyongCheck,
                        item.SunabCheck1,
                        //item.SunabCheck2,
                        item.DcCheck,
                        item.DcGubunCheck,
                        item.ConfirmCheck,
                        item.ReserYnCheck,
                        item.ChisikCheck,
                        item.NdayYn2,
                        item.DefaultJaeryoJundalYn,
                        item.DefaultWonyoiOrderYn,
                        item.SpecificComments,
                        item.SpecificCommentName,
                        item.SpecificCommentSysId,
                        item.SpecificCommentPgmId,
                        //item.OrderByKey,
                        //item.RowState,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #region GetGrdSangyongOrder
        /// <summary>
        /// GetGrdSangyongOrder
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdSangyongOrder(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            OCS0103U13GrdSangyongOrderListArgs args = new OCS0103U13GrdSangyongOrderListArgs();
            args.User = bvc["f_user"].VarValue;
            args.IoGubun = bvc["f_io_gubun"].VarValue;
            args.OrderGubun = bvc["f_order_gubun"].VarValue;
            args.OrderDate = bvc["f_order_date"].VarValue;
            args.SearchWord = bvc["f_search_word"].VarValue;
            args.WonnaeDrgYn = bvc["f_wonnae_drg_yn"].VarValue;
            args.ProtocolId = protocolId;
            args.PageNumber = bvc["f_page_number"].VarValue;
            args.Offset = "200";
            OCS0103U13GrdSangyongOrderListResult res = CloudService.Instance.Submit<OCS0103U13GrdSangyongOrderListResult,
                OCS0103U13GrdSangyongOrderListArgs>(args);

            if (null != res)
            {
                foreach (OCS0103U13GrdSangyongOrderListInfo item in res.GrdSangyongItem)
                {
                    lObj.Add(new object[]
                    {
                        item.SlipCode,
                        item.SlipName,
                        item.HangmogCode,
                        item.HangmogName,
                        item.Seq,
                        item.HospCode,
                        item.Memb,
                        item.MembGubun,
                        item.WonnaeDrgYn,
                        item.Rownum,
                        item.TrialFlag,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #region GetLaySpecimenTree
        /// <summary>
        /// GetLaySpecimenTree
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        //private IList<object[]> GetLaySpecimenTree(BindVarCollection bvc)
        //{
        //    IList<object[]> lObj = new List<object[]>();

        //    if (null != this._formResult)
        //    {
        //        foreach (OCS0103U13LaySpecimenTreeListInfo item in this._formResult.GrdSpecTreeItem)
        //        {
        //            lObj.Add(new object[]
        //            {
        //                item.SlipGubun,
        //                item.SlipGubunName,
        //                item.SlipCode,
        //                item.SlipName,
        //                item.CplCodeYn,
        //                item.Zero,
        //            });
        //        }
        //    }

        //    return lObj;
        //}
        #endregion

        #region Caching

        #region GetListCombo
        /// <summary>
        /// GetListCombo
        /// </summary>
        /// <returns></returns>
        private void GetListCombo()
        {
            OCS0103U13CboListResult res;

            OCS0103U13CboListArgs arg = new OCS0103U13CboListArgs();
            arg.ComboItemListInfo = new List<ComboDataSourceInfo>();
            arg.ComboItemListInfo.Add(new ComboDataSourceInfo("suryang", string.Empty, string.Empty, string.Empty));
            arg.ComboItemListInfo.Add(new ComboDataSourceInfo("nalsu", string.Empty, string.Empty, string.Empty));
            arg.ComboItemListInfo.Add(new ComboDataSourceInfo("order_gubun_bas", string.Empty, string.Empty, string.Empty));
            res = CacheService.Instance.Get<OCS0103U13CboListArgs, OCS0103U13CboListResult>(arg);

            this._cboListItems = res;
        }
        #endregion

        #region GetCboSearchCondition
        /// <summary>
        /// GetCboSearchCondition
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetCboSearchCondition(BindVarCollection bvc)
        {
            return _cboSearchCondLstItem ?? new List<object[]>();
        }
        #endregion

        #endregion

        #region ExecPrOcsApplyNdayOrder
        /// <summary>
        /// ExecPrOcsApplyNdayOrder
        /// </summary>
        private void ExecPrOcsApplyNdayOrder()
        {
            OCS0103U13PrOcsApplyNdayOrderArgs args = new OCS0103U13PrOcsApplyNdayOrderArgs();
            args.Bunho = mBunho;
            args.OrderDate = mOrderDate;
            OCS0103U13PrOcsApplyNdayOrderResult res = CloudService.Instance.Submit<OCS0103U13PrOcsApplyNdayOrderResult,
                OCS0103U13PrOcsApplyNdayOrderArgs>(args);

            if (null != res)
            {
                if (!res.Result)
                {
                    this.mbxMsg = XMsg.GetMsg("M005") + " - " + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...

                    MessageBox.Show(this.mbxMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (res.OutDataString != "0")
                {
                    this.mbxMsg = XMsg.GetMsg("M005") + " - " + res.OutDataString;  // 저장에 실패하였습니다 + 에러메세지...

                    MessageBox.Show(this.mbxMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region grdOrder_PreEndInitializing
        /// <summary>
        /// grdOrder_PreEndInitializing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdOrder_PreEndInitializing(object sender, EventArgs e)
        {
            try
            {
                //GetListCombo();

                ////this.xEditGridCell28.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
                //this.xEditGridCell387.ExecuteQuery = GetSuryangCbo; // suryang combobox
                //this.xEditGridCell398.ExecuteQuery = GetNalsuCbo; // nalsu combobox
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region DoFormLoad
        /// <summary>
        /// DoFormLoad
        /// </summary>
        private void DoFormLoad(string io_gubun)
        {
            GetComboDataSource();

            OCS0103U10FormLoadArgs args = new OCS0103U10FormLoadArgs();
            args.Bunho = mPatientInfo.GetPatientInfo == null ? string.Empty : mPatientInfo.GetPatientInfo["bunho"].ToString();
            args.GeneralDispYn = new GetUserOptionInfo(UserInfo.UserID, UserInfo.Gwa, "GENERAL_DISP_YN", io_gubun);
            args.InputTab = INPUTTAB;
            args.Memb = this.mMemb;
            args.OrderMode = ((int)this.mOrderMode).ToString();
            args.Pkinp1001 = mPatientInfo.GetPatientInfo == null ? string.Empty : mPatientInfo.GetPatientInfo["naewon_key"].ToString();
            args.SentouSearchYn = new GetUserOptionInfo(UserInfo.UserID, UserInfo.Gwa, "SENTOU_SEARCH_YN", this.IOEGUBUN);
            args.UsedTabInfo = new LoadOftenUsedTabInfo(this.mMemb, INPUTTAB);
            args.IsCheckDrgTime = this.IOEGUBUN == "O" && this.mPatientInfo.GetPatientInfo != null;
            args.CodeNameInfo = new LoadColumnCodeNameInfo("gwa_doctor", "%", this.mMemb, null, null);
            args.GwaDoctorCodeInfo = new GetMainGwaDoctorCodeInfo(this.mMemb);

            OCS0103U10FormLoadResult res = CloudService.Instance.Submit<OCS0103U10FormLoadResult,
                OCS0103U10FormLoadArgs>(args);

            _formResult = res ?? new OCS0103U10FormLoadResult();

            #region Load data into comboboxes
            this.cboSearchCondition.ExecuteQuery = GetCboSearchCondition;
            this.cboSearchCondition.SetDictDDLB();

            // cboInputGubun
            this.cboInputGubun.ExecuteQuery = GetCboInputGubun;
            this.cboInputGubun.SetDictDDLB();
            #endregion
        }
        #endregion

        #region GetListDataForSaveLayout
        /// <summary>
        /// GetListDataForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<OCS0103U10SaveLayoutInfo> GetListDataForSaveLayout()
        {
            List<OCS0103U10SaveLayoutInfo> lstResult = new List<OCS0103U10SaveLayoutInfo>();

            for (int i = 0; i < grdOrder.RowCount; i++)
            {
                if (grdOrder.GetRowState(i) == DataRowState.Unchanged) continue;

                OCS0103U10SaveLayoutInfo item = new OCS0103U10SaveLayoutInfo();
                item.UserId = UserInfo.UserID;
                item.OrderGubun = grdOrder.GetItemString(i, "order_gubun");
                item.Suryang = grdOrder.GetItemString(i, "suryang");
                item.DvTime = grdOrder.GetItemString(i, "dv_time");
                item.Dv = grdOrder.GetItemString(i, "dv");
                item.NdayYn = grdOrder.GetItemString(i, "nday_yn");
                item.Nalsu = grdOrder.GetItemString(i, "nalsu");
                item.Jusa = grdOrder.GetItemString(i, "jusa");
                item.BogyongCode = grdOrder.GetItemString(i, "bogyong_code");
                item.Emergency = grdOrder.GetItemString(i, "emergency");
                item.JaeryoJundalYn = grdOrder.GetItemString(i, "jaeryo_jundal_yn");
                item.JundalTable = grdOrder.GetItemString(i, "jundal_table");
                item.JundalPart = grdOrder.GetItemString(i, "jundal_part");
                item.MovePart = grdOrder.GetItemString(i, "move_part");
                item.Muhyo = grdOrder.GetItemString(i, "muhyo");
                item.PortableYn = grdOrder.GetItemString(i, "portable_yn");
                //item.AntiCancerYn                   = grdOrder.GetItemString(i, "anti_cancer_yn");
                item.DcYn = grdOrder.GetItemString(i, "dc_yn");
                item.DcGubun = grdOrder.GetItemString(i, "dc_gubun");
                item.BannabYn = grdOrder.GetItemString(i, "bannab_yn");
                item.BannabConfirm = grdOrder.GetItemString(i, "bannab_confirm");
                item.PowderYn = grdOrder.GetItemString(i, "powder_yn");
                item.HopeDate = grdOrder.GetItemString(i, "hope_date");
                item.HopeTime = grdOrder.GetItemString(i, "hope_time");
                item.Dv1 = grdOrder.GetItemString(i, "dv_1");
                item.Dv2 = grdOrder.GetItemString(i, "dv_2");
                item.Dv3 = grdOrder.GetItemString(i, "dv_3");
                item.Dv4 = grdOrder.GetItemString(i, "dv_4");
                item.Dv5 = grdOrder.GetItemString(i, "dv_5");
                item.Dv6 = grdOrder.GetItemString(i, "dv_6");
                item.Dv7 = grdOrder.GetItemString(i, "dv_7");
                item.Dv8 = grdOrder.GetItemString(i, "dv_8");
                item.MixGroup = grdOrder.GetItemString(i, "mix_group");
                item.OrderRemark = grdOrder.GetItemString(i, "order_remark");
                item.NurseRemark = grdOrder.GetItemString(i, "nurse_remark");
                item.BomOccurYn = grdOrder.GetItemString(i, "bom_occur_yn");
                item.BomSourceKey = grdOrder.GetItemString(i, "bom_source_key");
                item.NurseConfirmUser = grdOrder.GetItemString(i, "nurse_confirm_user");
                item.NurseConfirmDate = grdOrder.GetItemString(i, "nurse_confirm_date");
                item.NurseConfirmTime = grdOrder.GetItemString(i, "nurse_confirm_time");
                item.RegularYn = grdOrder.GetItemString(i, "regular_yn");
                item.HubalChangeYn = grdOrder.GetItemString(i, "hubal_change_yn");
                item.Pharmacy = grdOrder.GetItemString(i, "pharmacy");
                item.JusaSpdGubun = grdOrder.GetItemString(i, "jusa_spd_gubun");
                item.DrgPackYn = grdOrder.GetItemString(i, "drg_pack_yn");
                item.SortFkocskey = grdOrder.GetItemString(i, "sort_fkocskey");
                item.WonyoiOrderYn = grdOrder.GetItemString(i, "wonyoi_order_yn");
                item.SpecimenCode = grdOrder.GetItemString(i, "specimen_code");
                item.Pkocskey = grdOrder.GetItemString(i, "pkocskey");
                item.InputId = grdOrder.GetItemString(i, "input_id");
                item.HangmogCode = grdOrder.GetItemString(i, "hangmog_code");
                item.ActBuseo = grdOrder.GetItemString(i, "act_buseo");
                item.BichiYn = grdOrder.GetItemString(i, "bichi_yn");
                item.BogyongCodeSub = grdOrder.GetItemString(i, "bogyong_code_sub");
                item.Bunho = grdOrder.GetItemString(i, "bunho");
                item.InputPart = grdOrder.GetItemString(i, "input_part");
                item.GroupSer = grdOrder.GetItemString(i, "group_ser");
                item.Pay = grdOrder.GetItemString(i, "pay");
                item.OcsFlag = grdOrder.GetItemString(i, "ocs_flag");
                item.DrgBunho = grdOrder.GetItemString(i, "drg_bunho");
                item.InputTab = grdOrder.GetItemString(i, "input_tab");
                item.OrderDate = grdOrder.GetItemString(i, "order_date");
                item.InputGubun = grdOrder.GetItemString(i, "input_gubun");
                item.SlipCode = grdOrder.GetItemString(i, "slip_code");
                item.ReserDate = grdOrder.GetItemString(i, "reser_date");
                item.SgCode = grdOrder.GetItemString(i, "sg_code");
                item.SubSusul = grdOrder.GetItemString(i, "sub_susul");
                item.TelYn = grdOrder.GetItemString(i, "tel_yn");
                item.Seq = grdOrder.GetItemString(i, "seq");
                item.ReserTime = grdOrder.GetItemString(i, "reser_time");
                item.ActDoctor = grdOrder.GetItemString(i, "act_doctor");
                item.SgYmd = grdOrder.GetItemString(i, "sg_ymd");
                item.InOutKey = grdOrder.GetItemString(i, "in_out_key");
                item.Doctor = grdOrder.GetItemString(i, "doctor");
                item.ActGwa = grdOrder.GetItemString(i, "act_gwa");
                item.IoGubun = grdOrder.GetItemString(i, "io_gubun");
                item.InputDoctor = grdOrder.GetItemString(i, "input_doctor");
                item.InputGwa = grdOrder.GetItemString(i, "input_gwa");
                item.SourceOrdKey = grdOrder.GetItemString(i, "source_ord_key");

                item.RowState = grdOrder.GetRowState(i).ToString();
                lstResult.Add(item);
            }

            // Delete
            if (null != grdOrder.DeletedRowTable)
            {
                foreach (DataRow dr in grdOrder.DeletedRowTable.Rows)
                {
                    OCS0103U10SaveLayoutInfo item = new OCS0103U10SaveLayoutInfo();
                    item.Pkocskey = Convert.ToString(dr["pkocskey"]);
                    item.RowState = DataRowState.Deleted.ToString();
                    lstResult.Add(item);
                }
            }

            return lstResult;
        }
        #endregion

        #region GetGrdSearchOrder
        /// <summary>
        /// GetGrdSearchOrder
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdSearchOrder(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            OCS0103U13GrdSearchOrderListArgs arg = new OCS0103U13GrdSearchOrderListArgs();
            arg.OrderDate = bvc["f_order_date"].VarValue;
            arg.SearchWord = bvc["f_search_word"].VarValue;
            arg.ProtocolId = protocolId;
            OCS0103U13GrdSearchOrderListResult res = CloudService.Instance.Submit<OCS0103U13GrdSearchOrderListResult,
                OCS0103U13GrdSearchOrderListArgs>(arg);

            if (null != res)
            {
                foreach (OCS0103U13GrdSearchOrderListInfo item in res.GrdSearchOrderListItem)
                {
                    lObj.Add(new object[]
                    {
                        item.SlipCode,
                        item.SlipName,
                        item.HangmogCode,
                        item.HangmogName,
                        item.HospCode,
                        item.TrialFlg,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #region GetCboInputGubun
        /// <summary>
        /// GetCboInputGubun
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetCboInputGubun(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            OCS0103U10CboInputGubunResult res = CacheService.Instance.Get<OCS0103U10CboInputGubunArgs, OCS0103U10CboInputGubunResult>(new OCS0103U10CboInputGubunArgs());

            if (null != res)
            {
                foreach (SystemModels.ComboListItemInfo item in res.CboGubunItem)
                {
                    lObj.Add(new object[]
                    {
                        item.Code,
                        item.CodeName,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #region GetGrdDrgOrder
        /// <summary>
        /// GetGrdDrgOrder
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdDrgOrder(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            OCS0103U10GrdDrgOrderArgs args = new OCS0103U10GrdDrgOrderArgs();
            args.Code1 = bvc["f_code1"].VarValue;
            args.Mode = bvc["f_mode"].VarValue;
            args.OrderDate = bvc["f_order_date"].VarValue;
            args.SearchWord = bvc["f_search_word"].VarValue;
            args.WonnaeDrgYn = bvc["f_wonnae_drg_yn"].VarValue;
            args.ProtocolId = protocolId;
            args.PageNumber = bvc["f_page_number"].VarValue;
            args.OffSet = "200";
            OCS0103U10GrdDrgOrderResult res = CloudService.Instance.Submit<OCS0103U10GrdDrgOrderResult,
                OCS0103U10GrdDrgOrderArgs>(args);

            if (null != res)
            {
                foreach (OCS0103U10GrdDrgOrderInfo item in res.DrgOrderItem)
                {
                    lObj.Add(new object[]
                    {
                        item.HangmogCode,
                        item.HangmogName,
                        item.WonyoiOrderCrYn,
                        item.DefaultWonyoiOrderYn,
                        item.Code1,
                        item.DrgInfo,
                        item.OrderGubun,
                        item.OrderGubunName,
                        item.WonnaeDrgYn,
                        item.TrialFlg,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #region GetGrdGeneral
        /// <summary>
        /// GetGrdGeneral
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdGeneral(BindVarCollection bvc)
        {
            //OCS0103U10GrdGeneralInfo
            IList<object[]> lObj = new List<object[]>();

            OCS0103U10GrdGeneralArgs args = new OCS0103U10GrdGeneralArgs();
            args.Filter = bvc["f_filter"].VarValue;
            args.HangmogCode = bvc["f_hangmog_code"].VarValue;
            args.OrderDate = bvc["f_order_date"].VarValue;
            args.YakKijunCode = bvc["f_yak_kijun_code"].VarValue;
            OCS0103U10GrdGeneralResult res = CloudService.Instance.Submit<OCS0103U10GrdGeneralResult,
                OCS0103U10GrdGeneralArgs>(args);

            if (null != res)
            {
                foreach (OCS0103U10GrdGeneralInfo item in res.GrdGenItem)
                {
                    lObj.Add(new object[]
                    {
                        item.SlipCode,
                        item.SlipName,
                        item.HangmogCode,
                        item.HangmogName,
                        item.WonnaeDrgYn,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #region GetLayDrugTree
        /// <summary>
        /// GetLayDrugTree
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayDrugTree(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            OCS0103U10DrugTreeResult res = CloudService.Instance.Submit<OCS0103U10DrugTreeResult,
                OCS0103U10DrugTreeArgs>(new OCS0103U10DrugTreeArgs());

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.DrugTreeItem.ForEach(delegate(OCS0103U10DrugTreeInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Code,
                        item.CodeName,
                        item.Code1,
                        item.CodeName1,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetComboDataSource
        /// <summary>
        /// GetComboDataSource
        /// </summary>
        private void GetComboDataSource()
        {
            ComboResult dvTimeRes = CacheService.Instance.Get<ComboDvTimeArgs, ComboResult>(new ComboDvTimeArgs());
            if (null != dvTimeRes)
            {
                _dvTimeCbo = ConvertToDataTable(dvTimeRes.ComboItem);
            }

            ComboResult suryangRes = CacheService.Instance.Get<ComboSuryangArgs, ComboResult>(new ComboSuryangArgs());
            if (null != suryangRes)
            {
                _suryangCbo = ConvertToDataTable(suryangRes.ComboItem);
            }

            ComboResult dvRes = CacheService.Instance.Get<ComboDvArgs, ComboResult>(new ComboDvArgs());
            if (null != dvRes)
            {
                _dvCbo = ConvertToDataTable(dvRes.ComboItem);
            }

            ComboResult nalsuRes = CacheService.Instance.Get<ComboNalsuArgs, ComboResult>(new ComboNalsuArgs());
            if (null != nalsuRes)
            {
                _nalsuCbo = ConvertToDataTable(nalsuRes.ComboItem);
            }

            OCS0103U10SearchConditionCboResult scRes = CacheService.Instance.Get<OCS0103U10SearchConditionCboArgs,
                OCS0103U10SearchConditionCboResult>(new OCS0103U10SearchConditionCboArgs());
            if (null != scRes)
            {
                _cboSearchCondLstItem = new List<object[]>();
                foreach (SystemModels.ComboListItemInfo item in scRes.CboSearchConditionItem)
                {
                    _cboSearchCondLstItem.Add(new object[]
                    {
                        item.Code,
                        item.CodeName,
                    });
                }
            }
        }
        #endregion

        #region GetListDataForInterfaceInsert
        /// <summary>
        /// GetListDataForInterfaceInsert
        /// </summary>
        /// <returns></returns>
        private List<PrOcsInterfaceInsertInfo> GetListDataForInterfaceInsert()
        {
            List<PrOcsInterfaceInsertInfo> paramList = new List<PrOcsInterfaceInsertInfo>();

            foreach (Hashtable delItem in this.mInterface.MDeletedIfItems)
            {
                PrOcsInterfaceInsertInfo item = new PrOcsInterfaceInsertInfo(
                    Convert.ToString(delItem["io_gubun"]),
                    Convert.ToString(delItem["key"]),
                    Convert.ToString(delItem["user_id"]));

                paramList.Add(item);
            }

            foreach (Hashtable modItem in this.mInterface.MModifiedItems)
            {
                PrOcsInterfaceInsertInfo item = new PrOcsInterfaceInsertInfo(
                    Convert.ToString(modItem["io_gubun"]),
                    Convert.ToString(modItem["key"]),
                    Convert.ToString(modItem["user_id"]));

                paramList.Add(item);
            }

            return paramList;
        }
        #endregion

        public void ReLoadRegularOrder()
        {
            this.grdSangyongOrder.Reset();
            this.grdSangyongOrder.QueryLayout(true);
        }

        public void SetEventCbxWonyoiOrderYN(bool val)
        {
            if(val)
                this.cbxWonyoiOrderYN.CheckedChanged += new EventHandler(cbxWonyoiOrderYN_CheckedChanged);
            else
                this.cbxWonyoiOrderYN.CheckedChanged -= new EventHandler(cbxWonyoiOrderYN_CheckedChanged);
        }

        public void SetCbxWonyoiOrderYN(string s)
        {
            if (s == "Y")
                cbxWonyoiOrderYN.Checked = true;
            else
                cbxWonyoiOrderYN.Checked = false;
        }
        private void ResetGrd()
        {
            this.grdOrder.Reset();
            this.grdDrgOrder.Reset();
            this.grdGeneral.Reset();
            this.grdOutSang.Reset();
            this.grdSearchOrder.Reset();
            this.grdSangyongOrder.Reset();
            this.grdPreview.Reset();
        }

        #endregion

        private void GetUserOptions()
        {
            try
            {
                OCS2015U00GetUserOptionsArgs args = new OCS2015U00GetUserOptionsArgs();
                args.Gwa = UserInfo.Gwa;
                args.UserId = UserInfo.UserID;
                args.IoGubun = "O";
                OCS2015U00GetUserOptionsResult res = CloudService.Instance.Submit<OCS2015U00GetUserOptionsResult, OCS2015U00GetUserOptionsArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    potionDrugOrder = res.PotionDrugOrder;
                    
                }
            }
            catch
            {
                XMessageBox.Show("GetUserOptions fail!");
            }
        }

    }
    //insert by jc 
    #region XSavePeformer
    //public class XSavePeformer : ISavePerformer
    //{
    //    private OCS0103U10 parent = null;
    //    private IHIS.OCS.OrderBiz mOrderBiz = new OrderBiz("OCS0103U10");

    //    public XSavePeformer(OCS0103U10 parent)
    //    {
    //        this.parent = parent;
    //    }

    //    public bool Execute(char callerId, RowDataItem item)
    //    {
    //        string cmdText = "";
    //        object t_chk = "";
    //        string spName = "";
    //        ArrayList inList = new ArrayList();
    //        ArrayList outList = new ArrayList();

    //        item.BindVarList.Add("q_user_id", UserInfo.UserID);
    //        item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
    //        switch (callerId)
    //        {
    //            case '2':    // 삭제로직...

    //                #region 오더 삭제
    //                // 삭제시 DC 반납 원오더 원래대로 위치
    //                if (item.BindVarList["f_source_ord_key"].VarValue != "")
    //                {
    //                    inList.Clear();
    //                    outList.Clear();
    //                    inList.Add("I");
    //                    inList.Add(item.BindVarList["f_source_ord_key"].VarValue);

    //                    spName = "PR_OCS_UPDATE_DC_YN";

    //                    if (Service.ExecuteProcedure(spName, inList, outList) == false)
    //                    {
    //                        MessageBox.Show(Service.ErrFullMsg, "保存失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //                        return false;
    //                    }
    //                }

    //                // 현재 오더가 n데이 오더인경우 해당 키로 발생된 오더 삭제

    //                if (item.BindVarList["f_nday_yn"].VarValue == "Y")
    //                {
    //                    spName = "PR_OCS_DELETE_NDAY_ORDER";
    //                    inList.Clear();
    //                    inList.Add(item.BindVarList["f_pkocskey"].VarValue);
    //                    outList.Clear();

    //                    if (Service.ExecuteProcedure(spName, inList, outList) == false)
    //                    {
    //                        return false;
    //                    }

    //                    if (outList[0].ToString() != "0")
    //                    {
    //                        return false;
    //                    }
    //                }

    //                cmdText = " DELETE FROM OCS2003 "
    //                        + "  WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "
    //                        + "    AND PKOCS2003 = :f_pkocskey ";



    //                #endregion

    //                break;

    //            case '3':    // 인서트 & 업데이트 

    //                #region 오더 입력 및 변경

    //                switch (item.RowState)
    //                {
    //                    case DataRowState.Added:



    //                        // 키가 입력되지 않은경우 키를 따야함..
    //                        if (item.BindVarList["f_pkocskey"].VarValue == "")
    //                        {
    //                            cmdText = " SELECT OCSKEY_SEQ.NEXTVAL "
    //                                    + "   FROM SYS.DUAL ";

    //                            t_chk = Service.ExecuteScalar(cmdText);

    //                            item.BindVarList.Remove("f_pkocskey");
    //                            item.BindVarList.Add("f_pkocskey", t_chk.ToString());
    //                        }

    //                        // 시퀀스 가져오기
    //                        if (item.BindVarList["f_seq"].VarValue == "")
    //                        {
    //                            cmdText = " SELECT MAX(SEQ)+1 SEQ "
    //                                    + "   FROM OCS2003 "
    //                                    + "  WHERE HOSP_CODE  = '" + EnvironInfo.HospCode + "' "
    //                                    + "    AND BUNHO      = '" + item.BindVarList["f_bunho"].VarValue + "' "
    //                                    + "    AND FKINP1001  = " + item.BindVarList["f_in_out_key"].VarValue
    //                                    + "    AND ORDER_DATE = TO_DATE('" + item.BindVarList["f_order_date"].VarValue + "', 'YYYY/MM/DD')  ";

    //                            t_chk = Service.ExecuteScalar(cmdText);

    //                            if (TypeCheck.IsNull(t_chk) || t_chk.ToString() == "")
    //                            {
    //                                t_chk = "1";
    //                            }

    //                            item.BindVarList.Remove("f_seq");
    //                            item.BindVarList.Add("f_seq", t_chk.ToString());
    //                        }

    //                        cmdText = " INSERT INTO OCS2003 "
    //                                + "      ( SYS_DATE             , SYS_ID               , UPD_DATE          , UPD_ID                  , HOSP_CODE             , "
    //                                + "        PKOCS2003            , BUNHO                , ORDER_DATE        , ORDER_TIME              , DOCTOR                , "
    //                                + "        INPUT_ID             , INPUT_PART           , INPUT_GUBUN       , SEQ                     , RESIDENT              , "
    //                                + "        HANGMOG_CODE         , GROUP_SER            , SLIP_CODE         , NDAY_YN                 , ORDER_GUBUN           , "
    //                                + "        SPECIMEN_CODE        , SURYANG              , ORD_DANUI         , DV_TIME                 , DV                    , "
    //                                + "        NALSU                , JUSA                 , BOGYONG_CODE      , EMERGENCY               , JAERYO_JUNDAL_YN      , "
    //                                + "        JUNDAL_TABLE         , JUNDAL_PART          , MOVE_PART         , MUHYO                   , PORTABLE_YN           , "
    //                                + "        ANTI_CANCER_YN       , PAY                  , RESER_DATE        , RESER_TIME              , DC_YN                 , "
    //                                + "        DC_GUBUN             , BANNAB_YN            , BANNAB_CONFIRM    , ACT_DOCTOR              , ACT_GWA               , "
    //                                + "        ACT_BUSEO            , OCS_FLAG             , SG_CODE           , SG_YMD                  , IO_GUBUN              , "
    //                                + "        BICHI_YN             , DRG_BUNHO            , SUB_SUSUL         , WONYOI_ORDER_YN         , "
    //                                + "        POWDER_YN            , HOPE_DATE            , HOPE_TIME         , DV_1                    , "
    //                                + "        DV_2                 , DV_3                 , DV_4              , MIX_GROUP               , ORDER_REMARK          , "
    //                                + "        NURSE_REMARK         , BOM_OCCUR_YN         , BOM_SOURCE_KEY    , DISPLAY_YN              , NURSE_CONFIRM_USER    , "
    //                                + "        NURSE_CONFIRM_DATE   , NURSE_CONFIRM_TIME   , TEL_YN            , "
    //                                + "        REGULAR_YN           , INPUT_TAB            , HUBAL_CHANGE_YN   , PHARMACY                , INPUT_DOCTOR          , "
    //                                + "        JUSA_SPD_GUBUN       , DRG_PACK_YN          , SORT_FKOCSKEY     , FKINP1001               , INPUT_GWA             , "
    //                                + "        NDAY_OCCUR_YN        , DV_5                 , DV_6              , DV_7                    , DV_8                  , "
    //                                + "        BOGYONG_CODE_SUB     ) "
    //                                + " VALUES "
    //                                + "      ( SYSDATE              , :q_user_id           , SYSDATE           , :q_user_id              , :f_hosp_code             , "
    //                                + "        :f_pkocskey          , :f_bunho             , :f_order_date     , TO_CHAR(SYSDATE, 'HH24MI'), :f_doctor              , "
    //                                + "        :f_input_id          , :f_input_part        , :f_input_gubun    , :f_seq                  , :f_doctor                , "
    //                                + "        :f_hangmog_code      , :f_group_ser         , :f_slip_code      , :f_nday_yn              , :f_order_gubun           , "
    //                                + "        :f_specimen_code     , :f_suryang           , :f_ord_danui      , :f_dv_time              , :f_dv                    , "
    //                                + "        :f_nalsu             , :f_jusa              , :f_bogyong_code   , :f_emergency            , :f_jaeryo_jundal_yn      , "
    //                                + "        :f_jundal_table      , :f_jundal_part       , :f_move_part      , :f_muhyo                , :f_portable_yn           , "
    //                                + "        'N'                  , :f_pay               , :f_reser_date     , :f_reser_time           , :f_dc_yn                 , "
    //                                + "        :f_dc_gubun          , :f_bannab_yn         , :f_bannab_confirm , :f_act_doctor           , :f_act_gwa               , "
    //                                + "        :f_act_buseo         , :f_ocs_flag          , :f_sg_code        , :f_sg_ymd               , :f_io_gubun              , "
    //                                + "        :f_bichi_yn          , :f_drg_bunho         , :f_sub_susul      , :f_wonyoi_order_yn      , "
    //                                + "        :f_powder_yn         , :f_hope_date         , :f_hope_time      , :f_dv_1                 , "
    //                                + "        :f_dv_2              , :f_dv_3              , :f_dv_4           , :f_mix_group            , :f_order_remark          , "
    //                                + "        :f_nurse_remark      , :f_bom_occur_yn      , :f_bom_source_key , 'Y'                     , :f_nurse_confirm_user    , "
    //                                + "        :f_nurse_confirm_date, :f_nurse_confirm_time, :f_tel_yn         , "
    //                                + "        :f_regular_yn        , :f_input_tab         , :f_hubal_change_yn, :f_pharmacy             , :f_input_doctor          , "
    //                                + "        :f_jusa_spd_gubun    , :f_drg_pack_yn       , :f_sort_fkocskey  , :f_in_out_key           , :f_input_gwa             , "
    //                                + "        'N'                  , :f_dv_5              , :f_dv_6           , :f_dv_7                 , :f_dv_8                  , "
    //                                + "        :f_bogyong_code_sub  ) ";



    //                        break;

    //                    case DataRowState.Modified:

    //                        cmdText = " UPDATE OCS2003 "
    //                                + "    SET UPD_DATE         = SYSDATE "
    //                                + "      , UPD_ID           = :q_user_id "
    //                                + "      , ORDER_GUBUN      = :f_order_gubun "
    //                                + "      , SURYANG          = :f_suryang "
    //                                + "      , DV_TIME          = :f_dv_time "
    //                                + "      , DV               = :f_dv "
    //                                + "      , NDAY_YN          = :f_nday_yn "
    //                                + "      , NALSU            = :f_nalsu "
    //                                + "      , JUSA             = :f_jusa  "
    //                                + "      , BOGYONG_CODE     = :f_bogyong_code "
    //                                + "      , EMERGENCY        = :f_emergency "
    //                                + "      , JAERYO_JUNDAL_YN = :f_jaeryo_jundal_yn "
    //                                + "      , JUNDAL_TABLE     = :f_jundal_table "
    //                                + "      , JUNDAL_PART      = :f_jundal_part "
    //                                + "      , MOVE_PART        = :f_move_part "
    //                                + "      , MUHYO            = :f_muhyo "
    //                                + "      , PORTABLE_YN      = :f_portable_yn "
    //                                + "      , ANTI_CANCER_YN   = :f_anti_cancer_yn "
    //                                + "      , DC_YN            = :f_dc_yn "
    //                                + "      , DC_GUBUN         = :f_dc_gubun "
    //                                + "      , BANNAB_YN        = :f_bannab_yn "
    //                                + "      , BANNAB_CONFIRM   = :f_bannab_confirm "
    //                                + "      , POWDER_YN        = :f_powder_yn "
    //                                + "      , HOPE_DATE        = :f_hope_date "
    //                                + "      , HOPE_TIME        = :f_hope_time "
    //                                + "      , DV_1             = :f_dv_1 "
    //                                + "      , DV_2             = :f_dv_2 "
    //                                + "      , DV_3             = :f_dv_3 "
    //                                + "      , DV_4             = :f_dv_4 "
    //                                + "      , DV_5             = :f_dv_5 "
    //                                + "      , DV_6             = :f_dv_6 "
    //                                + "      , DV_7             = :f_dv_7 "
    //                                + "      , DV_8             = :f_dv_8 "
    //                                + "      , MIX_GROUP        = :f_mix_group "
    //                                + "      , ORDER_REMARK     = :f_order_remark "
    //                                + "      , NURSE_REMARK     = :f_nurse_remark "
    //                                + "      , BOM_OCCUR_YN     = :f_bom_occur_yn "
    //                                + "      , BOM_SOURCE_KEY   = :f_bom_source_key "
    //                                + "      , NURSE_CONFIRM_USER = :f_nurse_confirm_user "
    //                                + "      , NURSE_CONFIRM_DATE = :f_nurse_confirm_date "
    //                                + "      , NURSE_CONFIRM_TIME = :f_nurse_confirm_time "
    //                                + "      , REGULAR_YN       = :f_regular_yn "
    //                                + "      , HUBAL_CHANGE_YN  = :f_hubal_change_yn "
    //                                + "      , PHARMACY         = :f_pharmacy "
    //                                + "      , JUSA_SPD_GUBUN   = :f_jusa_spd_gubun "
    //                                + "      , DRG_PACK_YN      = :f_drg_pack_yn "
    //                                + "      , SORT_FKOCSKEY    = :f_sort_fkocskey "
    //                                + "      , WONYOI_ORDER_YN  = :f_wonyoi_order_yn "
    //                                + "      , DISPLAY_YN       = CASE WHEN DC_GUBUN = 'Y' AND SORT_FKOCSKEY IS NOT NULL AND :f_dc_gubun = 'N' THEN 'N' "
    //                                + "                                ELSE DISPLAY_YN END "
    //                                + "      , SPECIMEN_CODE    = :f_specimen_code "
    //                                + "  WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "
    //                                + "    AND PKOCS2003 = :f_pkocskey ";



    //                        break;

    //                }

    //                #endregion

    //                break;
    //        }

    //        bool isSuccess = Service.ExecuteNonQuery(cmdText, item.BindVarList);

    //        // 오더 업데이트의 경우는 정시약도 같이 업데이트 되어야 함.
    //        if (callerId == '3' && isSuccess)
    //        {
    //            if (this.mOrderBiz.SaveRegularOrder("2", item.BindVarList["f_pkocskey"].VarValue) == false)
    //            {
    //                isSuccess = false;
    //            }
    //            else
    //            {
    //                isSuccess = true;
    //            }
    //        }

    //        return isSuccess;
    //    }
    //}
    #endregion
}
