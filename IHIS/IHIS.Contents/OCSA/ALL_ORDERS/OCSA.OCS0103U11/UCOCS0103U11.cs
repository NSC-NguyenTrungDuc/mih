using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Arguments.Ocso;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Contracts.Results.Ocso;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
using IHIS.OCS;
using IHIS.OCSA.Properties;
using PatientInfo = IHIS.OCS.PatientInfo;
using IHIS.CloudConnector.Contracts.Arguments.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Results.Ocs.Lib;

namespace IHIS.OCSA
{
    public partial class UCOCS0103U11 : XScreen
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCOCS0103U11));
            this.pnlFill = new IHIS.Framework.XPanel();
            this.pnlSangyong = new IHIS.Framework.XPanel();
            this.grdSangyongOrder = new IHIS.Framework.XEditGrid();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.tabSangyongOrder = new IHIS.Framework.XTabControl();
            this.pnlSlipHangmog = new IHIS.Framework.XPanel();
            this.grdSlipHangmog = new IHIS.Framework.XEditGrid();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.tvwSlipCode = new IHIS.Framework.XTreeView();
            this.pnlSearch = new IHIS.Framework.XPanel();
            this.grdSearchOrder = new IHIS.Framework.XEditGrid();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xPanel8 = new IHIS.Framework.XPanel();
            this.cboSearchCondition = new IHIS.Framework.XDictComboBox();
            this.cboQueryCon = new IHIS.Framework.XComboBox();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.txtSearch = new IHIS.Framework.XTextBox();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.btnInsert = new IHIS.Framework.XButton();
            this.btnSelect = new IHIS.Framework.XButton();
            this.btnNewSelect = new IHIS.Framework.XButton();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.rbnSlipHangmog = new IHIS.Framework.XRadioButton();
            this.rbnOftenOrder = new IHIS.Framework.XRadioButton();
            this.rbnSearchOrder = new IHIS.Framework.XRadioButton();
            this.btnExpandSearch = new IHIS.Framework.XButton();
            this.pnlOrderInfo = new IHIS.Framework.XPanel();
            this.xPanel4 = new IHIS.Framework.XPanel();
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
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.xComboItem6 = new IHIS.Framework.XComboItem();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.pnlOrderDetail = new IHIS.Framework.XPanel();
            this.btnSpecificComment = new IHIS.Framework.XButton();
            this.btnSetOrder = new IHIS.Framework.XButton();
            this.btnDoOrder = new IHIS.Framework.XButton();
            this.btnExtend = new IHIS.Framework.XButton();
            this.cbxEmergency = new IHIS.Framework.XCheckBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.pnlOrderInput = new IHIS.Framework.XPanel();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.tabGroup = new IHIS.Framework.XTabControl();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
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
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ImageGrouping = new System.Windows.Forms.ImageList(this.components);
            this.laySlipCodeTree = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem151 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem152 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem153 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem154 = new IHIS.Framework.MultiLayoutItem();
            this.lyReserCanDate = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.laySaveLayout = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
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
            this.multiLayoutItem34 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem35 = new IHIS.Framework.MultiLayoutItem();
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
            this.multiLayoutItem698 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem699 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem700 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem711 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem719 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem720 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem725 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1019 = new IHIS.Framework.MultiLayoutItem();
            this.layDeletedData = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem869 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem870 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem871 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem872 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem873 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem874 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem875 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem876 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem877 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem878 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem879 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem880 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem881 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem882 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem883 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem884 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem885 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem886 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem887 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem888 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem889 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem890 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem891 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem892 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem893 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem894 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem895 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem896 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem897 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem898 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem899 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem900 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem901 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem902 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem903 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem904 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem905 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem906 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem907 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem908 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem909 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem910 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem911 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem912 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem913 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem914 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem915 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem916 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem917 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem918 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem919 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem920 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem921 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem922 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem923 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem924 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem925 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem926 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem927 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem928 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem929 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem930 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem931 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem932 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem933 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem934 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem935 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem936 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem937 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem938 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem939 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem940 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem941 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem942 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem943 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem944 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem945 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem946 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem947 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem948 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem949 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem950 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem951 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem952 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem953 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem954 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem955 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem956 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem957 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem958 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem959 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem960 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem961 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem962 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem963 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem964 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem965 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem966 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem967 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem968 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem969 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem970 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem971 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem972 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem973 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem974 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem975 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem976 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem977 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem978 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem979 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem980 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem981 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem982 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem983 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem984 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem985 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem986 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem987 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem988 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem989 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem990 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem991 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem992 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem993 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem994 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem995 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem996 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem997 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem998 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem999 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1000 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1001 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1002 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1003 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1004 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1005 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1006 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1007 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1008 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1009 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1010 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1011 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1012 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1017 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1018 = new IHIS.Framework.MultiLayoutItem();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.pnlFill.SuspendLayout();
            this.pnlSangyong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSangyongOrder)).BeginInit();
            this.pnlSlipHangmog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSlipHangmog)).BeginInit();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchOrder)).BeginInit();
            this.xPanel8.SuspendLayout();
            this.xPanel6.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.pnlOrderInfo.SuspendLayout();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).BeginInit();
            this.pnlOrderDetail.SuspendLayout();
            this.pnlOrderInput.SuspendLayout();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layGroupTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySlipCodeTree)).BeginInit();
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
            this.ImageList.Images.SetKeyName(7, "Plus.ico");
            this.ImageList.Images.SetKeyName(8, "오른쪽_회색1.gif");
            this.ImageList.Images.SetKeyName(9, "메뉴보기.gif");
            this.ImageList.Images.SetKeyName(10, "진료안내16.ico");
            this.ImageList.Images.SetKeyName(11, "++.gif");
            this.ImageList.Images.SetKeyName(12, "뒤로.gif");
            this.ImageList.Images.SetKeyName(13, "왼쪽_회색1.gif");
            // 
            // pnlFill
            // 
            this.pnlFill.AccessibleDescription = null;
            this.pnlFill.AccessibleName = null;
            resources.ApplyResources(this.pnlFill, "pnlFill");
            this.pnlFill.BackgroundImage = null;
            this.pnlFill.Controls.Add(this.pnlSangyong);
            this.pnlFill.Controls.Add(this.pnlSlipHangmog);
            this.pnlFill.Controls.Add(this.pnlSearch);
            this.pnlFill.Controls.Add(this.xPanel8);
            this.pnlFill.Controls.Add(this.xPanel6);
            this.pnlFill.Controls.Add(this.xPanel2);
            this.pnlFill.Controls.Add(this.pnlOrderInfo);
            this.pnlFill.Font = null;
            this.pnlFill.Name = "pnlFill";
            this.toolTip1.SetToolTip(this.pnlFill, resources.GetString("pnlFill.ToolTip"));
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
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell24,
            this.xEditGridCell62});
            this.grdSangyongOrder.ColPerLine = 2;
            this.grdSangyongOrder.Cols = 2;
            this.grdSangyongOrder.ExecuteQuery = null;
            this.grdSangyongOrder.FixedRows = 1;
            this.grdSangyongOrder.HeaderHeights.Add(28);
            this.grdSangyongOrder.Name = "grdSangyongOrder";
            this.grdSangyongOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSangyongOrder.ParamList")));
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
            this.xEditGridCell18.CellName = "slip_code";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "slip_name";
            this.xEditGridCell19.CellWidth = 97;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.SuppressRepeating = false;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "hangmog_code";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsNotNull = true;
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "hangmog_name";
            this.xEditGridCell21.CellWidth = 331;
            this.xEditGridCell21.Col = 1;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsReadOnly = true;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "seq";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "hosp_code";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsReadOnly = true;
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "memb";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "memb_gubun";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "wonnae_drg_yn";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellName = "trial_flg";
            this.xEditGridCell62.Col = -1;
            this.xEditGridCell62.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.IsVisible = false;
            this.xEditGridCell62.Row = -1;
            // 
            // tabSangyongOrder
            // 
            this.tabSangyongOrder.AccessibleDescription = null;
            this.tabSangyongOrder.AccessibleName = null;
            resources.ApplyResources(this.tabSangyongOrder, "tabSangyongOrder");
            this.tabSangyongOrder.BackgroundImage = null;
            this.tabSangyongOrder.Font = null;
            this.tabSangyongOrder.IDEPixelArea = true;
            this.tabSangyongOrder.IDEPixelBorder = false;
            this.tabSangyongOrder.Name = "tabSangyongOrder";
            this.toolTip1.SetToolTip(this.tabSangyongOrder, resources.GetString("tabSangyongOrder.ToolTip"));
            this.tabSangyongOrder.SelectionChanged += new System.EventHandler(this.tabSangyongOrder_SelectionChanged);
            // 
            // pnlSlipHangmog
            // 
            this.pnlSlipHangmog.AccessibleDescription = null;
            this.pnlSlipHangmog.AccessibleName = null;
            resources.ApplyResources(this.pnlSlipHangmog, "pnlSlipHangmog");
            this.pnlSlipHangmog.BackgroundImage = null;
            this.pnlSlipHangmog.Controls.Add(this.grdSlipHangmog);
            this.pnlSlipHangmog.Controls.Add(this.tvwSlipCode);
            this.pnlSlipHangmog.Font = null;
            this.pnlSlipHangmog.Name = "pnlSlipHangmog";
            this.toolTip1.SetToolTip(this.pnlSlipHangmog, resources.GetString("pnlSlipHangmog.ToolTip"));
            // 
            // grdSlipHangmog
            // 
            resources.ApplyResources(this.grdSlipHangmog, "grdSlipHangmog");
            this.grdSlipHangmog.ApplyPaintEventToAllColumn = true;
            this.grdSlipHangmog.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell56,
            this.xEditGridCell57,
            this.xEditGridCell58,
            this.xEditGridCell26,
            this.xEditGridCell63});
            this.grdSlipHangmog.ColPerLine = 2;
            this.grdSlipHangmog.Cols = 2;
            this.grdSlipHangmog.ExecuteQuery = null;
            this.grdSlipHangmog.FixedRows = 1;
            this.grdSlipHangmog.HeaderHeights.Add(21);
            this.grdSlipHangmog.Name = "grdSlipHangmog";
            this.grdSlipHangmog.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSlipHangmog.ParamList")));
            this.grdSlipHangmog.QuerySQL = resources.GetString("grdSlipHangmog.QuerySQL");
            this.grdSlipHangmog.Rows = 2;
            this.grdSlipHangmog.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.toolTip1.SetToolTip(this.grdSlipHangmog, resources.GetString("grdSlipHangmog.ToolTip"));
            this.grdSlipHangmog.ToolTipActive = true;
            this.grdSlipHangmog.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdSlipHangmog_GiveFeedback);
            this.grdSlipHangmog.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdSlipHangmog_DragEnter);
            this.grdSlipHangmog.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdSlipHangmog_MouseDown);
            this.grdSlipHangmog.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdSlipHangmog_GridCellPainting);
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "hangmog_code";
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            this.xEditGridCell56.IsUpdatable = false;
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellName = "hangmog_name";
            this.xEditGridCell57.CellWidth = 200;
            this.xEditGridCell57.Col = 1;
            this.xEditGridCell57.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell57, "xEditGridCell57");
            this.xEditGridCell57.IsUpdatable = false;
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellName = "order_gubun";
            this.xEditGridCell58.Col = -1;
            this.xEditGridCell58.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell58, "xEditGridCell58");
            this.xEditGridCell58.IsUpdatable = false;
            this.xEditGridCell58.IsVisible = false;
            this.xEditGridCell58.Row = -1;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "order_gubun_name";
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsUpdatable = false;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.CellName = "trial_flg";
            this.xEditGridCell63.Col = -1;
            this.xEditGridCell63.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsVisible = false;
            this.xEditGridCell63.Row = -1;
            // 
            // tvwSlipCode
            // 
            this.tvwSlipCode.AccessibleDescription = null;
            this.tvwSlipCode.AccessibleName = null;
            resources.ApplyResources(this.tvwSlipCode, "tvwSlipCode");
            this.tvwSlipCode.BackgroundImage = null;
            this.tvwSlipCode.HideSelection = false;
            this.tvwSlipCode.ImageList = this.ImageList;
            this.tvwSlipCode.Name = "tvwSlipCode";
            this.tvwSlipCode.ShowRootLines = false;
            this.toolTip1.SetToolTip(this.tvwSlipCode, resources.GetString("tvwSlipCode.ToolTip"));
            this.tvwSlipCode.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwSlipCode_AfterSelect);
            // 
            // pnlSearch
            // 
            this.pnlSearch.AccessibleDescription = null;
            this.pnlSearch.AccessibleName = null;
            resources.ApplyResources(this.pnlSearch, "pnlSearch");
            this.pnlSearch.BackgroundImage = null;
            this.pnlSearch.Controls.Add(this.grdSearchOrder);
            this.pnlSearch.Font = null;
            this.pnlSearch.Name = "pnlSearch";
            this.toolTip1.SetToolTip(this.pnlSearch, resources.GetString("pnlSearch.ToolTip"));
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
            this.xEditGridCell25,
            this.xEditGridCell33,
            this.xEditGridCell64});
            this.grdSearchOrder.ColPerLine = 2;
            this.grdSearchOrder.Cols = 2;
            this.grdSearchOrder.ExecuteQuery = null;
            this.grdSearchOrder.FixedRows = 1;
            this.grdSearchOrder.HeaderHeights.Add(28);
            this.grdSearchOrder.Name = "grdSearchOrder";
            this.grdSearchOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSearchOrder.ParamList")));
            this.grdSearchOrder.QuerySQL = resources.GetString("grdSearchOrder.QuerySQL");
            this.grdSearchOrder.Rows = 2;
            this.toolTip1.SetToolTip(this.grdSearchOrder, resources.GetString("grdSearchOrder.ToolTip"));
            this.grdSearchOrder.ToolTipActive = true;
            this.grdSearchOrder.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdSangyongOrder_GiveFeedback);
            this.grdSearchOrder.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdSangyongOrder_DragEnter);
            this.grdSearchOrder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdSearchOrder_MouseDown);
            this.grdSearchOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdSearchOrder_GridCellPainting);
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "slip_code";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsReadOnly = true;
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "slip_name";
            this.xEditGridCell29.CellWidth = 97;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.SuppressRepeating = false;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "hangmog_code";
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsReadOnly = true;
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "hangmog_name";
            this.xEditGridCell31.CellWidth = 329;
            this.xEditGridCell31.Col = 1;
            this.xEditGridCell31.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsReadOnly = true;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "wonnae_drg_yn";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "hosp_code";
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsReadOnly = true;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellName = "trial_flg";
            this.xEditGridCell64.Col = -1;
            this.xEditGridCell64.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.IsVisible = false;
            this.xEditGridCell64.Row = -1;
            // 
            // xPanel8
            // 
            this.xPanel8.AccessibleDescription = null;
            this.xPanel8.AccessibleName = null;
            resources.ApplyResources(this.xPanel8, "xPanel8");
            this.xPanel8.BackgroundImage = null;
            this.xPanel8.Controls.Add(this.cboSearchCondition);
            this.xPanel8.Controls.Add(this.cboQueryCon);
            this.xPanel8.Controls.Add(this.xLabel2);
            this.xPanel8.Controls.Add(this.txtSearch);
            this.xPanel8.Controls.Add(this.xLabel5);
            this.xPanel8.Font = null;
            this.xPanel8.Name = "xPanel8";
            this.toolTip1.SetToolTip(this.xPanel8, resources.GetString("xPanel8.ToolTip"));
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
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            this.toolTip1.SetToolTip(this.xLabel2, resources.GetString("xLabel2.ToolTip"));
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
            // xPanel6
            // 
            this.xPanel6.AccessibleDescription = null;
            this.xPanel6.AccessibleName = null;
            resources.ApplyResources(this.xPanel6, "xPanel6");
            this.xPanel6.BackgroundImage = null;
            this.xPanel6.Controls.Add(this.btnInsert);
            this.xPanel6.Controls.Add(this.btnSelect);
            this.xPanel6.Controls.Add(this.btnNewSelect);
            this.xPanel6.Font = null;
            this.xPanel6.Name = "xPanel6";
            this.toolTip1.SetToolTip(this.xPanel6, resources.GetString("xPanel6.ToolTip"));
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
            this.btnSelect.ImageIndex = 12;
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
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackColor = IHIS.Framework.XColor.XRoundPanelBackColor;
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.rbnSlipHangmog);
            this.xPanel2.Controls.Add(this.rbnOftenOrder);
            this.xPanel2.Controls.Add(this.rbnSearchOrder);
            this.xPanel2.Controls.Add(this.btnExpandSearch);
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            this.toolTip1.SetToolTip(this.xPanel2, resources.GetString("xPanel2.ToolTip"));
            // 
            // rbnSlipHangmog
            // 
            this.rbnSlipHangmog.AccessibleDescription = null;
            this.rbnSlipHangmog.AccessibleName = null;
            resources.ApplyResources(this.rbnSlipHangmog, "rbnSlipHangmog");
            this.rbnSlipHangmog.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbnSlipHangmog.BackgroundImage = null;
            this.rbnSlipHangmog.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbnSlipHangmog.ImageList = this.ImageList;
            this.rbnSlipHangmog.Name = "rbnSlipHangmog";
            this.rbnSlipHangmog.TabStop = true;
            this.toolTip1.SetToolTip(this.rbnSlipHangmog, resources.GetString("rbnSlipHangmog.ToolTip"));
            this.rbnSlipHangmog.UseVisualStyleBackColor = false;
            this.rbnSlipHangmog.CheckedChanged += new System.EventHandler(this.OrderRadio_CheckedChanged);
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
            // pnlOrderInfo
            // 
            this.pnlOrderInfo.AccessibleDescription = null;
            this.pnlOrderInfo.AccessibleName = null;
            resources.ApplyResources(this.pnlOrderInfo, "pnlOrderInfo");
            this.pnlOrderInfo.BackgroundImage = null;
            this.pnlOrderInfo.Controls.Add(this.xPanel4);
            this.pnlOrderInfo.Controls.Add(this.pnlOrderDetail);
            this.pnlOrderInfo.Controls.Add(this.pnlOrderInput);
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
            this.xPanel4.Controls.Add(this.grdOrder);
            this.xPanel4.Font = null;
            this.xPanel4.Name = "xPanel4";
            this.toolTip1.SetToolTip(this.xPanel4, resources.GetString("xPanel4.ToolTip"));
            // 
            // grdOrder
            // 
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
            this.xEditGridCell1,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell3,
            this.xEditGridCell2,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell27,
            this.xEditGridCell32,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell55,
            this.xEditGridCell59,
            this.xEditGridCell60,
            this.xEditGridCell61,
            this.xEditGridCell65,
            this.xEditGridCell66,
            this.xEditGridCell67});
            this.grdOrder.ColPerLine = 22;
            this.grdOrder.Cols = 23;
            this.grdOrder.EnableMultiSelection = true;
            this.grdOrder.ExecuteQuery = null;
            this.grdOrder.FixedCols = 1;
            this.grdOrder.FixedRows = 1;
            this.grdOrder.HeaderHeights.Add(37);
            this.grdOrder.Name = "grdOrder";
            this.grdOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOrder.ParamList")));
            this.grdOrder.QuerySQL = resources.GetString("grdOrder.QuerySQL");
            this.grdOrder.RowHeaderVisible = true;
            this.grdOrder.Rows = 2;
            this.grdOrder.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOrder.SelectionModeChangeable = true;
            this.grdOrder.ShowNumberAtRowHeader = false;
            this.grdOrder.TogglingRowSelection = true;
            this.toolTip1.SetToolTip(this.grdOrder, resources.GetString("grdOrder.ToolTip"));
            this.grdOrder.ToolTipActive = true;
            this.grdOrder.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdOrder_GiveFeedback);
            this.grdOrder.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdOrder_MouseUp);
            this.grdOrder.Click += new System.EventHandler(this.grdOrder_Click);
            this.grdOrder.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOrder_GridColumnChanged);
            this.grdOrder.GridReservedMemoButtonClick += new IHIS.Framework.GridReservedMemoButtonClickEventHandler(this.grdOrder_GridReservedMemoButtonClick);
            this.grdOrder.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdOrder_DragEnter);
            this.grdOrder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOrder_MouseDown);
            this.grdOrder.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdOrder_DragDrop);
            this.grdOrder.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grdOrder_MouseMove);
            this.grdOrder.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdOrder_GridFindClick);
            this.grdOrder.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOrder_RowFocusChanged);
            this.grdOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOrder_GridCellPainting);
            this.grdOrder.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOrder_GridColumnProtectModify);
            // 
            // xEditGridCell351
            // 
            this.xEditGridCell351.CellName = "pkocskey";
            this.xEditGridCell351.Col = -1;
            this.xEditGridCell351.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell351, "xEditGridCell351");
            this.xEditGridCell351.IsVisible = false;
            this.xEditGridCell351.Row = -1;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "memb";
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "yaksok_code";
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // xEditGridCell358
            // 
            this.xEditGridCell358.CellName = "bunho";
            this.xEditGridCell358.Col = -1;
            this.xEditGridCell358.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell358, "xEditGridCell358");
            this.xEditGridCell358.IsVisible = false;
            this.xEditGridCell358.Row = -1;
            // 
            // xEditGridCell359
            // 
            this.xEditGridCell359.CellName = "in_out_key";
            this.xEditGridCell359.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell359.Col = -1;
            this.xEditGridCell359.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell359, "xEditGridCell359");
            this.xEditGridCell359.IsVisible = false;
            this.xEditGridCell359.Row = -1;
            // 
            // xEditGridCell360
            // 
            this.xEditGridCell360.CellName = "order_date";
            this.xEditGridCell360.Col = -1;
            this.xEditGridCell360.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell360, "xEditGridCell360");
            this.xEditGridCell360.IsVisible = false;
            this.xEditGridCell360.Row = -1;
            // 
            // xEditGridCell361
            // 
            this.xEditGridCell361.CellName = "order_time";
            this.xEditGridCell361.Col = -1;
            this.xEditGridCell361.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell361, "xEditGridCell361");
            this.xEditGridCell361.IsVisible = false;
            this.xEditGridCell361.Row = -1;
            // 
            // xEditGridCell362
            // 
            this.xEditGridCell362.CellName = "gwa";
            this.xEditGridCell362.Col = -1;
            this.xEditGridCell362.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell362, "xEditGridCell362");
            this.xEditGridCell362.IsVisible = false;
            this.xEditGridCell362.Row = -1;
            // 
            // xEditGridCell363
            // 
            this.xEditGridCell363.CellName = "doctor";
            this.xEditGridCell363.Col = -1;
            this.xEditGridCell363.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell363, "xEditGridCell363");
            this.xEditGridCell363.IsVisible = false;
            this.xEditGridCell363.Row = -1;
            // 
            // xEditGridCell364
            // 
            this.xEditGridCell364.CellName = "resident";
            this.xEditGridCell364.Col = -1;
            this.xEditGridCell364.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell364, "xEditGridCell364");
            this.xEditGridCell364.IsVisible = false;
            this.xEditGridCell364.Row = -1;
            // 
            // xEditGridCell365
            // 
            this.xEditGridCell365.CellName = "naewon_type";
            this.xEditGridCell365.Col = -1;
            this.xEditGridCell365.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell365, "xEditGridCell365");
            this.xEditGridCell365.IsVisible = false;
            this.xEditGridCell365.Row = -1;
            // 
            // xEditGridCell366
            // 
            this.xEditGridCell366.CellName = "input_id";
            this.xEditGridCell366.Col = -1;
            this.xEditGridCell366.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell366, "xEditGridCell366");
            this.xEditGridCell366.IsVisible = false;
            this.xEditGridCell366.Row = -1;
            // 
            // xEditGridCell367
            // 
            this.xEditGridCell367.CellName = "input_part";
            this.xEditGridCell367.Col = -1;
            this.xEditGridCell367.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell367, "xEditGridCell367");
            this.xEditGridCell367.IsVisible = false;
            this.xEditGridCell367.Row = -1;
            // 
            // xEditGridCell368
            // 
            this.xEditGridCell368.CellName = "input_gwa";
            this.xEditGridCell368.Col = -1;
            this.xEditGridCell368.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell368, "xEditGridCell368");
            this.xEditGridCell368.IsVisible = false;
            this.xEditGridCell368.Row = -1;
            // 
            // xEditGridCell369
            // 
            this.xEditGridCell369.CellName = "input_doctor";
            this.xEditGridCell369.Col = -1;
            this.xEditGridCell369.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell369, "xEditGridCell369");
            this.xEditGridCell369.IsVisible = false;
            this.xEditGridCell369.Row = -1;
            // 
            // xEditGridCell370
            // 
            this.xEditGridCell370.CellName = "input_gubun";
            this.xEditGridCell370.Col = -1;
            this.xEditGridCell370.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell370, "xEditGridCell370");
            this.xEditGridCell370.IsVisible = false;
            this.xEditGridCell370.Row = -1;
            // 
            // xEditGridCell371
            // 
            this.xEditGridCell371.CellName = "input_gubun_name";
            this.xEditGridCell371.Col = -1;
            this.xEditGridCell371.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell371, "xEditGridCell371");
            this.xEditGridCell371.IsReadOnly = true;
            this.xEditGridCell371.IsUpdatable = false;
            this.xEditGridCell371.IsUpdCol = false;
            this.xEditGridCell371.IsVisible = false;
            this.xEditGridCell371.Row = -1;
            // 
            // xEditGridCell372
            // 
            this.xEditGridCell372.CellName = "group_ser";
            this.xEditGridCell372.CellWidth = 27;
            this.xEditGridCell372.Col = -1;
            this.xEditGridCell372.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell372, "xEditGridCell372");
            this.xEditGridCell372.IsVisible = false;
            this.xEditGridCell372.Row = -1;
            this.xEditGridCell372.SuppressRepeating = false;
            // 
            // xEditGridCell373
            // 
            this.xEditGridCell373.CellName = "input_tab";
            this.xEditGridCell373.Col = -1;
            this.xEditGridCell373.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell373, "xEditGridCell373");
            this.xEditGridCell373.IsVisible = false;
            this.xEditGridCell373.Row = -1;
            // 
            // xEditGridCell374
            // 
            this.xEditGridCell374.CellName = "input_tab_name";
            this.xEditGridCell374.Col = -1;
            this.xEditGridCell374.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell374, "xEditGridCell374");
            this.xEditGridCell374.IsReadOnly = true;
            this.xEditGridCell374.IsUpdatable = false;
            this.xEditGridCell374.IsUpdCol = false;
            this.xEditGridCell374.IsVisible = false;
            this.xEditGridCell374.Row = -1;
            // 
            // xEditGridCell375
            // 
            this.xEditGridCell375.CellName = "order_gubun";
            this.xEditGridCell375.Col = -1;
            this.xEditGridCell375.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell375, "xEditGridCell375");
            this.xEditGridCell375.IsVisible = false;
            this.xEditGridCell375.Row = -1;
            // 
            // xEditGridCell376
            // 
            this.xEditGridCell376.CellName = "order_gubun_name";
            this.xEditGridCell376.CellWidth = 60;
            this.xEditGridCell376.Col = 3;
            this.xEditGridCell376.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell376, "xEditGridCell376");
            this.xEditGridCell376.IsReadOnly = true;
            this.xEditGridCell376.IsUpdatable = false;
            this.xEditGridCell376.IsUpdCol = false;
            this.xEditGridCell376.SuppressRepeating = false;
            // 
            // xEditGridCell377
            // 
            this.xEditGridCell377.CellName = "group_yn";
            this.xEditGridCell377.Col = -1;
            this.xEditGridCell377.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell377, "xEditGridCell377");
            this.xEditGridCell377.IsVisible = false;
            this.xEditGridCell377.Row = -1;
            // 
            // xEditGridCell378
            // 
            this.xEditGridCell378.CellName = "seq";
            this.xEditGridCell378.Col = -1;
            this.xEditGridCell378.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell378, "xEditGridCell378");
            this.xEditGridCell378.IsVisible = false;
            this.xEditGridCell378.Row = -1;
            // 
            // xEditGridCell379
            // 
            this.xEditGridCell379.CellName = "slip_code";
            this.xEditGridCell379.Col = -1;
            this.xEditGridCell379.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell379, "xEditGridCell379");
            this.xEditGridCell379.IsVisible = false;
            this.xEditGridCell379.Row = -1;
            // 
            // xEditGridCell380
            // 
            this.xEditGridCell380.AutoTabDataSelected = true;
            this.xEditGridCell380.CellLen = 100;
            this.xEditGridCell380.CellName = "hangmog_code";
            this.xEditGridCell380.CellWidth = 90;
            this.xEditGridCell380.Col = 4;
            this.xEditGridCell380.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell380.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell380, "xEditGridCell380");
            this.xEditGridCell380.ImeMode = IHIS.Framework.ColumnImeMode.Katakana;
            this.xEditGridCell380.IsNotNull = true;
            this.xEditGridCell380.IsUpdatable = false;
            this.xEditGridCell380.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell384
            // 
            this.xEditGridCell384.CellName = "hangmog_name";
            this.xEditGridCell384.CellWidth = 250;
            this.xEditGridCell384.Col = 5;
            this.xEditGridCell384.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell384, "xEditGridCell384");
            this.xEditGridCell384.IsReadOnly = true;
            this.xEditGridCell384.IsUpdatable = false;
            this.xEditGridCell384.IsUpdCol = false;
            // 
            // xEditGridCell385
            // 
            this.xEditGridCell385.CellName = "specimen_code";
            this.xEditGridCell385.CellWidth = 54;
            this.xEditGridCell385.Col = -1;
            this.xEditGridCell385.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell385, "xEditGridCell385");
            this.xEditGridCell385.IsVisible = false;
            this.xEditGridCell385.Row = -1;
            // 
            // xEditGridCell386
            // 
            this.xEditGridCell386.CellName = "specimen_name";
            this.xEditGridCell386.CellWidth = 100;
            this.xEditGridCell386.Col = -1;
            this.xEditGridCell386.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell386, "xEditGridCell386");
            this.xEditGridCell386.IsReadOnly = true;
            this.xEditGridCell386.IsUpdatable = false;
            this.xEditGridCell386.IsUpdCol = false;
            this.xEditGridCell386.IsVisible = false;
            this.xEditGridCell386.Row = -1;
            // 
            // xEditGridCell387
            // 
            this.xEditGridCell387.CellName = "suryang";
            this.xEditGridCell387.CellWidth = 66;
            this.xEditGridCell387.Col = 8;
            this.xEditGridCell387.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.xEditGridCell387.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell387.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell387, "xEditGridCell387");
            this.xEditGridCell387.IsNotNull = true;
            this.xEditGridCell387.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell388
            // 
            this.xEditGridCell388.CellName = "sunab_suryang";
            this.xEditGridCell388.Col = -1;
            this.xEditGridCell388.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell388, "xEditGridCell388");
            this.xEditGridCell388.IsVisible = false;
            this.xEditGridCell388.Row = -1;
            // 
            // xEditGridCell389
            // 
            this.xEditGridCell389.CellName = "subul_suryang";
            this.xEditGridCell389.Col = -1;
            this.xEditGridCell389.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell389, "xEditGridCell389");
            this.xEditGridCell389.IsVisible = false;
            this.xEditGridCell389.Row = -1;
            // 
            // xEditGridCell390
            // 
            this.xEditGridCell390.CellName = "ord_danui";
            this.xEditGridCell390.Col = -1;
            this.xEditGridCell390.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell390, "xEditGridCell390");
            this.xEditGridCell390.IsVisible = false;
            this.xEditGridCell390.Row = -1;
            // 
            // xEditGridCell391
            // 
            this.xEditGridCell391.AutoTabDataSelected = true;
            this.xEditGridCell391.CellName = "ord_danui_name";
            this.xEditGridCell391.CellWidth = 46;
            this.xEditGridCell391.Col = 9;
            this.xEditGridCell391.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell391.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell391, "xEditGridCell391");
            this.xEditGridCell391.IsUpdCol = false;
            // 
            // xEditGridCell392
            // 
            this.xEditGridCell392.CellName = "dv_time";
            this.xEditGridCell392.CellWidth = 25;
            this.xEditGridCell392.Col = -1;
            this.xEditGridCell392.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell392, "xEditGridCell392");
            this.xEditGridCell392.IsVisible = false;
            this.xEditGridCell392.Row = -1;
            // 
            // xEditGridCell393
            // 
            this.xEditGridCell393.CellName = "dv";
            this.xEditGridCell393.CellWidth = 42;
            this.xEditGridCell393.Col = -1;
            this.xEditGridCell393.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell393, "xEditGridCell393");
            this.xEditGridCell393.IsVisible = false;
            this.xEditGridCell393.Row = -1;
            // 
            // xEditGridCell394
            // 
            this.xEditGridCell394.CellName = "dv_1";
            this.xEditGridCell394.CellWidth = 45;
            this.xEditGridCell394.Col = -1;
            this.xEditGridCell394.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell394, "xEditGridCell394");
            this.xEditGridCell394.IsVisible = false;
            this.xEditGridCell394.Row = -1;
            // 
            // xEditGridCell395
            // 
            this.xEditGridCell395.CellName = "dv_2";
            this.xEditGridCell395.CellWidth = 45;
            this.xEditGridCell395.Col = -1;
            this.xEditGridCell395.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell395, "xEditGridCell395");
            this.xEditGridCell395.IsVisible = false;
            this.xEditGridCell395.Row = -1;
            // 
            // xEditGridCell396
            // 
            this.xEditGridCell396.CellName = "dv_3";
            this.xEditGridCell396.CellWidth = 45;
            this.xEditGridCell396.Col = -1;
            this.xEditGridCell396.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell396, "xEditGridCell396");
            this.xEditGridCell396.IsVisible = false;
            this.xEditGridCell396.Row = -1;
            // 
            // xEditGridCell397
            // 
            this.xEditGridCell397.CellName = "dv_4";
            this.xEditGridCell397.CellWidth = 45;
            this.xEditGridCell397.Col = -1;
            this.xEditGridCell397.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell397, "xEditGridCell397");
            this.xEditGridCell397.IsVisible = false;
            this.xEditGridCell397.Row = -1;
            // 
            // xEditGridCell398
            // 
            this.xEditGridCell398.CellName = "nalsu";
            this.xEditGridCell398.CellWidth = 59;
            this.xEditGridCell398.Col = 10;
            this.xEditGridCell398.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.xEditGridCell398.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell398.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell398, "xEditGridCell398");
            this.xEditGridCell398.IsNotNull = true;
            this.xEditGridCell398.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell399
            // 
            this.xEditGridCell399.CellName = "sunab_nalsu";
            this.xEditGridCell399.Col = -1;
            this.xEditGridCell399.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell399, "xEditGridCell399");
            this.xEditGridCell399.IsVisible = false;
            this.xEditGridCell399.Row = -1;
            // 
            // xEditGridCell400
            // 
            this.xEditGridCell400.CellName = "jusa";
            this.xEditGridCell400.CellWidth = 38;
            this.xEditGridCell400.Col = -1;
            this.xEditGridCell400.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell400, "xEditGridCell400");
            this.xEditGridCell400.IsVisible = false;
            this.xEditGridCell400.Row = -1;
            // 
            // xEditGridCell401
            // 
            this.xEditGridCell401.CellName = "jusa_name";
            this.xEditGridCell401.Col = -1;
            this.xEditGridCell401.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell401, "xEditGridCell401");
            this.xEditGridCell401.IsReadOnly = true;
            this.xEditGridCell401.IsUpdatable = false;
            this.xEditGridCell401.IsUpdCol = false;
            this.xEditGridCell401.IsVisible = false;
            this.xEditGridCell401.Row = -1;
            // 
            // xEditGridCell402
            // 
            this.xEditGridCell402.CellName = "jusa_spd_gubun";
            this.xEditGridCell402.CellWidth = 39;
            this.xEditGridCell402.Col = -1;
            this.xEditGridCell402.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell402, "xEditGridCell402");
            this.xEditGridCell402.IsVisible = false;
            this.xEditGridCell402.Row = -1;
            // 
            // xEditGridCell403
            // 
            this.xEditGridCell403.CellName = "bogyong_code";
            this.xEditGridCell403.CellWidth = 64;
            this.xEditGridCell403.Col = -1;
            this.xEditGridCell403.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell403, "xEditGridCell403");
            this.xEditGridCell403.IsVisible = false;
            this.xEditGridCell403.Row = -1;
            // 
            // xEditGridCell404
            // 
            this.xEditGridCell404.CellName = "bogyong_name";
            this.xEditGridCell404.CellWidth = 93;
            this.xEditGridCell404.Col = -1;
            this.xEditGridCell404.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell404, "xEditGridCell404");
            this.xEditGridCell404.IsReadOnly = true;
            this.xEditGridCell404.IsVisible = false;
            this.xEditGridCell404.Row = -1;
            // 
            // xEditGridCell405
            // 
            this.xEditGridCell405.CellName = "emergency";
            this.xEditGridCell405.CellWidth = 26;
            this.xEditGridCell405.Col = -1;
            this.xEditGridCell405.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell405, "xEditGridCell405");
            this.xEditGridCell405.IsVisible = false;
            this.xEditGridCell405.Row = -1;
            // 
            // xEditGridCell406
            // 
            this.xEditGridCell406.CellName = "jaeryo_jundal_yn";
            this.xEditGridCell406.Col = -1;
            this.xEditGridCell406.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell406, "xEditGridCell406");
            this.xEditGridCell406.IsVisible = false;
            this.xEditGridCell406.Row = -1;
            // 
            // xEditGridCell407
            // 
            this.xEditGridCell407.CellName = "jundal_table";
            this.xEditGridCell407.Col = -1;
            this.xEditGridCell407.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell407, "xEditGridCell407");
            this.xEditGridCell407.IsVisible = false;
            this.xEditGridCell407.Row = -1;
            // 
            // xEditGridCell408
            // 
            this.xEditGridCell408.AutoTabDataSelected = true;
            this.xEditGridCell408.CellName = "jundal_part";
            this.xEditGridCell408.CellWidth = 135;
            this.xEditGridCell408.Col = 16;
            this.xEditGridCell408.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell408.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell408, "xEditGridCell408");
            // 
            // xEditGridCell409
            // 
            this.xEditGridCell409.CellName = "move_part";
            this.xEditGridCell409.Col = -1;
            this.xEditGridCell409.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell409, "xEditGridCell409");
            this.xEditGridCell409.IsVisible = false;
            this.xEditGridCell409.Row = -1;
            // 
            // xEditGridCell410
            // 
            this.xEditGridCell410.CellName = "portable_yn";
            this.xEditGridCell410.Col = -1;
            this.xEditGridCell410.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell410, "xEditGridCell410");
            this.xEditGridCell410.IsVisible = false;
            this.xEditGridCell410.Row = -1;
            // 
            // xEditGridCell411
            // 
            this.xEditGridCell411.CellName = "powder_yn";
            this.xEditGridCell411.CellWidth = 31;
            this.xEditGridCell411.Col = -1;
            this.xEditGridCell411.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell411, "xEditGridCell411");
            this.xEditGridCell411.IsVisible = false;
            this.xEditGridCell411.Row = -1;
            // 
            // xEditGridCell412
            // 
            this.xEditGridCell412.CellName = "hubal_change_yn";
            this.xEditGridCell412.CellWidth = 40;
            this.xEditGridCell412.Col = -1;
            this.xEditGridCell412.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell412, "xEditGridCell412");
            this.xEditGridCell412.IsVisible = false;
            this.xEditGridCell412.Row = -1;
            // 
            // xEditGridCell413
            // 
            this.xEditGridCell413.CellName = "pharmacy";
            this.xEditGridCell413.CellWidth = 29;
            this.xEditGridCell413.Col = -1;
            this.xEditGridCell413.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell413, "xEditGridCell413");
            this.xEditGridCell413.IsVisible = false;
            this.xEditGridCell413.Row = -1;
            // 
            // xEditGridCell414
            // 
            this.xEditGridCell414.CellName = "drg_pack_yn";
            this.xEditGridCell414.CellWidth = 26;
            this.xEditGridCell414.Col = -1;
            this.xEditGridCell414.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell414, "xEditGridCell414");
            this.xEditGridCell414.IsVisible = false;
            this.xEditGridCell414.Row = -1;
            // 
            // xEditGridCell415
            // 
            this.xEditGridCell415.CellName = "muhyo";
            this.xEditGridCell415.CellWidth = 54;
            this.xEditGridCell415.Col = 13;
            this.xEditGridCell415.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell415.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell415, "xEditGridCell415");
            // 
            // xEditGridCell416
            // 
            this.xEditGridCell416.CellName = "prn_yn";
            this.xEditGridCell416.CellWidth = 29;
            this.xEditGridCell416.Col = -1;
            this.xEditGridCell416.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell416, "xEditGridCell416");
            this.xEditGridCell416.IsVisible = false;
            this.xEditGridCell416.Row = -1;
            // 
            // xEditGridCell417
            // 
            this.xEditGridCell417.CellName = "toiwon_drg_yn";
            this.xEditGridCell417.CellWidth = 29;
            this.xEditGridCell417.Col = -1;
            this.xEditGridCell417.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell417, "xEditGridCell417");
            this.xEditGridCell417.IsVisible = false;
            this.xEditGridCell417.Row = -1;
            // 
            // xEditGridCell418
            // 
            this.xEditGridCell418.CellName = "prn_nurse";
            this.xEditGridCell418.Col = -1;
            this.xEditGridCell418.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell418, "xEditGridCell418");
            this.xEditGridCell418.IsVisible = false;
            this.xEditGridCell418.Row = -1;
            // 
            // xEditGridCell419
            // 
            this.xEditGridCell419.CellName = "append_yn";
            this.xEditGridCell419.Col = -1;
            this.xEditGridCell419.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell419, "xEditGridCell419");
            this.xEditGridCell419.IsVisible = false;
            this.xEditGridCell419.Row = -1;
            // 
            // xEditGridCell420
            // 
            this.xEditGridCell420.CellLen = 2000;
            this.xEditGridCell420.CellName = "order_remark";
            this.xEditGridCell420.Col = 6;
            this.xEditGridCell420.DisplayMemoText = true;
            this.xEditGridCell420.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell420.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell420, "xEditGridCell420");
            this.xEditGridCell420.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell420.ReservedMemoClassName = "IHIS.OCS.ReservedComment";
            this.xEditGridCell420.ReservedMemoFileName = Application.StartupPath + "\\OCSA\\OCS.Lib.CommonForms.dll";
            this.xEditGridCell420.ShowReservedMemoButton = true;
            // 
            // xEditGridCell421
            // 
            this.xEditGridCell421.CellLen = 2000;
            this.xEditGridCell421.CellName = "nurse_remark";
            this.xEditGridCell421.CellWidth = 100;
            this.xEditGridCell421.Col = 19;
            this.xEditGridCell421.DisplayMemoText = true;
            this.xEditGridCell421.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell421.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell421, "xEditGridCell421");
            this.xEditGridCell421.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell421.ReservedMemoClassName = "IHIS.OCS.ReservedComment";
            this.xEditGridCell421.ReservedMemoFileName = Application.StartupPath + "\\OCSA\\OCS.Lib.CommonForms.dll";
            this.xEditGridCell421.ShowReservedMemoButton = true;
            // 
            // xEditGridCell422
            // 
            this.xEditGridCell422.CellName = "mix_group";
            this.xEditGridCell422.Col = -1;
            this.xEditGridCell422.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell422, "xEditGridCell422");
            this.xEditGridCell422.IsVisible = false;
            this.xEditGridCell422.Row = -1;
            // 
            // xEditGridCell423
            // 
            this.xEditGridCell423.CellName = "amt";
            this.xEditGridCell423.Col = -1;
            this.xEditGridCell423.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell423, "xEditGridCell423");
            this.xEditGridCell423.IsVisible = false;
            this.xEditGridCell423.Row = -1;
            // 
            // xEditGridCell424
            // 
            this.xEditGridCell424.CellName = "pay";
            this.xEditGridCell424.CellWidth = 51;
            this.xEditGridCell424.Col = -1;
            this.xEditGridCell424.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell424, "xEditGridCell424");
            this.xEditGridCell424.IsVisible = false;
            this.xEditGridCell424.Row = -1;
            // 
            // xEditGridCell425
            // 
            this.xEditGridCell425.CellName = "wonyoi_order_yn";
            this.xEditGridCell425.CellWidth = 65;
            this.xEditGridCell425.Col = 14;
            this.xEditGridCell425.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell425.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell425, "xEditGridCell425");
            // 
            // xEditGridCell426
            // 
            this.xEditGridCell426.CellName = "dangil_gumsa_order_yn";
            this.xEditGridCell426.CellWidth = 133;
            this.xEditGridCell426.Col = 11;
            this.xEditGridCell426.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell426.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell426, "xEditGridCell426");
            // 
            // xEditGridCell427
            // 
            this.xEditGridCell427.CellName = "dangil_gumsa_result_yn";
            this.xEditGridCell427.CellWidth = 94;
            this.xEditGridCell427.Col = 12;
            this.xEditGridCell427.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell427.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell427, "xEditGridCell427");
            // 
            // xEditGridCell428
            // 
            this.xEditGridCell428.CellName = "bom_occur_yn";
            this.xEditGridCell428.Col = -1;
            this.xEditGridCell428.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell428, "xEditGridCell428");
            this.xEditGridCell428.IsVisible = false;
            this.xEditGridCell428.Row = -1;
            // 
            // xEditGridCell429
            // 
            this.xEditGridCell429.CellName = "bom_source_key";
            this.xEditGridCell429.Col = -1;
            this.xEditGridCell429.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell429, "xEditGridCell429");
            this.xEditGridCell429.IsVisible = false;
            this.xEditGridCell429.Row = -1;
            // 
            // xEditGridCell430
            // 
            this.xEditGridCell430.CellName = "display_yn";
            this.xEditGridCell430.Col = -1;
            this.xEditGridCell430.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell430, "xEditGridCell430");
            this.xEditGridCell430.IsVisible = false;
            this.xEditGridCell430.Row = -1;
            // 
            // xEditGridCell431
            // 
            this.xEditGridCell431.CellName = "sunab_yn";
            this.xEditGridCell431.Col = -1;
            this.xEditGridCell431.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell431, "xEditGridCell431");
            this.xEditGridCell431.IsVisible = false;
            this.xEditGridCell431.Row = -1;
            // 
            // xEditGridCell432
            // 
            this.xEditGridCell432.CellName = "sunab_date";
            this.xEditGridCell432.Col = -1;
            this.xEditGridCell432.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell432, "xEditGridCell432");
            this.xEditGridCell432.IsVisible = false;
            this.xEditGridCell432.Row = -1;
            // 
            // xEditGridCell433
            // 
            this.xEditGridCell433.CellName = "sunab_time";
            this.xEditGridCell433.Col = -1;
            this.xEditGridCell433.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell433, "xEditGridCell433");
            this.xEditGridCell433.IsVisible = false;
            this.xEditGridCell433.Row = -1;
            // 
            // xEditGridCell434
            // 
            this.xEditGridCell434.CellName = "hope_date";
            this.xEditGridCell434.Col = 7;
            this.xEditGridCell434.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell434.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell434, "xEditGridCell434");
            // 
            // xEditGridCell435
            // 
            this.xEditGridCell435.CellName = "hope_time";
            this.xEditGridCell435.Col = -1;
            this.xEditGridCell435.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell435, "xEditGridCell435");
            this.xEditGridCell435.IsVisible = false;
            this.xEditGridCell435.Row = -1;
            // 
            // xEditGridCell436
            // 
            this.xEditGridCell436.CellName = "nurse_confirm_user";
            this.xEditGridCell436.Col = -1;
            this.xEditGridCell436.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell436, "xEditGridCell436");
            this.xEditGridCell436.IsVisible = false;
            this.xEditGridCell436.Row = -1;
            // 
            // xEditGridCell437
            // 
            this.xEditGridCell437.CellName = "nurse_confirm_date";
            this.xEditGridCell437.Col = -1;
            this.xEditGridCell437.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell437, "xEditGridCell437");
            this.xEditGridCell437.IsVisible = false;
            this.xEditGridCell437.Row = -1;
            // 
            // xEditGridCell438
            // 
            this.xEditGridCell438.CellName = "nurse_confirm_time";
            this.xEditGridCell438.Col = -1;
            this.xEditGridCell438.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell438, "xEditGridCell438");
            this.xEditGridCell438.IsVisible = false;
            this.xEditGridCell438.Row = -1;
            // 
            // xEditGridCell439
            // 
            this.xEditGridCell439.CellName = "nurse_pickup_user";
            this.xEditGridCell439.Col = -1;
            this.xEditGridCell439.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell439, "xEditGridCell439");
            this.xEditGridCell439.IsVisible = false;
            this.xEditGridCell439.Row = -1;
            // 
            // xEditGridCell440
            // 
            this.xEditGridCell440.CellName = "nurse_pickup_date";
            this.xEditGridCell440.Col = -1;
            this.xEditGridCell440.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell440, "xEditGridCell440");
            this.xEditGridCell440.IsVisible = false;
            this.xEditGridCell440.Row = -1;
            // 
            // xEditGridCell441
            // 
            this.xEditGridCell441.CellName = "nurse_pickup_time";
            this.xEditGridCell441.Col = -1;
            this.xEditGridCell441.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell441, "xEditGridCell441");
            this.xEditGridCell441.IsVisible = false;
            this.xEditGridCell441.Row = -1;
            // 
            // xEditGridCell442
            // 
            this.xEditGridCell442.CellName = "nurse_hold_user";
            this.xEditGridCell442.Col = -1;
            this.xEditGridCell442.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell442, "xEditGridCell442");
            this.xEditGridCell442.IsVisible = false;
            this.xEditGridCell442.Row = -1;
            // 
            // xEditGridCell443
            // 
            this.xEditGridCell443.CellName = "nurse_hold_date";
            this.xEditGridCell443.Col = -1;
            this.xEditGridCell443.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell443, "xEditGridCell443");
            this.xEditGridCell443.IsVisible = false;
            this.xEditGridCell443.Row = -1;
            // 
            // xEditGridCell444
            // 
            this.xEditGridCell444.CellName = "nurse_hold_time";
            this.xEditGridCell444.Col = -1;
            this.xEditGridCell444.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell444, "xEditGridCell444");
            this.xEditGridCell444.IsVisible = false;
            this.xEditGridCell444.Row = -1;
            // 
            // xEditGridCell445
            // 
            this.xEditGridCell445.CellName = "reser_date";
            this.xEditGridCell445.Col = -1;
            this.xEditGridCell445.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell445, "xEditGridCell445");
            this.xEditGridCell445.IsVisible = false;
            this.xEditGridCell445.Row = -1;
            // 
            // xEditGridCell446
            // 
            this.xEditGridCell446.CellName = "reser_time";
            this.xEditGridCell446.Col = -1;
            this.xEditGridCell446.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell446, "xEditGridCell446");
            this.xEditGridCell446.IsVisible = false;
            this.xEditGridCell446.Row = -1;
            // 
            // xEditGridCell447
            // 
            this.xEditGridCell447.CellName = "jubsu_date";
            this.xEditGridCell447.Col = -1;
            this.xEditGridCell447.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell447, "xEditGridCell447");
            this.xEditGridCell447.IsVisible = false;
            this.xEditGridCell447.Row = -1;
            // 
            // xEditGridCell448
            // 
            this.xEditGridCell448.CellName = "jubsu_time";
            this.xEditGridCell448.Col = -1;
            this.xEditGridCell448.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell448, "xEditGridCell448");
            this.xEditGridCell448.IsVisible = false;
            this.xEditGridCell448.Row = -1;
            // 
            // xEditGridCell449
            // 
            this.xEditGridCell449.CellName = "acting_date";
            this.xEditGridCell449.Col = -1;
            this.xEditGridCell449.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell449, "xEditGridCell449");
            this.xEditGridCell449.IsVisible = false;
            this.xEditGridCell449.Row = -1;
            // 
            // xEditGridCell450
            // 
            this.xEditGridCell450.CellName = "acting_time";
            this.xEditGridCell450.Col = -1;
            this.xEditGridCell450.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell450, "xEditGridCell450");
            this.xEditGridCell450.IsVisible = false;
            this.xEditGridCell450.Row = -1;
            // 
            // xEditGridCell451
            // 
            this.xEditGridCell451.CellName = "acting_day";
            this.xEditGridCell451.Col = -1;
            this.xEditGridCell451.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell451, "xEditGridCell451");
            this.xEditGridCell451.IsVisible = false;
            this.xEditGridCell451.Row = -1;
            // 
            // xEditGridCell452
            // 
            this.xEditGridCell452.CellName = "result_date";
            this.xEditGridCell452.Col = -1;
            this.xEditGridCell452.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell452, "xEditGridCell452");
            this.xEditGridCell452.IsVisible = false;
            this.xEditGridCell452.Row = -1;
            // 
            // xEditGridCell453
            // 
            this.xEditGridCell453.CellName = "dc_gubun";
            this.xEditGridCell453.CellWidth = 44;
            this.xEditGridCell453.Col = 2;
            this.xEditGridCell453.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell453.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell453, "xEditGridCell453");
            // 
            // xEditGridCell454
            // 
            this.xEditGridCell454.CellName = "dc_yn";
            this.xEditGridCell454.Col = -1;
            this.xEditGridCell454.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell454, "xEditGridCell454");
            this.xEditGridCell454.IsVisible = false;
            this.xEditGridCell454.Row = -1;
            // 
            // xEditGridCell455
            // 
            this.xEditGridCell455.CellName = "bannab_yn";
            this.xEditGridCell455.Col = -1;
            this.xEditGridCell455.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell455, "xEditGridCell455");
            this.xEditGridCell455.IsVisible = false;
            this.xEditGridCell455.Row = -1;
            // 
            // xEditGridCell456
            // 
            this.xEditGridCell456.CellName = "bannab_confirm";
            this.xEditGridCell456.Col = -1;
            this.xEditGridCell456.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell456, "xEditGridCell456");
            this.xEditGridCell456.IsVisible = false;
            this.xEditGridCell456.Row = -1;
            // 
            // xEditGridCell457
            // 
            this.xEditGridCell457.CellName = "source_ord_key";
            this.xEditGridCell457.Col = -1;
            this.xEditGridCell457.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell457, "xEditGridCell457");
            this.xEditGridCell457.IsVisible = false;
            this.xEditGridCell457.Row = -1;
            // 
            // xEditGridCell458
            // 
            this.xEditGridCell458.CellName = "ocs_flag";
            this.xEditGridCell458.Col = -1;
            this.xEditGridCell458.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell458, "xEditGridCell458");
            this.xEditGridCell458.IsVisible = false;
            this.xEditGridCell458.Row = -1;
            // 
            // xEditGridCell459
            // 
            this.xEditGridCell459.CellName = "sg_code";
            this.xEditGridCell459.Col = -1;
            this.xEditGridCell459.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell459, "xEditGridCell459");
            this.xEditGridCell459.IsVisible = false;
            this.xEditGridCell459.Row = -1;
            // 
            // xEditGridCell460
            // 
            this.xEditGridCell460.CellName = "sg_ymd";
            this.xEditGridCell460.Col = -1;
            this.xEditGridCell460.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell460, "xEditGridCell460");
            this.xEditGridCell460.IsVisible = false;
            this.xEditGridCell460.Row = -1;
            // 
            // xEditGridCell461
            // 
            this.xEditGridCell461.CellName = "io_gubun";
            this.xEditGridCell461.Col = -1;
            this.xEditGridCell461.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell461, "xEditGridCell461");
            this.xEditGridCell461.IsVisible = false;
            this.xEditGridCell461.Row = -1;
            // 
            // xEditGridCell464
            // 
            this.xEditGridCell464.CellName = "after_act_yn";
            this.xEditGridCell464.Col = -1;
            this.xEditGridCell464.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell464, "xEditGridCell464");
            this.xEditGridCell464.IsVisible = false;
            this.xEditGridCell464.Row = -1;
            // 
            // xEditGridCell465
            // 
            this.xEditGridCell465.CellName = "bichi_yn";
            this.xEditGridCell465.CellWidth = 52;
            this.xEditGridCell465.Col = 15;
            this.xEditGridCell465.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell465.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell465, "xEditGridCell465");
            // 
            // xEditGridCell466
            // 
            this.xEditGridCell466.CellName = "drg_bunho";
            this.xEditGridCell466.Col = -1;
            this.xEditGridCell466.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell466, "xEditGridCell466");
            this.xEditGridCell466.IsVisible = false;
            this.xEditGridCell466.Row = -1;
            // 
            // xEditGridCell467
            // 
            this.xEditGridCell467.CellName = "sub_susul";
            this.xEditGridCell467.Col = -1;
            this.xEditGridCell467.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell467, "xEditGridCell467");
            this.xEditGridCell467.IsVisible = false;
            this.xEditGridCell467.Row = -1;
            // 
            // xEditGridCell468
            // 
            this.xEditGridCell468.CellName = "print_yn";
            this.xEditGridCell468.Col = -1;
            this.xEditGridCell468.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell468, "xEditGridCell468");
            this.xEditGridCell468.IsVisible = false;
            this.xEditGridCell468.Row = -1;
            // 
            // xEditGridCell469
            // 
            this.xEditGridCell469.CellName = "chisik";
            this.xEditGridCell469.Col = -1;
            this.xEditGridCell469.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell469, "xEditGridCell469");
            this.xEditGridCell469.IsVisible = false;
            this.xEditGridCell469.Row = -1;
            // 
            // xEditGridCell470
            // 
            this.xEditGridCell470.CellName = "sanmo_fkinp1001";
            this.xEditGridCell470.Col = -1;
            this.xEditGridCell470.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell470, "xEditGridCell470");
            this.xEditGridCell470.IsVisible = false;
            this.xEditGridCell470.Row = -1;
            // 
            // xEditGridCell471
            // 
            this.xEditGridCell471.CellName = "tel_yn";
            this.xEditGridCell471.Col = -1;
            this.xEditGridCell471.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell471, "xEditGridCell471");
            this.xEditGridCell471.IsVisible = false;
            this.xEditGridCell471.Row = -1;
            // 
            // xEditGridCell472
            // 
            this.xEditGridCell472.CellName = "order_gubun_bas";
            this.xEditGridCell472.Col = -1;
            this.xEditGridCell472.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell472, "xEditGridCell472");
            this.xEditGridCell472.IsVisible = false;
            this.xEditGridCell472.Row = -1;
            // 
            // xEditGridCell473
            // 
            this.xEditGridCell473.CellName = "input_control";
            this.xEditGridCell473.Col = -1;
            this.xEditGridCell473.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell473, "xEditGridCell473");
            this.xEditGridCell473.IsVisible = false;
            this.xEditGridCell473.Row = -1;
            // 
            // xEditGridCell474
            // 
            this.xEditGridCell474.CellName = "suga_yn";
            this.xEditGridCell474.Col = -1;
            this.xEditGridCell474.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell474, "xEditGridCell474");
            this.xEditGridCell474.IsVisible = false;
            this.xEditGridCell474.Row = -1;
            // 
            // xEditGridCell475
            // 
            this.xEditGridCell475.CellName = "jaeryo_yn";
            this.xEditGridCell475.Col = -1;
            this.xEditGridCell475.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell475, "xEditGridCell475");
            this.xEditGridCell475.IsVisible = false;
            this.xEditGridCell475.Row = -1;
            // 
            // xEditGridCell476
            // 
            this.xEditGridCell476.CellName = "wonyoi_check";
            this.xEditGridCell476.Col = -1;
            this.xEditGridCell476.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell476, "xEditGridCell476");
            this.xEditGridCell476.IsVisible = false;
            this.xEditGridCell476.Row = -1;
            // 
            // xEditGridCell477
            // 
            this.xEditGridCell477.CellName = "emergency_check";
            this.xEditGridCell477.Col = -1;
            this.xEditGridCell477.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell477, "xEditGridCell477");
            this.xEditGridCell477.IsVisible = false;
            this.xEditGridCell477.Row = -1;
            // 
            // xEditGridCell478
            // 
            this.xEditGridCell478.CellName = "specimen_check";
            this.xEditGridCell478.Col = -1;
            this.xEditGridCell478.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell478, "xEditGridCell478");
            this.xEditGridCell478.IsVisible = false;
            this.xEditGridCell478.Row = -1;
            // 
            // xEditGridCell479
            // 
            this.xEditGridCell479.CellName = "portable_check";
            this.xEditGridCell479.Col = -1;
            this.xEditGridCell479.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell479, "xEditGridCell479");
            this.xEditGridCell479.IsVisible = false;
            this.xEditGridCell479.Row = -1;
            // 
            // xEditGridCell480
            // 
            this.xEditGridCell480.CellName = "bulyong_check";
            this.xEditGridCell480.Col = -1;
            this.xEditGridCell480.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell480, "xEditGridCell480");
            this.xEditGridCell480.IsVisible = false;
            this.xEditGridCell480.Row = -1;
            // 
            // xEditGridCell481
            // 
            this.xEditGridCell481.CellName = "sunab_check";
            this.xEditGridCell481.Col = -1;
            this.xEditGridCell481.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell481, "xEditGridCell481");
            this.xEditGridCell481.IsVisible = false;
            this.xEditGridCell481.Row = -1;
            // 
            // xEditGridCell482
            // 
            this.xEditGridCell482.CellName = "dc_check";
            this.xEditGridCell482.Col = -1;
            this.xEditGridCell482.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell482, "xEditGridCell482");
            this.xEditGridCell482.IsVisible = false;
            this.xEditGridCell482.Row = -1;
            // 
            // xEditGridCell483
            // 
            this.xEditGridCell483.CellName = "dc_gubun_check";
            this.xEditGridCell483.Col = -1;
            this.xEditGridCell483.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell483, "xEditGridCell483");
            this.xEditGridCell483.IsVisible = false;
            this.xEditGridCell483.Row = -1;
            // 
            // xEditGridCell484
            // 
            this.xEditGridCell484.CellName = "confirm_check";
            this.xEditGridCell484.Col = -1;
            this.xEditGridCell484.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell484, "xEditGridCell484");
            this.xEditGridCell484.IsVisible = false;
            this.xEditGridCell484.Row = -1;
            // 
            // xEditGridCell485
            // 
            this.xEditGridCell485.CellName = "reser_yn_check";
            this.xEditGridCell485.Col = -1;
            this.xEditGridCell485.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell485, "xEditGridCell485");
            this.xEditGridCell485.IsVisible = false;
            this.xEditGridCell485.Row = -1;
            // 
            // xEditGridCell486
            // 
            this.xEditGridCell486.CellName = "chisik_check";
            this.xEditGridCell486.Col = -1;
            this.xEditGridCell486.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell486, "xEditGridCell486");
            this.xEditGridCell486.IsVisible = false;
            this.xEditGridCell486.Row = -1;
            // 
            // xEditGridCell487
            // 
            this.xEditGridCell487.CellName = "nday_yn";
            this.xEditGridCell487.Col = -1;
            this.xEditGridCell487.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell487, "xEditGridCell487");
            this.xEditGridCell487.IsVisible = false;
            this.xEditGridCell487.Row = -1;
            // 
            // xEditGridCell488
            // 
            this.xEditGridCell488.CellName = "default_jaeryo_jundal_yn";
            this.xEditGridCell488.Col = -1;
            this.xEditGridCell488.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell488, "xEditGridCell488");
            this.xEditGridCell488.IsVisible = false;
            this.xEditGridCell488.Row = -1;
            // 
            // xEditGridCell489
            // 
            this.xEditGridCell489.CellName = "default_wonyoi_order_yn";
            this.xEditGridCell489.Col = -1;
            this.xEditGridCell489.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell489, "xEditGridCell489");
            this.xEditGridCell489.IsVisible = false;
            this.xEditGridCell489.Row = -1;
            // 
            // xEditGridCell490
            // 
            this.xEditGridCell490.CellName = "specific_comment";
            this.xEditGridCell490.Col = -1;
            this.xEditGridCell490.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell490, "xEditGridCell490");
            this.xEditGridCell490.IsVisible = false;
            this.xEditGridCell490.Row = -1;
            // 
            // xEditGridCell491
            // 
            this.xEditGridCell491.CellName = "specific_comment_name";
            this.xEditGridCell491.Col = -1;
            this.xEditGridCell491.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell491, "xEditGridCell491");
            this.xEditGridCell491.IsVisible = false;
            this.xEditGridCell491.Row = -1;
            // 
            // xEditGridCell492
            // 
            this.xEditGridCell492.CellName = "specific_comment_sys_id";
            this.xEditGridCell492.Col = -1;
            this.xEditGridCell492.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell492, "xEditGridCell492");
            this.xEditGridCell492.IsVisible = false;
            this.xEditGridCell492.Row = -1;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "specific_comment_pgm_id";
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "specific_comment_not_null";
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "specific_comment_table_id";
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "specific_comment_col_id";
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "donbog_yn";
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "order_gubun_bas_name";
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "act_doctor";
            this.xEditGridCell45.Col = -1;
            this.xEditGridCell45.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.IsVisible = false;
            this.xEditGridCell45.Row = -1;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "act_buseo";
            this.xEditGridCell46.Col = -1;
            this.xEditGridCell46.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "act_gwa";
            this.xEditGridCell47.Col = -1;
            this.xEditGridCell47.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsVisible = false;
            this.xEditGridCell47.Row = -1;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "home_care_yn";
            this.xEditGridCell48.CellWidth = 49;
            this.xEditGridCell48.Col = 20;
            this.xEditGridCell48.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell48.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "regular_yn";
            this.xEditGridCell49.CellWidth = 30;
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "sort_fkocskey";
            this.xEditGridCell53.Col = -1;
            this.xEditGridCell53.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell54.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell54.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell54.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell54.CellName = "parent_gubun";
            this.xEditGridCell54.CellWidth = 21;
            this.xEditGridCell54.Col = 1;
            this.xEditGridCell54.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.IsReadOnly = true;
            this.xEditGridCell54.IsUpdatable = false;
            this.xEditGridCell54.IsUpdCol = false;
            this.xEditGridCell54.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell54.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell54.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "child_yn";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "jusbu_no";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "if_input_control";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "ref_fkocs2003";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "jaewonil";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "app_yn";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "order_end_yn";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "dummy";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "org_key";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "parent_key";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "bun_code";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "cp_code";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "cp_path_code";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "memb_gubun";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "wonnae_drg_yn";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "jundal_table_out";
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "jundal_part_out";
            this.xEditGridCell32.CellWidth = 187;
            this.xEditGridCell32.Col = 17;
            this.xEditGridCell32.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell32.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "jundal_table_inp";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "jundal_part_inp";
            this.xEditGridCell37.CellWidth = 180;
            this.xEditGridCell37.Col = 18;
            this.xEditGridCell37.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell37.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellName = "move_part_out";
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "move_part_inp";
            this.xEditGridCell55.Col = -1;
            this.xEditGridCell55.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.IsVisible = false;
            this.xEditGridCell55.Row = -1;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellName = "instead_yn";
            this.xEditGridCell59.CellWidth = 48;
            this.xEditGridCell59.Col = 21;
            this.xEditGridCell59.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem3,
            this.xComboItem4});
            this.xEditGridCell59.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell59.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
            this.xEditGridCell59.IsReadOnly = true;
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
            // xEditGridCell60
            // 
            this.xEditGridCell60.CellName = "approve_yn";
            this.xEditGridCell60.CellWidth = 65;
            this.xEditGridCell60.Col = 22;
            this.xEditGridCell60.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem5,
            this.xComboItem6});
            this.xEditGridCell60.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell60.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsReadOnly = true;
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
            // xEditGridCell61
            // 
            this.xEditGridCell61.CellName = "postapprove_yn";
            this.xEditGridCell61.Col = -1;
            this.xEditGridCell61.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.IsReadOnly = true;
            this.xEditGridCell61.IsVisible = false;
            this.xEditGridCell61.Row = -1;
            // 
            // pnlOrderDetail
            // 
            this.pnlOrderDetail.AccessibleDescription = null;
            this.pnlOrderDetail.AccessibleName = null;
            resources.ApplyResources(this.pnlOrderDetail, "pnlOrderDetail");
            this.pnlOrderDetail.Controls.Add(this.btnSpecificComment);
            this.pnlOrderDetail.Controls.Add(this.btnSetOrder);
            this.pnlOrderDetail.Controls.Add(this.btnDoOrder);
            this.pnlOrderDetail.Controls.Add(this.btnExtend);
            this.pnlOrderDetail.Controls.Add(this.cbxEmergency);
            this.pnlOrderDetail.Controls.Add(this.xLabel3);
            this.pnlOrderDetail.DrawBorder = true;
            this.pnlOrderDetail.Font = null;
            this.pnlOrderDetail.Name = "pnlOrderDetail";
            this.toolTip1.SetToolTip(this.pnlOrderDetail, resources.GetString("pnlOrderDetail.ToolTip"));
            // 
            // btnSpecificComment
            // 
            this.btnSpecificComment.AccessibleDescription = null;
            this.btnSpecificComment.AccessibleName = null;
            resources.ApplyResources(this.btnSpecificComment, "btnSpecificComment");
            this.btnSpecificComment.BackgroundImage = null;
            this.btnSpecificComment.Image = ((System.Drawing.Image)(resources.GetObject("btnSpecificComment.Image")));
            this.btnSpecificComment.Name = "btnSpecificComment";
            this.btnSpecificComment.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.toolTip1.SetToolTip(this.btnSpecificComment, resources.GetString("btnSpecificComment.ToolTip"));
            this.btnSpecificComment.Click += new System.EventHandler(this.btnSpecificComment_Click);
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
            this.xLabel3.BackColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xLabel3.ForeColor = IHIS.Framework.XColor.XCalendarHeaderTextColor;
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            this.toolTip1.SetToolTip(this.xLabel3, resources.GetString("xLabel3.ToolTip"));
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
            this.tabGroup.Font = null;
            this.tabGroup.IDEPixelArea = true;
            this.tabGroup.IDEPixelBorder = false;
            this.tabGroup.Name = "tabGroup";
            this.toolTip1.SetToolTip(this.tabGroup, resources.GetString("tabGroup.ToolTip"));
            this.tabGroup.SelectionChanged += new System.EventHandler(this.tabGroup_SelectionChanged);
            this.tabGroup.ClosePressed += new System.EventHandler(this.tabGroup_ClosePressed);
            this.tabGroup.SelectionChanging += new System.EventHandler(this.tabGroup_SelectionChanging);
            // 
            // xGridHeader1
            // 
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
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
            this.imageListPopupMenu.Images.SetKeyName(8, "로테이트.gif");
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
            this.xEditGridCell493.CellName = "specific_comment_sys_id";
            this.xEditGridCell493.Col = -1;
            this.xEditGridCell493.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell493, "xEditGridCell493");
            this.xEditGridCell493.IsVisible = false;
            this.xEditGridCell493.Row = -1;
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
            // xEditGridCell50
            // 
            this.xEditGridCell50.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            // 
            // ImageGrouping
            // 
            this.ImageGrouping.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageGrouping.ImageStream")));
            this.ImageGrouping.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageGrouping.Images.SetKeyName(0, "AcroRd32_252.ico");
            this.ImageGrouping.Images.SetKeyName(1, "오른쪽_회색1.gif");
            // 
            // laySlipCodeTree
            // 
            this.laySlipCodeTree.ExecuteQuery = null;
            this.laySlipCodeTree.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem151,
            this.multiLayoutItem152,
            this.multiLayoutItem153,
            this.multiLayoutItem154});
            this.laySlipCodeTree.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySlipCodeTree.ParamList")));
            this.laySlipCodeTree.QuerySQL = resources.GetString("laySlipCodeTree.QuerySQL");
            // 
            // multiLayoutItem151
            // 
            this.multiLayoutItem151.DataName = "code";
            // 
            // multiLayoutItem152
            // 
            this.multiLayoutItem152.DataName = "code_name";
            // 
            // multiLayoutItem153
            // 
            this.multiLayoutItem153.DataName = "code1";
            // 
            // multiLayoutItem154
            // 
            this.multiLayoutItem154.DataName = "code_name1";
            // 
            // lyReserCanDate
            // 
            this.lyReserCanDate.ExecuteQuery = null;
            this.lyReserCanDate.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.lyReserCanDate.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("lyReserCanDate.ParamList")));
            this.lyReserCanDate.QuerySQL = "SELECT FN_OCS_CHECK_CAN_RESER_DATE(:f_date, :f_doctor) FROM SYS.DUAL";
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "result";
            this.singleLayoutItem1.IsUpdItem = true;
            // 
            // laySaveLayout
            // 
            this.laySaveLayout.CallerID = '3';
            this.laySaveLayout.ExecuteQuery = null;
            this.laySaveLayout.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
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
            this.multiLayoutItem34,
            this.multiLayoutItem35,
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
            this.multiLayoutItem698,
            this.multiLayoutItem699,
            this.multiLayoutItem700,
            this.multiLayoutItem711,
            this.multiLayoutItem719,
            this.multiLayoutItem720,
            this.multiLayoutItem725,
            this.multiLayoutItem1019});
            this.laySaveLayout.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySaveLayout.ParamList")));
            this.laySaveLayout.UseDefaultTransaction = false;
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "in_out_key";
            this.multiLayoutItem9.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem9.IsUpdItem = true;
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "pkocskey";
            this.multiLayoutItem10.IsUpdItem = true;
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "bunho";
            this.multiLayoutItem11.IsUpdItem = true;
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "order_date";
            this.multiLayoutItem12.IsUpdItem = true;
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "gwa";
            this.multiLayoutItem18.IsUpdItem = true;
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "doctor";
            this.multiLayoutItem19.IsUpdItem = true;
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "resident";
            this.multiLayoutItem20.IsUpdItem = true;
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "naewon_type";
            this.multiLayoutItem21.IsUpdItem = true;
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "jubsu_no";
            this.multiLayoutItem22.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem22.IsUpdItem = true;
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "input_id";
            this.multiLayoutItem23.IsUpdItem = true;
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "input_part";
            this.multiLayoutItem24.IsUpdItem = true;
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "input_gwa";
            this.multiLayoutItem25.IsUpdItem = true;
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "input_doctor";
            this.multiLayoutItem26.IsUpdItem = true;
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "input_gubun";
            this.multiLayoutItem27.IsUpdItem = true;
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "input_gubun_name";
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "group_ser";
            this.multiLayoutItem29.IsUpdItem = true;
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "input_tab";
            this.multiLayoutItem30.IsUpdItem = true;
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "input_tab_name";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "order_gubun";
            this.multiLayoutItem32.IsUpdItem = true;
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "order_gubun_name";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "group_yn";
            this.multiLayoutItem34.IsUpdItem = true;
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "seq";
            this.multiLayoutItem35.IsUpdItem = true;
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "slip_code";
            this.multiLayoutItem36.IsUpdItem = true;
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "hangmog_code";
            this.multiLayoutItem37.IsUpdItem = true;
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "hangmog_name";
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "specimen_code";
            this.multiLayoutItem39.IsUpdItem = true;
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "specimen_name";
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "suryang";
            this.multiLayoutItem41.IsUpdItem = true;
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "sunab_suryang";
            this.multiLayoutItem42.IsUpdItem = true;
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "subul_suryang";
            this.multiLayoutItem43.IsUpdItem = true;
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "ord_danui";
            this.multiLayoutItem44.IsUpdItem = true;
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "ord_danui_name";
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "dv_time";
            this.multiLayoutItem46.IsUpdItem = true;
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "dv";
            this.multiLayoutItem47.IsUpdItem = true;
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "dv_1";
            this.multiLayoutItem48.IsUpdItem = true;
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "dv_2";
            this.multiLayoutItem49.IsUpdItem = true;
            // 
            // multiLayoutItem50
            // 
            this.multiLayoutItem50.DataName = "dv_3";
            this.multiLayoutItem50.IsUpdItem = true;
            // 
            // multiLayoutItem51
            // 
            this.multiLayoutItem51.DataName = "dv_4";
            this.multiLayoutItem51.IsUpdItem = true;
            // 
            // multiLayoutItem52
            // 
            this.multiLayoutItem52.DataName = "nalsu";
            this.multiLayoutItem52.IsUpdItem = true;
            // 
            // multiLayoutItem53
            // 
            this.multiLayoutItem53.DataName = "sunab_nalsu";
            this.multiLayoutItem53.IsUpdItem = true;
            // 
            // multiLayoutItem54
            // 
            this.multiLayoutItem54.DataName = "jusa";
            this.multiLayoutItem54.IsUpdItem = true;
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "jusa_name";
            this.multiLayoutItem55.IsUpdItem = true;
            // 
            // multiLayoutItem56
            // 
            this.multiLayoutItem56.DataName = "jusa_spd_gubun";
            this.multiLayoutItem56.IsUpdItem = true;
            // 
            // multiLayoutItem57
            // 
            this.multiLayoutItem57.DataName = "bogyong_code";
            this.multiLayoutItem57.IsUpdItem = true;
            // 
            // multiLayoutItem58
            // 
            this.multiLayoutItem58.DataName = "bogyong_name";
            this.multiLayoutItem58.IsUpdItem = true;
            // 
            // multiLayoutItem59
            // 
            this.multiLayoutItem59.DataName = "emergency";
            this.multiLayoutItem59.IsUpdItem = true;
            // 
            // multiLayoutItem60
            // 
            this.multiLayoutItem60.DataName = "jaeryo_jundal_yn";
            this.multiLayoutItem60.IsUpdItem = true;
            // 
            // multiLayoutItem61
            // 
            this.multiLayoutItem61.DataName = "jundal_table";
            this.multiLayoutItem61.IsUpdItem = true;
            // 
            // multiLayoutItem62
            // 
            this.multiLayoutItem62.DataName = "jundal_part";
            this.multiLayoutItem62.IsUpdItem = true;
            // 
            // multiLayoutItem63
            // 
            this.multiLayoutItem63.DataName = "move_part";
            this.multiLayoutItem63.IsUpdItem = true;
            // 
            // multiLayoutItem64
            // 
            this.multiLayoutItem64.DataName = "portable_yn";
            this.multiLayoutItem64.IsUpdItem = true;
            // 
            // multiLayoutItem65
            // 
            this.multiLayoutItem65.DataName = "powder_yn";
            this.multiLayoutItem65.IsUpdItem = true;
            // 
            // multiLayoutItem66
            // 
            this.multiLayoutItem66.DataName = "hubal_change_yn";
            this.multiLayoutItem66.IsUpdItem = true;
            // 
            // multiLayoutItem67
            // 
            this.multiLayoutItem67.DataName = "pharmacy";
            this.multiLayoutItem67.IsUpdItem = true;
            // 
            // multiLayoutItem68
            // 
            this.multiLayoutItem68.DataName = "drg_pack_yn";
            this.multiLayoutItem68.IsUpdItem = true;
            // 
            // multiLayoutItem69
            // 
            this.multiLayoutItem69.DataName = "muhyo";
            this.multiLayoutItem69.IsUpdItem = true;
            // 
            // multiLayoutItem70
            // 
            this.multiLayoutItem70.DataName = "prn_yn";
            this.multiLayoutItem70.IsUpdItem = true;
            // 
            // multiLayoutItem71
            // 
            this.multiLayoutItem71.DataName = "toiwon_drg_yn";
            this.multiLayoutItem71.IsUpdItem = true;
            // 
            // multiLayoutItem72
            // 
            this.multiLayoutItem72.DataName = "prn_nurse";
            this.multiLayoutItem72.IsUpdItem = true;
            // 
            // multiLayoutItem73
            // 
            this.multiLayoutItem73.DataName = "append_yn";
            this.multiLayoutItem73.IsUpdItem = true;
            // 
            // multiLayoutItem74
            // 
            this.multiLayoutItem74.DataName = "order_remark";
            this.multiLayoutItem74.IsUpdItem = true;
            // 
            // multiLayoutItem75
            // 
            this.multiLayoutItem75.DataName = "nurse_remark";
            this.multiLayoutItem75.IsUpdItem = true;
            // 
            // multiLayoutItem76
            // 
            this.multiLayoutItem76.DataName = "comment";
            this.multiLayoutItem76.IsUpdItem = true;
            // 
            // multiLayoutItem77
            // 
            this.multiLayoutItem77.DataName = "mix_group";
            this.multiLayoutItem77.IsUpdItem = true;
            // 
            // multiLayoutItem78
            // 
            this.multiLayoutItem78.DataName = "amt";
            this.multiLayoutItem78.IsUpdItem = true;
            // 
            // multiLayoutItem79
            // 
            this.multiLayoutItem79.DataName = "pay";
            this.multiLayoutItem79.IsUpdItem = true;
            // 
            // multiLayoutItem80
            // 
            this.multiLayoutItem80.DataName = "wonyoi_order_yn";
            this.multiLayoutItem80.IsUpdItem = true;
            // 
            // multiLayoutItem81
            // 
            this.multiLayoutItem81.DataName = "dangil_gumsa_order_yn";
            this.multiLayoutItem81.IsUpdItem = true;
            // 
            // multiLayoutItem82
            // 
            this.multiLayoutItem82.DataName = "dangil_gumsa_result_yn";
            this.multiLayoutItem82.IsUpdItem = true;
            // 
            // multiLayoutItem83
            // 
            this.multiLayoutItem83.DataName = "bom_occur_yn";
            this.multiLayoutItem83.IsUpdItem = true;
            // 
            // multiLayoutItem84
            // 
            this.multiLayoutItem84.DataName = "bom_source_key";
            this.multiLayoutItem84.IsUpdItem = true;
            // 
            // multiLayoutItem85
            // 
            this.multiLayoutItem85.DataName = "display_yn";
            this.multiLayoutItem85.IsUpdItem = true;
            // 
            // multiLayoutItem86
            // 
            this.multiLayoutItem86.DataName = "sunab_yn";
            this.multiLayoutItem86.IsUpdItem = true;
            // 
            // multiLayoutItem87
            // 
            this.multiLayoutItem87.DataName = "sunab_date";
            this.multiLayoutItem87.IsUpdItem = true;
            // 
            // multiLayoutItem88
            // 
            this.multiLayoutItem88.DataName = "sunab_time";
            this.multiLayoutItem88.IsUpdItem = true;
            // 
            // multiLayoutItem89
            // 
            this.multiLayoutItem89.DataName = "hope_date";
            this.multiLayoutItem89.IsUpdItem = true;
            // 
            // multiLayoutItem90
            // 
            this.multiLayoutItem90.DataName = "hope_time";
            this.multiLayoutItem90.IsUpdItem = true;
            // 
            // multiLayoutItem91
            // 
            this.multiLayoutItem91.DataName = "nurse_confirm_user";
            this.multiLayoutItem91.IsUpdItem = true;
            // 
            // multiLayoutItem92
            // 
            this.multiLayoutItem92.DataName = "nurse_confirm_date";
            this.multiLayoutItem92.IsUpdItem = true;
            // 
            // multiLayoutItem93
            // 
            this.multiLayoutItem93.DataName = "nurse_confirm_time";
            this.multiLayoutItem93.IsUpdItem = true;
            // 
            // multiLayoutItem94
            // 
            this.multiLayoutItem94.DataName = "nurse_pickup_user";
            this.multiLayoutItem94.IsUpdItem = true;
            // 
            // multiLayoutItem95
            // 
            this.multiLayoutItem95.DataName = "nurse_pickup_date";
            this.multiLayoutItem95.IsUpdItem = true;
            // 
            // multiLayoutItem96
            // 
            this.multiLayoutItem96.DataName = "nurse_pickup_time";
            this.multiLayoutItem96.IsUpdItem = true;
            // 
            // multiLayoutItem97
            // 
            this.multiLayoutItem97.DataName = "nurse_hold_user";
            this.multiLayoutItem97.IsUpdItem = true;
            // 
            // multiLayoutItem98
            // 
            this.multiLayoutItem98.DataName = "nurse_hold_date";
            this.multiLayoutItem98.IsUpdItem = true;
            // 
            // multiLayoutItem99
            // 
            this.multiLayoutItem99.DataName = "nurse_hold_time";
            this.multiLayoutItem99.IsUpdItem = true;
            // 
            // multiLayoutItem100
            // 
            this.multiLayoutItem100.DataName = "reser_date";
            this.multiLayoutItem100.IsUpdItem = true;
            // 
            // multiLayoutItem101
            // 
            this.multiLayoutItem101.DataName = "reser_time";
            this.multiLayoutItem101.IsUpdItem = true;
            // 
            // multiLayoutItem102
            // 
            this.multiLayoutItem102.DataName = "jubsu_date";
            this.multiLayoutItem102.IsUpdItem = true;
            // 
            // multiLayoutItem103
            // 
            this.multiLayoutItem103.DataName = "jubsu_time";
            this.multiLayoutItem103.IsUpdItem = true;
            // 
            // multiLayoutItem104
            // 
            this.multiLayoutItem104.DataName = "acting_date";
            this.multiLayoutItem104.IsUpdItem = true;
            // 
            // multiLayoutItem105
            // 
            this.multiLayoutItem105.DataName = "acting_time";
            this.multiLayoutItem105.IsUpdItem = true;
            // 
            // multiLayoutItem106
            // 
            this.multiLayoutItem106.DataName = "acting_day";
            this.multiLayoutItem106.IsUpdItem = true;
            // 
            // multiLayoutItem107
            // 
            this.multiLayoutItem107.DataName = "result_date";
            this.multiLayoutItem107.IsUpdItem = true;
            // 
            // multiLayoutItem108
            // 
            this.multiLayoutItem108.DataName = "dc_gubun";
            this.multiLayoutItem108.IsUpdItem = true;
            // 
            // multiLayoutItem109
            // 
            this.multiLayoutItem109.DataName = "dc_yn";
            this.multiLayoutItem109.IsUpdItem = true;
            // 
            // multiLayoutItem110
            // 
            this.multiLayoutItem110.DataName = "bannab_yn";
            this.multiLayoutItem110.IsUpdItem = true;
            // 
            // multiLayoutItem111
            // 
            this.multiLayoutItem111.DataName = "bannab_confirm";
            this.multiLayoutItem111.IsUpdItem = true;
            // 
            // multiLayoutItem112
            // 
            this.multiLayoutItem112.DataName = "source_ord_key";
            this.multiLayoutItem112.IsUpdItem = true;
            // 
            // multiLayoutItem113
            // 
            this.multiLayoutItem113.DataName = "ocs_flag";
            this.multiLayoutItem113.IsUpdItem = true;
            // 
            // multiLayoutItem114
            // 
            this.multiLayoutItem114.DataName = "sg_code";
            this.multiLayoutItem114.IsUpdItem = true;
            // 
            // multiLayoutItem115
            // 
            this.multiLayoutItem115.DataName = "sg_ymd";
            this.multiLayoutItem115.IsUpdItem = true;
            // 
            // multiLayoutItem116
            // 
            this.multiLayoutItem116.DataName = "io_gubun";
            this.multiLayoutItem116.IsUpdItem = true;
            // 
            // multiLayoutItem117
            // 
            this.multiLayoutItem117.DataName = "after_act_yn";
            this.multiLayoutItem117.IsUpdItem = true;
            // 
            // multiLayoutItem118
            // 
            this.multiLayoutItem118.DataName = "bichi_yn";
            this.multiLayoutItem118.IsUpdItem = true;
            // 
            // multiLayoutItem119
            // 
            this.multiLayoutItem119.DataName = "drg_bunho";
            this.multiLayoutItem119.IsUpdItem = true;
            // 
            // multiLayoutItem120
            // 
            this.multiLayoutItem120.DataName = "sub_susul";
            this.multiLayoutItem120.IsUpdItem = true;
            // 
            // multiLayoutItem121
            // 
            this.multiLayoutItem121.DataName = "print_yn";
            this.multiLayoutItem121.IsUpdItem = true;
            // 
            // multiLayoutItem122
            // 
            this.multiLayoutItem122.DataName = "chisik";
            this.multiLayoutItem122.IsUpdItem = true;
            // 
            // multiLayoutItem123
            // 
            this.multiLayoutItem123.DataName = "tel_yn";
            this.multiLayoutItem123.IsUpdItem = true;
            // 
            // multiLayoutItem124
            // 
            this.multiLayoutItem124.DataName = "order_gubun_bas";
            this.multiLayoutItem124.IsUpdItem = true;
            // 
            // multiLayoutItem125
            // 
            this.multiLayoutItem125.DataName = "input_control";
            this.multiLayoutItem125.IsUpdItem = true;
            // 
            // multiLayoutItem126
            // 
            this.multiLayoutItem126.DataName = "suga_yn";
            this.multiLayoutItem126.IsUpdItem = true;
            // 
            // multiLayoutItem127
            // 
            this.multiLayoutItem127.DataName = "jaeryo_yn";
            this.multiLayoutItem127.IsUpdItem = true;
            // 
            // multiLayoutItem128
            // 
            this.multiLayoutItem128.DataName = "wonyoi_check";
            this.multiLayoutItem128.IsUpdItem = true;
            // 
            // multiLayoutItem129
            // 
            this.multiLayoutItem129.DataName = "emergency_check";
            this.multiLayoutItem129.IsUpdItem = true;
            // 
            // multiLayoutItem130
            // 
            this.multiLayoutItem130.DataName = "specimen_check";
            // 
            // multiLayoutItem131
            // 
            this.multiLayoutItem131.DataName = "portable_check";
            this.multiLayoutItem131.IsUpdItem = true;
            // 
            // multiLayoutItem132
            // 
            this.multiLayoutItem132.DataName = "bulyong_check";
            this.multiLayoutItem132.IsUpdItem = true;
            // 
            // multiLayoutItem133
            // 
            this.multiLayoutItem133.DataName = "sunab_check";
            // 
            // multiLayoutItem134
            // 
            this.multiLayoutItem134.DataName = "dc_check";
            // 
            // multiLayoutItem135
            // 
            this.multiLayoutItem135.DataName = "dc_gubun_check";
            this.multiLayoutItem135.IsUpdItem = true;
            // 
            // multiLayoutItem136
            // 
            this.multiLayoutItem136.DataName = "confirm_check";
            this.multiLayoutItem136.IsUpdItem = true;
            // 
            // multiLayoutItem137
            // 
            this.multiLayoutItem137.DataName = "reser_yn_check";
            this.multiLayoutItem137.IsUpdItem = true;
            // 
            // multiLayoutItem138
            // 
            this.multiLayoutItem138.DataName = "chisik_check";
            this.multiLayoutItem138.IsUpdItem = true;
            // 
            // multiLayoutItem139
            // 
            this.multiLayoutItem139.DataName = "nday_yn";
            this.multiLayoutItem139.IsUpdItem = true;
            // 
            // multiLayoutItem140
            // 
            this.multiLayoutItem140.DataName = "default_jaeryo_jundal_yn";
            this.multiLayoutItem140.IsUpdItem = true;
            // 
            // multiLayoutItem141
            // 
            this.multiLayoutItem141.DataName = "default_wonyoi_order_yn";
            this.multiLayoutItem141.IsUpdItem = true;
            // 
            // multiLayoutItem142
            // 
            this.multiLayoutItem142.DataName = "specific_comment";
            this.multiLayoutItem142.IsUpdItem = true;
            // 
            // multiLayoutItem143
            // 
            this.multiLayoutItem143.DataName = "specific_comment_name";
            this.multiLayoutItem143.IsUpdItem = true;
            // 
            // multiLayoutItem144
            // 
            this.multiLayoutItem144.DataName = "specific_comment_sys_id";
            this.multiLayoutItem144.IsUpdItem = true;
            // 
            // multiLayoutItem145
            // 
            this.multiLayoutItem145.DataName = "specific_comment_pgm_id";
            this.multiLayoutItem145.IsUpdItem = true;
            // 
            // multiLayoutItem146
            // 
            this.multiLayoutItem146.DataName = "specific_comment_not_null";
            this.multiLayoutItem146.IsUpdItem = true;
            // 
            // multiLayoutItem147
            // 
            this.multiLayoutItem147.DataName = "specific_comment_table_id";
            this.multiLayoutItem147.IsUpdItem = true;
            // 
            // multiLayoutItem148
            // 
            this.multiLayoutItem148.DataName = "specific_comment_col_id";
            this.multiLayoutItem148.IsUpdItem = true;
            // 
            // multiLayoutItem149
            // 
            this.multiLayoutItem149.DataName = "donbog_yn";
            this.multiLayoutItem149.IsUpdItem = true;
            // 
            // multiLayoutItem150
            // 
            this.multiLayoutItem150.DataName = "order_gubun_bas_name";
            this.multiLayoutItem150.IsUpdItem = true;
            // 
            // multiLayoutItem698
            // 
            this.multiLayoutItem698.DataName = "act_doctor";
            this.multiLayoutItem698.IsUpdItem = true;
            // 
            // multiLayoutItem699
            // 
            this.multiLayoutItem699.DataName = "act_buseo";
            this.multiLayoutItem699.IsUpdItem = true;
            // 
            // multiLayoutItem700
            // 
            this.multiLayoutItem700.DataName = "act_gwa";
            this.multiLayoutItem700.IsUpdItem = true;
            // 
            // multiLayoutItem711
            // 
            this.multiLayoutItem711.DataName = "home_care_yn";
            this.multiLayoutItem711.IsUpdItem = true;
            // 
            // multiLayoutItem719
            // 
            this.multiLayoutItem719.DataName = "regular_yn";
            this.multiLayoutItem719.IsUpdItem = true;
            // 
            // multiLayoutItem720
            // 
            this.multiLayoutItem720.DataName = "sort_fkocskey";
            this.multiLayoutItem720.IsUpdItem = true;
            // 
            // multiLayoutItem725
            // 
            this.multiLayoutItem725.DataName = "child_yn";
            this.multiLayoutItem725.IsUpdItem = true;
            // 
            // multiLayoutItem1019
            // 
            this.multiLayoutItem1019.DataName = "child_exist_yn";
            this.multiLayoutItem1019.IsUpdItem = true;
            // 
            // layDeletedData
            // 
            this.layDeletedData.CallerID = '2';
            this.layDeletedData.ExecuteQuery = null;
            this.layDeletedData.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem869,
            this.multiLayoutItem870,
            this.multiLayoutItem871,
            this.multiLayoutItem872,
            this.multiLayoutItem873,
            this.multiLayoutItem874,
            this.multiLayoutItem875,
            this.multiLayoutItem876,
            this.multiLayoutItem877,
            this.multiLayoutItem878,
            this.multiLayoutItem879,
            this.multiLayoutItem880,
            this.multiLayoutItem881,
            this.multiLayoutItem882,
            this.multiLayoutItem883,
            this.multiLayoutItem884,
            this.multiLayoutItem885,
            this.multiLayoutItem886,
            this.multiLayoutItem887,
            this.multiLayoutItem888,
            this.multiLayoutItem889,
            this.multiLayoutItem890,
            this.multiLayoutItem891,
            this.multiLayoutItem892,
            this.multiLayoutItem893,
            this.multiLayoutItem894,
            this.multiLayoutItem895,
            this.multiLayoutItem896,
            this.multiLayoutItem897,
            this.multiLayoutItem898,
            this.multiLayoutItem899,
            this.multiLayoutItem900,
            this.multiLayoutItem901,
            this.multiLayoutItem902,
            this.multiLayoutItem903,
            this.multiLayoutItem904,
            this.multiLayoutItem905,
            this.multiLayoutItem906,
            this.multiLayoutItem907,
            this.multiLayoutItem908,
            this.multiLayoutItem909,
            this.multiLayoutItem910,
            this.multiLayoutItem911,
            this.multiLayoutItem912,
            this.multiLayoutItem913,
            this.multiLayoutItem914,
            this.multiLayoutItem915,
            this.multiLayoutItem916,
            this.multiLayoutItem917,
            this.multiLayoutItem918,
            this.multiLayoutItem919,
            this.multiLayoutItem920,
            this.multiLayoutItem921,
            this.multiLayoutItem922,
            this.multiLayoutItem923,
            this.multiLayoutItem924,
            this.multiLayoutItem925,
            this.multiLayoutItem926,
            this.multiLayoutItem927,
            this.multiLayoutItem928,
            this.multiLayoutItem929,
            this.multiLayoutItem930,
            this.multiLayoutItem931,
            this.multiLayoutItem932,
            this.multiLayoutItem933,
            this.multiLayoutItem934,
            this.multiLayoutItem935,
            this.multiLayoutItem936,
            this.multiLayoutItem937,
            this.multiLayoutItem938,
            this.multiLayoutItem939,
            this.multiLayoutItem940,
            this.multiLayoutItem941,
            this.multiLayoutItem942,
            this.multiLayoutItem943,
            this.multiLayoutItem944,
            this.multiLayoutItem945,
            this.multiLayoutItem946,
            this.multiLayoutItem947,
            this.multiLayoutItem948,
            this.multiLayoutItem949,
            this.multiLayoutItem950,
            this.multiLayoutItem951,
            this.multiLayoutItem952,
            this.multiLayoutItem953,
            this.multiLayoutItem954,
            this.multiLayoutItem955,
            this.multiLayoutItem956,
            this.multiLayoutItem957,
            this.multiLayoutItem958,
            this.multiLayoutItem959,
            this.multiLayoutItem960,
            this.multiLayoutItem961,
            this.multiLayoutItem962,
            this.multiLayoutItem963,
            this.multiLayoutItem964,
            this.multiLayoutItem965,
            this.multiLayoutItem966,
            this.multiLayoutItem967,
            this.multiLayoutItem968,
            this.multiLayoutItem969,
            this.multiLayoutItem970,
            this.multiLayoutItem971,
            this.multiLayoutItem972,
            this.multiLayoutItem973,
            this.multiLayoutItem974,
            this.multiLayoutItem975,
            this.multiLayoutItem976,
            this.multiLayoutItem977,
            this.multiLayoutItem978,
            this.multiLayoutItem979,
            this.multiLayoutItem980,
            this.multiLayoutItem981,
            this.multiLayoutItem982,
            this.multiLayoutItem983,
            this.multiLayoutItem984,
            this.multiLayoutItem985,
            this.multiLayoutItem986,
            this.multiLayoutItem987,
            this.multiLayoutItem988,
            this.multiLayoutItem989,
            this.multiLayoutItem990,
            this.multiLayoutItem991,
            this.multiLayoutItem992,
            this.multiLayoutItem993,
            this.multiLayoutItem994,
            this.multiLayoutItem995,
            this.multiLayoutItem996,
            this.multiLayoutItem997,
            this.multiLayoutItem998,
            this.multiLayoutItem999,
            this.multiLayoutItem1000,
            this.multiLayoutItem1001,
            this.multiLayoutItem1002,
            this.multiLayoutItem1003,
            this.multiLayoutItem1004,
            this.multiLayoutItem1005,
            this.multiLayoutItem1006,
            this.multiLayoutItem1007,
            this.multiLayoutItem1008,
            this.multiLayoutItem1009,
            this.multiLayoutItem1010,
            this.multiLayoutItem1011,
            this.multiLayoutItem1012,
            this.multiLayoutItem1017,
            this.multiLayoutItem1018});
            this.layDeletedData.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDeletedData.ParamList")));
            this.layDeletedData.UseDefaultTransaction = false;
            // 
            // multiLayoutItem869
            // 
            this.multiLayoutItem869.DataName = "in_out_key";
            this.multiLayoutItem869.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem869.IsUpdItem = true;
            // 
            // multiLayoutItem870
            // 
            this.multiLayoutItem870.DataName = "pkocskey";
            this.multiLayoutItem870.IsUpdItem = true;
            // 
            // multiLayoutItem871
            // 
            this.multiLayoutItem871.DataName = "bunho";
            this.multiLayoutItem871.IsUpdItem = true;
            // 
            // multiLayoutItem872
            // 
            this.multiLayoutItem872.DataName = "order_date";
            this.multiLayoutItem872.IsUpdItem = true;
            // 
            // multiLayoutItem873
            // 
            this.multiLayoutItem873.DataName = "gwa";
            this.multiLayoutItem873.IsUpdItem = true;
            // 
            // multiLayoutItem874
            // 
            this.multiLayoutItem874.DataName = "doctor";
            this.multiLayoutItem874.IsUpdItem = true;
            // 
            // multiLayoutItem875
            // 
            this.multiLayoutItem875.DataName = "resident";
            this.multiLayoutItem875.IsUpdItem = true;
            // 
            // multiLayoutItem876
            // 
            this.multiLayoutItem876.DataName = "naewon_type";
            this.multiLayoutItem876.IsUpdItem = true;
            // 
            // multiLayoutItem877
            // 
            this.multiLayoutItem877.DataName = "jubsu_no";
            this.multiLayoutItem877.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem877.IsUpdItem = true;
            // 
            // multiLayoutItem878
            // 
            this.multiLayoutItem878.DataName = "input_id";
            this.multiLayoutItem878.IsUpdItem = true;
            // 
            // multiLayoutItem879
            // 
            this.multiLayoutItem879.DataName = "input_part";
            this.multiLayoutItem879.IsUpdItem = true;
            // 
            // multiLayoutItem880
            // 
            this.multiLayoutItem880.DataName = "input_gwa";
            this.multiLayoutItem880.IsUpdItem = true;
            // 
            // multiLayoutItem881
            // 
            this.multiLayoutItem881.DataName = "input_doctor";
            this.multiLayoutItem881.IsUpdItem = true;
            // 
            // multiLayoutItem882
            // 
            this.multiLayoutItem882.DataName = "input_gubun";
            this.multiLayoutItem882.IsUpdItem = true;
            // 
            // multiLayoutItem883
            // 
            this.multiLayoutItem883.DataName = "input_gubun_name";
            // 
            // multiLayoutItem884
            // 
            this.multiLayoutItem884.DataName = "group_ser";
            this.multiLayoutItem884.IsUpdItem = true;
            // 
            // multiLayoutItem885
            // 
            this.multiLayoutItem885.DataName = "input_tab";
            this.multiLayoutItem885.IsUpdItem = true;
            // 
            // multiLayoutItem886
            // 
            this.multiLayoutItem886.DataName = "input_tab_name";
            // 
            // multiLayoutItem887
            // 
            this.multiLayoutItem887.DataName = "order_gubun";
            this.multiLayoutItem887.IsUpdItem = true;
            // 
            // multiLayoutItem888
            // 
            this.multiLayoutItem888.DataName = "order_gubun_name";
            // 
            // multiLayoutItem889
            // 
            this.multiLayoutItem889.DataName = "group_yn";
            this.multiLayoutItem889.IsUpdItem = true;
            // 
            // multiLayoutItem890
            // 
            this.multiLayoutItem890.DataName = "seq";
            this.multiLayoutItem890.IsUpdItem = true;
            // 
            // multiLayoutItem891
            // 
            this.multiLayoutItem891.DataName = "slip_code";
            this.multiLayoutItem891.IsUpdItem = true;
            // 
            // multiLayoutItem892
            // 
            this.multiLayoutItem892.DataName = "hangmog_code";
            this.multiLayoutItem892.IsUpdItem = true;
            // 
            // multiLayoutItem893
            // 
            this.multiLayoutItem893.DataName = "hangmog_name";
            // 
            // multiLayoutItem894
            // 
            this.multiLayoutItem894.DataName = "specimen_code";
            this.multiLayoutItem894.IsUpdItem = true;
            // 
            // multiLayoutItem895
            // 
            this.multiLayoutItem895.DataName = "specimen_name";
            // 
            // multiLayoutItem896
            // 
            this.multiLayoutItem896.DataName = "suryang";
            this.multiLayoutItem896.IsUpdItem = true;
            // 
            // multiLayoutItem897
            // 
            this.multiLayoutItem897.DataName = "sunab_suryang";
            this.multiLayoutItem897.IsUpdItem = true;
            // 
            // multiLayoutItem898
            // 
            this.multiLayoutItem898.DataName = "subul_suryang";
            this.multiLayoutItem898.IsUpdItem = true;
            // 
            // multiLayoutItem899
            // 
            this.multiLayoutItem899.DataName = "ord_danui";
            this.multiLayoutItem899.IsUpdItem = true;
            // 
            // multiLayoutItem900
            // 
            this.multiLayoutItem900.DataName = "ord_danui_name";
            // 
            // multiLayoutItem901
            // 
            this.multiLayoutItem901.DataName = "dv_time";
            this.multiLayoutItem901.IsUpdItem = true;
            // 
            // multiLayoutItem902
            // 
            this.multiLayoutItem902.DataName = "dv";
            this.multiLayoutItem902.IsUpdItem = true;
            // 
            // multiLayoutItem903
            // 
            this.multiLayoutItem903.DataName = "dv_1";
            this.multiLayoutItem903.IsUpdItem = true;
            // 
            // multiLayoutItem904
            // 
            this.multiLayoutItem904.DataName = "dv_2";
            this.multiLayoutItem904.IsUpdItem = true;
            // 
            // multiLayoutItem905
            // 
            this.multiLayoutItem905.DataName = "dv_3";
            this.multiLayoutItem905.IsUpdItem = true;
            // 
            // multiLayoutItem906
            // 
            this.multiLayoutItem906.DataName = "dv_4";
            this.multiLayoutItem906.IsUpdItem = true;
            // 
            // multiLayoutItem907
            // 
            this.multiLayoutItem907.DataName = "nalsu";
            this.multiLayoutItem907.IsUpdItem = true;
            // 
            // multiLayoutItem908
            // 
            this.multiLayoutItem908.DataName = "sunab_nalsu";
            this.multiLayoutItem908.IsUpdItem = true;
            // 
            // multiLayoutItem909
            // 
            this.multiLayoutItem909.DataName = "jusa";
            this.multiLayoutItem909.IsUpdItem = true;
            // 
            // multiLayoutItem910
            // 
            this.multiLayoutItem910.DataName = "jusa_name";
            this.multiLayoutItem910.IsUpdItem = true;
            // 
            // multiLayoutItem911
            // 
            this.multiLayoutItem911.DataName = "jusa_spd_gubun";
            this.multiLayoutItem911.IsUpdItem = true;
            // 
            // multiLayoutItem912
            // 
            this.multiLayoutItem912.DataName = "bogyong_code";
            this.multiLayoutItem912.IsUpdItem = true;
            // 
            // multiLayoutItem913
            // 
            this.multiLayoutItem913.DataName = "bogyong_name";
            this.multiLayoutItem913.IsUpdItem = true;
            // 
            // multiLayoutItem914
            // 
            this.multiLayoutItem914.DataName = "emergency";
            this.multiLayoutItem914.IsUpdItem = true;
            // 
            // multiLayoutItem915
            // 
            this.multiLayoutItem915.DataName = "jaeryo_jundal_yn";
            this.multiLayoutItem915.IsUpdItem = true;
            // 
            // multiLayoutItem916
            // 
            this.multiLayoutItem916.DataName = "jundal_table";
            this.multiLayoutItem916.IsUpdItem = true;
            // 
            // multiLayoutItem917
            // 
            this.multiLayoutItem917.DataName = "jundal_part";
            this.multiLayoutItem917.IsUpdItem = true;
            // 
            // multiLayoutItem918
            // 
            this.multiLayoutItem918.DataName = "move_part";
            this.multiLayoutItem918.IsUpdItem = true;
            // 
            // multiLayoutItem919
            // 
            this.multiLayoutItem919.DataName = "portable_yn";
            this.multiLayoutItem919.IsUpdItem = true;
            // 
            // multiLayoutItem920
            // 
            this.multiLayoutItem920.DataName = "powder_yn";
            this.multiLayoutItem920.IsUpdItem = true;
            // 
            // multiLayoutItem921
            // 
            this.multiLayoutItem921.DataName = "hubal_change_yn";
            this.multiLayoutItem921.IsUpdItem = true;
            // 
            // multiLayoutItem922
            // 
            this.multiLayoutItem922.DataName = "pharmacy";
            this.multiLayoutItem922.IsUpdItem = true;
            // 
            // multiLayoutItem923
            // 
            this.multiLayoutItem923.DataName = "drg_pack_yn";
            this.multiLayoutItem923.IsUpdItem = true;
            // 
            // multiLayoutItem924
            // 
            this.multiLayoutItem924.DataName = "muhyo";
            this.multiLayoutItem924.IsUpdItem = true;
            // 
            // multiLayoutItem925
            // 
            this.multiLayoutItem925.DataName = "prn_yn";
            this.multiLayoutItem925.IsUpdItem = true;
            // 
            // multiLayoutItem926
            // 
            this.multiLayoutItem926.DataName = "toiwon_drg_yn";
            this.multiLayoutItem926.IsUpdItem = true;
            // 
            // multiLayoutItem927
            // 
            this.multiLayoutItem927.DataName = "prn_nurse";
            this.multiLayoutItem927.IsUpdItem = true;
            // 
            // multiLayoutItem928
            // 
            this.multiLayoutItem928.DataName = "append_yn";
            this.multiLayoutItem928.IsUpdItem = true;
            // 
            // multiLayoutItem929
            // 
            this.multiLayoutItem929.DataName = "order_remark";
            this.multiLayoutItem929.IsUpdItem = true;
            // 
            // multiLayoutItem930
            // 
            this.multiLayoutItem930.DataName = "nurse_remark";
            this.multiLayoutItem930.IsUpdItem = true;
            // 
            // multiLayoutItem931
            // 
            this.multiLayoutItem931.DataName = "comment";
            this.multiLayoutItem931.IsUpdItem = true;
            // 
            // multiLayoutItem932
            // 
            this.multiLayoutItem932.DataName = "mix_group";
            this.multiLayoutItem932.IsUpdItem = true;
            // 
            // multiLayoutItem933
            // 
            this.multiLayoutItem933.DataName = "amt";
            this.multiLayoutItem933.IsUpdItem = true;
            // 
            // multiLayoutItem934
            // 
            this.multiLayoutItem934.DataName = "pay";
            this.multiLayoutItem934.IsUpdItem = true;
            // 
            // multiLayoutItem935
            // 
            this.multiLayoutItem935.DataName = "wonyoi_order_yn";
            this.multiLayoutItem935.IsUpdItem = true;
            // 
            // multiLayoutItem936
            // 
            this.multiLayoutItem936.DataName = "dangil_gumsa_order_yn";
            this.multiLayoutItem936.IsUpdItem = true;
            // 
            // multiLayoutItem937
            // 
            this.multiLayoutItem937.DataName = "dangil_gumsa_result_yn";
            this.multiLayoutItem937.IsUpdItem = true;
            // 
            // multiLayoutItem938
            // 
            this.multiLayoutItem938.DataName = "bom_occur_yn";
            this.multiLayoutItem938.IsUpdItem = true;
            // 
            // multiLayoutItem939
            // 
            this.multiLayoutItem939.DataName = "bom_source_key";
            this.multiLayoutItem939.IsUpdItem = true;
            // 
            // multiLayoutItem940
            // 
            this.multiLayoutItem940.DataName = "display_yn";
            this.multiLayoutItem940.IsUpdItem = true;
            // 
            // multiLayoutItem941
            // 
            this.multiLayoutItem941.DataName = "sunab_yn";
            this.multiLayoutItem941.IsUpdItem = true;
            // 
            // multiLayoutItem942
            // 
            this.multiLayoutItem942.DataName = "sunab_date";
            this.multiLayoutItem942.IsUpdItem = true;
            // 
            // multiLayoutItem943
            // 
            this.multiLayoutItem943.DataName = "sunab_time";
            this.multiLayoutItem943.IsUpdItem = true;
            // 
            // multiLayoutItem944
            // 
            this.multiLayoutItem944.DataName = "hope_date";
            this.multiLayoutItem944.IsUpdItem = true;
            // 
            // multiLayoutItem945
            // 
            this.multiLayoutItem945.DataName = "hope_time";
            this.multiLayoutItem945.IsUpdItem = true;
            // 
            // multiLayoutItem946
            // 
            this.multiLayoutItem946.DataName = "nurse_confirm_user";
            this.multiLayoutItem946.IsUpdItem = true;
            // 
            // multiLayoutItem947
            // 
            this.multiLayoutItem947.DataName = "nurse_confirm_date";
            this.multiLayoutItem947.IsUpdItem = true;
            // 
            // multiLayoutItem948
            // 
            this.multiLayoutItem948.DataName = "nurse_confirm_time";
            this.multiLayoutItem948.IsUpdItem = true;
            // 
            // multiLayoutItem949
            // 
            this.multiLayoutItem949.DataName = "nurse_pickup_user";
            this.multiLayoutItem949.IsUpdItem = true;
            // 
            // multiLayoutItem950
            // 
            this.multiLayoutItem950.DataName = "nurse_pickup_date";
            this.multiLayoutItem950.IsUpdItem = true;
            // 
            // multiLayoutItem951
            // 
            this.multiLayoutItem951.DataName = "nurse_pickup_time";
            this.multiLayoutItem951.IsUpdItem = true;
            // 
            // multiLayoutItem952
            // 
            this.multiLayoutItem952.DataName = "nurse_hold_user";
            this.multiLayoutItem952.IsUpdItem = true;
            // 
            // multiLayoutItem953
            // 
            this.multiLayoutItem953.DataName = "nurse_hold_date";
            this.multiLayoutItem953.IsUpdItem = true;
            // 
            // multiLayoutItem954
            // 
            this.multiLayoutItem954.DataName = "nurse_hold_time";
            this.multiLayoutItem954.IsUpdItem = true;
            // 
            // multiLayoutItem955
            // 
            this.multiLayoutItem955.DataName = "reser_date";
            this.multiLayoutItem955.IsUpdItem = true;
            // 
            // multiLayoutItem956
            // 
            this.multiLayoutItem956.DataName = "reser_time";
            this.multiLayoutItem956.IsUpdItem = true;
            // 
            // multiLayoutItem957
            // 
            this.multiLayoutItem957.DataName = "jubsu_date";
            this.multiLayoutItem957.IsUpdItem = true;
            // 
            // multiLayoutItem958
            // 
            this.multiLayoutItem958.DataName = "jubsu_time";
            this.multiLayoutItem958.IsUpdItem = true;
            // 
            // multiLayoutItem959
            // 
            this.multiLayoutItem959.DataName = "acting_date";
            this.multiLayoutItem959.IsUpdItem = true;
            // 
            // multiLayoutItem960
            // 
            this.multiLayoutItem960.DataName = "acting_time";
            this.multiLayoutItem960.IsUpdItem = true;
            // 
            // multiLayoutItem961
            // 
            this.multiLayoutItem961.DataName = "acting_day";
            this.multiLayoutItem961.IsUpdItem = true;
            // 
            // multiLayoutItem962
            // 
            this.multiLayoutItem962.DataName = "result_date";
            this.multiLayoutItem962.IsUpdItem = true;
            // 
            // multiLayoutItem963
            // 
            this.multiLayoutItem963.DataName = "dc_gubun";
            this.multiLayoutItem963.IsUpdItem = true;
            // 
            // multiLayoutItem964
            // 
            this.multiLayoutItem964.DataName = "dc_yn";
            this.multiLayoutItem964.IsUpdItem = true;
            // 
            // multiLayoutItem965
            // 
            this.multiLayoutItem965.DataName = "bannab_yn";
            this.multiLayoutItem965.IsUpdItem = true;
            // 
            // multiLayoutItem966
            // 
            this.multiLayoutItem966.DataName = "bannab_confirm";
            this.multiLayoutItem966.IsUpdItem = true;
            // 
            // multiLayoutItem967
            // 
            this.multiLayoutItem967.DataName = "source_ord_key";
            this.multiLayoutItem967.IsUpdItem = true;
            // 
            // multiLayoutItem968
            // 
            this.multiLayoutItem968.DataName = "ocs_flag";
            this.multiLayoutItem968.IsUpdItem = true;
            // 
            // multiLayoutItem969
            // 
            this.multiLayoutItem969.DataName = "sg_code";
            this.multiLayoutItem969.IsUpdItem = true;
            // 
            // multiLayoutItem970
            // 
            this.multiLayoutItem970.DataName = "sg_ymd";
            this.multiLayoutItem970.IsUpdItem = true;
            // 
            // multiLayoutItem971
            // 
            this.multiLayoutItem971.DataName = "io_gubun";
            this.multiLayoutItem971.IsUpdItem = true;
            // 
            // multiLayoutItem972
            // 
            this.multiLayoutItem972.DataName = "after_act_yn";
            this.multiLayoutItem972.IsUpdItem = true;
            // 
            // multiLayoutItem973
            // 
            this.multiLayoutItem973.DataName = "bichi_yn";
            this.multiLayoutItem973.IsUpdItem = true;
            // 
            // multiLayoutItem974
            // 
            this.multiLayoutItem974.DataName = "drg_bunho";
            this.multiLayoutItem974.IsUpdItem = true;
            // 
            // multiLayoutItem975
            // 
            this.multiLayoutItem975.DataName = "sub_susul";
            this.multiLayoutItem975.IsUpdItem = true;
            // 
            // multiLayoutItem976
            // 
            this.multiLayoutItem976.DataName = "print_yn";
            this.multiLayoutItem976.IsUpdItem = true;
            // 
            // multiLayoutItem977
            // 
            this.multiLayoutItem977.DataName = "chisik";
            this.multiLayoutItem977.IsUpdItem = true;
            // 
            // multiLayoutItem978
            // 
            this.multiLayoutItem978.DataName = "tel_yn";
            this.multiLayoutItem978.IsUpdItem = true;
            // 
            // multiLayoutItem979
            // 
            this.multiLayoutItem979.DataName = "order_gubun_bas";
            this.multiLayoutItem979.IsUpdItem = true;
            // 
            // multiLayoutItem980
            // 
            this.multiLayoutItem980.DataName = "input_control";
            this.multiLayoutItem980.IsUpdItem = true;
            // 
            // multiLayoutItem981
            // 
            this.multiLayoutItem981.DataName = "suga_yn";
            this.multiLayoutItem981.IsUpdItem = true;
            // 
            // multiLayoutItem982
            // 
            this.multiLayoutItem982.DataName = "jaeryo_yn";
            this.multiLayoutItem982.IsUpdItem = true;
            // 
            // multiLayoutItem983
            // 
            this.multiLayoutItem983.DataName = "wonyoi_check";
            this.multiLayoutItem983.IsUpdItem = true;
            // 
            // multiLayoutItem984
            // 
            this.multiLayoutItem984.DataName = "emergency_check";
            this.multiLayoutItem984.IsUpdItem = true;
            // 
            // multiLayoutItem985
            // 
            this.multiLayoutItem985.DataName = "specimen_check";
            // 
            // multiLayoutItem986
            // 
            this.multiLayoutItem986.DataName = "portable_check";
            this.multiLayoutItem986.IsUpdItem = true;
            // 
            // multiLayoutItem987
            // 
            this.multiLayoutItem987.DataName = "bulyong_check";
            this.multiLayoutItem987.IsUpdItem = true;
            // 
            // multiLayoutItem988
            // 
            this.multiLayoutItem988.DataName = "sunab_check";
            // 
            // multiLayoutItem989
            // 
            this.multiLayoutItem989.DataName = "dc_check";
            // 
            // multiLayoutItem990
            // 
            this.multiLayoutItem990.DataName = "dc_gubun_check";
            this.multiLayoutItem990.IsUpdItem = true;
            // 
            // multiLayoutItem991
            // 
            this.multiLayoutItem991.DataName = "confirm_check";
            this.multiLayoutItem991.IsUpdItem = true;
            // 
            // multiLayoutItem992
            // 
            this.multiLayoutItem992.DataName = "reser_yn_check";
            this.multiLayoutItem992.IsUpdItem = true;
            // 
            // multiLayoutItem993
            // 
            this.multiLayoutItem993.DataName = "chisik_check";
            this.multiLayoutItem993.IsUpdItem = true;
            // 
            // multiLayoutItem994
            // 
            this.multiLayoutItem994.DataName = "nday_yn";
            this.multiLayoutItem994.IsUpdItem = true;
            // 
            // multiLayoutItem995
            // 
            this.multiLayoutItem995.DataName = "default_jaeryo_jundal_yn";
            this.multiLayoutItem995.IsUpdItem = true;
            // 
            // multiLayoutItem996
            // 
            this.multiLayoutItem996.DataName = "default_wonyoi_order_yn";
            this.multiLayoutItem996.IsUpdItem = true;
            // 
            // multiLayoutItem997
            // 
            this.multiLayoutItem997.DataName = "specific_comment";
            this.multiLayoutItem997.IsUpdItem = true;
            // 
            // multiLayoutItem998
            // 
            this.multiLayoutItem998.DataName = "specific_comment_name";
            this.multiLayoutItem998.IsUpdItem = true;
            // 
            // multiLayoutItem999
            // 
            this.multiLayoutItem999.DataName = "specific_comment_sys_id";
            this.multiLayoutItem999.IsUpdItem = true;
            // 
            // multiLayoutItem1000
            // 
            this.multiLayoutItem1000.DataName = "specific_comment_pgm_id";
            this.multiLayoutItem1000.IsUpdItem = true;
            // 
            // multiLayoutItem1001
            // 
            this.multiLayoutItem1001.DataName = "specific_comment_not_null";
            this.multiLayoutItem1001.IsUpdItem = true;
            // 
            // multiLayoutItem1002
            // 
            this.multiLayoutItem1002.DataName = "specific_comment_table_id";
            this.multiLayoutItem1002.IsUpdItem = true;
            // 
            // multiLayoutItem1003
            // 
            this.multiLayoutItem1003.DataName = "specific_comment_col_id";
            this.multiLayoutItem1003.IsUpdItem = true;
            // 
            // multiLayoutItem1004
            // 
            this.multiLayoutItem1004.DataName = "donbog_yn";
            this.multiLayoutItem1004.IsUpdItem = true;
            // 
            // multiLayoutItem1005
            // 
            this.multiLayoutItem1005.DataName = "order_gubun_bas_name";
            this.multiLayoutItem1005.IsUpdItem = true;
            // 
            // multiLayoutItem1006
            // 
            this.multiLayoutItem1006.DataName = "act_doctor";
            this.multiLayoutItem1006.IsUpdItem = true;
            // 
            // multiLayoutItem1007
            // 
            this.multiLayoutItem1007.DataName = "act_buseo";
            this.multiLayoutItem1007.IsUpdItem = true;
            // 
            // multiLayoutItem1008
            // 
            this.multiLayoutItem1008.DataName = "act_gwa";
            this.multiLayoutItem1008.IsUpdItem = true;
            // 
            // multiLayoutItem1009
            // 
            this.multiLayoutItem1009.DataName = "home_care_yn";
            this.multiLayoutItem1009.IsUpdItem = true;
            // 
            // multiLayoutItem1010
            // 
            this.multiLayoutItem1010.DataName = "regular_yn";
            this.multiLayoutItem1010.IsUpdItem = true;
            // 
            // multiLayoutItem1011
            // 
            this.multiLayoutItem1011.DataName = "sort_fkocskey";
            this.multiLayoutItem1011.IsUpdItem = true;
            // 
            // multiLayoutItem1012
            // 
            this.multiLayoutItem1012.DataName = "child_yn";
            this.multiLayoutItem1012.IsUpdItem = true;
            // 
            // multiLayoutItem1017
            // 
            this.multiLayoutItem1017.DataName = "child_exist_yn";
            this.multiLayoutItem1017.IsUpdItem = true;
            // 
            // multiLayoutItem1018
            // 
            this.multiLayoutItem1018.DataName = "dummy";
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellName = "action_do_yn";
            this.xEditGridCell65.Col = -1;
            this.xEditGridCell65.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.IsVisible = false;
            this.xEditGridCell65.Row = -1;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellName = "yj_code";
            this.xEditGridCell66.Col = -1;
            this.xEditGridCell66.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.IsVisible = false;
            this.xEditGridCell66.Row = -1;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellName = "common_yn";
            this.xEditGridCell67.Col = -1;
            this.xEditGridCell67.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell67, "xEditGridCell67");
            this.xEditGridCell67.IsVisible = false;
            this.xEditGridCell67.Row = -1;
            // 
            // UCOCS0103U11
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlFill);
            this.Name = "UCOCS0103U11";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.pnlFill.ResumeLayout(false);
            this.pnlSangyong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSangyongOrder)).EndInit();
            this.pnlSlipHangmog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSlipHangmog)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchOrder)).EndInit();
            this.xPanel8.ResumeLayout(false);
            this.xPanel8.PerformLayout();
            this.xPanel6.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            this.pnlOrderInfo.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).EndInit();
            this.pnlOrderDetail.ResumeLayout(false);
            this.pnlOrderDetail.PerformLayout();
            this.pnlOrderInput.ResumeLayout(false);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layGroupTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySlipCodeTree)).EndInit();
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
        private IHIS.Framework.XPanel xPanel1;
        private System.Windows.Forms.ImageList imageListInfo;
        //private System.Windows.Forms.ImageList ImageList;
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
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XCheckBox cbxEmergency;
        private IHIS.Framework.XPanel xPanel4;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XTabControl tabGroup;
        private IHIS.Framework.XRadioButton rbnOftenOrder;
        private IHIS.Framework.XRadioButton rbnSlipHangmog;
        private IHIS.Framework.XRadioButton rbnSearchOrder;
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
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private ImageList ImageGrouping;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XButton btnSpecificComment;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XGridHeader xGridHeader1;
        private IHIS.Framework.XPanel pnlSearch;
        private IHIS.Framework.XEditGrid grdSearchOrder;
        private IHIS.Framework.XEditGridCell xEditGridCell28;
        private IHIS.Framework.XEditGridCell xEditGridCell29;
        private IHIS.Framework.XEditGridCell xEditGridCell30;
        private IHIS.Framework.XEditGridCell xEditGridCell31;
        private IHIS.Framework.XEditGridCell xEditGridCell33;
        private IHIS.Framework.XPanel pnlSlipHangmog;
        private IHIS.Framework.XEditGrid grdSlipHangmog;
        private IHIS.Framework.XTreeView tvwSlipCode;
        private IHIS.Framework.MultiLayout laySlipCodeTree;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell16;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XPanel xPanel8;
        private IHIS.Framework.XComboBox cboQueryCon;
        private IHIS.Framework.XComboItem xComboItem1;
        private IHIS.Framework.XComboItem xComboItem2;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XTextBox txtSearch;
        private IHIS.Framework.XLabel xLabel5;
        private IHIS.Framework.XEditGridCell xEditGridCell24;
        private IHIS.Framework.XEditGridCell xEditGridCell25;
        private IHIS.Framework.XButton btnExpandSearch;
        private IHIS.Framework.XEditGridCell xEditGridCell27;
        private IHIS.Framework.XEditGridCell xEditGridCell32;
        private IHIS.Framework.XEditGridCell xEditGridCell36;
        private IHIS.Framework.XEditGridCell xEditGridCell37;
        private IHIS.Framework.XEditGridCell xEditGridCell38;
        private IHIS.Framework.XEditGridCell xEditGridCell55;
        private IHIS.Framework.SingleLayout lyReserCanDate;
        private IHIS.Framework.SingleLayoutItem singleLayoutItem1;
        private IHIS.Framework.MultiLayout laySaveLayout;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem9;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem10;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem11;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem12;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem18;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem19;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem20;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem21;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem22;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem23;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem24;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem25;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem26;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem27;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem28;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem29;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem30;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem31;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem32;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem33;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem34;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem35;
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
        private IHIS.Framework.MultiLayoutItem multiLayoutItem698;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem699;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem700;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem711;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem719;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem720;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem725;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem1019;
        private IHIS.Framework.MultiLayout layDeletedData;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem869;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem870;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem871;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem872;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem873;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem874;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem875;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem876;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem877;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem878;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem879;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem880;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem881;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem882;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem883;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem884;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem885;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem886;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem887;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem888;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem889;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem890;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem891;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem892;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem893;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem894;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem895;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem896;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem897;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem898;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem899;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem900;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem901;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem902;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem903;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem904;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem905;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem906;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem907;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem908;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem909;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem910;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem911;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem912;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem913;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem914;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem915;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem916;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem917;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem918;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem919;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem920;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem921;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem922;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem923;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem924;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem925;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem926;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem927;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem928;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem929;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem930;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem931;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem932;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem933;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem934;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem935;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem936;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem937;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem938;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem939;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem940;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem941;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem942;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem943;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem944;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem945;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem946;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem947;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem948;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem949;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem950;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem951;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem952;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem953;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem954;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem955;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem956;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem957;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem958;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem959;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem960;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem961;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem962;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem963;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem964;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem965;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem966;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem967;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem968;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem969;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem970;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem971;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem972;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem973;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem974;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem975;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem976;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem977;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem978;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem979;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem980;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem981;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem982;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem983;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem984;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem985;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem986;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem987;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem988;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem989;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem990;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem991;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem992;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem993;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem994;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem995;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem996;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem997;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem998;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem999;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem1000;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem1001;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem1002;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem1003;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem1004;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem1005;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem1006;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem1007;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem1008;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem1009;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem1010;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem1011;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem1012;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem1017;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem1018;
        private IHIS.Framework.XEditGridCell xEditGridCell56;
        private IHIS.Framework.XEditGridCell xEditGridCell57;
        private IHIS.Framework.XEditGridCell xEditGridCell58;
        private IHIS.Framework.XEditGridCell xEditGridCell26;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem151;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem152;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem153;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem154;
        private IHIS.Framework.XDictComboBox cboSearchCondition;
        private IHIS.Framework.XEditGridCell xEditGridCell59;
        private IHIS.Framework.XEditGridCell xEditGridCell60;
        private IHIS.Framework.XComboItem xComboItem3;
        private IHIS.Framework.XComboItem xComboItem4;
        private IHIS.Framework.XComboItem xComboItem5;
        private IHIS.Framework.XComboItem xComboItem6;
        private XEditGridCell xEditGridCell62;
        private XEditGridCell xEditGridCell63;
        private XEditGridCell xEditGridCell64;
        private XButton btnInsert;
        private XEditGridCell xEditGridCell65;
        private XEditGridCell xEditGridCell66;
        private XEditGridCell xEditGridCell67;
        private IHIS.Framework.XEditGridCell xEditGridCell61;

        #endregion

        #region 1. 생성자를 정의한다

        public UCOCS0103U11()
            : this(true)
        {
            // MessageBox.Show("Constructor start");



            // MessageBox.Show("Constructor end");
        }
        public UCOCS0103U11(bool initialize)
        {
            // MessageBox.Show("Constructor start");
            if (initialize) EnsureInitialized();
        }
        private bool _initialized = false;

        public void EnsureInitialized()
        {
            if (!_initialized)
            {
                InitializeComponent();

                // Cloud updated
                InitItemsControl();
                _initialized = true;
            }

        }

        #endregion

        #region 2. Form변수를 정의한다

        private XButton mBtnPaste;
        private XButtonList mBtnList;
        private PictureBox mPbxCopy;
        private XButton mBtnCopy;
        private XScreen mOpener;
        private XPanel mPnlTop;
        private XScreen mContainer;
        private string mBunho;

        private string mbxMsg = "", mbxCap = "";
        private string mHospCode = EnvironInfo.HospCode;

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
        //private int OrderExtendWidth = 1081;
        private int OrderExtendWidth = 850;
        private int OrderNormalWidth = 762;
        private bool mIsExtended = false;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // 조회부분 화면 확장 관련
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private int OrderMinWidth = 618;
        private bool mIsSearchExtended = false;

        private int SearchHangmogNameNormalWidth = 329;
        private int SearchHangmogNameMaxWidth = 468;

        private int SlipHangmogNameNormalWidth = 175;
        private int SlipHangmogNameMaxWidth = 314;

        private int SangYongHangmogNormalWidth = 330;
        private int SangYongHangmogMaxWidth = 466;

        ///////////// Order 기본값 /////////////////////////////////////////////////////////////////////////
        private const string INPUTTAB = "10"; // リハビリ (10) 
        private string IOEGUBUN = "O";     // 입외구분(외래)
        private string mInputGubun = "D0";    // 입력구분(의사처방)
        private string mInputGubunName = "";  // 입력구분명
        private string mInputPart = "";      // 입력파트
        private string mCallerSysID = "";
        private string mCallerScreenID = "";
        private int mInitialGroupSer = 1100;
        private string protocolId = "";

        //공통
        private string mOrderDate = "";
        private MultiLayout mOrderLayout;
        private OrderVariables.OrderMode mOrderMode;
        private int mCurrentRow = -1;
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

        //insert by jc [OCS1003P01のデータウインドウから選択された際、自動ポイント移動に必要な変数]
        private int mCurrentRowNum = -1;
        private XDataWindow mCurrentDataWindow;
        private string mCurrentColName = "";
        private int mStartRowNum = -1;

        // 환자정보관련

        private bool mDoctorLogin = false;

        // 오더 정보 관련
        private DataTable mInDataRow;
        private DataTable mOutDataRow;

        private DataTable mLayDtOrderBuffer = null; // 처방 Copy & Paste용 Buffer DataTable

        private bool isEnableGrd = true;

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
        private bool mIsDrag = false;
        private int mDragX = 0;
        private int mDragY = 0;
        private int mDragRowIndex = 0;
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////Popup Menu ////////////////////////////////////////////////////////////////////////////
        private IHIS.X.Magic.Menus.PopupMenu popupOrderMenu = new IHIS.X.Magic.Menus.PopupMenu(); // 처방Grid용
        private IHIS.X.Magic.Menus.PopupMenu popupOftenUsedMenu = new IHIS.X.Magic.Menus.PopupMenu(); // 상용처방Grid용
        private IHIS.X.Magic.Menus.PopupMenu popupYaksokOrderMenu = new IHIS.X.Magic.Menus.PopupMenu(); // 약속처방Grid용
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private Hashtable mHtControl = null;        // Control과 연결할 HashTable

        private bool mIsSuccessBtnList = true;      // 버튼리스트 로직 콜해서 성공여부를 가지고 있는다(PerformClick의 Return값이 없어서)

        private string mPk_Naewon = ""; // 내원/재원환자List에서 환자 선택한 내원/재원Key

        private DataTable mDtOrderGubun;

        // 저장을 하기 위한 Layout
        private Hashtable mSaveLayout;

        // Screen Open check
        private bool mScreenOpen = true;

        // 신규 탭 페이지 
        private IHIS.X.Magic.Controls.TabPage tpgNew = new IHIS.X.Magic.Controls.TabPage();

        // Load screen
        private OCS0103U11InitializeScreenResult loadScreenResult;

        // 임시 컬럼
        string mTemp = "";
        private CommonItemCollection mPostCallParam;

        #endregion

        #region 3. Properties를 정의한다
        private bool isOpenPopUp = true;
        private bool isSearchFormKeyPress = false;
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

        #region 4. OnLoad 및 Main Screen Event를 정의한다

        /// <summary>
        /// 
        /// </summary>
        private void PostLoad()
        {
            //MessageBox.Show("PostLoad Start");

            /// 사용자 변경 Event Call /////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

            if (mPostCallParam != null) // 다른 화면에서 콜되는 경우
            {
                //HandleBtnListClick(FunctionType.Query);

                this.MakeGroupTabInfo(IOEGUBUN, this.mPkInOutKey, this.mInputGubun, INPUTTAB);
            }

            //added 2015-10-15
            SetEnableRbn();
            if (mPostCallParam != null && !mPostCallParam["isOpenPopUp"].Equals(true))
            {
                rbnSearchOrder.Visible = false;
                rbnSlipHangmog.Visible = false;

                rbnOftenOrder.Checked = true;
                rbnOftenOrder.Dock = DockStyle.Fill;
                overrideLookAndFeel();
            }

            // MessageBox.Show(this.grdOrder.CurrentRowNumber.ToString());
            this.txtSearch.Focus();
            this.setFocusGotoColumn();
        }

        private void overrideLookAndFeel()
        {
            this.pnlSangyong.Location = new Point(762, 100);
            this.pnlSlipHangmog.Location = new Point(762, 100);
            this.pnlSearch.Location = new Point(762, 100);
            this.xPanel8.Location = new Point(762, 31);
            this.btnInsert.Location = new Point(4, 6);
            this.btnSelect.Location = new Point(208, 6);
            this.btnNewSelect.Location = new Point(84, 6);
            this.xPanel6.Location = new Point(762, 558);
            this.xPanel2.Location = new Point(762, 0);
            this.pnlFill.Location = new Point(0, 0);
            //this.cboSearchCondition.Location = new Point(198, 36);
            //this.txtSearch.Location = new Point(83, 37);
            //this.xLabel5.Location = new Point(6, 37);
            this.btnExpandSearch.Location = new Point(0, 0);
            this.pnlOrderDetail.Location = new Point(0, 558);
            this.btnSpecificComment.Location = new Point(143, 7);
            this.btnSetOrder.Location = new Point(360, 7);
            this.btnDoOrder.Location = new Point(258, 7);
            this.btnExtend.Location = new Point(732, 3);
            this.pnlSangyong.Size = new Size(538, 458);
            this.pnlSlipHangmog.Size = new Size(538, 458);
            this.pnlSearch.Size = new Size(538, 458);
            this.xPanel8.Size = new Size(538, 69);
            this.btnInsert.Size = new Size(80, 29);
            this.btnSelect.Size = new Size(68, 29);
            this.btnNewSelect.Size = new Size(125, 29);
            this.xPanel6.Size = new Size(538, 42);
            this.xPanel2.Size = new Size(538, 31);
            this.pnlOrderInfo.Size = new Size(762, 600);
            this.pnlFill.Size = new Size(1300, 600);
            this.grdSangyongOrder.Size = new Size(538, 428);
            this.tabSangyongOrder.Size = new Size(538, 30);
            this.grdSlipHangmog.Size = new Size(387, 458);
            this.tvwSlipCode.Size = new Size(151, 458);
            this.grdSearchOrder.Size = new Size(538, 458);
            //this.cboQueryCon.Size = new Size(194, 20);
            this.xPanel4.Size = new Size(762, 527);
            this.grdOrder.Size = new Size(762, 527);
            this.pnlOrderDetail.Size = new Size(762, 42);
            this.pnlOrderInput.Size = new Size(762, 31);
            this.xPanel1.Size = new Size(762, 32);
            this.tabGroup.Size = new Size(762, 29);

            // 2015.11.11 AnhNV Edited
            this.cboSearchCondition.Location = new Point(207, 39);
            this.cboQueryCon.Size = new Size(110, 20);
            this.txtSearch.Size = new Size(110, 20);
            this.txtSearch.Location = new Point(95, 40);
            this.xLabel5.Location = new Point(4, 40);
        }

        private void SetEnableRbn()
        {
            rbnSearchOrder.Visible = true;
            rbnSlipHangmog.Visible = true;
            rbnOftenOrder.Visible = true;
        }

        /// <summary>
        /// 해당 Screen의 각종 Control 관련 Setting
        /// </summary>
        public String InitializeScreen()
        {
            string returnValue = "";
            //저장에 필요한 Layout을 정의한다.
            mSaveLayout = new Hashtable();
            mSaveLayout.Add("OCS1003", this.grdOrder);

            //DatePicker 문제로 일단        Reset하고 현재일자를 넣어준다.
            //this.dpkOrder_Date.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            if (this.mOrderDate == "")
            {
                //this.dpkOrder_Date.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                //TODO
                //this.dpkOrder_Date.SetDataValue(DateTime.Parse(loadScreenResult.SysDate).ToString("yyyy/MM/dd"));
                returnValue = DateTime.Parse(loadScreenResult.SysDate).ToString("yyyy/MM/dd");
            }

            // 상용처방을 로드한다.
            //            if (this.mOrderMode == OrderVariables.OrderMode.SetOrder) // = 1
            //            {
            //                // 유저별 공통 모드인데 이건 어쩔까...
            //                string name = "";
            //                this.mOrderBiz.LoadColumnCodeName("gwa_doctor", "%", this.mMemb, EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"), ref name);
            //
            //                if (name == "")
            //                {
            //                    // 주과의 상용오더를 가져오자.
            //                    string mainDoctorCode = this.mOrderBiz.GetMainGwaDoctorCode(this.mMemb);
            //                    if (mainDoctorCode != "")
            //                        this.MakeSangyongTab(mainDoctorCode, INPUTTAB);
            //                    else
            //                        this.MakeSangyongTab(mMemb, INPUTTAB);
            //                }
            //                else
            //                {
            //                    this.MakeSangyongTab(mMemb, INPUTTAB);
            //                }
            //            }
            //            else
            //            {
            //                // 상용처방을 로드한다.
            //                if (UserInfo.UserGubun == UserType.Doctor)
            //                {
            //                    this.MakeSangyongTab(UserInfo.DoctorID, INPUTTAB);
            //                }
            //                else
            //                    this.MakeSangyongTab(UserInfo.UserID, INPUTTAB);
            //            }
            this.MakeSangyongTab2(loadScreenResult.UsedTabInfo);

            // 약오더를 로드한다.
            this.MakeSpecimenOrder();

            return returnValue;
        }


        private void setFocusGotoColumn()
        {
            //insert by jc [OCS1003P01のデータウインドーウで選択されたROWがあった場合の処理]
            //位置検索はすべてhangmog_codeで検索する
            //コメントのROWにもOrderBizで該当するHangmog_codeを入れているので検索可能である。
            //カーソルのコントロールの際にはgrdOrderのグリドを同時に動かす。
            //pkocskeyは使えない。なぜかというとpkocskeyは保存される際、トリガーによって与えられるので保存されてない状態では使えないのだ

            int currentRow = -1;
            if (mCurrentRowNum > 0)
            {
                //[OCS1003P01のデータウインドウで選択されたcolumnのデータ取得]
                string currentData = this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, this.mCurrentColName);
                //[OCS1003P01のデータウインドウで選択されたgroup_ser取得]
                string currentGroupSer = this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "group_ser_num");

                //[該当するGROUPTABに移動]
                this.SelectGroupTab(currentGroupSer);

                if (this.mCurrentColName == "hangmog_name"
                    || (this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "bogyong_code_yn") == "N" && this.mCurrentColName == "order_detail")
                    || (this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "bogyong_code_yn") == "N" && this.mCurrentColName == "order_info"))
                {
                    //[OCS1003P01のデータウインドウで選択されたhangmog_name取得]
                    string currentHangmogCode = this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "hangmog_code");

                    //[OCS1003P01のデータウインドウで選択されたデータの位置検索]
                    for (int i = 0; i < this.grdOrder.RowCount; i++)
                    {
                        if (this.grdOrder.GetItemString(i, "hangmog_code") == currentHangmogCode && this.grdOrder.GetItemString(i, "group_ser") == currentGroupSer)
                        {
                            currentRow = i;
                            break;
                        }
                    }
                }

                switch (this.mCurrentColName)
                {
                    case "hangmog_name":
                        this.grdOrder.SetFocusToItem(currentRow, "hangmog_code", true);
                        break;
                    case "order_detail":
                        this.grdOrder.SetFocusToItem(currentRow, "suryang", true);
                        break;
                    case "order_info":
                        if (currentData.Substring(0, 1) == "└")
                        {
                            this.grdOrder.SetFocusToItem(currentRow, "order_remark", true);
                        }
                        else if (currentData.Substring(1, 1) == "希")
                        {
                            this.grdOrder.SetFocusToItem(currentRow, "hope_date", true);
                        }
                        break;
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

        #region [ 각종 초기화 ]

        private void InitScreen()
        {
            SetSizeColumByLanguage();
            //this.grdOrder.AutoSizeColumn(3, 0);
            //this.grdOrder.AutoSizeColumn(4, 0);

            this.grdOrder.AutoSizeColumn(15, 0);　//비치
            this.grdOrder.AutoSizeColumn(7, 0); //HOPE_DATE

            this.grdOrder.AutoSizeColumn(6, 0); //comment
            //this.grdOrder.AutoSizeColumn(8, 0); //suryang
            //this.grdOrder.AutoSizeColumn(9, 0); //danui
            //this.grdOrder.AutoSizeColumn(10, 0); //nalsu
            this.grdOrder.AutoSizeColumn(11, 0); //dangil_gumsa
            this.grdOrder.AutoSizeColumn(12, 0); //dangil_result

            // 셋트 오더인경우는 정시약, 반납지시 컬럼이 보이면 안됨. 그룹시리얼도
            if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                this.mOrderMode == OrderVariables.OrderMode.CpSetOrder)
            {
                this.grdOrder.AutoSizeColumn(2, 0);
                this.grdOrder.AutoSizeColumn(7, 0);
                this.grdOrder.AutoSizeColumn(16, 0);
            }
            // 의사 오더인 경우는 반납지시 컬럼이 보이지 않ㄴㅡㄴ다.
            else if (UserInfo.UserGubun == UserType.Doctor)
            {
                this.grdOrder.AutoSizeColumn(2, 0);
            }

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder)
            {
                this.grdOrder.AutoSizeColumn(17, 0);
                this.grdOrder.AutoSizeColumn(18, 0);
            }
            else
            {
                this.grdOrder.AutoSizeColumn(16, 0);
            }

            // 입원 외래에 따른 조회 조건 기본셋팅값
            if (this.IOEGUBUN == "O")
            {
                this.cboQueryCon.SetDataValue("%"); // 전체 기본
            }
            else
            {
                this.cboQueryCon.SetDataValue("Y"); // 원내 채용약 기본
                //insert by jc 入院オーダでは当日カラムがないので画面から見えないように修正。START
                this.grdOrder.AutoSizeColumn(11, 0);//当日施行
                this.grdOrder.AutoSizeColumn(12, 0);//当日結果
                //insert by jc 入院オーダでは当日カラムがないので画面から見えないように修正。END
            }


            // 팝업메뉴 초기화
            // 오더 팝업메뉴
            // 처방Grid PopupMenu
            popupOrderMenu.MenuCommands.Clear();
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.MSG001_MSG, (Image)this.imageListPopupMenu.Images[0],
                new EventHandler(PopUpMenuSelectAll_Click)));
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.MSG002_MSG, (Image)this.imageListPopupMenu.Images[1],
                new EventHandler(PopUpMenuUnSelectAll_Click)));
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.MSG003_MSG, (Image)this.imageListPopupMenu.Images[2],
                new EventHandler(PopUpMenuInsert_Click)));
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.MSG004_MSG, (Image)this.imageListPopupMenu.Images[3],
                new EventHandler(PopUpMenuPaste_Click)));
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.MSG005_MSG, (Image)this.imageListPopupMenu.Images[4],
                new EventHandler(PopUpMenuDelete_Click)));
            //popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.MSG006_MSG, (Image)this.imageListPopupMenu.Images[7],
            //    new EventHandler(PopUpMenuSelectOftenOrder_Click)));
            //popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.MSG007_MSG, (Image)this.imageListPopupMenu.Images[8],
            //    new EventHandler(PopUpMenuRecoverToDandok_Click)));

            // 상용오더 팝업메뉴
            popupOftenUsedMenu.MenuCommands.Clear();
            popupOftenUsedMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.MSG008_MSG, (Image)this.imageListPopupMenu.Images[4],
                new EventHandler(PopUpMenuSelectOftenOrderDelete_Click)));
        }
        private void SetSizeColumByLanguage()
        {
            if(NetInfo.Language != LangMode.Jr)
            {
                grdOrder.AutoSizeColumn(3, 60);
                grdOrder.AutoSizeColumn(8,66);
                grdOrder.AutoSizeColumn(9,46);
                grdOrder.AutoSizeColumn(10,59);
                grdOrder.AutoSizeColumn(13,54);
                grdOrder.AutoSizeColumn(14,65);
                grdOrder.AutoSizeColumn(16,135);
                grdOrder.AutoSizeColumn(20,49);
                grdOrder.AutoSizeColumn(21,48);
                grdOrder.AutoSizeColumn(22,65);
            }
            else
            {
                grdOrder.AutoSizeColumn(3, 50);
                grdOrder.AutoSizeColumn(8, 38);
                grdOrder.AutoSizeColumn(9, 35);
                grdOrder.AutoSizeColumn(10, 35);
                grdOrder.AutoSizeColumn(13, 30);
                grdOrder.AutoSizeColumn(14, 30);
                grdOrder.AutoSizeColumn(16, 46);
                grdOrder.AutoSizeColumn(20, 28);
                grdOrder.AutoSizeColumn(21, 30);
                grdOrder.AutoSizeColumn(22, 30);
            }
        }

        private void SetInitialOrderGridData(DataTable aInData)
        {
            //modify by jc
            //foreach (DataRow dr in this.mInDataRow.Rows)
            foreach (DataRow dr in aInData.Rows)
            {
                this.grdOrder.LayoutTable.ImportRow(dr);
            }

            this.grdOrder.DisplayData();

            this.DiaplayMixGroup(this.grdOrder);

            // 부모자식 이미지 셋팅
            this.SetImageToGrid(this.grdOrder);

            // 의사오더 이미지 셋팅
            this.SetOrderImage(this.grdOrder);
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
            openParams.Add("order_remark", "");

            openParams.Add("bogyong_code", "");

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0208Q00", ScreenOpenStyle.ResponseSizable, openParams);
        }


        private void OpenScreen_OCS0301Q09()
        {
            //string naewon_date = mOrderDate.PadRight(10).Substring(0, 10).Replace("-", "/");
            string naewon_date = this.mOrderDate.PadRight(10).Substring(0, 10).Replace("-", "/");

            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("input_tab", INPUTTAB);


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


            openParams.Add("naewon_date", this.mOrderDate);
            //openParams.Add("naewon_date", mOrderDate);
            if (UserInfo.UserGubun == UserType.Doctor)
                openParams.Add("input_gubun", "D%");
            else
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

        /// <summary>
        /// 의뢰서 화면 오픈
        /// </summary>
        /// <param name="aGrid"></param>
        /// <param name="aRowNumber"></param>
        private void OpenScreen_SpecificComment(XEditGrid aGrid, int aRowNumber, string aSpecific_Comment)
        {
            //if (aGrid.GetItemString(aRowNumber, "specific_comment_pgm_id") == "")
            //{
            //    MessageBox.Show(XMsg.GetMsg("M008"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", aGrid.GetItemString(aRowNumber, "bunho"));
            openParams.Add("order_date", aGrid.GetItemString(aRowNumber, "order_date"));
            if (aGrid.GetItemString(aRowNumber, "pkocskey") == "")
            {
                aGrid.SetItemValue(aRowNumber, "pkocskey", this.mOrderFunc.GetOrderKey(this.mOrderMode));
            }

            openParams.Add("pkocskey", aGrid.GetItemString(aRowNumber, "pkocskey"));

            openParams.Add("in_out_gubun", this.IOEGUBUN);
            openParams.Add("hangmog_code", aGrid.GetItemString(aRowNumber, "hangmog_code"));
            openParams.Add("gwa", aGrid.GetItemString(aRowNumber, "gwa"));
            openParams.Add("doctor", aGrid.GetItemString(aRowNumber, "doctor"));
            openParams.Add("jundal_part", aGrid.GetItemString(aRowNumber, "jundal_part"));
            openParams.Add("naewon_key", aGrid.GetItemString(aRowNumber, "in_out_key"));

            //string sysid = aGrid.GetItemString(aRowNumber, "specific_comment_sys_id");
            //string pgmid = aGrid.GetItemString(aRowNumber, "specific_comment_pgm_id");
            if (aSpecific_Comment == "18")
                XScreen.OpenScreenWithParam(this, "PHYS", "PHY8002U00", ScreenOpenStyle.ResponseSizable, openParams);
            else if (aSpecific_Comment == "19")
                XScreen.OpenScreenWithParam(this, "PHYS", "PHY8002U01", ScreenOpenStyle.ResponseSizable, openParams);

        }

        private void SetEnableUcGrid(bool isEnable)
        {
            //tabGroup.Enabled = isEnable;
            grdOrder.Enabled = isEnable;
            grdSangyongOrder.Enabled = isEnable;
            grdSearchOrder.Enabled = isEnable;
            grdSlipHangmog.Enabled = isEnable;
            xLabel3.Enabled = isEnable;
            pnlOrderDetail.Enabled = isEnable;
            cbxEmergency.Enabled = isEnable;
            btnSpecificComment.Enabled = isEnable;
            btnDoOrder.Enabled = isEnable;
            btnSetOrder.Enabled = isEnable;
            btnInsert.Enabled = isEnable;
            btnNewSelect.Enabled = isEnable;
            btnSelect.Enabled = isEnable;
            
            if (isEnable) cbxEmergency.CheckedChanged += cbxEmergency_CheckedChanged;
            else cbxEmergency.CheckedChanged -= cbxEmergency_CheckedChanged;

            if (mBtnCopy != null) mBtnCopy.Enabled = isEnable;
            if (mBtnPaste != null) mBtnPaste.Enabled = isEnable;

            //right
            cboQueryCon.Enabled = isEnable;
            cboSearchCondition.Enabled = isEnable;
            txtSearch.Enabled = isEnable;
        }

        public string ScreenOpen(CommonItemCollection aOpenParam, ref string aInputGubunName)
        {
            this.grdOrder.Reset();
            this.loadScreenResult = this.LoadScreen(aOpenParam != null, aOpenParam);
            if (aOpenParam != null && aOpenParam.Contains("caller_screen_id"))
            {
                this.mCallerScreenID = aOpenParam["caller_screen_id"].ToString();
            }
            if (UserInfo.UserGubun == UserType.Doctor)
            {
                this.mDoctorLogin = true;
            }

            SetEnableUcGrid(true);
            isEnableGrd = true;
            if (aOpenParam != null && aOpenParam.Contains("is_enable_grd") && (bool)aOpenParam["is_enable_grd"].Equals(false))
            {
                SetEnableUcGrid(false);
                isEnableGrd = false;
            }

            this.mOrderBiz = new IHIS.OCS.OrderBiz(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());             // OCS 그룹 Business 라이브러리
            this.mOrderFunc = new IHIS.OCS.OrderFunc(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());            // OCS 그룹 Function 라이브러리
            this.mPatientInfo = new IHIS.OCS.PatientInfo(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());        // OCS 환자정보 그룹 라이브러리 
            this.mHangmogInfo = new IHIS.OCS.HangmogInfo(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());        // OCS 항목정보 그룹 라이브러리
            this.mInputControl = new IHIS.OCS.InputControl(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());      // 입력제어 그룹 라이브러리 
            this.mCommonForms = new IHIS.OCS.CommonForms();                 // OCS 공통Form's 그룹 라이브러리 
            this.mColumnControl = new ColumnControl(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());      // 입력제어 그룹 라이브러리 
            this.mInterface = new IHIS.OCS.OrderInterface();

            /*this.layDeletedData.SavePerformer = new XSavePeformer(this);
            this.laySaveLayout.SavePerformer = this.layDeletedData.SavePerformer;*/

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
                    this.mOrderDate = DateTime.Parse(loadScreenResult.SysDate).ToString("yyyy/MM/dd").Replace("-", "/");
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

                    this.mOrderBiz.LoadColumnCodeName("code", "INPUT_GUBUN", this.mInputGubun, ref aInputGubunName);
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

                    // 환자정보가 있으면 이거 가져다 넣어주ㅝ야 함.
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

                //his.MakeGroupTabInfo(this.IOEGUBUN, this.mPkInOutKey, this.mInputGubun, INPUTTAB);

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

                if (aOpenParam.Contains("startRowNum"))
                {
                    this.mStartRowNum = int.Parse(aOpenParam["startRowNum"].ToString());
                }
                if (aOpenParam.Contains("protocol_id"))
                {
                    this.protocolId = aOpenParam["protocol_id"].ToString();
                }

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

            //insert into [検索語の検索条件初期化] 2012/10/15 
            //Random selected [like %word%]
            //Front selected [like word%]
            // string mSentouSearchYN = this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "SENTOU_SEARCH_YN", this.IOEGUBUN);
            string mSentouSearchYN = this.loadScreenResult.UserOption;
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
            mDtOrderGubun = Utility.ConvertToDataTable(loadScreenResult.OrderGubunInfo);

            // 라디오 버튼
            //if (this.rbnSearchOrder.Checked == false)
            //{
            //    this.rbnSearchOrder.Checked = true;
            //}
            this.InitScreen();
            this.InitializeScreen();

            if (this.rbnOftenOrder.Checked == false)
            {
                this.rbnOftenOrder.Checked = true;
            }

            

            // 수량, 횟수 콤보 구성
            //this.mOrderBiz.SetNumCombo(this.grdOrder, "suryang", true);
            this.mOrderBiz.SetNumCombo(this.grdOrder, "suryang", true, Utility.ConvertToDataTable(loadScreenResult.SuryangInfo));
            // 수량, 횟수 콤보 구성
            //this.mOrderBiz.SetNumCombo(this.grdOrder, "nalsu", false);
            this.mOrderBiz.SetNumCombo(this.grdOrder, "nalsu", false, Utility.ConvertToDataTable(loadScreenResult.NalsuInfo));


            //MessageBox.Show("Onload end");

            this.mPostCallParam = aOpenParam;
            PostCallHelper.PostCall(new PostMethod(PostLoad));

            this.btnInsert.Visible = true;

            isOpenPopUp = aOpenParam.Contains("isOpenPopUp") ? (bool)aOpenParam["isOpenPopUp"] : true;
            if (aOpenParam.Contains("isOpenPopUp") && aOpenParam["isOpenPopUp"].Equals(true))
            {
                this.btnInsert.Visible = false;
            }

            return null;
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

        #region [ 각종 비지니스 메소드 ]


        /// <summary>
        /// 환자정보 라벨 셋팅
        /// TODO SetPatientInfo
        /// </summary>


        /// <summary>
        /// 그룹탭 선택시 그룹관련 정보들 셋팅
        /// </summary>
        /// <param name="aGroupInfo">그룹정보</param>
        private void SetGroupControl(Hashtable aGroupInfo)
        {
            // 긴급여부
            this.cbxEmergency.SetDataValue(aGroupInfo["emergency"].ToString());
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
                //if (this.mOrderMode == OrderVariables.OrderMode.SetOrder)
                //    this.btnSetOrder.Visible = false;
                this.btnSpecificComment.Visible = false;
            }
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

            //aGrid.SetItemValue(aRowNumber, "in_out_key", this.mPkInOutKey);
            aGrid.SetItemValue(aRowNumber, "input_part", this.mInputPart);
            aGrid.SetItemValue(aRowNumber, "input_gubun", this.mInputGubun);
            aGrid.SetItemValue(aRowNumber, "input_gubun_name", this.mInputGubunName);

            aGrid.SetItemValue(aRowNumber, "order_date", mOrderDate);

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


        }

        private void ApplyDefaultOrderInfo(MultiLayout aSourceLayout, int aSettingRow, bool aIsCallCodeInput)
        {
            int parentKey = -1;
            string ordergubunname = "";
            int settingRow = aSettingRow;
            Hashtable groupInfo;

            if (this.tabGroup.SelectedTab == null)
                HandleBtnListClick(FunctionType.Process);

            groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            // 그리드 상에서 직접 입력할때와 뭔가를 통해 입력할때...
            // 어디다 집어 넣어야 할지에 대한 헷갈림...
            // 직접 넣을 때는 현재 로우에 무조건 넣어야 하는데...
            // 근데... 뭔가를 통해서 넣을때는 현재 로우에 데이터가 있으면 안되거덩...
            // 그래서 저 컬럼을 두고 aIsCallCodeInput 이 true이면 무조건 현재 로우에 넣는거야...
            // 그거는 그리드에서 컬럼 체인지 탈때만...
            if (aIsCallCodeInput == false)
            {
                XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)this.grdOrder);

                if (emptyNewCell == null)
                {
                    this.OrderGridCreateNewRow(settingRow);
                    settingRow = this.grdOrder.CurrentRowNumber;
                }
                else
                {
                    settingRow = emptyNewCell.Row;
                }
            }

            for (int i = 0; i < aSourceLayout.RowCount; i++)
            {
                if (i != 0)
                {
                    this.OrderGridCreateNewRow(settingRow);
                    settingRow = this.grdOrder.CurrentRowNumber;
                }

                // 긴급 관련
                if (this.mOrderBiz.IsAbleToCurrentEmergencyGroup(groupInfo, aSourceLayout.LayoutTable.Rows[i]) == false)
                {
                    return;
                }

                foreach (DataColumn cl in this.grdOrder.LayoutTable.Columns)
                {
                    if (aSourceLayout.LayoutTable.Columns.Contains(cl.ColumnName))
                    {
                        this.grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = aSourceLayout.LayoutTable.Rows[i][cl.ColumnName];
                    }
                }

                // 디폴트 일수 
                if (TypeCheck.IsNull(this.grdOrder.LayoutTable.Rows[settingRow]["nalsu"]))
                    this.grdOrder.LayoutTable.Rows[settingRow]["nalsu"] = 1;

                // 오더 구분 관련 
                //if (aSourceLayout.GetItemString(i, "order_gubun").Length < 2)
                //    this.grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, this.grdOrder, settingRow) + aSourceLayout.GetItemString(i, "order_gubun");
                //else
                //    this.grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, this.grdOrder, settingRow) + aSourceLayout.GetItemString(i, "order_gubun").Substring(1, 1);

                //if (this.mOrderBiz.LoadColumnCodeName("code", "ORDER_GUBUN_BAS", this.grdOrder.LayoutTable.Rows[settingRow]["order_gubun"].ToString().Substring(1, 1), ref ordergubunname))
                //{
                //    if (ordergubunname == "")
                //    {
                //        ordergubunname = "そのた";
                //    }
                //}
                //else
                //{
                //    ordergubunname = "そのた";
                //}

                //this.grdOrder.LayoutTable.Rows[settingRow]["order_gubun_name"] = ordergubunname;
                //this.grdOrder.LayoutTable.Rows[currRow]["order_gubun_bas_name"] = ordergubunname;

                // 오더 구분 관련 
                if (aSourceLayout.GetItemString(i, "order_gubun").Length < 2)
                    this.grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, this.grdOrder, settingRow) + aSourceLayout.GetItemString(i, "order_gubun");
                else
                    this.grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, this.grdOrder, settingRow) + aSourceLayout.GetItemString(i, "order_gubun").Substring(1, 1);

                if (this.mOrderMode == OrderVariables.OrderMode.SetOrder)
                {
                    this.grdOrder.LayoutTable.Rows[settingRow]["jundal_table_out"] = aSourceLayout.GetItemString(i, "jundal_table_out");
                    this.grdOrder.LayoutTable.Rows[settingRow]["jundal_table_inp"] = aSourceLayout.GetItemString(i, "jundal_table_inp");
                    this.grdOrder.LayoutTable.Rows[settingRow]["jundal_part_out"] = aSourceLayout.GetItemString(i, "jundal_part_out");
                    this.grdOrder.LayoutTable.Rows[settingRow]["jundal_part_inp"] = aSourceLayout.GetItemString(i, "jundal_part_inp");
                    this.grdOrder.LayoutTable.Rows[settingRow]["move_part_out"] = aSourceLayout.GetItemString(i, "move_part");
                    this.grdOrder.LayoutTable.Rows[settingRow]["move_part_inp"] = aSourceLayout.GetItemString(i, "move_part");
                    // 일단 그냥도 넣어주자 외래 기준
                    this.grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = aSourceLayout.GetItemString(i, "jundal_table_out");
                    this.grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = aSourceLayout.GetItemString(i, "jundal_part_out");
                    this.grdOrder.LayoutTable.Rows[settingRow]["move_part"] = aSourceLayout.GetItemString(i, "move_part");

                }
                else
                {
                    // 현재 화면이 외래 모드인경우만 인서트
                    if (IOEGUBUN == "O")
                        this.grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = aSourceLayout.GetItemString(i, "jundal_table_out");
                    else
                        this.grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = aSourceLayout.GetItemString(i, "jundal_table_inp");

                    // 현재 화면이 외래 모드인경우만 인서트
                    if (IOEGUBUN == "O")
                        this.grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = aSourceLayout.GetItemString(i, "jundal_part_out");
                    else
                        this.grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = aSourceLayout.GetItemString(i, "jundal_part_inp");
                }
                // 입력컨트롤이 시간 분인경우 시간분 입력창을 띄운다...


                // 부모자식 연관관계 셋팅
                if (aSourceLayout.GetItemString(i, "child_yn") == "Y")
                {
                    parentKey = this.mOrderFunc.GetParentOrderKey(this.mOrderMode, this.grdOrder.LayoutTable, settingRow - 1);

                    if (parentKey < 0)
                    {
                        this.grdOrder.LayoutTable.Rows[settingRow]["child_yn"] = "N";
                    }
                    else
                    {
                        this.mOrderFunc.SetParentInfoToChild(this.grdOrder, parentKey.ToString(), settingRow);
                    }
                }
                else
                {
                    this.grdOrder.LayoutTable.Rows[settingRow]["child_yn"] = "N";
                }

                // 나중에 순서 재정렬을 위하여 dummy 값을 채워주고 재정렬후 뺀다.
                this.grdOrder.SetItemValue(settingRow, "dummy", "mageshin");

                // 依頼書作成中保存せず閉じたとしたらPHY8002　テーブルに FK_OCS　キーがないため　キーがないと保存してないと見なし、オーダを生成しない。
                string pkocskey = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "pkocskey");
                //                string str = @"SELECT A.FK_OCS
                //                                 FROM PHY8002 A 
                //                                WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + @"' 
                //                                  AND A.FK_OCS = " + pkocskey;
                //                object obj = Service.ExecuteScalar(str);

                if (String.IsNullOrEmpty(pkocskey))
                {
                    pkocskey = "";
                }

                OcsoOCS1003P01CheckFkOcsArgs args = new OcsoOCS1003P01CheckFkOcsArgs();
                args.FkOcs = pkocskey;
                OcsoOCS1003P01CheckFkOcsResult result =
                    CloudService.Instance.Submit<OcsoOCS1003P01CheckFkOcsResult, OcsoOCS1003P01CheckFkOcsArgs>(args);

                if (this.mOrderMode != OrderVariables.OrderMode.SetOrder
                    && this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
                {
                    if (result.ExecutionStatus == ExecutionStatus.Success)
                    {
                        if (result.FkOcs == "" &&
                            this.grdOrder.GetItemString(settingRow, "specific_comment") != "")
                            this.grdOrder.DeleteRow(this.grdOrder.CurrentRowNumber);
                    }
                }
                this.grdOrder.DisplayData();

                //this.SetOrderImage(this.grdOrder);

            }

        }

        //TODO: set e.IsBaseCall and e.Success
        public void HandleBtnListClick(FunctionType type)
        {
            switch (type)
            {
                case FunctionType.Process:

                    #region 신규 오더 그룹 탭 추가

                    this.MakeNewOrderGroup(true);
                    this.txtSearch.Focus();

                    #endregion

                    break;

                case FunctionType.Insert:

                    #region 신규 오더 입력


                    if (this.tabGroup.TabPages.Count <= 0)
                        HandleBtnListClick(FunctionType.Process);

                    //if (this.AcceptData() == false) return;

                    // Insert한 Row 중에 Not Null필드 미입력 Row Search 하여 해당 Row로 이동
                    XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)this.grdOrder);

                    if (emptyNewCell != null)
                    {
                        //e.IsSuccess = false;
                        //e.IsBaseCall = false;

                        ((XEditGrid)this.grdOrder).SetFocusToItem(emptyNewCell.Row, emptyNewCell.CellName);
                        break;
                    }

                    this.OrderGridCreateNewRow(this.grdOrder.CurrentRowNumber);

                    if (mContainer != null) this.mContainer.AcceptData();

                    //this.tabGroup_SelectionChanged(this.tabGroup, new EventArgs());
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

                    if (mContainer != null)
                    {
                        if (this.mContainer.AcceptData() == false)
                        {
                            return;
                        }
                    }

                    if (this.IsUpdateCheck() == false)
                        return;
                    /* -------------------------------------------------------------------------------------------------- */
                    //inser by jc [詳細画面での保存処理] START 2012/04/17
                    //[Merge : grdOrder -> laySaveLayout] 
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
                                                                this.mOrderDate,
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
                            //                            Service.BeginTransaction();

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

                        #region to be deleted
                        /*if (this.layDeletedData.SaveLayout() == false)
                            {
                                Service.RollbackTransaction(); // 롤백

                                this.mbxMsg = XMsg.GetMsg("M005") + " - " + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...

                                MessageBox.Show(this.mbxMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                                return;
                            }

                            if (this.mInterface.InsertDeletedDataToTempTable() == false)
                            {
                            }

                            if (this.laySaveLayout.SaveLayout() == false)
                            {
                                Service.RollbackTransaction();  // 롤백

                                this.mbxMsg = XMsg.GetMsg("M005") + " - " + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...

                                MessageBox.Show(this.mbxMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                                return;
                            }
                            else
                            {
                                // 저장이 완료된 후에 NDAY 건을 처리하기 위하여 NDAY OCCUR YN 프로시져를 호출한다.
                                string procName = "PR_OCS_APPLY_NDAY_ORDER";
                                ArrayList inList = new ArrayList();
                                ArrayList outList = new ArrayList();

                                inList.Add(this.fbxBunho.GetDataValue());
                                inList.Add(mOrderDate);

                                if (Service.ExecuteProcedure(procName, inList, outList) == false)
                                {
                                    Service.RollbackTransaction();  // 롤백

                                    this.mbxMsg = XMsg.GetMsg("M005") + " - " + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...

                                    MessageBox.Show(this.mbxMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    return;
                                }
                                else
                                {
                                    if (outList[0].ToString() != "0")
                                    {
                                        Service.RollbackTransaction();  // 롤백

                                        this.mbxMsg = XMsg.GetMsg("M005") + " - " + outList[0].ToString();  // 저장에 실패하였습니다 + 에러메세지...

                                        MessageBox.Show(this.mbxMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                                        return;
                                    }
                                }
                            }
                        }
                        catch
                        {
                            Service.RollbackTransaction();
                        }

                        Service.CommitTransaction();  // 커밋*/
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

                        this.mOrderBiz.PrintXRT(this.laySaveLayout, this.layDeletedData);
                    }
                    //inser by jc [詳細画面での保存処理] END 2012/04/17
                    /* -------------------------------------------------------------------------------------------------- */

                    this.InvokeReturnSendReturnDataTable();

                    if (mContainer != null && mContainer.Name != "OCS2015U00") this.mContainer.Close();

                    #endregion

                    break;

                case FunctionType.Delete:


                    if (mContainer != null) this.mContainer.AcceptData();

                    ArrayList deleteRow = new ArrayList();
                    ArrayList parentKeys = new ArrayList();

                    for (int i = 0; i < this.grdOrder.RowCount; i++)
                    {
                        if (this.grdOrder.IsSelectedRow(i) && this.grdOrder.IsVisibleRow(i))
                        {
                            deleteRow.Add(i);
                            if (this.grdOrder.GetItemString(i, "child_yn") == "N" && this.grdOrder.GetItemString(i, "pkocskey") != "" &&
                                parentKeys.Contains(this.grdOrder.GetItemString(i, "pkocskey")) == false)
                            {
                                parentKeys.Add(this.grdOrder.GetItemString(i, "pkocskey"));
                            }
                        }
                    }

                    if (deleteRow.Count > 0)
                    {
                        for (int j = 0; j < deleteRow.Count; j++)
                        {
                            if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                                this.mOrderMode == OrderVariables.OrderMode.CpSetOrder ||
                                //modify by jc
                                this.mHangmogInfo.IsOrderDataChagnedEnabled(IOEGUBUN, this.grdOrder, (int)deleteRow[j], "", OrderVariables.CheckMode.RowDelete, OrderVariables.ErrorDisplayMode.MessageBox))
                            //this.mHangmogInfo.IsOrderDataChagnedEnabled(IOEGUBUN, this.grdOrder, (int)deleteRow[j], "", OrderVariables.CheckMode.RowDelete, OrderVariables.ErrorDisplayMode.MessageBox))
                            {
                                if (this.grdOrder.IsVisibleRow(this.grdOrder.CurrentRowNumber))
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
                            {
                                if (this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "child_yn") == "N" && this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "pkocskey") != "" &&
                                    parentKeys.Contains(this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "pkocskey")) == false)
                                {
                                    parentKeys.Add(this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "pkocskey"));
                                }

                                this.grdOrder.DeleteRow(this.grdOrder.CurrentRowNumber);
                            }
                        }
                    }

                    if (parentKeys.Count > 0)
                    {
                        this.mOrderFunc.ReSettingParentKeyAfterDelete(this.grdOrder, parentKeys);
                        PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert));
                    }

                    this.grdOrder.UnSelectAll();

                    //this.tabGroup_SelectionChanged(this.tabGroup, new EventArgs());
                    this.DisplayOrderGridGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag);

                    PostCallHelper.PostCall(new PostMethodInt(PostCallAfterDeleteRow), this.mOrderFunc.GetLastRow(this.grdOrder.LayoutTable, ((Hashtable)this.tabGroup.SelectedTab.Tag)["group_ser"].ToString()));

                    break;

                case FunctionType.Cancel:

                    #region 현재 그룹 탭 삭제


                    this.DeleteCurrentGroupTab(this.tabGroup.SelectedTab);

                    #endregion

                    break;

                case FunctionType.Close:

                    if (mContainer != null) this.mContainer.AcceptData();
                    if (this.mOrderBiz.IsCloseOrderScreen(this.grdOrder))
                    {
                        if (mContainer != null) this.mContainer.Close();
                    }
                    else
                        return;
                    break;
            }
        }

        private void ApplySangOrderInfo(string aHangmogCode, int aRowNumber, HangmogInfo.ExecutiveMode mExecutiveMode, bool aIsApplyCurrentRow)
        {
            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.mInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IOEGUBUN;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;

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
            loadExtraInfo.LayoutItems.Add("emergency", DataType.String);
            loadExtraInfo.InitializeLayoutTable();

            Hashtable groupInfo;

            if (this.tabGroup.SelectedTab == null)
                HandleBtnListClick(FunctionType.Process);

            groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            loadExtraInfo.InsertRow(-1);
            // 항목정보
            loadExtraInfo.SetItemValue(0, "hangmog_code", aHangmogCode);
            // 그룹정보 로드
            // 그룹시리얼
            if (groupInfo.Contains("group_ser"))
            {
                loadExtraInfo.SetItemValue(0, "group_ser", groupInfo["group_ser"].ToString());
            }
            // Emergency
            if (groupInfo.Contains("emergency"))
            {
                loadExtraInfo.SetItemValue(0, "emergency", groupInfo["emergency"].ToString());
            }

            #endregion

            if (this.mHangmogInfo.LoadHangmogInfo(mExecutiveMode, loadExtraInfo) == false)
            {
                return;

            }



            this.ApplyDefaultOrderInfo(this.mHangmogInfo.GetHangmogInfo, aRowNumber, aIsApplyCurrentRow);

            //PostCallHelper.PostCall(new PostMethodObject(PostOrderInsert), currRow);

        }

        private void ApplyCopyOrderInfo(MultiLayout aSourceLayout, OCS.HangmogInfo.ExecutiveMode aMode)
        {
            ArrayList mParentList = new ArrayList();
            Hashtable mParentInfo;
            Hashtable groupInfo;

            bool isMerge = true;

            // insert by jc
            if (this.tabGroup.SelectedTab == null)
                HandleBtnListClick(FunctionType.Process);

            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.mInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IOEGUBUN;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                this.mHangmogInfo.Parameter.Bunho = this.mPatientInfo.GetPatientInfo["bunho"].ToString();
                this.mHangmogInfo.Parameter.NaewonKey = this.mPatientInfo.GetPatientInfo["naewon_key"].ToString();
                this.mHangmogInfo.Parameter.Gubun = this.mPatientInfo.GetPatientInfo["gubun"].ToString();
                this.mHangmogInfo.Parameter.Birth_Date = this.mPatientInfo.GetPatientInfo["birth"].ToString();
                this.mHangmogInfo.Parameter.Gwa = this.mPatientInfo.GetPatientInfo["gwa"].ToString();
                this.mHangmogInfo.Parameter.ApproveDoctor = this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString();
                //this.mHangmogInfo.Parameter.Wonyoi_Order_Yn_Wonmu = this.cbxWonyoiOrderYN.GetDataValue();
            }

            if (this.mHangmogInfo.LoadHangmogInfo(aMode, aSourceLayout) == false)
            {
                return;
            }

            int settingStart = -1;
            int settingEnd = -1;
            int settingRow = -1;

            // 셋팅 시작 로우

            XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)this.grdOrder);

            if (emptyNewCell == null)
            {
                this.OrderGridCreateNewRow(this.grdOrder.CurrentRowNumber);
                settingStart = this.grdOrder.CurrentRowNumber;
            }
            else
            {
                settingStart = emptyNewCell.Row;
            }

            settingRow = settingStart;

            // 셋팅 끝 로우 
            settingEnd = settingStart + aSourceLayout.RowCount - 1;

            // 그룹정보
            groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            //foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
            foreach (DataRow dr in this.mHangmogInfo.GetHangmogInfo.LayoutTable.Rows)
            {
                emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)this.grdOrder);

                if (emptyNewCell == null)
                {
                    this.OrderGridCreateNewRow(this.grdOrder.CurrentRowNumber);
                    settingRow = this.grdOrder.CurrentRowNumber;
                }
                else
                {
                    settingRow = emptyNewCell.Row;
                }

                // 긴급 관련
                if (this.mOrderBiz.IsAbleToCurrentEmergencyGroup(groupInfo, dr) == false)
                {
                    break;
                }

                foreach (DataColumn cl in this.grdOrder.LayoutTable.Columns)
                {
                    if (groupInfo.Contains(cl.ColumnName))
                    {
                        this.grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = groupInfo[cl.ColumnName];
                    }
                    else if (this.mHangmogInfo.GetHangmogInfo.LayoutTable.Columns.Contains(cl.ColumnName))
                    {
                        if (cl.ColumnName != "child_gubun" &&
                            cl.ColumnName != "parent_gubun")
                            this.grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = dr[cl.ColumnName];
                    }
                }

                // 오더 구분 관련 
                if (dr["order_gubun"].ToString().Length < 2)
                    this.grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, this.grdOrder, settingRow) + dr["order_gubun"].ToString();
                else
                    this.grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, this.grdOrder, settingRow) + dr["order_gubun"].ToString().Substring(1, 1);

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    this.grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_out"];
                else
                    this.grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_inp"];

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    this.grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_out"];
                else
                    this.grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_inp"];

                if (this.mOrderFunc.IsParentCopyOrder(aSourceLayout, dr))
                {
                    this.grdOrder.SetItemValue(settingRow, "child_yn", "N");
                    mParentInfo = new Hashtable();
                    mParentInfo.Add("row_num", settingRow);
                    mParentInfo.Add("key", dr["org_key"].ToString());

                    mParentList.Add(mParentInfo);
                }
                else
                {
                    this.grdOrder.SetItemValue(settingRow, "child_yn", "Y");
                }

                this.grdOrder.SetItemValue(settingRow, "dummy", "mageshin");
            }

            this.mOrderFunc.ChildParentOrderKeyMapping(this.mOrderMode, this.grdOrder, settingStart, settingEnd, mParentList, this.mCurrentRow);

            PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert));

            string pkocskey = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "pkocskey");
            /*string str = @"SELECT A.FK_OCS
                                 FROM PHY8002 A 
                                WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + @"' 
                                  AND A.FK_OCS = " + pkocskey;
            object obj = Service.ExecuteScalar(str);*/
            OCS0103U11GetFkocsArgs args = new OCS0103U11GetFkocsArgs();
            args.Pkocskey = pkocskey;
            OCS0103U11GetFkocsResult result =
                CloudService.Instance.Submit<OCS0103U11GetFkocsResult, OCS0103U11GetFkocsArgs>(args);

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder
                && this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                if (result.Result.Trim() == "" && this.grdOrder.GetItemString(settingRow, "specific_comment") != "")
                    this.grdOrder.DeleteRow(this.grdOrder.CurrentRowNumber);
            }
            this.grdOrder.DisplayData();

            //this.SetOrderImage(this.grdOrder);
        }

        private void InvokeReturnSendReturnDataTable()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("isOpenPopUp", isOpenPopUp);
            if (this.mOrderMode == OrderVariables.OrderMode.InpOrder && this.mCallerScreenID != "OCS2003P01")
                param.Add("reha_order", this.laySaveLayout);
            else
                param.Add("reha_order", this.grdOrder);

            //((XScreen)this.Opener).Command(this.Name, param);
            if (mOpener != null) mOpener.Command("OCS0103U11", param);
        }

        private bool IsUpdateCheck()
        {
            Hashtable groupInfo;
            ArrayList delList = new ArrayList();
            bool isUpdatable = true;
            string msg = "";
            string cap = "";

            #region 체크전 데이터 확인 ( 빈로우, 빈그룹 삭제 )

            if (this.mOrderFunc == null)
            {
                return false;
            }
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

            return isUpdatable;
        }

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
        #endregion

        #region 오더 그리드 신규 로우 생성

        private void OrderGridCreateNewRow(int aRowNumber)
        {
            this.grdOrder.InsertRow(aRowNumber);

            // 그룹 기준 셋팅
            this.GridInitValueSetting(this.grdOrder, this.grdOrder.CurrentRowNumber);
        }

        #endregion

        #region  부모 자식 이미지 셋팅

        private void SetImageToGrid(XEditGrid grd)
        {
            for (int i = 0; i < grd.RowCount; i++)
            {
                // 부모인경우
                if (grd.GetItemString(i, "child_yn") != "Y")
                {

                    grd[i + grd.HeaderHeights.Count, 1].Image = this.ImageGrouping.Images[0];

                }
                // 자식인경우
                else
                {
                    grd[i + grd.HeaderHeights.Count, 1].Image = this.ImageGrouping.Images[1];
                }
            }
        }

        #endregion

        #region 부모자식 관련 로우 재구성

        private int SetRowSort()
        {
            MultiLayout mTemp = this.grdOrder.CloneToLayout();
            DataRow[] dtRows = this.grdOrder.LayoutTable.Select("child_yn='N'");
            DataRow[] chRows = this.grdOrder.LayoutTable.Select("child_yn='Y'");
            ArrayList parentList = new ArrayList();
            ArrayList childList = new ArrayList();
            ArrayList addedList = new ArrayList();
            int lastRow = -1;

            // 부모 복사
            for (int i = 0; i < dtRows.Length; i++)
            {
                parentList.Add(dtRows[i]);
            }

            // 자식복사
            for (int j = 0; j < chRows.Length; j++)
            {
                childList.Add(chRows[j]);
            }

            foreach (DataRow tr in parentList)
            {
                mTemp.LayoutTable.ImportRow(tr);

                addedList.Clear();

                foreach (DataRow cr in childList)
                {
                    if (tr["pkocskey"].ToString() == cr["bom_source_key"].ToString())
                    {
                        mTemp.LayoutTable.ImportRow(cr);
                        addedList.Add(cr);
                    }
                }

                foreach (DataRow deldr in addedList)
                {
                    childList.Remove(deldr);
                }
            }


            this.grdOrder.SuspendLayout();


            //this.grdOrder.Reset();
            this.grdOrder.LayoutTable.Clear();

            foreach (DataRow imdr in mTemp.LayoutTable.Rows)
            {
                this.grdOrder.LayoutTable.ImportRow(imdr);
            }

            this.grdOrder.DisplayData();

            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                if (this.grdOrder.GetItemString(i, "dummy") == "mageshin")
                {
                    //this.grdOrder.SetFocusToItem(i, "hangmog_code", false);
                    this.grdOrder.SetItemValue(i, "dummy", "");
                    //break;
                    lastRow = i;
                }
            }

            //this.tabGroup_SelectionChanged(this.tabGroup, new EventArgs());
            this.DisplayOrderGridGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag);

            this.grdOrder.ResumeLayout();

            return lastRow;
        }

        #endregion

        #region 오더링 로우 이동

        private void MoveOrderRow(XEditGrid grid, int aSourceRowNumber, int aDestRowNumber)
        {
            if (aSourceRowNumber == aDestRowNumber) return;

            MultiLayout mTempLayout = grid.CloneToLayout();
            int parentKey = -1;

            for (int i = 0; i < grid.RowCount; i++)
            {
                if (i == aSourceRowNumber)
                    continue;

                if (i == aDestRowNumber)
                {
                    parentKey = this.mOrderFunc.GetParentOrderKey(this.mOrderMode, this.grdOrder.LayoutTable, i, true);

                    if (parentKey > 0)
                    {
                        this.grdOrder.SetItemValue(aSourceRowNumber, "child_yn", "Y");
                        this.grdOrder.SetItemValue(aSourceRowNumber, "bom_source_key", parentKey);

                        this.MoveOrderRowSub(grid, aSourceRowNumber);
                    }
                    else
                    {
                        this.grdOrder.SetItemValue(aSourceRowNumber, "child_yn", "N");
                        this.grdOrder.SetItemValue(aSourceRowNumber, "bom_source_key", "");
                    }

                    this.grdOrder.SetItemValue(aSourceRowNumber, "dummy", "mageshin");

                    mTempLayout.LayoutTable.ImportRow(grid.LayoutTable.Rows[aSourceRowNumber]);

                }

                mTempLayout.LayoutTable.ImportRow(grid.LayoutTable.Rows[i]);
            }
        }

        private void MoveOrderRowSub(XEditGrid grid, int aSourceRow)
        {
            if (grid.GetItemString(aSourceRow, "pkocskey") != "")
            {
                foreach (DataRow dr in grid.LayoutTable.Select("bom_source_key=" + grid.GetItemString(aSourceRow, "pkocskey")))
                {
                    dr["bom_source_key"] = grid.GetItemString(aSourceRow, "bom_source_key");
                }
            }
        }

        #endregion

        #region 처방Row 이동시 Control Display 변경처리(OrderRowMovingChangedDisplay)
        /// <summary>
        /// 처방Row 이동시 Control Display 변경처리
        /// </summary>
        /// <param name="aGrd"> XEditGrid  Grid </param>
        /// <param name="aRow"> int  Row </param>
        /// <returns> void </returns>
        private void OrderRowMovingChangedDisplay(XEditGrid aGrd, int aRow)
        {
            if (aGrd == null || aRow < 0) return;

            // 상태에 따른 필드헤더변경 (수량/날수 (마취처방코드인 경우 시간/분으로 표시), 부수술 (체감인경우 체감))
            this.mHangmogInfo.DisplaySpecialColHeader(IOEGUBUN, aGrd, aRow, aGrd.GetItemString(aRow, "hangmog_code").Trim());

            //			// 현재 버튼 크기가 작어서 처리못함
            //			if (!TypeCheck.IsNull(aGrd.GetItemString(aRow, "specific_comment_name")))
            //				this.btnSpecificComment.Text = aGrd.GetItemString(aRow, "specific_comment_name"); // 항목별 서식지관리 명칭
            //			else
            //				this.btnSpecificComment.Text = TypeCheck.NVL(this.btnSpecificComment.Tag, "").ToString(); // 항목별 서식지관리 최초 명칭으로 초기화
        }
        #endregion

        #region 반납 지시 관련 컬럼 보이기

        private void ShowDcGubun(XEditGrid aGrid, string aGroupSer)
        {
            DataRow[] dr = aGrid.LayoutTable.Select("group_ser=" + aGroupSer + " AND dc_gubun='Y'");

            if (dr != null && dr.Length > 0)
            {
                aGrid.AutoSizeColumn(2, 35);
            }
            else
            {
                aGrid.AutoSizeColumn(2, 0);
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
            this.grdOrder.SetBindVarValue("memb", aMemb);
            this.grdOrder.SetBindVarValue("yaksok_code", aYaksokCode);
            this.grdOrder.SetBindVarValue("fk_in_out_key", aFkInOutKey);
            this.grdOrder.SetBindVarValue("input_tab", aInputTab);
            this.grdOrder.SetBindVarValue("input_gubun", aInputGubun);

            this.grdOrder.QueryLayout(true);
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

            if (groupSer == 1)
            {
                groupSer = this.mInitialGroupSer + groupSer;
            }

            tpg.Title = groupSer.ToString() + Resources.XMsg_00001;
            Hashtable groupInfo = new Hashtable();

            groupInfo.Add("group_ser", groupSer);
            groupInfo.Add("group_name", tpg.Title);
            groupInfo.Add("emergency", "N");

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
                bool isExist = false;

                foreach (DataRow dr in this.grdOrder.LayoutTable.Rows)
                {
                    // 의사인경우는 넘어온 input_gubun 과 일치하는 입력구분만 보여주고
                    // 의사 이외의 경우는 의사 오더 및 자신의 입력구분에 해당하는 오더를 전부 보여준다.
                    //if ((this.mInputGubun.Substring(0, 1) == "D" && dr["input_gubun"].ToString() == this.mInputGubun) ||
                    //     (this.mInputGubun.Substring(0, 1) != "D" && (dr["input_gubun"].ToString() == this.mInputGubun || dr["input_gubun"].ToString().Substring(0, 1) == "D")))
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

                                ldTab.Title = dr["group_ser"].ToString() + Resources.XMsg_00001;
                                ldTab.ImageList = this.ImageList;
                                ldTab.ImageIndex = 1;

                                groupInfo = new Hashtable();
                                groupInfo.Add("group_ser", dr["group_ser"]);
                                groupInfo.Add("group_name", dr["group_ser"].ToString() + Resources.XMsg_00001);
                                //groupInfo.Add("bogyong_code", dr["bogyong_code"].ToString());
                                //groupInfo.Add("bogyong_name", dr["bogyong_name"].ToString());
                                groupInfo.Add("emergency", dr["emergency"].ToString());
                                //groupInfo.Add("nalsu", dr["nalsu"].ToString());
                                //groupInfo.Add("wonyoi_order_yn", dr["wonyoi_order_yn"].ToString());

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
                    HandleBtnListClick(FunctionType.Process);
                }
            }
        }

        #endregion

        #region 그룹탭 관련 적용 모듈

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

            //if (aExistGroupInfo.Contains("bogyong_code"))
            //{
            //    bogyongCode = aExistGroupInfo["bogyong_code"].ToString();
            //}
            //if (aExistGroupInfo.Contains("bogyong_name"))
            //{
            //    bogyongName = aExistGroupInfo["bogyong_name"].ToString();
            //}
            //if (aExistGroupInfo.Contains("dv"))
            //{
            //    dv = aExistGroupInfo["dv"].ToString();
            //}
            //if (aExistGroupInfo.Contains("nalsu"))
            //{
            //    nalsu = aExistGroupInfo["nalsu"].ToString();
            //}
            if (aExistGroupInfo.Contains("emergency"))
            {
                emergency = aExistGroupInfo["emergency"].ToString();
            }
            //if (aExistGroupInfo.Contains("wonyoi_order_yn"))
            //{
            //    wonyoi_order_yn = aExistGroupInfo["wonyoi_order_yn"].ToString();
            //}
            //if (aExistGroupInfo.Contains("donbog_yn"))
            //{
            //    donbogyn = aExistGroupInfo["donbog_yn"].ToString();
            //}
            //if (aExistGroupInfo.Contains("order_remark"))
            //{
            //    orderRemark = aExistGroupInfo["order_remark"].ToString();
            //}

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
            // 탭인포에 적용
            Hashtable tabInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            this.tabGroup.SelectedTab.Title = tabInfo["group_ser"].ToString() + Resources.XMsg_00001;

            if (aBogyongCode != "")
            {
                this.tabGroup.SelectedTab.Title += ":" + aBogyongName;
            }


            if (tabInfo.Contains("emergency"))
                tabInfo.Remove("emergency");
            tabInfo.Add("emergency", aEmergency);


            // 오더에 적용
            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                // 같은 그룹의 오더들은 변경해준다.
                // 긴급
                if (this.grdOrder.GetItemString(i, "group_ser") == tabInfo["group_ser"].ToString())
                {
                    // 접수하기 전의 오더만 가능
                    if (this.grdOrder.GetRowState(i) == DataRowState.Added ||
                        (this.grdOrder.GetItemString(i, "ocs_flag") == "0" || this.grdOrder.GetItemString(i, "ocs_flag") == "1"))
                    {
                        // 긴급
                        if (this.grdOrder.GetItemString(i, "emergency") != aEmergency)
                        {
                            this.grdOrder.SetItemValue(i, "emergency", aEmergency);
                        }

                    }
                }
            }
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

            if (aExistGroupInfo.Contains("emergency"))
            {
                emergency = aExistGroupInfo["emergency"].ToString();
            }

            // 접수하기 전의 오더만 가능
            if (this.grdOrder.GetRowState(aSetRowNumber) == DataRowState.Added ||
                (this.grdOrder.GetItemString(aSetRowNumber, "ocs_flag") == "0" || this.grdOrder.GetItemString(aSetRowNumber, "ocs_flag") == "1"))
            {
                // 긴급
                if (this.grdOrder.GetItemString(aSetRowNumber, "emergency") != emergency)
                {
                    this.grdOrder.SetItemValue(aSetRowNumber, "emergency", emergency);
                }
            }
        }

        #endregion

        #region 현재 그룹 삭제

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
                // delete by jc グループを削除すると二回Confirmするので一回は消す。
                //if (MessageBox.Show(XMsg.GetMsg("M011"), XMsg.GetField("F002"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                //    return false;

                this.tabGroup.TabPages.Remove(aDestTabPage);

            }
            else
            {
                MessageBox.Show(XMsg.GetMsg("M012"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            //this.grdSangyongOrder.Reset();
            ////insert by jc [検索条件追加] 2012/10/15
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
            DataTable sangyongTab = this.mOrderBiz.LoadOftenUsedTabInfo(aMemb, aInputTab);
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

            for (int i = 0; i < sangyongTab.Rows.Count; i++)
            {
                tpg = new IHIS.X.Magic.Controls.TabPage();
                tpg.Title = sangyongTab.Rows[i]["order_gubun_name"].ToString();
                tpg.ImageList = this.ImageList;
                tpg.ImageIndex = 1;

                tabInfo = new Hashtable();
                tabInfo.Add("order_gubun", sangyongTab.Rows[i]["order_gubun"].ToString());
                tabInfo.Add("memb", sangyongTab.Rows[i]["memb"].ToString());
                //tabInfo.Add("xrt_yn", sangyongTab.Rows[i]["xray_yn"].ToString());
                tpg.Tag = tabInfo;

                this.tabSangyongOrder.TabPages.Add(tpg);
            }

            this.tabSangyongOrder.SelectionChanged += new EventHandler(tabSangyongOrder_SelectionChanged);

            this.tabSangyongOrder_SelectionChanged(this.tabSangyongOrder, new EventArgs());
        }

        // MinhLS
        private void MakeSangyongTab2(IEnumerable<LoadOftenUsedTabResponseInfo> itemList)
        {
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

            foreach (LoadOftenUsedTabResponseInfo item in itemList)
            {
                tpg = new IHIS.X.Magic.Controls.TabPage();
                tpg.Title = item.OrderGubunName;
                tpg.ImageList = this.ImageList;
                tpg.ImageIndex = 1;

                tabInfo = new Hashtable();
                tabInfo.Add("order_gubun", item.OrderGubun);
                tabInfo.Add("memb", item.Memb);
                //tabInfo.Add("xrt_yn", sangyongTab.Rows[i]["xray_yn"].ToString());
                tpg.Tag = tabInfo;

                this.tabSangyongOrder.TabPages.Add(tpg);
            }

            this.tabSangyongOrder.SelectionChanged += new EventHandler(tabSangyongOrder_SelectionChanged);

            this.tabSangyongOrder_SelectionChanged(this.tabSangyongOrder, new EventArgs());
        }

        void tabSangyongOrder_SelectionChanged(object sender, EventArgs e)
        {
            XTabControl control = sender as XTabControl;
            Hashtable tabInfo;
            string memb = "";

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

        #region [ 오더 검색 모듈 ]

        private void LoadSearchOrderInfo(string aSearchWord, string aGijunDate, string aInputTab, string aWonnaeDrgYn)
        {
            this.grdSearchOrder.Reset();
            //inser by jc [検索条件追加] 2012/10/15
            //if (aSearchWord.Trim() == "") return;

            //DataTable dtSearchResult = this.mOrderBiz.LoadSearchOrderInfo(aSearchWord, aGijunDate, aInputTab, aWonnaeDrgYn, this.cboSearchCondition.SelectedValue.ToString());

            //if (dtSearchResult != null && dtSearchResult.Rows.Count > 0)
            //{
            //    this.grdSearchOrder.ImportRowRange(dtSearchResult, 0);
            //    this.grdSearchOrder.DisplayData();
            //    this.grdSearchOrder.ResetUpdate();
            //}
            this.grdSearchOrder.SetBindVarValue("f_search_word", aSearchWord);
            this.grdSearchOrder.SetBindVarValue("f_gijun_date", aGijunDate);
            this.grdSearchOrder.SetBindVarValue("f_input_tab", aInputTab);
            this.grdSearchOrder.SetBindVarValue("f_wonnae_drg_yn", aWonnaeDrgYn);
            this.grdSearchOrder.SetBindVarValue("f_search_condition", this.cboSearchCondition.SelectedValue.ToString());
            this.grdSearchOrder.ExecuteQuery = ExecuteLoadSearchOrderInfo;
            this.grdSearchOrder.QueryLayout(false);

        }

        #endregion

        #region [ 검체오더 모듈 ]

        //TreeNode currNode;

        private void MakeSpecimenOrder()
        {
            // 분류 데이터 로드 
            this.LoadSlipCode();

            this.tvwSlipCode.AfterSelect -= new TreeViewEventHandler(tvwSlipCode_AfterSelect);

            this.tvwSlipCode.Nodes.Clear();

            TreeNode parentNode = new TreeNode();
            TreeNode childNode;
            Hashtable parentNodeInfo;
            Hashtable childNodeInfo;

            string currentParent = "";

            foreach (DataRow dr in this.laySlipCodeTree.LayoutTable.Rows)
            {
                if (currentParent != dr["code"].ToString())
                {
                    //if (currentParent != "")
                    //{
                    //    this.tvwSlipCode.Nodes.Add(parentNode);
                    //}

                    parentNode = new TreeNode(dr["code_name"].ToString(), 5, 6);
                    parentNodeInfo = new Hashtable();
                    //parentNodeInfo.Add("xray_code_yn", dr["xray_code_yn"].ToString());
                    parentNodeInfo.Add("code", dr["code"].ToString());
                    //parentNode.Tag = dr["code"].ToString();
                    parentNode.Tag = parentNodeInfo;

                    childNode = new TreeNode(dr["code_name1"].ToString(), 1, 0);
                    childNodeInfo = new Hashtable();
                    //childNodeInfo.Add("xray_code_yn", dr["xray_code_yn"].ToString());
                    childNodeInfo.Add("code", dr["code"].ToString());
                    childNodeInfo.Add("code1", dr["code1"].ToString());
                    //childNode.Tag = dr["code1"].ToString();
                    childNode.Tag = childNodeInfo;

                    parentNode.Nodes.Add(childNode);

                    //
                    tvwSlipCode.Nodes.Add(parentNode);

                    currentParent = dr["code"].ToString();
                }
                else
                {
                    childNode = new TreeNode(dr["code_name1"].ToString(), 1, 0);
                    childNodeInfo = new Hashtable();
                    //childNodeInfo.Add("xray_code_yn", dr["xray_code_yn"].ToString());
                    childNodeInfo.Add("code", dr["code"].ToString());
                    childNodeInfo.Add("code1", dr["code1"].ToString());
                    //childNode.Tag = dr["code1"].ToString();
                    childNode.Tag = childNodeInfo;

                    parentNode.Nodes.Add(childNode);
                }
            }

            this.tvwSlipCode.ExpandAll();
            this.tvwSlipCode.AfterSelect += new TreeViewEventHandler(tvwSlipCode_AfterSelect);

            this.rbnSlipHangmog.Checked = true;
            //this.tvwSlipCode.SelectedNode = this.tvwSlipCode.Nodes[0].Nodes[0];


        }



        private void tvwSlipCode_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (e.Node.Nodes.Count > 0)
            {
                this.grdSlipHangmog.Reset();
            }
            else
            {
                string wonnaeDrgYn = this.cboQueryCon.GetDataValue();
                this.LoadSlipHangmog("1", ((Hashtable)e.Node.Tag), wonnaeDrgYn, "");
            }
        }

        private void LoadSlipCode()
        {
            this.laySlipCodeTree.ExecuteQuery = LoadSlipCodeTree;
            this.laySlipCodeTree.QueryLayout(true);
        }

        //private void LoadSlipHangmog(Hashtable aCode1)
        private void LoadSlipHangmog(string aMode, Hashtable aNodeInfo, string aWonnaeDrgYn, string aSearchWord)
        {
            this.grdSlipHangmog.ParamList = CreateSlipHangmogParamList();

            /*string searchword = "";
            string cmd = " SELECT FN_ADM_CONVERT_KATAKANA_FULL('" + aSearchWord + "' ) " +
                         "   FROM SYS.DUAL ";

            if (aSearchWord != "%" && aSearchWord != "")
            {
                object returnVal = Service.ExecuteScalar(cmd);

                if (returnVal != null && returnVal.ToString() != "")
                {
                    searchword = returnVal.ToString();
                }
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
                        searchword = searchword;
                        break;
                    default:
                        searchword = "%" + searchword + "%";
                        break;


                }
            }
            else if (aSearchWord == "")
            {
                searchword = "%";
            }*/

            this.grdSlipHangmog.SetBindVarValue("f_mode", aMode);
            // this.grdSlipHangmog.SetBindVarValue("f_search_word", searchword);
            this.grdSlipHangmog.SetBindVarValue("f_search_word", aSearchWord);
            this.grdSlipHangmog.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            if (aMode == "1")
            {
                //if (aNodeInfo["xray_code_yn"].ToString() == "Y")
                //{
                //    this.grdSlipHangmog.SetBindVarValue("f_xray_code_yn", aNodeInfo["xray_code_yn"].ToString());
                //    this.grdSlipHangmog.SetBindVarValue("f_slip_code", aNodeInfo["code"].ToString());
                //    this.grdSlipHangmog.SetBindVarValue("f_xray_buwi", aNodeInfo["code1"].ToString());
                //    this.grdSlipHangmog.SetBindVarValue("f_specimen_code", "%");
                //    this.grdSlipHangmog.SetBindVarValue("f_hosp_code", mHospCode);
                //    this.grdSlipHangmog.SetBindVarValue("f_input_tab", INPUTTAB);

                //}
                //else
                //{
                //this.grdSlipHangmog.SetBindVarValue("f_xray_code_yn", aNodeInfo["xray_code_yn"].ToString());
                this.grdSlipHangmog.SetBindVarValue("f_slip_code", aNodeInfo["code1"].ToString());
                //this.grdSlipHangmog.SetBindVarValue("f_specimen_code", "%");
                this.grdSlipHangmog.SetBindVarValue("f_hosp_code", mHospCode);
                this.grdSlipHangmog.SetBindVarValue("f_input_tab", INPUTTAB);

                //}
            }
            else
            {
                //this.grdSlipHangmog.SetBindVarValue("f_specimen_code", "%");
                this.grdSlipHangmog.SetBindVarValue("f_slip_code", "%");
                this.grdSlipHangmog.SetBindVarValue("f_hosp_code", mHospCode);
                this.grdSlipHangmog.SetBindVarValue("f_input_tab", INPUTTAB);
            }

            if (this.mOrderMode == OrderVariables.OrderMode.InpOrder || this.mOrderMode == OrderVariables.OrderMode.OutOrder)
                this.grdSlipHangmog.SetBindVarValue("f_order_date", mOrderDate);
            else
                this.grdSlipHangmog.SetBindVarValue("f_order_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));

            this.grdSlipHangmog.ExecuteQuery = LoadGrdSlipHangmog;
            this.grdSlipHangmog.QueryLayout(true);
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

        private void btnExpandSearch_Click(object sender, EventArgs e)
        {
            if (this.mIsSearchExtended == false)
            {
                this.btnExpandSearch.ImageIndex = 3;
                this.pnlOrderInfo.Size = new Size(this.OrderMinWidth, this.pnlOrderInfo.Size.Height);

                this.grdSlipHangmog.AutoSizeColumn(1, this.SlipHangmogNameMaxWidth);
                this.grdSearchOrder.AutoSizeColumn(1, this.SearchHangmogNameMaxWidth);
                this.grdSangyongOrder.AutoSizeColumn(1, this.SangYongHangmogMaxWidth);

                this.mIsSearchExtended = true;
            }
            else
            {
                this.btnExpandSearch.ImageIndex = 4;
                this.pnlOrderInfo.Size = new Size(this.OrderNormalWidth, this.pnlOrderInfo.Size.Height);

                this.grdSlipHangmog.AutoSizeColumn(1, this.SlipHangmogNameNormalWidth);
                this.grdSearchOrder.AutoSizeColumn(1, this.SearchHangmogNameNormalWidth);
                this.grdSangyongOrder.AutoSizeColumn(1, this.SangYongHangmogNormalWidth);

                this.mIsSearchExtended = false;
            }
        }

        #region Do Set 오더 버튼

        private void btnSetOrder_Click(object sender, EventArgs e)
        {
            this.mCurrentRow = this.grdOrder.CurrentRowNumber;

            this.OpenScreen_OCS0301Q09();

            this.mCurrentRow = -1;
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

            /*//Old code
            mCopy_gubun = mBtnCopy != null ? mBtnCopy.Tag.ToString() : "1";*/
            mCopy_gubun = isCut ? "0" : "1";

            if (this.grdOrder.LayoutTable == null) return;

            bool isSelectedRow = false; // Select ?? 
            ArrayList selectedRow = new ArrayList();  // Selected Row's

            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                if (this.grdOrder.IsSelectedRow(i) && this.grdOrder.IsVisibleRow(i) && this.mOrderFunc.GetEmptyNewRow(this.grdOrder, i) == null) // Select ?? ??
                {
                    selectedRow.Add(i);
                    isSelectedRow = true;
                }
            }

            if (!isSelectedRow)
            {
                mbxMsg = Resources.MSG009_MSG;

                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
                return;
            }

            if (mPbxCopy != null) this.mPbxCopy.Visible = false;  // ??? Copy? ??? ???? False

            // DataTable ?? ?? ?? ??? ?? ??
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

            //this.pbxCopy.Visible = true; // Copy? ??? ???? true
            this.grdOrder.UnSelectAll();

            if (mCopy_gubun == "0")
            {
                Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;
                this.DisplayOrderGridGroupInfo(groupInfo);
            }
        }


        #endregion

        #region Mix 설정
        private void btnMix_Click(object sender, System.EventArgs e)
        {
            this.mHangmogInfo.SetMaxMixGroup(this.grdOrder);

            this.DiaplayMixGroup(this.grdOrder); // Mix Group 데이타 Image Display

            //this.mHangmogInfo.SetAlignMixGroup(grdOrder, settingStartRow, settingRow); // Mix Group 정렬

        }
        #endregion

        #region Mix 해제
        private void btnMixCancel_Click(object sender, System.EventArgs e)
        {
            this.mHangmogInfo.ReSetMixGroup(this.grdOrder);

            this.DiaplayMixGroup(this.grdOrder); // Mix Group 데이타 Image Display

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
            //if (rbnOftenOrder.Checked == true)
            //{
            //    grid = this.grdSangyongOrder as XGrid;
            //}
            //else
            //{
            //    grid = this.grdSearchOrder as XGrid;
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

            //this.ApplySangOrderInfo(grid.GetItemString(grid.CurrentRowNumber, "hangmog_code"), applyRow);

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

        #endregion

        #region 선택

        private void btnSelect_Click(object sender, EventArgs e)
        {
            XGrid grid;
            int rownumber = -1;

            if (this.tabGroup.SelectedTab == null)
            {
                HandleBtnListClick(FunctionType.Process);
            }

            // 현재 선택된 그리드의 항목코드 셋팅
            if (rbnOftenOrder.Checked == true)
            {
                grid = this.grdSangyongOrder as XGrid;
                rownumber = this.grdOrder.CurrentRowNumber;
            }
            else if (rbnSlipHangmog.Checked == true)
            {
                grid = this.grdSlipHangmog as XGrid;
                rownumber = this.grdOrder.CurrentRowNumber;
            }
            else
            {
                grid = this.grdSearchOrder as XGrid;
                rownumber = -1;
            }

            if (grid.RowCount <= 0 ||
                grid.CurrentRowNumber < 0) return;

            this.ApplySangOrderInfo(grid.GetItemString(grid.CurrentRowNumber, "hangmog_code"), this.grdOrder.CurrentRowNumber, HangmogInfo.ExecutiveMode.CodeInput, false);

            PostCallHelper.PostCall(new PostMethod(PostOrderInsert));
        }

        #endregion

        #region 의뢰서

        private void btnSpecificComment_Click(object sender, EventArgs e)
        {
            int currRow = -1;
            currRow = this.grdOrder.CurrentRowNumber;
            if (currRow < 0)
            {
                XMessageBox.Show(Resources.MSG013_MSG, Resources.CAP_13);
            };
            //RowStatus変更のために弄る。
            //this.grdOrder.SetItemValue(currRow, "nalsu", 1);
            this.OpenScreen_SpecificComment(this.grdOrder, currRow, this.grdOrder.GetItemString(currRow, "specific_comment"));
        }

        #endregion

        #endregion

        #region [ 오더 라디오 버튼 ]

        private void OrderRadio_CheckedChanged(object sender, EventArgs e)
        {
            XRadioButton control = sender as XRadioButton;
            //insert by jc TABが変わる際に検索語が既にあった場合はその検索語で検索する。
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

                        this.pnlSearch.Visible = true;
                        this.pnlSangyong.Visible = false;
                        this.pnlSlipHangmog.Visible = false;
                        this.grdSearchOrder.Reset();
                        PostCallHelper.PostCall(new PostMethod(PostSearchChecked));
                        //insert by jc TABが変わる際に検索語が既にあった場合はその検索語で検索する。
                        if (searchVoc != "")
                        {
                            if (this.rbnSearchOrder.Checked)
                                this.LoadSearchOrderInfo(searchVoc, mOrderDate, INPUTTAB, wonnaeDrgYn);
                        }
                        break;

                    case "rbnOftenOrder":    // 상용오더

                        this.pnlSearch.Visible = false;
                        this.pnlSangyong.Visible = true;
                        this.pnlSlipHangmog.Visible = false;
                        PostCallHelper.PostCall(new PostMethod(PostSearchChecked));
                        this.tabSangyongOrder_SelectionChanged(this.tabSangyongOrder, new EventArgs());

                        break;

                    case "rbnSlipHangmog":       // 효능별

                        this.pnlSearch.Visible = false;
                        this.pnlSangyong.Visible = false;
                        this.pnlSlipHangmog.Visible = true;
                        this.grdSlipHangmog.Reset();
                        PostCallHelper.PostCall(new PostMethod(PostSearchChecked));
                        //insert by jc TABが変わる際に検索語が既にあった場合はその検索語で検索する。
                        if (searchVoc != "")
                        {
                            if (this.rbnSlipHangmog.Checked)
                                this.LoadSlipHangmog("2", null, wonnaeDrgYn, this.txtSearch.GetDataValue());
                        }
                        this.tvwSlipCode.SelectedNode = null;
                        if (tvwSlipCode.Nodes.Count > 0)
                            this.tvwSlipCode.SelectedNode = this.tvwSlipCode.Nodes[0].Nodes[0];

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

        private void PostSearchChecked()
        {
            this.txtSearch.Focus();
        }

        #endregion

        #region XTab Control

        private void tabGroup_ClosePressed(object sender, EventArgs e)
        {
            IHIS.X.Magic.Controls.TabControl control = sender as IHIS.X.Magic.Controls.TabControl;
            // 탭 닫기 버튼을 누르는경우
            Hashtable groupInfo = control.SelectedTab.Tag as Hashtable;

            if (groupInfo["group_name"].ToString() == "New")
            {
                return;
            }

            // 오더가 있는경우와 없는경우로 나눈다.
            // 오더가 있는경우는 삭제 불가
            // 오더가 없는 경우만 삭제가 가능하다
            if (this.grdOrder.RowCount <= 0)
            {
                this.tabGroup.TabPages.Remove(control.SelectedTab);
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

                    this.DisplayOrderGridGroupInfo((Hashtable)tpg.Tag);

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

        #region [ 버튼 리스트 ]

        //TODO implement in OCS0103U11

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
        }

        #endregion

        #region [ 파인드 박스 이벤트 ]

        #endregion

        #region [ 그리드 이벤트 ]

        #region [ 오더 그리드 ]

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

            this.mHangmogInfo.ColumnColorForOrderState(IOEGUBUN, grd, e); // 처방상태에 따른 색상 처리

            dv = grd.GetItemString(e.RowNumber, "dv");

            // 공통 이외의 DV 처리
            switch (e.ColName)
            {
                case "dv_1":
                    if (grd.GetItemString(e.RowNumber, "donbog_yn") == "Y")
                        e.BackColor = OrderVariables.DisplayFieldColor.Color;
                    break;
                case "dv_2":
                    if (grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt("dv") == false)
                    {
                        e.BackColor = OrderVariables.DisplayFieldColor.Color;
                    }
                    else
                    {
                        if (int.Parse("dv") < 2)
                        {
                            e.BackColor = OrderVariables.DisplayFieldColor.Color;
                        }
                    }
                    break;
                case "dv_3":
                    if (grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt("dv") == false)
                    {
                        e.BackColor = OrderVariables.DisplayFieldColor.Color;
                    }
                    else
                    {
                        if (int.Parse("dv") < 3)
                        {
                            e.BackColor = OrderVariables.DisplayFieldColor.Color;
                        }
                    }
                    break;
                case "dv_4":
                    if (grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt("dv") == false)
                    {
                        e.BackColor = OrderVariables.DisplayFieldColor.Color;
                    }
                    else
                    {
                        if (int.Parse("dv") < 4)
                        {
                            e.BackColor = OrderVariables.DisplayFieldColor.Color;
                        }
                    }
                    break;

            }

        }

        private void grdOrder_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

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
                    //insert by jc [CellのWidthが０である場合はProtectを掛けてカーソルが行っても反応しないようにするため] 2012/02/20
                    this.grdOrder[e.RowNumber, e.ColName].AbsoluteRectangle.Width == 0)
                    e.Protect = true;
            }

            string dv = grd.GetItemString(e.RowNumber, "dv");

            // 공통 이외의 DV 처리
            switch (e.ColName)
            {
                case "dv_1":
                    if (grd.GetItemString(e.RowNumber, "donbog_yn") == "Y")
                        e.Protect = true;
                    break;
                case "dv_2":
                    if (grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt("dv") == false)
                    {
                        e.Protect = true;
                    }
                    else
                    {
                        if (int.Parse("dv") < 2)
                        {
                            e.Protect = true;
                        }
                    }
                    break;
                case "dv_3":
                    if (grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt("dv") == false)
                    {
                        e.Protect = true;
                    }
                    else
                    {
                        if (int.Parse("dv") < 3)
                        {
                            e.Protect = true;
                        }
                    }
                    break;
                case "dv_4":
                    if (grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt("dv") == false)
                    {
                        e.Protect = true;
                    }
                    else
                    {
                        if (int.Parse("dv") < 4)
                        {
                            e.Protect = true;
                        }
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

                    if (this.mOrderDate == "")
                    {
                        return;
                    }

                    this.OpenScreen_OCS0103Q00(grid.GetItemString(e.RowNumber, e.ColName), true); // 화면오픈

                    break;

                case "bogyong_code":  // 부위코드

                    e.Cancel = false;

                    if (grid.GetItemString(e.RowNumber, "hangmog_code") != "" && grid.GetItemString(e.RowNumber, "input_control") == "A")
                    {
                        this.OpenScreen_CHT0117Q00(grid.GetItemString(e.RowNumber, "order_gubun_bas"));
                    }

                    break;

                case "specimen_code":

                    e.Cancel = false;

                    if (grid.GetItemString(e.RowNumber, "hangmog_code") != "")
                    {
                        ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("specimen_code_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));
                    }

                    break;

                case "ord_danui_name":  // 오더단위

                    if (grid.GetItemString(e.RowNumber, "hangmog_code") != "")
                    {
                        // ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker(e.ColName, grid.GetItemString(e.RowNumber, "hangmog_code"));

                        // https://sofiamedix.atlassian.net/browse/MED-9500
                        ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker =
                            LoadFindWorker(e.ColName, grid.GetItemString(e.RowNumber, "hangmog_code"));
                    }

                    break;

                case "jundal_part": // 전달파트
                    // 외래 전달 파트 
                    if (this.IOEGUBUN == "O")
                    {
                        // ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_out_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                        ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker =
                            LoadFindWorker("jundal_part_out_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));
                    }
                    // 입원 전달파트 
                    else
                    {
                        // ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_inp_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

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
                    this.mHangmogInfo.Parameter.Wonyoi_Order_Yn_Wonmu = "N";

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
                    loadExtraInfo.LayoutItems.Add("emergency", DataType.String);
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
                    // Emergency
                    if (groupInfo.Contains("emergency"))
                    {
                        loadExtraInfo.SetItemValue(0, "emergency", groupInfo["emergency"].ToString());
                    }


                    #endregion

                    if (this.mHangmogInfo.LoadHangmogInfo(HangmogInfo.ExecutiveMode.CodeInput, loadExtraInfo) == false)
                    {
                        this.mOrderFunc.UndoPreviousValue(grid, e.RowNumber, e.ColName, previousValue);
                        this.OpenScreen_OCS0103Q00(e.ChangeValue.ToString(), true);
                        return;
                    }

                    int currentRow = this.grdOrder.CurrentRowNumber;

                    this.ApplyDefaultOrderInfo(this.mHangmogInfo.GetHangmogInfo, this.grdOrder.CurrentRowNumber, true);



                    //this.SetImageToGrid(grdOrder);
                    //this.DiaplayMixGroup(grid);

                    PostCallHelper.PostCall(new PostMethod(PostOrderInsert));

                    #endregion

                    break;

                case "ord_danui":

                    string code = "";
                    string codename = "";

                    if (e.ChangeValue.ToString() == "")
                    {
                        this.mOrderBiz.GetDefaultOrdDanui(hangmog_code, ref code, ref codename);

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
                        //if (this.mOrderBiz.GetJundaTable(this.IOEGUBUN, hangmog_code, grid.GetItemString(e.RowNumber, "order_date"), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)
                        if (this.mOrderBiz.GetJundaTable(this.IOEGUBUN, hangmog_code, TypeCheck.NVL(grid.GetItemString(e.RowNumber, "order_date"), mOrderDate).ToString(), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)
                        {
                            grid.SetItemValue(e.RowNumber, "jundal_table", jundalTable);
                            grid.SetItemValue(e.RowNumber, "move_part", movePart);
                        }
                    }
                    else if (e.ColName == "jundal_part_out")
                    {
                        //if (this.mOrderBiz.GetJundaTable("O", hangmog_code, grid.GetItemString(e.RowNumber, "order_date"), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)
                        if (this.mOrderBiz.GetJundaTable("O", hangmog_code, TypeCheck.NVL(grid.GetItemString(e.RowNumber, "order_date"), mOrderDate).ToString(), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)
                        {
                            grid.SetItemValue(e.RowNumber, "jundal_table_out", jundalTable);
                            grid.SetItemValue(e.RowNumber, "move_part_out", movePart);
                        }
                    }
                    else if (e.ColName == "jundal_part_inp")
                    {
                        //if (this.mOrderBiz.GetJundaTable("I", hangmog_code, grid.GetItemString(e.RowNumber, "order_date"), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)
                        if (this.mOrderBiz.GetJundaTable("I", hangmog_code, TypeCheck.NVL(grid.GetItemString(e.RowNumber, "order_date"), mOrderDate).ToString(), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)
                        {
                            grid.SetItemValue(e.RowNumber, "jundal_table_inp", jundalTable);
                            grid.SetItemValue(e.RowNumber, "move_part_inp", movePart);
                        }
                    }

                    break;

                case "hope_date":

                    if (e.ChangeValue.ToString() != "")
                    {
                        if (this.grdOrder.GetItemString(e.RowNumber, "dangil_gumsa_order_yn") == "Y")
                        {
                        }
                    }
                    else
                    {
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
        }



        private void grdOrder_Click(object sender, EventArgs e)
        {
            int lRow = grdOrder.CurrentRowNumber;
            string lResult = "";
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
                int curRowIndex = -1;
                int parentRowIndex = -1;
                XEditGrid grd = sender as XEditGrid;

                curRowIndex = grd.GetHitRowNumber(e.Y);


                if (e.Button == MouseButtons.Left && e.Clicks == 1)
                {
                    if (curRowIndex < 0) return;

                    // 재료만 이동이 가능함.
                    if (grd.GetItemString(curRowIndex, "if_input_control") != "P")
                    {
                        this.mDragX = e.X;
                        this.mDragY = e.Y;
                        ////Drag시 show info정보
                        //string dragInfo = "[" + grd.GetItemString(curRowIndex, "hangmog_code") + "]" + grd.GetItemString(curRowIndex, "hangmog_name");
                        //DragHelper.CreateDragCursor(grd, dragInfo, this.Font);
                        //grd.DoDragDrop("OrderGrid" + "|" + curRowIndex.ToString(), DragDropEffects.Move);

                        this.mDragRowIndex = curRowIndex;
                        this.mIsDrag = true;
                    }
                }

                if (e.Button == MouseButtons.Right && e.Clicks == 1)
                {
                    this.grdOrder.SetFocusToItem(curRowIndex, "hangmog_name");
                    popupOrderMenu.TrackPopup(grd.PointToScreen(new Point(e.X, e.Y)));
                }

                if (e.Button == MouseButtons.Left && e.Clicks == 2)
                {
                    switch (grd.CurrentColName)
                    {
                        case "hangmog_name":
                            //// 시간 , 분 처리
                            //DataRow dRow = this.mOrderFunc.CopyDataRow(grd.LayoutTable.Rows[grd.CurrentRowNumber]);

                            //if (!TypeCheck.IsNull(grd.GetItemString(curRowIndex, "hangmog_code")) && this.mHangmogInfo.GetInputTime(this, dRow))
                            //{
                            //    grd.SetItemValue(curRowIndex, "suryang", dRow["suryang"]);
                            //    grd.SetItemValue(curRowIndex, "nalsu", dRow["nalsu"]);
                            //}
                            this.btnSpecificComment.PerformClick();
                            break;
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void grdOrder_MouseMove(object sender, MouseEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            int offset = Math.Abs(this.mDragY - e.Y);

            if (this.mIsDrag && offset > 5)
            {
                //Drag시 show info정보
                string dragInfo = "[" + grd.GetItemString(this.mDragRowIndex, "hangmog_code") + "]" + grd.GetItemString(this.mDragRowIndex, "hangmog_name");
                DragHelper.CreateDragCursor(grd, dragInfo, this.Font);
                grd.DoDragDrop("OrderGrid" + "|" + this.mDragRowIndex.ToString(), DragDropEffects.Move);
            }
        }

        private void grdOrder_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.mIsDrag && e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                this.mDragX = 0;
                this.mDragY = 0;
                this.mDragRowIndex = -1;
                this.mIsDrag = false;
            }
        }

        #region 드레그엔 드랍 관련

        private void grdOrder_DragDrop(object sender, DragEventArgs e)
        {
            string data = e.Data.GetData("System.String").ToString();
            string gubun = data.Split('|')[0];
            string sourceRow = data.Split('|')[1];
            string hangmogCode = "";

            Point clientPoint = grdOrder.PointToClient(new Point(e.X, e.Y));
            int rowNumber = grdOrder.GetHitRowNumber(clientPoint.Y);

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
                case "SlipHangmog":

                    hangmogCode = this.grdSlipHangmog.GetItemString(int.Parse(sourceRow), "hangmog_code");

                    this.ApplySangOrderInfo(hangmogCode, rowNumber, HangmogInfo.ExecutiveMode.CodeInput, false);

                    PostCallHelper.PostCall(new PostMethod(PostOrderInsert));

                    break;

                case "Search":

                    hangmogCode = this.grdSearchOrder.GetItemString(int.Parse(sourceRow), "hangmog_code");

                    this.ApplySangOrderInfo(hangmogCode, rowNumber, HangmogInfo.ExecutiveMode.CodeInput, false);

                    PostCallHelper.PostCall(new PostMethod(PostOrderInsert));

                    break;

                case "SangYong":

                    hangmogCode = this.grdSangyongOrder.GetItemString(int.Parse(sourceRow), "hangmog_code");

                    this.ApplySangOrderInfo(hangmogCode, rowNumber, HangmogInfo.ExecutiveMode.CodeInput, false);

                    PostCallHelper.PostCall(new PostMethod(PostOrderInsert));

                    break;

                case "OrderGrid":

                    this.MoveOrderRow(grdOrder, int.Parse(sourceRow), rowNumber);

                    PostCallHelper.PostCall(new PostMethod(PostOrderInsert));

                    break;
            }

            this.mIsDrag = false;
            this.mDragX = 0;
            this.mDragY = 0;
            this.mDragRowIndex = -1;

        }

        private void grdOrder_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;  // Move 표시	
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

        #endregion

        private void grdOrder_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            this.OrderRowMovingChangedDisplay((XEditGrid)sender, e.CurrentRow);
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
                    aGrid[i + aGrid.HeaderHeights.Count, 0].Image = this.ImageList.Images[10];
                    aGrid[i + aGrid.HeaderHeights.Count, 0].ToolTipText = Resources.MSG011_MSG + aGrid[i + aGrid.HeaderHeights.Count, 0].ToolTipText;
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
                    loadParams.Add("category_gubun", OrderVariables.CATEGORY_COMMENT); // 처방Comment

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
            int applyRow = -1;

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

        #region [ 검체오더 그리드 ]

        private void grdSlipHangmog_MouseDown(object sender, MouseEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;
            int rowNumber = -1;

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
                grid.DoDragDrop("SlipHangmog" + "|" + rowNumber.ToString(), DragDropEffects.Move);
            }
        }

        private void grdSlipHangmog_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void grdSlipHangmog_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            // Drag시에 Cursor 바꿈
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                Cursor.Current = DragHelper.DragCursor;
            }
        }

        private void grdSlipHangmog_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            //this.mColumnControl.ColumnColorForCodeQueryGrid(IOEGUBUN, grid, e);

            if (grid.CellInfos.Contains("trial_flg"))
            {
                if (grid.GetItemString(e.RowNumber, "trial_flg") == "Y")
                {
                    e.BackColor = Color.Plum;
                }
            }
        }

        #endregion

        #region [ 검색 그리드 ]

        private void grdSearchOrder_MouseDown(object sender, MouseEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;
            int rowNumber = -1;

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

        #region [ 체크박스 이벤트 ]

        private void cbxEmergency_CheckedChanged(object sender, EventArgs e)
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

        private void cbxWonyoiOrderYN_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (this.tabGroup.SelectedTab == null) return;

            this.ApplyGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag, "wonyoi_order_yn", e.DataValue, "", "", "");
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
            //else if (this.rbnSlipHangmog.Checked)
            //{
            //    this.LoadSlipHangmog("2", null, wonnaeDrgYn, e.DataValue);
            //}

            //PostCallHelper.PostCall(new PostMethod(PostSearchValidating));

        }

        private void PostSearchValidating()
        {
            // this.txtSearch.SetDataValue("");
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
            else if (this.rbnSlipHangmog.Checked)
            {
                if (this.grdSlipHangmog.RowCount <= 0)
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


        #endregion

        #region [ 콤보 박스 이벤트 ]

        private void cboQueryCon_SelectedValueChanged(object sender, EventArgs e)
        {
            this.txtSearch.Focus();
            this.Search_text();
        }

        #endregion

        #endregion

        #region [ Command ]

        //TODO
        public override object Command(string command, CommonItemCollection commandParam)
        {
            //this.AcceptData();

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
                                HandleBtnListClick(FunctionType.Insert);
                                this.ApplySangOrderInfo(dr["hangmog_code"].ToString(), this.grdOrder.CurrentRowNumber, HangmogInfo.ExecutiveMode.CodeInput, true);
                            }
                        }

                        PostCallHelper.PostCall(new PostMethod(PostOrderInsert));
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

                        //PostCallHelper.PostCall(new PostMethodObject(PostOrderInsert), -1);

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
                        }

                        //PostCallHelper.PostCall(new PostMethodObject(PostOrderInsert), -1);

                        //this.grdOrder.AcceptData();

                    }

                    #endregion

                    break;
                case "PHY8002U00":
                    if (commandParam["PHY8002U00"].ToString() == "changed")
                    {
                        this.grdOrder.SetItemValue(this.grdOrder.CurrentRowNumber, "nalsu", 1);
                        this.grdOrder.Refresh();
                    }
                    break;
                case "PHY8002U01":
                    if (commandParam["PHY8002U01"].ToString() == "changed")
                    {
                        this.grdOrder.SetItemValue(this.grdOrder.CurrentRowNumber, "nalsu", 1);
                        this.grdOrder.Refresh();
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
            if (this.mBtnList == null || this.mBtnList.Enabled)
            {
                this.grdOrder.Focus();
                HandleBtnListClick(FunctionType.Delete);
            }
        }
        // Copy
        private void PopUpMenuInsert_Click(object sender, System.EventArgs e)
        {
            if (this.mBtnCopy == null || this.mBtnCopy.Enabled)
            {
                this.HandleBtnCopyClick(false);
            }
        }
        // Paster
        private void PopUpMenuPaste_Click(object sender, System.EventArgs e)
        {
            if (this.mBtnPaste == null || this.mBtnPaste.Enabled)
            {
                this.HandleBtnPasteClick();
            }
        }

        public void HandleBtnPasteClick()
        {
            string mbxMsg = "", mbxCap = "";

            //this.AcceptData();

            if (this.mLayDtOrderBuffer == null || this.mLayDtOrderBuffer.Rows.Count == 0)
            {
                mbxMsg = Resources.MSG010_MSG;

                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
                return;
            }

            // DataTable 데이타를 처방Grid에 카피한다
            MultiLayout lay = this.mOrderFunc.CloneDataLayoutMIO(this.grdOrder);

            foreach (DataRow dRow in this.mLayDtOrderBuffer.Rows) lay.LayoutTable.ImportRow(dRow);

            this.grdOrder.SetFocusToItem(this.grdOrder.RowCount - 1, "hangmog_code", false);

            this.mCurrentRow = this.grdOrder.CurrentRowNumber;

            this.ApplyCopyOrderInfo(lay, HangmogInfo.ExecutiveMode.OrderCopy);

            //PostCallHelper.PostCall(new PostMethodObject(this.PostOrderInsert), -1);
            // 로직 구동후에 사용자 입력 편의를 위해서 맨 마지막 Row로 이동한다
            //this.grdOrder.SetFocusToItem(this.grdOrder.RowCount - 1, "hangmog_code");

            //this.grdOrder.UnSelectAll();
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
        // 재료로 묶여 있는것을 단독으로 변경
        private void PopUpMenuRecoverToDandok_Click(object sender, System.EventArgs e)
        {
            ArrayList selectedRow = new ArrayList();
            //int maxRow = -1;
            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                if (this.grdOrder.IsSelectedRow(i))
                {
                    selectedRow.Add(i);
                }
            }

            if (selectedRow.Count > 0)
            {
                foreach (int j in selectedRow)
                {
                    this.grdOrder.SetItemValue(j, "child_yn", "N");
                    this.grdOrder.SetItemValue(j, "bom_source_key", "");
                    // 나중에 순서 재정렬을 위하여 dummy 값을 채워주고 재정렬후 뺀다.
                    this.grdOrder.SetItemValue(j, "dummy", "mageshin");

                    //maxRow = j;

                }
            }
            else
            {
                this.grdOrder.SetItemValue(this.grdOrder.CurrentRowNumber, "child_yn", "N");
                this.grdOrder.SetItemValue(this.grdOrder.CurrentRowNumber, "bom_source_key", "");
                this.grdOrder.SetItemValue(this.grdOrder.CurrentRowNumber, "dummy", "mageshin");

                //maxRow = this.grdOrder.CurrentRowNumber;
            }

            this.grdOrder.DisplayData();

            this.PostOrderInsert();
        }


        #endregion

        #region [ Post 이벤트 들 ]

        private void PostOrderInsert()
        {
            int lastRow = this.SetRowSort();

            this.SetImageToGrid(grdOrder);

            this.SetOrderImage(grdOrder);

            if (lastRow >= 0)
                this.grdOrder.SetFocusToItem(lastRow, "hangmog_code", false);

            this.grdOrder.AcceptData();

            //if (TypeCheck.IsNull(aValidInfo) == false)
            //{
            //    if (TypeCheck.IsInt(aValidInfo.ToString()))
            //    {
            //        this.grdOrder.SetFocusToItem(int.Parse(aValidInfo.ToString()), "hangmog_code", true);
            //    }
            //}
        }

        #endregion

        private void tabGroup_SelectionChanging(object sender, EventArgs e)
        {
            if (this.tabGroup.SelectedTab == null)
                return;

            Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            if (groupInfo.Contains("emergency") && groupInfo["emergency"].ToString() != this.cbxEmergency.GetDataValue())
            {
                this.cbxEmergency.AcceptData();
            }
        }

        public void HandleBtnIlgwalChangeClick()
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
            bool IsSelectedOrder = false;
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
                    if (this.mHangmogInfo.IsOrderDataChagnedEnabled(this.IOEGUBUN, this.grdOrder, i, "hope_date", OrderVariables.CheckMode.DataUpdate, OrderVariables.ErrorDisplayMode.NoDisplay) == false)
                    {
                        MessageBox.Show(XMsg.GetMsg("M034"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (this.mHangmogInfo.IsOrderDataChagnedEnabled(this.IOEGUBUN, this.grdOrder, i, "dangil_gumsa_order_yn", OrderVariables.CheckMode.DataUpdate, OrderVariables.ErrorDisplayMode.NoDisplay) == false)
                    {
                        MessageBox.Show(XMsg.GetMsg("M034"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (this.mHangmogInfo.IsOrderDataChagnedEnabled(this.IOEGUBUN, this.grdOrder, i, "dangil_gumsa_result_yn", OrderVariables.CheckMode.DataUpdate, OrderVariables.ErrorDisplayMode.NoDisplay) == false)
                    {
                        MessageBox.Show(XMsg.GetMsg("M034"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                IsSelectedOrder = true;
                foreach (int row in selectedIndex)
                {
                    if (this.mHangmogInfo.IsOrderDataChagnedEnabled(this.IOEGUBUN, this.grdOrder, row, "hope_date", OrderVariables.CheckMode.DataUpdate, OrderVariables.ErrorDisplayMode.NoDisplay) == false)
                    {
                        MessageBox.Show(XMsg.GetMsg("M034"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (this.mHangmogInfo.IsOrderDataChagnedEnabled(this.IOEGUBUN, this.grdOrder, row, "dangil_gumsa_order_yn", OrderVariables.CheckMode.DataUpdate, OrderVariables.ErrorDisplayMode.NoDisplay) == false)
                    {
                        MessageBox.Show(XMsg.GetMsg("M034"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (this.mHangmogInfo.IsOrderDataChagnedEnabled(this.IOEGUBUN, this.grdOrder, row, "dangil_gumsa_result_yn", OrderVariables.CheckMode.DataUpdate, OrderVariables.ErrorDisplayMode.NoDisplay) == false)
                    {
                        MessageBox.Show(XMsg.GetMsg("M034"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            //Hashtable returnValue = mCommonForms.ProcessHopeDateIlgwalChange(2);
            Hashtable returnValue = this.mCommonForms.ProcessIlgwalChange(2, "OCS0103U11", this.IOEGUBUN, IsSelectedOrder);

            #endregion

            #region リターン値に対するプロセス

            if (returnValue != null)
            {
                string allGroup = returnValue["allGroup"].ToString();

                if (selectedIndex.Count <= 1)
                {
                    for (int i = 0; i < this.grdOrder.RowCount; i++)
                    {
                        foreach (DataColumn cl in this.grdOrder.LayoutTable.Columns)
                        {
                            if (returnValue.Contains(cl.ColumnName))
                            {
                                if (this.mHangmogInfo.IsOrderDataChagnedEnabled(this.IOEGUBUN, this.grdOrder, i, cl.ColumnName, OrderVariables.CheckMode.DataUpdate, OrderVariables.ErrorDisplayMode.NoDisplay))
                                {
                                    if (allGroup == "N" && this.grdOrder.GetItemValue(i, "group_ser").ToString() == group_number)
                                    {
                                        this.grdOrder.SetItemValue(i, cl.ColumnName, returnValue[cl.ColumnName]);
                                        this.grdOrder.SetItemValue(i, "dangil_gumsa_order_yn", returnValue["dangil_gumsa_order_yn"]);
                                        if (returnValue.Contains("dangil_gumsa_result_yn"))
                                            this.grdOrder.SetItemValue(i, "dangil_gumsa_result_yn", returnValue["dangil_gumsa_result_yn"]);
                                        else
                                            this.grdOrder.SetItemValue(i, "dangil_gumsa_result_yn", "N");
                                    }
                                    else if (allGroup == "Y")
                                    {
                                        this.grdOrder.SetItemValue(i, cl.ColumnName, returnValue[cl.ColumnName]);
                                        this.grdOrder.SetItemValue(i, "dangil_gumsa_order_yn", returnValue["dangil_gumsa_order_yn"]);
                                        if (returnValue.Contains("dangil_gumsa_result_yn"))
                                            this.grdOrder.SetItemValue(i, "dangil_gumsa_result_yn", returnValue["dangil_gumsa_result_yn"]);
                                        else
                                            this.grdOrder.SetItemValue(i, "dangil_gumsa_result_yn", "N");
                                    }
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
                                    this.grdOrder.SetItemValue(row, cl.ColumnName, returnValue[cl.ColumnName]);
                                    //this.grdOrder.SetItemValue(row, "dangil_gumsa_order_yn", "N");
                                    //this.grdOrder.SetItemValue(row, "dangil_gumsa_result_yn", "N");
                                    this.grdOrder.SetItemValue(row, "dangil_gumsa_order_yn", returnValue["dangil_gumsa_order_yn"]);
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
            else if (this.rbnSlipHangmog.Checked)
            {
                this.LoadSlipHangmog("2", null, wonnaeDrgYn, searchText);
                WarningMessage(grdSlipHangmog);
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

        #region Cloud services

        private IList<object[]> LoadDataCboSearchCondition(BindVarCollection varlist)
        {
            IList<object[]> res = new List<object[]>();
            ComboSearchConditionArgs args = new ComboSearchConditionArgs("SEARCH_GUBUN");
            ComboResult result =
                CacheService.Instance.Get<ComboSearchConditionArgs, ComboResult>(args, delegate(ComboResult comboResult)
                    {
                        return comboResult.ExecutionStatus == ExecutionStatus.Success && comboResult.ComboItem != null &&
                               comboResult.ComboItem.Count > 0;
                    });
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> cboList = result.ComboItem;
                foreach (ComboListItemInfo info in cboList)
                {
                    res.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                }
            }
            return res;
        }

        //TODO: init screen
        private OCS0103U11InitializeScreenResult LoadScreen(bool hasOpenParams, CommonItemCollection aOpenParam)
        {
            // check condition
            if (hasOpenParams) // 다른 화면에서 콜되는 경우
            {
                if (aOpenParam.Contains("input_gubun"))
                {
                    this.mInputGubun = aOpenParam["input_gubun"].ToString();
                }
                if (aOpenParam.Contains("io_gubun"))
                {
                    this.IOEGUBUN = aOpenParam["io_gubun"].ToString();
                }
                if (aOpenParam.Contains("order_mode"))
                {
                    this.mOrderMode = (OrderVariables.OrderMode)aOpenParam["order_mode"];
                }
                if (aOpenParam.Contains("memb"))
                {
                    this.mMemb = aOpenParam["memb"].ToString();
                }
            }

            OCS0103U11InitializeScreenArgs args = new OCS0103U11InitializeScreenArgs();
            LoadColumnCodeNameInfo codeNameInfo = new LoadColumnCodeNameInfo();
            codeNameInfo.ColName = "code";
            codeNameInfo.Arg1 = "INPUT_GUBUN";
            codeNameInfo.Arg2 = this.mInputGubun;
            args.CodeInfo = codeNameInfo;

            GetUserOptionInfo userOptionInfo = new GetUserOptionInfo();
            userOptionInfo.Doctor = UserInfo.UserID;
            userOptionInfo.Gwa = UserInfo.Gwa;
            userOptionInfo.Keyword = "SENTOU_SEARCH_YN";
            userOptionInfo.IoGubun = this.IOEGUBUN;
            args.UserOptionInfo = userOptionInfo;

            args.OrderGubunInfo = new ComboDataSourceInfo();
            args.OrderGubunInfo.ColName = "order_gubun_bas";

            args.SuryangInfo = new ComboDataSourceInfo();
            args.SuryangInfo.ColName = "suryang";

            args.NalsuInfo = new ComboDataSourceInfo();
            args.NalsuInfo.ColName = "nalsu";

            args.OrderMode = this.mOrderMode.ToString();
            args.UserGubun = UserInfo.UserGubun.ToString();
            args.Doctor = UserType.Doctor.ToString();
            args.Memb = this.mMemb;
            args.DoctorId = UserInfo.DoctorID;
            args.UserId = UserInfo.UserID;
            args.InputTab = INPUTTAB;

            return CloudService.Instance.Submit<OCS0103U11InitializeScreenResult, OCS0103U11InitializeScreenArgs>(args);
        }

        private IList<object[]> LoadSlipCodeTree(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            List<OCS0103U11LaySlipCodeTreeInfo> infoList = this.loadScreenResult.LaySlipCodeTreeInfo;
            foreach (OCS0103U11LaySlipCodeTreeInfo info in infoList)
            {
                dataList.Add(new object[]
                {
                    info.SlipGubun,
                    info.SlipGubunName,
                    info.SlipCode,
                    info.SlipName,
                    info.OrderByKey
                });
            }
            return dataList;
        }

        private IList<object[]> LoadGrdSlipHangmog(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0103U11LoadSlipHangmogArgs args = new OCS0103U11LoadSlipHangmogArgs();
            args.SearchWord = bc["f_search_word"] != null ? bc["f_search_word"].VarValue : "";
            args.SearchCondition = this.cboSearchCondition.SelectedValue.ToString();
            args.SlipCode = bc["f_slip_code"] != null ? bc["f_slip_code"].VarValue : "";
            args.OrderDate = bc["f_order_date"] != null ? bc["f_order_date"].VarValue : "";
            args.ProtocolId = protocolId;
            OCS0103U11LoadSlipHangmogResult result = CloudService.Instance.Submit<OCS0103U11LoadSlipHangmogResult, OCS0103U11LoadSlipHangmogArgs>(args);
            if (result != null)
            {
                foreach (OCS0103U11LoadSlipHangmogInfo item in result.SlipHangmogInfo)
                {
                    object[] objects = 
				{ 
					item.HangmogCode, 
					item.HangmogName, 
					item.OrderGubun, 
					item.OrderGubunName, 
					//item.SpecificComment,
                    item.TrialFlag,
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<string> CreateSlipHangmogParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_search_word");
            paramList.Add("f_slip_code");
            paramList.Add("f_order_date");
            return paramList;
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
                //item.BogyongCodeSub                 = grdOrder.GetItemString(i, "bogyong_code_sub");
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

        #region ExecuteLoadSearchOrderInfo
        /// <summary>
        /// ExecuteLoadSearchOrderInfo
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> ExecuteLoadSearchOrderInfo(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            LoadSearchOrder2Args args = new LoadSearchOrder2Args();
            LoadSearchOrder2RequestInfo info = new LoadSearchOrder2RequestInfo();
            info.GijunDate = bvc["f_gijun_date"].VarValue;
            info.InputTab = bvc["f_input_tab"].VarValue;
            info.SearchCondition = bvc["f_search_condition"].VarValue;
            info.SearchWord = bvc["f_search_word"].VarValue;
            info.WonnaeDrgYn = bvc["f_wonnae_drg_yn"].VarValue;
            args.InputInfo = info;
            args.PageNumber = bvc["f_page_number"].VarValue;
            args.Offset = "200";
            args.ProtocolId = protocolId;
            LoadSearchOrder2Result result =
                CloudService.Instance.Submit<LoadSearchOrder2Result, LoadSearchOrder2Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<LoadSearchOrderInfo> listInfos = result.SearchResult;
                if (listInfos != null && listInfos.Count > 0)
                {
                    foreach (LoadSearchOrderInfo itemInfo in listInfos)
                    {
                        object[] objects = 
				        { 
					        itemInfo.SlipCode, 
					        itemInfo.SlipName, 
					        itemInfo.HangmogCode, 
					        itemInfo.HangmogName, 
					        itemInfo.WonnaeDrgYn, 
					        itemInfo.YakKijunCode,
                            itemInfo.TrialFlag,
				        };
                        lObj.Add(objects);
                    }
                }
            }

            return lObj;
        }
        #endregion

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
            //        "f_page_number"
            //    });
            //this.grdSpecimen.ExecuteQuery = GetGrdSpecimenList;

            // grdOrder
            //this.grdOrder.ParamList = new List<string>(new string[]
            //    {
            //        "f_memb",
            //        "f_yaksok_code",
            //        "f_fk_in_out_key",
            //        "f_input_tab",
            //        "f_input_gubun",
            //    });
            //this.grdOrder.ExecuteQuery = GetGrdOrder;

            // grdSangyongOrder
            this.grdSangyongOrder.ParamList = new List<string>(new string[]
                {
                    "f_user",
                    "f_io_gubun",
                    "f_order_gubun",
                    "f_order_date",
                    "f_search_word",
                    "f_wonnae_drg_yn",
                    "f_page_number"
                });
            this.grdSangyongOrder.ExecuteQuery = GetGrdSangyongOrder;

            // grdSearchOrder
            this.grdSearchOrder.ParamList = new List<string>(new string[] { "f_order_date", "f_search_word", "f_page_number", "f_gijun_date", "f_input_tab", "f_wonnae_drg_yn", "f_search_condition" });
            this.grdSearchOrder.ExecuteQuery = GetGrdSearchOrder;
            #endregion

            //GetListCombo();
            this.cboSearchCondition.ExecuteQuery = LoadDataCboSearchCondition;
            this.cboSearchCondition.SetDictDDLB();
        }
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
            args.PageNumber = bvc["f_page_number"].VarValue;
            args.Offset = "200";
            args.ProtocolId = protocolId;
            // Testing data
            //args.User = "098";
            //args.IoGubun = "I";
            //args.OrderGubun = "B";
            //args.OrderDate = "2015/01/01";
            //args.SearchWord = "%";
            //args.WonnaeDrgYn = "N";
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
                        item.TrialFlag,
                        item.Rownum,
                    });
                }
            }

            return lObj;
        }
        #endregion

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
                        null,
                        item.HospCode,
                        item.TrialFlg,
                    });
                }
            }

            return lObj;
        }
        #endregion

        private void btnInsert_Click(object sender, EventArgs e)
        {
            HandleBtnListClick(FunctionType.Insert);
        }

        private void grdSangyongOrder_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdSangyongOrder.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            //this.grdSangyongOrder.SetBindVarValue("f_user", UserInfo.UserID);
            if (UserInfo.UserGubun == UserType.Doctor)
            {
                this.grdSangyongOrder.SetBindVarValue("f_user", UserInfo.UserID);
            }
            else if (this.mPatientInfo.GetPatientInfo != null)
            {
                if (null != this.mPatientInfo.GetPatientInfo["approve_doctor"]
                    && this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString().Length > 2)
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
            this.grdSangyongOrder.SetBindVarValue("f_order_date", this.mOrderDate);
            this.grdSangyongOrder.SetBindVarValue("f_wonnae_drg_yn", this.cboQueryCon.GetDataValue());
        }
        public void ReLoadRegularOrder()
        {
            this.grdSangyongOrder.Reset();
            this.grdSangyongOrder.QueryLayout(true);
        }

        #region MED-6658
        //Warning message func
        private void WarningMessage(XEditGrid xGrd)
        {
            if (xGrd.RowCount == 0 && isSearchFormKeyPress)
            {
                XMessageBox.Show(Resources.UCOCS0103U11_WarningMessage, Resources.Cap_000033, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isSearchFormKeyPress = false;
            }
        }
        #endregion
    }
    //insert by jc 
    #region XSavePeformer
    /*public class XSavePeformer : ISavePerformer
    {
        private OCS0103U11 parent = null;
        private IHIS.OCS.OrderBiz mOrderBiz = new OrderBiz("OCS0103U11");

        public XSavePeformer(OCS0103U11 parent)
        {
            this.parent = parent;
        }

        public bool Execute(char callerId, RowDataItem item)
        {
            string cmdText = "";
            object t_chk = "";
            string spName = "";
            ArrayList inList = new ArrayList();
            ArrayList outList = new ArrayList();

            item.BindVarList.Add("q_user_id", UserInfo.UserID);
            item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
            switch (callerId)
            {
                case '2':    // 삭제로직... layDeletedData

                    #region 오더 삭제
                    // 삭제시 DC 반납 원오더 원래대로 위치
                    if (item.BindVarList["f_source_ord_key"].VarValue != "")
                    {
                        inList.Clear();
                        outList.Clear();
                        inList.Add("I");
                        inList.Add(item.BindVarList["f_source_ord_key"].VarValue);

                        spName = "PR_OCS_UPDATE_DC_YN";

                        if (Service.ExecuteProcedure(spName, inList, outList) == false)
                        {
                            MessageBox.Show(Service.ErrFullMsg, Resources.MSG012_MSG, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    // 현재 오더가 n데이 오더인경우 해당 키로 발생된 오더 삭제

                    if (item.BindVarList["f_nday_yn"].VarValue == "Y")
                    {
                        spName = "PR_OCS_DELETE_NDAY_ORDER";
                        inList.Clear();
                        inList.Add(item.BindVarList["f_pkocskey"].VarValue);
                        outList.Clear();

                        if (Service.ExecuteProcedure(spName, inList, outList) == false)
                        {
                            return false;
                        }

                        if (outList[0].ToString() != "0")
                        {
                            return false;
                        }
                    }

                    cmdText = " DELETE FROM OCS2003 "
                            + "  WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                            + "    AND PKOCS2003 = :f_pkocskey ";



                    #endregion

                    break;

                case '3':    // 인서트 & 업데이트 laySaveLayout

                    #region 오더 입력 및 변경

                    switch (item.RowState)
                    {
                        case DataRowState.Added:



                            // 키가 입력되지 않은경우 키를 따야함..
                            if (item.BindVarList["f_pkocskey"].VarValue == "")
                            {
                                cmdText = " SELECT OCSKEY_SEQ.NEXTVAL "
                                        + "   FROM SYS.DUAL ";

                                t_chk = Service.ExecuteScalar(cmdText);

                                item.BindVarList.Remove("f_pkocskey");
                                item.BindVarList.Add("f_pkocskey", t_chk.ToString());
                            }

                            // 시퀀스 가져오기
                            if (item.BindVarList["f_seq"].VarValue == "")
                            {
                                cmdText = " SELECT MAX(SEQ)+1 SEQ "
                                        + "   FROM OCS2003 "
                                        + "  WHERE HOSP_CODE  = '" + EnvironInfo.HospCode + "' "
                                        + "    AND BUNHO      = '" + item.BindVarList["f_bunho"].VarValue + "' "
                                        + "    AND FKINP1001  = " + item.BindVarList["f_in_out_key"].VarValue
                                        + "    AND ORDER_DATE = TO_DATE('" + item.BindVarList["f_order_date"].VarValue + "', 'YYYY/MM/DD')  ";

                                t_chk = Service.ExecuteScalar(cmdText);

                                if (TypeCheck.IsNull(t_chk) || t_chk.ToString() == "")
                                {
                                    t_chk = "1";
                                }

                                item.BindVarList.Remove("f_seq");
                                item.BindVarList.Add("f_seq", t_chk.ToString());
                            }

                            cmdText = " INSERT INTO OCS2003 "
                                    + "      ( SYS_DATE             , SYS_ID               , UPD_DATE          , UPD_ID                  , HOSP_CODE             , "
                                    + "        PKOCS2003            , BUNHO                , ORDER_DATE        , ORDER_TIME              , DOCTOR                , "
                                    + "        INPUT_ID             , INPUT_PART           , INPUT_GUBUN       , SEQ                     , RESIDENT              , "
                                    + "        HANGMOG_CODE         , GROUP_SER            , SLIP_CODE         , NDAY_YN                 , ORDER_GUBUN           , "
                                    + "        SPECIMEN_CODE        , SURYANG              , ORD_DANUI         , DV_TIME                 , DV                    , "
                                    + "        NALSU                , JUSA                 , BOGYONG_CODE      , EMERGENCY               , JAERYO_JUNDAL_YN      , "
                                    + "        JUNDAL_TABLE         , JUNDAL_PART          , MOVE_PART         , MUHYO                   , PORTABLE_YN           , "
                                    + "        ANTI_CANCER_YN       , PAY                  , RESER_DATE        , RESER_TIME              , DC_YN                 , "
                                    + "        DC_GUBUN             , BANNAB_YN            , BANNAB_CONFIRM    , ACT_DOCTOR              , ACT_GWA               , "
                                    + "        ACT_BUSEO            , OCS_FLAG             , SG_CODE           , SG_YMD                  , IO_GUBUN              , "
                                    + "        BICHI_YN             , DRG_BUNHO            , SUB_SUSUL         , WONYOI_ORDER_YN         , "
                                    + "        POWDER_YN            , HOPE_DATE            , HOPE_TIME         , DV_1                    , "
                                    + "        DV_2                 , DV_3                 , DV_4              , MIX_GROUP               , ORDER_REMARK          , "
                                    + "        NURSE_REMARK         , BOM_OCCUR_YN         , BOM_SOURCE_KEY    , DISPLAY_YN              , NURSE_CONFIRM_USER    , "
                                    + "        NURSE_CONFIRM_DATE   , NURSE_CONFIRM_TIME   , TEL_YN            , "
                                    + "        REGULAR_YN           , INPUT_TAB            , HUBAL_CHANGE_YN   , PHARMACY                , INPUT_DOCTOR          , "
                                    + "        JUSA_SPD_GUBUN       , DRG_PACK_YN          , SORT_FKOCSKEY     , FKINP1001               , INPUT_GWA             , "
                                    + "        NDAY_OCCUR_YN        ) "
                                    + " VALUES "
                                    + "      ( SYSDATE              , :q_user_id           , SYSDATE           , :q_user_id              , :f_hosp_code             , "
                                    + "        :f_pkocskey          , :f_bunho             , :f_order_date     , TO_CHAR(SYSDATE, 'HH24MI'), :f_doctor               , "
                                    + "        :f_input_id          , :f_input_part        , :f_input_gubun    , :f_seq                  , :f_doctor                , "
                                    + "        :f_hangmog_code      , :f_group_ser         , :f_slip_code      , :f_nday_yn              , :f_order_gubun           , "
                                    + "        :f_specimen_code     , :f_suryang           , :f_ord_danui      , :f_dv_time              , :f_dv                    , "
                                    + "        :f_nalsu             , :f_jusa              , :f_bogyong_code   , :f_emergency            , :f_jaeryo_jundal_yn      , "
                                    + "        :f_jundal_table      , :f_jundal_part       , :f_move_part      , :f_muhyo                , :f_portable_yn           , "
                                    + "        'N'                  , :f_pay               , :f_reser_date     , :f_reser_time           , :f_dc_yn                 , "
                                    + "        :f_dc_gubun          , :f_bannab_yn         , :f_bannab_confirm , :f_act_doctor           , :f_act_gwa               , "
                                    + "        :f_act_buseo         , :f_ocs_flag          , :f_sg_code        , :f_sg_ymd               , :f_io_gubun              , "
                                    + "        :f_bichi_yn          , :f_drg_bunho         , :f_sub_susul      , :f_wonyoi_order_yn      , "
                                    + "        :f_powder_yn         , :f_hope_date         , :f_hope_time      , :f_dv_1                 , "
                                    + "        :f_dv_2              , :f_dv_3              , :f_dv_4           , :f_mix_group            , :f_order_remark          , "
                                    + "        :f_nurse_remark      , :f_bom_occur_yn      , :f_bom_source_key , 'Y'                     , :f_nurse_confirm_user    , "
                                    + "        :f_nurse_confirm_date, :f_nurse_confirm_time, :f_tel_yn         , "
                                    + "        :f_regular_yn        , :f_input_tab         , :f_hubal_change_yn, :f_pharmacy             , :f_input_doctor          , "
                                    + "        :f_jusa_spd_gubun    , :f_drg_pack_yn       , :f_sort_fkocskey  , :f_in_out_key           , :f_input_gwa             , "
                                    + "        'N'                  ) ";



                            break;

                        case DataRowState.Modified:

                            cmdText = " UPDATE OCS2003 "
                                    + "    SET UPD_DATE         = SYSDATE "
                                    + "      , UPD_ID           = :q_user_id "
                                    + "      , ORDER_GUBUN      = :f_order_gubun "
                                    + "      , SURYANG          = :f_suryang "
                                    + "      , DV_TIME          = :f_dv_time "
                                    + "      , DV               = :f_dv "
                                    + "      , NDAY_YN          = :f_nday_yn "
                                    + "      , NALSU            = :f_nalsu "
                                    + "      , JUSA             = :f_jusa  "
                                    + "      , BOGYONG_CODE     = :f_bogyong_code "
                                    + "      , EMERGENCY        = :f_emergency "
                                    + "      , JAERYO_JUNDAL_YN = :f_jaeryo_jundal_yn "
                                    + "      , JUNDAL_TABLE     = :f_jundal_table "
                                    + "      , JUNDAL_PART      = :f_jundal_part "
                                    + "      , MOVE_PART        = :f_move_part "
                                    + "      , MUHYO            = :f_muhyo "
                                    + "      , PORTABLE_YN      = :f_portable_yn "
                                    + "      , ANTI_CANCER_YN   = :f_anti_cancer_yn "
                                    + "      , DC_YN            = :f_dc_yn "
                                    + "      , DC_GUBUN         = :f_dc_gubun "
                                    + "      , BANNAB_YN        = :f_bannab_yn "
                                    + "      , BANNAB_CONFIRM   = :f_bannab_confirm "
                                    + "      , POWDER_YN        = :f_powder_yn "
                                    + "      , HOPE_DATE        = :f_hope_date "
                                    + "      , HOPE_TIME        = :f_hope_time "
                                    + "      , DV_1             = :f_dv_1 "
                                    + "      , DV_2             = :f_dv_2 "
                                    + "      , DV_3             = :f_dv_3 "
                                    + "      , DV_4             = :f_dv_4 "
                                    + "      , MIX_GROUP        = :f_mix_group "
                                    + "      , ORDER_REMARK     = :f_order_remark "
                                    + "      , NURSE_REMARK     = :f_nurse_remark "
                                    + "      , BOM_OCCUR_YN     = :f_bom_occur_yn "
                                    + "      , BOM_SOURCE_KEY   = :f_bom_source_key "
                                    + "      , NURSE_CONFIRM_USER = :f_nurse_confirm_user "
                                    + "      , NURSE_CONFIRM_DATE = :f_nurse_confirm_date "
                                    + "      , NURSE_CONFIRM_TIME = :f_nurse_confirm_time "
                                    + "      , REGULAR_YN       = :f_regular_yn "
                                    + "      , HUBAL_CHANGE_YN  = :f_hubal_change_yn "
                                    + "      , PHARMACY         = :f_pharmacy "
                                    + "      , JUSA_SPD_GUBUN   = :f_jusa_spd_gubun "
                                    + "      , DRG_PACK_YN      = :f_drg_pack_yn "
                                    + "      , SORT_FKOCSKEY    = :f_sort_fkocskey "
                                    + "      , WONYOI_ORDER_YN  = :f_wonyoi_order_yn "
                                    + "      , DISPLAY_YN       = CASE WHEN DC_GUBUN = 'Y' AND SORT_FKOCSKEY IS NOT NULL AND :f_dc_gubun = 'N' THEN 'N' "
                                    + "                                ELSE DISPLAY_YN END "
                                    + "      , SPECIMEN_CODE    = :f_specimen_code "
                                    + "  WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                                    + "    AND PKOCS2003 = :f_pkocskey ";



                            break;

                    }

                    #endregion

                    break;
            }

            bool isSuccess = Service.ExecuteNonQuery(cmdText, item.BindVarList);

            // 오더 업데이트의 경우는 정시약도 같이 업데이트 되어야 함. laySaveLayout
            if (callerId == '3' && isSuccess)
            {
                // use SaveRegularOrderRequest
                if (this.mOrderBiz.SaveRegularOrder("2", item.BindVarList["f_pkocskey"].VarValue) == false)
                {
                    isSuccess = false;
                }
                else
                {
                    isSuccess = true;
                }
            }

            return isSuccess;
        }
    }*/
    #endregion
}
