using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Reflection;
using IHIS.Framework;

namespace IHIS.ADMM
{
	/// <summary>
	/// NotifyIconEx에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(System.Windows.Forms.NotifyIcon))]
	public class NotifyIconEx : System.ComponentModel.Component
	{
		#region Notify Icon Target Window
		private class NotifyIconTarget : System.Windows.Forms.Form
		{
			public NotifyIconTarget()
			{
			}
			protected override  void DefWndProc(ref Message msg)
			{
				if(msg.Msg == (int) Win32.Msgs.WM_USER) // WM_USER
				{
					uint msgId = (uint)msg.LParam;
					uint id = (uint)msg.WParam;
					
					//WM_LBUTTONUP, WM_LBUTTONDBCLK, WM_RBUTTONUP 처리
					switch(msgId)
					{
						case (int) Win32.Msgs.WM_LBUTTONUP: // WM_LBUTTONUP
							if(ClickNotify != null)
								ClickNotify(this, id);
							break;
						case (int) Win32.Msgs.WM_LBUTTONDBLCLK: // WM_LBUTTONDBLCLK
							if(DoubleClickNotify != null)
								DoubleClickNotify(this, id);
							break;

						case (int) Win32.Msgs.WM_RBUTTONUP: // WM_RBUTTONUP
							if(RightClickNotify != null)
								RightClickNotify(this, id);
							break;
					}
				}
				else
				{
					base.DefWndProc(ref msg);
				}
			}

			public delegate void NotifyIconHandler(object sender, uint id);
			public event NotifyIconHandler ClickNotify;
			public event NotifyIconHandler DoubleClickNotify;
			public event NotifyIconHandler RightClickNotify;
		}
		#endregion

		#region Win32 Struct, API
		[StructLayout(LayoutKind.Sequential)] private struct NotifyIconData
		{
			public int cbSize; // DWORD
			public IntPtr hWnd; // HWND
			public int uID; // UINT
			public NotifyFlags uFlags; // UINT
			public int uCallbackMessage; // UINT
			public IntPtr hIcon; // HICON
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst=128)]
			public string szTip; // char[128]
			public NotifyState dwState; // DWORD
			public NotifyState dwStateMask; // DWORD
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst=256)]
			public string szInfo; // char[256]
			public int uTimeoutOrVersion; // UINT
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst=64)]
			public string szInfoTitle; // char[64]
			public NotifyInfoFlags dwInfoFlags; // DWORD
		}

		[DllImport("shell32.Dll")]
		private static extern int Shell_NotifyIcon(NotifyCommand cmd, ref NotifyIconData data);

		[DllImport("User32.Dll")]
		private static extern int TrackPopupMenuEx(IntPtr hMenu,
			int uFlags,
			int x,
			int y,
			IntPtr hWnd,
			IntPtr ignore);

		[StructLayout(LayoutKind.Sequential)] private struct POINT
		{
			public int x;
			public int y;
		}

		[DllImport("User32.Dll")]
		private static extern int GetCursorPos(ref POINT point);

		[DllImport("User32.Dll")]
		private static extern int SetForegroundWindow(IntPtr hWnd);
		#endregion

		#region Enum
		private enum NotifyInfoFlags {Error=0x03, Info=0x01, None=0x00, Warning=0x02}
		private enum NotifyCommand {Add=0x00, Delete=0x02, Modify=0x01}
		private enum NotifyFlags {Message=0x01, Icon=0x02, Tip=0x04, Info=0x10, State=0x08}
		private enum NotifyState {Hidden=0x01}
		#endregion

		#region Fields
		private static NotifyIconTarget m_messageSink = new NotifyIconTarget();  //메세지 처리 창
		private static int m_nextId = 1;
		private int m_id = 0; // each icon in the notification area has an id
		private IntPtr m_handle; // Icon Handle 보관
		private string m_text = "";
		private Icon m_icon = null;
		private ContextMenu m_contextMenu = null;
		private bool m_visible = false;
		private bool m_doubleClick = false; // fix for extra mouse up message we want to discard

		public event EventHandler Click;
		public event EventHandler DoubleClick;
		#endregion

		#region Properties
		public string Text
		{
			set
			{
				if(m_text != value)
				{
					m_text = value;
					CreateOrUpdate();
				}
			}
			get
			{
				return m_text;
			}
		}

		public Icon Icon
		{
			set
			{
				m_icon = value;
				CreateOrUpdate();
			}
			get
			{
				return m_icon;
			}
		}

		public ContextMenu ContextMenu
		{
			set
			{
				m_contextMenu = value;
			}
			get
			{
				return m_contextMenu;
			}
		}

		public bool Visible
		{
			set
			{
				if(m_visible != value)
				{
					m_visible = value;
					CreateOrUpdate();
				}
			}
			get
			{
				return m_visible;
			}
		}
		#endregion
		
		#region 생성자
		public NotifyIconEx()
		{

		}
		#endregion

		#region Methods
		private void CreateOrUpdate()
		{
			if(this.DesignMode)
				return;

			if(m_id == 0)
			{
				//Icon이 있으면 Create Tray
				if(m_icon != null)
					Create(m_nextId++);
			}
			else  //Update Icon
				Update();
		}
		private void Create(int id)
		{
			try
			{
				NotifyIconData data = new NotifyIconData();
				data.cbSize = Marshal.SizeOf(data);

				m_handle = m_messageSink.Handle;
				data.hWnd = m_handle;
				m_id = id;
				data.uID = m_id;
			
				//WM_USER MSG를 CallBack
				data.uCallbackMessage = (int) Win32.Msgs.WM_USER;
				data.uFlags |= NotifyFlags.Message;

				data.hIcon = m_icon.Handle; // this should always be valid
				data.uFlags |= NotifyFlags.Icon;

				data.szTip = m_text;
				data.uFlags |= NotifyFlags.Tip;

				if(!m_visible)
					data.dwState = NotifyState.Hidden;
				data.dwStateMask |= NotifyState.Hidden;

				Shell_NotifyIcon(NotifyCommand.Add, ref data);

				// add handlers
				m_messageSink.ClickNotify += new NotifyIconTarget.NotifyIconHandler(OnClick);
				m_messageSink.DoubleClickNotify += new NotifyIconTarget.NotifyIconHandler(OnDoubleClick);
				m_messageSink.RightClickNotify += new NotifyIconTarget.NotifyIconHandler(OnRightClick);
			}
			catch{}
		}

		// update an existing icon
		private void Update()
		{
			try
			{
				NotifyIconData data = new NotifyIconData();
				data.cbSize = Marshal.SizeOf(data);

				data.hWnd = m_messageSink.Handle;
				data.uID = m_id;

				data.hIcon = m_icon.Handle; // this should always be valid
				data.uFlags |= NotifyFlags.Icon;

				data.szTip = m_text;
				data.uFlags |= NotifyFlags.Tip;
				data.uFlags |= NotifyFlags.State;

				if(!m_visible)
					data.dwState = NotifyState.Hidden;
				data.dwStateMask |= NotifyState.Hidden;

				Shell_NotifyIcon(NotifyCommand.Modify, ref data);
			}
			catch{}
		}

		protected override void Dispose(bool disposing)
		{
			Remove();
			base.Dispose(disposing);
		}

		public void Remove()
		{
			try
			{
				if(m_id != 0)
				{
					// remove the notify icon
					NotifyIconData data = new NotifyIconData();
					data.cbSize = Marshal.SizeOf(data);
					
					data.hWnd = m_handle;
					data.uID = m_id;

					Shell_NotifyIcon(NotifyCommand.Delete, ref data);

					m_id = 0;
				}
			}
			catch{}
		}
		#endregion

		#region Event Handler
		private void OnClick(object sender, uint id)
		{
			if(id == m_id)
			{
				if(!m_doubleClick && Click != null)
					Click(this, EventArgs.Empty);
				m_doubleClick = false;
			}
		}

		private void OnRightClick(object sender, uint id)
		{
			try
			{
				if(id == m_id)
				{
					// show context menu
					if(m_contextMenu != null)
					{					
						POINT point = new POINT();
						GetCursorPos(ref point);
					
						SetForegroundWindow(m_messageSink.Handle); // this ensures that if we show the menu and then click on another window the menu will close

						// call non public member of ContextMenu
						m_contextMenu.GetType().InvokeMember("OnPopup",
							BindingFlags.NonPublic|BindingFlags.InvokeMethod|BindingFlags.Instance,
							null, m_contextMenu, new Object[] {System.EventArgs.Empty});

						TrackPopupMenuEx(m_contextMenu.Handle, 0x40, point.x, point.y, m_messageSink.Handle, IntPtr.Zero);
					}
				}
			}
			catch{}
		}

		private void OnDoubleClick(object sender, uint id)
		{
			if(id == m_id)
			{
				m_doubleClick = true;
				if(DoubleClick != null)
					DoubleClick(this, EventArgs.Empty);
			}
		}
		#endregion
	}
}
