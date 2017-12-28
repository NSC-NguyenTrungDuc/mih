#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using System.Media;
#endregion

namespace IHIS.CPLS
{
	/// <summary>
	/// SCANVIEWER에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class SCANVIEWER : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XPanel xPanel4;
        private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XPatientBox paBox;
        private IHIS.Framework.XTabControl tabResult;
        private IHIS.Framework.XPanel panNew;
		private IHIS.Framework.XFlatRadioButton rbResultDate;
        private IHIS.Framework.XFlatRadioButton rbOrderDate;
		private IHIS.Framework.XFlatRadioButton rbJubsuDate;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private XEditGrid grdPaList;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XPanel pnlImage;
        private XPanel pnlImageList;
        private XPictureBox pbxImage;
        private MultiLayout layResultImageList;
        private XEditGridCell xEditGridCell13;
        private XComboItem xComboItem1;
        private XComboItem xComboItem2;
        private MultiLayout layPKOCS;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayout layMakeTabPage;
        private MultiLayout layTabImage;
        private XButton btnRotateR;
        private XButton btnRotateL;
        private XCheckBox cbxZoomer;
        private XPictureBox pbxZoomer;
        private XPanel pnlRight;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem24;
        private MultiLayoutItem multiLayoutItem25;
        private MultiLayoutItem multiLayoutItem26;
        private MultiLayoutItem multiLayoutItem27;
        private MultiLayoutItem multiLayoutItem28;
        private MultiLayoutItem multiLayoutItem29;
        private MultiLayoutItem multiLayoutItem30;
        private MultiLayoutItem multiLayoutItem31;
        private MultiLayoutItem multiLayoutItem32;
        private MultiLayoutItem multiLayoutItem33;
        private MultiLayoutItem multiLayoutItem34;
        private MultiLayoutItem multiLayoutItem35;
        private MultiLayoutItem multiLayoutItem36;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SCANVIEWER()
		{
            try
            {
                // 이 호출은 Windows Form 디자이너에 필요합니다.
                InitializeComponent();
            }
            catch (Exception x)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(x.Message + "---- " + x.StackTrace);
            }

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCANVIEWER));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.rbJubsuDate = new IHIS.Framework.XFlatRadioButton();
            this.rbOrderDate = new IHIS.Framework.XFlatRadioButton();
            this.rbResultDate = new IHIS.Framework.XFlatRadioButton();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdPaList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.panNew = new IHIS.Framework.XPanel();
            this.pnlImage = new IHIS.Framework.XPanel();
            this.btnRotateL = new IHIS.Framework.XButton();
            this.btnRotateR = new IHIS.Framework.XButton();
            this.pbxImage = new IHIS.Framework.XPictureBox();
            this.pnlRight = new IHIS.Framework.XPanel();
            this.pbxZoomer = new IHIS.Framework.XPictureBox();
            this.pnlImageList = new IHIS.Framework.XPanel();
            this.tabResult = new IHIS.Framework.XTabControl();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.cbxZoomer = new IHIS.Framework.XCheckBox();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.layResultImageList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
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
            this.layPKOCS = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.layMakeTabPage = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.layTabImage = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaList)).BeginInit();
            this.xPanel3.SuspendLayout();
            this.panNew.SuspendLayout();
            this.pnlImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).BeginInit();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxZoomer)).BeginInit();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layResultImageList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPKOCS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layMakeTabPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTabImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.rbJubsuDate);
            this.xPanel1.Controls.Add(this.rbOrderDate);
            this.xPanel1.Controls.Add(this.rbResultDate);
            this.xPanel1.Controls.Add(this.paBox);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(5, 5);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.xPanel1.Size = new System.Drawing.Size(1245, 35);
            this.xPanel1.TabIndex = 0;
            // 
            // rbJubsuDate
            // 
            this.rbJubsuDate.Checked = true;
            this.rbJubsuDate.ForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.rbJubsuDate.Location = new System.Drawing.Point(76, 6);
            this.rbJubsuDate.Name = "rbJubsuDate";
            this.rbJubsuDate.Size = new System.Drawing.Size(64, 24);
            this.rbJubsuDate.TabIndex = 270;
            this.rbJubsuDate.TabStop = true;
            this.rbJubsuDate.Text = "実施日";
            this.rbJubsuDate.UseVisualStyleBackColor = false;
            this.rbJubsuDate.CheckedChanged += new System.EventHandler(this.rbDate_CheckedChanged);
            // 
            // rbOrderDate
            // 
            this.rbOrderDate.ForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.rbOrderDate.Location = new System.Drawing.Point(6, 6);
            this.rbOrderDate.Name = "rbOrderDate";
            this.rbOrderDate.Size = new System.Drawing.Size(68, 24);
            this.rbOrderDate.TabIndex = 269;
            this.rbOrderDate.Text = "オーダ日";
            this.rbOrderDate.UseVisualStyleBackColor = false;
            this.rbOrderDate.CheckedChanged += new System.EventHandler(this.rbDate_CheckedChanged);
            // 
            // rbResultDate
            // 
            this.rbResultDate.ForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.rbResultDate.Location = new System.Drawing.Point(140, 6);
            this.rbResultDate.Name = "rbResultDate";
            this.rbResultDate.Size = new System.Drawing.Size(64, 24);
            this.rbResultDate.TabIndex = 268;
            this.rbResultDate.Text = "結果日";
            this.rbResultDate.UseVisualStyleBackColor = false;
            this.rbResultDate.CheckedChanged += new System.EventHandler(this.rbDate_CheckedChanged);
            // 
            // paBox
            // 
            this.paBox.BoxType = IHIS.Framework.PatientBoxType.NormalDetail;
            this.paBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.paBox.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paBox.Location = new System.Drawing.Point(210, 2);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 4);
            this.paBox.Size = new System.Drawing.Size(1031, 29);
            this.paBox.TabIndex = 0;
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.grdPaList);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(5, 40);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Padding = new System.Windows.Forms.Padding(2);
            this.xPanel2.Size = new System.Drawing.Size(307, 704);
            this.xPanel2.TabIndex = 0;
            // 
            // grdPaList
            // 
            this.grdPaList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell13});
            this.grdPaList.ColPerLine = 4;
            this.grdPaList.Cols = 5;
            this.grdPaList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPaList.FixedCols = 1;
            this.grdPaList.FixedRows = 1;
            this.grdPaList.HeaderHeights.Add(47);
            this.grdPaList.Location = new System.Drawing.Point(2, 2);
            this.grdPaList.Name = "grdPaList";
            this.grdPaList.QuerySQL = resources.GetString("grdPaList.QuerySQL");
            this.grdPaList.RowHeaderVisible = true;
            this.grdPaList.Rows = 2;
            this.grdPaList.Size = new System.Drawing.Size(301, 698);
            this.grdPaList.TabIndex = 0;
            this.grdPaList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPaList_QueryStarting);
            this.grdPaList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdPaList_RowFocusChanged);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "date";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell7.Col = 1;
            this.xEditGridCell7.HeaderText = "日付";
            this.xEditGridCell7.IsReadOnly = true;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "gwa";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "gwa_name";
            this.xEditGridCell9.CellWidth = 60;
            this.xEditGridCell9.Col = 3;
            this.xEditGridCell9.HeaderText = "診療科";
            this.xEditGridCell9.IsReadOnly = true;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "doctor";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "doctor_name";
            this.xEditGridCell11.CellWidth = 100;
            this.xEditGridCell11.Col = 4;
            this.xEditGridCell11.HeaderText = "診療医";
            this.xEditGridCell11.IsReadOnly = true;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "io_gubun";
            this.xEditGridCell13.CellWidth = 18;
            this.xEditGridCell13.Col = 2;
            this.xEditGridCell13.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2});
            this.xEditGridCell13.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell13.HeaderText = "外\r\n ･\r\n入";
            this.xEditGridCell13.IsReadOnly = true;
            // 
            // xComboItem1
            // 
            this.xComboItem1.DisplayItem = "入";
            this.xComboItem1.ValueItem = "I";
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = "外";
            this.xComboItem2.ValueItem = "O";
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.panNew);
            this.xPanel3.Controls.Add(this.tabResult);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Location = new System.Drawing.Point(312, 40);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Padding = new System.Windows.Forms.Padding(2);
            this.xPanel3.Size = new System.Drawing.Size(938, 704);
            this.xPanel3.TabIndex = 0;
            // 
            // panNew
            // 
            this.panNew.Controls.Add(this.pnlImage);
            this.panNew.Controls.Add(this.pnlRight);
            this.panNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panNew.Location = new System.Drawing.Point(2, 27);
            this.panNew.Name = "panNew";
            this.panNew.Size = new System.Drawing.Size(932, 673);
            this.panNew.TabIndex = 4;
            // 
            // pnlImage
            // 
            this.pnlImage.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.WhiteSmoke);
            this.pnlImage.Controls.Add(this.btnRotateL);
            this.pnlImage.Controls.Add(this.btnRotateR);
            this.pnlImage.Controls.Add(this.pbxImage);
            this.pnlImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImage.Location = new System.Drawing.Point(0, 0);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(495, 673);
            this.pnlImage.TabIndex = 0;
            // 
            // btnRotateL
            // 
            this.btnRotateL.Image = global::IHIS.CPLS.Properties.Resources.로테이트;
            this.btnRotateL.Location = new System.Drawing.Point(30, 724);
            this.btnRotateL.Name = "btnRotateL";
            this.btnRotateL.Size = new System.Drawing.Size(27, 23);
            this.btnRotateL.TabIndex = 2;
            this.btnRotateL.Click += new System.EventHandler(this.btnRotateL_Click);
            // 
            // btnRotateR
            // 
            this.btnRotateR.Image = global::IHIS.CPLS.Properties.Resources.로테이트2;
            this.btnRotateR.Location = new System.Drawing.Point(3, 724);
            this.btnRotateR.Name = "btnRotateR";
            this.btnRotateR.Size = new System.Drawing.Size(27, 23);
            this.btnRotateR.TabIndex = 1;
            this.btnRotateR.Click += new System.EventHandler(this.btnRotateR_Click);
            // 
            // pbxImage
            // 
            this.pbxImage.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.pbxImage.Location = new System.Drawing.Point(0, 0);
            this.pbxImage.Name = "pbxImage";
            this.pbxImage.Padding = new System.Windows.Forms.Padding(2);
            this.pbxImage.Protect = false;
            this.pbxImage.Size = new System.Drawing.Size(54, 43);
            this.pbxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxImage.TabIndex = 0;
            this.pbxImage.TabStop = false;
            this.pbxImage.DoubleClick += new System.EventHandler(this.pbxImage_DoubleClick);
            this.pbxImage.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pbxImage_MouseWheel);
            this.pbxImage.MouseLeave += new System.EventHandler(this.pbxImage_MouseLeave);
            this.pbxImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbxImage_MouseMove);
            this.pbxImage.MouseEnter += new System.EventHandler(this.pbxImage_MouseEnter);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pbxZoomer);
            this.pnlRight.Controls.Add(this.pnlImageList);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(495, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(437, 673);
            this.pnlRight.TabIndex = 2;
            // 
            // pbxZoomer
            // 
            this.pbxZoomer.BackColor = IHIS.Framework.XColor.XMonthCalendarBackColor;
            this.pbxZoomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxZoomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxZoomer.Location = new System.Drawing.Point(0, 0);
            this.pbxZoomer.Name = "pbxZoomer";
            this.pbxZoomer.Protect = false;
            this.pbxZoomer.Size = new System.Drawing.Size(437, 673);
            this.pbxZoomer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxZoomer.TabIndex = 0;
            this.pbxZoomer.TabStop = false;
            this.pbxZoomer.Visible = false;
            // 
            // pnlImageList
            // 
            this.pnlImageList.AutoScroll = true;
            this.pnlImageList.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.White);
            this.pnlImageList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlImageList.BorderColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.pnlImageList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlImageList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImageList.Location = new System.Drawing.Point(0, 0);
            this.pnlImageList.Name = "pnlImageList";
            this.pnlImageList.Size = new System.Drawing.Size(437, 673);
            this.pnlImageList.TabIndex = 1;
            // 
            // tabResult
            // 
            this.tabResult.ButtonActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabResult.ButtonInactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabResult.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabResult.IDEPixelArea = true;
            this.tabResult.IDEPixelBorder = false;
            this.tabResult.ImageList = this.ImageList;
            this.tabResult.Location = new System.Drawing.Point(2, 2);
            this.tabResult.Name = "tabResult";
            this.tabResult.ShowClose = false;
            this.tabResult.Size = new System.Drawing.Size(932, 25);
            this.tabResult.TabIndex = 0;
            this.tabResult.TextColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabResult.SelectionChanged += new System.EventHandler(this.tabResult_SelectionChanged);
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.cbxZoomer);
            this.xPanel4.Controls.Add(this.xButtonList1);
            this.xPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel4.DrawBorder = true;
            this.xPanel4.Location = new System.Drawing.Point(5, 744);
            this.xPanel4.Name = "xPanel4";
            this.xPanel4.Size = new System.Drawing.Size(1245, 36);
            this.xPanel4.TabIndex = 0;
            // 
            // cbxZoomer
            // 
            this.cbxZoomer.AutoSize = true;
            this.cbxZoomer.Checked = true;
            this.cbxZoomer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxZoomer.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.cbxZoomer.Location = new System.Drawing.Point(5, 8);
            this.cbxZoomer.Name = "cbxZoomer";
            this.cbxZoomer.Size = new System.Drawing.Size(98, 19);
            this.cbxZoomer.TabIndex = 1;
            this.cbxZoomer.Text = "拡大鏡使用";
            this.cbxZoomer.UseVisualStyleBackColor = false;
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.xButtonList1.Dock = System.Windows.Forms.DockStyle.Right;
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Location = new System.Drawing.Point(1080, 0);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.xButtonList1.Size = new System.Drawing.Size(163, 34);
            this.xButtonList1.TabIndex = 0;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "bunho";
            this.xEditGridCell1.Col = 2;
            this.xEditGridCell1.HeaderText = "bunho";
            this.xEditGridCell1.IsReadOnly = true;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "hangmog_code";
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.HeaderText = "hangmog_code";
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "hangmog_name";
            this.xEditGridCell3.HeaderText = "hangmog_name";
            this.xEditGridCell3.IsReadOnly = true;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "gubun";
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.HeaderText = "gubun";
            this.xEditGridCell5.IsReadOnly = true;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "base_date";
            this.xEditGridCell6.Col = 5;
            this.xEditGridCell6.HeaderText = "base_date";
            this.xEditGridCell6.IsReadOnly = true;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "dummy";
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.HeaderText = "dummy";
            this.xEditGridCell4.IsReadOnly = true;
            // 
            // layResultImageList
            // 
            this.layResultImageList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
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
            this.multiLayoutItem36});
            this.layResultImageList.QuerySQL = resources.GetString("layResultImageList.QuerySQL");
            this.layResultImageList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layResultImageList_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "pkscan";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "in_out_gubun";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "fkocs";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "system";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "cr_time";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "jundal_part";
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "image_path";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "image";
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "seq";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "order_date";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "acting_date";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "result_date";
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "hangmog_code";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "hangmog_name";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "specimen_code";
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "specimen_name";
            // 
            // layPKOCS
            // 
            this.layPKOCS.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem10});
            this.layPKOCS.QuerySQL = resources.GetString("layPKOCS.QuerySQL");
            this.layPKOCS.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layPKOCS_QueryStarting);
            this.layPKOCS.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layPKOCS_QueryEnd);
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "pkocs";
            // 
            // layMakeTabPage
            // 
            this.layMakeTabPage.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem2,
            this.multiLayoutItem5,
            this.multiLayoutItem6});
            this.layMakeTabPage.QuerySQL = resources.GetString("layMakeTabPage.QuerySQL");
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "jundal_table";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "jundal_part";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "tab_name";
            // 
            // layTabImage
            // 
            this.layTabImage.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem3,
            this.multiLayoutItem4});
            this.layTabImage.QuerySQL = resources.GetString("layTabImage.QuerySQL");
            this.layTabImage.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layTabImage_QueryStarting);
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "jundal_table";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "jundal_part";
            // 
            // SCANVIEWER
            // 
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel4);
            this.Name = "SCANVIEWER";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1255, 785);
            this.Activated += new System.EventHandler(this.SCANVIEWER_Activated);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.SCANVIEWER_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPaList)).EndInit();
            this.xPanel3.ResumeLayout(false);
            this.panNew.ResumeLayout(false);
            this.pnlImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).EndInit();
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxZoomer)).EndInit();
            this.xPanel4.ResumeLayout(false);
            this.xPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layResultImageList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPKOCS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layMakeTabPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTabImage)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Query:

					e.IsBaseCall = false;

                    this.grdPaList.QueryLayout(false);

					paBox.Focus();

					break;
				case FunctionType.Reset:
					e.IsBaseCall = false;
					break;
				default:
					break;				
			}
		}



		#region 스크린 오픈
		private void SCANVIEWER_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
            MakeTabPage();

			if (e.OpenParam != null )
			{
				paBox.SetPatientID(e.OpenParam["bunho"].ToString());
			}
			else
			{
				// 이전 스크린의 등록번호를 가져온다
				XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);

				if (patientInfo == null || (patientInfo != null && TypeCheck.IsNull(patientInfo.BunHo)))
				{
					// 이전 스크린의 등록번호를 못가지고 온 경우, 열려있는 전체 스크린에서 등록번호를 가져온다
					patientInfo = XScreen.GetOtherScreenBunHo(this, true);
				}

				if (patientInfo != null && !TypeCheck.IsNull(patientInfo.BunHo))
				{
					this.paBox.Focus();
					this.paBox.SetPatientID(patientInfo.BunHo);
				}
				else
				{
					//paBox.SetPatientID("000400032");
				}
			}
            //this.grdPaList.QueryLayout(false);
			paBox.Focus();
		}
		#endregion

    

		#region 환자박스 환자선택 후
		private void paBox_PatientSelected(object sender, System.EventArgs e)
        {
            this.grdPaList.QueryLayout(false);
		}
		#endregion

		#region [환자정보 Reques/Receive Event]
		/// <summary>
		/// Docking Screen에서 환자정보 변경시 Raise
		/// </summary>
		public override void OnReceiveBunHo(XPatientInfo info)
		{
			if (info != null && !TypeCheck.IsNull(info.BunHo))
			{
				this.paBox.Focus();
				this.paBox.SetPatientID(info.BunHo);
			}
		}

		/// <summary>
		/// 현Screen의 등록번호를 타Screen에 넘긴다
		/// </summary>
		public override XPatientInfo OnRequestBunHo()
		{
			if (!TypeCheck.IsNull(this.paBox.BunHo))
			{
				return new XPatientInfo(this.paBox.BunHo, "", "", "", this.ScreenName);
			}

			return null;
		}
		#endregion 


		private int set_tab_flag = 0; // 0-> 모두 조회 1->필터조회
		private void tabResult_SelectionChanged(object sender, System.EventArgs e)
        {
            LoadResult();
		}	

		#region 탭페이지 생성
		private void MakeTabPage()
		{
			bool isExists = false;
            this.layMakeTabPage.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layMakeTabPage.QueryLayout(true);

			// 텝 페이지 생성시 첫번째 페이지가 선택된것으로 간주된다.
			// 따라서 전체조회가 되므로 잠시 이벤트를 없애놓음
			this.tabResult.SelectionChanged -= new System.EventHandler(this.tabResult_SelectionChanged);

            //이상하게 HashTable 쓰면 나중에 조회가 안됨... 우선은 스트링으로 넣자.
            string tabTag = "";
			// 텝 페이지 생성
            for (int i = 0; i < layMakeTabPage.RowCount; i++)
            {
                IHIS.X.Magic.Controls.TabPage tabPage =
                    new IHIS.X.Magic.Controls.TabPage("[ "+ layMakeTabPage.GetItemString(i, "tab_name") + " ]");

                tabTag = "";
                tabTag = layMakeTabPage.GetItemString(i, "jundal_table") +"/"+ layMakeTabPage.GetItemString(i, "jundal_part");

                tabPage.Tag = tabTag;
                tabPage.ImageList = this.ImageList;

                foreach (IHIS.X.Magic.Controls.TabPage mtab in tabResult.TabPages)
                {
                    if (tabPage.Title == mtab.Title)
                    {
                        isExists = true;
                        break;
                    }
                }
                if (!isExists) tabResult.TabPages.Add(tabPage);
            }

			this.tabResult.SelectionChanged += new System.EventHandler(this.tabResult_SelectionChanged);
		}
		#endregion        

        private void ChangeTabImage()
        {
            this.layTabImage.QueryLayout(true);

            foreach (IHIS.X.Magic.Controls.TabPage tPage in this.tabResult.TabPages)
            {
                tPage.ImageIndex = 1; // 체크풀기
                string tabTag = "";
                for(int i = 0 ; i <this.layTabImage.RowCount ; i++)
                {
                    tabTag = "";
                    tabTag = tPage.Tag.ToString();
                    string[] tags = tabTag.Split('/');

                    if (this.layTabImage.GetItemString(i, "jundal_table") == tags.GetValue(0).ToString() &&
                        this.layTabImage.GetItemString(i, "jundal_part") == tags.GetValue(1).ToString())
                    {
                        tPage.ImageIndex = 0; // 체크
                        break;
                    }
                }
            }
        }

		private void SCANVIEWER_Activated(object sender, System.EventArgs e)
		{
			paBox.Focus();
		}

        #region ImageItem (Image 편집후 저장시 사용할 class, Cell의 Tag와 PictureBox의 Tag에 저장하였다가 이미지 편집후 저장처리함)
        internal class ImageItem
        {
            public PictureBox PBox = null;      //Image가 있는 PictureBox
            public XCell Cell = null;      //Image가 있는 Cell
            public Image Image = null;      //Image
            public string ClientFileName = "";  //Client File Name 
            public string ServerFileName = "";  //Server File Name
            public string ClientFilePath = "";  //Client의 파일 Path
            public string ServerFilePath = "";  //Server에 저장된 File Path
            public string CheckYn = "";         //결과조회에 보여주어야하는지의 여부
            /********************************************************/
            public string Seq = "";             //서버에 저장된 seq순번

            public string JundalPart = "";
            public string JundalPartName = "";
            public string HangmogCode = "";
            public string HangmogName = "";

            public string OrderDate = "";
            public string ActingDate = "";
            public string ResultDate = "";

            public ImageItem() { }
        }
        #endregion        

        private void grdPaList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdPaList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdPaList.SetBindVarValue("f_bunho", this.paBox.BunHo);

            if(this.rbOrderDate.Checked)
                this.grdPaList.SetBindVarValue("f_gubun", "1");
            else if (this.rbJubsuDate.Checked)
                this.grdPaList.SetBindVarValue("f_gubun", "2");
            else if (this.rbResultDate.Checked)
                this.grdPaList.SetBindVarValue("f_gubun", "3");
        }

        private void rbDate_CheckedChanged(object sender, EventArgs e)
        {
            this.grdPaList.QueryLayout(false);
        }

        private void grdPaList_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            ChangeTabImage();
            this.tabResult.SelectionChanged -= new System.EventHandler(this.tabResult_SelectionChanged);
            this.tabResult.SelectedIndex = 0;
            this.tabResult.SelectionChanged += new System.EventHandler(this.tabResult_SelectionChanged);
            LoadResult();
        }

        #region 검사 결과 Load (결과 Image)
        private ImageItem currentImageItem = null;  //현재 선택된 ImageItem
        private ArrayList ImageItemList = new ArrayList(); //Dicom Image의 ImageItem 관리 List

        private void LoadResult()
        {       
            try
            {
                //결과 이미지 조회, 성공시 Grid에 Image Set
                this.pbxImage.Image = null;
                this.currentImageItem = null; //Clear
                this.ImageItemList.Clear();
                
                ArrayList imageFileInfoList = new ArrayList();  //Total ImageFileInfo List
                ArrayList downloadFileInfoList = new ArrayList();  //다운로드할 ImageInfo의 List (ImageInfo 관리)

                string imagePath = ImageHelper.GetImageRoot();
                ImageFileInfo info = null;

                if (this.layResultImageList.QueryLayout(true))
                {
                    foreach (DataRow dtRow in this.layResultImageList.LayoutTable.Rows)
                    {
                        //2006.03.15 이미지 다운로드 규칙( 파일존재여부와 서버 생성시간과 비교하여 처리함)
                        info = new ImageFileInfo(imagePath, dtRow["image_path"].ToString(), dtRow["image"].ToString(), dtRow["image"].ToString());

                        //다운로드할 파일이면 다운로드 리스트에 Add
                        if (ImageHelper.IsFileDownload(imagePath + "\\" + dtRow["image"].ToString(), DateTime.Parse(dtRow["cr_time"].ToString())))
                        {
                            downloadFileInfoList.Add(info);
                        }
                        //이미지 List 에 Add
                        imageFileInfoList.Add(info);
                    }
                }
                //Download Image
                ImageItem imgItem = null;

                if (ImageHelper.DownloadImages(downloadFileInfoList, false))
                {
                    int rowNum = 0;
                    foreach (ImageFileInfo fInfo in imageFileInfoList)
                    {
                        imgItem = new ImageItem();
                        //Image는 ImageHelper를 통해서 가져옴. 바로 Image.FromFile을 하면 File사용해제가 안되서 Upload처리하지 못함
                        //기준정보 Image와 결과 Image를 같은 Dir에서 관리한다고 가정하고 처리함.
                        //다른 Server Dir에 관리한다면 다르게 처리해야함
                        imgItem.Image = ImageHelper.GetImage(fInfo.ClientPath + "\\" + fInfo.ClientFileName);
                        imgItem.ClientFilePath = fInfo.ClientPath;
                        imgItem.ClientFileName = fInfo.ClientFileName;
                        imgItem.ServerFilePath = fInfo.ServerPath;
                        /********************************************************************/
                        //imgItem.Seq = fInfo.Seq;
                        //imgItem.PBox = this.pbxImage;

                        imgItem.JundalPart = this.layResultImageList.GetItemString(rowNum, "jundal_part");
                        //imgItem.JundalPartName = this.layResultImageList.GetItemString(rowNum, "jundal_part");
                        imgItem.HangmogCode = this.layResultImageList.GetItemString(rowNum, "hangmog_code");
                        imgItem.HangmogName = this.layResultImageList.GetItemString(rowNum, "hangmog_name");
                        imgItem.OrderDate = this.layResultImageList.GetItemString(rowNum, "order_date");
                        imgItem.ActingDate = this.layResultImageList.GetItemString(rowNum, "acting_date");
                        imgItem.ResultDate = this.layResultImageList.GetItemString(rowNum, "result_date");

                        this.ImageItemList.Add(imgItem);
                        rowNum++;
                    }
                }
                //Image 배치하기
                ArrangeDicomImages();
            }
            catch (Exception xe)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show("結果照会エラー[" + xe.Message + "]");
            }
        }

        #endregion

        #region ArrangeDicomImages : Dicom Image 정렬하기

        //Dicom Image Control 설정하기, Label과 PictureBox를 한행에 두줄씩 배열하기
        const int PBOX_WIDTH = 70; //PictureBox Width (640*480 비율로 관리)
        const int PBOX_HEIGHT = 100; //PictureBox Height
        const int LABEL_WIDTH = 140;  //Label Width
        const int LABEL_HEIGHT = 15;  //Label Height
        const int MARGIN = 5;      // Picture Box 사이의 간격
        const int COUNT_PER_ROW = 2;  //한 행의 이미지 박스의 갯수 2
        private void ArrangeDicomImages()
        {
            this.SuspendLayout();  //그리기 일시 중지
            int count = 0, mod = 0, X = 0, Y = 0;

            Label label_part = null;
            Label label_hangmog = null;
            Label label_hangmog_name = null;
            Label label_order_date = null;
            Label label_acting_date = null;
            Label label_result_date = null;

            XPictureBox pBox = null;
            this.pnlImageList.Controls.Clear();

            //맨 앞에 있는 Item 부터 해서 한행에 2개씩 자리잡도록 함. DisplayImages와 같은 Logic 적용함
            foreach (ImageItem item in this.ImageItemList)
            {
                label_part = new Label();
                label_part.Name = "lblPart" + count.ToString();
                label_part.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
                label_part.Text = (count + 1).ToString() + ". " + item.JundalPart;
                label_part.BackColor = Color.AliceBlue;

                label_hangmog = new Label();
                label_hangmog.Name = "lblHangmog" + count.ToString();
                label_hangmog.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
                label_hangmog.Text = item.HangmogCode;
                label_hangmog.BackColor = Color.MintCream;

                label_hangmog_name = new Label();
                label_hangmog_name.Name = "lblHangmogName" + count.ToString();
                label_hangmog_name.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
                label_hangmog_name.Text = item.HangmogName;
                label_hangmog_name.BackColor = Color.AliceBlue;

                label_order_date = new Label();
                label_order_date.Name = "lblOrderDate" + count.ToString();
                label_order_date.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
                label_order_date.Text = " オ: " + item.OrderDate;
                label_order_date.BackColor = Color.MintCream;

                label_acting_date = new Label();
                label_acting_date.Name = "lblActingDate" + count.ToString();
                label_acting_date.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
                label_acting_date.Text = "実: " + item.ActingDate;
                label_acting_date.BackColor = Color.AliceBlue;

                label_result_date = new Label();
                label_result_date.Name = "lblResultDate" + count.ToString();
                label_result_date.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
                label_result_date.Text = "結: " + item.ResultDate;
                label_result_date.BackColor = Color.MintCream;

                pBox = new XPictureBox();
                pBox.Name = "pbx" + count.ToString();
                pBox.Image = item.Image;
                pBox.Size = new Size(PBOX_WIDTH, PBOX_HEIGHT);
                pBox.BorderStyle = BorderStyle.FixedSingle;
                pBox.SizeMode = PictureBoxSizeMode.StretchImage;  //큰 이미지를 pBox에 보여줌
                pBox.Click += new EventHandler(OnPictureBoxClick);  //Click Event 연결 (현재 ImageItem Set)
                pBox.DoubleClick += new EventHandler(OnPictureBoxDoubleClick);  //Click Event 연결 (큰사이즈 이미지)
                pBox.Padding = new Padding(3);
                pBox.BackColor = new XColor(Color.Transparent);
                pBox.Tag = item;  //Tag에 ImageItem 관리

                //mod = count % COUNT_PER_ROW;
                //X = MARGIN * (mod + 1) + PBOX_WIDTH * mod;  //맨처음은 Margin을 주고 다음은 PBOX_WIDTH + MARGIN으로 띄움
                //Y = (count / COUNT_PER_ROW) * (LABEL_HEIGHT + PBOX_HEIGHT);

                mod = count % COUNT_PER_ROW;
                X = MARGIN * (mod + 1) + PBOX_WIDTH * mod + LABEL_WIDTH * mod;  //맨처음은 Margin을 주고 다음은 PBOX_WIDTH + MARGIN으로 띄움
                Y = (count / COUNT_PER_ROW) * (MARGIN + PBOX_HEIGHT);

                //Label를 시작위치에, pBOX를 Label아래에 배치함.
                //pBox.Location = new Point(X, Y + LABEL_HEIGHT);
                pBox.Location = new Point(X, Y + MARGIN);

                label_part.Location = new Point(X + PBOX_WIDTH, Y + MARGIN);
                label_hangmog.Location = new Point(X + PBOX_WIDTH, Y + MARGIN + LABEL_HEIGHT);
                label_hangmog_name.Location = new Point(X + PBOX_WIDTH, Y + MARGIN + LABEL_HEIGHT * 2);
                label_order_date.Location = new Point(X + PBOX_WIDTH, Y + MARGIN + LABEL_HEIGHT * 3);
                label_acting_date.Location = new Point(X + PBOX_WIDTH, Y + MARGIN + LABEL_HEIGHT * 4);
                label_result_date.Location = new Point(X + PBOX_WIDTH, Y + MARGIN + LABEL_HEIGHT * 5);

                //checkbox 처리
                //Item의 PBox 설정
                item.PBox = pBox;

                //pnlImageList에 Add
                pnlImageList.Controls.Add(pBox);
                pnlImageList.Controls.Add(label_part);
                pnlImageList.Controls.Add(label_hangmog);
                pnlImageList.Controls.Add(label_hangmog_name);
                pnlImageList.Controls.Add(label_order_date);
                pnlImageList.Controls.Add(label_acting_date);
                pnlImageList.Controls.Add(label_result_date);
                count++;
            }
            this.ResumeLayout(true);

            //foreach (Control control in pnlImageList.Controls)
            //{
            //    if (control.Name.IndexOf("pbx") >= 0)
            //    {
            //        OnPictureBoxClick((XPictureBox)control, new EventArgs());
            //        return;
            //    }
            //}
        }

        private void OnPictureBoxClick(object sender, System.EventArgs e)
        {
            //XMessageBox.Show("OnPictureBoxClick_start");

            foreach (Control control in this.pnlImageList.Controls)
            {
                if (control.Name.IndexOf("pbx") >=0)
                {
                    XPictureBox pbBox = control as XPictureBox;
                    pbBox.BackColor = new XColor(Color.Transparent);
                }
            }
            //Tag에 저장된 ImageItem을 현재 ImageItem으로 SET
            XPictureBox selectedPBox = sender as XPictureBox;
            //pbBox.BorderStyle = BorderStyle.Fixed3D;
            selectedPBox.BackColor = new XColor(Color.Blue);

            this.currentImageItem = ((Control)sender).Tag as ImageItem;
            this.pbxImage.ResetData();

            //this.pbxImage.SizeMode = PictureBoxSizeMode.Zoom;
            //this.pbxImage.SizeMode = PictureBoxSizeMode.AutoSize;

            //XMessageBox.Show(this.pbxImage.Height.ToString() + ", " + this.pbxImage.Width.ToString());
            Size newSize = GetNewPicSize(this.currentImageItem.Image.Size, this.pnlImage.Size);

            this.pbxImage.Height = newSize.Height;
            this.pbxImage.Width = newSize.Width;
            this.pbxImage.Image = currentImageItem.Image;

            SetNewLocationImage();


            this.pbxImage.Refresh();

            //XMessageBox.Show("OnPictureBoxClick_end");
        }

        private void OnPictureBoxDoubleClick(object sender, System.EventArgs e)
        {
            this.currentImageItem = ((Control)sender).Tag as ImageItem;
            BigSizeViewer bigViewer = new BigSizeViewer();
            bigViewer.BigImage = this.currentImageItem.Image;
            bigViewer.ShowImage();
            
            bigViewer.Show();
            
            //Size newSize = GetNewPicSize(currentImageItem.Image.Size, bigViewer.Size);

        }

        #endregion

        private void SetNewLocationImage()
        {
            double locationX = (this.pnlImage.Width - this.pbxImage.Width) / 2;
            double locationY = (this.pnlImage.Height - this.pbxImage.Height) / 2;

            this.pbxImage.Location = new Point((int)locationX, (int)locationY);
        }

        private void layResultImageList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layResultImageList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.layResultImageList.SetBindVarValue("f_jundal_table", this.tabResult.SelectedTab.Tag.ToString());
            
            string tabTag = this.tabResult.SelectedTab.Tag.ToString();
            string[] tags = tabTag.Split('/');

            this.layResultImageList.SetBindVarValue("f_jundal_table", tags.GetValue(0).ToString());
            this.layResultImageList.SetBindVarValue("f_jundal_part", tags.GetValue(1).ToString());
            this.layResultImageList.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.layResultImageList.SetBindVarValue("f_date", this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "date"));
            this.layResultImageList.SetBindVarValue("f_doctor", this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "doctor"));

            

            if (this.rbOrderDate.Checked)
                this.layResultImageList.SetBindVarValue("f_gubun", "1");
            else if (this.rbJubsuDate.Checked)
                this.layResultImageList.SetBindVarValue("f_gubun", "2");
            else if (this.rbResultDate.Checked)
                this.layResultImageList.SetBindVarValue("f_gubun", "3");
            //this.layResultImageList.SetBindVarValue("f_fkocs", this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "pkocs"));
        }

        private void layPKOCS_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layPKOCS.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layPKOCS.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.layPKOCS.SetBindVarValue("f_date", this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "date"));

            if (this.rbOrderDate.Checked)
                this.layPKOCS.SetBindVarValue("f_gubun", "1");
            else if (this.rbJubsuDate.Checked)
                this.layPKOCS.SetBindVarValue("f_gubun", "2");
            else if (this.rbResultDate.Checked)
                this.layPKOCS.SetBindVarValue("f_gubun", "3");
        }

        private string mPKOCS = "";
        private void layPKOCS_QueryEnd(object sender, QueryEndEventArgs e)
        {
            mPKOCS = "";
            for (int i = 0; i < this.layPKOCS.RowCount; i++)
            {
                this.mPKOCS += ",'" + this.layPKOCS.GetItemString(i, "pkocs") + "'";
            }

            if (this.mPKOCS != "")
                mPKOCS = mPKOCS.Substring(1);
        }

        private void xButton1_Click(object sender, EventArgs e)
        {
            this.grdPaList.SetFilter("date = 'XX'");

        }

        private void layTabImage_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layTabImage.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layTabImage.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.layTabImage.SetBindVarValue("f_date", this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "date"));

            if (this.rbOrderDate.Checked)
                this.layTabImage.SetBindVarValue("f_gubun", "1");
            else if (this.rbJubsuDate.Checked)
                this.layTabImage.SetBindVarValue("f_gubun", "2");
            else if (this.rbResultDate.Checked)
                this.layTabImage.SetBindVarValue("f_gubun", "3");
        }

        //ImageZoomer iz = null;

        private void pbxImage_MouseEnter(object sender, EventArgs e)
        {

            //XMessageBox.Show("pbxImage_MouseEnter_start");
            if (this.pbxImage.Image != null)
            {
                if (this.cbxZoomer.Checked)
                {
                    //iz = new ImageZoomer();
                    //iz.ZoomImage = this.pbxImage.Image;
                    //iz.Location = new Point(900, 100);
                    //iz.ShowImage();

                    //iz.Show(this);

                    this.pbxZoomer.Visible = true;
                    this.pnlImageList.Visible = false;

                    //"C:\WINDOWS\system32\magnify.exe";
                    //System.Diagnostics.Process.Start(@"C:\WINDOWS\system32\magnify.exe");
                }
            }

            //XMessageBox.Show("pbxImage_MouseEnter_end");

        }

        private void pbxImage_MouseLeave(object sender, EventArgs e)
        {
            //if (iz != null)
            //{
            //    iz.Close();

            //}
            this.pnlImageList.Visible = true;
            this.pbxZoomer.Visible = false;
            this.pbxZoomer.ResetData();
        }

        //int mHeight = 400;
        //int mWidth = 400;

        int mHeight = 500;
        int mWidth = 300;
        int p_height = 0;
        int p_width = 0;
        int startX = 0;
        int startY = 0;

        double newClickPointX = 0f;
        double newClickPointY = 0f;

        private void pbxImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.pbxImage.Image != null)
            {
                p_height = 0;
                p_width = 0;
                startX = 0;
                startY = 0;
                newClickPointX = 0f;
                newClickPointY = 0f;
                //if (iz != null)
                //{
                //숫자가 커질 수록 확대이미지가 작아짐
                p_height = (this.mRatio < 0.4f) ? ((this.mRatio < 0.2f) ? (int)(mHeight * 3.2) : (int)(mHeight * 2.7)) : mHeight;
                p_width = (this.mRatio < 0.4f) ? ((this.mRatio < 0.2f) ? (int)(mWidth * 3.2) : (int)(mWidth * 2.7)) : mWidth;

                startX = (p_height / 2) ;
                startY = (p_width / 2);
                
                newClickPointX = e.X / mRatio;
                newClickPointY = e.Y / mRatio;
                    
                //가로세로 같은 비율이면 미세 조정필요없음
                Image tImage =
                     Crop(this.pbxImage.Image, p_width, p_height, (int)newClickPointX - startX + 110, (int)newClickPointY - startY - 100); 
                //Crop(this.pbxImage.Image, p_width, p_height, (int)newClickPointX - startX, (int)newClickPointY - startY);
                
                //iz.ZoomImage = tImage;
                //iz.Location = new Point(900, 100);
                //iz.ShowImage();
                this.pbxZoomer.ResetData();
                this.pbxZoomer.Image = tImage;
                this.pbxZoomer.Refresh();
                tImage.Dispose();
                    
                //}
            }
        }

        public Image Crop(Image imgPhoto, int Width, int Height, int adjustX, int adjustY)
        {

            //비트맵 종이한장 만들기

            //Bitmap bmPhoto = new Bitmap(Width - adjustX, Height - adjustY);
            Bitmap bmPhoto = new Bitmap(Width, Height);

            //그래픽 이미지 설정

            Graphics grPhoto = Graphics.FromImage(bmPhoto);

            int OriginalWidth = imgPhoto.Width;

            int OriginalHeight = imgPhoto.Height;

            //싹뚝 자르기

            grPhoto.DrawImage(imgPhoto,

                   new Rectangle(0, 0, Width, Height),

                   new Rectangle(adjustX, adjustY, Width, Height),

                   GraphicsUnit.Pixel);

            grPhoto.Dispose();

            return bmPhoto;

        }

        private void btnRotateR_Click(object sender, EventArgs e)
        {
            if (this.pbxImage.Image != null)
            {
                Image tImage = this.pbxImage.Image;
                tImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                this.pbxImage.Image = tImage;

                Size newSize = GetNewPicSize(this.pbxImage.Image.Size, this.pnlImage.Size);

                this.pbxImage.Height = newSize.Height;
                this.pbxImage.Width = newSize.Width;
                
                SetNewLocationImage();
                
                this.pbxImage.Refresh();
            }
        }

        private void btnRotateL_Click(object sender, EventArgs e)
        {
            if (this.pbxImage.Image != null)
            {                
                Image tImage = this.pbxImage.Image;
                tImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                this.pbxImage.Image = tImage;

                Size newSize = GetNewPicSize(this.pbxImage.Image.Size, this.pnlImage.Size);

                this.pbxImage.Height = newSize.Height;
                this.pbxImage.Width = newSize.Width;

                SetNewLocationImage();

                this.pbxImage.Refresh();
            }

        }


        double mRatio = 0f;
        private Size GetNewPicSize(Size orinSize, Size viewerSize)
        {
            double viewerH = (double)viewerSize.Height;
            double viewerW = (double)viewerSize.Width;

            double orginH = (double)orinSize.Height;
            double orginW = (double)orinSize.Width;

            double newH = 0f;
            double newW = 0f;
            //
            mRatio = 1f;
            if (viewerH < orginH)
            {
                mRatio = (viewerH / orginH);
                newH = mRatio * orginH;
                newW = mRatio * orginW; ;
            }
            else
            {
                newH = orginH;
                newW = orginW; ;
            }

            if (viewerW < newW)
            {
                mRatio = (viewerW / newW);
                newW = mRatio * newW;
                newH = mRatio * newH;
            }

            return new Size((int)newW, (int)newH);
        }

        private void pbxImage_DoubleClick(object sender, EventArgs e)
        {
            BigSizeViewer bigViewer = new BigSizeViewer();
            bigViewer.BigImage = this.pbxImage.Image;
            bigViewer.ShowImage();

            bigViewer.Show();

        }

        private void pbxImage_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / 120;

            mHeight = numberOfTextLinesToMove * 380;
            mWidth = numberOfTextLinesToMove * 380;

            pbxImage_MouseMove(sender, e);

        }

        //private void panel1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        //{
        //    // Update the drawing based upon the mouse wheel scrolling.

        //    int numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
        //    int numberOfPixelsToMove = numberOfTextLinesToMove * fontSize;

        //    if (numberOfPixelsToMove != 0)
        //    {
        //        System.Drawing.Drawing2D.Matrix translateMatrix = new System.Drawing.Drawing2D.Matrix();
        //        translateMatrix.Translate(0, numberOfPixelsToMove);
        //        mousePath.Transform(translateMatrix);
        //    }
        //    panel1.Invalidate();
        //}
    }
}

