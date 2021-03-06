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
	/// XPrintScreen에 대한 요약 설명입니다.
	/// </summary>
	public class XPrintScreen : IHIS.Framework.XScreen
	{
		const string PAGE_COUNT_FIELD_NAME = "cfd_count";
		protected bool IsPreviewStatus = false; //PreView 상태인지 여부
		protected IHIS.Framework.XDWWorker dwWorker;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XPanel pnlOption;
		protected IHIS.Framework.XDataWindow dwControl;
		private System.Windows.Forms.GroupBox gbxCount;
		private System.Windows.Forms.NumericUpDown nupCount;
		private System.Windows.Forms.Label lbCount;
		private System.Windows.Forms.CheckBox cbxCollate;
		private System.Windows.Forms.GroupBox gbxMag;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown nupMag;
		private System.Windows.Forms.Label lbMag;
		private System.Windows.Forms.GroupBox gbxDirection;
		private System.Windows.Forms.PictureBox pbxImage;
		private System.Windows.Forms.RadioButton rbLandScape;
		private System.Windows.Forms.RadioButton rbPortrait;
		private System.Windows.Forms.GroupBox gbxRange;
		private System.Windows.Forms.Label lbEnd;
		private System.Windows.Forms.NumericUpDown nupEnd;
		private System.Windows.Forms.Label lbStart;
		private System.Windows.Forms.NumericUpDown nupStart;
		private System.Windows.Forms.RadioButton rbPart;
		private System.Windows.Forms.RadioButton rbAll;
		private IHIS.Framework.XComboBox cboPaper;
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
		private System.Windows.Forms.Label lbPaper;
		private IHIS.Framework.XComboBox cboPrinter;
		private System.Windows.Forms.Label lbPrinter;
		private IHIS.Framework.XLabel lbOption;
		private IHIS.Framework.XLabel lbPrint;
		private IHIS.Framework.XPanel pnlLeft;
		protected IHIS.Framework.XPanel pnlCondition;
		private System.Windows.Forms.Panel pnlZoom;
		private IHIS.Framework.XButton btnDown;
		private IHIS.Framework.XButton btnUp;
		private System.Windows.Forms.NumericUpDown nudZoom;
		/// <summary> 
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public XPrintScreen()
		{
			// 이 호출은 Windows.Forms Form 디자이너에 필요합니다.
			InitializeComponent();

			// TODO: InitializeComponent를 호출한 다음 초기화 작업을 추가합니다.

			//언어모드에 따른 Text 설정
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

		#region 구성 요소 디자이너에서 생성한 코드
		/// <summary> 
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(XPrintScreen));
			this.dwWorker = new IHIS.Framework.XDWWorker();
			this.dwControl = new IHIS.Framework.XDataWindow();
			this.pnlBottom = new IHIS.Framework.XPanel();
			this.pnlZoom = new System.Windows.Forms.Panel();
			this.nudZoom = new System.Windows.Forms.NumericUpDown();
			this.btnUp = new IHIS.Framework.XButton();
			this.btnDown = new IHIS.Framework.XButton();
			this.btnList = new IHIS.Framework.XButtonList();
			this.pnlLeft = new IHIS.Framework.XPanel();
			this.lbPrint = new IHIS.Framework.XLabel();
			this.pnlCondition = new IHIS.Framework.XPanel();
			this.pnlOption = new IHIS.Framework.XPanel();
			this.lbOption = new IHIS.Framework.XLabel();
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
			this.pnlBottom.SuspendLayout();
			this.pnlZoom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudZoom)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
			this.pnlLeft.SuspendLayout();
			this.pnlOption.SuspendLayout();
			this.gbxCount.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nupCount)).BeginInit();
			this.gbxMag.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nupMag)).BeginInit();
			this.gbxDirection.SuspendLayout();
			this.gbxRange.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nupEnd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nupStart)).BeginInit();
			this.SuspendLayout();
			// 
			// dwWorker
			// 
			this.dwWorker.DWViewer = this.dwControl;
			this.dwWorker.LibraryList = "";
			this.dwWorker.ProcessType = IHIS.Framework.PrintProcessType.Viewer;
			// 
			// dwControl
			// 
			this.dwControl.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
			this.dwControl.DataWindowObject = "";
			this.dwControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dwControl.LibraryList = "";
			this.dwControl.Location = new System.Drawing.Point(2, 2);
			this.dwControl.Name = "dwControl";
			this.dwControl.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
			this.dwControl.Size = new System.Drawing.Size(956, 548);
			this.dwControl.TabIndex = 2;
			// 
			// pnlBottom
			// 
			this.pnlBottom.Controls.Add(this.pnlZoom);
			this.pnlBottom.Controls.Add(this.btnList);
			this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlBottom.Location = new System.Drawing.Point(2, 550);
			this.pnlBottom.Name = "pnlBottom";
			this.pnlBottom.Size = new System.Drawing.Size(956, 38);
			this.pnlBottom.TabIndex = 3;
			// 
			// pnlZoom
			// 
			this.pnlZoom.Controls.Add(this.nudZoom);
			this.pnlZoom.Controls.Add(this.btnUp);
			this.pnlZoom.Controls.Add(this.btnDown);
			this.pnlZoom.Location = new System.Drawing.Point(586, 8);
			this.pnlZoom.Name = "pnlZoom";
			this.pnlZoom.Size = new System.Drawing.Size(122, 26);
			this.pnlZoom.TabIndex = 1;
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
																  80,
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
			// btnList
			// 
			this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnList.Location = new System.Drawing.Point(710, 4);
			this.btnList.Name = "btnList";
			this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Print;
			this.btnList.Size = new System.Drawing.Size(244, 34);
			this.btnList.TabIndex = 0;
			this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
			// 
			// pnlLeft
			// 
			this.pnlLeft.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(229)), ((System.Byte)(231))));
			this.pnlLeft.Controls.Add(this.lbPrint);
			this.pnlLeft.Controls.Add(this.pnlCondition);
			this.pnlLeft.DrawBorder = true;
			this.pnlLeft.Location = new System.Drawing.Point(72, 78);
			this.pnlLeft.Name = "pnlLeft";
			this.pnlLeft.Size = new System.Drawing.Size(432, 404);
			this.pnlLeft.TabIndex = 4;
			// 
			// lbPrint
			// 
			this.lbPrint.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
			this.lbPrint.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbPrint.Location = new System.Drawing.Point(10, 6);
			this.lbPrint.Name = "lbPrint";
			this.lbPrint.Size = new System.Drawing.Size(408, 26);
			this.lbPrint.TabIndex = 19;
			this.lbPrint.Text = "출  력  조  건";
			this.lbPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pnlCondition
			// 
			this.pnlCondition.DrawBorder = true;
			this.pnlCondition.Location = new System.Drawing.Point(10, 42);
			this.pnlCondition.Name = "pnlCondition";
			this.pnlCondition.Size = new System.Drawing.Size(408, 346);
			this.pnlCondition.TabIndex = 6;
			// 
			// pnlOption
			// 
			this.pnlOption.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(229)), ((System.Byte)(231))));
			this.pnlOption.Controls.Add(this.lbOption);
			this.pnlOption.Controls.Add(this.gbxCount);
			this.pnlOption.Controls.Add(this.gbxMag);
			this.pnlOption.Controls.Add(this.gbxDirection);
			this.pnlOption.Controls.Add(this.gbxRange);
			this.pnlOption.Controls.Add(this.cboPaper);
			this.pnlOption.Controls.Add(this.lbPaper);
			this.pnlOption.Controls.Add(this.cboPrinter);
			this.pnlOption.Controls.Add(this.lbPrinter);
			this.pnlOption.DrawBorder = true;
			this.pnlOption.Location = new System.Drawing.Point(504, 78);
			this.pnlOption.Name = "pnlOption";
			this.pnlOption.Size = new System.Drawing.Size(344, 404);
			this.pnlOption.TabIndex = 5;
			// 
			// lbOption
			// 
			this.lbOption.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
			this.lbOption.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbOption.Location = new System.Drawing.Point(6, 6);
			this.lbOption.Name = "lbOption";
			this.lbOption.Size = new System.Drawing.Size(328, 26);
			this.lbOption.TabIndex = 18;
			this.lbOption.Text = "Print Option";
			this.lbOption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// gbxCount
			// 
			this.gbxCount.Controls.Add(this.nupCount);
			this.gbxCount.Controls.Add(this.lbCount);
			this.gbxCount.Controls.Add(this.cbxCollate);
			this.gbxCount.Location = new System.Drawing.Point(162, 290);
			this.gbxCount.Name = "gbxCount";
			this.gbxCount.Size = new System.Drawing.Size(174, 58);
			this.gbxCount.TabIndex = 17;
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
			this.gbxMag.Location = new System.Drawing.Point(162, 356);
			this.gbxMag.Name = "gbxMag";
			this.gbxMag.Size = new System.Drawing.Size(174, 36);
			this.gbxMag.TabIndex = 16;
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
			this.gbxDirection.Location = new System.Drawing.Point(6, 290);
			this.gbxDirection.Name = "gbxDirection";
			this.gbxDirection.Size = new System.Drawing.Size(146, 100);
			this.gbxDirection.TabIndex = 15;
			this.gbxDirection.TabStop = false;
			this.gbxDirection.Text = "용지방향";
			// 
			// pbxImage
			// 
			this.pbxImage.Image = ((System.Drawing.Image)(resources.GetObject("pbxImage.Image")));
			this.pbxImage.Location = new System.Drawing.Point(12, 26);
			this.pbxImage.Name = "pbxImage";
			this.pbxImage.Size = new System.Drawing.Size(50, 60);
			this.pbxImage.TabIndex = 3;
			this.pbxImage.TabStop = false;
			// 
			// rbLandScape
			// 
			this.rbLandScape.Checked = true;
			this.rbLandScape.Location = new System.Drawing.Point(70, 62);
			this.rbLandScape.Name = "rbLandScape";
			this.rbLandScape.Size = new System.Drawing.Size(68, 24);
			this.rbLandScape.TabIndex = 2;
			this.rbLandScape.TabStop = true;
			this.rbLandScape.Text = "가 로";
			this.rbLandScape.CheckedChanged += new System.EventHandler(this.rbLandScape_CheckedChanged);
			// 
			// rbPortrait
			// 
			this.rbPortrait.Location = new System.Drawing.Point(70, 26);
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
			this.gbxRange.Location = new System.Drawing.Point(6, 182);
			this.gbxRange.Name = "gbxRange";
			this.gbxRange.Size = new System.Drawing.Size(330, 82);
			this.gbxRange.TabIndex = 14;
			this.gbxRange.TabStop = false;
			this.gbxRange.Text = "인쇄범위";
			// 
			// lbEnd
			// 
			this.lbEnd.Location = new System.Drawing.Point(274, 54);
			this.lbEnd.Name = "lbEnd";
			this.lbEnd.Size = new System.Drawing.Size(34, 23);
			this.lbEnd.TabIndex = 5;
			this.lbEnd.Text = "까지";
			// 
			// nupEnd
			// 
			this.nupEnd.Enabled = false;
			this.nupEnd.Location = new System.Drawing.Point(198, 52);
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
			this.lbStart.Location = new System.Drawing.Point(160, 54);
			this.lbStart.Name = "lbStart";
			this.lbStart.Size = new System.Drawing.Size(34, 23);
			this.lbStart.TabIndex = 3;
			this.lbStart.Text = "부터";
			// 
			// nupStart
			// 
			this.nupStart.Enabled = false;
			this.nupStart.Location = new System.Drawing.Point(84, 52);
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
			this.rbPart.Location = new System.Drawing.Point(12, 50);
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
			this.cboPaper.Location = new System.Drawing.Point(6, 134);
			this.cboPaper.MaxDropDownItems = 13;
			this.cboPaper.Name = "cboPaper";
			this.cboPaper.Size = new System.Drawing.Size(328, 21);
			this.cboPaper.TabIndex = 13;
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
			this.lbPaper.Location = new System.Drawing.Point(6, 112);
			this.lbPaper.Name = "lbPaper";
			this.lbPaper.Size = new System.Drawing.Size(74, 21);
			this.lbPaper.TabIndex = 12;
			this.lbPaper.Text = "출력용지";
			this.lbPaper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboPrinter
			// 
			this.cboPrinter.Location = new System.Drawing.Point(6, 68);
			this.cboPrinter.Name = "cboPrinter";
			this.cboPrinter.Size = new System.Drawing.Size(328, 21);
			this.cboPrinter.TabIndex = 11;
			// 
			// lbPrinter
			// 
			this.lbPrinter.Location = new System.Drawing.Point(6, 46);
			this.lbPrinter.Name = "lbPrinter";
			this.lbPrinter.Size = new System.Drawing.Size(72, 21);
			this.lbPrinter.TabIndex = 10;
			this.lbPrinter.Text = "프린터";
			this.lbPrinter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// XPrintScreen
			// 
			this.Controls.Add(this.pnlOption);
			this.Controls.Add(this.pnlLeft);
			this.Controls.Add(this.dwControl);
			this.Controls.Add(this.pnlBottom);
			this.DockPadding.All = 2;
			this.Name = "XPrintScreen";
			this.PrintWorker = this.dwWorker;
			this.pnlBottom.ResumeLayout(false);
			this.pnlZoom.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudZoom)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
			this.pnlLeft.ResumeLayout(false);
			this.pnlOption.ResumeLayout(false);
			this.gbxCount.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nupCount)).EndInit();
			this.gbxMag.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nupMag)).EndInit();
			this.gbxDirection.ResumeLayout(false);
			this.gbxRange.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nupEnd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nupStart)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region OnLoad
		protected override void OnLoad(EventArgs e)
		{
			//프린터 DDLB SET
			foreach (string pName in PrinterSettings.InstalledPrinters)
				this.cboPrinter.ComboItems.Add(pName, pName);
			//Refresh
			if (this.cboPrinter.ComboItems.Count > 0)
				this.cboPrinter.RefreshComboItems();

			//DataWindow Not Visible (생성시 Not Visible이면 DataWindowObject 설정시에 에러발생(DW.NET BUG)
			this.dwControl.Visible = false;

			//dwControl에 LibraryList, DataWindowObject가 연결되어 있으면 다른 Property SET
			if ((dwControl.LibraryList != "") && (dwControl.DataWindowObject != ""))
			{
				try
				{
					//Preview 상태로
					dwControl.PrintProperties.Preview = true;
					//PreviewZoom은 80으로
					dwControl.PrintProperties.PreviewZoom = 80;
					//dwCont에서 PrinterName(기본 PrinterName을 가져와서 cboPrinter Set
					this.cboPrinter.SetDataValue(dwControl.PrintProperties.PrinterName);
					//용지 설정 (Default A4)
					dwControl.PrintProperties.PaperSize = (int) dwWorker.PaperSize;
					this.cboPaper.SelectedIndex = (int) dwWorker.PaperSize;
					//출력장수,배율,가로세로 설정
					dwControl.PrintProperties.Copies = dwWorker.Copies;
					dwControl.PrintProperties.Scale = dwWorker.Magnification;
					if (dwWorker.IsLandScape)
						this.dwControl.PrintProperties.Orientation = Sybase.DataWindow.PrintProperties.PrintOrientation.Landscape;
					else
						this.dwControl.PrintProperties.Orientation = Sybase.DataWindow.PrintProperties.PrintOrientation.Portrait;

					//한부씩 인쇄 SET
					this.dwControl.PrintProperties.Collate = dwWorker.Collate;
					if (dwWorker.Collate)
						this.cbxCollate.Checked = true;

					//Control SET
					this.nupMag.Value = dwWorker.Magnification;
					this.nupCount.Value = dwWorker.Copies;
					if (dwWorker.IsLandScape)
						this.rbLandScape.Checked = true;
					else
						this.rbPortrait.Checked = true;
				}
				catch{}
			}
			else
			{
				//아직 연결이 안되어 있는 경우에는 기본값으로 설정
				this.cboPrinter.SelectedIndex = 0; //첫번째
				this.cboPaper.SelectedIndex = (int) dwWorker.PaperSize;
				if (dwWorker.Collate)
					this.cbxCollate.Checked = true;
				//Control SET
				this.nupMag.Value = dwWorker.Magnification;
				this.nupCount.Value = dwWorker.Copies;
				if (dwWorker.IsLandScape)
					this.rbLandScape.Checked = true;
				else
					this.rbPortrait.Checked = true;
			}


			base.OnLoad (e);
		}

		#endregion

		#region Event Handler
		protected virtual void OnPrintButtonClick(IHIS.Framework.ButtonClickEventArgs e)
		{
		}
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			
			
			if (e.Func == FunctionType.Preview)  //미리보기
			{
				if (!this.IsPreviewStatus)  //Preview 상태가 아니면
				{
					//PrintButtonClick Event (어떻게 통제하는 것이 개발자에게 편한지 내일 확인하여 반영하자)
					OnPrintButtonClick(e);

					//Control에 설정된 값으로 dwWorker의 값 설정하기
					SetDWWorkerProperties();
					//정상적으로 데이타를 설정하고, Preview상태가 되었으면 Visible 변경
					if (this.dwWorker.Preview())
					{
						this.dwControl.Visible = true;
						this.pnlZoom.Visible = true;
						this.pnlLeft.Visible = false;
						this.pnlOption.Visible = false;
						this.IsPreviewStatus = true;
						//정상적으로 채운 데이타로 페이지 수 계산
						this.SetPageCount();
					}
					
				}
				else  //원상태로 복귀
				{
					this.dwControl.Visible = false;
					this.pnlZoom.Visible = false;
					this.pnlLeft.Visible = true;
					this.pnlOption.Visible = true;
					this.IsPreviewStatus = false;
				}
				e.IsBaseCall = false; //Base Call하지 않음
			}
			else if (e.Func == FunctionType.Print)
			{
				//Control에 설정된 값으로 dwWorker의 값 설정하기
				SetDWWorkerProperties();
			}
		}
		private void rbPortrait_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rbPortrait.Checked)
			{
				if ((dwControl.LibraryList != "") && (dwControl.DataWindowObject != ""))
					this.dwControl.PrintProperties.Orientation = Sybase.DataWindow.PrintProperties.PrintOrientation.Portrait;
				this.pbxImage.Image = DrawHelper.PortraitImage;
				//전체 Page 수 SET
				SetPageCount();
			}
		}

		private void rbLandScape_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rbLandScape.Checked)
			{
				if ((dwControl.LibraryList != "") && (dwControl.DataWindowObject != ""))
					this.dwControl.PrintProperties.Orientation = Sybase.DataWindow.PrintProperties.PrintOrientation.Landscape;
				this.pbxImage.Image = DrawHelper.LandscapeImage;
				//전체 Page 수 SET
				SetPageCount();
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

		private void rbAll_CheckedChanged(object sender, System.EventArgs e)
		{
			//All Check시에 nupStart, nupEnd Disable
			if (rbAll.Checked)
			{
				this.nupStart.Enabled = false;
				this.nupEnd.Enabled = false;
			}
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
			this.dwControl.PrintProperties.PreviewZoom = (int) this.nudZoom.Value;
		}
		#endregion

		
		//Control에 설정된 값으로 dwWorker의 속성 변경
		private void SetDWWorkerProperties()
		{
			//가로,세로, PaperSize, 인쇄배율, 장수, Collate
			dwWorker.IsLandScape = this.rbLandScape.Checked;
			dwWorker.PaperSize = (DataWindowPaperSize) Enum.ToObject(typeof(DataWindowPaperSize),Int32.Parse(this.cboPaper.GetDataValue()));
			dwWorker.Magnification = (int) this.nupMag.Value;
			dwWorker.Copies = (int) this.nupCount.Value;
			dwWorker.Collate = this.cbxCollate.Checked;
			//프린터명과 전체,일부출력은 dwControl의 PrintProperties에 SET
			try
			{
				if ((dwControl.LibraryList != "") && (dwControl.DataWindowObject != ""))
				{
					//출력양식의 속성 SET
					if (rbPart.Checked)
					{
						if (this.nupEnd.Value > this.nupStart.Value)
							dwControl.PrintProperties.PageRange = this.nupStart.Value.ToString() + "-" + this.nupEnd.Value.ToString(); //2-4
						else
							dwControl.PrintProperties.PageRange = this.nupStart.Value.ToString();  //잘못 지정시는 start만 SET
					}
					//출력프린터
					dwControl.PrintProperties.PrinterName = this.cboPrinter.GetDataValue();
				}
			}
			catch{}

		}


		private void SetPageCount()
		{
			//DataWindowObject에서 특정 Computed 필드는 pageCount를 가져오는 Computed Field로 정의함
			try
			{
				this.nupEnd.Value = dwControl.GetItemDecimal(1, PAGE_COUNT_FIELD_NAME);
				
			}
			catch  // PageCount Field가 없으면 1
			{
				this.nupEnd.Value = 1;
			}
		}

		//일본어, 한글 모드에 따른 Text 설정
		private void SetControlTextByLangMode()
		{
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
			this.lbPrint.Text = (NetInfo.Language == LangMode.Ko ? "출  력  조  건" : "印  刷  条  件");
			this.lbOption.Text = (NetInfo.Language == LangMode.Ko ? "Print Option" : "印刷 オプション");
		}
	}
}
