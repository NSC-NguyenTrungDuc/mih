using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;

namespace IHIS.Framework
{
	#region XOCXWorker
	public class XOCXWorker
	{

		const string REGSVR32 = "regsvr32.exe";
		public static void RegisterOCX(string fileName)
		{
			RegisterOCXSub(fileName, false, "");
		}
		public static void RegisterOCX(string fileName, string registeredTypeName)
		{
			//Registry에 이미 등록되어 있는지 여부 확인
			//OCX는 Registry의 HKEY_CLASSES_ROOT/CLSID/각Type명으로 등록되어 있음
			RegisterOCXSub(fileName, true, registeredTypeName);
		}
		public static void UnRegisterOCX(string fileName)
		{
			if (!File.Exists(fileName))
			{
				string msg = XMsg.GetMsg("M029") + fileName + XMsg.GetMsg("M030"); // 파일[" + fileName + "]이 존재하지 않습니다.
				string title = XMsg.GetMsg("M031"); //OCX 등록해제
				XMessageBox.Show(msg, title);
				return;
			}
			try
			{
				// regsvr32 /u fileName 이므로 args = /u fileName
				string args = "/u " + fileName;
				System.Diagnostics.Process.Start(REGSVR32, args);
			}
			catch(Exception xe)
			{
				string msg = XMsg.GetMsg("M032", xe); //OCX 등록해제에러[" + xe.Message + "]"
				string title = XMsg.GetMsg("M031"); //OCX 등록해제
				XMessageBox.Show(msg, title);
				
			}
		}
		private static void RegisterOCXSub(string fileName, bool checkExist, string registeredTypeName)
		{
			if (!File.Exists(fileName))
			{
				string msg = XMsg.GetMsg("M029") + fileName + XMsg.GetMsg("M030"); // 파일[" + fileName + "]이 존재하지 않습니다.
				string title = XMsg.GetMsg("M033"); //OCX 등록
				XMessageBox.Show(msg, title);
				return;
			}
			if (checkExist && IsRegisteredOCX(registeredTypeName)) return;

			try
			{
				//fileName에 Space가 있을 수 있으므로 ""로 묶음
				string args = "\"" + fileName + "\"";
				System.Diagnostics.Process.Start(REGSVR32, args);
			}
			catch(Exception xe)
			{
				string msg = XMsg.GetMsg("M034", xe); //OCX 등록에러[" + xe.Message + "]"
				string title = XMsg.GetMsg("M033"); //OCX 등록
				XMessageBox.Show(msg, title);
			}

		}
		public static bool IsRegisteredOCX(string registeredTypeName)
		{
		    try
		    {
		        /*Registry에 이미 등록되어 있는지 여부 확인
			 *OCX는 Registry의 HKEY_CLASSES_ROOT에 TypeName이 등록되어 있고,
			 *Type의 CLSID의 값이 Registry의 HKEY_CLASSES_ROOT/CLSID/CLSID값으로 등록되어 있다.
			*/
                //RegistryKey rootKey = Registry.ClassesRoot; //HKEY_CLASSES_ROOT

                //RegistryKey subKey = rootKey.OpenSubKey(registeredTypeName);
                //if (subKey == null) return false; //등록되지 않음

                //RegistryKey subKey1 = subKey.OpenSubKey("CLSID");
                //if (subKey1 == null) return false;

                //string[] valueNames = subKey1.GetValueNames();

                //if (valueNames.Length <= 0) return false;

                //object guid = subKey1.GetValue(valueNames[0]);

                //if (guid == null) return false;

                //subKey = rootKey.OpenSubKey("CLSID");
                //if (subKey != null)
                //{
                //    subKey1 = subKey.OpenSubKey(guid.ToString());
                //    if (subKey1 == null)
                //        return false;
                //    else
                //        return true;
                //}
                //else
                //    return false; //CLSID가 없을 수는 없음, CLSID가 없으면 등록도 불가
                return false;
		    }
            catch (Exception ex)
            {
                Logs.ErrWriteLog(string.Format("Message: {0}, StackTrace: {1}", ex.Message, ex.StackTrace));
                return false;
            }
		}
	}

	#endregion
}
