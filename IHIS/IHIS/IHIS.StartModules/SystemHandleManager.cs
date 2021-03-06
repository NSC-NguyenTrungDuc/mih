using System;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Collections;
using System.Windows.Forms;

namespace IHIS
{
	public class SystemHandle
	{
		private string systemID = "";
		private IntPtr handle = IntPtr.Zero;
		public string SystemID
		{
			get { return systemID;}
		}
		public IntPtr Handle
		{
			get { return handle;}
		}
		public SystemHandle(string systemID, IntPtr handle)
		{
			this.systemID = systemID;
			this.handle = handle;
		}
	}

	public class SystemHandleManager
	{
		private static ArrayList handleList = new ArrayList();
		public static ArrayList HandleList
		{
			get { return handleList;}
		}
		public static void AddHandleList(SystemHandle sysHandle)
		{
			handleList.Add(sysHandle);
		}

		public static void RemoveHandleList(string systemID)
		{
			try
			{
				SystemHandle removeItem = null;
				foreach (SystemHandle sh in handleList)
				{
					if (sh.SystemID == systemID)
					{
						removeItem = sh;
						break;
					}
				}
				if (removeItem != null)
				{
					handleList.Remove(removeItem);
				}
			}
			catch{}
		}
		public static bool Contains(string systemID)
		{
			foreach (SystemHandle sh in handleList)
				if (sh.SystemID == systemID)
					return true;
			return false;
		}
		public static IntPtr GetHandle(string systemID)
		{
			foreach (SystemHandle sh in handleList)
				if (sh.SystemID == systemID)
					return sh.Handle;
			return IntPtr.Zero;
		}
	}
}
