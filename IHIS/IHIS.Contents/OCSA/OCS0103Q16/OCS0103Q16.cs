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
	/// OCS0103Q16에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS0103Q16 : IHIS.Framework.XScreen
	{
		private string mbxMsg = "", mbxCap = "";		
		
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPictureBox xPictureBox1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XGrid grdOCS0103;
		private IHIS.Framework.XGridCell xGridCell1;
		private IHIS.Framework.XGridCell xGridCell2;
		private IHIS.Framework.XGridCell xGridCell3;
		private IHIS.Framework.XButton btnProcess;
		private IHIS.Framework.XGridCell xGridCell8;
		private System.Windows.Forms.CheckBox chkEmergency;
		private IHIS.Framework.XGridCell xGridCell5;
		private IHIS.Framework.XGridCell xGridCell6;
		private IHIS.Framework.XButton btnProClose;
		private IHIS.Framework.XGridCell xGridCell11;
		private IHIS.Framework.XLabel lblSelectAll;
		private System.Windows.Forms.TreeView tvwPFE0102;
		private IHIS.Framework.XGridCell xGridCell12;
		private IHIS.Framework.XGridCell xGridCell13;
		private IHIS.Framework.MultiLayout layPFE0102;
		private IHIS.Framework.MultiLayout laySelectOCS0103;
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

		public OCS0103Q16()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0103Q16));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.chkEmergency = new System.Windows.Forms.CheckBox();
            this.xPictureBox1 = new IHIS.Framework.XPictureBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnProClose = new IHIS.Framework.XButton();
            this.btnProcess = new IHIS.Framework.XButton();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.tvwPFE0102 = new System.Windows.Forms.TreeView();
            this.grdOCS0103 = new IHIS.Framework.XGrid();
            this.xGridCell11 = new IHIS.Framework.XGridCell();
            this.xGridCell12 = new IHIS.Framework.XGridCell();
            this.xGridCell8 = new IHIS.Framework.XGridCell();
            this.xGridCell13 = new IHIS.Framework.XGridCell();
            this.xGridCell1 = new IHIS.Framework.XGridCell();
            this.xGridCell2 = new IHIS.Framework.XGridCell();
            this.xGridCell3 = new IHIS.Framework.XGridCell();
            this.xGridCell5 = new IHIS.Framework.XGridCell();
            this.xGridCell6 = new IHIS.Framework.XGridCell();
            this.lblSelectAll = new IHIS.Framework.XLabel();
            this.layPFE0102 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.laySelectOCS0103 = new IHIS.Framework.MultiLayout();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox1)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0103)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPFE0102)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySelectOCS0103)).BeginInit();
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
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.chkEmergency);
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
            this.chkEmergency.Location = new System.Drawing.Point(632, 2);
            this.chkEmergency.Name = "chkEmergency";
            this.chkEmergency.Size = new System.Drawing.Size(88, 24);
            this.chkEmergency.TabIndex = 20;
            this.chkEmergency.Text = "       至急";
            this.chkEmergency.UseVisualStyleBackColor = false;
            this.chkEmergency.CheckedChanged += new System.EventHandler(this.chkEmergency_CheckedChanged);
            // 
            // xPictureBox1
            // 
            this.xPictureBox1.BackColor = IHIS.Framework.XColor.XMonthCalendarBackColor;
            this.xPictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPictureBox1.BackgroundImage")));
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
            this.btnProClose.Location = new System.Drawing.Point(359, 7);
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
            this.btnProcess.Location = new System.Drawing.Point(472, 7);
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
            this.xButtonList1.Location = new System.Drawing.Point(568, 4);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.xButtonList1.Size = new System.Drawing.Size(163, 34);
            this.xButtonList1.TabIndex = 0;
            // 
            // tvwPFE0102
            // 
            this.tvwPFE0102.BackColor = System.Drawing.SystemColors.Window;
            this.tvwPFE0102.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvwPFE0102.HideSelection = false;
            this.tvwPFE0102.ImageIndex = 0;
            this.tvwPFE0102.ImageList = this.ImageList;
            this.tvwPFE0102.Location = new System.Drawing.Point(0, 28);
            this.tvwPFE0102.Name = "tvwPFE0102";
            this.tvwPFE0102.SelectedImageIndex = 0;
            this.tvwPFE0102.Size = new System.Drawing.Size(280, 514);
            this.tvwPFE0102.TabIndex = 10;
            this.tvwPFE0102.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwPFE0102_AfterSelect);
            // 
            // grdOCS0103
            // 
            this.grdOCS0103.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdOCS0103.ApplyPaintEventToAllColumn = true;
            this.grdOCS0103.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell11,
            this.xGridCell12,
            this.xGridCell8,
            this.xGridCell13,
            this.xGridCell1,
            this.xGridCell2,
            this.xGridCell3,
            this.xGridCell5,
            this.xGridCell6});
            this.grdOCS0103.ColPerLine = 3;
            this.grdOCS0103.Cols = 3;
            this.grdOCS0103.EnableMultiSelection = true;
            this.grdOCS0103.FixedRows = 1;
            this.grdOCS0103.HeaderHeights.Add(21);
            this.grdOCS0103.Location = new System.Drawing.Point(280, 56);
            this.grdOCS0103.Name = "grdOCS0103";
            this.grdOCS0103.QuerySQL = resources.GetString("grdOCS0103.QuerySQL");
            this.grdOCS0103.Rows = 2;
            this.grdOCS0103.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS0103.Size = new System.Drawing.Size(474, 486);
            this.grdOCS0103.TabIndex = 9;
            this.grdOCS0103.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS0103_GridCellPainting);
            this.grdOCS0103.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdOCS0103_DragDrop);
            this.grdOCS0103.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0103_MouseDown);
            this.grdOCS0103.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdOCS0103_GiveFeedback);
            this.grdOCS0103.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdOCS0103_DragEnter);
            // 
            // xGridCell11
            // 
            this.xGridCell11.CellName = "pfe_type";
            this.xGridCell11.Col = -1;
            this.xGridCell11.HeaderText = "pfe_type";
            this.xGridCell11.IsVisible = false;
            this.xGridCell11.Row = -1;
            // 
            // xGridCell12
            // 
            this.xGridCell12.CellName = "pfe_type_name";
            this.xGridCell12.Col = -1;
            this.xGridCell12.HeaderText = "pfe_type_name";
            this.xGridCell12.IsVisible = false;
            this.xGridCell12.Row = -1;
            // 
            // xGridCell8
            // 
            this.xGridCell8.CellName = "pfe_gubun";
            this.xGridCell8.Col = -1;
            this.xGridCell8.HeaderText = "pfe_gubun";
            this.xGridCell8.IsVisible = false;
            this.xGridCell8.Row = -1;
            // 
            // xGridCell13
            // 
            this.xGridCell13.CellName = "pfe_gubun_name";
            this.xGridCell13.Col = -1;
            this.xGridCell13.HeaderText = "pfe_gubun_name";
            this.xGridCell13.IsVisible = false;
            this.xGridCell13.Row = -1;
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
            this.xGridCell2.CellWidth = 324;
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
            this.xGridCell6.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
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
            // layPFE0102
            // 
            this.layPFE0102.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6});
            this.layPFE0102.QuerySQL = resources.GetString("layPFE0102.QuerySQL");
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "pfe_type";
            this.multiLayoutItem1.IsNotNull = true;
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "pfe_type_name";
            this.multiLayoutItem2.IsNotNull = true;
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "pfe_gubun";
            this.multiLayoutItem3.IsNotNull = true;
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "pfe_gubun_name";
            this.multiLayoutItem4.IsNotNull = true;
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "node1";
            this.multiLayoutItem5.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "node2";
            this.multiLayoutItem6.DataType = IHIS.Framework.DataType.Number;
            // 
            // OCS0103Q16
            // 
            this.Controls.Add(this.lblSelectAll);
            this.Controls.Add(this.grdOCS0103);
            this.Controls.Add(this.tvwPFE0102);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS0103Q16";
            this.Size = new System.Drawing.Size(756, 582);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox1)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0103)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPFE0102)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySelectOCS0103)).EndInit();
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

			if(layPFE0102.QueryLayout(true))
			{
				ShowPFE0102();
			}
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

		#region [TreeView 생체검사구분]
		private void ShowPFE0102()
		{
			tvwPFE0102.Nodes.Clear();
			if(layPFE0102.RowCount < 1) return;
            
			string pfe_type = "";
			int node1 = -1, node2 = -1;
			TreeNode node;

			foreach(DataRow row in layPFE0102.LayoutTable.Rows)
			{
				if(pfe_type != row["pfe_type"].ToString())
				{
					node = new TreeNode( row["pfe_type_name"].ToString() );
					node.Tag = row["pfe_type"].ToString();
					tvwPFE0102.Nodes.Add(node);
					pfe_type = row["pfe_type"].ToString();	
					row["node1"] = -1;
					row["node1"] = -1;
					node1 = node1 + 1;
					node2 = -1;
				}

				node = new TreeNode( row["pfe_gubun_name"].ToString() );
				node.Tag = row["pfe_gubun"].ToString();
				node.ImageIndex = 2;
				node.SelectedImageIndex = 2;					
				tvwPFE0102.Nodes[tvwPFE0102.Nodes.Count -1].Nodes.Add(node);    
				node2 = node2 + 1;
				row["node1"] = node1;
				row["node2"] = node2;							
			}

			if(layPFE0102.RowCount > 0)
				tvwPFE0102.SelectedNode = tvwPFE0102.Nodes[0].Nodes[0];
		}

		private void tvwPFE0102_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{		
			if(tvwPFE0102.SelectedNode.Parent == null) return;

			try
			{
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
				
				string pfe_type = tvwPFE0102.SelectedNode.Parent.Tag.ToString();
				string pfe_gubun  = tvwPFE0102.SelectedNode.Tag.ToString();
                
				//선택된 row Backup
				BackSelectRow();
				grdOCS0103.SetBindVarValue("f_pfe_type", pfe_type);
				grdOCS0103.SetBindVarValue("f_pfe_gubun", pfe_gubun);
				if(grdOCS0103.QueryLayout(false))
				{
					if(chkEmergency.Checked)
					{
						for(int i = 0; i < grdOCS0103.RowCount; i++)
						{
							grdOCS0103.SetItemValue(i, "emergency", "Y");
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
					if(grdOCS0103.GetItemString(curRowIndex, "bulyong_check") == "Y") return;

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

		#region [Control Event]
		private void btnProClose_Click(object sender, System.EventArgs e)
		{
			CreateReturnLayout();
		}

		private void btnProcess_Click(object sender, System.EventArgs e)
		{
			CreateReturnLayout();
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
			foreach(DataRow row in layPFE0102.LayoutTable.Rows)
			{
				node1 = int.Parse(row["node1"].ToString());
				node2 = int.Parse(row["node2"].ToString());
				tvwPFE0102.Nodes[node1].Nodes[node2].ImageIndex = 2;
				tvwPFE0102.Nodes[node1].Nodes[node2].SelectedImageIndex = 2;
			}
		}

		/// <summary>
		/// 선택된 항목이 있는 경우 tab의 이미지를 변경한다.
		/// 조건검색에 따른 항목조회가 있기 때문에 선택된 항목 전체를 check한다.
		/// </summary>
		private void SetSelectTab()
		{
			ClearSelectTab();
            
			DataRow[] pfe_type;
			int node1 = -1, node2 = -1;
            
			//선택되어진 항목
			foreach(DataRow row in laySelectOCS0103.LayoutTable.Rows)
			{
				//해당 항목의 pfe_type정보를 가져온다.
				pfe_type = layPFE0102.LayoutTable.Select(" pfe_type = '" + row["pfe_type"].ToString() + "' and pfe_gubun = '" + row["pfe_gubun"].ToString() + "' ", "");

				if(pfe_type.Length < 1) continue;
				node1 = int.Parse(pfe_type[0]["node1"].ToString());
				node2 = int.Parse(pfe_type[0]["node2"].ToString());
				tvwPFE0102.Nodes[node1].Nodes[node2].ImageIndex = 3;
				tvwPFE0102.Nodes[node1].Nodes[node2].SelectedImageIndex = 3;
			}

			//선택된 항목
			//space는 filter를 못함 --;
			for(int rowIndex = 0; rowIndex < grdOCS0103.RowCount; rowIndex++)
			{
				if(grdOCS0103.GetItemString(rowIndex, "select") == "") continue;
				//해당 항목의 pfe_type정보를 가져온다.
				pfe_type = layPFE0102.LayoutTable.Select(" pfe_type = '" + grdOCS0103.GetItemString(rowIndex, "pfe_type")  + "' and pfe_gubun = '" + grdOCS0103.GetItemString(rowIndex, "pfe_gubun") + "' ", "");
			
				if(pfe_type.Length < 1) continue;
				node1 = int.Parse(pfe_type[0]["node1"].ToString());
				node2 = int.Parse(pfe_type[0]["node2"].ToString());
				tvwPFE0102.Nodes[node1].Nodes[node2].ImageIndex = 3;
				tvwPFE0102.Nodes[node1].Nodes[node2].SelectedImageIndex = 3;
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
	}
}

