#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;

#endregion

namespace IHIS.NURI
{
	/// <summary>
	/// INP1003U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class INP1003U00 : IHIS.Framework.XScreen
    {
        #region 자동생성
        private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XDatePicker dtpInpReserDate;
		private IHIS.Framework.XTextBox txtRemark;
		private IHIS.Framework.XEditGrid grdInpReser;
        private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XFindWorker fwkGwa;
		private IHIS.Framework.XFindWorker fwkDoctor;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
		private IHIS.Framework.FindColumnInfo findColumnInfo2;
		private IHIS.Framework.FindColumnInfo findColumnInfo9;
		private IHIS.Framework.FindColumnInfo findColumnInfo10;
		private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.FindColumnInfo findColumnInfo13;
		private IHIS.Framework.FindColumnInfo findColumnInfo14;
		private IHIS.Framework.FindColumnInfo findColumnInfo15;
        private IHIS.Framework.XLabel xLabel11;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private System.Windows.Forms.PictureBox pictureBox1;
		private IHIS.Framework.XButton btnNewPatient;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
		private IHIS.Framework.XEditGridCell xEditGridCell22;
		private IHIS.Framework.XEditGridCell xEditGridCell23;
		private IHIS.Framework.XEditGridCell xEditGridCell24;
		private IHIS.Framework.XGridHeader xGridHeader1;
		private IHIS.Framework.XGridHeader xGridHeader2;
		private IHIS.Framework.XGridHeader xGridHeader3;
        private IHIS.Framework.XComboBox cboQueryGubun;
		private IHIS.Framework.XComboItem xComboItem2;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XDictComboBox cboHodong;
		private IHIS.Framework.XEditGridCell xEditGridCell25;
        private IHIS.Framework.XEditGridCell xEditGridCell26;
		private IHIS.Framework.XEditGridCell xEditGridCell28;
		private IHIS.Framework.XEditGridCell xEditGridCell29;
		private IHIS.Framework.XButton btnReservedMemo;
        private IHIS.Framework.XLabel xLabel4;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XLabel xLabel5;
		private IHIS.Framework.XTextBox txtIpwon_Mokjuk;
		private IHIS.Framework.XButton btnIpwon_Mokjuk;

        BindVarCollection bindVars = new BindVarCollection();
        private FindColumnInfo findColumnInfo3;
        private FindColumnInfo findColumnInfo4;
        private FindColumnInfo findColumnInfo5;
        private FindColumnInfo findColumnInfo6;
        private XTextBox txtSangComment;
        private XPanel xPanel4;
        private FindColumnInfo findColumnInfo7;
        #endregion
        private XButton btnNUR1001;
        private XPanel xPanel5;
        private XPanel xPanel6;
        private XPanel xPanel7;

        /// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public INP1003U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
        }

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INP1003U00));
            this.dtpInpReserDate = new IHIS.Framework.XDatePicker();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.txtSangComment = new IHIS.Framework.XTextBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnReservedMemo = new IHIS.Framework.XButton();
            this.txtRemark = new IHIS.Framework.XTextBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.btnNewPatient = new IHIS.Framework.XButton();
            this.btnNUR1001 = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.btnIpwon_Mokjuk = new IHIS.Framework.XButton();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.txtIpwon_Mokjuk = new IHIS.Framework.XTextBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.cboHodong = new IHIS.Framework.XDictComboBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.cboQueryGubun = new IHIS.Framework.XComboBox();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grdInpReser = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.fwkGwa = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.fwkDoctor = new IHIS.Framework.XFindWorker();
            this.findColumnInfo5 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo6 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo7 = new IHIS.Framework.FindColumnInfo();
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
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.xGridHeader3 = new IHIS.Framework.XGridHeader();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo9 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo10 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo13 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo14 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo15 = new IHIS.Framework.FindColumnInfo();
            this.xPanel7 = new IHIS.Framework.XPanel();
            this.xPanel1.SuspendLayout();
            this.xPanel5.SuspendLayout();
            this.xPanel3.SuspendLayout();
            this.xPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel4.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInpReser)).BeginInit();
            this.xPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "진료의사.gif");
            // 
            // dtpInpReserDate
            // 
            this.dtpInpReserDate.IsJapanYearType = true;
            this.dtpInpReserDate.Location = new System.Drawing.Point(130, 5);
            this.dtpInpReserDate.Name = "dtpInpReserDate";
            this.dtpInpReserDate.Size = new System.Drawing.Size(112, 20);
            this.dtpInpReserDate.TabIndex = 0;
            this.dtpInpReserDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpInpReserDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpInpReserDate_DataValidating);
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xPanel5);
            this.xPanel1.Controls.Add(this.xPanel3);
            this.xPanel1.Controls.Add(this.xPanel6);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel1.Location = new System.Drawing.Point(5, 445);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(1100, 139);
            this.xPanel1.TabIndex = 2;
            // 
            // xPanel5
            // 
            this.xPanel5.Controls.Add(this.txtSangComment);
            this.xPanel5.Controls.Add(this.xLabel4);
            this.xPanel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.xPanel5.Location = new System.Drawing.Point(0, 0);
            this.xPanel5.Name = "xPanel5";
            this.xPanel5.Size = new System.Drawing.Size(479, 101);
            this.xPanel5.TabIndex = 11;
            // 
            // txtSangComment
            // 
            this.txtSangComment.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtSangComment.Location = new System.Drawing.Point(86, 0);
            this.txtSangComment.MaxLength = 4000;
            this.txtSangComment.Multiline = true;
            this.txtSangComment.Name = "txtSangComment";
            this.txtSangComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSangComment.Size = new System.Drawing.Size(393, 101);
            this.txtSangComment.TabIndex = 9;
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel4.Location = new System.Drawing.Point(0, 0);
            this.xLabel4.Name = "xLabel4";
            this.xLabel4.Size = new System.Drawing.Size(100, 101);
            this.xLabel4.TabIndex = 8;
            this.xLabel4.Text = "傷病コメント";
            this.xLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.btnReservedMemo);
            this.xPanel3.Controls.Add(this.txtRemark);
            this.xPanel3.Controls.Add(this.xLabel2);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.xPanel3.Location = new System.Drawing.Point(489, 0);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(611, 101);
            this.xPanel3.TabIndex = 10;
            // 
            // btnReservedMemo
            // 
            this.btnReservedMemo.Image = ((System.Drawing.Image)(resources.GetObject("btnReservedMemo.Image")));
            this.btnReservedMemo.Location = new System.Drawing.Point(16, 66);
            this.btnReservedMemo.Name = "btnReservedMemo";
            this.btnReservedMemo.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnReservedMemo.Size = new System.Drawing.Size(66, 28);
            this.btnReservedMemo.TabIndex = 7;
            this.btnReservedMemo.Text = "定型文";
            this.btnReservedMemo.Click += new System.EventHandler(this.btnReservedMemo_Click);
            // 
            // txtRemark
            // 
            this.txtRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemark.Location = new System.Drawing.Point(100, 0);
            this.txtRemark.MaxLength = 4000;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemark.Size = new System.Drawing.Size(511, 101);
            this.txtRemark.TabIndex = 1;
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Location = new System.Drawing.Point(0, 0);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(100, 101);
            this.xLabel2.TabIndex = 0;
            this.xLabel2.Text = "備考";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel6
            // 
            this.xPanel6.Controls.Add(this.btnNewPatient);
            this.xPanel6.Controls.Add(this.btnNUR1001);
            this.xPanel6.Controls.Add(this.btnList);
            this.xPanel6.Controls.Add(this.xPanel4);
            this.xPanel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel6.Location = new System.Drawing.Point(0, 101);
            this.xPanel6.Name = "xPanel6";
            this.xPanel6.Size = new System.Drawing.Size(1100, 38);
            this.xPanel6.TabIndex = 12;
            // 
            // btnNewPatient
            // 
            this.btnNewPatient.Image = ((System.Drawing.Image)(resources.GetObject("btnNewPatient.Image")));
            this.btnNewPatient.Location = new System.Drawing.Point(95, 7);
            this.btnNewPatient.Name = "btnNewPatient";
            this.btnNewPatient.Size = new System.Drawing.Size(86, 28);
            this.btnNewPatient.TabIndex = 6;
            this.btnNewPatient.Text = "新患登録";
            this.btnNewPatient.Visible = false;
            this.btnNewPatient.Click += new System.EventHandler(this.btnNewPatient_Click);
            // 
            // btnNUR1001
            // 
            this.btnNUR1001.Image = ((System.Drawing.Image)(resources.GetObject("btnNUR1001.Image")));
            this.btnNUR1001.Location = new System.Drawing.Point(3, 7);
            this.btnNUR1001.Name = "btnNUR1001";
            this.btnNUR1001.Size = new System.Drawing.Size(86, 28);
            this.btnNUR1001.TabIndex = 8;
            this.btnNUR1001.Text = "情報入力";
            this.btnNUR1001.Click += new System.EventHandler(this.btnNUR1001_Click);
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.Location = new System.Drawing.Point(613, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.Size = new System.Drawing.Size(487, 38);
            this.btnList.TabIndex = 5;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.btnIpwon_Mokjuk);
            this.xPanel4.Controls.Add(this.xLabel5);
            this.xPanel4.Controls.Add(this.txtIpwon_Mokjuk);
            this.xPanel4.Location = new System.Drawing.Point(321, 14);
            this.xPanel4.Name = "xPanel4";
            this.xPanel4.Size = new System.Drawing.Size(221, 113);
            this.xPanel4.TabIndex = 7;
            this.xPanel4.Visible = false;
            // 
            // btnIpwon_Mokjuk
            // 
            this.btnIpwon_Mokjuk.Image = ((System.Drawing.Image)(resources.GetObject("btnIpwon_Mokjuk.Image")));
            this.btnIpwon_Mokjuk.Location = new System.Drawing.Point(60, 48);
            this.btnIpwon_Mokjuk.Name = "btnIpwon_Mokjuk";
            this.btnIpwon_Mokjuk.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnIpwon_Mokjuk.Size = new System.Drawing.Size(66, 28);
            this.btnIpwon_Mokjuk.TabIndex = 8;
            this.btnIpwon_Mokjuk.Text = "定型文";
            this.btnIpwon_Mokjuk.Click += new System.EventHandler(this.btnIpwon_Mokjuk_Click);
            // 
            // xLabel5
            // 
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel5.Location = new System.Drawing.Point(42, -18);
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.Size = new System.Drawing.Size(100, 100);
            this.xLabel5.TabIndex = 11;
            this.xLabel5.Text = "入院目的";
            this.xLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtIpwon_Mokjuk
            // 
            this.txtIpwon_Mokjuk.Location = new System.Drawing.Point(142, -18);
            this.txtIpwon_Mokjuk.MaxLength = 4000;
            this.txtIpwon_Mokjuk.Multiline = true;
            this.txtIpwon_Mokjuk.Name = "txtIpwon_Mokjuk";
            this.txtIpwon_Mokjuk.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtIpwon_Mokjuk.Size = new System.Drawing.Size(160, 100);
            this.txtIpwon_Mokjuk.TabIndex = 12;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.cboHodong);
            this.xPanel2.Controls.Add(this.xLabel3);
            this.xPanel2.Controls.Add(this.cboQueryGubun);
            this.xPanel2.Controls.Add(this.xLabel1);
            this.xPanel2.Controls.Add(this.xLabel11);
            this.xPanel2.Controls.Add(this.dtpInpReserDate);
            this.xPanel2.Controls.Add(this.pictureBox1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel2.Location = new System.Drawing.Point(5, 5);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(1100, 31);
            this.xPanel2.TabIndex = 0;
            // 
            // cboHodong
            // 
            this.cboHodong.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboHodong.Location = new System.Drawing.Point(336, 5);
            this.cboHodong.MaxDropDownItems = 20;
            this.cboHodong.Name = "cboHodong";
            this.cboHodong.Size = new System.Drawing.Size(121, 20);
            this.cboHodong.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboHodong.TabIndex = 40;
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel3.Location = new System.Drawing.Point(248, 5);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(88, 20);
            this.xLabel3.TabIndex = 39;
            this.xLabel3.Text = "病棟";
            this.xLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboQueryGubun
            // 
            this.cboQueryGubun.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem2});
            this.cboQueryGubun.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboQueryGubun.Location = new System.Drawing.Point(821, 5);
            this.cboQueryGubun.Name = "cboQueryGubun";
            this.cboQueryGubun.Size = new System.Drawing.Size(121, 20);
            this.cboQueryGubun.TabIndex = 38;
            this.cboQueryGubun.Visible = false;
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = "全体";
            this.xComboItem2.ValueItem = "%";
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Location = new System.Drawing.Point(733, 5);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(88, 20);
            this.xLabel1.TabIndex = 37;
            this.xLabel1.Text = "照会条件";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xLabel1.Visible = false;
            // 
            // xLabel11
            // 
            this.xLabel11.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel11.EdgeRounding = false;
            this.xLabel11.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel11.Location = new System.Drawing.Point(26, 5);
            this.xLabel11.Name = "xLabel11";
            this.xLabel11.Size = new System.Drawing.Size(104, 20);
            this.xLabel11.TabIndex = 33;
            this.xLabel11.Text = "入院予定日";
            this.xLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1100, 31);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // grdInpReser
            // 
            this.grdInpReser.AddedHeaderLine = 1;
            this.grdInpReser.ApplyPaintEventToAllColumn = true;
            this.grdInpReser.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
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
            this.xEditGridCell29});
            this.grdInpReser.ColPerLine = 20;
            this.grdInpReser.Cols = 21;
            this.grdInpReser.ControlBinding = true;
            this.grdInpReser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInpReser.FixedCols = 1;
            this.grdInpReser.FixedRows = 2;
            this.grdInpReser.HeaderHeights.Add(42);
            this.grdInpReser.HeaderHeights.Add(1);
            this.grdInpReser.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1,
            this.xGridHeader2,
            this.xGridHeader3});
            this.grdInpReser.Location = new System.Drawing.Point(0, 0);
            this.grdInpReser.Name = "grdInpReser";
            this.grdInpReser.QuerySQL = resources.GetString("grdInpReser.QuerySQL");
            this.grdInpReser.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdInpReser.RowHeaderVisible = true;
            this.grdInpReser.Rows = 3;
            this.grdInpReser.Size = new System.Drawing.Size(1100, 409);
            this.grdInpReser.TabIndex = 4;
            this.grdInpReser.GridCellFocusChanged += new IHIS.Framework.XGridCellFocusChangedEventHandler(this.grdInpReser_GridCellFocusChanged);
            this.grdInpReser.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdInpReser_QueryStarting);
            this.grdInpReser.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdInpReser_GridColumnProtectModify);
            this.grdInpReser.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdInpReser_GridColumnChanged);
            this.grdInpReser.GridReservedMemoButtonClick += new IHIS.Framework.GridReservedMemoButtonClickEventHandler(this.grdInpReser_GridReservedMemoButtonClick);
            this.grdInpReser.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdInpReser_GridFindClick);
            this.grdInpReser.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdInpReser_RowFocusChanged);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "reser_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.CellWidth = 90;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell1.HeaderText = "入院予定日";
            this.xEditGridCell1.IsJapanYearType = true;
            this.xEditGridCell1.RowSpan = 2;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 9;
            this.xEditGridCell2.CellName = "bunho";
            this.xEditGridCell2.CellWidth = 71;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell2.HeaderText = "患者番号";
            this.xEditGridCell2.IsNotNull = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.RowSpan = 2;
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 30;
            this.xEditGridCell3.CellName = "suname";
            this.xEditGridCell3.CellWidth = 100;
            this.xEditGridCell3.Col = 3;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell3.HeaderText = "患者名";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdCol = false;
            this.xEditGridCell3.RowSpan = 2;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AutoTabDataSelected = true;
            this.xEditGridCell4.CellLen = 2;
            this.xEditGridCell4.CellName = "gwa";
            this.xEditGridCell4.CellWidth = 27;
            this.xEditGridCell4.Col = 4;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell4.FindWorker = this.fwkGwa;
            this.xEditGridCell4.HeaderText = "診療科";
            this.xEditGridCell4.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell4.Row = 1;
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkGwa
            // 
            this.fwkGwa.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkGwa.FormText = "診療科照会";
            this.fwkGwa.InputSQL = resources.GetString("fwkGwa.InputSQL");
            this.fwkGwa.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkGwa.ServerFilter = true;
            this.fwkGwa.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkGwa_QueryStarting);
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo3.ColName = "buseo_code";
            this.findColumnInfo3.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo3.HeaderText = "診療科";
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "buseo_name";
            this.findColumnInfo4.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo4.HeaderText = "診療科名";
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 40;
            this.xEditGridCell5.CellName = "gwa_name";
            this.xEditGridCell5.CellWidth = 83;
            this.xEditGridCell5.Col = 5;
            this.xEditGridCell5.HeaderText = "診療科名";
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdCol = false;
            this.xEditGridCell5.Row = 1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 4;
            this.xEditGridCell6.CellName = "ho_code";
            this.xEditGridCell6.CellWidth = 40;
            this.xEditGridCell6.Col = 11;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell6.HeaderText = "病室";
            this.xEditGridCell6.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell6.RowSpan = 2;
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AutoTabDataSelected = true;
            this.xEditGridCell7.CellLen = 20;
            this.xEditGridCell7.CellName = "doctor";
            this.xEditGridCell7.CellWidth = 60;
            this.xEditGridCell7.Col = 6;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell7.FindWorker = this.fwkDoctor;
            this.xEditGridCell7.HeaderText = "医師";
            this.xEditGridCell7.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell7.Row = 1;
            this.xEditGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkDoctor
            // 
            this.fwkDoctor.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo5,
            this.findColumnInfo6,
            this.findColumnInfo7});
            this.fwkDoctor.FormText = "医師照会";
            this.fwkDoctor.InputSQL = resources.GetString("fwkDoctor.InputSQL");
            this.fwkDoctor.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkDoctor.ServerFilter = true;
            // 
            // findColumnInfo5
            // 
            this.findColumnInfo5.ColName = "doctor";
            this.findColumnInfo5.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo5.HeaderText = "医師コード";
            // 
            // findColumnInfo6
            // 
            this.findColumnInfo6.ColName = "doctor_name";
            this.findColumnInfo6.ColWidth = 143;
            this.findColumnInfo6.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo6.HeaderText = "医師名";
            // 
            // findColumnInfo7
            // 
            this.findColumnInfo7.ColName = "gwa_name";
            this.findColumnInfo7.ColWidth = 118;
            this.findColumnInfo7.HeaderText = "診療科";
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 80;
            this.xEditGridCell8.CellName = "doctor_name";
            this.xEditGridCell8.CellWidth = 90;
            this.xEditGridCell8.Col = 7;
            this.xEditGridCell8.HeaderText = "医師名";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdCol = false;
            this.xEditGridCell8.Row = 1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "ipwon_rtn2";
            this.xEditGridCell9.CellWidth = 95;
            this.xEditGridCell9.Col = 15;
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell9.HeaderText = "入院経路";
            this.xEditGridCell9.RowSpan = 2;
            this.xEditGridCell9.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell9.UserSQL = "SELECT CODE, CODE_NAME\r\nFROM BAS0102\r\nWHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() \r" +
                "\n  AND CODE_TYPE = \'IPWON_RTN2\'";
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "ipwon_rtn_name";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.HeaderText = "ipwon_rtn_name";
            this.xEditGridCell10.IsUpdCol = false;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellLen = 15;
            this.xEditGridCell11.CellName = "tel";
            this.xEditGridCell11.CellWidth = 104;
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell11.HeaderText = "電話番号";
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            this.xEditGridCell11.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellLen = 15;
            this.xEditGridCell12.CellName = "tel1";
            this.xEditGridCell12.CellWidth = 100;
            this.xEditGridCell12.Col = 17;
            this.xEditGridCell12.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell12.HeaderText = "連絡先";
            this.xEditGridCell12.RowSpan = 2;
            this.xEditGridCell12.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "reser_end_type";
            this.xEditGridCell13.CellWidth = 110;
            this.xEditGridCell13.Col = 14;
            this.xEditGridCell13.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell13.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell13.HeaderText = "状態";
            this.xEditGridCell13.InitValue = "0";
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.RowSpan = 2;
            this.xEditGridCell13.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell13.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell13.UserSQL = "SELECT CODE, CODE_NAME\r\n  FROM BAS0102\r\n  WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE" +
                "()\r\n   AND CODE_TYPE = \'RESER_END_TYPE\'";
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellLen = 1;
            this.xEditGridCell14.CellName = "susul_reser_yn";
            this.xEditGridCell14.CellWidth = 52;
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell14.HeaderText = "手術";
            this.xEditGridCell14.InitValue = "N";
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AppendReservedMemoText = true;
            this.xEditGridCell15.BindControl = this.txtRemark;
            this.xEditGridCell15.CellLen = 1000;
            this.xEditGridCell15.CellName = "remark";
            this.xEditGridCell15.CellWidth = 50;
            this.xEditGridCell15.Col = 19;
            this.xEditGridCell15.DisplayMemoText = true;
            this.xEditGridCell15.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell15.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell15.HeaderText = "備考";
            this.xEditGridCell15.ReservedMemoClassName = "IHIS.NURI.ReserMemoControl";
            this.xEditGridCell15.ReservedMemoFileName = "C:\\IHIS\\NURI\\NURI.INP1003U00.dll";
            this.xEditGridCell15.RowSpan = 2;
            this.xEditGridCell15.ShowReservedMemoButton = true;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "pkinp1003";
            this.xEditGridCell16.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.HeaderText = "PK";
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "junpyo_date";
            this.xEditGridCell17.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.HeaderText = "伝票日付";
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellLen = 2;
            this.xEditGridCell18.CellName = "ho_dong";
            this.xEditGridCell18.CellWidth = 60;
            this.xEditGridCell18.Col = 10;
            this.xEditGridCell18.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell18.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell18.HeaderText = "病棟";
            this.xEditGridCell18.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell18.RowSpan = 2;
            this.xEditGridCell18.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellLen = 2;
            this.xEditGridCell19.CellName = "bed_no";
            this.xEditGridCell19.CellWidth = 35;
            this.xEditGridCell19.Col = 12;
            this.xEditGridCell19.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell19.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell19.HeaderText = "病床";
            this.xEditGridCell19.RowSpan = 2;
            this.xEditGridCell19.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "ipwon_mokjuk";
            this.xEditGridCell20.CellWidth = 110;
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell20.HeaderText = "入院目的";
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.MaxDropDownItems = 20;
            this.xEditGridCell20.Row = -1;
            this.xEditGridCell20.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell20.UserSQL = resources.GetString("xEditGridCell20.UserSQL");
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "reser_fkinp1001";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.HeaderText = "reser_fkinp1001";
            this.xEditGridCell21.IsUpdCol = false;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "ipwonsi_order_yn";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.HeaderText = "ipwonsi_order_yn";
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.AutoTabDataSelected = true;
            this.xEditGridCell23.CellLen = 20;
            this.xEditGridCell23.CellName = "jisi_doctor";
            this.xEditGridCell23.CellWidth = 60;
            this.xEditGridCell23.Col = 8;
            this.xEditGridCell23.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell23.FindWorker = this.fwkDoctor;
            this.xEditGridCell23.HeaderText = "jisi_doctor";
            this.xEditGridCell23.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell23.Row = 1;
            this.xEditGridCell23.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellLen = 90;
            this.xEditGridCell24.CellName = "jisi_doctor_name";
            this.xEditGridCell24.CellWidth = 90;
            this.xEditGridCell24.Col = 9;
            this.xEditGridCell24.HeaderText = "jisi_doctor_name";
            this.xEditGridCell24.IsReadOnly = true;
            this.xEditGridCell24.IsUpdCol = false;
            this.xEditGridCell24.Row = 1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.BindControl = this.txtSangComment;
            this.xEditGridCell25.CellLen = 1000;
            this.xEditGridCell25.CellName = "sang_bigo";
            this.xEditGridCell25.CellWidth = 50;
            this.xEditGridCell25.Col = 13;
            this.xEditGridCell25.DisplayMemoText = true;
            this.xEditGridCell25.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell25.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell25.HeaderText = "傷　病\r\nコメント";
            this.xEditGridCell25.ReservedMemoClassName = "IHIS.NURI.ReserMemoForm";
            this.xEditGridCell25.ReservedMemoFileName = "C:\\IHIS\\NURI\\NURI.INP1003U00.dll";
            this.xEditGridCell25.RowSpan = 2;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "sogye_yn";
            this.xEditGridCell26.CellWidth = 35;
            this.xEditGridCell26.Col = 16;
            this.xEditGridCell26.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell26.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell26.HeaderText = "紹介\r\n有無";
            this.xEditGridCell26.RowSpan = 2;
            this.xEditGridCell26.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell26.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell26.UserSQL = "SELECT CODE, CODE_NAME\r\n  FROM BAS0102\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE(" +
                ") \r\n   AND CODE_TYPE =\'SOGYE_YN\'\r\n ORDER BY CODE";
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "hope_room";
            this.xEditGridCell28.CellWidth = 60;
            this.xEditGridCell28.Col = 18;
            this.xEditGridCell28.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell28.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell28.HeaderText = "部屋の\r\n希望";
            this.xEditGridCell28.RowSpan = 2;
            this.xEditGridCell28.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell28.UserSQL = "SELECT \' \', FN_ADM_MSG(3395)\r\nFROM DUAL\r\nUNION ALL\r\nSELECT CODE, CODE_NAME\r\nFROM " +
                "BAS0102 \r\nWHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()\r\n  AND CODE_TYPE = \'HOPE_ROO" +
                "M\'\r\nORDER BY 1";
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "user_id";
            this.xEditGridCell29.CellWidth = 86;
            this.xEditGridCell29.Col = 20;
            this.xEditGridCell29.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell29.HeaderText = "最終修正者";
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.IsUpdCol = false;
            this.xEditGridCell29.RowSpan = 2;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 8;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridHeader1.HeaderText = "指示医師";
            this.xGridHeader1.HeaderWidth = 60;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 4;
            this.xGridHeader2.ColSpan = 2;
            this.xGridHeader2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridHeader2.HeaderText = "診療科";
            this.xGridHeader2.HeaderWidth = 27;
            // 
            // xGridHeader3
            // 
            this.xGridHeader3.Col = 6;
            this.xGridHeader3.ColSpan = 2;
            this.xGridHeader3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridHeader3.HeaderText = "主治医";
            this.xGridHeader3.HeaderWidth = 60;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo1.ColName = "buseo_code";
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo1.HeaderText = "診療科";
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "buseo_name";
            this.findColumnInfo2.ColWidth = 202;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo2.HeaderText = "診療科名";
            // 
            // findColumnInfo9
            // 
            this.findColumnInfo9.ColName = "doctor";
            this.findColumnInfo9.ColWidth = 91;
            this.findColumnInfo9.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo9.HeaderText = "医師";
            // 
            // findColumnInfo10
            // 
            this.findColumnInfo10.ColName = "doctor_name";
            this.findColumnInfo10.ColWidth = 157;
            this.findColumnInfo10.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo10.HeaderText = "医師名";
            // 
            // findColumnInfo13
            // 
            this.findColumnInfo13.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo13.ColName = "bunho";
            this.findColumnInfo13.ColWidth = 111;
            this.findColumnInfo13.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo13.HeaderText = "患者番号";
            // 
            // findColumnInfo14
            // 
            this.findColumnInfo14.ColName = "suname";
            this.findColumnInfo14.ColWidth = 192;
            this.findColumnInfo14.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo14.HeaderText = "患者名";
            // 
            // findColumnInfo15
            // 
            this.findColumnInfo15.ColName = "birthday";
            this.findColumnInfo15.ColWidth = 116;
            this.findColumnInfo15.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo15.HeaderText = "生年月日";
            // 
            // xPanel7
            // 
            this.xPanel7.Controls.Add(this.grdInpReser);
            this.xPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel7.Location = new System.Drawing.Point(5, 36);
            this.xPanel7.Name = "xPanel7";
            this.xPanel7.Size = new System.Drawing.Size(1100, 409);
            this.xPanel7.TabIndex = 5;
            // 
            // INP1003U00
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.xPanel7);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "INP1003U00";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1110, 589);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.INP1003U00_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel5.ResumeLayout(false);
            this.xPanel5.PerformLayout();
            this.xPanel3.ResumeLayout(false);
            this.xPanel3.PerformLayout();
            this.xPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel4.ResumeLayout(false);
            this.xPanel4.PerformLayout();
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInpReser)).EndInit();
            this.xPanel7.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region Screen 변수 

		private string mBunho = "";

		private string mMsg = "";
		private string mCaption = "";

		/*****************************************
		 *    입원목적 하드코딩
		 * ***************************************/
		private string ORDER_IN_IPWON = "17";       /* 입원시 오더 */
		private XColor mDoctorReserColor = new XColor(Color.LightGreen);

		// 비고 정형문구분코드
		private string RESER_MEMO_CATEGORY = "RESER_M1";   /* 입원예약정형문 */
		// 입원목적정형문
		private string IPWON_MOKJUK_MEMO_CATEGORY = "RESER_M2"; /*입원목적정형문*/

        private string mHospCode = "";

		#endregion

		#region DateTimePicker

		private void dtpInpReserDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			if (e.DataValue == "")
			{
				return ;
			}
			else
			{
				this.Load_INP1003();
				this.MakeHodongCombo(e.DataValue); // 재조회는 콤보박스에서 한다.
			}
		}

		#endregion

		#region DataLoad

        private void Load_INP1003()
        {
            this.grdInpReser.QueryLayout(true);
            this.GridHeaderImageChange();
        }

		#endregion

		#region Button List Click 

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:

					e.IsBaseCall = false;

					this.Load_INP1003();

					break;

				case FunctionType.Insert:

					e.IsBaseCall = false;

					// 예약 날자가 과거 인지 여부 체크 => 새로운 행 입력 하고 예약일은 오늘로 셋팅
//					if (TypeCheck.IsDateTime(this.dtpInpReserDate.GetDataValue()))
//					{
//						if (DateTime.Parse(this.dtpInpReserDate.GetDataValue()) < DateTime.Today)
//						{
//							mMsg = (NetInfo.Language == LangMode.Ko ? "과거 날자에는 입력할 수 없습니다." :
//								"過去日付には入力できません。");
//
//							e.IsBaseCall = false;
//							e.IsSuccess = false;
//
//							this.SetMsg(mMsg, MsgType.Error);
//							break;
//						}
//					}
					if (!TypeCheck.IsDateTime(this.dtpInpReserDate.GetDataValue()))
					{
						mMsg = (NetInfo.Language == LangMode.Ko ? "날자 형식이 틀립니다." :
							"入院予定日が有効ではありません。");

						e.IsBaseCall = false;
						e.IsSuccess = false;

						this.SetMsg(mMsg, MsgType.Error);
						break;
					}

					// 키값이 셋팅 되지 않은 행이 있을경우 새로운 행 삽입 불가
					for (int i=0; i<this.grdInpReser.RowCount; i++)
					{
						// 환자 번호 NULL 체크
						if (this.grdInpReser.GetRowState(i) != DataRowState.Unchanged)
						{
							if (this.grdInpReser.GetItemString(i, "bunho") == "")
							{
								this.grdInpReser.SetFocusToItem(i, "bunho", true);

								mMsg = (NetInfo.Language == LangMode.Ko ? "환자번호를 입력하세요." :
									"患者番号を入力してください。");
								this.SetMsg(mMsg, MsgType.Error);
								e.IsBaseCall = false;
								e.IsSuccess = false;
								return;
							}
						}
					}

					int rowNum = this.grdInpReser.InsertRow(-1);

					// 날자는 오늘로 자동셋팅
                    this.grdInpReser.SetItemValue(rowNum, "reser_date", this.dtpInpReserDate.GetDataValue());
					// 입원경로는 외래로 기본셋팅
                    this.grdInpReser.SetItemValue(rowNum, "ipwon_rtn2", "1");

                    this.grdInpReser.SetItemValue(rowNum, "sogye_yn", "0");
                    this.grdInpReser.SetItemValue(rowNum, "hope_room", " ");

					this.SetMsg("");

					break;

				case FunctionType.Update:

					e.IsBaseCall = false;

					this.AcceptData();

					// 각 조건 체크
					for (int i=0; i<this.grdInpReser.RowCount; i++)
					{
						if (this.grdInpReser.GetRowState(i) == DataRowState.Added ||
							this.grdInpReser.GetRowState(i) == DataRowState.Modified )
						{
							if (!this.IsValidDate(this.grdInpReser.GetItemString(i, "reser_date")))
							{
								this.mMsg = (NetInfo.Language == LangMode.Ko ? "예약일자가 유효하지 않습니다." : "予約日付が有効ではありません。");

								this.SetMsg(this.mMsg, MsgType.Error);

								this.grdInpReser.SetFocusToItem(i, "reser_date", true);
								e.IsSuccess = false;
                                return ;
							}

							// 환자번호 NULL체크
							if (this.grdInpReser.GetItemString(i, "bunho") == "")
							{
								mMsg = (NetInfo.Language == LangMode.Ko ? "환자번호가 없습니다. 확인해 주세요."
									                                   : "患者番号がありません。ご確認ください。");

								this.SetMsg(mMsg, MsgType.Error);

								// 포커스 이동
								this.grdInpReser.SetFocusToItem(i, "bunho", true);

								e.IsSuccess = false;
                                return;
							}

							// 병동 병실 베드 NULL 체크
                            if (this.grdInpReser.GetItemString(i, "ho_dong") == "" )
                            {

                                mMsg = (NetInfo.Language == LangMode.Ko ? "병동정보가 없습니다. 확인해 주세요"
                                    : "病棟情報がありません。ご確認ください。");
                                this.SetMsg(mMsg, MsgType.Error);

                                // 포커스 이동
                                this.grdInpReser.SetFocusToItem(i, "ho_dong", true);

                                e.IsSuccess = false;
                                return;
                            }
                            /*
							if (this.grdInpReser.GetItemString(i, "ho_dong") != "" ||
								this.grdInpReser.GetItemString(i, "ho_code") != "" ||
								this.grdInpReser.GetItemString(i, "bed_no") != "" )
							{
								if (this.grdInpReser.GetItemString(i, "ho_dong") == "" ||
									this.grdInpReser.GetItemString(i, "ho_code") == "" ||
									this.grdInpReser.GetItemString(i, "bed_no") == ""   )
								{

									mMsg = (NetInfo.Language == LangMode.Ko ? "병동, 병실, BED정보가 없습니다. 확인해 주세요" 
										: "病棟、病室、病床情報がありません。ご確認ください。");
									this.SetMsg(mMsg, MsgType.Error);

									// 포커스 이동
									this.grdInpReser.SetFocusToItem(i, "ho_dong", true);

									e.IsSuccess = false;
                                    return;
								}
							}
                             * */

							// 진료과체크
							if (this.grdInpReser.GetItemString(i, "gwa") == "")
							{
								this.mMsg = (NetInfo.Language == LangMode.Ko ? "진료과 정보가 없습니다. 확인해 주세요."
									                                         : "診療科情報がありません。ご確認ください。");
								this.SetMsg(mMsg, MsgType.Error);

								this.grdInpReser.SetFocusToItem(i, "gwa", true);

                                e.IsSuccess = false;
                                return;
							}

							// 의사 체크
							if (this.grdInpReser.GetItemString(i, "doctor") == "")
							{
								this.mMsg = (NetInfo.Language == LangMode.Ko ? "주치의 정보가 없습니다. 확인해 주세요."
									                                         : "主治医情報がありません。ご確認ください。");
								this.SetMsg(mMsg, MsgType.Error);

								this.grdInpReser.SetFocusToItem(i, "doctor", true);

                                e.IsSuccess = false;
                                return;
							}
						}
					}

                    if (this.grdInpReser.SaveLayout())
                    {
                        // 저장 성공시 재조회
                        this.mMsg = NetInfo.Language == LangMode.Ko ? "저장이 완료되었습니다." : "保存が完了しました。";
                        this.mCaption = NetInfo.Language == LangMode.Ko ? "저장완료" : "保存完了";
                        XMessageBox.Show(this.mMsg, this.mCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Load_INP1003();
                    }
                    else//보존이 실패했을 경우. 처리.재 조회.
                    {
                        this.mMsg = NetInfo.Language == LangMode.Ko ? "저장에 실패 하였습니다." : "保存に失敗しました。";
                        this.mMsg += "\r\n" + Service.ErrFullMsg;
                        this.mCaption = NetInfo.Language == LangMode.Ko ? "저장실패" : "保存失敗";

                        XMessageBox.Show(this.mMsg, this.mCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        e.IsSuccess = false;
                        return;
                        //this.Load_INP1003();                      
                    }

					break;

				case FunctionType.Delete:

					// 새로 입력된 행은 삭제 가능
					if (this.grdInpReser.GetRowState(grdInpReser.CurrentRowNumber) == DataRowState.Added)
					{
						e.IsBaseCall = true;
						e.IsSuccess = true;

						return;
					}

					// 예약중 일경우만 취소 가능
					if (this.grdInpReser.GetItemString(grdInpReser.CurrentRowNumber, "reser_end_type") == "0")
					{
						// 입원전 오더인경우 취소 불가능
                        if (this.grdInpReser.GetItemString(grdInpReser.CurrentRowNumber, "ipwonsi_order_yn") == "Y")
						{
							mMsg = (NetInfo.Language == LangMode.Ko ? "의사가 입력한 입원예약건은 취소가 불가능 합니다."
								                                    : "医師が入力した入院予約情報は取消が出来ません。");

							XMessageBox.Show(mMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);

							e.IsBaseCall = false;
							e.IsSuccess = false;

							return;
						}

						this.grdInpReser.SetItemValue(grdInpReser.CurrentRowNumber, "reser_end_type", "5"); /*취소*/

						e.IsBaseCall = false;
						e.IsSuccess = true;
					}
					else
					{
						mMsg = (NetInfo.Language == LangMode.Ko ? "예약중인 경우만 취소(행삭제)가 가능합니다." 
							                                   : "予約中の場合のみキャンセル(行削除)が可能です。" );

						this.SetMsg(mMsg, MsgType.Error);

						e.IsBaseCall = false;
						e.IsSuccess = false;
					}

					break;			
			}
		}

		private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Insert:

					break;
				case FunctionType.Update:
					
					break;
				case FunctionType.Reset:
					this.dtpInpReserDate.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
					this.dtpInpReserDate.AcceptData();
					break;
			}
		}

		#endregion

		#region Function

		#region 환자정보 Setting 

        //private void SettingPatientInfo()
        //{
        //    this.grdInpReser.SetItemValue(grdInpReser.CurrentRowNumber, "bunho", this.mBunho);
        //    this.grdInpReser.SetItemValue(grdInpReser.CurrentRowNumber, "suname", this.dsvBunhoValidation.GetOutValue("suname"));
        //    this.grdInpReser.SetItemValue(grdInpReser.CurrentRowNumber, "tel", this.dsvBunhoValidation.GetOutValue("tel"));
        //    this.grdInpReser.SetItemValue(grdInpReser.CurrentRowNumber, "tel1", this.dsvBunhoValidation.GetOutValue("tel"));
        //}

		#endregion

		#region 그리드 환자 번호 변경시 리셋

		private void ResetGridExceptBunho(int rowNumber)
		{
			this.grdInpReser.SetItemValue(rowNumber, "gwa", "");
			this.grdInpReser.SetItemValue(rowNumber, "gwa_name", "");
			this.grdInpReser.SetItemValue(rowNumber, "doctor", "");
			this.grdInpReser.SetItemValue(rowNumber, "doctor_name", "");
			this.grdInpReser.SetItemValue(rowNumber, "ho_dong", "");
			this.grdInpReser.SetItemValue(rowNumber, "ho_code", "");
			this.grdInpReser.SetItemValue(rowNumber, "bed_no", "");

		}

		#endregion

		#region 날자 체크 

		private bool IsValidDate (string currentDay)
		{
			DateTime today ;
			DateTime currentDate;

			string tempDay = "";

            tempDay = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");

			if (!TypeCheck.IsDateTime(tempDay))
			{
				return false;
			}

			today = DateTime.Parse(tempDay);

			if (!TypeCheck.IsDateTime(currentDay))
			{
				return false;
			}

			currentDate = DateTime.Parse(currentDay);

			if (today > currentDate)
			{
				return false;
			}

			return true;
		}

		#endregion

		#region GridHeaderImageChange

		private void GridHeaderImageChange()
		{
			for (int i=0; i<this.grdInpReser.RowCount; i++)
			{
				if (this.grdInpReser.GetItemString(i, "reser_fkinp1001") != "")
				{
					this.grdInpReser[i + this.grdInpReser.HeaderHeights.Count, 0].Image = ImageList.Images[0];
				}
			}
		}

		#endregion

		#region 예약 베드 중복 경고
        //호출안됨. 주석처리 김보현

        //private bool CheckDupHodong ()
        //{
        //    this.mMsg = "";
        //    this.mCaption = "";
        //    BindVarCollection bindVarChk = new BindVarCollection();
        //    foreach (DataRow dr in this.grdInpReser.LayoutTable.Rows)
        //    {
        //        if (dr.RowState == DataRowState.Added || 
        //            dr.RowState == DataRowState.Modified )
        //        {
        //            this.layReserCheck.SetBindVarValue("f_hosp_code", this.mHospCode);
        //            this.layReserCheck.SetBindVarValue("f_reser_date", dr["reser_date"].ToString());
        //            if(this.layReserCheck.QueryLayout(false))
        //            {
                   
        //            }
        //            if (this.layReserCheck.RowCount > 0)
        //            {
        //                foreach (DataRow ldr in this.layReserCheck.LayoutTable.Rows)
        //                {
        //                    if (this.mMsg == "")
        //                    {
        //                        this.mMsg = (NetInfo.Language == LangMode.Ko ? "현재 예약이 완료된 베드가 존재합니다." : "現在予約が完了した病床が存在します。") + "\n";
        //                        this.mMsg += "===================================================================\n";
        //                        this.mMsg += ldr["reser_date_jp"].ToString() + "  " + ldr["suname"].ToString() + "  " +
        //                                     ldr["gwa_name"].ToString() + "  " + ldr["doctor_name"].ToString() + "  " +
        //                                     dr["ho_dong"].ToString() + "/" + dr["ho_code"].ToString() + "/" + dr["bed_no"].ToString() + "\n";

        //                    }
        //                    else
        //                    {
        //                        this.mMsg += ldr["reser_date_jp"].ToString() + "  " + ldr["suname"].ToString() + "  " +
        //                            ldr["gwa_name"].ToString() + "  " + ldr["doctor_name"].ToString() + "  " +
        //                            dr["ho_dong"].ToString() + "/" + dr["ho_code"].ToString() + "/" + dr["bed_no"].ToString() + "\n";
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    if (this.mMsg != "")
        //    {
        //        this.mMsg += "===================================================================\n";
        //        this.mMsg += (NetInfo.Language == LangMode.Ko ? "이대로 저장 하시겠습니까?" : "このまま保存しますか？");

        //        this.mCaption = (NetInfo.Language == LangMode.Ko ? "중복베드" : "重複病床");

        //        DialogResult result = XMessageBox.Show(this.mMsg, this.mCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

        //        if (result == DialogResult.Yes)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}

		#endregion

		#region 병동콤보 구성

		private void MakeHodongCombo (string aGijunDate)
		{
			string aCurrHodong = this.cboHodong.GetDataValue();

			this.cboHodong.SelectedValueChanged -= new EventHandler(cboHodong_SelectedValueChanged);

            this.cboHodong.UserSQL = @"SELECT '%', FN_ADM_MSG(221)
                                        FROM DUAL 
                                       UNION ALL 
                                      SELECT A.GWA, A.GWA_NAME
                                        FROM BAS0260 A
                                       WHERE A.HOSP_CODE  = :f_hosp_code
                                         AND A.BUSEO_GUBUN = '2'
                                         AND TO_DATE(:f_reser_date,'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE
                                         AND A.GWA > ' ' 
                                         ORDER BY 1";

            this.cboHodong.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.cboHodong.SetBindVarValue("f_reser_date", aGijunDate);
			this.cboHodong.SetDictDDLB();
            //this.layCombo.Reset();
            string strSql = @"SELECT A.GWA        gwa
                                   , A.GWA_NAME   gwa_name
                                FROM BAS0260 A
                               WHERE A.HOSP_CODE  = :f_hosp_code
                                         AND A.BUSEO_GUBUN = '2'
                                         AND TO_DATE(:f_reser_date,'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE
                                         AND A.GWA > ' ' 
                                         ORDER BY 1";
            bindVars.Clear();
            bindVars.Add("f_hosp_code", this.mHospCode);
            bindVars.Add("f_reser_date", aGijunDate);
            DataTable dtHoCombo = Service.ExecuteDataTable(strSql, bindVars);

            this.grdInpReser.SetComboItems("ho_dong", dtHoCombo, "gwa_name", "gwa");

			if (this.cboHodong.ComboItems.Contains(aCurrHodong))
			{
				this.cboHodong.SetDataValue(aCurrHodong);
			}
			else
			{
				this.cboHodong.SelectedIndex = 0;
			}

			this.cboHodong.SelectedValueChanged += new EventHandler(cboHodong_SelectedValueChanged);

			this.cboHodong_SelectedValueChanged(this.cboHodong, new System.EventArgs());
		}
		#endregion

		#endregion

		#region XEditGrid

		#region 그리드 컬럼 벨리데이션

		private void grdInpReser_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			//string flag = "";
			//string name = "";
            string strSql = string.Empty;
            BindVarCollection bindVar = new BindVarCollection();
            this.SetMsg("");

			// 벨리데이션 수행후 포커스 컨트롤을 위한 PostCall
			PostCallHelper.PostCall(new PostMethodStr(PostInpReserGridColumnChanged), e.ColName);

			switch(e.ColName)
			{
				case "bunho":

					#region 환자번호
                                     

					if (e.ChangeValue.ToString() == "")
					{
						this.grdInpReser.SetItemValue(e.RowNumber, "suname", "");
						this.ResetGridExceptBunho(e.RowNumber);

						return;
					}

					mBunho = BizCodeHelper.GetStandardBunHo(e.ChangeValue.ToString());

					// 벨리데이션 서비스 콜
                    strSql = @"SELECT A.SUNAME                          suname
                                    , A.TEL                             tel
                                    , NVL(A.DELETE_YN, 'N')             delete_yn
                                 FROM OUT0101 A
                                WHERE A.HOSP_CODE = :f_hosp_code
                                  AND A.BUNHO = :f_bunho";
                    bindVars.Clear();
                    bindVars.Add("f_hosp_code", this.mHospCode);
                    bindVars.Add("f_bunho", mBunho);
                    DataTable dtBunho = Service.ExecuteDataTable(strSql,bindVars);

                    if (dtBunho.Rows.Count == 0)
					{
						mMsg = (NetInfo.Language == LangMode.Ko ? "등록되지 않은 환자 입니다." :
							"登録されていない患者です.");
						this.SetMsg(mMsg, MsgType.Error);
						e.Cancel = true;
						break;
					}
                    else if(dtBunho.Rows[0]["delete_yn"].ToString() == "Y")
                    {
                         mMsg = (NetInfo.Language == LangMode.Ko ? "의무기록실에서 삭제한 등록번호 입니다." :
                              "削除された患者番号です。番号を確認してください。");
                         this.SetMsg(mMsg, MsgType.Error);
                         e.Cancel = true;
                         break;
                    }
                    
					// 입원예약중인지 체크
                    strSql = @"SELECT 'Y' 
                                 FROM DUAL
                                WHERE EXISTS ( SELECT 'X'
                                                 FROM INP1003
                                                 WHERE HOSP_CODE = :f_hosp_code
                                                   AND BUNHO = :f_bunho
                                                   AND RESER_END_TYPE = '0' )";
                    bindVars.Clear();
                    bindVars.Add("f_hosp_code", this.mHospCode);
                    bindVars.Add("f_bunho", this.grdInpReser.GetItemString(e.RowNumber,"bunho"));
                    object dtReser = Service.ExecuteScalar(strSql,bindVars);

                    if (dtReser != null && dtReser.ToString() == "Y")
					{
						mMsg = (NetInfo.Language == LangMode.Ko ? "이미 입원예약중인 환자 입니다. " :
							"この患者は既に予約登録を行っています。");
						this.SetMsg(mMsg, MsgType.Error);
						e.Cancel = true;
						break;
					}
					// 재원여부 확인
                    strSql = @"SELECT 'Y'
                                FROM DUAL
                               WHERE EXISTS(SELECT 'X'
                                              FROM INP1001
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND BUNHO       = :f_bunho
                                               AND JAEWON_FLAG = 'Y'
                                               AND CANCEL_YN   = 'N')";
                    bindVar.Clear();
                    bindVar.Add("f_hosp_code", this.mHospCode);
                    bindVar.Add("f_bunho",this.mBunho);
                    object rtn_result = Service.ExecuteScalar(strSql,bindVar);

                    if (rtn_result != null && rtn_result.ToString().Equals("Y"))
					{
						this.mMsg = (NetInfo.Language == LangMode.Ko ? "재원중인 환자 입니다." : "患者は現在在院中です。");

						this.SetMsg(this.mMsg, MsgType.Error);

						e.Cancel = true;

						break;
					}

                    this.grdInpReser.SetItemValue(e.RowNumber, "bunho", this.mBunho);
                    this.grdInpReser.SetItemValue(e.RowNumber, "suname", dtBunho.Rows[0]["suname"]);
                    this.grdInpReser.SetItemValue(e.RowNumber, "tel", dtBunho.Rows[0]["tel"]);
                    this.grdInpReser.SetItemValue(e.RowNumber, "tel1", dtBunho.Rows[0]["tel"]);

                    this.ResetGridExceptBunho(e.RowNumber);

					this.SetMsg("");

					#endregion

					break;

				case "ho_dong" :    // 병동 

//                    #region 병동

//                    if (e.ChangeValue.ToString() == "")
//                    {
//                        this.grdInpReser.SetItemValue(e.RowNumber, "ho_code", "");
//                        this.grdInpReser.SetItemValue(e.RowNumber, "bed_no" , "");
//                        return;
//                    }

//                    strSql = @"SELECT A.GWA_NAME ho_dong_name
//                                 FROM BAS0260 A
//                                WHERE A.HOSP_CODE   = :f_hosp_code
//                                  AND A.BUSEO_GUBUN = '2'/*병동*/
//                                  AND A.GWA         = :f_ho_dong
//                                  AND TO_DATE(:f_buseo_ymd,'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE";
//                    bindVars.Clear();
//                    bindVars.Add("f_hosp_code", this.mHospCode);
//                    bindVars.Add("f_ho_dong", this.grdInpReser.GetItemString(e.RowNumber, "ho_dong"));
//                    bindVars.Add("f_buseo_ymd", this.grdInpReser.GetItemString(e.RowNumber, "reser_date"));

//                    DataTable dtHoDong = Service.ExecuteDataTable(strSql,bindVars);

//                    if (dtHoDong.Rows[0]["ho_dong_name"].ToString() == "")
//                    {
//                        this.mMsg = (NetInfo.Language == LangMode.Ko ? "병동이 정확하지않습니다. 확인바랍니다."
//                            : "病棟が 正しくありません. ご確認ください.");

//                        this.SetMsg(this.mMsg, MsgType.Error);

//                        e.Cancel = true;
//                    }
//                    else
//                    {
//                        this.grdInpReser.SetItemValue(e.RowNumber, "ho_code", "");
//                        this.grdInpReser.SetItemValue(e.RowNumber, "bed_no" , "");
//                        this.SetMsg("");
//                    }

//                    #endregion

					break;

				case "ho_code" :    // 병실

					#region 병실
					
					if (e.ChangeValue.ToString() == "")
					{
						this.grdInpReser.SetItemValue(e.RowNumber, "bed_no", "");
						return ;
					}
                    strSql = @"SELECT DISTINCT 
                                      A.HO_CODE HO_CODE
                                    , A.HO_DONG HO_DONG
                                 FROM BAS0250 A
                                WHERE A.HOSP_CODE  = :f_hosp_code 
                                  AND TO_DATE(:f_ho_code_ymd,'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE
                                  AND A.HO_DONG LIKE :f_ho_dong || '%'
                                  AND A.HO_CODE    = :f_ho_code";
                    bindVars.Clear();
                    bindVars.Add("f_hosp_code", this.mHospCode);
                    bindVars.Add("f_ho_dong", this.grdInpReser.GetItemString(e.RowNumber, "ho_dong"));
                    bindVars.Add("f_ho_code", this.grdInpReser.GetItemString(e.RowNumber, "ho_code"));
                    bindVars.Add("f_ho_code_ymd", this.grdInpReser.GetItemString(e.RowNumber, "reser_date"));

                    DataTable dtHoSil = Service.ExecuteDataTable(strSql, bindVars);

                    if (dtHoSil.Rows[0]["ho_code"].ToString() == "")
					{
						this.mMsg = (NetInfo.Language == LangMode.Ko ? "병실이 정확하지않습니다. 확인바랍니다." 
							: "病室が 正しくありません. ご確認ください.");
						
						this.SetMsg(this.mMsg, MsgType.Error);

						e.Cancel = true;
					}
					else
					{
                        this.grdInpReser.SetItemValue(e.RowNumber, "ho_dong", dtHoSil.Rows[0]["ho_dong"].ToString());
                        this.grdInpReser.SetItemValue(e.RowNumber, "bed_no", "");
						this.SetMsg("");
					}

					#endregion

					break;

				case "bed_no" :     // 베드

//                    #region 베드

//                    if (e.ChangeValue.ToString() == "")
//                    {
//                        return;
//                    }

//                    strSql = @"SELECT 'Y'
//                                 FROM DUAL
//                                WHERE EXISTS ( SELECT 'X'
//                                                FROM BAS0253 A
//                                               WHERE A.HOSP_CODE = :f_hosp_code
//                                                 AND A.HO_CODE = :f_ho_code
//                                                 AND A.BED_NO  = :f_bed_no
//                                                 AND TO_DATE(:f_reser_date, 'YYYY/MM/DD') BETWEEN A.FROM_BED_DATE 
//                                                                                              AND NVL(A.TO_BED_DATE, TO_DATE('9998/12/31', 'YYYY/MM/DD')))";
//                    bindVars.Clear();
//                    bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
//                    bindVars.Add("f_ho_code", this.grdInpReser.GetItemString(e.RowNumber, "ho_code"));
//                    bindVars.Add("f_bed_no", this.grdInpReser.GetItemString(e.RowNumber, "bed_no"));
//                    bindVars.Add("f_reser_date", this.grdInpReser.GetItemString(e.RowNumber, "reser_date"));

//                    Object objBed = Service.ExecuteScalar(strSql,bindVars);

//                    if (objBed.ToString() != "Y")
//                    {
//                        this.mMsg = (NetInfo.Language == LangMode.Ko ? "베드가 정확하지않습니다. 확인바랍니다." 
//                            : "病床が 正しくありません. ご確認ください.");
						
//                        this.SetMsg(this.mMsg, MsgType.Error);

//                        e.Cancel = true;
//                    }
//                    else
//                    {
//                        this.SetMsg("");
//                    }

//                    #endregion

					break;

				case "gwa" :

					#region 진료과

					if (e.ChangeValue.ToString() == "")
					{
						this.grdInpReser.SetItemValue(e.RowNumber, "gwa_name", "");
						this.grdInpReser.SetItemValue(e.RowNumber, "doctor", "");
						this.grdInpReser.SetItemValue(e.RowNumber, "doctor_name", "");
						return;
					}

                    strSql = @"SELECT A.GWA_NAME gwa_name
                                 FROM BAS0260 A
                                WHERE A.HOSP_CODE = :f_hosp_code
                                  AND A.BUSEO_GUBUN = '1'/*진료과*/
                                  AND A.GWA         = :f_gwa
                                  AND TO_DATE(:f_reser_date,'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE";
                    bindVars.Clear();
                    bindVars.Add("f_hosp_code", this.mHospCode);
                    bindVars.Add("f_gwa", this.grdInpReser.GetItemString(e.RowNumber, "gwa"));
                    bindVars.Add("f_reser_date", this.grdInpReser.GetItemString(e.RowNumber, "reser_date"));

                    DataTable dtGwa = Service.ExecuteDataTable(strSql,bindVars);

                    if (Service.ErrCode != 0 || dtGwa.Rows.Count == 0|| dtGwa.Rows[0]["gwa_name"].ToString() == "")
                    {
                        this.mMsg = (NetInfo.Language == LangMode.Ko ? "진료과가 정확하지않습니다. 확인바랍니다."
                            : "診療科が 有効ではありません。 ご確認ください。");

                        this.SetMsg(this.mMsg, MsgType.Error);

                        e.Cancel = true;
                    }
                	else
					{
                        this.grdInpReser.SetItemValue(e.RowNumber, "gwa_name", dtGwa.Rows[0]["gwa_name"].ToString());
						this.grdInpReser.SetItemValue(e.RowNumber, "doctor", "");
						this.grdInpReser.SetItemValue(e.RowNumber, "doctor_name", "");
						this.SetMsg("");
					}

					#endregion

					break;

				case "ipwon_mokjuk" :

					#region 입원목적

					if (e.ChangeValue.ToString() == "")
					{
						return;
					}

					// 입원시 오더는 의사만 가능함.
					if (UserInfo.UserGubun != UserType.Doctor)
					{
						if (e.ChangeValue.ToString() == ORDER_IN_IPWON)
						{
							this.mMsg = (NetInfo.Language == LangMode.Ko ? "입원시 오더는 의사만 가능 합니다." : "入院時オーダ項目は医師のみ入力可能です。");
							XMessageBox.Show(this.mMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							this.grdInpReser.SetItemValue(e.RowNumber, "ipwon_mokjuk", "");
							return;
						}
					}

					this.SetMsg("");

					#endregion

					break;

				case "reser_date":

					#region 예약일

					if (e.ChangeValue.ToString() == "")
					{
						return;
					}

					if (!this.IsValidDate(e.ChangeValue.ToString()))
					{
						e.Cancel = true;

						this.mMsg = (NetInfo.Language == LangMode.Ko ? "예약 일자가 유효하지 않습니다." : "予約日付が有効ではありません。");

						this.SetMsg(this.mMsg, MsgType.Error);

						return;
					}

					#endregion

					break;

				case "jisi_doctor" :

					#region 지시의사

					if (e.ChangeValue.ToString() == "")
					{
						this.grdInpReser.SetItemValue(e.RowNumber, "jisi_doctor_name", "");
						this.SetMsg("");
						return ;
					}
                    strSql = @"SELECT FN_BAS_LOAD_DOCTOR_NAME(:f_jisi_doctor, TO_DATE(:f_reser_date,'YYYY/MM/DD')) JISI_DOCTOR_NAME FROM DUAL";

                    bindVar.Add("f_jisi_doctor", e.ChangeValue.ToString());
                    bindVar.Add("f_reser_date",this.grdInpReser.GetItemString(e.RowNumber, "reser_date"));
                    object rtn_doctor_name = Service.ExecuteScalar(strSql,bindVar);

                    if (TypeCheck.IsNull(rtn_doctor_name))
					{
						this.mMsg = (NetInfo.Language == LangMode.Ko ? "의사가 정확하지않습니다. 확인바랍니다." 
							: "医師コードが 有効ではありません。 ご確認ください。");
						
						this.SetMsg(this.mMsg, MsgType.Error);

						e.Cancel = true;
					}
					else
					{
                        this.grdInpReser.SetItemValue(e.RowNumber, "jisi_doctor_name", rtn_doctor_name.ToString());
						this.SetMsg("");
					}

					#endregion

					break;

				case "doctor" :

					#region 의사

					if (e.ChangeValue.ToString() == "")
					{
						this.grdInpReser.SetItemValue(e.RowNumber, "doctor_name", "");
						this.SetMsg("");
					}

                    strSql = @"SELECT FN_BAS_LOAD_DOCTOR_NAME(:f_doctor, TO_DATE(:f_reser_date,'YYYY/MM/DD')) JISI_DOCTOR_NAME FROM DUAL";
                    
                    bindVar.Add("f_doctor", e.ChangeValue.ToString());
                    bindVar.Add("f_reser_date", this.grdInpReser.GetItemString(e.RowNumber, "reser_date"));
                    //bindVar.Add("f_gwa", this.grdInpReser.GetItemString(e.RowNumber, "gwa"));
                    object rtn_gwadoctor_name = Service.ExecuteScalar(strSql,bindVar);

                    if (TypeCheck.IsNull(rtn_gwadoctor_name))
					{
						this.mMsg = (NetInfo.Language == LangMode.Ko ? "의사가 정확하지않습니다. 확인바랍니다." 
							: "医師コードが 有効ではありません。 ご確認ください。");
						
						this.SetMsg(this.mMsg, MsgType.Error);

						e.Cancel = true;
					}
					else
					{
                        this.grdInpReser.SetItemValue(e.RowNumber, "doctor_name", rtn_gwadoctor_name.ToString());
						this.SetMsg("");
					}

					#endregion

					break;

				case "remark":

					if (this.txtRemark.GetDataValue() != e.ChangeValue.ToString())
					{
						this.txtRemark.SetDataValue(e.ChangeValue);
					}

					break;

				case "sang_bigo":

					if (this.txtSangComment.GetDataValue() != e.ChangeValue.ToString())
					{
						this.txtSangComment.SetDataValue(e.ChangeValue);
					}

					break;

			}
		}

		#endregion

		#region 그리드 Column Protect

		private void grdInpReser_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
		{
			// 오키나와 요청사항 2009.01.15일 
			// 다 풀어버림
			// 아니다 일자랑 이런거는 막아놔야지
			if (grdInpReser.GetItemString(e.RowNumber, "reser_fkinp1001") != "" && UserInfo.UserGubun != UserType.Doctor)
			{
				//2009.05.11 주치의,지시의 변경가능하도록..
				if (e.ColName != "reser_date" && e.ColName != "bunho" && e.ColName != "suname" &&
					e.ColName != "gwa" && e.ColName != "gwa_name" && e.ColName != "ipwon_mokjuk" &&
					grdInpReser.GetItemString(e.RowNumber, "reser_end_type") == "0")
				{
					e.Protect = false;
				}
				else
				{
					e.Protect = true;
				}
				return;
			}

			// inpwon_end_type이 "입원중"인 경우만 Modify가능 <-- 이거 멍미?? 0은 예약중임....
			if (grdInpReser.GetItemString(e.RowNumber, "reser_end_type") != "0")
			{
				e.Protect = true;
			}
			else
			{
				e.Protect = false;
			}
		}

		#endregion

		#region 그리드 Cell Focus Changed

		private void grdInpReser_GridCellFocusChanged(object sender, IHIS.Framework.XGridCellFocusChangedEventArgs e)
		{
			if (e.ColName == "doctor")
			{
				if (this.grdInpReser.GetItemString(e.RowNumber, "gwa") == "")
				{
					mMsg = (NetInfo.Language == LangMode.Ko ? "진료과를 먼저 입력하십시요." : 
                                  "診療科を入力してください");
					this.SetMsg(mMsg, MsgType.Error);
					this.grdInpReser.SetFocusToItem(e.RowNumber, "gwa", true);
				}
			}
		}

		#endregion

		#region 그리드 Row Focus Changed

		private void grdInpReser_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			// reser_end_type 이 0 "예약중" 이 아닐경우 비고 Text박스 protect
			if (grdInpReser.GetItemString(e.CurrentRow, "reser_end_type") != "0")
			{
				this.txtRemark.Protect = true;
				this.txtIpwon_Mokjuk.Protect = true;
				this.txtSangComment.Protect = true;
			}
			else
			{
				this.txtRemark.Protect = false;
				this.txtIpwon_Mokjuk.Protect = false;
				this.txtSangComment.Protect = false;
			}
		}

		#endregion

		#region 그리드 Find Click

		private void grdInpReser_GridFindClick(object sender, IHIS.Framework.GridFindClickEventArgs e)
		{
			switch (e.ColName)
			{
				case "bunho" :

					OpenScreen_OUT0101Q01();

					break;
                case "jisi_doctor":
                    this.fwkDoctor.SetBindVarValue("f_hosp_code", this.mHospCode);
                    this.fwkDoctor.SetBindVarValue("f_gwa", "%");
                    this.fwkDoctor.SetBindVarValue("f_doctor_ymd", this.grdInpReser.GetItemString(e.RowNumber, "reser_date")); 

					break;
				case "doctor" :

                    this.fwkDoctor.SetBindVarValue("f_hosp_code", this.mHospCode);
                    this.fwkDoctor.SetBindVarValue("f_gwa", this.grdInpReser.GetItemString(e.RowNumber, "gwa"));
                     this.fwkDoctor.SetBindVarValue("f_doctor_ymd", this.grdInpReser.GetItemString(e.RowNumber, "reser_date"));
					break;
				case "ho_code" :

					OpenScreen_BAS0250Q00();

					break;
				case "ho_dong" :

					OpenScreen_BAS0250Q00();

					break;
				case "bed_no" :

					OpenScreen_BAS0250Q00();

					break;
			}

		}

		#endregion

		#region 메모박스 버튼 클릭시

		private void grdInpReser_GridReservedMemoButtonClick(object sender, IHIS.Framework.GridReservedMemoButtonClickEventArgs e)
		{
			XEditGrid grd = sender as XEditGrid;

			CommonItemCollection loadParams;

			switch (e.ColName)
			{
				case "remark":

					loadParams = new CommonItemCollection();
					loadParams.Add("category", this.RESER_MEMO_CATEGORY);
					loadParams.Add("currText", grd.GetItemString(e.RowNumber, "remark"));
					grd.SetReservedMemoControlLoadParam(e.ColName, loadParams);
					break;

                //case "ipwon_mokjuk2":

                //    loadParams = new CommonItemCollection();

                //    loadParams.Add("category", this.IPWON_MOKJUK_MEMO_CATEGORY);
                //    loadParams.Add("currText", grd.GetItemString(e.RowNumber, "ipwon_mokjuk2"));
                //    grd.SetReservedMemoControlLoadParam(e.ColName, loadParams);
                //    break;
			}
		}

		 #endregion
        #endregion

        #region Command

        public override object Command(string command, CommonItemCollection commandParam)
		{
			// TODO:  INP1003U00.Command 구현을 추가합니다.
			switch (command)
			{
				case "OUT0101" :
					try
					{
						this.grdInpReser.SetFocusToItem(grdInpReser.CurrentRowNumber, "bunho", true);
						this.grdInpReser.SetEditorValue(((MultiLayout)commandParam[0]).LayoutTable.Rows[0]["bunho"]);

						if (this.grdInpReser.AcceptData())
						{
							PostCallHelper.PostCall(new PostMethodStr(PostCommandCall), "OUT0101");
						}
					}
					catch
					{
					}
					break;
				case "NewBunho" :

					mMsg = (NetInfo.Language == LangMode.Ko ? "새로운 환자에 대하여 입원예약을 수행 하시겠습니까?" :
						          "新しい患者に対して入院予約を行いますか。");
					mCaption = (NetInfo.Language == LangMode.Ko ? "확인" : "確認");

                    if (commandParam != null && 
                        ((MultiLayout)commandParam["OUT0101"]).RowCount > 0)
                    {
                        if (XMessageBox.Show(mMsg, mCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (this.grdInpReser.RowCount > 0 &&
                                this.grdInpReser.LayoutTable.Rows[this.grdInpReser.CurrentRowNumber].RowState == DataRowState.Added &&
                                this.grdInpReser.GetItemString(grdInpReser.CurrentRowNumber, "bunho").ToString() == "")
                            {
                                this.grdInpReser.SetFocusToItem(grdInpReser.CurrentRowNumber, "bunho", true);
                                this.grdInpReser.SetEditorValue(((MultiLayout)commandParam["OUT0101"]).GetItemString(0, "bunho"));
                                this.grdInpReser.SetFocusToItem(grdInpReser.CurrentRowNumber, "gwa", true);
                                this.grdInpReser.SetItemValue(grdInpReser.CurrentRowNumber, "reser_date", this.dtpInpReserDate.GetDataValue());
                            }
                            else
                            {
                                this.grdInpReser.InsertRow(-1);
                                this.grdInpReser.SetFocusToItem(grdInpReser.CurrentRowNumber, "bunho", true);
                                this.grdInpReser.SetEditorValue(((MultiLayout)commandParam["OUT0101"]).GetItemString(0, "bunho"));
                                this.grdInpReser.SetFocusToItem(grdInpReser.CurrentRowNumber, "gwa", true);
                                this.grdInpReser.SetItemValue(grdInpReser.CurrentRowNumber, "reser_date", this.dtpInpReserDate.GetDataValue());
                            }
                        }
                    }
					break;

				case "BAS0250Q00" :

					if (commandParam != null)
					{
						this.grdInpReser.SetItemValue(grdInpReser.CurrentRowNumber, "ho_dong", commandParam["ho_dong"].ToString());
						this.grdInpReser.SetItemValue(grdInpReser.CurrentRowNumber, "ho_code", commandParam["ho_code"].ToString());
						this.grdInpReser.SetItemValue(grdInpReser.CurrentRowNumber, "bed_no", commandParam["bed_no"].ToString());
						PostCallHelper.PostCall(new PostMethodStr(PostCommandCall), "BAS0250Q00");
					}
					break;

				case "INP1003U01" :

					if (commandParam != null)
					{
						XMessageBox.Show(commandParam["pkinp1001"].ToString());
					}

					break;

			}
			return base.Command (command, commandParam);
		}

		#endregion

		#region XButton

		private void btnNewPatient_Click(object sender, System.EventArgs e)
		{
			string sysid = EnvironInfo.CurrSystemID;
			string screen = this.ScreenID;

			CommonItemCollection param = new CommonItemCollection();

			param.Add("sysid", sysid);
			param.Add("screen", screen);

			XScreen.OpenScreenWithParam(this, "OUTS", "OUT0101U01", ScreenOpenStyle.ResponseFixed, param);

		}

		private void btnReservedMemo_Click(object sender, System.EventArgs e)
		{
            // 0 :예약중, 1:입원중, 2:입원취소, 3:퇴원, 4:예약취소
			if (this.grdInpReser.GetItemString(grdInpReser.CurrentRowNumber, "reser_end_type") != "0")
			{
				return;
			}

			ReserMemoForm form = new ReserMemoForm(this.RESER_MEMO_CATEGORY);

			Point location = this.btnReservedMemo.Location;
			location.Y = location.Y - form.Size.Height;

			form.Location = this.xPanel1.PointToScreen(location);

			DialogResult result = form.ShowDialog();

			if (result == DialogResult.OK)
			{
				this.txtRemark.SetEditValue(this.txtRemark.GetDataValue() + form.SelectedText);
				this.txtRemark.AcceptData();
			}

			form.Dispose();

		}

		private void btnIpwon_Mokjuk_Click(object sender, System.EventArgs e)
		{
			if (this.grdInpReser.GetItemString(grdInpReser.CurrentRowNumber, "reser_end_type") != "0")
			{
				return;
			}

			ReserMemoForm form = new ReserMemoForm(this.IPWON_MOKJUK_MEMO_CATEGORY);

			Point location = this.btnIpwon_Mokjuk.Location;
			location.Y = location.Y - form.Size.Height;

			form.Location = this.xPanel1.PointToScreen(location);

			DialogResult result = form.ShowDialog();

			if (result == DialogResult.OK)
			{
				this.txtIpwon_Mokjuk.SetEditValue(this.txtIpwon_Mokjuk.GetDataValue() + form.SelectedText);
				this.txtIpwon_Mokjuk.AcceptData();
			}

			form.Dispose();
		}

		#endregion

		#region 현Screen의 등록번호,성명,부서,병동 스크린명를 타Screen에 넘긴다
		public override XPatientInfo OnRequestBunHo()
		{
			if (!TypeCheck.IsNull(this.grdInpReser))
				return new XPatientInfo( this.grdInpReser.GetItemString(grdInpReser.CurrentRowNumber, "bunho")
					                   , this.grdInpReser.GetItemString(grdInpReser.CurrentRowNumber, "suname")
					                   , this.grdInpReser.GetItemString(grdInpReser.CurrentRowNumber, "gwa")
					                   , this.grdInpReser.GetItemString(grdInpReser.CurrentRowNumber, "ho_dong")
									   , this.grdInpReser.GetItemString(grdInpReser.CurrentRowNumber, "pkinp1003")
					                   , PatientPKGubun.In, "入院予約登録");
			return base.OnRequestBunHo ();
		}
		#endregion 

		#region Screen Open

		private void INP1003U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
            this.mHospCode = EnvironInfo.HospCode;
            //this.DataServiceCall(this.dsvQryReser);
            //저장 수행자 Set
            this.grdInpReser.SavePerformer = new XSavePerformer(this);
            //저장 Layout List Set
            this.SaveLayoutList.Add(this.grdInpReser);


			// 화면 크기를 화면에 맞게 최대화 시킨다 (다른 화면에서 연경우가 아닌경우)
			if (this.Opener is IHIS.Framework.MdiForm && 
				(this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpSizable || this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpFixed))
			{
				Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;			
				this.ParentForm.Size = new System.Drawing.Size(rc.Width - 30, rc.Height - 105);
            }
			
			// OpenParam이 존재 하는 경우
			if (this.OpenParam != null)
			{
				if (this.OpenParam.Contains("bunho"))
				{
					// 새로운 생 생성
					int rowNum = this.grdInpReser.InsertRow(-1);
                    this.grdInpReser.SetFocusToItem(rowNum, "bunho");
					this.grdInpReser.SetEditorValue(this.OpenParam["bunho"].ToString());
					this.grdInpReser.SetFocusToItem(rowNum, "suname");

					if (this.OpenParam.Contains("naewon_date"))
					{
                        this.grdInpReser.SetItemValue(rowNum, "reser_date", this.OpenParam["naewon_date"].ToString());
					}
					else
					{
                        this.grdInpReser.SetItemValue(rowNum, "reser_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
					}

					if (this.OpenParam.Contains("gwa"))
					{
                        this.grdInpReser.SetFocusToItem(rowNum, "gwa");
						this.grdInpReser.SetEditorValue(this.OpenParam["gwa"].ToString());
                        this.grdInpReser.SetFocusToItem(rowNum, "gwa_name");
					}

					if (this.OpenParam.Contains("doctor"))
					{
                        this.grdInpReser.SetFocusToItem(rowNum, "doctor");
						this.grdInpReser.SetEditorValue(this.OpenParam["doctor"].ToString());
                        this.grdInpReser.SetFocusToItem(rowNum, "doctor_name");
					}

					if (this.OpenParam.Contains("hodong"))
					{
						this.grdInpReser.SetItemValue(rowNum, "ho_dong", this.OpenParam["hodong"].ToString());
					}
				}
				return;
			}
			else
            {
                // 현재날자 적용
                this.dtpInpReserDate.SetDataValue(DateTime.Now);
                // 병동 셋팅
                this.MakeHodongCombo(this.dtpInpReserDate.GetDataValue());
                // 조회 구분 
                this.cboQueryGubun.SetDataValue("1");
				this.Load_INP1003();
			}
			// OpenParam이 존재하지 않는경우
			/* 예약은 프로그램의 시작점 이므로 번호를 받아오지 않아도 된다.*/
			/*XPatientInfo patientInfo = XScreen.GetOtherScreenBunHo(sender, true);
              if (patientInfo != null)
			  { this.grdInpReser.InsertRow(-1);
				this.grdInpReser.SetFocusToItem(grdInpReser.CurrentRowNumber, "bunho",true);
				this.grdInpReser.SetEditorValue(patientInfo.BunHo);
				this.grdInpReser.SetFocusToItem(grdInpReser.CurrentRowNumber, "suname", false);}*/

			// 그리드 Fix 컬럼 셋팅
			this.grdInpReser.FixedCols = 4;

		}

		#endregion

		#region 타화면 Open

		private void OpenScreen_BAS0250Q00()
		{
			CommonItemCollection param = new CommonItemCollection();

			param.Add("ho_dong"       , this.grdInpReser.GetItemString(grdInpReser.CurrentRowNumber, "ho_dong" ));
			param.Add("ipwon_date"    , this.grdInpReser.GetItemString(grdInpReser.CurrentRowNumber, "reser_date"));
			param.Add("accept_use_bed", "Y"); /* 사용중인 베드 선택 가능 */

			XScreen.OpenScreenWithParam(this, "BASS", "BAS0250Q00", ScreenOpenStyle.ResponseFixed, param);
		}

		private void OpenScreen_OUT0101Q01()
		{
            XScreen.OpenScreen(this, "OUT0101Q01", ScreenOpenStyle.PopUpFixed);
            //CommonItemCollection param = new CommonItemCollection();
            //XScreen.OpenScreenWithParam(this, "NURO", "OUT0101Q01", ScreenOpenStyle.ResponseFixed, param);
		}

		#endregion

		#region PostCallMethod 

		/// <summary>
		/// 스크린에서 Command 호출후 
		/// </summary>
		/// <param name="aScreenName"></param>
		private void PostCommandCall(string aScreenName)
		{
			switch (aScreenName)
			{
				case "OUT0101" :

					this.grdInpReser.Focus();
					this.grdInpReser.SetFocusToItem(grdInpReser.CurrentRowNumber, "jisi_doctor", true);

					break;

				case "BAS0250Q00" :

					this.grdInpReser.Focus();
					this.grdInpReser.SetFocusToItem(grdInpReser.CurrentRowNumber, "toiwon_res_date", true);

					break;
			}
		}

		/// <summary>
		/// 컬럼 벨리데이션 수행후 포커스 컨트롤
		/// </summary>
		/// <param name="aColumnName"></param>
		private void PostInpReserGridColumnChanged (string aColumnName)
		{
			switch (aColumnName)
			{
				case "jisi_doctor" :

                    this.grdInpReser.SetFocusToItem(grdInpReser.CurrentRowNumber, "ho_dong", true);

					break;

				case "gwa" :

					this.grdInpReser.SetFocusToItem(grdInpReser.CurrentRowNumber, "doctor", true);

					break;

				case "doctor" :

                    this.grdInpReser.SetFocusToItem(grdInpReser.CurrentRowNumber, "jisi_doctor", true);

					break;
			}
		}

		#endregion

		#region XComboBox

		private void cboHodong_SelectedValueChanged(object sender, EventArgs e)
		{
			this.btnList.PerformClick(FunctionType.Query);
		}

		#endregion

        #region XSavePerformer

        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private INP1003U00 parent = null;
            BindVarCollection bindChk = new BindVarCollection();

            public XSavePerformer(INP1003U00 parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";

                //Grid에서 넘어온 Bind 변수에 f_user_id SET
                if(UserInfo.UserGubun == UserType.Doctor)
                    item.BindVarList.Add("f_user_id", UserInfo.DoctorID);
                else
                    item.BindVarList.Add("f_user_id", UserInfo.UserID);

                item.BindVarList.Add("f_hosp_code", parent.mHospCode);

                switch (item.RowState)
                {
                    //insert sql
                    case DataRowState.Added:
                       
                            if (ChkVaild(item, "I"))
                            {
                                /*PKINP1003 Key 생성 */
                                string cmdText_sub = @"SELECT INP1003_SEQ.NEXTVAL
    			                   			             FROM DUAL";
                                object rtn_inp1003_seq = Service.ExecuteScalar(cmdText_sub);

                                cmdText_sub = @"SELECT INP1001_SEQ.NEXTVAL
    			                   			             FROM DUAL";
                                object rtn_inp1001_seq = Service.ExecuteScalar(cmdText_sub);

                                item.BindVarList.Remove("f_pkinp1003");
                                item.BindVarList.Remove("f_junpyo_date");
                                item.BindVarList.Remove("f_reser_fkinp1001");

                                item.BindVarList.Add("f_pkinp1003", rtn_inp1003_seq.ToString());
                                item.BindVarList.Add("f_junpyo_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                                item.BindVarList.Add("f_reser_fkinp1001", rtn_inp1001_seq.ToString());

                                cmdText = @"INSERT INTO INP1003
                                                 ( SYS_DATE        , SYS_ID             , UPD_DATE
                                                 , PKINP1003       , JUNPYO_DATE        , BUNHO
                                                 , TEL1            , TEL2               , RESER_DATE
                                                 , GWA             , DOCTOR             , HO_CODE
                                                 , RESER_END_TYPE  , REMARK             , SUSUL_RESER_YN
                                                 , IPWON_RTN2      , HO_DONG            , BED_NO
                                                 , IPWON_MOKJUK    , IPWONSI_ORDER_YN   , JISI_DOCTOR
                                                 , SANG_BIGO       , SOGYE_YN           , HOPE_ROOM
                                                 , HOSP_CODE       , UPD_ID             , RESER_FKINP1001)
                                            VALUES 
                                                 ( SYSDATE            , :f_user_id           , SYSDATE
                                                 , :f_pkinp1003       , TO_DATE(:f_junpyo_date,'YYYY/MM/DD')     , :f_bunho
                                                 , :f_tel             , :f_tel1              , TO_DATE(:f_reser_date,'YYYY/MM/DD')
                                                 , :f_gwa             , :f_doctor            , :f_ho_code
                                                 , :f_reser_end_type  , :f_remark            , :f_susul_reser_yn
                                                 , :f_ipwon_rtn2      , :f_ho_dong           , :f_bed_no
                                                 , :f_ipwon_mokjuk    , :f_ipwonsi_order_yn  , :f_jisi_doctor     
                                                 , :f_sang_bigo       , :f_sogye_yn          , :f_hope_room
                                                 , :f_hosp_code       , :f_user_id           , :f_reser_fkinp1001)";
                            }
                            else
                            { return false; }

                        break;
                    case DataRowState.Modified:
                        //if (this.CheckUpdate(item) == true)
                        //{
                               if (ChkVaild(item, "U"))
                               {
                                   cmdText
                                        = @"UPDATE INP1003
    			                               SET UPD_ID        = :f_user_id
	                                             , UPD_DATE       = SYSDATE
	                                             , JUNPYO_DATE    = TO_DATE(:f_junpyo_date,'YYYY/MM/DD')
	                                             , TEL1           = :f_tel
	                                             , TEL2           = :f_tel1
	                                             , RESER_DATE     = TO_DATE(:f_reser_date,'YYYY/MM/DD')
	                                             , GWA            = :f_gwa
	                                             , DOCTOR         = :f_doctor
	                                             , HO_CODE        = :f_ho_code
	                                             , RESER_END_TYPE = :f_reser_end_type
	                                             , REMARK         = :f_remark
	                                             , SUSUL_RESER_YN = :f_susul_reser_yn
	                                             , IPWON_RTN2     = :f_ipwon_rtn2
	                                             , HO_DONG        = :f_ho_dong
	                                             , BED_NO         = :f_bed_no
	                                             , IPWON_MOKJUK   = :f_ipwon_mokjuk
	                                             , JISI_DOCTOR    = :f_jisi_doctor 
	                                             , SANG_BIGO      = :f_sang_bigo
	                                             , SOGYE_YN       = :f_sogye_yn
	                                             , HOPE_ROOM      = :f_hope_room
	                                        WHERE HOSP_CODE      = :f_hosp_code
                                              AND PKINP1003      = :f_pkinp1003";

                               }
                               else
                               { return false; }
                          //}
                                           
                        break;

                    case DataRowState.Deleted:
                        /*환자번호 NULL체크 */
                        if (item.BindVarList["f_bunho"].ValueLen == 0)
                        {
                            XMessageBox.Show("患者情報がありません。");
                            return false;
                        }

                        /*PKINP1003 NULL체크 */
                        if (item.BindVarList["f_pkinp1003"].ValueLen == 0)
                        {
                            XMessageBox.Show("キーを探せません。");
                            return false;
                        }

                        if (item.BindVarList["f_junpyo_date"].ValueLen == 0)
                        {
                            XMessageBox.Show("伝票日付を探せません。");
                            return false;
                        }

                          cmdText
                            = @"DELETE FROM INP1003
                                      WHERE HOSP_CODE      = :f_hosp_code
                                        AND PKINP1003      = :f_pkinp1003";
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }

            #region 갱신전의 체크
//            private bool CheckUpdate(RowDataItem bindVar)
//            {
//                bool temp = true;
//                string result = string.Empty;
              
//                string strQuery = @"SELECT 'Y'
//        		                     FROM DUAL
//        		                    WHERE EXISTS ( SELECT 'X'
//        		                                     FROM INP1003 A
//        		                                    WHERE A.HOSP_CODE  = :f_hosp_code
//                                                      AND A.BUNHO = :f_bunho
//        		                                      AND A.RESER_DATE = TO_DATE(:f_reser_date,'YYYY/MM/DD')
//        		                                      AND A.RESER_END_TYPE = '0' 
//        		                                      AND A.PKINP1003 != :f_pkinp1003 )";

//                bindChk.Add("f_hosp_code", bindVar.BindVarList["f_hosp_code"].ToString());
//                bindChk.Add("f_bunho", bindVar.BindVarList["f_bunho"].ToString());
//                bindChk.Add("f_reser_date", bindVar.BindVarList["f_reser_date"].ToString());
//                bindChk.Add("f_pkinp1003", bindVar.BindVarList["f_pkinp1003"].ToString());

//                object retVal = Service.ExecuteScalar(strQuery, bindChk);
//                bindChk.Clear();
                
//                if (retVal != null && !retVal.Equals("Y"))
//                {
//                    temp = false;
//                }

//                return temp;

//            }
            #endregion

            #region 체크 의사의 과..
//            private string ChkDoctorGwa(RowDataItem i_item)
//            {
//                string rtn_value = "";

//                string strSql = @"SELECT A.DOCTOR_GWA
//                                   FROM BAS0270 A
//                                  WHERE A.HOSP_CODE    = :f_hosp_code
//                                    AND A.DOCTOR = :f_doctor
//                                    AND TO_DATE(:f_reser_date, 'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE";

//                bindChk.Add("f_hosp_code", i_item.BindVarList["f_hosp_code"].ToString());
//                bindChk.Add("f_doctor",i_item.BindVarList["f_doctor"].ToString());
//                bindChk.Add("f_reser_date",i_item.BindVarList["f_res_date"].ToString());

//                object rtn_gwa = Service.ExecuteScalar(strSql, bindChk);
//                bindChk.Clear();
//                if ((rtn_gwa != null && rtn_gwa.ToString().Length == 0) || Service.ErrCode != 0)
//                {
//                    XMessageBox.Show("主治医が正確ではありません。ご確認ください。");
//                    return rtn_value = string.Empty;
//                }
//                if (rtn_gwa != null && rtn_gwa.ToString().CompareTo(i_item.BindVarList[""].ToString()) != 0)
//                {
//                    XMessageBox.Show("入院診療科と主治医診療が一致しません。確認して下さい。");
//                    return rtn_value = string.Empty;
                
//                }
//                strSql = @"SELECT A.DOCTOR_GWA
//                         FROM BAS0270 A
//                        WHERE A.DOCTOR = :f_jisi_doctor
//                          AND NVL(A.DOCTOR_END_YMD,TO_DATE('99991231','YYYYMMDD')) > :f_reser_date
//                          AND A.DOCTOR_YMD = ( SELECT MAX(B.DOCTOR_YMD)
//                                                 FROM BAS0270 B
//                                                WHERE B.DOCTOR = A.DOCTOR
//                                                  AND B.DOCTOR_YMD <= :f_reser_date )";
//                bindChk.Add("f_jisi_doctor",i_item.BindVarList["f_jisi_doctor"].ToString());
//                bindChk.Add("f_reser_date",i_item.BindVarList["f_res_date"].ToString());
//                rtn_gwa = Service.ExecuteScalar(strSql, bindChk);
//                bindChk.Clear();

//                if ((rtn_gwa != null && rtn_gwa.ToString().Length == 0 )|| Service.ErrCode != 0)
//                {
//                    XMessageBox.Show("指示医が正確ではありません。ご確認ください。");
//                    return rtn_value = string.Empty;
//                }
      
//                return rtn_value = rtn_gwa.ToString();

//            }
            #endregion 

            #region 입력 ,갱신 ,삭제 전의 체크
            private bool ChkVaild(RowDataItem i_item, string chk_flag)
            {
                string chkSql = string.Empty;               

                /*환자번호 NULL체크 */
                if (i_item.BindVarList["f_bunho"].VarValue == "")
                {
                    XMessageBox.Show("患者情報がありません。");
                    return false;
                }

                if (chk_flag == "I" && chk_flag != "")
                {
                    /*환자번호 유효성체크 */

                    if (INP1003ChkBunho(i_item.BindVarList["f_bunho"].VarValue) != 0)
                    {
                        return false;
                    }

                    /*재원중인 환자 체크 */
                    if (INP1003CheckJaewon(i_item.BindVarList["f_bunho"].VarValue, i_item.BindVarList["f_reser_date"].VarValue) == 0)
                    {
                        XMessageBox.Show("患者様は現在在院中です。");
                        return false;
                    }
                }

                /*PKINP1003 NULL체크 */
                if (i_item.BindVarList["f_pkinp1003"].ValueLen == 0)
                {
                    XMessageBox.Show("予約キーがありません。");
                    return false;
                }

                /*진료과 NULL 체크 */
                if (i_item.BindVarList["f_gwa"].ValueLen == 0)
                {
                    XMessageBox.Show("診療科が有効ではありません。ご確認ください。");
                    return false;
                }
                /*주치의 NULL 체크 */
                if (i_item.BindVarList["f_doctor"].ValueLen == 0)
                {
                    XMessageBox.Show("主治医が有効ではありません。ご確認ください。");
                    return false;
                }

                /*예약중인 환자 체크 */
                if (chk_flag == "I" && chk_flag != "")
                {
                    chkSql = @"SELECT 'Y'
        		            FROM DUAL
        		            WHERE EXISTS ( SELECT 'X'
        		                             FROM INP1003 A
        		                            WHERE A.HOSP_CODE = :f_hosp_code
                                              AND A.BUNHO     = :f_bunho
        		                              AND A.RESER_DATE = TO_DATE(:f_reser_date,'YYYY/MM/DD')
        		                              AND A.RESER_END_TYPE = '0' )";
                    bindChk.Clear();
                    bindChk.Add("f_hosp_code", i_item.BindVarList["f_hosp_code"].VarValue);
                    bindChk.Add("f_bunho", i_item.BindVarList["f_bunho"].VarValue);
                    bindChk.Add("f_reser_date", i_item.BindVarList["f_reser_date"].VarValue);
                    object rtn_value = Service.ExecuteScalar(chkSql, bindChk);

                    if (rtn_value != null && rtn_value.ToString().Equals("Y"))
                    {
                        XMessageBox.Show("既に登録されている入院予約データがあります。");
                        return false;
                    }
                }
                else if(chk_flag == "U" && chk_flag != "")
                { 
                    chkSql = @"SELECT 'Y'
        		                     FROM DUAL
        		                    WHERE EXISTS ( SELECT 'X'
        		                                     FROM INP1003 A
        		                                    WHERE A.HOSP_CODE  = :f_hosp_code
                                                      AND A.BUNHO      = :f_bunho
        		                                      AND A.RESER_DATE = TO_DATE(:f_reser_date,'YYYY/MM/DD')
        		                                      AND A.RESER_END_TYPE = '0' 
        		                                      AND A.PKINP1003 != :f_pkinp1003 )";
                    bindChk.Clear();
                    bindChk.Add("f_hosp_code", i_item.BindVarList["f_hosp_code"].ToString());
                    bindChk.Add("f_bunho", i_item.BindVarList["f_bunho"].ToString());
                    bindChk.Add("f_reser_date", i_item.BindVarList["f_reser_date"].ToString());
                    bindChk.Add("f_pkinp1003", i_item.BindVarList["f_pkinp1003"].ToString());

                    object rtn_value = Service.ExecuteScalar(chkSql, bindChk);
                    if (rtn_value != null && !rtn_value.ToString().Equals("Y"))
                    {
                        XMessageBox.Show("既に登録されている入院予約データがあります。");
                        return false;
                    }
                }

                if (chk_flag == "U" && chk_flag != "")
                {
                    /*JUNPYO_DATE NULL체크*/
                    if (i_item.BindVarList["f_junpyo_date"].ValueLen == 0)
                    {
                        XMessageBox.Show("伝票日付がありません。");
                        return false;
                    }

                }
               return true;
            }

            /*
         * 목적     : OUT0101환자 마스터로 환자번호 VALIDATION CHECK
         * 입력     : BUNHO
         * 출력     : RETURN VALUE 0:정상, 1:정상아님, O_MSG(에러 메세지)
         */
            public int INP1003ChkBunho(string i_bunho)
            {
                int rtn_service = 0;
                BindVarCollection bindVar = new BindVarCollection();

                string strSql = @"SELECT NVL(A.DELETE_YN, 'N')     DELETE_YN
                                       , NVL(A.JUBSU_BREAK, 'N')   JUBSU_BREAK
                                       , FN_BAS_LOAD_CODE_NAME('JUBSU_BREAK_REASON', A.JUBSU_BREAK_REASON) CODE_NAME
                                    FROM OUT0101 A
                                   WHERE A.HOSP_CODE = :f_hosp_code
                                     AND A.BUNHO     = :f_bunho";
                bindVar.Add("f_hosp_code", parent.mHospCode);
                bindVar.Add("f_bunho", i_bunho);
                DataTable dtBunho = Service.ExecuteDataTable(strSql, bindVar);

                if (dtBunho.Rows.Count == 0)
                {
                    XMessageBox.Show("患者情報がありません。");
                    rtn_service = 1;

                }
                else
                {
                    if (dtBunho.Rows[0]["delete_yn"].ToString() == "Y")
                    {
                        XMessageBox.Show("削除した患者番号です。番号を確認してください");
                        rtn_service = 1;
                    }
                    if (dtBunho.Rows[0]["jubsu_break"].ToString() == "Y")
                    {
                        XMessageBox.Show(dtBunho.Rows[0]["CODE_NAME"].ToString() + "によって受付が制限されました。");
                        rtn_service = 1;
                    }
                }
                return rtn_service;
            }
            /*
         * 목적     : 재원중인지 여부 체크
         * 입력     : BUNHO, IPWON_DATE
         * 출력     : RETURN VALUE 0:정상, 1:재원중, O_MSG(에러 메세지), PKINP1001, JAEWON_FLAG
         */

            public  int INP1003CheckJaewon(string i_bunho, string i_ipwon_date)
            {
                int rtn_service = 0;
                BindVarCollection bindInp1003 = new BindVarCollection();
                string strSql = @"SELECT A.PKINP1001
	                                   , A.JAEWON_FLAG 
	                                FROM INP1001 A
	                               WHERE A.HOSP_CODE   = :f_hosp_code
                                     AND A.BUNHO       = :f_bunho
	                                 AND A.JAEWON_FLAG = 'Y'
	                                 AND NVL(A.CANCEL_YN, 'N') = 'N'
	                                 AND A.IPWON_DATE <= NVL(:f_ipwon_date , TRUNC(SYSDATE))
	                               ORDER BY A.IPWON_DATE";


                bindInp1003.Add("f_hosp_code", parent.mHospCode);
                bindInp1003.Add("f_bunho", i_bunho);
                bindInp1003.Add("f_ipwon_date", i_ipwon_date);

                DataTable dtResult = Service.ExecuteDataTable(strSql, bindInp1003);
                if (dtResult.Rows.Count == 0)
                {
                    rtn_service = 1;
                }

                bindInp1003.Clear();
                return rtn_service;
            }
            #endregion 
        }
        #endregion

        private void fwkGwa_QueryStarting(object sender, CancelEventArgs e)
        {
            this.fwkGwa.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.fwkGwa.SetBindVarValue("f_buseo_ymd", this.grdInpReser.GetItemString(this.grdInpReser.CurrentRowNumber, "reser_date"));
        }

        private void grdInpReser_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdInpReser.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdInpReser.SetBindVarValue("f_reser_date",this.dtpInpReserDate.GetDataValue());
            //this.grdInpReser.SetBindVarValue("f_query_gubun",this.cboQueryGubun.GetDataValue());
            this.grdInpReser.SetBindVarValue("f_ho_dong",this.cboHodong.GetDataValue());
        }

        private void btnNUR1001_Click(object sender, EventArgs e)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", grdInpReser.GetItemString(grdInpReser.CurrentRowNumber, "bunho"));

            XScreen.OpenScreenWithParam(this , "NURI", "NUR1001U00", ScreenOpenStyle.PopupSingleFixed, param);
        }
        
    }
}

