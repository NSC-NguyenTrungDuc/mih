#region 사용 NameSpace 지정
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
#endregion
 
namespace IHIS.OCSA
{
	/// <summary>
	/// OCS0103Q12에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS0103Q12 : IHIS.Framework.XScreen
	{
		private string mSpecimen = "";
		private string mbxMsg = "", mbxCap = "";	
		private IHIS.X.Magic.Menus.PopupMenu popupMenu = new IHIS.X.Magic.Menus.PopupMenu(); 
		private IHIS.Framework.MultiLayout laySelectOCS0103 = new MultiLayout();

		private System.Windows.Forms.TreeView tvwSlip_Info;
		private IHIS.Framework.XEditGrid grdOCS0103_P1;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XGridHeader xGridHeader1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
		private IHIS.Framework.XEditGridCell xEditGridCell22;
		private IHIS.Framework.XEditGridCell xEditGridCell23;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private System.Windows.Forms.Panel pnlSpecimen;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XEditGrid grdOCS0103_P2;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XGridHeader xGridHeader2;
		private System.Windows.Forms.PictureBox pictureBox2;
		private IHIS.Framework.XLabel lblSlip_name;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private System.Windows.Forms.CheckBox chkEmergency;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XLabel lblSelectAll_P1;
		private IHIS.Framework.XLabel lblSelectAll_P2;
		private IHIS.Framework.XButton btnProClose;
		private IHIS.Framework.XButton btnProcess;
		private IHIS.Framework.XButton btnCPLInfo;
		private IHIS.Framework.MultiLayout laySlip_Info;
		private IHIS.Framework.MultiLayout laySpecimen;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem7;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem8;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem9;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem10;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem11;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem12;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem13;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem14;

		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OCS0103Q12()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0103Q12));
            this.tvwSlip_Info = new System.Windows.Forms.TreeView();
            this.grdOCS0103_P1 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnCPLInfo = new IHIS.Framework.XButton();
            this.btnProcess = new IHIS.Framework.XButton();
            this.chkEmergency = new System.Windows.Forms.CheckBox();
            this.btnProClose = new IHIS.Framework.XButton();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.lblSlip_name = new IHIS.Framework.XLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlSpecimen = new System.Windows.Forms.Panel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.lblSelectAll_P2 = new IHIS.Framework.XLabel();
            this.lblSelectAll_P1 = new IHIS.Framework.XLabel();
            this.grdOCS0103_P2 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.laySlip_Info = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.laySpecimen = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0103_P1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0103_P2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySlip_Info)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySpecimen)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "");
            this.ImageList.Images.SetKeyName(4, "");
            // 
            // tvwSlip_Info
            // 
            this.tvwSlip_Info.BackColor = System.Drawing.SystemColors.Window;
            this.tvwSlip_Info.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvwSlip_Info.ImageIndex = 0;
            this.tvwSlip_Info.ImageList = this.ImageList;
            this.tvwSlip_Info.Location = new System.Drawing.Point(0, 0);
            this.tvwSlip_Info.Name = "tvwSlip_Info";
            this.tvwSlip_Info.SelectedImageIndex = 1;
            this.tvwSlip_Info.Size = new System.Drawing.Size(220, 590);
            this.tvwSlip_Info.TabIndex = 5;
            this.tvwSlip_Info.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwSlip_Info_AfterSelect);
            // 
            // grdOCS0103_P1
            // 
            this.grdOCS0103_P1.AddedHeaderLine = 1;
            this.grdOCS0103_P1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdOCS0103_P1.ApplyPaintEventToAllColumn = true;
            this.grdOCS0103_P1.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell18,
            this.xEditGridCell1,
            this.xEditGridCell4});
            this.grdOCS0103_P1.ColPerLine = 4;
            this.grdOCS0103_P1.Cols = 4;
            this.grdOCS0103_P1.FixedRows = 2;
            this.grdOCS0103_P1.HeaderHeights.Add(22);
            this.grdOCS0103_P1.HeaderHeights.Add(0);
            this.grdOCS0103_P1.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdOCS0103_P1.Location = new System.Drawing.Point(2, 24);
            this.grdOCS0103_P1.Name = "grdOCS0103_P1";
            this.grdOCS0103_P1.QuerySQL = resources.GetString("grdOCS0103_P1.QuerySQL");
            this.grdOCS0103_P1.Rows = 3;
            this.grdOCS0103_P1.RowStateCheckOnPaint = false;
            this.grdOCS0103_P1.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS0103_P1.Size = new System.Drawing.Size(368, 364);
            this.grdOCS0103_P1.TabIndex = 14;
            this.grdOCS0103_P1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0103_P1_MouseDown);
            this.grdOCS0103_P1.GridContDisplayed += new IHIS.Framework.XGridContDisplayedEventHandler(this.grdOCS0103_P1_GridContDisplayed);
            this.grdOCS0103_P1.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS0103_P1_GridCellPainting);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "slip_code";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderText = "slip_code";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "position";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "position";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell5.CellName = "seq";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell5.CellWidth = 36;
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.HeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell5.HeaderText = "seq";
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            this.xEditGridCell5.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell5.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell6.ApplyPaintingEvent = true;
            this.xEditGridCell6.CellName = "hangmog_code";
            this.xEditGridCell6.CellWidth = 77;
            this.xEditGridCell6.Col = 1;
            this.xEditGridCell6.HeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell6.HeaderText = "項目コード";
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.Row = 1;
            this.xEditGridCell6.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell6.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell7.ApplyPaintingEvent = true;
            this.xEditGridCell7.CellName = "hangmog_name";
            this.xEditGridCell7.CellWidth = 184;
            this.xEditGridCell7.Col = 2;
            this.xEditGridCell7.HeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell7.HeaderText = "項目名";
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.Row = 1;
            this.xEditGridCell7.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell7.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell21.ApplyPaintingEvent = true;
            this.xEditGridCell21.CellName = "specimen_code";
            this.xEditGridCell21.CellWidth = 45;
            this.xEditGridCell21.Col = 3;
            this.xEditGridCell21.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell21.HeaderText = "検体";
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.IsUpdatable = false;
            this.xEditGridCell21.RowSpan = 2;
            this.xEditGridCell21.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell21.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "group_yn";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.HeaderText = "group_yn";
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.IsUpdatable = false;
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "bulyong_check";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.HeaderText = "bulyong_check";
            this.xEditGridCell23.IsReadOnly = true;
            this.xEditGridCell23.IsUpdatable = false;
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "specimen_base";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.HeaderText = "specimen_base";
            this.xEditGridCell18.IsUpdatable = false;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 1;
            this.xEditGridCell1.CellName = "emergency";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.HeaderText = "emergency";
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell4.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell4.ApplyPaintingEvent = true;
            this.xEditGridCell4.CellName = "select";
            this.xEditGridCell4.CellWidth = 37;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell4.HeaderText = "選択";
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell4.RowSpan = 2;
            this.xEditGridCell4.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell4.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 1;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridHeader1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridHeader1.HeaderText = "オ―ダコード";
            this.xGridHeader1.HeaderWidth = 77;
            this.xGridHeader1.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridHeader1.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Location = new System.Drawing.Point(552, 4);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.xButtonList1.Size = new System.Drawing.Size(163, 34);
            this.xButtonList1.TabIndex = 16;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(960, 590);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.btnCPLInfo);
            this.xPanel1.Controls.Add(this.btnProcess);
            this.xPanel1.Controls.Add(this.chkEmergency);
            this.xPanel1.Controls.Add(this.xButtonList1);
            this.xPanel1.Controls.Add(this.btnProClose);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(220, 546);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(740, 44);
            this.xPanel1.TabIndex = 19;
            // 
            // btnCPLInfo
            // 
            this.btnCPLInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCPLInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnCPLInfo.Image")));
            this.btnCPLInfo.Location = new System.Drawing.Point(12, 7);
            this.btnCPLInfo.Name = "btnCPLInfo";
            this.btnCPLInfo.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnCPLInfo.Size = new System.Drawing.Size(118, 28);
            this.btnCPLInfo.TabIndex = 24;
            this.btnCPLInfo.Text = "検査情報照会";
            this.btnCPLInfo.Click += new System.EventHandler(this.btnCPLInfo_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Image = ((System.Drawing.Image)(resources.GetObject("btnProcess.Image")));
            this.btnProcess.Location = new System.Drawing.Point(454, 7);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(98, 28);
            this.btnProcess.TabIndex = 22;
            this.btnProcess.Text = "選択";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // chkEmergency
            // 
            this.chkEmergency.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkEmergency.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.chkEmergency.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkEmergency.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.chkEmergency.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkEmergency.ImageIndex = 2;
            this.chkEmergency.ImageList = this.ImageList;
            this.chkEmergency.Location = new System.Drawing.Point(364, 8);
            this.chkEmergency.Name = "chkEmergency";
            this.chkEmergency.Size = new System.Drawing.Size(88, 24);
            this.chkEmergency.TabIndex = 21;
            this.chkEmergency.Text = "       至急";
            this.chkEmergency.UseVisualStyleBackColor = false;
            this.chkEmergency.CheckedChanged += new System.EventHandler(this.chkEmergency_CheckedChanged);
            // 
            // btnProClose
            // 
            this.btnProClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProClose.Image = ((System.Drawing.Image)(resources.GetObject("btnProClose.Image")));
            this.btnProClose.Location = new System.Drawing.Point(340, 8);
            this.btnProClose.Name = "btnProClose";
            this.btnProClose.Size = new System.Drawing.Size(114, 28);
            this.btnProClose.TabIndex = 23;
            this.btnProClose.Text = "選択後閉じる";
            this.btnProClose.Visible = false;
            this.btnProClose.Click += new System.EventHandler(this.btnProClose_Click);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.lblSlip_name);
            this.xPanel2.Controls.Add(this.pictureBox2);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(220, 0);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(740, 38);
            this.xPanel2.TabIndex = 25;
            // 
            // lblSlip_name
            // 
            this.lblSlip_name.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblSlip_name.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.lblSlip_name.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.lblSlip_name.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSlip_name.Location = new System.Drawing.Point(0, 12);
            this.lblSlip_name.Name = "lblSlip_name";
            this.lblSlip_name.Size = new System.Drawing.Size(738, 24);
            this.lblSlip_name.TabIndex = 14;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(738, 36);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // pnlSpecimen
            // 
            this.pnlSpecimen.AutoScroll = true;
            this.pnlSpecimen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSpecimen.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSpecimen.Location = new System.Drawing.Point(220, 38);
            this.pnlSpecimen.Name = "pnlSpecimen";
            this.pnlSpecimen.Size = new System.Drawing.Size(740, 118);
            this.pnlSpecimen.TabIndex = 23;
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.lblSelectAll_P2);
            this.xPanel3.Controls.Add(this.lblSelectAll_P1);
            this.xPanel3.Controls.Add(this.grdOCS0103_P2);
            this.xPanel3.Controls.Add(this.grdOCS0103_P1);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel3.Location = new System.Drawing.Point(220, 156);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(740, 390);
            this.xPanel3.TabIndex = 24;
            // 
            // lblSelectAll_P2
            // 
            this.lblSelectAll_P2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblSelectAll_P2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelectAll_P2.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.lblSelectAll_P2.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.lblSelectAll_P2.Image = ((System.Drawing.Image)(resources.GetObject("lblSelectAll_P2.Image")));
            this.lblSelectAll_P2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSelectAll_P2.ImageIndex = 2;
            this.lblSelectAll_P2.ImageList = this.ImageList;
            this.lblSelectAll_P2.Location = new System.Drawing.Point(370, 0);
            this.lblSelectAll_P2.Name = "lblSelectAll_P2";
            this.lblSelectAll_P2.Size = new System.Drawing.Size(368, 24);
            this.lblSelectAll_P2.TabIndex = 18;
            this.lblSelectAll_P2.Text = " 全体選択";
            this.lblSelectAll_P2.Click += new System.EventHandler(this.lblSelectAll_P2_Click);
            // 
            // lblSelectAll_P1
            // 
            this.lblSelectAll_P1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblSelectAll_P1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelectAll_P1.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.lblSelectAll_P1.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.lblSelectAll_P1.Image = ((System.Drawing.Image)(resources.GetObject("lblSelectAll_P1.Image")));
            this.lblSelectAll_P1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSelectAll_P1.ImageIndex = 2;
            this.lblSelectAll_P1.ImageList = this.ImageList;
            this.lblSelectAll_P1.Location = new System.Drawing.Point(2, 0);
            this.lblSelectAll_P1.Name = "lblSelectAll_P1";
            this.lblSelectAll_P1.Size = new System.Drawing.Size(368, 24);
            this.lblSelectAll_P1.TabIndex = 17;
            this.lblSelectAll_P1.Text = " 全体選択";
            this.lblSelectAll_P1.Click += new System.EventHandler(this.lblSelectAll_P1_Click);
            // 
            // grdOCS0103_P2
            // 
            this.grdOCS0103_P2.AddedHeaderLine = 1;
            this.grdOCS0103_P2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdOCS0103_P2.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell19,
            this.xEditGridCell8,
            this.xEditGridCell17});
            this.grdOCS0103_P2.ColPerLine = 4;
            this.grdOCS0103_P2.Cols = 4;
            this.grdOCS0103_P2.FixedRows = 2;
            this.grdOCS0103_P2.HeaderHeights.Add(22);
            this.grdOCS0103_P2.HeaderHeights.Add(0);
            this.grdOCS0103_P2.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader2});
            this.grdOCS0103_P2.Location = new System.Drawing.Point(370, 24);
            this.grdOCS0103_P2.Name = "grdOCS0103_P2";
            this.grdOCS0103_P2.QuerySQL = resources.GetString("grdOCS0103_P2.QuerySQL");
            this.grdOCS0103_P2.Rows = 3;
            this.grdOCS0103_P2.RowStateCheckOnPaint = false;
            this.grdOCS0103_P2.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS0103_P2.Size = new System.Drawing.Size(368, 364);
            this.grdOCS0103_P2.TabIndex = 15;
            this.grdOCS0103_P2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0103_P2_MouseDown);
            this.grdOCS0103_P2.GridContDisplayed += new IHIS.Framework.XGridContDisplayedEventHandler(this.grdOCS0103_P2_GridContDisplayed);
            this.grdOCS0103_P2.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS0103_P2_GridCellPainting);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "slip_code";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.HeaderText = "slip_code";
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "position";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.HeaderText = "position";
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell11.CellName = "seq";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell11.CellWidth = 36;
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.HeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell11.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell11.HeaderText = "seq";
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            this.xEditGridCell11.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell11.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell12.ApplyPaintingEvent = true;
            this.xEditGridCell12.CellName = "hangmog_code";
            this.xEditGridCell12.CellWidth = 77;
            this.xEditGridCell12.Col = 1;
            this.xEditGridCell12.HeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell12.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell12.HeaderText = "項目コード";
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.Row = 1;
            this.xEditGridCell12.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell12.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell13.ApplyPaintingEvent = true;
            this.xEditGridCell13.CellName = "hangmog_name";
            this.xEditGridCell13.CellWidth = 184;
            this.xEditGridCell13.Col = 2;
            this.xEditGridCell13.HeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell13.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell13.HeaderText = "項目名";
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsUpdatable = false;
            this.xEditGridCell13.Row = 1;
            this.xEditGridCell13.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell13.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell14.ApplyPaintingEvent = true;
            this.xEditGridCell14.CellName = "specimen_code";
            this.xEditGridCell14.CellWidth = 45;
            this.xEditGridCell14.Col = 3;
            this.xEditGridCell14.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell14.HeaderText = "検体";
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsUpdatable = false;
            this.xEditGridCell14.RowSpan = 2;
            this.xEditGridCell14.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell14.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "group_yn";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.HeaderText = "group_yn";
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.IsUpdatable = false;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "bulyong_check";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.HeaderText = "bulyong_check";
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsUpdatable = false;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "specimen_base";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.HeaderText = "specimen_base";
            this.xEditGridCell19.IsUpdatable = false;
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "emergency";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "emergency";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell17.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell17.ApplyPaintingEvent = true;
            this.xEditGridCell17.CellName = "select";
            this.xEditGridCell17.CellWidth = 37;
            this.xEditGridCell17.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell17.HeaderText = "選択";
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.IsUpdatable = false;
            this.xEditGridCell17.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell17.RowSpan = 2;
            this.xEditGridCell17.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell17.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 1;
            this.xGridHeader2.ColSpan = 2;
            this.xGridHeader2.HeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridHeader2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridHeader2.HeaderText = "オ―ダコード";
            this.xGridHeader2.HeaderWidth = 77;
            this.xGridHeader2.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridHeader2.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // laySlip_Info
            // 
            this.laySlip_Info.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14});
            this.laySlip_Info.QuerySQL = resources.GetString("laySlip_Info.QuerySQL");
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "slip_gubun";
            this.multiLayoutItem9.IsNotNull = true;
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "slip_gubun_name";
            this.multiLayoutItem10.IsNotNull = true;
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "slip_code";
            this.multiLayoutItem11.IsNotNull = true;
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "slip_name";
            this.multiLayoutItem12.IsNotNull = true;
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "node1";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "node2";
            // 
            // laySpecimen
            // 
            this.laySpecimen.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem7,
            this.multiLayoutItem8});
            this.laySpecimen.QuerySQL = resources.GetString("laySpecimen.QuerySQL");
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "specimen_code";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "specimen_name";
            // 
            // OCS0103Q12
            // 
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.pnlSpecimen);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.tvwSlip_Info);
            this.Controls.Add(this.pictureBox1);
            this.Name = "OCS0103Q12";
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0103_P1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0103_P2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySlip_Info)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySpecimen)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]
		
		#region 현재 화면이 열려있는 경우에 호출을 받았을 경우 처리
		public override object Command(string command, CommonItemCollection commandParam)
		{	
			if(command == "F") return base.Command (command, commandParam);
		
			
			return base.Command (command, commandParam);
		}
		#endregion

		protected override void OnLoad(EventArgs e)
		{	
			base.OnLoad (e);

			// 처방입력시 팝업메뉴 초기화
			try
			{					
				popupMenu.MenuCommands.Clear();
				popupMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(NetInfo.Language == LangMode.Jr ? "検査情報照会" : "검사정보조회", (Image)this.ImageList.Images[4], 
					new EventHandler(this.PopUpMenuGumsaInfo_Click)));
			}
			catch{}

			//initial Size
			pnlSpecimen.SetBounds(pnlSpecimen.Location.X, pnlSpecimen.Location.Y, pnlSpecimen.Size.Width, 0);

			CreateLayout(laySelectOCS0103, grdOCS0103_P1);

			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

		private void PostLoad()
		{	
			laySlip_Info.QueryLayout(false);

			//Show TreeView 
			ShowSlip_Info();
		}
		
		/// <summary>
		/// DataLayout LayoutItems생성
		/// </summary>
		private void CreateLayout(MultiLayout  laySelectLayout, XGrid grd)
		{	
			foreach(XGridCell cell in grd.CellInfos)
			{
				laySelectLayout.LayoutItems.Add(cell.CellName, (DataType)cell.CellType);
			}

			laySelectLayout.InitializeLayoutTable();				
		}
		#endregion

		#region [TreeView Slip Info]
		private void ShowSlip_Info()
		{
			tvwSlip_Info.Nodes.Clear();
			if(laySlip_Info.RowCount < 1) return;

			string slip_gubun = "";
			int node1 = -1, node2 = -1;
			TreeNode node;

			foreach(DataRow row in laySlip_Info.LayoutTable.Rows)
			{
				if(slip_gubun != row["slip_gubun"].ToString())
				{
					node = new TreeNode( row["slip_gubun_name"].ToString() );
					node.Tag = row["slip_gubun"].ToString();
					tvwSlip_Info.Nodes.Add(node);
					slip_gubun = row["slip_gubun"].ToString();

					row["node1"] = -1;
					row["node1"] = -1;
					node1 = node1 + 1;
					node2 = -1;
				}

				node = new TreeNode( row["slip_name"].ToString() );
				node.Tag = row["slip_code"].ToString();
				node.ImageIndex = 2;
				node.SelectedImageIndex = 2;
				tvwSlip_Info.Nodes[tvwSlip_Info.Nodes.Count -1].Nodes.Add(node);

				node2 = node2 + 1;
				row["node1"] = node1;
				row["node2"] = node2;
			}

			tvwSlip_Info.SelectedNode = tvwSlip_Info.Nodes[0].Nodes[0];
		}

		private void tvwSlip_Info_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if(tvwSlip_Info.SelectedNode.Parent == null) return;

			try
			{
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;	
				
				mSpecimen = "";

				lblSlip_name.Text = "[" + tvwSlip_Info.SelectedNode.Tag.ToString() + "]" + tvwSlip_Info.SelectedNode.Text;			

				ShowSpecimen(tvwSlip_Info.SelectedNode.Tag.ToString());

				ShowOCS0103(tvwSlip_Info.SelectedNode.Tag.ToString(), "%");				
			}
			finally
			{					
				Cursor.Current = System.Windows.Forms.Cursors.Default;
			}
		}
		#endregion

		#region [Show OCS0103]
		/// <summary>
		/// 해당 사용자의 서식지에 대한 항목정보(OCS0103)를 Load합니다.
		/// </summary>
		private void ShowOCS0103(string arSlip_code, string arSpecimen_code)
		{
			//현재선택된 row trans
			//OCS0103 P1
			for(int i = 0; i < grdOCS0103_P1.RowCount; i++)
			{
				if(grdOCS0103_P1.GetItemString(i, "select") == " ")
				{	
					laySelectOCS0103.LayoutTable.ImportRow(grdOCS0103_P1.LayoutTable.Rows[i]);
				}
			}

			//OCS0103 P2
			for(int i = 0; i < grdOCS0103_P2.RowCount; i++)
			{
				if(grdOCS0103_P2.GetItemString(i, "select") == " ")
				{
					laySelectOCS0103.LayoutTable.ImportRow(grdOCS0103_P2.LayoutTable.Rows[i]);
				}
			}            

			//Position Ⅰ
			lblSelectAll_P1.ImageIndex = 2;
			lblSelectAll_P1.Text = " 全体選択";

			if(arSlip_code != "%") grdOCS0103_P1.SetBindVarValue("f_slip_code", arSlip_code);			
			grdOCS0103_P1.SetBindVarValue("f_specimen_code", arSpecimen_code);
			grdOCS0103_P1.SetBindVarValue("f_position", "1");
			if(grdOCS0103_P1.QueryLayout(true))
			{
				string slip_code = tvwSlip_Info.SelectedNode.Tag.ToString();

				for(int i = 0; i < grdOCS0103_P1.RowCount; i++)
				{
					for(int j = 0; j < laySelectOCS0103.RowCount; j++)
					{
						if(grdOCS0103_P1.GetItemString(i, "hangmog_code") == laySelectOCS0103.GetItemString(j, "hangmog_code"))
						{
							//이전에 선택한 항목이 있으면 선택상태로
							grdOCS0103_P1.SetItemValue(i, "select", " ");
							//이전 선택정보 삭제
							laySelectOCS0103.LayoutTable.Rows.Remove(laySelectOCS0103.LayoutTable.Rows[j]);
						}
					}
				}            
				
				if(chkEmergency.Checked)
				{
					for(int i = 0; i < grdOCS0103_P1.RowCount; i++)
					{
						grdOCS0103_P1.SetItemValue(i, "emergency", "Y");
					}
				}

				SelectionBackColorChange(grdOCS0103_P1);
			}

			//Position Ⅱ
			lblSelectAll_P1.ImageIndex = 2;
			lblSelectAll_P1.Text = " 全体選択";
			
			if(arSlip_code != "%") grdOCS0103_P2.SetBindVarValue("f_slip_code", arSlip_code);
			grdOCS0103_P2.SetBindVarValue("f_specimen_code", arSpecimen_code);
			grdOCS0103_P2.SetBindVarValue("f_position", "2");
			if(grdOCS0103_P2.QueryLayout(true))
			{
				string slip_code = tvwSlip_Info.SelectedNode.Tag.ToString();

				for(int i = 0; i < grdOCS0103_P2.RowCount; i++)
				{
					for(int j = 0; j < laySelectOCS0103.RowCount; j++)
					{
						if(grdOCS0103_P2.GetItemString(i, "hangmog_code") == laySelectOCS0103.GetItemString(j, "hangmog_code"))
						{
							//이전에 선택한 항목이 있으면 선택상태로
							grdOCS0103_P2.SetItemValue(i, "select", " ");
							//이전 선택정보 삭제
							laySelectOCS0103.LayoutTable.Rows.Remove(laySelectOCS0103.LayoutTable.Rows[j]);
						}
					}
				}

				if(chkEmergency.Checked)
				{	
					for(int i = 0; i < grdOCS0103_P1.RowCount; i++)
					{
						grdOCS0103_P2.SetItemValue(i, "emergency", "Y");
					}
				}

				SelectionBackColorChange(grdOCS0103_P2);
			}
		}		
		#endregion

		#region [Show Specimen]
		/// <summary>
		/// 해당 사용자의 서식지에 대한 검체코드를 보여줍니다.
		/// </summary>
		private void ShowSpecimen(string arSlip_code)
		{				
			//Clear Specimen Control
			pnlSpecimen.Controls.Clear();

			laySpecimen.SetBindVarValue("f_slip_code", arSlip_code);
			laySpecimen.QueryLayout(true);

			if(laySpecimen.RowCount < 1)
				pnlSpecimen.SetBounds(pnlSpecimen.Location.X, pnlSpecimen.Location.Y, pnlSpecimen.Size.Width, 0);
			else
			{
				this.SuspendLayout();
				CreateSpecimenControl(laySpecimen);
				pnlSpecimen.SetBounds(pnlSpecimen.Location.X, pnlSpecimen.Location.Y, pnlSpecimen.Size.Width, 118);
				this.ResumeLayout();
			}
		}

		private void CreateSpecimenControl(MultiLayout laySpecimen)
		{
			int setPositionX = 8, setPositionY = 6;
			int MaxPositionX = 540;

			XFlatRadioButton rbtSpecimen;

			//전체추가
			if(laySpecimen.RowCount > 0)
			{
				//Specimen RadioButton 생성
				rbtSpecimen = new IHIS.Framework.XFlatRadioButton();
				rbtSpecimen.BackColor = IHIS.Framework.XColor.XRadioButtonBackColor;
				rbtSpecimen.Cursor = System.Windows.Forms.Cursors.Hand;
				rbtSpecimen.Location =  new System.Drawing.Point(setPositionX, setPositionY);
				rbtSpecimen.Name = "rbt" + "ALL";
				rbtSpecimen.Size = new System.Drawing.Size(175, 20);				
				rbtSpecimen.Text = "全体";
				rbtSpecimen.Tag  = "%";
				rbtSpecimen.Click += new System.EventHandler(this.RadioButton_Click);				

				rbtSpecimen.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
				rbtSpecimen.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
				rbtSpecimen.Checked = true;

				setPositionX = setPositionX + 175;
				
				pnlSpecimen.Controls.Add(rbtSpecimen);
			}

			foreach(DataRow row in laySpecimen.LayoutTable.Rows)
			{
				if(MaxPositionX < setPositionX)
				{
					setPositionX = 8;
					setPositionY = setPositionY + 20;
				}

				//Specimen RadioButton 생성
				rbtSpecimen = new IHIS.Framework.XFlatRadioButton();
				rbtSpecimen.BackColor = IHIS.Framework.XColor.XRadioButtonBackColor;
				rbtSpecimen.Cursor = System.Windows.Forms.Cursors.Hand;
				rbtSpecimen.Location =  new System.Drawing.Point(setPositionX, setPositionY);
				rbtSpecimen.Name = "rbt" + row["specimen_code"].ToString();
				rbtSpecimen.Size = new System.Drawing.Size(175, 20);				
				rbtSpecimen.Text = row["specimen_name"].ToString();
				rbtSpecimen.Tag  = row["specimen_code"].ToString();
				rbtSpecimen.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
				rbtSpecimen.Click += new System.EventHandler(this.RadioButton_Click);

				setPositionX = setPositionX + 175;
				
				pnlSpecimen.Controls.Add(rbtSpecimen);
			}
		}
		
		private void RadioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			XFlatRadioButton rbtSpecimen = sender as XFlatRadioButton;

			mSpecimen = "";

			if(rbtSpecimen.Checked)
			{
				mSpecimen = rbtSpecimen.Tag.ToString();
				rbtSpecimen.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
				rbtSpecimen.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
			}
			else 
			{
				rbtSpecimen.BackColor = XColor.XRadioButtonBackColor;
				rbtSpecimen.ForeColor = XColor.NormalForeColor;
			}
            			 
//			if(mSpecimen != "%")
//			{
//				if(grdOCS0103_P1.RowCount > 0) grdOCS0103_P1.SetFilter(" specimen_code = '" + mSpecimen + "' ");
//				if(grdOCS0103_P2.RowCount > 0) grdOCS0103_P2.SetFilter(" specimen_code = '" + mSpecimen + "' ");
//			}

//			SelectionBackColorChange(grdOCS0103_P1);
//			SelectionBackColorChange(grdOCS0103_P2);

			ShowOCS0103("%", mSpecimen);
		}

		private void RadioButton_Click(object sender, System.EventArgs e)
		{
			XFlatRadioButton rbtSpecimen = sender as XFlatRadioButton;

			mSpecimen = "";

			if(rbtSpecimen.Checked)
			{
				foreach(object obj in pnlSpecimen.Controls)
				{
					((XFlatRadioButton)obj).BackColor = XColor.XRadioButtonBackColor;
					((XFlatRadioButton)obj).ForeColor = XColor.NormalForeColor;
				}

				mSpecimen = rbtSpecimen.Tag.ToString();
				rbtSpecimen.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
				rbtSpecimen.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
			}

			ShowOCS0103("%", mSpecimen);		
		}
		#endregion

		#region [Button List]
		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Process:
					e.IsBaseCall = false;
					CreateReturnLayout();				
					break;
				default:
					break;
			}			
		}
		#endregion

		#region [Return Layout 생성]
		private void CreateReturnLayout()
		{
			this.AcceptData();
			
			//OCS0103
			for(int i = 0; i < grdOCS0103_P1.RowCount; i++)
			{
				if(grdOCS0103_P1.GetItemString(i, "select") == " ")
					laySelectOCS0103.LayoutTable.ImportRow(grdOCS0103_P1.LayoutTable.Rows[i]);
			}

			for(int i = 0; i < grdOCS0103_P2.RowCount; i++)
			{
				if(grdOCS0103_P2.GetItemString(i, "select") == " ")
					laySelectOCS0103.LayoutTable.ImportRow(grdOCS0103_P2.LayoutTable.Rows[i]);
			}
			
			if(laySelectOCS0103.LayoutTable.Rows.Count < 1 )
			{				
				mbxMsg = NetInfo.Language == LangMode.Jr ? "オーダが選択されませんでした。ご確認下さい。" : "처방이 선택되지 않았습니다. 확인하세요.";
				mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인";
				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
				return;				
			}	
 
			
			//약속코드선택정보가 있는 경우 Return Value
			IHIS.Framework.XScreen scrOpener = (XScreen)Opener;	

			CommonItemCollection commandParams  = new CommonItemCollection();
			commandParams.Add( "OCS0103", laySelectOCS0103);
			scrOpener.Command(ScreenID, commandParams);

			ClearSelect();

			this.Close();
		}
		#endregion

		#region [Grid Event]
		private void grdOCS0103_P1_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if(e.DataRow["bulyong_check"].ToString() == "Y")
			{
				e.BackColor = ((XEditGridCell)grdOCS0103_P1.CellInfos[e.ColName]).RowBackColor.Color;
				e.ForeColor = Color.Red;
			}
		}

		private void grdOCS0103_P1_GridContDisplayed(object sender, IHIS.Framework.XGridContDisplayedEventArgs e)
		{
			SelectionBackColorChange(sender);
		}

		private void grdOCS0103_P1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int rowIndex = -1;

			if(e.Button == MouseButtons.Left && e.Clicks == 1)
			{
				rowIndex = grdOCS0103_P1.GetHitRowNumber(e.Y);				
				if(rowIndex < 0) return;

				if(grdOCS0103_P1.CurrentColNumber == 0)
				{	
					//불용처리된 것은 선택을 막는다.
					if(grdOCS0103_P1.GetItemString(rowIndex, "bulyong_check") == "Y") return;

					if(grdOCS0103_P1.GetItemString(rowIndex, "select") == "")
					{
						grdOCS0103_P1.SetItemValue(rowIndex, "select", " ");
						SelectionBackColorChange(sender, rowIndex, "Y");
					}
					else
					{
						grdOCS0103_P1.SetItemValue(rowIndex, "select", "");
						SelectionBackColorChange(sender, rowIndex, "N");
					}

					SetSelectTab();
				}
			}	
			else if (e.Button == MouseButtons.Right && e.Clicks == 1)
			{
				rowIndex = grdOCS0103_P1.GetHitRowNumber(e.Y);
				if(rowIndex < 0) return;

				if(grdOCS0103_P1.GetItemString(rowIndex, "slip_code").Substring(0, 1) != "B") return;

				popupMenu.TrackPopup(((IHIS.Framework.XEditGrid)sender).PointToScreen(new Point(e.X,e.Y)));
			}
		}

		private void grdOCS0103_P2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int rowIndex = -1;

			if(e.Button == MouseButtons.Left && e.Clicks == 1)
			{
				rowIndex = grdOCS0103_P2.GetHitRowNumber(e.Y);				
				if(rowIndex < 0) return;

				if(grdOCS0103_P2.CurrentColNumber == 0)
				{
					//불용처리된 것은 선택을 막는다.
					if(grdOCS0103_P2.GetItemString(rowIndex, "bulyong_check") == "Y") return;

					if(grdOCS0103_P2.GetItemString(rowIndex, "select") == "")
					{
						grdOCS0103_P2.SetItemValue(rowIndex, "select", " ");
						SelectionBackColorChange(sender, rowIndex, "Y");
					}
					else
					{
						grdOCS0103_P2.SetItemValue(rowIndex, "select", "");
						SelectionBackColorChange(sender, rowIndex, "N");
					}

					SetSelectTab();
				}
			}	
			else if (e.Button == MouseButtons.Right && e.Clicks == 1)
			{
				rowIndex = grdOCS0103_P2.GetHitRowNumber(e.Y);
				if(rowIndex < 0) return;

				if(grdOCS0103_P2.GetItemString(rowIndex, "slip_code").Substring(0, 1) != "B") return;

				popupMenu.TrackPopup(((IHIS.Framework.XEditGrid)sender).PointToScreen(new Point(e.X,e.Y)));
			}
		}

		private void grdOCS0103_P2_GridContDisplayed(object sender, IHIS.Framework.XGridContDisplayedEventArgs e)
		{
			SelectionBackColorChange(sender);
		}

		private void grdOCS0103_P2_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if(e.DataRow["bulyong_check"].ToString() == "Y")
			{
				e.BackColor = ((XEditGridCell)grdOCS0103_P2.CellInfos[e.ColName]).RowBackColor.Color;
				e.ForeColor = Color.Red;
			}
		}
		#endregion

		#region [Control Event]
		private void chkEmergency_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkEmergency.Checked)
			{
				chkEmergency.BackColor = System.Drawing.SystemColors.ActiveCaption;
				chkEmergency.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
				chkEmergency.ImageIndex = 3;

				for(int i = 0; i < grdOCS0103_P1.RowCount; i++)
				{
					grdOCS0103_P1.SetItemValue(i, "emergency", "Y");
				}

				for(int i = 0; i < grdOCS0103_P2.RowCount; i++)
				{
					grdOCS0103_P2.SetItemValue(i, "emergency", "Y");
				}
			}
			else
			{
				chkEmergency.BackColor = System.Drawing.SystemColors.InactiveCaption;
				chkEmergency.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
				chkEmergency.ImageIndex = 2;

				for(int i = 0; i < grdOCS0103_P1.RowCount; i++)
				{
					grdOCS0103_P1.SetItemValue(i, "emergency", "N");
				}

				for(int i = 0; i < grdOCS0103_P2.RowCount; i++)
				{
					grdOCS0103_P2.SetItemValue(i, "emergency", "Y");
				}
			}
		}

		private void lblSelectAll_P1_Click(object sender, System.EventArgs e)
		{
			if(lblSelectAll_P1.ImageIndex == 2)
			{
				grdSelectAll(this.grdOCS0103_P1, true);
				lblSelectAll_P1.ImageIndex = 3;
				lblSelectAll_P1.Text = " 全体選択取消";
			}
			else
			{
				grdSelectAll(this.grdOCS0103_P1, false);
				lblSelectAll_P1.ImageIndex = 2;
				lblSelectAll_P1.Text = " 全体選択";
			}

			SetSelectTab();
		}

		private void lblSelectAll_P2_Click(object sender, System.EventArgs e)
		{
			if(lblSelectAll_P2.ImageIndex == 2)
			{
				grdSelectAll(this.grdOCS0103_P2, true);
				lblSelectAll_P2.ImageIndex = 3;
				lblSelectAll_P2.Text = " 全体選択取消";
			}
			else
			{
				grdSelectAll(this.grdOCS0103_P2, false);
				lblSelectAll_P2.ImageIndex = 2;
				lblSelectAll_P2.Text = " 全体選択";
			}

			SetSelectTab();
		}

		private void btnCPLInfo_Click(object sender, System.EventArgs e)
		{
			if (this.CurrMQLayout != grdOCS0103_P1 && this.CurrMQLayout != grdOCS0103_P2) return;

			int rowIndex = this.CurrMQLayout.CurrentRowNumber;
			if(rowIndex < 0) return;

			if(this.CurrMQLayout.GetItemValue(rowIndex, "slip_code").ToString().Substring(0, 1) != "B") return;

			popupMenu.MenuCommands[0].OnClick(null);
		}

		private void btnProClose_Click(object sender, System.EventArgs e)
		{
			CreateReturnLayout();
		}

		private void btnProcess_Click(object sender, System.EventArgs e)
		{
			CreateReturnLayout();
		}

		#endregion

		#region [Function]
		private void grdSelectAll(XGrid grdObject, bool select)
		{
			int rowIndex = -1;

			if(select)
			{
				for(rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
				{
					if(grdObject.GetItemString( rowIndex, "bulyong_check") != "Y" ) grdObject.SetItemValue(rowIndex, "select", " ");
				}
			}
			else
			{
				for(rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
				{
					if(grdObject.GetItemString( rowIndex, "bulyong_check") != "Y" ) grdObject.SetItemValue(rowIndex, "select", "");
				}
			}

			SelectionBackColorChange(grdObject);

			SetSelectTab();

		}

		private void ClearSelect()
		{
			//선택된 Tab
			ClearSelectTab();

			//선택된 row Clear
			for(int i = 0; i < this.grdOCS0103_P1.RowCount; i++)
			{
				grdOCS0103_P1.SetItemValue(i, "select", "");
			}

			SelectionBackColorChange(grdOCS0103_P1);

			//선택된 row Clear
			for(int i = 0; i < this.grdOCS0103_P2.RowCount; i++)
			{
				grdOCS0103_P2.SetItemValue(i, "select", "");
			}

			SelectionBackColorChange(grdOCS0103_P2);

			laySelectOCS0103.Reset();
		}

		/// <summary>
		/// tab의 이미지를 Clear한다.
		/// </summary>
		private void ClearSelectTab()
		{
			int node1 = -1, node2 = -1;
			foreach(DataRow row in laySlip_Info.LayoutTable.Rows)
			{
				node1 = int.Parse(row["node1"].ToString());
				node2 = int.Parse(row["node2"].ToString());
				tvwSlip_Info.Nodes[node1].Nodes[node2].ImageIndex = 2;
				tvwSlip_Info.Nodes[node1].Nodes[node2].SelectedImageIndex = 2;
			}
		}
        
		/// <summary>
		/// 선택된 항목이 있는 경우 tab의 이미지를 변경한다.
		/// 조건검색에 따른 항목조회가 있기 때문에 선택된 항목 전체를 check한다.
		/// </summary>
		private void SetSelectTab()
		{			
			DataRow[] slip_code;
			int node1 = -1, node2 = -1, imageIndex = 2;

			//선택된 항목
			//space는 filter를 못함 --;
			for(int rowIndex = 0; rowIndex < grdOCS0103_P1.RowCount; rowIndex++)
			{				
				//해당 항목의 slip_code정보를 가져온다.
				slip_code = laySlip_Info.LayoutTable.Select(" slip_code = '" + grdOCS0103_P1.GetItemString(rowIndex, "slip_code") + "' " );
                
				if(slip_code.Length < 1) continue;
				node1 = int.Parse(slip_code[0]["node1"].ToString());
				node2 = int.Parse(slip_code[0]["node2"].ToString());

				if(grdOCS0103_P1.GetItemString(rowIndex, "select") == "") continue;
				imageIndex = 3;
				break;
			}

			//선택된 항목
			//space는 filter를 못함 --;
			for(int rowIndex = 0; rowIndex < grdOCS0103_P2.RowCount; rowIndex++)
			{
				if(imageIndex == 3) break;

				//해당 항목의 slip_code정보를 가져온다.
				slip_code = laySlip_Info.LayoutTable.Select(" slip_code = '" + grdOCS0103_P2.GetItemString(rowIndex, "slip_code") + "' " );
                
				if(slip_code.Length < 1) continue;
				node1 = int.Parse(slip_code[0]["node1"].ToString());
				node2 = int.Parse(slip_code[0]["node2"].ToString());

				if(grdOCS0103_P2.GetItemString(rowIndex, "select") == "") continue;                
				imageIndex = 3;				
				break;
			}

			if(node1 != -1)
			{
				tvwSlip_Info.Nodes[node1].Nodes[node2].ImageIndex = imageIndex;
				tvwSlip_Info.Nodes[node1].Nodes[node2].SelectedImageIndex = imageIndex;
			}
		}
		#endregion

		#region [검사정보조회]
		// 검사정보조회
		private void PopUpMenuGumsaInfo_Click(object sender, System.EventArgs e)
		{
			if(this.CurrMSLayout == null || CurrMSLayout.CurrentRowNumber < 0) return;

			CommonItemCollection openParams  = new CommonItemCollection();
			openParams.Add("hangmog_code", CurrMSLayout.GetItemValue(CurrMSLayout.CurrentRowNumber, "hangmog_code"));
			XScreen.OpenScreenWithParam(this, "CPLS", "CPL0000Q01", ScreenOpenStyle.ResponseFixed, openParams);			
		}

		#endregion

		#region 그리드에서 선택한 Row에 대한 BackColor를 변경한다
		private void SelectionBackColorChange(object grid, int currentRowIndex, string data)
		{
			XEditGrid grdObject = (XEditGrid)grid;          
            
			//선택된 Row에대해서 색을 변경한다
			//data   Y :색을 변경, N :색을 변경 해제
			//image 설정
			if(data == "Y")
			{
				grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[3];
			}
			else
			{
				grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[2];
			}

			for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
			{
				if(data == "Y")
				{
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
				}
				else 
				{
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
				}
			}
		}

		
		private void SelectionBackColorChange(object grid)
		{
			XEditGrid grdObject = (XEditGrid)grid;

			//기존의 색으로 변경을 시킨다
			for(int rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
			{	
				try
				{
					if(grdObject[rowIndex + grdObject.HeaderHeights.Count, 0] == null) break;
				}
				catch
				{
					break;
				}
				
				//불용은 넘어간다.
				if(grdObject.GetItemString(rowIndex, "bulyong_check") == "Y") continue;

				if(grdObject.GetItemString(rowIndex, "select").ToString() == " " )
				{
					//image 변경
					grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[3];					

					//ColorYn Y :색을 변경, N :색을 변경 해제
					for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
					{					
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
					}
				}
				else
				{
					//image 변경
					grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[2];
					for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
					{					
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
					}
				}
			}
		}
		#endregion

	}
}

