using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.Framework;
using IHIS.OCS;
using IHIS.OCSA.Properties;
using PatientInfo = IHIS.OCS.PatientInfo;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Arguments.System;

namespace IHIS.OCSA
{
    public partial class UCOCS0103U12C : XScreen
    {
        private DataTable grdOutSangDt;
        private bool isOpenPopUp = true;
        public DataTable GrdOutSangDt
        {
            get { return grdOutSangDt; }
            set { grdOutSangDt = value; }
        }

        private DataTable mDrugDt;
        private XEditGridCell xEditGridCell105;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell25;
        private bool isSearchFormKeyPress = false;
        private XFindWorker fwkFind;
        private FindColumnInfo findColumnInfo1;
        private FindColumnInfo findColumnInfo2;

        #region auto gen code
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCOCS0103U12C));
            this.pnlFill = new IHIS.Framework.XPanel();
            this.pnlRight = new IHIS.Framework.XPanel();
            this.pnlSangyong = new IHIS.Framework.XPanel();
            this.grdSangyongOrder = new IHIS.Framework.XEditGrid();
            this.xEditGridCell103 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.tabSangyongOrder = new IHIS.Framework.XTabControl();
            this.pnlSearchTool = new IHIS.Framework.XPanel();
            this.cboSearchCondition = new IHIS.Framework.XDictComboBox();
            this.cboQueryCon = new IHIS.Framework.XComboBox();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.txtSearch = new IHIS.Framework.XTextBox();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.btnInsert = new IHIS.Framework.XButton();
            this.cboInputGubun = new IHIS.Framework.XDictComboBox();
            this.lblInputGubun = new IHIS.Framework.XLabel();
            this.btnSelect = new IHIS.Framework.XButton();
            this.btnNewSelect = new IHIS.Framework.XButton();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnExpandSearch = new IHIS.Framework.XButton();
            this.rbnOftenOrder = new IHIS.Framework.XRadioButton();
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
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.xComboItem6 = new IHIS.Framework.XComboItem();
            this.xEditGridCell101 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell105 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.pnlOrderDetail = new IHIS.Framework.XPanel();
            this.pbxIsBgtDrg = new System.Windows.Forms.PictureBox();
            this.btnBroughtDrg = new IHIS.Framework.XButton();
            this.btnJungsiDrug = new IHIS.Framework.XButton();
            this.btnSetOrder = new IHIS.Framework.XButton();
            this.btnNalsu = new IHIS.Framework.XButton();
            this.btnDoOrder = new IHIS.Framework.XButton();
            this.btnExtend = new IHIS.Framework.XButton();
            this.dbxJusaName = new IHIS.Framework.XDisplayBox();
            this.fbxJusa = new IHIS.Framework.XFindBox();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.cboNalsu = new IHIS.Framework.XComboBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
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
            this.laySaveLayout = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem160 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem161 = new IHIS.Framework.MultiLayoutItem();
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
            this.layDeletedData = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem324 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem325 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem326 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem327 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem328 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem329 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem330 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem331 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem332 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem333 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem334 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem335 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem336 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem337 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem338 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem339 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem340 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem341 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem342 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem343 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem344 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem345 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem346 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem347 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem348 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem349 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem350 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem351 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem352 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem353 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem354 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem355 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem356 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem357 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem358 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem359 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem360 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem361 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem362 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem363 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem364 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem365 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem366 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem367 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem368 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem369 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem370 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem371 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem372 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem373 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem374 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem375 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem376 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem377 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem378 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem379 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem380 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem381 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem382 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem383 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem384 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem385 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem386 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem387 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem388 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem389 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem390 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem391 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem392 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem393 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem394 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem395 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem396 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem397 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem398 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem399 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem400 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem401 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem402 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem403 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem404 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem405 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem406 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem407 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem408 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem409 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem410 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem411 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem412 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem413 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem414 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem415 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem416 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem417 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem418 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem419 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem420 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem421 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem422 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem423 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem424 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem425 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem426 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem427 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem428 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem429 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem430 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem431 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem432 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem433 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem434 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem435 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem436 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem437 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem438 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem439 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem440 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem441 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem442 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem443 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem444 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem445 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem446 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem447 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem448 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem449 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem450 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem451 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem452 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem453 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem454 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem455 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem456 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem457 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem458 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem459 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem460 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem461 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem462 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem463 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem464 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem465 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem466 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem467 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem468 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem469 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem470 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem471 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem472 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem473 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem474 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem475 = new IHIS.Framework.MultiLayoutItem();
            this.fwkFind = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.pnlFill.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlSangyong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSangyongOrder)).BeginInit();
            this.pnlSearchTool.SuspendLayout();
            this.xPanel6.SuspendLayout();
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
            // pnlFill
            // 
            resources.ApplyResources(this.pnlFill, "pnlFill");
            this.pnlFill.Controls.Add(this.pnlRight);
            this.pnlFill.Controls.Add(this.xPanel2);
            this.pnlFill.Controls.Add(this.pnlOrderInfo);
            this.pnlFill.Name = "pnlFill";
            this.toolTip1.SetToolTip(this.pnlFill, resources.GetString("pnlFill.ToolTip"));
            // 
            // pnlRight
            // 
            resources.ApplyResources(this.pnlRight, "pnlRight");
            this.pnlRight.Controls.Add(this.pnlSangyong);
            this.pnlRight.Controls.Add(this.pnlSearchTool);
            this.pnlRight.Controls.Add(this.xPanel6);
            this.pnlRight.Name = "pnlRight";
            this.toolTip1.SetToolTip(this.pnlRight, resources.GetString("pnlRight.ToolTip"));
            // 
            // pnlSangyong
            // 
            resources.ApplyResources(this.pnlSangyong, "pnlSangyong");
            this.pnlSangyong.Controls.Add(this.grdSangyongOrder);
            this.pnlSangyong.Controls.Add(this.tabSangyongOrder);
            this.pnlSangyong.Name = "pnlSangyong";
            this.toolTip1.SetToolTip(this.pnlSangyong, resources.GetString("pnlSangyong.ToolTip"));
            // 
            // grdSangyongOrder
            // 
            resources.ApplyResources(this.grdSangyongOrder, "grdSangyongOrder");
            this.grdSangyongOrder.ApplyPaintEventToAllColumn = true;
            this.grdSangyongOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell103,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell79,
            this.xEditGridCell80,
            this.xEditGridCell82});
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
            this.grdSangyongOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdSangyongOrder_GridCellPainting);
            this.grdSangyongOrder.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdSangyongOrder_QueryStarting);
            this.grdSangyongOrder.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdSangyongOrder_DragEnter);
            this.grdSangyongOrder.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdSangyongOrder_GiveFeedback);
            this.grdSangyongOrder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdSangyongOrder_MouseDown);
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell103.CellName = "trial_flg";
            this.xEditGridCell103.Col = -1;
            this.xEditGridCell103.ExecuteQuery = null;
            this.xEditGridCell103.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell103, "xEditGridCell103");
            this.xEditGridCell103.IsVisible = false;
            this.xEditGridCell103.Row = -1;
            this.xEditGridCell103.RowFont = new System.Drawing.Font("Arial", 8.75F);
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
            this.xEditGridCell19.CellWidth = 84;
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
            this.xEditGridCell21.CellWidth = 314;
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
            // xEditGridCell79
            // 
            this.xEditGridCell79.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell79.CellName = "memb";
            this.xEditGridCell79.Col = -1;
            this.xEditGridCell79.ExecuteQuery = null;
            this.xEditGridCell79.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell79, "xEditGridCell79");
            this.xEditGridCell79.IsVisible = false;
            this.xEditGridCell79.Row = -1;
            this.xEditGridCell79.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell80.CellName = "memb_gubun";
            this.xEditGridCell80.Col = -1;
            this.xEditGridCell80.ExecuteQuery = null;
            this.xEditGridCell80.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell80, "xEditGridCell80");
            this.xEditGridCell80.IsVisible = false;
            this.xEditGridCell80.Row = -1;
            this.xEditGridCell80.RowFont = new System.Drawing.Font("Arial", 8.75F);
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
            // tabSangyongOrder
            // 
            resources.ApplyResources(this.tabSangyongOrder, "tabSangyongOrder");
            this.tabSangyongOrder.IDEPixelArea = true;
            this.tabSangyongOrder.IDEPixelBorder = false;
            this.tabSangyongOrder.Name = "tabSangyongOrder";
            this.toolTip1.SetToolTip(this.tabSangyongOrder, resources.GetString("tabSangyongOrder.ToolTip"));
            // 
            // pnlSearchTool
            // 
            resources.ApplyResources(this.pnlSearchTool, "pnlSearchTool");
            this.pnlSearchTool.Controls.Add(this.cboSearchCondition);
            this.pnlSearchTool.Controls.Add(this.cboQueryCon);
            this.pnlSearchTool.Controls.Add(this.xLabel2);
            this.pnlSearchTool.Controls.Add(this.txtSearch);
            this.pnlSearchTool.Controls.Add(this.xLabel5);
            this.pnlSearchTool.Name = "pnlSearchTool";
            this.toolTip1.SetToolTip(this.pnlSearchTool, resources.GetString("pnlSearchTool.ToolTip"));
            // 
            // cboSearchCondition
            // 
            resources.ApplyResources(this.cboSearchCondition, "cboSearchCondition");
            this.cboSearchCondition.ExecuteQuery = null;
            this.cboSearchCondition.Name = "cboSearchCondition";
            this.cboSearchCondition.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboSearchCondition.ParamList")));
            this.cboSearchCondition.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.toolTip1.SetToolTip(this.cboSearchCondition, resources.GetString("cboSearchCondition.ToolTip"));
            this.cboSearchCondition.SelectedValueChanged += new System.EventHandler(this.cboSearchCondition_SelectedValueChanged);
            // 
            // cboQueryCon
            // 
            resources.ApplyResources(this.cboQueryCon, "cboQueryCon");
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
            // xLabel2
            // 
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Name = "xLabel2";
            this.toolTip1.SetToolTip(this.xLabel2, resources.GetString("xLabel2.ToolTip"));
            // 
            // txtSearch
            // 
            resources.ApplyResources(this.txtSearch, "txtSearch");
            this.txtSearch.EnterKeyToTab = false;
            this.txtSearch.Name = "txtSearch";
            this.toolTip1.SetToolTip(this.txtSearch, resources.GetString("txtSearch.ToolTip"));
            this.txtSearch.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtSearch_DataValidating);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // xLabel5
            // 
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.Name = "xLabel5";
            this.toolTip1.SetToolTip(this.xLabel5, resources.GetString("xLabel5.ToolTip"));
            // 
            // xPanel6
            // 
            resources.ApplyResources(this.xPanel6, "xPanel6");
            this.xPanel6.Controls.Add(this.btnInsert);
            this.xPanel6.Controls.Add(this.cboInputGubun);
            this.xPanel6.Controls.Add(this.lblInputGubun);
            this.xPanel6.Controls.Add(this.btnSelect);
            this.xPanel6.Controls.Add(this.btnNewSelect);
            this.xPanel6.Name = "xPanel6";
            this.toolTip1.SetToolTip(this.xPanel6, resources.GetString("xPanel6.ToolTip"));
            // 
            // btnInsert
            // 
            resources.ApplyResources(this.btnInsert, "btnInsert");
            this.btnInsert.Image = global::IHIS.OCSA.Properties.Resources.Insert;
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.toolTip1.SetToolTip(this.btnInsert, resources.GetString("btnInsert.ToolTip"));
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // cboInputGubun
            // 
            resources.ApplyResources(this.cboInputGubun, "cboInputGubun");
            this.cboInputGubun.BackColor = IHIS.Framework.XColor.XCalendarSelectedDateBackColor;
            this.cboInputGubun.ExecuteQuery = null;
            this.cboInputGubun.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.cboInputGubun.Name = "cboInputGubun";
            this.cboInputGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboInputGubun.ParamList")));
            this.cboInputGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.toolTip1.SetToolTip(this.cboInputGubun, resources.GetString("cboInputGubun.ToolTip"));
            this.cboInputGubun.UserSQL = resources.GetString("cboInputGubun.UserSQL");
            // 
            // lblInputGubun
            // 
            resources.ApplyResources(this.lblInputGubun, "lblInputGubun");
            this.lblInputGubun.BackColor = IHIS.Framework.XColor.XCalendarFullHolidayTextColor;
            this.lblInputGubun.EdgeRounding = false;
            this.lblInputGubun.Name = "lblInputGubun";
            this.toolTip1.SetToolTip(this.lblInputGubun, resources.GetString("lblInputGubun.ToolTip"));
            // 
            // btnSelect
            // 
            resources.ApplyResources(this.btnSelect, "btnSelect");
            this.btnSelect.ImageIndex = 10;
            this.btnSelect.ImageList = this.ImageList;
            this.btnSelect.Name = "btnSelect";
            this.toolTip1.SetToolTip(this.btnSelect, resources.GetString("btnSelect.ToolTip"));
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnNewSelect
            // 
            resources.ApplyResources(this.btnNewSelect, "btnNewSelect");
            this.btnNewSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnNewSelect.Image")));
            this.btnNewSelect.Name = "btnNewSelect";
            this.btnNewSelect.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.toolTip1.SetToolTip(this.btnNewSelect, resources.GetString("btnNewSelect.ToolTip"));
            this.btnNewSelect.Click += new System.EventHandler(this.btnNewSelect_Click);
            // 
            // xPanel2
            // 
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackColor = IHIS.Framework.XColor.XRoundPanelBackColor;
            this.xPanel2.Controls.Add(this.btnExpandSearch);
            this.xPanel2.Controls.Add(this.rbnOftenOrder);
            this.xPanel2.Name = "xPanel2";
            this.toolTip1.SetToolTip(this.xPanel2, resources.GetString("xPanel2.ToolTip"));
            // 
            // btnExpandSearch
            // 
            resources.ApplyResources(this.btnExpandSearch, "btnExpandSearch");
            this.btnExpandSearch.ImageIndex = 4;
            this.btnExpandSearch.ImageList = this.ImageList;
            this.btnExpandSearch.Name = "btnExpandSearch";
            this.toolTip1.SetToolTip(this.btnExpandSearch, resources.GetString("btnExpandSearch.ToolTip"));
            this.btnExpandSearch.Click += new System.EventHandler(this.btnExpandSearch_Click);
            // 
            // rbnOftenOrder
            // 
            resources.ApplyResources(this.rbnOftenOrder, "rbnOftenOrder");
            this.rbnOftenOrder.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbnOftenOrder.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbnOftenOrder.ImageList = this.ImageList;
            this.rbnOftenOrder.Name = "rbnOftenOrder";
            this.rbnOftenOrder.TabStop = true;
            this.toolTip1.SetToolTip(this.rbnOftenOrder, resources.GetString("rbnOftenOrder.ToolTip"));
            this.rbnOftenOrder.UseVisualStyleBackColor = false;
            this.rbnOftenOrder.CheckedChanged += new System.EventHandler(this.OrderRadio_CheckedChanged);
            // 
            // pnlOrderInfo
            // 
            resources.ApplyResources(this.pnlOrderInfo, "pnlOrderInfo");
            this.pnlOrderInfo.Controls.Add(this.xPanel4);
            this.pnlOrderInfo.Controls.Add(this.pnlOrderDetail);
            this.pnlOrderInfo.Controls.Add(this.pnlOrderInput);
            this.pnlOrderInfo.Controls.Add(this.grdOutSang);
            this.pnlOrderInfo.Name = "pnlOrderInfo";
            this.toolTip1.SetToolTip(this.pnlOrderInfo, resources.GetString("pnlOrderInfo.ToolTip"));
            // 
            // xPanel4
            // 
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.Controls.Add(this.pnlStatus);
            this.xPanel4.Controls.Add(this.grdOrder);
            this.xPanel4.Name = "xPanel4";
            this.toolTip1.SetToolTip(this.xPanel4, resources.GetString("xPanel4.ToolTip"));
            // 
            // pnlStatus
            // 
            resources.ApplyResources(this.pnlStatus, "pnlStatus");
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.lbStatus);
            this.pnlStatus.Controls.Add(this.pgbProgress);
            this.pnlStatus.Name = "pnlStatus";
            this.toolTip1.SetToolTip(this.pnlStatus, resources.GetString("pnlStatus.ToolTip"));
            // 
            // lbStatus
            // 
            resources.ApplyResources(this.lbStatus, "lbStatus");
            this.lbStatus.BackColor = System.Drawing.Color.Transparent;
            this.lbStatus.ForeColor = System.Drawing.Color.Red;
            this.lbStatus.Name = "lbStatus";
            this.toolTip1.SetToolTip(this.lbStatus, resources.GetString("lbStatus.ToolTip"));
            // 
            // pgbProgress
            // 
            resources.ApplyResources(this.pgbProgress, "pgbProgress");
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
            this.xEditGridCell65,
            this.xEditGridCell75,
            this.xEditGridCell76,
            this.xEditGridCell77,
            this.xEditGridCell78,
            this.xEditGridCell84,
            this.xEditGridCell85,
            this.xEditGridCell86,
            this.xEditGridCell87,
            this.xEditGridCell88,
            this.xEditGridCell89,
            this.xEditGridCell91,
            this.xEditGridCell92,
            this.xEditGridCell93,
            this.xEditGridCell94,
            this.xEditGridCell95,
            this.xEditGridCell96,
            this.xEditGridCell98,
            this.xEditGridCell99,
            this.xEditGridCell100,
            this.xEditGridCell101,
            this.xEditGridCell24,
            this.xEditGridCell105,
            this.xEditGridCell25});
            this.grdOrder.ColPerLine = 33;
            this.grdOrder.Cols = 34;
            this.grdOrder.EnableMultiSelection = true;
            this.grdOrder.ExecuteQuery = null;
            this.grdOrder.FixedCols = 1;
            this.grdOrder.FixedRows = 2;
            this.grdOrder.HeaderHeights.Add(37);
            this.grdOrder.HeaderHeights.Add(0);
            this.grdOrder.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdOrder.Name = "grdOrder";
            this.grdOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOrder.ParamList")));
            this.grdOrder.QuerySQL = resources.GetString("grdOrder.QuerySQL");
            this.grdOrder.RowHeaderVisible = true;
            this.grdOrder.Rows = 3;
            this.grdOrder.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOrder.SelectionModeChangeable = true;
            this.grdOrder.ShowNumberAtRowHeader = false;
            this.grdOrder.TogglingRowSelection = true;
            this.toolTip1.SetToolTip(this.grdOrder, resources.GetString("grdOrder.ToolTip"));
            this.grdOrder.ToolTipActive = true;
            this.grdOrder.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOrder_GridColumnProtectModify);
            this.grdOrder.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdOrder_GridFindClick);
            this.grdOrder.GridReservedMemoButtonClick += new IHIS.Framework.GridReservedMemoButtonClickEventHandler(this.grdOrder_GridReservedMemoButtonClick);
            this.grdOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOrder_GridCellPainting);
            this.grdOrder.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOrder_GridColumnChanged);
            this.grdOrder.GridContDisplayed += new IHIS.Framework.XGridContDisplayedEventHandler(this.grdOrder_GridContDisplayed);
            this.grdOrder.Click += new System.EventHandler(this.grdOrder_Click);
            this.grdOrder.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdOrder_DragDrop);
            this.grdOrder.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdOrder_DragEnter);
            this.grdOrder.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdOrder_GiveFeedback);
            this.grdOrder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOrder_MouseDown);
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
            this.xEditGridCell371.CellWidth = 78;
            this.xEditGridCell371.Col = 3;
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
            this.xEditGridCell372.CellWidth = 27;
            this.xEditGridCell372.Col = 4;
            this.xEditGridCell372.ExecuteQuery = null;
            this.xEditGridCell372.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell372, "xEditGridCell372");
            this.xEditGridCell372.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell372.RowSpan = 2;
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
            this.xEditGridCell376.CellWidth = 65;
            this.xEditGridCell376.Col = 6;
            this.xEditGridCell376.ExecuteQuery = null;
            this.xEditGridCell376.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell376, "xEditGridCell376");
            this.xEditGridCell376.IsReadOnly = true;
            this.xEditGridCell376.IsUpdatable = false;
            this.xEditGridCell376.IsUpdCol = false;
            this.xEditGridCell376.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell376.RowSpan = 2;
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
            this.xEditGridCell380.CellLen = 100;
            this.xEditGridCell380.CellName = "hangmog_code";
            this.xEditGridCell380.CellWidth = 74;
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
            this.xEditGridCell384.CellWidth = 200;
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
            this.xEditGridCell387.CellWidth = 57;
            this.xEditGridCell387.Col = 11;
            this.xEditGridCell387.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.xEditGridCell387.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell387.ExecuteQuery = null;
            this.xEditGridCell387.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell387, "xEditGridCell387");
            this.xEditGridCell387.IsNotNull = true;
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
            this.xEditGridCell391.CellWidth = 60;
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
            this.xEditGridCell392.CellWidth = 25;
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
            this.xEditGridCell394.CellWidth = 45;
            this.xEditGridCell394.Col = -1;
            this.xEditGridCell394.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.xEditGridCell394.ExecuteQuery = null;
            this.xEditGridCell394.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell394, "xEditGridCell394");
            this.xEditGridCell394.IsVisible = false;
            this.xEditGridCell394.Row = -1;
            this.xEditGridCell394.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell394.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell395
            // 
            this.xEditGridCell395.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell395.CellName = "dv_2";
            this.xEditGridCell395.CellWidth = 45;
            this.xEditGridCell395.Col = -1;
            this.xEditGridCell395.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.xEditGridCell395.ExecuteQuery = null;
            this.xEditGridCell395.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell395, "xEditGridCell395");
            this.xEditGridCell395.IsVisible = false;
            this.xEditGridCell395.Row = -1;
            this.xEditGridCell395.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell395.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell396
            // 
            this.xEditGridCell396.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell396.CellName = "dv_3";
            this.xEditGridCell396.CellWidth = 45;
            this.xEditGridCell396.Col = -1;
            this.xEditGridCell396.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.xEditGridCell396.ExecuteQuery = null;
            this.xEditGridCell396.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell396, "xEditGridCell396");
            this.xEditGridCell396.IsVisible = false;
            this.xEditGridCell396.Row = -1;
            this.xEditGridCell396.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell396.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell397
            // 
            this.xEditGridCell397.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell397.CellName = "dv_4";
            this.xEditGridCell397.CellWidth = 45;
            this.xEditGridCell397.Col = -1;
            this.xEditGridCell397.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.xEditGridCell397.ExecuteQuery = null;
            this.xEditGridCell397.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell397, "xEditGridCell397");
            this.xEditGridCell397.IsVisible = false;
            this.xEditGridCell397.Row = -1;
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
            this.xEditGridCell402.CellWidth = 60;
            this.xEditGridCell402.Col = 16;
            this.xEditGridCell402.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell402.ExecuteQuery = null;
            this.xEditGridCell402.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell402, "xEditGridCell402");
            this.xEditGridCell402.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell402.RowSpan = 2;
            this.xEditGridCell402.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell402.UserSQL = "SELECT A.CODE, A.CODE_NAME\r\n  FROM OCS0132 A\r\n WHERE A.HOSP_CODE = FN_ADM_LOAD_HO" +
    "SP_CODE \r\n   AND A.CODE_TYPE = \'JUSA_SPD_GUBUN\'\r\n ORDER BY A.CODE";
            // 
            // xEditGridCell403
            // 
            this.xEditGridCell403.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell403.CellName = "bogyong_code";
            this.xEditGridCell403.CellWidth = 60;
            this.xEditGridCell403.Col = 15;
            this.xEditGridCell403.ExecuteQuery = null;
            this.xEditGridCell403.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell403, "xEditGridCell403");
            this.xEditGridCell403.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell403.RowSpan = 2;
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
            this.xEditGridCell408.CellName = "jundal_part";
            this.xEditGridCell408.CellWidth = 60;
            this.xEditGridCell408.Col = 23;
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
            this.xEditGridCell411.CellWidth = 60;
            this.xEditGridCell411.Col = 22;
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
            this.xEditGridCell412.CellWidth = 90;
            this.xEditGridCell412.Col = 26;
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
            this.xEditGridCell413.CellWidth = 50;
            this.xEditGridCell413.Col = 20;
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
            this.xEditGridCell414.CellWidth = 60;
            this.xEditGridCell414.Col = 17;
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
            this.xEditGridCell415.CellWidth = 60;
            this.xEditGridCell415.Col = 18;
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
            this.xEditGridCell417.CellWidth = 60;
            this.xEditGridCell417.Col = 21;
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
            this.xEditGridCell420.CellWidth = 62;
            this.xEditGridCell420.Col = 9;
            this.xEditGridCell420.DisplayMemoText = true;
            this.xEditGridCell420.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell420.ExecuteQuery = null;
            this.xEditGridCell420.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell420, "xEditGridCell420");
            this.xEditGridCell420.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell420.ReservedMemoClassName = "IHIS.OCS.ReservedComment";
            this.xEditGridCell420.ReservedMemoFileName = Application.StartupPath + "\\OCSA\\OCS.Lib.CommonForms.dll";
            this.xEditGridCell420.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell420.RowSpan = 2;
            this.xEditGridCell420.ShowReservedMemoButton = true;
            // 
            // xEditGridCell421
            // 
            this.xEditGridCell421.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell421.CellLen = 2000;
            this.xEditGridCell421.CellName = "nurse_remark";
            this.xEditGridCell421.CellWidth = 100;
            this.xEditGridCell421.Col = 27;
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
            this.xEditGridCell453.CellWidth = 60;
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
            this.xEditGridCell465.CellWidth = 25;
            this.xEditGridCell465.Col = 19;
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
            this.xEditGridCell48.CellWidth = 60;
            this.xEditGridCell48.Col = 28;
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
            this.xEditGridCell49.CellWidth = 60;
            this.xEditGridCell49.Col = 5;
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
            // xEditGridCell65
            // 
            this.xEditGridCell65.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell65.CellName = "wonnae_drg_yn";
            this.xEditGridCell65.Col = -1;
            this.xEditGridCell65.ExecuteQuery = null;
            this.xEditGridCell65.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.IsVisible = false;
            this.xEditGridCell65.Row = -1;
            this.xEditGridCell65.RowFont = new System.Drawing.Font("Arial", 8.75F);
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
            // xEditGridCell84
            // 
            this.xEditGridCell84.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell84.CellName = "jundal_table_out";
            this.xEditGridCell84.Col = -1;
            this.xEditGridCell84.ExecuteQuery = null;
            this.xEditGridCell84.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell84, "xEditGridCell84");
            this.xEditGridCell84.IsVisible = false;
            this.xEditGridCell84.Row = -1;
            this.xEditGridCell84.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell85.CellName = "jundal_part_out";
            this.xEditGridCell85.CellWidth = 120;
            this.xEditGridCell85.Col = 24;
            this.xEditGridCell85.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell85.ExecuteQuery = null;
            this.xEditGridCell85.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell85, "xEditGridCell85");
            this.xEditGridCell85.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell85.RowSpan = 2;
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell86.CellName = "jundal_table_inp";
            this.xEditGridCell86.Col = -1;
            this.xEditGridCell86.ExecuteQuery = null;
            this.xEditGridCell86.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell86, "xEditGridCell86");
            this.xEditGridCell86.IsVisible = false;
            this.xEditGridCell86.Row = -1;
            this.xEditGridCell86.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell87.CellName = "jundal_part_inp";
            this.xEditGridCell87.CellWidth = 120;
            this.xEditGridCell87.Col = 25;
            this.xEditGridCell87.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell87.ExecuteQuery = null;
            this.xEditGridCell87.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell87, "xEditGridCell87");
            this.xEditGridCell87.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell87.RowSpan = 2;
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell88.CellName = "move_part_out";
            this.xEditGridCell88.Col = -1;
            this.xEditGridCell88.ExecuteQuery = null;
            this.xEditGridCell88.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell88, "xEditGridCell88");
            this.xEditGridCell88.IsVisible = false;
            this.xEditGridCell88.Row = -1;
            this.xEditGridCell88.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell89.CellName = "move_part_inp";
            this.xEditGridCell89.Col = -1;
            this.xEditGridCell89.ExecuteQuery = null;
            this.xEditGridCell89.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell89, "xEditGridCell89");
            this.xEditGridCell89.IsVisible = false;
            this.xEditGridCell89.Row = -1;
            this.xEditGridCell89.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell91.CellName = "mixed_yn";
            this.xEditGridCell91.CellWidth = 25;
            this.xEditGridCell91.Col = 2;
            this.xEditGridCell91.ExecuteQuery = null;
            this.xEditGridCell91.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell91, "xEditGridCell91");
            this.xEditGridCell91.IsReadOnly = true;
            this.xEditGridCell91.IsUpdatable = false;
            this.xEditGridCell91.IsUpdCol = false;
            this.xEditGridCell91.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell91.RowSpan = 2;
            this.xEditGridCell91.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell92.CellName = "if_input_control";
            this.xEditGridCell92.Col = -1;
            this.xEditGridCell92.ExecuteQuery = null;
            this.xEditGridCell92.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell92, "xEditGridCell92");
            this.xEditGridCell92.IsUpdatable = false;
            this.xEditGridCell92.IsVisible = false;
            this.xEditGridCell92.Row = -1;
            this.xEditGridCell92.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell93.CellName = "bogyong_code_sub";
            this.xEditGridCell93.CellWidth = 60;
            this.xEditGridCell93.Col = 29;
            this.xEditGridCell93.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell93.ExecuteQuery = null;
            this.xEditGridCell93.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell93, "xEditGridCell93");
            this.xEditGridCell93.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell93.RowSpan = 2;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell94.CellName = "bogyong_name_sub";
            this.xEditGridCell94.Col = 30;
            this.xEditGridCell94.ExecuteQuery = null;
            this.xEditGridCell94.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell94, "xEditGridCell94");
            this.xEditGridCell94.IsReadOnly = true;
            this.xEditGridCell94.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell94.RowSpan = 2;
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell95.CellName = "pkocs1024";
            this.xEditGridCell95.Col = -1;
            this.xEditGridCell95.ExecuteQuery = null;
            this.xEditGridCell95.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell95, "xEditGridCell95");
            this.xEditGridCell95.IsReadOnly = true;
            this.xEditGridCell95.IsVisible = false;
            this.xEditGridCell95.Row = -1;
            this.xEditGridCell95.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell96.CellName = "brought_drg_yn";
            this.xEditGridCell96.CellWidth = 60;
            this.xEditGridCell96.Col = 31;
            this.xEditGridCell96.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell96.ExecuteQuery = null;
            this.xEditGridCell96.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell96, "xEditGridCell96");
            this.xEditGridCell96.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell96.RowSpan = 2;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell98.CellName = "jundal_part_name";
            this.xEditGridCell98.CellWidth = 45;
            this.xEditGridCell98.Col = -1;
            this.xEditGridCell98.ExecuteQuery = null;
            this.xEditGridCell98.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell98, "xEditGridCell98");
            this.xEditGridCell98.IsVisible = false;
            this.xEditGridCell98.Row = -1;
            this.xEditGridCell98.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell99.CellName = "instead_yn";
            this.xEditGridCell99.CellWidth = 60;
            this.xEditGridCell99.Col = 32;
            this.xEditGridCell99.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem3,
            this.xComboItem4});
            this.xEditGridCell99.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell99.ExecuteQuery = null;
            this.xEditGridCell99.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell99, "xEditGridCell99");
            this.xEditGridCell99.IsReadOnly = true;
            this.xEditGridCell99.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell99.RowSpan = 2;
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
            // xEditGridCell100
            // 
            this.xEditGridCell100.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell100.CellName = "approve_yn";
            this.xEditGridCell100.CellWidth = 60;
            this.xEditGridCell100.Col = 33;
            this.xEditGridCell100.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem5,
            this.xComboItem6});
            this.xEditGridCell100.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell100.ExecuteQuery = null;
            this.xEditGridCell100.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell100, "xEditGridCell100");
            this.xEditGridCell100.IsReadOnly = true;
            this.xEditGridCell100.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell100.RowSpan = 2;
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
            // xEditGridCell101
            // 
            this.xEditGridCell101.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell101.CellName = "postapprove_yn";
            this.xEditGridCell101.Col = -1;
            this.xEditGridCell101.ExecuteQuery = null;
            this.xEditGridCell101.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell101, "xEditGridCell101");
            this.xEditGridCell101.IsReadOnly = true;
            this.xEditGridCell101.IsVisible = false;
            this.xEditGridCell101.Row = -1;
            this.xEditGridCell101.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell24.CellName = "action_do_yn";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            this.xEditGridCell24.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            this.xEditGridCell24.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell105
            // 
            this.xEditGridCell105.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell105.CellName = "yj_code";
            this.xEditGridCell105.Col = -1;
            this.xEditGridCell105.ExecuteQuery = null;
            this.xEditGridCell105.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell105, "xEditGridCell105");
            this.xEditGridCell105.IsVisible = false;
            this.xEditGridCell105.Row = -1;
            this.xEditGridCell105.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell25.CellName = "common_yn";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            this.xEditGridCell25.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            this.xEditGridCell25.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 13;
            this.xGridHeader1.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 25;
            // 
            // pnlOrderDetail
            // 
            resources.ApplyResources(this.pnlOrderDetail, "pnlOrderDetail");
            this.pnlOrderDetail.Controls.Add(this.pbxIsBgtDrg);
            this.pnlOrderDetail.Controls.Add(this.btnBroughtDrg);
            this.pnlOrderDetail.Controls.Add(this.btnJungsiDrug);
            this.pnlOrderDetail.Controls.Add(this.btnSetOrder);
            this.pnlOrderDetail.Controls.Add(this.btnNalsu);
            this.pnlOrderDetail.Controls.Add(this.btnDoOrder);
            this.pnlOrderDetail.Controls.Add(this.btnExtend);
            this.pnlOrderDetail.Controls.Add(this.dbxJusaName);
            this.pnlOrderDetail.Controls.Add(this.fbxJusa);
            this.pnlOrderDetail.Controls.Add(this.xLabel8);
            this.pnlOrderDetail.Controls.Add(this.cboNalsu);
            this.pnlOrderDetail.Controls.Add(this.xLabel4);
            this.pnlOrderDetail.Controls.Add(this.cbxEmergency);
            this.pnlOrderDetail.Controls.Add(this.xLabel3);
            this.pnlOrderDetail.Controls.Add(this.cbxWonyoiOrderYN);
            this.pnlOrderDetail.DrawBorder = true;
            this.pnlOrderDetail.Name = "pnlOrderDetail";
            this.toolTip1.SetToolTip(this.pnlOrderDetail, resources.GetString("pnlOrderDetail.ToolTip"));
            // 
            // pbxIsBgtDrg
            // 
            resources.ApplyResources(this.pbxIsBgtDrg, "pbxIsBgtDrg");
            this.pbxIsBgtDrg.Name = "pbxIsBgtDrg";
            this.pbxIsBgtDrg.TabStop = false;
            this.toolTip1.SetToolTip(this.pbxIsBgtDrg, resources.GetString("pbxIsBgtDrg.ToolTip"));
            // 
            // btnBroughtDrg
            // 
            resources.ApplyResources(this.btnBroughtDrg, "btnBroughtDrg");
            this.btnBroughtDrg.ImageIndex = 7;
            this.btnBroughtDrg.ImageList = this.ImageList;
            this.btnBroughtDrg.Name = "btnBroughtDrg";
            this.btnBroughtDrg.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.toolTip1.SetToolTip(this.btnBroughtDrg, resources.GetString("btnBroughtDrg.ToolTip"));
            this.btnBroughtDrg.Click += new System.EventHandler(this.btnBroughtDrg_Click);
            // 
            // btnJungsiDrug
            // 
            resources.ApplyResources(this.btnJungsiDrug, "btnJungsiDrug");
            this.btnJungsiDrug.ImageIndex = 7;
            this.btnJungsiDrug.ImageList = this.ImageList;
            this.btnJungsiDrug.Name = "btnJungsiDrug";
            this.btnJungsiDrug.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.toolTip1.SetToolTip(this.btnJungsiDrug, resources.GetString("btnJungsiDrug.ToolTip"));
            this.btnJungsiDrug.Click += new System.EventHandler(this.btnJungsiDrug_Click);
            // 
            // btnSetOrder
            // 
            resources.ApplyResources(this.btnSetOrder, "btnSetOrder");
            this.btnSetOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnSetOrder.Image")));
            this.btnSetOrder.Name = "btnSetOrder";
            this.btnSetOrder.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.toolTip1.SetToolTip(this.btnSetOrder, resources.GetString("btnSetOrder.ToolTip"));
            this.btnSetOrder.Click += new System.EventHandler(this.btnSetOrder_Click);
            // 
            // btnNalsu
            // 
            resources.ApplyResources(this.btnNalsu, "btnNalsu");
            this.btnNalsu.Image = ((System.Drawing.Image)(resources.GetObject("btnNalsu.Image")));
            this.btnNalsu.Name = "btnNalsu";
            this.toolTip1.SetToolTip(this.btnNalsu, resources.GetString("btnNalsu.ToolTip"));
            this.btnNalsu.Click += new System.EventHandler(this.btnNalsu_Click);
            // 
            // btnDoOrder
            // 
            resources.ApplyResources(this.btnDoOrder, "btnDoOrder");
            this.btnDoOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnDoOrder.Image")));
            this.btnDoOrder.Name = "btnDoOrder";
            this.toolTip1.SetToolTip(this.btnDoOrder, resources.GetString("btnDoOrder.ToolTip"));
            this.btnDoOrder.Click += new System.EventHandler(this.btnDoOrder_Click);
            // 
            // btnExtend
            // 
            resources.ApplyResources(this.btnExtend, "btnExtend");
            this.btnExtend.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExtend.ImageIndex = 3;
            this.btnExtend.ImageList = this.ImageList;
            this.btnExtend.Name = "btnExtend";
            this.toolTip1.SetToolTip(this.btnExtend, resources.GetString("btnExtend.ToolTip"));
            this.btnExtend.Click += new System.EventHandler(this.btnExtend_Click);
            // 
            // dbxJusaName
            // 
            resources.ApplyResources(this.dbxJusaName, "dbxJusaName");
            this.dbxJusaName.AllowDrop = true;
            this.dbxJusaName.Name = "dbxJusaName";
            this.toolTip1.SetToolTip(this.dbxJusaName, resources.GetString("dbxJusaName.ToolTip"));
            this.dbxJusaName.Click += new System.EventHandler(this.dbxJusaName_Click);
            // 
            // fbxJusa
            // 
            resources.ApplyResources(this.fbxJusa, "fbxJusa");
            this.fbxJusa.AutoTabDataSelected = true;
            this.fbxJusa.FindWorker = this.fwkFind;
            this.fbxJusa.Name = "fbxJusa";
            this.toolTip1.SetToolTip(this.fbxJusa, resources.GetString("fbxJusa.ToolTip"));
            this.fbxJusa.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxJusa_FindClick);
            this.fbxJusa.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxJusa_DataValidating);
            this.fbxJusa.TextChanged += new System.EventHandler(this.fbxJusa_TextChanged);
            // 
            // xLabel8
            // 
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.EdgeRounding = false;
            this.xLabel8.Name = "xLabel8";
            this.toolTip1.SetToolTip(this.xLabel8, resources.GetString("xLabel8.ToolTip"));
            // 
            // cboNalsu
            // 
            resources.ApplyResources(this.cboNalsu, "cboNalsu");
            this.cboNalsu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboNalsu.Name = "cboNalsu";
            this.toolTip1.SetToolTip(this.cboNalsu, resources.GetString("cboNalsu.ToolTip"));
            this.cboNalsu.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.cboNalsu_DataValidating);
            this.cboNalsu.SelectedValueChanged += new System.EventHandler(this.cboNalsu_SelectedValueChanged);
            this.cboNalsu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cboNalsu_MouseDown);
            // 
            // xLabel4
            // 
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.Name = "xLabel4";
            this.toolTip1.SetToolTip(this.xLabel4, resources.GetString("xLabel4.ToolTip"));
            // 
            // cbxEmergency
            // 
            resources.ApplyResources(this.cbxEmergency, "cbxEmergency");
            this.cbxEmergency.Name = "cbxEmergency";
            this.toolTip1.SetToolTip(this.cbxEmergency, resources.GetString("cbxEmergency.ToolTip"));
            this.cbxEmergency.UseVisualStyleBackColor = false;
            this.cbxEmergency.CheckedChanged += new System.EventHandler(this.cbxEmergency_CheckedChanged);
            // 
            // xLabel3
            // 
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.ForeColor = IHIS.Framework.XColor.XCalendarHeaderTextColor;
            this.xLabel3.Name = "xLabel3";
            this.toolTip1.SetToolTip(this.xLabel3, resources.GetString("xLabel3.ToolTip"));
            // 
            // cbxWonyoiOrderYN
            // 
            resources.ApplyResources(this.cbxWonyoiOrderYN, "cbxWonyoiOrderYN");
            this.cbxWonyoiOrderYN.Name = "cbxWonyoiOrderYN";
            this.toolTip1.SetToolTip(this.cbxWonyoiOrderYN, resources.GetString("cbxWonyoiOrderYN.ToolTip"));
            this.cbxWonyoiOrderYN.UseVisualStyleBackColor = false;
            this.cbxWonyoiOrderYN.CheckedChanged += new System.EventHandler(this.cbxWonyoiOrderYN_CheckedChanged);
            // 
            // pnlOrderInput
            // 
            resources.ApplyResources(this.pnlOrderInput, "pnlOrderInput");
            this.pnlOrderInput.Controls.Add(this.xPanel1);
            this.pnlOrderInput.Name = "pnlOrderInput";
            this.toolTip1.SetToolTip(this.pnlOrderInput, resources.GetString("pnlOrderInput.ToolTip"));
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackColor = IHIS.Framework.XColor.XRoundPanelBackColor;
            this.xPanel1.Controls.Add(this.tabGroup);
            this.xPanel1.Name = "xPanel1";
            this.toolTip1.SetToolTip(this.xPanel1, resources.GetString("xPanel1.ToolTip"));
            // 
            // tabGroup
            // 
            resources.ApplyResources(this.tabGroup, "tabGroup");
            this.tabGroup.IDEPixelArea = true;
            this.tabGroup.IDEPixelBorder = false;
            this.tabGroup.Name = "tabGroup";
            this.toolTip1.SetToolTip(this.tabGroup, resources.GetString("tabGroup.ToolTip"));
            this.tabGroup.ClosePressed += new System.EventHandler(this.tabGroup_ClosePressed);
            this.tabGroup.SelectionChanging += new System.EventHandler(this.tabGroup_SelectionChanging);
            this.tabGroup.SelectionChanged += new System.EventHandler(this.tabGroup_SelectionChanged);
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
            this.multiLayoutItem21,
            this.multiLayoutItem22,
            this.multiLayoutItem23,
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem26,
            this.multiLayoutItem27,
            this.multiLayoutItem28,
            this.multiLayoutItem29,
            this.multiLayoutItem32});
            this.layPreview.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layPreview.ParamList")));
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "group_ser";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "order_gubun";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "hangmog_name";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "suryang";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "hoisu";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "dc_gubun";
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "nalsu";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "order_data_yn";
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "row_num";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "danui";
            // 
            // laySaveLayout
            // 
            this.laySaveLayout.CallerID = '3';
            this.laySaveLayout.ExecuteQuery = null;
            this.laySaveLayout.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem160,
            this.multiLayoutItem161,
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
            this.multiLayoutItem306});
            this.laySaveLayout.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySaveLayout.ParamList")));
            this.laySaveLayout.UseDefaultTransaction = false;
            // 
            // multiLayoutItem160
            // 
            this.multiLayoutItem160.DataName = "in_out_key";
            this.multiLayoutItem160.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem160.IsUpdItem = true;
            // 
            // multiLayoutItem161
            // 
            this.multiLayoutItem161.DataName = "pkocskey";
            this.multiLayoutItem161.IsUpdItem = true;
            // 
            // multiLayoutItem162
            // 
            this.multiLayoutItem162.DataName = "bunho";
            this.multiLayoutItem162.IsUpdItem = true;
            // 
            // multiLayoutItem163
            // 
            this.multiLayoutItem163.DataName = "order_date";
            this.multiLayoutItem163.IsUpdItem = true;
            // 
            // multiLayoutItem164
            // 
            this.multiLayoutItem164.DataName = "gwa";
            this.multiLayoutItem164.IsUpdItem = true;
            // 
            // multiLayoutItem165
            // 
            this.multiLayoutItem165.DataName = "doctor";
            this.multiLayoutItem165.IsUpdItem = true;
            // 
            // multiLayoutItem166
            // 
            this.multiLayoutItem166.DataName = "resident";
            this.multiLayoutItem166.IsUpdItem = true;
            // 
            // multiLayoutItem167
            // 
            this.multiLayoutItem167.DataName = "naewon_type";
            this.multiLayoutItem167.IsUpdItem = true;
            // 
            // multiLayoutItem168
            // 
            this.multiLayoutItem168.DataName = "jubsu_no";
            this.multiLayoutItem168.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem168.IsUpdItem = true;
            // 
            // multiLayoutItem169
            // 
            this.multiLayoutItem169.DataName = "input_id";
            this.multiLayoutItem169.IsUpdItem = true;
            // 
            // multiLayoutItem170
            // 
            this.multiLayoutItem170.DataName = "input_part";
            this.multiLayoutItem170.IsUpdItem = true;
            // 
            // multiLayoutItem171
            // 
            this.multiLayoutItem171.DataName = "input_gwa";
            this.multiLayoutItem171.IsUpdItem = true;
            // 
            // multiLayoutItem172
            // 
            this.multiLayoutItem172.DataName = "input_doctor";
            this.multiLayoutItem172.IsUpdItem = true;
            // 
            // multiLayoutItem173
            // 
            this.multiLayoutItem173.DataName = "input_gubun";
            this.multiLayoutItem173.IsUpdItem = true;
            // 
            // multiLayoutItem174
            // 
            this.multiLayoutItem174.DataName = "input_gubun_name";
            // 
            // multiLayoutItem175
            // 
            this.multiLayoutItem175.DataName = "group_ser";
            this.multiLayoutItem175.IsUpdItem = true;
            // 
            // multiLayoutItem176
            // 
            this.multiLayoutItem176.DataName = "input_tab";
            this.multiLayoutItem176.IsUpdItem = true;
            // 
            // multiLayoutItem177
            // 
            this.multiLayoutItem177.DataName = "input_tab_name";
            // 
            // multiLayoutItem178
            // 
            this.multiLayoutItem178.DataName = "order_gubun";
            this.multiLayoutItem178.IsUpdItem = true;
            // 
            // multiLayoutItem179
            // 
            this.multiLayoutItem179.DataName = "order_gubun_name";
            // 
            // multiLayoutItem180
            // 
            this.multiLayoutItem180.DataName = "group_yn";
            this.multiLayoutItem180.IsUpdItem = true;
            // 
            // multiLayoutItem181
            // 
            this.multiLayoutItem181.DataName = "seq";
            this.multiLayoutItem181.IsUpdItem = true;
            // 
            // multiLayoutItem182
            // 
            this.multiLayoutItem182.DataName = "slip_code";
            this.multiLayoutItem182.IsUpdItem = true;
            // 
            // multiLayoutItem183
            // 
            this.multiLayoutItem183.DataName = "hangmog_code";
            this.multiLayoutItem183.IsUpdItem = true;
            // 
            // multiLayoutItem184
            // 
            this.multiLayoutItem184.DataName = "hangmog_name";
            // 
            // multiLayoutItem185
            // 
            this.multiLayoutItem185.DataName = "specimen_code";
            this.multiLayoutItem185.IsUpdItem = true;
            // 
            // multiLayoutItem186
            // 
            this.multiLayoutItem186.DataName = "specimen_name";
            // 
            // multiLayoutItem187
            // 
            this.multiLayoutItem187.DataName = "suryang";
            this.multiLayoutItem187.IsUpdItem = true;
            // 
            // multiLayoutItem188
            // 
            this.multiLayoutItem188.DataName = "sunab_suryang";
            this.multiLayoutItem188.IsUpdItem = true;
            // 
            // multiLayoutItem189
            // 
            this.multiLayoutItem189.DataName = "subul_suryang";
            this.multiLayoutItem189.IsUpdItem = true;
            // 
            // multiLayoutItem190
            // 
            this.multiLayoutItem190.DataName = "ord_danui";
            this.multiLayoutItem190.IsUpdItem = true;
            // 
            // multiLayoutItem191
            // 
            this.multiLayoutItem191.DataName = "ord_danui_name";
            // 
            // multiLayoutItem192
            // 
            this.multiLayoutItem192.DataName = "dv_time";
            this.multiLayoutItem192.IsUpdItem = true;
            // 
            // multiLayoutItem193
            // 
            this.multiLayoutItem193.DataName = "dv";
            this.multiLayoutItem193.IsUpdItem = true;
            // 
            // multiLayoutItem194
            // 
            this.multiLayoutItem194.DataName = "dv_1";
            this.multiLayoutItem194.IsUpdItem = true;
            // 
            // multiLayoutItem195
            // 
            this.multiLayoutItem195.DataName = "dv_2";
            this.multiLayoutItem195.IsUpdItem = true;
            // 
            // multiLayoutItem196
            // 
            this.multiLayoutItem196.DataName = "dv_3";
            this.multiLayoutItem196.IsUpdItem = true;
            // 
            // multiLayoutItem197
            // 
            this.multiLayoutItem197.DataName = "dv_4";
            this.multiLayoutItem197.IsUpdItem = true;
            // 
            // multiLayoutItem198
            // 
            this.multiLayoutItem198.DataName = "nalsu";
            this.multiLayoutItem198.IsUpdItem = true;
            // 
            // multiLayoutItem199
            // 
            this.multiLayoutItem199.DataName = "sunab_nalsu";
            this.multiLayoutItem199.IsUpdItem = true;
            // 
            // multiLayoutItem200
            // 
            this.multiLayoutItem200.DataName = "jusa";
            this.multiLayoutItem200.IsUpdItem = true;
            // 
            // multiLayoutItem201
            // 
            this.multiLayoutItem201.DataName = "jusa_name";
            this.multiLayoutItem201.IsUpdItem = true;
            // 
            // multiLayoutItem202
            // 
            this.multiLayoutItem202.DataName = "jusa_spd_gubun";
            this.multiLayoutItem202.IsUpdItem = true;
            // 
            // multiLayoutItem203
            // 
            this.multiLayoutItem203.DataName = "bogyong_code";
            this.multiLayoutItem203.IsUpdItem = true;
            // 
            // multiLayoutItem204
            // 
            this.multiLayoutItem204.DataName = "bogyong_name";
            this.multiLayoutItem204.IsUpdItem = true;
            // 
            // multiLayoutItem205
            // 
            this.multiLayoutItem205.DataName = "emergency";
            this.multiLayoutItem205.IsUpdItem = true;
            // 
            // multiLayoutItem206
            // 
            this.multiLayoutItem206.DataName = "jaeryo_jundal_yn";
            this.multiLayoutItem206.IsUpdItem = true;
            // 
            // multiLayoutItem207
            // 
            this.multiLayoutItem207.DataName = "jundal_table";
            this.multiLayoutItem207.IsUpdItem = true;
            // 
            // multiLayoutItem208
            // 
            this.multiLayoutItem208.DataName = "jundal_part";
            this.multiLayoutItem208.IsUpdItem = true;
            // 
            // multiLayoutItem209
            // 
            this.multiLayoutItem209.DataName = "move_part";
            this.multiLayoutItem209.IsUpdItem = true;
            // 
            // multiLayoutItem210
            // 
            this.multiLayoutItem210.DataName = "portable_yn";
            this.multiLayoutItem210.IsUpdItem = true;
            // 
            // multiLayoutItem211
            // 
            this.multiLayoutItem211.DataName = "powder_yn";
            this.multiLayoutItem211.IsUpdItem = true;
            // 
            // multiLayoutItem212
            // 
            this.multiLayoutItem212.DataName = "hubal_change_yn";
            this.multiLayoutItem212.IsUpdItem = true;
            // 
            // multiLayoutItem213
            // 
            this.multiLayoutItem213.DataName = "pharmacy";
            this.multiLayoutItem213.IsUpdItem = true;
            // 
            // multiLayoutItem214
            // 
            this.multiLayoutItem214.DataName = "drg_pack_yn";
            this.multiLayoutItem214.IsUpdItem = true;
            // 
            // multiLayoutItem215
            // 
            this.multiLayoutItem215.DataName = "muhyo";
            this.multiLayoutItem215.IsUpdItem = true;
            // 
            // multiLayoutItem216
            // 
            this.multiLayoutItem216.DataName = "prn_yn";
            this.multiLayoutItem216.IsUpdItem = true;
            // 
            // multiLayoutItem217
            // 
            this.multiLayoutItem217.DataName = "toiwon_drg_yn";
            this.multiLayoutItem217.IsUpdItem = true;
            // 
            // multiLayoutItem218
            // 
            this.multiLayoutItem218.DataName = "prn_nurse";
            this.multiLayoutItem218.IsUpdItem = true;
            // 
            // multiLayoutItem219
            // 
            this.multiLayoutItem219.DataName = "append_yn";
            this.multiLayoutItem219.IsUpdItem = true;
            // 
            // multiLayoutItem220
            // 
            this.multiLayoutItem220.DataName = "order_remark";
            this.multiLayoutItem220.IsUpdItem = true;
            // 
            // multiLayoutItem221
            // 
            this.multiLayoutItem221.DataName = "nurse_remark";
            this.multiLayoutItem221.IsUpdItem = true;
            // 
            // multiLayoutItem222
            // 
            this.multiLayoutItem222.DataName = "comment";
            this.multiLayoutItem222.IsUpdItem = true;
            // 
            // multiLayoutItem223
            // 
            this.multiLayoutItem223.DataName = "mix_group";
            this.multiLayoutItem223.IsUpdItem = true;
            // 
            // multiLayoutItem224
            // 
            this.multiLayoutItem224.DataName = "amt";
            this.multiLayoutItem224.IsUpdItem = true;
            // 
            // multiLayoutItem225
            // 
            this.multiLayoutItem225.DataName = "pay";
            this.multiLayoutItem225.IsUpdItem = true;
            // 
            // multiLayoutItem226
            // 
            this.multiLayoutItem226.DataName = "wonyoi_order_yn";
            this.multiLayoutItem226.IsUpdItem = true;
            // 
            // multiLayoutItem227
            // 
            this.multiLayoutItem227.DataName = "dangil_gumsa_order_yn";
            this.multiLayoutItem227.IsUpdItem = true;
            // 
            // multiLayoutItem228
            // 
            this.multiLayoutItem228.DataName = "dangil_gumsa_result_yn";
            this.multiLayoutItem228.IsUpdItem = true;
            // 
            // multiLayoutItem229
            // 
            this.multiLayoutItem229.DataName = "bom_occur_yn";
            this.multiLayoutItem229.IsUpdItem = true;
            // 
            // multiLayoutItem230
            // 
            this.multiLayoutItem230.DataName = "bom_source_key";
            this.multiLayoutItem230.IsUpdItem = true;
            // 
            // multiLayoutItem231
            // 
            this.multiLayoutItem231.DataName = "display_yn";
            this.multiLayoutItem231.IsUpdItem = true;
            // 
            // multiLayoutItem232
            // 
            this.multiLayoutItem232.DataName = "sunab_yn";
            this.multiLayoutItem232.IsUpdItem = true;
            // 
            // multiLayoutItem233
            // 
            this.multiLayoutItem233.DataName = "sunab_date";
            this.multiLayoutItem233.IsUpdItem = true;
            // 
            // multiLayoutItem234
            // 
            this.multiLayoutItem234.DataName = "sunab_time";
            this.multiLayoutItem234.IsUpdItem = true;
            // 
            // multiLayoutItem235
            // 
            this.multiLayoutItem235.DataName = "hope_date";
            this.multiLayoutItem235.IsUpdItem = true;
            // 
            // multiLayoutItem236
            // 
            this.multiLayoutItem236.DataName = "hope_time";
            this.multiLayoutItem236.IsUpdItem = true;
            // 
            // multiLayoutItem237
            // 
            this.multiLayoutItem237.DataName = "nurse_confirm_user";
            this.multiLayoutItem237.IsUpdItem = true;
            // 
            // multiLayoutItem238
            // 
            this.multiLayoutItem238.DataName = "nurse_confirm_date";
            this.multiLayoutItem238.IsUpdItem = true;
            // 
            // multiLayoutItem239
            // 
            this.multiLayoutItem239.DataName = "nurse_confirm_time";
            this.multiLayoutItem239.IsUpdItem = true;
            // 
            // multiLayoutItem240
            // 
            this.multiLayoutItem240.DataName = "nurse_pickup_user";
            this.multiLayoutItem240.IsUpdItem = true;
            // 
            // multiLayoutItem241
            // 
            this.multiLayoutItem241.DataName = "nurse_pickup_date";
            this.multiLayoutItem241.IsUpdItem = true;
            // 
            // multiLayoutItem242
            // 
            this.multiLayoutItem242.DataName = "nurse_pickup_time";
            this.multiLayoutItem242.IsUpdItem = true;
            // 
            // multiLayoutItem243
            // 
            this.multiLayoutItem243.DataName = "nurse_hold_user";
            this.multiLayoutItem243.IsUpdItem = true;
            // 
            // multiLayoutItem244
            // 
            this.multiLayoutItem244.DataName = "nurse_hold_date";
            this.multiLayoutItem244.IsUpdItem = true;
            // 
            // multiLayoutItem245
            // 
            this.multiLayoutItem245.DataName = "nurse_hold_time";
            this.multiLayoutItem245.IsUpdItem = true;
            // 
            // multiLayoutItem246
            // 
            this.multiLayoutItem246.DataName = "reser_date";
            this.multiLayoutItem246.IsUpdItem = true;
            // 
            // multiLayoutItem247
            // 
            this.multiLayoutItem247.DataName = "reser_time";
            this.multiLayoutItem247.IsUpdItem = true;
            // 
            // multiLayoutItem248
            // 
            this.multiLayoutItem248.DataName = "jubsu_date";
            this.multiLayoutItem248.IsUpdItem = true;
            // 
            // multiLayoutItem249
            // 
            this.multiLayoutItem249.DataName = "jubsu_time";
            this.multiLayoutItem249.IsUpdItem = true;
            // 
            // multiLayoutItem250
            // 
            this.multiLayoutItem250.DataName = "acting_date";
            this.multiLayoutItem250.IsUpdItem = true;
            // 
            // multiLayoutItem251
            // 
            this.multiLayoutItem251.DataName = "acting_time";
            this.multiLayoutItem251.IsUpdItem = true;
            // 
            // multiLayoutItem252
            // 
            this.multiLayoutItem252.DataName = "acting_day";
            this.multiLayoutItem252.IsUpdItem = true;
            // 
            // multiLayoutItem253
            // 
            this.multiLayoutItem253.DataName = "result_date";
            this.multiLayoutItem253.IsUpdItem = true;
            // 
            // multiLayoutItem254
            // 
            this.multiLayoutItem254.DataName = "dc_gubun";
            this.multiLayoutItem254.IsUpdItem = true;
            // 
            // multiLayoutItem255
            // 
            this.multiLayoutItem255.DataName = "dc_yn";
            this.multiLayoutItem255.IsUpdItem = true;
            // 
            // multiLayoutItem256
            // 
            this.multiLayoutItem256.DataName = "bannab_yn";
            this.multiLayoutItem256.IsUpdItem = true;
            // 
            // multiLayoutItem257
            // 
            this.multiLayoutItem257.DataName = "bannab_confirm";
            this.multiLayoutItem257.IsUpdItem = true;
            // 
            // multiLayoutItem258
            // 
            this.multiLayoutItem258.DataName = "source_ord_key";
            this.multiLayoutItem258.IsUpdItem = true;
            // 
            // multiLayoutItem259
            // 
            this.multiLayoutItem259.DataName = "ocs_flag";
            this.multiLayoutItem259.IsUpdItem = true;
            // 
            // multiLayoutItem260
            // 
            this.multiLayoutItem260.DataName = "sg_code";
            this.multiLayoutItem260.IsUpdItem = true;
            // 
            // multiLayoutItem261
            // 
            this.multiLayoutItem261.DataName = "sg_ymd";
            this.multiLayoutItem261.IsUpdItem = true;
            // 
            // multiLayoutItem262
            // 
            this.multiLayoutItem262.DataName = "io_gubun";
            this.multiLayoutItem262.IsUpdItem = true;
            // 
            // multiLayoutItem263
            // 
            this.multiLayoutItem263.DataName = "after_act_yn";
            this.multiLayoutItem263.IsUpdItem = true;
            // 
            // multiLayoutItem264
            // 
            this.multiLayoutItem264.DataName = "bichi_yn";
            this.multiLayoutItem264.IsUpdItem = true;
            // 
            // multiLayoutItem265
            // 
            this.multiLayoutItem265.DataName = "drg_bunho";
            this.multiLayoutItem265.IsUpdItem = true;
            // 
            // multiLayoutItem266
            // 
            this.multiLayoutItem266.DataName = "sub_susul";
            this.multiLayoutItem266.IsUpdItem = true;
            // 
            // multiLayoutItem267
            // 
            this.multiLayoutItem267.DataName = "print_yn";
            this.multiLayoutItem267.IsUpdItem = true;
            // 
            // multiLayoutItem268
            // 
            this.multiLayoutItem268.DataName = "chisik";
            this.multiLayoutItem268.IsUpdItem = true;
            // 
            // multiLayoutItem269
            // 
            this.multiLayoutItem269.DataName = "tel_yn";
            this.multiLayoutItem269.IsUpdItem = true;
            // 
            // multiLayoutItem270
            // 
            this.multiLayoutItem270.DataName = "order_gubun_bas";
            this.multiLayoutItem270.IsUpdItem = true;
            // 
            // multiLayoutItem271
            // 
            this.multiLayoutItem271.DataName = "input_control";
            this.multiLayoutItem271.IsUpdItem = true;
            // 
            // multiLayoutItem272
            // 
            this.multiLayoutItem272.DataName = "suga_yn";
            this.multiLayoutItem272.IsUpdItem = true;
            // 
            // multiLayoutItem273
            // 
            this.multiLayoutItem273.DataName = "jaeryo_yn";
            this.multiLayoutItem273.IsUpdItem = true;
            // 
            // multiLayoutItem274
            // 
            this.multiLayoutItem274.DataName = "wonyoi_check";
            this.multiLayoutItem274.IsUpdItem = true;
            // 
            // multiLayoutItem275
            // 
            this.multiLayoutItem275.DataName = "emergency_check";
            this.multiLayoutItem275.IsUpdItem = true;
            // 
            // multiLayoutItem276
            // 
            this.multiLayoutItem276.DataName = "specimen_check";
            // 
            // multiLayoutItem277
            // 
            this.multiLayoutItem277.DataName = "portable_check";
            this.multiLayoutItem277.IsUpdItem = true;
            // 
            // multiLayoutItem278
            // 
            this.multiLayoutItem278.DataName = "bulyong_check";
            this.multiLayoutItem278.IsUpdItem = true;
            // 
            // multiLayoutItem279
            // 
            this.multiLayoutItem279.DataName = "sunab_check";
            // 
            // multiLayoutItem280
            // 
            this.multiLayoutItem280.DataName = "dc_check";
            // 
            // multiLayoutItem281
            // 
            this.multiLayoutItem281.DataName = "dc_gubun_check";
            this.multiLayoutItem281.IsUpdItem = true;
            // 
            // multiLayoutItem282
            // 
            this.multiLayoutItem282.DataName = "confirm_check";
            this.multiLayoutItem282.IsUpdItem = true;
            // 
            // multiLayoutItem283
            // 
            this.multiLayoutItem283.DataName = "reser_yn_check";
            this.multiLayoutItem283.IsUpdItem = true;
            // 
            // multiLayoutItem284
            // 
            this.multiLayoutItem284.DataName = "chisik_check";
            this.multiLayoutItem284.IsUpdItem = true;
            // 
            // multiLayoutItem285
            // 
            this.multiLayoutItem285.DataName = "nday_yn";
            this.multiLayoutItem285.IsUpdItem = true;
            // 
            // multiLayoutItem286
            // 
            this.multiLayoutItem286.DataName = "default_jaeryo_jundal_yn";
            this.multiLayoutItem286.IsUpdItem = true;
            // 
            // multiLayoutItem287
            // 
            this.multiLayoutItem287.DataName = "default_wonyoi_order_yn";
            this.multiLayoutItem287.IsUpdItem = true;
            // 
            // multiLayoutItem288
            // 
            this.multiLayoutItem288.DataName = "specific_comment";
            this.multiLayoutItem288.IsUpdItem = true;
            // 
            // multiLayoutItem289
            // 
            this.multiLayoutItem289.DataName = "specific_comment_name";
            this.multiLayoutItem289.IsUpdItem = true;
            // 
            // multiLayoutItem290
            // 
            this.multiLayoutItem290.DataName = "specific_comment_sys_id";
            this.multiLayoutItem290.IsUpdItem = true;
            // 
            // multiLayoutItem291
            // 
            this.multiLayoutItem291.DataName = "specific_comment_pgm_id";
            this.multiLayoutItem291.IsUpdItem = true;
            // 
            // multiLayoutItem292
            // 
            this.multiLayoutItem292.DataName = "specific_comment_not_null";
            this.multiLayoutItem292.IsUpdItem = true;
            // 
            // multiLayoutItem293
            // 
            this.multiLayoutItem293.DataName = "specific_comment_table_id";
            this.multiLayoutItem293.IsUpdItem = true;
            // 
            // multiLayoutItem294
            // 
            this.multiLayoutItem294.DataName = "specific_comment_col_id";
            this.multiLayoutItem294.IsUpdItem = true;
            // 
            // multiLayoutItem295
            // 
            this.multiLayoutItem295.DataName = "donbog_yn";
            this.multiLayoutItem295.IsUpdItem = true;
            // 
            // multiLayoutItem296
            // 
            this.multiLayoutItem296.DataName = "order_gubun_bas_name";
            this.multiLayoutItem296.IsUpdItem = true;
            // 
            // multiLayoutItem297
            // 
            this.multiLayoutItem297.DataName = "act_doctor";
            this.multiLayoutItem297.IsUpdItem = true;
            // 
            // multiLayoutItem298
            // 
            this.multiLayoutItem298.DataName = "act_buseo";
            this.multiLayoutItem298.IsUpdItem = true;
            // 
            // multiLayoutItem299
            // 
            this.multiLayoutItem299.DataName = "act_gwa";
            this.multiLayoutItem299.IsUpdItem = true;
            // 
            // multiLayoutItem300
            // 
            this.multiLayoutItem300.DataName = "home_care_yn";
            this.multiLayoutItem300.IsUpdItem = true;
            // 
            // multiLayoutItem301
            // 
            this.multiLayoutItem301.DataName = "regular_yn";
            this.multiLayoutItem301.IsUpdItem = true;
            // 
            // multiLayoutItem302
            // 
            this.multiLayoutItem302.DataName = "sort_fkocskey";
            this.multiLayoutItem302.IsUpdItem = true;
            // 
            // multiLayoutItem303
            // 
            this.multiLayoutItem303.DataName = "child_yn";
            this.multiLayoutItem303.IsUpdItem = true;
            // 
            // multiLayoutItem304
            // 
            this.multiLayoutItem304.DataName = "child_exist_yn";
            this.multiLayoutItem304.IsUpdItem = true;
            // 
            // multiLayoutItem305
            // 
            this.multiLayoutItem305.DataName = "bogyong_code_sub";
            this.multiLayoutItem305.IsUpdItem = true;
            // 
            // multiLayoutItem306
            // 
            this.multiLayoutItem306.DataName = "bogyong_name_sub";
            this.multiLayoutItem306.IsUpdItem = true;
            // 
            // layDeletedData
            // 
            this.layDeletedData.CallerID = '2';
            this.layDeletedData.ExecuteQuery = null;
            this.layDeletedData.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem324,
            this.multiLayoutItem325,
            this.multiLayoutItem326,
            this.multiLayoutItem327,
            this.multiLayoutItem328,
            this.multiLayoutItem329,
            this.multiLayoutItem330,
            this.multiLayoutItem331,
            this.multiLayoutItem332,
            this.multiLayoutItem333,
            this.multiLayoutItem334,
            this.multiLayoutItem335,
            this.multiLayoutItem336,
            this.multiLayoutItem337,
            this.multiLayoutItem338,
            this.multiLayoutItem339,
            this.multiLayoutItem340,
            this.multiLayoutItem341,
            this.multiLayoutItem342,
            this.multiLayoutItem343,
            this.multiLayoutItem344,
            this.multiLayoutItem345,
            this.multiLayoutItem346,
            this.multiLayoutItem347,
            this.multiLayoutItem348,
            this.multiLayoutItem349,
            this.multiLayoutItem350,
            this.multiLayoutItem351,
            this.multiLayoutItem352,
            this.multiLayoutItem353,
            this.multiLayoutItem354,
            this.multiLayoutItem355,
            this.multiLayoutItem356,
            this.multiLayoutItem357,
            this.multiLayoutItem358,
            this.multiLayoutItem359,
            this.multiLayoutItem360,
            this.multiLayoutItem361,
            this.multiLayoutItem362,
            this.multiLayoutItem363,
            this.multiLayoutItem364,
            this.multiLayoutItem365,
            this.multiLayoutItem366,
            this.multiLayoutItem367,
            this.multiLayoutItem368,
            this.multiLayoutItem369,
            this.multiLayoutItem370,
            this.multiLayoutItem371,
            this.multiLayoutItem372,
            this.multiLayoutItem373,
            this.multiLayoutItem374,
            this.multiLayoutItem375,
            this.multiLayoutItem376,
            this.multiLayoutItem377,
            this.multiLayoutItem378,
            this.multiLayoutItem379,
            this.multiLayoutItem380,
            this.multiLayoutItem381,
            this.multiLayoutItem382,
            this.multiLayoutItem383,
            this.multiLayoutItem384,
            this.multiLayoutItem385,
            this.multiLayoutItem386,
            this.multiLayoutItem387,
            this.multiLayoutItem388,
            this.multiLayoutItem389,
            this.multiLayoutItem390,
            this.multiLayoutItem391,
            this.multiLayoutItem392,
            this.multiLayoutItem393,
            this.multiLayoutItem394,
            this.multiLayoutItem395,
            this.multiLayoutItem396,
            this.multiLayoutItem397,
            this.multiLayoutItem398,
            this.multiLayoutItem399,
            this.multiLayoutItem400,
            this.multiLayoutItem401,
            this.multiLayoutItem402,
            this.multiLayoutItem403,
            this.multiLayoutItem404,
            this.multiLayoutItem405,
            this.multiLayoutItem406,
            this.multiLayoutItem407,
            this.multiLayoutItem408,
            this.multiLayoutItem409,
            this.multiLayoutItem410,
            this.multiLayoutItem411,
            this.multiLayoutItem412,
            this.multiLayoutItem413,
            this.multiLayoutItem414,
            this.multiLayoutItem415,
            this.multiLayoutItem416,
            this.multiLayoutItem417,
            this.multiLayoutItem418,
            this.multiLayoutItem419,
            this.multiLayoutItem420,
            this.multiLayoutItem421,
            this.multiLayoutItem422,
            this.multiLayoutItem423,
            this.multiLayoutItem424,
            this.multiLayoutItem425,
            this.multiLayoutItem426,
            this.multiLayoutItem427,
            this.multiLayoutItem428,
            this.multiLayoutItem429,
            this.multiLayoutItem430,
            this.multiLayoutItem431,
            this.multiLayoutItem432,
            this.multiLayoutItem433,
            this.multiLayoutItem434,
            this.multiLayoutItem435,
            this.multiLayoutItem436,
            this.multiLayoutItem437,
            this.multiLayoutItem438,
            this.multiLayoutItem439,
            this.multiLayoutItem440,
            this.multiLayoutItem441,
            this.multiLayoutItem442,
            this.multiLayoutItem443,
            this.multiLayoutItem444,
            this.multiLayoutItem445,
            this.multiLayoutItem446,
            this.multiLayoutItem447,
            this.multiLayoutItem448,
            this.multiLayoutItem449,
            this.multiLayoutItem450,
            this.multiLayoutItem451,
            this.multiLayoutItem452,
            this.multiLayoutItem453,
            this.multiLayoutItem454,
            this.multiLayoutItem455,
            this.multiLayoutItem456,
            this.multiLayoutItem457,
            this.multiLayoutItem458,
            this.multiLayoutItem459,
            this.multiLayoutItem460,
            this.multiLayoutItem461,
            this.multiLayoutItem462,
            this.multiLayoutItem463,
            this.multiLayoutItem464,
            this.multiLayoutItem465,
            this.multiLayoutItem466,
            this.multiLayoutItem467,
            this.multiLayoutItem468,
            this.multiLayoutItem469,
            this.multiLayoutItem470,
            this.multiLayoutItem471,
            this.multiLayoutItem472,
            this.multiLayoutItem473,
            this.multiLayoutItem474,
            this.multiLayoutItem475});
            this.layDeletedData.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDeletedData.ParamList")));
            this.layDeletedData.UseDefaultTransaction = false;
            // 
            // multiLayoutItem324
            // 
            this.multiLayoutItem324.DataName = "in_out_key";
            this.multiLayoutItem324.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem324.IsUpdItem = true;
            // 
            // multiLayoutItem325
            // 
            this.multiLayoutItem325.DataName = "pkocskey";
            this.multiLayoutItem325.IsUpdItem = true;
            // 
            // multiLayoutItem326
            // 
            this.multiLayoutItem326.DataName = "bunho";
            this.multiLayoutItem326.IsUpdItem = true;
            // 
            // multiLayoutItem327
            // 
            this.multiLayoutItem327.DataName = "order_date";
            this.multiLayoutItem327.IsUpdItem = true;
            // 
            // multiLayoutItem328
            // 
            this.multiLayoutItem328.DataName = "gwa";
            this.multiLayoutItem328.IsUpdItem = true;
            // 
            // multiLayoutItem329
            // 
            this.multiLayoutItem329.DataName = "doctor";
            this.multiLayoutItem329.IsUpdItem = true;
            // 
            // multiLayoutItem330
            // 
            this.multiLayoutItem330.DataName = "resident";
            this.multiLayoutItem330.IsUpdItem = true;
            // 
            // multiLayoutItem331
            // 
            this.multiLayoutItem331.DataName = "naewon_type";
            this.multiLayoutItem331.IsUpdItem = true;
            // 
            // multiLayoutItem332
            // 
            this.multiLayoutItem332.DataName = "jubsu_no";
            this.multiLayoutItem332.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem332.IsUpdItem = true;
            // 
            // multiLayoutItem333
            // 
            this.multiLayoutItem333.DataName = "input_id";
            this.multiLayoutItem333.IsUpdItem = true;
            // 
            // multiLayoutItem334
            // 
            this.multiLayoutItem334.DataName = "input_part";
            this.multiLayoutItem334.IsUpdItem = true;
            // 
            // multiLayoutItem335
            // 
            this.multiLayoutItem335.DataName = "input_gwa";
            this.multiLayoutItem335.IsUpdItem = true;
            // 
            // multiLayoutItem336
            // 
            this.multiLayoutItem336.DataName = "input_doctor";
            this.multiLayoutItem336.IsUpdItem = true;
            // 
            // multiLayoutItem337
            // 
            this.multiLayoutItem337.DataName = "input_gubun";
            this.multiLayoutItem337.IsUpdItem = true;
            // 
            // multiLayoutItem338
            // 
            this.multiLayoutItem338.DataName = "input_gubun_name";
            // 
            // multiLayoutItem339
            // 
            this.multiLayoutItem339.DataName = "group_ser";
            this.multiLayoutItem339.IsUpdItem = true;
            // 
            // multiLayoutItem340
            // 
            this.multiLayoutItem340.DataName = "input_tab";
            this.multiLayoutItem340.IsUpdItem = true;
            // 
            // multiLayoutItem341
            // 
            this.multiLayoutItem341.DataName = "input_tab_name";
            // 
            // multiLayoutItem342
            // 
            this.multiLayoutItem342.DataName = "order_gubun";
            this.multiLayoutItem342.IsUpdItem = true;
            // 
            // multiLayoutItem343
            // 
            this.multiLayoutItem343.DataName = "order_gubun_name";
            // 
            // multiLayoutItem344
            // 
            this.multiLayoutItem344.DataName = "group_yn";
            this.multiLayoutItem344.IsUpdItem = true;
            // 
            // multiLayoutItem345
            // 
            this.multiLayoutItem345.DataName = "seq";
            this.multiLayoutItem345.IsUpdItem = true;
            // 
            // multiLayoutItem346
            // 
            this.multiLayoutItem346.DataName = "slip_code";
            this.multiLayoutItem346.IsUpdItem = true;
            // 
            // multiLayoutItem347
            // 
            this.multiLayoutItem347.DataName = "hangmog_code";
            this.multiLayoutItem347.IsUpdItem = true;
            // 
            // multiLayoutItem348
            // 
            this.multiLayoutItem348.DataName = "hangmog_name";
            // 
            // multiLayoutItem349
            // 
            this.multiLayoutItem349.DataName = "specimen_code";
            this.multiLayoutItem349.IsUpdItem = true;
            // 
            // multiLayoutItem350
            // 
            this.multiLayoutItem350.DataName = "specimen_name";
            // 
            // multiLayoutItem351
            // 
            this.multiLayoutItem351.DataName = "suryang";
            this.multiLayoutItem351.IsUpdItem = true;
            // 
            // multiLayoutItem352
            // 
            this.multiLayoutItem352.DataName = "sunab_suryang";
            this.multiLayoutItem352.IsUpdItem = true;
            // 
            // multiLayoutItem353
            // 
            this.multiLayoutItem353.DataName = "subul_suryang";
            this.multiLayoutItem353.IsUpdItem = true;
            // 
            // multiLayoutItem354
            // 
            this.multiLayoutItem354.DataName = "ord_danui";
            this.multiLayoutItem354.IsUpdItem = true;
            // 
            // multiLayoutItem355
            // 
            this.multiLayoutItem355.DataName = "ord_danui_name";
            // 
            // multiLayoutItem356
            // 
            this.multiLayoutItem356.DataName = "dv_time";
            this.multiLayoutItem356.IsUpdItem = true;
            // 
            // multiLayoutItem357
            // 
            this.multiLayoutItem357.DataName = "dv";
            this.multiLayoutItem357.IsUpdItem = true;
            // 
            // multiLayoutItem358
            // 
            this.multiLayoutItem358.DataName = "dv_1";
            this.multiLayoutItem358.IsUpdItem = true;
            // 
            // multiLayoutItem359
            // 
            this.multiLayoutItem359.DataName = "dv_2";
            this.multiLayoutItem359.IsUpdItem = true;
            // 
            // multiLayoutItem360
            // 
            this.multiLayoutItem360.DataName = "dv_3";
            this.multiLayoutItem360.IsUpdItem = true;
            // 
            // multiLayoutItem361
            // 
            this.multiLayoutItem361.DataName = "dv_4";
            this.multiLayoutItem361.IsUpdItem = true;
            // 
            // multiLayoutItem362
            // 
            this.multiLayoutItem362.DataName = "nalsu";
            this.multiLayoutItem362.IsUpdItem = true;
            // 
            // multiLayoutItem363
            // 
            this.multiLayoutItem363.DataName = "sunab_nalsu";
            this.multiLayoutItem363.IsUpdItem = true;
            // 
            // multiLayoutItem364
            // 
            this.multiLayoutItem364.DataName = "jusa";
            this.multiLayoutItem364.IsUpdItem = true;
            // 
            // multiLayoutItem365
            // 
            this.multiLayoutItem365.DataName = "jusa_name";
            this.multiLayoutItem365.IsUpdItem = true;
            // 
            // multiLayoutItem366
            // 
            this.multiLayoutItem366.DataName = "jusa_spd_gubun";
            this.multiLayoutItem366.IsUpdItem = true;
            // 
            // multiLayoutItem367
            // 
            this.multiLayoutItem367.DataName = "bogyong_code";
            this.multiLayoutItem367.IsUpdItem = true;
            // 
            // multiLayoutItem368
            // 
            this.multiLayoutItem368.DataName = "bogyong_name";
            this.multiLayoutItem368.IsUpdItem = true;
            // 
            // multiLayoutItem369
            // 
            this.multiLayoutItem369.DataName = "emergency";
            this.multiLayoutItem369.IsUpdItem = true;
            // 
            // multiLayoutItem370
            // 
            this.multiLayoutItem370.DataName = "jaeryo_jundal_yn";
            this.multiLayoutItem370.IsUpdItem = true;
            // 
            // multiLayoutItem371
            // 
            this.multiLayoutItem371.DataName = "jundal_table";
            this.multiLayoutItem371.IsUpdItem = true;
            // 
            // multiLayoutItem372
            // 
            this.multiLayoutItem372.DataName = "jundal_part";
            this.multiLayoutItem372.IsUpdItem = true;
            // 
            // multiLayoutItem373
            // 
            this.multiLayoutItem373.DataName = "move_part";
            this.multiLayoutItem373.IsUpdItem = true;
            // 
            // multiLayoutItem374
            // 
            this.multiLayoutItem374.DataName = "portable_yn";
            this.multiLayoutItem374.IsUpdItem = true;
            // 
            // multiLayoutItem375
            // 
            this.multiLayoutItem375.DataName = "powder_yn";
            this.multiLayoutItem375.IsUpdItem = true;
            // 
            // multiLayoutItem376
            // 
            this.multiLayoutItem376.DataName = "hubal_change_yn";
            this.multiLayoutItem376.IsUpdItem = true;
            // 
            // multiLayoutItem377
            // 
            this.multiLayoutItem377.DataName = "pharmacy";
            this.multiLayoutItem377.IsUpdItem = true;
            // 
            // multiLayoutItem378
            // 
            this.multiLayoutItem378.DataName = "drg_pack_yn";
            this.multiLayoutItem378.IsUpdItem = true;
            // 
            // multiLayoutItem379
            // 
            this.multiLayoutItem379.DataName = "muhyo";
            this.multiLayoutItem379.IsUpdItem = true;
            // 
            // multiLayoutItem380
            // 
            this.multiLayoutItem380.DataName = "prn_yn";
            this.multiLayoutItem380.IsUpdItem = true;
            // 
            // multiLayoutItem381
            // 
            this.multiLayoutItem381.DataName = "toiwon_drg_yn";
            this.multiLayoutItem381.IsUpdItem = true;
            // 
            // multiLayoutItem382
            // 
            this.multiLayoutItem382.DataName = "prn_nurse";
            this.multiLayoutItem382.IsUpdItem = true;
            // 
            // multiLayoutItem383
            // 
            this.multiLayoutItem383.DataName = "append_yn";
            this.multiLayoutItem383.IsUpdItem = true;
            // 
            // multiLayoutItem384
            // 
            this.multiLayoutItem384.DataName = "order_remark";
            this.multiLayoutItem384.IsUpdItem = true;
            // 
            // multiLayoutItem385
            // 
            this.multiLayoutItem385.DataName = "nurse_remark";
            this.multiLayoutItem385.IsUpdItem = true;
            // 
            // multiLayoutItem386
            // 
            this.multiLayoutItem386.DataName = "comment";
            this.multiLayoutItem386.IsUpdItem = true;
            // 
            // multiLayoutItem387
            // 
            this.multiLayoutItem387.DataName = "mix_group";
            this.multiLayoutItem387.IsUpdItem = true;
            // 
            // multiLayoutItem388
            // 
            this.multiLayoutItem388.DataName = "amt";
            this.multiLayoutItem388.IsUpdItem = true;
            // 
            // multiLayoutItem389
            // 
            this.multiLayoutItem389.DataName = "pay";
            this.multiLayoutItem389.IsUpdItem = true;
            // 
            // multiLayoutItem390
            // 
            this.multiLayoutItem390.DataName = "wonyoi_order_yn";
            this.multiLayoutItem390.IsUpdItem = true;
            // 
            // multiLayoutItem391
            // 
            this.multiLayoutItem391.DataName = "dangil_gumsa_order_yn";
            this.multiLayoutItem391.IsUpdItem = true;
            // 
            // multiLayoutItem392
            // 
            this.multiLayoutItem392.DataName = "dangil_gumsa_result_yn";
            this.multiLayoutItem392.IsUpdItem = true;
            // 
            // multiLayoutItem393
            // 
            this.multiLayoutItem393.DataName = "bom_occur_yn";
            this.multiLayoutItem393.IsUpdItem = true;
            // 
            // multiLayoutItem394
            // 
            this.multiLayoutItem394.DataName = "bom_source_key";
            this.multiLayoutItem394.IsUpdItem = true;
            // 
            // multiLayoutItem395
            // 
            this.multiLayoutItem395.DataName = "display_yn";
            this.multiLayoutItem395.IsUpdItem = true;
            // 
            // multiLayoutItem396
            // 
            this.multiLayoutItem396.DataName = "sunab_yn";
            this.multiLayoutItem396.IsUpdItem = true;
            // 
            // multiLayoutItem397
            // 
            this.multiLayoutItem397.DataName = "sunab_date";
            this.multiLayoutItem397.IsUpdItem = true;
            // 
            // multiLayoutItem398
            // 
            this.multiLayoutItem398.DataName = "sunab_time";
            this.multiLayoutItem398.IsUpdItem = true;
            // 
            // multiLayoutItem399
            // 
            this.multiLayoutItem399.DataName = "hope_date";
            this.multiLayoutItem399.IsUpdItem = true;
            // 
            // multiLayoutItem400
            // 
            this.multiLayoutItem400.DataName = "hope_time";
            this.multiLayoutItem400.IsUpdItem = true;
            // 
            // multiLayoutItem401
            // 
            this.multiLayoutItem401.DataName = "nurse_confirm_user";
            this.multiLayoutItem401.IsUpdItem = true;
            // 
            // multiLayoutItem402
            // 
            this.multiLayoutItem402.DataName = "nurse_confirm_date";
            this.multiLayoutItem402.IsUpdItem = true;
            // 
            // multiLayoutItem403
            // 
            this.multiLayoutItem403.DataName = "nurse_confirm_time";
            this.multiLayoutItem403.IsUpdItem = true;
            // 
            // multiLayoutItem404
            // 
            this.multiLayoutItem404.DataName = "nurse_pickup_user";
            this.multiLayoutItem404.IsUpdItem = true;
            // 
            // multiLayoutItem405
            // 
            this.multiLayoutItem405.DataName = "nurse_pickup_date";
            this.multiLayoutItem405.IsUpdItem = true;
            // 
            // multiLayoutItem406
            // 
            this.multiLayoutItem406.DataName = "nurse_pickup_time";
            this.multiLayoutItem406.IsUpdItem = true;
            // 
            // multiLayoutItem407
            // 
            this.multiLayoutItem407.DataName = "nurse_hold_user";
            this.multiLayoutItem407.IsUpdItem = true;
            // 
            // multiLayoutItem408
            // 
            this.multiLayoutItem408.DataName = "nurse_hold_date";
            this.multiLayoutItem408.IsUpdItem = true;
            // 
            // multiLayoutItem409
            // 
            this.multiLayoutItem409.DataName = "nurse_hold_time";
            this.multiLayoutItem409.IsUpdItem = true;
            // 
            // multiLayoutItem410
            // 
            this.multiLayoutItem410.DataName = "reser_date";
            this.multiLayoutItem410.IsUpdItem = true;
            // 
            // multiLayoutItem411
            // 
            this.multiLayoutItem411.DataName = "reser_time";
            this.multiLayoutItem411.IsUpdItem = true;
            // 
            // multiLayoutItem412
            // 
            this.multiLayoutItem412.DataName = "jubsu_date";
            this.multiLayoutItem412.IsUpdItem = true;
            // 
            // multiLayoutItem413
            // 
            this.multiLayoutItem413.DataName = "jubsu_time";
            this.multiLayoutItem413.IsUpdItem = true;
            // 
            // multiLayoutItem414
            // 
            this.multiLayoutItem414.DataName = "acting_date";
            this.multiLayoutItem414.IsUpdItem = true;
            // 
            // multiLayoutItem415
            // 
            this.multiLayoutItem415.DataName = "acting_time";
            this.multiLayoutItem415.IsUpdItem = true;
            // 
            // multiLayoutItem416
            // 
            this.multiLayoutItem416.DataName = "acting_day";
            this.multiLayoutItem416.IsUpdItem = true;
            // 
            // multiLayoutItem417
            // 
            this.multiLayoutItem417.DataName = "result_date";
            this.multiLayoutItem417.IsUpdItem = true;
            // 
            // multiLayoutItem418
            // 
            this.multiLayoutItem418.DataName = "dc_gubun";
            this.multiLayoutItem418.IsUpdItem = true;
            // 
            // multiLayoutItem419
            // 
            this.multiLayoutItem419.DataName = "dc_yn";
            this.multiLayoutItem419.IsUpdItem = true;
            // 
            // multiLayoutItem420
            // 
            this.multiLayoutItem420.DataName = "bannab_yn";
            this.multiLayoutItem420.IsUpdItem = true;
            // 
            // multiLayoutItem421
            // 
            this.multiLayoutItem421.DataName = "bannab_confirm";
            this.multiLayoutItem421.IsUpdItem = true;
            // 
            // multiLayoutItem422
            // 
            this.multiLayoutItem422.DataName = "source_ord_key";
            this.multiLayoutItem422.IsUpdItem = true;
            // 
            // multiLayoutItem423
            // 
            this.multiLayoutItem423.DataName = "ocs_flag";
            this.multiLayoutItem423.IsUpdItem = true;
            // 
            // multiLayoutItem424
            // 
            this.multiLayoutItem424.DataName = "sg_code";
            this.multiLayoutItem424.IsUpdItem = true;
            // 
            // multiLayoutItem425
            // 
            this.multiLayoutItem425.DataName = "sg_ymd";
            this.multiLayoutItem425.IsUpdItem = true;
            // 
            // multiLayoutItem426
            // 
            this.multiLayoutItem426.DataName = "io_gubun";
            this.multiLayoutItem426.IsUpdItem = true;
            // 
            // multiLayoutItem427
            // 
            this.multiLayoutItem427.DataName = "after_act_yn";
            this.multiLayoutItem427.IsUpdItem = true;
            // 
            // multiLayoutItem428
            // 
            this.multiLayoutItem428.DataName = "bichi_yn";
            this.multiLayoutItem428.IsUpdItem = true;
            // 
            // multiLayoutItem429
            // 
            this.multiLayoutItem429.DataName = "drg_bunho";
            this.multiLayoutItem429.IsUpdItem = true;
            // 
            // multiLayoutItem430
            // 
            this.multiLayoutItem430.DataName = "sub_susul";
            this.multiLayoutItem430.IsUpdItem = true;
            // 
            // multiLayoutItem431
            // 
            this.multiLayoutItem431.DataName = "print_yn";
            this.multiLayoutItem431.IsUpdItem = true;
            // 
            // multiLayoutItem432
            // 
            this.multiLayoutItem432.DataName = "chisik";
            this.multiLayoutItem432.IsUpdItem = true;
            // 
            // multiLayoutItem433
            // 
            this.multiLayoutItem433.DataName = "tel_yn";
            this.multiLayoutItem433.IsUpdItem = true;
            // 
            // multiLayoutItem434
            // 
            this.multiLayoutItem434.DataName = "order_gubun_bas";
            this.multiLayoutItem434.IsUpdItem = true;
            // 
            // multiLayoutItem435
            // 
            this.multiLayoutItem435.DataName = "input_control";
            this.multiLayoutItem435.IsUpdItem = true;
            // 
            // multiLayoutItem436
            // 
            this.multiLayoutItem436.DataName = "suga_yn";
            this.multiLayoutItem436.IsUpdItem = true;
            // 
            // multiLayoutItem437
            // 
            this.multiLayoutItem437.DataName = "jaeryo_yn";
            this.multiLayoutItem437.IsUpdItem = true;
            // 
            // multiLayoutItem438
            // 
            this.multiLayoutItem438.DataName = "wonyoi_check";
            this.multiLayoutItem438.IsUpdItem = true;
            // 
            // multiLayoutItem439
            // 
            this.multiLayoutItem439.DataName = "emergency_check";
            this.multiLayoutItem439.IsUpdItem = true;
            // 
            // multiLayoutItem440
            // 
            this.multiLayoutItem440.DataName = "specimen_check";
            // 
            // multiLayoutItem441
            // 
            this.multiLayoutItem441.DataName = "portable_check";
            this.multiLayoutItem441.IsUpdItem = true;
            // 
            // multiLayoutItem442
            // 
            this.multiLayoutItem442.DataName = "bulyong_check";
            this.multiLayoutItem442.IsUpdItem = true;
            // 
            // multiLayoutItem443
            // 
            this.multiLayoutItem443.DataName = "sunab_check";
            // 
            // multiLayoutItem444
            // 
            this.multiLayoutItem444.DataName = "dc_check";
            // 
            // multiLayoutItem445
            // 
            this.multiLayoutItem445.DataName = "dc_gubun_check";
            this.multiLayoutItem445.IsUpdItem = true;
            // 
            // multiLayoutItem446
            // 
            this.multiLayoutItem446.DataName = "confirm_check";
            this.multiLayoutItem446.IsUpdItem = true;
            // 
            // multiLayoutItem447
            // 
            this.multiLayoutItem447.DataName = "reser_yn_check";
            this.multiLayoutItem447.IsUpdItem = true;
            // 
            // multiLayoutItem448
            // 
            this.multiLayoutItem448.DataName = "chisik_check";
            this.multiLayoutItem448.IsUpdItem = true;
            // 
            // multiLayoutItem449
            // 
            this.multiLayoutItem449.DataName = "nday_yn";
            this.multiLayoutItem449.IsUpdItem = true;
            // 
            // multiLayoutItem450
            // 
            this.multiLayoutItem450.DataName = "default_jaeryo_jundal_yn";
            this.multiLayoutItem450.IsUpdItem = true;
            // 
            // multiLayoutItem451
            // 
            this.multiLayoutItem451.DataName = "default_wonyoi_order_yn";
            this.multiLayoutItem451.IsUpdItem = true;
            // 
            // multiLayoutItem452
            // 
            this.multiLayoutItem452.DataName = "specific_comment";
            this.multiLayoutItem452.IsUpdItem = true;
            // 
            // multiLayoutItem453
            // 
            this.multiLayoutItem453.DataName = "specific_comment_name";
            this.multiLayoutItem453.IsUpdItem = true;
            // 
            // multiLayoutItem454
            // 
            this.multiLayoutItem454.DataName = "specific_comment_sys_id";
            this.multiLayoutItem454.IsUpdItem = true;
            // 
            // multiLayoutItem455
            // 
            this.multiLayoutItem455.DataName = "specific_comment_pgm_id";
            this.multiLayoutItem455.IsUpdItem = true;
            // 
            // multiLayoutItem456
            // 
            this.multiLayoutItem456.DataName = "specific_comment_not_null";
            this.multiLayoutItem456.IsUpdItem = true;
            // 
            // multiLayoutItem457
            // 
            this.multiLayoutItem457.DataName = "specific_comment_table_id";
            this.multiLayoutItem457.IsUpdItem = true;
            // 
            // multiLayoutItem458
            // 
            this.multiLayoutItem458.DataName = "specific_comment_col_id";
            this.multiLayoutItem458.IsUpdItem = true;
            // 
            // multiLayoutItem459
            // 
            this.multiLayoutItem459.DataName = "donbog_yn";
            this.multiLayoutItem459.IsUpdItem = true;
            // 
            // multiLayoutItem460
            // 
            this.multiLayoutItem460.DataName = "order_gubun_bas_name";
            this.multiLayoutItem460.IsUpdItem = true;
            // 
            // multiLayoutItem461
            // 
            this.multiLayoutItem461.DataName = "act_doctor";
            this.multiLayoutItem461.IsUpdItem = true;
            // 
            // multiLayoutItem462
            // 
            this.multiLayoutItem462.DataName = "act_buseo";
            this.multiLayoutItem462.IsUpdItem = true;
            // 
            // multiLayoutItem463
            // 
            this.multiLayoutItem463.DataName = "act_gwa";
            this.multiLayoutItem463.IsUpdItem = true;
            // 
            // multiLayoutItem464
            // 
            this.multiLayoutItem464.DataName = "home_care_yn";
            this.multiLayoutItem464.IsUpdItem = true;
            // 
            // multiLayoutItem465
            // 
            this.multiLayoutItem465.DataName = "regular_yn";
            this.multiLayoutItem465.IsUpdItem = true;
            // 
            // multiLayoutItem466
            // 
            this.multiLayoutItem466.DataName = "sort_fkocskey";
            this.multiLayoutItem466.IsUpdItem = true;
            // 
            // multiLayoutItem467
            // 
            this.multiLayoutItem467.DataName = "child_yn";
            this.multiLayoutItem467.IsUpdItem = true;
            // 
            // multiLayoutItem468
            // 
            this.multiLayoutItem468.DataName = "child_exist_yn";
            this.multiLayoutItem468.IsUpdItem = true;
            // 
            // multiLayoutItem469
            // 
            this.multiLayoutItem469.DataName = "dummy";
            // 
            // multiLayoutItem470
            // 
            this.multiLayoutItem470.DataName = "dv_5";
            this.multiLayoutItem470.IsUpdItem = true;
            // 
            // multiLayoutItem471
            // 
            this.multiLayoutItem471.DataName = "dv_6";
            this.multiLayoutItem471.IsUpdItem = true;
            // 
            // multiLayoutItem472
            // 
            this.multiLayoutItem472.DataName = "dv_7";
            this.multiLayoutItem472.IsUpdItem = true;
            // 
            // multiLayoutItem473
            // 
            this.multiLayoutItem473.DataName = "dv_8";
            this.multiLayoutItem473.IsUpdItem = true;
            // 
            // multiLayoutItem474
            // 
            this.multiLayoutItem474.DataName = "bogyong_code_sub";
            this.multiLayoutItem474.IsUpdItem = true;
            // 
            // multiLayoutItem475
            // 
            this.multiLayoutItem475.DataName = "bogyong_name_sub";
            this.multiLayoutItem475.IsUpdItem = true;
            // 
            // fwkFind
            // 
            this.fwkFind.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkFind.ExecuteQuery = null;
            this.fwkFind.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkFind.ParamList")));
            this.fwkFind.SearchImeMode = System.Windows.Forms.ImeMode.Inherit;
            this.fwkFind.ServerFilter = true;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "sg_code";
            this.findColumnInfo1.ColWidth = 119;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "sg_name";
            this.findColumnInfo2.ColWidth = 364;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // UCOCS0103U12C
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlFill);
            this.Name = "UCOCS0103U12C";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Activated += new System.EventHandler(this.UCOCS0103U12C_Activated);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UCOCS0103U12C_Paint);
            this.pnlFill.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlSangyong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSangyongOrder)).EndInit();
            this.pnlSearchTool.ResumeLayout(false);
            this.pnlSearchTool.PerformLayout();
            this.xPanel6.ResumeLayout(false);
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
        private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XCheckBox cbxEmergency;
        private IHIS.Framework.XComboBox cboNalsu;
        private IHIS.Framework.XPanel xPanel4;
        private IHIS.Framework.XFindBox fbxJusa;
        private IHIS.Framework.XLabel xLabel8;
        private IHIS.Framework.XDisplayBox dbxJusaName;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XTabControl tabGroup;
        private IHIS.Framework.XRadioButton rbnOftenOrder;
        private IHIS.Framework.XPanel pnlSangyong;
        private IHIS.Framework.XEditGrid grdSangyongOrder;
        private IHIS.Framework.XButton btnExtend;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XEditGridCell xEditGridCell20;
        private IHIS.Framework.XEditGridCell xEditGridCell21;
        private IHIS.Framework.XEditGridCell xEditGridCell22;
        private IHIS.Framework.XEditGridCell xEditGridCell23;
        private IHIS.Framework.XPanel xPanel6;
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
        private IHIS.Framework.XEditGridCell xEditGridCell39;
        private IHIS.Framework.XEditGridCell xEditGridCell40;
        private IHIS.Framework.XGridHeader xGridHeader1;
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
        private Panel pnlStatus;
        private Label lbStatus;
        private IHIS.Framework.XProgressBar pgbProgress;
        private IHIS.Framework.XEditGridCell xEditGridCell61;
        private IHIS.Framework.XEditGridCell xEditGridCell62;
        private IHIS.Framework.XEditGridCell xEditGridCell63;
        private IHIS.Framework.XEditGridCell xEditGridCell64;
        private IHIS.Framework.XEditGridCell xEditGridCell65;
        private IHIS.Framework.XPanel pnlRight;
        private IHIS.Framework.MultiLayout layPreview;
        private IHIS.Framework.XEditGridCell xEditGridCell75;
        private IHIS.Framework.XEditGridCell xEditGridCell76;
        private IHIS.Framework.XEditGridCell xEditGridCell77;
        private IHIS.Framework.XEditGridCell xEditGridCell78;
        private IHIS.Framework.XEditGridCell xEditGridCell79;
        private IHIS.Framework.XEditGridCell xEditGridCell80;
        private IHIS.Framework.XPanel pnlSearchTool;
        private IHIS.Framework.XComboBox cboQueryCon;
        private IHIS.Framework.XComboItem xComboItem1;
        private IHIS.Framework.XComboItem xComboItem2;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XTextBox txtSearch;
        private IHIS.Framework.XLabel xLabel5;
        private IHIS.Framework.XEditGridCell xEditGridCell82;
        private IHIS.Framework.XButton btnExpandSearch;
        private IHIS.Framework.XEditGridCell xEditGridCell84;
        private IHIS.Framework.XEditGridCell xEditGridCell85;
        private IHIS.Framework.XEditGridCell xEditGridCell86;
        private IHIS.Framework.XEditGridCell xEditGridCell87;
        private IHIS.Framework.XEditGridCell xEditGridCell88;
        private IHIS.Framework.XEditGridCell xEditGridCell89;
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
        private IHIS.Framework.XEditGridCell xEditGridCell91;
        private IHIS.Framework.XButton btnNalsu;
        private IHIS.Framework.XEditGridCell xEditGridCell92;
        private IHIS.Framework.MultiLayout laySaveLayout;
        private IHIS.Framework.MultiLayout layDeletedData;
        private IHIS.Framework.XDictComboBox cboSearchCondition;
        private IHIS.Framework.XEditGridCell xEditGridCell93;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem324;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem325;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem326;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem327;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem328;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem329;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem330;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem331;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem332;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem333;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem334;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem335;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem336;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem337;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem338;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem339;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem340;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem341;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem342;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem343;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem344;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem345;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem346;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem347;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem348;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem349;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem350;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem351;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem352;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem353;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem354;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem355;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem356;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem357;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem358;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem359;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem360;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem361;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem362;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem363;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem364;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem365;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem366;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem367;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem368;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem369;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem370;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem371;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem372;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem373;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem374;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem375;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem376;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem377;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem378;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem379;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem380;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem381;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem382;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem383;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem384;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem385;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem386;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem387;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem388;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem389;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem390;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem391;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem392;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem393;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem394;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem395;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem396;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem397;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem398;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem399;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem400;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem401;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem402;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem403;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem404;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem405;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem406;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem407;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem408;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem409;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem410;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem411;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem412;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem413;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem414;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem415;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem416;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem417;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem418;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem419;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem420;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem421;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem422;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem423;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem424;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem425;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem426;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem427;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem428;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem429;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem430;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem431;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem432;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem433;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem434;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem435;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem436;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem437;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem438;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem439;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem440;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem441;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem442;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem443;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem444;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem445;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem446;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem447;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem448;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem449;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem450;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem451;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem452;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem453;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem454;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem455;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem456;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem457;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem458;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem459;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem460;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem461;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem462;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem463;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem464;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem465;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem466;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem467;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem468;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem469;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem470;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem471;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem472;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem473;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem474;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem475;
        private IHIS.Framework.XEditGridCell xEditGridCell94;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem160;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem161;
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
        private IHIS.Framework.XDictComboBox cboInputGubun;
        private IHIS.Framework.XLabel lblInputGubun;
        private PictureBox pbxIsBgtDrg;
        private IHIS.Framework.XButton btnBroughtDrg;
        private IHIS.Framework.XEditGridCell xEditGridCell95;
        private IHIS.Framework.XEditGridCell xEditGridCell96;
        private IHIS.Framework.XEditGridCell xEditGridCell98;
        private IHIS.Framework.XEditGridCell xEditGridCell99;
        private IHIS.Framework.XEditGridCell xEditGridCell100;
        private IHIS.Framework.XComboItem xComboItem3;
        private IHIS.Framework.XComboItem xComboItem4;
        private IHIS.Framework.XComboItem xComboItem5;
        private IHIS.Framework.XComboItem xComboItem6;
        private IHIS.Framework.XEditGridCell xEditGridCell101;
        private IHIS.Framework.XEditGridCell xEditGridCell103;
        private string allWarning = "";
        #endregion

        private const int maxRowpage = 200;

        #region Properties
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
        private XButton btnInsert;
        private XCheckBox mCbxAutoMixYN;
        private bool isEnableGrd = true;

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

        public XCheckBox MCbxAutoMixYN
        {
            get
            {
                return mCbxAutoMixYN;
            }
            set
            {
                mCbxAutoMixYN = value;
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

        #region 1. 생성자를 정의한다
        public UCOCS0103U12C()
            : this(false)
        {

        }

        private bool _initialized = false;

        public void EnsureInitialized()
        {
            if (!_initialized)
            {
                InitializeComponent();

                cboResult = InitializeComboBox();
                this.cboSearchCondition.ExecuteQuery = LoadDataCboSearchCondition;
                this.cboInputGubun.ExecuteQuery = LoadDataCboInputGubun;
                cboSearchCondition.SetDictDDLB();
                cboInputGubun.SetDictDDLB();

                grdSangyongOrder.ParamList = new List<string>(new String[] { "f_hosp_code", "f_user", "f_io_gubun", "f_search_word", "f_order_gubun", "f_order_date", "f_wonnae_drg_yn" });
                grdSangyongOrder.ExecuteQuery = LoadDataGrdSangyongOrder;
                layDrugTree.ExecuteQuery = LoadDataLayDrugTree;

                this.fwkFind.ParamList = new List<string>(new String[] { "f_find1", "f_code_type" });

                _initialized = true;
            }

        }
        public UCOCS0103U12C(bool initialize)
        {
            // MessageBox.Show("Constructor start");
            if (initialize) EnsureInitialized();
        }

        private IList<object[]> LoadGrdSearchOrder(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            LoadSearchOrder1Args args = new LoadSearchOrder1Args();
            args.InputInfo = new IHIS.CloudConnector.Contracts.Models.Ocs.Lib.LoadSearchOrder1RequestInfo();
            args.InputInfo.SearchWord = varlist["f_search_word"].VarValue;
            args.InputInfo.GijunDate = varlist["f_gijun_date"].VarValue;
            args.InputInfo.InputTab = varlist["f_input_tab"].VarValue;
            args.InputInfo.WonnaeDrgYn = varlist["f_wonnae_drg_yn"].VarValue;
            args.InputInfo.PageNumber = varlist["f_page_number"] != null ? varlist["f_page_number"].VarValue : "";
            args.InputInfo.Offset = maxRowpage.ToString();
            args.InputInfo.ProtocolId = this._protocolID;
            LoadSearchOrder1Result result = CloudService.Instance.Submit<LoadSearchOrder1Result, LoadSearchOrder1Args>(args);

            if (result != null && result.SearchResult != null && result.SearchResult.Count > 0)
            {
                List<LoadSearchOrderInfo> grdList = result.SearchResult;
                foreach (LoadSearchOrderInfo info in grdList)
                {
                    dataList.Add(new object[]
                    {
                        info.TrialFlag,
                        info.SlipCode,
                        info.SlipName,
                        info.HangmogCode,
                        info.HangmogName,
                        info.WonnaeDrgYn,
                        info.YakKijunCode
                    });
                }
            }
            return dataList;
        }

        private IList<object[]> LoadDataGrdGeneral(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            OCS0103U12GrdGeneralArgs args = new OCS0103U12GrdGeneralArgs();
            args.Filter = varlist["f_filter"].VarValue;
            args.HangmogCode = varlist["f_hangmog_code"].VarValue;
            args.OrderDate = varlist["f_order_date"].VarValue;
            args.YakKijunCode = varlist["f_yak_kijun_code"].VarValue;
            args.PageNumber = varlist["f_page_number"] != null ? varlist["f_page_number"].VarValue : "";
            args.Offset = maxRowpage.ToString();
            OCS0103U12GrdGeneralResult result =
                CloudService.Instance.Submit<OCS0103U12GrdGeneralResult, OCS0103U12GrdGeneralArgs>(args);

            if (result != null && result.Info1 != null && result.Info1.Count > 0)
            {
                List<OCS0103U12GrdGeneralInfo> grdList = result.Info1;
                foreach (OCS0103U12GrdGeneralInfo info in grdList)
                {
                    dataList.Add(new object[]
                    {
                        info.SlipCode,
                        info.SlipName,
                        info.HangmogCode,
                        info.HangmogName,
                        info.WonnaeDrgYn
                    });
                }
            }
            return dataList;
        }

        private IList<object[]> LoadDataLayDrugTree(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            OCS0103U12LayDrugTreeArgs args = new OCS0103U12LayDrugTreeArgs();
            OCS0103U12LayDrugTreeResult result =
                CloudService.Instance.Submit<OCS0103U12LayDrugTreeResult, OCS0103U12LayDrugTreeArgs>(args);
            if (result != null && result.LayDrugTreeList != null && result.LayDrugTreeList.Count > 0)
            {
                List<OCS0103U12LayDrugTreeInfo> layList = result.LayDrugTreeList;
                foreach (OCS0103U12LayDrugTreeInfo info in layList)
                {
                    dataList.Add(new object[]
                    {
                        info.Code,
                        info.CodeName,
                        info.Code1,
                        info.CodeName1
                    });
                }
            }
            return dataList;
        }

        private IList<object[]> LoadDataGrdSangyongOrder(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            OCS0103U12GrdSangyongOrderArgs args = new OCS0103U12GrdSangyongOrderArgs();
            args.IoGubun = varlist["f_io_gubun"].VarValue;
            args.OrderDate = varlist["f_order_date"].VarValue;
            args.OrderGubun = varlist["f_order_gubun"].VarValue;
            args.SearchWord = varlist["f_search_word"].VarValue;
            args.User = varlist["f_user"].VarValue;
            args.WonnaeDrgYn = varlist["f_wonnae_drg_yn"].VarValue;
            args.ProtocolId = this._protocolID;
            OCS0103U12GrdSangyongOrderResult result =
                CloudService.Instance.Submit<OCS0103U12GrdSangyongOrderResult, OCS0103U12GrdSangyongOrderArgs>(args, true);
            if (result != null)
            {
                List<OCS0103U12GrdSangyongOrderInfo> grdList = result.GrdSangyongList;
                foreach (OCS0103U12GrdSangyongOrderInfo info in grdList)
                {
                    dataList.Add(new object[]
                    {
                        info.TrialFlag,
                        info.SlipCode,
                        info.SlipName,
                        info.HangmogCode,
                        info.HangmogName,
                        info.Seq,
                        info.HospCode,
                        info.Memb,
                        info.MembGubun,
                        info.WonnaeDrgYn,
                        info.Rownum
                    });
                }
            }
            return dataList;
        }

        #endregion

        #region 2. Form변수를 정의한다

        private string mbxMsg = "", mbxCap = "";

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
        //modify by jc
        private int OrderExtendWidth = 850;
        //private int OrderExtendWidth = 1081;

        private int OrderNormalWidth = 762;
        private bool mIsExtended = false;

        private bool mPostApproveYN = false;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // 조회부분 화면 확장 관련
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private int OrderMinWidth = 618;
        private bool mIsSearchExtended = false;

        private int PreviewHangmogMaxWidth = 315;
        private int PreviewHangmogNormalWidth = 179;

        private int SearchHangmogNameNormalWidth = 304;
        private int SearchHangmogNameMaxWidth = 443;

        private int DrgHangmogNameNormalWidth = 152;
        private int DrgHangmogNameMaxWidth = 294;

        private int SangYongHangmogNormalWidth = 305;
        private int SangYongHangmogMaxWidth = 441;


        ///////////// Order 기본값 /////////////////////////////////////////////////////////////////////////
        private const string INPUTTAB = "03"; // 내복약 (01) 
        private string IOEGUBUN = "O";     // 입외구분(외래)
        private string mInputGubun = "D0";    // 입력구분(의사처방)
        private string mInputGubunName = "";  // 입력구분명
        private string mInputPart = "";      // 입력파트
        private string mCallerSysID = "";
        private string mCallerScreenID = "";

        //insert by jc [OCS1003P01のデータウインドウから選択された際、自動ポイント移動に必要な変数]
        private int mCurrentRowNum = -1;
        private XDataWindow mCurrentDataWindow;
        private string mCurrentColName = "";

        //공통
        private XEditGrid mSelectedGRD = null;
        private string mOrderDate = "";
        private string mBunho = "";
        //private MultiLayout mOrderLayout;
        private OrderVariables.OrderMode mOrderMode;
        //입원외래 order
        private string mPkInOutKey = "";
        // 셋트오더 관련 _ 키
        private string mMemb = "";
        private string mYaksokCode = "";
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
        private IHIS.X.Magic.Menus.PopupMenu popupOftenUsedMenu = new IHIS.X.Magic.Menus.PopupMenu(); // 상용처방Grid용
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
        //string mTemp = "";

        private const string CACHE_OCS0103U12_COMBO_LIST_ITEM_KEYS = "OCSO.Ocs0103U12.ComboList";
        private OCS0103U12InitComboBoxResult cboResult;
        private OCS0103U12ScreenOpenResult screenOpenResult;
        private OCS0103U12LoadDrgOrderResult drgOrderResult;

        #endregion

        #region 3. Properties를 정의한다
        private string _protocolID = "";
        private bool _screenActivated = false;
        private CommonItemCollection _aOpenParam;

        public bool ScreenActivated
        {
            get { return _screenActivated; }
        }

        #endregion

        #region 4. OnLoad 및 Main Screen Event를 정의한다
        /// <summary>
        /// Screen Open시 Parameter를 받는다 (등록번호 연계)
        /// </summary>
        /// <remarks>
        /// 해당 등록번호와 내원정보로 외래처방 데이타 조회
        /// </remarks>
        public string ScreenOpen(CommonItemCollection aOpenParam)
        {
            if (!_screenActivated)
            {
                _aOpenParam = aOpenParam;
                return "";
            }
            grdOrder.Reset();

            if (aOpenParam != null && aOpenParam.Contains("caller_screen_id"))
            {
                this.mCallerScreenID = aOpenParam["caller_screen_id"].ToString();
            }
            if (UserInfo.UserGubun == UserType.Doctor)
            {
                this.mDoctorLogin = true;
            }

            if (aOpenParam != null && aOpenParam.Contains("drug_dt"))
            {
                this.mDrugDt = aOpenParam["drug_dt"] as DataTable;
            }

            SetEnableUcGrid(true);
            isEnableGrd = true;
            if (aOpenParam != null && aOpenParam.Contains("is_enable_grd") && (bool)aOpenParam["is_enable_grd"].Equals(false))
            {
                SetEnableUcGrid(false);
                isEnableGrd = false;
            }

            /*this.mOrderBiz = new IHIS.OCS.OrderBiz(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());             // OCS 그룹 Business 라이브러리
            this.mOrderFunc = new IHIS.OCS.OrderFunc(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());            // OCS 그룹 Function 라이브러리
            this.mPatientInfo = new IHIS.OCS.PatientInfo(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());        // OCS 환자정보 그룹 라이브러리 
            this.mHangmogInfo = new IHIS.OCS.HangmogInfo(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());        // OCS 항목정보 그룹 라이브러리
            this.mInputControl = new IHIS.OCS.InputControl(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());      // 입력제어 그룹 라이브러리 
            this.mCommonForms = new IHIS.OCS.CommonForms();                 // OCS 공통Form's 그룹 라이브러리 
            this.mColumnControl = new ColumnControl(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());      // OCS 오더별 컬럼 컨트롤 라이브러리
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

                // 오더일자
                if (aOpenParam.Contains("order_date"))
                {
                    this.mOrderDate = aOpenParam["order_date"].ToString();
                }
                else
                {
                    this.mOrderDate = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/");
                }

                // 환자번호
                if (aOpenParam.Contains("bunho"))
                {
                    this.mBunho = aOpenParam["bunho"].ToString();
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
                    //this.mOrderBiz.LoadColumnCodeName("code", "INPUT_GUBUN", this.mInputGubun, ref this.mInputGubunName);

                    //tungtx
                    OCS0103U12LoadColumnNameArgs args = new OCS0103U12LoadColumnNameArgs();
                    LoadColumnCodeNameInfo info = new LoadColumnCodeNameInfo();
                    info.ColName = "code";
                    info.Arg1 = "INPUT_GUBUN";
                    info.Arg2 = this.mInputGubun;
                    args.Code = info;
                    OCS0103U12LoadColumnNameResult result =
                        CloudService.Instance.Submit<OCS0103U12LoadColumnNameResult, OCS0103U12LoadColumnNameArgs>(args);
                    if (result != null)
                    {
                        this.mInputGubunName = result.CodeName;
                    }

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
                    this._protocolID = aOpenParam["protocol_id"].ToString();
                }

                //inser by jc [CpSetOrderの場合は日数ボタンを見せない] 2012/04/09
                if (this.mCallerScreenID == "OCS6000U00")
                    this.btnNalsu.Visible = false;
                //his.MakeGroupTabInfo(this.IOEGUBUN, this.mPkInOutKey, this.mInputGubun, INPUTTAB);

                // 오더일자와 환자번호는 변경할수 없도록 프로텍트 처리

                this.hopeDateColorChange();
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

            //tungtx
            OCS0103U12ScreenOpenArgs screenOpenArgs = new OCS0103U12ScreenOpenArgs();
            OcsOrderBizGetUserOptionInfo userOptionInfo = new OcsOrderBizGetUserOptionInfo();
            userOptionInfo.Doctor = UserInfo.UserID;
            userOptionInfo.Gwa = UserInfo.Gwa;
            userOptionInfo.Keyword = "SENTOU_SEARCH_YN";
            userOptionInfo.IoGubun = this.IOEGUBUN;

            List<ComboDataSourceInfo> listCboDataSource = new List<ComboDataSourceInfo>();
            ComboDataSourceInfo infoOrderGubunBas = new ComboDataSourceInfo();
            infoOrderGubunBas.ColName = "order_gubun_bas";
            ComboDataSourceInfo infoDvTime = new ComboDataSourceInfo();
            infoDvTime.ColName = "dv_time";
            ComboDataSourceInfo infoSuryang = new ComboDataSourceInfo();
            infoSuryang.ColName = "suryang";
            ComboDataSourceInfo infoDv = new ComboDataSourceInfo();
            infoDv.ColName = "dv";
            ComboDataSourceInfo infoNalsu = new ComboDataSourceInfo();
            infoNalsu.ColName = "nalsu";
            listCboDataSource.Add(infoOrderGubunBas);
            listCboDataSource.Add(infoDvTime);
            listCboDataSource.Add(infoSuryang);
            listCboDataSource.Add(infoDv);
            listCboDataSource.Add(infoNalsu);

            screenOpenArgs.GetUserOption = userOptionInfo;
            screenOpenArgs.ComboInfo = listCboDataSource;
            screenOpenArgs.Bunho = aOpenParam.Contains("bunho") ? mPatientInfo.GetPatientInfo["bunho"].ToString() : string.Empty;
            screenOpenArgs.Pkinp1001 = aOpenParam.Contains("bunho") ? mPatientInfo.GetPatientInfo["naewon_key"].ToString() : string.Empty;
            screenOpenArgs.InputTab = INPUTTAB;

            screenOpenResult = CloudService.Instance.Submit<OCS0103U12ScreenOpenResult, OCS0103U12ScreenOpenArgs>(screenOpenArgs);
            string mSentouSearchYN = "";
            DataTable dtDvTime = new DataTable();
            DataTable dtSuryang = new DataTable();
            DataTable dtDv = new DataTable();
            DataTable dtNalsu = new DataTable();
            DataTable dtJusa = new DataTable();

            if (screenOpenResult != null)
            {
                if (screenOpenResult.UserOptionResult != null)
                {
                    mSentouSearchYN = screenOpenResult.UserOptionResult;
                }
                if (screenOpenResult.CboDvTime != null)
                {
                    dtDvTime = ConvertToDataTable<ComboListItemInfo>(screenOpenResult.CboDvTime);
                }
                if (screenOpenResult.CboSuryang != null)
                {
                    dtSuryang = ConvertToDataTable<ComboListItemInfo>(screenOpenResult.CboSuryang);
                }
                if (screenOpenResult.CboDv != null)
                {
                    dtDv = ConvertToDataTable<ComboListItemInfo>(screenOpenResult.CboDv);
                }
                if (screenOpenResult.CboNalsu != null)
                {
                    dtNalsu = ConvertToDataTable<ComboListItemInfo>(screenOpenResult.CboNalsu);
                }
            }
            ComboJusaSpdGubunArgs arg = new ComboJusaSpdGubunArgs();
            ComboResult res = CloudService.Instance.Submit<ComboResult, ComboJusaSpdGubunArgs>(arg);
            if (res.ComboItem != null)
            {
                dtJusa = ConvertToDataTable<ComboListItemInfo>(res.ComboItem);
            }

            //insert into [検索語の検索条件初期化] 2012/10/15 
            //Random selected [like %word%]
            //Front selected [like word%]
            //string mSentouSearchYN = this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "SENTOU_SEARCH_YN", this.IOEGUBUN);
            if (mSentouSearchYN == "Y")
                //this.cbxSentou.Checked = true;
                this.cboSearchCondition.SelectedIndex = 1;
            else
                this.cboSearchCondition.SelectedIndex = 0;

            // 신규 탭페이지 설정
            this.tpgNew.Title = XMsg.GetMsg("M002"); // 신규로 작성
            this.tpgNew.ImageIndex = 1;
            Hashtable groupInfo = new Hashtable();
            groupInfo.Add("group_ser", "0");
            groupInfo.Add("group_name", "New");

            // 처방구분정보 Load
            //mDtOrderGubun = this.mOrderBiz.LoadComboDataSource("order_gubun_bas").LayoutTable;

            //// 라디오 버튼 -- 오더 상황이 디폴트
            //if (this.rbnOrderStatus.Checked == false)
            //{
            //    this.rbnOrderStatus.Checked = true;
            //}

            this.InitScreen();

            // 각종 콤보 데이터 로드 
            //DataTable dtTemp;

            ////             dv_time 콤보 구성
            //dtTemp = this.mOrderBiz.LoadComboDataSource("dv_time").LayoutTable;
            //this.grdOrder.SetListItems("dv_time", dtTemp, "code_name", "code");

            //tungtx
            this.grdOrder.SetListItems("dv_time", dtDvTime, "code_name", "code");



            // 수량, 횟수 콤보 구성
            //this.mOrderBiz.SetNumCombo(this.grdOrder, "suryang", true);
            //tungtx
            this.mOrderBiz.SetNumCombo(this.grdOrder, "suryang", true, dtSuryang);
            this.mOrderBiz.SetNumCombo(this.grdOrder, "jusa_spd_gubun", true, dtJusa);

            //this.mOrderBiz.SetNumCombo(this.grdOrder, "dv", false);
            //tungtx
            this.mOrderBiz.SetNumCombo(this.grdOrder, "dv", false, dtDv);

            // 횟수(1234) 콤보구성
            //this.mOrderBiz.SetNumCombo(this.grdOrder, "dv_1", true);
            //this.mOrderBiz.SetNumCombo(this.grdOrder, "dv_2", true);
            //this.mOrderBiz.SetNumCombo(this.grdOrder, "dv_3", true);
            //this.mOrderBiz.SetNumCombo(this.grdOrder, "dv_4", true);

            // 날수 콤보
            //this.mOrderBiz.SetNumCombo(this.cboNalsu, "nalsu", false);
            //tungtx
            this.mOrderBiz.SetNumCombo(this.cboNalsu, "nalsu", false, dtNalsu);

            this.InitializeScreen();

            /*cboQueryCon.SetEditValue("%");*/

            //MessageBox.Show("Onload end");

            //PostCallHelper.PostCall(new PostMethod(PostLoad));
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
            else
            {
                //OverrideLookAndFeel();
            }

            return mInputGubunName;
        }
        private void SetEnableUcGrid(bool isEnable)
        {
            //tabGroup.Enabled = isEnable;
            grdOrder.Enabled = isEnable;
            grdOutSang.Enabled = isEnable;
            grdSangyongOrder.Enabled = isEnable;
            cbxEmergency.Enabled = isEnable;
            pnlOrderDetail.Enabled = isEnable;
            cboNalsu.Enabled = isEnable;
            btnNalsu.Enabled = isEnable;
            cbxWonyoiOrderYN.Enabled = isEnable;
            btnBroughtDrg.Enabled = isEnable;
            btnJungsiDrug.Enabled = isEnable;
            btnDoOrder.Enabled = isEnable;
            btnSetOrder.Enabled = isEnable;
            btnInsert.Enabled = isEnable;
            btnNewSelect.Enabled = isEnable;
            btnSelect.Enabled = isEnable;
            fbxJusa.Enabled = isEnable;
            dbxJusaName.Enabled = isEnable;

            if (isEnable) cbxEmergency.CheckedChanged += cbxEmergency_CheckedChanged;
            else cbxEmergency.CheckedChanged -= cbxEmergency_CheckedChanged;

            if (isEnable) cbxWonyoiOrderYN.CheckedChanged += cbxWonyoiOrderYN_CheckedChanged;
            else cbxWonyoiOrderYN.CheckedChanged -= cbxWonyoiOrderYN_CheckedChanged;

            if (mBtnCopy != null) mBtnCopy.Enabled = isEnable;
            if (mBtnPaste != null) mBtnPaste.Enabled = isEnable;
            if (mBtnMix != null) mBtnMix.Enabled = isEnable;
            if (mBtnMixCancel != null) mBtnMixCancel.Enabled = isEnable;
            if (mBtnChangeWonyoi != null) mBtnChangeWonyoi.Enabled = isEnable;

            //right
            cboQueryCon.Enabled = isEnable;
            cboSearchCondition.Enabled = isEnable;
            txtSearch.Enabled = isEnable;
        }

        private void OverrideLookAndFeel()
        {
            pbxIsBgtDrg.Location = new Point(390, 8);
            btnBroughtDrg.Location = new Point(390, 4);
            btnJungsiDrug.Location = new Point(390, 33);
            btnSetOrder.Location = new Point(525, 34);
            btnNalsu.Location = new Point(305, 4);
            btnDoOrder.Location = new Point(525, 4);
            dbxJusaName.Location = new Point(128, 6);
            fbxJusa.Location = new Point(75, 6);
            cboNalsu.Location = new Point(225, 35);
            xLabel4.Location = new Point(305, 37);
            cbxEmergency.Location = new Point(110, 39);
            cbxWonyoiOrderYN.Location = new Point(372, 42);
            pnlFill.Location = new Point(0, 0);
            pnlSangyong.Location = new Point(0, 72);
            cboSearchCondition.Location = new Point(171, 40);
            txtSearch.Location = new Point(70, 41);
            xLabel5.Location = new Point(6, 41);
            btnInsert.Location = new Point(5, 6);
            btnSelect.Location = new Point(220, 6);
            btnNewSelect.Location = new Point(88, 6);
            btnBroughtDrg.Size = new Size(82, 27);
            btnJungsiDrug.Size = new Size(135, 27);
            btnSetOrder.Size = new Size(81, 27);
            btnNalsu.Size = new Size(120, 27);
            btnDoOrder.Size = new Size(81, 27);
            dbxJusaName.Size = new Size(173, 20);
            fbxJusa.Size = new Size(47, 20);
            xLabel8.Size = new Size(62, 19);
            cboNalsu.Size = new Size(76, 21);
            xLabel4.Size = new Size(61, 19);
            xLabel3.Size = new Size(62, 19);
            pnlSangyong.Size = new Size(426, 386);
            grdSangyongOrder.Size = new Size(426, 356);
            pnlSearchTool.Size = new Size(426, 72);
            cboQueryCon.Size = new Size(172, 20);
            btnInsert.Size = new Size(83, 29);
            btnSelect.Size = new Size(63, 29);
            btnNewSelect.Size = new Size(130, 29);
            this.AutoScaleDimensions = new SizeF(6, 13);
            this.Size = new Size(1150, 531);
            //
            this.txtSearch.Location = new Point(99, 41);
            this.cboSearchCondition.Location = new Point(184, 41);
        }


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
                //HandleBtnListButtonClick(FunctionType.Query);

                this.MakeGroupTabInfo(IOEGUBUN, this.mPkInOutKey, this.mInputGubun, INPUTTAB);
            }

            if (this.grdOrder.RowCount > 0)
            {
                if (aOpenParam.Contains("isOpenPopUp") && aOpenParam["isOpenPopUp"].Equals(true))
                {
                    HandleBtnListButtonClick(FunctionType.Process, out msgOut);
                }
            }

            // 오더가 있는경우는 디폴트가 오더 상황
            // 없는 경우는 디폴트가 오더검색
            //DataRow[] dr = grdOrder.LayoutTable.Select("input_gubun = '"+mInputGubun+"'");

            ////if (this.grdOrder.RowCount > 0)
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
            this.txtSearch.Focus();
            this.setFocusGotoColumn();

            SetEnableRbn();
            if (aOpenParam != null && !aOpenParam["isOpenPopUp"].Equals(true))
            {
                rbnOftenOrder.Checked = true;
                rbnOftenOrder.Dock = DockStyle.Fill;
            }
            else
            {
                rbnOftenOrder.Checked = true;
                rbnOftenOrder.Dock = DockStyle.Fill;
            }
        }

        private void SetEnableRbn()
        {
            rbnOftenOrder.Visible = true;
        }

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

            //tungtx
            if (screenOpenResult != null && screenOpenResult.YnValue != "N" && this.btnBroughtDrg.Visible == true)
                this.pbxIsBgtDrg.Visible = true;
            else
                this.pbxIsBgtDrg.Visible = false;
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
                string name = "";
                //this.mOrderBiz.LoadColumnCodeName("gwa_doctor", "%", this.mMemb, EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"), ref name);

                //if (name == "")
                //{
                //    // 주과의 상용오더를 가져오자.
                //    string mainDoctorCode = this.mOrderBiz.GetMainGwaDoctorCode(this.mMemb);
                //    if (mainDoctorCode != "")

                //tungtx
                OCS0103U12InitializeScreenArgs args = new OCS0103U12InitializeScreenArgs();
                LoadColumnCodeNameInfo info = new LoadColumnCodeNameInfo();
                info.ColName = "gwa_doctor";
                info.Arg1 = "%";
                info.Arg2 = "0110001";
                info.Arg3 = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/");
                args.Code = info;
                OCS0103U12InitializeScreenResult result =
                    CloudService.Instance.Submit<OCS0103U12InitializeScreenResult, OCS0103U12InitializeScreenArgs>(args);
                if (result != null)
                {
                    name = result.CodeName;
                    if (name == "")
                    {
                        string mainDoctorCode = result.MainDoctorCode;
                        if (mainDoctorCode != "")
                        {
                            this.MakeSangyongTab(mainDoctorCode, INPUTTAB);
                        }
                        else
                        {
                            this.MakeSangyongTab(mMemb, INPUTTAB);
                        }
                    }
                    else
                    {
                        this.MakeSangyongTab(mMemb, INPUTTAB);
                    }
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

            // 약오더를 로드한다.
            this.MakeDrugOrder();


        }

        private void OCS0103U12_Closing(object sender, CancelEventArgs e)
        {
            //string mbxMsg = "", mbxCap = "";

            // 처방 변경된 자료가 있는 경우 자료 Reset됨을 알림
            // 처방 입력가능여부 이면서 자료 수정여부 체크
            //if (this.IsOrderInputCheck(false, true, false) && this.IsOrderDataModifed())
            //{
            //    mbxMsg = "저장하지 않은 데이타가 존재합니다.\r\n외래처방을 종료하시겠습니까?";
            //    mbxCap = "종료여부";
            //    if (XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.YesNo) == DialogResult.No)
            //    {
            //        e.Cancel = true;
            //        return;
            //    }
            //}

            // 종료 버튼등 클릭여부 Validation Check 안하기 위함
            // Control의 Validation 체크에 의하여 종료가 안되는 것을 푼다... (중요)
            e.Cancel = false;

        }

        #endregion


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
                string input = prop.Name;
                StringBuilder sb = new StringBuilder();
                sb.Append(input[0].ToString().ToLower());
                for (int i = 1; i < input.Length; i++)
                {
                    char c = input[i];
                    if (Char.IsUpper(c))
                    {
                        sb.Append("_").Append(c.ToString().ToLower());
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
                dataTable.Columns.Add(sb.ToString());
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

        #region [ 각종 초기화 ]

        private void InitScreen()
        {
            this.grdOrder.AutoSizeColumn(29, 0); //注射部位コード
            this.grdOrder.AutoSizeColumn(30, 0); //注射部位名称

            //this.grdOrder.AutoSizeColumn(2, 0); // GR
            ////this.grdOrder.AutoSizeColumn(14, 0);// 일포화
            ////this.grdOrder.AutoSizeColumn(16, 0);// 비치
            ////this.grdOrder.AutoSizeColumn(17, 0);// 간이현탁
            ////this.grdOrder.AutoSizeColumn(18, 0);// 퇴/외
            ////this.grdOrder.AutoSizeColumn(19, 0);// 분쇄
            //this.grdOrder.AutoSizeColumn(15, 0);// 일포화
            //this.grdOrder.AutoSizeColumn(17, 0);// 비치
            //this.grdOrder.AutoSizeColumn(18, 0);// 간이현탁
            //this.grdOrder.AutoSizeColumn(19, 0);// 퇴/외
            //this.grdOrder.AutoSizeColumn(20, 0);// 분쇄


            //// 셋트 오더인경우는 정시약, 반납지시 컬럼이 보이면 안됨. 그룹시리얼도
            //if (this.mOrderMode == OrderVariables.OrderMode.SetOrder||
            //    this.mOrderMode == OrderVariables.OrderMode.CpSetOrder)
            //{
            //    this.grdOrder.AutoSizeColumn(1, 0);
            //    this.grdOrder.AutoSizeColumn(2, 0);
            //    this.grdOrder.AutoSizeColumn(3, 0);
            //    //this.grdOrder.AutoSizeColumn(20, 0);
            //    this.grdOrder.AutoSizeColumn(8, 0);
            //    this.grdOrder.AutoSizeColumn(21, 0);

            //}
            //// 의사 오더인 경우는 반납지시 컬럼이 보이지 않ㄴㅡㄴ다.
            //else if (UserInfo.UserGubun == UserType.Doctor)
            //{
            //    this.grdOrder.AutoSizeColumn(1, 0);
            //    this.grdOrder.AutoSizeColumn(25, 0);
            //}

            //if (this.mOrderMode != OrderVariables.OrderMode.SetOrder)
            //{
            //    this.grdOrder.AutoSizeColumn(22, 0);  // 외래 행위부서
            //    this.grdOrder.AutoSizeColumn(23, 0);  // 입원 행위부서
            //}
            //else
            //{
            //    this.grdOrder.AutoSizeColumn(21, 0);
            //}

            this.grdOrder.AutoSizeColumn(4, 0); // GR//
            this.grdOrder.AutoSizeColumn(17, 0);// 일포화//
            this.grdOrder.AutoSizeColumn(19, 0);// 비치//
            this.grdOrder.AutoSizeColumn(20, 0);// 간이현탁//
            this.grdOrder.AutoSizeColumn(21, 0);// 퇴/외//
            this.grdOrder.AutoSizeColumn(22, 0);// 분쇄//
            this.grdOrder.AutoSizeColumn(26, 0);// 後発//
            this.grdOrder.AutoSizeColumn(28, 0);// 在宅//


            // 셋트 오더인경우는 정시약, 반납지시 컬럼이 보이면 안됨. 그룹시리얼도
            if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                this.mOrderMode == OrderVariables.OrderMode.CpSetOrder)
            {
                this.grdOrder.AutoSizeColumn(1, 0);
                this.grdOrder.AutoSizeColumn(4, 0);//GR//
                this.grdOrder.AutoSizeColumn(5, 0);//定時//
                this.grdOrder.AutoSizeColumn(10, 0);//希望日//
                this.grdOrder.AutoSizeColumn(23, 0);//行為部署//
                this.cboInputGubun.Visible = false;
                this.lblInputGubun.Visible = false;

            }
            // 의사 오더인 경우는 반납지시 컬럼이 보이지 않ㄴㅡㄴ다.
            else if (UserInfo.UserGubun == UserType.Doctor)
            {
                this.grdOrder.AutoSizeColumn(1, 0);
                this.grdOrder.AutoSizeColumn(27, 0);//
            }

            if (this.mOrderMode == OrderVariables.OrderMode.InpOrder)
            {
                // 持参薬があるかどうかチェックし点滅させる。
                setBgtDrgICON();
            }

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder)
            {
                this.grdOrder.AutoSizeColumn(24, 0);  // 외래 행위부서//
                this.grdOrder.AutoSizeColumn(25, 0);  // 입원 행위부서//
            }
            else
            {
                this.grdOrder.AutoSizeColumn(23, 0);//
            }


            // 입원 외래에 따른 조회 조건 기본셋팅값
            if (this.IOEGUBUN == "O")
            {
                this.cboInputGubun.Visible = false;
                this.lblInputGubun.Visible = false;
                this.grdOrder.AutoSizeColumn(31, 0);//持参
                this.btnBroughtDrg.Visible = false; // 持参薬ボタン
            }
            else
            {
                this.grdOrder.AutoSizeColumn(5, 0);//定時//
                this.btnJungsiDrug.Visible = false;
            }
            if (this.mInputGubun == "D7")
            {
                this.btnNalsu.Visible = false;
            }

            //modify by jc [病院側で基本院内採用薬にしてほしいと]
            this.cboQueryCon.SetDataValue("%"); // 원내 채용약 기본

            // 팝업메뉴 초기화
            // 오더 팝업메뉴
            // 처방Grid PopupMenu
            popupOrderMenu.MenuCommands.Clear();
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.Btn_00001, (Image)this.imageListPopupMenu.Images[0],
                new EventHandler(PopUpMenuSelectAll_Click)));
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.Btn_00002, (Image)this.imageListPopupMenu.Images[1],
                new EventHandler(PopUpMenuUnSelectAll_Click)));
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.Btn_00008, (Image)this.imageListPopupMenu.Images[2],
                new EventHandler(PopUpMenuInsert_Click)));
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.Btn_00009, (Image)this.imageListPopupMenu.Images[3],
                new EventHandler(PopUpMenuPaste_Click)));
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.Btn_00003, (Image)this.imageListPopupMenu.Images[4],
                new EventHandler(PopUpMenuDelete_Click)));
            //popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.Btn_00004, (Image)this.imageListPopupMenu.Images[5],
            //    new EventHandler(PopUpMenuMix_Click)));
            //popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.Btn_00005, (Image)this.imageListPopupMenu.Images[6],
            //    new EventHandler(PopUpMenuMixCancel_Click)));
            //popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.Btn_00006, (Image)this.imageListPopupMenu.Images[7],
            //    new EventHandler(PopUpMenuSelectOftenOrder_Click)));

            // 상용오더 팝업메뉴
            popupOftenUsedMenu.MenuCommands.Clear();
            popupOftenUsedMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.Btn_00007, (Image)this.imageListPopupMenu.Images[4],
                new EventHandler(PopUpMenuSelectOftenOrderDelete_Click)));

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

            this.grdOrder.DisplayData(true);

            this.DisplayMixGroup(this.grdOrder);

            this.SetOrderImage(this.grdOrder);

            this.MakePreviewStatus();
        }

        #endregion

        #region [ 다른 화면 오픈 ]

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
            CommonItemCollection param = new CommonItemCollection();

            param.Add("hangmog_code", aHangmogCode);
            param.Add("multiSelect", true);
            param.Add("input_tab", INPUTTAB);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103Q00", ScreenOpenStyle.ResponseFixed, param);
        }

        private void OpenScreen_OCS0301Q09()
        {
            string naewon_date = mOrderDate.PadRight(10).Substring(0, 10).Replace("-", "/");

            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("input_tab", INPUTTAB);
            openParams.Add("input_gubun", this.mInputGubun);

            if (UserInfo.Gwa == "CK")
            {
                openParams.Add("gwa", this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString().Substring(0, 2));
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
                openParams.Add("gwa", this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString().Substring(0, 2));
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
            XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003Q09", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void OpenScreen_OCS1023U00(string aBunho, string aGwa)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", aBunho);
            param.Add("gwa", aGwa);
            param.Add("auto_close", "Y");
            param.Add("input_tab", INPUTTAB);

            XScreen.OpenScreenWithParam(this, "OCSO", "OCS1023U00", ScreenOpenStyle.ResponseFixed, param);
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

        #region [ 각종 비지니스 메소드 ]

        #region 환자정보 라벨 관련
        /// <summary>
        /// 오더모드에 따른 환자정보 패널 셋팅
        /// </summary>
        private void SetVisiblePatientInfoPanel()
        {
            if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                this.mOrderMode == OrderVariables.OrderMode.CpSetOrder)
            {
                if (this.MPnlTop != null) this.MPnlTop.Visible = false;
                this.btnDoOrder.Visible = false;
                //delete by jc [セットオーダを登録する際にも既存のセットオーダを参考にしたいという要請] 2012/04/24
                //this.btnSetOrder.Visible = false;
                this.btnJungsiDrug.Visible = false;
            }
        }

        #endregion

        #region 원래 오더 화면에 데이터 넘기기

        private void InvokeReturnSendReturnDataTable()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("isOpenPopUp", isOpenPopUp);
            if (this.mOrderMode == OrderVariables.OrderMode.InpOrder && this.mCallerScreenID != "OCS2003P01")
                param.Add("jusa_order", this.laySaveLayout);
            else
                param.Add("jusa_order", this.grdOrder);

            param.Add("allWarning", this.allWarning);

            if (MOpener != null) MOpener.Command("OCS0103U12", param);
        }

        #endregion

        #region 저장전 체크

        public bool IsUpdateCheck(out string msgOut)
        {
            msgOut = "";
            Hashtable groupInfo;
            ArrayList delList = new ArrayList();
            bool isUpdatable = true;
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

            #region 업데이트 체크
            // 그룹정보 입력체크 
            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroup.TabPages)
            {
                groupInfo = tpg.Tag as Hashtable;

                if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                    this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
                {
                    // 복용코드 체크 
                    ////////////////////////////////////////////////////////////////////////////////////////////
                    if (groupInfo.Contains("jusa"))
                    {
                        if (groupInfo["jusa"].ToString() == "")
                        {
                            msg = XMsg.GetMsg("M005"); //그룹에 대하여 복용코드를 입력해 주세요.
                            isUpdatable = false;
                            this.tabGroup.SelectedTab = tpg;
                            msgOut = "E1";
                            break;
                        }
                    }
                    else
                    {
                        msg = XMsg.GetMsg("M005"); //그룹에 대하여 복용코드를 입력해 주세요.
                        this.tabGroup.SelectedTab = tpg;
                        isUpdatable = false;
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
                    }
                }

            }
            ///////////////////////////////////////////////////////////////////////////////////
            if (isUpdatable == false)
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

            #region 持参薬有効チェック
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

                            OCS0103U12IsUpdateCheckSelectArgs selectArgs1 = new OCS0103U12IsUpdateCheckSelectArgs();
                            selectArgs1.Pkocs2003 = this.grdOrder.GetItemString(i, "pkocskey");
                            OCS0103U12IsUpdateCheckSelectResult result =
                                CloudService.Instance
                                    .Submit<OCS0103U12IsUpdateCheckSelectResult, OCS0103U12IsUpdateCheckSelectArgs>(selectArgs1);

                            double a_total_suryang = -1;
                            //DataTable dt = Service.ExecuteDataTable(cmd, bind);
                            //if (dt.Rows.Count > 0)
                            if (result.SelectInfo.Count > 0)
                            {
                                //switch (dt.Rows[0]["dv_time"].ToString())
                                switch (result.SelectInfo[0].DvTime)
                                {
                                    case "*":
                                        //a_total_suryang = double.Parse(dt.Rows[0]["suryang"].ToString()) * int.Parse(dt.Rows[0]["dv"].ToString()) * int.Parse(dt.Rows[0]["nalsu"].ToString());
                                        a_total_suryang = double.Parse(result.SelectInfo[0].Suryang) * int.Parse(result.SelectInfo[0].Dv) * int.Parse(result.SelectInfo[0].Nalsu);
                                        break;
                                    case "/":
                                        //a_total_suryang = double.Parse(dt.Rows[0]["suryang"].ToString()) * int.Parse(dt.Rows[0]["nalsu"].ToString());
                                        a_total_suryang = double.Parse(result.SelectInfo[0].Suryang) * int.Parse(result.SelectInfo[0].Nalsu);
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

                            OCS0103U12IsUpdateCheckSelectArgs selectArgs2 = new OCS0103U12IsUpdateCheckSelectArgs();
                            selectArgs2.Pkocs2003 = this.grdOrder.GetItemString(i, "pkocskey");
                            OCS0103U12IsUpdateCheckSelectResult result =
                                CloudService.Instance
                                    .Submit<OCS0103U12IsUpdateCheckSelectResult, OCS0103U12IsUpdateCheckSelectArgs>(selectArgs2);

                            double a_total_suryang = -1;
                            //DataTable dt = Service.ExecuteDataTable(cmd, bind);
                            //if (dt.Rows.Count > 0)
                            if (result.SelectInfo.Count > 0)
                            {
                                //switch (dt.Rows[0]["dv_time"].ToString())
                                switch (result.SelectInfo[0].DvTime)
                                {
                                    case "*":
                                        //a_total_suryang = double.Parse(dt.Rows[0]["suryang"].ToString()) * int.Parse(dt.Rows[0]["dv"].ToString()) * int.Parse(dt.Rows[0]["nalsu"].ToString());
                                        a_total_suryang = double.Parse(result.SelectInfo[0].Suryang) * int.Parse(result.SelectInfo[0].Dv) * int.Parse(result.SelectInfo[0].Nalsu);
                                        break;
                                    case "/":
                                        //a_total_suryang = double.Parse(dt.Rows[0]["suryang"].ToString()) * int.Parse(dt.Rows[0]["nalsu"].ToString());
                                        a_total_suryang = double.Parse(result.SelectInfo[0].Suryang) * int.Parse(result.SelectInfo[0].Nalsu);
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

            //    bind_bgt.Add("f_bunho", this.mPatientInfo.GetPatientInfo["bunho"].ToString());
            //    bind_bgt.Add("f_pkocs1024", pkocs1024);
            //    bind_bgt.Add("f_suryang", ht[pkocs1024].ToString());
            //    bind_bgt.Add("f_dv", "1");
            //    bind_bgt.Add("f_dv_time", "*");
            //    bind_bgt.Add("f_nalsu", "1");

            //    insert_yn = Service.ExecuteScalar(cmd_bgt, bind_bgt).ToString();

            //    if (insert_yn == "N")
            //    {
            //        MessageBox.Show("現在の持参薬数量が足りません。ご確認ください。", "確認");
            //        return false;
            //    }
            //}

            List<OCS0103U12IsUpdateCheckInsertInfo> dtList = new List<OCS0103U12IsUpdateCheckInsertInfo>();
            foreach (string pkocs1024 in ht.Keys)
            {
                OCS0103U12IsUpdateCheckInsertInfo info = new OCS0103U12IsUpdateCheckInsertInfo();
                info.Bunho = this.mPatientInfo.GetPatientInfo["bunho"].ToString();
                info.Dv = "1";
                info.DvTime = "*";
                info.Nalsu = "1";
                info.Pkocs1024 = pkocs1024;
                info.Suryang = ht[pkocs1024].ToString();
                dtList.Add(info);
            }
            if (dtList.Count > 0)
            {
                OCS0103U12IsUpdateCheckInsertArgs args = new OCS0103U12IsUpdateCheckInsertArgs();
                args.InsertInfo = dtList;
                UpdateResult resultInsert = CloudService.Instance.Submit<UpdateResult, OCS0103U12IsUpdateCheckInsertArgs>(args);
                if (resultInsert == null || resultInsert.Result == false)
                {
                    MessageBox.Show(Resources.XMsg_00001, Resources.XMsg_000002);
                    return false;
                }
            }


            #endregion

            return isUpdatable;
        }

        #endregion

        #region Mix Group 데이타 Image Display (DiaplayMixGroup)
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
                //for (int i = 0; i < aGrd.RowCount; i++) aGrd[i + aGrd.HeaderHeights.Count, 0].Image = null;

                for (int i = 0; i < aGrd.DisplayRowCount; i++)
                {
                    //if (this.grdOrder.IsVisibleRow(i))
                    aGrd[i + aGrd.HeaderHeights.Count, 2].Image = null;
                }

                for (int i = 0; i < aGrd.DisplayRowCount; i++)
                {

                    //if (!this.grdOrder.IsVisibleRow(i)) continue;

                    if (aGrd.GetItemString(i, "dc_check") == "Y") continue;

                    // 이미 이미지 세팅이 안된건에 한해서 작업수행
                    //if (!TypeCheck.IsNull(aGrd.GetItemValue(i, "mix_group")) && aGrd[i + aGrd.HeaderHeights.Count, 0].Image == null)
                    if (!TypeCheck.IsNull(aGrd.GetItemValue(i, "mix_group")) && aGrd[i + aGrd.HeaderHeights.Count, 2].Image == null)
                    {
                        //이미수행한건 빼는로직이 있어야함..
                        int count = 0;
                        for (int j = i; j < aGrd.DisplayRowCount; j++)
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
                                    //aGrd[j + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[imageCnt];
                                    //aGrd[i + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[imageCnt];

                                    //if (!this.grdOrder.IsVisibleRow(j)) continue;
                                    aGrd[j + aGrd.HeaderHeights.Count, 2].Image = this.imageListMixGroup.Images[imageCnt];

                                    //if (!this.grdOrder.IsVisibleRow(i)) continue;
                                    aGrd[i + aGrd.HeaderHeights.Count, 2].Image = this.imageListMixGroup.Images[imageCnt];
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
        #endregion

        #region 동일 Mix Group 관련 데이터 셋팅

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
                    //insert by jc [空白を同じグループで認識するのを防ぐため空白は対象外とする。] START
                    (mix_group != "" || aGrid.GetItemString(i, "mix_group").Trim() != "") &&
                    //insert by jc [空白を同じグループで認識するのを防ぐため空白は対象外とする。] END
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

                            case "home_care_yn":

                                if (aValue.ToString() == "Y")
                                {
                                    //aGrid.SetItemValue(i, "jundal_part", "HOM");
                                    //if (aGrid.LayoutTable.Columns.Contains("jundal_part_name"))
                                    //    aGrid.SetItemValue(i, "jundal_part_name", "HOM");
                                }
                                else
                                {
                                    //aGrid.SetItemValue(i, "nalsu", 1);
                                    // 왜 날수를 1로 만들까....
                                    this.mOrderBiz.SetOrderGubunDefaultInfo("O", aGrid, i, aGrid.GetItemString(i, "order_gubun").Trim().PadRight(2).Substring(1, 1), this.cbxWonyoiOrderYN.GetDataValue(), "");
                                }
                                break;

                        }

                        //횟수 및 용법이 변경되는 경우 불균등 dv 수량을 Reset한다.
                        if (aColName == "dv" || aColName == "bogyong_code")
                        {
                            aGrid.SetItemValue(i, "dv_1", "");
                            aGrid.SetItemValue(i, "dv_2", "");
                            aGrid.SetItemValue(i, "dv_3", "");
                            aGrid.SetItemValue(i, "dv_4", "");
                        }
                    }

                }
            }
        }

        #endregion

        #region 그리드의 MAX Mix Group 가져오기

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

        #endregion

        #region Mix 관련 데이터

        private void ReGroupingMix(int aStartRow, int aEndRow, bool aIsReCalMix)
        {
            this.mHangmogInfo.SetAlignMixGroup(this.grdOrder, aStartRow, aEndRow, aIsReCalMix);

            this.DisplayMixGroup(this.grdOrder);
        }

        #endregion

        #region N 데이 주사 오더 관련 Mix

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

        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        #region 오더 그리드 신규 로우 생성

        private void OrderGridCreateNewRow(int aRowNumber)
        {
            this.grdOrder.InsertRow(aRowNumber);

            // 그룹 기준 셋팅
            this.GridInitValueSetting(this.grdOrder, this.grdOrder.CurrentRowNumber);
        }

        #endregion

        #region 그리드 신규 로우 초기값 셋팅

        private void GridInitValueSetting(XEditGrid aGrid, int aRowNumber)
        {
            string temp = "";

            if (tabGroup.SelectedTab == null)
            {
                return;
            }
            Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            // 그룹시리얼 셋팅
            if (groupInfo.Contains("group_ser"))
                aGrid.SetItemValue(aRowNumber, "group_ser", groupInfo["group_ser"].ToString());

            // 복용코드
            if (groupInfo.Contains("jusa"))
                aGrid.SetItemValue(aRowNumber, "jusa", groupInfo["jusa"].ToString());

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
            //this.mOrderBiz.LoadColumnCodeName("code", "INPUT_TAB", INPUTTAB, ref temp);

            //tungtx
            OCS0103U12LoadColumnNameArgs args = new OCS0103U12LoadColumnNameArgs();
            LoadColumnCodeNameInfo info = new LoadColumnCodeNameInfo();
            info.ColName = "code";
            info.Arg1 = "INPUT_TAB";
            info.Arg2 = INPUTTAB;
            args.Code = info;
            OCS0103U12LoadColumnNameResult result =
                CloudService.Instance.Submit<OCS0103U12LoadColumnNameResult, OCS0103U12LoadColumnNameArgs>(args);
            if (result != null && !String.IsNullOrEmpty(result.CodeName))
            {
                temp = result.CodeName;
            }
            aGrid.SetItemValue(aRowNumber, "input_tab_name", temp);


            aGrid.SetItemValue(aRowNumber, "input_part", this.mInputPart);
            aGrid.SetItemValue(aRowNumber, "input_gubun", this.mInputGubun);
            aGrid.SetItemValue(aRowNumber, "input_gubun_name", this.mInputGubunName);
            aGrid.SetItemValue(aRowNumber, "order_date", mOrderDate);

            // 진료정보 ( 오더일자, 진료과, 의사 )
            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder && this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                //// 입력구분
                //aGrid.SetItemValue(aRowNumber, "input_id", UserInfo.UserID);

                //aGrid.SetItemValue(aRowNumber, "input_doctor", UserInfo.DoctorID);
                //aGrid.SetItemValue(aRowNumber, "input_gwa", UserInfo.Gwa);

                if (UserInfo.UserGubun == UserType.Doctor)
                {
                    aGrid.SetItemValue(aRowNumber, "input_doctor", UserInfo.DoctorID);
                    aGrid.SetItemValue(aRowNumber, "input_gwa", UserInfo.Gwa);
                }
                else if (UserInfo.Gwa == "CK")
                {
                    aGrid.SetItemValue(aRowNumber, "input_doctor", this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString());
                    aGrid.SetItemValue(aRowNumber, "input_gwa", this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString().Substring(0, 2));
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



                aGrid.SetItemValue(aRowNumber, "input_id", UserInfo.UserID);


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

        #endregion

        #region 오더코드 그리드에 셋팅

        #region 보통의 경우 그리드 셋팅

        private void ApplyDefaultOrderInfo(MultiLayout aSourceLayout, XEditGrid aDestGrid, int aRowNumber, bool aIsCallCodeInput)
        {
            //string ordergubunname = "";  // 헤더를 붙인 오더구분을 넣는다.
            int currRow = aRowNumber;
            int startRow = aRowNumber;
            Hashtable groupInfo;

            if (aSourceLayout.RowCount <= 0) return;

            if (this.tabGroup.SelectedTab == null)
                HandleBtnListButtonClick(FunctionType.Process, out msgOut);

            groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

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

                // 긴급 관련
                if (this.mOrderBiz.IsAbleToCurrentEmergencyGroup(groupInfo, aSourceLayout.LayoutTable.Rows[i]) == false)
                {
                    return;
                }

                if (this.fbxJusa.GetDataValue() == "")
                {
                    this.fbxJusa.SetEditValue(aSourceLayout.GetItemString(i, "default_bogyong_code"));
                    this.fbxJusa.AcceptData();
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
                    this.grdOrder.LayoutTable.Rows[currRow]["jundal_table_out"] = aSourceLayout.GetItemString(i, "jundal_table_out");
                    this.grdOrder.LayoutTable.Rows[currRow]["jundal_table_inp"] = aSourceLayout.GetItemString(i, "jundal_table_inp");
                    this.grdOrder.LayoutTable.Rows[currRow]["jundal_part_out"] = aSourceLayout.GetItemString(i, "jundal_part_out");
                    this.grdOrder.LayoutTable.Rows[currRow]["jundal_part_inp"] = aSourceLayout.GetItemString(i, "jundal_part_inp");
                    this.grdOrder.LayoutTable.Rows[currRow]["move_part_out"] = aSourceLayout.GetItemString(i, "move_part");
                    this.grdOrder.LayoutTable.Rows[currRow]["move_part_inp"] = aSourceLayout.GetItemString(i, "move_part");

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

                this.grdOrder.DisplayData(true);

                if (this.tabGroup.SelectedTab.Tag != null)
                    this.ApplyGroupInfoToRow((Hashtable)this.tabGroup.SelectedTab.Tag, currRow);
            }

            this.mHangmogInfo.SetAlignMixGroup(this.grdOrder, startRow, currRow);

            this.grdOrder.DisplayData(true);

            this.SetOrderImage(this.grdOrder);

            //insert by jc [Focus設定] 2012/04/10
            this.grdOrder.SetFocusToItem(currRow, "hangmog_name");
            //注射だけをMIXする。2012/11/12
            if (this.grdOrder.GetItemString(currRow, "order_gubun_bas") == "B")
            {
                if (this.grdOrder.RowCount > 1)
                {
                    int selectedCNT = 0; //選択されたROWのカウンタ「MIXする前に選択されたROWが２以上じゃなければメソッドを実行しないように」

                    //オーダを選択した時の自動MIX処理
                    //todo: check again if incurred bug
                    if (mCbxAutoMixYN != null && mCbxAutoMixYN.GetDataValue().ToString() == "Y")
                    {
                        for (int i = 0; i < this.grdOrder.RowCount; i++)
                        {
                            if (this.grdOrder.GetItemString(currRow, "group_ser") == this.grdOrder.GetItemString(i, "group_ser"))
                            {
                                if (this.grdOrder.GetItemString(currRow, "jundal_part") == this.grdOrder.GetItemString(i, "jundal_part"))
                                {
                                    this.grdOrder.SelectRow(i);
                                    selectedCNT++;
                                }
                                else
                                {
                                    XMessageBox.Show(Properties.Resources.MSG1, Resources.MSG_Confirm);
                                    this.grdOrder.DeleteRow(currRow);
                                }
                            }
                        }


                        if (this.grdOrder.LayoutTable.Select("group_ser=" + (((Hashtable)this.tabGroup.SelectedTab.Tag)["group_ser"].ToString())).Length > 1 && selectedCNT > 1)
                        {
                            this.mHangmogInfo.SetMaxMixGroup(this.grdOrder);

                            this.DisplayMixGroup(this.grdOrder); // Mix Group 데이타 Image Display
                        }
                    }
                }
            }
        }

        #endregion

        #region 카피오더중 현재 그룹으로 합치지 않고 나누어 지는경우의 셋팅

        private void ApplyDivideOrderInfo(MultiLayout aSourceLayout, XEditGrid aDestGrid, int aRowNumber)
        {
            //string ordergubunname = "";  // 헤더를 붙인 오더구분을 넣는다.
            int currRow = aRowNumber;
            int startRow = aRowNumber;

            if (aSourceLayout.RowCount <= 0) return;

            // 먼저 넘어온 데이터에서 그룹정보만을 셋팅 한다.
            #region
            string aJusa = "";
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
                    if (dr["jusa"].ToString() != aJusa ||
                        dr["nalsu"].ToString() != aCurrNalsu ||
                        dr["emergency"].ToString() != aCurrEmergency ||
                        dr["wonyoi_order_yn"].ToString() != aCurrWonyoiOrderYn ||
                        dr["group_ser"].ToString() != aCurrGroupSer)
                    {
                        groupInfo = new Hashtable();

                        groupInfo.Add("jusa", dr["jusa"].ToString());
                        groupInfo.Add("nalsu", dr["nalsu"].ToString());
                        groupInfo.Add("emergency", dr["emergency"].ToString());
                        groupInfo.Add("wonyoi_order_yn", dr["wonyoi_order_yn"].ToString());
                        groupInfo.Add("group_ser", dr["group_ser"].ToString());

                        groupInfoList.Add(groupInfo);

                        aJusa = dr["jusa"].ToString();
                        aCurrNalsu = dr["nalsu"].ToString();
                        aCurrEmergency = dr["emergency"].ToString();
                        aCurrWonyoiOrderYn = dr["wonyoi_order_yn"].ToString();
                        aCurrGroupSer = dr["group_ser"].ToString();
                    }
                }
                else
                {
                    if (dr["jusa"].ToString() != aJusa ||
                        dr["nalsu"].ToString() != aCurrNalsu ||
                        dr["emergency"].ToString() != aCurrEmergency ||
                        dr["wonyoi_order_yn"].ToString() != aCurrWonyoiOrderYn)
                    {
                        groupInfo = new Hashtable();

                        groupInfo.Add("jusa", dr["jusa"].ToString());
                        groupInfo.Add("nalsu", dr["nalsu"].ToString());
                        groupInfo.Add("emergency", dr["emergency"].ToString());
                        groupInfo.Add("wonyoi_order_yn", dr["wonyoi_order_yn"].ToString());

                        groupInfoList.Add(groupInfo);

                        aJusa = dr["jusa"].ToString();
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
                if (info.Contains("group_ser"))
                {
                    filter = "jusa='" + info["jusa"].ToString() + "' AND " +
                             "nalsu=" + info["nalsu"].ToString() + " AND " +
                             "emergency='" + info["emergency"].ToString() + "' AND " +
                             "wonyoi_order_yn='" + info["wonyoi_order_yn"].ToString() + "' AND " +
                             "group_ser=" + info["group_ser"].ToString();
                }
                else
                {
                    filter = "jusa='" + info["jusa"].ToString() + "' AND " +
                             "nalsu=" + info["nalsu"].ToString() + " AND " +
                             "emergency='" + info["emergency"].ToString() + "' AND " +
                             "wonyoi_order_yn='" + info["wonyoi_order_yn"].ToString() + "'";
                }

                DataRow[] rows = aSourceLayout.LayoutTable.Select(filter);

                // 커런트 그룹정보가 동일한지 여부
                //    - 커런트 그룹이 아직 복용코드 정보가 입력되지 않은 경우는 현재 그룹정보를 
                //      지금 그룹으로 변경해 버린다.
                //    - 그렇지 않은 경우는 새 그룹 생성

                if (this.fbxJusa.GetDataValue() == "" && this.mOrderFunc.IsEmptyGroup(this.grdOrder, (((Hashtable)this.tabGroup.SelectedTab.Tag)["group_ser"]).ToString()))
                {
                    // 그룹정보 맞추기
                    this.cboNalsu.SelectedValueChanged -= new EventHandler(cboNalsu_SelectedValueChanged);
                    this.cboNalsu.SetDataValue(info["nalsu"].ToString());
                    this.cboNalsu.SelectedValueChanged += new EventHandler(cboNalsu_SelectedValueChanged);
                    this.cbxEmergency.SetDataValue(info["emergency"].ToString());
                    this.cbxWonyoiOrderYN.SetDataValue(info["wonyoi_order_yn"].ToString());
                    this.fbxJusa.SetEditValue(info["jusa"].ToString());
                    this.fbxJusa.AcceptData();
                }

                //if (this.IsSameCurrentGroupInfo(info["jusa"].ToString(), info["nalsu"].ToString(), info["emergency"].ToString(), info["wonyoi_order_yn"].ToString()) == false)
                //{
                //    // 신규 그룹생성
                //    HandleBtnListButtonClick(FunctionType.Process, out msgOut);
                //    // 그룹정보 맞추기
                //    this.cboNalsu.SelectedValueChanged -= new EventHandler(cboNalsu_SelectedValueChanged);
                //    this.cboNalsu.SetDataValue(info["nalsu"].ToString());
                //    this.cboNalsu.SelectedValueChanged += new EventHandler(cboNalsu_SelectedValueChanged);
                //    this.cbxEmergency.SetDataValue(info["emergency"].ToString());
                //    this.cbxWonyoiOrderYN.SetDataValue(info["wonyoi_order_yn"].ToString());
                //    if (info["jusa"].ToString() != "")
                //    {
                //        this.fbxJusa.SetEditValue(info["jusa"].ToString());
                //        this.fbxJusa.AcceptData();
                //    }
                //}

                // 신규 그룹생성
                HandleBtnListButtonClick(FunctionType.Process, out msgOut);
                // 그룹정보 맞추기
                this.cboNalsu.SelectedValueChanged -= new EventHandler(cboNalsu_SelectedValueChanged);
                this.cboNalsu.SetDataValue(info["nalsu"].ToString());
                this.cboNalsu.SelectedValueChanged += new EventHandler(cboNalsu_SelectedValueChanged);
                this.cbxEmergency.SetDataValue(info["emergency"].ToString());
                this.cbxWonyoiOrderYN.SetDataValue(info["wonyoi_order_yn"].ToString());

                groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

                if (info["jusa"].ToString() != "")
                {
                    this.fbxJusa.SetEditValue(info["jusa"].ToString());
                    this.fbxJusa.AcceptData();
                }

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

                    // 긴급 관련
                    if (this.mOrderBiz.IsAbleToCurrentEmergencyGroup(groupInfo, aSourceLayout.LayoutTable.Rows[i]) == false)
                    {
                        return;
                    }

                    foreach (DataColumn cl in this.grdOrder.LayoutTable.Columns)
                    {
                        // 그룹정보내의 정보이면 그룹정보에서 가져가고
                        if (((Hashtable)this.tabGroup.SelectedTab.Tag).Contains(cl.ColumnName))
                        {
                            this.grdOrder.LayoutTable.Rows[currRow][cl.ColumnName] = ((Hashtable)this.tabGroup.SelectedTab.Tag)[cl.ColumnName].ToString();
                        }
                        // 아닌것들은 로우에서 가져간다.
                        else if (aSourceLayout.LayoutTable.Columns.Contains(cl.ColumnName))
                        {
                            this.grdOrder.LayoutTable.Rows[currRow][cl.ColumnName] = rows[i][cl.ColumnName];
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

                    this.grdOrder.DisplayData(true);

                    //if (this.tabGroup.SelectedTab.Tag != null)
                    //    this.ApplyGroupInfoToRow((Hashtable)this.tabGroup.SelectedTab.Tag, currRow);
                }

                this.mHangmogInfo.SetAlignMixGroup(this.grdOrder, startRow, currRow);

                this.grdOrder.DisplayData(true);

                this.SetOrderImage(this.grdOrder);

            }

            #endregion
        }

        #endregion

        #region 카피 오더의 경우 ( 카피, 셋트, Do 오더의 경우 )

        private void ApplyCopyOrderInfo(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aExcutiveMode)
        {
            bool isMerge = true;

            Hashtable groupInfo;
            int focusRow = -1;

            if (this.tabGroup.SelectedTab == null)
                HandleBtnListButtonClick(FunctionType.Process, out msgOut);

            groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.mInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IOEGUBUN;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder && this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                this.mHangmogInfo.Parameter.Bunho = this.mPatientInfo.GetPatientInfo["bunho"].ToString();
                this.mHangmogInfo.Parameter.NaewonKey = this.mPatientInfo.GetPatientInfo["naewon_key"].ToString();
                this.mHangmogInfo.Parameter.Gubun = this.mPatientInfo.GetPatientInfo["gubun"].ToString();
                this.mHangmogInfo.Parameter.Birth_Date = this.mPatientInfo.GetPatientInfo["birth"].ToString();
                this.mHangmogInfo.Parameter.Gwa = this.mPatientInfo.GetPatientInfo["gwa"].ToString();
                this.mHangmogInfo.Parameter.ApproveDoctor = this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString();
                this.mHangmogInfo.Parameter.Wonyoi_Order_Yn_Wonmu = this.cbxWonyoiOrderYN.GetDataValue();
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
                //if (this.mOrderMode == OrderVariables.OrderMode.CpOrder)
                //{
                //    for (int row = 0; row < layOrderData.RowCount; row++)
                //    {
                //        if (layOrderData.GetItemString(row, "nalsu") != "1")
                //            layOrderData.SetItemValue(row, "nalsu", "1");
                //    }
                //}

                // Set 오더 인경우는 jusa, 긴급, 원외 등의 값이 없는 경우는 현재 그룹에 맞추어 간다.
                if (aExcutiveMode == HangmogInfo.ExecutiveMode.YaksokCopy)
                {
                    for (int row = 0; row < layOrderData.RowCount; row++)
                    {
                        if (layOrderData.GetItemString(row, "jusa") == "" && groupInfo.Contains("jusa"))
                        {
                            layOrderData.SetItemValue(row, "jusa", groupInfo["jusa"]);
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
                #region 그룹정보 및 항목코드 셋팅

                //Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

                for (int i = 0; i < layOrderData.RowCount; i++)
                {
                    // 그룹정보 로드
                    // 그룹시리얼
                    if (groupInfo.Contains("group_ser"))
                    {
                        layOrderData.SetItemValue(i, "group_ser", groupInfo["group_ser"].ToString());
                    }
                    // 복용코드
                    if (groupInfo.Contains("jusa"))
                    {
                        layOrderData.SetItemValue(i, "jusa", groupInfo["jusa"].ToString());
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
                }

                #endregion
            }

            // 인서트 후 포커스 로우
            focusRow = this.grdOrder.RowCount - 1 + layOrderData.RowCount;

            if (isMerge)
                //this.ApplyDefaultOrderInfo(this.mHangmogInfo.GetHangmogInfo, this.grdOrder, -1);
                this.ApplyDefaultOrderInfo(layOrderData, this.grdOrder, this.grdOrder.CurrentRowNumber, false);
            else
                //this.ApplyDivideOrderInfo(this.mHangmogInfo.GetHangmogInfo, this.grdOrder, -1);
                this.ApplyDivideOrderInfo(layOrderData, this.grdOrder, this.grdOrder.CurrentRowNumber);

            // 이거 다 해놓고
            // 그룹이벤트를 다시 태워야 하네...
            this.tabGroup_SelectionChanged(this.tabGroup, new EventArgs());
            //this.DisplayOrderGridGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag);

            this.DisplayMixGroup(this.grdOrder);

            this.SetOrderImage(this.grdOrder);

            PostCallHelper.PostCall(new PostMethodInt(this.PostOrderInsert), focusRow);

        }

        #endregion

        #region 상용오더의 경우

        private void ApplySangOrderInfo(string aHangmogCode, int aApplyRow, bool aIsApplyCurrentRow)
        {
            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.mInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IOEGUBUN;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;
            this.mHangmogInfo.Parameter.Wonyoi_Order_Yn_Wonmu = this.cbxWonyoiOrderYN.GetDataValue();

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
            loadExtraInfo.LayoutItems.Add("jusa", DataType.String);
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
            if (groupInfo.Contains("jusa"))
            {
                loadExtraInfo.SetItemValue(0, "jusa", groupInfo["jusa"].ToString());
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

            this.ApplyDefaultOrderInfo(this.mHangmogInfo.GetHangmogInfo, this.grdOrder, aApplyRow, aIsApplyCurrentRow);

            // 이거 다 해놓고
            // 그룹이벤트를 다시 태워야 하네...
            //this.tabGroup_SelectionChanged(this.tabGroup, new EventArgs());
            this.DisplayOrderGridGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag);

            ////insert by jc [自動MIX処理] 2012/03/12
            ////this.grdOrder.SetFocusToItem(aApplyRow, "hangmog_code");

            //if (this.grdOrder.RowCount > 1)
            //{
            //    for (int i = 0; i < this.grdOrder.RowCount; i++)
            //    {
            //        if (this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jundal_part") == this.grdOrder.GetItemString(i, "jundal_part"))
            //            this.grdOrder.SelectRow(i);
            //    }

            //    if (this.grdOrder.LayoutTable.Select("group_ser=" + (((Hashtable)this.tabGroup.SelectedTab.Tag)["group_ser"].ToString())).Length > 1)
            //    {
            //        this.mHangmogInfo.SetMaxMixGroup(this.grdOrder);

            //        this.DiaplayMixGroup(this.grdOrder); // Mix Group 데이타 Image Display
            //    }
            //}

            this.DisplayMixGroup(this.grdOrder);

            this.SetOrderImage(this.grdOrder);
        }

        #endregion

        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        #region Status BAR 관련 메소드

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

        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        #region 반납 지시 관련 컬럼 보이기

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

        #endregion

        #endregion

        #region [ 데이터 로드 ]

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
            //this.grdOrder.SetBindVarValue("memb", aMemb);
            //this.grdOrder.SetBindVarValue("yaksok_code", aYaksokCode);
            //this.grdOrder.SetBindVarValue("fk_in_out_key", aFkInOutKey);
            //this.grdOrder.SetBindVarValue("input_tab", aInputTab);
            //this.grdOrder.SetBindVarValue("input_gubun", aInputGubun);

            //tungtx
            this.grdOrder.ExecuteQuery = LoadDataGrdOrder;

            this.grdOrder.QueryLayout(true);
        }

        private IList<object[]> LoadDataGrdOrder(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            OCS0103U13GrdOrderListArgs args = new OCS0103U13GrdOrderListArgs();
            args.Memb = this.mMemb;
            args.YaksokCode = this.mYaksokCode;
            args.FkInOutKey = this.mPkInOutKey;
            args.InputGubun = this.mInputGubun;
            args.InputTab = INPUTTAB;
            //args.FkInOutKey = "001";
            //args.InputTab = "04";
            //args.YaksokCode = "04/10010/1/204";
            //args.OrderMode = "1";
            //args.InputGubun = "1";
            //args.Memb = "10010";
            OCS0103U13GrdOrderListResult result =
                CloudService.Instance.Submit<OCS0103U13GrdOrderListResult, OCS0103U13GrdOrderListArgs>(args);
            if (result != null)
            {
                List<OCS0103U13GrdOrderListInfo> grdList = result.GrdOrderListItem;
                if (grdList != null && grdList.Count > 0)
                {
                    foreach (OCS0103U13GrdOrderListInfo info in grdList)
                    {
                        dataList.Add(new object[]
                        {
                            info.PkOrdKey,
                            info.Memb,
                            info.YaksokCode,
                            info.Bunho,
                            info.IoGubun1,
                            info.OrderDate,
                            info.OrderTime,
                            info.Gwa,
                            info.Doctor,
                            info.Resident,
                            info.NaewonType,
                            info.InputId,
                            info.InputPart,
                            info.InputGwa,
                            info.InputDoctor,
                            info.InputGubun,
                            info.InputGubunName,
                            info.GroupSer,
                            info.InputTab,
                            info.InputTabName,
                            info.OrderGubun,
                            info.OrderGubunName,
                            info.NdayYn1,
                            info.Seq,
                            info.SlipCode,
                            info.HangmogCode,
                            info.HangmogName,
                            info.SpecimenCode,
                            info.SpecimenName,
                            info.Suryang,
                            info.SunabSuryang,
                            info.SubulSuryang,
                            info.OrdDanui,
                            info.OrdDanuiName,
                            info.DvTime,
                            info.Dv,
                            info.Dv1,
                            info.Dv2,
                            info.Dv3,
                            info.Dv4,
                            info.Nalsu,
                            info.SunabNalsu,
                            info.Jusa,
                            info.JusaName,
                            info.JusaSpdGubun,
                            info.BogyongCode,
                            info.BogyongName,
                            info.Emergency,
                            info.JaeryoJundalYn,
                            info.JundalTable,
                            info.JundalPart,
                            info.MovePart,
                            info.PortableYn,
                            info.PowderYn,
                            info.HubalChangeYn,
                            info.Phamacy,
                            info.DrgPackYn,
                            info.Muhyo,
                            info.PrnYn,
                            info.ToiwonDrgYn,
                            info.PrnNurse,
                            info.AppendYn,
                            info.OrderRemark,
                            info.NurseRemark,
                            info.MixGroup,
                            info.Amt,
                            info.Pay,
                            info.WonyoiOrderYn,
                            info.DangilGumsaOrderYn,
                            info.DangilGumsaResultYn,
                            info.BomOccurYn,
                            info.BomSourceKey,
                            info.DisplayYn,
                            info.SunabYn,
                            info.SunabDate,
                            info.SunabTime,
                            info.HopeDate,
                            info.HopeTime,
                            info.NurseConfirmUser,
                            info.NurseConfirmDate,
                            info.NurseConfirmTime,
                            info.NursePickupUser,
                            info.NursePickupDate,
                            info.NursePickupTime,
                            info.NurseHoldUser,
                            info.NurseHoldDate,
                            info.NurseHoldTime,
                            info.ReserDate,
                            info.ReserTime,
                            info.JubsuDate,
                            info.JubsuTime,
                            info.ActingDate,
                            info.ActingTime,
                            info.ActingDay,
                            info.ResultDate,
                            info.DcGubun,
                            info.DcYn,
                            info.BannabYn,
                            info.BannabConfirm,
                            info.SourceOrdKey,
                            info.OcsFlag,
                            info.SgCode,
                            info.SgYmd,
                            info.IoGubun2,
                            info.AfterActYn,
                            info.BichiYn,
                            info.DrgBunho,
                            info.SubSusul,
                            info.PrintYn,
                            info.Chisik,
                            info.TelYn,
                            info.OrderGubunBas,
                            info.InputControl,
                            info.SugaYn,
                            info.JaeryoYn,
                            info.WonyoiCheck,
                            info.EmergencyCheck,
                            info.SpecimenCheck,
                            info.PortableCheck,
                            info.BulyongCheck,
                            info.SunabCheck2,
                            info.DcCheck,
                            info.DcGubunCheck,
                            info.ConfirmCheck,
                            info.ReserYnCheck,
                            info.ChisikCheck,
                            info.NdayYn2,
                            info.DefaultJaeryoJundalYn,
                            info.DefaultWonyoiOrderYn,
                            info.SpecificComments,
                            info.SpecificCommentName,
                            info.SpecificCommentSysId,
                            info.SpecificCommentPgmId,
                            info.OrderByKey
                        });
                    }
                }
            }
            return dataList;
        }

        #endregion

        #region [ =======================================  그룹 탭 관련 ]

        #region 그룹탭 생성 관련

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

        /// <summary>
        /// 신규그룹페이지 생성하기
        /// </summary>
        private void MakeNewOrderGroup(bool aIsShowFindDlg)
        {
            if (this.IsExistEmptyGroup()) return;

            IHIS.X.Magic.Controls.TabPage tpg = new IHIS.X.Magic.Controls.TabPage();

            //int groupSer = (this.mHangmogInfo.GetMaxGroupSer(this.grdOrder) + 1);

            //2014/06/30 inserted by yjc
            int groupSer = 1;

            if (mPatientInfo.GetPatientInfo != null)
            {
                if (this.IOEGUBUN == "O")
                    //groupSer = (this.mHangmogInfo.GetMaxGroupSer(this.grdOrder) + 1);
                    groupSer = int.Parse(this.mHangmogInfo.GetNextGroupSer(INPUTTAB, this.mPatientInfo.GetPatientInfo["bunho"].ToString(), mPatientInfo.GetPatientInfo["naewon_key"].ToString(), "OCS1003"));
                else
                    groupSer = int.Parse(this.mHangmogInfo.GetNextGroupSer(INPUTTAB, this.mPatientInfo.GetPatientInfo["bunho"].ToString(), mPatientInfo.GetPatientInfo["naewon_key"].ToString(), "OCS2003"));
            }
            if (groupSer == 1 || groupSer == 400)
            {
                groupSer = 301;
            }

            tpg.Title = Resources.groupSer1 + groupSer.ToString() + Resources.groupSer2;
            Hashtable groupInfo = new Hashtable();

            groupInfo.Add("group_ser", groupSer);
            groupInfo.Add("group_name", tpg.Title);
            groupInfo.Add("jusa", "");
            groupInfo.Add("jusa_name", "");
            groupInfo.Add("emergency", "N");
            groupInfo.Add("nalsu", "1");
            groupInfo.Add("wonyoi_order_yn", "N");

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
            this.cboNalsu.SetEditValue("1"); // 날수는 1로 기본셋팅
            this.cboNalsu.AcceptData();

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
                HandleBtnListButtonClick(FunctionType.Process, out msgOut);
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
                bool isExist = false;

                foreach (DataRow dr in this.grdOrder.LayoutTable.Rows)
                {
                    // 의사인경우는 넘어온 input_gubun 과 일치하는 입력구분만 보여주고
                    // 의사 이외의 경우는 의사 오더 및 자신의 입력구분에 해당하는 오더를 전부 보여준다.
                    //if ((this.mInputGubun.Substring(0, 1) == "D" && dr["input_gubun"].ToString() == this.mInputGubun) ||
                    //     (this.mInputGubun.Substring(0, 1) != "D" && (dr["input_gubun"].ToString() == this.mInputGubun || dr["input_gubun"].ToString().Substring(0, 1) == "D")))

                    // input_gubunに合うgroup_serタブを作る
                    //if (dr["input_gubun"].ToString() == this.mInputGubun)
                    //{
                    if ((UserInfo.UserGubun == UserType.Doctor && dr["input_gubun"].ToString() == this.mInputGubun)
                       || (UserInfo.UserGubun != UserType.Doctor && UserInfo.Gwa != "CK" && (dr["input_gubun"].ToString() == this.mInputGubun || dr["input_gubun"].ToString().Substring(0, 1) == "D"))
                       || (UserInfo.Gwa == "CK" && (dr["input_gubun"].ToString().Substring(0, 1) == "D" || dr["input_gubun"].ToString() == UserInfo.Gwa))
                      )
                    {

                        if (curGroupSer != dr["group_ser"].ToString())
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

                                ldTab.Title = dr["group_ser"].ToString() + Resources.XMsg_000003 + dr["jusa_name"].ToString();
                                ldTab.ImageList = this.ImageList;
                                ldTab.ImageIndex = 1;

                                groupInfo = new Hashtable();
                                groupInfo.Add("group_ser", dr["group_ser"]);
                                groupInfo.Add("group_name", dr["group_ser"].ToString() + Resources.XMsg_000003 + dr["jusa_name"].ToString());
                                groupInfo.Add("jusa", dr["jusa"].ToString());
                                groupInfo.Add("jusa_name", dr["jusa_name"].ToString());
                                groupInfo.Add("emergency", dr["emergency"].ToString());
                                groupInfo.Add("nalsu", dr["nalsu"].ToString());
                                groupInfo.Add("wonyoi_order_yn", dr["wonyoi_order_yn"].ToString());

                                ldTab.Tag = groupInfo;

                                this.tabGroup.TabPages.Add(ldTab);

                                curGroupSer = dr["group_ser"].ToString();
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
                    HandleBtnListButtonClick(FunctionType.Process, out msgOut);
                }
            }
        }

        #endregion

        #region 그룹탭 관련 적용 모듈

        private void ApplyGroupInfo(Hashtable aExistGroupInfo, string aType, string aValue1, string aValue2, string aValue3, string aValue4)
        {
            string jusa = "";
            string jusaName = "";
            string nalsu = "";
            string emergency = "";
            string wonyoi_order_yn = "";

            #region 기존 데이터 셋팅

            if (aExistGroupInfo.Contains("jusa"))
            {
                jusa = aExistGroupInfo["jusa"].ToString();
            }
            if (aExistGroupInfo.Contains("jusa_name"))
            {
                jusaName = aExistGroupInfo["jusa_name"].ToString();
            }
            if (aExistGroupInfo.Contains("emergency"))
            {
                emergency = aExistGroupInfo["emergency"].ToString();
            }
            if (aExistGroupInfo.Contains("nalsu"))
            {
                nalsu = aExistGroupInfo["nalsu"].ToString();
            }
            if (aExistGroupInfo.Contains("wonyoi_order_yn"))
            {
                wonyoi_order_yn = aExistGroupInfo["wonyoi_order_yn"].ToString();
            }

            #endregion

            #region 변경에 따른 데이터 셋팅

            switch (aType)
            {
                case "jusa":

                    jusa = aValue1;
                    jusaName = aValue2;

                    break;

                case "emergency":

                    emergency = aValue1;

                    break;

                case "nalsu":

                    nalsu = aValue1;

                    break;

                case "wonyoi_order_yn":

                    wonyoi_order_yn = aValue1;

                    break;
            }

            #endregion

            this.ApplyGroupInfo(jusa, jusaName, nalsu, emergency, wonyoi_order_yn);
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
        private void ApplyGroupInfo(string aJusa, string aJusaName
                                   , string aNalsu, string aEmergency, string aWonyoiOrderYN)
        {
            // 탭인포에 적용
            if (this.tabGroup.SelectedTab == null) return;
            Hashtable tabInfo = this.tabGroup.SelectedTab.Tag as Hashtable;
            string nalsu = aNalsu;

            this.tabGroup.SelectedTab.Title = Resources.groupSer1 + tabInfo["group_ser"].ToString() + Resources.groupSer2;

            if (aJusa != "")
            {
                this.tabGroup.SelectedTab.Title += ":" + aJusaName;
            }

            if (tabInfo.Contains("jusa"))
                tabInfo.Remove("jusa");
            tabInfo.Add("jusa", aJusa);

            if (tabInfo.Contains("jusa_name"))
                tabInfo.Remove("jusa_name");
            tabInfo.Add("jusa_name", aJusaName);

            if (tabInfo.Contains("emergency"))
                tabInfo.Remove("emergency");
            tabInfo.Add("emergency", aEmergency);

            if (tabInfo.Contains("nalsu"))
                tabInfo.Remove("nalsu");
            tabInfo.Add("nalsu", aNalsu);

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
                    // 주사방법을 기준으로 변경 가능한것만 그룹정보 업데이트 한다.
                    if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                        this.mOrderMode == OrderVariables.OrderMode.CpSetOrder ||
                        this.mHangmogInfo.IsOrderDataChagnedEnabled(this.IOEGUBUN, this.grdOrder, i, "jusa", OrderVariables.CheckMode.DataUpdate, OrderVariables.ErrorDisplayMode.NoDisplay))
                    {
                        // 복용코드
                        if (this.grdOrder.GetItemString(i, "jusa") != aJusa)
                        {
                            this.grdOrder.SetItemValue(i, "jusa", aJusa);
                        }

                        // 복용법 명칭
                        if (this.grdOrder.GetItemString(i, "jusa_name") != aJusaName)
                        {
                            this.grdOrder.SetItemValue(i, "jusa_name", aJusaName);
                        }

                        if (this.grdOrder.GetItemString(i, "nalsu") != aNalsu)
                        {
                            this.grdOrder.SetItemValue(i, "nalsu", aNalsu);


                        }

                        // 날수 셋팅에 따른 Nday YN 설정
                        if (TypeCheck.IsInt(aNalsu) && int.Parse(aNalsu) > 1)
                        {
                            this.grdOrder.SetItemValue(i, "nday_yn", "Y");
                        }
                        else
                        {
                            this.grdOrder.SetItemValue(i, "nday_yn", "N");
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

                        //注射オーダの場合、院外処方の際には予約（希望日）が入れられないようする。
                        if (aWonyoiOrderYN == "Y" && this.grdOrder.GetItemString(i, "hope_date") != "")
                        {
                            this.grdOrder.SetItemValue(i, "hope_date", "");
                        }

                    }
                }
            }

            this.MakePreviewStatus();
        }

        private void ApplyGroupInfoToRow(Hashtable aExistGroupInfo, int aSetRowNumber)
        {
            string jusa = "";
            string jusaName = "";
            string nalsu = "";
            string emergency = "N";
            string wonyoi_order_yn = "N";

            if (aExistGroupInfo.Contains("jusa"))
            {
                jusa = aExistGroupInfo["jusa"].ToString();
            }
            if (aExistGroupInfo.Contains("jusa_name"))
            {
                jusaName = aExistGroupInfo["jusa_name"].ToString();
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

            // 접수하기 전의 오더만 가능
            // 주사방법을 기준으로 변경 가능한것만 그룹정보 업데이트 한다.
            if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                this.mOrderMode == OrderVariables.OrderMode.CpSetOrder ||
                this.mHangmogInfo.IsOrderDataChagnedEnabled(this.IOEGUBUN, this.grdOrder, aSetRowNumber, "jusa", OrderVariables.CheckMode.DataUpdate, OrderVariables.ErrorDisplayMode.NoDisplay))
            {
                // 복용코드
                if (this.grdOrder.GetItemString(aSetRowNumber, "jusa") != jusa)
                {
                    this.grdOrder.SetItemValue(aSetRowNumber, "jusa", jusa);
                }

                // 복용법 명칭
                if (this.grdOrder.GetItemString(aSetRowNumber, "jusa_name") != jusaName)
                {
                    this.grdOrder.SetItemValue(aSetRowNumber, "jusa_name", jusaName);
                }

                // 긴급
                if (this.grdOrder.GetItemString(aSetRowNumber, "emergency") != emergency)
                {
                    this.grdOrder.SetItemValue(aSetRowNumber, "emergency", emergency);
                }

                // 날수 
                if (this.grdOrder.GetItemString(aSetRowNumber, "nalsu") != nalsu)
                {
                    this.grdOrder.SetItemValue(aSetRowNumber, "nalsu", nalsu);


                }

                // 날수 셋팅에 따른 Nday YN 설정
                if (TypeCheck.IsInt(nalsu) && int.Parse(nalsu) > 1)
                {
                    this.grdOrder.SetItemValue(aSetRowNumber, "nday_yn", "Y");
                }
                else
                {
                    this.grdOrder.SetItemValue(aSetRowNumber, "nday_yn", "N");
                }

                // 원외여부
                if (this.grdOrder.GetItemString(aSetRowNumber, "wonyoi_order_yn") != wonyoi_order_yn)
                {
                    this.grdOrder.SetItemValue(aSetRowNumber, "wonyoi_order_yn", wonyoi_order_yn);
                }

            }

            this.MakePreviewStatus();
        }

        #endregion

        #region 그룹탭 선택시 그룹관련 정보들 셋팅

        /// <summary>
        /// 그룹탭 선택시 그룹관련 정보들 셋팅
        /// </summary>
        /// <param name="aGroupInfo">그룹정보</param>
        private void SetGroupControl(Hashtable aGroupInfo)
        {
            // 복용코드
            this.fbxJusa.SetDataValue(aGroupInfo["jusa"].ToString());
            // 복용명칭
            this.dbxJusaName.SetDataValue(aGroupInfo["jusa_name"].ToString());
            // 날수
            this.cboNalsu.SelectedValueChanged -= new EventHandler(cboNalsu_SelectedValueChanged);
            this.cboNalsu.SetDataValue(aGroupInfo["nalsu"].ToString());
            this.cboNalsu.SelectedValueChanged += new EventHandler(cboNalsu_SelectedValueChanged);
            // 긴급여부
            this.cbxEmergency.CheckedChanged -= new EventHandler(cbxEmergency_CheckedChanged);
            this.cbxEmergency.SetDataValue(aGroupInfo["emergency"].ToString());
            this.cbxEmergency.CheckedChanged += new EventHandler(cbxEmergency_CheckedChanged);
            // 원외오더
            this.cbxWonyoiOrderYN.CheckedChanged -= new EventHandler(cbxWonyoiOrderYN_CheckedChanged);
            this.cbxWonyoiOrderYN.SetDataValue(aGroupInfo["wonyoi_order_yn"].ToString());
            this.cbxWonyoiOrderYN.CheckedChanged += new EventHandler(cbxWonyoiOrderYN_CheckedChanged);
        }

        #endregion

        #region 그룹내 오더 상태에 따른 그룹 정보 프로텍트

        /// <summary>
        /// 그룹정보 프로텍트 여부 
        /// </summary>
        /// <param name="aGroupSer">그룹시리얼</param>
        private void ProtectGroupControl(string aGroupSer)
        {
            int cnt = 0;

            //if (this.mCallerScreenID != "OCS0301U00" )
            if (this.mCallerScreenID == "OCS1003P01" || this.mCallerScreenID == "OCS2003P01")
            {
                //insert by jc [グループ内にCHILDオーダがACTINGされたオーダがあるのかチェックする。あればグループ情報変更不可にするため]
                //SingleLayout layChildOrder = new SingleLayout();
                //layChildOrder.LayoutItems.Add("cnt");
                //layChildOrder.InitializeLifetimeService();
                //                layChildOrder.QuerySQL = @"SELECT COUNT(*)
                //   			                             FROM OCS2003 B, (SELECT A.PKOCS2003
                //  				      	                                    FROM OCS2003 A
                //						                                   WHERE A.BUNHO           = :f_bunho
                //                                                             AND A.HOSP_CODE       = '" + EnvironInfo.HospCode + @"'
                //						                                     AND A.ORDER_DATE      = :f_order_date
                //						                                     AND SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('B', 'C', 'D')
                //						                                     AND NVL(A.DC_YN, 'N') = 'N'
                //						                                     AND A.NDAY_YN         = 'Y'
                //						                                     AND A.NDAY_OCCUR_YN   = 'Y') P
                //				                        WHERE B.HOSP_CODE = '" + EnvironInfo.HospCode + @"'
                //                                          AND B.SORT_FKOCSKEY = P.PKOCS2003 
                //				                          AND B.ACTING_DATE IS NOT NULL
                //                                          AND B.GROUP_SER = :f_group_ser";


                //layChildOrder.SetBindVarValue("f_bunho", this.mPatientInfo.GetPatientInfo["bunho"].ToString());
                //layChildOrder.SetBindVarValue("f_order_date", mOrderDate);
                //layChildOrder.SetBindVarValue("f_group_ser", aGroupSer);

                //layChildOrder.QueryLayout();

                //tungtx
                OCS0103U12ProtectGroupControlArgs args = new OCS0103U12ProtectGroupControlArgs();
                args.Bunho = this.mPatientInfo.GetPatientInfo["bunho"].ToString();
                args.GroupSer = aGroupSer;
                args.OrderDate = mOrderDate;
                OCS0103U12ProtectGroupControlResult result =
                    CloudService.Instance.Submit<OCS0103U12ProtectGroupControlResult, OCS0103U12ProtectGroupControlArgs>
                        (args);

                //cnt = int.Parse(layChildOrder.GetItemValue("cnt").ToString());
                if (result != null && !String.IsNullOrEmpty(result.Cnt))
                {
                    cnt = int.Parse(result.Cnt);
                }
            }
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
                // 의사가 아니ㅣㄴ사람이 로그인한 경우 의사오더가 존재하면 전부 protect 
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

                //if (cnt > 0 || dr[i].RowState != DataRowState.Added && dr[i]["ocs_flag"].ToString() != "0" && dr[i]["ocs_flag"].ToString() != "1")
                if (cnt > 0 || dr[i].RowState != DataRowState.Added && (dr[i]["ocs_flag"].ToString() != "0" && dr[i]["ocs_flag"].ToString() != "1" || dr[i]["sunab_yn"].ToString() == "Y"))
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


        #endregion

        #region 파라미터 레이아웃 안에 다른 그룹정보가 존재하는지 여부

        private bool IsExistDifferentGroupInfo(MultiLayout aLayout)
        {
            foreach (DataRow dr in aLayout.LayoutTable.Rows)
            {
                if (this.IsSameCurrentGroupInfo(dr["jusa"].ToString(), dr["nalsu"].ToString(), dr["emergency"].ToString(), dr["wonyoi_order_yn"].ToString()) == false)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region 현재 커런트 그룹이 넘어온 파라미터 정보와 일치하는지 여부

        private bool IsSameCurrentGroupInfo(string aJusa, string aNalsu, string aEmergency, string aWonyoiOrderYn)
        {
            Hashtable tabInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            //if (tabInfo["jusa"].ToString() == "")
            //{
            //    if (this.mOrderFunc.IsEmptyGroup(this.grdOrder, tabInfo["group_ser"].ToString()))
            //    {
            //        return true;
            //    }

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

            if (tabInfo["jusa"].ToString() != aJusa ||
                tabInfo["nalsu"].ToString() != aNalsu ||
                tabInfo["emergency"].ToString() != aEmergency ||
                tabInfo["wonyoi_order_yn"].ToString() != aWonyoiOrderYn)
            {
                return false;
            }

            return true;
        }

        #endregion

        #region 현재 그룹 삭제

        private bool DeleteCurrentGroupTab(IHIS.X.Magic.Controls.TabPage aDestTabPage)
        {
            Hashtable groupInfo;

            if (MessageBox.Show(XMsg.GetMsg("M012"), XMsg.GetField("F002"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return false;

            if (aDestTabPage == null) return false;

            // 현재 오더 테이블에서 empty row 는 삭제 
            this.mOrderFunc.DeleteEmptyNewRow(this.grdOrder);

            // 현재 탭의 오더가 전부 삭제 가능한지 확인한다.
            bool isExistActingOrder = false;
            ArrayList deletRows = new ArrayList();
            for (int i = 0; i < this.grdOrder.DisplayRowCount; i++)
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
                MessageBox.Show(XMsg.GetMsg("M013"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        #endregion

        #region 그룹 선택시의 설정들...

        private void DisplayOrderGridGroupInfo(Hashtable aGroupInfo)
        {
            // 오더그리드의 오더항목 visible setting 
            this.mOrderFunc.SetGridRowVisibleByGroupSer(this.grdOrder, aGroupInfo["group_ser"].ToString(), this.mInputGubun);

            // 그룹항목셋팅
            this.SetGroupControl(aGroupInfo);

            // 그룹항목에 대하여 프로텍트 여부 
            this.ProtectGroupControl(aGroupInfo["group_ser"].ToString());

            // dc 구분관련 보일것인가 말것인가..
            this.ShowDcGubun(this.grdOrder, (aGroupInfo["group_ser"].ToString()));

        }

        #endregion

        #endregion

        #region [ 상용오더 모듈 ]

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
        //            string cmd = @" SELECT A.DOCTOR
        //                              FROM BAS0270 A
        //                             WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + @"'
        //                               AND A.SABUN = :f_memb
        //                               AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND NVL(A.END_DATE,TO_DATE('99981231', 'YYYYMMDD'))
        //                               AND NVL(A.MAIN_GWA_YN, 'N') = 'Y'
        //                               AND A.ROWNUM = 1
        //                             ORDER BY A.DOCTOR ";

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

            //tungtx
            //DataTable sangyongTab = new DataTable();
            OCS0103U12MakeSangyongTabArgs args = new OCS0103U12MakeSangyongTabArgs();
            LoadOftenUsedTabInfo info = new LoadOftenUsedTabInfo();
            info.InputTab = aInputTab;
            info.Memb = aMemb;
            args.RequestInfo = info;
            OCS0103U12MakeSangyongTabResult result =
                CloudService.Instance.Submit<OCS0103U12MakeSangyongTabResult, OCS0103U12MakeSangyongTabArgs>(args);
            if (result == null)
            {
                return;
            }

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

            //for (int i = 0; i < sangyongTab.Rows.Count; i++)
            //{
            //    tpg = new IHIS.X.Magic.Controls.TabPage();
            //    //tpg.Title = sangyongTab.Rows[i]["order_gubun_name"].ToString();
            //    tpg.Title = sangyongTab.Rows[i]["order_gubun_name"].ToString();
            //    tpg.ImageList = this.ImageList;
            //    tpg.ImageIndex = 1;

            //    tabInfo = new Hashtable();
            //    //tabInfo.Add("order_gubun", sangyongTab.Rows[i]["order_gubun"].ToString());
            //    tabInfo.Add("order_gubun", sangyongTab.Rows[i]["order_gubun"].ToString());
            //    //tabInfo.Add("memb", sangyongTab.Rows[i]["memb"].ToString());
            //    tabInfo.Add("memb", sangyongTab.Rows[i]["memb"].ToString());
            //    tpg.Tag = tabInfo;

            //    this.tabSangyongOrder.TabPages.Add(tpg);
            //}

            foreach (OCS0103U12MakeSangyongTabInfo item in result.Result)
            {
                tpg = new IHIS.X.Magic.Controls.TabPage();
                //tpg.Title = sangyongTab.Rows[i]["order_gubun_name"].ToString();
                tpg.Title = item.OrderGubunName;
                tpg.ImageList = this.ImageList;
                tpg.ImageIndex = 1;

                tabInfo = new Hashtable();
                //tabInfo.Add("order_gubun", sangyongTab.Rows[i]["order_gubun"].ToString());
                tabInfo.Add("order_gubun", item.OrderGubun);
                //tabInfo.Add("memb", sangyongTab.Rows[i]["memb"].ToString());
                tabInfo.Add("memb", item.Memb);
                tpg.Tag = tabInfo;

                this.tabSangyongOrder.TabPages.Add(tpg);
            }

            this.tabSangyongOrder.SelectionChanged += new EventHandler(tabSangyongOrder_SelectionChanged);

            this.tabSangyongOrder_SelectionChanged(this.tabSangyongOrder, new EventArgs());
        }

        void tabSangyongOrder_SelectionChanged(object sender, EventArgs e)
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

        #endregion

        #region [ 약오더 모듈 ]

        //TreeNode currNode;

        private void MakeDrugOrder()
        {
            // 분류 데이터 로드 
            this.LoadDrgBunryu();

            TreeNode parentNode = new TreeNode();
            TreeNode childNode;

            string currentParent = "";

            foreach (DataRow dr in this.layDrugTree.LayoutTable.Rows)
            {
                if (currentParent != dr["code"].ToString())
                {
                    if (currentParent != "")
                    {

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
            
        }

        private void LoadDrgBunryu()
        {
            this.layDrugTree.QueryLayout(true);
        }

        private IList<object[]> LoadDataGrdDrgOrder(BindVarCollection varlist)
        {
            OCS0103U12LoadDrgOrderArgs args = new OCS0103U12LoadDrgOrderArgs();
            args.AMode = varlist["f_mode"].VarValue;
            args.ACode1 = varlist["f_code1"].VarValue;
            args.AWonnaeDrgYn = varlist["f_wonnae_drg_yn"].VarValue;
            args.SearchCondition = this.cboSearchCondition.SelectedValue.ToString();
            args.ASearchWord = varlist["f_search_word"].VarValue;
            if (this.mOrderMode == OrderVariables.OrderMode.InpOrder ||
                this.mOrderMode == OrderVariables.OrderMode.OutOrder)
            {
                args.OrderDate = mOrderDate;
            }
            else
            {
                args.OrderDate = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/");
            }
            args.PageNumber = varlist["f_page_number"] != null ? varlist["f_page_number"].VarValue : "";
            args.Offset = maxRowpage.ToString();
            args.ProtocolId = this._protocolID;
            drgOrderResult = CloudService.Instance.Submit<OCS0103U12LoadDrgOrderResult, OCS0103U12LoadDrgOrderArgs>(args);

            IList<object[]> dataList = new List<object[]>();
            if (this.drgOrderResult != null)
            {
                List<OCS0103U12LoadDrgOrderInfo> grdList = drgOrderResult.DrgOrderList;
                if (grdList != null && grdList.Count > 0)
                {
                    foreach (OCS0103U12LoadDrgOrderInfo info in grdList)
                    {
                        dataList.Add(new object[]
                        {
                            info.TrialFlag,
                            info.HangmogCode,
                            info.HangmogName,
                            info.WonyoiOrderCrYn,
                            info.DefaultWonyoiOrderYn,
                            info.Code1,
                            info.DrgInfo,
                            info.OrderGubun,
                            info.OrderGubunName,
                            info.WonnaeDrgYn
                        });
                    }
                }
            }
            return dataList;
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

        #region [ 컨트롤 이벤트 ]

        #region [ 버튼 이벤트 ]

        #region 확장

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

        #endregion

        #region 검색 부분 확장

        private void btnExpandSearch_Click(object sender, EventArgs e)
        {
            if (this.mIsSearchExtended == false)
            {
                this.btnExpandSearch.ImageIndex = 3;
                this.pnlOrderInfo.Size = new Size(this.OrderMinWidth, this.pnlOrderInfo.Size.Height);

                this.grdSangyongOrder.AutoSizeColumn(1, this.SangYongHangmogMaxWidth);

                this.mIsSearchExtended = true;
            }
            else
            {
                this.btnExpandSearch.ImageIndex = 4;
                this.pnlOrderInfo.Size = new Size(this.OrderNormalWidth, this.pnlOrderInfo.Size.Height);

                this.grdSangyongOrder.AutoSizeColumn(1, this.SangYongHangmogNormalWidth);

                this.mIsSearchExtended = false;
            }
        }

        #endregion

        #region Do Set 오더 버튼

        private void btnSetOrder_Click(object sender, EventArgs e)
        {
            this.OpenScreen_OCS0301Q09();
        }

        private void btnDoOrder_Click(object sender, EventArgs e)
        {
            this.OpenScreen_OCS1003Q09(false);
        }

        #endregion

        #region Copy Paste

        public void HandleBtnCopyClick(bool isCut)
        {
            string mbxMsg = "", mbxCap = "";
            string mCopy_gubun = "";
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
                mbxMsg = Resources.MSG2;

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

            //if (MContainer != null) MContainer.AcceptData();

            if (this.mLayDtOrderBuffer == null || this.mLayDtOrderBuffer.Rows.Count == 0)
            {
                mbxMsg = Resources.MSG3;

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
        }

        #endregion

        #region Mix 설정
        public void HandleBtnMixClick()
        {
            this.mHangmogInfo.SetMaxMixGroup(this.grdOrder);

            this.DisplayMixGroup(this.grdOrder); // Mix Group 데이타 Image Display

            string max_mix_group = (int.Parse(GetMixGroup(this.grdOrder)) - 1).ToString();

            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                if (this.grdOrder.GetItemString(i, "mix_group") == max_mix_group)
                    this.grdOrder.SelectRow(i);
            }
            //this.mHangmogInfo.SetAlignMixGroup(grdOrder, settingStartRow, settingRow); // Mix Group 정렬

        }
        #endregion

        #region Mix 해제
        public void HandleBtnMixCancelClick()
        {
            this.mHangmogInfo.ReSetMixGroup(this.grdOrder);

            this.DisplayMixGroup(this.grdOrder); // Mix Group 데이타 Image Display

            //this.mHangmogInfo.SetAlignMixGroup(grdOrder, settingStartRow, settingRow); // Mix Group 정렬
        }
        #endregion


        #region 신규 그룹으로 생성

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

            HandleBtnListButtonClick(FunctionType.Process, out msgOut);

            this.btnSelect.PerformClick();

        }

        #endregion

        #region 선택

        private void btnSelect_Click(object sender, EventArgs e)
        {
            XGrid grid = null;
            int applyRow = -1;

            if (this.tabGroup.SelectedTab == null)
            {
                HandleBtnListButtonClick(FunctionType.Process, out msgOut);
            }
            
            if (rbnOftenOrder.Checked == true)
            {
                grid = this.grdSangyongOrder as XGrid;
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

            this.ApplySangOrderInfo(grid.GetItemString(grid.CurrentRowNumber, "hangmog_code"), applyRow, false);


            PostCallHelper.PostCall(new PostMethodInt(this.PostOrderInsert), applyRow);

            ProcessCheckKinki();
        }

        private void ProcessCheckKinki()
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

            if (mDrugDt != null)
            {
                foreach (DataRow row in mDrugDt.Rows)
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

        #endregion

        #region 정시약 버튼

        private void btnJungsiDrug_Click(object sender, EventArgs e)
        {
            OpenScreen_OCS1023U00(this.mPatientInfo.GetPatientInfo["bunho"].ToString(), this.mPatientInfo.GetPatientInfo["gwa"].ToString());
        }

        #endregion

        #endregion

        #region [ 오더 라디오 버튼 ]

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
                    
                    case "rbnOftenOrder":    // 상용오더
                        this.pnlSearchTool.Visible = true;
                        this.pnlSangyong.Visible = true;
                        PostCallHelper.PostCall(new PostMethod(PostRadioCheckedChanged));
                        this.tabSangyongOrder_SelectionChanged(this.tabSangyongOrder, new EventArgs());

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

        private void PostRadioCheckedChanged()
        {
            this.txtSearch.Focus();
        }

        #endregion

        #region [ XTab Control ]

        private void tabGroup_ClosePressed(object sender, EventArgs e)
        {
            IHIS.X.Magic.Controls.TabControl control = sender as IHIS.X.Magic.Controls.TabControl;

            this.DeleteCurrentGroupTab(control.SelectedTab);
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

                    // 해당 그룹의 젤 마지막 로우로 포커스 이동
                    if (this.mCurrentColName == "")
                    {
                        PostCallHelper.PostCall(new PostMethodInt(this.PostTabSelection), this.mOrderFunc.GetLastRow(this.grdOrder.LayoutTable, ((Hashtable)tpg.Tag)["group_ser"].ToString()));
                    }
                }
                else
                {
                    tpg.ImageIndex = 1;
                }
            }
        }

        private void PostTabSelection(int aRowNumber)
        {
            this.grdOrder.SetFocusToItem(aRowNumber, "hangmog_code", false);
        }

        #endregion

        #region [複数のオーダが存在し、MIXされてないオーダがあればTRUE]
        //insert by jc 
        private string IsNoMixOrder()
        {
            ArrayList groupList = new ArrayList();
            foreach (IHIS.X.Magic.Controls.TabPage tabGroup in this.tabGroup.TabPages)
            {
                Hashtable groupInfo = tabGroup.Tag as Hashtable;

                if (this.grdOrder.RowCount > 0)
                {
                    for (int i = 0; i < this.grdOrder.RowCount; i++)
                    {

                        //[グループ毎にオーダ数を求める]
                        int groupInOrderCnt = 0;
                        //int actedCnt = 0;
                        int sameHospDate = 0;
                        for (int j = 0; j < this.grdOrder.RowCount; j++)
                        {
                            if (groupInfo["group_ser"].ToString() == this.grdOrder.GetItemString(j, "group_ser")
                                && this.grdOrder.GetItemString(j, "acting_date") == "" && this.grdOrder.GetItemString(j, "order_gubun_bas") == "B")
                            {
                                for (int k = 0; k < this.grdOrder.RowCount; k++)
                                {
                                    if (k != j && this.grdOrder.GetItemString(k, "hope_date") == this.grdOrder.GetItemString(j, "hope_date"))
                                    {
                                        sameHospDate++;
                                    }
                                }
                                groupInOrderCnt++;
                            }
                            //else if (groupInfo["group_ser"].ToString() == this.grdOrder.GetItemString(j, "group_ser")
                            //    && this.grdOrder.GetItemString(j, "acting_date") != "")
                            //{
                            //    actedCnt++;
                            //}
                        }

                        //[グループに施行されてないオーダが一つであればOK ArrayListにADDする。]
                        if (groupInOrderCnt <= 1 || sameHospDate == 0)
                        {
                            groupList.Add(groupInfo["group_ser"].ToString());
                        }

                        //[同じグループ内で一つでもmix_groupがあればOK ArrayListにADDする。]
                        if (groupInfo["group_ser"].ToString() == this.grdOrder.GetItemString(i, "group_ser")
                            && this.grdOrder.GetItemString(i, "mix_group") != ""
                            && !groupList.Contains(groupInfo["group_ser"].ToString()))
                        {
                            groupList.Add(groupInfo["group_ser"].ToString());
                        }
                    }
                }
            }
            //[すべてのTABを比較してgroupListに入ってないと入ってないグループの番号をリターン]
            foreach (IHIS.X.Magic.Controls.TabPage tabGroup in this.tabGroup.TabPages)
            {
                Hashtable groupInfo = tabGroup.Tag as Hashtable;

                if (!groupList.Contains(groupInfo["group_ser"].ToString()))
                {
                    return groupInfo["group_ser"].ToString();
                }
            }
            return "Success";
        }
        #endregion

        #region [ 버튼 리스트 ]

        private void ChangeInputGubun()
        {
            XEditGrid grd = this.grdOrder;
            string changeInputGubunName = "";
            //this.mOrderBiz.LoadColumnCodeName("code", "INPUT_GUBUN", this.cboInputGubun.SelectedValue.ToString(), ref changeInputGubunName);

            //tungtx
            OCS0103U12LoadColumnNameArgs args = new OCS0103U12LoadColumnNameArgs();
            LoadColumnCodeNameInfo info = new LoadColumnCodeNameInfo();
            info.ColName = "code";
            info.Arg1 = "INPUT_GUBUN";
            info.Arg2 = this.cboInputGubun.SelectedValue.ToString();
            args.Code = info;
            OCS0103U12LoadColumnNameResult result =
                CloudService.Instance.Submit<OCS0103U12LoadColumnNameResult, OCS0103U12LoadColumnNameArgs>(args);
            if (result != null && !String.IsNullOrEmpty(result.CodeName))
            {
                changeInputGubunName = result.CodeName;
            }

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
        private string msgOut = "";
        public void HandleBtnListButtonClick(FunctionType type, out string msgOut)
        {
            msgOut = "";
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
                        HandleBtnListButtonClick(FunctionType.Process, out msgOut);

                    // Insert한 Row 중에 Not Null필드 미입력 Row Search 하여 해당 Row로 이동
                    XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)this.grdOrder);

                    if (emptyNewCell != null)
                    {
                        /*//todo: check again
                        e.IsSuccess = false;*/

                        ((XEditGrid)this.grdOrder).SetFocusToItem(emptyNewCell.Row, emptyNewCell.CellName);
                        break;
                    }

                    //modify by jc

                    //this.OrderGridCreateNewRow(-1);
                    this.OrderGridCreateNewRow(this.grdOrder.CurrentRowNumber);

                    if (MContainer != null) MContainer.AcceptData();

                    //this.tabGroup_SelectionChanged(this.tabGroup, new EventArgs());
                    this.DisplayOrderGridGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag);

                    // 포커스를 HANGMOG_CODE로
                    //this.grdOrder.SetFocusToItem(this.grdOrder.CurrentRowNumber, "hangmog_code", true);
                    PostCallHelper.PostCall(new PostMethodStr(PostCallAfterInsertRow), "hangmog_code");

                    //insert by jc
                    this.grdOrder.UnSelectAll();

                    #endregion

                    break;

                case FunctionType.Query:

                    if (MContainer != null) MContainer.AcceptData();

                    this.LoadOrderTable(this.mOrderMode, this.mMemb, this.mYaksokCode, this.mPkInOutKey, this.mInputGubun, INPUTTAB, "");

                    this.MakeGroupTabInfo(this.IOEGUBUN, this.mPkInOutKey, this.mInputGubun, INPUTTAB);

                    break;

                case FunctionType.Update:

                    #region 저장

                    if (MContainer != null && MContainer.AcceptData() == false)
                    {
                       
                        return;
                    }


                    if (this.IsUpdateCheck(out msgOut) == false)  
                    {                        
                        return;
                    }

                    // 現在選択されているINPUT_GUBUNで変更する。
                    //this.ChangeInputGubun();

                    //insert by jc START
                    this.grdOrder.Sort("group_ser, hope_date");
                    //insert by jc [選択されているgroupがない内はInput_gubunによるVisible設定をやり直す。]

                    //Sort後荒れたグループ中身を纏める
                    if (this.tabGroup.SelectedTab != null)
                        this.DisplayOrderGridGroupInfo((Hashtable)(this.tabGroup.SelectedTab.Tag));

                    this.DisplayMixGroup(this.grdOrder); // Mix Group 데이타 Image Display
                    this.hopeDateColorChange();

                    if (this.IsNoMixOrder() != "Success")
                    {
                        if (XMessageBox.Show("「" + this.IsNoMixOrder() + Resources.MSG4, Resources.MSG_Confirm, MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            foreach (IHIS.X.Magic.Controls.TabPage tabGroup in this.tabGroup.TabPages)
                            {
                                Hashtable groupInfo = tabGroup.Tag as Hashtable;
                                if (groupInfo["group_ser"].ToString() == this.IsNoMixOrder())
                                {
                                    this.tabGroup.SelectedTab = tabGroup;
                                    return;
                                }
                            }
                        }
                    }

                    //if(this.tabGroup.SelectedTab != null)
                    //    this.mOrderFunc.SetGridRowVisibleByGroupSer(this.grdOrder, ((Hashtable)this.tabGroup.SelectedTab.Tag)["group_ser"].ToString(), this.mInputGubun);
                    /* -------------------------------------------------------------------------------------------------- */
                    //inser by jc [詳細画面での保存処理] START 2012/04/17
                    //[Merge : grdOrder -> laySaveLayout] 
                    if (this.mOrderMode == OrderVariables.OrderMode.InpOrder && this.mCallerScreenID != "OCS2003P01")
                    {
                        if (this.grdOrder.RowCount > 0)
                            this.SetSameOrderDateGroupSer(this.grdOrder);

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
                            //PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert));
                            //this.DisplayMixGroup(this.grdOrder);
                            return;
                        }

                        //insert by jc
                        this.grdOrder.Sort("hope_date");

                        //[InterFace]
                        this.mInterface.MakeIFDataLayout("I", this.layDeletedData.LayoutTable, true, false, true);

                        this.mInterface.MakeIFDataLayout("I", this.laySaveLayout.LayoutTable, false, true, false);

                        this.mInterface.MakeIFDataLayout("I", this.laySaveLayout.LayoutTable, false, false, false);

                        // 트랜잭션 시작
                        //try
                        //{
                        //Service.BeginTransaction();

                        // 삭제시에는 삭제테이블의 데이터를 건드려 줘야 함.
                        //for (int i = 0; i < this.layDeletedData.RowCount; i++)
                        //{
                        //    this.layDeletedData.SetItemValue(i, "dummy", "mageshin");
                        //}

                        #region to be deleted

                        //if (this.layDeletedData.SaveLayout() == false)
                        //{
                        //    Service.RollbackTransaction(); // 롤백

                        //    this.mbxMsg = XMsg.GetMsg("M005") + " - " + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...

                        //    MessageBox.Show(this.mbxMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //    return;
                        //}

                        //if (this.mInterface.InsertDeletedDataToTempTable() == false)
                        //{
                        //}

                        //if (this.laySaveLayout.SaveLayout() == false)
                        //{
                        //    Service.RollbackTransaction();  // 롤백

                        //    this.mbxMsg = XMsg.GetMsg("M005") + " - " + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...

                        //    MessageBox.Show(this.mbxMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //    return;
                        //}
                        //else
                        //{
                        //    // 저장이 완료된 후에 NDAY 건을 처리하기 위하여 NDAY OCCUR YN 프로시져를 호출한다.
                        //    string procName = "PR_OCS_APPLY_NDAY_ORDER";
                        //    ArrayList inList = new ArrayList();
                        //    ArrayList outList = new ArrayList();

                        //    inList.Add(mBunho);
                        //    inList.Add(mOrderDate);

                        //    if (Service.ExecuteProcedure(procName, inList, outList) == false)
                        //    {
                        //        Service.RollbackTransaction();  // 롤백

                        //        this.mbxMsg = XMsg.GetMsg("M005") + " - " + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...

                        //        MessageBox.Show(this.mbxMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //        return;
                        //    }
                        //    else
                        //    {
                        //        if (outList[0].ToString() != "0")
                        //        {
                        //            Service.RollbackTransaction();  // 롤백

                        //            this.mbxMsg = XMsg.GetMsg("M005") + " - " + outList[0].ToString();  // 저장에 실패하였습니다 + 에러메세지...

                        //            MessageBox.Show(this.mbxMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //            return;
                        //        }
                        //    }
                        //}

                        #endregion


                        try
                        {
                            for (int i = 0; i < this.layDeletedData.RowCount; i++)
                            {
                                this.layDeletedData.SetItemValue(i, "dummy", "mageshin");
                            }

                            // Cloud updated code START
                            OCS0103U12SaveLayoutArgs args = new OCS0103U12SaveLayoutArgs();
                            args.SaveLayoutItem = GetListDataForSaveLayout();
                            args.InterfaceInsertItem = GetListDataForInterfaceInsert();
                            args.Bunho = mBunho;
                            args.OrderDate = mOrderDate;

                            OCS0103U10SaveLayoutResult res = CloudService.Instance.Submit<OCS0103U10SaveLayoutResult, OCS0103U12SaveLayoutArgs>(args);

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
                        }
                        catch// (Exception exception)
                        {
                            throw;
                        }
                        //}
                        //catch
                        //{
                        //    Service.RollbackTransaction();
                        //}

                        //Service.CommitTransaction();  // 커밋

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

                    //insert by jc END
                    this.InvokeReturnSendReturnDataTable();

                    if (mContainer != null && mContainer.Name != "OCS2015U00") this.mContainer.Close();


                    #endregion

                    break;

                case FunctionType.Delete:

                    if (MContainer != null) MContainer.AcceptData();

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

                    //insert by jc
                    this.grdOrder.UnSelectAll();

                    break;

                case FunctionType.Close:

                    if (MContainer != null) MContainer.AcceptData();
                    if (this.mOrderBiz.IsCloseOrderScreen(this.grdOrder))
                        if (MContainer != null) MContainer.Close();
                        else
                            return;
                    break;
            }
        }


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
                item.AntiCancerYn = grdOrder.GetItemString(i, "anti_cancer_yn");
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
                //item.Dv5                            = grdOrder.GetItemString(i, "dv_5");
                //item.Dv6                            = grdOrder.GetItemString(i, "dv_6");
                //item.Dv7                            = grdOrder.GetItemString(i, "dv_7");
                //item.Dv8                            = grdOrder.GetItemString(i, "dv_8");
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
        private void SetSameOrderDateGroupSer(XEditGrid grd)
        {
            bool isSameGroupSer = false;
            //[現在登録されているGROUP_SERリスト取得]
            //MultiLayout GroupSerList = new MultiLayout();
            //            GroupSerList.LayoutItems.Add("group_ser", DataType.String);
            //            GroupSerList.InitializeLayoutTable();

            //            GroupSerList.QuerySQL = @"select distinct(a.group_ser) group_ser
            //                                        from ocs2003 a 
            //                                       where a.hosp_code    = :f_hosp_code
            //                                         and a.order_date   = :f_order_date
            //                                         and a.input_tab    = :f_input_tab
            //                                         and a.dc_yn       != 'Y' 
            //                                         and a.bannab_yn   != 'Y'
            //                                         and a.bunho        = :f_bunho
            //                                         and a.input_doctor = :f_input_doctor
            //                                         and a.acting_date is null
            //                                         and a.group_ser not in (select distinct(b.group_ser) 
            //                                                                   from ocs2003 b 
            //					                                              where b.hosp_cdoe    = :f_hosp_code 
            //                                                                    and b.order_date   = :f_order_date
            //					                                                and b.input_tab    = :f_input_tab
            //					                                                and b.bunho        = :f_bunho
            //					                                                and b.input_doctor = :f_input_doctor)
            //                                         order by a.group_ser";

            //            GroupSerList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //            GroupSerList.SetBindVarValue("f_order_date", mOrderDate);
            //            GroupSerList.SetBindVarValue("f_input_tab", "03");
            //            GroupSerList.SetBindVarValue("f_bunho", mBunho);
            //            GroupSerList.SetBindVarValue("f_input_doctor", UserInfo.DoctorID);

            //            if (GroupSerList.QueryLayout(true) == false) return;

            OCS0103U12SetSameOrderDateGroupSerArgs args = new OCS0103U12SetSameOrderDateGroupSerArgs();
            args.OrderDate = mOrderDate;
            args.InputTab = "03";
            args.Bunho = mBunho;
            args.InputDoctor = UserInfo.DoctorID;
            OCS0103U12SetSameOrderDateGroupSerResult result =
                CloudService.Instance
                    .Submit<OCS0103U12SetSameOrderDateGroupSerResult, OCS0103U12SetSameOrderDateGroupSerArgs>(args);
            if (result == null || result.Data == null || result.Data.Count == 0)
            {
                return;
            }
            for (int i = 0; i < grd.RowCount; i++)
            {
                isSameGroupSer = false;

                //for (int j = 0; j < GroupSerList.RowCount; j++)
                for (int j = 0; j < result.Data.Count; j++)
                {
                    // 既に施行されたオーダは対象外とする。pkocskeyがnullであるオーダだけをチェックを行う。（保存されてないオーダだけ）
                    if (grd.GetItemString(i, "acting_date") == ""
                        //&& grd.GetItemString(i, "group_ser") == GroupSerList.GetItemString(j, "group_ser")

                        && grd.GetItemString(i, "group_ser") == result.Data[j].DataValue
                        && grd.GetRowState(i) == DataRowState.Added
                        && grd.GetItemString(i, "pkocskey") == "")
                    {
                        isSameGroupSer = true;
                        break;
                    }
                }

                if (isSameGroupSer == true)
                {
                    string str = grd.GetItemString(i, "group_ser");
                    //int max_group_ser = int.Parse(GroupSerList.GetItemString(GroupSerList.RowCount - 1, "group_ser")) + 1 > (MaxGroup_ser("03", grd)) + 1 ? int.Parse(GroupSerList.GetItemString(GroupSerList.RowCount - 1, "group_ser")) + 1 : (MaxGroup_ser("03", grd)) + 1;
                    int max_group_ser = int.Parse(result.Data[result.Data.Count - 1].DataValue) + 1 > (MaxGroup_ser("03", grd)) + 1 ? int.Parse(result.Data[result.Data.Count - 1].DataValue) + 1 : (MaxGroup_ser("03", grd)) + 1;

                    for (int k = 0; k < grd.RowCount; k++)
                    {
                        if (grd.GetItemString(k, "group_ser") == str && grd.GetItemString(k, "acting_date") == "")
                        {
                            grd.SetItemValue(k, "group_ser", max_group_ser);
                            grd.AcceptData();
                        }
                    }
                }
            }

        }
        private int MaxGroup_ser(string aInput_tab, XEditGrid aLayout)
        {
            int max = 0;

            for (int i = 0; i < aLayout.RowCount; i++)
            {
                if (aInput_tab == aLayout.GetItemString(i, "input_tab") && max < int.Parse(aLayout.GetItemString(i, "group_ser")))
                {
                    max = int.Parse(aLayout.GetItemString(i, "group_ser"));
                }
            }

            return max;
        }
        private void PostCallAfterInsertRow(string aFocusColumn)
        {
            this.grdOrder.Focus();
            this.grdOrder.SetFocusToItem(this.grdOrder.CurrentRowNumber, aFocusColumn, true);
            //insert by jc
            this.hopeDateColorChange();
        }

        private void PostCallAfterDeleteRow(int aRowNumber)
        {
            this.grdOrder.Focus();
            this.grdOrder.SetFocusToItem(aRowNumber, "hangmog_code", false);
            //insert by jc
            this.hopeDateColorChange();
        }

        #endregion

        #region [ 파인드 박스 이벤트 ]

        #region [ 주사방법 ]

        private void fbxJusa_FindClick(object sender, CancelEventArgs e)
        {
            XFindBox control = sender as XFindBox;

            if (this.tabGroup.SelectedTab == null) return;

            Hashtable tabInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            if (this.mOrderFunc.IsEmptyGroup(this.grdOrder, tabInfo["group_ser"].ToString()))
            {
                MessageBox.Show(XMsg.GetMsg("M032"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //control.FindWorker = this.mOrderBiz.GetFindWorker("jusa", this.IOEGUBUN);

            /*//tungtx
            control.FindWorker = new XFindWorker();

            control.FindWorker.AutoQuery = true;
            control.FindWorker.SearchImeMode = System.Windows.Forms.ImeMode.NoControl;
            control.FindWorker.ExecuteQuery = LoadDataFdwCommon;
            control.FindWorker.ColInfos.Add("code", Resources.code_fbxJusa, FindColType.String, 100, 0, true, FilterType.Yes);
            control.FindWorker.ColInfos.Add("code_name", Resources.code_name_fbxJusa, FindColType.String, 300, 0, true, FilterType.No);
            control.FindWorker.ServerFilter = true;*/

            //MED-16858
            fwkFind.AutoQuery = true;
            fwkFind.SearchImeMode = System.Windows.Forms.ImeMode.NoControl;
            fwkFind.ExecuteQuery = LoadDataFdwCommon;
            /*fwkFind.ColInfos.Add("code", Resources.code_fbxJusa, FindColType.String, 100, 0, true, FilterType.Yes);
            fwkFind.ColInfos.Add("code_name", Resources.code_name_fbxJusa, FindColType.String, 300, 0, true, FilterType.No);*/

            this.fwkFind.ColInfos[0].HeaderText = Resources.code_fbxJusa;
            this.fwkFind.ColInfos[1].HeaderText = Resources.code_name_fbxJusa;

            fwkFind.ServerFilter = true;
        }

        private IList<object[]> LoadDataFdwCommon(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            OCS0103U12FbxJusaFindClickArgs args = new OCS0103U12FbxJusaFindClickArgs();
            args.IoGubun = this.IOEGUBUN;
            args.Find1 = varlist["f_find1"] != null ? varlist["f_find1"].VarValue : "";

            OCS0103U12FbxJusaFindClickResult result =
                CloudService.Instance.Submit<OCS0103U12FbxJusaFindClickResult, OCS0103U12FbxJusaFindClickArgs>(args);
            if (result != null)
            {
                List<ComboListItemInfo> cboList = result.CboResult;
                if (cboList != null && cboList.Count > 0)
                {
                    foreach (ComboListItemInfo info in cboList)
                    {
                        dataList.Add(new object[]
                        {
                            info.Code,
                            info.CodeName
                        });
                    }
                }
            }
            return dataList;
        }

        private void fbxJusa_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue == "")
            {
                this.dbxJusaName.SetDataValue("");
                
                this.ApplyGroupInfo("", "", this.cboNalsu.GetDataValue(), this.cbxEmergency.GetDataValue()
                                   , this.cbxWonyoiOrderYN.GetDataValue());

                this.mContainer.SetMsg("");
                return;
            }

            string jusaName = "";

            //tungtx
            OCS0103U12LoadColumnNameArgs args = new OCS0103U12LoadColumnNameArgs();
            LoadColumnCodeNameInfo info = new LoadColumnCodeNameInfo();
            info.ColName = "jusa";
            info.Arg1 = e.DataValue;
            args.Code = info;
            OCS0103U12LoadColumnNameResult result =
                CloudService.Instance.Submit<OCS0103U12LoadColumnNameResult, OCS0103U12LoadColumnNameArgs>(args);

            //if (this.mOrderBiz.LoadColumnCodeName("jusa", e.DataValue, ref jusaName) == false)
            if (result == null || String.IsNullOrEmpty(result.CodeName))
            {
                //주사방법이 정확하지 않습니다.
                MessageBox.Show(XMsg.GetMsg("M003"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.mContainer.SetMsg(XMsg.GetMsg("M003"), MsgType.Error);

                e.Cancel = true;
            }
            else
            {
                jusaName = result.CodeName;
                this.dbxJusaName.SetDataValue(jusaName);
                //
                PostCallHelper.PostCall(new PostMethod(PostNalsuValidating));// Todo
                this.ApplyGroupInfo(e.DataValue, jusaName, this.cboNalsu.GetDataValue()
                                   , this.cbxEmergency.GetDataValue(), this.cbxWonyoiOrderYN.GetDataValue());

                this.mContainer.SetMsg("");
            }

        }

        #endregion

        #endregion

        #region [ 그리드 이벤트 ]

        #region [ 오더 그리드 ]

        private void grdOrder_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;
            string dv = "";


            //insert by jc [CellPaintingの前に色が変わったら変わったままにしておくため　hopeDateColorChange()]
            if (e.BackColor == OrderVariables.DisplayFieldColor.Color || e.BackColor == OrderVariables.DisplayFieldColor.Color)
            {
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
            }
            this.mHangmogInfo.ColumnColorForOrderState(IOEGUBUN, grd, e); // 처방상태에 따른 색상 처리


            dv = grd.GetItemString(e.RowNumber, "dv");

            // 공통 이외의 DV 처리
            switch (e.ColName)
            {
                case "dv_1":
                    break;
                case "dv_2":
                    if (TypeCheck.IsInt(dv) == false)
                    {
                        e.BackColor = OrderVariables.DisplayFieldColor.Color;
                    }
                    else
                    {
                        if (int.Parse(dv) < 2)
                        {
                            e.BackColor = OrderVariables.DisplayFieldColor.Color;
                        }
                    }
                    break;
                case "dv_3":
                    if (TypeCheck.IsInt(dv) == false)
                    {
                        e.BackColor = OrderVariables.DisplayFieldColor.Color;
                    }
                    else
                    {
                        if (int.Parse(dv) < 3)
                        {
                            e.BackColor = OrderVariables.DisplayFieldColor.Color;
                        }
                    }
                    break;
                case "dv_4":
                    if (TypeCheck.IsInt(dv) == false)
                    {
                        e.BackColor = OrderVariables.DisplayFieldColor.Color;
                    }
                    else
                    {
                        if (int.Parse(dv) < 4)
                        {
                            e.BackColor = OrderVariables.DisplayFieldColor.Color;
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
                //insert by jc [if_input_control親・子になっている項目に関しては赤い文字に表示させる] 2012/03/09
                //delete by jc [システム的なものを表に出す必要があるのか] 2013/01/09
                //case "hangmog_name":
                //    if (this.grdOrder.GetItemString(e.RowNumber, "if_input_control") == "B")
                //    {
                //        e.ForeColor = Color.Red;
                //    }
                //    break;
            }
        }

        private void grdOrder_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;
            int cnt = 0;
            //insert by jc [現在のROWに該当するCHILDオーダがACTINGされたオーダがあるのかチェックする。あればROW情報変更不可にするため]
            //if (this.mCallerScreenID != "OCS0301U00")
            if (this.mCallerScreenID == "OCS1003P01" || this.mCallerScreenID == "OCS2003P01")
            {
                //                SingleLayout laySingle = new SingleLayout();
                //                laySingle.LayoutItems.Add("cnt");
                //                laySingle.InitializeLifetimeService();

                //                laySingle.QuerySQL = @" SELECT COUNT(*)
                //   			                          FROM OCS2003 B, (SELECT A.PKOCS2003,
                //                                                              A.HOSP_CODE
                //  				          	                             FROM OCS2003 A
                //						                                WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + @"'
                //                                                          AND A.BUNHO = :f_bunho
                //						                                  AND A.ORDER_DATE = :f_order_date
                //                                                          AND A.HANGMOG_CODE = :f_hangmog_code
                //						                                  AND SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('B', 'C', 'D')
                //						                                  AND NVL(A.DC_YN, 'N') = 'N'
                //						                                  AND A.NDAY_YN = 'Y'
                //						                                  AND A.NDAY_OCCUR_YN = 'Y') P
                //				                     WHERE B.HOSP_CODE = P.HOSP_CODE
                //                                       AND B.SORT_FKOCSKEY = P.PKOCS2003 
                //				                       AND B.ACTING_DATE IS NOT NULL";

                //                laySingle.SetBindVarValue("f_order_date", dpkOrder_Date.GetDataValue());
                //                laySingle.SetBindVarValue("f_bunho", mPatientInfo.GetPatientInfo["bunho"].ToString());
                //                laySingle.SetBindVarValue("f_hangmog_code", grd.GetItemValue(e.RowNumber, "hangmog_code").ToString());

                //                laySingle.QueryLayout();

                //tungtx
                OCS0103U12GridColumnProtectModifyArgs args =
                    new OCS0103U12GridColumnProtectModifyArgs(mOrderDate, mPatientInfo.GetPatientInfo["bunho"].ToString(), grd.GetItemValue(e.RowNumber, "hangmog_code").ToString());
                OCS0103U12GridColumnProtectModifyResult result =
                    CloudService.Instance
                        .Submit<OCS0103U12GridColumnProtectModifyResult, OCS0103U12GridColumnProtectModifyArgs>(args);
                if (result != null)
                {
                    cnt = int.Parse(result.Cnt);
                }

                //cnt = int.Parse(laySingle.GetItemValue("cnt").ToString());

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
                    !this.mHangmogInfo.IsOrderDataChagnedEnabled(IOEGUBUN, grd, e.RowNumber, e.ColName, OrderVariables.CheckMode.Protected, OrderVariables.ErrorDisplayMode.NoDisplay) ||
                    //!this.mHangmogInfo.IsOrderDataChagnedEnabled(IOEGUBUN, grd, e.RowNumber, e.ColName, OrderVariables.CheckMode.Protected, OrderVariables.ErrorDisplayMode.NoDisplay))
                    cnt > 0 ||
                    //insert by jc [CellのWidthが０である場合はProtectを掛けてカーソルが行っても反応しないようにするため] 2012/02/20
                    this.grdOrder[e.RowNumber, e.ColName].AbsoluteRectangle.Width == 0)
                    e.Protect = true;
            }

            string dv = grd.GetItemString(e.RowNumber, "dv");

            // 공통 이외의 DV 처리
            switch (e.ColName)
            {
                case "dv_1":

                    break;
                case "dv_2":
                    if (TypeCheck.IsInt(dv) == false)
                    {
                        e.Protect = true;
                    }
                    else
                    {
                        if (int.Parse(dv) < 2)
                        {
                            e.Protect = true;
                        }
                    }
                    break;
                case "dv_3":
                    if (TypeCheck.IsInt(dv) == false)
                    {
                        e.Protect = true;
                    }
                    else
                    {
                        if (int.Parse(dv) < 3)
                        {
                            e.Protect = true;
                        }
                    }
                    break;
                case "dv_4":
                    if (TypeCheck.IsInt(dv) == false)
                    {
                        e.Protect = true;
                    }
                    else
                    {
                        if (int.Parse(dv) < 4)
                        {
                            e.Protect = true;
                        }
                    }
                    break;
                //insert by jc [行為部署がHOMである場合は希望日を選択できないようにする] 2012/03/15
                case "hope_date":
                    if (UserInfo.Gwa != "CK" && (grd.GetItemString(e.RowNumber, "jundal_part") == "HOM" || grd.GetItemString(e.RowNumber, "wonyoi_order_yn") == "Y"))
                    {
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

                    break;

                case "ord_danui_name":  // 오더단위

                    //((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker(e.ColName, grid.GetItemString(e.RowNumber, "hangmog_code"));

                    //tungtx
                    ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker =
                        LoadFindWorker(e.ColName, grid.GetItemString(e.RowNumber, "hangmog_code"));


                    break;

                case "jundal_part": // 전달파트

                    // 외래 전달 파트 
                    if (this.IOEGUBUN == "O")
                    {
                        //((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_out_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                        //tungtx
                        ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker =
                            LoadFindWorker("jundal_part_out_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));
                    }
                    // 입원 전달파트 
                    else
                    {
                        //((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_inp_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                        //tungtx
                        ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker =
                            LoadFindWorker("jundal_part_inp_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));
                    }

                    break;

                case "jundal_part_out": // 전달파트 외래

                    //((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_out_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                    //tungtx
                    ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker =
                        LoadFindWorker("jundal_part_out_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                    break;

                case "jundal_part_inp": // 전달파트 입원

                    //((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_inp_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                    //tungtx
                    ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker =
                        LoadFindWorker("jundal_part_inp_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                    break;

                case "bogyong_code_sub":  // 注射部位

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
                    fdwTemp.ColInfos.Add("ord_danui_name", Resources.XMsg_000004, FindColType.String, 100, 0, true, FilterType.Yes);
                    fdwTemp.ColInfos.Add("ord_danui", Resources.XMsg_000005, FindColType.String, 100, 0, true, FilterType.Yes);
                    break;

                case "jundal_part_out_hangmog":
                    fdwTemp.ColInfos.Add("gwa", Resources.XMsg_000006, FindColType.String, 100, 0, true, FilterType.Yes);
                    fdwTemp.ColInfos.Add("gwa_name", Resources.XMsg_000007, FindColType.String, 300, 0, true, FilterType.No);
                    break;

                case "jundal_part_inp_hangmog":
                    fdwTemp.ColInfos.Add("gwa", Resources.XMsg_000006, FindColType.String, 100, 0, true, FilterType.Yes);
                    fdwTemp.ColInfos.Add("gwa_name", Resources.XMsg_000007, FindColType.String, 300, 0, true, FilterType.No);
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
            // 항목을 제외한 다른 컬럼들의 일반적 validation 은 이안에서 기술한다.   
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
                        //this.mOrderFunc.UndoPreviousValue(grid, e.RowNumber, e.ColName, previousValue);   // 이전값으로 되돌린다.
                        return;
                    }

                    this.mHangmogInfo.Parameter.Clear();
                    this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
                    this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
                    this.mHangmogInfo.Parameter.InputGubun = this.mInputGubun;
                    this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
                    this.mHangmogInfo.Parameter.IOEGubun = this.IOEGUBUN;
                    this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;
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

                    #region 그룹정보 및 항목코드 셋팅

                    MultiLayout loadExtraInfo = new MultiLayout();

                    loadExtraInfo.LayoutItems.Add("hangmog_code", DataType.String);
                    loadExtraInfo.LayoutItems.Add("group_ser", DataType.String);
                    loadExtraInfo.LayoutItems.Add("jusa", DataType.String);
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
                    if (groupInfo.Contains("jusa"))
                    {
                        loadExtraInfo.SetItemValue(0, "jusa", groupInfo["jusa"].ToString());
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
                        this.OpenScreen_OCS0103Q00(e.ChangeValue.ToString(), true);
                        return;
                    }

                    this.ApplyDefaultOrderInfo(this.mHangmogInfo.GetHangmogInfo, grid, e.RowNumber, true);

                    // 이거 다 해놓고
                    // 그룹이벤트를 다시 태워야 하네...
                    //this.tabGroup_SelectionChanged(this.tabGroup, new EventArgs());
                    this.DisplayOrderGridGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag);

                    this.DisplayMixGroup(this.grdOrder);

                    this.SetOrderImage(this.grdOrder);

                    #endregion

                    ProcessCheckKinki();

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
                        //insert by jc MIXされたオーダは行為部署変更が不可能にする。MIX解除してからやり直すようにMSG表示。
                        //string current_mix_group = grid.GetItemString(e.RowNumber, "mix_group");
                        //if (current_mix_group != "")
                        //{
                        //    XMessageBox.Show("MIXされたオーダです。変更する場合はMIXを解除してからやり直してください。");
                        //    this.mOrderFunc.UndoPreviousValue(grid, e.RowNumber, e.ColName, previousValue);
                        //    return;
                        //}
                        //insert by jc [HOMの場合は希望日を入れられない。] 
                        if (grid.GetItemString(e.RowNumber, "jundal_part") == "HOM")
                        {
                            for (int i = 0; i < grid.RowCount; i++)
                            {
                                if (grid.GetItemString(e.RowNumber, "mix_group") == grid.GetItemString(i, "mix_group") && grid.GetItemString(e.RowNumber, "mix_group") != "")
                                {
                                    grid.SetItemValue(i, "hope_date", "");
                                    grid.SetItemValue(i, "hope_time", "");
                                }
                            }
                        }
                        //if (this.mOrderBiz.GetJundaTable(this.IOEGUBUN, hangmog_code, grid.GetItemString(e.RowNumber, "order_date"), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)
                        if (this.mOrderBiz.GetJundaTable(this.IOEGUBUN, hangmog_code, TypeCheck.NVL(grid.GetItemString(e.RowNumber, "order_date"), mOrderDate.ToString()).ToString(), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)
                        {
                            grid.SetItemValue(e.RowNumber, "jundal_table", jundalTable);
                            grid.SetItemValue(e.RowNumber, "move_part", movePart);
                        }


                        for (int i = 0; i < grdOrder.RowCount; i++)
                        {
                            if (grdOrder.GetItemString(i, "mix_group") == grdOrder.GetItemString(grdOrder.CurrentRowNumber, "mix_group")
                                && grdOrder.GetItemString(i, "jundal_part") != grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part")
                                && grdOrder.GetItemString(i, "mix_group") != "")
                            {
                                grdOrder.SetItemValue(i, "jundal_table", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_table"));
                                grdOrder.SetItemValue(i, "move_part", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "move_part"));
                                grdOrder.SetItemValue(i, "jundal_part", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
                                grdOrder.AcceptData();
                            }
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
                //insert by jc [mix_group間のhope_date同期化]　START
                case "hope_date":
                    for (int i = 0; i < grdOrder.RowCount; i++)
                    {
                        if (grdOrder.GetItemString(i, "mix_group") == grdOrder.GetItemString(grdOrder.CurrentRowNumber, "mix_group")
                            && grdOrder.GetItemString(i, "hope_date") != grdOrder.GetItemString(grdOrder.CurrentRowNumber, "hope_date")
                            && grdOrder.GetItemString(i, "mix_group") != "")
                        {
                            grdOrder.SetItemValue(i, "hope_date", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "hope_date"));
                            grdOrder.AcceptData();
                        }
                    }

                    //for (int j = 0; j < grdOrder.RowCount; j++)
                    //{
                    //    grdOrder.SetItemValue(j, "hope_date", grdOrder.GetItemString(j, "hope_date"));
                    //    grdOrder.AcceptData();
                    //    this.flg = true;
                    //}

                    //this.grdOrder.Refresh();

                    break;
                //insert by jc [mix_group間のhope_date同期化]　END

                //注射速度欄に数字以外は入力できない様に修正。2013/05/24
                case "bogyong_code":
                    string str = e.ChangeValue.ToString();

                    if (!TypeCheck.IsDouble(str))
                    {
                        XMessageBox.Show(Resources.MSG5,Resources.MSG_Confirm);
                        this.mOrderFunc.UndoPreviousValue(grid, e.RowNumber, e.ColName, previousValue);
                    }
                    break;
            }

            //this.ReGroupingMix(0, this.grdOrder.RowCount - 1, false);

            this.SetMixOrderValue(grid, e.RowNumber, e.ColName, e.ChangeValue.ToString());

            this.MakePreviewStatus();
        }


        #region [hope_dateの色を塗りつける]
        private void hopeDateColorChange()
        {
            XColor cr = null;
            XColor cr1 = null;
            XColor cr2 = null;
            int ppCnt = 0;

            for (int i = 0; i < this.grdOrder.DisplayRowCount; i++)
            {
                // [色変えのためppCntが１ずつ増えるたびに色を変える]
                if (ppCnt % 2 == 0)
                {
                    cr1 = new XColor(Color.Khaki);
                    cr2 = new XColor(Color.LightGreen);
                }
                else
                {
                    cr2 = new XColor(Color.Khaki);
                    cr1 = new XColor(Color.LightGreen);
                }

                if (grdOrder.GetItemString(i, "hope_date") != "")
                {
                    // [前ROWと比較するため前ROWのhope_dateを持っている]
                    string preRow = grdOrder.GetItemString(i - 1, "hope_date");
                    // [前ROWと現在のROWのhope_dateが同一であれば同じ色を塗りつける]
                    // [現在のROWNUMが０であり、前ROWのhope_dateがなくても色をつける]
                    if (preRow == grdOrder.GetItemString(i, "hope_date") || (i == 0 && preRow == ""))
                    {
                        /*if ((i - 1) < 0)*/
                        cr = cr1;
                    }
                    else
                    {
                        cr = cr2;
                        // [前ROW現在のROWのhope_dateが違うたび、色の入れ替えのためにカウンターする]
                        ppCnt++;
                    }

                    //if(this.grdOrder.IsVisibleRow(i))
                    this.grdOrder[i, "hope_date"].BackColor = cr;
                }
                else if (grdOrder.GetItemString(i, "hope_date") == "")
                {
                    //if (this.grdOrder.IsVisibleRow(i))
                    this.grdOrder[i, "hope_date"].BackColor = new XColor(Color.White);
                }
            }
        }
        #endregion

        private void PostValidationColumn(object aValidInfo)
        {
            Hashtable info = aValidInfo as Hashtable;


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
                    HandleBtnListButtonClick(FunctionType.Insert,out msgOut);
                }
            }
        }

        private void grdOrder_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                int curRowIndex = -1;
                XEditGrid grd = sender as XEditGrid;
                curRowIndex = grd.GetHitRowNumber(e.Y);

                if (e.Button == MouseButtons.Right && e.Clicks == 1)
                {
                    this.grdOrder.SetFocusToItem(curRowIndex, "hangmog_name");
                    popupOrderMenu.TrackPopup(grd.PointToScreen(new Point(e.X, e.Y)));
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
                    HandleBtnListButtonClick(FunctionType.Process, out msgOut);
                }

                switch (gubun)
                {
                    case "Drug":
                        
                        this.ApplySangOrderInfo(hangmogCode, rowNumber, false);

                        PostCallHelper.PostCall(new PostMethodInt(PostOrderInsert), rowNumber);

                        break;

                    case "Search":

                        hangmogCode = this.mSelectedGRD.GetItemString(int.Parse(sourceRow), "hangmog_code");

                        this.ApplySangOrderInfo(hangmogCode, rowNumber, false);

                        PostCallHelper.PostCall(new PostMethodInt(PostOrderInsert), rowNumber);

                        break;

                    case "SangYong":

                        hangmogCode = this.grdSangyongOrder.GetItemString(int.Parse(sourceRow), "hangmog_code");

                        this.ApplySangOrderInfo(hangmogCode, rowNumber, false);

                        PostCallHelper.PostCall(new PostMethodInt(PostOrderInsert), rowNumber);

                        break;
                }

                ProcessCheckKinki();
            }
            catch (Exception ex)
            {
                Service.WriteLog("Exception on grdOrder_DragDrop function: " + ex.StackTrace);
            }
        }

        private void SetOrderImage(XEditGrid aGrid)
        {
            // 의사가 입력하는 경우는 스킵
            if (this.mInputGubun.Substring(0, 1) == "D") return;

            for (int i = 0; i < aGrid.RowCount; i++)
            {
                // 의사 오더인경우
                if (aGrid.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                {
                    aGrid[i + aGrid.HeaderHeights.Count, 0].Image = this.ImageList.Images[8];
                    aGrid[i + aGrid.HeaderHeights.Count, 0].ToolTipText = Resources.XMsg_000008 + aGrid[i + aGrid.HeaderHeights.Count, 0].ToolTipText;
                }
            }
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
                    loadParams.Add("category_gubun", OrderVariables.CATEGORY_INJ_COMMENT); // 注射コメント

                    grd.SetReservedMemoControlLoadParam(e.ColName, loadParams);

                    break;
            }
        }

        #endregion

        #region [ 상용오더 그리드 ]

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

                this.popupOftenUsedMenu.TrackPopup(grid.PointToScreen(new Point(e.X, e.Y)));
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

        #endregion

        #region [ 약오더 그리드 ]

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

        #endregion

        #region [ 검색 그리드 ]

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

        #endregion

        #endregion

        #region [ 콤보박스 이벤트 ]

        private void cboNalsu_SelectedValueChanged(object sender, EventArgs e)
        {
            //TO DO
            //this.cboNalsu.SetEditValue(this.cboNalsu.GetDataValue()); 
            this.cboNalsu.SetEditValue("1");
            this.cboNalsu.AcceptData();
        }

        private void cboNalsu_DataValidating(object sender, DataValidatingEventArgs e)
        {

            if (this.tabGroup.SelectedTab == null) return;
            //if (!this.IsSelectedRowForNalsu()) return;

            Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            int nalsu = 1;

            if (TypeCheck.IsInt(e.DataValue))
            {
                nalsu = int.Parse(e.DataValue);
            }

            //if (this.IOEGUBUN == "O" && nalsu > 1)
            if (nalsu > 1)
            {
                //if (this.IOEGUBUN == "O" && this.mOrderMode == OrderVariables.OrderMode.OutOrder)
                //if (this.mOrderMode == OrderVariables.OrderMode.OutOrder)
                //{
                // 현재 그리드에 해당 그룹의 오더가 없는경우 
                // 즉 빈 그룹인경우 오더를 입력하라는 메세지
                if (this.mOrderFunc.IsEmptyGroup(this.grdOrder, groupInfo["group_ser"].ToString()))
                {
                    //오더코드를 먼저 입력해 주세요.
                    MessageBox.Show(XMsg.GetMsg("M004"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    PostCallHelper.PostCall(new PostMethod(PostNalsuValidating));

                    return;
                }

                // 먼저 주사방법이 결정되어야 한다.
                if (this.fbxJusa.GetDataValue() == "")
                {
                    // 먼저 주사방법을 입력해 주세요.
                    MessageBox.Show(XMsg.GetMsg("M009"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    PostCallHelper.PostCall(new PostMethod(PostNalsuValidating));

                    return;
                }

                if (nalsu > 999)
                {
                    // 날수를 정확히 입력해 주세요.
                    MessageBox.Show(XMsg.GetMsg("M031"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    PostCallHelper.PostCall(new PostMethod(PostNalsuValidating));

                    return;
                }

                // 주사방법이 없는 경우는 일수로 처방으로 나오게 한다.
                if (OrderVariables.HOME_CARE_JUSA == this.fbxJusa.GetDataValue())
                {
                    this.ApplyGroupInfo(this.fbxJusa.GetDataValue(), this.dbxJusaName.GetDataValue(), e.DataValue, this.cbxEmergency.GetDataValue(), this.cbxWonyoiOrderYN.GetDataValue());
                    return;
                }
                else
                {

                    OrderVariables.Objects objects = new OrderVariables.Objects(this.grdOrder, this.grdOrder.CurrentRowNumber, this.grdOrder.GetItemString(0, "order_date")
                                                                              , e.DataValue, this.grdOrder.GetItemString(0, "jundal_table")
                                                                              , this.grdOrder.GetItemString(0, "order_gubun_bas")
                                                                              , this.grdOrder.GetItemString(0, "home_care_yn"));

                    PostCallHelper.PostCall(new PostMethodObject(PostNalsuValidating), objects);
                }
                //}
                //else if (this.mOrderMode == OrderVariables.OrderMode.SetOrder)
                //{
                //    // 셋트 입력시 주사오더의 일수는 1로 고정됩니다.
                //    MessageBox.Show(XMsg.GetMsg("M010"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //    return;
                //}

                PostCallHelper.PostCall(new PostMethod(PostNalsuValidating));
            }
            else
            {
                //if (this.mOrderMode == OrderVariables.OrderMode.CpOrder && nalsu > 1)
                //{
                //    // 크리티컬 패스 정보 입력시 주사오더의 일수는 1로 고정됩니다.
                //    MessageBox.Show(XMsg.GetMsg("M010"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //    PostCallHelper.PostCall(new PostMethod(PostNalsuValidating));

                //    return;
                //}
                //else
                //{
                //    this.ApplyGroupInfo(this.fbxJusa.GetDataValue(), this.dbxJusaName.GetDataValue(), e.DataValue, this.cbxEmergency.GetDataValue(), this.cbxWonyoiOrderYN.GetDataValue());
                //}
                this.ApplyGroupInfo(this.fbxJusa.GetDataValue(), this.dbxJusaName.GetDataValue(), e.DataValue, this.cbxEmergency.GetDataValue(), this.cbxWonyoiOrderYN.GetDataValue());
            }

        }

        // Post Method 
        private void PostNalsuValidating()
        {
            // 에러로 취소시 날수는 1로 원상복귀
            this.cboNalsu.SetEditValue("1");
            this.cboNalsu.AcceptData();
        }
        private void PostNalsuValidating(object aParam)
        {
            try
            {
                this.grdOrder.GridCellPainting -= new IHIS.Framework.XGridCellPaintEventHandler(this.grdOrder_GridCellPainting);

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

                // 해당 원 데이타의 일수를 1일로 세팅한다.
                //grd.SetItemValue(row, "nalsu", 1);
                // 해당 원 데이터의 재택을 "N"으로 세팅한다.
                //grd.SetItemValue(row, "home_care_yn", "N");

                // 그룹의 일수를 1로 다시 변경한다.
                this.cboNalsu.SelectedValueChanged -= new EventHandler(cboNalsu_SelectedValueChanged);
                this.cboNalsu.SetDataValue("1");
                this.cboNalsu.SelectedValueChanged += new EventHandler(cboNalsu_SelectedValueChanged);

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
                    //if (i==0)
                    if (i == 0 && this.mHangmogInfo.IsOrderDataChagnedEnabled(this.IOEGUBUN, this.grdOrder, this.grdOrder.CurrentRowNumber, "jusa", OrderVariables.CheckMode.DataUpdate, OrderVariables.ErrorDisplayMode.NoDisplay)) // 초기 1회는 현재 화면의 데이터 즉 기준데이터를 가지고 희망일자만 셋팅하면 된다.
                    {
                        if (selectedIndex.Count > 0)
                        {
                            foreach (int rows in selectedIndex)
                            {
                                //if (this.grdOrder.GetItemString(rows, "group_ser") == ((Hashtable)this.tabGroup.SelectedTab.Tag)["group_ser"].ToString() &&
                                //                                    this.grdOrder.GetItemString(rows, "input_gubun") == this.mInputGubun)
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
                        string currentMix = "";
                        foreach (DataRow dr in layGijunData.LayoutTable.Rows)
                        {
                            dr.AcceptChanges();
                            if (currentMix != dr["mix_group"].ToString())
                            {
                                for (int k = 0; k < mixInfo.RowCount; k++)
                                    mixInfo.SetItemValue(k, "cnv_mix", "");
                            }

                            if (dr.RowState == DataRowState.Unchanged)
                                dr.SetAdded();

                            string cnvMix = "";
                            if (mixInfo.RowCount > 0)
                                mixInfo.SetItemValue(0, "org_mix", dr["mix_group"].ToString());

                            if (dr["mix_group"].ToString() != "")
                            {
                                currentMix = dr["mix_group"].ToString();
                                cnvMix = this.GetConvertMixInfo(mixInfo, dr["mix_group"].ToString());

                                if (cnvMix == "")
                                {
                                    cnvMix = this.GetMixGroup(this.grdOrder);
                                    this.SetConvertMixInfo(mixInfo, dr["mix_group"].ToString(), cnvMix);
                                }
                            }
                            dr["hope_date"] = receiveDate.GetItemString(i, "day");
                            dr["mix_group"] = cnvMix;

                            //reset
                            dr["pkocskey"] = null;
                            dr["ocs_flag"] = "1";
                            dr["acting_date"] = null;
                            dr["seq"] = null;

                            dr["dc_yn"] = "N";
                            dr["dc_gubun"] = "N";
                            dr["bannab_yn"] = "N";
                            dr["bannab_confirm"] = null;
                            dr["act_doctor"] = null;
                            dr["act_gwa"] = null;
                            dr["act_buseo"] = null;
                            dr["jubsu_date"] = null;

                            if (dr["sg_ymd"].ToString() != "")
                                dr["sg_ymd"] = DateTime.Parse(dr["sg_ymd"].ToString()).ToString("yyyy/MM/dd");


                            this.grdOrder.LayoutTable.ImportRow(dr);

                            this.grdOrder.AcceptData();

                            //modify by jc START
                            //this.grdOrder.LayoutTable.ImportRow(dr);

                            //DataRow newRow = this.grdOrder.LayoutTable.NewRow();

                            //foreach (DataColumn cl in this.grdOrder.LayoutTable.Columns)
                            //{
                            //    switch (cl.ColumnName)
                            //    {
                            //        case "hope_date":

                            //            newRow[cl.ColumnName] = receiveDate.GetItemString(i, "day");

                            //            break;

                            //        case "mix_group":

                            //            newRow[cl.ColumnName] = cnvMix;

                            //            break;

                            //        default:

                            //            newRow[cl.ColumnName] = dr[cl.ColumnName];

                            //            break;
                            //    }
                            //}
                            //// [追加した予約分を作って画面のグリドに追加する]
                            //this.grdOrder.LayoutTable.Rows.Add(newRow);

                            //DataRow newRow = this.grdOrder.LayoutTable.NewRow();

                            //insert by jc [選択されたオーダの中一番RowNumberが高い方をcurrentRowとして使う]
                            //ArrayList RowNumList = new ArrayList();
                            //for (int k = 0; k < this.grdOrder.RowCount; k++)
                            //{
                            //    if (this.grdOrder.IsSelectedRow(k))
                            //    {
                            //        RowNumList.Add(k);
                            //    }
                            //}

                            //for (int j = 0; j < RowNumList.Count; j++)
                            //{
                            //    if (currentRow < int.Parse(RowNumList[j].ToString()))
                            //    {
                            //        currentRow = int.Parse(RowNumList[j].ToString());
                            //    }
                            //}

                            //int currentRow = this.grdOrder.CurrentRowNumber;
                            //int currentRow = this.grdOrder.RowCount;
                            //this.grdOrder.InsertRow(currentRow);
                            //課題[コーピーではなく新しくオーダを作るように修正]

                            //this.ApplySangOrderInfo(dr["hangmog_code"].ToString(), currentRow + 1, true);
                            //this.grdOrder.SetItemValue(currentRow + 1, "hope_date", receiveDate.GetItemString(i, "day"));
                            //this.grdOrder.SetItemValue(currentRow + 1, "mix_group", cnvMix);

                            //PostCallHelper.PostCall(new PostMethodInt(this.PostOrderInsert), currentRow + 1);

                            //this.grdOrder.LayoutTable.Rows.Add(dr);

                            //dr["hope_date"] = receiveDate.GetItemString(i, "day");
                            ////dr["mix_group"] = cnvMix;
                            //this.grdOrder.LayoutTable.ImportRow(dr);
                            //this.grdOrder.AcceptData();


                            //this.grdOrder.SetItemValue(this.grdOrder.CurrentRowNumber, "hope_date", receiveDate.GetItemString(i, "day"));
                            //this.grdOrder.SetItemValue(this.grdOrder.CurrentRowNumber, "mix_group", cnvMix);

                            //foreach (DataColumn cl in this.grdOrder.LayoutTable.Columns)
                            //{
                            //    switch (cl.ColumnName)
                            //    {
                            //        case "pkocskey": break;
                            //        case "seq": break;
                            //        case "muhyo": break;
                            //        case "dc_yn": break;
                            //        case "bannab_yn": break;
                            //        case "bannab_confirm": break;
                            //        case "ocs_flag": break;
                            //        case "sg_ymd": break;
                            //        case "after_act_yn": break;


                            //        case "hope_date":

                            //            this.grdOrder.SetItemValue(this.grdOrder.CurrentRowNumber, cl.ColumnName, receiveDate.GetItemString(i, "day"));

                            //            break;

                            //        case "mix_group":

                            //            //newRow[cl.ColumnName] = cnvMix;
                            //            this.grdOrder.SetItemValue(this.grdOrder.CurrentRowNumber, cl.ColumnName, cnvMix);

                            //            break;

                            //        default:

                            //            //newRow[cl.ColumnName] = dr[cl.ColumnName];
                            //            this.grdOrder.SetItemValue(this.grdOrder.CurrentRowNumber, cl.ColumnName, dr[cl.ColumnName]);
                            //            break;
                            //    }
                            //}
                            // [追加した予約分を作って画面のグリドに追加する]
                            //this.grdOrder.LayoutTable.Rows.Add(newRow);
                            //modify by jc END
                        }
                    }
                }
                this.grdOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOrder_GridCellPainting);

                this.grdOrder.DisplayData(true);

                this.DisplayMixGroup(this.grdOrder);

                //this.tabGroup_SelectionChanged(this.tabGroup, new EventArgs());
                this.DisplayOrderGridGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag);

            }
            finally
            {
                this.SetVisibleStatusBar(false);
                this.Cursor = System.Windows.Forms.Cursors.Default;
                this.MakePreviewStatus();
            }
        }

        private void cboQueryCon_SelectedValueChanged(object sender, EventArgs e)
        {
            this.txtSearch.Focus();
            this.Search_text();
            this.grdSangyongOrder.QueryLayout(true);
        }

        #endregion

        #region [ 체크박스 이벤트 ]

        private void cbxWonyoiOrderYN_CheckedChanged(object sender, EventArgs e)
        {
            if (this.tabGroup.SelectedTab == null) return;

            //insert by jc [注射方法が「０」（なし）の際の院外チェックを外すと注射方法がリセットされるように]
            //delete by jc [院外チェックを外すと注射方法がOの場合注射方法を消す処理を削除] 2012/03/22
            //if (this.cbxWonyoiOrderYN.GetDataValue().ToString() == "N"
            //    && this.fbxJusa.GetDataValue().ToString() == "0")
            //{
            //    this.fbxJusa.SetDataValue("");
            //    this.fbxJusa.AcceptData();

            //    this.dbxJusaName.SetDataValue("");

            //    this.ApplyGroupInfo("", "", this.cboNalsu.GetDataValue(), this.cbxEmergency.GetDataValue()
            //                       , this.cbxWonyoiOrderYN.GetDataValue());

            //    this.mContainer.SetMsg("");

            //}
            //else
            //this.ApplyGroupInfo(this.fbxJusa.GetDataValue(), this.dbxJusaName.GetDataValue(), this.cboNalsu.GetDataValue(), this.cbxEmergency.GetDataValue()
            //                      , this.cbxWonyoiOrderYN.GetDataValue());

            //this.mContainer.SetMsg("");

            this.ApplyGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag, "wonyoi_order_yn", this.cbxWonyoiOrderYN.GetDataValue(), "", "", "");
        }

        public void HandleCbxEmergencyCheckedChanged()
        {
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
        private void cbxEmergency_CheckedChanged(object sender, EventArgs e)
        {
            HandleCbxEmergencyCheckedChanged();
        }

        private void PostEmergencyCheckedChangeFail(string aOrgCheckedValue)
        {
            this.cbxEmergency.CheckedChanged -= new EventHandler(cbxEmergency_CheckedChanged);

            this.cbxEmergency.SetDataValue(aOrgCheckedValue);

            this.cbxEmergency.CheckedChanged += new EventHandler(cbxEmergency_CheckedChanged);
        }

        #endregion

        #region [ 텍스트 박스 이벤트 ]

        private void txtSearch_DataValidating(object sender, DataValidatingEventArgs e)
        {


        }

        private void PostSearchValidating()
        {
            bool isFocusToTextBox = false;
            
            if (this.rbnOftenOrder.Checked)
            {
                if (this.grdSangyongOrder.RowCount <= 0)
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

        ////insert by jc
        //private void PostSearchValidating()
        //{
        //    this.txtSearch.SetDataValue("");
        //}

        #endregion

        #endregion

        #region [ Command ]

        public override object Command(string command, CommonItemCollection commandParam)
        {
            //if (MContainer != null) MContainer.AcceptData();

            switch (command)
            {
                case "OCS0103Q00":            // 항목검색

                    #region 항목검색

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("OCS0103") && ((MultiLayout)commandParam["OCS0103"]).RowCount > 0)
                        {
                            foreach (DataRow dr in ((MultiLayout)commandParam["OCS0103"]).LayoutTable.Rows)
                            {
                                HandleBtnListButtonClick(FunctionType.Insert,out msgOut);
                                this.ApplySangOrderInfo(dr["hangmog_code"].ToString(), this.grdOrder.CurrentRowNumber, true);
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
                            ProcessCheckKinki();
                        }

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
                        }
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

        #endregion

        #region [PopupMenu 클릭 Event]
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
            if (this.MBtnList == null || this.MBtnList.Enabled)
            {
                this.grdOrder.Focus();
                HandleBtnListButtonClick(FunctionType.Delete,out msgOut);
            }
        }
        // Copy
        private void PopUpMenuInsert_Click(object sender, System.EventArgs e)
        {
            if (this.MBtnCopy == null || this.MBtnCopy.Enabled) HandleBtnCopyClick(false);
        }
        // Paster
        private void PopUpMenuPaste_Click(object sender, System.EventArgs e)
        {
            if (this.MBtnPaste == null || this.MBtnPaste.Enabled) HandleBtnPasteClick();
        }
        // Mix
        private void PopUpMenuMix_Click(object sender, System.EventArgs e)
        {
            if (this.MBtnMix == null || this.MBtnMix.Enabled) HandleBtnMixClick();
        }
        // Mix해제
        private void PopUpMenuMixCancel_Click(object sender, System.EventArgs e)
        {
            if (this.MBtnMixCancel == null || this.MBtnMixCancel.Enabled) HandleBtnMixCancelClick();

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

                    //this.mOrderBiz.LoadColumnCodeName("gwa_doctor", "%", this.mMemb, EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"), ref name);

                    //tungtx
                    OCS0103U12LoadColumnNameArgs args = new OCS0103U12LoadColumnNameArgs();
                    LoadColumnCodeNameInfo info = new LoadColumnCodeNameInfo();
                    info.ColName = "gwa_doctor";
                    info.Arg1 = "%";
                    info.Arg2 = this.mMemb;
                    info.Arg3 = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/");
                    args.Code = info;
                    OCS0103U12LoadColumnNameResult result =
                        CloudService.Instance.Submit<OCS0103U12LoadColumnNameResult, OCS0103U12LoadColumnNameArgs>(args);
                    if (result != null && result.CodeName != null)
                    {
                        name = result.CodeName;
                    }
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

        #endregion

        #region Post Event

        private void PostOrderInsert(int aFocusRow)
        {
            int focusRow = -1;
            if (aFocusRow < 0)
                focusRow = this.grdOrder.RowCount - 1;
            else
                focusRow = aFocusRow;

            if (focusRow < 0) return;

            this.MakePreviewStatus();

            this.grdOrder.VerticalScroll.Maximum = 1000;
            this.grdOrder.VerticalScroll.Value = 500;
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

        #endregion

        #region Preview 관련 모듈

        private void MakePreviewStatus()
        {
            //insert by jc
            this.hopeDateColorChange();

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

        private void SelectGroupTab(string aGroupSer)
        {
            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroup.TabPages)
            {
                if (((Hashtable)tpg.Tag)["group_ser"].ToString() == aGroupSer)
                {
                    this.tabGroup.SelectedTab = tpg;
                    return;
                }
            }
        }

        #endregion

        private void tabGroup_SelectionChanging(object sender, EventArgs e)
        {
            if (this.tabGroup.SelectedTab == null)
                return;

            Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            if (groupInfo.Contains("nalsu") && groupInfo["nalsu"].ToString() != this.cboNalsu.GetDataValue())
            {
                this.cboNalsu.AcceptData();
            }

            if (groupInfo.Contains("jusa") && groupInfo["jusa"].ToString() != this.fbxJusa.GetDataValue())
            {
                this.fbxJusa.AcceptData();
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

        //insert by jc [Nalsuクリック時grdOrderに選択されている行がないと進まない]
        private void cboNalsu_MouseDown(object sender, MouseEventArgs e)
        {
            IsSelectedRowForNalsu();
        }

        private bool IsSelectedRowForNalsu()
        {
            int selectRow = 0;
            //Hashtable groupInfo = this.tabGroup.SelectedTab.Tag; 
            //if (this.IOEGUBUN == "O")
            //{
            if (this.grdOrder.RowCount > 0)
            {
                //if (int.Parse(this.cboNalsu.GetDataValue()) > 1)
                //{
                for (int i = 0; i < this.grdOrder.RowCount; i++)
                {
                    if (this.grdOrder.IsSelectedRow(i))
                    {
                        if (this.grdOrder.GetItemString(i, "jundal_part") == "HOM" && this.mInputGubun != "CK")
                        {
                            MessageBox.Show(Resources.XMsg_000009, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    XMessageBox.Show(Resources.MSG6, Resources.MSG_Confirm);
                    this.cboNalsu.SetDataValue("1");
                    //this.cboNalsu.AcceptData();
                    return false;
                }
                //}
            }
            //}
            return true;
        }
        //insert by jc [注射方法のコードが「０」の場合は在宅なので院外チェックボックスに自動的にチェックを入れておく]
        private void fbxJusa_TextChanged(object sender, EventArgs e)
        {
            //delete by jc [自動院外チェック処理削除] 2012/03/22
            //if (fbxJusa.GetDataValue().ToString() == "0")
            //{
            //    this.cbxWonyoiOrderYN.SetDataValue("Y");
            //}
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
                    string currentHopeDate = this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "hope_date").Trim();
                    //オーダ登録グリドから検索
                    for (int i = 0; i < this.grdOrder.RowCount; i++)
                    {
                        if (this.grdOrder.GetItemString(i, "hangmog_code") == currentHangmogCode && this.grdOrder.GetItemString(i, "group_ser") == currentGroupSer && this.grdOrder.GetItemString(i, "hope_date") == currentHopeDate)
                        {
                            currentRow = i;
                            break;
                        }
                    }
                    //オーダプリヴューグリドから検索
                    if (this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "input_tab") == "01"
                        || this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "input_tab") == "03")
                    {

                    }
                }

                //フォーカス設定
                switch (this.mCurrentColName)
                {
                    case "hangmog_name":
                        this.grdOrder.SetFocusToItem(currentRow, "hangmog_code", true);
                        break;
                    case "order_detail":
                        if (this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "bogyong_code_yn") == "Y")
                        {
                            this.cboNalsu.Focus();
                        }
                        else
                        {
                            this.grdOrder.SetFocusToItem(currentRow, "suryang", true);
                        }
                        break;
                    case "order_info":
                        //コメント
                        if (currentData.Substring(0, 1) == Resources.XMsg_000016)
                        {
                            this.grdOrder.SetFocusToItem(currentRow, "order_remark", true);
                        }
                        //不均等オーダ
                        else if (currentData.Substring(0, 2) == Resources.XMsg_000015)
                        {
                            this.grdOrder.SetFocusToItem(currentRow, "dv_1", true);
                        }
                        //希望日
                        else if (currentData.Substring(1, 1) == Resources.XMsg_000014)
                        {
                            this.grdOrder.SetFocusToItem(currentRow, "hope_date", true);
                        }
                        //服用コード
                        else
                            this.fbxJusa.Focus();
                        break;
                }
            }
        }
        private bool IsSelectedDiffHopeDate()
        {
            ArrayList HopeDateList = new ArrayList();
            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                if (this.grdOrder.IsSelectedRow(i))
                {
                    HopeDateList.Add(this.grdOrder.GetItemString(i, "hope_date"));
                }
            }

            for (int j = 0; j < HopeDateList.Count; j++)
            {
                for (int k = j; k < HopeDateList.Count; k++)
                {
                    if (HopeDateList[j].ToString() != HopeDateList[k].ToString())
                    {
                        return false;
                    }
                }
            }

            return true;
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
            if (this.fbxJusa.GetDataValue() == "")
            {
                // 먼저 주사방법을 입력해 주세요.
                MessageBox.Show(XMsg.GetMsg("M009"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                PostCallHelper.PostCall(new PostMethod(PostNalsuValidating));

                return;
            }

            // 주사방법이 없는 경우는 일수로 처방으로 나오게 한다.
            if (OrderVariables.HOME_CARE_JUSA == this.fbxJusa.GetDataValue())
            {
                //this.ApplyGroupInfo(this.fbxJusa.GetDataValue(), this.dbxJusaName.GetDataValue(), e.DataValue, this.cbxEmergency.GetDataValue(), this.cbxWonyoiOrderYN.GetDataValue());
                return;
            }
            else
            {

                OrderVariables.Objects objects = new OrderVariables.Objects(this.grdOrder, this.grdOrder.CurrentRowNumber, this.grdOrder.GetItemString(0, "order_date")
                                                                          , 1, this.grdOrder.GetItemString(0, "jundal_table")
                                                                          , this.grdOrder.GetItemString(0, "order_gubun_bas")
                                                                          , this.grdOrder.GetItemString(0, "home_care_yn"));

                PostCallHelper.PostCall(new PostMethodObject(PostNalsuValidating), objects);
            }


            PostCallHelper.PostCall(new PostMethod(PostNalsuValidating));


        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                isSearchFormKeyPress = true;
                this.Search_text();
            }
        }

        private void Search_text()
        {
            string searchText = this.txtSearch.GetDataValue();
            //Implement with bug MED-6542
            if (searchText == "" /*&& this.rbnOftenOrder.Checked*/)
                searchText = "%";

            if (searchText == "")
                return;

            string wonnaeDrgYn = "";
            wonnaeDrgYn = this.cboQueryCon.GetDataValue();
            
            if (this.rbnOftenOrder.Checked)
            {
                if (this.tabSangyongOrder.SelectedTab != null)
                {
                    Hashtable tabInfo = this.tabSangyongOrder.SelectedTab.Tag as Hashtable;

                    this.LoadOftenUseOrder("1", tabInfo["memb"].ToString(), tabInfo["order_gubun"].ToString(), wonnaeDrgYn, searchText);
                    WarningMessage(grdSangyongOrder);
                }
            }

            PostCallHelper.PostCall(new PostMethod(PostSearchValidating));
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

        private void dbxJusaName_Click(object sender, EventArgs e)
        {
            //this.fbxJusa.FindClick();
            //fbxJusa_FindClick();

            //XFindBox control = this.fbxJusa;

            //if (this.tabGroup.SelectedTab == null) return;

            //Hashtable tabInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            //if (this.mOrderFunc.IsEmptyGroup(this.grdOrder, tabInfo["group_ser"].ToString()))
            //{
            //    MessageBox.Show(XMsg.GetMsg("M032"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //control.FindWorker = this.mOrderBiz.GetFindWorker("jusa");
            //control.FindWorker.ServerFilter = true;
        }

        private void grdSangyongOrder_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdSangyongOrder.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            //this.grdSangyongOrder.SetBindVarValue("f_user",             UserInfo.UserID);
            if (UserInfo.UserGubun == UserType.Doctor)
                this.grdSangyongOrder.SetBindVarValue("f_user", UserInfo.UserID);
            //else if (this.mPatientInfo.GetPatientInfo != null)

            //tungtx
            else if (this.mPatientInfo.GetPatientInfo != null && this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString().Length >= 2)
                this.grdSangyongOrder.SetBindVarValue("f_user", this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString().Substring(2));
            else
                this.grdSangyongOrder.SetBindVarValue("f_user", UserInfo.UserID);

            this.grdSangyongOrder.SetBindVarValue("f_io_gubun", this.IOEGUBUN);
            this.grdSangyongOrder.SetBindVarValue("f_search_word", this.txtSearch.Text);
            if (tabSangyongOrder != null && this.tabSangyongOrder.SelectedTab != null)
            {
                this.grdSangyongOrder.SetBindVarValue("f_order_gubun", ((Hashtable)this.tabSangyongOrder.SelectedTab.Tag)["order_gubun"].ToString());
            }
            this.grdSangyongOrder.SetBindVarValue("f_order_date", mOrderDate);
            this.grdSangyongOrder.SetBindVarValue("f_wonnae_drg_yn", this.cboQueryCon.GetDataValue());
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

        private void grdOrder_GridContDisplayed(object sender, XGridContDisplayedEventArgs e)
        {
            this.hopeDateColorChange();
            this.DisplayMixGroup(this.grdOrder);
            //PostOrderInsert(199);
        }

        private OCS0103U12InitComboBoxResult InitializeComboBox()
        {
            OCS0103U12InitComboBoxArgs args = new OCS0103U12InitComboBoxArgs();
            OCS0103U12InitComboBoxResult result =
                CacheService.Instance.Get<OCS0103U12InitComboBoxArgs, OCS0103U12InitComboBoxResult>(args);
            return result;
        }

        private IList<object[]> LoadDataCboSearchCondition(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            if (cboResult != null)
            {
                List<ComboListItemInfo> cboList = cboResult.CboSearchConditionList;
                foreach (ComboListItemInfo info in cboList)
                {
                    dataList.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                }
            }
            return dataList;
        }

        private IList<object[]> LoadDataCboInputGubun(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            if (cboResult != null)
            {
                List<ComboListItemInfo> cboList = cboResult.CboInputGubun;
                foreach (ComboListItemInfo info in cboList)
                {
                    dataList.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                }
            }
            return dataList;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            HandleBtnListButtonClick(FunctionType.Insert,out msgOut);
        }
        public void ReLoadRegularOrder()
        {
            this.grdSangyongOrder.Reset();
            this.grdSangyongOrder.QueryLayout(true);
        }

        private void UCOCS0103U12C_Activated(object sender, EventArgs e)
        {

        }

        private void UCOCS0103U12C_Paint(object sender, PaintEventArgs e)
        {
            if (!_screenActivated)
            {
                _screenActivated = true;
                string temp = "";
                ScreenOpen(_aOpenParam);
            }
        }

        #region MED-6658
        //Warning message func
        private void WarningMessage(XEditGrid xGrd)
        {
            if (xGrd.RowCount == 0 && isSearchFormKeyPress)
            {
                XMessageBox.Show(Resources.UCOCS0103U12_WarningMessage, Resources.Cap_000033, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isSearchFormKeyPress = false;
            }
        }
        #endregion
    }
    //insert by jc 
    #region XSavePeformer
    //public class XSavePeformer : ISavePerformer
    //{
    //    private OCS0103U12 parent = null;
    //    private IHIS.OCS.OrderBiz mOrderBiz = new OrderBiz("OCS0103U12");

    //    public XSavePeformer(OCS0103U12 parent)
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
    //                                + "        NDAY_OCCUR_YN        , BOGYONG_CODE_SUB     ) "
    //                                + " VALUES "
    //                                + "      ( SYSDATE              , :q_user_id           , SYSDATE           , :q_user_id              , :f_hosp_code             , "
    //                                + "        :f_pkocskey          , :f_bunho             , :f_order_date     , TO_CHAR(SYSDATE, 'HH24MI'), :f_doctor               , "
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
    //                                + "        'N'                  , :f_bogyong_code_sub  ) ";



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
    //                                + "      , BOGYONG_CODE_SUB = :f_bogyong_code_sub "
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
