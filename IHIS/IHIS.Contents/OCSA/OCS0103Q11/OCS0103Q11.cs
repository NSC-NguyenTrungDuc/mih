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

/*
 * OCS.Lib 작업이 남아 있음 
 */

namespace IHIS.OCSA
{
	/// <summary>
	/// OCS0103Q11에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS0103Q11 : IHIS.Framework.XScreen
	{
		#region [OCS Library]
		private IHIS.OCS.OrderBiz  mOrderBiz  = null;         // OCS 그룹 Business 라이브러리
		private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리		
		private IHIS.OCS.HangmogInfo mHangmogInfo = null;     // OCS 항목정보 그룹 라이브러리
		#endregion

		private string mbxMsg = "", mbxCap = "";
		private IHIS.Framework.MultiLayout laySelectOCS0103 = new MultiLayout();
		
		private string mQueryMode = "0";
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XTextBox txtHangmog_index;
		private IHIS.Framework.XPictureBox xPictureBox1;
		private IHIS.Framework.XPanel xPanel2;
		private System.Windows.Forms.TreeView tvwXRT0101;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XGrid grdOCS0103;
		private IHIS.Framework.XGridCell xGridCell1;
		private IHIS.Framework.XGridCell xGridCell2;
		private IHIS.Framework.XGridCell xGridCell3;
		private IHIS.Framework.XButton btnProcess;
		private IHIS.Framework.XGridCell xGridCell7;
		private IHIS.Framework.XGridCell xGridCell8;
		private IHIS.Framework.XGridCell xGridCell9;
		private IHIS.Framework.XGridCell xGridCell10;
		private IHIS.Framework.XGridCell xGridCell4;
		private System.Windows.Forms.CheckBox chkPortable_yn;
		private System.Windows.Forms.CheckBox chkEmergency;
		private IHIS.Framework.XGridCell xGridCell5;
		private IHIS.Framework.XGridCell xGridCell6;
		private IHIS.Framework.XButton btnProClose;
		private IHIS.Framework.XGridCell xGridCell11;
		private IHIS.Framework.XLabel lblSelectAll;
		private IHIS.Framework.MultiLayout layXRT0101;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem1;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem2;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem3;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem4;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem5;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem6;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OCS0103Q11()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
			this.mOrderBiz  = new IHIS.OCS.OrderBiz();                      // OCS 그룹 Business 라이브러리
			this.mOrderFunc = new IHIS.OCS.OrderFunc();                     // OCS 그룹 Function 라이브러리			
			this.mHangmogInfo = new IHIS.OCS.HangmogInfo(this.ScreenID);    // OCS 항목정보 그룹 라이브러리
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OCS0103Q11));
			this.xPanel1 = new IHIS.Framework.XPanel();
			this.chkEmergency = new System.Windows.Forms.CheckBox();
			this.xLabel1 = new IHIS.Framework.XLabel();
			this.txtHangmog_index = new IHIS.Framework.XTextBox();
			this.chkPortable_yn = new System.Windows.Forms.CheckBox();
			this.xPictureBox1 = new IHIS.Framework.XPictureBox();
			this.xPanel2 = new IHIS.Framework.XPanel();
			this.btnProClose = new IHIS.Framework.XButton();
			this.btnProcess = new IHIS.Framework.XButton();
			this.xButtonList1 = new IHIS.Framework.XButtonList();
			this.tvwXRT0101 = new System.Windows.Forms.TreeView();
			this.grdOCS0103 = new IHIS.Framework.XGrid();
			this.xGridCell1 = new IHIS.Framework.XGridCell();
			this.xGridCell2 = new IHIS.Framework.XGridCell();
			this.xGridCell3 = new IHIS.Framework.XGridCell();
			this.xGridCell7 = new IHIS.Framework.XGridCell();
			this.xGridCell4 = new IHIS.Framework.XGridCell();
			this.xGridCell11 = new IHIS.Framework.XGridCell();
			this.xGridCell8 = new IHIS.Framework.XGridCell();
			this.xGridCell9 = new IHIS.Framework.XGridCell();
			this.xGridCell10 = new IHIS.Framework.XGridCell();
			this.xGridCell5 = new IHIS.Framework.XGridCell();
			this.xGridCell6 = new IHIS.Framework.XGridCell();
			this.lblSelectAll = new IHIS.Framework.XLabel();
			this.layXRT0101 = new IHIS.Framework.MultiLayout();
			this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
			this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
			this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
			this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
			this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
			this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
			this.xPanel1.SuspendLayout();
			this.xPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdOCS0103)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layXRT0101)).BeginInit();
			this.SuspendLayout();
			// 
			// ImageList
			// 
			this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
			// 
			// xPanel1
			// 
			this.xPanel1.Controls.Add(this.chkEmergency);
			this.xPanel1.Controls.Add(this.xLabel1);
			this.xPanel1.Controls.Add(this.txtHangmog_index);
			this.xPanel1.Controls.Add(this.chkPortable_yn);
			this.xPanel1.Controls.Add(this.xPictureBox1);
			this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.xPanel1.DrawBorder = true;
			this.xPanel1.Location = new System.Drawing.Point(0, 0);
			this.xPanel1.Name = "xPanel1";
			this.xPanel1.Size = new System.Drawing.Size(756, 28);
			this.xPanel1.TabIndex = 7;
			// 
			// chkEmergency
			// 
			this.chkEmergency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkEmergency.Appearance = System.Windows.Forms.Appearance.Button;
			this.chkEmergency.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.chkEmergency.Cursor = System.Windows.Forms.Cursors.Hand;
			this.chkEmergency.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.chkEmergency.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkEmergency.ImageIndex = 2;
			this.chkEmergency.ImageList = this.ImageList;
			this.chkEmergency.Location = new System.Drawing.Point(646, 2);
			this.chkEmergency.Name = "chkEmergency";
			this.chkEmergency.Size = new System.Drawing.Size(88, 24);
			this.chkEmergency.TabIndex = 20;
			this.chkEmergency.Text = "       至急";
			this.chkEmergency.CheckedChanged += new System.EventHandler(this.chkEmergency_CheckedChanged);
			// 
			// xLabel1
			// 
			this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
			this.xLabel1.EdgeRounding = false;
			this.xLabel1.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
			this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
			this.xLabel1.Location = new System.Drawing.Point(2, 4);
			this.xLabel1.Name = "xLabel1";
			this.xLabel1.Size = new System.Drawing.Size(82, 20);
			this.xLabel1.TabIndex = 18;
			this.xLabel1.Text = "検索語";
			this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtHangmog_index
			// 
			this.txtHangmog_index.Location = new System.Drawing.Point(84, 4);
			this.txtHangmog_index.Name = "txtHangmog_index";
			this.txtHangmog_index.Size = new System.Drawing.Size(430, 20);
			this.txtHangmog_index.TabIndex = 17;
			this.txtHangmog_index.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtHangmog_index_DataValidating);
			// 
			// chkPortable_yn
			// 
			this.chkPortable_yn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkPortable_yn.Appearance = System.Windows.Forms.Appearance.Button;
			this.chkPortable_yn.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.chkPortable_yn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.chkPortable_yn.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.chkPortable_yn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkPortable_yn.ImageIndex = 2;
			this.chkPortable_yn.ImageList = this.ImageList;
			this.chkPortable_yn.Location = new System.Drawing.Point(558, 2);
			this.chkPortable_yn.Name = "chkPortable_yn";
			this.chkPortable_yn.Size = new System.Drawing.Size(88, 24);
			this.chkPortable_yn.TabIndex = 7;
			this.chkPortable_yn.Text = "     移動撮影";
			this.chkPortable_yn.Visible = false;
			this.chkPortable_yn.CheckedChanged += new System.EventHandler(this.chkPortable_yn_CheckedChanged);
			// 
			// xPictureBox1
			// 
			this.xPictureBox1.BackColor = IHIS.Framework.XColor.XMonthCalendarBackColor;
			this.xPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.xPictureBox1.Location = new System.Drawing.Point(0, 0);
			this.xPictureBox1.Name = "xPictureBox1";
			this.xPictureBox1.Protect = false;
			this.xPictureBox1.Size = new System.Drawing.Size(754, 26);
			this.xPictureBox1.TabIndex = 19;
			this.xPictureBox1.TabStop = false;
			// 
			// xPanel2
			// 
			this.xPanel2.Controls.Add(this.btnProClose);
			this.xPanel2.Controls.Add(this.btnProcess);
			this.xPanel2.Controls.Add(this.xButtonList1);
			this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.xPanel2.DrawBorder = true;
			this.xPanel2.Location = new System.Drawing.Point(0, 542);
			this.xPanel2.Name = "xPanel2";
			this.xPanel2.Size = new System.Drawing.Size(756, 40);
			this.xPanel2.TabIndex = 8;
			// 
			// btnProClose
			// 
			this.btnProClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnProClose.Image = ((System.Drawing.Image)(resources.GetObject("btnProClose.Image")));
			this.btnProClose.Location = new System.Drawing.Point(349, 7);
			this.btnProClose.Name = "btnProClose";
			this.btnProClose.Size = new System.Drawing.Size(114, 28);
			this.btnProClose.TabIndex = 7;
			this.btnProClose.Text = "選択後閉じる";
			this.btnProClose.Visible = false;
			this.btnProClose.Click += new System.EventHandler(this.btnProClose_Click);
			// 
			// btnProcess
			// 
			this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnProcess.Image = ((System.Drawing.Image)(resources.GetObject("btnProcess.Image")));
			this.btnProcess.Location = new System.Drawing.Point(463, 7);
			this.btnProcess.Name = "btnProcess";
			this.btnProcess.Size = new System.Drawing.Size(98, 28);
			this.btnProcess.TabIndex = 5;
			this.btnProcess.Text = "選択";
			this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
			// 
			// xButtonList1
			// 
			this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xButtonList1.IsVisibleReset = false;
			this.xButtonList1.Location = new System.Drawing.Point(562, 4);
			this.xButtonList1.Name = "xButtonList1";
			this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
			this.xButtonList1.Size = new System.Drawing.Size(163, 34);
			this.xButtonList1.TabIndex = 0;
			// 
			// tvwXRT0101
			// 
			this.tvwXRT0101.BackColor = System.Drawing.SystemColors.Window;
			this.tvwXRT0101.Dock = System.Windows.Forms.DockStyle.Left;
			this.tvwXRT0101.HideSelection = false;
			this.tvwXRT0101.ImageList = this.ImageList;
			this.tvwXRT0101.Location = new System.Drawing.Point(0, 28);
			this.tvwXRT0101.Name = "tvwXRT0101";
			this.tvwXRT0101.SelectedImageIndex = 1;
			this.tvwXRT0101.Size = new System.Drawing.Size(280, 514);
			this.tvwXRT0101.TabIndex = 10;
			this.tvwXRT0101.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwXRT0101_AfterSelect);
			// 
			// grdOCS0103
			// 
			this.grdOCS0103.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.grdOCS0103.ApplyPaintEventToAllColumn = true;
			this.grdOCS0103.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
																				  this.xGridCell1,
																				  this.xGridCell2,
																				  this.xGridCell3,
																				  this.xGridCell7,
																				  this.xGridCell4,
																				  this.xGridCell11,
																				  this.xGridCell8,
																				  this.xGridCell9,
																				  this.xGridCell10,
																				  this.xGridCell5,
																				  this.xGridCell6});
			this.grdOCS0103.ColPerLine = 4;
			this.grdOCS0103.Cols = 4;
			this.grdOCS0103.EnableMultiSelection = true;
			this.grdOCS0103.FixedRows = 1;
			this.grdOCS0103.HeaderHeights.Add(21);
			this.grdOCS0103.Location = new System.Drawing.Point(280, 56);
			this.grdOCS0103.Name = "grdOCS0103";
			this.grdOCS0103.QuerySQL = "SELECT B.HANGMOG_CODE                                           HANGMOG_CODE   ,\r" +
				"\n       B.HANGMOG_NAME                                           HANGMOG_NAME   " +
				",\r\n       FN_OCS_BULYONG_CHECK_OUT(B.HANGMOG_CODE, TRUNC(SYSDATE)) BULYONG_CHECK" +
				"  ,\r\n       B.SLIP_CODE                                              SLIP_CODE  " +
				"    ,\r\n       NVL(A.XRAY_CNT, 1)                                       XRAY_CNT " +
				"      ,\r\n       A.XRAY_GUBUN                                             XRAY_GU" +
				"BUN     ,\r\n       A.XRAY_BUWI                                              XRAY_" +
				"BUWI      ,\r\n       B.PORTABLE_YN                                            POR" +
				"TABLE_YN    ,\r\n       B.PORTABLE_YN                                            P" +
				"ORTABLE_YN_BAS\r\n  FROM XRT0001 A,\r\n       OCS0103 B\r\n WHERE :f_query_mode  =  \'0" +
				"\'\r\n   AND A.XRAY_GUBUN   = :f_xray_gubun\r\n   AND A.XRAY_BUWI    = :f_xray_buwi\r\n" +
				"   AND B.HANGMOG_CODE = A.XRAY_CODE\r\n   AND FN_OCS_BULYONG_CHECK_OUT(B.HANGMOG_C" +
				"ODE, TRUNC(SYSDATE)) = \'N\'\r\n UNION ALL\r\nSELECT A.HANGMOG_CODE                   " +
				"                        HANGMOG_CODE   ,\r\n       A.HANGMOG_NAME                 " +
				"                          HANGMOG_NAME   ,\r\n       FN_OCS_BULYONG_CHECK_OUT(A.HA" +
				"NGMOG_CODE, TRUNC(SYSDATE)) BULYONG_CHECK  ,\r\n       A.SLIP_CODE                " +
				"                              SLIP_CODE      ,\r\n       NVL(B.XRAY_CNT, 1)       " +
				"                                XRAY_CNT       ,\r\n       B.XRAY_GUBUN           " +
				"                                  XRAY_GUBUN     ,\r\n       B.XRAY_BUWI          " +
				"                                    XRAY_BUWI      ,\r\n       A.PORTABLE_YN      " +
				"                                      PORTABLE_YN    ,\r\n       A.PORTABLE_YN    " +
				"                                        PORTABLE_YN_BAS\r\n  FROM OCS0103 A,\r\n    " +
				"   XRT0001 B\r\n WHERE :f_query_mode      =  \'1\'\r\n   AND A.HANGMOG_NAME_INX LIKE \'" +
				"%\'||:f_hangmog_name_inx||\'%\'\r\n   AND B.XRAY_CODE        =    A.HANGMOG_CODE\r\n   " +
				"AND FN_OCS_BULYONG_CHECK_OUT(A.HANGMOG_CODE, TRUNC(SYSDATE)) = \'N\'\r\n ORDER BY HA" +
				"NGMOG_CODE";
			this.grdOCS0103.Rows = 2;
			this.grdOCS0103.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
			this.grdOCS0103.Size = new System.Drawing.Size(474, 486);
			this.grdOCS0103.TabIndex = 9;
			this.grdOCS0103.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0103_MouseDown);
			this.grdOCS0103.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS0103_QueryEnd);
			this.grdOCS0103.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdOCS0103_DragDrop);
			this.grdOCS0103.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS0103_GridCellPainting);
			this.grdOCS0103.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdOCS0103_DragEnter);
			this.grdOCS0103.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdOCS0103_GiveFeedback);
			// 
			// xGridCell1
			// 
			this.xGridCell1.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xGridCell1.ApplyPaintingEvent = true;
			this.xGridCell1.CellName = "hangmog_code";
			this.xGridCell1.CellWidth = 74;
			this.xGridCell1.Col = 1;
			this.xGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
			this.xGridCell1.HeaderText = "オ―ダコード";
			this.xGridCell1.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
			this.xGridCell1.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
			// 
			// xGridCell2
			// 
			this.xGridCell2.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xGridCell2.ApplyPaintingEvent = true;
			this.xGridCell2.CellName = "hangmog_name";
			this.xGridCell2.CellWidth = 268;
			this.xGridCell2.Col = 2;
			this.xGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
			this.xGridCell2.HeaderText = "オ―ダコード名";
			this.xGridCell2.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
			this.xGridCell2.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
			// 
			// xGridCell3
			// 
			this.xGridCell3.CellName = "bulyong_check";
			this.xGridCell3.Col = -1;
			this.xGridCell3.HeaderText = "bulyong_check";
			this.xGridCell3.IsVisible = false;
			this.xGridCell3.Row = -1;
			// 
			// xGridCell7
			// 
			this.xGridCell7.CellName = "slip_code";
			this.xGridCell7.Col = -1;
			this.xGridCell7.HeaderText = "slip_code";
			this.xGridCell7.IsVisible = false;
			this.xGridCell7.Row = -1;
			// 
			// xGridCell4
			// 
			this.xGridCell4.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xGridCell4.CellName = "xray_cnt";
			this.xGridCell4.CellType = IHIS.Framework.XCellDataType.Number;
			this.xGridCell4.CellWidth = 58;
			this.xGridCell4.Col = 3;
			this.xGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
			this.xGridCell4.HeaderText = "撮影回数";
			this.xGridCell4.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
			this.xGridCell4.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
			// 
			// xGridCell11
			// 
			this.xGridCell11.CellName = "xray_gubun";
			this.xGridCell11.Col = -1;
			this.xGridCell11.HeaderText = "xray_gubun";
			this.xGridCell11.IsVisible = false;
			this.xGridCell11.Row = -1;
			// 
			// xGridCell8
			// 
			this.xGridCell8.CellName = "xray_buwi";
			this.xGridCell8.Col = -1;
			this.xGridCell8.HeaderText = "xray_buwi";
			this.xGridCell8.IsVisible = false;
			this.xGridCell8.Row = -1;
			// 
			// xGridCell9
			// 
			this.xGridCell9.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xGridCell9.ApplyPaintingEvent = true;
			this.xGridCell9.CellName = "portable_yn";
			this.xGridCell9.CellWidth = 62;
			this.xGridCell9.Col = -1;
			this.xGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
			this.xGridCell9.HeaderText = "移動撮影";
			this.xGridCell9.IsVisible = false;
			this.xGridCell9.Row = -1;
			this.xGridCell9.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
			this.xGridCell9.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
			this.xGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// xGridCell10
			// 
			this.xGridCell10.CellName = "portable_base";
			this.xGridCell10.Col = -1;
			this.xGridCell10.HeaderText = "portable_base";
			this.xGridCell10.IsVisible = false;
			this.xGridCell10.Row = -1;
			// 
			// xGridCell5
			// 
			this.xGridCell5.CellName = "emergency";
			this.xGridCell5.Col = -1;
			this.xGridCell5.HeaderText = "emergency";
			this.xGridCell5.IsVisible = false;
			this.xGridCell5.Row = -1;
			// 
			// xGridCell6
			// 
			this.xGridCell6.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xGridCell6.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.xGridCell6.CellName = "select";
			this.xGridCell6.CellWidth = 51;
			this.xGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
			this.xGridCell6.HeaderText = "選択";
			this.xGridCell6.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblSelectAll
			// 
			this.lblSelectAll.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
			this.lblSelectAll.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblSelectAll.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
			this.lblSelectAll.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
			this.lblSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("lblSelectAll.Image")));
			this.lblSelectAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblSelectAll.ImageIndex = 2;
			this.lblSelectAll.ImageList = this.ImageList;
			this.lblSelectAll.Location = new System.Drawing.Point(282, 30);
			this.lblSelectAll.Name = "lblSelectAll";
			this.lblSelectAll.Size = new System.Drawing.Size(474, 24);
			this.lblSelectAll.TabIndex = 16;
			this.lblSelectAll.Text = " 全体選択";
			this.lblSelectAll.Click += new System.EventHandler(this.lblSelectAll_Click);
			// 
			// layXRT0101
			// 
			this.layXRT0101.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
																						  this.multiLayoutItem1,
																						  this.multiLayoutItem2,
																						  this.multiLayoutItem3,
																						  this.multiLayoutItem4,
																						  this.multiLayoutItem5,
																						  this.multiLayoutItem6});
			this.layXRT0101.QuerySQL = @"SELECT DISTINCT
       A.XRAY_GUBUN,
       B.CODE_NAME  XRAY_GUBUN_NAME,
       A.XRAY_BUWI,
       C.BUWI_NAME           
  FROM XRT0001 A,
       XRT0102 B,
       XRT0122 C
 WHERE B.CODE      = A.XRAY_GUBUN
   AND B.CODE_TYPE = 'X1'
   AND C.BUWI_CODE = A.XRAY_BUWI
 ORDER BY XRAY_GUBUN DESC";
			this.layXRT0101.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layXRT0101_QueryEnd);
			// 
			// multiLayoutItem1
			// 
			this.multiLayoutItem1.DataName = "xray_gubun";
			this.multiLayoutItem1.IsNotNull = true;
			// 
			// multiLayoutItem2
			// 
			this.multiLayoutItem2.DataName = "xray_gubun_name";
			this.multiLayoutItem2.IsNotNull = true;
			// 
			// multiLayoutItem3
			// 
			this.multiLayoutItem3.DataName = "xray_buwi";
			this.multiLayoutItem3.IsNotNull = true;
			// 
			// multiLayoutItem4
			// 
			this.multiLayoutItem4.DataName = "xray_buwi_name";
			this.multiLayoutItem4.IsNotNull = true;
			// 
			// multiLayoutItem5
			// 
			this.multiLayoutItem5.DataName = "node1";
			// 
			// multiLayoutItem6
			// 
			this.multiLayoutItem6.DataName = "node2";
			// 
			// OCS0103Q11
			// 
			this.Controls.Add(this.lblSelectAll);
			this.Controls.Add(this.grdOCS0103);
			this.Controls.Add(this.tvwXRT0101);
			this.Controls.Add(this.xPanel2);
			this.Controls.Add(this.xPanel1);
			this.Name = "OCS0103Q11";
			this.Size = new System.Drawing.Size(756, 582);
			this.xPanel1.ResumeLayout(false);
			this.xPanel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdOCS0103)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layXRT0101)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]
		#region 현재 화면이 열려있는 경우에 호출을 받았을 경우 처리
		public override object Command(string command, CommonItemCollection commandParam)
		{	
			return base.Command (command, commandParam);
		}
		#endregion

		protected override void OnLoad(EventArgs e)
		{	
			base.OnLoad (e);
			
			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

		private void PostLoad()
		{
			//Create Return DataLayout 
			CreateLayout();
			layXRT0101.QueryLayout(true);
		}
		
		/// <summary>
		/// DataLayout LayoutItems생성
		/// </summary>
		private void CreateLayout()
		{			
			//OCS0103
			foreach(XGridCell cell in this.grdOCS0103.CellInfos)
			{
				laySelectOCS0103.LayoutItems.Add(cell.CellName, (DataType)cell.CellType);
			}
			laySelectOCS0103.InitializeLayoutTable();
		}
		#endregion

		#region [TreeView 약분류]
		private void ShowXRT0101()
		{
			tvwXRT0101.Nodes.Clear();
			if(layXRT0101.RowCount < 1) return;
            
			string xray_gubun = "";
			int node1 = -1, node2 = -1;
			TreeNode node;

			foreach(DataRow row in layXRT0101.LayoutTable.Rows)
			{
				if(xray_gubun != row["xray_gubun"].ToString())
				{
					node = new TreeNode( row["xray_gubun_name"].ToString() );
					node.Tag = row["xray_gubun"].ToString();
					tvwXRT0101.Nodes.Add(node);
					xray_gubun = row["xray_gubun"].ToString();	
				
					row["node1"] = -1;
					row["node1"] = -1;
					node1 = node1 + 1;
					node2 = -1;
				}

				node = new TreeNode( row["xray_buwi_name"].ToString() );
				node.Tag = row["xray_buwi"].ToString();
				node.ImageIndex = 2;
				node.SelectedImageIndex = 2;					
				tvwXRT0101.Nodes[tvwXRT0101.Nodes.Count -1].Nodes.Add(node);
				node2 = node2 + 1;
				row["node1"] = node1;
				row["node2"] = node2;
			}

			if(layXRT0101.RowCount > 0)
				tvwXRT0101.SelectedNode = tvwXRT0101.Nodes[0].Nodes[0];
		}

		private void tvwXRT0101_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if(tvwXRT0101.SelectedNode.Parent == null) return;

			try
			{
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;					
				mQueryMode = "0";
				string xray_gubun = tvwXRT0101.SelectedNode.Parent.Tag.ToString();
				string xray_buwi  = tvwXRT0101.SelectedNode.Tag.ToString();

				if(xray_gubun == "X" || xray_gubun == "Z")
					chkPortable_yn.Visible = true;
				else
					chkPortable_yn.Visible = false;
                
				//선택된 row Backup
				BackSelectRow();
				grdOCS0103.SetBindVarValue("f_query_mode"      , mQueryMode);
				grdOCS0103.SetBindVarValue("f_xray_gubun"      , xray_gubun);
				grdOCS0103.SetBindVarValue("f_xray_buwi"       , xray_buwi );
				grdOCS0103.SetBindVarValue("f_hangmog_name_inx", "");
				if(grdOCS0103.QueryLayout(true))
				{
					if(chkEmergency.Checked)
					{
						for(int i = 0; i < grdOCS0103.RowCount; i++)
						{
							grdOCS0103.SetItemValue(i, "emergency", "Y");
						}
					}

					if(chkPortable_yn.Checked && chkPortable_yn.Visible)
					{
						for(int i = 0; i < grdOCS0103.RowCount; i++)
						{
							grdOCS0103.SetItemValue(i, "portable_yn", "Y");
						}
					}

					//선택상태변경
					lblSelectAll.ImageIndex = 2;
					lblSelectAll.Text = " 全体選択";
					SetSelect();
				}
			}
			finally
			{					
				Cursor.Current = System.Windows.Forms.Cursors.Default;
			}
		}
		#endregion

		#region [Return Layout 생성]
		private void CreateReturnLayout()
		{
			this.AcceptData();			
			BackSelectRow();
			
			if(laySelectOCS0103.LayoutTable.Rows.Count < 1 )
			{				
				mbxMsg = NetInfo.Language == LangMode.Jr ? "オーダが選択されませんでした。ご確認下さい。" : "처방이 선택되지 않았습니다. 확인하세요.";
				mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인";
				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
				return;				
			}				
			
			IHIS.Framework.XScreen scrOpener = (XScreen)Opener;	
			CommonItemCollection commandParams  = new CommonItemCollection();
			commandParams.Add( "OCS0103", laySelectOCS0103);
			scrOpener.Command(ScreenID, commandParams);

			ClearSelect();
			this.Close();
		}
		#endregion

		#region [Function]
		/// <summary>
		/// 해당 Grid가 다시 load되기 전에 선택된 row를 backup
		/// </summary>
		private void BackSelectRow()
		{
			this.AcceptData();

			foreach(DataRow row in grdOCS0103.LayoutTable.Rows)
			{
				if(row["select"].ToString() == " ")
					laySelectOCS0103.LayoutTable.ImportRow(row);				
			}

			SetSelectTab();
		}
	    
		private void SetSelect()
		{
			DataRow[] backSelectRow;
			foreach(DataRow row in grdOCS0103.LayoutTable.Rows)
			{
				backSelectRow = laySelectOCS0103.LayoutTable.Select("hangmog_code = '" + row["hangmog_code"].ToString() + "' ", "");

				if(backSelectRow.Length > 0)
				{
					row["select"] = " ";
					//backSelectRow는 삭제한다.
					laySelectOCS0103.LayoutTable.Rows.Remove(backSelectRow[0]);
				}
			}

			SelectionBackColorChange(grdOCS0103);
		}

		private void ClearSelect()
		{
			//선택된 Tab
			ClearSelectTab();

			//선택된 row Clear
			for(int i = 0; i < this.grdOCS0103.RowCount; i++)
			{
				grdOCS0103.SetItemValue(i, "select", "");
			}

			SelectionBackColorChange(grdOCS0103);

			laySelectOCS0103.Reset();
		}
        
		/// <summary>
		/// tab의 이미지를 Clear한다.
		/// 조건검색에 따른 항목조회가 있기 때문에 선택된 항목 전체를 check한다.
		/// </summary>
		private void ClearSelectTab()
		{
			int node1 = -1, node2 = -1;
			foreach(DataRow row in layXRT0101.LayoutTable.Rows)
			{
				node1 = int.Parse(row["node1"].ToString());
				node2 = int.Parse(row["node2"].ToString());
				tvwXRT0101.Nodes[node1].Nodes[node2].ImageIndex = 2;
				tvwXRT0101.Nodes[node1].Nodes[node2].SelectedImageIndex = 2;
			}
		}

		/// <summary>
		/// 선택된 항목이 있는 경우 tab의 이미지를 변경한다.
		/// 조건검색에 따른 항목조회가 있기 때문에 선택된 항목 전체를 check한다.
		/// </summary>
		private void SetSelectTab()
		{
			ClearSelectTab();
            
			DataRow[] xray_gubun;
			int node1 = -1, node2 = -1;
            
			//선택되어진 항목
			foreach(DataRow row in laySelectOCS0103.LayoutTable.Rows)
			{
				//해당 항목의 xray_gubun정보를 가져온다.
				xray_gubun = layXRT0101.LayoutTable.Select(" xray_gubun = '" + row["xray_gubun"].ToString() + "' and xray_buwi = '" + row["xray_buwi"].ToString() + "' ", "");

				if(xray_gubun.Length < 1) continue;
				node1 = int.Parse(xray_gubun[0]["node1"].ToString());
				node2 = int.Parse(xray_gubun[0]["node2"].ToString());
				tvwXRT0101.Nodes[node1].Nodes[node2].ImageIndex = 3;
				tvwXRT0101.Nodes[node1].Nodes[node2].SelectedImageIndex = 3;
			}

			//선택된 항목
			//space는 filter를 못함 --;
			for(int rowIndex = 0; rowIndex < grdOCS0103.RowCount; rowIndex++)
			{
				if(grdOCS0103.GetItemString(rowIndex, "select") == "") continue;
				//해당 항목의 xray_gubun정보를 가져온다.
				xray_gubun = layXRT0101.LayoutTable.Select(" xray_gubun = '" + grdOCS0103.GetItemString(rowIndex, "xray_gubun")  + "' and xray_buwi = '" + grdOCS0103.GetItemString(rowIndex, "xray_buwi") + "' ", "");
			
				if(xray_gubun.Length < 1) continue;
				node1 = int.Parse(xray_gubun[0]["node1"].ToString());
				node2 = int.Parse(xray_gubun[0]["node2"].ToString());
				tvwXRT0101.Nodes[node1].Nodes[node2].ImageIndex = 3;
				tvwXRT0101.Nodes[node1].Nodes[node2].SelectedImageIndex = 3;
			}
		}
		#endregion

		#region 그리드에서 선택한 Row에 대한 BackColor를 변경한다
		private void SelectionBackColorChange(object grd, int currentRowIndex, string data)
		{
			XGrid grdObject = (XGrid)grd;
			//선택된 Row에대해서 색을 변경한다
			//data   Y :색을 변경, N :색을 변경 해제
			//image 설정
			if(data == "Y")
				grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[3];
			else
				grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[2];

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

		private void SelectionBackColorChange(object grd)
		{
			XGrid grdObject = (XGrid)grd;

			//기존의 색으로 변경을 시킨다
			for(int rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
			{	
				//불용은 넘어간다.
				if(grdObject.GetItemString(rowIndex, "bulyong_check") == "Y" ) continue;

				if(grdObject.GetItemString(rowIndex, "select").ToString() == " ")
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

		#region [Control Event]
		private void txtHangmog_index_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			try
			{
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;	
				
				//현재 선택된 row backup
				BackSelectRow();
				grdOCS0103.SetBindVarValue("f_query_mode"      , "1");
				grdOCS0103.SetBindVarValue("f_xray_gubun"      , "" );
				grdOCS0103.SetBindVarValue("f_xray_buwi"       , "" );
				grdOCS0103.SetBindVarValue("f_hangmog_name_inx", JapanTextHelper.GetFullKatakana(e.DataValue.Trim(), true));
				if(grdOCS0103.QueryLayout(true))
				{
					if(chkEmergency.Checked)
					{
						for(int i = 0; i < grdOCS0103.RowCount; i++)
						{
							grdOCS0103.SetItemValue(i, "emergency", "Y");
						}
					}

					if(chkPortable_yn.Checked && chkPortable_yn.Visible)
					{
						for(int i = 0; i < grdOCS0103.RowCount; i++)
						{
							grdOCS0103.SetItemValue(i, "portable_yn", "Y");
						}
					}

					//선택상태변경
					lblSelectAll.ImageIndex = 2;
					lblSelectAll.Text = " 全体選択";
					SetSelect();
				}
			}
			finally
			{					
				Cursor.Current = System.Windows.Forms.Cursors.Default;
			}
		}

		private void chkPortable_yn_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkPortable_yn.Checked)
			{
				chkPortable_yn.BackColor = System.Drawing.SystemColors.ActiveCaption;
				chkPortable_yn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
				chkPortable_yn.ImageIndex = 3;

				for(int i = 0; i < grdOCS0103.RowCount; i++)
				{
					grdOCS0103.SetItemValue(i, "portable_yn", "Y");
				}
			}
			else
			{
				chkPortable_yn.BackColor = System.Drawing.SystemColors.InactiveCaption;
				chkPortable_yn.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
				chkPortable_yn.ImageIndex = 2;

				for(int i = 0; i < grdOCS0103.RowCount; i++)
				{
					grdOCS0103.SetItemValue(i, "portable_yn", grdOCS0103.GetItemString(i, "portable_base"));
				}
			}
		}

		private void chkEmergency_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkEmergency.Checked)
			{
				chkEmergency.BackColor = System.Drawing.SystemColors.ActiveCaption;
				chkEmergency.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
				chkEmergency.ImageIndex = 3;

				for(int i = 0; i < grdOCS0103.RowCount; i++)
				{
					grdOCS0103.SetItemValue(i, "emergency", "Y");
				}
			}
			else
			{
				chkEmergency.BackColor = System.Drawing.SystemColors.InactiveCaption;
				chkEmergency.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
				chkEmergency.ImageIndex = 2;

				for(int i = 0; i < grdOCS0103.RowCount; i++)
				{
					grdOCS0103.SetItemValue(i, "emergency", "N");
				}
			}
		}

		private void lblSelectAll_Click(object sender, System.EventArgs e)
		{
			if(lblSelectAll.ImageIndex == 2)
			{
				grdSelectAll(this.grdOCS0103, true);
				lblSelectAll.ImageIndex = 3;
				lblSelectAll.Text = " 全体選択取消";
			}
			else
			{
				grdSelectAll(this.grdOCS0103, false);
				lblSelectAll.ImageIndex = 2;
				lblSelectAll.Text = " 全体選択";
			}
		}

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
            
			//선택된 Tab표시
			SetSelectTab();
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

		#region [Grid Event]
		private void grdOCS0103_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			return;
		}

		private void grdOCS0103_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;
		}

		private void grdOCS0103_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			// Drag시에 Cursor 바꿈
			if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
			{
				Cursor.Current = DragHelper.DragCursor;
			}
		}

		private void grdOCS0103_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if(e.DataRow["bulyong_check"].ToString() == "Y")
			{
				e.ForeColor = Color.Red;
			}
		}

		private void grdOCS0103_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int curRowIndex = -1;

			if(e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				curRowIndex = grdOCS0103.GetHitRowNumber(e.Y);
				if(curRowIndex < 0) return;

				CreateReturnLayout();
			}
			else if (e.Button == MouseButtons.Left && e.Clicks == 1 && grdOCS0103.CurrentColNumber == 0)
			{
				curRowIndex = grdOCS0103.GetHitRowNumber(e.Y);				
				if(curRowIndex < 0) return;

				if(grdOCS0103.CurrentColNumber == 0)
				{	
					//불용처리된 것은 선택을 막는다.
					if(grdOCS0103.GetItemString(curRowIndex, "bulyong_check") == "Y") 
					{
						//불용인 경우에는 해당 항목의 심사기준을 보여준다.
						mbxMsg = this.mOrderBiz.LoadSimsa_comment(grdOCS0103.GetItemString(curRowIndex, "hangmog_code")); 
						mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인";
						if( !TypeCheck.IsNull(mbxMsg) ) XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);

						return;
					}

					if(grdOCS0103.GetItemString(curRowIndex, "select") == "")
					{
						grdOCS0103.SetItemValue(curRowIndex, "select", " ");
						SelectionBackColorChange(sender, curRowIndex, "Y");
						SetSelectTab();
					}
					else
					{
						grdOCS0103.SetItemValue(curRowIndex, "select", "");
						SelectionBackColorChange(sender, curRowIndex, "N");
						SetSelectTab();
					}
				}
			}
			else if (e.Button == MouseButtons.Left && e.Clicks == 1)
			{
				if(grdOCS0103.GetHitRowNumber(e.Y) < 0 ) return;		
				curRowIndex = grdOCS0103.GetHitRowNumber(e.Y);

				//Drag시 show info정보
				string dragInfo = "[" + grdOCS0103.GetItemString(curRowIndex, "hangmog_code") + "]" + grdOCS0103.GetItemString(curRowIndex, "hangmog_name");
				DragHelper.CreateDragCursor(grdOCS0103, dragInfo, this.Font);

				BackSelectRow();
				object[] dragData = new object[2];
				dragData[0] = this.ScreenID;
				dragData[1] = laySelectOCS0103;
				grdOCS0103.DoDragDrop( dragData, DragDropEffects.Move);
			}
		}
		#endregion

		#region [Query Event]
		private void layXRT0101_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{
			ShowXRT0101();
		}

		private void grdOCS0103_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{
			if(chkEmergency.Checked)
			{
				for(int i = 0; i < grdOCS0103.RowCount; i++)
				{
					grdOCS0103.SetItemValue(i, "emergency", "Y");
				}
			}

			if(chkPortable_yn.Checked && chkPortable_yn.Visible)
			{
				for(int i = 0; i < grdOCS0103.RowCount; i++)
				{
					grdOCS0103.SetItemValue(i, "portable_yn", "Y");
				}
			}

			//선택상태변경
			lblSelectAll.ImageIndex = 2;
			lblSelectAll.Text = " 全体選択";
			SetSelect();
		}
		#endregion
	}
}

