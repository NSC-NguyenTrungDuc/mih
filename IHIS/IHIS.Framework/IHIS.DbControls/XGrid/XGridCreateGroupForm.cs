using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;
using System.Data;

namespace IHIS.Framework
{
	/// <summary>
	/// XGridCreateGroupForm에 대한 요약 설명입니다.
	/// </summary>
	public class XGridCreateGroupForm : System.Windows.Forms.Form
	{
		private IHIS.Framework.XButton btnCancel;
		private IHIS.Framework.XButton btnOK;
		private IHIS.Framework.XListView columnList;
		private bool	canDragging = false;
		private int		dragPointX = 0;
		private int		dragPointY = 0;
		private bool    isGroupListDragging = false;  //GroupList를 Drag하는지 여부
		private ArrayList deletedGroupList = new ArrayList();
		private XGridGroupInfoCollection groupCellInfos = null;
		private XGridCellCollection cellInfos = null; 
		private IHIS.Framework.XListView groupColumnList;
		private IHIS.Framework.XListView groupList;
		private IHIS.Framework.XColumnHeader columnHeader1;
		private IHIS.Framework.XColumnHeader columnHeader2;
		private IHIS.Framework.XColumnHeader columnHeader3;
		private System.Windows.Forms.Panel pnlWaste;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		/// <summary>
		/// GroupColumns의 List를 가져옵니다.
		/// </summary>
		public System.Windows.Forms.ListView.ListViewItemCollection GroupColumns
		{
			get { return this.groupColumnList.Items;}
		}
		/// <summary>
		/// 삭제된 GroupList의 Group명을 관리하는 ArrayList입니다.
		/// </summary>
		public ArrayList DeletedGroupList
		{
			get { return deletedGroupList;}
		}

		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		/// <summary>
		/// XGridCreateGroupForm 생성자
		/// </summary>
		/// <param name="groupCellInfos"> Grouping된 컬럼을 관리하는 컬렉션 </param>
		/// <param name="cellInfos"> 컬럼정보를 관리하는 Collection </param>
		public XGridCreateGroupForm(XGridGroupInfoCollection groupCellInfos, XGridCellCollection cellInfos)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//휴지통 Image SET
			this.pnlWaste.BackgroundImage = XGridImage.CleanBox;
			this.groupCellInfos = groupCellInfos;
			this.cellInfos = cellInfos;
			this.deletedGroupList.Clear();

			//columnsList Set
			foreach (XGridCell info in cellInfos)
				columnList.Items.Add(info.CellName);
			// 이미 생성된 GroupList 보여주기
			string text = "";
			foreach (XGridGroupInfo groupInfo in this.groupCellInfos)
			{
				text = groupInfo.GroupName + ":Columns(";
				foreach (object item in groupInfo.ColumnList)
					text += item.ToString() + ",";
				text = text.Substring(0, text.Length -1) + ")";
				groupList.Items.Add(text);
				text = "";
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

		#region Windows Form Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnCancel = new IHIS.Framework.XButton();
			this.btnOK = new IHIS.Framework.XButton();
			this.columnList = new IHIS.Framework.XListView();
			this.columnHeader2 = new IHIS.Framework.XColumnHeader();
			this.groupColumnList = new IHIS.Framework.XListView();
			this.columnHeader3 = new IHIS.Framework.XColumnHeader();
			this.groupList = new IHIS.Framework.XListView();
			this.columnHeader1 = new IHIS.Framework.XColumnHeader();
			this.pnlWaste = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(306, 356);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
			this.btnCancel.Size = new System.Drawing.Size(56, 24);
			this.btnCancel.TabIndex = 12;
			this.btnCancel.Text = "취   소";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(242, 356);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(56, 24);
			this.btnOK.TabIndex = 11;
			this.btnOK.Text = "확   인";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// columnList
			// 
			this.columnList.AllowDrop = true;
			this.columnList.AutoArrange = false;
			this.columnList.Columns.AddRange(new IHIS.Framework.XColumnHeader[] {
																			   this.columnHeader2});
			this.columnList.Dock = System.Windows.Forms.DockStyle.Left;
			this.columnList.GridLines = true;
			this.columnList.LabelWrap = false;
			this.columnList.Location = new System.Drawing.Point(10, 70);
			this.columnList.MultiSelect = false;
			this.columnList.Name = "columnList";
			this.columnList.Size = new System.Drawing.Size(174, 198);
			this.columnList.TabIndex = 13;
			this.columnList.View = System.Windows.Forms.View.Details;
			this.columnList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.columnList_MouseDown);
			this.columnList.DragDrop += new System.Windows.Forms.DragEventHandler(this.columnList_DragDrop);
			this.columnList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.columnList_MouseMove);
			this.columnList.DragEnter += new System.Windows.Forms.DragEventHandler(this.columnList_DragEnter);
			this.columnList.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.columnList_GiveFeedback);
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Column List";
			this.columnHeader2.Width = 169;
			// 
			// groupColumnList
			// 
			this.groupColumnList.AllowDrop = true;
			this.groupColumnList.AutoArrange = false;
			this.groupColumnList.Columns.AddRange(new IHIS.Framework.XColumnHeader[] {
																					this.columnHeader3});
			this.groupColumnList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupColumnList.GridLines = true;
			this.groupColumnList.LabelWrap = false;
			this.groupColumnList.Location = new System.Drawing.Point(184, 70);
			this.groupColumnList.MultiSelect = false;
			this.groupColumnList.Name = "groupColumnList";
			this.groupColumnList.Size = new System.Drawing.Size(176, 198);
			this.groupColumnList.TabIndex = 14;
			this.groupColumnList.View = System.Windows.Forms.View.Details;
			this.groupColumnList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.groupColumnList_MouseDown);
			this.groupColumnList.DragDrop += new System.Windows.Forms.DragEventHandler(this.groupColumnList_DragDrop);
			this.groupColumnList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.groupColumnList_MouseMove);
			this.groupColumnList.DragEnter += new System.Windows.Forms.DragEventHandler(this.groupColumnList_DragEnter);
			this.groupColumnList.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.groupColumnList_GiveFeedback);
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Group Column List";
			this.columnHeader3.Width = 171;
			// 
			// groupList
			// 
			this.groupList.AllowDrop = true;
			this.groupList.AutoArrange = false;
			this.groupList.Columns.AddRange(new IHIS.Framework.XColumnHeader[] {
																			  this.columnHeader1});
			this.groupList.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupList.GridLines = true;
			this.groupList.LabelWrap = false;
			this.groupList.Location = new System.Drawing.Point(10, 268);
			this.groupList.MultiSelect = false;
			this.groupList.Name = "groupList";
			this.groupList.Size = new System.Drawing.Size(350, 76);
			this.groupList.TabIndex = 21;
			this.groupList.View = System.Windows.Forms.View.Details;
			this.groupList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.groupList_MouseDown);
			this.groupList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.groupList_MouseMove);
			this.groupList.DragEnter += new System.Windows.Forms.DragEventHandler(this.groupList_DragEnter);
			this.groupList.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.groupList_GiveFeedback);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "생성된 Group List";
			this.columnHeader1.Width = 346;
			// 
			// pnlWaste
			// 
			this.pnlWaste.AllowDrop = true;
			this.pnlWaste.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlWaste.Location = new System.Drawing.Point(12, 348);
			this.pnlWaste.Name = "pnlWaste";
			this.pnlWaste.Size = new System.Drawing.Size(48, 36);
			this.pnlWaste.TabIndex = 23;
			this.pnlWaste.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlWaste_DragEnter);
			this.pnlWaste.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlWaste_DragDrop);
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.Color.Purple;
			this.label3.Location = new System.Drawing.Point(4, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(376, 20);
			this.label3.TabIndex = 24;
			this.label3.Text = "※ 그룹컬럼 삭제 : Drag and Drop Group Columns To Columns";
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.Color.Purple;
			this.label1.Location = new System.Drawing.Point(4, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(376, 20);
			this.label1.TabIndex = 15;
			this.label1.Text = "※ 그룹컬럼 추가 : Drag and Drop Columns To Group Columns";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.label2.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.label2.Location = new System.Drawing.Point(4, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(376, 20);
			this.label2.TabIndex = 25;
			this.label2.Text = "※ 그룹 삭제 : Drag and Drop Group List To Basket";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.label4.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.label4.Location = new System.Drawing.Point(68, 348);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(160, 20);
			this.label4.TabIndex = 26;
			this.label4.Text = "삭제할 Group을 Drag하여";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.label5.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.label5.Location = new System.Drawing.Point(68, 368);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(105, 16);
			this.label5.TabIndex = 27;
			this.label5.Text = "Box에 넣으세요.";
			// 
			// XGridCreateGroupForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(370, 384);
			this.ControlBox = false;
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.pnlWaste);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.groupColumnList);
			this.Controls.Add(this.columnList);
			this.Controls.Add(this.groupList);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.DockPadding.Bottom = 40;
			this.DockPadding.Left = 10;
			this.DockPadding.Right = 10;
			this.DockPadding.Top = 70;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "XGridCreateGroupForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Group 추가 삭제";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			//Validation Check ,findColInfos Set
			if (!CheckValidation())	return;

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		#region Private Method
		
		private bool CheckValidation()
		{
			//GroupList의 Items의 갯수도 없고, 삭제된 GroupList도 없으면
			if ((groupColumnList.Items.Count < 1) && (this.deletedGroupList.Count < 1))
			{
				MessageBox.Show("Group 변경사항이 없습니다.");
				return false;
			}
			// 삭제된 GroupList는 1개이어야 함
			if (this.deletedGroupList.Count > 1)
			{
				MessageBox.Show("그룹은 1개씩 삭제해야 합니다.");
				return false;
			}
			//GroupList에 추가된 것이 없으면 return
			if (groupColumnList.Items.Count < 1) return true;

			// Group Columns Validation
			// ex > Columns (a,b,c,d)일때 group은 (a), (a,b), (a,b,c), (a,b,c,d)만 지정가능
			// a지정후 b지정불가, a,b 지정후 (a,d),(b,c)등 지정불가
			// Binary Type은 그룹으로 지정불가
			XGridCell cellInfo = null;
			foreach (ListViewItem item in groupColumnList.Items)
			{
				cellInfo = this.cellInfos[item.Text] as XGridCell;
				if ((cellInfo != null) && (cellInfo.CellType == XCellDataType.Binary))
				{
					MessageBox.Show("Binary Type의 컬럼은 Grouping할 수 없습니다.");
					return false;
				}
				cellInfo = null;
			}
			int groupColumnCnt = groupColumnList.Items.Count;
			int count = 0;
			ArrayList groupColList = new ArrayList();
			foreach (ListViewItem item in groupColumnList.Items)
				groupColList.Add(item.Text);

			foreach (XGridGroupInfo item in this.groupCellInfos)
			{
				count = 0;

				if (groupColumnCnt == item.ColumnList.Count)
				{
					MessageBox.Show("컬럼의 갯수가 " + groupColumnCnt.ToString() + "개인 Group은 이미 지정되었습니다.");
					return false;
				}
				if (groupColumnCnt > item.ColumnList.Count)
				{
					foreach (object colName in item.ColumnList)
						if (groupColList.Contains(colName))
							count++;
					if (count != item.ColumnList.Count)
					{
						MessageBox.Show("이미 Group을 지정된 컬럼은 반드시 포함되어야 합니다.");
						return false;
					}
				}
				else
				{
					foreach (object colName in item.ColumnList)
						if (groupColList.Contains(colName))
							count++;
					if (count != groupColumnCnt)
					{
						MessageBox.Show("이미 Group을 지정된 컬럼은 반드시 포함되어야 합니다.");
						return false;
					}
				}
			}
			return true;
		}
		#endregion

		private void columnList_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			//Group Columns에서 Remove (GroupList Dragging이 아닐때)
			ListView.SelectedListViewItemCollection selectedItems = (ListView.SelectedListViewItemCollection) (e.Data.GetData(typeof(ListView.SelectedListViewItemCollection)));
			if (isGroupListDragging || (selectedItems == null))
				return;
			foreach (ListViewItem item in selectedItems)
				groupColumnList.Items.Remove(item);
		}

		private void columnList_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)))
				e.Effect = DragDropEffects.Move;
		}

		private void columnList_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			// Drag시에 Cursor 바꿈
			if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
				Cursor.Current = XGridImage.DragCursor;
		}

		private void groupColumnList_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			//Group Columns에 Add (GroupList Dragging이 아닐때)
			ListView.SelectedListViewItemCollection selectedItems = (ListView.SelectedListViewItemCollection) (e.Data.GetData(typeof(ListView.SelectedListViewItemCollection)));
			if (isGroupListDragging || (selectedItems == null))
				return;
			
			bool isAdded = false;
			XGridCell cellInfo = null;
			foreach (ListViewItem item in selectedItems)
			{
				// 선택된 컬럼이 ReadOnly컬럼이 아니면 그룹추가 불가
				cellInfo = this.cellInfos[item.Text] as XGridCell;
				if ((cellInfo != null) && !cellInfo.IsReadOnly)
				{
					MessageBox.Show("ReadOnly컬럼만 그룹컬럼으로 지정가능합니다.");
					return;
				}
				// 이미 추가되었는지 여부 확인
				foreach (ListViewItem viewItem in groupColumnList.Items)
				{
					if (viewItem.Text == item.Text)
					{
						isAdded = true;
						break;
					}
				}
				if (!isAdded)
					groupColumnList.Items.Add(item.Text);

				isAdded = false;
			}
		}

		private void groupColumnList_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(System.Windows.Forms.ListView.SelectedListViewItemCollection)))
				e.Effect = DragDropEffects.Move;
		}

		private void groupColumnList_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			// Drag시에 Cursor 바꿈
			if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
				Cursor.Current = XGridImage.DragCursor;
		}

		private void columnList_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				canDragging = true;
				dragPointX = e.X;
				dragPointY = e.Y;
			}
		}

		private void columnList_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (canDragging && (Math.Abs(e.X - dragPointX) > 3 || Math.Abs(e.Y - dragPointY) > 3))
			{
				canDragging = false;
				// Starts a drag-and-drop operation with that item.
				if (columnList.SelectedItems.Count > 0)
				{
					isGroupListDragging = false;
					columnList.DoDragDrop(columnList.SelectedItems, DragDropEffects.Move);
				}
			}
		}

		private void groupColumnList_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				canDragging = true;
				dragPointX = e.X;
				dragPointY = e.Y;
			}
		}

		private void groupColumnList_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (canDragging && (Math.Abs(e.X - dragPointX) > 3 || Math.Abs(e.Y - dragPointY) > 3))
			{
				canDragging = false;
				// Starts a drag-and-drop operation with that item.
				if (groupColumnList.SelectedItems.Count > 0)
				{
					isGroupListDragging = false;
					groupColumnList.DoDragDrop(groupColumnList.SelectedItems, DragDropEffects.Move);
				}
			}
		}

		private void groupList_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			// Drag시에 Cursor 바꿈
			if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
				Cursor.Current = XGridImage.DragCursor;
		}

		private void groupList_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				canDragging = true;
				dragPointX = e.X;
				dragPointY = e.Y;
			}
		}

		private void groupList_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (canDragging && (Math.Abs(e.X - dragPointX) > 3 || Math.Abs(e.Y - dragPointY) > 3))
			{
				canDragging = false;
				// Starts a drag-and-drop operation with that item.
				if (groupList.SelectedItems.Count > 0)
				{
					isGroupListDragging = true;
					groupList.DoDragDrop(groupList.SelectedItems, DragDropEffects.Move);
				}
			}
		}

		private void groupList_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(System.Windows.Forms.ListView.SelectedListViewItemCollection)))
				e.Effect = DragDropEffects.Move;
		}

		private void pnlWaste_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			//Group List에서 선택된 Item Remove
			ListView.SelectedListViewItemCollection selectedItems = (ListView.SelectedListViewItemCollection) (e.Data.GetData(typeof(ListView.SelectedListViewItemCollection)));
			//GroupList Dragging일때
			if (!isGroupListDragging || (selectedItems == null))
				return;
			// 삭제된 Group이 이미 있으면 추가불가(삭제된 Group은 1개이어야 함)
			if (this.deletedGroupList.Count > 0)
			{
				MessageBox.Show("이미 삭제할 그룹을 추가하였습니다");
				return;
			}
			string groupName = "";
			foreach (ListViewItem item in selectedItems)
			{
				groupName = item.Text.Substring(0, item.Text.IndexOf(":"));
				this.deletedGroupList.Add(groupName);
				groupList.Items.Remove(item);
			}
		}

		private void pnlWaste_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(System.Windows.Forms.ListView.SelectedListViewItemCollection)))
				e.Effect = DragDropEffects.Move;
		}
	}
}