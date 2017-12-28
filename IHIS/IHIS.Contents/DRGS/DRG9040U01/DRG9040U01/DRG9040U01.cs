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
using IHIS.CloudConnector.Contracts.Arguments.Drgs;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Drgs;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.DRGS.Properties;
using IHIS.Framework;
#endregion

namespace IHIS.DRGS
{
    /// <summary>
    /// DRG9040U01에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class DRG9040U01 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XMstGrid grdOrder;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell29;
        private IHIS.Framework.XEditGridCell xEditGridCell30;
        private IHIS.Framework.XEditGridCell xEditGridCell31;
        private IHIS.Framework.XEditGridCell xEditGridCell32;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell33;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell74;
        private IHIS.Framework.XEditGridCell xEditGridCell81;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XPanel xPanel4;
        private IHIS.Framework.XPatientBox paBox;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XEditGrid grdJUSAOrderList;
        private IHIS.Framework.XEditGridCell xEditGridCell57;
        private IHIS.Framework.XEditGridCell xEditGridCell101;
        private IHIS.Framework.XEditGridCell xEditGridCell102;
        private IHIS.Framework.XEditGridCell xEditGridCell103;
        private IHIS.Framework.XEditGridCell xEditGridCell104;
        private IHIS.Framework.XEditGridCell xEditGridCell105;
        private IHIS.Framework.XEditGridCell xEditGridCell106;
        private IHIS.Framework.XEditGridCell xEditGridCell107;
        private IHIS.Framework.XEditGridCell xEditGridCell108;
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
        private IHIS.Framework.XEditGridCell xEditGridCell119;
        private IHIS.Framework.XEditGridCell xEditGridCell120;
        private IHIS.Framework.XEditGridCell xEditGridCell121;
        private IHIS.Framework.XEditGridCell xEditGridCell122;
        private IHIS.Framework.XEditGridCell xEditGridCell124;
        private IHIS.Framework.XEditGridCell xEditGridCell125;
        private IHIS.Framework.XEditGridCell xEditGridCell128;
        private IHIS.Framework.XComboItem xComboItem1;
        private IHIS.Framework.XComboItem xComboItem2;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private XLabel xLabel3;
        private XPanel xPanel5;
        private XLabel xLabel4;
        private XRichTextBox txtPaOrdRemark;
        private XLabel xLabel1;
        private XRichTextBox txtPaDrgRemark;
        private XLabel xLabel2;
        private XLabel xLabel5;
        private XLabel xLabel7;
        private XLabel xLabel6;
        private XDatePicker dtpToDate;
        private XDatePicker dtpFromDate;
        private XLabel xLabel8;
        private SingleLayout layPaComment;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private XMstGrid grdOrderOut;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell26;
        private XEditGridCell xEditGridCell28;
        private XEditGridCell xEditGridCell37;
        private XEditGridCell xEditGridCell69;
        private XEditGridCell xEditGridCell38;
        private XEditGridCell xEditGridCell39;
        private XEditGridCell xEditGridCell60;
        private XEditGrid grdOrderListOut;
        private XEditGridCell xEditGridCell83;
        private XEditGridCell xEditGridCell84;
        private XEditGridCell xEditGridCell85;
        private XEditGridCell xEditGridCell86;
        private XEditGridCell xEditGridCell87;
        private XEditGridCell xEditGridCell88;
        private XEditGridCell xEditGridCell61;
        private XEditGridCell xEditGridCell62;
        private XEditGridCell xEditGridCell89;
        private XEditGridCell xEditGridCell63;
        private XEditGridCell xEditGridCell90;
        private XEditGridCell xEditGridCell64;
        private XEditGridCell xEditGridCell91;
        private XEditGridCell xEditGridCell92;
        private XEditGridCell xEditGridCell93;
        private XEditGridCell xEditGridCell65;
        private XEditGridCell xEditGridCell94;
        private XEditGridCell xEditGridCell95;
        private XEditGridCell xEditGridCell96;
        private XEditGridCell xEditGridCell97;
        private XEditGridCell xEditGridCell66;
        private XEditGridCell xEditGridCell67;
        private XEditGridCell xEditGridCell68;
        private XEditGridCell xEditGridCell99;
        private XEditGridCell xEditGridCell100;
        private XEditGridCell xEditGridCell71;
        private XEditGridCell xEditGridCell72;
        private XEditGridCell xEditGridCell73;
        private XEditGridCell xEditGridCell75;
        private XEditGridCell xEditGridCell76;
        private XEditGridCell xEditGridCell77;
        private XEditGridCell xEditGridCell78;
        private XEditGridCell xEditGridCell79;
        private XEditGridCell xEditGridCell80;
        private XEditGridCell xEditGridCell82;
        private XEditGridCell xEditGridCell98;
        private XEditGridCell xEditGridCell129;
        private XEditGridCell xEditGridCell130;
        private XEditGridCell xEditGridCell131;
        private XEditGridCell xEditGridCell132;
        private XEditGridCell xEditGridCell133;
        private XEditGridCell xEditGridCell134;
        private XEditGridCell xEditGridCell135;
        private XEditGridCell xEditGridCell137;
        private XEditGridCell xEditGridCell138;
        private XEditGridCell xEditGridCell139;
        private XEditGridCell xEditGridCell140;
        private XEditGridCell xEditGridCell141;
        private XLabel xLabel9;
        private XComboBox cboInOutGubun;
        private XComboItem xComboItem3;
        private XComboItem xComboItem4;
        private XEditGrid grdOrderList;
        private XEditGridCell xEditGridCell27;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell34;
        private XEditGridCell xEditGridCell35;
        private XEditGridCell xEditGridCell36;
        private XEditGridCell xEditGridCell40;
        private XEditGridCell xEditGridCell41;
        private XEditGridCell xEditGridCell42;
        private XEditGridCell xEditGridCell43;
        private XEditGridCell xEditGridCell44;
        private XEditGridCell xEditGridCell45;
        private XEditGridCell xEditGridCell46;
        private XEditGridCell xEditGridCell47;
        private XEditGridCell xEditGridCell48;
        private XEditGridCell xEditGridCell49;
        private XEditGridCell xEditGridCell50;
        private XEditGridCell xEditGridCell51;
        private XEditGridCell xEditGridCell52;
        private XEditGridCell xEditGridCell53;
        private XEditGridCell xEditGridCell54;
        private XEditGridCell xEditGridCell55;
        private XEditGridCell xEditGridCell56;
        private XEditGridCell xEditGridCell123;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell126;
        private XEditGridCell xEditGridCell127;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public DRG9040U01()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            // TODO comment use connect cloud
            /*//저장 수행자 Set
            this.grdOrder.SavePerformer = new XSavePerformer(this);
            this.grdJUSAOrderList.SavePerformer = this.grdOrder.SavePerformer;
            this.grdOrderList.SavePerformer = this.grdOrder.SavePerformer;
            this.grdOrderOut.SavePerformer = this.grdOrder.SavePerformer;
            this.grdOrderListOut.SavePerformer = this.grdOrder.SavePerformer;
            //저장 Layout List Set
            this.SaveLayoutList.Add(this.grdOrder);
            this.SaveLayoutList.Add(this.grdJUSAOrderList);
            this.SaveLayoutList.Add(this.grdOrderList);
            this.SaveLayoutList.Add(this.grdOrderOut);
            this.SaveLayoutList.Add(this.grdOrderListOut);*/

            grdJUSAOrderList.ParamList = new List<string>(new String[] { "f_jubsu_date", "f_drg_bunho", "f_magam_bunryu" });
            grdJUSAOrderList.ExecuteQuery = ExecuteQueryGrdJUSAOrderListInfo;

            grdOrderListOut.ParamList = new List<string>(new String[] { "f_order_date", "f_drg_bunho", "f_bunho" });
            grdOrderListOut.ExecuteQuery = ExecuteQueryGrdOrderListOutInfo;

            grdOrderList.ParamList = new List<string>(new String[] { "f_jubsu_date", "f_drg_bunho", "f_magam_bunryu" });
            grdOrderList.ExecuteQuery = ExecuteQueryGrdOrderListInfo;

            grdOrderOut.ParamList = new List<string>(new String[] { "f_from_date", "f_to_date", "f_bunho" });
            grdOrderOut.ExecuteQuery = ExecuteQueryGrdOrderOutInfo;

            grdOrder.ParamList = new List<string>(new String[] { "f_from_date", "f_to_date", "f_bunho" });
            grdOrder.ExecuteQuery = ExecuteQueryGrdOrderInfo;

            layPaComment.ParamList = new List<string>(new String[] { "f_bunho" });
            layPaComment.ExecuteQuery = ExecuteQueryLayPaCommentInfo;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG9040U01));
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.txtPaDrgRemark = new IHIS.Framework.XRichTextBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.txtPaOrdRemark = new IHIS.Framework.XRichTextBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.grdOrder = new IHIS.Framework.XMstGrid();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdOrderList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell123 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell126 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell127 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.grdOrderListOut = new IHIS.Framework.XEditGrid();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell129 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell130 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell131 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell132 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell133 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell134 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell135 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell137 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell138 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell139 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell140 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell141 = new IHIS.Framework.XEditGridCell();
            this.grdOrderOut = new IHIS.Framework.XMstGrid();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.grdJUSAOrderList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell101 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell102 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell103 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell104 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell105 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell106 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell107 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell108 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell119 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell120 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell121 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell122 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell124 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell125 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell128 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.cboInOutGubun = new IHIS.Framework.XComboBox();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.dtpToDate = new IHIS.Framework.XDatePicker();
            this.dtpFromDate = new IHIS.Framework.XDatePicker();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.layPaComment = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderListOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJUSAOrderList)).BeginInit();
            this.xPanel4.SuspendLayout();
            this.xPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // xPanel3
            // 
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Controls.Add(this.txtPaDrgRemark);
            this.xPanel3.Controls.Add(this.xLabel2);
            this.xPanel3.Controls.Add(this.txtPaOrdRemark);
            this.xPanel3.Controls.Add(this.xLabel1);
            this.xPanel3.Controls.Add(this.xLabel4);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            // 
            // txtPaDrgRemark
            // 
            resources.ApplyResources(this.txtPaDrgRemark, "txtPaDrgRemark");
            this.txtPaDrgRemark.Name = "txtPaDrgRemark";
            // 
            // xLabel2
            // 
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackColor = IHIS.Framework.XColor.XListBoxAlternatingItemBackColor;
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD2;
            this.xLabel2.BorderColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.xLabel2.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XComboBoxBackColor;
            this.xLabel2.Name = "xLabel2";
            // 
            // txtPaOrdRemark
            // 
            resources.ApplyResources(this.txtPaOrdRemark, "txtPaOrdRemark");
            this.txtPaOrdRemark.Name = "txtPaOrdRemark";
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackColor = IHIS.Framework.XColor.XListBoxAlternatingItemBackColor;
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD2;
            this.xLabel1.BorderColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.xLabel1.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XComboBoxBackColor;
            this.xLabel1.Name = "xLabel1";
            // 
            // xLabel4
            // 
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackColor = IHIS.Framework.XColor.XListBoxAlternatingItemBackColor;
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD2;
            this.xLabel4.BorderColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.xLabel4.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XTreeViewBackColor;
            this.xLabel4.Name = "xLabel4";
            // 
            // xLabel3
            // 
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackColor = IHIS.Framework.XColor.XListBoxBackColor;
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.BorderColor = IHIS.Framework.XColor.XGridSelectedCellBackColor;
            this.xLabel3.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.xLabel3.Name = "xLabel3";
            // 
            // paBox
            // 
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.BackColor = IHIS.Framework.XColor.XListBoxAlternatingItemBackColor;
            this.paBox.Name = "paBox";
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // grdOrder
            // 
            resources.ApplyResources(this.grdOrder, "grdOrder");
            this.grdOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell31,
            this.xEditGridCell3,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell32,
            this.xEditGridCell5,
            this.xEditGridCell33,
            this.xEditGridCell4,
            this.xEditGridCell74,
            this.xEditGridCell81,
            this.xEditGridCell10,
            this.xEditGridCell17});
            this.grdOrder.ColPerLine = 7;
            this.grdOrder.ColResizable = true;
            this.grdOrder.Cols = 8;
            this.grdOrder.ControlBinding = true;
            this.grdOrder.ExecuteQuery = null;
            this.grdOrder.FixedCols = 1;
            this.grdOrder.FixedRows = 1;
            this.grdOrder.HeaderHeights.Add(33);
            this.grdOrder.Name = "grdOrder";
            this.grdOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOrder.ParamList")));
            this.grdOrder.QuerySQL = resources.GetString("grdOrder.QuerySQL");
            this.grdOrder.RowHeaderVisible = true;
            this.grdOrder.Rows = 2;
            this.grdOrder.UseDefaultTransaction = false;
            this.grdOrder.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOrder_RowFocusChanged);
            this.grdOrder.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOrder_QueryStarting);
            this.grdOrder.PreEndInitializing += new System.EventHandler(this.grdOrder_PreEndInitializing);
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "jubsu_date";
            this.xEditGridCell31.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell31.CellWidth = 90;
            this.xEditGridCell31.Col = 1;
            this.xEditGridCell31.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsReadOnly = true;
            this.xEditGridCell31.SuppressRepeating = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.ApplyPaintingEvent = true;
            this.xEditGridCell3.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell3.CellName = "drg_bunho";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell3.CellWidth = 67;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.GeneralNumberFormat = true;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "bunho";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.IsUpdatable = false;
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "order_date";
            this.xEditGridCell30.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsReadOnly = true;
            this.xEditGridCell30.IsUpdCol = false;
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "doctor";
            this.xEditGridCell32.Col = -1;
            this.xEditGridCell32.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsReadOnly = true;
            this.xEditGridCell32.IsUpdatable = false;
            this.xEditGridCell32.IsUpdCol = false;
            this.xEditGridCell32.IsVisible = false;
            this.xEditGridCell32.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.ApplyPaintingEvent = true;
            this.xEditGridCell5.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell5.CellLen = 30;
            this.xEditGridCell5.CellName = "doctor_name";
            this.xEditGridCell5.CellWidth = 117;
            this.xEditGridCell5.Col = 5;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsUpdCol = false;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "gwa";
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsReadOnly = true;
            this.xEditGridCell33.IsUpdatable = false;
            this.xEditGridCell33.IsUpdCol = false;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.ApplyPaintingEvent = true;
            this.xEditGridCell4.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell4.CellLen = 30;
            this.xEditGridCell4.CellName = "buseo_name";
            this.xEditGridCell4.CellWidth = 132;
            this.xEditGridCell4.Col = 4;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsUpdCol = false;
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.CellLen = 2000;
            this.xEditGridCell74.CellName = "order_remark";
            this.xEditGridCell74.CellWidth = 250;
            this.xEditGridCell74.Col = 6;
            this.xEditGridCell74.DisplayMemoText = true;
            this.xEditGridCell74.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell74.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell74, "xEditGridCell74");
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.CellLen = 2000;
            this.xEditGridCell81.CellName = "drg_remark";
            this.xEditGridCell81.CellWidth = 250;
            this.xEditGridCell81.Col = 7;
            this.xEditGridCell81.DisplayMemoText = true;
            this.xEditGridCell81.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell81.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell81, "xEditGridCell81");
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "magam_gubun";
            this.xEditGridCell10.CellWidth = 85;
            this.xEditGridCell10.Col = 3;
            this.xEditGridCell10.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2});
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdCol = false;
            this.xEditGridCell10.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell10.UserSQL = "SELECT A.CODE\r\n     , A.CODE_NAME\r\n  FROM INV0102 A\r\nWHERE A.HOSP_CODE = \'K01\'\r\n " +
    " AND A.CODE_TYPE = FN_ADM_LOAD_HOSP_CODE()";
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "11";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "21";
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "bunryu1";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsUpdatable = false;
            this.xEditGridCell17.IsUpdCol = false;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackColor = IHIS.Framework.XColor.XListBoxAlternatingItemBackColor;
            this.xPanel1.Controls.Add(this.btnList);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackColor = IHIS.Framework.XColor.XListBoxAlternatingItemBackColor;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.EntryS;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel2
            // 
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Controls.Add(this.grdOrderList);
            this.xPanel2.Controls.Add(this.grdOrderListOut);
            this.xPanel2.Controls.Add(this.grdJUSAOrderList);
            this.xPanel2.Controls.Add(this.xLabel8);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // grdOrderList
            // 
            resources.ApplyResources(this.grdOrderList, "grdOrderList");
            this.grdOrderList.ApplyPaintEventToAllColumn = true;
            this.grdOrderList.CallerID = '3';
            this.grdOrderList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell27,
            this.xEditGridCell1,
            this.xEditGridCell6,
            this.xEditGridCell34,
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell40,
            this.xEditGridCell41,
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
            this.xEditGridCell123,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell126,
            this.xEditGridCell127,
            this.xEditGridCell15,
            this.xEditGridCell16});
            this.grdOrderList.ColPerLine = 17;
            this.grdOrderList.ColResizable = true;
            this.grdOrderList.Cols = 18;
            this.grdOrderList.ControlBinding = true;
            this.grdOrderList.ExecuteQuery = null;
            this.grdOrderList.FixedCols = 1;
            this.grdOrderList.FixedRows = 1;
            this.grdOrderList.HeaderHeights.Add(41);
            this.grdOrderList.Name = "grdOrderList";
            this.grdOrderList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOrderList.ParamList")));
            this.grdOrderList.QuerySQL = resources.GetString("grdOrderList.QuerySQL");
            this.grdOrderList.RowHeaderVisible = true;
            this.grdOrderList.Rows = 2;
            this.grdOrderList.ToolTipActive = true;
            this.grdOrderList.UseDefaultTransaction = false;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "order_date";
            this.xEditGridCell27.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell27.CellWidth = 77;
            this.xEditGridCell27.Col = 10;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsReadOnly = true;
            this.xEditGridCell27.IsUpdCol = false;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "group_ser";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell1.CellWidth = 27;
            this.xEditGridCell1.Col = 9;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdCol = false;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "jaeryo_code";
            this.xEditGridCell6.CellWidth = 77;
            this.xEditGridCell6.Col = 3;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdCol = false;
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "jaeryo_name";
            this.xEditGridCell34.CellWidth = 203;
            this.xEditGridCell34.Col = 4;
            this.xEditGridCell34.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsReadOnly = true;
            this.xEditGridCell34.IsUpdCol = false;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "ord_suryang";
            this.xEditGridCell35.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell35.CellWidth = 40;
            this.xEditGridCell35.Col = 5;
            this.xEditGridCell35.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsReadOnly = true;
            this.xEditGridCell35.IsUpdCol = false;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "dv_time";
            this.xEditGridCell36.CellWidth = 22;
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsReadOnly = true;
            this.xEditGridCell36.IsUpdCol = false;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            this.xEditGridCell36.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "dv";
            this.xEditGridCell40.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell40.CellWidth = 22;
            this.xEditGridCell40.Col = 6;
            this.xEditGridCell40.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsReadOnly = true;
            this.xEditGridCell40.IsUpdCol = false;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "nalsu";
            this.xEditGridCell41.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell41.CellWidth = 22;
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.IsReadOnly = true;
            this.xEditGridCell41.IsUpdCol = false;
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "order_danui";
            this.xEditGridCell42.CellWidth = 22;
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.IsReadOnly = true;
            this.xEditGridCell42.IsUpdCol = false;
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "danui_name";
            this.xEditGridCell43.CellWidth = 47;
            this.xEditGridCell43.Col = 7;
            this.xEditGridCell43.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsReadOnly = true;
            this.xEditGridCell43.IsUpdCol = false;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "bogyong_code";
            this.xEditGridCell44.CellWidth = 22;
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsReadOnly = true;
            this.xEditGridCell44.IsUpdCol = false;
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "bogyong_name";
            this.xEditGridCell45.CellWidth = 121;
            this.xEditGridCell45.Col = 8;
            this.xEditGridCell45.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.IsReadOnly = true;
            this.xEditGridCell45.IsUpdCol = false;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "powder_yn";
            this.xEditGridCell46.CellWidth = 34;
            this.xEditGridCell46.Col = 14;
            this.xEditGridCell46.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell46.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.IsReadOnly = true;
            this.xEditGridCell46.IsUpdCol = false;
            this.xEditGridCell46.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "remark";
            this.xEditGridCell47.CellWidth = 62;
            this.xEditGridCell47.Col = 13;
            this.xEditGridCell47.DisplayMemoText = true;
            this.xEditGridCell47.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell47.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsReadOnly = true;
            this.xEditGridCell47.IsUpdCol = false;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "dv_1";
            this.xEditGridCell48.CellWidth = 22;
            this.xEditGridCell48.Col = -1;
            this.xEditGridCell48.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            this.xEditGridCell48.IsReadOnly = true;
            this.xEditGridCell48.IsUpdCol = false;
            this.xEditGridCell48.IsVisible = false;
            this.xEditGridCell48.Row = -1;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "dv_2";
            this.xEditGridCell49.CellWidth = 22;
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            this.xEditGridCell49.IsReadOnly = true;
            this.xEditGridCell49.IsUpdCol = false;
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "dv_3";
            this.xEditGridCell50.CellWidth = 22;
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            this.xEditGridCell50.IsReadOnly = true;
            this.xEditGridCell50.IsUpdCol = false;
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "dv_4";
            this.xEditGridCell51.CellWidth = 22;
            this.xEditGridCell51.Col = -1;
            this.xEditGridCell51.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.IsReadOnly = true;
            this.xEditGridCell51.IsUpdCol = false;
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "dv_5";
            this.xEditGridCell52.CellWidth = 22;
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.IsReadOnly = true;
            this.xEditGridCell52.IsUpdCol = false;
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "hubal_change_yn";
            this.xEditGridCell53.CellWidth = 45;
            this.xEditGridCell53.Col = 17;
            this.xEditGridCell53.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell53.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.IsReadOnly = true;
            this.xEditGridCell53.IsUpdCol = false;
            this.xEditGridCell53.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "pharmacy";
            this.xEditGridCell54.CellWidth = 43;
            this.xEditGridCell54.Col = 15;
            this.xEditGridCell54.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell54.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.IsReadOnly = true;
            this.xEditGridCell54.IsUpdCol = false;
            this.xEditGridCell54.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "drg_pack_yn";
            this.xEditGridCell55.CellWidth = 41;
            this.xEditGridCell55.Col = 16;
            this.xEditGridCell55.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell55.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.IsReadOnly = true;
            this.xEditGridCell55.IsUpdCol = false;
            this.xEditGridCell55.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "jusa";
            this.xEditGridCell56.CellWidth = 22;
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            this.xEditGridCell56.IsReadOnly = true;
            this.xEditGridCell56.IsUpdCol = false;
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            this.xEditGridCell56.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell123
            // 
            this.xEditGridCell123.CellName = "suname";
            this.xEditGridCell123.Col = 2;
            this.xEditGridCell123.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell123, "xEditGridCell123");
            this.xEditGridCell123.IsReadOnly = true;
            this.xEditGridCell123.IsUpdCol = false;
            this.xEditGridCell123.SuppressRepeating = true;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellLen = 1000;
            this.xEditGridCell11.CellName = "order_remark";
            this.xEditGridCell11.CellWidth = 61;
            this.xEditGridCell11.Col = 11;
            this.xEditGridCell11.DisplayMemoText = true;
            this.xEditGridCell11.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellLen = 1000;
            this.xEditGridCell12.CellName = "drg_remark";
            this.xEditGridCell12.CellWidth = 56;
            this.xEditGridCell12.Col = 12;
            this.xEditGridCell12.DisplayMemoText = true;
            this.xEditGridCell12.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // xEditGridCell126
            // 
            this.xEditGridCell126.CellName = "drg_bunho";
            this.xEditGridCell126.CellWidth = 40;
            this.xEditGridCell126.Col = 1;
            this.xEditGridCell126.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell126, "xEditGridCell126");
            this.xEditGridCell126.IsReadOnly = true;
            this.xEditGridCell126.SuppressRepeating = true;
            // 
            // xEditGridCell127
            // 
            this.xEditGridCell127.CellName = "jubsu_date";
            this.xEditGridCell127.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell127.CellWidth = 22;
            this.xEditGridCell127.Col = -1;
            this.xEditGridCell127.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell127, "xEditGridCell127");
            this.xEditGridCell127.IsVisible = false;
            this.xEditGridCell127.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "bunho";
            this.xEditGridCell15.CellWidth = 22;
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "fkocs2003";
            this.xEditGridCell16.CellWidth = 22;
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // grdOrderListOut
            // 
            resources.ApplyResources(this.grdOrderListOut, "grdOrderListOut");
            this.grdOrderListOut.CallerID = '5';
            this.grdOrderListOut.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell83,
            this.xEditGridCell84,
            this.xEditGridCell85,
            this.xEditGridCell86,
            this.xEditGridCell87,
            this.xEditGridCell88,
            this.xEditGridCell61,
            this.xEditGridCell62,
            this.xEditGridCell89,
            this.xEditGridCell63,
            this.xEditGridCell90,
            this.xEditGridCell64,
            this.xEditGridCell91,
            this.xEditGridCell92,
            this.xEditGridCell93,
            this.xEditGridCell65,
            this.xEditGridCell94,
            this.xEditGridCell95,
            this.xEditGridCell96,
            this.xEditGridCell97,
            this.xEditGridCell66,
            this.xEditGridCell67,
            this.xEditGridCell68,
            this.xEditGridCell99,
            this.xEditGridCell100,
            this.xEditGridCell71,
            this.xEditGridCell72,
            this.xEditGridCell73,
            this.xEditGridCell75,
            this.xEditGridCell76,
            this.xEditGridCell77,
            this.xEditGridCell78,
            this.xEditGridCell79,
            this.xEditGridCell80,
            this.xEditGridCell82,
            this.xEditGridCell98,
            this.xEditGridCell129,
            this.xEditGridCell130,
            this.xEditGridCell131,
            this.xEditGridCell132,
            this.xEditGridCell133,
            this.xEditGridCell134,
            this.xEditGridCell135,
            this.xEditGridCell137,
            this.xEditGridCell138,
            this.xEditGridCell139,
            this.xEditGridCell140,
            this.xEditGridCell141});
            this.grdOrderListOut.ColPerLine = 16;
            this.grdOrderListOut.Cols = 17;
            this.grdOrderListOut.ControlBinding = true;
            this.grdOrderListOut.ExecuteQuery = null;
            this.grdOrderListOut.FixedCols = 1;
            this.grdOrderListOut.FixedRows = 1;
            this.grdOrderListOut.HeaderHeights.Add(56);
            this.grdOrderListOut.MasterLayout = this.grdOrderOut;
            this.grdOrderListOut.Name = "grdOrderListOut";
            this.grdOrderListOut.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOrderListOut.ParamList")));
            this.grdOrderListOut.QuerySQL = resources.GetString("grdOrderListOut.QuerySQL");
            this.grdOrderListOut.RowHeaderVisible = true;
            this.grdOrderListOut.Rows = 2;
            this.grdOrderListOut.ToolTipActive = true;
            this.grdOrderListOut.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOrderListOut_QueryStarting);
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "bunho";
            this.xEditGridCell83.CellWidth = 25;
            this.xEditGridCell83.Col = -1;
            this.xEditGridCell83.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell83, "xEditGridCell83");
            this.xEditGridCell83.IsReadOnly = true;
            this.xEditGridCell83.IsVisible = false;
            this.xEditGridCell83.Row = -1;
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellName = "drg_bunho";
            this.xEditGridCell84.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell84.Col = -1;
            this.xEditGridCell84.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell84, "xEditGridCell84");
            this.xEditGridCell84.IsReadOnly = true;
            this.xEditGridCell84.IsVisible = false;
            this.xEditGridCell84.Row = -1;
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellName = "naewon_date";
            this.xEditGridCell85.Col = -1;
            this.xEditGridCell85.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell85, "xEditGridCell85");
            this.xEditGridCell85.IsReadOnly = true;
            this.xEditGridCell85.IsUpdCol = false;
            this.xEditGridCell85.IsVisible = false;
            this.xEditGridCell85.Row = -1;
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.CellName = "group_ser";
            this.xEditGridCell86.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell86.CellWidth = 22;
            this.xEditGridCell86.Col = -1;
            this.xEditGridCell86.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell86, "xEditGridCell86");
            this.xEditGridCell86.IsReadOnly = true;
            this.xEditGridCell86.IsUpdCol = false;
            this.xEditGridCell86.IsVisible = false;
            this.xEditGridCell86.Row = -1;
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellName = "jubsu_date";
            this.xEditGridCell87.Col = -1;
            this.xEditGridCell87.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell87, "xEditGridCell87");
            this.xEditGridCell87.IsReadOnly = true;
            this.xEditGridCell87.IsVisible = false;
            this.xEditGridCell87.Row = -1;
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.CellName = "order_date";
            this.xEditGridCell88.Col = -1;
            this.xEditGridCell88.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell88, "xEditGridCell88");
            this.xEditGridCell88.IsReadOnly = true;
            this.xEditGridCell88.IsUpdCol = false;
            this.xEditGridCell88.IsVisible = false;
            this.xEditGridCell88.Row = -1;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.ApplyPaintingEvent = true;
            this.xEditGridCell61.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell61.CellName = "jaeryo_code";
            this.xEditGridCell61.CellWidth = 74;
            this.xEditGridCell61.Col = 2;
            this.xEditGridCell61.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.IsReadOnly = true;
            this.xEditGridCell61.IsUpdCol = false;
            this.xEditGridCell61.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.ApplyPaintingEvent = true;
            this.xEditGridCell62.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell62.CellName = "nalsu";
            this.xEditGridCell62.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell62.CellWidth = 45;
            this.xEditGridCell62.Col = 7;
            this.xEditGridCell62.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.IsReadOnly = true;
            this.xEditGridCell62.IsUpdCol = false;
            this.xEditGridCell62.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellName = "divide";
            this.xEditGridCell89.Col = -1;
            this.xEditGridCell89.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell89, "xEditGridCell89");
            this.xEditGridCell89.IsReadOnly = true;
            this.xEditGridCell89.IsUpdCol = false;
            this.xEditGridCell89.IsVisible = false;
            this.xEditGridCell89.Row = -1;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.ApplyPaintingEvent = true;
            this.xEditGridCell63.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell63.CellName = "ord_suryang";
            this.xEditGridCell63.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell63.CellWidth = 50;
            this.xEditGridCell63.Col = 4;
            this.xEditGridCell63.DecimalDigits = 3;
            this.xEditGridCell63.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsReadOnly = true;
            this.xEditGridCell63.IsUpdCol = false;
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.CellName = "order_suryang";
            this.xEditGridCell90.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell90.Col = -1;
            this.xEditGridCell90.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell90, "xEditGridCell90");
            this.xEditGridCell90.IsReadOnly = true;
            this.xEditGridCell90.IsUpdCol = false;
            this.xEditGridCell90.IsVisible = false;
            this.xEditGridCell90.Row = -1;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.ApplyPaintingEvent = true;
            this.xEditGridCell64.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell64.CellName = "order_danui";
            this.xEditGridCell64.CellWidth = 75;
            this.xEditGridCell64.Col = 8;
            this.xEditGridCell64.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.IsReadOnly = true;
            this.xEditGridCell64.IsUpdCol = false;
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.CellName = "subul_danui";
            this.xEditGridCell91.Col = -1;
            this.xEditGridCell91.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell91, "xEditGridCell91");
            this.xEditGridCell91.IsReadOnly = true;
            this.xEditGridCell91.IsUpdCol = false;
            this.xEditGridCell91.IsVisible = false;
            this.xEditGridCell91.Row = -1;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "group_yn";
            this.xEditGridCell92.Col = -1;
            this.xEditGridCell92.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell92, "xEditGridCell92");
            this.xEditGridCell92.IsReadOnly = true;
            this.xEditGridCell92.IsUpdCol = false;
            this.xEditGridCell92.IsVisible = false;
            this.xEditGridCell92.Row = -1;
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.CellName = "jaeryo_gubun";
            this.xEditGridCell93.Col = -1;
            this.xEditGridCell93.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell93, "xEditGridCell93");
            this.xEditGridCell93.IsReadOnly = true;
            this.xEditGridCell93.IsUpdCol = false;
            this.xEditGridCell93.IsVisible = false;
            this.xEditGridCell93.Row = -1;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.ApplyPaintingEvent = true;
            this.xEditGridCell65.CellName = "bogyong_code";
            this.xEditGridCell65.CellWidth = 65;
            this.xEditGridCell65.Col = -1;
            this.xEditGridCell65.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.IsReadOnly = true;
            this.xEditGridCell65.IsUpdCol = false;
            this.xEditGridCell65.IsVisible = false;
            this.xEditGridCell65.Row = -1;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.CellName = "bogyong_name";
            this.xEditGridCell94.CellWidth = 95;
            this.xEditGridCell94.Col = 9;
            this.xEditGridCell94.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell94, "xEditGridCell94");
            this.xEditGridCell94.IsReadOnly = true;
            this.xEditGridCell94.IsUpdCol = false;
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.CellName = "caution_name";
            this.xEditGridCell95.Col = -1;
            this.xEditGridCell95.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell95, "xEditGridCell95");
            this.xEditGridCell95.IsReadOnly = true;
            this.xEditGridCell95.IsUpdCol = false;
            this.xEditGridCell95.IsVisible = false;
            this.xEditGridCell95.Row = -1;
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellName = "caution_code";
            this.xEditGridCell96.Col = -1;
            this.xEditGridCell96.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell96, "xEditGridCell96");
            this.xEditGridCell96.IsReadOnly = true;
            this.xEditGridCell96.IsUpdCol = false;
            this.xEditGridCell96.IsVisible = false;
            this.xEditGridCell96.Row = -1;
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.CellName = "mix_yn";
            this.xEditGridCell97.Col = -1;
            this.xEditGridCell97.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell97, "xEditGridCell97");
            this.xEditGridCell97.IsReadOnly = true;
            this.xEditGridCell97.IsUpdCol = false;
            this.xEditGridCell97.IsVisible = false;
            this.xEditGridCell97.Row = -1;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.ApplyPaintingEvent = true;
            this.xEditGridCell66.CellLen = 35;
            this.xEditGridCell66.CellName = "atc_yn";
            this.xEditGridCell66.CellWidth = 28;
            this.xEditGridCell66.Col = -1;
            this.xEditGridCell66.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.IsReadOnly = true;
            this.xEditGridCell66.IsUpdCol = false;
            this.xEditGridCell66.IsVisible = false;
            this.xEditGridCell66.Row = -1;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.ApplyPaintingEvent = true;
            this.xEditGridCell67.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell67.CellName = "dv";
            this.xEditGridCell67.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell67.CellWidth = 39;
            this.xEditGridCell67.Col = 6;
            this.xEditGridCell67.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell67, "xEditGridCell67");
            this.xEditGridCell67.IsReadOnly = true;
            this.xEditGridCell67.IsUpdCol = false;
            this.xEditGridCell67.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.ApplyPaintingEvent = true;
            this.xEditGridCell68.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell68.CellName = "dv_time";
            this.xEditGridCell68.CellWidth = 34;
            this.xEditGridCell68.Col = 5;
            this.xEditGridCell68.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell68, "xEditGridCell68");
            this.xEditGridCell68.IsReadOnly = true;
            this.xEditGridCell68.IsUpdCol = false;
            this.xEditGridCell68.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.CellName = "dc_yn";
            this.xEditGridCell99.Col = -1;
            this.xEditGridCell99.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell99, "xEditGridCell99");
            this.xEditGridCell99.IsReadOnly = true;
            this.xEditGridCell99.IsUpdCol = false;
            this.xEditGridCell99.IsVisible = false;
            this.xEditGridCell99.Row = -1;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.CellName = "bannab_yn";
            this.xEditGridCell100.Col = -1;
            this.xEditGridCell100.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell100, "xEditGridCell100");
            this.xEditGridCell100.IsReadOnly = true;
            this.xEditGridCell100.IsUpdCol = false;
            this.xEditGridCell100.IsVisible = false;
            this.xEditGridCell100.Row = -1;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.CellName = "source_fkocs1003";
            this.xEditGridCell71.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell71.Col = -1;
            this.xEditGridCell71.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell71, "xEditGridCell71");
            this.xEditGridCell71.IsReadOnly = true;
            this.xEditGridCell71.IsUpdCol = false;
            this.xEditGridCell71.IsVisible = false;
            this.xEditGridCell71.Row = -1;
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.CellName = "fkocs1003";
            this.xEditGridCell72.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell72.Col = -1;
            this.xEditGridCell72.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell72, "xEditGridCell72");
            this.xEditGridCell72.IsReadOnly = true;
            this.xEditGridCell72.IsVisible = false;
            this.xEditGridCell72.Row = -1;
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellName = "fkout1001";
            this.xEditGridCell73.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell73.Col = -1;
            this.xEditGridCell73.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell73, "xEditGridCell73");
            this.xEditGridCell73.IsReadOnly = true;
            this.xEditGridCell73.IsUpdCol = false;
            this.xEditGridCell73.IsVisible = false;
            this.xEditGridCell73.Row = -1;
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.CellName = "sunab_date";
            this.xEditGridCell75.Col = -1;
            this.xEditGridCell75.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell75, "xEditGridCell75");
            this.xEditGridCell75.IsReadOnly = true;
            this.xEditGridCell75.IsUpdCol = false;
            this.xEditGridCell75.IsVisible = false;
            this.xEditGridCell75.Row = -1;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellName = "pattern";
            this.xEditGridCell76.Col = -1;
            this.xEditGridCell76.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell76, "xEditGridCell76");
            this.xEditGridCell76.IsReadOnly = true;
            this.xEditGridCell76.IsUpdCol = false;
            this.xEditGridCell76.IsVisible = false;
            this.xEditGridCell76.Row = -1;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.ApplyPaintingEvent = true;
            this.xEditGridCell77.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell77.CellName = "jaeryo_name";
            this.xEditGridCell77.CellWidth = 224;
            this.xEditGridCell77.Col = 3;
            this.xEditGridCell77.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell77, "xEditGridCell77");
            this.xEditGridCell77.IsReadOnly = true;
            this.xEditGridCell77.IsUpdCol = false;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellLen = 35;
            this.xEditGridCell78.CellName = "sunab_nalsu";
            this.xEditGridCell78.CellWidth = 35;
            this.xEditGridCell78.Col = -1;
            this.xEditGridCell78.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell78, "xEditGridCell78");
            this.xEditGridCell78.IsReadOnly = true;
            this.xEditGridCell78.IsUpdCol = false;
            this.xEditGridCell78.IsVisible = false;
            this.xEditGridCell78.Row = -1;
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellName = "wonyoi_yn";
            this.xEditGridCell79.Col = -1;
            this.xEditGridCell79.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell79, "xEditGridCell79");
            this.xEditGridCell79.IsReadOnly = true;
            this.xEditGridCell79.IsUpdCol = false;
            this.xEditGridCell79.IsVisible = false;
            this.xEditGridCell79.Row = -1;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellLen = 4000;
            this.xEditGridCell80.CellName = "ord_remark";
            this.xEditGridCell80.CellWidth = 66;
            this.xEditGridCell80.Col = 14;
            this.xEditGridCell80.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell80.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell80, "xEditGridCell80");
            this.xEditGridCell80.IsReadOnly = true;
            this.xEditGridCell80.IsUpdCol = false;
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellName = "act_date";
            this.xEditGridCell82.Col = -1;
            this.xEditGridCell82.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell82, "xEditGridCell82");
            this.xEditGridCell82.IsReadOnly = true;
            this.xEditGridCell82.IsUpdCol = false;
            this.xEditGridCell82.IsVisible = false;
            this.xEditGridCell82.Row = -1;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.CellName = "mayak";
            this.xEditGridCell98.Col = -1;
            this.xEditGridCell98.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell98, "xEditGridCell98");
            this.xEditGridCell98.IsReadOnly = true;
            this.xEditGridCell98.IsUpdCol = false;
            this.xEditGridCell98.IsVisible = false;
            this.xEditGridCell98.Row = -1;
            // 
            // xEditGridCell129
            // 
            this.xEditGridCell129.CellName = "tpn_joje_gubun";
            this.xEditGridCell129.Col = -1;
            this.xEditGridCell129.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell129, "xEditGridCell129");
            this.xEditGridCell129.IsReadOnly = true;
            this.xEditGridCell129.IsUpdCol = false;
            this.xEditGridCell129.IsVisible = false;
            this.xEditGridCell129.Row = -1;
            // 
            // xEditGridCell130
            // 
            this.xEditGridCell130.CellName = "ui_jusa_yn";
            this.xEditGridCell130.Col = -1;
            this.xEditGridCell130.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell130, "xEditGridCell130");
            this.xEditGridCell130.IsReadOnly = true;
            this.xEditGridCell130.IsUpdCol = false;
            this.xEditGridCell130.IsVisible = false;
            this.xEditGridCell130.Row = -1;
            // 
            // xEditGridCell131
            // 
            this.xEditGridCell131.CellName = "subul_suryang";
            this.xEditGridCell131.Col = -1;
            this.xEditGridCell131.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell131, "xEditGridCell131");
            this.xEditGridCell131.IsReadOnly = true;
            this.xEditGridCell131.IsUpdCol = false;
            this.xEditGridCell131.IsVisible = false;
            this.xEditGridCell131.Row = -1;
            // 
            // xEditGridCell132
            // 
            this.xEditGridCell132.ApplyPaintingEvent = true;
            this.xEditGridCell132.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell132.CellName = "serial_v";
            this.xEditGridCell132.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell132.CellWidth = 25;
            this.xEditGridCell132.Col = 1;
            this.xEditGridCell132.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell132, "xEditGridCell132");
            this.xEditGridCell132.IsUpdCol = false;
            this.xEditGridCell132.SuppressRepeating = true;
            this.xEditGridCell132.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell133
            // 
            this.xEditGridCell133.ApplyPaintingEvent = true;
            this.xEditGridCell133.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell133.CellName = "powder_yn";
            this.xEditGridCell133.CellWidth = 53;
            this.xEditGridCell133.Col = 10;
            this.xEditGridCell133.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell133.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell133, "xEditGridCell133");
            this.xEditGridCell133.IsReadOnly = true;
            this.xEditGridCell133.IsUpdCol = false;
            this.xEditGridCell133.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell134
            // 
            this.xEditGridCell134.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell134.CellName = "gyunbon_yn";
            this.xEditGridCell134.CellWidth = 25;
            this.xEditGridCell134.Col = -1;
            this.xEditGridCell134.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell134, "xEditGridCell134");
            this.xEditGridCell134.IsUpdCol = false;
            this.xEditGridCell134.IsVisible = false;
            this.xEditGridCell134.Row = -1;
            this.xEditGridCell134.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell135
            // 
            this.xEditGridCell135.CellName = "print_yn";
            this.xEditGridCell135.Col = -1;
            this.xEditGridCell135.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell135, "xEditGridCell135");
            this.xEditGridCell135.IsUpdatable = false;
            this.xEditGridCell135.IsUpdCol = false;
            this.xEditGridCell135.IsVisible = false;
            this.xEditGridCell135.Row = -1;
            // 
            // xEditGridCell137
            // 
            this.xEditGridCell137.CellLen = 2000;
            this.xEditGridCell137.CellName = "order_remark";
            this.xEditGridCell137.CellWidth = 118;
            this.xEditGridCell137.Col = 15;
            this.xEditGridCell137.DisplayMemoText = true;
            this.xEditGridCell137.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell137.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell137, "xEditGridCell137");
            // 
            // xEditGridCell138
            // 
            this.xEditGridCell138.CellLen = 2000;
            this.xEditGridCell138.CellName = "drg_remark";
            this.xEditGridCell138.CellWidth = 117;
            this.xEditGridCell138.Col = 16;
            this.xEditGridCell138.DisplayMemoText = true;
            this.xEditGridCell138.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell138.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell138, "xEditGridCell138");
            // 
            // xEditGridCell139
            // 
            this.xEditGridCell139.CellName = "hubal_change_yn";
            this.xEditGridCell139.CellWidth = 57;
            this.xEditGridCell139.Col = 13;
            this.xEditGridCell139.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell139.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell139, "xEditGridCell139");
            this.xEditGridCell139.IsUpdCol = false;
            // 
            // xEditGridCell140
            // 
            this.xEditGridCell140.CellName = "pharmacy";
            this.xEditGridCell140.CellWidth = 56;
            this.xEditGridCell140.Col = 11;
            this.xEditGridCell140.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell140.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell140, "xEditGridCell140");
            this.xEditGridCell140.IsUpdCol = false;
            // 
            // xEditGridCell141
            // 
            this.xEditGridCell141.CellName = "drg_pack_yn";
            this.xEditGridCell141.CellWidth = 44;
            this.xEditGridCell141.Col = 12;
            this.xEditGridCell141.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell141.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell141, "xEditGridCell141");
            // 
            // grdOrderOut
            // 
            resources.ApplyResources(this.grdOrderOut, "grdOrderOut");
            this.grdOrderOut.CallerID = '4';
            this.grdOrderOut.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell2,
            this.xEditGridCell9,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell28,
            this.xEditGridCell37,
            this.xEditGridCell69,
            this.xEditGridCell38,
            this.xEditGridCell39,
            this.xEditGridCell60});
            this.grdOrderOut.ColPerLine = 11;
            this.grdOrderOut.ColResizable = true;
            this.grdOrderOut.Cols = 12;
            this.grdOrderOut.ControlBinding = true;
            this.grdOrderOut.ExecuteQuery = null;
            this.grdOrderOut.FixedCols = 1;
            this.grdOrderOut.FixedRows = 1;
            this.grdOrderOut.HeaderHeights.Add(29);
            this.grdOrderOut.Name = "grdOrderOut";
            this.grdOrderOut.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOrderOut.ParamList")));
            this.grdOrderOut.QuerySQL = resources.GetString("grdOrderOut.QuerySQL");
            this.grdOrderOut.RowHeaderVisible = true;
            this.grdOrderOut.Rows = 2;
            this.grdOrderOut.ToolTipActive = true;
            this.grdOrderOut.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOrderOut_RowFocusChanged);
            this.grdOrderOut.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOrderOut_QueryStarting);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.ApplyPaintingEvent = true;
            this.xEditGridCell2.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell2.CellName = "drg_bunho";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell2.CellWidth = 38;
            this.xEditGridCell2.Col = 3;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.GeneralNumberFormat = true;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "bunho";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "order_date";
            this.xEditGridCell18.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell18.Col = 1;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsReadOnly = true;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "jubsu_date";
            this.xEditGridCell19.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell19.CellWidth = 85;
            this.xEditGridCell19.Col = 8;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsReadOnly = true;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.ApplyPaintingEvent = true;
            this.xEditGridCell20.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell20.CellName = "jubsu_time";
            this.xEditGridCell20.CellWidth = 45;
            this.xEditGridCell20.Col = 9;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsReadOnly = true;
            this.xEditGridCell20.IsUpdatable = false;
            this.xEditGridCell20.IsUpdCol = false;
            this.xEditGridCell20.Mask = "##:##";
            this.xEditGridCell20.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "doctor";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.IsUpdatable = false;
            this.xEditGridCell21.IsUpdCol = false;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.ApplyPaintingEvent = true;
            this.xEditGridCell22.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell22.CellLen = 30;
            this.xEditGridCell22.CellName = "doctor_name";
            this.xEditGridCell22.Col = 5;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.IsUpdatable = false;
            this.xEditGridCell22.IsUpdCol = false;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "gwa";
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
            this.xEditGridCell24.ApplyPaintingEvent = true;
            this.xEditGridCell24.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell24.CellLen = 30;
            this.xEditGridCell24.CellName = "buseo_name";
            this.xEditGridCell24.CellWidth = 132;
            this.xEditGridCell24.Col = 4;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsReadOnly = true;
            this.xEditGridCell24.IsUpdatable = false;
            this.xEditGridCell24.IsUpdCol = false;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.ApplyPaintingEvent = true;
            this.xEditGridCell25.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell25.CellName = "act_date";
            this.xEditGridCell25.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell25.CellWidth = 85;
            this.xEditGridCell25.Col = 7;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.IsUpdatable = false;
            this.xEditGridCell25.IsUpdCol = false;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.ApplyPaintingEvent = true;
            this.xEditGridCell26.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell26.CellName = "act_yn";
            this.xEditGridCell26.CellWidth = 33;
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsUpdCol = false;
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.ApplyPaintingEvent = true;
            this.xEditGridCell28.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell28.CellName = "sunab_date";
            this.xEditGridCell28.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell28.CellWidth = 85;
            this.xEditGridCell28.Col = 6;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsReadOnly = true;
            this.xEditGridCell28.IsUpdCol = false;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "chulgo_date";
            this.xEditGridCell37.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsUpdatable = false;
            this.xEditGridCell37.IsUpdCol = false;
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell69.ApplyPaintingEvent = true;
            this.xEditGridCell69.CellName = "boryu_yn";
            this.xEditGridCell69.CellWidth = 36;
            this.xEditGridCell69.Col = -1;
            this.xEditGridCell69.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell69, "xEditGridCell69");
            this.xEditGridCell69.IsReadOnly = true;
            this.xEditGridCell69.IsUpdCol = false;
            this.xEditGridCell69.IsVisible = false;
            this.xEditGridCell69.Row = -1;
            this.xEditGridCell69.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellLen = 2000;
            this.xEditGridCell38.CellName = "order_remark";
            this.xEditGridCell38.CellWidth = 170;
            this.xEditGridCell38.Col = 10;
            this.xEditGridCell38.DisplayMemoText = true;
            this.xEditGridCell38.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell38.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellLen = 2000;
            this.xEditGridCell39.CellName = "drg_remark";
            this.xEditGridCell39.CellWidth = 170;
            this.xEditGridCell39.Col = 11;
            this.xEditGridCell39.DisplayMemoText = true;
            this.xEditGridCell39.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell39.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.ApplyPaintingEvent = true;
            this.xEditGridCell60.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell60.CellName = "wonyoi_yn";
            this.xEditGridCell60.CellWidth = 52;
            this.xEditGridCell60.Col = 2;
            this.xEditGridCell60.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsReadOnly = true;
            this.xEditGridCell60.IsUpdCol = false;
            this.xEditGridCell60.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdJUSAOrderList
            // 
            resources.ApplyResources(this.grdJUSAOrderList, "grdJUSAOrderList");
            this.grdJUSAOrderList.ApplyPaintEventToAllColumn = true;
            this.grdJUSAOrderList.CallerID = '2';
            this.grdJUSAOrderList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell57,
            this.xEditGridCell101,
            this.xEditGridCell102,
            this.xEditGridCell103,
            this.xEditGridCell104,
            this.xEditGridCell105,
            this.xEditGridCell106,
            this.xEditGridCell107,
            this.xEditGridCell108,
            this.xEditGridCell109,
            this.xEditGridCell110,
            this.xEditGridCell111,
            this.xEditGridCell112,
            this.xEditGridCell113,
            this.xEditGridCell114,
            this.xEditGridCell115,
            this.xEditGridCell116,
            this.xEditGridCell117,
            this.xEditGridCell118,
            this.xEditGridCell119,
            this.xEditGridCell120,
            this.xEditGridCell121,
            this.xEditGridCell122,
            this.xEditGridCell124,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell125,
            this.xEditGridCell128,
            this.xEditGridCell13,
            this.xEditGridCell14});
            this.grdJUSAOrderList.ColPerLine = 18;
            this.grdJUSAOrderList.ColResizable = true;
            this.grdJUSAOrderList.Cols = 19;
            this.grdJUSAOrderList.ControlBinding = true;
            this.grdJUSAOrderList.ExecuteQuery = null;
            this.grdJUSAOrderList.FixedCols = 1;
            this.grdJUSAOrderList.FixedRows = 1;
            this.grdJUSAOrderList.HeaderHeights.Add(41);
            this.grdJUSAOrderList.Name = "grdJUSAOrderList";
            this.grdJUSAOrderList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdJUSAOrderList.ParamList")));
            this.grdJUSAOrderList.QuerySQL = resources.GetString("grdJUSAOrderList.QuerySQL");
            this.grdJUSAOrderList.RowHeaderVisible = true;
            this.grdJUSAOrderList.Rows = 2;
            this.grdJUSAOrderList.ToolTipActive = true;
            this.grdJUSAOrderList.UseDefaultTransaction = false;
            this.grdJUSAOrderList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdJUSAOrderList_QueryStarting);
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellName = "order_date";
            this.xEditGridCell57.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell57.CellWidth = 77;
            this.xEditGridCell57.Col = 11;
            this.xEditGridCell57.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell57, "xEditGridCell57");
            this.xEditGridCell57.IsReadOnly = true;
            this.xEditGridCell57.IsUpdCol = false;
            this.xEditGridCell57.SuppressRepeating = true;
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.CellName = "group_ser";
            this.xEditGridCell101.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell101.CellWidth = 29;
            this.xEditGridCell101.Col = 10;
            this.xEditGridCell101.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell101, "xEditGridCell101");
            this.xEditGridCell101.IsReadOnly = true;
            this.xEditGridCell101.IsUpdCol = false;
            this.xEditGridCell101.SuppressRepeating = true;
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.CellName = "jaeryo_code";
            this.xEditGridCell102.CellWidth = 77;
            this.xEditGridCell102.Col = 3;
            this.xEditGridCell102.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell102, "xEditGridCell102");
            this.xEditGridCell102.IsReadOnly = true;
            this.xEditGridCell102.IsUpdCol = false;
            this.xEditGridCell102.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.CellName = "jaeryo_name";
            this.xEditGridCell103.CellWidth = 179;
            this.xEditGridCell103.Col = 4;
            this.xEditGridCell103.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell103, "xEditGridCell103");
            this.xEditGridCell103.IsReadOnly = true;
            this.xEditGridCell103.IsUpdCol = false;
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellName = "ord_suryang";
            this.xEditGridCell104.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell104.CellWidth = 24;
            this.xEditGridCell104.Col = 5;
            this.xEditGridCell104.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell104, "xEditGridCell104");
            this.xEditGridCell104.IsReadOnly = true;
            this.xEditGridCell104.IsUpdCol = false;
            // 
            // xEditGridCell105
            // 
            this.xEditGridCell105.CellName = "dv_time";
            this.xEditGridCell105.CellWidth = 22;
            this.xEditGridCell105.Col = -1;
            this.xEditGridCell105.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell105, "xEditGridCell105");
            this.xEditGridCell105.IsReadOnly = true;
            this.xEditGridCell105.IsUpdCol = false;
            this.xEditGridCell105.IsVisible = false;
            this.xEditGridCell105.Row = -1;
            this.xEditGridCell105.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.CellName = "dv";
            this.xEditGridCell106.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell106.CellWidth = 22;
            this.xEditGridCell106.Col = 6;
            this.xEditGridCell106.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell106, "xEditGridCell106");
            this.xEditGridCell106.IsReadOnly = true;
            this.xEditGridCell106.IsUpdCol = false;
            // 
            // xEditGridCell107
            // 
            this.xEditGridCell107.CellName = "nalsu";
            this.xEditGridCell107.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell107.CellWidth = 22;
            this.xEditGridCell107.Col = -1;
            this.xEditGridCell107.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell107, "xEditGridCell107");
            this.xEditGridCell107.IsReadOnly = true;
            this.xEditGridCell107.IsUpdCol = false;
            this.xEditGridCell107.IsVisible = false;
            this.xEditGridCell107.Row = -1;
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.CellName = "order_danui";
            this.xEditGridCell108.CellWidth = 50;
            this.xEditGridCell108.Col = -1;
            this.xEditGridCell108.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell108, "xEditGridCell108");
            this.xEditGridCell108.IsReadOnly = true;
            this.xEditGridCell108.IsUpdCol = false;
            this.xEditGridCell108.IsVisible = false;
            this.xEditGridCell108.Row = -1;
            // 
            // xEditGridCell109
            // 
            this.xEditGridCell109.CellName = "danui_name";
            this.xEditGridCell109.CellWidth = 49;
            this.xEditGridCell109.Col = 7;
            this.xEditGridCell109.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell109, "xEditGridCell109");
            this.xEditGridCell109.IsReadOnly = true;
            this.xEditGridCell109.IsUpdCol = false;
            // 
            // xEditGridCell110
            // 
            this.xEditGridCell110.CellName = "bogyong_code";
            this.xEditGridCell110.CellWidth = 197;
            this.xEditGridCell110.Col = -1;
            this.xEditGridCell110.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell110, "xEditGridCell110");
            this.xEditGridCell110.IsReadOnly = true;
            this.xEditGridCell110.IsUpdCol = false;
            this.xEditGridCell110.IsVisible = false;
            this.xEditGridCell110.Row = -1;
            // 
            // xEditGridCell111
            // 
            this.xEditGridCell111.CellName = "bogyong_name";
            this.xEditGridCell111.CellWidth = 72;
            this.xEditGridCell111.Col = 8;
            this.xEditGridCell111.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell111, "xEditGridCell111");
            this.xEditGridCell111.IsReadOnly = true;
            this.xEditGridCell111.IsUpdCol = false;
            this.xEditGridCell111.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell112
            // 
            this.xEditGridCell112.CellName = "powder_yn";
            this.xEditGridCell112.CellWidth = 25;
            this.xEditGridCell112.Col = 15;
            this.xEditGridCell112.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell112.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell112, "xEditGridCell112");
            this.xEditGridCell112.IsReadOnly = true;
            this.xEditGridCell112.IsUpdCol = false;
            this.xEditGridCell112.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell113
            // 
            this.xEditGridCell113.CellName = "remark";
            this.xEditGridCell113.CellWidth = 50;
            this.xEditGridCell113.Col = 14;
            this.xEditGridCell113.DisplayMemoText = true;
            this.xEditGridCell113.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell113.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell113, "xEditGridCell113");
            this.xEditGridCell113.IsReadOnly = true;
            this.xEditGridCell113.IsUpdCol = false;
            // 
            // xEditGridCell114
            // 
            this.xEditGridCell114.CellName = "dv_1";
            this.xEditGridCell114.Col = -1;
            this.xEditGridCell114.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell114, "xEditGridCell114");
            this.xEditGridCell114.IsReadOnly = true;
            this.xEditGridCell114.IsUpdCol = false;
            this.xEditGridCell114.IsVisible = false;
            this.xEditGridCell114.Row = -1;
            // 
            // xEditGridCell115
            // 
            this.xEditGridCell115.CellName = "dv_2";
            this.xEditGridCell115.Col = -1;
            this.xEditGridCell115.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell115, "xEditGridCell115");
            this.xEditGridCell115.IsReadOnly = true;
            this.xEditGridCell115.IsUpdCol = false;
            this.xEditGridCell115.IsVisible = false;
            this.xEditGridCell115.Row = -1;
            // 
            // xEditGridCell116
            // 
            this.xEditGridCell116.CellName = "dv_3";
            this.xEditGridCell116.Col = -1;
            this.xEditGridCell116.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell116, "xEditGridCell116");
            this.xEditGridCell116.IsReadOnly = true;
            this.xEditGridCell116.IsUpdCol = false;
            this.xEditGridCell116.IsVisible = false;
            this.xEditGridCell116.Row = -1;
            // 
            // xEditGridCell117
            // 
            this.xEditGridCell117.CellName = "dv_4";
            this.xEditGridCell117.Col = -1;
            this.xEditGridCell117.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell117, "xEditGridCell117");
            this.xEditGridCell117.IsReadOnly = true;
            this.xEditGridCell117.IsUpdCol = false;
            this.xEditGridCell117.IsVisible = false;
            this.xEditGridCell117.Row = -1;
            // 
            // xEditGridCell118
            // 
            this.xEditGridCell118.CellName = "dv_5";
            this.xEditGridCell118.Col = -1;
            this.xEditGridCell118.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell118, "xEditGridCell118");
            this.xEditGridCell118.IsReadOnly = true;
            this.xEditGridCell118.IsUpdCol = false;
            this.xEditGridCell118.IsVisible = false;
            this.xEditGridCell118.Row = -1;
            // 
            // xEditGridCell119
            // 
            this.xEditGridCell119.CellName = "hubal_change_yn";
            this.xEditGridCell119.CellWidth = 25;
            this.xEditGridCell119.Col = 18;
            this.xEditGridCell119.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell119.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell119, "xEditGridCell119");
            this.xEditGridCell119.IsReadOnly = true;
            this.xEditGridCell119.IsUpdCol = false;
            this.xEditGridCell119.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell120
            // 
            this.xEditGridCell120.CellName = "pharmacy";
            this.xEditGridCell120.CellWidth = 30;
            this.xEditGridCell120.Col = 16;
            this.xEditGridCell120.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell120.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell120, "xEditGridCell120");
            this.xEditGridCell120.IsReadOnly = true;
            this.xEditGridCell120.IsUpdCol = false;
            this.xEditGridCell120.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell121
            // 
            this.xEditGridCell121.CellName = "drg_pack_yn";
            this.xEditGridCell121.CellWidth = 25;
            this.xEditGridCell121.Col = 17;
            this.xEditGridCell121.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell121.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell121, "xEditGridCell121");
            this.xEditGridCell121.IsReadOnly = true;
            this.xEditGridCell121.IsUpdCol = false;
            this.xEditGridCell121.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell122
            // 
            this.xEditGridCell122.CellName = "jusa";
            this.xEditGridCell122.CellWidth = 84;
            this.xEditGridCell122.Col = 9;
            this.xEditGridCell122.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell122, "xEditGridCell122");
            this.xEditGridCell122.IsReadOnly = true;
            this.xEditGridCell122.IsUpdCol = false;
            // 
            // xEditGridCell124
            // 
            this.xEditGridCell124.CellName = "suname";
            this.xEditGridCell124.Col = 1;
            this.xEditGridCell124.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell124, "xEditGridCell124");
            this.xEditGridCell124.IsUpdCol = false;
            this.xEditGridCell124.SuppressRepeating = true;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 1000;
            this.xEditGridCell7.CellName = "order_remark";
            this.xEditGridCell7.CellWidth = 50;
            this.xEditGridCell7.Col = 12;
            this.xEditGridCell7.DisplayMemoText = true;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 1000;
            this.xEditGridCell8.CellName = "drg_remark";
            this.xEditGridCell8.CellWidth = 50;
            this.xEditGridCell8.Col = 13;
            this.xEditGridCell8.DisplayMemoText = true;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // xEditGridCell125
            // 
            this.xEditGridCell125.CellName = "drg_bunho";
            this.xEditGridCell125.CellWidth = 40;
            this.xEditGridCell125.Col = 2;
            this.xEditGridCell125.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell125, "xEditGridCell125");
            this.xEditGridCell125.SuppressRepeating = true;
            // 
            // xEditGridCell128
            // 
            this.xEditGridCell128.CellName = "jubsu_date";
            this.xEditGridCell128.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell128.Col = -1;
            this.xEditGridCell128.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell128, "xEditGridCell128");
            this.xEditGridCell128.IsVisible = false;
            this.xEditGridCell128.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "bunho";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "fkocs2003";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xLabel8
            // 
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.BackColor = IHIS.Framework.XColor.XListBoxAlternatingItemBackColor;
            this.xLabel8.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD2;
            this.xLabel8.BorderColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.xLabel8.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel8.GradientEndColor = IHIS.Framework.XColor.XTreeViewBackColor;
            this.xLabel8.Name = "xLabel8";
            // 
            // xPanel4
            // 
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.Controls.Add(this.grdOrderOut);
            this.xPanel4.Controls.Add(this.grdOrder);
            this.xPanel4.Controls.Add(this.xLabel7);
            this.xPanel4.DrawBorder = true;
            this.xPanel4.Name = "xPanel4";
            // 
            // xLabel7
            // 
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.BackColor = IHIS.Framework.XColor.XListBoxAlternatingItemBackColor;
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD2;
            this.xLabel7.BorderColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.xLabel7.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel7.GradientEndColor = IHIS.Framework.XColor.XTreeViewBackColor;
            this.xLabel7.Name = "xLabel7";
            // 
            // xPanel5
            // 
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.BackColor = IHIS.Framework.XColor.XListBoxAlternatingItemBackColor;
            this.xPanel5.Controls.Add(this.cboInOutGubun);
            this.xPanel5.Controls.Add(this.xLabel9);
            this.xPanel5.Controls.Add(this.xLabel6);
            this.xPanel5.Controls.Add(this.dtpToDate);
            this.xPanel5.Controls.Add(this.dtpFromDate);
            this.xPanel5.Controls.Add(this.xLabel5);
            this.xPanel5.Controls.Add(this.xLabel3);
            this.xPanel5.Controls.Add(this.paBox);
            this.xPanel5.DrawBorder = true;
            this.xPanel5.Name = "xPanel5";
            // 
            // cboInOutGubun
            // 
            resources.ApplyResources(this.cboInOutGubun, "cboInOutGubun");
            this.cboInOutGubun.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem3,
            this.xComboItem4});
            this.cboInOutGubun.Name = "cboInOutGubun";
            this.cboInOutGubun.SelectedIndexChanged += new System.EventHandler(this.cboInOutGubun_SelectedIndexChanged);
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ValueItem = "I";
            // 
            // xComboItem4
            // 
            resources.ApplyResources(this.xComboItem4, "xComboItem4");
            this.xComboItem4.ValueItem = "O";
            // 
            // xLabel9
            // 
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.BackColor = IHIS.Framework.XColor.XListBoxBackColor;
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.BorderColor = IHIS.Framework.XColor.XGridSelectedCellBackColor;
            this.xLabel9.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel9.GradientEndColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.xLabel9.Name = "xLabel9";
            // 
            // xLabel6
            // 
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.BackColor = IHIS.Framework.XColor.XListBoxAlternatingItemBackColor;
            this.xLabel6.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel6.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel6.Name = "xLabel6";
            // 
            // dtpToDate
            // 
            resources.ApplyResources(this.dtpToDate, "dtpToDate");
            this.dtpToDate.IsVietnameseYearType = false;
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpDate_DataValidating);
            // 
            // dtpFromDate
            // 
            resources.ApplyResources(this.dtpFromDate, "dtpFromDate");
            this.dtpFromDate.IsVietnameseYearType = false;
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpDate_DataValidating);
            // 
            // xLabel5
            // 
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.BackColor = IHIS.Framework.XColor.XListBoxBackColor;
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.BorderColor = IHIS.Framework.XColor.XGridSelectedCellBackColor;
            this.xLabel5.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.xLabel5.Name = "xLabel5";
            // 
            // layPaComment
            // 
            this.layPaComment.CallerID = '4';
            this.layPaComment.ExecuteQuery = null;
            this.layPaComment.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1,
            this.singleLayoutItem2});
            this.layPaComment.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layPaComment.ParamList")));
            this.layPaComment.QuerySQL = "SELECT ORDER_REMARK\r\n     , DRG_REMARK\r\n  FROM DRG9041\r\n WHERE BUNHO = :f_bunho\r\n" +
    "   AND HOSP_CODE = :f_hosp_code";
            this.layPaComment.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layPaComment_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.BindControl = this.txtPaOrdRemark;
            this.singleLayoutItem1.DataName = "pa_ord_remark";
            this.singleLayoutItem1.IsUpdItem = true;
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.BindControl = this.txtPaDrgRemark;
            this.singleLayoutItem2.DataName = "pa_drg_remark";
            this.singleLayoutItem2.IsUpdItem = true;
            // 
            // DRG9040U01
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel4);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel5);
            this.Name = "DRG9040U01";
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).EndInit();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderListOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJUSAOrderList)).EndInit();
            this.xPanel4.ResumeLayout(false);
            this.xPanel5.ResumeLayout(false);
            this.xPanel5.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Common Properties
        private string mHospCode = EnvironInfo.HospCode;
        private string mInOutGubun = "O";
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (this.OpenParam != null)
            {
                if (this.OpenParam.Contains("bunho"))
                    this.paBox.SetPatientID(this.OpenParam["bunho"].ToString());

                if (this.OpenParam.Contains("in_out_gubun"))
                    this.mInOutGubun = this.OpenParam["in_out_gubun"].ToString();
                
                this.cboInOutGubun.SetDataValue(this.mInOutGubun);

                if (this.OpenParam.Contains("from_date"))
                    this.dtpFromDate.SetDataValue(this.OpenParam["from_date"]);
                else
                    this.dtpFromDate.SetDataValue(EnvironInfo.GetSysDate());

                if (this.OpenParam.Contains("to_date"))
                    this.dtpToDate.SetDataValue(this.OpenParam["to_date"]);
                else
                    this.dtpToDate.SetDataValue(EnvironInfo.GetSysDate());

                layPaComment.QueryLayout();
                
                screenQuery();

                return;
            }
            else
            {
                this.cboInOutGubun.SetDataValue("O");
                this.dtpFromDate.SetDataValue(EnvironInfo.GetSysDate());
                this.dtpToDate.SetDataValue(EnvironInfo.GetSysDate());
            }
        }
        #endregion

        #region 버튼리스트 클릭 이벤트
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    try
                    {
                        layPaComment.QueryLayout();
                        if (mInOutGubun == "I")
                        {
                            if (!grdOrder.QueryLayout(false)) throw new Exception(Service.ErrFullMsg);
                        }
                        else
                        {
                            if (!grdOrderOut.QueryLayout(false)) throw new Exception(Service.ErrFullMsg);
                        }
                    }
                    catch (Exception xe)
                    {
                        XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace, "照会エラー", MessageBoxIcon.Hand);
                        return;
                    }
                    break;
                case FunctionType.Update:
                    e.IsBaseCall = false;

                    try
                    {
                        /*Service.BeginTransaction();
                        if (!grdOrder.SaveLayout()) throw new Exception(Service.ErrFullMsg);
                        if (!grdJUSAOrderList.SaveLayout()) throw new Exception(Service.ErrFullMsg);
                        if (!grdOrderList.SaveLayout()) throw new Exception(Service.ErrFullMsg);
                        if (!grdOrderOut.SaveLayout()) throw new Exception(Service.ErrFullMsg);
                        if (!grdOrderListOut.SaveLayout()) throw new Exception(Service.ErrFullMsg);
                        if (!SavePaComment()) throw new Exception(Service.ErrFullMsg);*/

                        if (DRG9040U01SaveLayout())
                        {
                            e.IsBaseCall = true;
                            XMessageBox.Show(Resources.MSG_1, Resources.MSG_Caption_1, MessageBoxIcon.Information);
                            btnList.PerformClick(FunctionType.Query);
                        }
                        else
                        {
                            XMessageBox.Show(Resources.MSG_2, Resources.MSG_Caption_1, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception xe)
                    {
//                        Service.RollbackTransaction();
                        XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace, "保存エラー", MessageBoxIcon.Hand);
                        return;
                    }

//                    Service.CommitTransaction();
                    break;
            }
        }
        #endregion

        #region 그리드별 로우 포커스 체인지 이벤트
        private void grdOrder_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            /* 기존 로직 막음(허상열위원 작성인지, 김용건위원 작성인지 알수 없슴)
             * 마감구분으로 주사 또는 내복 그리드를 보여주도록 되어 있는 데, 
             * 1. 아래 로직의 마감구분이 맞지 않음.
             * 2. 병동응급의 경우는 내복/외용/주사가 다 존재하는 데 어케 보일려구 했는 지 모르겠슴
             * 테스트가 되었는 지 어떤 개념으로 로직이 구현되었는 지 모르겠슴
            string magam_bunryu = "1";
            string magam_gubun = "";

            magam_gubun = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "magam_gubun");

            //내복, 외용
            if (magam_gubun == "11")
            {
                magam_bunryu = "1";
                dsvOrderList.MOutputLayout = grdOrderList;
                grdOrderList.Visible = true;
                grdJUSAOrderList.Visible = false;
            }
            //주사
            if ((magam_gubun == "31") || (magam_gubun == "32"))
            {
                magam_bunryu = "2";
                dsvOrderList.MOutputLayout = grdJUSAOrderList;
                grdOrderList.Visible = false;
                grdJUSAOrderList.Visible = true;
            }
            */

            /* 기존 그리드를 변경하지 않는 조건으로 grdOrder에 bunryu1 정보를 가져와서
             * 해당 정보로 주사 또는 내복 그리드를 보여주도록 조정함.
             * 약국 너무 에러가 많다.
             */
            string magam_bunryu = "1";
            string bunryu1 = "";

            bunryu1 = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunryu1");

            //주사
            if (bunryu1 == "4")
            {
                magam_bunryu = "2";
                grdOrderList.Visible = false;
                grdJUSAOrderList.Visible = true;
                grdJUSAOrderList.SetBindVarValue("f_magam_bunryu", magam_bunryu);
                if (!grdJUSAOrderList.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
            }
            else
            {
                magam_bunryu = "1";
                grdOrderList.Visible = true;
                grdJUSAOrderList.Visible = false;
                grdOrderList.SetBindVarValue("f_magam_bunryu", magam_bunryu);
                if (!grdOrderList.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
            }
        }

        private void grdOrderOut_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            grdOrderListOut.QueryLayout(false);
        }
        #endregion

        #region 환자번호 선택시
        private void paBox_PatientSelected(object sender, EventArgs e)
        {
            if (mInOutGubun == "I")
            {
                if (!grdOrder.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
            }
            else
            {
                if (!grdOrderOut.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
            }

        }
        #endregion

        #region 각 그리드에 바인드변수 설정
        private void grdOrder_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOrder.SetBindVarValue("f_bunho", paBox.BunHo);
            grdOrder.SetBindVarValue("f_hosp_code", mHospCode);
            grdOrder.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue());
            grdOrder.SetBindVarValue("f_to_date", dtpToDate.GetDataValue());
        }

        private void grdJUSAOrderList_QueryStarting(object sender, CancelEventArgs e)
        {
            grdJUSAOrderList.SetBindVarValue("f_jubsu_date", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jubsu_date"));
            grdJUSAOrderList.SetBindVarValue("f_drg_bunho", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "drg_bunho"));
            grdJUSAOrderList.SetBindVarValue("f_hosp_code", mHospCode);
        }

        private void grdOrderList_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOrderList.SetBindVarValue("f_jubsu_date", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jubsu_date"));
            grdOrderList.SetBindVarValue("f_drg_bunho", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "drg_bunho"));
            grdOrderList.SetBindVarValue("f_hosp_code", mHospCode);
        }

        private void grdOrderOut_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOrderOut.SetBindVarValue("f_bunho", paBox.BunHo);
            grdOrderOut.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue());
            grdOrderOut.SetBindVarValue("f_to_date", dtpToDate.GetDataValue());
        }

        private void grdOrderListOut_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOrderListOut.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdOrderListOut.SetBindVarValue("f_order_date", grdOrderOut.GetItemString(grdOrderOut.CurrentRowNumber, "order_date"));
            grdOrderListOut.SetBindVarValue("f_drg_bunho", grdOrderOut.GetItemString(grdOrderOut.CurrentRowNumber, "drg_bunho"));
            grdOrderListOut.SetBindVarValue("f_bunho", grdOrderOut.GetItemString(grdOrderOut.CurrentRowNumber, "bunho"));
        }
        #endregion

        #region Connect to cloud service

        /// <summary>
        /// ExecuteQueryGrdJUSAOrderListInfo
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdJUSAOrderListInfo(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            DRG9040U01GrdJUSAOrderListArgs vDRG9040U01GrdJUSAOrderListArgs = new DRG9040U01GrdJUSAOrderListArgs();
            vDRG9040U01GrdJUSAOrderListArgs.JubsuDate = bc["f_jubsu_date"] != null ? bc["f_jubsu_date"].VarValue : "";
            vDRG9040U01GrdJUSAOrderListArgs.DrgBunho = bc["f_drg_bunho"] != null ? bc["f_drg_bunho"].VarValue : "";
            vDRG9040U01GrdJUSAOrderListArgs.MagamBunryu = bc["f_magam_bunryu"] != null ? bc["f_magam_bunryu"].VarValue : "";
            DRG9040U01GrdJUSAOrderListResult result = CloudService.Instance.Submit<DRG9040U01GrdJUSAOrderListResult, DRG9040U01GrdJUSAOrderListArgs>(vDRG9040U01GrdJUSAOrderListArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (DRG9040U01GrdJUSAOrderListInfo item in result.GrdOrderListInfo)
                {
                    object[] objects = 
				{ 
					item.OrderDate, 
					item.GroupSer, 
					item.JaeryoCode, 
					item.JaeryoName, 
					item.OrdSuryang, 
					item.DvTime, 
					item.Dv, 
					item.Nalsu, 
					item.OrderDanui, 
					item.DanuiName, 
					item.BogyongCode, 
					item.BogyongName, 
					item.PowderYn, 
					item.Remark, 
					item.Dv1, 
					item.Dv2, 
					item.Dv3, 
					item.Dv4, 
					item.Dv5, 
					item.HubalChangeYn, 
					item.Pharmacy, 
					item.DrgPackYn, 
					item.CodeName, 
					item.Suname, 
					item.OrderRemark, 
					item.DrgRemark, 
					item.DrgBunho, 
					item.JubsuDate, 
					item.Bunho, 
					item.Fkocs2003
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryGrdOrderListOutInfo
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdOrderListOutInfo(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            DRG9040U01GrdOrderListOutArgs vDRG9040U01GrdOrderListOutArgs = new DRG9040U01GrdOrderListOutArgs();
            vDRG9040U01GrdOrderListOutArgs.OrderDate = bc["f_order_date"] != null ? bc["f_order_date"].VarValue : "";
            vDRG9040U01GrdOrderListOutArgs.DrgBunho = bc["f_drg_bunho"] != null ? bc["f_drg_bunho"].VarValue : "";
            vDRG9040U01GrdOrderListOutArgs.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            DRG9040U01GrdOrderListOutResult result = CloudService.Instance.Submit<DRG9040U01GrdOrderListOutResult, DRG9040U01GrdOrderListOutArgs>(vDRG9040U01GrdOrderListOutArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (DRG9040U01GrdOrderListOutInfo item in result.GrdOrderListOutInfo)
                {
                    object[] objects = 
				{ 
					item.Bunho, 
					item.DrgBunho, 
					item.NaewonDate, 
					item.GroupSer, 
					item.JubsuDate, 
					item.OrderDate, 
					item.JaeryoCode, 
					item.Nalsu, 
					item.Divide, 
					item.OrdSuryang, 
					item.OrderSuryang, 
					item.OrderDanui, 
					item.SubulDanui, 
					item.GroupYn, 
					item.JaeryoGubun, 
					item.BogyongCode, 
					item.BogyongName, 
					item.CautionName, 
					item.CautionCode, 
					item.MixYn, 
					item.AtcYn, 
					item.Dv, 
					item.DvTime, 
					item.DcYn, 
					item.BannabYn, 
					item.SourceFkocs1003, 
					item.Fkocs1003, 
					item.Fkout1001, 
					item.SunabDate, 
					item.Pattern, 
					item.JaeryoName, 
					item.SunabNalsu, 
					item.WonyoiYn, 
					item.Remark, 
					item.ActDate, 
					item.Mayak, 
					item.TpnJojeGubun, 
					item.UiJusaYn, 
					item.SubulSuryang, 
					item.SerialV, 
					item.PowderYn, 
					item.GyunbonYn, 
					item.PrintYn, 
					item.OrderRemark, 
					item.DrgRemark, 
					item.HubakChangeYn, 
					item.Pharmacy, 
					item.DrgPackYn
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryGrdOrderListInfo
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdOrderListInfo(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            DRG9040U01GrdOrderListArgs vDRG9040U01GrdOrderListArgs = new DRG9040U01GrdOrderListArgs();
            vDRG9040U01GrdOrderListArgs.JubsuDate = bc["f_jubsu_date"] != null ? bc["f_jubsu_date"].VarValue : "";
            vDRG9040U01GrdOrderListArgs.DrgBunho = bc["f_drg_bunho"] != null ? bc["f_drg_bunho"].VarValue : "";
            vDRG9040U01GrdOrderListArgs.MagamBunryu = bc["f_magam_bunryu"] != null ? bc["f_magam_bunryu"].VarValue : "";
            DRG9040U01GrdOrderListResult result = CloudService.Instance.Submit<DRG9040U01GrdOrderListResult, DRG9040U01GrdOrderListArgs>(vDRG9040U01GrdOrderListArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (DRG9040U01GrdOrderListInfo item in result.GrdOrderListInfo)
                {
                    object[] objects = 
				{ 
					item.OrderDate, 
					item.GroupSer, 
					item.JaeryoCode, 
					item.JaeryoName, 
					item.OrdSuryang, 
					item.DvTime, 
					item.Dv, 
					item.Nalsu, 
					item.OrderDanui, 
					item.DanuiName, 
					item.BogyongCode, 
					item.BogyongName, 
					item.PowderYn, 
					item.Remark, 
					item.Dv1, 
					item.Dv2, 
					item.Dv3, 
					item.Dv4, 
					item.Dv5, 
					item.HubalChangeYn, 
					item.Pharmacy, 
					item.DrgPackYn, 
					item.Jusa, 
					item.Suname, 
					item.OrderRemark, 
					item.DrgRemark, 
					item.DrgBunho, 
					item.JubsuDate, 
					item.Bunho, 
					item.Fkocs2003
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryGrdOrderOutInfo
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdOrderOutInfo(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            DRG9040U01GrdOrderOutArgs vDRG9040U01GrdOrderOutArgs = new DRG9040U01GrdOrderOutArgs();
            vDRG9040U01GrdOrderOutArgs.FromDate = bc["f_from_date"] != null ? bc["f_from_date"].VarValue : "";
            vDRG9040U01GrdOrderOutArgs.ToDate = bc["f_to_date"] != null ? bc["f_to_date"].VarValue : "";
            vDRG9040U01GrdOrderOutArgs.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            DRG9040U01GrdOrderOutResult result = CloudService.Instance.Submit<DRG9040U01GrdOrderOutResult, DRG9040U01GrdOrderOutArgs>(vDRG9040U01GrdOrderOutArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (DRG9040U01GrdOrderOutInfo item in result.GrdOrderOutInfo)
                {
                    object[] objects = 
				{ 
					item.DrgBunho, 
					item.Bunho, 
					item.OrderDate, 
					item.JubsuDate, 
					item.JubsuTime, 
					item.Doctor, 
					item.DoctorName, 
					item.Gwa, 
					item.BuseoName, 
					item.ActDate, 
					item.ActYn, 
					item.SunabDate, 
					item.ChulgoDate, 
					item.BoryuYn, 
					item.OrderRemark, 
					item.DrgRemark, 
					item.WonyoiOrderYn
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryGrdOrderInfo
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdOrderInfo(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            DRG9040U01GrdOrderArgs vDRG9040U01GrdOrderArgs = new DRG9040U01GrdOrderArgs();
            vDRG9040U01GrdOrderArgs.FromDate = bc["f_from_date"] != null ? bc["f_from_date"].VarValue : "";
            vDRG9040U01GrdOrderArgs.ToDate = bc["f_to_date"] != null ? bc["f_to_date"].VarValue : "";
            vDRG9040U01GrdOrderArgs.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            DRG9040U01GrdOrderResult result = CloudService.Instance.Submit<DRG9040U01GrdOrderResult, DRG9040U01GrdOrderArgs>(vDRG9040U01GrdOrderArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (DRG9040U01GrdOrderInfo item in result.GrdOrderInfo)
                {
                    object[] objects = 
				{ 
					item.JubsuDate, 
					item.DrgBunho, 
					item.Bunho, 
					item.OrderDate, 
					item.Doctor, 
					item.DoctorName, 
					item.Gwa, 
					item.BuseoName, 
					item.OrderRemark, 
					item.DrgRemark, 
					item.MagamGubun, 
					item.Bunryu1
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// Save data 
        /// </summary>
        /// <returns></returns>
        private bool DRG9040U01SaveLayout()
        {
            DRG9040U01SaveLayoutArgs args = new DRG9040U01SaveLayoutArgs();
            args.GrdOrderInfo = CreateDataForSaveGrdOrder();
            args.GrdJusaOrderInfo = CreateDataForSaveGrdJUSAOrderList();
            args.GrdOrderListInfo = CreateDataForSaveGrdOrderList();
            args.GrdOrderOutInfo = CreateDataForSaveGrdOrderOut();
            args.GrdOrderListOutInfo = CreateDataForSaveGrdOrderListOut();

            txtPaDrgRemark.AcceptData();
            txtPaOrdRemark.AcceptData();
            args.Bunho = paBox.BunHo;
            args.Drg9041OcsRemark = txtPaOrdRemark.GetDataValue();
            args.Drg9041DrgRemark = txtPaDrgRemark.GetDataValue();
            args.UserId = UserInfo.UserID;
            UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, DRG9040U01SaveLayoutArgs>(args);
            if (updateResult == null || updateResult.ExecutionStatus != ExecutionStatus.Success ||
                updateResult.Result == false)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// CreateDataForSaveGrdOrder
        /// </summary>
        /// <returns></returns>
        private List<DRG9040U01GrdOrderInfo> CreateDataForSaveGrdOrder()
        {
            List<DRG9040U01GrdOrderInfo> listgrGrdOrderInfo = new List<DRG9040U01GrdOrderInfo>();
            for (int i = 0; i < grdOrder.RowCount; i++)
            {
                if (grdOrder.GetRowState(i) == DataRowState.Modified)
                {
                    DRG9040U01GrdOrderInfo grdOrderInfo = new DRG9040U01GrdOrderInfo();
                    grdOrderInfo.JubsuDate = grdOrder.GetItemString(i, "jubsu_date");
                    grdOrderInfo.OrderDate = grdOrder.GetItemString(i, "order_date");
                    grdOrderInfo.OrderRemark = grdOrder.GetItemString(i, "order_remark");
                    grdOrderInfo.DrgRemark = grdOrder.GetItemString(i, "drg_remark");
                    grdOrderInfo.DrgBunho = grdOrder.GetItemString(i, "drg_bunho");
                    grdOrderInfo.Bunho = grdOrder.GetItemString(i, "bunho");
                    grdOrderInfo.DataRowState = DataRowState.Modified.ToString();

                    listgrGrdOrderInfo.Add(grdOrderInfo);
                }
            }
            return listgrGrdOrderInfo;
        }

        /// <summary>
        /// CreateDataForSaveGrdJUSAOrderList
        /// </summary>
        /// <returns></returns>
        private List<DRG9040U01GrdJUSAOrderListInfo> CreateDataForSaveGrdJUSAOrderList()
        {
            List<DRG9040U01GrdJUSAOrderListInfo>  listGrdJusaOrderListInfo = new List<DRG9040U01GrdJUSAOrderListInfo>();
            for (int i = 0; i < grdJUSAOrderList.RowCount; i++)
            {
                if (grdJUSAOrderList.GetRowState(i) == DataRowState.Modified)
                {
                    DRG9040U01GrdJUSAOrderListInfo grdJusaOrderListInfo = new DRG9040U01GrdJUSAOrderListInfo();
                    grdJusaOrderListInfo.Fkocs2003 = grdJUSAOrderList.GetItemString(i, "fkocs2003");
                    grdJusaOrderListInfo.OrderRemark = grdJUSAOrderList.GetItemString(i, "order_remark");
                    grdJusaOrderListInfo.DrgRemark = grdJUSAOrderList.GetItemString(i, "drg_remark");
                    grdJusaOrderListInfo.Bunho = grdJUSAOrderList.GetItemString(i, "bunho");
                    grdJusaOrderListInfo.DataRowState = DataRowState.Modified.ToString();

                    listGrdJusaOrderListInfo.Add(grdJusaOrderListInfo);
                }
            }
            return listGrdJusaOrderListInfo;
        }

        /// <summary>
        /// CreateDataForGrdOrderList
        /// </summary>
        /// <returns></returns>
        private List<DRG9040U01GrdOrderListInfo> CreateDataForSaveGrdOrderList()
        {
            List<DRG9040U01GrdOrderListInfo> listGrdOrderListInfo = new List<DRG9040U01GrdOrderListInfo>();
            for (int i = 0; i < grdOrderList.RowCount; i++)
            {
                if (grdOrderList.GetRowState(i) == DataRowState.Modified)
                {
                    DRG9040U01GrdOrderListInfo grdOrderListInfo = new DRG9040U01GrdOrderListInfo();
                    grdOrderListInfo.Fkocs2003 = grdJUSAOrderList.GetItemString(i, "fkocs2003");
                    grdOrderListInfo.OrderRemark = grdJUSAOrderList.GetItemString(i, "order_remark");
                    grdOrderListInfo.DrgRemark = grdJUSAOrderList.GetItemString(i, "drg_remark");
                    grdOrderListInfo.Bunho = grdJUSAOrderList.GetItemString(i, "bunho");
                    grdOrderListInfo.DataRowState = DataRowState.Modified.ToString();

                    listGrdOrderListInfo.Add(grdOrderListInfo);
                }   
            }
            return listGrdOrderListInfo;
        }

        /// <summary>
        /// CreateDataForSaveGrdOrderOut
        /// </summary>
        /// <returns></returns>
        private List<DRG9040U01GrdOrderOutInfo> CreateDataForSaveGrdOrderOut()
        {
            List<DRG9040U01GrdOrderOutInfo> ListGrdOrderOutInfo = new List<DRG9040U01GrdOrderOutInfo>();
            for (int i = 0; i < grdOrderOut.RowCount; i++)
            {
                if (grdOrderOut.GetRowState(i) == DataRowState.Modified)
                {
                    DRG9040U01GrdOrderOutInfo grdOrderOutInfo = new DRG9040U01GrdOrderOutInfo();
                    grdOrderOutInfo.JubsuDate = grdOrderOut.GetItemString(i, "jubsu_date");
                    grdOrderOutInfo.OrderDate = grdOrderOut.GetItemString(i, "order_date");
                    grdOrderOutInfo.DrgBunho = grdOrderOut.GetItemString(i, "drg_bunho");
                    grdOrderOutInfo.Bunho = grdOrderOut.GetItemString(i, "bunho");
                    grdOrderOutInfo.OrderRemark = grdOrderOut.GetItemString(i, "order_remark");
                    grdOrderOutInfo.DrgRemark = grdOrderOut.GetItemString(i, "drg_remark");
                    grdOrderOutInfo.DataRowState = DataRowState.Modified.ToString();

                    ListGrdOrderOutInfo.Add(grdOrderOutInfo);
                }
            }
            return ListGrdOrderOutInfo;
        }

        /// <summary>
        /// CreateDataForSaveGrdOrderListOut
        /// </summary>
        /// <returns></returns>
        private List<DRG9040U01GrdOrderListOutInfo> CreateDataForSaveGrdOrderListOut()
        {
            List<DRG9040U01GrdOrderListOutInfo> listGrdOrderListOut = new List<DRG9040U01GrdOrderListOutInfo>();
            for (int i = 0; i < grdOrderListOut.RowCount; i++)
            {
                if (grdOrderListOut.GetRowState(i) == DataRowState.Modified)
                {
                    DRG9040U01GrdOrderListOutInfo grdOrderListOutInfo = new DRG9040U01GrdOrderListOutInfo();
                    grdOrderListOutInfo.Fkocs1003 = grdOrderListOut.GetItemString(i, "fkocs1003");
                    grdOrderListOutInfo.Bunho = grdOrderListOut.GetItemString(i, "bunho");
                    grdOrderListOutInfo.OrderRemark = grdOrderListOut.GetItemString(i, "order_remark");
                    grdOrderListOutInfo.DrgRemark = grdOrderListOut.GetItemString(i, "drg_remark");
                    grdOrderListOutInfo.DataRowState = DataRowState.Modified.ToString();
                    listGrdOrderListOut.Add(grdOrderListOutInfo);
                }
            }
            return listGrdOrderListOut;
        }

        /// <summary>
        /// ExecuteQueryLayPaCommentInfo
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryLayPaCommentInfo(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            DRG9040U01LayPaCommentArgs vDRG9040U01LayPaCommentArgs = new DRG9040U01LayPaCommentArgs();
            vDRG9040U01LayPaCommentArgs.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            DRG9040U01LayPaCommentResult result = CloudService.Instance.Submit<DRG9040U01LayPaCommentResult, DRG9040U01LayPaCommentArgs>(vDRG9040U01LayPaCommentArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (DRG9040U01LayPaCommentInfo item in result.LayPaComment)
                {
                    object[] objects = 
				{ 
					item.OrderRemark, 
					item.DrgRemark
				};
                    res.Add(objects);
                }
            }
            return res;
        } 

        #endregion

        #region [ XSavePerformer ]
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private DRG9040U01 parent = null;
            public XSavePerformer(DRG9040U01 parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                //Grid에서 넘어온 Bind 변수에 f_user_id SET
                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);

                switch (callerID)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Modified:
                                cmdText = @"SELECT 'Y' FROM DRG9040 
                                             WHERE IN_OUT_GUBUN = 'I'
                                               AND JUBSU_DATE   = :f_jubsu_date
                                               AND ORDER_DATE   = :f_order_date
                                               AND DRG_BUNHO    = :f_drg_bunho
                                               AND HOSP_CODE    = :f_hosp_code";
                                object retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
                                if (!TypeCheck.IsNull(retVal))
                                {
                                    cmdText = @"UPDATE DRG9040
                                                   SET UPD_ID     = :q_user_id
                                                     , UPD_DATE   = SYSDATE
                                                     , INPUT_DATE = TRUNC(SYSDATE)
                                                     , INPUT_USER = :q_user_id
                                                     , ORDER_REMARK = :f_order_remark
                                                     , DRG_REMARK   = :f_drg_remark
                                                 WHERE IN_OUT_GUBUN = 'I'
                                                   AND JUBSU_DATE   = :f_jubsu_date
                                                   AND ORDER_DATE   = :f_order_date
                                                   AND DRG_BUNHO    = :f_drg_bunho
                                                   AND HOSP_CODE    = :f_hosp_code";
                                }
                                else
                                {
                                    cmdText = @"INSERT INTO DRG9040( SYS_DATE
                                                                    ,SYS_ID
                                                                    ,IN_OUT_GUBUN
                                                                    ,JUBSU_DATE
                                                                    ,ORDER_DATE
                                                                    ,DRG_BUNHO
                                                                    ,BUNHO
                                                                    ,INPUT_DATE
                                                                    ,INPUT_USER
                                                                    ,ORDER_REMARK
                                                                    ,DRG_REMARK
                                                                    ,HOSP_CODE
                                                                   )
                                                             VALUES( SYSDATE
                                                                    ,:q_user_id
                                                                    ,'I'
                                                                    ,:f_jubsu_date
                                                                    ,:f_order_date
                                                                    ,:f_drg_bunho
                                                                    ,:f_bunho
                                                                    ,TRUNC(SYSDATE)
                                                                    ,:q_user_id
                                                                    ,:f_order_remark
                                                                    ,:f_drg_remark
                                                                    ,:f_hosp_code
                                                                    )";
                                }
                                break;
                        }
                        break;

                    case '2':
                        switch (item.RowState)
                        {
                            case DataRowState.Modified:
                                object retVal = Service.ExecuteScalar(
                                    "SELECT 'Y' FROM DRG9042 WHERE IN_OUT_GUBUN = 'I' AND FKOCS = :f_fkocs2003 AND HOSP_CODE = :f_hosp_code", item.BindVarList);
                                if (!TypeCheck.IsNull(retVal))
                                {
                                    cmdText = @"UPDATE DRG9042
                                                   SET UPD_ID        = :q_user_id
                                                     , UPD_DATE      = SYSDATE
                                                     , ORDER_REMARK = :f_order_remark
                                                     , DRG_REMARK   = :f_drg_remark
                                                 WHERE IN_OUT_GUBUN = 'I'
                                                   AND FKOCS        = :f_fkocs2003
                                                   AND HOSP_CODE    = :f_hosp_code";
                                }
                                else
                                {
                                    cmdText = @"INSERT INTO DRG9042( SYS_DATE
                                                                    ,SYS_ID
                                                                    ,IN_OUT_GUBUN
                                                                    ,FKOCS
                                                                    ,BUNHO
                                                                    ,INPUT_DATE
                                                                    ,INPUT_USER
                                                                    ,ORDER_REMARK
                                                                    ,DRG_REMARK
                                                                    ,HOSP_CODE
                                                                   )
                                                             VALUES( SYSDATE
                                                                    ,:q_user_id
                                                                    ,'I'
                                                                    ,:f_fkocs2003
                                                                    ,:f_bunho
                                                                    ,TRUNC(SYSDATE)
                                                                    ,:q_user_id
                                                                    ,:f_order_remark
                                                                    ,:f_drg_remark
                                                                    ,:f_hosp_code
                                                                   )";
                                }
                                break;
                        }
                        break;

                    case '3':
                        switch (item.RowState)
                        {
                            case DataRowState.Modified:
                                object retVal = Service.ExecuteScalar(
                                    "SELECT 'Y' FROM DRG9042 WHERE IN_OUT_GUBUN = 'I' AND FKOCS = :f_fkocs2003 AND HOSP_CODE = :f_hosp_code", item.BindVarList);
                                if (!TypeCheck.IsNull(retVal))
                                {
                                    cmdText = @"UPDATE DRG9042
                                                   SET UPD_ID        = :q_user_id
                                                     , UPD_DATE      = SYSDATE
                                                     , ORDER_REMARK = :f_order_remark
                                                     , DRG_REMARK   = :f_drg_remark
                                                 WHERE IN_OUT_GUBUN = 'I'
                                                   AND FKOCS        = :f_fkocs2003
                                                   AND HOSP_CODE    = :f_hosp_code";
                                }
                                else
                                {
                                    cmdText = @"INSERT INTO DRG9042( SYS_DATE
                                                                    ,SYS_ID
                                                                    ,IN_OUT_GUBUN
                                                                    ,FKOCS
                                                                    ,BUNHO
                                                                    ,INPUT_DATE
                                                                    ,INPUT_USER
                                                                    ,ORDER_REMARK
                                                                    ,DRG_REMARK
                                                                    ,HOSP_CODE
                                                                    )
                                                             VALUES( SYSDATE
                                                                    ,:q_user_id
                                                                    ,'I'
                                                                    ,:f_fkocs2003
                                                                    ,:f_bunho
                                                                    ,TRUNC(SYSDATE)
                                                                    ,:q_user_id
                                                                    ,:f_order_remark
                                                                    ,:f_drg_remark
                                                                    ,:f_hosp_code
                                                                   )";
                                }
                                break;
                        }
                        break;

                    case '4':
                        switch (item.RowState)
                        {
                            case DataRowState.Modified:
                                cmdText = @"SELECT 'Y' FROM DRG9040 
                                             WHERE IN_OUT_GUBUN = 'O'
                                               AND JUBSU_DATE   = :f_jubsu_date
                                               AND ORDER_DATE   = :f_order_date
                                               AND DRG_BUNHO    = :f_drg_bunho
                                               AND HOSP_CODE    = :f_hosp_code";
                                object retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
                                if (!TypeCheck.IsNull(retVal))
                                {
                                    cmdText = @"UPDATE DRG9040
                                                   SET UPD_ID     = :q_user_id
                                                     , UPD_DATE   = SYSDATE
                                                     , INPUT_DATE = TRUNC(SYSDATE)
                                                     , INPUT_USER = :q_user_id
                                                     , ORDER_REMARK = :f_order_remark
                                                     , DRG_REMARK   = :f_drg_remark
                                                 WHERE IN_OUT_GUBUN = 'O'
                                                   AND JUBSU_DATE   = :f_jubsu_date
                                                   AND ORDER_DATE   = :f_order_date
                                                   AND DRG_BUNHO    = :f_drg_bunho
                                                   AND HOSP_CODE    = :f_hosp_code";
                                }
                                else
                                {
                                    cmdText = @"INSERT INTO DRG9040( SYS_DATE
                                                                    ,SYS_ID
                                                                    ,IN_OUT_GUBUN
                                                                    ,JUBSU_DATE
                                                                    ,ORDER_DATE
                                                                    ,DRG_BUNHO
                                                                    ,BUNHO
                                                                    ,INPUT_DATE
                                                                    ,INPUT_USER
                                                                    ,ORDER_REMARK
                                                                    ,DRG_REMARK
                                                                    ,HOSP_CODE
                                                                   )
                                                             VALUES( SYSDATE
                                                                    ,:q_user_id
                                                                    ,'O'
                                                                    ,:f_jubsu_date
                                                                    ,:f_order_date
                                                                    ,:f_drg_bunho
                                                                    ,:f_bunho
                                                                    ,TRUNC(SYSDATE)
                                                                    ,:q_user_id
                                                                    ,:f_order_remark
                                                                    ,:f_drg_remark
                                                                    ,:f_hosp_code
                                                                    )";
                                }
                                break;
                        }
                        break;

                    case '5':
                        switch (item.RowState)
                        {
                            case DataRowState.Modified:
                                object retVal = Service.ExecuteScalar(
                                    "SELECT 'Y' FROM DRG9042 WHERE IN_OUT_GUBUN = 'O' AND FKOCS = :f_fkocs1003 AND HOSP_CODE = :f_hosp_code", item.BindVarList);
                                if (!TypeCheck.IsNull(retVal))
                                {
                                    cmdText = @"UPDATE DRG9042
                                                   SET UPD_ID        = :q_user_id
                                                     , UPD_DATE      = SYSDATE
                                                     , ORDER_REMARK = :f_order_remark
                                                     , DRG_REMARK   = :f_drg_remark
                                                 WHERE IN_OUT_GUBUN = 'O'
                                                   AND FKOCS        = :f_fkocs1003
                                                   AND HOSP_CODE    = :f_hosp_code";
                                }
                                else
                                {
                                    cmdText = @"INSERT INTO DRG9042( SYS_DATE
                                                                    ,SYS_ID
                                                                    ,IN_OUT_GUBUN
                                                                    ,FKOCS
                                                                    ,BUNHO
                                                                    ,INPUT_DATE
                                                                    ,INPUT_USER
                                                                    ,ORDER_REMARK
                                                                    ,DRG_REMARK
                                                                    ,HOSP_CODE
                                                                    )
                                                             VALUES( SYSDATE
                                                                    ,:q_user_id
                                                                    ,'O'
                                                                    ,:f_fkocs1003
                                                                    ,:f_bunho
                                                                    ,TRUNC(SYSDATE)
                                                                    ,:q_user_id
                                                                    ,:f_order_remark
                                                                    ,:f_drg_remark
                                                                    ,:f_hosp_code
                                                                   )";
                                }
                                break;
                        }
                        break;
                    default:
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        #region SavePaComment()
        private bool SavePaComment()
        {
            BindVarCollection bindVarList = new BindVarCollection();
            bool isExistPaCmmt = false;
            object retVal;
            string cmdText;

            bindVarList.Add("f_bunho", paBox.BunHo);
            bindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

            retVal = Service.ExecuteScalar("SELECT 'Y' FROM DRG9041 WHERE BUNHO = :f_bunho AND HOSP_CODE = :f_hosp_code", bindVarList);

            isExistPaCmmt = (TypeCheck.IsNull(retVal) ? false : true);

            txtPaDrgRemark.AcceptData();
            txtPaOrdRemark.AcceptData();

            // 환자별 코멘트가 하나라도 존재 한다면, 인서트 혹은 업데이트
            if (!TypeCheck.IsNull(this.txtPaOrdRemark.GetDataValue()) || !TypeCheck.IsNull(this.txtPaDrgRemark.GetDataValue()))
            {
                bindVarList.Add("f_drg9041_ocs_remark", txtPaOrdRemark.GetDataValue());
                bindVarList.Add("f_drg9041_drg_remark", txtPaDrgRemark.GetDataValue());
                if (isExistPaCmmt)
                {
                    cmdText = @"UPDATE DRG9041
                                                   SET UPD_ID       = :q_user_id
                                                     , UPD_DATE     = SYSDATE
                                                     , INPUT_DATE   = TRUNC(SYSDATE)
                                                     , INPUT_USER   = :q_user_id
                                                     , ORDER_REMARK = :f_drg9041_ocs_remark
                                                     , DRG_REMARK   = :f_drg9041_drg_remark
                                                 WHERE BUNHO        = :f_bunho
                                                   AND HOSP_CODE    = :f_hosp_code";
                }
                else
                {
                    cmdText = @"INSERT INTO DRG9041( SYS_DATE
                                                                    ,SYS_ID
                                                                    ,BUNHO
                                                                    ,INPUT_DATE
                                                                    ,INPUT_USER
                                                                    ,ORDER_REMARK
                                                                    ,DRG_REMARK
                                                                    ,HOSP_CODE
                                                                   )
                                                             VALUES( SYSDATE
                                                                    ,:q_user_id
                                                                    ,:f_bunho
                                                                    ,TRUNC(SYSDATE)
                                                                    ,:q_user_id
                                                                    ,:f_drg9041_ocs_remark
                                                                    ,:f_drg9041_drg_remark
                                                                    ,:f_hosp_code
                                                                    )";
                }
                return Service.ExecuteNonQuery(cmdText, bindVarList);
            }
            // 입력된 pa comment 가 없으면, 혹은 있던 코멘트를 지웠으면
            else
            {
                if (isExistPaCmmt)
                {
                    cmdText = @"DELETE DRG9041
                                 WHERE BUNHO     = :f_bunho
                                   AND HOSP_CODE = :f_hosp_code
                               ";

                    return Service.ExecuteNonQuery(cmdText, bindVarList);
                }
                return true;
            }
        }
        #endregion

        #region 환자별 코멘트 조회 인변수 셋팅
        private void layPaComment_QueryStarting(object sender, CancelEventArgs e)
        {
            layPaComment.SetBindVarValue("f_bunho", paBox.BunHo);
            layPaComment.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }
        #endregion

        #region InOutGubun 콤보변경시
        private void cboInOutGubun_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.mInOutGubun = this.cboInOutGubun.GetDataValue();

            screenQuery();
        }
        #endregion

        #region ScreenQuery()
        private void screenQuery()
        {
            if (mInOutGubun == "O")
            {
                grdOrderOut.Visible = true;
                grdOrder.Visible = false;
                grdOrderListOut.Visible = true;
                grdOrderList.Visible = false;
                grdJUSAOrderList.Visible = false;

                grdOrderOut.QueryLayout(false);
            }
            else
            {
                grdOrderOut.Visible = false;
                grdOrder.Visible = true;
                grdOrderListOut.Visible = false;
                grdOrderList.Visible = true;
                grdJUSAOrderList.Visible = false;

                grdOrder.QueryLayout(false);
            }
        }
        #endregion

        #region date value 변경시 재조회 로직
        private void dtpDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            screenQuery();
        }
        #endregion

        private void grdOrder_PreEndInitializing(object sender, EventArgs e)
        {
            xEditGridCell10.ExecuteQuery = EditGridCell10GetData;
        }

        private List<object[]> EditGridCell10GetData(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            return res;
        }
    }
}

