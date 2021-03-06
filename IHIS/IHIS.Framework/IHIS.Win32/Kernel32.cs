using System;
using System.Text;
using System.Runtime.InteropServices;

namespace IHIS.Framework
{
    public class Kernel32
    {
		[DllImport("Kernel32.dll", ExactSpelling=true, CharSet=CharSet.Auto)]
		public static extern int GetCurrentThreadId();

		[DllImport("kernel32.dll")]
		public static extern bool Beep(int n, int m); // n은 주파수, m은 소리내는 시간(단위: 1/1000초)

		[DllImport("winmm.dll")]
		public static extern int PlaySound(string pszSound, int hmod, Win32.SoundFlags falgs);
		[DllImport("winmm.dll")]
		public static extern int PlaySound(string pszSound, IntPtr hmod, Win32.SoundFlags falgs);

		[DllImport( "kernel32.dll")]
		public static extern void SetSystemTime([In] Win32.SYSTEMTIME st);
		
		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString(string section,
			string key,string data,string fileName);
		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section,
			string key,string defaultValue, StringBuilder retValue,
			int size,string fileName);

		public static void Beep()
		{
			Beep(500,300);
		}

		public static void Nofify()
		{
			PlaySound("notify",0, Win32.SoundFlags.SND_ASYNC);
		}

		public static void Warn()
		{
			PlaySound("SystemHand",0,Win32.SoundFlags.SND_ASYNC);
		}

		public static void SetProfileString(string fileName, string section, string key, string data)
		{
			try
			{
				WritePrivateProfileString(section, key, data, fileName);
			}
			catch{}
		}
		public static string GetProfileString(string fileName, string section, string key)
		{
			return GetProfileString(fileName, section, key, "");
		}
		public static string GetProfileString(string fileName, string section, string key, string defaultValue)
		{
			try
			{
				StringBuilder temp = new StringBuilder(255);
				GetPrivateProfileString(section, key, defaultValue, temp, 255, fileName);
				return temp.ToString();
			}
			catch
			{
				return "";
			}
		}
	}
}