using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace IHIS.Framework
{
	#region enum
	public enum XToolTipIcons : int
	{
		None	= 0,
		Info	= 1,
		Warning	= 2,
		Error	= 3
	}
	#endregion
	/// <summary>
	/// XToolTip에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxBitmap(typeof(System.Windows.Forms.ToolTip))]
	[ProvideProperty("ToolTip", typeof(Control))]
	public class XToolTip : System.ComponentModel.Component, System.ComponentModel.IExtenderProvider
	{
		#region DllImports
		[DllImport("User32.dll")]
		private static extern IntPtr CreateWindowEx(int exstyle, string classname, string windowtitle, int style, int x, int y, int width, int height, IntPtr parent, int menu,
			int nullvalue, int nullptr);

		[DllImport("User32.dll")]
		private static extern int DestroyWindow(IntPtr hwnd);

		[DllImport("User32.dll")]
		private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);

		[DllImport("User32.dll")]
		private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);

		private struct toolinfo
		{
			public int size;
			public int flag;
			public IntPtr parent;
			public int id;
			public Rectangle rect;
			public int nullvalue;
			[MarshalAs(UnmanagedType.LPTStr)]
			public string text;
			public int param;
		}
		
		// Used by some constants values, not by the code.
		private const int WM_USER = 0x0400;
		
		private const int TTM_ADDTOOL				= WM_USER + 50;		
		private const int TTM_DELTOOL				= WM_USER + 51;		
		private const int TTM_ACTIVATE				= WM_USER + 1;		
		private const int TTM_SETMAXTIPWIDTH		= WM_USER + 24;	
		private const int TTM_SETTITLE				= WM_USER + 33;
		private const int TTM_SETDELAYTIME			= WM_USER + 3;
		private const int TTM_UPDATETIPTEXT			= WM_USER + 57;
		private const int TTM_SETTIPBKCOLOR			= WM_USER + 19;
		private const int TTM_SETTIPTEXTCOLOR		= WM_USER + 20;
		private const int TTM_GETTOOLINFO			= WM_USER + 53;
		private const int TTM_SETTOOLINFO			= WM_USER + 54;

		private const int TTS_ALWAYSTIP				= 0x01;
		private const int TTS_NOPREFIX				= 0x02;
		private const int TTS_BALLOON				= 0x40;

		private const int TTF_SUBCLASS				= 0x0010;
		private const int TTF_TRANSPARENT			= 0x0100;

		private const int SWP_NOSIZE				= 0x0001;
		private const int SWP_NOMOVE				= 0x0002;
		private const int SWP_NOACTIVATE			= 0x0010;
		
		private const int TTDT_AUTOPOP		       = 2;
		private const int TTDT_INITIAL		       = 3;
		
		private const int WS_POPUP					= unchecked((int)0x80000000);
		private const int CW_USEDEFAULT				= unchecked((int)0x80000000);
		
		private IntPtr TOPMOST						= new IntPtr(-1);
		#endregion

		#region Fields
		private int maxinumWidth = 200;  //Pixel
		private int autoPopDelay = 5000; //밀리 Second
		private int initialDelay = 500;	 //밀리 Second
		private bool active = true;
		private string title = "";
		private XToolTipIcons icon = XToolTipIcons.None;
		private XColor backColor = XColor.XToolTipBackColor;
		private XColor textColor = XColor.XToolTipTextColor;
		private Hashtable tooltexts = new Hashtable();  //각 Control의 ToolTip Text 관리 List
		private toolinfo tf;
		private IntPtr toolwindow;
		private IntPtr tempptr;
		#endregion

		#region Properties
		[Browsable(true),Category("추가속성"),DefaultValue(200),
		Description("ToolTip창의 Max Width를 Pixel단위로 지정합니다.(100-500)")]
		public int MaxinumWidth
		{
			get { return maxinumWidth;}
			set
			{
				if (value < 100 || value > 500) return;
				maxinumWidth = value;
				//SIZE 변경 MSG를 toolwindow에 Send
				SendMessage(toolwindow, TTM_SETMAXTIPWIDTH, 0, new IntPtr(value));
			}
		}
		[Browsable(true),Category("추가속성"),DefaultValue(5000),
		Description("포인터가 ToolTip영역내에 고정되어 있는 경우 ToolTip창이 표시되는 시간을 지정합니다.(milleSecond단위(1000-10000)")]
		public int AutoPopDelay
		{
			get { return autoPopDelay;}
			set
			{
				if (value < 1000 || value > 10000) return;
				autoPopDelay = value;
				//SIZE 변경 MSG를 toolwindow에 Send
				SendMessage(toolwindow, TTM_SETDELAYTIME, TTDT_AUTOPOP, new IntPtr(value));
			}
		}
		[Browsable(true),Category("추가속성"),DefaultValue(500),
		Description("ToolTip이 나타날 때까지 걸리는 시간을 가져오거나 설정합니다(milleSecond단위(100-2000)")]
		public int InitialDelay
		{
			get { return initialDelay;}
			set
			{
				if (value < 100 || value > 2000) return;
				initialDelay = value;
				//SIZE 변경 MSG를 toolwindow에 Send
				SendMessage(toolwindow, TTM_SETDELAYTIME, TTDT_INITIAL, new IntPtr(value));
			}
		}
		[Browsable(true),Category("추가속성"),DefaultValue(true),
		Description("ToolTip이 현재 활성화되어 있는지 여부를 나타내는 값을 가져오거나 설정합니다.")]
		public bool Active
		{
			get { return active;}
			set
			{
				if (active != value)
				{
					active = value;
					//SIZE 변경 MSG를 toolwindow에 Send
					SendMessage(toolwindow, TTM_ACTIVATE, Convert.ToInt32(value), new IntPtr(0));
				}
			}
		}
		[Browsable(true),Category("추가속성"),DefaultValue(""),
		Description("ToolTip의 Title을 지정합니다.")]
		public string Title
		{
			get { return title;}
			set
			{
				if (title != value)
				{
					title = value;
					tempptr = Marshal.StringToHGlobalUni(title);
					SendMessage(toolwindow, TTM_SETTITLE, (int) icon, tempptr);
					Marshal.FreeHGlobal(tempptr);
				}
			}
		}
		[Browsable(true),Category("추가속성"),DefaultValue(XToolTipIcons.None),
		Description("ToolTip의 Icon종류를 설정합니다.")]
		public XToolTipIcons Icon
		{
			get { return this.icon;}
			set
			{
				if (icon != value)
				{
					icon = value;
					tempptr = Marshal.StringToHGlobalUni(title);
					SendMessage(toolwindow, TTM_SETTITLE, (int) icon, tempptr);
					Marshal.FreeHGlobal(tempptr);
				}
			}
		}
		[DefaultValue(typeof(XColor),"XToolTipBackColor"),
		Description("ToolTip창의 배경색을 지정합니다.")]
		public XColor BackColor
		{
			get { return backColor;}
			set
			{
				if (backColor != value)
				{
					backColor = value;
					SendMessage(toolwindow, TTM_SETTIPBKCOLOR, ColorTranslator.ToWin32(value.Color), new IntPtr(0));
				}
			}
		}
		[DefaultValue(typeof(XColor),"XToolTipTextColor"),
		Description("ToolTip창의 텍스트색을 지정합니다.")]
		public XColor TextColor
		{
			get { return textColor;}
			set
			{
				if (textColor != value)
				{
					textColor = value;
					SendMessage(toolwindow, TTM_SETTIPTEXTCOLOR, ColorTranslator.ToWin32(value.Color), new IntPtr(0));
				}
			}
		}
		#endregion

		#region 생성자
		public XToolTip()
		{
			// ToolTip 창 생성
			toolwindow = CreateWindowEx(0, "tooltips_class32", string.Empty, WS_POPUP | TTS_BALLOON | TTS_NOPREFIX | TTS_ALWAYSTIP, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, IntPtr.Zero, 0, 0, 0);
			SetWindowPos(toolwindow, TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE);
			SendMessage(toolwindow, TTM_SETMAXTIPWIDTH, 0, new IntPtr(maxinumWidth));
			
			// ToolInfo 구조체 생성 관리
			tf = new toolinfo();
			tf.id = 0;
			tf.nullvalue = 0;
			tf.param = 0;
			tf.flag = TTF_SUBCLASS | TTF_TRANSPARENT;
			tf.size = Marshal.SizeOf(typeof(toolinfo));	
		}
		#endregion

		#region 소멸자, Dispose
		~XToolTip()
		{
			Dispose(false);
		}
		// Overriding Dispose is a must to free our window handle we created at the constructor.
		protected override void Dispose(bool disposing)
		{
			if(disposing)
			{
				tooltexts.Clear();
				tooltexts = null;
			}
			DestroyWindow(toolwindow);		// Free the window handle obtained by CreateWindowEx.
			base.Dispose (disposing);

		}
		#endregion

		#region IExtenderProvider Implemetation (다른 targer에게 추가적인 속성을 제공하는 IF, ToolTip처럼 ProvideProperty Attr을 통해 제공함)
		bool IExtenderProvider.CanExtend(object target)
		{
			if ((target is Control) && !(target is XToolTip))
			{
				return true;
			}
			return false;
		}
		#endregion

		#region ProvideProperty Attr에 대한 Method (ToolTip을 노출하므로 GetToolTip, SetToolTip Method 구현)
		//기본값을 설정하여 모든 Control에 ""인 SetToolTip이 생기지 않도록 함
		[DefaultValue("")]
		public string GetToolTip(Control parent)
		{
			//ToolTipText를 관리하는 List에 해당 Control이 등록되어 있으면 해당 Text Return, 없으면 ""
			if(tooltexts.Contains(parent))
			{
				return tooltexts[parent].ToString();
			}
			else
			{
				return string.Empty;
			}
		}
		public void SetToolTip(Control parent, string tipText)
		{
			if(tipText == null)
			{
				tipText = string.Empty;
			}
			// If the tool text have been cleared, remove the control from our service list.
			//Text 가 없으면 List에서 제거하고, 연결한 Event Handler도 제거함.
			if(tipText == string.Empty)
			{
				tooltexts.Remove(parent);

				tf.parent = parent.Handle;

				tempptr = Marshal.AllocHGlobal(tf.size);
				Marshal.StructureToPtr(tf, tempptr, false);
				SendMessage(toolwindow, TTM_DELTOOL, 0, tempptr);
				Marshal.FreeHGlobal(tempptr);
				parent.Resize -= new EventHandler(OnControlResize);

			}
			else
			{
				//Tool 구조체 생성
				tf.parent = parent.Handle;
				tf.rect = parent.ClientRectangle;
				tf.text = tipText;
				tempptr = Marshal.AllocHGlobal(tf.size);
				Marshal.StructureToPtr(tf, tempptr, false);
				
				if(tooltexts.Contains(parent))
				{
					tooltexts[parent] = tipText;
					SendMessage(toolwindow, TTM_UPDATETIPTEXT, 0, tempptr);
				}
				else
				{
					tooltexts.Add(parent, tipText);
					SendMessage(toolwindow, TTM_ADDTOOL, 0, tempptr);
					//Control의 Resize Event를 연결하여 Size 변경시 ToolInfo의 Size 다시 조정
					parent.Resize += new EventHandler(OnControlResize);
				}
				Marshal.FreeHGlobal(tempptr);

			}
		}
		private void OnControlResize(object sender, EventArgs e)
		{
			tf.parent =((Control)sender).Handle;

			tempptr = Marshal.AllocHGlobal(tf.size);
			Marshal.StructureToPtr(tf, tempptr, false);

			SendMessage(toolwindow, TTM_GETTOOLINFO, 0, tempptr);

			tf = (toolinfo) Marshal.PtrToStructure(tempptr, typeof(toolinfo));
			tf.rect = ((Control)sender).ClientRectangle;

			Marshal.StructureToPtr(tf, tempptr, false);

			SendMessage(toolwindow, TTM_SETTOOLINFO, 0, tempptr);
            
			Marshal.FreeHGlobal(tempptr);
		}
		#endregion
	}
}
