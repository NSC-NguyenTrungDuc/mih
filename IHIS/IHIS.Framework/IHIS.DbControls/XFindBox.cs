using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

namespace IHIS.Framework
{
	/// <summary>
	/// FindBox에 대한 요약 설명입니다.
	/// (IHIS.X.Magic.Docking.IPopupControl를 상속받은 이유는 이 컨트롤을 사용하는 화면이 Docking형태로 열릴때
	/// Find창을 Popup하면서 생기는 문제를 방지하기 위해 상속(자세한 내용은 IPopupControl Comment참조))
	/// </summary>
	[DefaultProperty("FindWorker")]
	[DefaultEvent("FindClick")]
	[ToolboxBitmap(typeof(IHIS.Framework.XFindBox), "Images.XFindBox.bmp")]
	public class XFindBox : IHIS.Framework.XTextBox, IHIS.X.Magic.Docking.IPopupControl
	{
		#region Class Fields
		const int findButtonWidth = 20;

		private Image findImage;
		private bool  buttonHover = false;
		private bool  buttonPressed = false;
		private XFindWorker findWorker = null;
		private int dataIndex = 0; // Find후 Return되는 값중 데이타로 설정한 Index
		private Keys clickHotKey = Keys.F4;  //Click 처리를 할 Hot Key 정의
		private bool  autoTabDataSelected = false; //Find창을 띄운후 데이타선택시 자동으로 TAB 발생시킬지 여부
		private bool  enableEdit = true; //편집이 가능한지 여부
		#endregion

		#region Properties
		// FindWorker instance 속성
		[Browsable(true), Category("추가속성"), DefaultValue(null),
		Description("Find 정보를 관리하는 Controller를 지정합니다.")]
		public XFindWorker FindWorker
		{
			get { return findWorker; }
			set { findWorker = value; }
		}
		[Browsable(true), Category("추가속성"), DefaultValue(0),
		Description("Find후 Return값들중 컨트롤의 값으로 사용할 값의 Index입니다.")]
		public int	DataIndex
		{
			get { return dataIndex; }
			set { dataIndex = Math.Max(0, value); }
		}
		[Browsable(true), Category("추가속성"), DefaultValue(Keys.F4),
		Description("Click을 발생시킬 Hot Key를 지정합니다.")]
		public Keys ClickHotKey
		{
			get { return clickHotKey;}
			set { clickHotKey = value;}
		}
		[Browsable(true), Category("추가속성"), DefaultValue(false),
		Description("Find창에서 데이타 선택시 자동으로 TAB을 발생시킬지 여부를 지정합니다.")]
		public bool AutoTabDataSelected
		{
			get { return autoTabDataSelected;}
			set { autoTabDataSelected = value;}
		}
		[Browsable(true), Category("추가속성"), DefaultValue(true),
		Description("텍스트 수정이 가능한지 여부를 지정합니다.(false시 Text 수정불가)")]
		public bool EnableEdit
		{
			get { return enableEdit;}
			set 
			{ 
				//Protect가 걸리면 EnableEdit는 무조건 false
				if (this.Protect)
					enableEdit = false;
				else
				{
					enableEdit = value;
					this.ReadOnly = !value;  //ReadOnly는 반대
				}
			}
		}
		/// <summary>
		/// 컨트롤이 편집가능한지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(false),
		MergableProperty(true),
		Description("Protect속성을 지정합니다.")]
		public new bool Protect
		{
			get { return base.Protect; }
			set
			{
				base.Protect = value;
				//Protect가 걸리면 EnableEdit는 false
				if (value)
					this.enableEdit = false;
			}
		}
		#endregion

		#region Original Property 재정의(Not Browsable)
		/// <summary>
		/// 여러 줄을 입력할 수 있는지 여부를 가져오거나 설정합니다.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		Browsable(false)]
		public override bool Multiline
		{
			get{ return base.Multiline;}
			set{ base.Multiline = value ;}
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		Browsable(false)]
		public new bool AcceptsReturn
		{
			get { return base.AcceptsReturn;}
			set { base.AcceptsReturn = value;}
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		Browsable(false)]
		public new bool AcceptsTab
		{
			get { return base.AcceptsTab;}
			set { base.AcceptsTab = value;}
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		Browsable(false)]
		public override bool AutoSize
		{
			get { return base.AutoSize;}
			set { base.AutoSize = value;}
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		Browsable(false)]
		public new char PasswordChar
		{
			get { return base.PasswordChar;}
			set { base.PasswordChar = value;}
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		Browsable(false)]
		public new ScrollBars ScrollBars
		{
			get { return base.ScrollBars;}
			set { base.ScrollBars = value;}
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		Browsable(false)]
		public override RightToLeft RightToLeft 
		{
			get { return base.RightToLeft;}
			set { base.RightToLeft = value;}
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		Browsable(false)]
		public new bool WordWrap 
		{
			get { return base.WordWrap;}
			set { base.WordWrap = value;}
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		Browsable(false)]
		public new string[] Lines
		{
			get { return base.Lines;}
			set { base.Lines = value;}
		}
		#endregion

		#region Events
		// Interface Event
		/// <summary>
		/// FindButton을 클릭할 때 발생하는 Event입니다.
		/// </summary>
		[Browsable(true),
		Category("추가이벤트"),
		Description("FindButton을 클릭할 때 발생합니다.")]
		public event CancelEventHandler FindClick;

		/// <summary>
		/// Find창에서 항목을 선택했을 때 발생하는 Event입니다.
		/// </summary>
		[Browsable(true),
		Category("추가이벤트"),
		Description("Find 창에서 항목을 선택할 때 발생합니다.")]
		public event FindEventHandler FindSelected;
		#endregion

		public XFindBox()
		{
			// Find Image 설정
			findImage = DrawHelper.FindImage;
		}

		#region Event Invokers
		protected virtual void OnFindClick(CancelEventArgs e)
		{
			if (FindClick != null)
				FindClick(this, e);
		}

		protected virtual void OnFindSelected(FindEventArgs e)
		{
			if (FindSelected != null)
				FindSelected(this, e);
		}
		#endregion

		#region Override Methods
		protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
		{
			base.OnKeyDown(e);

			if ((e.KeyCode == this.clickHotKey) && !this.Protect && this.Enabled)
			{
				//Find Click Event 발생시킴
				if (FindClick != null)
				{
					CancelEventArgs xe = new CancelEventArgs(false);
					OnFindClick(xe);
					//Find 조건이 맞지 않으면 Find창 띄우지 않음
					if (xe.Cancel) return;
				}
				PopupFindDlg();
			}
		}

		protected override void SetBoundsCore(int x, int y, int w, int h, BoundsSpecified bs)
		{
			if (w < findButtonWidth + 5)
				w = findButtonWidth + 5;
			base.SetBoundsCore(x, y, w, h, bs);
		}

		/// <summary>
		/// Non Client 영역 관련
		/// </summary>
		/// <param name="m"></param>
		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			switch (m.Msg)
			{
				case (int)Win32.Msgs.WM_NCCALCSIZE :
					int isValidClientArea = (int)m.WParam;
					if (isValidClientArea != 0)
					{
						Win32.NCCALCSIZE_PARAMS newRect = (Win32.NCCALCSIZE_PARAMS)(Marshal.PtrToStructure(m.LParam, typeof(Win32.NCCALCSIZE_PARAMS)));
						newRect.rgrc0.right -= findButtonWidth - 1;
						newRect.rgrc2.right -= findButtonWidth - 1;
						Marshal.StructureToPtr(newRect, m.LParam, true);
					}
					else
					{
						Win32.RECT newRect = (Win32.RECT)(Marshal.PtrToStructure(m.LParam, typeof(Win32.RECT)));
						newRect.right -= findButtonWidth - 1;
						Marshal.StructureToPtr(newRect, m.LParam, true);
					}
					break;
				case (int)Win32.Msgs.WM_NCHITTEST :
					int x = (int)m.LParam % 0x10000;
					int y = (int)m.LParam / 0x10000;
					Point pos = this.PointToClient(new Point(x, y));
					buttonPressed = false;
					if (pos.X >= (Bounds.Width - findButtonWidth))
					{
						m.Result = (IntPtr)19;		// Object
						if (!this.Protect && this.Enabled)
						{
							if (!buttonHover)
							{
								buttonHover = true;
								DrawFindButton(m.HWnd);
							}
						}
						else
						{
							if (buttonHover)
							{
								buttonHover = false;
								DrawFindButton(m.HWnd);
							}
						}
					}
					else if (buttonHover)
					{
						buttonHover = false;
						DrawFindButton(m.HWnd);
					}
					break;
				case (int)Win32.Msgs.WM_PAINT :
					// Paint Message에서도 Button을 칠한다.
					DrawFindButton(m.HWnd);
					break;
				case (int)Win32.Msgs.WM_NCPAINT :
					DrawFindButton(m.HWnd);
					m.Result = IntPtr.Zero;
					break;
				case (int)Win32.Msgs.WM_NCLBUTTONUP :
					if (!this.Protect && this.Enabled)
					{
						if (this.Focus())
						{
							buttonPressed = false;
							DrawFindButton(m.HWnd);
							//Find Click Event 발생시킴
							if (FindClick != null)
							{
								CancelEventArgs xe = new CancelEventArgs(false);
								OnFindClick(xe);
								//Find 조건이 맞지 않으면 Find창 띄우지 않음
								if (xe.Cancel) return;
							}
							PopupFindDlg();
						}
					}
					break;
				case (int)Win32.Msgs.WM_NCLBUTTONDOWN :
					if (!this.Protect && this.Enabled)
					{
						if (this.Focus())
						{
							buttonPressed = true;
							DrawFindButton(m.HWnd);
						}
					}
					break;
				case (int)Win32.Msgs.WM_NCMOUSELEAVE :
					if (buttonHover)
					{
						buttonHover = false;
						DrawFindButton(m.HWnd);
					}
					break;
				case (int)Win32.Msgs.WM_NCMOUSEMOVE :
					RequestMouseLeaveMessage(m.HWnd);
					break;
			}
		}
		#endregion

		#region Find Dialog 관련 Methods
		public void PopupFindDlg()
		{
			if (this.findWorker == null)
				return;

			//2007.11.08 findWorker의 QueryStarting Event Invoke 추가
			CancelEventArgs ce = new CancelEventArgs(false);
			this.findWorker.OnQueryStarting(ce);
			//Cancel시에 FindForm 띄우지 않음
			if (ce.Cancel)
				return;

			FindForm findDlg = new FindForm(this.findWorker, this);
			if (findDlg.ShowDialog() == DialogResult.OK)
			{
				if (findDlg.DataCount > 0)
				{
					//DataIndex에 따라 Data설정
					if ((this.dataIndex >= 0) && (this.dataIndex < findDlg.DataCount))
						this.DataValue = findDlg.SelectedData[this.dataIndex].ToString();
					
					//FindSelected Event 구동
					FindEventArgs e = new FindEventArgs(findDlg.SelectedData);
					OnFindSelected(e);

					// DataValidating Event도 구동
					DataValidatingEventArgs xe = new DataValidatingEventArgs(false, DataValue);
					OnDataValidating(xe);
					//Cancel이 아니면 다음 Control로 이동
					if (!xe.Cancel)
					{
						//DataChanged Clear
						this.DataChanged = false;

						//다음 Control로 이동
						if (this.autoTabDataSelected)
							SendKeys.Send("{TAB}");
					}
				}
			}
			findDlg.Dispose();
		}
		#endregion

		#region Other Private Methos
		private void DrawFindButton(IntPtr hwnd)
		{
			IntPtr hDC = User32.GetWindowDC(hwnd);
			Graphics g = Graphics.FromHdc(hDC);

			Rectangle buttonRect = new Rectangle(Bounds.Width - findButtonWidth -1, 0, findButtonWidth , Bounds.Height - 1);
			g.FillRectangle(new SolidBrush(Color.WhiteSmoke), buttonRect);
			Point imagePos = new Point(buttonRect.Left + (buttonRect.Width - findImage.Width) / 2 + 1, buttonRect.Top + (buttonRect.Height - findImage.Height) / 2);
			if (buttonHover && !buttonPressed)
				imagePos.Offset(0, -1);
			//g.DrawImage(findImage, imagePos);
			g.DrawImageUnscaled(findImage, imagePos);
			//DrawHelper.BlitBitmap(g, buttonRect, 0,0, ((Bitmap)findImage).GetHbitmap());
			Pen rectPen = null;
			if (buttonPressed)
				rectPen = new Pen(Color.LightSeaGreen);
			else if (buttonHover)
				rectPen = new Pen(XColor.ActiveBorderColor.Color);
			else
				rectPen = new Pen(XColor.NormalBorderColor.Color);

			g.DrawRectangle(rectPen, buttonRect);

			// Button에 Mouse Pointer가 있는 상태
			if (buttonHover)
			{
				g.DrawLine(new Pen(Color.White), buttonRect.Location, new Point(buttonRect.Right, buttonRect.Top));
				g.DrawLine(new Pen(Color.White), buttonRect.Location, new Point(buttonRect.Left, buttonRect.Bottom));
				g.DrawLine(new Pen(Color.DarkGray), new Point(buttonRect.Right - 1, buttonRect.Top + 1), new Point(buttonRect.Right - 1, buttonRect.Bottom - 1));
				g.DrawLine(new Pen(Color.DarkGray), new Point(buttonRect.Left + 1, buttonRect.Bottom - 1), new Point(buttonRect.Right - 1, buttonRect.Bottom - 1));
			}

			rectPen.Dispose();
			g.Dispose();
			User32.ReleaseDC(hwnd, hDC);
		}

		private void RequestMouseLeaveMessage(IntPtr hwnd)
		{
			Win32.TRACKMOUSEEVENTS tme = new Win32.TRACKMOUSEEVENTS();
			tme.cbSize = 16;
			tme.dwFlags = (uint)(Win32.TrackerEventFlags.TME_NONCLIENT | Win32.TrackerEventFlags.TME_LEAVE);
			tme.hWnd = hwnd;
			tme.dwHoverTime = 0;
			User32.TrackMouseEvent(ref tme);
		}
		#endregion

	}

	#region FindEventHandler
	[Serializable]
	public delegate void FindEventHandler(object sender, FindEventArgs e);
	
	public class FindEventArgs : EventArgs
	{
		object[]	returnValues;

		public object[] ReturnValues
		{
			get { return returnValues; }
			set { returnValues = value; }
		}

		public FindEventArgs(object[] data)
		{
			this.returnValues = data;
		}
	}
	#endregion
}
