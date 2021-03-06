using System;
using System.Collections.Generic;
using System.Text;
using IHIS.Framework;

namespace IHIS.OCSA
{
    partial class OCS0301Q09
    {
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

        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XButtonList xButtonList1;
        private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.MultiLayout dloOrder_danui;
        private IHIS.Framework.MultiLayout dloSelectOCS0301;
        private IHIS.Framework.MultiLayout dloSelectOCS0303;
        private IHIS.Framework.MultiLayout dloInputControl;
        private IHIS.Framework.XButton btnProcessD7;
        private System.Windows.Forms.CheckBox chkIsNewGroup;
        private System.Windows.Forms.ImageList imageListMixGroup;
        private IHIS.Framework.XRadioButton rbt;
        private IHIS.Framework.MultiLayout dloMemb;
        private IHIS.Framework.XPanel panMemb;
        private System.Windows.Forms.TreeView tvwOCS0300;
        private IHIS.Framework.XButton btnCPLInfo;
        private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XTextBox txtSearchSetName;
        private IHIS.Framework.MultiLayout dloSetOrderCopy;
        private XEditGridCell xEditGridCell138;
        private XEditGridCell xEditGridCell139;
        private XEditGridCell xEditGridCell140;
        private XEditGridCell xEditGridCell141;
        private XEditGridCell xEditGridCell142;
        private XEditGridCell xEditGridCell144;
        private XEditGridCell xEditGridCell145;
        private XEditGridCell xEditGridCell146;
        private XEditGridCell xEditGridCell147;
        private XMstGrid grdOCS0301;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayoutItem multiLayoutItem19;
        private MultiLayoutItem multiLayoutItem20;
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem22;
        private MultiLayoutItem multiLayoutItem23;
        private MultiLayoutItem multiLayoutItem24;
        private MultiLayoutItem multiLayoutItem25;
        private MultiLayoutItem multiLayoutItem26;
        private MultiLayoutItem multiLayoutItem27;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private XEditGridCell xEditGridCell162;
        private XEditGrid grdOCS0303;
        private XEditGridCell xEditGridCell78;
        private XEditGridCell xEditGridCell79;
        private XEditGridCell xEditGridCell80;
        private XEditGridCell xEditGridCell81;
        private XEditGridCell xEditGridCell82;
        private XEditGridCell xEditGridCell83;
        private XEditGridCell xEditGridCell84;
        private XEditGridCell xEditGridCell85;
        private XEditGridCell xEditGridCell86;
        private XEditGridCell xEditGridCell87;
        private XEditGridCell xEditGridCell88;
        private XEditGridCell xEditGridCell89;
        private XEditGridCell xEditGridCell90;
        private XEditGridCell xEditGridCell91;
        private XEditGridCell xEditGridCell92;
        private XEditGridCell xEditGridCell93;
        private XEditGridCell xEditGridCell94;
        private XEditGridCell xEditGridCell95;
        private XEditGridCell xEditGridCell96;
        private XEditGridCell xEditGridCell97;
        private XEditGridCell xEditGridCell98;
        private XEditGridCell xEditGridCell99;
        private XEditGridCell xEditGridCell100;
        private XEditGridCell xEditGridCell101;
        private XEditGridCell xEditGridCell102;
        private XEditGridCell xEditGridCell103;
        private XEditGridCell xEditGridCell104;
        private XEditGridCell xEditGridCell105;
        private XEditGridCell xEditGridCell106;
        private XEditGridCell xEditGridCell107;
        private XEditGridCell xEditGridCell108;
        private XEditGridCell xEditGridCell109;
        private XEditGridCell xEditGridCell110;
        private XEditGridCell xEditGridCell111;
        private XEditGridCell xEditGridCell112;
        private XEditGridCell xEditGridCell113;
        private XEditGridCell xEditGridCell114;
        private XEditGridCell xEditGridCell115;
        private XEditGridCell xEditGridCell116;
        private XEditGridCell xEditGridCell117;
        private XEditGridCell xEditGridCell118;
        private XEditGridCell xEditGridCell119;
        private XEditGridCell xEditGridCell120;
        private XEditGridCell xEditGridCell121;
        private XEditGridCell xEditGridCell122;
        private XEditGridCell xEditGridCell123;
        private XEditGridCell xEditGridCell124;
        private XEditGridCell xEditGridCell125;
        private XEditGridCell xEditGridCell126;
        private XEditGridCell xEditGridCell127;
        private XEditGridCell xEditGridCell128;
        private XEditGridCell xEditGridCell129;
        private XEditGridCell xEditGridCell133;
        private XEditGridCell xEditGridCell134;
        private XEditGridCell xEditGridCell135;
        private XEditGridCell xEditGridCell136;
        private XEditGridCell xEditGridCell137;
        private XEditGridCell xEditGridCell143;
        private XEditGridCell xEditGridCell148;
        private XEditGridCell xEditGridCell149;
        private XEditGridCell xEditGridCell151;
        private XEditGridCell xEditGridCell152;
        private XEditGridCell xEditGridCell153;
        private XEditGridCell xEditGridCell154;
        private XEditGridCell xEditGridCell155;
        private XEditGridCell xEditGridCell156;
        private XEditGridCell xEditGridCell157;
        private XEditGridCell xEditGridCell158;
        private XEditGridCell xEditGridCell159;
        private XEditGridCell xEditGridCell160;
        private XEditGridCell xEditGridCell161;
        private XGridHeader xGridHeader1;
        private XPanel pnlOrder;
        private XTabControl tabGroupSerial;
        private XPanel pnlTop;
        private XButton btnSelectAllTab;
        private XButton btnSelectCurrentTab;
        private XPanel pnlFill;
        private XEditGridCell xEditGridCell3;
        private XGridHeader xGridHeader2;
        private XGridHeader xGridHeader3;
        private XEditGridCell xEditGridCell4;
        protected System.Windows.Forms.ImageList imageList1;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
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
        private XCheckBox cbxGeneric_YN;
        private XButton btnProcessD0;
        private XButton btnProcessD4;
        private System.ComponentModel.IContainer components;

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0301Q09));
            this.panMemb = new IHIS.Framework.XPanel();
            this.rbt = new IHIS.Framework.XRadioButton();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.txtSearchSetName = new IHIS.Framework.XTextBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnCPLInfo = new IHIS.Framework.XButton();
            this.chkIsNewGroup = new System.Windows.Forms.CheckBox();
            this.btnProcessD0 = new IHIS.Framework.XButton();
            this.btnProcessD4 = new IHIS.Framework.XButton();
            this.btnProcessD7 = new IHIS.Framework.XButton();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.grdOCS0301 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell138 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell141 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell139 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell140 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell142 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell162 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell144 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell145 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell146 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell147 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.dloSelectOCS0301 = new IHIS.Framework.MultiLayout();
            this.dloSelectOCS0303 = new IHIS.Framework.MultiLayout();
            this.dloOrder_danui = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.dloInputControl = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
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
            this.imageListMixGroup = new System.Windows.Forms.ImageList(this.components);
            this.dloMemb = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.tvwOCS0300 = new System.Windows.Forms.TreeView();
            this.dloSetOrderCopy = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.grdOCS0303 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell123 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell124 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell125 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell126 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell127 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell128 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell129 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell133 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell134 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell135 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell136 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell137 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell143 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell148 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell149 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell151 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell152 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell153 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell154 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell155 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell156 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell157 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell158 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell159 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell160 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader3 = new IHIS.Framework.XGridHeader();
            this.xEditGridCell161 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.pnlOrder = new IHIS.Framework.XPanel();
            this.grdOCS0307 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.tabGroupSerial = new IHIS.Framework.XTabControl();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.cbxGeneric_YN = new IHIS.Framework.XCheckBox();
            this.btnSelectAllTab = new IHIS.Framework.XButton();
            this.btnSelectCurrentTab = new IHIS.Framework.XButton();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.panMemb.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0301)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS0301)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS0303)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloOrder_danui)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloInputControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloMemb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSetOrderCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0303)).BeginInit();
            this.pnlOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0307)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlFill.SuspendLayout();
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
            // 
            // panMemb
            // 
            this.panMemb.AccessibleDescription = null;
            this.panMemb.AccessibleName = null;
            resources.ApplyResources(this.panMemb, "panMemb");
            this.panMemb.Controls.Add(this.rbt);
            this.panMemb.Font = null;
            this.panMemb.Name = "panMemb";
            // 
            // rbt
            // 
            this.rbt.AccessibleDescription = null;
            this.rbt.AccessibleName = null;
            resources.ApplyResources(this.rbt, "rbt");
            this.rbt.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbt.BackgroundImage = null;
            this.rbt.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbt.ImageList = this.ImageList;
            this.rbt.Name = "rbt";
            this.rbt.UseVisualStyleBackColor = false;
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel4.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.xLabel4.Name = "xLabel4";
            // 
            // txtSearchSetName
            // 
            this.txtSearchSetName.AccessibleDescription = null;
            this.txtSearchSetName.AccessibleName = null;
            resources.ApplyResources(this.txtSearchSetName, "txtSearchSetName");
            this.txtSearchSetName.BackgroundImage = null;
            this.txtSearchSetName.Name = "txtSearchSetName";
            this.txtSearchSetName.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtSearchSetName_DataValidating);
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.btnCPLInfo);
            this.xPanel2.Controls.Add(this.chkIsNewGroup);
            this.xPanel2.Controls.Add(this.btnProcessD0);
            this.xPanel2.Controls.Add(this.btnProcessD4);
            this.xPanel2.Controls.Add(this.btnProcessD7);
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // btnCPLInfo
            // 
            this.btnCPLInfo.AccessibleDescription = null;
            this.btnCPLInfo.AccessibleName = null;
            resources.ApplyResources(this.btnCPLInfo, "btnCPLInfo");
            this.btnCPLInfo.BackgroundImage = null;
            this.btnCPLInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCPLInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnCPLInfo.Image")));
            this.btnCPLInfo.Name = "btnCPLInfo";
            this.btnCPLInfo.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnCPLInfo.Click += new System.EventHandler(this.btnCPLInfo_Click);
            // 
            // chkIsNewGroup
            // 
            this.chkIsNewGroup.AccessibleDescription = null;
            this.chkIsNewGroup.AccessibleName = null;
            resources.ApplyResources(this.chkIsNewGroup, "chkIsNewGroup");
            this.chkIsNewGroup.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkIsNewGroup.BackgroundImage = null;
            this.chkIsNewGroup.Checked = true;
            this.chkIsNewGroup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsNewGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkIsNewGroup.Font = null;
            this.chkIsNewGroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkIsNewGroup.ImageList = this.ImageList;
            this.chkIsNewGroup.Name = "chkIsNewGroup";
            this.chkIsNewGroup.UseVisualStyleBackColor = false;
            this.chkIsNewGroup.CheckedChanged += new System.EventHandler(this.chkIsNewGroup_CheckedChanged);
            // 
            // btnProcessD0
            // 
            this.btnProcessD0.AccessibleDescription = null;
            this.btnProcessD0.AccessibleName = null;
            resources.ApplyResources(this.btnProcessD0, "btnProcessD0");
            this.btnProcessD0.BackgroundImage = null;
            this.btnProcessD0.Image = ((System.Drawing.Image)(resources.GetObject("btnProcessD0.Image")));
            this.btnProcessD0.Name = "btnProcessD0";
            this.btnProcessD0.Tag = "D0";
            this.btnProcessD0.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnProcessD4
            // 
            this.btnProcessD4.AccessibleDescription = null;
            this.btnProcessD4.AccessibleName = null;
            resources.ApplyResources(this.btnProcessD4, "btnProcessD4");
            this.btnProcessD4.BackgroundImage = null;
            this.btnProcessD4.Image = ((System.Drawing.Image)(resources.GetObject("btnProcessD4.Image")));
            this.btnProcessD4.Name = "btnProcessD4";
            this.btnProcessD4.Tag = "D4";
            this.btnProcessD4.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnProcessD7
            // 
            this.btnProcessD7.AccessibleDescription = null;
            this.btnProcessD7.AccessibleName = null;
            resources.ApplyResources(this.btnProcessD7, "btnProcessD7");
            this.btnProcessD7.BackgroundImage = null;
            this.btnProcessD7.Image = ((System.Drawing.Image)(resources.GetObject("btnProcessD7.Image")));
            this.btnProcessD7.Name = "btnProcessD7";
            this.btnProcessD7.Tag = "D7";
            this.btnProcessD7.Click += new System.EventHandler(this.btnProcess_Click);
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
            // grdOCS0301
            // 
            resources.ApplyResources(this.grdOCS0301, "grdOCS0301");
            this.grdOCS0301.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell138,
            this.xEditGridCell141,
            this.xEditGridCell139,
            this.xEditGridCell140,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell142,
            this.xEditGridCell162,
            this.xEditGridCell16,
            this.xEditGridCell144,
            this.xEditGridCell145,
            this.xEditGridCell146,
            this.xEditGridCell147,
            this.xEditGridCell17});
            this.grdOCS0301.ColPerLine = 14;
            this.grdOCS0301.Cols = 14;
            this.grdOCS0301.ControlBinding = true;
            this.grdOCS0301.ExecuteQuery = null;
            this.grdOCS0301.FixedRows = 1;
            this.grdOCS0301.HeaderHeights.Add(21);
            this.grdOCS0301.Name = "grdOCS0301";
            this.grdOCS0301.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0301.ParamList")));
            this.grdOCS0301.QuerySQL = resources.GetString("grdOCS0301.QuerySQL");
            this.grdOCS0301.Rows = 2;
            this.grdOCS0301.RowStateCheckOnPaint = false;
            this.grdOCS0301.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS0301.ToolTipActive = true;
            this.grdOCS0301.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS0301_QueryEnd);
            this.grdOCS0301.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOCS0301_RowFocusChanged);
            this.grdOCS0301.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0301_QueryStarting);
            // 
            // xEditGridCell138
            // 
            this.xEditGridCell138.CellName = "memb";
            this.xEditGridCell138.CellWidth = 65;
            this.xEditGridCell138.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell138, "xEditGridCell138");
            this.xEditGridCell138.IsUpdatable = false;
            // 
            // xEditGridCell141
            // 
            this.xEditGridCell141.CellName = "pk_seq";
            this.xEditGridCell141.Col = 3;
            this.xEditGridCell141.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell141, "xEditGridCell141");
            this.xEditGridCell141.IsUpdatable = false;
            // 
            // xEditGridCell139
            // 
            this.xEditGridCell139.CellName = "yaksok_gubun";
            this.xEditGridCell139.Col = 1;
            this.xEditGridCell139.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell139, "xEditGridCell139");
            this.xEditGridCell139.IsUpdatable = false;
            // 
            // xEditGridCell140
            // 
            this.xEditGridCell140.CellName = "yaksok_gubun_name";
            this.xEditGridCell140.Col = 2;
            this.xEditGridCell140.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell140, "xEditGridCell140");
            this.xEditGridCell140.IsUpdatable = false;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "yaksok_code";
            this.xEditGridCell1.Col = 10;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "yaksok_name";
            this.xEditGridCell2.Col = 5;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsUpdatable = false;
            // 
            // xEditGridCell142
            // 
            this.xEditGridCell142.CellName = "input_tab";
            this.xEditGridCell142.Col = 4;
            this.xEditGridCell142.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell142, "xEditGridCell142");
            this.xEditGridCell142.IsUpdatable = false;
            // 
            // xEditGridCell162
            // 
            this.xEditGridCell162.CellName = "pk_yaksok";
            this.xEditGridCell162.Col = 11;
            this.xEditGridCell162.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell162, "xEditGridCell162");
            this.xEditGridCell162.IsUpdatable = false;
            this.xEditGridCell162.IsUpdCol = false;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "input_tab_name";
            this.xEditGridCell16.Col = 12;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsUpdatable = false;
            // 
            // xEditGridCell144
            // 
            this.xEditGridCell144.CellName = "select";
            this.xEditGridCell144.Col = 6;
            this.xEditGridCell144.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell144, "xEditGridCell144");
            this.xEditGridCell144.IsUpdatable = false;
            this.xEditGridCell144.IsUpdCol = false;
            // 
            // xEditGridCell145
            // 
            this.xEditGridCell145.CellName = "select_sang";
            this.xEditGridCell145.Col = 7;
            this.xEditGridCell145.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell145, "xEditGridCell145");
            this.xEditGridCell145.IsUpdatable = false;
            this.xEditGridCell145.IsUpdCol = false;
            // 
            // xEditGridCell146
            // 
            this.xEditGridCell146.CellName = "node1";
            this.xEditGridCell146.Col = 8;
            this.xEditGridCell146.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell146, "xEditGridCell146");
            this.xEditGridCell146.IsUpdatable = false;
            this.xEditGridCell146.IsUpdCol = false;
            // 
            // xEditGridCell147
            // 
            this.xEditGridCell147.CellName = "node2";
            this.xEditGridCell147.Col = 9;
            this.xEditGridCell147.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell147, "xEditGridCell147");
            this.xEditGridCell147.IsUpdatable = false;
            this.xEditGridCell147.IsUpdCol = false;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "node3";
            this.xEditGridCell17.Col = 13;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsUpdatable = false;
            this.xEditGridCell17.IsUpdCol = false;
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
            // 
            // dloSelectOCS0301
            // 
            this.dloSelectOCS0301.ExecuteQuery = null;
            this.dloSelectOCS0301.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dloSelectOCS0301.ParamList")));
            // 
            // dloSelectOCS0303
            // 
            this.dloSelectOCS0303.ExecuteQuery = null;
            this.dloSelectOCS0303.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dloSelectOCS0303.ParamList")));
            // 
            // dloOrder_danui
            // 
            this.dloOrder_danui.ExecuteQuery = null;
            this.dloOrder_danui.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem3,
            this.multiLayoutItem4});
            this.dloOrder_danui.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dloOrder_danui.ParamList")));
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "code";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "code_name";
            // 
            // dloInputControl
            // 
            this.dloInputControl.ExecuteQuery = null;
            this.dloInputControl.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem5,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20,
            this.multiLayoutItem21,
            this.multiLayoutItem22,
            this.multiLayoutItem23,
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem26,
            this.multiLayoutItem27});
            this.dloInputControl.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dloInputControl.ParamList")));
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "input_control";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "input_control_name";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "specimen_cr_yn";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "suryang_cr_yn";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "ord_danui_cr_yn";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "dv_time_cr_yn";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "dv_cr_yn";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "nalsu_cr_yn";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "jusa_cr_yn";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "bogyong_code_cr_yn";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "toiwon_drg_cr_yn";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "tpn_cr_yn";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "anti_cancer_cr_yn";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "fluid_cr_yn";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "portable_cr_yn";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "doner_cr_yn";
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "amt_cr_yn";
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
            // dloMemb
            // 
            this.dloMemb.ExecuteQuery = null;
            this.dloMemb.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            this.dloMemb.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dloMemb.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "memb";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "memb_name";
            // 
            // tvwOCS0300
            // 
            this.tvwOCS0300.AccessibleDescription = null;
            this.tvwOCS0300.AccessibleName = null;
            this.tvwOCS0300.AllowDrop = true;
            resources.ApplyResources(this.tvwOCS0300, "tvwOCS0300");
            this.tvwOCS0300.BackColor = System.Drawing.SystemColors.Window;
            this.tvwOCS0300.BackgroundImage = null;
            this.tvwOCS0300.Font = null;
            this.tvwOCS0300.HideSelection = false;
            this.tvwOCS0300.HotTracking = true;
            this.tvwOCS0300.ImageList = this.ImageList;
            this.tvwOCS0300.Name = "tvwOCS0300";
            this.tvwOCS0300.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwOCS0300_AfterSelect);
            this.tvwOCS0300.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvwOCS0300_MouseDown);
            // 
            // dloSetOrderCopy
            // 
            this.dloSetOrderCopy.ExecuteQuery = null;
            this.dloSetOrderCopy.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11});
            this.dloSetOrderCopy.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dloSetOrderCopy.ParamList")));
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "source_memb";
            this.multiLayoutItem6.IsUpdItem = true;
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "source_yaksok_code";
            this.multiLayoutItem7.IsUpdItem = true;
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "target_memb";
            this.multiLayoutItem8.IsUpdItem = true;
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "yaksok_code";
            this.multiLayoutItem9.IsUpdItem = true;
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "yaksok_name";
            this.multiLayoutItem10.IsUpdItem = true;
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "input_tab";
            this.multiLayoutItem11.IsUpdItem = true;
            // 
            // grdOCS0303
            // 
            this.grdOCS0303.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdOCS0303, "grdOCS0303");
            this.grdOCS0303.ApplyPaintEventToAllColumn = true;
            this.grdOCS0303.CallerID = '2';
            this.grdOCS0303.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell25,
            this.xEditGridCell78,
            this.xEditGridCell79,
            this.xEditGridCell80,
            this.xEditGridCell81,
            this.xEditGridCell82,
            this.xEditGridCell83,
            this.xEditGridCell84,
            this.xEditGridCell85,
            this.xEditGridCell86,
            this.xEditGridCell87,
            this.xEditGridCell88,
            this.xEditGridCell89,
            this.xEditGridCell90,
            this.xEditGridCell91,
            this.xEditGridCell92,
            this.xEditGridCell93,
            this.xEditGridCell94,
            this.xEditGridCell95,
            this.xEditGridCell96,
            this.xEditGridCell97,
            this.xEditGridCell98,
            this.xEditGridCell99,
            this.xEditGridCell100,
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
            this.xEditGridCell123,
            this.xEditGridCell124,
            this.xEditGridCell125,
            this.xEditGridCell126,
            this.xEditGridCell127,
            this.xEditGridCell128,
            this.xEditGridCell129,
            this.xEditGridCell133,
            this.xEditGridCell134,
            this.xEditGridCell135,
            this.xEditGridCell136,
            this.xEditGridCell137,
            this.xEditGridCell143,
            this.xEditGridCell148,
            this.xEditGridCell149,
            this.xEditGridCell151,
            this.xEditGridCell152,
            this.xEditGridCell153,
            this.xEditGridCell154,
            this.xEditGridCell155,
            this.xEditGridCell156,
            this.xEditGridCell157,
            this.xEditGridCell158,
            this.xEditGridCell159,
            this.xEditGridCell160,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell15,
            this.xEditGridCell26});
            this.grdOCS0303.ColPerLine = 27;
            this.grdOCS0303.Cols = 28;
            this.grdOCS0303.ControlBinding = true;
            this.grdOCS0303.ExecuteQuery = null;
            this.grdOCS0303.FixedCols = 1;
            this.grdOCS0303.FixedRows = 2;
            this.grdOCS0303.HeaderHeights.Add(37);
            this.grdOCS0303.HeaderHeights.Add(0);
            this.grdOCS0303.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader3});
            this.grdOCS0303.Name = "grdOCS0303";
            this.grdOCS0303.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0303.ParamList")));
            this.grdOCS0303.QuerySQL = resources.GetString("grdOCS0303.QuerySQL");
            this.grdOCS0303.ReadOnly = true;
            this.grdOCS0303.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOCS0303.RowHeaderVisible = true;
            this.grdOCS0303.Rows = 3;
            this.grdOCS0303.RowStateCheckOnPaint = false;
            this.grdOCS0303.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS0303.ToolTipActive = true;
            this.grdOCS0303.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS0303_GridColumnChanged);
            this.grdOCS0303.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS0303_QueryEnd);
            this.grdOCS0303.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0303_MouseDown);
            this.grdOCS0303.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOCS0303_RowFocusChanged);
            this.grdOCS0303.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS0303_GridCellPainting);
            this.grdOCS0303.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0303_QueryStarting);
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "trial_flg";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "memb";
            this.xEditGridCell78.Col = -1;
            this.xEditGridCell78.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell78, "xEditGridCell78");
            this.xEditGridCell78.IsVisible = false;
            this.xEditGridCell78.Row = -1;
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellName = "yaksok_code";
            this.xEditGridCell79.Col = -1;
            this.xEditGridCell79.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell79, "xEditGridCell79");
            this.xEditGridCell79.IsVisible = false;
            this.xEditGridCell79.Row = -1;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellName = "pk_yaksok";
            this.xEditGridCell80.Col = -1;
            this.xEditGridCell80.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell80, "xEditGridCell80");
            this.xEditGridCell80.IsVisible = false;
            this.xEditGridCell80.Row = -1;
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.CellName = "pkocs0303";
            this.xEditGridCell81.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell81.Col = -1;
            this.xEditGridCell81.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell81, "xEditGridCell81");
            this.xEditGridCell81.IsVisible = false;
            this.xEditGridCell81.Row = -1;
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellName = "group_ser";
            this.xEditGridCell82.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell82.CellWidth = 25;
            this.xEditGridCell82.Col = 4;
            this.xEditGridCell82.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell82, "xEditGridCell82");
            this.xEditGridCell82.RowSpan = 2;
            this.xEditGridCell82.SuppressRepeating = true;
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "mix_group";
            this.xEditGridCell83.Col = -1;
            this.xEditGridCell83.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell83, "xEditGridCell83");
            this.xEditGridCell83.IsVisible = false;
            this.xEditGridCell83.Row = -1;
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellName = "seq";
            this.xEditGridCell84.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell84.Col = -1;
            this.xEditGridCell84.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell84, "xEditGridCell84");
            this.xEditGridCell84.IsVisible = false;
            this.xEditGridCell84.Row = -1;
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellName = "order_gubun";
            this.xEditGridCell85.Col = -1;
            this.xEditGridCell85.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell85, "xEditGridCell85");
            this.xEditGridCell85.IsVisible = false;
            this.xEditGridCell85.Row = -1;
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.CellName = "order_gubun_name";
            this.xEditGridCell86.CellWidth = 65;
            this.xEditGridCell86.Col = 3;
            this.xEditGridCell86.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell86, "xEditGridCell86");
            this.xEditGridCell86.RowSpan = 2;
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellName = "input_tab";
            this.xEditGridCell87.Col = -1;
            this.xEditGridCell87.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell87, "xEditGridCell87");
            this.xEditGridCell87.IsVisible = false;
            this.xEditGridCell87.Row = -1;
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.CellName = "hangmog_code";
            this.xEditGridCell88.CellWidth = 75;
            this.xEditGridCell88.Col = 5;
            this.xEditGridCell88.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell88, "xEditGridCell88");
            this.xEditGridCell88.RowSpan = 2;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellLen = 80;
            this.xEditGridCell89.CellName = "hangmog_name";
            this.xEditGridCell89.CellWidth = 268;
            this.xEditGridCell89.Col = 6;
            this.xEditGridCell89.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell89, "xEditGridCell89");
            this.xEditGridCell89.RowSpan = 2;
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.CellName = "specimen_code";
            this.xEditGridCell90.Col = -1;
            this.xEditGridCell90.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell90, "xEditGridCell90");
            this.xEditGridCell90.IsVisible = false;
            this.xEditGridCell90.Row = -1;
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.CellLen = 100;
            this.xEditGridCell91.CellName = "specimen_name";
            this.xEditGridCell91.CellWidth = 60;
            this.xEditGridCell91.Col = 8;
            this.xEditGridCell91.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell91, "xEditGridCell91");
            this.xEditGridCell91.RowSpan = 2;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "suryang";
            this.xEditGridCell92.CellWidth = 55;
            this.xEditGridCell92.Col = 9;
            this.xEditGridCell92.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell92, "xEditGridCell92");
            this.xEditGridCell92.RowSpan = 2;
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.CellName = "ord_danui";
            this.xEditGridCell93.Col = -1;
            this.xEditGridCell93.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell93, "xEditGridCell93");
            this.xEditGridCell93.IsVisible = false;
            this.xEditGridCell93.Row = -1;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.CellLen = 6;
            this.xEditGridCell94.CellName = "order_danui_name";
            this.xEditGridCell94.CellWidth = 48;
            this.xEditGridCell94.Col = 10;
            this.xEditGridCell94.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell94, "xEditGridCell94");
            this.xEditGridCell94.RowSpan = 2;
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.CellLen = 1;
            this.xEditGridCell95.CellName = "dv_time";
            this.xEditGridCell95.CellWidth = 15;
            this.xEditGridCell95.Col = 11;
            this.xEditGridCell95.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell95.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell95, "xEditGridCell95");
            this.xEditGridCell95.Row = 1;
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellName = "dv";
            this.xEditGridCell96.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell96.CellWidth = 25;
            this.xEditGridCell96.Col = 12;
            this.xEditGridCell96.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell96, "xEditGridCell96");
            this.xEditGridCell96.Row = 1;
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.CellName = "dv_1";
            this.xEditGridCell97.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell97.Col = -1;
            this.xEditGridCell97.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell97, "xEditGridCell97");
            this.xEditGridCell97.IsVisible = false;
            this.xEditGridCell97.Row = -1;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.CellName = "dv_2";
            this.xEditGridCell98.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell98.Col = -1;
            this.xEditGridCell98.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell98, "xEditGridCell98");
            this.xEditGridCell98.IsVisible = false;
            this.xEditGridCell98.Row = -1;
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.CellName = "dv_3";
            this.xEditGridCell99.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell99.Col = -1;
            this.xEditGridCell99.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell99, "xEditGridCell99");
            this.xEditGridCell99.IsVisible = false;
            this.xEditGridCell99.Row = -1;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.CellName = "dv_4";
            this.xEditGridCell100.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell100.CellWidth = 10;
            this.xEditGridCell100.Col = -1;
            this.xEditGridCell100.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell100, "xEditGridCell100");
            this.xEditGridCell100.IsVisible = false;
            this.xEditGridCell100.Row = -1;
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.CellName = "nalsu";
            this.xEditGridCell101.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell101.CellWidth = 67;
            this.xEditGridCell101.Col = 13;
            this.xEditGridCell101.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell101, "xEditGridCell101");
            this.xEditGridCell101.RowSpan = 2;
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.CellName = "jusa";
            this.xEditGridCell102.Col = -1;
            this.xEditGridCell102.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell102, "xEditGridCell102");
            this.xEditGridCell102.IsVisible = false;
            this.xEditGridCell102.Row = -1;
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.CellLen = 100;
            this.xEditGridCell103.CellName = "jusa_name";
            this.xEditGridCell103.CellWidth = 68;
            this.xEditGridCell103.Col = 15;
            this.xEditGridCell103.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell103, "xEditGridCell103");
            this.xEditGridCell103.RowSpan = 2;
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellName = "bogyong_code";
            this.xEditGridCell104.Col = -1;
            this.xEditGridCell104.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell104, "xEditGridCell104");
            this.xEditGridCell104.IsVisible = false;
            this.xEditGridCell104.Row = -1;
            // 
            // xEditGridCell105
            // 
            this.xEditGridCell105.CellName = "bogyong_name";
            this.xEditGridCell105.CellWidth = 90;
            this.xEditGridCell105.Col = 14;
            this.xEditGridCell105.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell105, "xEditGridCell105");
            this.xEditGridCell105.RowSpan = 2;
            this.xEditGridCell105.SuppressRepeating = true;
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.CellName = "jusa_spd_gubun";
            this.xEditGridCell106.CellWidth = 40;
            this.xEditGridCell106.Col = 16;
            this.xEditGridCell106.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell106.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell106, "xEditGridCell106");
            this.xEditGridCell106.RowSpan = 2;
            // 
            // xEditGridCell107
            // 
            this.xEditGridCell107.CellName = "hubal_change_yn";
            this.xEditGridCell107.CellWidth = 145;
            this.xEditGridCell107.Col = 24;
            this.xEditGridCell107.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell107.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell107, "xEditGridCell107");
            this.xEditGridCell107.IsUpdatable = false;
            this.xEditGridCell107.RowSpan = 2;
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.CellName = "pharmacy";
            this.xEditGridCell108.CellWidth = 64;
            this.xEditGridCell108.Col = 23;
            this.xEditGridCell108.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell108.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell108, "xEditGridCell108");
            this.xEditGridCell108.IsUpdatable = false;
            this.xEditGridCell108.RowSpan = 2;
            // 
            // xEditGridCell109
            // 
            this.xEditGridCell109.CellName = "drg_pack_yn";
            this.xEditGridCell109.CellWidth = 75;
            this.xEditGridCell109.Col = 22;
            this.xEditGridCell109.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell109.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell109, "xEditGridCell109");
            this.xEditGridCell109.IsUpdatable = false;
            this.xEditGridCell109.RowSpan = 2;
            // 
            // xEditGridCell110
            // 
            this.xEditGridCell110.CellLen = 1;
            this.xEditGridCell110.CellName = "emergency";
            this.xEditGridCell110.CellWidth = 63;
            this.xEditGridCell110.Col = 19;
            this.xEditGridCell110.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell110.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell110, "xEditGridCell110");
            this.xEditGridCell110.IsUpdatable = false;
            this.xEditGridCell110.RowSpan = 2;
            // 
            // xEditGridCell111
            // 
            this.xEditGridCell111.CellLen = 1;
            this.xEditGridCell111.CellName = "pay";
            this.xEditGridCell111.CellWidth = 52;
            this.xEditGridCell111.Col = -1;
            this.xEditGridCell111.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell111, "xEditGridCell111");
            this.xEditGridCell111.IsUpdatable = false;
            this.xEditGridCell111.IsVisible = false;
            this.xEditGridCell111.Row = -1;
            // 
            // xEditGridCell112
            // 
            this.xEditGridCell112.CellLen = 1;
            this.xEditGridCell112.CellName = "portable_yn";
            this.xEditGridCell112.CellWidth = 49;
            this.xEditGridCell112.Col = -1;
            this.xEditGridCell112.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell112, "xEditGridCell112");
            this.xEditGridCell112.IsUpdatable = false;
            this.xEditGridCell112.IsVisible = false;
            this.xEditGridCell112.Row = -1;
            // 
            // xEditGridCell113
            // 
            this.xEditGridCell113.CellLen = 1;
            this.xEditGridCell113.CellName = "powder_yn";
            this.xEditGridCell113.CellWidth = 22;
            this.xEditGridCell113.Col = -1;
            this.xEditGridCell113.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell113, "xEditGridCell113");
            this.xEditGridCell113.IsUpdatable = false;
            this.xEditGridCell113.IsVisible = false;
            this.xEditGridCell113.Row = -1;
            // 
            // xEditGridCell114
            // 
            this.xEditGridCell114.CellLen = 1;
            this.xEditGridCell114.CellName = "muhyo";
            this.xEditGridCell114.CellWidth = 54;
            this.xEditGridCell114.Col = 21;
            this.xEditGridCell114.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell114.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell114, "xEditGridCell114");
            this.xEditGridCell114.IsUpdatable = false;
            this.xEditGridCell114.RowSpan = 2;
            // 
            // xEditGridCell115
            // 
            this.xEditGridCell115.CellLen = 1;
            this.xEditGridCell115.CellName = "prn_yn";
            this.xEditGridCell115.Col = -1;
            this.xEditGridCell115.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell115, "xEditGridCell115");
            this.xEditGridCell115.IsUpdatable = false;
            this.xEditGridCell115.IsVisible = false;
            this.xEditGridCell115.Row = -1;
            // 
            // xEditGridCell116
            // 
            this.xEditGridCell116.CellName = "order_remark";
            this.xEditGridCell116.CellWidth = 112;
            this.xEditGridCell116.Col = 25;
            this.xEditGridCell116.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell116.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell116, "xEditGridCell116");
            this.xEditGridCell116.IsUpdatable = false;
            this.xEditGridCell116.RowSpan = 2;
            // 
            // xEditGridCell117
            // 
            this.xEditGridCell117.CellName = "nurse_remark";
            this.xEditGridCell117.CellWidth = 109;
            this.xEditGridCell117.Col = 26;
            this.xEditGridCell117.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell117.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell117, "xEditGridCell117");
            this.xEditGridCell117.IsUpdatable = false;
            this.xEditGridCell117.RowSpan = 2;
            // 
            // xEditGridCell118
            // 
            this.xEditGridCell118.CellName = "bulyong_check";
            this.xEditGridCell118.Col = -1;
            this.xEditGridCell118.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell118, "xEditGridCell118");
            this.xEditGridCell118.IsUpdatable = false;
            this.xEditGridCell118.IsVisible = false;
            this.xEditGridCell118.Row = -1;
            // 
            // xEditGridCell119
            // 
            this.xEditGridCell119.CellName = "slip_code";
            this.xEditGridCell119.Col = -1;
            this.xEditGridCell119.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell119, "xEditGridCell119");
            this.xEditGridCell119.IsUpdatable = false;
            this.xEditGridCell119.IsVisible = false;
            this.xEditGridCell119.Row = -1;
            // 
            // xEditGridCell120
            // 
            this.xEditGridCell120.CellName = "group_yn";
            this.xEditGridCell120.Col = -1;
            this.xEditGridCell120.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell120, "xEditGridCell120");
            this.xEditGridCell120.IsUpdatable = false;
            this.xEditGridCell120.IsVisible = false;
            this.xEditGridCell120.Row = -1;
            // 
            // xEditGridCell121
            // 
            this.xEditGridCell121.CellName = "order_gubun_bas";
            this.xEditGridCell121.Col = -1;
            this.xEditGridCell121.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell121, "xEditGridCell121");
            this.xEditGridCell121.IsUpdatable = false;
            this.xEditGridCell121.IsVisible = false;
            this.xEditGridCell121.Row = -1;
            // 
            // xEditGridCell122
            // 
            this.xEditGridCell122.CellName = "input_control";
            this.xEditGridCell122.Col = -1;
            this.xEditGridCell122.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell122, "xEditGridCell122");
            this.xEditGridCell122.IsUpdatable = false;
            this.xEditGridCell122.IsVisible = false;
            this.xEditGridCell122.Row = -1;
            // 
            // xEditGridCell123
            // 
            this.xEditGridCell123.CellName = "sg_code";
            this.xEditGridCell123.Col = -1;
            this.xEditGridCell123.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell123, "xEditGridCell123");
            this.xEditGridCell123.IsUpdatable = false;
            this.xEditGridCell123.IsVisible = false;
            this.xEditGridCell123.Row = -1;
            // 
            // xEditGridCell124
            // 
            this.xEditGridCell124.CellName = "suga_yn";
            this.xEditGridCell124.Col = -1;
            this.xEditGridCell124.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell124, "xEditGridCell124");
            this.xEditGridCell124.IsUpdatable = false;
            this.xEditGridCell124.IsVisible = false;
            this.xEditGridCell124.Row = -1;
            // 
            // xEditGridCell125
            // 
            this.xEditGridCell125.CellName = "emergency_check";
            this.xEditGridCell125.Col = -1;
            this.xEditGridCell125.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell125, "xEditGridCell125");
            this.xEditGridCell125.IsUpdatable = false;
            this.xEditGridCell125.IsVisible = false;
            this.xEditGridCell125.Row = -1;
            // 
            // xEditGridCell126
            // 
            this.xEditGridCell126.CellName = "limit_suryang";
            this.xEditGridCell126.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell126.Col = -1;
            this.xEditGridCell126.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell126, "xEditGridCell126");
            this.xEditGridCell126.IsUpdatable = false;
            this.xEditGridCell126.IsVisible = false;
            this.xEditGridCell126.Row = -1;
            // 
            // xEditGridCell127
            // 
            this.xEditGridCell127.CellName = "specimen_yn";
            this.xEditGridCell127.Col = -1;
            this.xEditGridCell127.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell127, "xEditGridCell127");
            this.xEditGridCell127.IsUpdatable = false;
            this.xEditGridCell127.IsVisible = false;
            this.xEditGridCell127.Row = -1;
            // 
            // xEditGridCell128
            // 
            this.xEditGridCell128.CellName = "jaeryo_yn";
            this.xEditGridCell128.Col = -1;
            this.xEditGridCell128.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell128, "xEditGridCell128");
            this.xEditGridCell128.IsUpdatable = false;
            this.xEditGridCell128.IsVisible = false;
            this.xEditGridCell128.Row = -1;
            // 
            // xEditGridCell129
            // 
            this.xEditGridCell129.CellName = "ord_danui_check";
            this.xEditGridCell129.Col = -1;
            this.xEditGridCell129.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell129, "xEditGridCell129");
            this.xEditGridCell129.IsUpdatable = false;
            this.xEditGridCell129.IsVisible = false;
            this.xEditGridCell129.Row = -1;
            // 
            // xEditGridCell133
            // 
            this.xEditGridCell133.CellName = "wonyoi_order_yn";
            this.xEditGridCell133.CellWidth = 71;
            this.xEditGridCell133.Col = 20;
            this.xEditGridCell133.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell133.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell133, "xEditGridCell133");
            this.xEditGridCell133.IsUpdatable = false;
            this.xEditGridCell133.RowSpan = 2;
            // 
            // xEditGridCell134
            // 
            this.xEditGridCell134.CellName = "dangil_gumsa_order_yn";
            this.xEditGridCell134.Col = -1;
            this.xEditGridCell134.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell134, "xEditGridCell134");
            this.xEditGridCell134.IsUpdatable = false;
            this.xEditGridCell134.IsVisible = false;
            this.xEditGridCell134.Row = -1;
            // 
            // xEditGridCell135
            // 
            this.xEditGridCell135.CellName = "dangil_gumsa_result_yn";
            this.xEditGridCell135.Col = -1;
            this.xEditGridCell135.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell135, "xEditGridCell135");
            this.xEditGridCell135.IsUpdatable = false;
            this.xEditGridCell135.IsVisible = false;
            this.xEditGridCell135.Row = -1;
            // 
            // xEditGridCell136
            // 
            this.xEditGridCell136.CellName = "wonyoi_order_cr_yn";
            this.xEditGridCell136.Col = -1;
            this.xEditGridCell136.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell136, "xEditGridCell136");
            this.xEditGridCell136.IsUpdatable = false;
            this.xEditGridCell136.IsVisible = false;
            this.xEditGridCell136.Row = -1;
            // 
            // xEditGridCell137
            // 
            this.xEditGridCell137.CellName = "nday_yn";
            this.xEditGridCell137.Col = -1;
            this.xEditGridCell137.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell137, "xEditGridCell137");
            this.xEditGridCell137.IsUpdatable = false;
            this.xEditGridCell137.IsVisible = false;
            this.xEditGridCell137.Row = -1;
            // 
            // xEditGridCell143
            // 
            this.xEditGridCell143.CellName = "muhyo_yn";
            this.xEditGridCell143.Col = -1;
            this.xEditGridCell143.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell143, "xEditGridCell143");
            this.xEditGridCell143.IsUpdatable = false;
            this.xEditGridCell143.IsVisible = false;
            this.xEditGridCell143.Row = -1;
            // 
            // xEditGridCell148
            // 
            this.xEditGridCell148.CellName = "pay_name";
            this.xEditGridCell148.Col = -1;
            this.xEditGridCell148.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell148, "xEditGridCell148");
            this.xEditGridCell148.IsUpdatable = false;
            this.xEditGridCell148.IsVisible = false;
            this.xEditGridCell148.Row = -1;
            // 
            // xEditGridCell149
            // 
            this.xEditGridCell149.CellName = "bun_code";
            this.xEditGridCell149.Col = -1;
            this.xEditGridCell149.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell149, "xEditGridCell149");
            this.xEditGridCell149.IsUpdatable = false;
            this.xEditGridCell149.IsVisible = false;
            this.xEditGridCell149.Row = -1;
            // 
            // xEditGridCell151
            // 
            this.xEditGridCell151.CellName = "data_control";
            this.xEditGridCell151.Col = -1;
            this.xEditGridCell151.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell151, "xEditGridCell151");
            this.xEditGridCell151.IsUpdatable = false;
            this.xEditGridCell151.IsVisible = false;
            this.xEditGridCell151.Row = -1;
            // 
            // xEditGridCell152
            // 
            this.xEditGridCell152.CellName = "donbog_yn";
            this.xEditGridCell152.Col = -1;
            this.xEditGridCell152.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell152, "xEditGridCell152");
            this.xEditGridCell152.IsUpdatable = false;
            this.xEditGridCell152.IsVisible = false;
            this.xEditGridCell152.Row = -1;
            // 
            // xEditGridCell153
            // 
            this.xEditGridCell153.CellName = "dv_name";
            this.xEditGridCell153.Col = -1;
            this.xEditGridCell153.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell153, "xEditGridCell153");
            this.xEditGridCell153.IsUpdatable = false;
            this.xEditGridCell153.IsVisible = false;
            this.xEditGridCell153.Row = -1;
            // 
            // xEditGridCell154
            // 
            this.xEditGridCell154.CellName = "drg_info";
            this.xEditGridCell154.Col = -1;
            this.xEditGridCell154.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell154, "xEditGridCell154");
            this.xEditGridCell154.IsReadOnly = true;
            this.xEditGridCell154.IsUpdatable = false;
            this.xEditGridCell154.IsVisible = false;
            this.xEditGridCell154.Row = -1;
            // 
            // xEditGridCell155
            // 
            this.xEditGridCell155.CellName = "drg_bunryu";
            this.xEditGridCell155.Col = -1;
            this.xEditGridCell155.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell155, "xEditGridCell155");
            this.xEditGridCell155.IsReadOnly = true;
            this.xEditGridCell155.IsUpdatable = false;
            this.xEditGridCell155.IsVisible = false;
            this.xEditGridCell155.Row = -1;
            // 
            // xEditGridCell156
            // 
            this.xEditGridCell156.CellName = "child_gubun";
            this.xEditGridCell156.CellWidth = 19;
            this.xEditGridCell156.Col = 2;
            this.xEditGridCell156.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell156, "xEditGridCell156");
            this.xEditGridCell156.IsUpdatable = false;
            this.xEditGridCell156.RowSpan = 2;
            // 
            // xEditGridCell157
            // 
            this.xEditGridCell157.CellName = "bom_source_key";
            this.xEditGridCell157.Col = -1;
            this.xEditGridCell157.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell157, "xEditGridCell157");
            this.xEditGridCell157.IsUpdatable = false;
            this.xEditGridCell157.IsVisible = false;
            this.xEditGridCell157.Row = -1;
            // 
            // xEditGridCell158
            // 
            this.xEditGridCell158.CellName = "haengwee_yn";
            this.xEditGridCell158.Col = -1;
            this.xEditGridCell158.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell158, "xEditGridCell158");
            this.xEditGridCell158.IsUpdatable = false;
            this.xEditGridCell158.IsVisible = false;
            this.xEditGridCell158.Row = -1;
            // 
            // xEditGridCell159
            // 
            this.xEditGridCell159.CellName = "org_key";
            this.xEditGridCell159.Col = -1;
            this.xEditGridCell159.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell159, "xEditGridCell159");
            this.xEditGridCell159.IsUpdatable = false;
            this.xEditGridCell159.IsVisible = false;
            this.xEditGridCell159.Row = -1;
            // 
            // xEditGridCell160
            // 
            this.xEditGridCell160.CellName = "parent_key";
            this.xEditGridCell160.Col = -1;
            this.xEditGridCell160.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell160, "xEditGridCell160");
            this.xEditGridCell160.IsUpdatable = false;
            this.xEditGridCell160.IsVisible = false;
            this.xEditGridCell160.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "fkocs0300_seq";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "child_yn";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "jundal_table_out";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "jundal_part_out";
            this.xEditGridCell8.CellWidth = 181;
            this.xEditGridCell8.Col = 17;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.RowSpan = 2;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "jundal_table_inp";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "jundal_part_inp";
            this.xEditGridCell10.CellWidth = 181;
            this.xEditGridCell10.Col = 18;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.RowSpan = 2;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "move_part_out";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "move_part_inp";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "jundal_part_out_name";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "jundal_part_inp_name";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "wonnae_drg_yn";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsUpdatable = false;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "dv_5";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "dv_6";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "dv_7";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "dv_8";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "general_disp_yn";
            this.xEditGridCell23.CellWidth = 169;
            this.xEditGridCell23.Col = 7;
            this.xEditGridCell23.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.RowSpan = 2;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "generic_name";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell15.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell15.CellName = "select";
            this.xEditGridCell15.CellWidth = 30;
            this.xEditGridCell15.Col = 1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell15.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell15.RowSpan = 2;
            this.xEditGridCell15.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "yj_code";
            this.xEditGridCell26.Col = 27;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.Row = 1;
            // 
            // xGridHeader3
            // 
            this.xGridHeader3.Col = 11;
            this.xGridHeader3.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader3, "xGridHeader3");
            this.xGridHeader3.HeaderWidth = 15;
            // 
            // xEditGridCell161
            // 
            this.xEditGridCell161.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell161.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell161.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell161.CellName = "select";
            this.xEditGridCell161.CellWidth = 30;
            this.xEditGridCell161.Col = 1;
            this.xEditGridCell161.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell161, "xEditGridCell161");
            this.xEditGridCell161.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell161.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell161.RowSpan = 2;
            this.xEditGridCell161.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // xGridHeader1
            // 
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            // 
            // xGridHeader2
            // 
            resources.ApplyResources(this.xGridHeader2, "xGridHeader2");
            // 
            // pnlOrder
            // 
            this.pnlOrder.AccessibleDescription = null;
            this.pnlOrder.AccessibleName = null;
            resources.ApplyResources(this.pnlOrder, "pnlOrder");
            this.pnlOrder.BackgroundImage = null;
            this.pnlOrder.Controls.Add(this.grdOCS0307);
            this.pnlOrder.Controls.Add(this.grdOCS0303);
            this.pnlOrder.Controls.Add(this.tabGroupSerial);
            this.pnlOrder.DrawBorder = true;
            this.pnlOrder.Font = null;
            this.pnlOrder.Name = "pnlOrder";
            // 
            // grdOCS0307
            // 
            resources.ApplyResources(this.grdOCS0307, "grdOCS0307");
            this.grdOCS0307.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell27,
            this.xEditGridCell28});
            this.grdOCS0307.ColPerLine = 2;
            this.grdOCS0307.Cols = 3;
            this.grdOCS0307.ExecuteQuery = null;
            this.grdOCS0307.FixedCols = 1;
            this.grdOCS0307.FixedRows = 1;
            this.grdOCS0307.HeaderHeights.Add(21);
            this.grdOCS0307.Name = "grdOCS0307";
            this.grdOCS0307.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0307.ParamList")));
            this.grdOCS0307.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOCS0307.RowHeaderVisible = true;
            this.grdOCS0307.Rows = 2;
            this.grdOCS0307.RowStateCheckOnPaint = false;
            this.grdOCS0307.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS0307.ToolTipActive = true;
            this.grdOCS0307.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0307_QueryStarting);
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "sang_code";
            this.xEditGridCell27.CellWidth = 94;
            this.xEditGridCell27.Col = 1;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "sang_name";
            this.xEditGridCell28.CellWidth = 902;
            this.xEditGridCell28.Col = 2;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            // 
            // tabGroupSerial
            // 
            this.tabGroupSerial.AccessibleDescription = null;
            this.tabGroupSerial.AccessibleName = null;
            resources.ApplyResources(this.tabGroupSerial, "tabGroupSerial");
            this.tabGroupSerial.BackgroundImage = null;
            this.tabGroupSerial.Font = null;
            this.tabGroupSerial.IDEPixelArea = true;
            this.tabGroupSerial.IDEPixelBorder = false;
            this.tabGroupSerial.ImageList = this.ImageList;
            this.tabGroupSerial.Name = "tabGroupSerial";
            this.tabGroupSerial.SelectionChanged += new System.EventHandler(this.tabGroupSerial_SelectionChanged);
            // 
            // pnlTop
            // 
            this.pnlTop.AccessibleDescription = null;
            this.pnlTop.AccessibleName = null;
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.BackgroundImage = null;
            this.pnlTop.Controls.Add(this.cbxGeneric_YN);
            this.pnlTop.Controls.Add(this.btnSelectAllTab);
            this.pnlTop.Controls.Add(this.btnSelectCurrentTab);
            this.pnlTop.Font = null;
            this.pnlTop.Name = "pnlTop";
            // 
            // cbxGeneric_YN
            // 
            this.cbxGeneric_YN.AccessibleDescription = null;
            this.cbxGeneric_YN.AccessibleName = null;
            resources.ApplyResources(this.cbxGeneric_YN, "cbxGeneric_YN");
            this.cbxGeneric_YN.BackgroundImage = null;
            this.cbxGeneric_YN.Name = "cbxGeneric_YN";
            this.cbxGeneric_YN.UseVisualStyleBackColor = false;
            this.cbxGeneric_YN.CheckedChanged += new System.EventHandler(this.cbxGeneric_YN_CheckedChanged);
            // 
            // btnSelectAllTab
            // 
            this.btnSelectAllTab.AccessibleDescription = null;
            this.btnSelectAllTab.AccessibleName = null;
            resources.ApplyResources(this.btnSelectAllTab, "btnSelectAllTab");
            this.btnSelectAllTab.BackgroundImage = null;
            this.btnSelectAllTab.Image = global::IHIS.OCSA.Properties.Resources.YESEN1;
            this.btnSelectAllTab.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSelectAllTab.Name = "btnSelectAllTab";
            this.btnSelectAllTab.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnSelectAllTab.Tag = "n";
            this.btnSelectAllTab.Click += new System.EventHandler(this.btnDeleteAllTab_Click);
            // 
            // btnSelectCurrentTab
            // 
            this.btnSelectCurrentTab.AccessibleDescription = null;
            this.btnSelectCurrentTab.AccessibleName = null;
            resources.ApplyResources(this.btnSelectCurrentTab, "btnSelectCurrentTab");
            this.btnSelectCurrentTab.BackgroundImage = null;
            this.btnSelectCurrentTab.Image = global::IHIS.OCSA.Properties.Resources.YESUP1;
            this.btnSelectCurrentTab.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSelectCurrentTab.Name = "btnSelectCurrentTab";
            this.btnSelectCurrentTab.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnSelectCurrentTab.Click += new System.EventHandler(this.btnSelectAllTab_Click);
            // 
            // pnlFill
            // 
            this.pnlFill.AccessibleDescription = null;
            this.pnlFill.AccessibleName = null;
            resources.ApplyResources(this.pnlFill, "pnlFill");
            this.pnlFill.BackgroundImage = null;
            this.pnlFill.Controls.Add(this.pnlOrder);
            this.pnlFill.Font = null;
            this.pnlFill.Name = "pnlFill";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "YESEN1.ICO");
            this.imageList1.Images.SetKeyName(1, "YESUP1.ICO");
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "jundal_table_out";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "jundal_table_out";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // OCS0301Q09
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.grdOCS0301);
            this.Controls.Add(this.xLabel4);
            this.Controls.Add(this.txtSearchSetName);
            this.Controls.Add(this.tvwOCS0300);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.panMemb);
            this.Name = "OCS0301Q09";
            this.UserChanged += new System.EventHandler(this.OCS0301Q00_UserChanged);
            this.panMemb.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0301)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS0301)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS0303)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloOrder_danui)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloInputControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloMemb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSetOrderCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0303)).EndInit();
            this.pnlOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0307)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlFill.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell26;
        private XEditGrid grdOCS0307;
        private XEditGridCell xEditGridCell27;
        private XEditGridCell xEditGridCell28;
    }
}
