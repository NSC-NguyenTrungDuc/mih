using System;
using System.Drawing.Printing;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Sybase.DataWindow;

namespace IHIS.Framework
{
	/// <summary>
	/// DataWindowForm에 대한 요약 설명입니다.
	/// </summary>
	internal class DataWindowForm : System.Windows.Forms.Form
	{
		#region Properties
		const string PAGE_COUNT_FIELD_NAME = "cfd_count";
		//프린트의 결과(OK, Error, Cancel)
		private PrintResult result = PrintResult.PrintCancel;
		public PrintResult Result
		{
			get { return result;}
		}
		private bool isPreviewStatus = false; //Preview상태인지여부
		#endregion

		private XDWWorker dwWorker = null;
		private IHIS.Framework.XDataWindow dwCont;
		private IHIS.Framework.XPanel pnlCenter;
		private System.Windows.Forms.Label lbPrinter;
		private System.Windows.Forms.GroupBox gbxRange;
		private System.Windows.Forms.RadioButton rbAll;
		private System.Windows.Forms.RadioButton rbPart;
		private System.Windows.Forms.Label lbStart;
		private System.Windows.Forms.Label lbEnd;
		private System.Windows.Forms.GroupBox gbxDirection;
		private System.Windows.Forms.RadioButton rbPortrait;
		private System.Windows.Forms.RadioButton rbLandScape;
		private System.Windows.Forms.PictureBox pbxImage;
		private System.Windows.Forms.Label lbMag;
		private System.Windows.Forms.GroupBox gbxMag;
		private System.Windows.Forms.GroupBox gbxCount;
		private System.Windows.Forms.Label lbCount;
		private System.Windows.Forms.Label label1;
		private IHIS.Framework.XButton btnPrint;
		private IHIS.Framework.XButton btnClose;
		private IHIS.Framework.XButton btnPreview;
		private System.Windows.Forms.NumericUpDown nupCount;
		private System.Windows.Forms.NumericUpDown nupMag;
		private System.Windows.Forms.NumericUpDown nupStart;
		private System.Windows.Forms.NumericUpDown nupEnd;
		private IHIS.Framework.XComboItem xComboItem1;
		private IHIS.Framework.XComboItem xComboItem2;
		private IHIS.Framework.XComboItem xComboItem3;
		private IHIS.Framework.XComboItem xComboItem4;
		private IHIS.Framework.XComboItem xComboItem5;
		private IHIS.Framework.XComboItem xComboItem6;
		private IHIS.Framework.XComboItem xComboItem7;
		private IHIS.Framework.XComboItem xComboItem8;
		private IHIS.Framework.XComboItem xComboItem9;
		private IHIS.Framework.XComboItem xComboItem10;
		private IHIS.Framework.XComboItem xComboItem11;
		private IHIS.Framework.XComboItem xComboItem12;
		private IHIS.Framework.XComboItem xComboItem13;
		private IHIS.Framework.XComboBox cboPaper;
		private IHIS.Framework.XComboBox cboPrinter;
		private System.Windows.Forms.Label lbPaper;
		private System.Windows.Forms.CheckBox cbxCollate;
		private System.Windows.Forms.Panel pnlZoom;
		private System.Windows.Forms.NumericUpDown nudZoom;
		private IHIS.Framework.XButton btnUp;
		private IHIS.Framework.XButton btnDown;
		private System.Windows.Forms.ToolTip toolTip;
		private System.ComponentModel.IContainer components;

		public DataWindowForm(XDWWorker dwWorker)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();


			this.dwWorker = dwWorker;

			//Text Set
			SetControlTextByLangMode();
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

		#region Windows Form 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DataWindowForm));
			this.dwCont = new IHIS.Framework.XDataWindow();
			this.pnlCenter = new IHIS.Framework.XPanel();
			this.gbxCount = new System.Windows.Forms.GroupBox();
			this.nupCount = new System.Windows.Forms.NumericUpDown();
			this.lbCount = new System.Windows.Forms.Label();
			this.cbxCollate = new System.Windows.Forms.CheckBox();
			this.gbxMag = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.nupMag = new System.Windows.Forms.NumericUpDown();
			this.lbMag = new System.Windows.Forms.Label();
			this.gbxDirection = new System.Windows.Forms.GroupBox();
			this.pbxImage = new System.Windows.Forms.PictureBox();
			this.rbLandScape = new System.Windows.Forms.RadioButton();
			this.rbPortrait = new System.Windows.Forms.RadioButton();
			this.gbxRange = new System.Windows.Forms.GroupBox();
			this.lbEnd = new System.Windows.Forms.Label();
			this.nupEnd = new System.Windows.Forms.NumericUpDown();
			this.lbStart = new System.Windows.Forms.Label();
			this.nupStart = new System.Windows.Forms.NumericUpDown();
			this.rbPart = new System.Windows.Forms.RadioButton();
			this.rbAll = new System.Windows.Forms.RadioButton();
			this.cboPaper = new IHIS.Framework.XComboBox();
			this.xComboItem1 = new IHIS.Framework.XComboItem();
			this.xComboItem2 = new IHIS.Framework.XComboItem();
			this.xComboItem3 = new IHIS.Framework.XComboItem();
			this.xComboItem4 = new IHIS.Framework.XComboItem();
			this.xComboItem5 = new IHIS.Framework.XComboItem();
			this.xComboItem6 = new IHIS.Framework.XComboItem();
			this.xComboItem7 = new IHIS.Framework.XComboItem();
			this.xComboItem8 = new IHIS.Framework.XComboItem();
			this.xComboItem9 = new IHIS.Framework.XComboItem();
			this.xComboItem10 = new IHIS.Framework.XComboItem();
			this.xComboItem11 = new IHIS.Framework.XComboItem();
			this.xComboItem12 = new IHIS.Framework.XComboItem();
			this.xComboItem13 = new IHIS.Framework.XComboItem();
			this.lbPaper = new System.Windows.Forms.Label();
			this.cboPrinter = new IHIS.Framework.XComboBox();
			this.lbPrinter = new System.Windows.Forms.Label();
			this.btnClose = new IHIS.Framework.XButton();
			this.btnPreview = new IHIS.Framework.XButton();
			this.btnPrint = new IHIS.Framework.XButton();
			this.pnlZoom = new System.Windows.Forms.Panel();
			this.nudZoom = new System.Windows.Forms.NumericUpDown();
			this.btnUp = new IHIS.Framework.XButton();
			this.btnDown = new IHIS.Framework.XButton();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.pnlCenter.SuspendLayout();
			this.gbxCount.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nupCount)).BeginInit();
			this.gbxMag.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nupMag)).BeginInit();
			this.gbxDirection.SuspendLayout();
			this.gbxRange.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nupEnd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nupStart)).BeginInit();
			this.pnlZoom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudZoom)).BeginInit();
			this.SuspendLayout();
			// 
			// dwCont
			// 
			this.dwCont.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.FixedSingle;
			this.dwCont.DataWindowObject = "";
			this.dwCont.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dwCont.LibraryList = "";
			this.dwCont.Location = new System.Drawing.Point(0, 0);
			this.dwCont.Name = "dwCont";
			this.dwCont.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
			this.dwCont.Size = new System.Drawing.Size(694, 492);
			this.dwCont.TabIndex = 0;
			// 
			// pnlCenter
			// 
			this.pnlCenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlCenter.Controls.Add(this.gbxCount);
			this.pnlCenter.Controls.Add(this.gbxMag);
			this.pnlCenter.Controls.Add(this.gbxDirection);
			this.pnlCenter.Controls.Add(this.gbxRange);
			this.pnlCenter.Controls.Add(this.cboPaper);
			this.pnlCenter.Controls.Add(this.lbPaper);
			this.pnlCenter.Controls.Add(this.cboPrinter);
			this.pnlCenter.Controls.Add(this.lbPrinter);
			this.pnlCenter.Location = new System.Drawing.Point(172, 108);
			this.pnlCenter.Name = "pnlCenter";
			this.pnlCenter.Size = new System.Drawing.Size(360, 284);
			this.pnlCenter.TabIndex = 1;
			// 
			// gbxCount
			// 
			this.gbxCount.Controls.Add(this.nupCount);
			this.gbxCount.Controls.Add(this.lbCount);
			this.gbxCount.Controls.Add(this.cbxCollate);
			this.gbxCount.Location = new System.Drawing.Point(172, 182);
			this.gbxCount.Name = "gbxCount";
			this.gbxCount.Size = new System.Drawing.Size(174, 58);
			this.gbxCount.TabIndex = 9;
			this.gbxCount.TabStop = false;
			// 
			// nupCount
			// 
			this.nupCount.Location = new System.Drawing.Point(74, 10);
			this.nupCount.Minimum = new System.Decimal(new int[] {
																	 1,
																	 0,
																	 0,
																	 0});
			this.nupCount.Name = "nupCount";
			this.nupCount.Size = new System.Drawing.Size(74, 20);
			this.nupCount.TabIndex = 7;
			this.nupCount.Value = new System.Decimal(new int[] {
																   1,
																   0,
																   0,
																   0});
			// 
			// lbCount
			// 
			this.lbCount.Location = new System.Drawing.Point(8, 10);
			this.lbCount.Name = "lbCount";
			this.lbCount.Size = new System.Drawing.Size(64, 21);
			this.lbCount.TabIndex = 6;
			this.lbCount.Text = "인쇄매수";
			this.lbCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cbxCollate
			// 
			this.cbxCollate.Location = new System.Drawing.Point(56, 34);
			this.cbxCollate.Name = "cbxCollate";
			this.cbxCollate.Size = new System.Drawing.Size(104, 22);
			this.cbxCollate.TabIndex = 13;
			this.cbxCollate.Text = "한부씩 인쇄";
			// 
			// gbxMag
			// 
			this.gbxMag.Controls.Add(this.label1);
			this.gbxMag.Controls.Add(this.nupMag);
			this.gbxMag.Controls.Add(this.lbMag);
			this.gbxMag.Location = new System.Drawing.Point(172, 240);
			this.gbxMag.Name = "gbxMag";
			this.gbxMag.Size = new System.Drawing.Size(174, 36);
			this.gbxMag.TabIndex = 8;
			this.gbxMag.TabStop = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(148, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(18, 20);
			this.label1.TabIndex = 9;
			this.label1.Text = "%";
			// 
			// nupMag
			// 
			this.nupMag.Location = new System.Drawing.Point(74, 9);
			this.nupMag.Maximum = new System.Decimal(new int[] {
																   200,
																   0,
																   0,
																   0});
			this.nupMag.Minimum = new System.Decimal(new int[] {
																   50,
																   0,
																   0,
																   0});
			this.nupMag.Name = "nupMag";
			this.nupMag.Size = new System.Drawing.Size(74, 20);
			this.nupMag.TabIndex = 8;
			this.nupMag.Value = new System.Decimal(new int[] {
																 100,
																 0,
																 0,
																 0});
			// 
			// lbMag
			// 
			this.lbMag.Location = new System.Drawing.Point(8, 10);
			this.lbMag.Name = "lbMag";
			this.lbMag.Size = new System.Drawing.Size(64, 21);
			this.lbMag.TabIndex = 6;
			this.lbMag.Text = "인쇄배율";
			this.lbMag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// gbxDirection
			// 
			this.gbxDirection.Controls.Add(this.pbxImage);
			this.gbxDirection.Controls.Add(this.rbLandScape);
			this.gbxDirection.Controls.Add(this.rbPortrait);
			this.gbxDirection.Location = new System.Drawing.Point(16, 182);
			this.gbxDirection.Name = "gbxDirection";
			this.gbxDirection.Size = new System.Drawing.Size(146, 94);
			this.gbxDirection.TabIndex = 5;
			this.gbxDirection.TabStop = false;
			this.gbxDirection.Text = "용지방향";
			// 
			// pbxImage
			// 
			this.pbxImage.Image = ((System.Drawing.Image)(resources.GetObject("pbxImage.Image")));
			this.pbxImage.Location = new System.Drawing.Point(12, 22);
			this.pbxImage.Name = "pbxImage";
			this.pbxImage.Size = new System.Drawing.Size(50, 60);
			this.pbxImage.TabIndex = 3;
			this.pbxImage.TabStop = false;
			// 
			// rbLandScape
			// 
			this.rbLandScape.Checked = true;
			this.rbLandScape.Location = new System.Drawing.Point(70, 58);
			this.rbLandScape.Name = "rbLandScape";
			this.rbLandScape.Size = new System.Drawing.Size(68, 24);
			this.rbLandScape.TabIndex = 2;
			this.rbLandScape.TabStop = true;
			this.rbLandScape.Text = "가 로";
			this.rbLandScape.CheckedChanged += new System.EventHandler(this.rbLandScape_CheckedChanged);
			// 
			// rbPortrait
			// 
			this.rbPortrait.Location = new System.Drawing.Point(70, 22);
			this.rbPortrait.Name = "rbPortrait";
			this.rbPortrait.Size = new System.Drawing.Size(68, 24);
			this.rbPortrait.TabIndex = 1;
			this.rbPortrait.Text = "세 로";
			this.rbPortrait.CheckedChanged += new System.EventHandler(this.rbPortrait_CheckedChanged);
			// 
			// gbxRange
			// 
			this.gbxRange.Controls.Add(this.lbEnd);
			this.gbxRange.Controls.Add(this.nupEnd);
			this.gbxRange.Controls.Add(this.lbStart);
			this.gbxRange.Controls.Add(this.nupStart);
			this.gbxRange.Controls.Add(this.rbPart);
			this.gbxRange.Controls.Add(this.rbAll);
			this.gbxRange.Location = new System.Drawing.Point(16, 102);
			this.gbxRange.Name = "gbxRange";
			this.gbxRange.Size = new System.Drawing.Size(330, 76);
			this.gbxRange.TabIndex = 4;
			this.gbxRange.TabStop = false;
			this.gbxRange.Text = "인쇄범위";
			// 
			// lbEnd
			// 
			this.lbEnd.Location = new System.Drawing.Point(274, 50);
			this.lbEnd.Name = "lbEnd";
			this.lbEnd.Size = new System.Drawing.Size(34, 23);
			this.lbEnd.TabIndex = 5;
			this.lbEnd.Text = "까지";
			// 
			// nupEnd
			// 
			this.nupEnd.Enabled = false;
			this.nupEnd.Location = new System.Drawing.Point(198, 48);
			this.nupEnd.Maximum = new System.Decimal(new int[] {
																   500,
																   0,
																   0,
																   0});
			this.nupEnd.Minimum = new System.Decimal(new int[] {
																   1,
																   0,
																   0,
																   0});
			this.nupEnd.Name = "nupEnd";
			this.nupEnd.Size = new System.Drawing.Size(74, 20);
			this.nupEnd.TabIndex = 4;
			this.nupEnd.Value = new System.Decimal(new int[] {
																 1,
																 0,
																 0,
																 0});
			// 
			// lbStart
			// 
			this.lbStart.Location = new System.Drawing.Point(160, 50);
			this.lbStart.Name = "lbStart";
			this.lbStart.Size = new System.Drawing.Size(34, 23);
			this.lbStart.TabIndex = 3;
			this.lbStart.Text = "부터";
			// 
			// nupStart
			// 
			this.nupStart.Enabled = false;
			this.nupStart.Location = new System.Drawing.Point(84, 48);
			this.nupStart.Minimum = new System.Decimal(new int[] {
																	 1,
																	 0,
																	 0,
																	 0});
			this.nupStart.Name = "nupStart";
			this.nupStart.Size = new System.Drawing.Size(74, 20);
			this.nupStart.TabIndex = 2;
			this.nupStart.Value = new System.Decimal(new int[] {
																   1,
																   0,
																   0,
																   0});
			// 
			// rbPart
			// 
			this.rbPart.Location = new System.Drawing.Point(12, 46);
			this.rbPart.Name = "rbPart";
			this.rbPart.Size = new System.Drawing.Size(68, 24);
			this.rbPart.TabIndex = 1;
			this.rbPart.Text = "일부분";
			this.rbPart.CheckedChanged += new System.EventHandler(this.rbPart_CheckedChanged);
			// 
			// rbAll
			// 
			this.rbAll.Checked = true;
			this.rbAll.Location = new System.Drawing.Point(12, 18);
			this.rbAll.Name = "rbAll";
			this.rbAll.Size = new System.Drawing.Size(68, 24);
			this.rbAll.TabIndex = 0;
			this.rbAll.TabStop = true;
			this.rbAll.Text = "전 체";
			this.rbAll.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
			// 
			// cboPaper
			// 
			this.cboPaper.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
																				 this.xComboItem1,
																				 this.xComboItem2,
																				 this.xComboItem3,
																				 this.xComboItem4,
																				 this.xComboItem5,
																				 this.xComboItem6,
																				 this.xComboItem7,
																				 this.xComboItem8,
																				 this.xComboItem9,
																				 this.xComboItem10,
																				 this.xComboItem11,
																				 this.xComboItem12,
																				 this.xComboItem13});
			this.cboPaper.Location = new System.Drawing.Point(14, 76);
			this.cboPaper.MaxDropDownItems = 13;
			this.cboPaper.Name = "cboPaper";
			this.cboPaper.Size = new System.Drawing.Size(332, 21);
			this.cboPaper.TabIndex = 3;
			// 
			// xComboItem1
			// 
			this.xComboItem1.DisplayItem = "0. Default paper size for printer";
			this.xComboItem1.ValueItem = "0";
			// 
			// xComboItem2
			// 
			this.xComboItem2.DisplayItem = "1. Letter 8 1/2 x 11 in";
			this.xComboItem2.ValueItem = "1";
			// 
			// xComboItem3
			// 
			this.xComboItem3.DisplayItem = "2. LetterSmall 8 1/2 x 11 in";
			this.xComboItem3.ValueItem = "2";
			// 
			// xComboItem4
			// 
			this.xComboItem4.DisplayItem = "3. Tabloid 17 x 11 inches";
			this.xComboItem4.ValueItem = "3";
			// 
			// xComboItem5
			// 
			this.xComboItem5.DisplayItem = "4. Ledger 17 x 11 in";
			this.xComboItem5.ValueItem = "4";
			// 
			// xComboItem6
			// 
			this.xComboItem6.DisplayItem = "5. Legal 8 1/2 x 14 in";
			this.xComboItem6.ValueItem = "5";
			// 
			// xComboItem7
			// 
			this.xComboItem7.DisplayItem = "6. Statement 5 1/2 x 8 1/2 in";
			this.xComboItem7.ValueItem = "6";
			// 
			// xComboItem8
			// 
			this.xComboItem8.DisplayItem = "7. Executive 7 1/4 x 10 1/2 in";
			this.xComboItem8.ValueItem = "7";
			// 
			// xComboItem9
			// 
			this.xComboItem9.DisplayItem = "8. A3 297 x 420 mm";
			this.xComboItem9.ValueItem = "8";
			// 
			// xComboItem10
			// 
			this.xComboItem10.DisplayItem = "9. A4 210 x 297 mm";
			this.xComboItem10.ValueItem = "9";
			// 
			// xComboItem11
			// 
			this.xComboItem11.DisplayItem = "10. A4 small 210 x 297 mm";
			this.xComboItem11.ValueItem = "10";
			// 
			// xComboItem12
			// 
			this.xComboItem12.DisplayItem = "11. A5 148 x 210 mm";
			this.xComboItem12.ValueItem = "11";
			// 
			// xComboItem13
			// 
			this.xComboItem13.DisplayItem = "12. B4 250 x 354 mm";
			this.xComboItem13.ValueItem = "12";
			// 
			// lbPaper
			// 
			this.lbPaper.Location = new System.Drawing.Point(14, 54);
			this.lbPaper.Name = "lbPaper";
			this.lbPaper.Size = new System.Drawing.Size(74, 21);
			this.lbPaper.TabIndex = 2;
			this.lbPaper.Text = "출력용지";
			this.lbPaper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboPrinter
			// 
			this.cboPrinter.Location = new System.Drawing.Point(14, 28);
			this.cboPrinter.Name = "cboPrinter";
			this.cboPrinter.Size = new System.Drawing.Size(332, 21);
			this.cboPrinter.TabIndex = 1;
			// 
			// lbPrinter
			// 
			this.lbPrinter.Location = new System.Drawing.Point(14, 6);
			this.lbPrinter.Name = "lbPrinter";
			this.lbPrinter.Size = new System.Drawing.Size(72, 21);
			this.lbPrinter.TabIndex = 0;
			this.lbPrinter.Text = "프린터";
			this.lbPrinter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
			this.btnClose.Location = new System.Drawing.Point(608, 494);
			this.btnClose.Name = "btnClose";
			this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
			this.btnClose.Size = new System.Drawing.Size(84, 30);
			this.btnClose.TabIndex = 12;
			this.btnClose.Text = "닫 기";
			this.toolTip.SetToolTip(this.btnClose, "ショートカット[ESC]");
			// 
			// btnPreview
			// 
			this.btnPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPreview.Image")));
			this.btnPreview.Location = new System.Drawing.Point(436, 494);
			this.btnPreview.Name = "btnPreview";
			this.btnPreview.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
			this.btnPreview.Size = new System.Drawing.Size(84, 30);
			this.btnPreview.TabIndex = 11;
			this.btnPreview.Text = "미리보기";
			this.toolTip.SetToolTip(this.btnPreview, "ショートカット[F11]");
			this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
			// 
			// btnPrint
			// 
			this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
			this.btnPrint.Location = new System.Drawing.Point(522, 494);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Scheme = IHIS.Framework.XButtonSchemes.Silver;
			this.btnPrint.Size = new System.Drawing.Size(84, 30);
			this.btnPrint.TabIndex = 10;
			this.btnPrint.Text = "인 쇄";
			this.toolTip.SetToolTip(this.btnPrint, "ショートカット[F12]");
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// pnlZoom
			// 
			this.pnlZoom.Controls.Add(this.nudZoom);
			this.pnlZoom.Controls.Add(this.btnUp);
			this.pnlZoom.Controls.Add(this.btnDown);
			this.pnlZoom.Location = new System.Drawing.Point(312, 496);
			this.pnlZoom.Name = "pnlZoom";
			this.pnlZoom.Size = new System.Drawing.Size(122, 26);
			this.pnlZoom.TabIndex = 13;
			this.pnlZoom.Visible = false;
			// 
			// nudZoom
			// 
			this.nudZoom.Location = new System.Drawing.Point(36, 4);
			this.nudZoom.Maximum = new System.Decimal(new int[] {
																	200,
																	0,
																	0,
																	0});
			this.nudZoom.Minimum = new System.Decimal(new int[] {
																	50,
																	0,
																	0,
																	0});
			this.nudZoom.Name = "nudZoom";
			this.nudZoom.Size = new System.Drawing.Size(58, 20);
			this.nudZoom.TabIndex = 9;
			this.nudZoom.Value = new System.Decimal(new int[] {
																  100,
																  0,
																  0,
																  0});
			this.nudZoom.ValueChanged += new System.EventHandler(this.nudZoom_ValueChanged);
			// 
			// btnUp
			// 
			this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
			this.btnUp.Location = new System.Drawing.Point(94, 2);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(26, 24);
			this.btnUp.TabIndex = 1;
			this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
			// 
			// btnDown
			// 
			this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
			this.btnDown.Location = new System.Drawing.Point(10, 2);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(26, 24);
			this.btnDown.TabIndex = 0;
			this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
			// 
			// DataWindowForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(249)), ((System.Byte)(251)));
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(694, 526);
			this.Controls.Add(this.pnlZoom);
			this.Controls.Add(this.pnlCenter);
			this.Controls.Add(this.dwCont);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnPreview);
			this.Controls.Add(this.btnPrint);
			this.DockPadding.Bottom = 34;
			this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.KeyPreview = true;
			this.Name = "DataWindowForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "인쇄";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataWindowForm_KeyDown);
			this.pnlCenter.ResumeLayout(false);
			this.gbxCount.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nupCount)).EndInit();
			this.gbxMag.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nupMag)).EndInit();
			this.gbxDirection.ResumeLayout(false);
			this.gbxRange.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nupEnd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nupStart)).EndInit();
			this.pnlZoom.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudZoom)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region OnLoad
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			//LibraryList, DataWindowObject Set
			this.dwCont.LibraryList = dwWorker.LibraryList;
			this.dwCont.DataWindowObject = dwWorker.DataWindowObject;

			//프린터 DDLB SET
			foreach (string pName in PrinterSettings.InstalledPrinters)
				this.cboPrinter.ComboItems.Add(pName, pName);

			//2006.04.21 PrinterName 설정
			if (dwWorker.PrinterName.Trim() != "")
			{
				try
				{
					this.dwCont.PrintProperties.PrinterName = dwWorker.PrinterName.Trim();
				}
				catch{}
				//cboPrinter의 PrinterName 설정
				cboPrinter.SetDataValue(dwWorker.PrinterName.Trim());
			}
			//첫번째 선택
			if (this.cboPrinter.ComboItems.Count > 0)
				this.cboPrinter.RefreshComboItems();

			//DataWindow Not Visible (생성시 Not Visible이면 DataWindowObject 설정시에 에러발생(DW.NET BUG)
			this.dwCont.Visible = false;


			//DataSource Fill 
			//1.NestedReport가 아니면 SourceLayout Fill -> DataSourceFill
			//2.NestedReport이면 ChildSources를 돌며 DataFill
			if (!dwWorker.IsNestedReport)
			{
				this.dwCont.FillData(this.dwWorker.SourceTable);
			}
			else  //Nested
			{
				foreach (XDWWorkerChildSource item in dwWorker.ChildSources)
				{
					if (item.IsGroupedChild)  //Grouped Child
					{
						if (item.SourceTable != null)
							dwCont.FillGroupedChildData(item.ChildName, item.SourceTable);
					}
					else
					{
						if (item.SourceTable != null)
							dwCont.FillChildData(item.ChildName, item.SourceTable);
					}
				}
			}

			//TextArgs Set (DW의 Text 동적할당)
			//TextArgs 설정 (Text Object 잘못 지정시에는 에러로 처리하지 않고 Text만 안설정되게 Try,catch함
			string modStr = "";
			//DataWindow에 있는 Object 목록 Get
			string setting = dwCont.Describe("DataWindow.Objects");
			foreach (XDWWorkerText item in dwWorker.TextArgs)
			{
				try
				{
					//"text_1.Text='Employee'"
					//Object 목록에 item.Name이 있으면 SET
					if (setting.IndexOf(item.Name) >= 0)
					{
						modStr = item.Name + ".Text='" + item.Data + "'";
						dwCont.Modify(modStr);
					}
				}
				catch{}
			}

			//2006.03.15 Footer 기본 이미지 설정
			dwCont.SetFooterImage();

			//2006.03.14 ImageArgs 설정(Computed Field Control의 이미지를 동적으로 할당)
			//설정시 에러발생시 에러를 발생시키지 않고 try-catch만 함
			foreach (XDWWorkerText item in dwWorker.ImageArgs)
			{
				try
				{
					//"computed_1.Expression='Bitmap("C:\IFC\AAA.gif"'"
					//파일이 존재하고 Object 목록에 item.Name이 있으면 SET
					if (File.Exists(item.Data) && (setting.IndexOf(item.Name) >= 0))
					{

						modStr = item.Name + ".Expression='Bitmap(\"" + item.Data + "\")'";
						dwCont.Modify(modStr);
					}
				}
				catch{}
			}

			//Preview 상태로
			dwCont.PrintProperties.Preview = true;

			//2005.11.08 프린터와의 관계에 의해 DataWindow Print Property 설정시 속도가 느리면
			//OnLoad에서는 Property설정부분은 COMMENT 처리하고 , 출력시 다시 설정하기
			//dwCont에서 PrinterName(기본 PrinterName을 가져와서 cboPrinter Set
			this.cboPrinter.SetDataValue(dwCont.PrintProperties.PrinterName);
			//용지 설정 (Default A4)
			dwCont.PrintProperties.PaperSize = (int) dwWorker.PaperSize; //여기
			this.cboPaper.SelectedIndex = (int) dwWorker.PaperSize;

			//출력장수,배율,가로세로 설정
			dwCont.PrintProperties.Copies = dwWorker.Copies;  //여기
			dwCont.PrintProperties.Scale = dwWorker.Magnification;  //여기

			//여기
			if (dwWorker.IsLandScape)
				this.dwCont.PrintProperties.Orientation = Sybase.DataWindow.PrintProperties.PrintOrientation.Landscape;
			else
				this.dwCont.PrintProperties.Orientation = Sybase.DataWindow.PrintProperties.PrintOrientation.Portrait;


			//한부씩 인쇄 SET
			//this.dwCont.PrintProperties.Collate = dwWorker.Collate;
			if (dwWorker.Collate)
				this.cbxCollate.Checked = true;


			//Control SET
			this.nupMag.Value = dwWorker.Magnification;
			this.nupCount.Value = dwWorker.Copies;
			if (dwWorker.IsLandScape)
				this.rbLandScape.Checked = true;
			else
				this.rbPortrait.Checked = true;

			
			//전체 Page 수 SET
			SetPageCount();

			//최초 PreviewZoom은 80%로 설정함
			this.nudZoom.Value = 80;

			//2005.12.13 dwWorker의 PrintProcessType이 Direct이면 출력 Button Click Logic반영
			if (dwWorker.ProcessType == PrintProcessType.Direct)
			{
				this.btnPrint.PerformClick();
				return;
			}

			//2005.12.13 DWWorker의 IsPreviewStatusPopup 여부에 따라 미리보기 상태 처리
			if (this.dwWorker.IsPreviewStatusPopup)
				this.btnPreview.PerformClick();

		}

		#endregion

		private void btnPreview_Click(object sender, System.EventArgs e)
		{
			if (!this.isPreviewStatus)  //PreView상태가 아닐때
			{
				this.pnlCenter.Visible = false;
				this.dwCont.Visible = true;
				this.pnlZoom.Visible = true;
				this.isPreviewStatus = true;
			}
			else  //다시 복구
			{
				this.pnlCenter.Visible = true;
				this.dwCont.Visible = false;
				this.pnlZoom.Visible = false;
				this.isPreviewStatus = false;
			}
		}

		private void rbPortrait_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rbPortrait.Checked)
			{
				this.dwCont.PrintProperties.Orientation = Sybase.DataWindow.PrintProperties.PrintOrientation.Portrait;
				this.pbxImage.Image = DrawHelper.PortraitImage;
				//전체 Page 수 SET
				SetPageCount();
			}
		}

		private void rbLandScape_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rbLandScape.Checked)
			{
				this.dwCont.PrintProperties.Orientation = Sybase.DataWindow.PrintProperties.PrintOrientation.Landscape;
				this.pbxImage.Image = DrawHelper.LandscapeImage;
				//전체 Page 수 SET
				SetPageCount();
			}
		}

		private void rbAll_CheckedChanged(object sender, System.EventArgs e)
		{
			//All Check시에 nupStart, nupEnd Disable
			if (rbAll.Checked)
			{
				this.nupStart.Enabled = false;
				this.nupEnd.Enabled = false;
			}
		}

		private void rbPart_CheckedChanged(object sender, System.EventArgs e)
		{
			//일부 Check시에 nupStart, nupEnd Enable
			if (rbPart.Checked)
			{
				this.nupStart.Enabled = true;
				this.nupEnd.Enabled = true;
			}
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			try
			{
				//출력양식의 속성 SET
				if (rbPart.Checked)
				{
					if (this.nupEnd.Value > this.nupStart.Value)
						dwCont.PrintProperties.PageRange = this.nupStart.Value.ToString() + "-" + this.nupEnd.Value.ToString(); //2-4
					else
						dwCont.PrintProperties.PageRange = this.nupStart.Value.ToString();  //잘못 지정시는 start만 SET
				}
				//출력프린터
				dwCont.PrintProperties.PrinterName = this.cboPrinter.GetDataValue();
				dwCont.PrintProperties.PaperSize = Int32.Parse(this.cboPaper.GetDataValue());  //PaperSize
				dwCont.PrintProperties.Copies = (int) this.nupCount.Value; //장수
				dwCont.PrintProperties.Scale = (int ) this.nupMag.Value; //출력배율
				dwCont.PrintProperties.Collate = this.cbxCollate.Checked;

				dwCont.Print();
				this.result = PrintResult.PrintOK;
			}
			catch //Print Error
			{
				this.result = PrintResult.PrintError;
			}
			this.Close();

			
		}

		private void SetPageCount()
		{
			//DataWindowObject에서 특정 Computed 필드는 pageCount를 가져오는 Computed Field로 정의함
			try
			{
				this.nupEnd.Value = dwCont.GetItemDecimal(1, PAGE_COUNT_FIELD_NAME);
				
			}
			catch  // PageCount Field가 없으면 1
			{
				this.nupEnd.Value = 1;
			}
		}

		//일본어, 한글 모드에 따른 Text 설정
		private void SetControlTextByLangMode()
		{
			this.Text = (NetInfo.Language == LangMode.Ko ? "출 력" : "印 刷");
			this.btnPrint.Text = (NetInfo.Language == LangMode.Ko ? "인 쇄" : "印 刷");
			this.btnPreview.Text = (NetInfo.Language == LangMode.Ko ? "미리보기" : "プレビュー");
			this.btnClose.Text = (NetInfo.Language == LangMode.Ko ? "닫 기" : "閉じる");
			this.lbPrinter.Text = (NetInfo.Language == LangMode.Ko ? "프린터" : "プリンター");
			this.lbPaper.Text = (NetInfo.Language == LangMode.Ko ? "인쇄용지" : "印刷用紙");
			this.lbCount.Text = (NetInfo.Language == LangMode.Ko ? "인쇄매수" : "印刷部数");
			this.lbStart.Text = (NetInfo.Language == LangMode.Ko ? "부터" : "から");
			this.lbEnd.Text = (NetInfo.Language == LangMode.Ko ? "까지" : "まで");
			this.lbMag.Text = (NetInfo.Language == LangMode.Ko ? "인쇄배율" : "印刷倍率");
			this.gbxRange.Text = (NetInfo.Language == LangMode.Ko ? "인쇄범위" : "印刷範囲");
			this.gbxDirection.Text = (NetInfo.Language == LangMode.Ko ? "용지방향" : "用紙方向");
			this.rbAll.Text = (NetInfo.Language == LangMode.Ko ? "전 체" : "全 体");
			this.rbPart.Text = (NetInfo.Language == LangMode.Ko ? "일부분" : "一部分");
			this.rbPortrait.Text = (NetInfo.Language == LangMode.Ko ? "세 로" : "縦");
			this.rbLandScape.Text = (NetInfo.Language == LangMode.Ko ? "가 로" : "横");
			this.cbxCollate.Text = (NetInfo.Language == LangMode.Ko ? "한부씩 인쇄" : "部単位印刷");
		}

		private void btnDown_Click(object sender, System.EventArgs e)
		{
			//Down시에 nudZoom값 Up
			if (this.nudZoom.Value > this.nudZoom.Minimum)
				this.nudZoom.Value--;
		}

		private void btnUp_Click(object sender, System.EventArgs e)
		{
			//Down시에 nudZoom값 Up
			if (this.nudZoom.Value < this.nudZoom.Maximum)
				this.nudZoom.Value++;
		}

		private void nudZoom_ValueChanged(object sender, System.EventArgs e)
		{
			//Preview상태에서 PreviewZoom 변경
			this.dwCont.PrintProperties.PreviewZoom = (int) this.nudZoom.Value;
		}

		private void DataWindowForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			//ShortCut 처리
			if (e.KeyData == Keys.F11)
				this.btnPreview.PerformClick();
			else if (e.KeyData == Keys.F12)
				this.btnPrint.PerformClick();
		}
	}
}
