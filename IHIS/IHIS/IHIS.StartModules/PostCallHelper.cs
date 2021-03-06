using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace IHIS
{

	// PostCall 사용 Delegate
	/// <summary>
	/// Argument가 없는 메서드를 PostMessage하는 메서드를 나타냅니다.
	/// </summary>
	public delegate void PostMethod();
	/// <summary>
	/// Argument가 int형인 메서드를 PostMessage하는 메서드를 나타냅니다.
	/// </summary>
	public delegate void PostMethodInt(int argInt);
	/// <summary>
	/// Argument가 int형 2개인 메서드를 PostMessage하는 메서드를 나타냅니다.
	/// </summary>
	public delegate void PostMethodInt2(Int16 argInt1, Int16 argInt2);
	/// <summary>
	/// Argument가 string형인 메서드를 PostMessage하는 메서드를 나타냅니다.
	/// </summary>
	public delegate void PostMethodStr(string argStr);
	/// <summary>
	/// Argument가 object형인 메서드를 PostMessage하는 메서드를 나타냅니다.
	/// </summary>
	public delegate void PostMethodObject(object argObj);

	/// <summary>
	/// PostCallHelper에 대한 요약 설명입니다.
	/// </summary>
	public class PostCallHelper
	{
		// Static Member =================================
		const int postCallMsg = (int)Msgs.WM_USER;
		const int maxCall = 100;
		private static FormPostCallHelper msgForm;
		private static IntPtr	hWnd;
		private static object[] methods = new object[maxCall];
		private static int		serial = -1;
		/// <summary>
		/// PostCallHelper static 생성자
		/// </summary>
		static PostCallHelper()
		{
		}
		/// <summary>
		/// Control의 Focus를 PostMessage합니다.
		/// </summary>
		/// <param name="cont"> Control </param>
		public static void PostFocus(Control cont)
		{
			// Control로 Focus PostMessage
			User32.PostMessage(cont.Handle, (int)Msgs.WM_SETFOCUS, 0, 0);
		}
		/// <summary>
		/// Control의 Close를 PostMessage합니다.
		/// </summary>
		/// <param name="cont"></param>
		public static void PostClose(Control cont)
		{
			// Control로 Close PostMessage
			User32.PostMessage(cont.Handle, (int)Msgs.WM_CLOSE, 0, 0);
		}
		/// <summary>
		/// Click Enum
		/// </summary>
		public enum Click
		{
			/// <summary>
			/// Click Down
			/// </summary>
			Down,
			/// <summary>
			/// Click Up
			/// </summary>
			Up,
			/// <summary>
			/// Double Click
			/// </summary>
			Double
		}
		/// <summary>
		/// Control의 Click을 PostMessage합니다.
		/// </summary>
		/// <param name="cont"> Control </param>
		/// <param name="button"> MouseButtons </param>
		/// <param name="click"> Click Enum(Down,Up,Double) </param>
		public static void PostClick(Control cont, MouseButtons button, Click click)
		{
			int msg = 0;

			switch (button)
			{
				case MouseButtons.Left :
				switch (click)
				{
					case Click.Down :
						msg = (int)Msgs.WM_LBUTTONDOWN;
						break;
					case Click.Up :
						msg = (int)Msgs.WM_LBUTTONUP;
						break;
					case Click.Double :
						msg = (int)Msgs.WM_LBUTTONDBLCLK;
						break;
				}
					break;

				case MouseButtons.Right :
				switch (click)
				{
					case Click.Down :
						msg = (int)Msgs.WM_RBUTTONDOWN;
						break;
					case Click.Up :
						msg = (int)Msgs.WM_RBUTTONUP;
						break;
					case Click.Double :
						msg = (int)Msgs.WM_RBUTTONDBLCLK;
						break;
				}
					break;

				case MouseButtons.Middle :
				switch (click)
				{
					case Click.Down :
						msg = (int)Msgs.WM_MBUTTONDOWN;
						break;
					case Click.Up :
						msg = (int)Msgs.WM_MBUTTONUP;
						break;
					case Click.Double :
						msg = (int)Msgs.WM_MBUTTONDBLCLK;
						break;
				}
					break;

				default :
					return;
			}
			// Control로 Click PostMessage
			User32.PostMessage(cont.Handle, msg, 0, 0);
		}
		
		/// <summary>
		/// PostCall Sub 메서드입니다.
		/// </summary>
		/// <param name="method"> 구동할 메서드 </param>
		/// <param name="lParam"> LParam </param>
		protected static void InternalPostCall(object method, IntPtr lParam)
		{
			if (msgForm == null)
			{
				msgForm = new FormPostCallHelper(postCallMsg);
				msgForm.PostMsgReceived += new PostEventHandler(OnPostMsgReceived);
				msgForm.Show();
				hWnd = msgForm.Handle;
			}

			serial ++;
			if (serial >= maxCall) serial = 0;
			methods[serial] = method;

			// Hidden Form으로 PostMessage
			User32.PostMessage(hWnd, postCallMsg, (uint)serial, (uint)lParam);
		}

		/// <summary>
		/// 매개변수가 없는 메서드를 PostMessage하는 메서드입니다.
		/// </summary>
		/// <param name="method"> 구동할 메서드 </param>
		public static void PostCall(PostMethod method)
		{
			InternalPostCall(method, (IntPtr)0);
		}
		/// <summary>
		/// 매개변수가 int형인 메서드를 PostMessage하는 메서드입니다.
		/// </summary>
		/// <param name="method"> 구동할 메서드 </param>
		/// <param name="argInt"> int형 매개변수 </param>
		public static void PostCall(PostMethodInt method, int argInt)
		{
			InternalPostCall(method, (IntPtr)argInt);
		}
		/// <summary>
		/// 매개변수가 int형 2개인 메서드를 PostMessage하는 메서드입니다.
		/// </summary>
		/// <param name="method"> 구동할 메서드 </param>
		/// <param name="argInt1"> int형 매개변수 </param>
		/// <param name="argInt2"> int형 매개변수 </param>
		public static void PostCall(PostMethodInt2 method, Int16 argInt1, Int16 argInt2)
		{
			int	argInt = argInt1 * 0x10000 + argInt2;
			InternalPostCall(method, (IntPtr)argInt);
		}
		/// <summary>
		/// 매개변수가 string형인 메서드를 PostMessage하는 메서드입니다.
		/// </summary>
		/// <param name="method"> 구동할 메서드 </param>
		/// <param name="argStr"> string형 매개변수</param>
		public static void PostCall(PostMethodStr method, string argStr)
		{
			IntPtr arg = Marshal.StringToHGlobalUni(argStr);
			InternalPostCall(method, arg);
		}
		
		/// <summary>
		/// 매개변수가 object형인 메서드를 PostMessage하는 메서드입니다.
		/// </summary>
		/// <param name="method"> 구동할 메서드 </param>
		/// <param name="argObj"> object형 매개변수</param>
		public static void PostCall(PostMethodObject method, object argObj)
		{
			IntPtr arg = Marshal.AllocHGlobal(10);
			Marshal.GetNativeVariantForObject(argObj, arg);
			InternalPostCall(method, arg);
		}

		/// <summary>
		/// Message 접수시 지정한 Delegate Call합니다.
		/// </summary>
		/// <param name="m"> Window Message </param>
		protected static void OnPostMsgReceived(Message m)
		{
			int index = (int)m.WParam;
			if (index >= maxCall) return;
			if (methods[index] == null) return;

			if (methods[index] is PostMethod)
				CallMethod((PostMethod)methods[index]);
			else if (methods[index] is PostMethodInt)
				CallMethod((PostMethodInt)methods[index], (int)m.LParam);
			else if (methods[index] is PostMethodInt2)
			{
				Int16 argInt1 = (Int16)((int)m.LParam / 0x10000);
				Int16 argInt2 = (Int16)((int)m.LParam % 0x10000);
				CallMethod((PostMethodInt2)methods[index], argInt1, argInt2);
			}
			else if (methods[index] is PostMethodStr)
			{
				string arg = Marshal.PtrToStringUni(m.LParam);
				Marshal.FreeHGlobal(m.LParam);
				CallMethod((PostMethodStr)methods[index], arg);
			}
			else if (methods[index] is PostMethodObject)
			{
				object arg = Marshal.GetObjectForNativeVariant(m.LParam);
				Marshal.FreeHGlobal(m.LParam);
				CallMethod((PostMethodObject)methods[index], arg);
			}
		}
		/// <summary>
		/// 매개변수가 없은 메서드를 Call합니다.
		/// </summary>
		/// <param name="method"> 구동할 메서드 </param>
		protected static void CallMethod(PostMethod method)
		{
			method();
		}
		/// <summary>
		/// 매개변수가 int형인 메서드를 Call합니다.
		/// </summary>
		/// <param name="method"> 구동할 메서드 </param>
		/// <param name="argInt"> int형 매개변수 </param>
		protected static void CallMethod(PostMethodInt method, int argInt)
		{
			method(argInt);
		}
		/// <summary>
		/// 매개변수가 int형 2개인 메서드를 Call합니다.
		/// </summary>
		/// <param name="method"> 구동할 메서드 </param>
		/// <param name="argInt1"> int형 매개변수 </param>
		/// <param name="argInt2"> int형 매개변수 </param>
		protected static void CallMethod(PostMethodInt2 method, Int16 argInt1, Int16 argInt2)
		{
			method(argInt1, argInt2) ;
		}
		/// <summary>
		/// 매개변수가 string형인 메서드를 Call합니다.
		/// </summary>
		/// <param name="method"> 구동할 메서드 </param>
		/// <param name="argStr"> string형 매개변수 </param>
		protected static void CallMethod(PostMethodStr method, string argStr)
		{
			method(argStr);
		}
		/// <summary>
		/// 매개변수가 object형인 메서드를 Call합니다.
		/// </summary>
		/// <param name="method"> 구동할 메서드 </param>
		/// <param name="argObj"> object형 매개변수 </param>
		protected static void CallMethod(PostMethodObject method, object argObj)
		{
			method(argObj);
		}
	}
}
