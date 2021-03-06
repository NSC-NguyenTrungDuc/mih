using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace IHIS.Framework
{
	#region XListBoxForm
	/// <summary>
	/// XListBoxForm에 대한 요약 설명입니다.
	/// </summary>
	internal class XListBoxForm : System.Windows.Forms.Form
	{
		#region Fields
		const int cBottomMargin = 3;
		const int cBtnWidth = 76;
		const int cBtnHeight = 24;
		const int cCaptionLeft = 22;
		const int cCaptionTop = 5;
		const int cTextBoxMargin = 5;
		const int cIconMargin = 5;
		const int cCaptionRegion = 35;
		const int cBtnRegion = 30;
		const int cFormMinWidth = 300;
		const int cFormMaxWidth = 800;
		const int cFormMinHeight = 150;
		const int cFormMaxHeight = 700;
		const int cScrollBarWidth = 25;
		private Font BTN_FONT = new Font("MS UI Gothic", 9.75f);
		private int buttonCount = 0;
		private ArrayList selectedList = new ArrayList();
		private DataTable sourceTable = null;
		private MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
		private Point formLocation = Point.Empty;
		private IHIS.Framework.XGrid grdList;
		private IHIS.Framework.XLabel lbTitle;
		private IHIS.Framework.XButton btn1 = null;
		private IHIS.Framework.XButton btn2 = null;
		private IHIS.Framework.XButton btn3 = null;

		private System.ComponentModel.IContainer components = null;
		#endregion
		
		#region Property
		internal ArrayList SelectedList
		{
			get { return selectedList;}
		}
		#endregion

		public XListBoxForm(string title, XListMsgBoxColumnCollection columns, DataTable sourceTable, MessageBoxButtons buttons, Font listFont, bool headerVisible, Point formLocation)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//Text Set
			this.lbTitle.Text = title;

			//columns 가 null이면 sourceTable에 정의된 모든 컬럼 Display, columns가 정의되어 있으면 
			//지정된 컬럼만 Display
			this.sourceTable = sourceTable;
			this.buttons = buttons;
			this.formLocation = formLocation;
			if (sourceTable == null) return;
			XGridCell cellInfo = null;
			int colIndex = 0;
			if (columns == null)
			{
				foreach (DataColumn dtCol in sourceTable.Columns)
				{
					cellInfo = new XGridCell();
					cellInfo.CellName = dtCol.ColumnName;
					//CellType은 DateTime형은 Date로 그외는 String
					if (dtCol.DataType == typeof(DateTime))
						cellInfo.CellType = XCellDataType.Date;
					else
						cellInfo.CellType = XCellDataType.String;
					cellInfo.Col = colIndex;
					//Number Type은 Align은 Right
					if (IsNumberColumn(dtCol.DataType))
						cellInfo.TextAlignment = ContentAlignment.MiddleRight;
					
					//Font 설정
					cellInfo.HeaderFont = listFont;
					cellInfo.RowFont = listFont;
					cellInfo.AlterateRowFont = listFont;
					//HeaderText 설정
					cellInfo.HeaderText = dtCol.ColumnName;

					colIndex++;
					this.grdList.CellInfos.Add(cellInfo);
				}
			}
			else
			{
				foreach (XListMsgBoxColumn item in columns)
				{
					if (sourceTable.Columns.Contains(item.ColName))
					{
						cellInfo = new XGridCell();
						cellInfo.CellName = item.ColName;
						//CellType은 DateTime형은 Date로 그외는 String
						if (sourceTable.Columns[item.ColName].DataType == typeof(DateTime))
							cellInfo.CellType = XCellDataType.Date;
						else
							cellInfo.CellType = XCellDataType.String;
						if (item.ColWidth <= 0)
							cellInfo.IsVisible = false;
						else
							cellInfo.CellWidth = item.ColWidth;
						//Number Type은 Align은 Right
						if (IsNumberColumn(sourceTable.Columns[item.ColName].DataType))
							cellInfo.TextAlignment = ContentAlignment.MiddleRight;
						cellInfo.Col = colIndex;

						//Font 설정
						cellInfo.HeaderFont = listFont;
						cellInfo.RowFont = listFont;
						cellInfo.AlterateRowFont = listFont;

						//HeaderText 설정
						cellInfo.HeaderText = item.HeaderText;
						
						if (cellInfo.IsVisible)
							colIndex++;
						this.grdList.CellInfos.Add(cellInfo);
					}
				}
			}

			this.grdList.LinePerRow = 1;
			this.grdList.ColPerLine = colIndex; //한 라인의 컬럼수

			//Font에 따라 DefaultHeight 설정 Font의 Size + 8.3f
			Graphics g = this.CreateGraphics();
			SizeF size = g.MeasureString("A", listFont);
			this.grdList.DefaultHeight = (int) (size.Height + 8.3f);

			//HeaderVisible여부에 따라 HeaderHeight Set
			if (headerVisible)
				this.grdList.HeaderHeights.Add(this.grdList.DefaultHeight);
			else
				this.grdList.HeaderHeights.Add(0); //Header는 보여주지 않음

			//컬럼초기화
			this.grdList.InitializeColumns();

		}
		private void SetButtons(MessageBoxButtons buttons, float xRate)
		{
			switch (buttons)
			{
				case MessageBoxButtons.AbortRetryIgnore:
					btn1 = new XButton();
					btn1.Font = BTN_FONT;
					btn1.Text = XMsg.GetField("F011"); // "중 단(&A)" : "Abort(&A)");
					btn1.DialogResult = DialogResult.Abort;
					btn2 = new XButton();
					btn2.Font = BTN_FONT;
					btn2.Text = XMsg.GetField("F012"); // 다시시도(&R)" : "Retry(&R)");
					btn2.Scheme = XButtonSchemes.Silver;
					btn2.DialogResult = DialogResult.Retry;
					btn3 = new XButton();
					btn3.Font = BTN_FONT;
					btn3.Text = XMsg.GetField("F013"); // 무 시(&I)" : "Ignore(&I)");
					btn3.Scheme = XButtonSchemes.OliveGreen;
					btn3.DialogResult = DialogResult.Ignore;
					buttonCount = 3;
					break;
				case MessageBoxButtons.OK:
					btn1 = new XButton();
					btn1.Font = BTN_FONT;
					btn1.Text = XMsg.GetField("F014"); // "확 인" : "確 認");
					btn1.DialogResult = DialogResult.OK;
					buttonCount = 1;
					this.AcceptButton = btn1;
					break;
				case MessageBoxButtons.OKCancel:
					btn1 = new XButton();
					btn1.Font = BTN_FONT;
					btn1.Text =  XMsg.GetField("F014"); // 확 인" : "確 認");
					btn1.DialogResult = DialogResult.OK;
					btn2 = new XButton();
					btn2.Font = BTN_FONT;
					btn2.Text =  XMsg.GetField("F015"); // 취 소" : "取消し");
					btn2.Scheme = XButtonSchemes.OliveGreen;
					btn2.DialogResult = DialogResult.Cancel;
					buttonCount = 2;
					this.AcceptButton = btn1;
					this.CancelButton = btn2;
					break;
				case MessageBoxButtons.RetryCancel:
					btn1 = new XButton();
					btn1.Font = BTN_FONT;
					btn1.Text = XMsg.GetField("F011"); // "중 단(&A)" : "Abort(&A)");
					btn1.DialogResult = DialogResult.Retry;
					btn2 = new XButton();
					btn2.Font = BTN_FONT;
					btn2.Text = XMsg.GetField("F015"); // 취 소" : "取消し");
					btn2.Scheme = XButtonSchemes.OliveGreen;
					btn2.DialogResult = DialogResult.Cancel;
					buttonCount = 2;
					this.CancelButton = btn2;
					break;
				case MessageBoxButtons.YesNo:
					btn1 = new XButton();
					btn1.Font = BTN_FONT;
					btn1.Text = XMsg.GetField("F016"); // 예(&Y)" : "Yes(&Y)");
					btn1.DialogResult = DialogResult.Yes;
					btn2 = new XButton();
					btn2.Font = BTN_FONT;
					btn2.Text = XMsg.GetField("F017"); // 아니오(&N)" : "No(&N)");
					btn2.Scheme = XButtonSchemes.OliveGreen;
					btn2.DialogResult = DialogResult.No;
					buttonCount = 2;
					break;
				case MessageBoxButtons.YesNoCancel:
					btn1 = new XButton();
					btn1.Font = BTN_FONT;
					btn1.Text = XMsg.GetField("F016"); // 예(&Y)" : "Yes(&Y)");
					btn1.DialogResult = DialogResult.Yes;
					btn2 = new XButton();
					btn2.Font = BTN_FONT;
					btn2.Text = XMsg.GetField("F017"); // 아니오(&N)" : "No(&N)");
					btn2.Scheme = XButtonSchemes.Silver;
					btn2.DialogResult = DialogResult.No;
					btn3 = new XButton();
					btn3.Font = BTN_FONT;
					btn3.Text = XMsg.GetField("F015"); // 취 소" : "取消し");
					btn3.Scheme = XButtonSchemes.OliveGreen;
					btn3.DialogResult = DialogResult.Cancel;
					buttonCount = 3;
					this.CancelButton = btn3;
					break;
			}

			int fWidth = this.ClientSize.Width;
			int fHeight = this.ClientSize.Height;
			int xPos = 0; 
			int yPos = fHeight - cBottomMargin - cBtnHeight;
			switch (buttonCount)
			{
				case 1:
					btn1.Size = new Size(cBtnWidth, cBtnHeight);
					xPos = fWidth/2 - cBtnWidth/2; //가운데
					btn1.Location = new Point(xPos, yPos);
					this.Controls.Add(btn1);
					break;
				case 2:
					btn1.Size = new Size(cBtnWidth, cBtnHeight);
					btn2.Size = new Size(cBtnWidth, cBtnHeight);
					xPos = (int) (fWidth/2 - cBtnWidth*xRate/2 - cBtnWidth);
					btn1.Location = new Point(xPos, yPos);
					xPos = (int) (fWidth/2 + cBtnWidth*xRate/2);
					btn2.Location = new Point(xPos, yPos);
					this.Controls.Add(btn1);
					this.Controls.Add(btn2);
					btn1.BringToFront();
					btn2.BringToFront();
					break;
				case 3:
					btn1.Size = new Size(cBtnWidth, cBtnHeight);
					btn2.Size = new Size(cBtnWidth, cBtnHeight);
					btn3.Size = new Size(cBtnWidth, cBtnHeight);
					int btnGap = 0;
					if (fWidth < 270)
						btnGap = (fWidth - cBtnWidth*3 - 8)/2;
					else
						btnGap = (int) (14.0f*xRate);
					xPos = fWidth/2 - cBtnWidth/2 - btnGap - cBtnWidth;
					btn1.Location = new Point(xPos, yPos);
					xPos = fWidth/2 - cBtnWidth/2;  //가운데
					btn2.Location = new Point(xPos, yPos);
					xPos = fWidth/2 + cBtnWidth/2 + btnGap;
					btn3.Location = new Point(xPos, yPos);
					this.Controls.Add(btn1);
					this.Controls.Add(btn2);
					this.Controls.Add(btn3);
					break;
			}
		}

		private bool IsNumberColumn(Type colType)
		{
			//컬럼의 Type이 numberType인지 여부
			if ((colType == typeof(decimal)) || (colType == typeof(double)) || (colType == typeof(float)) ||
				(colType == typeof(int)) || (colType == typeof(uint)) || (colType == typeof(long)) ||
				(colType == typeof(ulong)) || (colType == typeof(short)) || (colType == typeof(ushort)))
				return true;
			
			return false;
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
			this.grdList = new IHIS.Framework.XGrid();
			this.lbTitle = new IHIS.Framework.XLabel();
			((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
			this.SuspendLayout();
			// 
			// grdList
			// 
			this.grdList.ApplyAutoHeight = true;
			this.grdList.Cols = 0;
			this.grdList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdList.Location = new System.Drawing.Point(2, 25);
			this.grdList.Name = "grdList";
			this.grdList.Rows = 0;
			this.grdList.ShowBottomRightImage = false;
			this.grdList.Size = new System.Drawing.Size(790, 639);
			this.grdList.TabIndex = 4;
			this.grdList.DoubleClick += new System.EventHandler(this.grdList_DoubleClick);
			// 
			// lbTitle
			// 
			this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbTitle.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbTitle.Location = new System.Drawing.Point(2, 2);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(790, 23);
			this.lbTitle.TabIndex = 5;
			this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// XListBoxForm
			// 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(794, 694);
			this.ControlBox = false;
			this.Controls.Add(this.grdList);
			this.Controls.Add(this.lbTitle);
			this.DockPadding.Bottom = 30;
			this.DockPadding.Left = 2;
			this.DockPadding.Right = 2;
			this.DockPadding.Top = 2;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.Name = "XListBoxForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region WndProc
		protected override void WndProc(ref Message m)
		{
			//WM_NCHITTEST시에 Caption을 선택한 것처럼 Msg Hook
			if (m.Msg == (int) Win32.Msgs.WM_NCHITTEST)
				m.Result = new IntPtr(2); //Hit Caption
			else
				base.WndProc(ref m);
		}
		#endregion
		
		#region OnKeyDown
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown (e);
			//Button이 1개일때 Escape Key 처리(닫기)
			if ((this.buttonCount == 1) && (e.KeyData == Keys.Escape))
				this.Close();
		}
		#endregion

		#region OnClosing, OnLoad
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			
			if (sourceTable.Rows.Count > 0)
			{
				DataRow[] dataRows = new DataRow[sourceTable.Rows.Count];
				int index = 0;
				foreach (DataRow dtRow in sourceTable.Rows)
				{
					dataRows[index] = dtRow;
					index++;
				}
				//데이타 Import처리함
				grdList.ImportRowRange(dataRows, -1);
			}
			//Form Size 조정 (Grid가 Scroll되지 않도록 조정)
			int width = 0;
			int height = 0;
			for (int i = 0 ; i < this.grdList.Cols ; i++)
				width += this.grdList.GetColWidth(i);
			for (int i = 0 ; i < this.grdList.Rows ; i++)
				height += this.grdList.GetRowHeight(i);
			
			//Width은 ScrollBar고려 cScrollBarWidth증가 + Form의 DockPadding고려, 
			// Height는 cScrollBarWidth 증가 + Form의 DockPadding고려 + Label Height 고려
			width += cScrollBarWidth + this.DockPadding.Left + this.DockPadding.Right;
			height += cScrollBarWidth + this.DockPadding.Top + this.DockPadding.Bottom + this.lbTitle.Height;
			//최대높이,최대너비 고려
			width = Math.Min(cFormMaxWidth, Math.Max(cFormMinWidth,width));
			height = Math.Min(cFormMaxHeight, Math.Max(cFormMinHeight,height));
			//ClientSize 
			this.ClientSize = new Size(width, height);
			this.MaximumSize = this.ClientSize;
			
			//최초 크기와 비교한 xRate 계산
			float xRate = (float)width /(float)cFormMinWidth;
			//Button Set
			SetButtons(buttons, xRate);

			//2005.01.05 formLocation 이 있으면 해당 Location으로 아니면 Center
			if (this.formLocation != Point.Empty)
			{
				Point pos = this.formLocation;
				Rectangle rc = Screen.PrimaryScreen.WorkingArea;
				//창의 높이가 아래로 보이게 할때 가려지면 위로 띄움, X,Y위치 변경
				if (this.Width > rc.Width - pos.X)
				{
					pos.X = Math.Max(rc.Width - this.Width, 0);
				}
				if (this.Height > rc.Height - pos.Y)
				{
					if (this.Height > pos.Y)
						pos.Y = Math.Max(rc.Height - this.Height, 0);
					else
						pos.Y -= this.Height;
				}
				this.Location = pos;
			}
			else
			{
				//Location Center
				Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
				this.Location = new Point((rc.Width - this.Width)/2, (rc.Height - this.Height)/2);
			}
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing (e);

			//화면이 닫힐때 선택된 DataRow를 selectedList에 Add합니다.
			for (int i = 0; i < this.grdList.RowCount ; i++)
			{
				//선택된 행이면
				if (this.grdList.IsSelectedRow(i))
					this.selectedList.Add(this.sourceTable.Rows[i]);
			}
		}
		#endregion

		private void grdList_DoubleClick(object sender, System.EventArgs e)
		{
			//List Double Click시에 확인과 동일하게 처리
			if (this.btn1 != null)
				this.btn1.PerformClick();
		}

	}
	#endregion

	#region XListMsgBox
	/// <summary>
	/// XListMsgBox에 대한 요약 설명입니다.
	/// </summary>
	public class XListMsgBox
	{
		private static ArrayList selectedList = new ArrayList();
		private static Font defaultFont = new Font("MS UI Gothic",9.75f);
		public static ArrayList SelectedList
		{
			get { return selectedList;}
		}
		public static DialogResult Show(string title, DataTable sourceTable)
		{
			return Show(title, null, sourceTable, MessageBoxButtons.OKCancel, defaultFont, false);
		}
		public static DialogResult Show(string title, DataTable sourceTable, Point location)
		{
			return Show(title, null, sourceTable, MessageBoxButtons.OKCancel, defaultFont, false, location);
		}
		public static DialogResult Show(string title, DataTable sourceTable, Font listFont)
		{
			return Show(title, null, sourceTable, MessageBoxButtons.OKCancel, listFont, false);
		}
		public static DialogResult Show(string title, DataTable sourceTable, MessageBoxButtons buttons)
		{
			return Show(title, null, sourceTable, buttons, defaultFont, false);
		}
		public static DialogResult Show(string title, DataTable sourceTable, MessageBoxButtons buttons, Font listFont)
		{
			return Show(title, null, sourceTable, buttons, listFont, false);
		}
		public static DialogResult Show(string title, XListMsgBoxColumnCollection columns, DataTable sourceTable)
		{
			return Show(title, columns, sourceTable, MessageBoxButtons.OKCancel, defaultFont, false);
		}
		public static DialogResult Show(string title, XListMsgBoxColumnCollection columns, DataTable sourceTable, bool headerVisible)
		{
			return Show(title, columns, sourceTable, MessageBoxButtons.OKCancel, defaultFont, headerVisible);
		}
		public static DialogResult Show(string title, XListMsgBoxColumnCollection columns, DataTable sourceTable, Font listFont)
		{
			return Show(title, columns, sourceTable, MessageBoxButtons.OKCancel, listFont, false);
		}
		public static DialogResult Show(string title, XListMsgBoxColumnCollection columns, DataTable sourceTable, Font listFont, bool headerVisible)
		{
			return Show(title, columns, sourceTable, MessageBoxButtons.OKCancel, listFont, headerVisible);
		}
		public static DialogResult Show(string title, XListMsgBoxColumnCollection columns, DataTable sourceTable, MessageBoxButtons buttons)
		{
			return Show(title, columns, sourceTable, buttons, defaultFont, false);
		}
		public static DialogResult Show(string title, XListMsgBoxColumnCollection columns, DataTable sourceTable, MessageBoxButtons buttons, bool headerVisible)
		{
			return Show(title, columns, sourceTable, buttons, defaultFont, headerVisible);
		}
		public static DialogResult Show(string title, XListMsgBoxColumnCollection columns, DataTable sourceTable, MessageBoxButtons buttons, Font listFont)
		{
			return Show(title, columns, sourceTable, buttons, listFont, false);
		}
		public static DialogResult Show(string title, XListMsgBoxColumnCollection columns, DataTable sourceTable, MessageBoxButtons buttons, Font listFont, bool headerVisible)
		{
			return Show(title, columns, sourceTable, buttons, listFont, headerVisible, Point.Empty);	
		}
		public static DialogResult Show(string title, XListMsgBoxColumnCollection columns, DataTable sourceTable, MessageBoxButtons buttons, Font listFont, bool headerVisible, Point location)
		{
			//기존 선택된 데이타 Clear
			XListMsgBox.selectedList.Clear();
			XListBoxForm dlg = new XListBoxForm(title, columns, sourceTable, buttons, listFont, headerVisible, location);
			DialogResult result = dlg.ShowDialog();
			//DataRow List 저장
			foreach (DataRow dtRow in dlg.SelectedList)
				XListMsgBox.selectedList.Add(dtRow);
			dlg.Dispose();
			return result;
		}
	}
	#endregion

	#region XListMsgBoxColumnCollection
	internal class XListMsgBoxColumn
	{
		private string	colName = "";
		private string	headerText = "";
		private int		colWidth = 80;
		internal string ColName
		{
			get { return colName;}
		}
		internal string HeaderText
		{
			get { return headerText;}
		}
		internal int ColWidth
		{
			get { return colWidth;}
		}
		internal XListMsgBoxColumn(string colName, string headerText, int colWidth)
		{
			this.colName = colName;
			this.headerText = headerText;
			this.colWidth = colWidth;
		}
	}
	/// <summary>
	/// XListMsgBoxColumn 을 관리하는 컬렉션입니다.
	/// </summary>
	public class XListMsgBoxColumnCollection : System.Collections.CollectionBase
	{
		const int cMinWidth = 0;
		/// <summary>
		/// 보여줄 컬럼명을 지정하여 XListMsgBoxColumn을 만들어 컬렉션에 추가합니다.
		/// </summary>
		/// <param name="colName"> 보여줄 컬럼명 </param>
		public void Add(string colName)
		{
			XListMsgBoxColumn	item = new XListMsgBoxColumn(colName,"",80);
			List.Add(item);
		}
		public void Add(string colName, int width)
		{
			XListMsgBoxColumn	item = new XListMsgBoxColumn(colName, "", Math.Max(cMinWidth,width));
			List.Add(item);
		}
		public void Add(string colName, string headerText, int width)
		{
			XListMsgBoxColumn	item = new XListMsgBoxColumn(colName, headerText, Math.Max(cMinWidth,width));
			List.Add(item);
		}
		/// <summary>
		/// 지정한 Index의 ComboItem을 삭제합니다.
		/// </summary>
		/// <param name="index"> 지정 Index </param>
		public void Remove(int index)
		{
			if ((index <= Count - 1) &&(index >= 0))
				List.RemoveAt(index); 
		}
	}
	#endregion

}
