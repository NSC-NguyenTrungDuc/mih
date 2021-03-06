using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using IHIS.CloudConnector.Contracts.Arguments.Ocso;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using IHIS.CloudConnector.Contracts.Results.Ocso;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results;
using System.Collections.Generic;
using IHIS.OCSO.Properties;

namespace IHIS.OCSO
{
    /// <summary>
    /// OCS1003R00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class OCS1003R00 : IHIS.Framework.XScreen
    {
        #region Auto-gen code

        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XDataWindow dw_order_list;
        private IHIS.Framework.XDisplayBox dbxZoom;
        private IHIS.Framework.XButton btnZoomIn;
        private IHIS.Framework.XButton btnZoomOut;
        private IHIS.Framework.XButton btnExcel;
        private IHIS.Framework.XRadioButton rbtOCS;
        private IHIS.Framework.XRadioButton rbtALL;
        private IHIS.Framework.XRadioButton rbtOUT;
        private IHIS.Framework.XPaInfoBox xPaInfoBox1;
        private System.Windows.Forms.Panel panOrderInfo;
        private System.Windows.Forms.Panel panel1;
        private IHIS.Framework.MultiLayout layOUT1001;
        private IHIS.Framework.MultiLayout layOCS1001;
        private IHIS.Framework.MultiLayout layOCS1003;
        private IHIS.Framework.MultiLayout layOCS1003_PRINT;
        private IHIS.Framework.MultiLayout layDisplayOrderInfo;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem1;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem2;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem3;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem4;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem5;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem6;
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
        private MultiLayoutItem multiLayoutItem97;
        private MultiLayoutItem multiLayoutItem98;
        private MultiLayoutItem multiLayoutItem99;
        private MultiLayoutItem multiLayoutItem100;
        private MultiLayoutItem multiLayoutItem101;
        private MultiLayoutItem multiLayoutItem102;
        private MultiLayoutItem multiLayoutItem103;
        private MultiLayoutItem multiLayoutItem104;
        private MultiLayoutItem multiLayoutItem105;
        private MultiLayoutItem multiLayoutItem106;
        private MultiLayoutItem multiLayoutItem107;
        private MultiLayoutItem multiLayoutItem108;
        private MultiLayoutItem multiLayoutItem109;
        private MultiLayoutItem multiLayoutItem110;
        private MultiLayoutItem multiLayoutItem111;
        private MultiLayoutItem multiLayoutItem112;
        private MultiLayoutItem multiLayoutItem113;
        private MultiLayoutItem multiLayoutItem114;
        private MultiLayoutItem multiLayoutItem131;
        private MultiLayoutItem multiLayoutItem132;
        private MultiLayoutItem multiLayoutItem133;
        private MultiLayoutItem multiLayoutItem134;
        private MultiLayoutItem multiLayoutItem135;
        private MultiLayoutItem multiLayoutItem136;
        private MultiLayoutItem multiLayoutItem137;
        private MultiLayoutItem multiLayoutItem138;
        private MultiLayoutItem multiLayoutItem139;
        private MultiLayoutItem multiLayoutItem140;
        private MultiLayoutItem multiLayoutItem141;
        private MultiLayoutItem multiLayoutItem142;
        private MultiLayoutItem multiLayoutItem143;
        private MultiLayoutItem multiLayoutItem144;
        private MultiLayoutItem multiLayoutItem145;
        private MultiLayoutItem multiLayoutItem54;
        private MultiLayoutItem multiLayoutItem55;
        private MultiLayoutItem multiLayoutItem56;
        private MultiLayoutItem multiLayoutItem57;
        private MultiLayoutItem multiLayoutItem58;
        private MultiLayoutItem multiLayoutItem59;
        private MultiLayoutItem multiLayoutItem60;
        private MultiLayoutItem multiLayoutItem61;
        private MultiLayoutItem multiLayoutItem62;
        private MultiLayoutItem multiLayoutItem63;
        private MultiLayoutItem multiLayoutItem64;
        private MultiLayoutItem multiLayoutItem65;
        private MultiLayoutItem multiLayoutItem66;
        private MultiLayoutItem multiLayoutItem67;
        private MultiLayoutItem multiLayoutItem68;
        private MultiLayoutItem multiLayoutItem69;
        private MultiLayoutItem multiLayoutItem70;
        private MultiLayoutItem multiLayoutItem71;
        private MultiLayoutItem multiLayoutItem72;
        private MultiLayoutItem multiLayoutItem73;
        private MultiLayoutItem multiLayoutItem74;
        private MultiLayoutItem multiLayoutItem75;
        private MultiLayoutItem multiLayoutItem76;
        private MultiLayoutItem multiLayoutItem77;
        private MultiLayoutItem multiLayoutItem78;
        private MultiLayoutItem multiLayoutItem79;
        private MultiLayoutItem multiLayoutItem80;
        private MultiLayoutItem multiLayoutItem81;
        private MultiLayoutItem multiLayoutItem82;
        private MultiLayoutItem multiLayoutItem83;
        private MultiLayoutItem multiLayoutItem84;
        private MultiLayoutItem multiLayoutItem146;
        private MultiLayoutItem multiLayoutItem147;
        private MultiLayoutItem multiLayoutItem148;
        private MultiLayoutItem multiLayoutItem149;
        private MultiLayoutItem multiLayoutItem150;
        private MultiLayoutItem multiLayoutItem151;
        private MultiLayoutItem multiLayoutItem152;
        private MultiLayoutItem multiLayoutItem153;
        private MultiLayoutItem multiLayoutItem154;
        private MultiLayoutItem multiLayoutItem155;
        private MultiLayoutItem multiLayoutItem156;
        private MultiLayoutItem multiLayoutItem157;
        private MultiLayoutItem multiLayoutItem158;
        private MultiLayoutItem multiLayoutItem159;
        private MultiLayoutItem multiLayoutItem160;
        private MultiLayoutItem multiLayoutItem161;
        private MultiLayoutItem multiLayoutItem162;
        private MultiLayoutItem multiLayoutItem163;
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
        private MultiLayoutItem multiLayoutItem19;
        private MultiLayoutItem multiLayoutItem20;
        private MultiLayoutItem multiLayoutItem21;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS1003R00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPaInfoBox1 = new IHIS.Framework.XPaInfoBox();
            this.rbtOUT = new IHIS.Framework.XRadioButton();
            this.rbtOCS = new IHIS.Framework.XRadioButton();
            this.rbtALL = new IHIS.Framework.XRadioButton();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnExcel = new IHIS.Framework.XButton();
            this.btnZoomIn = new IHIS.Framework.XButton();
            this.dbxZoom = new IHIS.Framework.XDisplayBox();
            this.btnZoomOut = new IHIS.Framework.XButton();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.dw_order_list = new IHIS.Framework.XDataWindow();
            this.panOrderInfo = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.layOUT1001 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
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
            this.layOCS1001 = new IHIS.Framework.MultiLayout();
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
            this.layOCS1003 = new IHIS.Framework.MultiLayout();
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
            this.layOCS1003_PRINT = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem162 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem163 = new IHIS.Framework.MultiLayoutItem();
            this.layDisplayOrderInfo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xPaInfoBox1)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layOUT1001)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOCS1001)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOCS1003)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOCS1003_PRINT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDisplayOrderInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xPanel1.Controls.Add(this.xPaInfoBox1);
            this.xPanel1.Controls.Add(this.rbtOUT);
            this.xPanel1.Controls.Add(this.rbtOCS);
            this.xPanel1.Controls.Add(this.rbtALL);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // xPaInfoBox1
            // 
            this.xPaInfoBox1.AccessibleDescription = null;
            this.xPaInfoBox1.AccessibleName = null;
            resources.ApplyResources(this.xPaInfoBox1, "xPaInfoBox1");
            this.xPaInfoBox1.BackgroundImage = null;
            this.xPaInfoBox1.Font = null;
            this.xPaInfoBox1.Name = "xPaInfoBox1";
            // 
            // rbtOUT
            // 
            this.rbtOUT.AccessibleDescription = null;
            this.rbtOUT.AccessibleName = null;
            resources.ApplyResources(this.rbtOUT, "rbtOUT");
            this.rbtOUT.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbtOUT.BackgroundImage = null;
            this.rbtOUT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtOUT.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbtOUT.ImageList = this.ImageList;
            this.rbtOUT.Name = "rbtOUT";
            this.rbtOUT.UseVisualStyleBackColor = false;
            this.rbtOUT.Click += new System.EventHandler(this.rbtPrint_Click);
            // 
            // rbtOCS
            // 
            this.rbtOCS.AccessibleDescription = null;
            this.rbtOCS.AccessibleName = null;
            resources.ApplyResources(this.rbtOCS, "rbtOCS");
            this.rbtOCS.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.rbtOCS.BackgroundImage = null;
            this.rbtOCS.Checked = true;
            this.rbtOCS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtOCS.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.rbtOCS.ImageList = this.ImageList;
            this.rbtOCS.Name = "rbtOCS";
            this.rbtOCS.TabStop = true;
            this.rbtOCS.UseVisualStyleBackColor = false;
            this.rbtOCS.Click += new System.EventHandler(this.rbtPrint_Click);
            // 
            // rbtALL
            // 
            this.rbtALL.AccessibleDescription = null;
            this.rbtALL.AccessibleName = null;
            resources.ApplyResources(this.rbtALL, "rbtALL");
            this.rbtALL.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbtALL.BackgroundImage = null;
            this.rbtALL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtALL.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbtALL.ImageList = this.ImageList;
            this.rbtALL.Name = "rbtALL";
            this.rbtALL.UseVisualStyleBackColor = false;
            this.rbtALL.Click += new System.EventHandler(this.rbtPrint_Click);
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xPanel2.Controls.Add(this.btnExcel);
            this.xPanel2.Controls.Add(this.btnZoomIn);
            this.xPanel2.Controls.Add(this.dbxZoom);
            this.xPanel2.Controls.Add(this.btnZoomOut);
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // btnExcel
            // 
            this.btnExcel.AccessibleDescription = null;
            this.btnExcel.AccessibleName = null;
            resources.ApplyResources(this.btnExcel, "btnExcel");
            this.btnExcel.BackgroundImage = null;
            this.btnExcel.Name = "btnExcel";
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.AccessibleDescription = null;
            this.btnZoomIn.AccessibleName = null;
            resources.ApplyResources(this.btnZoomIn, "btnZoomIn");
            this.btnZoomIn.BackgroundImage = null;
            this.btnZoomIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomIn.Image")));
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // dbxZoom
            // 
            this.dbxZoom.AccessibleDescription = null;
            this.dbxZoom.AccessibleName = null;
            resources.ApplyResources(this.dbxZoom, "dbxZoom");
            this.dbxZoom.EditMaskType = IHIS.Framework.MaskType.Number;
            this.dbxZoom.GeneralNumberFormat = true;
            this.dbxZoom.Image = null;
            this.dbxZoom.Name = "dbxZoom";
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.AccessibleDescription = null;
            this.btnZoomOut.AccessibleName = null;
            resources.ApplyResources(this.btnZoomOut, "btnZoomOut");
            this.btnZoomOut.BackgroundImage = null;
            this.btnZoomOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomOut.Image")));
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // xButtonList1
            // 
            this.xButtonList1.AccessibleDescription = null;
            this.xButtonList1.AccessibleName = null;
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.BackgroundImage = null;
            this.xButtonList1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xButtonList1.IsVisiblePreview = false;
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Report;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // dw_order_list
            // 
            resources.ApplyResources(this.dw_order_list, "dw_order_list");
            this.dw_order_list.DataWindowObject = "dw_order_list_orderinfo";
            this.dw_order_list.LibraryList = "OCSO\\ocso.ocs1003r00.pbd";
            this.dw_order_list.Name = "dw_order_list";
            this.dw_order_list.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            // 
            // panOrderInfo
            // 
            this.panOrderInfo.AccessibleDescription = null;
            this.panOrderInfo.AccessibleName = null;
            resources.ApplyResources(this.panOrderInfo, "panOrderInfo");
            this.panOrderInfo.BackColor = System.Drawing.Color.White;
            this.panOrderInfo.BackgroundImage = null;
            this.panOrderInfo.Font = null;
            this.panOrderInfo.Name = "panOrderInfo";
            // 
            // panel1
            // 
            this.panel1.AccessibleDescription = null;
            this.panel1.AccessibleName = null;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = null;
            this.panel1.Controls.Add(this.panOrderInfo);
            this.panel1.Font = null;
            this.panel1.Name = "panel1";
            // 
            // layOUT1001
            // 
            this.layOUT1001.ExecuteQuery = null;
            this.layOUT1001.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20,
            this.multiLayoutItem21});
            this.layOUT1001.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOUT1001.ParamList")));
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "reser_yn";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "bunho";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "suname";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "suname2";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "birth";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "age_sex";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "doctor";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "doctor_name";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "gwa";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "gwa_name";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "chojae";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "chojae_name";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "naewon_date";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "input_gubun";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "order_end_yn";
            // 
            // layOCS1001
            // 
            this.layOCS1001.ExecuteQuery = null;
            this.layOCS1001.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem96});
            this.layOCS1001.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOCS1001.ParamList")));
            // 
            // multiLayoutItem85
            // 
            this.multiLayoutItem85.DataName = "ju_sang_yn";
            // 
            // multiLayoutItem86
            // 
            this.multiLayoutItem86.DataName = "sang_code";
            // 
            // multiLayoutItem87
            // 
            this.multiLayoutItem87.DataName = "ser";
            this.multiLayoutItem87.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem88
            // 
            this.multiLayoutItem88.DataName = "dis_sang_name";
            // 
            // multiLayoutItem89
            // 
            this.multiLayoutItem89.DataName = "sang_start_date";
            this.multiLayoutItem89.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem90
            // 
            this.multiLayoutItem90.DataName = "sang_end_date";
            this.multiLayoutItem90.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem91
            // 
            this.multiLayoutItem91.DataName = "sang_end_sayu";
            // 
            // multiLayoutItem92
            // 
            this.multiLayoutItem92.DataName = "sang_end_sayu_name";
            // 
            // multiLayoutItem93
            // 
            this.multiLayoutItem93.DataName = "sang_name";
            // 
            // multiLayoutItem94
            // 
            this.multiLayoutItem94.DataName = "pre_modifier_name";
            // 
            // multiLayoutItem95
            // 
            this.multiLayoutItem95.DataName = "post_modifier_name";
            // 
            // multiLayoutItem96
            // 
            this.multiLayoutItem96.DataName = "end_yn";
            // 
            // layOCS1003
            // 
            this.layOCS1003.ExecuteQuery = null;
            this.layOCS1003.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem145});
            this.layOCS1003.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOCS1003.ParamList")));
            // 
            // multiLayoutItem97
            // 
            this.multiLayoutItem97.DataName = "input_gubun";
            // 
            // multiLayoutItem98
            // 
            this.multiLayoutItem98.DataName = "input_gubun_name";
            // 
            // multiLayoutItem99
            // 
            this.multiLayoutItem99.DataName = "group_ser";
            this.multiLayoutItem99.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem100
            // 
            this.multiLayoutItem100.DataName = "mix_group";
            // 
            // multiLayoutItem101
            // 
            this.multiLayoutItem101.DataName = "order_gubun";
            // 
            // multiLayoutItem102
            // 
            this.multiLayoutItem102.DataName = "order_gubun_name";
            // 
            // multiLayoutItem103
            // 
            this.multiLayoutItem103.DataName = "order_gubun_bas";
            // 
            // multiLayoutItem104
            // 
            this.multiLayoutItem104.DataName = "hangmog_code";
            // 
            // multiLayoutItem105
            // 
            this.multiLayoutItem105.DataName = "hangmog_name";
            // 
            // multiLayoutItem106
            // 
            this.multiLayoutItem106.DataName = "sg_code";
            // 
            // multiLayoutItem107
            // 
            this.multiLayoutItem107.DataName = "sg_name";
            // 
            // multiLayoutItem108
            // 
            this.multiLayoutItem108.DataName = "suryang";
            // 
            // multiLayoutItem109
            // 
            this.multiLayoutItem109.DataName = "ord_danui";
            // 
            // multiLayoutItem110
            // 
            this.multiLayoutItem110.DataName = "ord_danui_name";
            // 
            // multiLayoutItem111
            // 
            this.multiLayoutItem111.DataName = "dv_time";
            // 
            // multiLayoutItem112
            // 
            this.multiLayoutItem112.DataName = "dv";
            // 
            // multiLayoutItem113
            // 
            this.multiLayoutItem113.DataName = "nalsu";
            // 
            // multiLayoutItem114
            // 
            this.multiLayoutItem114.DataName = "wonyoi_order_yn";
            // 
            // multiLayoutItem131
            // 
            this.multiLayoutItem131.DataName = "specimen_code";
            // 
            // multiLayoutItem132
            // 
            this.multiLayoutItem132.DataName = "specimen_name";
            // 
            // multiLayoutItem133
            // 
            this.multiLayoutItem133.DataName = "jusa";
            // 
            // multiLayoutItem134
            // 
            this.multiLayoutItem134.DataName = "jusa_name";
            // 
            // multiLayoutItem135
            // 
            this.multiLayoutItem135.DataName = "bogyong_code";
            // 
            // multiLayoutItem136
            // 
            this.multiLayoutItem136.DataName = "bogyong_name";
            // 
            // multiLayoutItem137
            // 
            this.multiLayoutItem137.DataName = "hope_date";
            // 
            // multiLayoutItem138
            // 
            this.multiLayoutItem138.DataName = "order_remark";
            // 
            // multiLayoutItem139
            // 
            this.multiLayoutItem139.DataName = "dangil_gumsa_order_yn";
            // 
            // multiLayoutItem140
            // 
            this.multiLayoutItem140.DataName = "dangil_gumsa_result_yn";
            // 
            // multiLayoutItem141
            // 
            this.multiLayoutItem141.DataName = "emergency";
            // 
            // multiLayoutItem142
            // 
            this.multiLayoutItem142.DataName = "reser_yn";
            // 
            // multiLayoutItem143
            // 
            this.multiLayoutItem143.DataName = "seq";
            this.multiLayoutItem143.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem144
            // 
            this.multiLayoutItem144.DataName = "reser_date";
            this.multiLayoutItem144.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem145
            // 
            this.multiLayoutItem145.DataName = "acting_date";
            this.multiLayoutItem145.DataType = IHIS.Framework.DataType.Date;
            // 
            // layOCS1003_PRINT
            // 
            this.layOCS1003_PRINT.ExecuteQuery = null;
            this.layOCS1003_PRINT.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem162,
            this.multiLayoutItem163});
            this.layOCS1003_PRINT.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOCS1003_PRINT.ParamList")));
            // 
            // multiLayoutItem54
            // 
            this.multiLayoutItem54.DataName = "print_gubun";
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "title_gubun";
            // 
            // multiLayoutItem56
            // 
            this.multiLayoutItem56.DataName = "reser_yn";
            // 
            // multiLayoutItem57
            // 
            this.multiLayoutItem57.DataName = "bunho";
            // 
            // multiLayoutItem58
            // 
            this.multiLayoutItem58.DataName = "suname";
            // 
            // multiLayoutItem59
            // 
            this.multiLayoutItem59.DataName = "suname2";
            // 
            // multiLayoutItem60
            // 
            this.multiLayoutItem60.DataName = "birth";
            // 
            // multiLayoutItem61
            // 
            this.multiLayoutItem61.DataName = "age_sex";
            // 
            // multiLayoutItem62
            // 
            this.multiLayoutItem62.DataName = "doctor";
            // 
            // multiLayoutItem63
            // 
            this.multiLayoutItem63.DataName = "doctor_name";
            // 
            // multiLayoutItem64
            // 
            this.multiLayoutItem64.DataName = "gwa";
            // 
            // multiLayoutItem65
            // 
            this.multiLayoutItem65.DataName = "gwa_name";
            // 
            // multiLayoutItem66
            // 
            this.multiLayoutItem66.DataName = "chojae";
            // 
            // multiLayoutItem67
            // 
            this.multiLayoutItem67.DataName = "chojae_name";
            // 
            // multiLayoutItem68
            // 
            this.multiLayoutItem68.DataName = "naewon_date";
            // 
            // multiLayoutItem69
            // 
            this.multiLayoutItem69.DataName = "comment";
            // 
            // multiLayoutItem70
            // 
            this.multiLayoutItem70.DataName = "tusuk_patient";
            // 
            // multiLayoutItem71
            // 
            this.multiLayoutItem71.DataName = "order_end_yn";
            // 
            // multiLayoutItem72
            // 
            this.multiLayoutItem72.DataName = "record_gubun";
            // 
            // multiLayoutItem73
            // 
            this.multiLayoutItem73.DataName = "ju_sang_yn";
            // 
            // multiLayoutItem74
            // 
            this.multiLayoutItem74.DataName = "dis_sang_name";
            // 
            // multiLayoutItem75
            // 
            this.multiLayoutItem75.DataName = "sang_start_date";
            // 
            // multiLayoutItem76
            // 
            this.multiLayoutItem76.DataName = "sang_end_date";
            // 
            // multiLayoutItem77
            // 
            this.multiLayoutItem77.DataName = "input_gubun";
            // 
            // multiLayoutItem78
            // 
            this.multiLayoutItem78.DataName = "input_gubun_name";
            // 
            // multiLayoutItem79
            // 
            this.multiLayoutItem79.DataName = "group_ser";
            this.multiLayoutItem79.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem80
            // 
            this.multiLayoutItem80.DataName = "mix_group";
            // 
            // multiLayoutItem81
            // 
            this.multiLayoutItem81.DataName = "order_gubun_name";
            // 
            // multiLayoutItem82
            // 
            this.multiLayoutItem82.DataName = "hangmog_code";
            // 
            // multiLayoutItem83
            // 
            this.multiLayoutItem83.DataName = "hangmog_name";
            // 
            // multiLayoutItem84
            // 
            this.multiLayoutItem84.DataName = "suryang";
            // 
            // multiLayoutItem146
            // 
            this.multiLayoutItem146.DataName = "ord_danui";
            // 
            // multiLayoutItem147
            // 
            this.multiLayoutItem147.DataName = "ord_danui_name";
            // 
            // multiLayoutItem148
            // 
            this.multiLayoutItem148.DataName = "dv_time";
            // 
            // multiLayoutItem149
            // 
            this.multiLayoutItem149.DataName = "dv";
            // 
            // multiLayoutItem150
            // 
            this.multiLayoutItem150.DataName = "nalsu";
            // 
            // multiLayoutItem151
            // 
            this.multiLayoutItem151.DataName = "order_detail";
            // 
            // multiLayoutItem152
            // 
            this.multiLayoutItem152.DataName = "wonyoi_order_yn";
            // 
            // multiLayoutItem153
            // 
            this.multiLayoutItem153.DataName = "specimen_code";
            // 
            // multiLayoutItem154
            // 
            this.multiLayoutItem154.DataName = "specimen_name";
            // 
            // multiLayoutItem155
            // 
            this.multiLayoutItem155.DataName = "jusa";
            // 
            // multiLayoutItem156
            // 
            this.multiLayoutItem156.DataName = "jusa_name";
            // 
            // multiLayoutItem157
            // 
            this.multiLayoutItem157.DataName = "bogyong_code";
            // 
            // multiLayoutItem158
            // 
            this.multiLayoutItem158.DataName = "bogyong_name";
            // 
            // multiLayoutItem159
            // 
            this.multiLayoutItem159.DataName = "order_remark";
            // 
            // multiLayoutItem160
            // 
            this.multiLayoutItem160.DataName = "seq";
            // 
            // multiLayoutItem161
            // 
            this.multiLayoutItem161.DataName = "prtmode";
            // 
            // multiLayoutItem162
            // 
            this.multiLayoutItem162.DataName = "reser_date";
            this.multiLayoutItem162.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem163
            // 
            this.multiLayoutItem163.DataName = "acting_date";
            this.multiLayoutItem163.DataType = IHIS.Framework.DataType.Date;
            // 
            // layDisplayOrderInfo
            // 
            this.layDisplayOrderInfo.ExecuteQuery = null;
            this.layDisplayOrderInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6});
            this.layDisplayOrderInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDisplayOrderInfo.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "group_ser";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "order_gubun";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "order_mark";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "order_info";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "order_detail";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "nalsu";
            // 
            // OCS1003R00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dw_order_list);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS1003R00";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCS1003R00_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xPaInfoBox1)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layOUT1001)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOCS1001)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOCS1003)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOCS1003_PRINT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDisplayOrderInfo)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #endregion

        #region [Instance Variable]
        //Message처리
        string mbxMsg = "", mbxCap = "";
        
        //내원일자
        private string mNaewon_date = "";
        //등록번호
        private string mBunho = "";
        //진료과
        private string mGwa = "";
        //진료의사
        private string mDoctor = "";
        //내원Type
        private string mNaewon_type = "";
        //내원번호
        private string mJubsu_no = "";
        //입력구분
        private string mInput_gubun = "";
        // 접수키
        private string mJubsuKey = "";

        //MAX LINE
        private const int MAXLINE    = 30;
        private int       mPrintLine = 1;

        //출력구분
        private int       mPrintGubun = 1;

        //화면 닫을지 여부
        private bool mAuto_close = false;

        //hospital code
        private string mHospCode = EnvironInfo.HospCode;

        // Updated by Cloud
        OCS1003R00FormLoadResult _grdData = new OCS1003R00FormLoadResult();
        #endregion

        #region Constructor
        /// <summary>
        /// OCS1003R00
        /// </summary>
        public OCS1003R00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
        }
        #endregion

        #region [Screen Event]
        protected override void OnLoad(EventArgs e)
        {    
            base.OnLoad (e);

            // DataWindow Preview설정
            dw_order_list.Modify("DataWindow.Print.Preview=Yes");                        
            dw_order_list.Modify("DataWindow.Print.Preview.Zoom= 100");
            dbxZoom.SetDataValue("100");

            // Implement multi-hospital
            dw_order_list.Modify(string.Format("hosp_name.Text = '{0}'", UserInfo.HospName));
        }

        private void OCS1003R00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
            // Call된 경우
            if ( e.OpenParam != null ) 
            {
                try
                {
                    mNaewon_date = DateTime.Now.ToString("yyyy/MM/dd");
                    if(e.OpenParam.Contains("naewon_date"))
                    {
                        if(TypeCheck.IsDateTime(e.OpenParam["naewon_date"].ToString()))
                            mNaewon_date = e.OpenParam["naewon_date"].ToString();
                    }

                    if(e.OpenParam.Contains("bunho"))
                    {
                        if(e.OpenParam["bunho"].ToString().Trim() == "")
                        {
                            mbxMsg = NetInfo.Language == LangMode.Jr ? "患者番号が正しくありません。ご確認ください。" : "환자번호가 정확하지않습니다. 확인바랍니다.";
                            mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                            XMessageBox.Show(mbxMsg, mbxCap);
                            return;
                        }
                        else
                            mBunho = e.OpenParam["bunho"].ToString().Trim();
                    }
                    else
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "患者番号が正しくありません。ご確認ください。" : "환자번호가 정확하지않습니다. 확인바랍니다.";
                        mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                        XMessageBox.Show(mbxMsg, mbxCap);    
                        return;
                    }

                    if(e.OpenParam.Contains("gwa"))
                    {
                        if(e.OpenParam["gwa"].ToString().Trim() == "")
                        {
                            mbxMsg = NetInfo.Language == LangMode.Jr ? "診療科が正しくありません。ご確認ください。" : "진료과가 정확하지않습니다. 확인바랍니다.";
                            mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                            XMessageBox.Show(mbxMsg, mbxCap);
                            mBunho = "";
                            return;
                        }
                        else
                            mGwa = e.OpenParam["gwa"].ToString().Trim();
                    }
                    else
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "診療科が正しくありません。ご確認ください。" : "진료과가 정확하지않습니다. 확인바랍니다.";
                        mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                        XMessageBox.Show(mbxMsg, mbxCap);    
                        return;
                    }

                    if(e.OpenParam.Contains("doctor"))
                    {
                        if(e.OpenParam["doctor"].ToString().Trim() == "")
                        {
                            mbxMsg = NetInfo.Language == LangMode.Jr ? "診療医師が正しくありません。ご確認ください。" : "진료의사가 정확하지않습니다. 확인바랍니다.";
                            mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                            XMessageBox.Show(mbxMsg, mbxCap);
                            mBunho = "";
                            return;
                        }
                        else
                            mDoctor = e.OpenParam["doctor"].ToString().Trim();
                    }
                    else
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "診療医師が正しくありません。ご確認ください。" : "진료의사가 정확하지않습니다. 확인바랍니다.";
                        mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                        XMessageBox.Show(mbxMsg, mbxCap);    
                        return;
                    }

                    if(e.OpenParam.Contains("naewon_type"))
                    {
                        if(e.OpenParam["naewon_type"].ToString().Trim() == "")
                        {
                            mbxMsg = NetInfo.Language == LangMode.Jr ? "来院類型が正しくありません。ご確認ください。" : "내원유형이 정확하지않습니다. 확인바랍니다.";
                            mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                            XMessageBox.Show(mbxMsg, mbxCap);
                            mBunho = "";
                            return;
                        }
                        else
                            mNaewon_type = e.OpenParam["naewon_type"].ToString().Trim();
                    }
                    else
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "来院類型が正しくありません。ご確認ください。" : "내원유형이 정확하지않습니다. 확인바랍니다.";
                        mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                        XMessageBox.Show(mbxMsg, mbxCap);    
                        return;
                    }

                    mJubsu_no = "1";
                    if(e.OpenParam.Contains("jubsu_no"))
                    {
                        if(TypeCheck.IsInt(e.OpenParam["jubsu_no"].ToString()))
                            mJubsu_no = e.OpenParam["jubsu_no"].ToString();
                    }

                    if(e.OpenParam.Contains("input_gubun"))
                    {
                        if(TypeCheck.IsNull(e.OpenParam["input_gubun"].ToString().Trim()))
                        {
                            mbxMsg = NetInfo.Language == LangMode.Jr ? "入力区分が正しくありません。ご確認ください。" : "입력구분이 정확하지않습니다. 확인바랍니다.";
                            mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                            XMessageBox.Show(mbxMsg, mbxCap);
                            this.Close();
                            return;
                        }
                        else
                            mInput_gubun = e.OpenParam["input_gubun"].ToString().Trim();
                    }
                    else
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "入力区分が正しくありません。ご確認ください。" : "입력구분이 정확하지않습니다. 확인바랍니다.";
                        mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                        XMessageBox.Show(mbxMsg, mbxCap);    
                        this.Close();
                        return;
                    }

                    if (e.OpenParam.Contains("jubsu_key"))
                    {
                        this.mJubsuKey = e.OpenParam["jubsu_key"].ToString();
                    }

                    //Data가 없는 경우 화면 닫을지 여부
                    if(e.OpenParam.Contains("auto_close"))
                    {
                        mAuto_close = bool.Parse(e.OpenParam["auto_close"].ToString().Trim());
                        if(mAuto_close) this.ParentForm.WindowState = FormWindowState.Minimized;
                    }
                }
                catch (Exception ex)
                {
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message, "");    
                    this.Close();
                }
            }
            else
            {
                //mBunho = "000400403";
                //mGwa = "01";
                //mDoctor = "D1001";
                //mNaewon_date = "2006/04/18";                
                //mNaewon_type = "0";
                //mJubsu_no = "1";
                //mInput_gubun = "D0";
            }

            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        private void PostLoad()
        {                
            layOUT1001.SetBindVarValue("f_naewon_date", mNaewon_date);
            layOUT1001.SetBindVarValue("f_bunho"      , mBunho      );
            layOUT1001.SetBindVarValue("f_gwa"        , mGwa        );
            layOUT1001.SetBindVarValue("f_doctor"     , mDoctor     );
            layOUT1001.SetBindVarValue("f_naewon_type", mNaewon_type);
            layOUT1001.SetBindVarValue("f_jubsu_no"   , mJubsu_no   );
            layOUT1001.SetBindVarValue("f_input_gubun", mInput_gubun);
            layOUT1001.SetBindVarValue("f_hosp_code"  , mHospCode);

            layOCS1001.SetBindVarValue("f_naewon_date", mNaewon_date);
            layOCS1001.SetBindVarValue("f_bunho"      , mBunho      );
            layOCS1001.SetBindVarValue("f_gwa"        , mGwa        );
            layOCS1001.SetBindVarValue("f_doctor"     , mDoctor     );
            layOCS1001.SetBindVarValue("f_naewon_type", mNaewon_type);
            layOCS1001.SetBindVarValue("f_jubsu_no"   , mJubsu_no   );
            layOCS1001.SetBindVarValue("f_hosp_code"  , mHospCode);

            layOCS1003.SetBindVarValue("f_naewon_date", mNaewon_date);
            layOCS1003.SetBindVarValue("f_bunho"      , mBunho      );
            layOCS1003.SetBindVarValue("f_gwa"        , mGwa        );
            layOCS1003.SetBindVarValue("f_doctor"     , mDoctor     );
            layOCS1003.SetBindVarValue("f_naewon_type", mNaewon_type);
            layOCS1003.SetBindVarValue("f_jubsu_no"   , mJubsu_no   );
            layOCS1003.SetBindVarValue("f_input_gubun", mInput_gubun);
            layOCS1003.SetBindVarValue("f_hosp_code"  , mHospCode);

            LoadData();

            if(mAuto_close)
            {
                //OCS
                if(dw_order_list.RowCount > 0) this.Print();
                
                this.Close();
                return;
            }
        }
        #endregion

        #region [Data Load]
        private void LoadData()
        {
            try
            {    
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                SetMsg("");

                // Cloud updated code START
                layOUT1001.ExecuteQuery = GetLayOUT1001;
                layOCS1001.ExecuteQuery = GetLayOCS1001;
                layOCS1003.ExecuteQuery = GetLayOCS1003;

                OCS1003R00FormLoadArgs args = new OCS1003R00FormLoadArgs();
                args.Bunho = mBunho;
                args.Doctor = mDoctor;
                args.Gwa = mGwa;
                args.InputGubun = mInput_gubun;
                args.JubsuNo = mJubsu_no;
                args.NaewonDate = mNaewon_date;
                args.NaewonType = mNaewon_type;
                OCS1003R00FormLoadResult res = CloudService.Instance.Submit<OCS1003R00FormLoadResult, OCS1003R00FormLoadArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    _grdData = res;
                }

                layOUT1001.QueryLayout(false);
                //layOCS1001.QueryLayout(false);
                layOCS1003.QueryLayout(true);
                // Cloud updated code END

                SetOrderData(false);
                
            }
            finally
            {
                SetMsg(" ");
                Cursor.Current = System.Windows.Forms.Cursors.Default;
            }
        }

        private void SetOrderData(bool allPrint)
        {
            dw_order_list.Reset();
            this.layOCS1003_PRINT.Reset();

            if( layOUT1001.RowCount < 1 || layOCS1003.RowCount < 1 ) return;

            int currentRowIndex = -1;

            //input_gubun, group_ser, 복용법, 일수 등등 출력관련
            string pre_input_gubun, pre_group_ser, pre_bogyong_code, pre_hope_date, pre_nalsu;
            
            //처방단위, DV, 일수는 출력에 맞게 수정한다.
            string hangmog_name_header, hangmog_name, ord_danui, dv, nalsu, order_detail, remark;
            
            //환자정보(접수정보)
            for(int out1001Index = 0; out1001Index < layOUT1001.RowCount; out1001Index++)
            {
                mPrintLine = 1;
                
                //currentRowIndex = InsertPrintRow(out1001Index, allPrint);

                //dataWindow group header
                if(layOCS1001.RowCount > 0) mPrintLine = mPrintLine + 1;
                
                //상병
                for(int ocs1001Index = 0; ocs1001Index < layOCS1001.RowCount; ocs1001Index++)
                {
                    //if(currentRowIndex != 0)
                    currentRowIndex = InsertPrintRow(out1001Index, allPrint);

                    //record gubun
                    layOCS1003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "0");
                    //prtmode
                    layOCS1003_PRINT.SetItemValue(currentRowIndex, "prtmode", "2");
                    //주상병
                    layOCS1003_PRINT.SetItemValue(currentRowIndex, "ju_sang_yn", layOCS1001.GetItemString(ocs1001Index, "ju_sang_yn"));
                    //상병명
                    layOCS1003_PRINT.SetItemValue(currentRowIndex, "dis_sang_name", layOCS1001.GetItemString(ocs1001Index, "dis_sang_name"));
                    //상병시작일
                    layOCS1003_PRINT.SetItemValue(currentRowIndex, "sang_start_date", layOCS1001.GetItemString(ocs1001Index, "sang_start_date"));
                    //상병종료일
                    layOCS1003_PRINT.SetItemValue(currentRowIndex, "sang_end_date", layOCS1001.GetItemString(ocs1001Index, "sang_end_date"));

                    //reser_yn //예약검사를 별도용지에 출력하기 위해서
                    layOCS1003_PRINT.SetItemValue(currentRowIndex, "reser_yn", "0");

                    if(!TypeCheck.IsNull(layOCS1001.GetItemString(ocs1001Index, "sang_end_date")))
                    {
                        currentRowIndex = InsertPrintRow(out1001Index, allPrint);
                        //record gubun
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "0");
                        //prtmode
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "prtmode", "2");
                        //reser_yn //예약검사를 별도용지에 출력하기 위해서
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "reser_yn", "0");
                        //상병종료사유
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "dis_sang_name",  " ┗ 傷病終了事由 : " + layOCS1001.GetItemString(ocs1001Index, "sang_end_sayu_name"));
                    }

                    if(currentRowIndex == 0) currentRowIndex++;
                }

                //처방
                //dataWindow group header
                if(layOCS1003.RowCount > 0)
                {
                    mPrintLine = mPrintLine == MAXLINE ? 1 : mPrintLine + 1;
                    pre_input_gubun  = " ";
                    pre_group_ser    = layOCS1003.GetItemString(0, "group_ser"   );
                    pre_bogyong_code = layOCS1003.GetItemString(0, "bogyong_code"); 
                    pre_hope_date    = layOCS1003.GetItemString(0, "hope_date"   ); 
                    pre_nalsu        = layOCS1003.GetItemString(0, "nalsu"       );

                }
                else
                {
                    pre_input_gubun  = " ";
                    pre_group_ser    = " ";
                    pre_bogyong_code = " ";
                    pre_hope_date    = " ";
                    pre_nalsu        = " ";
                }
                
                for(int ocs1003Index = 0; ocs1003Index < layOCS1003.RowCount; ocs1003Index++)
                {                    
                    if(currentRowIndex != 0)
                    {
                        if( pre_input_gubun  != layOCS1003.GetItemString(ocs1003Index, "input_gubun" ) ||
                            pre_group_ser    != layOCS1003.GetItemString(ocs1003Index, "group_ser"   ) ||
                            pre_bogyong_code != layOCS1003.GetItemString(ocs1003Index, "bogyong_code") ||
                            pre_hope_date    != layOCS1003.GetItemString(ocs1003Index, "hope_date"   ) ||
                            pre_nalsu        != layOCS1003.GetItemString(ocs1003Index, "nalsu"       ) )
                        {
                            //내복약, 외용약처리[복용법, 복용시작일, 날수]
                            if( layOCS1003.GetItemString(ocs1003Index -1, "order_gubun_bas" ).Trim() == "C" )
                            {
                                currentRowIndex = InsertPrintRow(out1001Index, allPrint);
                                layOCS1003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "1");
                                layOCS1003_PRINT.SetItemValue(currentRowIndex, "prtmode", "1");
                                layOCS1003_PRINT.SetItemValue(currentRowIndex, "group_ser"       , layOCS1003.GetItemString(ocs1003Index -1, "group_ser"       ));
                                layOCS1003_PRINT.SetItemValue(currentRowIndex, "order_gubun_name", layOCS1003.GetItemString(ocs1003Index -1, "order_gubun_name"));
                                

                                //reser_yn //예약검사를 별도용지에 출력하기 위해서
                                //layOCS1003_PRINT.SetItemValue(currentRowIndex, "reser_yn", layOCS1003.GetItemString(ocs1003Index -1, "reser_yn"));
                                layOCS1003_PRINT.SetItemValue(currentRowIndex, "reser_yn", "N");
                                
                                //복용법
                                remark = layOCS1003.GetItemString(ocs1003Index  -1, "bogyong_name" );
                                
                                //투약시작일
                                if(!TypeCheck.IsNull(layOCS1003.GetItemString(ocs1003Index  -1, "hope_date" ).Trim()))
                                {
                                    layOCS1003_PRINT.SetItemValue(currentRowIndex, "order_remark", remark);

                                    currentRowIndex = InsertPrintRow(out1001Index, allPrint);
                                    layOCS1003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "1");
                                    layOCS1003_PRINT.SetItemValue(currentRowIndex, "prtmode", "1");
                                    layOCS1003_PRINT.SetItemValue(currentRowIndex, "group_ser"       , layOCS1003.GetItemString(ocs1003Index -1, "group_ser"       ));
                                    layOCS1003_PRINT.SetItemValue(currentRowIndex, "order_gubun_name", layOCS1003.GetItemString(ocs1003Index -1, "order_gubun_name"));

                                    //reser_yn //예약검사를 별도용지에 출력하기 위해서
                                    //layOCS1003_PRINT.SetItemValue(currentRowIndex, "reser_yn", layOCS1003.GetItemString(ocs1003Index -1, "reser_yn"));
                                    layOCS1003_PRINT.SetItemValue(currentRowIndex, "reser_yn", "N");

                                    remark = " ◈ 投薬スタート日 : " + layOCS1003.GetItemString(ocs1003Index  -1, "hope_date" );
                                }

                                layOCS1003_PRINT.SetItemValue(currentRowIndex, "order_remark", remark);
                                
                                //날수
                                nalsu = layOCS1003.GetItemString(ocs1003Index  -1, "nalsu").Trim().Replace("D", "") + "日";
                                layOCS1003_PRINT.SetItemValue(currentRowIndex, "nalsu", nalsu);
                            }

                            //그룹이 변경될 때 New로 표시한다.
                            if(pre_group_ser != layOCS1003.GetItemString(ocs1003Index, "group_ser") && mPrintLine != MAXLINE )
                            {
    //                            currentRowIndex = InsertPrintRow(out1001Index);
    //                            //record gubun
    //                            layOCS1003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "1");
    //                            //prtmode
    //                            layOCS1003_PRINT.SetItemValue(currentRowIndex, "prtmode", "1");

                            }

                            //input_gubun이 변경될 때 input_gubun명을 표시한다.
                            if(pre_input_gubun != layOCS1003.GetItemString(ocs1003Index, "input_gubun"))
                            {
                                currentRowIndex = InsertPrintRow(out1001Index, allPrint);
                                layOCS1003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "1");
                                layOCS1003_PRINT.SetItemValue(currentRowIndex, "prtmode", "2");
                                layOCS1003_PRINT.SetItemValue(currentRowIndex, "input_gubun"     , layOCS1003.GetItemString(ocs1003Index, "input_gubun"     ));
                                layOCS1003_PRINT.SetItemValue(currentRowIndex, "input_gubun_name", "【"+ layOCS1003.GetItemString(ocs1003Index, "input_gubun_name") + "】");

                                //reser_yn //예약검사를 별도용지에 출력하기 위해서
                                //layOCS1003_PRINT.SetItemValue(currentRowIndex, "reser_yn", layOCS1003.GetItemString(ocs1003Index, "reser_yn"));
                                layOCS1003_PRINT.SetItemValue(currentRowIndex, "reser_yn", "N");

                            }
                        }

                        currentRowIndex = InsertPrintRow(out1001Index, allPrint);
                    }
                    else
                    {
                        currentRowIndex = InsertPrintRow(out1001Index, allPrint);
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "1");
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "prtmode", "2");
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "input_gubun"     , layOCS1003.GetItemString(ocs1003Index, "input_gubun"     ));
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "input_gubun_name", "【"+ layOCS1003.GetItemString(ocs1003Index, "input_gubun_name") + "】");
                    }


                    //record gubun
                    layOCS1003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "1");
                    //prtmode
                    layOCS1003_PRINT.SetItemValue(currentRowIndex, "prtmode", "0");
                    
                    layOCS1003_PRINT.SetItemValue(currentRowIndex, "group_ser"       , layOCS1003.GetItemString(ocs1003Index, "group_ser"       ));
                    layOCS1003_PRINT.SetItemValue(currentRowIndex, "mix_group"       , layOCS1003.GetItemString(ocs1003Index, "mix_group"       ));
                    layOCS1003_PRINT.SetItemValue(currentRowIndex, "order_gubun_name", layOCS1003.GetItemString(ocs1003Index, "order_gubun_name"));
                    layOCS1003_PRINT.SetItemValue(currentRowIndex, "hangmog_code"    , layOCS1003.GetItemString(ocs1003Index, "hangmog_code"    ));

                    //reser_yn //예약검사를 별도용지에 출력하기 위해서
                    //layOCS1003_PRINT.SetItemValue(currentRowIndex, "reser_yn", layOCS1003.GetItemString(ocs1003Index, "reser_yn"));
                    layOCS1003_PRINT.SetItemValue(currentRowIndex, "reser_yn", "N");
                    
                    hangmog_name = layOCS1003.GetItemString(ocs1003Index, "hangmog_name");
                    hangmog_name_header = "";

                    //원외여부                
                    if(layOCS1003.GetItemString(ocs1003Index, "wonyoi_order_yn") == "Y")
                        hangmog_name = "[院外]" + hangmog_name;
                    
                    //예약
                    if(layOCS1003.GetItemString(ocs1003Index, "reser_yn") == "Y")
                        hangmog_name_header = hangmog_name_header + "[予]";
                    
                    //응급
                    if(layOCS1003.GetItemString(ocs1003Index, "emergency") == "Y")
                        hangmog_name_header = hangmog_name_header + "[緊急]";
                    
                    //MIX
                    if(!TypeCheck.IsNull(layOCS1003.GetItemString(ocs1003Index, "mix_group")))
                        hangmog_name_header = hangmog_name_header + "[MIX " + layOCS1003.GetItemString(ocs1003Index, "mix_group").Trim() + "] ";

                    layOCS1003_PRINT.SetItemValue(currentRowIndex, "hangmog_name"    , hangmog_name_header +  hangmog_name);

                      
                    //Order 상세[수량 + 단위 + DV Time + DV]
                    order_detail = layOCS1003.GetItemString(ocs1003Index, "suryang");
                    layOCS1003_PRINT.SetItemValue(currentRowIndex, "suryang"         , order_detail);
                    
                    //Order 단위
                    ord_danui = "";                    

                    if( layOCS1003.GetItemString(ocs1003Index, "ord_danui_name") == "H" )
                        ord_danui = "時間";
                    else if( layOCS1003.GetItemString(ocs1003Index, "ord_danui_name") == "L" )
                        ord_danui = "ℓ/分";
                    else
                        ord_danui = layOCS1003.GetItemString(ocs1003Index, "ord_danui_name");

                    layOCS1003_PRINT.SetItemValue(currentRowIndex, "ord_danui"       , layOCS1003.GetItemString(ocs1003Index, "ord_danui"  ));
                    layOCS1003_PRINT.SetItemValue(currentRowIndex, "ord_danui_name"  , ord_danui);

                    order_detail = order_detail + ord_danui.Trim();
                                        
                    layOCS1003_PRINT.SetItemValue(currentRowIndex, "dv_time"         , layOCS1003.GetItemString(ocs1003Index, "dv_time"    ));                    
                    dv = layOCS1003.GetItemString(ocs1003Index, "dv_time").Trim() + " " + layOCS1003.GetItemString(ocs1003Index, "dv").Trim();
                    layOCS1003_PRINT.SetItemValue(currentRowIndex, "dv"              , dv );

                    layOCS1003_PRINT.SetItemValue(currentRowIndex, "reser_date", this.GetMMDD(layOCS1003.GetItemString(ocs1003Index , "reser_date")));
                    layOCS1003_PRINT.SetItemValue(currentRowIndex, "acting_date", this.GetMMDD(layOCS1003.GetItemString(ocs1003Index, "acting_date")));

                    order_detail = order_detail + dv;
                    layOCS1003_PRINT.SetItemValue(currentRowIndex, "order_detail"    , order_detail );
                    
                    //날수
                    if( layOCS1003.GetItemString(ocs1003Index, "order_gubun_bas" ).Trim() != "C" &&  
                        layOCS1003.GetItemString(ocs1003Index, "order_gubun_bas" ).Trim() != "D"  )
                    {
                        nalsu = "";
                        if( layOCS1003.GetItemString(ocs1003Index, "nalsu").IndexOf("D") >= 0 )
                            nalsu = layOCS1003.GetItemString(ocs1003Index, "nalsu").Trim().Replace("D", "") + "日";
                        else if( layOCS1003.GetItemString(ocs1003Index, "nalsu").IndexOf("M") >= 0 )
                            nalsu = layOCS1003.GetItemString(ocs1003Index, "nalsu").Trim().Replace("M", "") + "分";

                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "nalsu", nalsu);
                    }
                    
                    //검체명
                    if(layOCS1003.GetItemString(ocs1003Index, "specimen_name" ).Trim() != "" && layOCS1003.GetItemString(ocs1003Index, "specimen_name" ).Trim() != "*")
                    {
                        if(!TypeCheck.IsNull(layOCS1003.GetItemString(ocs1003Index, "suryang")) && layOCS1003.GetItemString(ocs1003Index, "suryang") != "1")
                            layOCS1003_PRINT.SetItemValue(currentRowIndex, "specimen_name", layOCS1003.GetItemString(ocs1003Index, "specimen_name") + "     " + order_detail + "回");
                        else
                            layOCS1003_PRINT.SetItemValue(currentRowIndex, "specimen_name", layOCS1003.GetItemString(ocs1003Index, "specimen_name"));
                    }
                    
                    //의사회계용인 경우에는 점수명을 보여준다.
                    if(allPrint && !TypeCheck.IsNull(layOCS1003.GetItemString(ocs1003Index, "sg_code")))
                    {
                        currentRowIndex = InsertPrintRow(out1001Index, allPrint);
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "1");
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "prtmode", "1");

                        //reser_yn //예약검사를 별도용지에 출력하기 위해서
                        //layOCS1003_PRINT.SetItemValue(currentRowIndex, "reser_yn", layOCS1003.GetItemString(ocs1003Index, "reser_yn"));
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "reser_yn", "N");

                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "group_ser"       , layOCS1003.GetItemString(ocs1003Index, "group_ser"       ));
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "order_gubun_name", layOCS1003.GetItemString(ocs1003Index, "order_gubun_name"));
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "order_remark"    , "└ [" + layOCS1003.GetItemString(ocs1003Index, "sg_code") + "] " +layOCS1003.GetItemString(ocs1003Index, "sg_name"));
                    }

                    remark = "";

                    //주사
                    if(( layOCS1003.GetItemString(ocs1003Index, "order_gubun_bas" ).Trim() == "A"  ||  
                        layOCS1003.GetItemString(ocs1003Index, "order_gubun_bas" ).Trim() == "B"  ) && 
                        layOCS1003.GetItemString(ocs1003Index, "jusa" ).Trim() != "0" && layOCS1003.GetItemString(ocs1003Index, "jusa_name" ).Trim() != "")
                    {
                        currentRowIndex = InsertPrintRow(out1001Index, allPrint);
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "1");
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "prtmode", "1");

                        //reser_yn //예약검사를 별도용지에 출력하기 위해서
                        //layOCS1003_PRINT.SetItemValue(currentRowIndex, "reser_yn", layOCS1003.GetItemString(ocs1003Index, "reser_yn"));
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "reser_yn", "N");
                        

                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "group_ser"       , layOCS1003.GetItemString(ocs1003Index, "group_ser"       ));
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "order_gubun_name", layOCS1003.GetItemString(ocs1003Index, "order_gubun_name"));

                        remark = " 注射 : " + layOCS1003.GetItemString(ocs1003Index, "jusa_name" );
                        if( (layOCS1003.GetItemString(ocs1003Index, "order_gubun_bas" ).Trim() == "A" || layOCS1003.GetItemString(ocs1003Index, "order_gubun_bas" ).Trim() == "B" )
                            && layOCS1003.GetItemString(ocs1003Index, "bogyong_code" ).Trim() != "")
                            remark = remark + " [速度 : " + layOCS1003.GetItemString(ocs1003Index, "bogyong_code" ).Trim() + " ㎖/hr]";

                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "order_remark", remark);
                    }

                    //희망일자
                    if(!TypeCheck.IsNull(layOCS1003.GetItemString(ocs1003Index, "hope_date" ).Trim())) 
                    {   
                        if( layOCS1003.GetItemString(ocs1003Index, "order_gubun_bas" ).Trim() != "C" &&  
                            layOCS1003.GetItemString(ocs1003Index, "order_gubun_bas" ).Trim() != "D"  )
                        {
                            //if(remark.Length == 0)
                            //{
                            currentRowIndex = InsertPrintRow(out1001Index, allPrint);
                            layOCS1003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "1");
                            layOCS1003_PRINT.SetItemValue(currentRowIndex, "prtmode", "1");

                            //reser_yn //예약검사를 별도용지에 출력하기 위해서
                            //layOCS1003_PRINT.SetItemValue(currentRowIndex, "reser_yn", layOCS1003.GetItemString(ocs1003Index, "reser_yn"));
                            layOCS1003_PRINT.SetItemValue(currentRowIndex, "reser_yn", "N");

                            layOCS1003_PRINT.SetItemValue(currentRowIndex, "group_ser"       , layOCS1003.GetItemString(ocs1003Index, "group_ser"       ));
                            layOCS1003_PRINT.SetItemValue(currentRowIndex, "order_gubun_name", layOCS1003.GetItemString(ocs1003Index, "order_gubun_name"));
                            //}

                            //remark = remark +" 希望日 : " + layOCS1003.GetItemString(ocs1003Index, "hope_date" );
                            //remark = " 希望日 : " + layOCS1003.GetItemString(ocs1003Index, "hope_date" );

                            layOCS1003_PRINT.SetItemValue(currentRowIndex, "order_remark", remark);
                        }
                        
                    }

                    //처치 부위
                    if( layOCS1003.GetItemString(ocs1003Index, "order_gubun_bas" ).Trim() == "H" &&
                        layOCS1003.GetItemString(ocs1003Index, "bogyong_name" ).Trim() != "")
                    {
                        currentRowIndex = InsertPrintRow(out1001Index, allPrint);
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "1");
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "prtmode", "1");

                        //reser_yn //예약검사를 별도용지에 출력하기 위해서
                        //layOCS1003_PRINT.SetItemValue(currentRowIndex, "reser_yn", layOCS1003.GetItemString(ocs1003Index, "reser_yn"));
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "reser_yn", "N");

                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "group_ser"       , layOCS1003.GetItemString(ocs1003Index, "group_ser"       ));
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "order_gubun_name", layOCS1003.GetItemString(ocs1003Index, "order_gubun_name"));

                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "order_remark"    , layOCS1003.GetItemString(ocs1003Index, "bogyong_name" ).Trim());
                    }

                    //외용약
                    if( layOCS1003.GetItemString(ocs1003Index, "order_gubun_bas" ).Trim() == "D" )
                    {
                        currentRowIndex = InsertPrintRow(out1001Index, allPrint);
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "1");
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "prtmode", "1");

                        //reser_yn //예약검사를 별도용지에 출력하기 위해서
                        //layOCS1003_PRINT.SetItemValue(currentRowIndex, "reser_yn", layOCS1003.GetItemString(ocs1003Index, "reser_yn"));
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "reser_yn", "N");

                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "group_ser"       , layOCS1003.GetItemString(ocs1003Index, "group_ser"       ));
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "order_gubun_name", layOCS1003.GetItemString(ocs1003Index, "order_gubun_name"));
                                
                        //복용법
                        remark = layOCS1003.GetItemString(ocs1003Index, "bogyong_name" );
                                
                        //투약시작일
                        if(!TypeCheck.IsNull(layOCS1003.GetItemString(ocs1003Index, "hope_date" ).Trim()))
                            remark = remark + " 投薬スタート日 : " + layOCS1003.GetItemString(ocs1003Index, "hope_date" );
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "order_remark", remark);                       
                    }

                    //처방 Remark
                    if(layOCS1003.GetItemString(ocs1003Index, "order_remark" ).Trim() != "")
                    {
                        currentRowIndex = InsertPrintRow(out1001Index, allPrint);
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "1");
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "prtmode", "1");

                        //reser_yn //예약검사를 별도용지에 출력하기 위해서
                        //layOCS1003_PRINT.SetItemValue(currentRowIndex, "reser_yn", layOCS1003.GetItemString(ocs1003Index, "reser_yn"));
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "reser_yn", "N");


                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "group_ser"       , layOCS1003.GetItemString(ocs1003Index, "group_ser"       ));
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "order_gubun_name", layOCS1003.GetItemString(ocs1003Index, "order_gubun_name"));

                        remark = "┗ " + layOCS1003.GetItemString(ocs1003Index, "order_remark" );
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "order_remark", remark);
                    }

                    pre_input_gubun  = layOCS1003.GetItemString(ocs1003Index, "input_gubun" );
                    pre_group_ser    = layOCS1003.GetItemString(ocs1003Index, "group_ser"   );
                    pre_bogyong_code = layOCS1003.GetItemString(ocs1003Index, "bogyong_code");
                    pre_hope_date    = layOCS1003.GetItemString(ocs1003Index, "hope_date"   ); 
                    pre_nalsu        = layOCS1003.GetItemString(ocs1003Index, "nalsu"       );

                    //if(currentRowIndex == 0) currentRowIndex++;

                    //마직막 row인 경우 내복약, 외용약처리 [복용법, 투약시작일, 날수]
                    if( ocs1003Index == layOCS1003.RowCount -1 &&
                        ( layOCS1003.GetItemString(ocs1003Index, "order_gubun_bas" ).Trim() == "C" ))
                    {
                        currentRowIndex = InsertPrintRow(out1001Index, allPrint);
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "1");
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "prtmode", "1");

                        //reser_yn //예약검사를 별도용지에 출력하기 위해서
                        //layOCS1003_PRINT.SetItemValue(currentRowIndex, "reser_yn", layOCS1003.GetItemString(ocs1003Index, "reser_yn"));
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "reser_yn", "N");

                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "group_ser"       , layOCS1003.GetItemString(ocs1003Index, "group_ser"       ));
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "order_gubun_name", layOCS1003.GetItemString(ocs1003Index, "order_gubun_name"));
                                
                        //복용법
                        remark = layOCS1003.GetItemString(ocs1003Index, "bogyong_name" );
                                
                        //투약시작일
                        if(!TypeCheck.IsNull(layOCS1003.GetItemString(ocs1003Index, "hope_date" ).Trim()))
                            remark = remark + " 投薬スタート日 : " + layOCS1003.GetItemString(ocs1003Index, "hope_date" );
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "order_remark", remark);
                                
                        nalsu = layOCS1003.GetItemString(ocs1003Index, "nalsu").Trim().Replace("D", "") + "日";
                        layOCS1003_PRINT.SetItemValue(currentRowIndex, "nalsu", nalsu);
                    }

                    if(currentRowIndex == 0) currentRowIndex++;

                }

            }

            //출력에 맞게 Data를 가공한다.
            if (layOCS1003_PRINT.RowCount > 0)
            {
                this.dw_order_list.Reset();
                ApplyMutilanguage();
                dw_order_list.FillData(layOCS1003_PRINT.LayoutTable);
                this.dw_order_list.Refresh();
            }
        }

        private int InsertPrintRow(int patInfo, bool allPrint)
        {
            int currentRowIndex = layOCS1003_PRINT.InsertRow(-1);

            if(allPrint)
                layOCS1003_PRINT.SetItemValue(currentRowIndex, "print_gubun", Resources.TEXT001);

            if(mInput_gubun.Substring(0, 1) == "D")
                layOCS1003_PRINT.SetItemValue(currentRowIndex, "title_gubun", Resources.TEXT002);
            else if(mInput_gubun == "NR")
            {
                layOCS1003_PRINT.SetItemValue(currentRowIndex, "title_gubun", Resources.TEXT003);
            }
            else if(mInput_gubun == "XX")
            {
                layOCS1003_PRINT.SetItemValue(currentRowIndex, "title_gubun", Resources.TEXT004);
            }
            else
                layOCS1003_PRINT.SetItemValue(currentRowIndex, "title_gubun", Resources.TEXT005);
                                
                
            foreach(MultiLayoutItem item in layOUT1001.LayoutItems)
            {
                if(layOCS1003_PRINT.LayoutItems.Contains(item.DataName))
                    layOCS1003_PRINT.SetItemValue(currentRowIndex, item.DataName, layOUT1001.GetItemString(patInfo, item.DataName));
            }

            //string comment = "";

            //if( layOUT1001.GetItemString(patInfo, "atc_yn") == "Y" )
            //    comment = "一包化";
            //else if( layOUT1001.GetItemString(patInfo, "atc_yn") == "P" )
            //    comment = "粉砕する";
            //else if( layOUT1001.GetItemString(patInfo, "atc_yn") == "C" )
            //    comment = "錠剤　ｶﾌﾟｾﾙ一包化";

            //if( layOUT1001.GetItemString(patInfo, "hubal_change_yn") == "Y" )
            //    comment = comment.Length > 0 ? comment + ",後発医薬品への変更可" : "後発医薬品への変更可";

            //layOCS1003_PRINT.SetItemValue(currentRowIndex, "comment", comment);

            //page가 넘어갈 때 dataWindow group header line을 감안해서 2로 가져간다.
            if(layOCS1001.RowCount > 0) mPrintLine = mPrintLine == MAXLINE ? 2 : mPrintLine + 1;

            return currentRowIndex;
        }

        private void SetDisplayOrderData()
        {
            string MIX_START = "┏";
            string MIX_MID   = "┃";
            string MIX_END   = "┗";

            int    ORD_INFO_LENGTH = 60;

            if(layOCS1003.RowCount == 0) 
            {
                panOrderInfo.Controls.Clear();
                return;
            }
            
            // group_ser, mix, 복용법, 일수, 희망일자 등등 출력관련
            string pre_group_ser    = "";
            string pre_order_gubun  = "";
            string pre_bogyong_code = "";
            string pre_hope_date    = "";
            string pre_nalsu        = "";
            string pre_mix_group    = "";
            
            // 처방단위, DV, 일수는 출력에 맞게 수정한다.
            string group_ser, order_gubun, order_mark, order_info, order_detail, nalsu;
                
            int currentRowIndex = 0 ;
            string tempValue    = "";
            string[] tempArray ;

            layDisplayOrderInfo.Reset();

            for(int ocs1003Index = 0; ocs1003Index < layOCS1003.RowCount; ocs1003Index++)
            {                    
                if(ocs1003Index != 0)
                {
                    //내복약처리
                    if( layOCS1003.GetItemString(ocs1003Index -1, "order_gubun_bas" ).Trim() == "C" )
                    {
                        if( pre_group_ser    != layOCS1003.GetItemString(ocs1003Index, "group_ser"   ) ||
                            pre_bogyong_code != layOCS1003.GetItemString(ocs1003Index, "bogyong_code") ||
                            pre_hope_date    != layOCS1003.GetItemString(ocs1003Index, "hope_date"   ) ||
                            pre_nalsu        != layOCS1003.GetItemString(ocs1003Index, "nalsu"       ) )
                        {     
                            //복용법
                            currentRowIndex = this.layDisplayOrderInfo.InsertRow(-1);
                            //order_mark
                            if( !TypeCheck.IsNull(layOCS1003.GetItemString(ocs1003Index -1, "mix_group" ).Trim()) )
                                layDisplayOrderInfo.SetItemValue(currentRowIndex, "order_mark"  , MIX_MID  );
                            
                            tempValue       = layOCS1003.GetItemString(ocs1003Index  -1, "bogyong_name");
                            layDisplayOrderInfo.SetItemValue(currentRowIndex, "order_info", tempValue);
                                
                            //투약시작일
                            if(!TypeCheck.IsNull(layOCS1003.GetItemString(ocs1003Index  -1, "hope_date" ).Trim()))
                            {
                                currentRowIndex = this.layDisplayOrderInfo.InsertRow(-1);
                                if( !TypeCheck.IsNull(layOCS1003.GetItemString(ocs1003Index -1, "mix_group" ).Trim()) )
                                    layDisplayOrderInfo.SetItemValue(currentRowIndex, "order_mark"  , MIX_MID  );

                                tempValue = " ◈ 投薬スタート日 : " + layOCS1003.GetItemString(ocs1003Index  -1, "hope_date" );
                                layDisplayOrderInfo.SetItemValue(currentRowIndex, "order_info", tempValue);
                            }
   
                            //날수
                            nalsu = layOCS1003.GetItemString(ocs1003Index  -1, "nalsu").Trim().Replace("D", "") + "日";
                            layDisplayOrderInfo.SetItemValue(currentRowIndex, "nalsu", nalsu);                            
                        }
                    }

                    // Mix표시
                    // 전 Mix 마크처리
                    if( (!TypeCheck.IsNull(layOCS1003.GetItemString(ocs1003Index - 1, "mix_group"))) &&
                        (pre_order_gubun != layOCS1003.GetItemString(ocs1003Index, "order_gubun") ||
                        pre_group_ser   != layOCS1003.GetItemString(ocs1003Index, "group_ser"  ) ||
                        pre_mix_group   != layOCS1003.GetItemString(ocs1003Index, "mix_group"  )) )
                    {
                        layDisplayOrderInfo.SetItemValue(currentRowIndex, "order_mark", MIX_END);    
                    }
                }

                group_ser = ""; order_gubun = ""; order_mark = "";
                
                //그룹 title
                if( pre_group_ser != layOCS1003.GetItemString(ocs1003Index, "group_ser") )
                    group_ser   = "GR " + layOCS1003.GetItemString(ocs1003Index, "group_ser");
                
                //오더구분
                if( pre_order_gubun != layOCS1003.GetItemString(ocs1003Index, "order_gubun") )
                    order_gubun = layOCS1003.GetItemString(ocs1003Index, "order_gubun_name");


                if( !TypeCheck.IsNull(layOCS1003.GetItemString(ocs1003Index, "mix_group")) )
                {
                    if( pre_order_gubun != layOCS1003.GetItemString(ocs1003Index, "order_gubun") ||
                        pre_group_ser   != layOCS1003.GetItemString(ocs1003Index, "group_ser"  ) || 
                        pre_mix_group   != layOCS1003.GetItemString(ocs1003Index, "mix_group"  ) )
                        order_mark = MIX_START;
                    else
                        order_mark = MIX_MID;
                }

                order_info = "";

                //예약
                if(layOCS1003.GetItemString(ocs1003Index, "reser_yn") == "Y")
                    order_info = order_info + "[予]" ;
                    
                //응급
                if(layOCS1003.GetItemString(ocs1003Index, "emergency") == "Y")
                    order_info = order_info + "[緊急]";
                
                //원외여부                
                if(layOCS1003.GetItemString(ocs1003Index, "wonyoi_order_yn") == "Y")
                    order_info = order_info + "[院外]";

                order_info = order_info + layOCS1003.GetItemString(ocs1003Index, "hangmog_name");
                
                      
                //Order 상세[수량 + 단위 + DV Time + DV]
                order_detail = layOCS1003.GetItemString(ocs1003Index, "suryang");
                
                if( layOCS1003.GetItemString(ocs1003Index, "ord_danui_name") == "H" )
                    order_detail = order_detail + "時間";
                else if( layOCS1003.GetItemString(ocs1003Index, "ord_danui_name") == "L" )
                    order_detail = order_detail + "ℓ/分";                
                else
                    order_detail = order_detail + layOCS1003.GetItemString(ocs1003Index, "ord_danui_name");
                
                order_detail = order_detail + layOCS1003.GetItemString(ocs1003Index, "dv_time").Trim() + " " + layOCS1003.GetItemString(ocs1003Index, "dv").Trim();

                
                                    
                //날수
                nalsu = "";
                if( layOCS1003.GetItemString(ocs1003Index, "order_gubun_bas" ).Trim() != "C" &&  
                    layOCS1003.GetItemString(ocs1003Index, "order_gubun_bas" ).Trim() != "D"  )
                {    
                    if( layOCS1003.GetItemString(ocs1003Index, "nalsu").IndexOf("D") >= 0 )
                        nalsu = layOCS1003.GetItemString(ocs1003Index, "nalsu").Trim().Replace("D", "") + "日";
                    else if( layOCS1003.GetItemString(ocs1003Index, "nalsu").IndexOf("M") >= 0 )
                        nalsu = layOCS1003.GetItemString(ocs1003Index, "nalsu").Trim().Replace("M", "") + "分";
                }
                    
                //검체명
                if(layOCS1003.GetItemString(ocs1003Index, "specimen_name" ).Trim() != "" && layOCS1003.GetItemString(ocs1003Index, "specimen_name" ).Trim() != "*")
                {
                    if(!TypeCheck.IsNull(layOCS1003.GetItemString(ocs1003Index, "suryang")) && layOCS1003.GetItemString(ocs1003Index, "suryang") != "1")
                        order_detail = layOCS1003.GetItemString(ocs1003Index, "specimen_name") + "     " + order_detail + "回";
                    else
                        order_detail = layOCS1003.GetItemString(ocs1003Index, "specimen_name");
                }
                else
                {
                    if(TypeCheck.IsNull(layOCS1003.GetItemString(ocs1003Index, "ord_danui_name").Trim())) //검사
                        order_detail = "";
                }

                currentRowIndex = this.layDisplayOrderInfo.InsertRow(-1);
                layDisplayOrderInfo.SetItemValue(currentRowIndex, "group_ser"   , group_ser   );
                layDisplayOrderInfo.SetItemValue(currentRowIndex, "order_gubun" , order_gubun );
                layDisplayOrderInfo.SetItemValue(currentRowIndex, "order_mark"  , order_mark  );                
                layDisplayOrderInfo.SetItemValue(currentRowIndex, "order_detail", order_detail);
                layDisplayOrderInfo.SetItemValue(currentRowIndex, "nalsu"       , nalsu       );

                //오더명은 diplay길이로 잘라서 처리
                tempArray = this.GetArraySubstrByte(order_info, ORD_INFO_LENGTH);
                for(int i = 0; i < tempArray.Length; i++)
                {                        
                    if( i != 0 ) currentRowIndex = this.layDisplayOrderInfo.InsertRow(-1);
                    layDisplayOrderInfo.SetItemValue(currentRowIndex, "order_info"  , order_info);
                }                

                //주사
                if(( layOCS1003.GetItemString(ocs1003Index, "order_gubun_bas" ).Trim() == "A"  ||  
                    layOCS1003.GetItemString(ocs1003Index, "order_gubun_bas" ).Trim() == "B"  ) && 
                    layOCS1003.GetItemString(ocs1003Index, "jusa" ).Trim() != "0" && layOCS1003.GetItemString(ocs1003Index, "jusa_name" ).Trim() != "")
                {
                    
                    currentRowIndex = this.layDisplayOrderInfo.InsertRow(-1);
                    //order_mark
                    if( !TypeCheck.IsNull(layOCS1003.GetItemString(ocs1003Index, "mix_group" ).Trim()) )
                        layDisplayOrderInfo.SetItemValue(currentRowIndex, "order_mark"  , MIX_MID  );

                    order_info = " 注射 : " + layOCS1003.GetItemString(ocs1003Index, "jusa_name" );
                    
                    if( !TypeCheck.IsNull(layOCS1003.GetItemString(ocs1003Index, "bogyong_code" ).Trim()) )
                        order_info = order_info + " [速度 : " + layOCS1003.GetItemString(ocs1003Index, "bogyong_code" ).Trim() + " ㎖/hr]";

                    layDisplayOrderInfo.SetItemValue(currentRowIndex, "order_info"  , order_info  );
                }

                //희망일자
                if(!TypeCheck.IsNull(layOCS1003.GetItemString(ocs1003Index, "hope_date" ).Trim())) 
                {   
                    if( layOCS1003.GetItemString(ocs1003Index, "order_gubun_bas" ).Trim() != "C" &&  
                        layOCS1003.GetItemString(ocs1003Index, "order_gubun_bas" ).Trim() != "D"  )
                    {
                        currentRowIndex = this.layDisplayOrderInfo.InsertRow(-1);
                        //order_mark
                        if( !TypeCheck.IsNull(layOCS1003.GetItemString(ocs1003Index, "mix_group" ).Trim()) )
                            layDisplayOrderInfo.SetItemValue(currentRowIndex, "order_mark"  , MIX_MID  );

                        //order_info = " 希望日 : " + layOCS1003.GetItemString(ocs1003Index, "hope_date" );
                        layDisplayOrderInfo.SetItemValue(currentRowIndex, "order_info"  , order_info  );
                    }
                        
                }

                //처치 부위
                if( layOCS1003.GetItemString(ocs1003Index, "order_gubun_bas" ).Trim() == "H" &&
                    layOCS1003.GetItemString(ocs1003Index, "bogyong_name" ).Trim() != "")
                {
                    currentRowIndex = this.layDisplayOrderInfo.InsertRow(-1);
                    //order_mark
                    if( !TypeCheck.IsNull(layOCS1003.GetItemString(ocs1003Index, "mix_group" ).Trim()) )
                        layDisplayOrderInfo.SetItemValue(currentRowIndex, "order_mark"  , MIX_MID  );

                    order_info = " " + layOCS1003.GetItemString(ocs1003Index, "bogyong_name" );                    
                    layDisplayOrderInfo.SetItemValue(currentRowIndex, "order_info"  , order_info  );
                }

                //외용약
                if( layOCS1003.GetItemString(ocs1003Index, "order_gubun_bas" ).Trim() == "D" )
                {
                    currentRowIndex = this.layDisplayOrderInfo.InsertRow(-1);
                    //order_mark
                    if( !TypeCheck.IsNull(layOCS1003.GetItemString(ocs1003Index, "mix_group" ).Trim()) )
                        layDisplayOrderInfo.SetItemValue(currentRowIndex, "order_mark"  , MIX_MID  );

                    // 복용법
                    order_info = " " + layOCS1003.GetItemString(ocs1003Index, "bogyong_name" );                    
                    layDisplayOrderInfo.SetItemValue(currentRowIndex, "order_info"  , order_info  );                                
                              
                    //투약시작일
                    if(!TypeCheck.IsNull(layOCS1003.GetItemString(ocs1003Index, "hope_date" ).Trim()))
                    {
                        currentRowIndex = this.layDisplayOrderInfo.InsertRow(-1);
                        //order_mark
                        if( !TypeCheck.IsNull(layOCS1003.GetItemString(ocs1003Index, "mix_group" ).Trim()) )
                            layDisplayOrderInfo.SetItemValue(currentRowIndex, "order_mark"  , MIX_MID  );

                        // 복용법
                        order_info = " " + " 投薬スタート日 : " + layOCS1003.GetItemString(ocs1003Index, "hope_date" );                    
                        layDisplayOrderInfo.SetItemValue(currentRowIndex, "order_info"  , order_info  );
                    }
                }

                //처방 Remark
                if(layOCS1003.GetItemString(ocs1003Index, "order_remark" ).Trim() != "")
                {
                    order_info = " " + layOCS1003.GetItemString(ocs1003Index, "order_remark" );    
                    tempArray = this.GetArraySubstrByte(order_info, ORD_INFO_LENGTH);
                    
                    foreach( string s in tempArray )
                    {    
                        currentRowIndex = this.layDisplayOrderInfo.InsertRow(-1);
                        //order_mark
                        if( !TypeCheck.IsNull(layOCS1003.GetItemString(ocs1003Index, "mix_group" ).Trim()) )
                            layDisplayOrderInfo.SetItemValue(currentRowIndex, "order_mark"  , MIX_MID  );
                        
                        layDisplayOrderInfo.SetItemValue(currentRowIndex, "order_info"  , s);
                    }
                }

                pre_group_ser    = layOCS1003.GetItemString(ocs1003Index, "group_ser"   );
                pre_order_gubun  = layOCS1003.GetItemString(ocs1003Index, "order_gubun" );
                pre_bogyong_code = layOCS1003.GetItemString(ocs1003Index, "bogyong_code");
                pre_hope_date    = layOCS1003.GetItemString(ocs1003Index, "hope_date"   ); 
                pre_nalsu        = layOCS1003.GetItemString(ocs1003Index, "nalsu"       );
                pre_mix_group    = layOCS1003.GetItemString(ocs1003Index, "mix_group"   );
            }

            if(layOCS1003.RowCount > 0)
            {
                //내복약처리
                if( layOCS1003.GetItemString(layOCS1003.RowCount -1, "order_gubun_bas" ).Trim() == "C" )
                {
                    //복용법
                    currentRowIndex = this.layDisplayOrderInfo.InsertRow(-1);
                    //order_mark
                    if( !TypeCheck.IsNull(layOCS1003.GetItemString(layOCS1003.RowCount, "mix_group" ).Trim()) )
                        layDisplayOrderInfo.SetItemValue(currentRowIndex, "order_mark"  , MIX_MID  );

                    tempValue       = layOCS1003.GetItemString(layOCS1003.RowCount  -1, "bogyong_name");
                    layDisplayOrderInfo.SetItemValue(currentRowIndex, "order_info", tempValue);
                                
                    //투약시작일
                    if(!TypeCheck.IsNull(layOCS1003.GetItemString(layOCS1003.RowCount  -1, "hope_date" ).Trim()))
                    {
                        currentRowIndex = this.layDisplayOrderInfo.InsertRow(-1);
                        //order_mark
                        if( !TypeCheck.IsNull(layOCS1003.GetItemString(layOCS1003.RowCount, "mix_group" ).Trim()) )
                            layDisplayOrderInfo.SetItemValue(currentRowIndex, "order_mark"  , MIX_MID  );

                        tempValue = " ◈ 投薬スタート日 : " + layOCS1003.GetItemString(layOCS1003.RowCount  -1, "hope_date" );
                        layDisplayOrderInfo.SetItemValue(currentRowIndex, "order_info", tempValue);
                    }
   
                    //날수
                    nalsu = layOCS1003.GetItemString(layOCS1003.RowCount  -1, "nalsu").Trim().Replace("D", "") + "日";
                    layDisplayOrderInfo.SetItemValue(currentRowIndex, "nalsu", nalsu);                                                
                }    

                // Mix 마크처리
                if( !TypeCheck.IsNull(layOCS1003.GetItemString(layOCS1003.RowCount - 1, "mix_group")) )
                    layDisplayOrderInfo.SetItemValue(currentRowIndex, "order_mark", MIX_END);
            }

            //display 처리
            displayLabelData();
//            for( int i = 0; i < layDisplayOrderInfo.RowCount; i++ )
//            {
//                this.lblGroup.Text        = lblGroup.Text        + "\n"+ layDisplayOrderInfo.GetItemString(i, "group_ser"   ) ;
//                this.lblOrder_gubun.Text  = lblOrder_gubun.Text  + "\n"+ layDisplayOrderInfo.GetItemString(i, "order_gubun" ) ;
//                this.lblOrder_mark.Text   = lblOrder_mark.Text   + "\n"+ layDisplayOrderInfo.GetItemString(i, "order_mark"  ) ;
//                this.lblOrderInfo.Text    = lblOrderInfo.Text    + "\n"+ layDisplayOrderInfo.GetItemString(i, "order_info"  ) ;
//                this.lblOrder_detail.Text = lblOrder_detail.Text + "\n"+ layDisplayOrderInfo.GetItemString(i, "order_detail") ;
//                this.lblNalsu.Text        = lblNalsu.Text        + "\n"+ layDisplayOrderInfo.GetItemString(i, "nalsu"       ) ;
//            }
        }
        
        private void displayLabelData()
        {
            //컬럼 너비
            int GROUP_WIDTH        = 36;
            int ORDER_GUBUN_WIDTH  = 84;
            int ORDER_MARK_WIDTH   = 20;
            int ORDER_INFO_WIDTH   = 400;
            int ORDER_DETAIL_WIDTH = 90;    
            int NALSU_WIDTH        = 60;

            int LABEL_HEIGHT       = 20;

            
            panOrderInfo.Controls.Clear();

            //display 처리
            int startX = 0, startY = 0;
            for( int i = 0; i < layDisplayOrderInfo.RowCount; i++ )
            {
                startX = 0;

                //order_group
                addDisplayLabel(startX, startY, GROUP_WIDTH, LABEL_HEIGHT, ContentAlignment.MiddleLeft, layDisplayOrderInfo.GetItemString(i, "group_ser"   ));
                startX = startX + GROUP_WIDTH;
                //order_gubun
                addDisplayLabel(startX, startY, ORDER_GUBUN_WIDTH, LABEL_HEIGHT, ContentAlignment.MiddleLeft, layDisplayOrderInfo.GetItemString(i, "order_gubun"   ));
                startX = startX + ORDER_GUBUN_WIDTH;
                //order_mark
                addDisplayLabel(startX, startY, ORDER_MARK_WIDTH, LABEL_HEIGHT, ContentAlignment.MiddleRight, layDisplayOrderInfo.GetItemString(i, "order_mark"   ));
                startX = startX + ORDER_MARK_WIDTH;
                //order_info
                addDisplayLabel(startX, startY, ORDER_INFO_WIDTH, LABEL_HEIGHT, ContentAlignment.MiddleLeft, layDisplayOrderInfo.GetItemString(i, "order_info"   ));
                startX = startX + ORDER_INFO_WIDTH;
                //order_detail
                addDisplayLabel(startX, startY, ORDER_DETAIL_WIDTH, LABEL_HEIGHT, ContentAlignment.MiddleRight, layDisplayOrderInfo.GetItemString(i, "order_detail"   ));
                startX = startX + ORDER_DETAIL_WIDTH;
                //order_detail
                addDisplayLabel(startX, startY, NALSU_WIDTH, LABEL_HEIGHT, ContentAlignment.MiddleRight, layDisplayOrderInfo.GetItemString(i, "nalsu"   ));
                startY = startY + LABEL_HEIGHT;
            }

            
        }

        private void addDisplayLabel(int X, int Y, int width, int height, ContentAlignment lta, string displayData)
        {
            System.Windows.Forms.Label lblDisplay;
            lblDisplay = new System.Windows.Forms.Label();            
            lblDisplay.BackColor = System.Drawing.Color.White;
            lblDisplay.Location = new System.Drawing.Point(X, Y);
            lblDisplay.Name = "lbl" + X.ToString() + "_" + Y.ToString();
            lblDisplay.Size = new System.Drawing.Size(width, height);
            lblDisplay.TextAlign = lta;
            lblDisplay.Text = displayData;

            this.panOrderInfo.Controls.Add(lblDisplay);
        }

        #endregion

        #region [Zoom 처리]
        private void btnZoomIn_Click(object sender, System.EventArgs e)
        {            
            int zoom = int.Parse(dbxZoom.GetDataValue());
            if (zoom < 200 ) zoom = zoom + 10;
            
            dw_order_list.Modify("DataWindow.Print.Preview.Zoom= " + zoom.ToString());

            dbxZoom.SetDataValue(zoom);            
        }

        private void btnZoomOut_Click(object sender, System.EventArgs e)
        {
            int zoom = int.Parse(dbxZoom.GetDataValue());
            if (zoom > 0) zoom = zoom -10;

            dw_order_list.Modify("DataWindow.Print.Preview.Zoom= " + zoom.ToString());            
            
            dbxZoom.SetDataValue(zoom);
        }

        #endregion

        #region [출력]
        private void Print()
        {
            try
            {    
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                SetMsg("");

                if(dw_order_list.RowCount > 0)
                {
                    try
                    {
                        dw_order_list.Print(true);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                else
                {
                    mbxMsg = NetInfo.Language == LangMode.Jr ? "出力するデータが存在しません。 確認してください。" : "출력할 데이터가 존재하지 않습니다. 확인바랍니다.";
                    mbxCap = NetInfo.Language == LangMode.Jr ? "出力" : "출력";
                    XMessageBox.Show(mbxMsg, mbxCap);
                }
                
            }
            finally
            {
                SetMsg(" ");
                Cursor.Current = System.Windows.Forms.Cursors.Default;
            }
        }

        #endregion

        #region [ButtonList Event]
        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:

                    e.IsBaseCall = false;
                    
                    LoadData();

                    break;

                case FunctionType.Print:

                    e.IsBaseCall = false;                    
                    
                    if(mPrintGubun == 0)
                    {
                        //OCS
                        this.Print();
                        //의사회계
                        SetOrderData(true);
                        this.Print();
                    }
                    else if(mPrintGubun == 1)
                    {
                        //OCS
                        this.Print();
                    }
                    else
                    {
                        //의사회계
                        SetOrderData(true);
                        this.Print();                        
                    }

                    SetOrderData(false);

                    break;
            }
        }

        private void btnExcel_Click(object sender, System.EventArgs e)
        {
            if(this.dw_order_list.RowCount == 0) return;

            string fileName;            

            SaveFileDialog saveFileDialogExcel = new SaveFileDialog();       
            saveFileDialogExcel.Filter = "excel files (*.xls)|*.xls";
            saveFileDialogExcel.FilterIndex = 1;
            saveFileDialogExcel.RestoreDirectory = true ;
            saveFileDialogExcel.OverwritePrompt  = false ;

            if(saveFileDialogExcel.ShowDialog() == DialogResult.OK)
            {   
                fileName = saveFileDialogExcel.FileName;                
            }
            else
            {
                return;
            }
            
            dw_order_list.SaveAsFormattedText(fileName,"\t","","\r\n", true, Sybase.DataWindow.FileSaveAsEncoding.Ansi);    
        }
        #endregion

        #region [Control]

        private void rbtPrint_Click(object sender, System.EventArgs e)
        {
            if(rbtALL.Checked)
            {
                rbtALL.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);                
                rbtALL.Font = new Font(rbtALL.Font.FontFamily, rbtALL.Font.Size, FontStyle.Bold);
                rbtALL.ImageIndex = 1;

                rbtOCS.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                rbtOCS.Font = new Font(rbtOCS.Font.FontFamily, rbtOCS.Font.Size);
                rbtOCS.ImageIndex = 0;
  
                rbtOUT.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                rbtOUT.Font = new Font(rbtOUT.Font.FontFamily, rbtOUT.Font.Size);
                rbtOUT.ImageIndex = 0;

                mPrintGubun = 0;
            }
            else if(rbtOCS.Checked)
            {
                rbtOCS.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);                
                rbtOCS.Font = new Font(rbtOCS.Font.FontFamily, rbtOCS.Font.Size, FontStyle.Bold);
                rbtOCS.ImageIndex = 1;

                rbtALL.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                rbtALL.Font = new Font(rbtALL.Font.FontFamily, rbtALL.Font.Size);
                rbtALL.ImageIndex = 0;
  
                rbtOUT.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                rbtOUT.Font = new Font(rbtOUT.Font.FontFamily, rbtOUT.Font.Size);
                rbtOUT.ImageIndex = 0;

                mPrintGubun = 1;
            
            }    
            else 
            {
                rbtOUT.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);                
                rbtOUT.Font = new Font(rbtOUT.Font.FontFamily, rbtOUT.Font.Size, FontStyle.Bold);
                rbtOUT.ImageIndex = 1;

                rbtALL.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                rbtALL.Font = new Font(rbtALL.Font.FontFamily, rbtALL.Font.Size);
                rbtALL.ImageIndex = 0;
  
                rbtOCS.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                rbtOCS.Font = new Font(rbtOCS.Font.FontFamily, rbtOCS.Font.Size);
                rbtOCS.ImageIndex = 0;            

                mPrintGubun = 2;
            }    
        }

        

        #endregion

        #region [String]
        /// <summary>
        /// string 값의 Byte를 구한다.
        /// </summary>
        public int GetStringByte(string s)
        {   
            int returnByte = 0;

            if(s.Length == 0)
            {
                return returnByte;
            }

            Encoding KscEncoding = Encoding.GetEncoding("ks_c_5601-1987");            
            returnByte = KscEncoding.GetByteCount(s);
            return returnByte;
        }

        /// <summary>
        /// <summary>
        /// string 값을 Byte 단위로 substring 한다.
        /// </summary>
        public string SubstringByte(string s, int startIndex, int length)
        {   
            string returnString = "";
            int    limitLen,  cutLen;
            string padSpace = " ";
            
            if(GetStringByte(s) == 0 || GetStringByte(s) < startIndex || length < 1)
            {
                return returnString;
            }

            limitLen = GetStringByte(s) - startIndex -1;
            
            //제한길이 check
            if (length > limitLen)
            {
                cutLen = limitLen;
            }
            else
            {
                cutLen = length;
            }

            Encoding KscEncoding = Encoding.GetEncoding("ks_c_5601-1987");            
            Byte[] encodingByte = KscEncoding.GetBytes(s);
            
            returnString = KscEncoding.GetString(encodingByte, startIndex,  cutLen);
            encodingByte = KscEncoding.GetBytes(returnString);
            
            //한글이 깨지는 경우(\0) space로 바꿈
            if(encodingByte[encodingByte.Length-1] == 0)
            {
                encodingByte[encodingByte.Length-1] = 32;
                returnString = KscEncoding.GetString(encodingByte, 0,  cutLen);
            }
            
            //해당 길이만큼 RPAD처리
            if(length > cutLen)
            {
                padSpace = padSpace.PadRight(length - cutLen);
                returnString = returnString + padSpace;
            }
            return returnString;
        }    

        public string SubstringByte(string s, int startIndex)
        {   
            string returnString = "";
            int    cutLen;
            
            if(GetStringByte(s) == 0 || GetStringByte(s) < startIndex )
            {
                return returnString;
            }

            cutLen = GetStringByte(s) - startIndex -1;
        
            Encoding KscEncoding = Encoding.GetEncoding("ks_c_5601-1987");            
            Byte[] encodingByte = KscEncoding.GetBytes(s);
            
            returnString = KscEncoding.GetString(encodingByte, startIndex,  cutLen);
            
            return returnString;
        }    
                
        /// <summary>
        /// string 값을 Byte 단위로 substring하여 배열로 반환한다.
        /// substring할 문자길이는 2Byte를 넘어야 한다.
        /// new line(\n) 또는 사용자 ENTER(\r\n)가 포함된 경우 다음 배열로
        /// 값을 처리한다.
        /// </summary>
        public string[] GetArraySubstrByte(string s, int lengthInt)
        {   
            string[] returnString;
                        
            if(s.Length == 0 || lengthInt < 2)
            {   
                returnString    = new string[1];
                returnString[0] = "";
                return returnString;
            }

            //사용자 ENTER 값은 "\r\n"은 "\n"으로 처리
            s = s.Replace("\r\n", "\n");

            Encoding KscEncoding = Encoding.GetEncoding("ks_c_5601-1987");
            string convertStr  = "";
            string tempString  = "";
            int    tempByte    = 0 ;
            int    totalByte   = 0 ;
            int    limitLength = s.Length;        
            
            for ( int i = 0; i < limitLength; i++)
            {   
                tempString = s.Substring(i, 1);                
                tempByte   = KscEncoding.GetByteCount(tempString);
                totalByte  = totalByte + tempByte;                
                if ( totalByte <= lengthInt )
                {   
                    convertStr = convertStr + tempString;    
                    if (tempString == "\n")
                    {    
                        totalByte  = 0;
                    }                    
                }
                else
                {  
                    if (tempString == "\n")
                    {    
                        convertStr = convertStr + tempString;
                        totalByte  = 0;    
                    }
                    else
                    {
                        convertStr = convertStr + "\n" + tempString;    
                        totalByte  = tempByte;    
                    }                
                }
            }

            returnString = convertStr.Split('\n');

            return returnString;
        }
        
        /// <summary>
        /// string 값을 Byte 단위로 substring한 후 RPad한다.
        /// </summary>
        public string SubstrByteRPad(string s, int startIndex, int length)
        {   
            string returnString = "";
            int    limitLen,  cutLen;
            string padSpace = " ";
            
            if(GetStringByte(s) == 0 || GetStringByte(s) < startIndex || length < 1)
            {
                return returnString;
            }

            limitLen = GetStringByte(s) - startIndex -1;
            
            //제한길이 check
            if (length > limitLen)
            {
                cutLen = limitLen;
            }
            else
            {
                cutLen = length;
            }

            Encoding KscEncoding = Encoding.GetEncoding("ks_c_5601-1987");            
            Byte[] encodingByte = KscEncoding.GetBytes(s);
            
            returnString = KscEncoding.GetString(encodingByte, startIndex,  cutLen);
            encodingByte = KscEncoding.GetBytes(returnString);
            
            //한글이 깨지는 경우(\0) space로 바꿈
            if(encodingByte[encodingByte.Length-1] == 0)
            {
                encodingByte[encodingByte.Length-1] = 32;
                returnString = KscEncoding.GetString(encodingByte, 0,  cutLen);
            }
            
            //해당 길이만큼 RPAD처리
            if(length > cutLen)
            {
                padSpace = padSpace.PadRight(length - cutLen);
                returnString = returnString + padSpace;
            }
            return returnString;
        }
        
        /// <summary>
        /// string 값을 Byte 단위로 substring 한 후 LPad한다.
        /// </summary>
        public string SubstrByteLPad(string s, int startIndex, int length)
        {   
            string returnString = "";
            int    limitLen,  cutLen;
            string padSpace = " ";
            
            if(GetStringByte(s) == 0 || GetStringByte(s) < startIndex || length < 1)
            {
                return returnString;
            }

            limitLen = GetStringByte(s) - startIndex -1;
            
            //제한길이 check
            if (length > limitLen)
            {
                cutLen = limitLen;
            }
            else
            {
                cutLen = length;
            }

            Encoding KscEncoding = Encoding.GetEncoding("ks_c_5601-1987");            
            Byte[] encodingByte = KscEncoding.GetBytes(s);
            
            returnString = KscEncoding.GetString(encodingByte, startIndex,  cutLen);
            encodingByte = KscEncoding.GetBytes(returnString);
            
            //한글이 깨지는 경우(\0) space로 바꿈
            if(encodingByte[encodingByte.Length-1] == 0)
            {
                encodingByte[encodingByte.Length-1] = 32;
                returnString = KscEncoding.GetString(encodingByte, 0,  cutLen);
            }
            
            //해당 길이만큼 RPAD처리
            if(length > cutLen)
            {
                padSpace = padSpace.PadRight(length - cutLen);
                returnString = padSpace + returnString;
            }
            return returnString;
        }
        #endregion
        
        #region [EMR 내보내기- virtual Driver]
        private void btnEMRPrint_Click(object sender, System.EventArgs e)
        {
            //if(!checkExistEMR() || layOUT1001.RowCount == 0 ) return;
            ////virtual Printer 유효여부
            //bool installFlag = false;
            //foreach( string s in System.Drawing.Printing.PrinterSettings.InstalledPrinters )
            //{
            //    MessageBox.Show(s);
            //    if( s == "BonaWriter" )
            //    {
            //        installFlag = true;
            //        //ini 파일 생성
            //        makeEMRVirtualINIFile();
            //        //virtual drive print
            //        dw_order_list.PrintProperties.PrinterName = "BonaWriter";
            //        dw_order_list.Print();
            //        break;
            //    }
            //}
            
            ////virtual Driver가 설치되지 않은 경우
            //if(!installFlag)
            //{
            //}    

            EMRCALLHelper.PrintToEmr(this.Name, this.dw_order_list, "O", this.mBunho, this.mNaewon_date, this.mJubsuKey);
        
        }

        private bool makeEMRVirtualINIFile()
        {   
            bool sucessMake = false;

            if(!checkExistEMR()) return sucessMake;

            try
            {
                sucessMake = true;

                string fileName = @"C:\ICM\EMR.ini";
                // 파일이 존재하면 삭제처리한다.
                if (File.Exists(fileName)) 
                {
                    File.Delete(fileName);
                }

                xPaInfoBox1.SetPatientID(mBunho);

                using (StreamWriter sw = File.CreateText(fileName)) 
                {
                    sw.WriteLine("[PATIENT]");
                    sw.WriteLine("PATIENTNAME = '" + layOUT1001.GetItemString(0, "suname") + "'");
                    sw.WriteLine("PATIENTRRN = '" + this.mNaewon_date + "'");
                    sw.WriteLine("PATIENTINDATE = '" + xPaInfoBox1.Birth + "'");
                    sw.WriteLine("PATIENTORDER = '" + EnvironInfo.GetSysDate().ToString("yyyy/MM/dd") + "'");
                    sw.WriteLine("");
                    sw.WriteLine("[USERINFO]");
                    sw.WriteLine("USERNO = '" + UserInfo.UserID + "'");
                    sw.WriteLine("USERNAME = '" + UserInfo.UserName + "'");
                    sw.WriteLine("");
                    sw.WriteLine("[SHEETID]");
                    sw.WriteLine("SHEETID = '" + "0000000006" + "'");                    
                }
            }
            catch( Exception ex )
            {
                sucessMake = false;
                mbxMsg = ex.Message;
                mbxCap = "EMR FILE ERROR";
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(mbxMsg, mbxCap,MessageBoxIcon.Error);
            }
        

            return sucessMake;

        }

        private bool checkExistEMR()
        {
            return Directory.Exists(@"C:\ICM\ezEMR");
        }

        #endregion

        private string GetMMDD(string aYYYYMMDD)
        {
            if (aYYYYMMDD != "")
            {
                return aYYYYMMDD.Substring(5, 2) + "/" + aYYYYMMDD.Substring(8, 2) ;
            }

            return "";
        }

        #region Cloud updated code

        #region GetLayOCS1001
        /// <summary>
        /// GetLayOCS1001
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayOCS1001(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            if (null != _grdData.Ocs1001Item)
            {
                _grdData.Ocs1001Item.ForEach(delegate(OCS1003R00LayOCS1001Info item)
                {
                    lObj.Add(new object[]
                    {
                        item.JuSangYn,
                        item.SangCode,
                        item.Ser,
                        item.DisSangName,
                        item.SangStartDate,
                        item.SangEndDate,
                        item.SangEndSayu,
                        item.SangName,
                        item.PreModifierName,
                        item.PostModifierName,
                        item.EndYn,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetLayOCS1003
        /// <summary>
        /// GetLayOCS1003
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayOCS1003(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            if (null != _grdData.Ocs1003Item)
            {
                _grdData.Ocs1003Item.ForEach(delegate(OCS1003R00LayOCS1003Info item)
                {
                    lObj.Add(new object[]
                    {
                        item.InputGubun,
                        item.InputGubunName,
                        item.GroupSer,
                        item.MixGroup,
                        item.OrderGubun,
                        item.OrderGubunName,
                        item.OrderGubunBas,
                        item.HangmogCode,
                        item.HangmogName,
                        item.SgCode,
                        item.SgName,
                        item.Suryang,
                        item.OrdDanui,
                        item.OrdDanuiName,
                        item.DvTime,
                        item.Dv,
                        item.Nalsu,
                        item.WonyoiOrderYn,
                        item.SpecimenCode,
                        item.SpecimenName,
                        item.Jusa,
                        item.JusaName,
                        item.BogyongCode,
                        item.BogyongName,
                        item.HopeDate,
                        item.OrderRemark,
                        item.DangilGumsaOrderYn,
                        item.DangilGumsaResultYn,
                        item.Emergency,
                        item.ReserYn,
                        item.Seq,
                        item.ReserDate,
                        item.ActingDate,
                        item.OrderByKey,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetLayOUT1001
        /// <summary>
        /// GetLayOUT1001
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayOUT1001(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            if (null != _grdData.Out1001Item)
            {
                _grdData.Out1001Item.ForEach(delegate(OCS1003R00LayOUT1001Info item)
                {
                    lObj.Add(new object[]
                    {
                        item.ReserYn,
                        item.Bunho,
                        item.Suname,
                        item.Suname2,
                        item.Birth,
                        item.SexAge,
                        item.Doctor,
                        item.DoctorName,
                        item.Gwa,
                        item.GwaName,
                        item.Chojae,
                        item.ChojaeName,
                        item.NaewonDate,
                        item.InputGubun,
                        item.OrderEndYn,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #endregion

        private void ApplyMutilanguage()
        {
            try
            {
                //dw_comment
                dw_order_list.Refresh();
                dw_order_list.Modify(string.Format("t_11.text =  '{0}'", Resources.DW_TXT_1));
                dw_order_list.Modify(string.Format("t_12.text =  '{0}'", Resources.DW_TXT_2));
                dw_order_list.Modify(string.Format("t_13.text =  '{0}'", Resources.DW_TXT_3));
                dw_order_list.Modify(string.Format("t_14.text =  '{0}'", Resources.DW_TXT_4));
                dw_order_list.Modify(string.Format("t_15.text =  '{0}'", Resources.DW_TXT_5));
                dw_order_list.Modify(string.Format("t_16.text =  '{0}'", Resources.DW_TXT_6));
                dw_order_list.Modify(string.Format("t_io_gubun.text =  '{0}'", Resources.DW_TXT_7));
                dw_order_list.Modify(string.Format("t_3.text =  '{0}'", Resources.DW_TXT_8));
                dw_order_list.Modify(string.Format("t_10.text =  '{0}'", Resources.DW_TXT_9));
                dw_order_list.Modify(string.Format("t_2.text =  '{0}'", Resources.DW_TXT_10));
                dw_order_list.Modify(string.Format("t_4.text =  '{0}'", Resources.DW_TXT_11));
                dw_order_list.Modify(string.Format("t_9.text =  '{0}'", Resources.DW_TXT_12));
                dw_order_list.Modify(string.Format("t_17.text =  '{0}'", Resources.DW_TXT_13));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}

