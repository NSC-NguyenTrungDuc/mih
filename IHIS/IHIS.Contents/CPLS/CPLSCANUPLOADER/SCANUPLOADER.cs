#region 사용 NameSpace 지정
using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using System.Threading;


#endregion

namespace IHIS.CPLS
{
    /// <summary>
    /// PFESCAN001에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class SCANUPLOADER : IHIS.Framework.XScreen
    {
        #region openparam values
        private string mBunho = "";
        private string mOrderDate = "";
        private string mSystemID = "";
        private string mJundalPart = "";
        private string mHangmogCode = "";
        #endregion

        //private string TempFileName = @"C:\IHIS\Images\temp_scan_image.jpg";


        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel4;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XButtonList xButtonList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XEditGrid grdDetail;
        private IHIS.Framework.XMstGrid grdMaster;
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
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell16;
        private IHIS.Framework.XDatePicker dtpFrDt;
        private IHIS.Framework.XLabel xLabel7;
        private IHIS.Framework.XDatePicker dtpToDt;
        private IHIS.Framework.XPatientBox paid;
        private IHIS.Framework.XLabel xLabel8;
        private IHIS.Framework.XDictComboBox cboJundal;
        //		private IHIS.Framework.DataServiceSIMO dsvMaster;
        //		private IHIS.Framework.DataServiceSIMO dsvDetail;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        //		private IHIS.Framework.DataServiceMISO dsvSave;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
        private System.Windows.Forms.Label label1;
        private IHIS.Framework.XDictComboBox cboSystem;
        private IHIS.Framework.XLabel xLabel9;
        private System.Windows.Forms.Splitter splitter2;
        private IHIS.Framework.XComboItem xComboItem3;
        private IHIS.Framework.XComboItem xComboItem4;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XEditGridCell xEditGridCell20;
        private IHIS.Framework.XEditGridCell xEditGridCell21;
        private IHIS.Framework.XEditGridCell xEditGridCell23;
        private IHIS.Framework.XEditGridCell xEditGridCell24;
        private IHIS.Framework.XPictureBox pictWiaItem;
        private System.Windows.Forms.Panel previewPanel;
        private IHIS.Framework.XProgressBar progressBar;
        private System.Timers.Timer timer1;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XDisplayBox dbxHangmogName;
        private IHIS.Framework.XFindBox fbxHangmogCode;
        //		private IHIS.Framework.XFindWorker fwkHangmog;
        private IHIS.Framework.FindColumnInfo findColumnInfo11;
        private IHIS.Framework.FindColumnInfo findColumnInfo12;
        private IHIS.Framework.XButton btnImageLoad;
        //		private IHIS.Framework.ValidationServiceDyn vsvHangmog;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XFindWorker fwkHangmog;
        private IHIS.Framework.FindColumnInfo findColumnInfo1;
        private IHIS.Framework.FindColumnInfo findColumnInfo2;
        private IHIS.Framework.SingleLayout layHangmog;
        private IHIS.Framework.SingleLayoutItem singleLayoutItem1;
        private System.Windows.Forms.Timer timer2;
        private XEditGridCell xEditGridCell22;
        private IContainer components;
        private MultiLayout layOrderList;
        private XEditGridCell xEditGridCell25;
        private MultiLayoutItem multiLayoutItem1;

        public SCANUPLOADER()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            this.grdDetail.SavePerformer = new XSavePerformer(this);
            this.SaveLayoutList.Add(this.grdDetail);

        }



        const int STEP = 5;
        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            progressBar.Value += STEP;
            progressBar.Text = progressBar.Value.ToString() + " %";

            if ((pictWiaItem.Image != null) || (progressBar.Value > 100))
            {
                timer1.Stop();
                progressBar.Visible = false;
            }
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
                    ImageHelper.DeletePreImage(EnvironInfo.GetSysDateTime().Date);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCANUPLOADER));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dbxHangmogName = new IHIS.Framework.XDisplayBox();
            this.fbxHangmogCode = new IHIS.Framework.XFindBox();
            this.fwkHangmog = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.cboSystem = new IHIS.Framework.XDictComboBox();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.cboJundal = new IHIS.Framework.XDictComboBox();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.dtpToDt = new IHIS.Framework.XDatePicker();
            this.dtpFrDt = new IHIS.Framework.XDatePicker();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.paid = new IHIS.Framework.XPatientBox();
            this.findColumnInfo11 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo12 = new IHIS.Framework.FindColumnInfo();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.btnImageLoad = new IHIS.Framework.XButton();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.previewPanel = new System.Windows.Forms.Panel();
            this.pictWiaItem = new IHIS.Framework.XPictureBox();
            this.progressBar = new IHIS.Framework.XProgressBar();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdDetail = new IHIS.Framework.XEditGrid();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.grdMaster = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.timer1 = new System.Timers.Timer();
            this.layHangmog = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.layOrderList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paid)).BeginInit();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.previewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictWiaItem)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderList)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.dbxHangmogName);
            this.xPanel1.Controls.Add(this.fbxHangmogCode);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.cboSystem);
            this.xPanel1.Controls.Add(this.xLabel9);
            this.xPanel1.Controls.Add(this.cboJundal);
            this.xPanel1.Controls.Add(this.xLabel8);
            this.xPanel1.Controls.Add(this.dtpToDt);
            this.xPanel1.Controls.Add(this.dtpFrDt);
            this.xPanel1.Controls.Add(this.xLabel7);
            this.xPanel1.Controls.Add(this.label1);
            this.xPanel1.Controls.Add(this.paid);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(5, 5);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(1104, 61);
            this.xPanel1.TabIndex = 0;
            // 
            // xLabel2
            // 
            this.xLabel2.Location = new System.Drawing.Point(2, 32);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(68, 21);
            this.xLabel2.TabIndex = 37;
            this.xLabel2.Text = "患者番号";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxHangmogName
            // 
            this.dbxHangmogName.Location = new System.Drawing.Point(861, 6);
            this.dbxHangmogName.Name = "dbxHangmogName";
            this.dbxHangmogName.Size = new System.Drawing.Size(210, 21);
            this.dbxHangmogName.TabIndex = 36;
            // 
            // fbxHangmogCode
            // 
            this.fbxHangmogCode.AutoTabAtMaxLength = true;
            this.fbxHangmogCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxHangmogCode.FindWorker = this.fwkHangmog;
            this.fbxHangmogCode.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.fbxHangmogCode.Location = new System.Drawing.Point(773, 6);
            this.fbxHangmogCode.MaxLength = 13;
            this.fbxHangmogCode.Name = "fbxHangmogCode";
            this.fbxHangmogCode.Size = new System.Drawing.Size(88, 21);
            this.fbxHangmogCode.TabIndex = 35;
            this.fbxHangmogCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxHangmogCode_DataValidating);
            // 
            // fwkHangmog
            // 
            this.fwkHangmog.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkHangmog.FormText = "検査項目照会";
            this.fwkHangmog.SearchImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.fwkHangmog.ServerFilter = true;
            this.fwkHangmog.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkHangmog_QueryStarting);
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "code";
            this.findColumnInfo1.ColWidth = 122;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo1.HeaderText = "項目コード";
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "name";
            this.findColumnInfo2.ColWidth = 324;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo2.HeaderText = "項目名";
            // 
            // xLabel1
            // 
            this.xLabel1.Location = new System.Drawing.Point(716, 6);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(57, 21);
            this.xLabel1.TabIndex = 31;
            this.xLabel1.Text = "検査名";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboSystem
            // 
            this.cboSystem.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.cboSystem.Location = new System.Drawing.Point(357, 6);
            this.cboSystem.Name = "cboSystem";
            this.cboSystem.Size = new System.Drawing.Size(134, 21);
            this.cboSystem.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboSystem.TabIndex = 30;
            this.cboSystem.UserSQL = resources.GetString("cboSystem.UserSQL");
            this.cboSystem.SelectionChangeCommitted += new System.EventHandler(this.cboSystem_SelectionChangeCommitted);
            this.cboSystem.SelectedIndexChanged += new System.EventHandler(this.cboSystem_SelectedIndexChanged);
            // 
            // xLabel9
            // 
            this.xLabel9.Location = new System.Drawing.Point(297, 6);
            this.xLabel9.Name = "xLabel9";
            this.xLabel9.Size = new System.Drawing.Size(60, 21);
            this.xLabel9.TabIndex = 29;
            this.xLabel9.Text = "検査部署";
            this.xLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboJundal
            // 
            this.cboJundal.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.cboJundal.Location = new System.Drawing.Point(566, 6);
            this.cboJundal.MaxDropDownItems = 15;
            this.cboJundal.Name = "cboJundal";
            this.cboJundal.Size = new System.Drawing.Size(134, 21);
            this.cboJundal.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboJundal.TabIndex = 27;
            this.cboJundal.UserSQL = resources.GetString("cboJundal.UserSQL");
            this.cboJundal.SelectionChangeCommitted += new System.EventHandler(this.cboJundal_SelectionChangeCommitted);
            // 
            // xLabel8
            // 
            this.xLabel8.Location = new System.Drawing.Point(500, 6);
            this.xLabel8.Name = "xLabel8";
            this.xLabel8.Size = new System.Drawing.Size(66, 21);
            this.xLabel8.TabIndex = 26;
            this.xLabel8.Text = "伝達パート";
            this.xLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpToDt
            // 
            this.dtpToDt.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.dtpToDt.Location = new System.Drawing.Point(187, 6);
            this.dtpToDt.Name = "dtpToDt";
            this.dtpToDt.Size = new System.Drawing.Size(100, 21);
            this.dtpToDt.TabIndex = 4;
            this.dtpToDt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpFrDt
            // 
            this.dtpFrDt.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.dtpFrDt.Location = new System.Drawing.Point(70, 6);
            this.dtpFrDt.Name = "dtpFrDt";
            this.dtpFrDt.Size = new System.Drawing.Size(100, 21);
            this.dtpFrDt.TabIndex = 3;
            this.dtpFrDt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xLabel7
            // 
            this.xLabel7.Location = new System.Drawing.Point(3, 6);
            this.xLabel7.Name = "xLabel7";
            this.xLabel7.Size = new System.Drawing.Size(67, 21);
            this.xLabel7.TabIndex = 2;
            this.xLabel7.Text = "検査日";
            this.xLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(173, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 14);
            this.label1.TabIndex = 28;
            this.label1.Text = "~";
            // 
            // paid
            // 
            this.paid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.paid.BoxType = IHIS.Framework.PatientBoxType.NormalDetail;
            this.paid.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paid.Location = new System.Drawing.Point(0, 28);
            this.paid.Name = "paid";
            this.paid.Padding = new System.Windows.Forms.Padding(0, 5, 0, 4);
            this.paid.Size = new System.Drawing.Size(1066, 30);
            this.paid.TabIndex = 0;
            this.paid.Validating += new System.ComponentModel.CancelEventHandler(this.paid_Validating);
            this.paid.PatientSelected += new System.EventHandler(this.paid_PatientSelected);
            // 
            // findColumnInfo11
            // 
            this.findColumnInfo11.ColName = "code";
            this.findColumnInfo11.ColWidth = 113;
            this.findColumnInfo11.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo11.HeaderText = "項目コード";
            // 
            // findColumnInfo12
            // 
            this.findColumnInfo12.ColName = "name";
            this.findColumnInfo12.ColWidth = 281;
            this.findColumnInfo12.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo12.HeaderText = "項目名";
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.btnImageLoad);
            this.xPanel4.Controls.Add(this.xButtonList1);
            this.xPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel4.DrawBorder = true;
            this.xPanel4.Location = new System.Drawing.Point(5, 709);
            this.xPanel4.Name = "xPanel4";
            this.xPanel4.Size = new System.Drawing.Size(1104, 36);
            this.xPanel4.TabIndex = 3;
            // 
            // btnImageLoad
            // 
            this.btnImageLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImageLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnImageLoad.Image")));
            this.btnImageLoad.Location = new System.Drawing.Point(497, 3);
            this.btnImageLoad.Name = "btnImageLoad";
            this.btnImageLoad.Size = new System.Drawing.Size(90, 28);
            this.btnImageLoad.TabIndex = 1;
            this.btnImageLoad.Text = "ＰＣイメージ";
            this.btnImageLoad.Click += new System.EventHandler(this.btnImageLoad_Click);
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.xButtonList1.Dock = System.Windows.Forms.DockStyle.Right;
            this.xButtonList1.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Insert, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Preview, System.Windows.Forms.Shortcut.None, "SCAN", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Delete, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.xButtonList1.Location = new System.Drawing.Point(615, 0);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.xButtonList1.Size = new System.Drawing.Size(487, 34);
            this.xButtonList1.TabIndex = 0;
            this.xButtonList1.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.xButtonList1_PostButtonClick);
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.AutoScrollMargin = new System.Drawing.Size(563, 524);
            this.xPanel2.Controls.Add(this.previewPanel);
            this.xPanel2.Controls.Add(this.splitter1);
            this.xPanel2.Controls.Add(this.panel1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel2.Location = new System.Drawing.Point(5, 66);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(1104, 643);
            this.xPanel2.TabIndex = 5;
            // 
            // previewPanel
            // 
            this.previewPanel.AutoScroll = true;
            this.previewPanel.Controls.Add(this.pictWiaItem);
            this.previewPanel.Controls.Add(this.progressBar);
            this.previewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewPanel.Location = new System.Drawing.Point(591, 0);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(513, 643);
            this.previewPanel.TabIndex = 7;
            // 
            // pictWiaItem
            // 
            this.pictWiaItem.BackColor = IHIS.Framework.XColor.XMonthCalendarBackColor;
            this.pictWiaItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictWiaItem.Font = new System.Drawing.Font("MS UI Gothic", 9.75F);
            this.pictWiaItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictWiaItem.Location = new System.Drawing.Point(0, 0);
            this.pictWiaItem.Name = "pictWiaItem";
            this.pictWiaItem.Protect = false;
            this.pictWiaItem.Size = new System.Drawing.Size(513, 643);
            this.pictWiaItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictWiaItem.TabIndex = 5;
            this.pictWiaItem.TabStop = false;
            this.pictWiaItem.DoubleClick += new System.EventHandler(this.pictWiaItem_DoubleClick);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(103, 224);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(298, 30);
            this.progressBar.TabIndex = 6;
            this.progressBar.Text = "0%";
            this.progressBar.Visible = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(588, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 643);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grdDetail);
            this.panel1.Controls.Add(this.splitter2);
            this.panel1.Controls.Add(this.grdMaster);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 643);
            this.panel1.TabIndex = 5;
            // 
            // grdDetail
            // 
            this.grdDetail.CallerID = '2';
            this.grdDetail.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell16,
            this.xEditGridCell15,
            this.xEditGridCell9,
            this.xEditGridCell8,
            this.xEditGridCell10,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell24,
            this.xEditGridCell18});
            this.grdDetail.ColPerLine = 2;
            this.grdDetail.ColResizable = true;
            this.grdDetail.Cols = 3;
            this.grdDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDetail.FixedCols = 1;
            this.grdDetail.FixedRows = 1;
            this.grdDetail.HeaderHeights.Add(26);
            this.grdDetail.Location = new System.Drawing.Point(0, 309);
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.RowHeaderVisible = true;
            this.grdDetail.Rows = 2;
            this.grdDetail.Size = new System.Drawing.Size(588, 334);
            this.grdDetail.TabIndex = 6;
            this.grdDetail.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDetail_QueryStarting);
            this.grdDetail.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdDetail_PreSaveLayout);
            this.grdDetail.RowFocusChanging += new IHIS.Framework.RowFocusChangingEventHandler(this.grdDetail_RowFocusChanging);
            this.grdDetail.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdDetail_SaveEnd);
            this.grdDetail.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdDetail_RowFocusChanged);
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "pkscan001";
            this.xEditGridCell16.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "fkocs";
            this.xEditGridCell15.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "system";
            this.xEditGridCell9.CellWidth = 55;
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.HeaderText = "システム";
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "cr_time";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.DateTime;
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "jundal_part";
            this.xEditGridCell10.CellWidth = 72;
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.HeaderText = "伝達パート";
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "bunho";
            this.xEditGridCell12.CellWidth = 74;
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.HeaderText = "患者番号";
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellLen = 100;
            this.xEditGridCell13.CellName = "image_path";
            this.xEditGridCell13.CellWidth = 288;
            this.xEditGridCell13.Col = 1;
            this.xEditGridCell13.HeaderText = "イメージ保存経路";
            this.xEditGridCell13.IsReadOnly = true;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellLen = 50;
            this.xEditGridCell14.CellName = "image";
            this.xEditGridCell14.CellWidth = 256;
            this.xEditGridCell14.Col = 2;
            this.xEditGridCell14.HeaderText = "イメージファイル名";
            this.xEditGridCell14.IsReadOnly = true;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "seq";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell18.CellName = "btn";
            this.xEditGridCell18.CellWidth = 76;
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.HeaderText = "イメージ修正";
            this.xEditGridCell18.IsUpdCol = false;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            this.xEditGridCell18.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 306);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(588, 3);
            this.splitter2.TabIndex = 7;
            this.splitter2.TabStop = false;
            // 
            // grdMaster
            // 
            this.grdMaster.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell11,
            this.xEditGridCell17,
            this.xEditGridCell23,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell25});
            this.grdMaster.ColPerLine = 10;
            this.grdMaster.ColResizable = true;
            this.grdMaster.Cols = 11;
            this.grdMaster.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdMaster.FixedCols = 1;
            this.grdMaster.FixedRows = 1;
            this.grdMaster.HeaderHeights.Add(25);
            this.grdMaster.Location = new System.Drawing.Point(0, 0);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.ReadOnly = true;
            this.grdMaster.RowHeaderVisible = true;
            this.grdMaster.Rows = 2;
            this.grdMaster.Size = new System.Drawing.Size(588, 306);
            this.grdMaster.TabIndex = 5;
            this.grdMaster.ToolTipActive = true;
            this.grdMaster.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdMaster_RowFocusChanged);
            this.grdMaster.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMaster_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "gumsa_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.Col = 2;
            this.xEditGridCell1.HeaderText = "検査日付";
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "jundal_part_name";
            this.xEditGridCell2.CellWidth = 71;
            this.xEditGridCell2.Col = 3;
            this.xEditGridCell2.HeaderText = "伝達パート";
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "bunho";
            this.xEditGridCell3.CellWidth = 70;
            this.xEditGridCell3.Col = 4;
            this.xEditGridCell3.HeaderText = "患者番号";
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "suname";
            this.xEditGridCell4.CellWidth = 77;
            this.xEditGridCell4.Col = 5;
            this.xEditGridCell4.HeaderText = "患者氏名";
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "hangmog_name";
            this.xEditGridCell5.CellWidth = 121;
            this.xEditGridCell5.Col = 6;
            this.xEditGridCell5.HeaderText = "項目名";
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "in_out_gubun";
            this.xEditGridCell6.CellWidth = 38;
            this.xEditGridCell6.Col = 1;
            this.xEditGridCell6.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem3,
            this.xComboItem4});
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell6.HeaderText = "外/入";
            // 
            // xComboItem3
            // 
            this.xComboItem3.DisplayItem = "外来";
            this.xComboItem3.ValueItem = "O";
            // 
            // xComboItem4
            // 
            this.xComboItem4.DisplayItem = "入院";
            this.xComboItem4.ValueItem = "I";
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "fkocs";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "system";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "jundal_part";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "emergency";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "hangmog_code";
            this.xEditGridCell19.CellWidth = 67;
            this.xEditGridCell19.Col = 7;
            this.xEditGridCell19.HeaderText = "項目コード";
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "specimen_code";
            this.xEditGridCell20.CellWidth = 30;
            this.xEditGridCell20.Col = 8;
            this.xEditGridCell20.HeaderText = "検体";
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "specimen_name";
            this.xEditGridCell21.CellWidth = 87;
            this.xEditGridCell21.Col = 9;
            this.xEditGridCell21.HeaderText = "検体名";
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "doctor";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "doctor_name";
            this.xEditGridCell25.Col = 10;
            this.xEditGridCell25.HeaderText = "医師名";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.SynchronizingObject = this;
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
            // 
            // layHangmog
            // 
            this.layHangmog.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layHangmog.QuerySQL = "SELECT HANGMOG_NAME\r\n   FROM OCS0103\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()\r" +
                "\n   AND HANGMOG_CODE = :f_hangmog_code\r\n   AND TRUNC(SYSDATE) BETWEEN START_DATE" +
                " AND NVL(END_DATE, \'9998/12/31\')";
            this.layHangmog.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layHangmog_QueryStarting);
            this.layHangmog.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layHangmog_QueryEnd);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.BindControl = this.dbxHangmogName;
            this.singleLayoutItem1.DataName = "dbxHangmogName";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // layOrderList
            // 
            this.layOrderList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1});
            this.layOrderList.QuerySQL = resources.GetString("layOrderList.QuerySQL");
            this.layOrderList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layOrderList_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "pkocs";
            // 
            // SCANUPLOADER
            // 
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel4);
            this.Controls.Add(this.xPanel1);
            this.Name = "SCANUPLOADER";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1114, 750);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paid)).EndInit();
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.previewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictWiaItem)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderList)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region fields
        private string mPathNm = string.Empty;
        private string grdDeatail_IUD = string.Empty;
        private DateTime mCrTime;
        private string ip = string.Empty;
        private string user = string.Empty;
        private string pswd = string.Empty;
        private string msg = string.Empty;
        #endregion

        #region properties
        // path
        [Browsable(false), DataBindable]
        public string PathNm
        {
            get { return mPathNm; }
        }
        #endregion

        #region 로드시 처리할 것들
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        private void PostLoad()
        {

            dtpFrDt.SetDataValue(EnvironInfo.GetSysDate().AddDays(-7));
            dtpToDt.SetDataValue(EnvironInfo.GetSysDate());

            string strSys=EnvironInfo.CurrSystemID.Substring(0, 3);

            if (strSys != "CPL")
            {
                cboSystem.SetEditValue(strSys);
                grdMaster_CellSize(false);
            }
            else
            {
                cboSystem.SetEditValue("CPL");
                grdMaster_CellSize(true);
            }

            /*
            if (EnvironInfo.CurrSystemID == "CPLS")
                cboSystem.SetEditValue("CPL");
            else
                cboSystem.SetEditValue(EnvironInfo.CurrSystemID);
            cboSystem.AcceptData();
             * 
             */


            //cboSystem.SelectedIndex = 0;
            //cboJundal.SelectedIndex = 0;

            //if (EnvironInfo.CurrSystemID == "CPLS")
            //{
            //    cboSystem.SetEditValue("CPL");
            //    grdMaster_CellSize(true);
            //}
            //else
            //{
            //    cboSystem.SetEditValue(EnvironInfo.CurrSystemID);
            //    grdMaster_CellSize(false);
            //}
            //cboSystem.AcceptData();
            //cboSystem.SelectedIndex = 0;
            //cboJundal.SelectedIndex = 0;


            if (this.OpenParam != null)
            {
                this.mBunho = this.OpenParam["bunho"].ToString();
                this.mOrderDate = this.OpenParam["order_date"].ToString();
                this.mSystemID = this.OpenParam["system_id"].ToString();
                this.mJundalPart = this.OpenParam["jundal_part"].ToString();
                this.mHangmogCode = this.OpenParam["hangmog_code"].ToString();

                this.paid.SetPatientID(mBunho);
                //this.dtpFrDt.SetDataValue(mOrderDate);
                //this.dtpToDt.SetDataValue(mOrderDate);
                this.cboSystem.SetDataValue(mSystemID);
                this.cboJundal.SetDataValue(mJundalPart);
                this.fbxHangmogCode.SetDataValue(mHangmogCode);
                if (!this.grdMaster.QueryLayout(false))
                {
                    XMessageBox.Show("PostLoad() grdMaster ERR! " + Service.ErrFullMsg);
                    return;
                }
            }

            string cmdStr = @"SELECT CODE_NAME FROM OCS0132 WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() AND CODE_TYPE = 'RESULT_PATH' AND CODE = 'PATH'";
            object retVal = Service.ExecuteScalar(cmdStr);
            if (!TypeCheck.IsNull(retVal))
            {
                mPathNm = retVal.ToString();
            }
            this.xButtonList1.PerformClick(FunctionType.Query);
        }
        #endregion

        #region 버튼리스트 클릭시 처리할 것들
        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    if (!this.grdMaster.QueryLayout(true))
                    {
                        XMessageBox.Show("ButtonList Click grdMaster.QueryLayout Err! " + Service.ErrFullMsg);
                        return;
                    }
                    break;
                case FunctionType.Insert:
                    if (this.grdMaster.RowCount == 0)
                    {
                        e.IsBaseCall = false;
                        e.IsSuccess = false;
                    }

                    for(int i =0; i < grdDetail.Rows ; i++)
                    {
                        if (grdDetail.GetRowState(i) == DataRowState.Added)
                        {
                            string msg = (NetInfo.Language == LangMode.Ko ? "데이타가 변경되었습니다. 저장해주세요."
                                : "データが変更されました。保存してください。");
                            XMessageBox.Show(msg, "確認");

                            e.IsBaseCall = false;
                            e.IsSuccess = false;
                            return;
                        }
                    }

                    this.CurrMSLayout = grdDetail;
                    this.CurrMQLayout = grdDetail;
                    break;
                case FunctionType.Delete:
                    this.CurrMSLayout = grdDetail;
                    this.CurrMQLayout = grdDetail;

                    
                    
                    break;
                case FunctionType.Preview:
                    if (this.grdDetail.RowCount > 0)
                    {
                        ScanStart();
                    }
                    else
                    {
                        string msg = (NetInfo.Language == LangMode.Ko ? "이미지파일 정보를 등록해 주세요"
                            : "イメージファイル情報を登録してください。");
                        XMessageBox.Show(msg, "確認");
                    }
                    break;
                case FunctionType.Update:
                    e.IsBaseCall = false;
                    if (this.pictWiaItem.Image != null)
                    {                        
                            timer2.Stop();
                            //Service.BeginTransaction();
                            try
                            {
                                mCrTime = EnvironInfo.GetSysDateTime();

                                Service.BeginTransaction();

                                if (!this.grdDetail.SaveLayout())
                                {
                                    //Service.RollbackTransaction();
                                    XMessageBox.Show("update Err! " + Service.ErrFullMsg);
                                    return;
                                }

                                // 메세지 보내기
                                if (!this.SendMSG())
                                {
                                    new Exception("Send Message ERR!");
                                }
                                Service.CommitTransaction();
                                
                            }
                            catch (Exception ex)
                            {
                                Service.RollbackTransaction();
                                //https://sofiamedix.atlassian.net/browse/MED-10610
                                //XMessageBox.Show("saveLogic ERR! " + ex.Message);
                                return;
                            }

                    }
                    else
                    {
                        if (grdDetail.RowCount == 0) // 로우가 없으면, 이미지 없이 저장이 되어야 한다.
                        {
                            this.grdDetail.SaveLayout();
                        }
                        else
                        {
                            string msg = (NetInfo.Language == LangMode.Ko ? "이미지가 존재하지 않습니다. 스켄 또는 폴더이미지를 선택하여 이미지 로드 후 저장해 주세요."
                                : "イメージが存在しません。スキャン又はフォルダイメージを選択してイメージロード後、保存してください。");
                            XMessageBox.Show(msg, "確認");
                            grdDetail.DeleteRow(grdDetail.CurrentRowNumber);
                            e.IsSuccess = false;
                        }
                    }   
                    

                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Message System

        private bool SendMSG()
        {
            /*
            string msg = "";
            string cap = "";

            string user_id = UserInfo.UserID;
            string senderBuseo = UserInfo.BuseoCode;
            string doctor = this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "doctor").Substring(2);
            string suname = this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "suname");

            string msgTitle = this.cboSystem.Text;
            string msgContents = suname + "さんの検査結果が登録されました。";

            string newLine = "\r\n";
            object tempobject = null;
            string sendSeq = "";


            //해당일자,해당사용자의 MAX 송신순번
            string cmd = " SELECT NVL(MAX(SEND_SEQ),0) + 1 FROM ADM0700 "
                + "  WHERE SEND_DT   = TRUNC(SYSDATE) "
                + "    AND SENDER_ID = '" + user_id + "' ";

            tempobject = Service.ExecuteScalar(cmd);

            if (tempobject == null || tempobject.ToString() == "")
            {
                sendSeq = "1";
            }
            else
            {
                sendSeq = tempobject.ToString();
            }

            // 송신내역 insert 
            cmd = @" INSERT INTO ADM0700
                                      (SEND_DT, SENDER_ID, SEND_SEQ, SEND_SPOT, MSG_TITLE, MSG_CONTENTS, VALID_YN, SEND_ALL_CNFM_YN,
                                       RECV_ALL_CNFM_YN, FILE_ATCH_YN, CR_MEMB, CR_TIME, CR_TRM)
                                 VALUES
                                      (TRUNC(SYSDATE), :f_sender_id, :f_send_seq, :f_sender_buseo, :f_msg_title, :f_msg_contents, 'Y',:f_send_all_cnfm_yn,
                                      'N', :f_file_atch_yn, :f_user_id, SYSDATE, :f_user_trm)";
            BindVarCollection bindVar = new BindVarCollection();

            bindVar.Add("f_sender_id", user_id);
            bindVar.Add("f_send_seq", sendSeq);
            bindVar.Add("f_sender_buseo", senderBuseo);
            bindVar.Add("f_msg_title", msgTitle);
            bindVar.Add("f_msg_contents", msgContents);
            bindVar.Add("f_send_all_cnfm_yn", "N");
            bindVar.Add("f_file_atch_yn", "N");
            bindVar.Add("f_user_id", user_id);
            bindVar.Add("f_user_trm", "");

            if (Service.ExecuteNonQuery(cmd, bindVar) == false)
            {
                msg = "送信内訳生成に失敗しました。[" + Service.ErrFullMsg + "]";
                cap = "送信失敗";

                return false;
            }

            object recv_spot = null;

            cmd = @" SELECT A.DEPT_CODE "
                       + "   FROM ADM3200 A "
                       + "  WHERE A.USER_ID = '" + doctor + "' ";

            recv_spot = Service.ExecuteScalar(cmd);

            if (recv_spot == null)
            {
                recv_spot = "";
            }

            cmd = " DECLARE " + newLine
                + "   T_CHECK   VARCHAR2(1); " + newLine
                + " BEGIN " + newLine
                + "   T_CHECK := 'N'; " + newLine
                + "   FOR R1 IN ( SELECT 'X' " + newLine
                + "                 FROM ADM0710 X " + newLine
                + "                WHERE SEND_DT = TRUNC(SYSDATE) " + newLine
                + "                  AND SENDER_ID = '" + user_id + "' " + newLine
                + "                  AND SEND_SEQ = " + sendSeq + newLine
                + "                  AND RECV_SPOT = '" + recv_spot.ToString() + "' " + newLine
                + "                  AND RECVER_ID = '" + doctor + "') LOOP " + newLine
                + "      T_CHECK := 'Y'; " + newLine
                + "   END LOOP;" + newLine
                + "   IF T_CHECK != 'Y' THEN " + newLine
                + "     INSERT INTO ADM0710 " + newLine
                + "          ( SEND_DT     , SENDER_ID   , SEND_SEQ, RECV_SPOT " + newLine
                + "          , RECVER_ID   , RECV_SPOT_YN, CNFM_YN , RECV_ALL_CNFM_YN " + newLine
                + "          , FILE_ATCH_YN, VALID_YN    , UP_MEMB , UP_TIME " + newLine
                + "          , UP_TRM      , CR_MEMB     , CR_TIME , CR_TRM           )" + newLine
                + "     VALUES " + newLine
                + "          ( TRUNC(SYSDATE), '" + user_id + "' " + newLine
                + "          , " + sendSeq + ", '" + recv_spot.ToString() + "' " + newLine
                + "          , '" + doctor + "', 'Y' " + newLine
                + "          , 'N', 'N' " + newLine
                + "          , 'N', 'Y' " + newLine
                + "          , '" + user_id + "', SYSDATE " + newLine
                + "          , '', '" + user_id + "' " + newLine
                + "          , SYSDATE, '' ); " + newLine
                + "   END IF; " + newLine
                + " END ;";

            if (Service.ExecuteNonQuery(cmd) == false)
            {
                msg = "送信内訳生成に失敗しました。[" + Service.ErrFullMsg + "]";
                cap = "送信失敗";

                return false;
            }

            IHIS.Framework.UdpHelper.SendMsgToID(UserInfo.UserID, doctor, msgTitle, msgContents);
            //IHIS.Framework.UdpHelper.SendMsgToID(doctor, UserInfo.UserID, msgTitle, msgContents + "2");
            */

            return true;
        
        }

        #endregion

        #region 버튼리스트 클릭 후 처리할 것들
        private void xButtonList1_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert:
                    if (e.IsSuccess)
                    {
                        //인서트시에 파일명 생성

                        string strsql = "   SELECT SCAN001_SEQ.NEXTVAL FROM DUAL ";

                        object retVal = Service.ExecuteScalar(strsql);

                        if (retVal == null)
                        {
                            retVal = "1";
                        }                       

                        //int seq = this.grdDetail.RowCount;

                        string seq = retVal.ToString();
                        /*
                        * 추후 경로변경 필요
                        * "/IFCImage/..."를 "/IHISImage/..."로 변경필요
                        * 
                        * */
                        
                        string gumsa_date = this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "gumsa_date");
                        string path = mPathNm + "/"
                            //+ this.cboSystem.GetDataValue().Substring(0, 3) + "/"
                            + this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "system") + "/"
                            + this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "jundal_part") + "/"
                            + gumsa_date.Substring(0,4) + "/"
                            + DateTime.Parse(gumsa_date).ToString("yyyyMMdd") + "/";
                        //						string path = "/IHISImage/" + this.cboSystem.GetDataValue().Substring(0,3) + "/" 
                        //							+ this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber,"jundal_part") + "/";

                        string name = this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "bunho") + "."
                            + this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "gumsa_date").Replace("/", "") + "."
                            //+ this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "fkocs") + "."
                            + seq.ToString() + ".JPG";
                        grdDetail.SetItemValue(grdDetail.CurrentRowNumber, "image_path", path);
                        grdDetail.SetItemValue(grdDetail.CurrentRowNumber, "image", name);
                        grdDetail.SetItemValue(grdDetail.CurrentRowNumber, "seq", seq);
                        grdDetail.SetItemValue(grdDetail.CurrentRowNumber, "cr_time", EnvironInfo.GetSysDateTime());
                    }
                    
                    break;
                case FunctionType.Update:
                    if (e.IsSuccess)
                    {
                        XMessageBox.Show("保存されました");
                    }
                    else
                    {
                        XMessageBox.Show("保存できませんでした");
                    }
                    break;


                case FunctionType.Delete:

                    timer2.Stop();
                    pictWiaItem.Image = null;

                    if (grdDetail.RowCount < 1) return;

                    if (grdDetail.GetRowState(grdDetail.CurrentRowNumber) == DataRowState.Unchanged)
                    {
                        //이미지 다운로드하여 이미지 SET(다운로드 이미지 리스트를 만들어 Download)
                        string fileName = this.grdDetail.GetItemString(this.grdDetail.CurrentRowNumber, "image");
                        if (fileName.Trim().Length > 0)
                        {
                            string jundal_part = this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "jundal_part");
                            string filePath = Directory.GetParent(Application.StartupPath) + "\\" + cboSystem.GetDataValue().Substring(0, 3) + "Images" + "\\" + jundal_part;
                            string createTime = grdDetail.GetItemString(grdDetail.CurrentRowNumber, "cr_time");
                            //createTime = EnvironInfo.GetSysDate().ToString();
                            string serverPath = grdDetail.GetItemString(grdDetail.CurrentRowNumber, "image_path");
                            if (ImageHelper.IsFileDownload(filePath + "\\" + fileName, DateTime.Parse(createTime)))
                            {
                                ArrayList fileList = new ArrayList();
                                fileList.Add(new ImageFileInfo(filePath, serverPath, fileName, fileName));
                                ImageHelper.DownloadImages(fileList, false);
                            }
                            this.pictWiaItem.Image = ImageHelper.GetImage(filePath + "\\" + fileName);
                        }
                    }

                    break;

            }
        }
        #endregion

        #region 항목그리드 로우 포커스 체인지
        private void grdMaster_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            pictWiaItem.Image = null;

            grdDetail.SetBindVarValue("f_fkocs", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "fkocs"));
            if (!this.grdDetail.QueryLayout(true))
            {
                XMessageBox.Show("grdDetail_RowFocusChanged grdDetail ERR! " + Service.ErrFullMsg);
                return;
            }

            layOrderList.QueryLayout(true);

            //cboSystem.SetDataValue(grdMaster.GetItemValue(grdMaster.CurrentRowNumber, "system"));
            //cboJundal.SetDataValue(grdMaster.GetItemValue(grdMaster.CurrentRowNumber, "jundal_part"));
        }
        #endregion

        #region 이미지그리드 저장 전 처리
        private void grdDetail_PreSaveLayout(object sender, IHIS.Framework.GridRecordEventArgs e)
        {
            //grdDeatail_IUD = e.RowState.ToString();
            if (e.RowState == DataRowState.Added)
            {
                if (grdMaster.GetItemString(grdMaster.CurrentRowNumber, "fkocs") != "")
                {
                    grdDetail.SetItemValue(e.RowNumber, "fkocs", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "fkocs"));
                }
                //grdDetail.SetItemValue(e.RowNumber, "pkscan001", seq);
                grdDetail.SetItemValue(e.RowNumber, "system", grdMaster.GetItemValue(grdMaster.CurrentRowNumber, "system"));
                grdDetail.SetItemValue(e.RowNumber, "jundal_part", grdMaster.GetItemValue(grdMaster.CurrentRowNumber, "jundal_part"));
                grdDetail.SetItemValue(e.RowNumber, "bunho", grdMaster.GetItemValue(grdMaster.CurrentRowNumber, "bunho"));
            }
        }
        #endregion

        #region 이미지그리드 로우 포커스 처리
        private void grdDetail_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            timer2.Stop();
            
            pictWiaItem.Image = null;

            if (grdDetail.RowCount < 1) return;

            if (grdDetail.GetRowState(e.CurrentRow) == DataRowState.Unchanged)
            {
                //이미지 다운로드하여 이미지 SET(다운로드 이미지 리스트를 만들어 Download)
                string fileName = this.grdDetail.GetItemString(this.grdDetail.CurrentRowNumber, "image");
                if (fileName.Trim().Length > 0)
                {
                    string jundal_part = this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "jundal_part");
                    string filePath = Directory.GetParent(Application.StartupPath) + "\\" + cboSystem.GetDataValue().Substring(0, 3) + "Images" + "\\" + jundal_part;
                    string createTime = grdDetail.GetItemString(grdDetail.CurrentRowNumber, "cr_time");
                    //createTime = EnvironInfo.GetSysDate().ToString();
                    string serverPath = grdDetail.GetItemString(grdDetail.CurrentRowNumber, "image_path");
                    if (ImageHelper.IsFileDownload(filePath + "\\" + fileName, DateTime.Parse(createTime)))
                    {
                        ArrayList fileList = new ArrayList();
                        fileList.Add(new ImageFileInfo(filePath, serverPath, fileName, fileName));
                        ImageHelper.DownloadImages(fileList, false);
                    }
                    this.pictWiaItem.Image = ImageHelper.GetImage(filePath + "\\" + fileName);

                }
            }
        }
        #endregion

        #region 이미지 저장 처리 후
        private void grdDetail_SaveEnd(object sender, IHIS.Framework.SaveEndEventArgs e)
        {
            if (e.IsSuccess)
            {
                switch (grdDeatail_IUD)
                {
                    case "Added":
                    case "Modified":
                        string jundal_part = this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "jundal_part");
                        string gumsa_date = this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "gumsa_date");
                        string image_name = grdDetail.GetItemString(grdDetail.CurrentRowNumber, "image");

                        Image image = pictWiaItem.Image;
                        string filePath = Directory.GetParent(Application.StartupPath) + "\\" + cboSystem.GetDataValue().Substring(0, 3) + "Images" + "\\" + jundal_part;
                        //파일경로가 없으면 생성
                        if (!Directory.Exists(filePath))
                            Directory.CreateDirectory(filePath);
                        //Image를 Client 파일로 저장(파일명은 서버파일명으로)한후에 FTP를 통해 서버로 Upload
                        string fileName = Directory.GetParent(Application.StartupPath) + "\\" + cboSystem.GetDataValue().Substring(0, 3) + "Images" + "\\" + jundal_part + "\\" + image_name;
                        //Image를 지정한 파일로 저장
                        if (!ImageHelper.SaveImageFile(image, fileName)) return;

                        string clientFilePath = Directory.GetParent(Application.StartupPath) + "\\" + cboSystem.GetDataValue().Substring(0, 3) + "Images" + "\\" + jundal_part;

                        /*
                            * 추후 경로변경 필요
                            * "/IFCImage/..."를 "/IHISImage/..."로 변경필요
                            * 
                        * */
                        string serverFilePath = mPathNm + "/"
                            //+ this.cboSystem.GetDataValue().Substring(0, 3) + "/"
                                + this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "system") + "/"
                                + this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "jundal_part") + "/"
                                + gumsa_date.Substring(0, 4) + "/"
                                + DateTime.Parse(gumsa_date).ToString("yyyyMMdd");
                        //					string serverFilePath = "/IHISImage/" + cboSystem.GetDataValue().Substring(0,3) + "/" + jundal_part;
                        ArrayList uploadFileInfoList = new ArrayList();
                        uploadFileInfoList.Add(new ImageFileInfo(clientFilePath, serverFilePath, image_name, image_name));

                        //Upload 실패시 Return
                        if (!ImageHelper.UploadImages(uploadFileInfoList, true))
                            return;

                        break;

                    default:
                        break;

                }

                /*
                if (grdDeatail_IUD == "Added" || grdDeatail_IUD == "Modified")
                {
                    string jundal_part = this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "jundal_part");
                    string gumsa_date = this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "gumsa_date");
                    string image_name = grdDetail.GetItemString(grdDetail.CurrentRowNumber, "image");

                    Image image = pictWiaItem.Image;
                    string filePath = Directory.GetParent(Application.StartupPath) + "\\" + cboSystem.GetDataValue().Substring(0, 3) + "Images" + "\\" + jundal_part;
                    //파일경로가 없으면 생성
                    if (!Directory.Exists(filePath))
                        Directory.CreateDirectory(filePath);
                    //Image를 Client 파일로 저장(파일명은 서버파일명으로)한후에 FTP를 통해 서버로 Upload
                    string fileName = Directory.GetParent(Application.StartupPath) + "\\" + cboSystem.GetDataValue().Substring(0, 3) + "Images" + "\\" + jundal_part + "\\" + image_name;
                    //Image를 지정한 파일로 저장
                    if (!ImageHelper.SaveImageFile(image, fileName)) return;

                    string clientFilePath = Directory.GetParent(Application.StartupPath) + "\\" + cboSystem.GetDataValue().Substring(0, 3) + "Images" + "\\" + jundal_part;

                    /*
                        * 추후 경로변경 필요
                        * "/IFCImage/..."를 "/IHISImage/..."로 변경필요
                        * 
                    * 
                    string serverFilePath = mPathNm + "/"
                            //+ this.cboSystem.GetDataValue().Substring(0, 3) + "/"
                            + this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "system") + "/"
                            + this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "jundal_part") + "/"
                            + gumsa_date.Substring(0, 4) + "/"
                            + DateTime.Parse(gumsa_date).ToString("yyyyMMdd");
                    //					string serverFilePath = "/IHISImage/" + cboSystem.GetDataValue().Substring(0,3) + "/" + jundal_part;
                    ArrayList uploadFileInfoList = new ArrayList();
                    uploadFileInfoList.Add(new ImageFileInfo(clientFilePath, serverFilePath, image_name, image_name));

                    //Upload 실패시 Return
                    if (!ImageHelper.UploadImages(uploadFileInfoList, true))
                        return;

                }
            */
                //정상저장 처리 완료 후 이미지 그리드의 재조회
                if (!this.grdDetail.QueryLayout(false))
                {
                    XMessageBox.Show("grdDetail_SaveEnd grdDetail Layout Err! " + Service.ErrFullMsg);
                    return;

                }
            }
        }
        #endregion

        #region 시스템 변경시 전달파트콤보 재구성
        private void cboSystem_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string sql = "";
            string sql2 = "";
            if (this.cboSystem.GetDataValue() == "CPL")
            {
                sql = @"SELECT '%', ''
                          FROM DUAL
                         UNION ALL
                        SELECT DISTINCT 
                               A.CODE
                             , A.CODE_NAME 
                          FROM CPL0109 A 
                         WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                           AND A.CODE_TYPE  = '01'
                           AND EXISTS (SELECT 'X' 
                                         FROM CPL0101 C
                                            , OCS0103 B
                                        WHERE B.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                                          AND (B.JUNDAL_TABLE_OUT = 'CPL' OR B.JUNDAL_TABLE_INP = 'CPL')
                                          AND (B.JUNDAL_PART_OUT  = 'CPL' OR B.JUNDAL_PART_INP  = 'CPL')
                                          AND B.RESULT_GUBUN = 'S'
                                          AND C.HOSP_CODE    = B.HOSP_CODE 
                                          AND C.HANGMOG_CODE = B.HANGMOG_CODE
                                          AND C.JUNDAL_GUBUN = A.CODE
                                          AND TRUNC(SYSDATE) BETWEEN B.START_DATE AND NVL(B.END_DATE, '9998/12/31'))
                                          ";
                this.cboJundal.UserSQL = sql;
                this.cboJundal.SetDictDDLB();
                this.cboJundal.SelectedIndex = 0;
                this.cboJundal.Refresh();
                sql2 = "SELECT GUMSA_NAME FROM CPL0101 WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() AND HANGMOG_CODE = :f_hangmog_code";
                this.layHangmog.QuerySQL = sql2;
            }
            else
            {
                sql = @"SELECT '%', ''
                          FROM DUAL
                         UNION ALL
                        SELECT DISTINCT 
                               JUNDAL_PART_OUT
                             , FN_BAS_LOAD_GWA_NAME(JUNDAL_PART_OUT,SYSDATE) 
                          FROM OCS0103 
                         WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                           AND JUNDAL_TABLE_OUT = '" + this.cboSystem.GetDataValue() + @"'
                           AND RESULT_GUBUN = 'S'
                           AND TRUNC(SYSDATE) BETWEEN START_DATE AND NVL(END_DATE, '9998/12/31')";
                this.cboJundal.UserSQL = sql;
                this.cboJundal.SetDictDDLB();
                //this.cboJundal.SetEditValue("00");
                this.cboJundal.SelectedIndex = 0;
                this.cboJundal.Refresh();
                sql2 = "SELECT HANGMOG_NAME FROM OCS0103 WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() AND HANGMOG_CODE = :f_hangmog_code AND TRUNC(SYSDATE) BETWEEN START_DATE AND NVL(END_DATE, '9998/12/31')";
                this.layHangmog.QuerySQL = sql2;
            }

            this.fbxHangmogCode.SetDataValue("");
            this.dbxHangmogName.SetDataValue("");
            this.cboJundal.AcceptData();
            this.xButtonList1.PerformClick(FunctionType.Query);

        }
        #endregion

        #region 이미지그리드 클릭시 행 없을때 자동 추가
        private void grdDetail_Click(object sender, System.EventArgs e)
        {
            if (this.grdMaster.RowCount > 0 && this.grdDetail.RowCount == 0)
                xButtonList1.PerformClick(FunctionType.Insert);
        }
        #endregion

        #region 그리드의 이미지 편집 버튼 클릭, 또는 이미지를 더블 클릭 할때 편집 가능하게 처리
        private void grdDetail_GridButtonClick(object sender, IHIS.Framework.GridButtonClickEventArgs e)
        {
            if (e.ColName == "btn")
            {
                EditImage();
            }
        }

        private void pictWiaItem_DoubleClick(object sender, System.EventArgs e)
        {
            EditImage();
        }

        private void EditImage()
        {
            ImageEditorForm dlg = new ImageEditorForm(this.pictWiaItem.Image);
            if (dlg.ShowDialog() != DialogResult.OK) return; //편집저장시만 처리

            Image image = dlg.Image;

            string jundal_part = this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "jundal_part");
            string gumsa_date = this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "gumsa_date");
            string image_name = grdDetail.GetItemString(grdDetail.CurrentRowNumber, "image");

            //Image를 Client 파일로 저장(파일명은 서버파일명으로)한후에 FTP를 통해 서버로 Upload
            string fileName = Directory.GetParent(Application.StartupPath) + "\\" + cboSystem.GetDataValue().Substring(0, 3) + "Images" + "\\" + jundal_part + "\\" + image_name;

            string clientFilePath = Directory.GetParent(Application.StartupPath) + "\\" + cboSystem.GetDataValue().Substring(0, 3) + "Images" + "\\" + jundal_part;
            /*
            * 추후 경로변경 필요
            * "/IFCImage/..."를 "/IHISImage/..."로 변경필요
            * 
            * */
            string serverFilePath = mPathNm + "/"
                            //+ this.cboSystem.GetDataValue().Substring(0, 3) + "/"
                            + this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "system") + "/"
                            + this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "jundal_part") + "/"
                            + gumsa_date.Substring(0, 4) + "/"
                            + DateTime.Parse(gumsa_date).ToString("yyyyMMdd");
            //			string serverFilePath = "/IHISImage/" + cboSystem.GetDataValue().Substring(0,3) + "/" + jundal_part;

            //Image를 지정한 파일로 저장
            if (!ImageHelper.SaveImageFile(image, fileName)) return;

            ArrayList imageFileInfoList = new ArrayList();
            imageFileInfoList.Add(new ImageFileInfo(clientFilePath, serverFilePath, image_name, image_name));

            //Upload 실패시 Return
            if (!ImageHelper.UploadImages(imageFileInfoList, true)) return;

            pictWiaItem.Image = ImageHelper.GetImage(fileName);


            this.grdDetail.SetItemValue(this.grdDetail.CurrentRowNumber, "cr_time", EnvironInfo.GetSysDateTime());
            this.grdDetail.SetItemValue(this.grdDetail.CurrentRowNumber, "system", this.cboSystem.GetDataValue());
            try
            {
                Service.BeginTransaction();

                if (!this.grdDetail.SaveLayout())
                {
                    Service.RollbackTransaction();
                    XMessageBox.Show("EditImage Save Err! " + Service.ErrFullMsg);
                    return;
                }
            }
            catch (Exception ex)
            {
                Service.RollbackTransaction();
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show("EditImage Save Err! " + ex.Message);
                return;
            }

        }
        #endregion

        #region 항목파인드 벨리데이션
        private void fwkHangmog_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string cmdSql = "";
            this.fwkHangmog.BindVarList.Clear();

            this.fwkHangmog.SetBindVarValue("f_jundal_part", this.cboJundal.GetDataValue());

            if (this.cboSystem.GetDataValue() == "CPL")
            {
                cmdSql = @"SELECT DISTINCT
								  A.HANGMOG_CODE
								, A.GUMSA_NAME
							 FROM OCS0103 B
                                , CPL0101 A
							WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                              AND A.JUNDAL_GUBUN LIKE :f_jundal_part||'%'
							  AND (A.HANGMOG_CODE LIKE :f_find1||'%'
								  OR A.GUMSA_NAME LIKE :f_find1||'%')
                              AND B.HOSP_CODE    = A.HOSP_CODE
                              AND B.HANGMOG_CODE = A.HANGMOG_CODE
                              AND B.RESULT_GUBUN = 'S'
                              AND TRUNC(SYSDATE) BETWEEN B.START_DATE AND NVL(B.END_DATE, '9998/12/31')
							ORDER BY A.HANGMOG_CODE";

            }
            else
            {
                cmdSql = @"SELECT DISTINCT
								  A.HANGMOG_CODE
								, A.HANGMOG_NAME 
							 FROM OCS0103 A
							WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                              AND (A.JUNDAL_PART_OUT = :f_jundal_part
								  OR A.JUNDAL_PART_INP = :f_jundal_part)
							  AND (A.HANGMOG_CODE LIKE :f_find1||'%'
								  OR A.HANGMOG_NAME LIKE :f_find1||'%')
                              AND A.RESULT_GUBUN = 'S'
                              AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND NVL(A.END_DATE, '9998/12/31')
							ORDER BY A.HANGMOG_CODE";
            }
            this.fwkHangmog.InputSQL = cmdSql;
        }
        #endregion

        #region pc내의 이미지 로드
        private void btnImageLoad_Click(object sender, System.EventArgs e)
        {
            if (this.grdDetail.RowCount > 0)
            {
                OpenFileDialog dlg = new OpenFileDialog();
                //dlg.Filter = "bmp files (*.bmp)|*.bmp|gif files (*.gif)|*.gif|jpg files (*.jpg)|*.jpg";
                dlg.Filter = "jpg files (*.jpg)|*.jpg|bmp files (*.bmp)|*.bmp|gif files (*.gif)|*.gif";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    pictWiaItem.Image = ImageHelper.GetImage(dlg.FileName);
                    grdDetail.SetItemValue(grdDetail.CurrentRowNumber, "btn", "");
                }
            }
            else
            {
                string msg = (NetInfo.Language == LangMode.Ko ? "이미지파일 정보를 등록해 주세요"
                    : "イメージファイル情報を登録してください。");
                XMessageBox.Show(msg, "確認");
            }
        }
        #endregion

        private void grdMaster_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string cmdSql = "";
            if (this.cboSystem.GetDataValue() == "CPL")
            {
                cmdSql = @"SELECT DECODE(A.JUNDAL_TABLE, 'HOM', A.ORDER_DATE, A.ACTING_DATE)  GUMSA_DATE
								, FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART,A.ORDER_DATE)   JUNDAL_PART_NAME
                                , A.BUNHO
                                , D.SUNAME
                                , '' HANGMOG_NAME
                                , 'O'   IN_OUT_GUBUN
                                , NULL FKOCS
                                , A.JUNDAL_TABLE
                                , A.JUNDAL_PART
                                , '' EMERGENCY
                                , '' HANGMOG_CODE
                                , A.SPECIMEN_CODE                
                                , FN_CPL_LOAD_CODE_NAME('04', A.SPECIMEN_CODE)
                                , A.DOCTOR
                                , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, SYSDATE)
							 FROM OUT0101 D
								, OCS0103 C
								, OCS1003 A
							WHERE A.HOSP_CODE = :f_hosp_code
                              AND DECODE(A.JUNDAL_TABLE, 'HOM', A.ORDER_DATE, A.ACTING_DATE)  BETWEEN :f_fr_date AND :f_to_date
							  AND A.BUNHO        LIKE :f_bunho||'%'
							  AND A.HANGMOG_CODE LIKE :f_hangmog_code||'%'
  							  --AND A.JUNDAL_PART  LIKE :f_jundal_part||'%'
                              AND C.HOSP_CODE    = A.HOSP_CODE
							  AND C.HANGMOG_CODE = A.HANGMOG_CODE
							  AND C.RESULT_GUBUN = 'S'
                              AND D.HOSP_CODE    = A.HOSP_CODE
							  AND D.BUNHO        = A.BUNHO
                              AND A.JUNDAL_TABLE = :f_jundal_table
                              AND A.ORDER_DATE BETWEEN C.START_DATE AND NVL(C.END_DATE, '9998/12/31')
                              GROUP BY DECODE(A.JUNDAL_TABLE, 'HOM', A.ORDER_DATE, A.ACTING_DATE), FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART, A.ORDER_DATE), A.BUNHO, SUNAME, A.SPECIMEN_CODE, A.DOCTOR, A.JUNDAL_TABLE, A.JUNDAL_PART
							UNION
                           SELECT DECODE(A.JUNDAL_TABLE, 'HOM', A.ORDER_DATE, A.ACTING_DATE)  GUMSA_DATE
								, FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART,A.ORDER_DATE)   JUNDAL_PART_NAME
								, A.BUNHO
								, D.SUNAME
								--, C.HANGMOG_NAME
                                , '' HANGMOG_NAME
                                , 'I'   IN_OUT_GUBUN
                                --, A.PKOCS2003  FKOCS
                                , NULL FKOCS
                                , A.JUNDAL_TABLE
                                , A.JUNDAL_PART
                                --, C.EMERGENCY
                                , '' EMERGENCY
                                --, C.HANGMOG_CODE
                                , '' HANGMOG_CODE
                                , A.SPECIMEN_CODE                
                                , FN_CPL_LOAD_CODE_NAME('04', A.SPECIMEN_CODE)
                                , A.DOCTOR
                                , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, SYSDATE)
							 FROM OUT0101 D
								, OCS0103 C
								, OCS2003 A
							WHERE A.HOSP_CODE = :f_hosp_code
                              AND A.ACTING_DATE  BETWEEN :f_fr_date AND :f_to_date
							  AND A.BUNHO        LIKE :f_bunho||'%'
							  AND A.HANGMOG_CODE LIKE :f_hangmog_code||'%'
  							  AND A.JUNDAL_PART  LIKE :f_jundal_part||'%'
                              AND C.HOSP_CODE    = A.HOSP_CODE
							  AND C.HANGMOG_CODE = A.HANGMOG_CODE
							  AND C.RESULT_GUBUN = 'S'
                              AND D.HOSP_CODE    = A.HOSP_CODE
							  AND D.BUNHO        = A.BUNHO
                              --AND C.JUNDAL_TABLE_INP = :f_jundal_table
                              AND A.JUNDAL_TABLE = :f_jundal_table
                              AND A.ORDER_DATE BETWEEN C.START_DATE AND NVL(C.END_DATE, '9998/12/31')
							ORDER BY 1 DESC,2,3,4";
                /*
                cmdSql = @"SELECT A.PART_JUBSU_DATE
								, E.CODE_NAME   JUNDAL_PART_NAME
								, A.BUNHO
								, D.SUNAME
								, C.GUMSA_NAME
								, A.IN_OUT_GUBUN
								, DECODE(A.IN_OUT_GUBUN,'I',A.FKOCS2003,A.FKOCS1003)  FKOCS
								, 'CPLS'
								, A.JUNDAL_GUBUN
								, B.EMERGENCY
								, B.HANGMOG_CODE
								, B.SPECIMEN_CODE
								, F.CODE_NAME       SPECIMEN_NAME
								, B.SPECIMEN_SER
							 FROM OCS0103 G
                                , CPL0109 F
								, CPL0109 E
								, OUT0101 D
								, CPL0101 C
								, CPL3020 B
								, CPL2010 A
							WHERE A.PART_JUBSU_DATE BETWEEN :f_fr_date AND :f_to_date     
							  AND A.BUNHO           LIKE :f_bunho||'%' 
							  AND A.PART_JUBSU_DATE IS NOT NULL
							  AND A.JUNDAL_GUBUN    LIKE :f_jundal_part||'%' 
							  AND A.HANGMOG_CODE    LIKE :f_hangmog_code||'%'
							  AND B.FKCPL2010       = A.PKCPL2010
							  AND C.HANGMOG_CODE    = B.HANGMOG_CODE
							  AND C.SPECIMEN_CODE   = B.SPECIMEN_CODE
							  AND C.EMERGENCY       = B.EMERGENCY
							  AND D.BUNHO           = A.BUNHO
							  AND E.CODE_TYPE       = '01'
							  AND E.CODE            = A.JUNDAL_GUBUN
							  AND F.CODE_TYPE       = '04'
							  AND F.CODE            = B.SPECIMEN_CODE
                              AND G.HANGMOG_CODE    = B.HANGMOG_CODE
                              AND G.RESULT_GUBUN    = 'S'
							ORDER BY 1,2,3,4";*/

            }
            else
            {
                cmdSql = @"SELECT A.ACTING_DATE  GUMSA_DATE
								, FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART,A.ORDER_DATE)   JUNDAL_PART_NAME
								, A.BUNHO
								, D.SUNAME
								, C.HANGMOG_NAME
								, 'O'   IN_OUT_GUBUN
								, A.PKOCS1003  FKOCS
								, A.JUNDAL_TABLE
								, A.JUNDAL_PART
								, C.EMERGENCY
								, C.HANGMOG_CODE
							 FROM OUT0101 D
								, OCS0103 C
								, OCS1003 A
							WHERE A.HOSP_CODE = :f_hosp_code
                              AND A.ACTING_DATE  BETWEEN :f_fr_date AND :f_to_date
							  AND A.BUNHO        LIKE :f_bunho||'%'
							  AND A.HANGMOG_CODE LIKE :f_hangmog_code||'%'
  							  AND A.JUNDAL_PART  LIKE :f_jundal_part||'%'
                              AND C.HOSP_CODE    = A.HOSP_CODE
							  AND C.HANGMOG_CODE = A.HANGMOG_CODE
							  AND C.RESULT_GUBUN = 'S'
                              AND D.HOSP_CODE    = A.HOSP_CODE
							  AND D.BUNHO        = A.BUNHO
                              AND C.JUNDAL_TABLE_OUT = :f_jundal_table
							UNION
                           SELECT DECODE(A.JUNDAL_TABLE, 'HOM', A.ORDER_DATE, A.ACTING_DATE)  GUMSA_DATE
								, FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART,A.ORDER_DATE)   JUNDAL_PART_NAME
								, A.BUNHO
								, D.SUNAME
								, C.HANGMOG_NAME
								, 'I'   IN_OUT_GUBUN
								, A.PKOCS2003  FKOCS
								, A.JUNDAL_TABLE
								, A.JUNDAL_PART
								, C.EMERGENCY
								, C.HANGMOG_CODE
							 FROM OUT0101 D
								, OCS0103 C
								, OCS2003 A
							WHERE A.HOSP_CODE = :f_hosp_code
                              AND A.ACTING_DATE  BETWEEN :f_fr_date AND :f_to_date
							  AND A.BUNHO        LIKE :f_bunho||'%'
							  AND A.HANGMOG_CODE LIKE :f_hangmog_code||'%'
  							  AND A.JUNDAL_PART  LIKE :f_jundal_part||'%'
                              AND C.HOSP_CODE    = A.HOSP_CODE
							  AND C.HANGMOG_CODE = A.HANGMOG_CODE
							  AND C.RESULT_GUBUN = 'S'
                              AND D.HOSP_CODE    = A.HOSP_CODE
							  AND D.BUNHO        = A.BUNHO
                              AND C.JUNDAL_TABLE_INP = :f_jundal_table
							ORDER BY 1 DESC,2,3,4";
            }
            this.grdMaster.QuerySQL = cmdSql;
            this.grdMaster.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdMaster.SetBindVarValue("f_jundal_table", this.cboSystem.GetDataValue());
            this.grdMaster.SetBindVarValue("f_fr_date", this.dtpFrDt.GetDataValue());
            this.grdMaster.SetBindVarValue("f_to_date", this.dtpToDt.GetDataValue());
            this.grdMaster.SetBindVarValue("f_jundal_part", this.cboJundal.GetDataValue());
            if (mBunho == "")
            {
                mBunho = paid.BunHo;
            }
            this.grdMaster.SetBindVarValue("f_bunho", mBunho);
            this.grdMaster.SetBindVarValue("f_hangmog_code", this.fbxHangmogCode.GetDataValue());
            this.grdDetail.Reset();
            pictWiaItem.Image = null;
        }

        private void grdDetail_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (cboSystem.GetDataValue() == "CPL")
            {
                grdDetail.QuerySQL = @"SELECT   '' PKSCAN001  
                                               ,'' FKOCS      
                                               ,A.SYSTEM     
                                               --,MIN(TO_CHAR(NVL(A.CR_TIME, SYSDATE),'YYYY/MM/DD HH24:MI:SS')) CR_TIME
                                               ,A.CR_TIME
                                               ,A.JUNDAL_PART
                                               ,A.BUNHO      
                                               ,A.IMAGE_PATH 
                                               ,A.IMAGE  
                                               ,'' SEQ
                                          FROM SCAN001 A
                                          WHERE A.HOSP_CODE = :f_hosp_code
                                            AND A.FKOCS IN (SELECT PKOCS1003 
                                                              FROM OCS1003 A,
                                                                   OCS0103 B
                                                             WHERE A.HOSP_CODE = :f_hosp_code
                                                               AND ACTING_DATE = :f_acting_date
                                                               AND B.HOSP_CODE = A.HOSP_CODE  
                                                               AND B.HANGMOG_CODE = A.HANGMOG_CODE
                                                               AND B.RESULT_GUBUN = 'S'
                                                               AND A.DOCTOR = :f_doctor
                                                               AND A.SPECIMEN_CODE = :f_specimen_code
                                                               AND A.JUNDAL_TABLE = :f_jundal_table
                                                               AND A.JUNDAL_PART = :f_jundal_part
                                                               AND A.BUNHO = :f_bunho)
                                            OR A.FKOCS IN (SELECT PKOCS2003 
                                                              FROM OCS2003 A,
                                                                   OCS0103 B
                                                             WHERE A.HOSP_CODE = :f_hosp_code
                                                               AND ACTING_DATE = :f_acting_date
                                                               AND B.HOSP_CODE = A.HOSP_CODE 
                                                               AND B.HANGMOG_CODE = A.HANGMOG_CODE
                                                               AND B.RESULT_GUBUN = 'S'
                                                               AND A.DOCTOR = :f_doctor
                                                               AND A.SPECIMEN_CODE = :f_specimen_code
                                                               AND A.JUNDAL_TABLE = :f_jundal_table
                                                               AND A.JUNDAL_PART = :f_jundal_part
                                                               AND A.BUNHO = :f_bunho)
                                       GROUP BY A.SYSTEM, A.JUNDAL_PART, A.BUNHO, A.IMAGE_PATH, A.IMAGE, A.CR_TIME";

                this.grdDetail.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.grdDetail.SetBindVarValue("f_acting_date", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "gumsa_date"));
                this.grdDetail.SetBindVarValue("f_doctor", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "doctor"));
                this.grdDetail.SetBindVarValue("f_specimen_code", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "specimen_code"));
                this.grdDetail.SetBindVarValue("f_jundal_table", cboSystem.GetDataValue());
                this.grdDetail.SetBindVarValue("f_jundal_part", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "jundal_part"));
                this.grdDetail.SetBindVarValue("f_bunho", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "bunho"));


            }
            else
            {
                grdDetail.QuerySQL = @"SELECT  A.PKSCAN001  
                                               ,A.FKOCS      
                                               ,A.SYSTEM     
                                               ,TO_CHAR(NVL(A.CR_TIME, SYSDATE),'YYYY/MM/DD HH24:MI:SS')    
                                               ,A.JUNDAL_PART
                                               ,A.BUNHO      
                                               ,A.IMAGE_PATH 
                                               ,A.IMAGE  
                                               ,A.SEQ    
                                          FROM SCAN001 A
                                         WHERE A.HOSP_CODE = :f_hosp_code
                                           AND A.FKOCS     = :f_fkocs
                                         ORDER BY A.FKOCS, A.SEQ";
            }

            this.grdDetail.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdDetail.SetBindVarValue("f_fkocs", this.grdMaster.GetItemString(grdMaster.CurrentRowNumber, "fkocs"));

        }

        private void layHangmog_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.layHangmog.SetBindVarValue("f_hangmog_code", this.fbxHangmogCode.GetDataValue());
        }

        private void layHangmog_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
        {

            if (!this.grdMaster.QueryLayout(false))
            {
                XMessageBox.Show("layHangmog_QueryEnd grdMaster Err! " + Service.ErrFullMsg);
                return;
            }
        }

        private void fbxHangmogCode_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            if (e.DataValue=="")
            {
                this.dbxHangmogName.SetDataValue("");
                if (!this.grdMaster.QueryLayout(false))
                {
                    XMessageBox.Show("layHangmog_QueryEnd grdMaster Err! " + Service.ErrFullMsg);
                    return;
                }
                return;
            }
            if (!this.layHangmog.QueryLayout())
            {
                XMessageBox.Show("fbxHangmogCode_Validated layHangmog Err! " + Service.ErrFullMsg);
                return;
            }
        }

        private void ScanStart()
        {
            MainFrame dig = new MainFrame();
            dig.Enabled = true;
            dig.Show();

            this.timer2.Start();
        }


        public static Image mScanImage;

        public static void CreateImageFile(Image image)
        {
            mScanImage = image;
            
        }


        #region SavePerformer
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private SCANUPLOADER parent = null;


            public XSavePerformer(SCANUPLOADER parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callID, RowDataItem item)
			{
				string userID = UserInfo.UserID;
				string iIUD = "";

                string strCmd = "";
                Hashtable inputList = new Hashtable();
                Hashtable outputList = new Hashtable();


				item.BindVarList.Add("f_user_id",UserInfo.UserID);
				
				
				switch(item.RowState)
				{
					case DataRowState.Added :
						iIUD = "I";
                        parent.grdDeatail_IUD = "Added";

                        if (parent.cboSystem.GetDataValue() == "CPL")
                        {
                            if (parent.layOrderList.RowCount > 0)
                            {
                                string strsql = "   SELECT SCAN001_SEQ.NEXTVAL FROM DUAL ";
                                for (int i = 0; i < parent.layOrderList.RowCount; i++)
                                {
                                    //grdDetail의 pk 만들어서 넣어주기
                                    //오더 번호 변경해가면서 바꿔주기 
                                    object retVal = Service.ExecuteScalar(strsql);

                                    if (retVal == null)
                                    {
                                        retVal = "1";
                                    }

                                    item.BindVarList.Add("f_pkscan001", retVal.ToString());
                                    item.BindVarList.Add("f_fkocs", parent.layOrderList.GetItemString(i,"pkocs"));
                                    item.BindVarList.Add("f_system", "CPL");
                                    item.BindVarList.Add("f_jundal_part", item.BindVarList["f_jundal_part"].VarValue);
                                    item.BindVarList.Add("f_bunho", item.BindVarList["f_bunho"].VarValue);
                                    item.BindVarList.Add("f_image_path", item.BindVarList["f_image_path"].VarValue);
                                    item.BindVarList.Add("f_image", item.BindVarList["f_image"].VarValue);
                                    item.BindVarList.Add("f_seq", retVal.ToString());
                                    item.BindVarList.Add("f_user_id", userID);


                                    strCmd = @"INSERT INTO SCAN001 (SYS_DATE, UPD_ID, UPD_DATE
                                                          ,PKSCAN001
                                                          ,FKOCS
                                                          ,SYSTEM
                                                          ,CR_TIME
                                                          ,JUNDAL_PART
                                                          ,BUNHO
                                                          ,IMAGE_PATH
                                                          ,IMAGE
                                                          ,SEQ
                                                          ,SYS_ID
                                                          ,HOSP_CODE
                                                        ) VALUES ( SYSDATE,:f_user_id, SYSDATE
                                                          ,:f_pkscan001
                                                          ,:f_fkocs
                                                          ,:f_system
                                                          ,TO_DATE(:f_cr_time, 'YYYY/MM/DD HH24/MI/SS')
                                                          ,:f_jundal_part
                                                          ,:f_bunho
                                                          ,:f_image_path
                                                          ,:f_image
                                                          ,:f_seq
                                                          ,:f_user_id
                                                          ,FN_ADM_LOAD_HOSP_CODE()) ";

                                    if (Service.ExecuteNonQuery(strCmd, item.BindVarList))
                                    {
                                        inputList.Clear();
                                        outputList.Clear();
                                        inputList.Add("I_IN_OUT_GUBUN", parent.grdMaster.GetItemString(parent.grdMaster.CurrentRowNumber, "in_out_gubun"));
                                        inputList.Add("I_FKOCS", parent.layOrderList.GetItemInt(i,"pkocs"));
                                        inputList.Add("I_RESULT_BUSEO", item.BindVarList["f_jundal_part"].VarValue);
                                        inputList.Add("I_RESULT_DATE", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

                                        if (Service.ExecuteProcedure("PR_OCS_UPDATE_RESULT", inputList, outputList))
                                        {

                                        }
                                        else
                                        {
                                            XMessageBox.Show(Service.ErrFullMsg);
                                        }
                                    }
                                }
                            }
                        }
						break;

                        
					case DataRowState.Modified :
                        iIUD = "U";
                        parent.grdDeatail_IUD = "Modified";

                        /*
                        if (parent.cboSystem.GetDataValue() == "CPL")
                        {
                            if (parent.layOrderList.RowCount > 0)
                            {
                                strCmd = @"UPDATE SCAN001 
                                              SET UPD_ID = :f_user_id
                                                , UPD_DATE = SYSDATE 
                                                , IMAGE_PATH = :f_image_path
                                                , IMAGE = :f_image
                                            WHERE FKOCS IN  (SELECT PKOCS1003 
                                                              FROM OCS1003 C,
                                                                   OCS0103 D
                                                             WHERE C.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                                                               AND C.ACTING_DATE = :f_acting_date
                                                               AND C.HANGMOG_CODE = D.HANGMOG_CODE
                                                               AND D.RESULT_GUBUN = 'S'
                                                               AND C.DOCTOR = :f_doctor
                                                               AND C.SPECIMEN_CODE = :f_specimen_code
                                                               AND C.JUNDAL_TABLE = :f_jundal_table
                                                               AND C.JUNDAL_PART = :f_jundal_part
                                                               AND C.BUNHO = :f_bunho)";


                                item.BindVarList.Add("f_image_path", item.BindVarList["f_image_path"].VarValue);
                                item.BindVarList.Add("f_image", item.BindVarList["f_image"].VarValue);
                                item.BindVarList.Add("f_user_id", userID);
                                item.BindVarList.Add("f_acting_date", parent.grdMaster.GetItemString(parent.grdMaster.CurrentRowNumber, "gumsa_date"));
                                item.BindVarList.Add("f_doctor", parent.grdMaster.GetItemString(parent.grdMaster.CurrentRowNumber, "doctor"));
                                item.BindVarList.Add("f_specimen_code", parent.grdMaster.GetItemString(parent.grdMaster.CurrentRowNumber, "specimen_code"));
                                item.BindVarList.Add("f_jundal_table", parent.cboSystem.GetDataValue());
                                item.BindVarList.Add("f_jundal_part", parent.grdMaster.GetItemString(parent.grdMaster.CurrentRowNumber, "jundal_part"));
                                item.BindVarList.Add("f_bunho", parent.grdMaster.GetItemString(parent.grdMaster.CurrentRowNumber, "bunho"));

                                if (Service.ExecuteNonQuery(strCmd, item.BindVarList))
                                {
                                    for (int i = 0; i < parent.layOrderList.RowCount; i++)
                                    {
                                        inputList.Clear();
                                        outputList.Clear();
                                        inputList.Add("I_IN_OUT_GUBUN", parent.grdMaster.GetItemString(parent.grdMaster.CurrentRowNumber, "in_out_gubun"));
                                        inputList.Add("I_FKOCS", parent.layOrderList.GetItemInt(i, "pkocs"));
                                        inputList.Add("I_RESULT_BUSEO", item.BindVarList["f_jundal_part"].VarValue);
                                        inputList.Add("I_RESULT_DATE", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                                        Service.ExecuteProcedure("PR_OCS_UPDATE_RESULT", inputList, outputList);
                                    }
                                }
                            }
                        }
                        */
						break;
					case DataRowState.Deleted :
						iIUD = "D";
                        parent.grdDeatail_IUD = "Deleted";
                        if (parent.cboSystem.GetDataValue() == "CPL")
                        {
                            if (parent.layOrderList.RowCount > 0)
                            {
                                strCmd = @" DELETE SCAN001 
                                             WHERE FKOCS IN  (SELECT PKOCS1003 
                                                                FROM OCS1003 C,
                                                                     OCS0103 D
                                                               WHERE C.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                                                                 AND C.ACTING_DATE = :f_acting_date
                                                                 AND C.HANGMOG_CODE = D.HANGMOG_CODE
                                                                 AND D.RESULT_GUBUN = 'S'
                                                                 AND C.DOCTOR = :f_doctor
                                                                 AND C.SPECIMEN_CODE = :f_specimen_code
                                                                 AND C.JUNDAL_TABLE = :f_jundal_table
                                                                 AND C.JUNDAL_PART = :f_jundal_part
                                                                 AND C.BUNHO = :f_bunho)
                                             OR FKOCS IN (SELECT PKOCS2003 
                                                                FROM OCS2003 C,
                                                                     OCS0103 D
                                                               WHERE C.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                                                                 AND C.ACTING_DATE = :f_acting_date
                                                                 AND C.HANGMOG_CODE = D.HANGMOG_CODE
                                                                 AND D.RESULT_GUBUN = 'S'
                                                                 AND C.DOCTOR = :f_doctor
                                                                 AND C.SPECIMEN_CODE = :f_specimen_code
                                                                 AND C.JUNDAL_TABLE = :f_jundal_table
                                                                 AND C.JUNDAL_PART = :f_jundal_part
                                                                 AND C.BUNHO = :f_bunho)
                                             AND IMAGE = :f_image";
                                item.BindVarList.Add("f_acting_date", parent.grdMaster.GetItemString(parent.grdMaster.CurrentRowNumber, "gumsa_date"));
                                item.BindVarList.Add("f_doctor", parent.grdMaster.GetItemString(parent.grdMaster.CurrentRowNumber, "doctor"));
                                item.BindVarList.Add("f_specimen_code", parent.grdMaster.GetItemString(parent.grdMaster.CurrentRowNumber, "specimen_code"));
                                item.BindVarList.Add("f_jundal_table", parent.cboSystem.GetDataValue());
                                item.BindVarList.Add("f_jundal_part", parent.grdMaster.GetItemString(parent.grdMaster.CurrentRowNumber, "jundal_part"));
                                item.BindVarList.Add("f_bunho", parent.grdMaster.GetItemString(parent.grdMaster.CurrentRowNumber, "bunho"));

                                if (!Service.ExecuteNonQuery(strCmd, item.BindVarList))
                                {
                                }
                            }
                        }
						break;
				}


                if (parent.cboSystem.GetDataValue() != "CPL")
                {

                    inputList.Clear();
                    outputList.Clear();

                    inputList.Add("I_IUD", iIUD);
                    inputList.Add("I_USER_ID", userID);

                    if (item.BindVarList["f_pkscan001"].VarValue == "")
                        inputList.Add("I_PKSCAN001", DBNull.Value);
                    else
                        inputList.Add("I_PKSCAN001", Convert.ToInt32(item.BindVarList["f_pkscan001"].VarValue));

                    if (item.BindVarList["f_fkocs"].VarValue == "")
                        inputList.Add("I_FKOCS", DBNull.Value);
                    else
                        inputList.Add("I_FKOCS", Convert.ToInt32(item.BindVarList["f_fkocs"].VarValue));

                    inputList.Add("I_SYSTEM", item.BindVarList["f_system"].VarValue);

                    if (item.BindVarList["f_cr_time"].VarValue == "")
                        inputList.Add("I_CR_TIME", DBNull.Value);
                    else
                        inputList.Add("I_CR_TIME", Convert.ToDateTime(item.BindVarList["f_cr_time"].VarValue));

                    inputList.Add("I_JUNDAL_PART", item.BindVarList["f_jundal_part"].VarValue);
                    inputList.Add("I_BUNHO", item.BindVarList["f_bunho"].VarValue);
                    inputList.Add("I_IMAGE_PATH", item.BindVarList["f_image_path"].VarValue);
                    inputList.Add("I_IMAGE", item.BindVarList["f_image"].VarValue);
                    if (item.BindVarList["f_seq"].VarValue == "")
                        inputList.Add("I_SEQ", DBNull.Value);
                    else
                        inputList.Add("I_SEQ", Convert.ToInt32(item.BindVarList["f_seq"].VarValue));

                    bool ret = Service.ExecuteProcedure("PR_PFE_PFESCAN001_WORKTP_S", inputList, outputList);
                    if (!ret)
                        MessageBox.Show("false Error=" + Service.ErrFullMsg);
                    else
                    {

                    }
                    return ret;
                }
                return true;     // 보류 
			}
        }
        #endregion

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.pictWiaItem.Image = mScanImage;
        }

        private void grdDetail_RowFocusChanging(object sender, RowFocusChangingEventArgs e)
        {
            if (grdDetail.GetRowState(e.CurrentRow) == DataRowState.Modified || grdDetail.GetRowState(e.CurrentRow) == DataRowState.Added)
            {
                string msg = (NetInfo.Language == LangMode.Ko ? "데이타가 변경되었습니다. 저장해주세요."
                                : "データが変更されました。保存しますか？");
                if (XMessageBox.Show(msg, "確認", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    xButtonList1.PerformClick(FunctionType.Update);
                }
                else
                {
                    grdDetail.DeleteRow(grdDetail.CurrentRowNumber);
                }
            }
        }

        private void paid_PatientSelected(object sender, EventArgs e)
        {
            //this.paid.BunHo
            this.mBunho = paid.BunHo;
            this.xButtonList1.PerformClick(FunctionType.Query);

        }
        private void grdMaster_CellSize(bool isCPL)
        {
            if (isCPL == true)
            {
                grdMaster.AutoSizeColumn(6, 0);
                grdMaster.AutoSizeColumn(7, 0);
            }
            else
            {
                grdMaster.AutoSizeColumn(6, 121);
                grdMaster.AutoSizeColumn(7, 67);
            }
        }

        private void cboSystem_SelectionChangeCommitted(object sender, EventArgs e)
        {

            if (cboSystem.GetDataValue() == "CPL")
            {
                grdMaster_CellSize(true);
            }
            else
            {
                grdMaster_CellSize(false);
            }


            string sql = "";
            string sql2 = "";
            if (this.cboSystem.GetDataValue() == "CPL")
            {
                sql = @"SELECT '%', ''
                          FROM DUAL
                         UNION ALL
                        SELECT A.CODE
                             , A.CODE_NAME 
                          FROM CPL0109 A 
                         WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                           AND A.CODE_TYPE  = '01'
                           AND EXISTS (SELECT 'X' 
                                         FROM CPL0101 C
                                            , OCS0103 B
                                        WHERE B.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                                          AND (B.JUNDAL_TABLE_OUT = 'CPL' OR B.JUNDAL_TABLE_INP = 'CPL')
                                          AND (B.JUNDAL_PART_OUT  = 'CPL' OR B.JUNDAL_PART_INP  = 'CPL')
                                          AND B.RESULT_GUBUN = 'S'
                                          AND C.HOSP_CODE    = B.HOSP_CODE
                                          AND C.HANGMOG_CODE = B.HANGMOG_CODE
                                          AND C.JUNDAL_GUBUN = A.CODE)
                                          ";
                this.cboJundal.UserSQL = sql;
                this.cboJundal.SetDictDDLB();
                this.cboJundal.SelectedIndex = 0;
                this.cboJundal.Refresh();
                sql2 = "SELECT GUMSA_NAME FROM CPL0101 WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() AND HANGMOG_CODE = :f_hangmog_code";
                this.layHangmog.QuerySQL = sql2;
            }
            else
            {
                sql = @"SELECT '%', ''
                          FROM DUAL
                         UNION ALL
                        SELECT DISTINCT 
                               JUNDAL_PART_OUT
                             , FN_BAS_LOAD_GWA_NAME(JUNDAL_PART_OUT,SYSDATE) 
                          FROM OCS0103 
                         WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                           AND JUNDAL_TABLE_OUT = '" + this.cboSystem.GetDataValue() + @"'
                           AND RESULT_GUBUN = 'S'";
                this.cboJundal.UserSQL = sql;
                this.cboJundal.SetDictDDLB();
                //this.cboJundal.SetEditValue("00");
                this.cboJundal.SelectedIndex = 0;
                this.cboJundal.Refresh();
                sql2 = "SELECT HANGMOG_NAME FROM OCS0103 WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() AND HANGMOG_CODE = :f_hangmog_code";
                this.layHangmog.QuerySQL = sql2;
            }

            this.fbxHangmogCode.SetDataValue("");
            this.dbxHangmogName.SetDataValue("");

            this.cboJundal.AcceptData();

            this.xButtonList1.PerformClick(FunctionType.Query);
        }

        private void cboJundal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.xButtonList1.PerformClick(FunctionType.Query);
        }

        private void paid_Validating(object sender, CancelEventArgs e)
        {
            if (paid.BunHo == "")
            {
                this.mBunho = paid.BunHo;
                this.xButtonList1.PerformClick(FunctionType.Query);
            }
        }

        private void layOrderList_QueryStarting(object sender, CancelEventArgs e)
        {
            layOrderList.SetBindVarValue("f_bunho", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "bunho"));
            layOrderList.SetBindVarValue("f_acting_date", grdMaster.GetItemDateTime(grdMaster.CurrentRowNumber, "gumsa_date").ToString("yyyy/MM/dd"));
            layOrderList.SetBindVarValue("f_doctor", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "doctor"));
            layOrderList.SetBindVarValue("f_specimen_code", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "specimen_code"));
            layOrderList.SetBindVarValue("f_jundal_table", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "system"));
            layOrderList.SetBindVarValue("f_jundal_part", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "jundal_part"));
        }
    }
}

