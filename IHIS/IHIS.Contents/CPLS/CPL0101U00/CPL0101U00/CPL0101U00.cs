#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Cpls;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Cpls;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.CPLS.Properties;
using IHIS.Framework;
#endregion

namespace IHIS.CPLS
{
    /// <summary>
    /// CPL0102U00에 대한 요약 설명입니다.
    /// 바코드 컬럼을 SRL의 보관용법으로 쓴다.
    /// </summary>
    [ToolboxItem(false)]
    public class CPL0101U00 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XEditGrid grdMaster;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XLabel xLabel5;
        private IHIS.Framework.XLabel xLabel6;
        private IHIS.Framework.XLabel xLabel7;
        private IHIS.Framework.XLabel xLabel8;
        private IHIS.Framework.XLabel xLabel9;
        private IHIS.Framework.XLabel xLabel10;
        private IHIS.Framework.XLabel xLabel11;
        private IHIS.Framework.XLabel xLabel12;
        private IHIS.Framework.XLabel xLabel13;
        private IHIS.Framework.XLabel xLabel14;
        private IHIS.Framework.XLabel xLabel15;
        private System.Windows.Forms.Label label1;
        private IHIS.Framework.XLabel xLabel16;
        private System.Windows.Forms.GroupBox groupBox1;
        private IHIS.Framework.XLabel xLabel17;
        private IHIS.Framework.XLabel xLabel18;
        private IHIS.Framework.XLabel xLabel19;
        private IHIS.Framework.XLabel xLabel21;
        private IHIS.Framework.XLabel xLabel22;
        private IHIS.Framework.XLabel xLabel23;
        private IHIS.Framework.XLabel xLabel24;
        private IHIS.Framework.XLabel xLabel25;
        private IHIS.Framework.XLabel xLabel26;
        private IHIS.Framework.XLabel xLabel27;
        private IHIS.Framework.XLabel xLabel28;
        private IHIS.Framework.XLabel xLabel29;
        private IHIS.Framework.XFindBox fbxSlipCode;
        private IHIS.Framework.XTextBox txtSerial;
        private IHIS.Framework.XFindBox fbxJangbiCode2;
        private IHIS.Framework.XFindBox fbxJangbiCode;
        private IHIS.Framework.XFindBox fbxSutakCode;
        private IHIS.Framework.XFindBox fbxUitakCode;
        private IHIS.Framework.XFindBox fbxTubeCode;
        private IHIS.Framework.XFindBox fbxDanui;
        private IHIS.Framework.XFindBox fbxJundalGubun;
        private IHIS.Framework.XDatePicker dtpJukYongDate;
        private IHIS.Framework.XCheckBox cbxEmergency;
        private IHIS.Framework.XCheckBox cbxDefaultYN;
        private IHIS.Framework.XFindBox fbxSpecimenCode;
        private IHIS.Framework.XFindBox fbxHangmogCode;
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
        private IHIS.Framework.XEditGridCell xEditGridCell18;
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
        private IHIS.Framework.XEditGridCell xEditGridCell31;
        private IHIS.Framework.XEditGridCell xEditGridCell32;
        private IHIS.Framework.XEditGridCell xEditGridCell33;
        private IHIS.Framework.XEditGridCell xEditGridCell34;
        private IHIS.Framework.XEditGridCell xEditGridCell35;
        private IHIS.Framework.XEditGridCell xEditGridCell36;
        private IHIS.Framework.XEditGridCell xEditGridCell37;
        private IHIS.Framework.XEditGridCell xEditGridCell38;
        private IHIS.Framework.XEditGridCell xEditGridCell39;
        private IHIS.Framework.XTextBox txtGumsaName;
        private IHIS.Framework.XTextBox txtGumsaNameRe;
        private IHIS.Framework.XDictComboBox cboBarcode;
        private IHIS.Framework.XTextBox txtDefaultResult;
        private IHIS.Framework.XTextBox txtCommentJuCode;
        private IHIS.Framework.XTextBox txtJangbiOutCode3;
        private IHIS.Framework.XFindBox fbxJangbiCode3;
        private IHIS.Framework.XTextBox txtJangbiOutCode2;
        private IHIS.Framework.XTextBox txtJangbiOutCode;
        private IHIS.Framework.XTextBox txtMedicalJundal;
        private IHIS.Framework.XEditMask txtSpecimenAmt;
        private IHIS.Framework.XRadioButton rbxMedicalJundal3;
        private IHIS.Framework.XRadioButton rbxMedicalJundal2;
        private IHIS.Framework.XRadioButton rbxMedicalJundal1;
        private IHIS.Framework.XDictComboBox cboResultForm;
        private IHIS.Framework.XEditGridCell xEditGridCell40;
        private IHIS.Framework.XEditGridCell xEditGridCell41;
        private IHIS.Framework.XFindWorker fwkCPL0101;
        private IHIS.Framework.FindColumnInfo findColumnInfo11;
        private IHIS.Framework.FindColumnInfo findColumnInfo12;
        private IHIS.Framework.XComboBox cboGroupGubun;
        private IHIS.Framework.XComboItem xComboItem1;
        private IHIS.Framework.XComboItem xComboItem2;
        private IHIS.Framework.XComboItem xComboItem3;
        private IHIS.Framework.XDictComboBox cboChubang_yn;
        private IHIS.Framework.XComboItem xComboItem4;
        private IHIS.Framework.XComboItem xComboItem5;
        private IHIS.Framework.XDictComboBox cboResult_yn;
        private IHIS.Framework.XComboItem xComboItem6;
        private IHIS.Framework.XComboItem xComboItem7;
        private IHIS.Framework.XDictComboBox cboTongGubun_yn;
        private IHIS.Framework.XComboItem xComboItem8;
        private IHIS.Framework.XComboItem xComboItem9;
        private IHIS.Framework.XDictComboBox cboDisplayYn;
        private IHIS.Framework.XComboItem xComboItem10;
        private IHIS.Framework.XComboItem xComboItem11;
        private IHIS.Framework.XLabel xLabel20;
        private IHIS.Framework.XEditGridCell xEditGridCell42;
        private IHIS.Framework.XLabel xLabel30;
        private IHIS.Framework.XRichTextBox txtDetailInfo;
        private IHIS.Framework.XEditGridCell xEditGridCell43;
        private IHIS.Framework.XTextBox txtJundalGubunName;
        private IHIS.Framework.XEditGridCell xEditGridCell44;
        private IHIS.Framework.XDictComboBox cboSpcialName;
        private IHIS.Framework.XLabel xLabel31;
        private IHIS.Framework.XEditGridCell xEditGridCell45;
        private System.Windows.Forms.GroupBox groupBox2;
        private IHIS.Framework.XLabel xLabel32;
        private IHIS.Framework.XLabel xLabel33;
        private System.Windows.Forms.Button btnHangmogCopy;
        private IHIS.Framework.XFindBox fbxNewSpecimenCode;
        private IHIS.Framework.XCheckBox cbxNewEmergency;
        private IHIS.Framework.XTextBox txtTongSerial;
        private IHIS.Framework.XLabel xLabel34;
        private IHIS.Framework.XEditGridCell xEditGridCell46;
        private IHIS.Framework.XLabel xLabel35;
        private IHIS.Framework.XEditGridCell xEditGridCell47;
        private IHIS.Framework.XEditGridCell xEditGridCell48;
        private IHIS.Framework.XEditGridCell xEditGridCell49;
        private IHIS.Framework.XEditMask txtPoint;
        private IHIS.Framework.XEditMask txtPoint2;
        private IHIS.Framework.XEditMask txtPoint3;
        private IHIS.Framework.XLabel xLabel36;
        private IHIS.Framework.XTextBox txtOutTube;
        private IHIS.Framework.XTextBox txtOutTube2;
        private IHIS.Framework.XEditGridCell xEditGridCell50;
        private IHIS.Framework.XEditGridCell xEditGridCell51;
        private IHIS.Framework.XTextBox txtHangmogMarkName;
        private IHIS.Framework.XLabel xLabel37;
        private IHIS.Framework.XEditGridCell xEditGridCell52;
        private IHIS.Framework.XLabel xLabel38;
        private IHIS.Framework.XCheckBox cbxMiddleResult;
        private IHIS.Framework.XEditGridCell xEditGridCell53;
        private IHIS.Framework.XButton btnHangCopy;
        private System.Windows.Forms.ToolTip toolTip;
        private IHIS.Framework.XButton btnExcel;
        private IHIS.Framework.XDictComboBox cboUserGubun;
        private IHIS.Framework.XEditGridCell xEditGridCell54;
        private IHIS.Framework.XLabel lbUserGubun;
        private XTextBox txtTubeName;
        private XTextBox txtJundalName;
        private XTextBox txtUitakName;
        private XTextBox txtDanuiName;
        private XTextBox txtJangbiName3;
        private XTextBox txtJangbiName2;
        private XTextBox txtJangbiName;
        private XTextBox txtSlipName;
        private XTextBox txtSutakName;
        private XTextBox txtSpecimenName;
        private XButton btnGroup;
        private XLabel xLabel39;
        private XDictComboBox cboInoutGubun;
        private XPanel xPanel4;
        private XTextBox txtHangmog;
        private XLabel xLabel1;
        private XButton btnUpdMstData;
        private XButton btnUploadIFMst;
        private XTextBox txtJlac10Code1;
        private XTextBox txtJlac10Code2;
        private XLabel xLabel41;
        private XLabel xLabel40;
        private XEditGridCell xEditGridCell55;
        private XEditGridCell xEditGridCell56;
        private System.ComponentModel.IContainer components;

        public CPL0101U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //저장 수행자 Set
            // TODO: Comment use connect cloud
           /* this.grdMaster.SavePerformer = new XSavePerformer(this);
            //저장 Layout List Set
            this.SaveLayoutList.Add(this.grdMaster);*/
			// Set ParamList and ExecuteQuery
            grdMaster.ParamList = new List<string>(new String[] { "f_txtHangmog", "f_io_gubun", "f_page_number" });
            grdMaster.ExecuteQuery = GrdMaster_ExecuteQuery;

            // Create data for combo 
            cboBarcode.ExecuteQuery = cboBarcode_ExecuteQuery;
            cboBarcode.SetDictDDLB();

            cboResultForm.ExecuteQuery = cboResultForm_ExecuteQuery;
            cboResultForm.SetDictDDLB();

            cboSpcialName.ExecuteQuery = cboSpcialName_ExecuteQuery;
            cboSpcialName.SetDictDDLB();

            cboInoutGubun.ExecuteQuery = cboInoutGubun_ExecuteQuery;
            cboInoutGubun.SetDictDDLB();

            // Create Data for fwkCPL0101 
            fwkCPL0101.ParamList = new List<string>(new String[] { "Ctr_name", "code_type", "find1", "find2", "system_gubun" });
            fwkCPL0101.ExecuteQuery = fwkCPL0101_ExecuteQuery;

            cboUserGubun.ExecuteQuery = cboUserGubun_ExecuteQuery;
            cboUserGubun.SetDictDDLB();

            //https://sofiamedix.atlassian.net/browse/MED-15176
            if (NetInfo.Language == LangMode.En)
            {
                SetSizeForColumnEng();
            }

            // https://sofiamedix.atlassian.net/browse/MED-16554
            btnUpdMstData.Visible = false;
        }

        private void SetSizeForColumnEng()
        {
            grdMaster.AutoSizeColumn(xEditGridCell40.Col, 95);
            xLabel24.Height = 25;
            lbUserGubun.Height = 25;
            xLabel38.Height = 25;
            xLabel17.Height = 25;
            xLabel21.Height = 25;
            xLabel19.Height = 25;
            xLabel22.Height = 25;
            xLabel18.Height = 25;
            xLabel30.Height = 25;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPL0101U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnUploadIFMst = new IHIS.Framework.XButton();
            this.btnUpdMstData = new IHIS.Framework.XButton();
            this.btnHangCopy = new IHIS.Framework.XButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnHangmogCopy = new System.Windows.Forms.Button();
            this.fbxNewSpecimenCode = new IHIS.Framework.XFindBox();
            this.fwkCPL0101 = new IHIS.Framework.XFindWorker();
            this.findColumnInfo11 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo12 = new IHIS.Framework.FindColumnInfo();
            this.xLabel32 = new IHIS.Framework.XLabel();
            this.xLabel33 = new IHIS.Framework.XLabel();
            this.cbxNewEmergency = new IHIS.Framework.XCheckBox();
            this.btnList = new IHIS.Framework.XButtonList();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbxMedicalJundal3 = new IHIS.Framework.XRadioButton();
            this.rbxMedicalJundal2 = new IHIS.Framework.XRadioButton();
            this.rbxMedicalJundal1 = new IHIS.Framework.XRadioButton();
            this.btnExcel = new IHIS.Framework.XButton();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdMaster = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.dtpJukYongDate = new IHIS.Framework.XDatePicker();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.fbxHangmogCode = new IHIS.Framework.XFindBox();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.fbxSpecimenCode = new IHIS.Framework.XFindBox();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.txtSpecimenName = new IHIS.Framework.XTextBox();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.cbxEmergency = new IHIS.Framework.XCheckBox();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.cbxDefaultYN = new IHIS.Framework.XCheckBox();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.fbxJundalGubun = new IHIS.Framework.XFindBox();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.txtJundalName = new IHIS.Framework.XTextBox();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.fbxDanui = new IHIS.Framework.XFindBox();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.txtDanuiName = new IHIS.Framework.XTextBox();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.fbxTubeCode = new IHIS.Framework.XFindBox();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.txtTubeName = new IHIS.Framework.XTextBox();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.fbxUitakCode = new IHIS.Framework.XFindBox();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.txtUitakName = new IHIS.Framework.XTextBox();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.fbxSutakCode = new IHIS.Framework.XFindBox();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.txtSutakName = new IHIS.Framework.XTextBox();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.fbxSlipCode = new IHIS.Framework.XFindBox();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.txtSlipName = new IHIS.Framework.XTextBox();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.fbxJangbiCode = new IHIS.Framework.XFindBox();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.txtJangbiName = new IHIS.Framework.XTextBox();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.txtJangbiOutCode = new IHIS.Framework.XTextBox();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.fbxJangbiCode2 = new IHIS.Framework.XFindBox();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.txtJangbiName2 = new IHIS.Framework.XTextBox();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.txtJangbiOutCode2 = new IHIS.Framework.XTextBox();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.fbxJangbiCode3 = new IHIS.Framework.XFindBox();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.txtJangbiName3 = new IHIS.Framework.XTextBox();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.txtJangbiOutCode3 = new IHIS.Framework.XTextBox();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.cboGroupGubun = new IHIS.Framework.XComboBox();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.txtGumsaNameRe = new IHIS.Framework.XTextBox();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.cboBarcode = new IHIS.Framework.XDictComboBox();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.txtGumsaName = new IHIS.Framework.XTextBox();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.txtDefaultResult = new IHIS.Framework.XTextBox();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.txtMedicalJundal = new IHIS.Framework.XTextBox();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.txtCommentJuCode = new IHIS.Framework.XTextBox();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.txtSerial = new IHIS.Framework.XTextBox();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.cboChubang_yn = new IHIS.Framework.XDictComboBox();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.cboResult_yn = new IHIS.Framework.XDictComboBox();
            this.xComboItem6 = new IHIS.Framework.XComboItem();
            this.xComboItem7 = new IHIS.Framework.XComboItem();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.cboResultForm = new IHIS.Framework.XDictComboBox();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.cboTongGubun_yn = new IHIS.Framework.XDictComboBox();
            this.xComboItem8 = new IHIS.Framework.XComboItem();
            this.xComboItem9 = new IHIS.Framework.XComboItem();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.txtSpecimenAmt = new IHIS.Framework.XEditMask();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.txtDetailInfo = new IHIS.Framework.XRichTextBox();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.cboDisplayYn = new IHIS.Framework.XDictComboBox();
            this.xComboItem10 = new IHIS.Framework.XComboItem();
            this.xComboItem11 = new IHIS.Framework.XComboItem();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.txtJundalGubunName = new IHIS.Framework.XTextBox();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.cboSpcialName = new IHIS.Framework.XDictComboBox();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.txtTongSerial = new IHIS.Framework.XTextBox();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.txtPoint = new IHIS.Framework.XEditMask();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.txtPoint2 = new IHIS.Framework.XEditMask();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.txtPoint3 = new IHIS.Framework.XEditMask();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.txtOutTube = new IHIS.Framework.XTextBox();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.txtOutTube2 = new IHIS.Framework.XTextBox();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.txtHangmogMarkName = new IHIS.Framework.XTextBox();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.cbxMiddleResult = new IHIS.Framework.XCheckBox();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.txtJlac10Code1 = new IHIS.Framework.XTextBox();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.txtJlac10Code2 = new IHIS.Framework.XTextBox();
            this.cboUserGubun = new IHIS.Framework.XDictComboBox();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.cboInoutGubun = new IHIS.Framework.XDictComboBox();
            this.xLabel39 = new IHIS.Framework.XLabel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.txtHangmog = new IHIS.Framework.XTextBox();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.btnGroup = new IHIS.Framework.XButton();
            this.lbUserGubun = new IHIS.Framework.XLabel();
            this.xLabel38 = new IHIS.Framework.XLabel();
            this.xLabel37 = new IHIS.Framework.XLabel();
            this.xLabel36 = new IHIS.Framework.XLabel();
            this.xLabel35 = new IHIS.Framework.XLabel();
            this.xLabel34 = new IHIS.Framework.XLabel();
            this.xLabel31 = new IHIS.Framework.XLabel();
            this.xLabel30 = new IHIS.Framework.XLabel();
            this.xLabel20 = new IHIS.Framework.XLabel();
            this.xLabel29 = new IHIS.Framework.XLabel();
            this.xLabel28 = new IHIS.Framework.XLabel();
            this.xLabel27 = new IHIS.Framework.XLabel();
            this.xLabel26 = new IHIS.Framework.XLabel();
            this.xLabel25 = new IHIS.Framework.XLabel();
            this.xLabel24 = new IHIS.Framework.XLabel();
            this.xLabel23 = new IHIS.Framework.XLabel();
            this.xLabel41 = new IHIS.Framework.XLabel();
            this.xLabel40 = new IHIS.Framework.XLabel();
            this.xLabel21 = new IHIS.Framework.XLabel();
            this.xLabel22 = new IHIS.Framework.XLabel();
            this.xLabel19 = new IHIS.Framework.XLabel();
            this.xLabel18 = new IHIS.Framework.XLabel();
            this.xLabel17 = new IHIS.Framework.XLabel();
            this.xLabel16 = new IHIS.Framework.XLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.xLabel15 = new IHIS.Framework.XLabel();
            this.xLabel14 = new IHIS.Framework.XLabel();
            this.xLabel13 = new IHIS.Framework.XLabel();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.xPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).BeginInit();
            this.xPanel3.SuspendLayout();
            this.xPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.btnUploadIFMst);
            this.xPanel1.Controls.Add(this.btnUpdMstData);
            this.xPanel1.Controls.Add(this.btnHangCopy);
            this.xPanel1.Controls.Add(this.groupBox2);
            this.xPanel1.Controls.Add(this.btnList);
            this.xPanel1.Controls.Add(this.groupBox1);
            this.xPanel1.Controls.Add(this.btnExcel);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            this.toolTip.SetToolTip(this.xPanel1, resources.GetString("xPanel1.ToolTip"));
            // 
            // btnUploadIFMst
            // 
            this.btnUploadIFMst.AccessibleDescription = null;
            this.btnUploadIFMst.AccessibleName = null;
            resources.ApplyResources(this.btnUploadIFMst, "btnUploadIFMst");
            this.btnUploadIFMst.BackgroundImage = null;
            this.btnUploadIFMst.Name = "btnUploadIFMst";
            this.toolTip.SetToolTip(this.btnUploadIFMst, resources.GetString("btnUploadIFMst.ToolTip"));
            this.btnUploadIFMst.Click += new System.EventHandler(this.btnUploadIFMst_Click);
            // 
            // btnUpdMstData
            // 
            this.btnUpdMstData.AccessibleDescription = null;
            this.btnUpdMstData.AccessibleName = null;
            resources.ApplyResources(this.btnUpdMstData, "btnUpdMstData");
            this.btnUpdMstData.BackgroundImage = null;
            this.btnUpdMstData.Name = "btnUpdMstData";
            this.toolTip.SetToolTip(this.btnUpdMstData, resources.GetString("btnUpdMstData.ToolTip"));
            this.btnUpdMstData.Click += new System.EventHandler(this.btnUpdMstData_Click);
            // 
            // btnHangCopy
            // 
            this.btnHangCopy.AccessibleDescription = null;
            this.btnHangCopy.AccessibleName = null;
            resources.ApplyResources(this.btnHangCopy, "btnHangCopy");
            this.btnHangCopy.BackgroundImage = null;
            this.btnHangCopy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHangCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnHangCopy.Image")));
            this.btnHangCopy.Name = "btnHangCopy";
            this.toolTip.SetToolTip(this.btnHangCopy, resources.GetString("btnHangCopy.ToolTip"));
            this.btnHangCopy.Click += new System.EventHandler(this.btnHangCopy_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.AccessibleDescription = null;
            this.groupBox2.AccessibleName = null;
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.BackgroundImage = null;
            this.groupBox2.Controls.Add(this.btnHangmogCopy);
            this.groupBox2.Controls.Add(this.fbxNewSpecimenCode);
            this.groupBox2.Controls.Add(this.xLabel32);
            this.groupBox2.Controls.Add(this.xLabel33);
            this.groupBox2.Controls.Add(this.cbxNewEmergency);
            this.groupBox2.Font = null;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            this.toolTip.SetToolTip(this.groupBox2, resources.GetString("groupBox2.ToolTip"));
            // 
            // btnHangmogCopy
            // 
            this.btnHangmogCopy.AccessibleDescription = null;
            this.btnHangmogCopy.AccessibleName = null;
            resources.ApplyResources(this.btnHangmogCopy, "btnHangmogCopy");
            this.btnHangmogCopy.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnHangmogCopy.BackgroundImage = null;
            this.btnHangmogCopy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHangmogCopy.Font = null;
            this.btnHangmogCopy.Name = "btnHangmogCopy";
            this.btnHangmogCopy.TabStop = false;
            this.toolTip.SetToolTip(this.btnHangmogCopy, resources.GetString("btnHangmogCopy.ToolTip"));
            this.btnHangmogCopy.UseVisualStyleBackColor = false;
            this.btnHangmogCopy.Click += new System.EventHandler(this.btnHangmogCopy_Click);
            // 
            // fbxNewSpecimenCode
            // 
            this.fbxNewSpecimenCode.AccessibleDescription = null;
            this.fbxNewSpecimenCode.AccessibleName = null;
            resources.ApplyResources(this.fbxNewSpecimenCode, "fbxNewSpecimenCode");
            this.fbxNewSpecimenCode.BackgroundImage = null;
            this.fbxNewSpecimenCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxNewSpecimenCode.FindWorker = this.fwkCPL0101;
            this.fbxNewSpecimenCode.Name = "fbxNewSpecimenCode";
            this.fbxNewSpecimenCode.TabStop = false;
            this.toolTip.SetToolTip(this.fbxNewSpecimenCode, resources.GetString("fbxNewSpecimenCode.ToolTip"));
            this.fbxNewSpecimenCode.FindClick += new System.ComponentModel.CancelEventHandler(this.fbx_FindClick);
            // 
            // fwkCPL0101
            // 
            this.fwkCPL0101.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo11,
            this.findColumnInfo12});
            this.fwkCPL0101.ExecuteQuery = null;
            this.fwkCPL0101.FormText = global::IHIS.CPLS.Properties.Resources.FWKCPL0101_FORMTEXT;
            this.fwkCPL0101.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkCPL0101.ParamList")));
            this.fwkCPL0101.SearchImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.fwkCPL0101.ServerFilter = true;
            // 
            // findColumnInfo11
            // 
            this.findColumnInfo11.ColName = "code";
            this.findColumnInfo11.ColWidth = 131;
            this.findColumnInfo11.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo11, "findColumnInfo11");
            // 
            // findColumnInfo12
            // 
            this.findColumnInfo12.ColName = "name";
            this.findColumnInfo12.ColWidth = 269;
            this.findColumnInfo12.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo12, "findColumnInfo12");
            // 
            // xLabel32
            // 
            this.xLabel32.AccessibleDescription = null;
            this.xLabel32.AccessibleName = null;
            resources.ApplyResources(this.xLabel32, "xLabel32");
            this.xLabel32.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel32.Image = null;
            this.xLabel32.Name = "xLabel32";
            this.toolTip.SetToolTip(this.xLabel32, resources.GetString("xLabel32.ToolTip"));
            // 
            // xLabel33
            // 
            this.xLabel33.AccessibleDescription = null;
            this.xLabel33.AccessibleName = null;
            resources.ApplyResources(this.xLabel33, "xLabel33");
            this.xLabel33.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel33.Image = null;
            this.xLabel33.Name = "xLabel33";
            this.toolTip.SetToolTip(this.xLabel33, resources.GetString("xLabel33.ToolTip"));
            // 
            // cbxNewEmergency
            // 
            this.cbxNewEmergency.AccessibleDescription = null;
            this.cbxNewEmergency.AccessibleName = null;
            resources.ApplyResources(this.cbxNewEmergency, "cbxNewEmergency");
            this.cbxNewEmergency.BackgroundImage = null;
            this.cbxNewEmergency.Name = "cbxNewEmergency";
            this.cbxNewEmergency.TabStop = false;
            this.toolTip.SetToolTip(this.cbxNewEmergency, resources.GetString("cbxNewEmergency.ToolTip"));
            this.cbxNewEmergency.UseVisualStyleBackColor = false;
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.toolTip.SetToolTip(this.btnList, resources.GetString("btnList.ToolTip"));
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = null;
            this.groupBox1.AccessibleName = null;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackgroundImage = null;
            this.groupBox1.Controls.Add(this.rbxMedicalJundal3);
            this.groupBox1.Controls.Add(this.rbxMedicalJundal2);
            this.groupBox1.Controls.Add(this.rbxMedicalJundal1);
            this.groupBox1.Font = null;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.toolTip.SetToolTip(this.groupBox1, resources.GetString("groupBox1.ToolTip"));
            // 
            // rbxMedicalJundal3
            // 
            this.rbxMedicalJundal3.AccessibleDescription = null;
            this.rbxMedicalJundal3.AccessibleName = null;
            resources.ApplyResources(this.rbxMedicalJundal3, "rbxMedicalJundal3");
            this.rbxMedicalJundal3.BackgroundImage = null;
            this.rbxMedicalJundal3.Name = "rbxMedicalJundal3";
            this.toolTip.SetToolTip(this.rbxMedicalJundal3, resources.GetString("rbxMedicalJundal3.ToolTip"));
            this.rbxMedicalJundal3.UseVisualStyleBackColor = false;
            this.rbxMedicalJundal3.CheckedChanged += new System.EventHandler(this.rbxMedicalJundal3_CheckedChanged);
            // 
            // rbxMedicalJundal2
            // 
            this.rbxMedicalJundal2.AccessibleDescription = null;
            this.rbxMedicalJundal2.AccessibleName = null;
            resources.ApplyResources(this.rbxMedicalJundal2, "rbxMedicalJundal2");
            this.rbxMedicalJundal2.BackgroundImage = null;
            this.rbxMedicalJundal2.Name = "rbxMedicalJundal2";
            this.toolTip.SetToolTip(this.rbxMedicalJundal2, resources.GetString("rbxMedicalJundal2.ToolTip"));
            this.rbxMedicalJundal2.UseVisualStyleBackColor = false;
            this.rbxMedicalJundal2.CheckedChanged += new System.EventHandler(this.rbxMedicalJundal2_CheckedChanged);
            // 
            // rbxMedicalJundal1
            // 
            this.rbxMedicalJundal1.AccessibleDescription = null;
            this.rbxMedicalJundal1.AccessibleName = null;
            resources.ApplyResources(this.rbxMedicalJundal1, "rbxMedicalJundal1");
            this.rbxMedicalJundal1.BackgroundImage = null;
            this.rbxMedicalJundal1.Name = "rbxMedicalJundal1";
            this.toolTip.SetToolTip(this.rbxMedicalJundal1, resources.GetString("rbxMedicalJundal1.ToolTip"));
            this.rbxMedicalJundal1.UseVisualStyleBackColor = false;
            this.rbxMedicalJundal1.CheckedChanged += new System.EventHandler(this.rbxMedicalJundal1_CheckedChanged);
            // 
            // btnExcel
            // 
            this.btnExcel.AccessibleDescription = null;
            this.btnExcel.AccessibleName = null;
            resources.ApplyResources(this.btnExcel, "btnExcel");
            this.btnExcel.BackgroundImage = null;
            this.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.toolTip.SetToolTip(this.btnExcel, resources.GetString("btnExcel.ToolTip"));
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.grdMaster);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            this.toolTip.SetToolTip(this.xPanel2, resources.GetString("xPanel2.ToolTip"));
            // 
            // grdMaster
            // 
            resources.ApplyResources(this.grdMaster, "grdMaster");
            this.grdMaster.ApplyPaintEventToAllColumn = true;
            this.grdMaster.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell40,
            this.xEditGridCell4,
            this.xEditGridCell41,
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
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell34,
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell39,
            this.xEditGridCell43,
            this.xEditGridCell42,
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
            this.xEditGridCell56});
            this.grdMaster.ColPerLine = 4;
            this.grdMaster.ColResizable = true;
            this.grdMaster.Cols = 5;
            this.grdMaster.ControlBinding = true;
            this.grdMaster.ExecuteQuery = null;
            this.grdMaster.FixedCols = 1;
            this.grdMaster.FixedRows = 1;
            this.grdMaster.HeaderHeights.Add(35);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMaster.ParamList")));
            this.grdMaster.RowHeaderVisible = true;
            this.grdMaster.Rows = 2;
            this.grdMaster.TabStop = false;
            this.toolTip.SetToolTip(this.grdMaster, resources.GetString("grdMaster.ToolTip"));
            this.grdMaster.ToolTipActive = true;
            this.grdMaster.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdMaster_RowFocusChanged);
            this.grdMaster.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdMaster_SaveEnd);
            this.grdMaster.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdMaster_GridCellPainting);
            this.grdMaster.PreEndInitializing += new System.EventHandler(this.grdMaster_PreEndInitializing);
            this.grdMaster.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMaster_QueryStarting);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell3.BindControl = this.dtpJukYongDate;
            this.xEditGridCell3.CellName = "jukyong_date";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            this.xEditGridCell3.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // dtpJukYongDate
            // 
            this.dtpJukYongDate.AccessibleDescription = null;
            this.dtpJukYongDate.AccessibleName = null;
            resources.ApplyResources(this.dtpJukYongDate, "dtpJukYongDate");
            this.dtpJukYongDate.BackgroundImage = null;
            this.dtpJukYongDate.IsVietnameseYearType = false;
            this.dtpJukYongDate.Name = "dtpJukYongDate";
            this.toolTip.SetToolTip(this.dtpJukYongDate, resources.GetString("dtpJukYongDate.ToolTip"));
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.BindControl = this.fbxHangmogCode;
            this.xEditGridCell1.CellName = "hangmog_code";
            this.xEditGridCell1.CellWidth = 67;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            //this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.SuppressRepeating = true;
            // 
            // fbxHangmogCode
            // 
            this.fbxHangmogCode.AccessibleDescription = null;
            this.fbxHangmogCode.AccessibleName = null;
            resources.ApplyResources(this.fbxHangmogCode, "fbxHangmogCode");
            this.fbxHangmogCode.BackgroundImage = null;
            this.fbxHangmogCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxHangmogCode.FindWorker = this.fwkCPL0101;
            this.fbxHangmogCode.Name = "fbxHangmogCode";
            this.toolTip.SetToolTip(this.fbxHangmogCode, resources.GetString("fbxHangmogCode.ToolTip"));
            this.fbxHangmogCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbx_DataValidating);
            this.fbxHangmogCode.FindClick += new System.ComponentModel.CancelEventHandler(this.fbx_FindClick);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell2.BindControl = this.fbxSpecimenCode;
            this.xEditGridCell2.CellLen = 2;
            this.xEditGridCell2.CellName = "specimen_code";
            this.xEditGridCell2.CellWidth = 45;
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            this.xEditGridCell2.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell2.SuppressRepeating = true;
            // 
            // fbxSpecimenCode
            // 
            this.fbxSpecimenCode.AccessibleDescription = null;
            this.fbxSpecimenCode.AccessibleName = null;
            resources.ApplyResources(this.fbxSpecimenCode, "fbxSpecimenCode");
            this.fbxSpecimenCode.BackgroundImage = null;
            this.fbxSpecimenCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxSpecimenCode.FindWorker = this.fwkCPL0101;
            this.fbxSpecimenCode.Name = "fbxSpecimenCode";
            this.toolTip.SetToolTip(this.fbxSpecimenCode, resources.GetString("fbxSpecimenCode.ToolTip"));
            this.fbxSpecimenCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbx_DataValidating);
            this.fbxSpecimenCode.FindClick += new System.ComponentModel.CancelEventHandler(this.fbx_FindClick);
            this.fbxSpecimenCode.MaxLength = 3;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell40.BindControl = this.txtSpecimenName;
            this.xEditGridCell40.CellName = "specimen_name";
            this.xEditGridCell40.CellWidth = 85;
            this.xEditGridCell40.Col = 3;
            this.xEditGridCell40.ExecuteQuery = null;
            this.xEditGridCell40.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsReadOnly = true;
            this.xEditGridCell40.IsUpdCol = false;
            this.xEditGridCell40.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtSpecimenName
            // 
            this.txtSpecimenName.AccessibleDescription = null;
            this.txtSpecimenName.AccessibleName = null;
            resources.ApplyResources(this.txtSpecimenName, "txtSpecimenName");
            this.txtSpecimenName.BackColor = IHIS.Framework.XColor.XTreeViewBackColor;
            this.txtSpecimenName.BackgroundImage = null;
            this.txtSpecimenName.Name = "txtSpecimenName";
            this.txtSpecimenName.TabStop = false;
            this.toolTip.SetToolTip(this.txtSpecimenName, resources.GetString("txtSpecimenName.ToolTip"));
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.BindControl = this.cbxEmergency;
            this.xEditGridCell4.CellLen = 1;
            this.xEditGridCell4.CellName = "emergency";
            this.xEditGridCell4.CellWidth = 35;
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.InitValue = "N";
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            this.xEditGridCell4.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // cbxEmergency
            // 
            this.cbxEmergency.AccessibleDescription = null;
            this.cbxEmergency.AccessibleName = null;
            resources.ApplyResources(this.cbxEmergency, "cbxEmergency");
            this.cbxEmergency.BackgroundImage = null;
            this.cbxEmergency.Name = "cbxEmergency";
            this.toolTip.SetToolTip(this.cbxEmergency, resources.GetString("cbxEmergency.ToolTip"));
            this.cbxEmergency.UseVisualStyleBackColor = false;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell41.BindControl = this.cbxDefaultYN;
            this.xEditGridCell41.CellLen = 1;
            this.xEditGridCell41.CellName = "default_yn";
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.ExecuteQuery = null;
            this.xEditGridCell41.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            this.xEditGridCell41.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // cbxDefaultYN
            // 
            this.cbxDefaultYN.AccessibleDescription = null;
            this.cbxDefaultYN.AccessibleName = null;
            resources.ApplyResources(this.cbxDefaultYN, "cbxDefaultYN");
            this.cbxDefaultYN.BackgroundImage = null;
            this.cbxDefaultYN.Name = "cbxDefaultYN";
            this.toolTip.SetToolTip(this.cbxDefaultYN, resources.GetString("cbxDefaultYN.ToolTip"));
            this.cbxDefaultYN.UseVisualStyleBackColor = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.BindControl = this.fbxJundalGubun;
            this.xEditGridCell5.CellLen = 4;
            this.xEditGridCell5.CellName = "jundal_gubun";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            this.xEditGridCell5.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // fbxJundalGubun
            // 
            this.fbxJundalGubun.AccessibleDescription = null;
            this.fbxJundalGubun.AccessibleName = null;
            resources.ApplyResources(this.fbxJundalGubun, "fbxJundalGubun");
            this.fbxJundalGubun.BackgroundImage = null;
            this.fbxJundalGubun.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxJundalGubun.FindWorker = this.fwkCPL0101;
            this.fbxJundalGubun.Name = "fbxJundalGubun";
            this.toolTip.SetToolTip(this.fbxJundalGubun, resources.GetString("fbxJundalGubun.ToolTip"));
            this.fbxJundalGubun.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbx_DataValidating);
            this.fbxJundalGubun.FindClick += new System.ComponentModel.CancelEventHandler(this.fbx_FindClick);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell6.BindControl = this.txtJundalName;
            this.xEditGridCell6.CellName = "jundal_name";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsUpdCol = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            this.xEditGridCell6.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtJundalName
            // 
            this.txtJundalName.AccessibleDescription = null;
            this.txtJundalName.AccessibleName = null;
            resources.ApplyResources(this.txtJundalName, "txtJundalName");
            this.txtJundalName.BackColor = IHIS.Framework.XColor.XTreeViewBackColor;
            this.txtJundalName.BackgroundImage = null;
            this.txtJundalName.Name = "txtJundalName";
            this.txtJundalName.TabStop = false;
            this.toolTip.SetToolTip(this.txtJundalName, resources.GetString("txtJundalName.ToolTip"));
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell7.BindControl = this.fbxDanui;
            this.xEditGridCell7.CellLen = 6;
            this.xEditGridCell7.CellName = "danui";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            this.xEditGridCell7.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // fbxDanui
            // 
            this.fbxDanui.AccessibleDescription = null;
            this.fbxDanui.AccessibleName = null;
            resources.ApplyResources(this.fbxDanui, "fbxDanui");
            this.fbxDanui.BackgroundImage = null;
            this.fbxDanui.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxDanui.FindWorker = this.fwkCPL0101;
            this.fbxDanui.Name = "fbxDanui";
            this.toolTip.SetToolTip(this.fbxDanui, resources.GetString("fbxDanui.ToolTip"));
            this.fbxDanui.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbx_DataValidating);
            this.fbxDanui.FindClick += new System.ComponentModel.CancelEventHandler(this.fbx_FindClick);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell8.BindControl = this.txtDanuiName;
            this.xEditGridCell8.CellName = "danui_name";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsUpdCol = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            this.xEditGridCell8.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtDanuiName
            // 
            this.txtDanuiName.AccessibleDescription = null;
            this.txtDanuiName.AccessibleName = null;
            resources.ApplyResources(this.txtDanuiName, "txtDanuiName");
            this.txtDanuiName.BackColor = IHIS.Framework.XColor.XTreeViewBackColor;
            this.txtDanuiName.BackgroundImage = null;
            this.txtDanuiName.Name = "txtDanuiName";
            this.txtDanuiName.TabStop = false;
            this.toolTip.SetToolTip(this.txtDanuiName, resources.GetString("txtDanuiName.ToolTip"));
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell9.BindControl = this.fbxTubeCode;
            this.xEditGridCell9.CellLen = 4;
            this.xEditGridCell9.CellName = "tube_code";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            this.xEditGridCell9.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // fbxTubeCode
            // 
            this.fbxTubeCode.AccessibleDescription = null;
            this.fbxTubeCode.AccessibleName = null;
            resources.ApplyResources(this.fbxTubeCode, "fbxTubeCode");
            this.fbxTubeCode.BackgroundImage = null;
            this.fbxTubeCode.FindWorker = this.fwkCPL0101;
            this.fbxTubeCode.Name = "fbxTubeCode";
            this.toolTip.SetToolTip(this.fbxTubeCode, resources.GetString("fbxTubeCode.ToolTip"));
            this.fbxTubeCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbx_DataValidating);
            this.fbxTubeCode.FindClick += new System.ComponentModel.CancelEventHandler(this.fbx_FindClick);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell10.BindControl = this.txtTubeName;
            this.xEditGridCell10.CellName = "tube_name";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsUpdCol = false;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            this.xEditGridCell10.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtTubeName
            // 
            this.txtTubeName.AccessibleDescription = null;
            this.txtTubeName.AccessibleName = null;
            resources.ApplyResources(this.txtTubeName, "txtTubeName");
            this.txtTubeName.BackColor = IHIS.Framework.XColor.XTreeViewBackColor;
            this.txtTubeName.BackgroundImage = null;
            this.txtTubeName.Name = "txtTubeName";
            this.txtTubeName.TabStop = false;
            this.toolTip.SetToolTip(this.txtTubeName, resources.GetString("txtTubeName.ToolTip"));
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell11.BindControl = this.fbxUitakCode;
            this.xEditGridCell11.CellLen = 4;
            this.xEditGridCell11.CellName = "uitak_code";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            this.xEditGridCell11.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // fbxUitakCode
            // 
            this.fbxUitakCode.AccessibleDescription = null;
            this.fbxUitakCode.AccessibleName = null;
            resources.ApplyResources(this.fbxUitakCode, "fbxUitakCode");
            this.fbxUitakCode.BackgroundImage = null;
            this.fbxUitakCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxUitakCode.FindWorker = this.fwkCPL0101;
            this.fbxUitakCode.Name = "fbxUitakCode";
            this.toolTip.SetToolTip(this.fbxUitakCode, resources.GetString("fbxUitakCode.ToolTip"));
            this.fbxUitakCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbx_DataValidating);
            this.fbxUitakCode.FindClick += new System.ComponentModel.CancelEventHandler(this.fbx_FindClick);
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell12.BindControl = this.txtUitakName;
            this.xEditGridCell12.CellName = "uitak_name";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsUpdCol = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            this.xEditGridCell12.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtUitakName
            // 
            this.txtUitakName.AccessibleDescription = null;
            this.txtUitakName.AccessibleName = null;
            resources.ApplyResources(this.txtUitakName, "txtUitakName");
            this.txtUitakName.BackColor = IHIS.Framework.XColor.XTreeViewBackColor;
            this.txtUitakName.BackgroundImage = null;
            this.txtUitakName.Name = "txtUitakName";
            this.txtUitakName.TabStop = false;
            this.toolTip.SetToolTip(this.txtUitakName, resources.GetString("txtUitakName.ToolTip"));
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell13.BindControl = this.fbxSutakCode;
            this.xEditGridCell13.CellLen = 4;
            this.xEditGridCell13.CellName = "sutak_code";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            this.xEditGridCell13.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // fbxSutakCode
            // 
            this.fbxSutakCode.AccessibleDescription = null;
            this.fbxSutakCode.AccessibleName = null;
            resources.ApplyResources(this.fbxSutakCode, "fbxSutakCode");
            this.fbxSutakCode.BackgroundImage = null;
            this.fbxSutakCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxSutakCode.FindWorker = this.fwkCPL0101;
            this.fbxSutakCode.Name = "fbxSutakCode";
            this.toolTip.SetToolTip(this.fbxSutakCode, resources.GetString("fbxSutakCode.ToolTip"));
            this.fbxSutakCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbx_DataValidating);
            this.fbxSutakCode.FindClick += new System.ComponentModel.CancelEventHandler(this.fbx_FindClick);
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell14.BindControl = this.txtSutakName;
            this.xEditGridCell14.CellName = "sutak_name";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsUpdCol = false;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            this.xEditGridCell14.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtSutakName
            // 
            this.txtSutakName.AccessibleDescription = null;
            this.txtSutakName.AccessibleName = null;
            resources.ApplyResources(this.txtSutakName, "txtSutakName");
            this.txtSutakName.BackColor = IHIS.Framework.XColor.XTreeViewBackColor;
            this.txtSutakName.BackgroundImage = null;
            this.txtSutakName.Name = "txtSutakName";
            this.txtSutakName.TabStop = false;
            this.toolTip.SetToolTip(this.txtSutakName, resources.GetString("txtSutakName.ToolTip"));
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell15.BindControl = this.fbxSlipCode;
            this.xEditGridCell15.CellLen = 6;
            this.xEditGridCell15.CellName = "slip_code";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            this.xEditGridCell15.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // fbxSlipCode
            // 
            this.fbxSlipCode.AccessibleDescription = null;
            this.fbxSlipCode.AccessibleName = null;
            resources.ApplyResources(this.fbxSlipCode, "fbxSlipCode");
            this.fbxSlipCode.BackgroundImage = null;
            this.fbxSlipCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxSlipCode.FindWorker = this.fwkCPL0101;
            this.fbxSlipCode.Name = "fbxSlipCode";
            this.toolTip.SetToolTip(this.fbxSlipCode, resources.GetString("fbxSlipCode.ToolTip"));
            this.fbxSlipCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbx_DataValidating);
            this.fbxSlipCode.FindClick += new System.ComponentModel.CancelEventHandler(this.fbx_FindClick);
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell16.BindControl = this.txtSlipName;
            this.xEditGridCell16.CellName = "slip_name";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            this.xEditGridCell16.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsUpdCol = false;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            this.xEditGridCell16.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtSlipName
            // 
            this.txtSlipName.AccessibleDescription = null;
            this.txtSlipName.AccessibleName = null;
            resources.ApplyResources(this.txtSlipName, "txtSlipName");
            this.txtSlipName.BackColor = IHIS.Framework.XColor.XTreeViewBackColor;
            this.txtSlipName.BackgroundImage = null;
            this.txtSlipName.Name = "txtSlipName";
            this.txtSlipName.TabStop = false;
            this.toolTip.SetToolTip(this.txtSlipName, resources.GetString("txtSlipName.ToolTip"));
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell17.BindControl = this.fbxJangbiCode;
            this.xEditGridCell17.CellLen = 4;
            this.xEditGridCell17.CellName = "jangbi_code";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            this.xEditGridCell17.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            this.xEditGridCell17.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // fbxJangbiCode
            // 
            this.fbxJangbiCode.AccessibleDescription = null;
            this.fbxJangbiCode.AccessibleName = null;
            resources.ApplyResources(this.fbxJangbiCode, "fbxJangbiCode");
            this.fbxJangbiCode.BackgroundImage = null;
            this.fbxJangbiCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxJangbiCode.FindWorker = this.fwkCPL0101;
            this.fbxJangbiCode.Name = "fbxJangbiCode";
            this.toolTip.SetToolTip(this.fbxJangbiCode, resources.GetString("fbxJangbiCode.ToolTip"));
            this.fbxJangbiCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbx_DataValidating);
            this.fbxJangbiCode.FindClick += new System.ComponentModel.CancelEventHandler(this.fbx_FindClick);
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell18.BindControl = this.txtJangbiName;
            this.xEditGridCell18.CellName = "jangbi_name";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            this.xEditGridCell18.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsUpdCol = false;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            this.xEditGridCell18.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtJangbiName
            // 
            this.txtJangbiName.AccessibleDescription = null;
            this.txtJangbiName.AccessibleName = null;
            resources.ApplyResources(this.txtJangbiName, "txtJangbiName");
            this.txtJangbiName.BackColor = IHIS.Framework.XColor.XTreeViewBackColor;
            this.txtJangbiName.BackgroundImage = null;
            this.txtJangbiName.Name = "txtJangbiName";
            this.txtJangbiName.TabStop = false;
            this.toolTip.SetToolTip(this.txtJangbiName, resources.GetString("txtJangbiName.ToolTip"));
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell19.BindControl = this.txtJangbiOutCode;
            this.xEditGridCell19.CellLen = 30;
            this.xEditGridCell19.CellName = "jangbi_out_code";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.ExecuteQuery = null;
            this.xEditGridCell19.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            this.xEditGridCell19.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtJangbiOutCode
            // 
            this.txtJangbiOutCode.AccessibleDescription = null;
            this.txtJangbiOutCode.AccessibleName = null;
            resources.ApplyResources(this.txtJangbiOutCode, "txtJangbiOutCode");
            this.txtJangbiOutCode.BackgroundImage = null;
            this.txtJangbiOutCode.Name = "txtJangbiOutCode";
            this.toolTip.SetToolTip(this.txtJangbiOutCode, resources.GetString("txtJangbiOutCode.ToolTip"));
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell20.BindControl = this.fbxJangbiCode2;
            this.xEditGridCell20.CellLen = 4;
            this.xEditGridCell20.CellName = "jangbi_code2";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            this.xEditGridCell20.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            this.xEditGridCell20.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // fbxJangbiCode2
            // 
            this.fbxJangbiCode2.AccessibleDescription = null;
            this.fbxJangbiCode2.AccessibleName = null;
            resources.ApplyResources(this.fbxJangbiCode2, "fbxJangbiCode2");
            this.fbxJangbiCode2.BackgroundImage = null;
            this.fbxJangbiCode2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxJangbiCode2.FindWorker = this.fwkCPL0101;
            this.fbxJangbiCode2.Name = "fbxJangbiCode2";
            this.toolTip.SetToolTip(this.fbxJangbiCode2, resources.GetString("fbxJangbiCode2.ToolTip"));
            this.fbxJangbiCode2.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbx_DataValidating);
            this.fbxJangbiCode2.FindClick += new System.ComponentModel.CancelEventHandler(this.fbx_FindClick);
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell21.BindControl = this.txtJangbiName2;
            this.xEditGridCell21.CellLen = 30;
            this.xEditGridCell21.CellName = "jangbi_name2";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.ExecuteQuery = null;
            this.xEditGridCell21.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsUpdCol = false;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            this.xEditGridCell21.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtJangbiName2
            // 
            this.txtJangbiName2.AccessibleDescription = null;
            this.txtJangbiName2.AccessibleName = null;
            resources.ApplyResources(this.txtJangbiName2, "txtJangbiName2");
            this.txtJangbiName2.BackColor = IHIS.Framework.XColor.XTreeViewBackColor;
            this.txtJangbiName2.BackgroundImage = null;
            this.txtJangbiName2.Name = "txtJangbiName2";
            this.txtJangbiName2.TabStop = false;
            this.toolTip.SetToolTip(this.txtJangbiName2, resources.GetString("txtJangbiName2.ToolTip"));
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell22.BindControl = this.txtJangbiOutCode2;
            this.xEditGridCell22.CellLen = 30;
            this.xEditGridCell22.CellName = "jangbi_out_code2";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            this.xEditGridCell22.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            this.xEditGridCell22.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtJangbiOutCode2
            // 
            this.txtJangbiOutCode2.AccessibleDescription = null;
            this.txtJangbiOutCode2.AccessibleName = null;
            resources.ApplyResources(this.txtJangbiOutCode2, "txtJangbiOutCode2");
            this.txtJangbiOutCode2.BackgroundImage = null;
            this.txtJangbiOutCode2.Name = "txtJangbiOutCode2";
            this.toolTip.SetToolTip(this.txtJangbiOutCode2, resources.GetString("txtJangbiOutCode2.ToolTip"));
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell23.BindControl = this.fbxJangbiCode3;
            this.xEditGridCell23.CellLen = 4;
            this.xEditGridCell23.CellName = "jangbi_code3";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.ExecuteQuery = null;
            this.xEditGridCell23.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            this.xEditGridCell23.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // fbxJangbiCode3
            // 
            this.fbxJangbiCode3.AccessibleDescription = null;
            this.fbxJangbiCode3.AccessibleName = null;
            resources.ApplyResources(this.fbxJangbiCode3, "fbxJangbiCode3");
            this.fbxJangbiCode3.BackgroundImage = null;
            this.fbxJangbiCode3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxJangbiCode3.FindWorker = this.fwkCPL0101;
            this.fbxJangbiCode3.Name = "fbxJangbiCode3";
            this.toolTip.SetToolTip(this.fbxJangbiCode3, resources.GetString("fbxJangbiCode3.ToolTip"));
            this.fbxJangbiCode3.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbx_DataValidating);
            this.fbxJangbiCode3.FindClick += new System.ComponentModel.CancelEventHandler(this.fbx_FindClick);
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell24.BindControl = this.txtJangbiName3;
            this.xEditGridCell24.CellName = "jangbi_name3";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            this.xEditGridCell24.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsUpdCol = false;
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            this.xEditGridCell24.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtJangbiName3
            // 
            this.txtJangbiName3.AccessibleDescription = null;
            this.txtJangbiName3.AccessibleName = null;
            resources.ApplyResources(this.txtJangbiName3, "txtJangbiName3");
            this.txtJangbiName3.BackColor = IHIS.Framework.XColor.XTreeViewBackColor;
            this.txtJangbiName3.BackgroundImage = null;
            this.txtJangbiName3.Name = "txtJangbiName3";
            this.txtJangbiName3.TabStop = false;
            this.toolTip.SetToolTip(this.txtJangbiName3, resources.GetString("txtJangbiName3.ToolTip"));
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell25.BindControl = this.txtJangbiOutCode3;
            this.xEditGridCell25.CellLen = 30;
            this.xEditGridCell25.CellName = "jangbi_out_code3";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            this.xEditGridCell25.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            this.xEditGridCell25.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtJangbiOutCode3
            // 
            this.txtJangbiOutCode3.AccessibleDescription = null;
            this.txtJangbiOutCode3.AccessibleName = null;
            resources.ApplyResources(this.txtJangbiOutCode3, "txtJangbiOutCode3");
            this.txtJangbiOutCode3.BackgroundImage = null;
            this.txtJangbiOutCode3.Name = "txtJangbiOutCode3";
            this.toolTip.SetToolTip(this.txtJangbiOutCode3, resources.GetString("txtJangbiOutCode3.ToolTip"));
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell26.BindControl = this.cboGroupGubun;
            this.xEditGridCell26.CellName = "group_gubun";
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.ExecuteQuery = null;
            this.xEditGridCell26.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            this.xEditGridCell26.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // cboGroupGubun
            // 
            this.cboGroupGubun.AccessibleDescription = null;
            this.cboGroupGubun.AccessibleName = null;
            resources.ApplyResources(this.cboGroupGubun, "cboGroupGubun");
            this.cboGroupGubun.BackgroundImage = null;
            this.cboGroupGubun.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2,
            this.xComboItem3});
            this.cboGroupGubun.Name = "cboGroupGubun";
            this.toolTip.SetToolTip(this.cboGroupGubun, resources.GetString("cboGroupGubun.ToolTip"));
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "01";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "02";
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ValueItem = "03";
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell27.BindControl = this.txtGumsaNameRe;
            this.xEditGridCell27.CellName = "gumsa_name_re";
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.ExecuteQuery = null;
            this.xEditGridCell27.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            this.xEditGridCell27.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtGumsaNameRe
            // 
            this.txtGumsaNameRe.AccessibleDescription = null;
            this.txtGumsaNameRe.AccessibleName = null;
            resources.ApplyResources(this.txtGumsaNameRe, "txtGumsaNameRe");
            this.txtGumsaNameRe.BackgroundImage = null;
            this.txtGumsaNameRe.Name = "txtGumsaNameRe";
            this.toolTip.SetToolTip(this.txtGumsaNameRe, resources.GetString("txtGumsaNameRe.ToolTip"));
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell28.BindControl = this.cboBarcode;
            this.xEditGridCell28.CellName = "barcode";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.ExecuteQuery = null;
            this.xEditGridCell28.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            this.xEditGridCell28.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // cboBarcode
            // 
            this.cboBarcode.AccessibleDescription = null;
            this.cboBarcode.AccessibleName = null;
            resources.ApplyResources(this.cboBarcode, "cboBarcode");
            this.cboBarcode.BackgroundImage = null;
            this.cboBarcode.ExecuteQuery = null;
            this.cboBarcode.Name = "cboBarcode";
            this.cboBarcode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboBarcode.ParamList")));
            this.cboBarcode.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.toolTip.SetToolTip(this.cboBarcode, resources.GetString("cboBarcode.ToolTip"));
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell29.BindControl = this.txtGumsaName;
            this.xEditGridCell29.CellName = "gumsa_name";
            this.xEditGridCell29.CellWidth = 174;
            this.xEditGridCell29.Col = 2;
            this.xEditGridCell29.ExecuteQuery = null;
            this.xEditGridCell29.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtGumsaName
            // 
            this.txtGumsaName.AccessibleDescription = null;
            this.txtGumsaName.AccessibleName = null;
            resources.ApplyResources(this.txtGumsaName, "txtGumsaName");
            this.txtGumsaName.BackgroundImage = null;
            this.txtGumsaName.Name = "txtGumsaName";
            this.toolTip.SetToolTip(this.txtGumsaName, resources.GetString("txtGumsaName.ToolTip"));
            this.txtGumsaName.TextChanged += new System.EventHandler(this.txtGumsaName_TextChanged);
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell30.BindControl = this.txtDefaultResult;
            this.xEditGridCell30.CellLen = 100;
            this.xEditGridCell30.CellName = "default_result";
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.ExecuteQuery = null;
            this.xEditGridCell30.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            this.xEditGridCell30.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtDefaultResult
            // 
            this.txtDefaultResult.AccessibleDescription = null;
            this.txtDefaultResult.AccessibleName = null;
            resources.ApplyResources(this.txtDefaultResult, "txtDefaultResult");
            this.txtDefaultResult.BackgroundImage = null;
            this.txtDefaultResult.Name = "txtDefaultResult";
            this.toolTip.SetToolTip(this.txtDefaultResult, resources.GetString("txtDefaultResult.ToolTip"));
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell31.BindControl = this.txtMedicalJundal;
            this.xEditGridCell31.CellName = "medical_jundal";
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.ExecuteQuery = null;
            this.xEditGridCell31.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            this.xEditGridCell31.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtMedicalJundal
            // 
            this.txtMedicalJundal.AccessibleDescription = null;
            this.txtMedicalJundal.AccessibleName = null;
            resources.ApplyResources(this.txtMedicalJundal, "txtMedicalJundal");
            this.txtMedicalJundal.BackgroundImage = null;
            this.txtMedicalJundal.Name = "txtMedicalJundal";
            this.toolTip.SetToolTip(this.txtMedicalJundal, resources.GetString("txtMedicalJundal.ToolTip"));
            this.txtMedicalJundal.TextChanged += new System.EventHandler(this.txtMedicalJundal_TextChanged);
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell32.BindControl = this.txtCommentJuCode;
            this.xEditGridCell32.CellLen = 200;
            this.xEditGridCell32.CellName = "comment_ju_code";
            this.xEditGridCell32.Col = -1;
            this.xEditGridCell32.ExecuteQuery = null;
            this.xEditGridCell32.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsVisible = false;
            this.xEditGridCell32.Row = -1;
            this.xEditGridCell32.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtCommentJuCode
            // 
            this.txtCommentJuCode.AccessibleDescription = null;
            this.txtCommentJuCode.AccessibleName = null;
            resources.ApplyResources(this.txtCommentJuCode, "txtCommentJuCode");
            this.txtCommentJuCode.BackgroundImage = null;
            this.txtCommentJuCode.Name = "txtCommentJuCode";
            this.toolTip.SetToolTip(this.txtCommentJuCode, resources.GetString("txtCommentJuCode.ToolTip"));
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell33.BindControl = this.txtSerial;
            this.xEditGridCell33.CellName = "serial";
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            this.xEditGridCell33.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            this.xEditGridCell33.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtSerial
            // 
            this.txtSerial.AccessibleDescription = null;
            this.txtSerial.AccessibleName = null;
            resources.ApplyResources(this.txtSerial, "txtSerial");
            this.txtSerial.BackgroundImage = null;
            this.txtSerial.Name = "txtSerial";
            this.toolTip.SetToolTip(this.txtSerial, resources.GetString("txtSerial.ToolTip"));
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell34.BindControl = this.cboChubang_yn;
            this.xEditGridCell34.CellName = "chubang_yn";
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.ExecuteQuery = null;
            this.xEditGridCell34.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            this.xEditGridCell34.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // cboChubang_yn
            // 
            this.cboChubang_yn.AccessibleDescription = null;
            this.cboChubang_yn.AccessibleName = null;
            resources.ApplyResources(this.cboChubang_yn, "cboChubang_yn");
            this.cboChubang_yn.BackgroundImage = null;
            this.cboChubang_yn.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem4,
            this.xComboItem5});
            this.cboChubang_yn.ExecuteQuery = null;
            this.cboChubang_yn.Name = "cboChubang_yn";
            this.cboChubang_yn.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboChubang_yn.ParamList")));
            this.toolTip.SetToolTip(this.cboChubang_yn, resources.GetString("cboChubang_yn.ToolTip"));
            // 
            // xComboItem4
            // 
            resources.ApplyResources(this.xComboItem4, "xComboItem4");
            this.xComboItem4.ValueItem = "Y";
            // 
            // xComboItem5
            // 
            resources.ApplyResources(this.xComboItem5, "xComboItem5");
            this.xComboItem5.ValueItem = "N";
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell35.BindControl = this.cboResult_yn;
            this.xEditGridCell35.CellName = "result_yn";
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.ExecuteQuery = null;
            this.xEditGridCell35.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            this.xEditGridCell35.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // cboResult_yn
            // 
            this.cboResult_yn.AccessibleDescription = null;
            this.cboResult_yn.AccessibleName = null;
            resources.ApplyResources(this.cboResult_yn, "cboResult_yn");
            this.cboResult_yn.BackgroundImage = null;
            this.cboResult_yn.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem6,
            this.xComboItem7});
            this.cboResult_yn.ExecuteQuery = null;
            this.cboResult_yn.Name = "cboResult_yn";
            this.cboResult_yn.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboResult_yn.ParamList")));
            this.toolTip.SetToolTip(this.cboResult_yn, resources.GetString("cboResult_yn.ToolTip"));
            // 
            // xComboItem6
            // 
            resources.ApplyResources(this.xComboItem6, "xComboItem6");
            this.xComboItem6.ValueItem = "Y";
            // 
            // xComboItem7
            // 
            resources.ApplyResources(this.xComboItem7, "xComboItem7");
            this.xComboItem7.ValueItem = "N";
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell36.BindControl = this.cboResultForm;
            this.xEditGridCell36.CellName = "result_form";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            this.xEditGridCell36.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            this.xEditGridCell36.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // cboResultForm
            // 
            this.cboResultForm.AccessibleDescription = null;
            this.cboResultForm.AccessibleName = null;
            resources.ApplyResources(this.cboResultForm, "cboResultForm");
            this.cboResultForm.BackgroundImage = null;
            this.cboResultForm.ExecuteQuery = null;
            this.cboResultForm.Name = "cboResultForm";
            this.cboResultForm.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboResultForm.ParamList")));
            this.cboResultForm.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.toolTip.SetToolTip(this.cboResultForm, resources.GetString("cboResultForm.ToolTip"));
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell37.BindControl = this.cboTongGubun_yn;
            this.xEditGridCell37.CellName = "tong_gubun";
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.ExecuteQuery = null;
            this.xEditGridCell37.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            this.xEditGridCell37.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // cboTongGubun_yn
            // 
            this.cboTongGubun_yn.AccessibleDescription = null;
            this.cboTongGubun_yn.AccessibleName = null;
            resources.ApplyResources(this.cboTongGubun_yn, "cboTongGubun_yn");
            this.cboTongGubun_yn.BackgroundImage = null;
            this.cboTongGubun_yn.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem8,
            this.xComboItem9});
            this.cboTongGubun_yn.ExecuteQuery = null;
            this.cboTongGubun_yn.Name = "cboTongGubun_yn";
            this.cboTongGubun_yn.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboTongGubun_yn.ParamList")));
            this.toolTip.SetToolTip(this.cboTongGubun_yn, resources.GetString("cboTongGubun_yn.ToolTip"));
            // 
            // xComboItem8
            // 
            resources.ApplyResources(this.xComboItem8, "xComboItem8");
            this.xComboItem8.ValueItem = "Y";
            // 
            // xComboItem9
            // 
            resources.ApplyResources(this.xComboItem9, "xComboItem9");
            this.xComboItem9.ValueItem = "N";
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell38.BindControl = this.txtSpecimenAmt;
            this.xEditGridCell38.CellName = "specimen_amt";
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.ExecuteQuery = null;
            this.xEditGridCell38.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            this.xEditGridCell38.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtSpecimenAmt
            // 
            this.txtSpecimenAmt.AccessibleDescription = null;
            this.txtSpecimenAmt.AccessibleName = null;
            resources.ApplyResources(this.txtSpecimenAmt, "txtSpecimenAmt");
            this.txtSpecimenAmt.BackgroundImage = null;
            this.txtSpecimenAmt.DecimalDigits = 1;
            this.txtSpecimenAmt.EditMaskType = IHIS.Framework.MaskType.Decimal;
            this.txtSpecimenAmt.EditVietnameseMaskType = IHIS.Framework.MaskType.Decimal;
            this.txtSpecimenAmt.GeneralNumberFormat = true;
            this.txtSpecimenAmt.IsVietnameseYearType = false;
            this.txtSpecimenAmt.MaxinumCipher = 10;
            this.txtSpecimenAmt.MinusAccept = true;
            this.txtSpecimenAmt.Name = "txtSpecimenAmt";
            this.toolTip.SetToolTip(this.txtSpecimenAmt, resources.GetString("txtSpecimenAmt.ToolTip"));
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell39.CellName = "old_slip_code";
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.ExecuteQuery = null;
            this.xEditGridCell39.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            this.xEditGridCell39.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell43.BindControl = this.txtDetailInfo;
            this.xEditGridCell43.CellLen = 4000;
            this.xEditGridCell43.CellName = "detail_info";
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.ExecuteQuery = null;
            this.xEditGridCell43.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            this.xEditGridCell43.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtDetailInfo
            // 
            this.txtDetailInfo.AccessibleDescription = null;
            this.txtDetailInfo.AccessibleName = null;
            resources.ApplyResources(this.txtDetailInfo, "txtDetailInfo");
            this.txtDetailInfo.BackgroundImage = null;
            this.txtDetailInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetailInfo.EnterKeyToTab = false;
            this.txtDetailInfo.Name = "txtDetailInfo";
            this.toolTip.SetToolTip(this.txtDetailInfo, resources.GetString("txtDetailInfo.ToolTip"));
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell42.BindControl = this.cboDisplayYn;
            this.xEditGridCell42.CellLen = 1;
            this.xEditGridCell42.CellName = "display_yn";
            this.xEditGridCell42.CellWidth = 81;
            this.xEditGridCell42.Col = 4;
            this.xEditGridCell42.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell42.ExecuteQuery = null;
            this.xEditGridCell42.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell42.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboDisplayYn
            // 
            this.cboDisplayYn.AccessibleDescription = null;
            this.cboDisplayYn.AccessibleName = null;
            resources.ApplyResources(this.cboDisplayYn, "cboDisplayYn");
            this.cboDisplayYn.BackgroundImage = null;
            this.cboDisplayYn.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem10,
            this.xComboItem11});
            this.cboDisplayYn.ExecuteQuery = null;
            this.cboDisplayYn.Name = "cboDisplayYn";
            this.cboDisplayYn.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboDisplayYn.ParamList")));
            this.toolTip.SetToolTip(this.cboDisplayYn, resources.GetString("cboDisplayYn.ToolTip"));
            // 
            // xComboItem10
            // 
            resources.ApplyResources(this.xComboItem10, "xComboItem10");
            this.xComboItem10.ValueItem = "Y";
            // 
            // xComboItem11
            // 
            resources.ApplyResources(this.xComboItem11, "xComboItem11");
            this.xComboItem11.ValueItem = "N";
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell44.BindControl = this.txtJundalGubunName;
            this.xEditGridCell44.CellName = "jundal_gubun_name";
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.ExecuteQuery = null;
            this.xEditGridCell44.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            this.xEditGridCell44.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtJundalGubunName
            // 
            this.txtJundalGubunName.AccessibleDescription = null;
            this.txtJundalGubunName.AccessibleName = null;
            resources.ApplyResources(this.txtJundalGubunName, "txtJundalGubunName");
            this.txtJundalGubunName.BackgroundImage = null;
            this.txtJundalGubunName.Name = "txtJundalGubunName";
            this.toolTip.SetToolTip(this.txtJundalGubunName, resources.GetString("txtJundalGubunName.ToolTip"));
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell45.BindControl = this.cboSpcialName;
            this.xEditGridCell45.CellName = "spcial_name";
            this.xEditGridCell45.Col = -1;
            this.xEditGridCell45.ExecuteQuery = null;
            this.xEditGridCell45.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.IsVisible = false;
            this.xEditGridCell45.Row = -1;
            this.xEditGridCell45.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // cboSpcialName
            // 
            this.cboSpcialName.AccessibleDescription = null;
            this.cboSpcialName.AccessibleName = null;
            resources.ApplyResources(this.cboSpcialName, "cboSpcialName");
            this.cboSpcialName.BackgroundImage = null;
            this.cboSpcialName.ExecuteQuery = null;
            this.cboSpcialName.Name = "cboSpcialName";
            this.cboSpcialName.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboSpcialName.ParamList")));
            this.cboSpcialName.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.toolTip.SetToolTip(this.cboSpcialName, resources.GetString("cboSpcialName.ToolTip"));
            this.cboSpcialName.UserSQL = "SELECT CODE, CODE_NAME\r\n    FROM CPL0109\r\n  WHERE HOSP_CODE = fn_adm_load_hosp_co" +
                "de()\r\n    AND CODE_TYPE = \'22\'";
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell46.BindControl = this.txtTongSerial;
            this.xEditGridCell46.CellName = "tong_serial";
            this.xEditGridCell46.Col = -1;
            this.xEditGridCell46.ExecuteQuery = null;
            this.xEditGridCell46.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
            this.xEditGridCell46.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtTongSerial
            // 
            this.txtTongSerial.AccessibleDescription = null;
            this.txtTongSerial.AccessibleName = null;
            resources.ApplyResources(this.txtTongSerial, "txtTongSerial");
            this.txtTongSerial.BackgroundImage = null;
            this.txtTongSerial.Name = "txtTongSerial";
            this.toolTip.SetToolTip(this.txtTongSerial, resources.GetString("txtTongSerial.ToolTip"));
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell47.BindControl = this.txtPoint;
            this.xEditGridCell47.CellName = "point";
            this.xEditGridCell47.Col = -1;
            this.xEditGridCell47.ExecuteQuery = null;
            this.xEditGridCell47.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsVisible = false;
            this.xEditGridCell47.Row = -1;
            this.xEditGridCell47.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtPoint
            // 
            this.txtPoint.AccessibleDescription = null;
            this.txtPoint.AccessibleName = null;
            resources.ApplyResources(this.txtPoint, "txtPoint");
            this.txtPoint.BackgroundImage = null;
            this.txtPoint.EditMaskType = IHIS.Framework.MaskType.Number;
            this.txtPoint.EditVietnameseMaskType = IHIS.Framework.MaskType.Number;
            this.txtPoint.IsVietnameseYearType = false;
            this.txtPoint.Name = "txtPoint";
            this.toolTip.SetToolTip(this.txtPoint, resources.GetString("txtPoint.ToolTip"));
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell48.BindControl = this.txtPoint2;
            this.xEditGridCell48.CellName = "point2";
            this.xEditGridCell48.Col = -1;
            this.xEditGridCell48.ExecuteQuery = null;
            this.xEditGridCell48.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            this.xEditGridCell48.IsVisible = false;
            this.xEditGridCell48.Row = -1;
            this.xEditGridCell48.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtPoint2
            // 
            this.txtPoint2.AccessibleDescription = null;
            this.txtPoint2.AccessibleName = null;
            resources.ApplyResources(this.txtPoint2, "txtPoint2");
            this.txtPoint2.BackgroundImage = null;
            this.txtPoint2.EditMaskType = IHIS.Framework.MaskType.Number;
            this.txtPoint2.EditVietnameseMaskType = IHIS.Framework.MaskType.Number;
            this.txtPoint2.IsVietnameseYearType = false;
            this.txtPoint2.Name = "txtPoint2";
            this.toolTip.SetToolTip(this.txtPoint2, resources.GetString("txtPoint2.ToolTip"));
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell49.BindControl = this.txtPoint3;
            this.xEditGridCell49.CellName = "point3";
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.ExecuteQuery = null;
            this.xEditGridCell49.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            this.xEditGridCell49.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtPoint3
            // 
            this.txtPoint3.AccessibleDescription = null;
            this.txtPoint3.AccessibleName = null;
            resources.ApplyResources(this.txtPoint3, "txtPoint3");
            this.txtPoint3.BackgroundImage = null;
            this.txtPoint3.EditMaskType = IHIS.Framework.MaskType.Number;
            this.txtPoint3.EditVietnameseMaskType = IHIS.Framework.MaskType.Number;
            this.txtPoint3.IsVietnameseYearType = false;
            this.txtPoint3.Name = "txtPoint3";
            this.toolTip.SetToolTip(this.txtPoint3, resources.GetString("txtPoint3.ToolTip"));
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell50.BindControl = this.txtOutTube;
            this.xEditGridCell50.CellLen = 4;
            this.xEditGridCell50.CellName = "out_tube";
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.ExecuteQuery = null;
            this.xEditGridCell50.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            this.xEditGridCell50.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtOutTube
            // 
            this.txtOutTube.AccessibleDescription = null;
            this.txtOutTube.AccessibleName = null;
            resources.ApplyResources(this.txtOutTube, "txtOutTube");
            this.txtOutTube.BackgroundImage = null;
            this.txtOutTube.Name = "txtOutTube";
            this.toolTip.SetToolTip(this.txtOutTube, resources.GetString("txtOutTube.ToolTip"));
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell51.BindControl = this.txtOutTube2;
            this.xEditGridCell51.CellLen = 4;
            this.xEditGridCell51.CellName = "out_tube2";
            this.xEditGridCell51.Col = -1;
            this.xEditGridCell51.ExecuteQuery = null;
            this.xEditGridCell51.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            this.xEditGridCell51.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtOutTube2
            // 
            this.txtOutTube2.AccessibleDescription = null;
            this.txtOutTube2.AccessibleName = null;
            resources.ApplyResources(this.txtOutTube2, "txtOutTube2");
            this.txtOutTube2.BackgroundImage = null;
            this.txtOutTube2.Name = "txtOutTube2";
            this.toolTip.SetToolTip(this.txtOutTube2, resources.GetString("txtOutTube2.ToolTip"));
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell52.BindControl = this.txtHangmogMarkName;
            this.xEditGridCell52.CellLen = 20;
            this.xEditGridCell52.CellName = "hangmog_mark_name";
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.ExecuteQuery = null;
            this.xEditGridCell52.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            this.xEditGridCell52.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtHangmogMarkName
            // 
            this.txtHangmogMarkName.AccessibleDescription = null;
            this.txtHangmogMarkName.AccessibleName = null;
            resources.ApplyResources(this.txtHangmogMarkName, "txtHangmogMarkName");
            this.txtHangmogMarkName.BackgroundImage = null;
            this.txtHangmogMarkName.Name = "txtHangmogMarkName";
            this.toolTip.SetToolTip(this.txtHangmogMarkName, resources.GetString("txtHangmogMarkName.ToolTip"));
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell53.BindControl = this.cbxMiddleResult;
            this.xEditGridCell53.CellName = "middle_result";
            this.xEditGridCell53.Col = -1;
            this.xEditGridCell53.ExecuteQuery = null;
            this.xEditGridCell53.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            this.xEditGridCell53.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // cbxMiddleResult
            // 
            this.cbxMiddleResult.AccessibleDescription = null;
            this.cbxMiddleResult.AccessibleName = null;
            resources.ApplyResources(this.cbxMiddleResult, "cbxMiddleResult");
            this.cbxMiddleResult.BackgroundImage = null;
            this.cbxMiddleResult.Name = "cbxMiddleResult";
            this.toolTip.SetToolTip(this.cbxMiddleResult, resources.GetString("cbxMiddleResult.ToolTip"));
            this.cbxMiddleResult.UseVisualStyleBackColor = false;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell54.CellName = "user_gubun";
            this.xEditGridCell54.Col = -1;
            this.xEditGridCell54.ExecuteQuery = null;
            this.xEditGridCell54.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.IsVisible = false;
            this.xEditGridCell54.Row = -1;
            this.xEditGridCell54.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell54.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell55.BindControl = this.txtJlac10Code1;
            this.xEditGridCell55.CellLen = 100;
            this.xEditGridCell55.CellName = "jlac10_code1";
            this.xEditGridCell55.Col = -1;
            this.xEditGridCell55.ExecuteQuery = null;
            this.xEditGridCell55.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.IsVisible = false;
            this.xEditGridCell55.Row = -1;
            this.xEditGridCell55.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtJlac10Code1
            // 
            this.txtJlac10Code1.AccessibleDescription = null;
            this.txtJlac10Code1.AccessibleName = null;
            resources.ApplyResources(this.txtJlac10Code1, "txtJlac10Code1");
            this.txtJlac10Code1.BackgroundImage = null;
            this.txtJlac10Code1.Name = "txtJlac10Code1";
            this.toolTip.SetToolTip(this.txtJlac10Code1, resources.GetString("txtJlac10Code1.ToolTip"));
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell56.BindControl = this.txtJlac10Code2;
            this.xEditGridCell56.CellLen = 100;
            this.xEditGridCell56.CellName = "jlac10_code2";
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.ExecuteQuery = null;
            this.xEditGridCell56.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            this.xEditGridCell56.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtJlac10Code2
            // 
            this.txtJlac10Code2.AccessibleDescription = null;
            this.txtJlac10Code2.AccessibleName = null;
            resources.ApplyResources(this.txtJlac10Code2, "txtJlac10Code2");
            this.txtJlac10Code2.BackgroundImage = null;
            this.txtJlac10Code2.Name = "txtJlac10Code2";
            this.toolTip.SetToolTip(this.txtJlac10Code2, resources.GetString("txtJlac10Code2.ToolTip"));
            // 
            // cboUserGubun
            // 
            this.cboUserGubun.AccessibleDescription = null;
            this.cboUserGubun.AccessibleName = null;
            resources.ApplyResources(this.cboUserGubun, "cboUserGubun");
            this.cboUserGubun.BackgroundImage = null;
            this.cboUserGubun.ExecuteQuery = null;
            this.cboUserGubun.Name = "cboUserGubun";
            this.cboUserGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboUserGubun.ParamList")));
            this.cboUserGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.toolTip.SetToolTip(this.cboUserGubun, resources.GetString("cboUserGubun.ToolTip"));
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.cboInoutGubun);
            this.xPanel3.Controls.Add(this.xLabel39);
            this.xPanel3.Controls.Add(this.xPanel4);
            this.xPanel3.Controls.Add(this.btnGroup);
            this.xPanel3.Controls.Add(this.txtSpecimenName);
            this.xPanel3.Controls.Add(this.txtJangbiName3);
            this.xPanel3.Controls.Add(this.txtJangbiName2);
            this.xPanel3.Controls.Add(this.txtJangbiName);
            this.xPanel3.Controls.Add(this.txtSlipName);
            this.xPanel3.Controls.Add(this.txtSutakName);
            this.xPanel3.Controls.Add(this.txtUitakName);
            this.xPanel3.Controls.Add(this.txtDanuiName);
            this.xPanel3.Controls.Add(this.txtJundalName);
            this.xPanel3.Controls.Add(this.cboUserGubun);
            this.xPanel3.Controls.Add(this.lbUserGubun);
            this.xPanel3.Controls.Add(this.cbxMiddleResult);
            this.xPanel3.Controls.Add(this.xLabel38);
            this.xPanel3.Controls.Add(this.txtHangmogMarkName);
            this.xPanel3.Controls.Add(this.xLabel37);
            this.xPanel3.Controls.Add(this.txtOutTube2);
            this.xPanel3.Controls.Add(this.txtOutTube);
            this.xPanel3.Controls.Add(this.xLabel36);
            this.xPanel3.Controls.Add(this.txtPoint3);
            this.xPanel3.Controls.Add(this.txtPoint2);
            this.xPanel3.Controls.Add(this.txtPoint);
            this.xPanel3.Controls.Add(this.xLabel35);
            this.xPanel3.Controls.Add(this.xLabel34);
            this.xPanel3.Controls.Add(this.txtTongSerial);
            this.xPanel3.Controls.Add(this.cboSpcialName);
            this.xPanel3.Controls.Add(this.xLabel31);
            this.xPanel3.Controls.Add(this.txtDetailInfo);
            this.xPanel3.Controls.Add(this.xLabel30);
            this.xPanel3.Controls.Add(this.cboDisplayYn);
            this.xPanel3.Controls.Add(this.xLabel20);
            this.xPanel3.Controls.Add(this.cboTongGubun_yn);
            this.xPanel3.Controls.Add(this.cboResult_yn);
            this.xPanel3.Controls.Add(this.cboChubang_yn);
            this.xPanel3.Controls.Add(this.txtMedicalJundal);
            this.xPanel3.Controls.Add(this.txtGumsaName);
            this.xPanel3.Controls.Add(this.cboResultForm);
            this.xPanel3.Controls.Add(this.txtSpecimenAmt);
            this.xPanel3.Controls.Add(this.xLabel29);
            this.xPanel3.Controls.Add(this.xLabel28);
            this.xPanel3.Controls.Add(this.xLabel27);
            this.xPanel3.Controls.Add(this.xLabel26);
            this.xPanel3.Controls.Add(this.fbxSlipCode);
            this.xPanel3.Controls.Add(this.xLabel25);
            this.xPanel3.Controls.Add(this.xLabel24);
            this.xPanel3.Controls.Add(this.txtSerial);
            this.xPanel3.Controls.Add(this.xLabel23);
            this.xPanel3.Controls.Add(this.txtJlac10Code1);
            this.xPanel3.Controls.Add(this.txtJlac10Code2);
            this.xPanel3.Controls.Add(this.txtGumsaNameRe);
            this.xPanel3.Controls.Add(this.xLabel41);
            this.xPanel3.Controls.Add(this.xLabel40);
            this.xPanel3.Controls.Add(this.xLabel21);
            this.xPanel3.Controls.Add(this.cboBarcode);
            this.xPanel3.Controls.Add(this.xLabel22);
            this.xPanel3.Controls.Add(this.txtDefaultResult);
            this.xPanel3.Controls.Add(this.xLabel19);
            this.xPanel3.Controls.Add(this.txtCommentJuCode);
            this.xPanel3.Controls.Add(this.txtJundalGubunName);
            this.xPanel3.Controls.Add(this.xLabel18);
            this.xPanel3.Controls.Add(this.xLabel17);
            this.xPanel3.Controls.Add(this.xLabel16);
            this.xPanel3.Controls.Add(this.label1);
            this.xPanel3.Controls.Add(this.cboGroupGubun);
            this.xPanel3.Controls.Add(this.xLabel15);
            this.xPanel3.Controls.Add(this.txtJangbiOutCode3);
            this.xPanel3.Controls.Add(this.fbxJangbiCode3);
            this.xPanel3.Controls.Add(this.xLabel14);
            this.xPanel3.Controls.Add(this.txtJangbiOutCode2);
            this.xPanel3.Controls.Add(this.fbxJangbiCode2);
            this.xPanel3.Controls.Add(this.xLabel13);
            this.xPanel3.Controls.Add(this.txtJangbiOutCode);
            this.xPanel3.Controls.Add(this.fbxJangbiCode);
            this.xPanel3.Controls.Add(this.xLabel11);
            this.xPanel3.Controls.Add(this.fbxSutakCode);
            this.xPanel3.Controls.Add(this.xLabel12);
            this.xPanel3.Controls.Add(this.fbxUitakCode);
            this.xPanel3.Controls.Add(this.xLabel9);
            this.xPanel3.Controls.Add(this.fbxTubeCode);
            this.xPanel3.Controls.Add(this.xLabel10);
            this.xPanel3.Controls.Add(this.fbxDanui);
            this.xPanel3.Controls.Add(this.xLabel7);
            this.xPanel3.Controls.Add(this.fbxJundalGubun);
            this.xPanel3.Controls.Add(this.xLabel8);
            this.xPanel3.Controls.Add(this.cbxEmergency);
            this.xPanel3.Controls.Add(this.xLabel5);
            this.xPanel3.Controls.Add(this.cbxDefaultYN);
            this.xPanel3.Controls.Add(this.xLabel4);
            this.xPanel3.Controls.Add(this.fbxSpecimenCode);
            this.xPanel3.Controls.Add(this.xLabel3);
            this.xPanel3.Controls.Add(this.xLabel2);
            this.xPanel3.Controls.Add(this.txtTubeName);
            this.xPanel3.Controls.Add(this.fbxHangmogCode);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            this.toolTip.SetToolTip(this.xPanel3, resources.GetString("xPanel3.ToolTip"));
            // 
            // cboInoutGubun
            // 
            this.cboInoutGubun.AccessibleDescription = null;
            this.cboInoutGubun.AccessibleName = null;
            resources.ApplyResources(this.cboInoutGubun, "cboInoutGubun");
            this.cboInoutGubun.BackgroundImage = null;
            this.cboInoutGubun.ExecuteQuery = null;
            this.cboInoutGubun.Name = "cboInoutGubun";
            this.cboInoutGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboInoutGubun.ParamList")));
            this.cboInoutGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.toolTip.SetToolTip(this.cboInoutGubun, resources.GetString("cboInoutGubun.ToolTip"));
            this.cboInoutGubun.SelectedValueChanged += new System.EventHandler(this.cboInoutGubun_SelectedValueChanged);
            // 
            // xLabel39
            // 
            this.xLabel39.AccessibleDescription = null;
            this.xLabel39.AccessibleName = null;
            resources.ApplyResources(this.xLabel39, "xLabel39");
            this.xLabel39.Image = null;
            this.xLabel39.Name = "xLabel39";
            this.toolTip.SetToolTip(this.xLabel39, resources.GetString("xLabel39.ToolTip"));
            // 
            // xPanel4
            // 
            this.xPanel4.AccessibleDescription = null;
            this.xPanel4.AccessibleName = null;
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.BackColor = IHIS.Framework.XColor.DockingGradientStartColor;
            this.xPanel4.BackgroundImage = null;
            this.xPanel4.BorderColor = IHIS.Framework.XColor.DockingGradientEndColor;
            this.xPanel4.Controls.Add(this.xLabel1);
            this.xPanel4.Controls.Add(this.txtHangmog);
            this.xPanel4.Controls.Add(this.dtpJukYongDate);
            this.xPanel4.Controls.Add(this.xLabel6);
            this.xPanel4.Font = null;
            this.xPanel4.Name = "xPanel4";
            this.toolTip.SetToolTip(this.xPanel4, resources.GetString("xPanel4.ToolTip"));
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            this.toolTip.SetToolTip(this.xLabel1, resources.GetString("xLabel1.ToolTip"));
            // 
            // txtHangmog
            // 
            this.txtHangmog.AcceptsTab = true;
            this.txtHangmog.AccessibleDescription = null;
            this.txtHangmog.AccessibleName = null;
            resources.ApplyResources(this.txtHangmog, "txtHangmog");
            this.txtHangmog.BackgroundImage = null;
            this.txtHangmog.EnterKeyToTab = false;
            this.txtHangmog.Name = "txtHangmog";
            this.toolTip.SetToolTip(this.txtHangmog, resources.GetString("txtHangmog.ToolTip"));
            this.txtHangmog.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHangmog_KeyDown);
            // 
            // xLabel6
            // 
            this.xLabel6.AccessibleDescription = null;
            this.xLabel6.AccessibleName = null;
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.Image = null;
            this.xLabel6.Name = "xLabel6";
            this.toolTip.SetToolTip(this.xLabel6, resources.GetString("xLabel6.ToolTip"));
            // 
            // btnGroup
            // 
            this.btnGroup.AccessibleDescription = null;
            this.btnGroup.AccessibleName = null;
            resources.ApplyResources(this.btnGroup, "btnGroup");
            this.btnGroup.BackgroundImage = null;
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.TabStop = false;
            this.toolTip.SetToolTip(this.btnGroup, resources.GetString("btnGroup.ToolTip"));
            // 
            // lbUserGubun
            // 
            this.lbUserGubun.AccessibleDescription = null;
            this.lbUserGubun.AccessibleName = null;
            resources.ApplyResources(this.lbUserGubun, "lbUserGubun");
            this.lbUserGubun.Cursor = System.Windows.Forms.Cursors.Help;
            this.lbUserGubun.Image = null;
            this.lbUserGubun.Name = "lbUserGubun";
            this.toolTip.SetToolTip(this.lbUserGubun, resources.GetString("lbUserGubun.ToolTip"));
            // 
            // xLabel38
            // 
            this.xLabel38.AccessibleDescription = null;
            this.xLabel38.AccessibleName = null;
            resources.ApplyResources(this.xLabel38, "xLabel38");
            this.xLabel38.Image = null;
            this.xLabel38.Name = "xLabel38";
            this.toolTip.SetToolTip(this.xLabel38, resources.GetString("xLabel38.ToolTip"));
            // 
            // xLabel37
            // 
            this.xLabel37.AccessibleDescription = null;
            this.xLabel37.AccessibleName = null;
            resources.ApplyResources(this.xLabel37, "xLabel37");
            this.xLabel37.Image = null;
            this.xLabel37.Name = "xLabel37";
            this.toolTip.SetToolTip(this.xLabel37, resources.GetString("xLabel37.ToolTip"));
            // 
            // xLabel36
            // 
            this.xLabel36.AccessibleDescription = null;
            this.xLabel36.AccessibleName = null;
            resources.ApplyResources(this.xLabel36, "xLabel36");
            this.xLabel36.Image = null;
            this.xLabel36.Name = "xLabel36";
            this.toolTip.SetToolTip(this.xLabel36, resources.GetString("xLabel36.ToolTip"));
            // 
            // xLabel35
            // 
            this.xLabel35.AccessibleDescription = null;
            this.xLabel35.AccessibleName = null;
            resources.ApplyResources(this.xLabel35, "xLabel35");
            this.xLabel35.Image = null;
            this.xLabel35.Name = "xLabel35";
            this.toolTip.SetToolTip(this.xLabel35, resources.GetString("xLabel35.ToolTip"));
            // 
            // xLabel34
            // 
            this.xLabel34.AccessibleDescription = null;
            this.xLabel34.AccessibleName = null;
            resources.ApplyResources(this.xLabel34, "xLabel34");
            this.xLabel34.Image = null;
            this.xLabel34.Name = "xLabel34";
            this.toolTip.SetToolTip(this.xLabel34, resources.GetString("xLabel34.ToolTip"));
            // 
            // xLabel31
            // 
            this.xLabel31.AccessibleDescription = null;
            this.xLabel31.AccessibleName = null;
            resources.ApplyResources(this.xLabel31, "xLabel31");
            this.xLabel31.Image = null;
            this.xLabel31.Name = "xLabel31";
            this.toolTip.SetToolTip(this.xLabel31, resources.GetString("xLabel31.ToolTip"));
            // 
            // xLabel30
            // 
            this.xLabel30.AccessibleDescription = null;
            this.xLabel30.AccessibleName = null;
            resources.ApplyResources(this.xLabel30, "xLabel30");
            this.xLabel30.Image = null;
            this.xLabel30.Name = "xLabel30";
            this.toolTip.SetToolTip(this.xLabel30, resources.GetString("xLabel30.ToolTip"));
            // 
            // xLabel20
            // 
            this.xLabel20.AccessibleDescription = null;
            this.xLabel20.AccessibleName = null;
            resources.ApplyResources(this.xLabel20, "xLabel20");
            this.xLabel20.Image = null;
            this.xLabel20.Name = "xLabel20";
            this.toolTip.SetToolTip(this.xLabel20, resources.GetString("xLabel20.ToolTip"));
            // 
            // xLabel29
            // 
            this.xLabel29.AccessibleDescription = null;
            this.xLabel29.AccessibleName = null;
            resources.ApplyResources(this.xLabel29, "xLabel29");
            this.xLabel29.Image = null;
            this.xLabel29.Name = "xLabel29";
            this.toolTip.SetToolTip(this.xLabel29, resources.GetString("xLabel29.ToolTip"));
            // 
            // xLabel28
            // 
            this.xLabel28.AccessibleDescription = null;
            this.xLabel28.AccessibleName = null;
            resources.ApplyResources(this.xLabel28, "xLabel28");
            this.xLabel28.Image = null;
            this.xLabel28.Name = "xLabel28";
            this.toolTip.SetToolTip(this.xLabel28, resources.GetString("xLabel28.ToolTip"));
            // 
            // xLabel27
            // 
            this.xLabel27.AccessibleDescription = null;
            this.xLabel27.AccessibleName = null;
            resources.ApplyResources(this.xLabel27, "xLabel27");
            this.xLabel27.Image = null;
            this.xLabel27.Name = "xLabel27";
            this.toolTip.SetToolTip(this.xLabel27, resources.GetString("xLabel27.ToolTip"));
            // 
            // xLabel26
            // 
            this.xLabel26.AccessibleDescription = null;
            this.xLabel26.AccessibleName = null;
            resources.ApplyResources(this.xLabel26, "xLabel26");
            this.xLabel26.Image = null;
            this.xLabel26.Name = "xLabel26";
            this.toolTip.SetToolTip(this.xLabel26, resources.GetString("xLabel26.ToolTip"));
            // 
            // xLabel25
            // 
            this.xLabel25.AccessibleDescription = null;
            this.xLabel25.AccessibleName = null;
            resources.ApplyResources(this.xLabel25, "xLabel25");
            this.xLabel25.Image = null;
            this.xLabel25.Name = "xLabel25";
            this.toolTip.SetToolTip(this.xLabel25, resources.GetString("xLabel25.ToolTip"));
            // 
            // xLabel24
            // 
            this.xLabel24.AccessibleDescription = null;
            this.xLabel24.AccessibleName = null;
            resources.ApplyResources(this.xLabel24, "xLabel24");
            this.xLabel24.Image = null;
            this.xLabel24.Name = "xLabel24";
            this.toolTip.SetToolTip(this.xLabel24, resources.GetString("xLabel24.ToolTip"));
            // 
            // xLabel23
            // 
            this.xLabel23.AccessibleDescription = null;
            this.xLabel23.AccessibleName = null;
            resources.ApplyResources(this.xLabel23, "xLabel23");
            this.xLabel23.Image = null;
            this.xLabel23.Name = "xLabel23";
            this.toolTip.SetToolTip(this.xLabel23, resources.GetString("xLabel23.ToolTip"));
            // 
            // xLabel41
            // 
            this.xLabel41.AccessibleDescription = null;
            this.xLabel41.AccessibleName = null;
            resources.ApplyResources(this.xLabel41, "xLabel41");
            this.xLabel41.Image = null;
            this.xLabel41.Name = "xLabel41";
            this.toolTip.SetToolTip(this.xLabel41, resources.GetString("xLabel41.ToolTip"));
            // 
            // xLabel40
            // 
            this.xLabel40.AccessibleDescription = null;
            this.xLabel40.AccessibleName = null;
            resources.ApplyResources(this.xLabel40, "xLabel40");
            this.xLabel40.Image = null;
            this.xLabel40.Name = "xLabel40";
            this.toolTip.SetToolTip(this.xLabel40, resources.GetString("xLabel40.ToolTip"));
            // 
            // xLabel21
            // 
            this.xLabel21.AccessibleDescription = null;
            this.xLabel21.AccessibleName = null;
            resources.ApplyResources(this.xLabel21, "xLabel21");
            this.xLabel21.Image = null;
            this.xLabel21.Name = "xLabel21";
            this.toolTip.SetToolTip(this.xLabel21, resources.GetString("xLabel21.ToolTip"));
            // 
            // xLabel22
            // 
            this.xLabel22.AccessibleDescription = null;
            this.xLabel22.AccessibleName = null;
            resources.ApplyResources(this.xLabel22, "xLabel22");
            this.xLabel22.Image = null;
            this.xLabel22.Name = "xLabel22";
            this.toolTip.SetToolTip(this.xLabel22, resources.GetString("xLabel22.ToolTip"));
            // 
            // xLabel19
            // 
            this.xLabel19.AccessibleDescription = null;
            this.xLabel19.AccessibleName = null;
            resources.ApplyResources(this.xLabel19, "xLabel19");
            this.xLabel19.Image = null;
            this.xLabel19.Name = "xLabel19";
            this.toolTip.SetToolTip(this.xLabel19, resources.GetString("xLabel19.ToolTip"));
            // 
            // xLabel18
            // 
            this.xLabel18.AccessibleDescription = null;
            this.xLabel18.AccessibleName = null;
            resources.ApplyResources(this.xLabel18, "xLabel18");
            this.xLabel18.Image = null;
            this.xLabel18.Name = "xLabel18";
            this.toolTip.SetToolTip(this.xLabel18, resources.GetString("xLabel18.ToolTip"));
            // 
            // xLabel17
            // 
            this.xLabel17.AccessibleDescription = null;
            this.xLabel17.AccessibleName = null;
            resources.ApplyResources(this.xLabel17, "xLabel17");
            this.xLabel17.Image = null;
            this.xLabel17.Name = "xLabel17";
            this.toolTip.SetToolTip(this.xLabel17, resources.GetString("xLabel17.ToolTip"));
            // 
            // xLabel16
            // 
            this.xLabel16.AccessibleDescription = null;
            this.xLabel16.AccessibleName = null;
            resources.ApplyResources(this.xLabel16, "xLabel16");
            this.xLabel16.Image = null;
            this.xLabel16.Name = "xLabel16";
            this.toolTip.SetToolTip(this.xLabel16, resources.GetString("xLabel16.ToolTip"));
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.toolTip.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // xLabel15
            // 
            this.xLabel15.AccessibleDescription = null;
            this.xLabel15.AccessibleName = null;
            resources.ApplyResources(this.xLabel15, "xLabel15");
            this.xLabel15.Image = null;
            this.xLabel15.Name = "xLabel15";
            this.toolTip.SetToolTip(this.xLabel15, resources.GetString("xLabel15.ToolTip"));
            // 
            // xLabel14
            // 
            this.xLabel14.AccessibleDescription = null;
            this.xLabel14.AccessibleName = null;
            resources.ApplyResources(this.xLabel14, "xLabel14");
            this.xLabel14.Image = null;
            this.xLabel14.Name = "xLabel14";
            this.toolTip.SetToolTip(this.xLabel14, resources.GetString("xLabel14.ToolTip"));
            // 
            // xLabel13
            // 
            this.xLabel13.AccessibleDescription = null;
            this.xLabel13.AccessibleName = null;
            resources.ApplyResources(this.xLabel13, "xLabel13");
            this.xLabel13.Image = null;
            this.xLabel13.Name = "xLabel13";
            this.toolTip.SetToolTip(this.xLabel13, resources.GetString("xLabel13.ToolTip"));
            // 
            // xLabel11
            // 
            this.xLabel11.AccessibleDescription = null;
            this.xLabel11.AccessibleName = null;
            resources.ApplyResources(this.xLabel11, "xLabel11");
            this.xLabel11.Image = null;
            this.xLabel11.Name = "xLabel11";
            this.toolTip.SetToolTip(this.xLabel11, resources.GetString("xLabel11.ToolTip"));
            // 
            // xLabel12
            // 
            this.xLabel12.AccessibleDescription = null;
            this.xLabel12.AccessibleName = null;
            resources.ApplyResources(this.xLabel12, "xLabel12");
            this.xLabel12.Image = null;
            this.xLabel12.Name = "xLabel12";
            this.toolTip.SetToolTip(this.xLabel12, resources.GetString("xLabel12.ToolTip"));
            // 
            // xLabel9
            // 
            this.xLabel9.AccessibleDescription = null;
            this.xLabel9.AccessibleName = null;
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.Image = null;
            this.xLabel9.Name = "xLabel9";
            this.toolTip.SetToolTip(this.xLabel9, resources.GetString("xLabel9.ToolTip"));
            // 
            // xLabel10
            // 
            this.xLabel10.AccessibleDescription = null;
            this.xLabel10.AccessibleName = null;
            resources.ApplyResources(this.xLabel10, "xLabel10");
            this.xLabel10.Image = null;
            this.xLabel10.Name = "xLabel10";
            this.toolTip.SetToolTip(this.xLabel10, resources.GetString("xLabel10.ToolTip"));
            // 
            // xLabel7
            // 
            this.xLabel7.AccessibleDescription = null;
            this.xLabel7.AccessibleName = null;
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.Image = null;
            this.xLabel7.Name = "xLabel7";
            this.toolTip.SetToolTip(this.xLabel7, resources.GetString("xLabel7.ToolTip"));
            // 
            // xLabel8
            // 
            this.xLabel8.AccessibleDescription = null;
            this.xLabel8.AccessibleName = null;
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.Image = null;
            this.xLabel8.Name = "xLabel8";
            this.toolTip.SetToolTip(this.xLabel8, resources.GetString("xLabel8.ToolTip"));
            // 
            // xLabel5
            // 
            this.xLabel5.AccessibleDescription = null;
            this.xLabel5.AccessibleName = null;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.Image = null;
            this.xLabel5.Name = "xLabel5";
            this.toolTip.SetToolTip(this.xLabel5, resources.GetString("xLabel5.ToolTip"));
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.Image = null;
            this.xLabel4.Name = "xLabel4";
            this.toolTip.SetToolTip(this.xLabel4, resources.GetString("xLabel4.ToolTip"));
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            this.toolTip.SetToolTip(this.xLabel3, resources.GetString("xLabel3.ToolTip"));
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            this.toolTip.SetToolTip(this.xLabel2, resources.GetString("xLabel2.ToolTip"));
            // 
            // splitter1
            // 
            this.splitter1.AccessibleDescription = null;
            this.splitter1.AccessibleName = null;
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.BackgroundImage = null;
            this.splitter1.Font = null;
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            this.toolTip.SetToolTip(this.splitter1, resources.GetString("splitter1.ToolTip"));
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            // 
            // CPL0101U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "CPL0101U00";
            this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.CPL0101U00_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).EndInit();
            this.xPanel3.ResumeLayout(false);
            this.xPanel3.PerformLayout();
            this.xPanel4.ResumeLayout(false);
            this.xPanel4.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region checkBox control
        private void rbxMedicalJundal1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.rbxMedicalJundal1.Checked == true)
                this.txtMedicalJundal.SetDataValue("N");
        }

        private void rbxMedicalJundal2_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.rbxMedicalJundal2.Checked == true)
                this.txtMedicalJundal.SetDataValue("Y");
        }

        private void rbxMedicalJundal3_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.rbxMedicalJundal3.Checked == true)
                this.txtMedicalJundal.SetDataValue("I");
        }

        private void txtMedicalJundal_TextChanged(object sender, System.EventArgs e)
        {
            if (this.txtMedicalJundal.GetDataValue() == "I")
                this.rbxMedicalJundal3.Checked = true;
            else if (this.txtMedicalJundal.GetDataValue() == "N")
                this.rbxMedicalJundal1.Checked = true;
            else
                this.rbxMedicalJundal2.Checked = true;
        }
        #endregion

        #region 통합 벨리데이션

        #region MakeValService
        //각각의 컨트롤(파인드박스)에 맞는 벨리데이션 서비스로 셋팅
        private bool MakeValService(XFindBox aCtl)
        {
            bool result = false;

            //findBox validation 
//            BindVarCollection bindVarList = new BindVarCollection();
//            string cmdText = "";
//            object retVal = null;

            CPL0101U00MakeValSerViceResult makeValSerViceResult = null;

            //end sample

            switch (aCtl.Name)
            {
                case "fbxHangmogCode":
                    txtGumsaName.Text = "";

//                    bindVarList.Add("f_code", aCtl.GetDataValue());
//                    cmdText = "select gumsa_name from cpl0101 where hangmog_code = :f_code";
//                    retVal = Service.ExecuteScalar(cmdText,bindVarList);


                    // Connect cloud 
                    makeValSerViceResult = MakeValServiceFromCloud("fbxHangmogCode", "", aCtl.GetDataValue());

                    if (makeValSerViceResult == null || makeValSerViceResult.ExecutionStatus != ExecutionStatus.Success)
                    {
                        this.SetMsg(XMsg.GetMsg("M001"), MsgType.Normal); //존재하지 않는 항목코드입니다.
                        //return;
                    }
                    else
                    {
                        //항목명 SET
                        this.txtGumsaName.SetEditValue(makeValSerViceResult.Name);
                        this.txtGumsaName.AcceptData();
                    }   
                    result = true;
                    break;
                case "fbxSpecimenCode":
                    txtSpecimenName.SetDataValue("");

//                    bindVarList.Add("f_code", aCtl.GetDataValue());
//                    cmdText = "select code_name from cpl0109 where code_type = \'04\' and code = :f_code";
//                    retVal = Service.ExecuteScalar(cmdText, bindVarList);


                    // Connect cloud
                    makeValSerViceResult = MakeValServiceFromCloud("fbxSpecimenCode", "04", aCtl.GetDataValue());

                    if (makeValSerViceResult == null || makeValSerViceResult.ExecutionStatus != ExecutionStatus.Success)
                    {
                        this.SetMsg(XMsg.GetMsg("M002"), MsgType.Normal); //존재하지 않는 코드입니다.
                        aCtl.Focus();
                        return false;
                    }
                    //검체명 SET
                    this.txtSpecimenName.SetEditValue(makeValSerViceResult.Name);
                    this.txtSpecimenName.AcceptData();

                    result = true;
                    break;
                case "fbxJundalGubun":
                    txtJundalName.SetDataValue("");

//                    bindVarList.Add("f_code", aCtl.GetDataValue());
//                    cmdText = "select code_name from cpl0109 where code_type = \'01\' and system_gubun = \'CPL\' and code = :f_code";
//                    retVal = Service.ExecuteScalar(cmdText, bindVarList);


                    // Connect cloud
                    makeValSerViceResult = MakeValServiceFromCloud("fbxJundalGubun", "01", aCtl.GetDataValue());
                    if (makeValSerViceResult == null || makeValSerViceResult.ExecutionStatus != ExecutionStatus.Success)
                    {
                        this.SetMsg(XMsg.GetMsg("M002"), MsgType.Normal); //존재하지 않는 코드입니다.
                        aCtl.Focus();
                        return false;
                    }
                    //전달구분명 SET
                    this.txtJundalName.SetEditValue(makeValSerViceResult.Name);
                    this.txtJundalName.AcceptData();

                    result = true;
                    break;
                case "fbxDanui":
                    txtDanuiName.SetDataValue("");

//                    bindVarList.Add("f_code", aCtl.GetDataValue());
//                    cmdText = "select code_name from cpl0109 where code_type = \'03\' and code = :f_code";
//                    retVal = Service.ExecuteScalar(cmdText, bindVarList);


                    // Connect cloud
                    makeValSerViceResult = MakeValServiceFromCloud("fbxDanui", "03", aCtl.GetDataValue());

                    if (makeValSerViceResult == null || makeValSerViceResult.ExecutionStatus != ExecutionStatus.Success)
                    {
                        this.SetMsg(XMsg.GetMsg("M002"), MsgType.Normal); //존재하지 않는 코드입니다.
                        aCtl.Focus();
                        return false;
                    }
                    //전달구분명 SET
                    this.txtDanuiName.SetEditValue(makeValSerViceResult.Name);
                    this.txtDanuiName.AcceptData();

                    result = true;
                    break;
                case "fbxTubeCode":
                    txtTubeName.SetDataValue("");

//                    bindVarList.Add("f_code", aCtl.GetDataValue());
//                    cmdText = "select code_name from cpl0109 where code_type = \'02\' and code = :f_code";
//                    retVal = Service.ExecuteScalar(cmdText, bindVarList);


                    // Connect cloud
                    makeValSerViceResult = MakeValServiceFromCloud("fbxTubeCode", "02", aCtl.GetDataValue());

                    if (makeValSerViceResult == null || makeValSerViceResult.ExecutionStatus != ExecutionStatus.Success)
                    {
                        this.SetMsg(XMsg.GetMsg("M002"), MsgType.Normal); //존재하지 않는 코드입니다.
                        aCtl.Focus();
                        return false;
                    }
                    //용기명 SET
                    this.txtTubeName.SetEditValue(makeValSerViceResult.Name);
                    this.txtTubeName.AcceptData();

                    result = true;
                    break;
                case "fbxUitakCode":
                    txtUitakName.SetDataValue("");

//                    bindVarList.Add("f_code", aCtl.GetDataValue());
//                    cmdText = "select code_name from cpl0109 where code_type = \'06\' and code = :f_code";
//                    retVal = Service.ExecuteScalar(cmdText, bindVarList);


                    // Connect cloud
                    makeValSerViceResult = MakeValServiceFromCloud("fbxUitakCode", "06", aCtl.GetDataValue());
                    if (makeValSerViceResult == null || makeValSerViceResult.ExecutionStatus != ExecutionStatus.Success)
                    {
                        this.SetMsg(XMsg.GetMsg("M002"), MsgType.Normal); //존재하지 않는 코드입니다.
                        aCtl.Focus();
                        return false;
                    }
                    //위탁업체명 SET
                    this.txtUitakName.SetEditValue(makeValSerViceResult.Name);
                    this.txtUitakName.AcceptData();
                    
                    result = true;
                    break;
                case "fbxSutakCode":
                    txtSutakName.SetDataValue("");

//                    bindVarList.Add("f_code", aCtl.GetDataValue());
//                    cmdText = "select code_name from cpl0109 where code_type = \'06\' and code = :f_code";
//                    retVal = Service.ExecuteScalar(cmdText, bindVarList);


                    // Connect cloud
                    makeValSerViceResult = MakeValServiceFromCloud("fbxSutakCode", "06", aCtl.GetDataValue());
                    if (makeValSerViceResult == null || makeValSerViceResult.ExecutionStatus != ExecutionStatus.Success)
                    {
                        this.SetMsg(XMsg.GetMsg("M002"), MsgType.Normal); //존재하지 않는 코드입니다.
                        aCtl.Focus();
                        return false;
                    }
                    //위탁업체명 SET
                    this.txtSutakName.SetEditValue(makeValSerViceResult.Name);
                    this.txtSutakName.AcceptData();

                    result = true;
                    break;
                case "fbxSlipCode":
                    txtSlipName.SetDataValue("");

//                    bindVarList.Add("f_code", aCtl.GetDataValue());
//                    cmdText = "select slip_name from cpl0001 where slip_code = :f_code";
//                    retVal = Service.ExecuteScalar(cmdText, bindVarList);


                    // Connect cloud
                    makeValSerViceResult = MakeValServiceFromCloud("fbxSlipCode", "", aCtl.GetDataValue());
                    if (makeValSerViceResult == null || makeValSerViceResult.ExecutionStatus != ExecutionStatus.Success)
                    {
                        this.SetMsg(XMsg.GetMsg("M002"), MsgType.Normal); //존재하지 않는 코드입니다.
                        aCtl.Focus();
                        return false;
                    }
                    //슬립명 SET
                    this.txtSlipName.SetEditValue(makeValSerViceResult.Name);
                    this.txtSlipName.AcceptData();

                    result = true;
                    break;
                case "fbxJangbiCode":
                    txtJangbiName.SetDataValue("");

//                    bindVarList.Add("f_code", aCtl.GetDataValue());
//                    cmdText = "select code_name from cpl0109 where code_type = \'07\' and code = :f_code";
//                    retVal = Service.ExecuteScalar(cmdText, bindVarList);


                    // Connect cloud
                    makeValSerViceResult = MakeValServiceFromCloud("fbxJangbiCode", "07", aCtl.GetDataValue());
                    if (makeValSerViceResult == null || makeValSerViceResult.ExecutionStatus != ExecutionStatus.Success)
                    {
                        this.SetMsg(XMsg.GetMsg("M002"), MsgType.Normal); //존재하지 않는 코드입니다.
                        aCtl.Focus();
                        return false;
                    }
                    //장비명 SET
                    this.txtJangbiName.SetEditValue(makeValSerViceResult.Name);
                    this.txtJangbiName.AcceptData();

                    result = true;
                    break;
                case "fbxJangbiCode2":
                    txtJangbiName2.SetDataValue("");

//                    bindVarList.Add("f_code", aCtl.GetDataValue());
//                    cmdText = "select code_name from cpl0109 where code_type = \'07\' and code = :f_code";
//                    retVal = Service.ExecuteScalar(cmdText, bindVarList);


                    // Connect cloud
                    makeValSerViceResult = MakeValServiceFromCloud("fbxJangbiCode2", "07", aCtl.GetDataValue());
                    if (makeValSerViceResult == null || makeValSerViceResult.ExecutionStatus != ExecutionStatus.Success)
                    {
                        this.SetMsg(XMsg.GetMsg("M002"), MsgType.Normal); //존재하지 않는 코드입니다.
                        aCtl.Focus();
                        return false;
                    }
                    //장비명 SET
                    this.txtJangbiName2.SetEditValue(makeValSerViceResult.Name);
                    this.txtJangbiName2.AcceptData();

                    result = true;
                    break;
                case "fbxJangbiCode3":
                    txtJangbiName3.SetDataValue("");

//                    bindVarList.Add("f_code", aCtl.GetDataValue());
//                    cmdText = "select code_name from cpl0109 where code_type = \'07\' and code = :f_code";
//                    retVal = Service.ExecuteScalar(cmdText, bindVarList);


                    // Connect cloud
                    makeValSerViceResult = MakeValServiceFromCloud("fbxJangbiCode3", "07", aCtl.GetDataValue());
                    if (makeValSerViceResult == null || makeValSerViceResult.ExecutionStatus != ExecutionStatus.Success)
                    {
                        this.SetMsg(XMsg.GetMsg("M002"), MsgType.Normal); //존재하지 않는 코드입니다.
                        aCtl.Focus();
                        return false;
                    }
                    //장비명 SET
                    this.txtJangbiName3.SetEditValue(makeValSerViceResult.Name);
                    this.txtJangbiName3.AcceptData();

                    result = true;
                    break;
                default:
                    XMessageBox.Show("NO CONTROL FOUND", "ERROR");
                    result = false;
                    break;
            }
            return result;

        }
        #endregion

        #region 벨리데이션을 타는 컨트롤의 validating 이벤트 처리
        //컨트롤로 포커스가 이동할 때 해당 컨트롤에 적합한 벨리데이션 서비스로 셋팅
        private void fbx_DataValidating(object sender, DataValidatingEventArgs e)
        {
            MakeValService((XFindBox)sender);
        }
        #endregion

        
        #endregion

        #region 통합 파인드워커

        #region MakeFindWorker
        //각각의 컨트롤(파인드박스)에 적합한 파인드 워커로 셋팅
        private bool MakeFindWorker(XFindBox aCtr)
        {
            bool result = false;
            switch (aCtr.Name)
            {
                case "fbxHangmogCode":
                    this.fwkCPL0101.FormText = Resources.FWKCPL0101_FORMTEXT_01;
//                    this.fwkCPL0101.InputSQL = "    SELECT DISTINCT"



//                                             + "           HANGMOG_CODE"
//                                             + "         , GUMSA_NAME"
//                                             + "      FROM CPL0101"
//                                             + "     WHERE HOSP_CODE = '"+ EnvironInfo.HospCode +"' "
//                                             + "       AND ((HANGMOG_CODE LIKE '%'||:f_find1||'%')"
//                                             + "        OR  (GUMSA_NAME   LIKE '%'||:f_find2||'%'))"

//                                             + "     ORDER BY HANGMOG_CODE";
                    this.fwkCPL0101.BindVarList.Clear();
                    this.fwkCPL0101.SetBindVarValue("Ctr_name", "fbxHangmogCode");

                    this.fwkCPL0101.ColInfos[0].HeaderText = Resources.FWKCPL0101_HEADERTEXT0_01;
                    this.fwkCPL0101.ColInfos[1].HeaderText = Resources.FWKCPL0101_HEADERTEXT1_01;
                    result = true;
                    break;
                case "fbxSpecimenCode":
                    this.fwkCPL0101.FormText = Resources.FWKCPL0101_FORMTEXT_02;
//                    this.fwkCPL0101.InputSQL = "    SELECT CODE"


//                                             + "         , CODE_NAME"
//                                             + "      FROM CPL0109"
//                                             + "     WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "

//                                             + "       AND CODE_TYPE  = '04'"
//                                             + "       AND ((CODE      LIKE '%'||:f_find1||'%')"
//                                             + "        OR  (CODE_NAME LIKE '%'||:f_find2||'%'))"

//                                             + "     ORDER BY CODE";

                    this.fwkCPL0101.BindVarList.Clear();
                    this.fwkCPL0101.SetBindVarValue("Ctr_name", "fbxSpecimenCode");
                    this.fwkCPL0101.SetBindVarValue("code_type", "04");

                    this.fwkCPL0101.ColInfos[0].HeaderText = Resources.FWKCPL0101_HEADERTEXT0_02;
                    this.fwkCPL0101.ColInfos[1].HeaderText = Resources.FWKCPL0101_HEADERTEXT1_02;
                    result = true;
                    break;
                case "fbxNewSpecimenCode":
                    this.fwkCPL0101.FormText = Resources.FWKCPL0101_FORMTEXT_02;
//                    this.fwkCPL0101.InputSQL = "    SELECT CODE"


//                                             + "         , CODE_NAME"
//                                             + "      FROM CPL0109"
//                                             + "     WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "

//                                             + "       AND CODE_TYPE  = '04'"
//                                             + "       AND ((CODE      LIKE '%'||:f_find1||'%')"
//                                             + "        OR  (CODE_NAME LIKE '%'||:f_find2||'%'))"

//                                             + "     ORDER BY CODE";

                    this.fwkCPL0101.BindVarList.Clear();
                    this.fwkCPL0101.SetBindVarValue("Ctr_name", "fbxNewSpecimenCode");
                    this.fwkCPL0101.SetBindVarValue("code_type", "04");

                    this.fwkCPL0101.ColInfos[0].HeaderText = Resources.FWKCPL0101_HEADERTEXT0_02;
                    this.fwkCPL0101.ColInfos[1].HeaderText = Resources.FWKCPL0101_HEADERTEXT1_02;
                    result = true;
                    break;
                case "fbxSlipCode":
                    this.fwkCPL0101.FormText = Resources.FWKCPL0101_FORMTEXT_03;
//                    this.fwkCPL0101.InputSQL = "    SELECT SLIP_CODE"


//                                             + "         , SLIP_NAME"
//                                             + "      FROM CPL0001"
//                                             + "     WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "
//                                             + "       AND ((SLIP_CODE      LIKE '%'||:f_find1||'%')"
//                                             + "        OR  (SLIP_NAME      LIKE '%'||:f_find2||'%'))"

//                                             + "     ORDER BY SLIP_CODE";

                    this.fwkCPL0101.BindVarList.Clear();
                    this.fwkCPL0101.SetBindVarValue("Ctr_name", "fbxSlipCode");

                    this.fwkCPL0101.ColInfos[0].HeaderText = Resources.FWKCPL0101_HEADERTEXT0_03;
                    this.fwkCPL0101.ColInfos[1].HeaderText = Resources.FWKCPL0101_HEADERTEXT1_03;
                    result = true;
                    break;
                case "fbxJundalGubun":
                    this.fwkCPL0101.FormText = Resources.FWKCPL0101_FORMTEXT_04;
//                    this.fwkCPL0101.InputSQL = "    SELECT CODE"


//                                             + "         , CODE_NAME"
//                                             + "      FROM CPL0109"
//                                             + "     WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "


//                                             + "       AND CODE_TYPE    = '01'"
//                                             + "       AND SYSTEM_GUBUN = 'CPL'"
//                                             + "       AND ((CODE       LIKE '%'||:f_find1||'%')"
//                                             + "        OR  (CODE_NAME  LIKE '%'||:f_find2||'%'))"

//                                             + "     ORDER BY CODE";

                    this.fwkCPL0101.BindVarList.Clear();
                    this.fwkCPL0101.SetBindVarValue("Ctr_name", "fbxJundalGubun");
                    this.fwkCPL0101.SetBindVarValue("code_type", "01");
                    this.fwkCPL0101.SetBindVarValue("system_gubun", "CPL");

                    this.fwkCPL0101.ColInfos[0].HeaderText = Resources.FWKCPL0101_HEADERTEXT0_04;
                    this.fwkCPL0101.ColInfos[1].HeaderText = Resources.FWKCPL0101_HEADERTEXT1_04;
                    result = true;
                    break;
                case "fbxDanui":
                    this.fwkCPL0101.FormText = Resources.FWKCPL0101_FORMTEXT_05;
//                    this.fwkCPL0101.InputSQL = "    SELECT CODE"


//                                             + "         , CODE_NAME"
//                                             + "      FROM CPL0109"
//                                             + "     WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "


//                                             + "       AND CODE_TYPE    = '03'"
//                                             + "       AND SYSTEM_GUBUN = 'CPL'"
//                                             + "       AND ((CODE       LIKE '%'||:f_find1||'%')"
//                                             + "        OR  (CODE_NAME  LIKE '%'||:f_find2||'%'))"

//                                             + "     ORDER BY CODE";

                    this.fwkCPL0101.BindVarList.Clear();
                    this.fwkCPL0101.SetBindVarValue("Ctr_name", "fbxDanui");
                    this.fwkCPL0101.SetBindVarValue("code_type", "03");
                    this.fwkCPL0101.SetBindVarValue("system_gubun", "CPL");

                    this.fwkCPL0101.ColInfos[0].HeaderText = Resources.FWKCPL0101_HEADERTEXT0_05;
                    this.fwkCPL0101.ColInfos[1].HeaderText = Resources.FWKCPL0101_HEADERTEXT1_05;
                    result = true;
                    break;
                case "fbxUitakCode":
                    this.fwkCPL0101.FormText = Resources.FWKCPL0101_FORMTEXT_06;
//                    this.fwkCPL0101.InputSQL = "    SELECT CODE"


//                                             + "         , CODE_NAME"
//                                             + "      FROM CPL0109"
//                                             + "     WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "


//                                             + "       AND CODE_TYPE    = '06'"
//                                             + "       AND SYSTEM_GUBUN = 'CPL'"
//                                             + "       AND ((CODE       LIKE '%'||:f_find1||'%')"
//                                             + "        OR  (CODE_NAME  LIKE '%'||:f_find2||'%'))"

//                                             + "     ORDER BY CODE";

                    this.fwkCPL0101.BindVarList.Clear();
                    this.fwkCPL0101.SetBindVarValue("Ctr_name", "fbxUitakCode");
                    this.fwkCPL0101.SetBindVarValue("code_type", "06");
                    this.fwkCPL0101.SetBindVarValue("system_gubun", "CPL");

                    this.fwkCPL0101.ColInfos[0].HeaderText = Resources.FWKCPL0101_HEADERTEXT0_06;
                    this.fwkCPL0101.ColInfos[1].HeaderText = Resources.FWKCPL0101_HEADERTEXT1_06;
                    result = true;
                    break;
                case "fbxSutakCode":
                    this.fwkCPL0101.FormText = Resources.FWKCPL0101_FORMTEXT_07;
//                    this.fwkCPL0101.InputSQL = "    SELECT CODE"


//                                             + "         , CODE_NAME"
//                                             + "      FROM CPL0109"
//                                             + "     WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "


//                                             + "       AND CODE_TYPE    = '06'"
//                                             + "       AND SYSTEM_GUBUN = 'CPL'"
//                                             + "       AND ((CODE       LIKE '%'||:f_find1||'%')"
//                                             + "        OR  (CODE_NAME  LIKE '%'||:f_find2||'%'))"

//                                             + "     ORDER BY CODE";

                    this.fwkCPL0101.BindVarList.Clear();
                    this.fwkCPL0101.SetBindVarValue("Ctr_name", "fbxSutakCode");
                    this.fwkCPL0101.SetBindVarValue("code_type", "06");
                    this.fwkCPL0101.SetBindVarValue("system_gubun", "CPL");

                    this.fwkCPL0101.ColInfos[0].HeaderText = Resources.FWKCPL0101_HEADERTEXT0_07;
                    this.fwkCPL0101.ColInfos[1].HeaderText = Resources.FWKCPL0101_HEADERTEXT1_07;
                    result = true;
                    break;
                case "fbxJangbiCode":
                    this.fwkCPL0101.FormText = Resources.FWKCPL0101_FORMTEXT_08;
//                    this.fwkCPL0101.InputSQL = "    SELECT CODE"


//                                             + "         , CODE_NAME"
//                                             + "      FROM CPL0109"
//                                             + "     WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "


//                                             + "       AND CODE_TYPE    = '07'"
//                                             + "       AND SYSTEM_GUBUN = 'CPL'"
//                                             + "       AND ((CODE       LIKE '%'||:f_find1||'%')"
//                                             + "        OR  (CODE_NAME  LIKE '%'||:f_find2||'%'))"

//                                             + "     ORDER BY CODE";

                    this.fwkCPL0101.BindVarList.Clear();
                    this.fwkCPL0101.SetBindVarValue("Ctr_name", "fbxJangbiCode");
                    this.fwkCPL0101.SetBindVarValue("code_type", "07");
                    this.fwkCPL0101.SetBindVarValue("system_gubun", "CPL");

                    this.fwkCPL0101.ColInfos[0].HeaderText = Resources.FWKCPL0101_HEADERTEXT0_08;
                    this.fwkCPL0101.ColInfos[1].HeaderText = Resources.FWKCPL0101_HEADERTEXT1_08;
                    result = true;
                    break;
                case "fbxJangbiCode2":
                    this.fwkCPL0101.FormText = Resources.FWKCPL0101_FORMTEXT_08;
//                    this.fwkCPL0101.InputSQL = "    SELECT CODE"


//                                             + "         , CODE_NAME"
//                                             + "      FROM CPL0109"
//                                             + "     WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "


//                                             + "       AND CODE_TYPE    = '07'"
//                                             + "       AND SYSTEM_GUBUN = 'CPL'"
//                                             + "       AND ((CODE       LIKE '%'||:f_find1||'%')"
//                                             + "        OR  (CODE_NAME  LIKE '%'||:f_find2||'%'))"

//                                             + "     ORDER BY CODE";

                    this.fwkCPL0101.BindVarList.Clear();
                    this.fwkCPL0101.SetBindVarValue("Ctr_name", "fbxJangbiCode2");
                    this.fwkCPL0101.SetBindVarValue("code_type", "07");
                    this.fwkCPL0101.SetBindVarValue("system_gubun", "CPL");

                    this.fwkCPL0101.ColInfos[0].HeaderText = Resources.FWKCPL0101_HEADERTEXT0_08;
                    this.fwkCPL0101.ColInfos[1].HeaderText = Resources.FWKCPL0101_HEADERTEXT1_08;
                    result = true;
                    break;
                case "fbxJangbiCode3":
                    this.fwkCPL0101.FormText = Resources.FWKCPL0101_FORMTEXT_08;
//                    this.fwkCPL0101.InputSQL = "    SELECT CODE"


//                                             + "         , CODE_NAME"
//                                             + "      FROM CPL0109"
//                                             + "     WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "


//                                             + "       AND CODE_TYPE    = '07'"
//                                             + "       AND SYSTEM_GUBUN = 'CPL'"
//                                             + "       AND ((CODE       LIKE '%'||:f_find1||'%')"
//                                             + "        OR  (CODE_NAME  LIKE '%'||:f_find2||'%'))"

//                                             + "     ORDER BY CODE";

                    this.fwkCPL0101.BindVarList.Clear();
                    this.fwkCPL0101.SetBindVarValue("Ctr_name", "fbxJangbiCode3");
                    this.fwkCPL0101.SetBindVarValue("code_type", "07");
                    this.fwkCPL0101.SetBindVarValue("system_gubun", "CPL");

                    this.fwkCPL0101.ColInfos[0].HeaderText = Resources.FWKCPL0101_HEADERTEXT0_08;
                    this.fwkCPL0101.ColInfos[1].HeaderText = Resources.FWKCPL0101_HEADERTEXT1_08;
                    result = true;
                    break;
                case "fbxTubeCode":
                    this.fwkCPL0101.FormText = Resources.FWKCPL0101_FORMTEXT_09;
//                    this.fwkCPL0101.InputSQL = "    SELECT CODE"


//                                             + "         , CODE_NAME"
//                                             + "      FROM CPL0109"
//                                             + "     WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "


//                                             + "       AND CODE_TYPE    = '02'"
//                                             + "       AND SYSTEM_GUBUN = 'CPL'"
//                                             + "       AND ((CODE       LIKE '%'||:f_find1||'%')"
//                                             + "        OR  (CODE_NAME  LIKE '%'||:f_find2||'%'))"

//                                             + "     ORDER BY CODE";

                    this.fwkCPL0101.BindVarList.Clear();
                    this.fwkCPL0101.SetBindVarValue("Ctr_name", "fbxTubeCode");
                    this.fwkCPL0101.SetBindVarValue("code_type", "02");
                    this.fwkCPL0101.SetBindVarValue("system_gubun", "CPL");

                    this.fwkCPL0101.ColInfos[0].HeaderText = Resources.FWKCPL0101_HEADERTEXT0_09;
                    this.fwkCPL0101.ColInfos[1].HeaderText = Resources.FWKCPL0101_HEADERTEXT1_09;
                    result = true;
                    break;
                default:
                    XMessageBox.Show("NO CONTROL FOUND", "ERROR");
                    result = false;
                    break;
            }   
            return result;
        }
        #endregion

        #region 파인드 컨트롤 클릭이벤트들
        // 각각의 파인드 박스 컨트롤의 버튼이 클릭될때 그 컨트롤에 맞게 워커를 셋팅해 주어야 함
        private void fbx_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
                this.MakeFindWorker((XFindBox)sender);
        }
        #endregion

        private int mCurRow;

        #endregion

        private int mkimFlag = 0;

        #region 버튼리스트 수행전
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    this.mCurRow = -1;
                    this.mkimFlag = -1;
                    this.CurrMQLayout = this.grdMaster;
                    break;
                case FunctionType.Update:
                    this.CurrMSLayout = this.grdMaster;
                    this.mCurRow = this.grdMaster.CurrentRowNumber;
                    if (grdMaster.RowCount > 0)
                    {
                        if (this.dtpJukYongDate.GetDataValue().Length == 0)
                        {
                            string msg = Resources.MSG001_MSG;
                            XMessageBox.Show(msg, Resources.MSG001_CAP, MessageBoxButtons.OK);
                            this.dtpJukYongDate.Focus();
                            e.IsBaseCall = false;
                            e.IsSuccess = false;
                        }
                        else if (this.fbxHangmogCode.GetDataValue().Length == 0)
                        {
                            string msg = Resources.MSG002_MSG;
                            XMessageBox.Show(msg, Resources.MSG001_CAP, MessageBoxButtons.OK);
                            this.fbxHangmogCode.Focus();
                            e.IsBaseCall = false;
                            e.IsSuccess = false;
                        }
                        else if (this.fbxSpecimenCode.GetDataValue().Length == 0)
                        {
                            string msg = Resources.MSG003_MSG;
                            XMessageBox.Show(msg, Resources.MSG001_CAP, MessageBoxButtons.OK);
                            this.fbxSpecimenCode.Focus();
                            e.IsBaseCall = false;
                            e.IsSuccess = false;
                        }
                    }

                    // Save layout
                    UpdateResult updateResult = GrdMasterSaveLayout();
                    if (updateResult == null || updateResult.ExecutionStatus != ExecutionStatus.Success ||
                        updateResult.Result == false)
                    {
                        string msg = Resources.MSG007_MSG;
                        XMessageBox.Show(msg, Resources.MSG001_CAP, MessageBoxButtons.OK);
                        this.fbxSpecimenCode.Focus();
                        e.IsBaseCall = false;
                        e.IsSuccess = false;
                    }
                    else
                    {
                        string msg = Resources.MSG006_MSG;
                        XMessageBox.Show(msg, Resources.MSG001_CAP, MessageBoxButtons.OK);
                        e.IsBaseCall = true;
                        e.IsSuccess = true;
                    }
                    
                    break;
                case FunctionType.Insert:
                    if (this.CurrMSLayout == null)
                        this.CurrMSLayout = this.grdMaster;
                    if (this.grdMaster.RowCount == 0)
                    {
                        e.IsBaseCall = false;
                        this.grdMaster.InsertRow();
                    }
                    else
                    {
                        DataRowState rowState = this.grdMaster.LayoutTable.Rows[this.grdMaster.CurrentRowNumber].RowState;
                        // 입력 버튼이 클릭 되었을 때만 체크
                        if (rowState == DataRowState.Added)
                        {
                            string msg = Resources.MSG004_MSG;
                            XMessageBox.Show(msg, Resources.MSG001_CAP, MessageBoxButtons.OK);
                            this.fbxHangmogCode.Focus();
                            e.IsBaseCall = false;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 버튼리스트 수행후
        private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    this.mAddFlag = -1;
                    this.mkimFlag = -1;
                    break;
                case FunctionType.Update:
                    if (e.IsSuccess == true)
                    {
                        //this.DataServiceCall(this.dsvMasterQry);
                        this.mkimFlag = -1;
                        this.mAddFlag = -1;
                    }
                    break;
                case FunctionType.Insert:
                    this.dtpJukYongDate.SetEditValue("2011/01/01");
                    this.dtpJukYongDate.AcceptData();
                    this.fbxHangmogCode.Focus();
                    break;
                default:
                    break;
            }
        }
        #endregion

        private int mAddFlag = -1;

        #region 그리드 로우포커스 체인지
        private void grdMaster_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            if (this.mAddFlag == -1)
            {
                DataRowState rowState = this.grdMaster.LayoutTable.Rows[this.grdMaster.CurrentRowNumber].RowState;
                // 입력 버튼이 클릭 되었을 때만 체크
                if (rowState == DataRowState.Added)
                {
                    this.fbxHangmogCode.ReadOnly = false;
                    //this.fbxSpecimenCode.Enabled = true;
                    //this.cbxEmergency.Enabled = true;
                    this.mAddFlag = e.CurrentRow;
                    this.fbxHangmogCode.Focus();
                }
                else
                {
                    this.fbxHangmogCode.ReadOnly = true;
                    //this.fbxSpecimenCode.Enabled = false;
                    //this.cbxEmergency.Enabled = false;
                    this.mAddFlag = -1;

                    this.txtHangmog.Focus();
                }
            }
            else
            {
                if (this.mkimFlag != -1)
                {
                    string msg = (Resources.MSG004_MSG);
                    XMessageBox.Show(msg, Resources.MSG001_CAP, MessageBoxButtons.OK);
                    this.mAddFlag = -1;
                    this.grdMaster.SetFocusToItem(e.PreviousRow, "hangmog_code");
                }
                else
                {
                    this.fbxHangmogCode.ReadOnly = true;
                    //this.fbxSpecimenCode.Enabled = false;
                    //this.cbxEmergency.Enabled = false;
                }

                this.txtHangmog.Focus();
            }
        }
        #endregion

        private void txtGumsaName_TextChanged(object sender, System.EventArgs e)
        {
            this.grdMaster.SetItemValue(this.grdMaster.CurrentRowNumber, "gumsa_name", this.txtGumsaName.GetDataValue());
        }

        private void grdMaster_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            string group_gubun = this.grdMaster.GetItemString(e.RowNumber, "group_gubun");
            if (group_gubun == "01")
                e.BackColor = XColor.XProgressBarGradientStartColor.Color;
            else if (group_gubun == "03")
                e.BackColor = XColor.XGroupBoxForeColor.Color;
        }

        #region 항목 카피(무조건 저장됨)
        private void btnHangmogCopy_Click(object sender, System.EventArgs e)
        {
            if (grdMaster.RowCount == 0) return;

            if (TypeCheck.IsNull(fbxNewSpecimenCode.GetDataValue()))
            {
                string msg = Resources.MSG005_MSG;
                XMessageBox.Show(msg, Resources.MSG001_CAP, MessageBoxButtons.OK);
                fbxNewSpecimenCode.Focus();
                return;
            }

//            BindVarCollection bindVarList = new BindVarCollection();
//            bindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
//            bindVarList.Add("f_hangmog_code", fbxHangmogCode.GetDataValue());
//            bindVarList.Add("f_specimen_code", fbxSpecimenCode.GetDataValue());
//            bindVarList.Add("f_emergency", cbxEmergency.GetDataValue());
//            string cmdText = @"SELECT 'Y'   
//                                 FROM DUAL
//                                WHERE EXISTS ( SELECT 'X'
//                                                 FROM CPL0101
//                                                WHERE HOSP_CODE     = :f_hosp_code
//                                                  AND HANGMOG_CODE  = :f_hangmog_code
//                                                  AND SPECIMEN_CODE = :f_specimen_code
//                                                  AND EMERGENCY     = :f_emergency )";
//            object retVal = Service.ExecuteScalar(cmdText,bindVarList);

            // Connect to cloud
            CPL0101U00CheckHangMogCopyArgs checkHangMogCopyArgs = new CPL0101U00CheckHangMogCopyArgs();
            checkHangMogCopyArgs.HangmogCode = fbxHangmogCode.GetDataValue();
            checkHangMogCopyArgs.SpecimenCode = fbxSpecimenCode.GetDataValue();
            checkHangMogCopyArgs.NewEmergency = cbxEmergency.GetDataValue();
            CPL0101U00CheckHangMogCopyResult checkHangMogCopyResult =
                CloudService.Instance.Submit<CPL0101U00CheckHangMogCopyResult, CPL0101U00CheckHangMogCopyArgs>(checkHangMogCopyArgs);
            if (checkHangMogCopyResult != null || checkHangMogCopyResult.ExecutionStatus != ExecutionStatus.Success || checkHangMogCopyResult.Result == false)
            {
                XMessageBox.Show(XMsg.GetMsg("M003"), XMsg.GetField("F001"), MessageBoxButtons.OK); //입력하신 항목은 현재 존재합니다.확인해주세요
                return;
            }
           
            string newSpecimencode = fbxNewSpecimenCode.GetDataValue();
            string newEmergency = "N";
            if (cbxNewEmergency.Checked)
                newEmergency = "Y";

            //            bindVarList.Clear();
//            bindVarList.Add("f_hangmog_code", fbxHangmogCode.GetDataValue());
//            bindVarList.Add("f_specimen_code", fbxSpecimenCode.GetDataValue());
//            bindVarList.Add("f_emergency", cbxEmergency.GetDataValue());
//            bindVarList.Add("f_new_specimen_code", newSpecimencode);
//            bindVarList.Add("f_new_emergency", newEmergency);
//            cmdText = @"BEGIN
//    	                  PR_CPL_COPY_CPL0101(:f_hangmog_code





//                                            , :f_specimen_code
//                                            , :f_emergency
//                                            , :f_new_specimen_code
//                                            , :f_new_emergency);
//                        END;";
//            bool retBoolVal = Service.ExecuteNonQuery(cmdText, bindVarList);

            // Connect to cloud service
            CPL0101U00PrCplCopyCPL0101Args args = new CPL0101U00PrCplCopyCPL0101Args();
            args.HangmogCode = fbxHangmogCode.GetDataValue();
            args.SpecimenCode = fbxSpecimenCode.GetDataValue();
            args.Emergency = cbxEmergency.GetDataValue();
            args.NewEmergency = newEmergency;
            args.NewSpecimenCode = newSpecimencode;
            CPL0101U00CheckHangMogCopyResult copyResult =
                CloudService.Instance.Submit<CPL0101U00CheckHangMogCopyResult, CPL0101U00PrCplCopyCPL0101Args>(args);

            if (copyResult != null || copyResult.ExecutionStatus != ExecutionStatus.Success || copyResult.Result == false)
            {
                XMessageBox.Show("Execute PR_CPL_COPY_CPL0101 is fail");
            }
        }
        #endregion

        #region 항목 카피 기능 추가(카피만 떠 둠.. 저장까지는 안됨)
        private void btnHangCopy_Click(object sender, System.EventArgs e)
        {
            int targetRow = grdMaster.CurrentRowNumber;

            if (targetRow < 0) return;

            int currRowIndex = grdMaster.InsertRow(targetRow);
            object targetValue;

            foreach (XEditGridCell cell in grdMaster.CellInfos)
            {
                //if(cell.CellName == "specimen_code") continue;

                targetValue = grdMaster.GetItemValue(targetRow, cell.CellName);
                grdMaster.SetItemValue(currRowIndex, cell.CellName, targetValue);
            }
            grdMaster.SetFocusToItem(targetRow, "hangmog_code");
            grdMaster.SetFocusToItem(currRowIndex, "hangmog_code");

            fbxSpecimenCode.Enabled = true;
            fbxHangmogCode.ReadOnly = false;
            cbxEmergency.Enabled = true;
            fbxSpecimenCode.Focus();
        }
        #endregion

        #region 스크린 오픈 ( 툴팁 셋팅 )
        private void CPL0101U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
            this.toolTip.SetToolTip(this.btnHangCopy, Resources.BTN_HANG_COPY_TOOLTIP);
            this.toolTip.SetToolTip(this.btnHangmogCopy, Resources.BTN_HANGMOG_COPY_TOOLTIP);
            this.toolTip.SetToolTip(this.btnExcel, Resources.BTN_EXCEL_TOOLTIP);
            this.toolTip.SetToolTip(this.lbUserGubun, Resources.BTN_USER_GUBUN_TOOLTIP);

            this.cboInoutGubun.SetEditValue("%");
        }
        #endregion

        private void cboInoutGubun_SelectedValueChanged(object sender, EventArgs e)
        {
            this.grdMaster.QueryLayout(false);
        }

        #region 해당 데이터 엑셀 출력
        private void btnExcel_Click(object sender, System.EventArgs e)
        {
            this.grdMaster.QueryLayout(false);
            this.grdMaster.Export(true, false);
        }
        #endregion

        #region 조회시 그리드의 바인드 변수 셋팅
        private void grdMaster_QueryStarting(object sender, CancelEventArgs e)
        {
            grdMaster.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //grdMaster.SetBindVarValue("f_hangmog_code", fbxHangmogCode.GetDataValue());
            //grdMaster.SetBindVarValue("f_specimen_code", fbxSpecimenCode.GetDataValue());
            //grdMaster.SetBindVarValue("f_jangbi_code", fbxJangbiCode.GetDataValue());
            //grdMaster.SetBindVarValue("f_jundal_gubun", fbxJundalGubun.GetDataValue());
            //grdMaster.SetBindVarValue("f_danui", fbxDanui.GetDataValue());
            //grdMaster.SetBindVarValue("f_tube_code", fbxTubeCode.GetDataValue());
            //grdMaster.SetBindVarValue("f_slip_code", fbxSlipCode.GetDataValue());
            //grdMaster.SetBindVarValue("f_gumsa_name", txtGumsaName.GetDataValue());
            //grdMaster.SetBindVarValue("f_jangbi_out_code", txtJangbiOutCode.GetDataValue());
            //grdMaster.SetBindVarValue("f_group_gubun", cboGroupGubun.GetDataValue());
            //grdMaster.SetBindVarValue("f_uitak_code", fbxUitakCode.GetDataValue());
            grdMaster.SetBindVarValue("f_txtHangmog", this.txtHangmog.Text);
            grdMaster.SetBindVarValue("f_io_gubun", this.cboInoutGubun.GetDataValue());

        }
        #endregion

        #region XSavePerformer
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private CPL0101U00 parent = null;
            public XSavePerformer(CPL0101U00 parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                //Grid에서 넘어온 Bind 변수에 f_user_id SET
                item.BindVarList.Add("f_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);


                switch (item.RowState)
                {
                    case DataRowState.Added:
                        cmdText = @"INSERT INTO CPL0101 (
                                                         SYS_DATE             ,SYS_ID               ,UPD_DATE
                                                        ,JUKYONG_DATE         ,HANGMOG_CODE         ,SPECIMEN_CODE   
                                                        ,EMERGENCY            ,DEFAULT_YN           ,JUNDAL_GUBUN    
                                                        ,DANUI                ,TUBE_CODE            ,UITAK_CODE      
                                                        ,SUTAK_CODE           ,SLIP_CODE            ,JANGBI_CODE     
                                                        ,JANGBI_OUT_CODE      ,JANGBI_CODE2         ,JANGBI_OUT_CODE2
                                                        ,JANGBI_CODE3         ,JANGBI_OUT_CODE3     ,GROUP_GUBUN     
                                                        ,GUMSA_NAME_RE        ,BARCODE              ,GUMSA_NAME      
                                                        ,DEFAULT_RESULT       ,MEDICAL_JUNDAL       ,COMMENT_JU_CODE 
                                                        ,SERIAL               ,CHUBANG_YN           ,RESULT_YN       
                                                        ,RESULT_FORM          ,TONG_GUBUN           ,SPECIMEN_AMT    
                                                        ,OLD_SLIP_CODE        ,DETAIL_INFO          ,DISPLAY_YN
                                                        ,JUNDAL_GUBUN_NAME    ,SPCIAL_NAME          ,SYSTEM_GUBUN   
                                                        ,TONG_SERIAL          ,POINT                ,POINT2
                                                        ,POINT3               ,OUT_TUBE             ,OUT_TUBE2
                                                        ,HANGMOG_MARK_NAME    ,MIDDLE_RESULT        ,USER_GUBUN
                                                        ,HOSP_CODE
                                               ) VALUES (
                                                         SYSDATE              ,:f_user_id           ,SYSDATE
                                                        ,:f_jukyong_date      ,:f_hangmog_code      ,:f_specimen_code   
                                                        ,:f_emergency         ,:f_default_yn        ,:f_jundal_gubun    
                                                        ,:f_danui             ,:f_tube_code         ,:f_uitak_code      
                                                        ,:f_sutak_code        ,:f_slip_code         ,:f_jangbi_code     
                                                        ,:f_jangbi_out_code   ,:f_jangbi_code2      ,:f_jangbi_out_code2
                                                        ,:f_jangbi_code3      ,:f_jangbi_out_code3  ,:f_group_gubun     
                                                        ,:f_gumsa_name_re     ,:f_barcode           ,:f_gumsa_name      
                                                        ,:f_default_result    ,:f_medical_jundal    ,:f_comment_ju_code 
                                                        ,:f_serial            ,:f_chubang_yn        ,:f_result_yn       
                                                        ,:f_result_form       ,:f_tong_gubun        ,:f_specimen_amt    
                                                        ,:f_old_slip_code     ,:f_detail_info       ,:f_display_yn
                                                        ,:f_jundal_gubun_name ,:f_spcial_name       ,'CPL'   
                                                        ,:f_tong_serial       ,:f_point             ,:f_point2
                                                        ,:f_point3            ,:f_out_tube          ,:f_out_tube2
                                                        ,:f_hangmog_mark_name ,:f_middle_result     ,:f_user_gubun
                                                        ,:f_hosp_code
                                                        )";  
                        break;
                    case DataRowState.Modified:
                        cmdText = @"UPDATE CPL0101
                                       SET UPD_ID           = :f_user_id
                                         , UPD_DATE         = SYSDATE
                                         , JUKYONG_DATE     = :f_jukyong_date
                                         , SPECIMEN_CODE    = :f_specimen_code
                                         , EMERGENCY        = :f_emergency
                                         , DEFAULT_YN       = :f_default_yn
                                         , JUNDAL_GUBUN     = :f_jundal_gubun                        
                                         , DANUI            = :f_danui
                                         , TUBE_CODE        = :f_tube_code
                                         , UITAK_CODE       = :f_uitak_code                            
                                         , SUTAK_CODE       = :f_sutak_code                              
                                         , SLIP_CODE        = :f_slip_code                              
                                         , JANGBI_CODE      = :f_jangbi_code     
                                         , JANGBI_OUT_CODE  = :f_jangbi_out_code 
                                         , JANGBI_CODE2     = :f_jangbi_code2    
                                         , JANGBI_OUT_CODE2 = :f_jangbi_out_code2
                                         , JANGBI_CODE3     = :f_jangbi_code3    
                                         , JANGBI_OUT_CODE3 = :f_jangbi_out_code3
                                         , GROUP_GUBUN      = :f_group_gubun     
                                         , GUMSA_NAME_RE    = :f_gumsa_name_re   
                                         , BARCODE          = :f_barcode
                                         , GUMSA_NAME       = :f_gumsa_name      
                                         , DEFAULT_RESULT   = :f_default_result  
                                         , MEDICAL_JUNDAL   = :f_medical_jundal
                                         , COMMENT_JU_CODE  = :f_comment_ju_code 
                                         , SERIAL           = :f_serial
                                         , CHUBANG_YN       = :f_chubang_yn
                                         , RESULT_YN        = :f_result_yn
                                         , RESULT_FORM      = :f_result_form
                                         , TONG_GUBUN       = :f_tong_gubun
                                         , SPECIMEN_AMT     = :f_specimen_amt
                                         , OLD_SLIP_CODE    = :f_old_slip_code  
                                         , DETAIL_INFO      = :f_detail_info
                                         , DISPLAY_YN       = :f_display_yn 
                                         , JUNDAL_GUBUN_NAME= :f_jundal_gubun_name
                                         , SPCIAL_NAME      = :f_spcial_name
                                         , TONG_SERIAL      = :f_tong_serial
                                         , POINT            = :f_point
                                         , POINT2           = :f_point2
                                         , POINT3           = :f_point3
                                         , OUT_TUBE         = :f_out_tube 
                                         , OUT_TUBE2        = :f_out_tube2
                                         , HANGMOG_MARK_NAME= :f_hangmog_mark_name
                                         , MIDDLE_RESULT    = :f_middle_result
                                         , USER_GUBUN       = :f_user_gubun
                                     WHERE HOSP_CODE        = :f_hosp_code
                                       AND HANGMOG_CODE     = :f_hangmog_code";
                        break;
                    case DataRowState.Deleted:
                        cmdText = @"DELETE CPL0101
                                     WHERE HOSP_CODE        = :f_hosp_code
                                       AND HANGMOG_CODE     = :f_hangmog_code";
                        break;
                }

                if (Service.ExecuteNonQuery(cmdText, item.BindVarList))
                {
                    string msg = Resources.MSG006_MSG;
                    XMessageBox.Show(msg, Resources.MSG001_CAP, MessageBoxButtons.OK);
                    return true;
                }
                else
                {
                    string msg = Resources.MSG007_MSG;
                    XMessageBox.Show(msg, Resources.MSG001_CAP, MessageBoxButtons.OK);
                    return false;
                }

            }
        }
        #endregion

        #region 저장 처리 후 에러메세지 팝업처리
        private void grdMaster_SaveEnd(object sender, SaveEndEventArgs e)
        {
           if ( !e.IsSuccess ) XMessageBox.Show("ERROR CODE : " + Service.ErrCode + "   " + e.ErrMsg);
        }
        #endregion

        private void rbx_CheckedChanged(object sender, EventArgs e)
        {
            if (((XRadioButton)sender).Checked)
            {
                btnList.PerformClick(FunctionType.Reset);
                grdMaster.QueryLayout(false);
                
            }
        }

        private void txtHangmog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnList.PerformClick(FunctionType.Query);
            }

            //if (e.KeyCode == Keys.Tab)
            //{
            //    this.fbxHangmogCode.Focus();
            //}
        }

        private void grdMaster_PreEndInitializing(object sender, EventArgs e)
        {
            this.xEditGridCell54.ExecuteQuery = cboUserGubun_ExecuteQuery;
        }

        #region Connect to cloud service
        /// <summary>
        /// GrdMaster_ExecuteQuery
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private IList<object[]> GrdMaster_ExecuteQuery(BindVarCollection bc)
        {
            IList<object[]> res = new List<object[]>();
            CPL0101U00InitArgs vCPL0101U00InitArgs = new CPL0101U00InitArgs();
            vCPL0101U00InitArgs.TxtHangmog = bc["f_txtHangmog"].VarValue;
            vCPL0101U00InitArgs.IoGubun = bc["f_io_gubun"].VarValue;
            vCPL0101U00InitArgs.PageNumber = bc["f_page_number"].VarValue;
            //vCPL0101U00InitArgs.PageNumber = "";
            vCPL0101U00InitArgs.Offset = "200";
            CPL0101U00InitResult result = CloudService.Instance.Submit<CPL0101U00InitResult, CPL0101U00InitArgs>(vCPL0101U00InitArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<CPL0101U00InitListItemInfo> listItemInfo = result.InitInfo;
                if (listItemInfo != null && listItemInfo.Count > 0)
                {
                    foreach (CPL0101U00InitListItemInfo item in listItemInfo)
                    {
                        object[] objects =
                        {
                            item.JukyongDate,
                            item.HangmogCode,
                            item.SpecimenCode,
                            item.SpecimenName,
                            item.Emergency,
                            item.DefaultYn,
                            item.JundalGubun,
                            item.JundalName,
                            item.Danui,
                            item.DanuiName,
                            item.TubeCode,
                            item.TubeName,
                            item.UitakCode,
                            item.UitakName,
                            item.SutakCode,
                            item.SutakName,
                            item.SlipCode,
                            item.SlipName,
                            item.JangbiCode,
                            item.JangbiName,
                            item.JangbiOutCode,
                            item.JangbiCode2,
                            item.JangbiName2,
                            item.JangbiOutCode2,
                            item.JangbiCode3,
                            item.JangbiName3,
                            item.JangbiOutCode3,
                            item.GroupGubun,
                            item.GumsaNameRe,
                            item.Barcode,
                            item.GumsaName,
                            item.DefaultResult,
                            item.MedicalJundal,
                            item.CommentJuCode,
                            item.Serial,
                            item.ChubangYn,
                            item.ResultYn,
                            item.ResultForm,
                            item.TongGubun,
                            item.SpecimenAmt,
                            item.OldSlipCode,
                            item.DetailInfo,
                            item.DisplayYn,
                            item.JundalGubunName,
                            item.SpcialName,
                            item.TongSerial,
                            item.Point,
                            item.Point2,
                            item.Point3,
                            item.OutTube,
                            item.OutTube2,
                            item.HangmogMarkName,
                            item.MiddleResult,
                            item.UserGubun,
                            // MED-15918
                            item.Jlac10Code1,
                            item.Jlac10Code2
                        };
                        res.Add(objects);
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// cboBarcode_ExecuteQuery
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> cboBarcode_ExecuteQuery(BindVarCollection varCollection)
        {
            IList<object[]> lstObject = new List<object[]>(); 
            ComboBarCodeArgs barCodeArgs = new ComboBarCodeArgs();
            barCodeArgs.CodeType = "11";
            ComboResult comboResult =
                CloudService.Instance.Submit<ComboResult, ComboBarCodeArgs>(barCodeArgs);
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> lstComboListItemInfo = comboResult.ComboItem;
                if (lstComboListItemInfo != null && lstComboListItemInfo.Count > 0)
                {
                    foreach (ComboListItemInfo info in lstComboListItemInfo)
                    {
                        lstObject.Add(new object[]
                        {
                            info.Code,
                            info.CodeName
                        });
                    }
                }
            }
            return lstObject;
        }

        /// <summary>
        /// cboResultForm_ExecuteQuery
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> cboResultForm_ExecuteQuery(BindVarCollection varCollection)
        {
            IList<object[]> lstObject = new List<object[]>();
            ComboResultFormArgs comboResultFormArgs = new ComboResultFormArgs();
            comboResultFormArgs.CodeType = "27";
            //ComboResult comboResult =
            //    CacheService.Instance.Get<ComboResultFormArgs, ComboResult>(
            //        Constants.CacheKeyCbo.CACHE_CPLS_COMBO_RESULT_FORM, comboResultFormArgs, delegate(ComboResult result)
            //        {
            //            return result != null && result.ComboItem != null && result.ComboItem.Count > 0;
            //        });
            ComboResult comboResult = CacheService.Instance.Get<ComboResultFormArgs, ComboResult>(comboResultFormArgs);
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> lstComboListItemInfo = comboResult.ComboItem;
                if (lstComboListItemInfo != null && lstComboListItemInfo.Count > 0)
                {
                    foreach (ComboListItemInfo info in lstComboListItemInfo)
                    {
                        lstObject.Add(new object[]
                        {
                            info.Code,
                            info.CodeName
                        });
                    }
                }
            }
            return lstObject;
        }

        /// <summary>
        /// cboSpcialName_ExecuteQuery
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> cboSpcialName_ExecuteQuery(BindVarCollection varCollection)
        {
            IList<object[]> lstObject = new List<object[]>();
            ComboSpcialNameArgs comboSpcialNameArgs = new ComboSpcialNameArgs();
            comboSpcialNameArgs.CodeType = "22";
            ComboResult comboResult =
                CacheService.Instance.Get<ComboSpcialNameArgs, ComboResult>(comboSpcialNameArgs);
            //ComboResult comboResult =
            //    CacheService.Instance.Get<ComboSpcialNameArgs, ComboResult>(
            //        Constants.CacheKeyCbo.CACHE_CPLS_COMBO_SPCIAL_NAME, comboSpcialNameArgs, delegate(ComboResult result)
            //        {
            //            return result != null && result.ComboItem != null && result.ComboItem.Count > 0;
            //        });
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> lstComboListItemInfo = comboResult.ComboItem;
                if (lstComboListItemInfo != null && lstComboListItemInfo.Count > 0)
                {
                    foreach (ComboListItemInfo info in lstComboListItemInfo)
                    {
                        lstObject.Add(new object[]
                        {
                            info.Code,
                            info.CodeName
                        });
                    }
                }
            }
            return lstObject;
        }

        /// <summary>
        /// cboInoutGubun_ExecuteQuery
        /// </summary>
        /// <param name="bindVarCollection"></param>
        /// <returns></returns>
        private IList<object[]> cboInoutGubun_ExecuteQuery(BindVarCollection bindVarCollection)
        {
            IList<object[]> lstObject = new List<object[]>();
            ComboInOutGubunArgs comboInOutGubunArgs = new ComboInOutGubunArgs();
            comboInOutGubunArgs.CodeType = "IO_GUBUN";
            //ComboResult comboResult =
            //    CacheService.Instance.Get<ComboInOutGubunArgs, ComboResult>(
            //        Constants.CacheKeyCbo.CACHE_CPLS_COMBO_IOGUBUN, comboInOutGubunArgs, delegate(ComboResult result)
            //        {
            //            return result != null && result.ComboItem != null && result.ComboItem.Count > 0;
            //        });
            ComboResult comboResult = CacheService.Instance.Get<ComboInOutGubunArgs, ComboResult>(comboInOutGubunArgs);
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> lstComboListItemInfo = comboResult.ComboItem;
                if (lstComboListItemInfo != null && lstComboListItemInfo.Count > 0)
                {
                    foreach (ComboListItemInfo info in lstComboListItemInfo)
                    {
                        lstObject.Add(new object[]
                        {
                            info.Code,
                            info.CodeName
                        });
                    }
                }
            }
            return lstObject;
        }

        /// <summary>
        /// MakeValServiceFromCloud
        /// </summary>
        /// <param name="aCtlName"></param>
        /// <param name="aCodeType"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        private CPL0101U00MakeValSerViceResult MakeValServiceFromCloud(string aCtlName, string aCodeType, string code)
        {
            CPL0101U00MakeValSerViceArgs vCPL0101U00MakeValSerViceArgs = new CPL0101U00MakeValSerViceArgs();
            vCPL0101U00MakeValSerViceArgs.ACtlName = aCtlName;
            vCPL0101U00MakeValSerViceArgs.CodeType = aCodeType;
            vCPL0101U00MakeValSerViceArgs.Code = code;
            return CloudService.Instance.Submit<CPL0101U00MakeValSerViceResult, CPL0101U00MakeValSerViceArgs>(vCPL0101U00MakeValSerViceArgs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> fwkCPL0101_ExecuteQuery(BindVarCollection varCollection)
        {
            IList<object[]> lstObject = new List<object[]>();
            CPL0101U00MakeFindWorkerArgs args = new CPL0101U00MakeFindWorkerArgs();
            args.ACtrName = varCollection["Ctr_name"].VarValue;
            args.CodeType = varCollection["code_type"].VarValue;
            args.Find1 = varCollection["find1"].VarValue;
            args.Find2 = varCollection["find2"].VarValue;
            args.SystemGubun = varCollection["system_gubun"].VarValue;

            ComboResult comboResult =
            CloudService.Instance.Submit<ComboResult, CPL0101U00MakeFindWorkerArgs>(args);
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> lsComboListItemInfo = comboResult.ComboItem;
                if (lsComboListItemInfo != null && lsComboListItemInfo.Count > 0)
                {
                    foreach (ComboListItemInfo info in lsComboListItemInfo)
                    {
                        lstObject.Add(new object[]
                        {
                            info.Code,
                            info.CodeName
                        });
                    }
                }
            }
            return lstObject;
        }

        /// <summary>
        /// GrdMasterSaveLayout
        /// </summary>
        /// <returns></returns>
        private UpdateResult GrdMasterSaveLayout()
        {
            List<CPL0101U00InitListItemInfo> lstCpl0101U00InitListItemInfo = CreateListGridInfo();
            if (lstCpl0101U00InitListItemInfo == null || lstCpl0101U00InitListItemInfo.Count < 0)
            {
                return null;
            }
            CPL0101U00GridMasterSaveLayoutArgs args = new CPL0101U00GridMasterSaveLayoutArgs();
            args.ItemInfo = lstCpl0101U00InitListItemInfo;
            args.UserId = UserInfo.UserID;

            return CloudService.Instance.Submit<UpdateResult, CPL0101U00GridMasterSaveLayoutArgs>(args);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<CPL0101U00InitListItemInfo> CreateListGridInfo()
        {
            List<CPL0101U00InitListItemInfo> lstCpl0101U00InitListItemInfo = new List<CPL0101U00InitListItemInfo>();
            for (int i = 0; i < grdMaster.RowCount; i++)
            {
                if (grdMaster.GetRowState(i) == DataRowState.Added || grdMaster.GetRowState(i) == DataRowState.Modified)
                {
                    CPL0101U00InitListItemInfo itemInfo = new CPL0101U00InitListItemInfo();
                    itemInfo.JukyongDate = grdMaster.GetItemString(i, "jukyong_date");
                    itemInfo.HangmogCode = grdMaster.GetItemString(i, "hangmog_code");
                    itemInfo.SpecimenCode = grdMaster.GetItemString(i, "specimen_code");
                    itemInfo.SpecimenName = grdMaster.GetItemString(i, "specimen_name");
                    itemInfo.Emergency = grdMaster.GetItemString(i, "emergency");
                    itemInfo.DefaultYn = grdMaster.GetItemString(i, "default_yn");
                    itemInfo.JundalGubun = grdMaster.GetItemString(i, "jundal_gubun");
                    itemInfo.JundalName = grdMaster.GetItemString(i, "jundal_name");
                    itemInfo.Danui = grdMaster.GetItemString(i, "danui");
                    itemInfo.DanuiName = grdMaster.GetItemString(i, "danui_name");
                    itemInfo.TubeCode = grdMaster.GetItemString(i, "tube_code");
                    itemInfo.TubeName = grdMaster.GetItemString(i, "tube_name");
                    itemInfo.UitakCode = grdMaster.GetItemString(i, "uitak_code");
                    itemInfo.UitakName = grdMaster.GetItemString(i, "uitak_name");
                    itemInfo.SutakCode = grdMaster.GetItemString(i, "sutak_code");
                    itemInfo.SutakName = grdMaster.GetItemString(i, "sutak_name");
                    itemInfo.SlipCode = grdMaster.GetItemString(i, "slip_code");
                    itemInfo.SlipName = grdMaster.GetItemString(i, "slip_name");
                    itemInfo.JangbiCode = grdMaster.GetItemString(i, "jangbi_code");
                    itemInfo.JangbiName = grdMaster.GetItemString(i, "jangbi_name");
                    itemInfo.JangbiOutCode = grdMaster.GetItemString(i, "jangbi_out_code");
                    itemInfo.JangbiCode2 = grdMaster.GetItemString(i, "jangbi_code2");
                    itemInfo.JangbiName2 = grdMaster.GetItemString(i, "jangbi_name2");
                    itemInfo.JangbiOutCode2 = grdMaster.GetItemString(i, "jangbi_out_code2");
                    itemInfo.JangbiCode3 = grdMaster.GetItemString(i, "jangbi_code3");
                    itemInfo.JangbiName3 = grdMaster.GetItemString(i, "jangbi_name3");
                    itemInfo.JangbiOutCode3 = grdMaster.GetItemString(i, "jangbi_out_code3");
                    itemInfo.GroupGubun = grdMaster.GetItemString(i, "group_gubun");
                    itemInfo.GumsaNameRe = grdMaster.GetItemString(i, "gumsa_name_re");
                    itemInfo.Barcode = grdMaster.GetItemString(i, "barcode");
                    itemInfo.GumsaName = grdMaster.GetItemString(i, "gumsa_name");
                    itemInfo.DefaultResult = grdMaster.GetItemString(i, "default_result");
                    itemInfo.MedicalJundal = grdMaster.GetItemString(i, "medical_jundal");
                    itemInfo.CommentJuCode = grdMaster.GetItemString(i, "comment_ju_code");
                    itemInfo.Serial = grdMaster.GetItemString(i, "serial");
                    itemInfo.ChubangYn = grdMaster.GetItemString(i, "chubang_yn");
                    itemInfo.ResultYn = grdMaster.GetItemString(i, "result_yn");
                    itemInfo.ResultForm = grdMaster.GetItemString(i, "result_form");
                    itemInfo.TongGubun = grdMaster.GetItemString(i, "tong_gubun");
                    itemInfo.SpecimenAmt = grdMaster.GetItemString(i, "specimen_amt");
                    itemInfo.OldSlipCode = grdMaster.GetItemString(i, "old_slip_code");
                    itemInfo.DetailInfo = grdMaster.GetItemString(i, "detail_info");
                    itemInfo.DisplayYn = grdMaster.GetItemString(i, "display_yn");
                    itemInfo.JundalGubunName = grdMaster.GetItemString(i, "jundal_gubun_name");
                    itemInfo.SpcialName = grdMaster.GetItemString(i, "spcial_name");
                    itemInfo.TongSerial = grdMaster.GetItemString(i, "tong_serial");
                    itemInfo.Point = grdMaster.GetItemString(i, "point");
                    itemInfo.Point2 = grdMaster.GetItemString(i, "point2");
                    itemInfo.Point3 = grdMaster.GetItemString(i, "point3");
                    itemInfo.OutTube = grdMaster.GetItemString(i, "out_tube");
                    itemInfo.OutTube2 = grdMaster.GetItemString(i, "out_tube2");
                    itemInfo.HangmogMarkName = grdMaster.GetItemString(i, "hangmog_mark_name");
                    itemInfo.MiddleResult = grdMaster.GetItemString(i, "middle_result");
                    itemInfo.UserGubun = grdMaster.GetItemString(i, "user_gubun");
                    itemInfo.DataRowState = grdMaster.GetRowState(i).ToString();

                    lstCpl0101U00InitListItemInfo.Add(itemInfo);
                }
            }
            if (grdMaster.DeletedRowTable != null && grdMaster.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdMaster.DeletedRowTable.Rows)
                {
                    CPL0101U00InitListItemInfo itemInfo = new CPL0101U00InitListItemInfo();
                    itemInfo.JukyongDate = row["jukyong_date"].ToString();
                    itemInfo.HangmogCode = row["hangmog_code"].ToString();
                    itemInfo.SpecimenCode = row["specimen_code"].ToString();
                    itemInfo.SpecimenName = row["specimen_name"].ToString();
                    itemInfo.Emergency = row["emergency"].ToString();
                    itemInfo.DefaultYn = row["default_yn"].ToString();
                    itemInfo.JundalGubun = row["jundal_gubun"].ToString();
                    itemInfo.JundalName = row["jundal_name"].ToString();
                    itemInfo.Danui = row["danui"].ToString();
                    itemInfo.DanuiName = row["danui_name"].ToString();
                    itemInfo.TubeCode = row["tube_code"].ToString();
                    itemInfo.TubeName = row["tube_name"].ToString();
                    itemInfo.UitakCode = row["uitak_code"].ToString();
                    itemInfo.UitakName = row["uitak_name"].ToString();
                    itemInfo.SutakCode = row["sutak_code"].ToString();
                    itemInfo.SutakName = row["sutak_name"].ToString();
                    itemInfo.SlipCode = row["slip_code"].ToString();
                    itemInfo.SlipName = row["slip_name"].ToString();
                    itemInfo.JangbiCode = row["jangbi_code"].ToString();
                    itemInfo.JangbiName = row["jangbi_name"].ToString();
                    itemInfo.JangbiOutCode = row["jangbi_out_code"].ToString();
                    itemInfo.JangbiCode2 = row["jangbi_code2"].ToString();
                    itemInfo.JangbiName2 = row["jangbi_name2"].ToString();
                    itemInfo.JangbiOutCode2 = row["jangbi_out_code2"].ToString();
                    itemInfo.JangbiCode3 = row["jangbi_code3"].ToString();
                    itemInfo.JangbiName3 = row["jangbi_name3"].ToString();
                    itemInfo.JangbiOutCode3 = row["jangbi_out_code3"].ToString();
                    itemInfo.GroupGubun = row["group_gubun"].ToString();
                    itemInfo.GumsaNameRe = row["gumsa_name_re"].ToString();
                    itemInfo.Barcode = row["barcode"].ToString();
                    itemInfo.GumsaName = row["gumsa_name"].ToString();
                    itemInfo.DefaultResult = row["default_result"].ToString();
                    itemInfo.MedicalJundal = row["medical_jundal"].ToString();
                    itemInfo.CommentJuCode = row["comment_ju_code"].ToString();
                    itemInfo.Serial = row["serial"].ToString();
                    itemInfo.ChubangYn = row["chubang_yn"].ToString();
                    itemInfo.ResultYn = row["result_yn"].ToString();
                    itemInfo.ResultForm = row["result_form"].ToString();
                    itemInfo.TongGubun = row["tong_gubun"].ToString();
                    itemInfo.SpecimenAmt = row["specimen_amt"].ToString();
                    itemInfo.OldSlipCode = row["old_slip_code"].ToString();
                    itemInfo.DetailInfo = row["detail_info"].ToString();
                    itemInfo.DisplayYn = row["display_yn"].ToString();
                    itemInfo.JundalGubunName = row["jundal_gubun_name"].ToString();
                    itemInfo.SpcialName = row["spcial_name"].ToString();
                    itemInfo.TongSerial = row["tong_serial"].ToString();
                    itemInfo.Point = row["point"].ToString();
                    itemInfo.Point2 = row["point2"].ToString();
                    itemInfo.Point3 = row["point3"].ToString();
                    itemInfo.OutTube = row["out_tube"].ToString();
                    itemInfo.OutTube2 = row["out_tube2"].ToString();
                    itemInfo.HangmogMarkName = row["hangmog_mark_name"].ToString();
                    itemInfo.MiddleResult = row["middle_result"].ToString();
                    itemInfo.UserGubun = row["user_gubun"].ToString();
                    itemInfo.DataRowState = DataRowState.Deleted.ToString();

                    lstCpl0101U00InitListItemInfo.Add(itemInfo);
                }
            }

            return lstCpl0101U00InitListItemInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> cboUserGubun_ExecuteQuery(BindVarCollection varCollection)
        {
            List<object[]> lstObject = new List<object[]>();
            ComboADM1110GetByColNameArgs args = new ComboADM1110GetByColNameArgs();
            args.ColName = "USER_GUBUN";
            //ComboResult comboResult =
            //    CacheService.Instance.Get<ComboADM1110GetByColNameArgs, ComboResult>(
            //        Constants.CacheKeyCbo.CACHE_COMBO_ADM1110_GET_BY_COL_USER_GUBUN, args,
            //        delegate(ComboResult result)
            //        {
            //            return result != null && result.ExecutionStatus == ExecutionStatus.Success &&
            //                   result.ComboItem.Count > 0;
            //        });
            ComboResult comboResult = CacheService.Instance.Get<ComboADM1110GetByColNameArgs, ComboResult>(args);
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> listItemInfo = comboResult.ComboItem;
                if (listItemInfo != null && listItemInfo.Count > 0)
                {
                    foreach (ComboListItemInfo itemInfo in listItemInfo)
                    {
                        lstObject.Add(new object[]
                        {
                            itemInfo.Code,
                            itemInfo.CodeName
                        });
                    }
                }
            }
            return lstObject;
        } 
        #endregion

        /// <summary>
        /// 2016.02.03 AnhNV Added
        /// https://sofiamedix.atlassian.net/browse/MED-7335
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdMstData_Click(object sender, EventArgs e)
        {
            Service.StartWriteLog();
            Service.WriteLog("[UPDATE MASTER DATA]...");
            Cursor preCur = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                UpdateMasterDataArgs args = new UpdateMasterDataArgs();
                args.ScreenName = this.Name;
                UpdateResult res = CloudService.Instance.Submit<UpdateResult, UpdateMasterDataArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    // Update master data succeeded
                    grdMaster.QueryLayout(false);
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog("[UPDATE MASTER DATA] Failed at " + ex.StackTrace);
                Service.WriteLog("[UPDATE MASTER DATA] Error: " + ex.Message);
            }
            finally
            {
                Cursor.Current = preCur;
            }

            Service.EndWriteLog();
        }

        /// <summary>
        /// https://sofiamedix.atlassian.net/browse/MED-16286
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUploadIFMst_Click(object sender, EventArgs e)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("opener", this.Name);

            XScreen.OpenScreenWithParam(this, "CPLS", "CPLMASTERUPLOADER", ScreenOpenStyle.PopUpFixed, openParams);
        }
    }
}