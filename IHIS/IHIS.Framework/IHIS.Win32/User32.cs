using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace IHIS.Framework
{
	public class User32
	{
		// CallBacks
		public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, ref int bRetValue, uint fWinINI);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool AnimateWindow(IntPtr hWnd, uint dwTime, uint dwFlags);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool InvalidateRect(IntPtr hWnd, ref Win32.RECT rect, bool erase);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern IntPtr LoadCursor(IntPtr hInstance, uint cursor);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern IntPtr SetCursor(IntPtr hCursor);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern IntPtr GetFocus();

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern IntPtr SetFocus(IntPtr hWnd);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool ReleaseCapture();

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool WaitMessage();

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool TranslateMessage(ref Win32.MSG msg);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool DispatchMessage(ref Win32.MSG msg);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool PostMessage(IntPtr hWnd, int Msg, uint wParam, uint lParam);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool PostMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

		#region SendMessage
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern uint SendMessage(IntPtr hWnd, int Msg, uint wParam, uint lParam);

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

		[DllImport("User32.dll",CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, ref Win32.RECT r);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref Win32.HDHITTESTINFO hti);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref Win32.HDLAYOUT hdl);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref Win32.HDITEM hdi);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref Win32.LVCOLUMN lvc);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref Win32.DRAWITEMSTRUCT dis);
		#endregion

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool GetMessage(ref Win32.MSG msg, int hWnd, uint wFilterMin, uint wFilterMax);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool PeekMessage(ref Win32.MSG msg, int hWnd, uint wFilterMin, uint wFilterMax, uint wFlag);

		[DllImport("User32.dll", ExactSpelling=true)]
		public static extern int GetMessagePos();

		[DllImport("User32.dll", ExactSpelling=true)]
		public static extern int GetMessageTime();

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern IntPtr BeginPaint(IntPtr hWnd, ref Win32.PAINTSTRUCT ps);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool EndPaint(IntPtr hWnd, ref Win32.PAINTSTRUCT ps);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern IntPtr GetDC(IntPtr hWnd);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern IntPtr GetWindowDC(IntPtr hWnd);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern int ShowWindow(IntPtr hWnd, short cmdShow);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int width, int height, bool repaint);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndAfter, int X, int Y, int Width, int Height, uint flags);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern int SetWindowPos(int hWnd, int hWndInsertAfter, int X, int Y, int Width, int Height, uint flags);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Win32.POINT pptDst, ref Win32.SIZE psize, IntPtr hdcSrc, ref Win32.POINT pprSrc, Int32 crKey, ref Win32.BLENDFUNCTION pblend, Int32 dwFlags);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool GetWindowRect(IntPtr hWnd, ref Win32.RECT rect);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool ClientToScreen(IntPtr hWnd, ref Win32.POINT pt);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool ScreenToClient(IntPtr hWnd, ref Win32.POINT pt);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool TrackMouseEvent(ref Win32.TRACKMOUSEEVENTS tme);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool redraw);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern ushort GetKeyState(int virtKey);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern IntPtr GetParent(IntPtr hWnd);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool DrawFocusRect(IntPtr hWnd, ref Win32.RECT rect);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool HideCaret(IntPtr hWnd);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool ShowCaret(IntPtr hWnd);

		[DllImport("User32.dll", CallingConvention=CallingConvention.StdCall)]
		public static extern bool InflateRect(ref Win32.RECT lprc, int dx, int dy);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static int GetClientRect(IntPtr hWnd, ref Win32.RECT rc);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static IntPtr GetDlgItem(IntPtr hDlg, int nControlID);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static int GetDlgCtrlID(IntPtr hwndCtl);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern IntPtr SetWindowsHookEx(int hookid, HookProc pfnhook, IntPtr hinst, int threadid);

		[DllImport("User32.dll", CharSet=CharSet.Auto, ExactSpelling=true)]
		public static extern bool UnhookWindowsHookEx(IntPtr hhook);

		[DllImport("User32.dll", CharSet=CharSet.Auto, ExactSpelling=true)]
		public static extern IntPtr CallNextHookEx(IntPtr hhook, int code, IntPtr wparam, IntPtr lparam);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static int DrawText(IntPtr hdc, string lpString, int nCount, ref Win32.RECT lpRect, int uFormat);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern int GetWindowText(IntPtr hWnd, out Win32.STRINGBUFFER text, int maxCount);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static IntPtr SetParent(IntPtr hChild, IntPtr hParent);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static int GetSystemMetrics(Win32.SystemMetricsCodes code);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static bool ScrollWindow(IntPtr hWnd, int XAmount, int YAmount, ref Win32.RECT lpRect, ref Win32.RECT lpClipRect);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);


		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static bool ScrollWindow(IntPtr hWnd, int XAmount, int YAmount, IntPtr lpRect, IntPtr lpClipRect);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static bool SetForegroundWindow(IntPtr hWnd);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static bool SetActiveWindow(IntPtr hWnd);

		[DllImport("User32.dll",CharSet = CharSet.Auto)]
		public static extern int GetUpdateRect(IntPtr hwnd, ref Win32.RECT rect, bool erase);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool LockWindowUpdate(IntPtr hWndLock);


		#region Win32 Macro-Like helpers
		public static int GET_X_LPARAM(int lParam)
		{
			return (lParam & 0xffff);
		}
	 

		public static int GET_Y_LPARAM(int lParam)
		{
			return (lParam >> 16);
		}

		public static Point GetPointFromLPARAM(int lParam)
		{
			return new Point(GET_X_LPARAM(lParam), GET_Y_LPARAM(lParam));
		}
		#endregion
	}
}