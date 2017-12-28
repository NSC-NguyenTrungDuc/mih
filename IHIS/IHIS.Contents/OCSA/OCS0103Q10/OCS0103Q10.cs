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

namespace IHIS.OCSA
{
	/// <summary>
	/// OCS0103Q10에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS0103Q10 : IHIS.Framework.XScreen
	{
		#region [OCS Library]
		private IHIS.OCS.OrderBiz  mOrderBiz  = null;         // OCS 그룹 Business 라이브러리
		private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리		
		private IHIS.OCS.HangmogInfo mHangmogInfo = null;     // OCS 항목정보 그룹 라이브러리
		#endregion

		private string mbxMsg = "", mbxCap = "";
		private IHIS.Framework.MultiLayout laySelectOCS0103 = new MultiLayout();
		
		private string mQueryMode = "0";
		private System.Windows.Forms.TreeView tvwDRG0140;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XTextBox txtHangmog_index;
		private IHIS.Framework.XPictureBox xPictureBox1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XGrid grdOCS0103;
		private IHIS.Framework.XGridCell xGridCell1;
		private IHIS.Framework.XGridCell xGridCell2;
		private IHIS.Framework.XGridCell xGridCell3;
		private IHIS.Framework.XGridCell xGridCell4;
        private IHIS.Framework.XGridCell xGridCell5;
		private IHIS.Framework.XButton btnProcess;
		private IHIS.Framework.XButton btnProClose;
		private IHIS.Framework.XGridCell xGridCell7;
		private IHIS.Framework.XGridCell xGridCell8;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XLabel lblSelectAll;
		private IHIS.Framework.XGridCell xGridCell9;
		private IHIS.Framework.MultiLayout layDRG0140;
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

		public OCS0103Q10()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0103Q10));
            this.tvwDRG0140 = new System.Windows.Forms.TreeView();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.txtHangmog_index = new IHIS.Framework.XTextBox();
            this.xPictureBox1 = new IHIS.Framework.XPictureBox();
            this.grdOCS0103 = new IHIS.Framework.XGrid();
            this.xGridCell1 = new IHIS.Framework.XGridCell();
            this.xGridCell2 = new IHIS.Framework.XGridCell();
            this.xGridCell3 = new IHIS.Framework.XGridCell();
            this.xGridCell4 = new IHIS.Framework.XGridCell();
            this.xGridCell5 = new IHIS.Framework.XGridCell();
            this.xGridCell8 = new IHIS.Framework.XGridCell();
            this.xGridCell9 = new IHIS.Framework.XGridCell();
            this.xGridCell7 = new IHIS.Framework.XGridCell();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnProClose = new IHIS.Framework.XButton();
            this.btnProcess = new IHIS.Framework.XButton();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.lblSelectAll = new IHIS.Framework.XLabel();
            this.layDRG0140 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0103)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layDRG0140)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "");
            // 
            // tvwDRG0140
            // 
            this.tvwDRG0140.BackColor = System.Drawing.SystemColors.Window;
            this.tvwDRG0140.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvwDRG0140.HideSelection = false;
            this.tvwDRG0140.ImageIndex = 0;
            this.tvwDRG0140.ImageList = this.ImageList;
            this.tvwDRG0140.Location = new System.Drawing.Point(0, 0);
            this.tvwDRG0140.Name = "tvwDRG0140";
            this.tvwDRG0140.SelectedImageIndex = 1;
            this.tvwDRG0140.Size = new System.Drawing.Size(230, 510);
            this.tvwDRG0140.TabIndex = 6;
            this.tvwDRG0140.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwDRG0140_AfterSelect);
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.txtHangmog_index);
            this.xPanel1.Controls.Add(this.xPictureBox1);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(766, 32);
            this.xPanel1.TabIndex = 7;
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel1.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.xLabel1.Image = ((System.Drawing.Image)(resources.GetObject("xLabel1.Image")));
            this.xLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel1.Location = new System.Drawing.Point(4, 6);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(94, 20);
            this.xLabel1.TabIndex = 18;
            this.xLabel1.Text = "検索語";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHangmog_index
            // 
            this.txtHangmog_index.Location = new System.Drawing.Point(100, 6);
            this.txtHangmog_index.Name = "txtHangmog_index";
            this.txtHangmog_index.Size = new System.Drawing.Size(326, 20);
            this.txtHangmog_index.TabIndex = 17;
            this.txtHangmog_index.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtHangmog_index_DataValidating);
            // 
            // xPictureBox1
            // 
            this.xPictureBox1.BackColor = IHIS.Framework.XColor.XMonthCalendarBackColor;
            this.xPictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPictureBox1.BackgroundImage")));
            this.xPictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.xPictureBox1.Name = "xPictureBox1";
            this.xPictureBox1.Protect = false;
            this.xPictureBox1.Size = new System.Drawing.Size(764, 580);
            this.xPictureBox1.TabIndex = 19;
            this.xPictureBox1.TabStop = false;
            // 
            // grdOCS0103
            // 
            this.grdOCS0103.ApplyPaintEventToAllColumn = true;
            this.grdOCS0103.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell1,
            this.xGridCell2,
            this.xGridCell3,
            this.xGridCell4,
            this.xGridCell5,
            this.xGridCell8,
            this.xGridCell9,
            this.xGridCell7});
            this.grdOCS0103.ColPerLine = 3;
            this.grdOCS0103.Cols = 3;
            this.grdOCS0103.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOCS0103.EnableMultiSelection = true;
            this.grdOCS0103.FixedRows = 1;
            this.grdOCS0103.HeaderHeights.Add(21);
            this.grdOCS0103.Location = new System.Drawing.Point(230, 24);
            this.grdOCS0103.Name = "grdOCS0103";
            this.grdOCS0103.QuerySQL = resources.GetString("grdOCS0103.QuerySQL");
            this.grdOCS0103.Rows = 2;
            this.grdOCS0103.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS0103.Size = new System.Drawing.Size(534, 486);
            this.grdOCS0103.TabIndex = 9;
            this.grdOCS0103.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdOCS0103_DragEnter);
            this.grdOCS0103.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS0103_GridCellPainting);
            this.grdOCS0103.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdOCS0103_DragDrop);
            this.grdOCS0103.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS0103_QueryEnd);
            this.grdOCS0103.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0103_MouseDown);
            this.grdOCS0103.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdOCS0103_GiveFeedback);
            // 
            // xGridCell1
            // 
            this.xGridCell1.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell1.ApplyPaintingEvent = true;
            this.xGridCell1.CellName = "hangmog_code";
            this.xGridCell1.CellWidth = 92;
            this.xGridCell1.Col = 1;
            this.xGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell1.HeaderText = "オ―ダコード";
            this.xGridCell1.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell1.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xGridCell2
            // 
            this.xGridCell2.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell2.ApplyPaintingEvent = true;
            this.xGridCell2.CellName = "hangmog_name";
            this.xGridCell2.CellWidth = 364;
            this.xGridCell2.Col = 2;
            this.xGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell2.HeaderText = "オ―ダコード名";
            this.xGridCell2.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell2.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xGridCell3
            // 
            this.xGridCell3.CellName = "bulyong_check";
            this.xGridCell3.Col = -1;
            this.xGridCell3.HeaderText = "bulyong_check";
            this.xGridCell3.IsVisible = false;
            this.xGridCell3.Row = -1;
            // 
            // xGridCell4
            // 
            this.xGridCell4.CellName = "wonyoi_order_cr_yn";
            this.xGridCell4.Col = -1;
            this.xGridCell4.HeaderText = "wonyoi_order_cr_yn";
            this.xGridCell4.IsVisible = false;
            this.xGridCell4.Row = -1;
            // 
            // xGridCell5
            // 
            this.xGridCell5.CellName = "default_wonyoi_order_yn";
            this.xGridCell5.Col = -1;
            this.xGridCell5.HeaderText = "default_wonyoi_order_yn";
            this.xGridCell5.IsVisible = false;
            this.xGridCell5.Row = -1;
            // 
            // xGridCell8
            // 
            this.xGridCell8.CellName = "code1";
            this.xGridCell8.Col = -1;
            this.xGridCell8.HeaderText = "code1";
            this.xGridCell8.IsVisible = false;
            this.xGridCell8.Row = -1;
            // 
            // xGridCell9
            // 
            this.xGridCell9.CellName = "order_gubun_bas";
            this.xGridCell9.Col = -1;
            this.xGridCell9.IsVisible = false;
            this.xGridCell9.Row = -1;
            // 
            // xGridCell7
            // 
            this.xGridCell7.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell7.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xGridCell7.CellName = "select";
            this.xGridCell7.CellWidth = 47;
            this.xGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell7.HeaderText = "選択";
            this.xGridCell7.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xGridCell7.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell7.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.btnProClose);
            this.xPanel2.Controls.Add(this.btnProcess);
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.Location = new System.Drawing.Point(0, 544);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(766, 38);
            this.xPanel2.TabIndex = 8;
            // 
            // btnProClose
            // 
            this.btnProClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProClose.Image = ((System.Drawing.Image)(resources.GetObject("btnProClose.Image")));
            this.btnProClose.Location = new System.Drawing.Point(380, 7);
            this.btnProClose.Name = "btnProClose";
            this.btnProClose.Size = new System.Drawing.Size(114, 28);
            this.btnProClose.TabIndex = 6;
            this.btnProClose.Text = "選択後閉じる";
            this.btnProClose.Visible = false;
            this.btnProClose.Click += new System.EventHandler(this.btnProClose_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Image = ((System.Drawing.Image)(resources.GetObject("btnProcess.Image")));
            this.btnProcess.Location = new System.Drawing.Point(496, 7);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(98, 28);
            this.btnProcess.TabIndex = 5;
            this.btnProcess.Text = "選択";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Location = new System.Drawing.Point(596, 4);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.xButtonList1.Size = new System.Drawing.Size(163, 34);
            this.xButtonList1.TabIndex = 0;
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.grdOCS0103);
            this.xPanel3.Controls.Add(this.lblSelectAll);
            this.xPanel3.Controls.Add(this.tvwDRG0140);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Location = new System.Drawing.Point(0, 32);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(766, 512);
            this.xPanel3.TabIndex = 9;
            // 
            // lblSelectAll
            // 
            this.lblSelectAll.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblSelectAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelectAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSelectAll.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.lblSelectAll.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.lblSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("lblSelectAll.Image")));
            this.lblSelectAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSelectAll.ImageIndex = 2;
            this.lblSelectAll.ImageList = this.ImageList;
            this.lblSelectAll.Location = new System.Drawing.Point(230, 0);
            this.lblSelectAll.Name = "lblSelectAll";
            this.lblSelectAll.Size = new System.Drawing.Size(534, 24);
            this.lblSelectAll.TabIndex = 15;
            this.lblSelectAll.Text = " 全体選択";
            this.lblSelectAll.Click += new System.EventHandler(this.lblSelectAll_Click);
            // 
            // layDRG0140
            // 
            this.layDRG0140.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6});
            this.layDRG0140.QuerySQL = resources.GetString("layDRG0140.QuerySQL");
            this.layDRG0140.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layDRG0140_QueryEnd);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "code";
            this.multiLayoutItem1.IsNotNull = true;
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "code_name";
            this.multiLayoutItem2.IsNotNull = true;
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "code1";
            this.multiLayoutItem3.IsNotNull = true;
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "code_name1";
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
            // OCS0103Q10
            // 
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS0103Q10";
            this.Size = new System.Drawing.Size(766, 582);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0103)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layDRG0140)).EndInit();
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

			layDRG0140.QueryLayout(true);
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

		private void ShowDRG0140()
		{
			tvwDRG0140.Nodes.Clear();
			if(layDRG0140.RowCount < 1) return;
            
			string code = "";
			int node1 = -1, node2 = -1;
			TreeNode node;

			foreach(DataRow row in layDRG0140.LayoutTable.Rows)
			{
				if(code != row["code"].ToString())
				{
					node = new TreeNode( row["code_name"].ToString() );
					node.Tag = row["code"].ToString();
					tvwDRG0140.Nodes.Add(node);
					code = row["code"].ToString();	
				
					row["node1"] = -1;
					row["node1"] = -1;
					node1 = node1 + 1;
					node2 = -1;
				}

				node = new TreeNode( row["code_name1"].ToString() );
				node.Tag = row["code1"].ToString();
				node.ImageIndex = 2;
				node.SelectedImageIndex = 2;
				tvwDRG0140.Nodes[tvwDRG0140.Nodes.Count -1].Nodes.Add(node);   
             
				node2 = node2 + 1;
				row["node1"] = node1;
				row["node2"] = node2;							
			}

			if(layDRG0140.RowCount > 0) tvwDRG0140.SelectedNode = tvwDRG0140.Nodes[0].Nodes[0];


		}

		private void tvwDRG0140_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{		
			//if(tvwDRG0140.SelectedNode.Parent == null) return;

			try
			{
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;	
				
				mQueryMode = "0";			
            
				BackSelectRow();
				string code1 = tvwDRG0140.SelectedNode.Tag.ToString();
				grdOCS0103.SetBindVarValue("f_query_mode"      , mQueryMode);
				grdOCS0103.SetBindVarValue("f_code1"           , code1);
				grdOCS0103.SetBindVarValue("f_hangmog_name_inx", "");
                grdOCS0103.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
				if(grdOCS0103.QueryLayout(false))
				{
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
       
		#region [Control Event]
		private void txtHangmog_index_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{				
			try
			{
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;	
				
				//현재 선택된 row backup
				BackSelectRow();
				grdOCS0103.SetBindVarValue("f_query_mode"      , "1");
				grdOCS0103.SetBindVarValue("f_code1"           , "");
				grdOCS0103.SetBindVarValue("f_hangmog_name_inx",  JapanTextHelper.GetFullKatakana(e.DataValue.Trim(), true));
                grdOCS0103.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
				if(grdOCS0103.QueryLayout(false))
				{
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

		private void btnProcess_Click(object sender, System.EventArgs e)
		{
			CreateReturnLayout();
		}

		private void btnProClose_Click(object sender, System.EventArgs e)
		{
			CreateReturnLayout();
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
        
		/// <summary>
		/// 해당 Grid 전체선택 해제
		/// </summary>
		/// <param name="grd"></param>
		/// <param name="select"></param>
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
			
			//약속코드선택정보가 있는 경우 Return Value
			IHIS.Framework.XScreen scrOpener = (XScreen)Opener;	

			CommonItemCollection commandParams  = new CommonItemCollection();
			commandParams.Add( "OCS0103", laySelectOCS0103);
			scrOpener.Command(ScreenID, commandParams);

			ClearSelect();

			this.Close();			
		}		
		#endregion

		#region [grdOCS0103 Event]
		private void grdOCS0103_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			return;
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
//				if(grdOCS0103.GetHitRowNumber(e.Y) < 0 ) return;		
//				curRowIndex = grdOCS0103.GetHitRowNumber(e.Y);
//
//				//Drag시 show info정보
//				string dragInfo = "[" + grdOCS0103.GetItemString(curRowIndex, "hangmog_code") + "]" + grdOCS0103.GetItemString(curRowIndex, "hangmog_name");
//				DragHelper.CreateDragCursor(grdOCS0103, dragInfo, this.Font);
//				
//				BackSelectRow();
//				object[] dragData = new object[2];
//				dragData[0] = this.ScreenID;
//				dragData[1] = laySelectOCS0103;
//				grdOCS0103.DoDragDrop( dragData, DragDropEffects.Move);
			}
		
		}

		private void grdOCS0103_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;  // Move 표시			
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
			foreach(DataRow row in layDRG0140.LayoutTable.Rows)
			{
				node1 = int.Parse(row["node1"].ToString());
				node2 = int.Parse(row["node2"].ToString());
				tvwDRG0140.Nodes[node1].Nodes[node2].ImageIndex = 2;
				tvwDRG0140.Nodes[node1].Nodes[node2].SelectedImageIndex = 2;
			}
		}

		/// <summary>
		/// 선택된 항목이 있는 경우 tab의 이미지를 변경한다.
		/// 조건검색에 따른 항목조회가 있기 때문에 선택된 항목 전체를 check한다.
		/// </summary>
		private void SetSelectTab()
		{
			ClearSelectTab();
            
			DataRow[] code1;
			int node1 = -1, node2 = -1;
            
			//선택되어진 항목
			foreach(DataRow row in laySelectOCS0103.LayoutTable.Rows)
			{
				//해당 항목의 code1정보를 가져온다.
				code1 = layDRG0140.LayoutTable.Select(" code1 = '" + row["code1"].ToString() + "' ", "");

				if(code1.Length < 1) continue;
				node1 = int.Parse(code1[0]["node1"].ToString());
				node2 = int.Parse(code1[0]["node2"].ToString());
				tvwDRG0140.Nodes[node1].Nodes[node2].ImageIndex = 3;
				tvwDRG0140.Nodes[node1].Nodes[node2].SelectedImageIndex = 3;
			}

//선택된 항목
//space는 filter를 못함 --;
//			foreach(DataRow row in grdOCS0103.LayoutTable.Select(" select = ' ' ", ""))
//			{
//				//해당 항목의 code1정보를 가져온다.
//				code1 = layDRG0140.LayoutTable.Select(" code1 = '" + row["code1"].ToString() + "' ", "");
//
//				if(code1.Length < 1) continue;
//				node1 = int.Parse(code1[0]["node1"].ToString());
//				node2 = int.Parse(code1[0]["node2"].ToString());
//				tvwDRG0140.Nodes[node1].Nodes[node2].ImageIndex = 3;
//				tvwDRG0140.Nodes[node1].Nodes[node2].SelectedImageIndex = 3;
//			}

			for(int rowIndex = 0; rowIndex < grdOCS0103.RowCount; rowIndex++)
			{
				if(grdOCS0103.GetItemString(rowIndex, "select") == "") continue;
				//해당 항목의 code1정보를 가져온다.
				code1 = layDRG0140.LayoutTable.Select(" code1 = '" + grdOCS0103.GetItemString(rowIndex, "code1") + "' ", "");
			
				if(code1.Length < 1) continue;
				node1 = int.Parse(code1[0]["node1"].ToString());
				node2 = int.Parse(code1[0]["node2"].ToString());
				tvwDRG0140.Nodes[node1].Nodes[node2].ImageIndex = 3;
				tvwDRG0140.Nodes[node1].Nodes[node2].SelectedImageIndex = 3;
			}
		}
		#endregion

		#region [QueryEnd Evnet]
		private void layDRG0140_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{
			this.ShowDRG0140();
		}
		private void grdOCS0103_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{
			//선택상태변경
			lblSelectAll.ImageIndex = 2;
			lblSelectAll.Text = " 全体選択";

			SetSelect();
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
	}
}