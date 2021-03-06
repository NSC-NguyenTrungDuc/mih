using System;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Configuration.Assemblies;

namespace IHIS.Framework
{
	internal enum AsmLoadRet
	{
		Success,
		NotFound,
		OldVersion,
		OldVersionInUse,
		Others
	}

	/// <summary>
	/// ScreenLoader에 대한 요약 설명입니다.
	/// </summary>
	internal class ScreenLoader
	{
		static string	basePath;
		static string	clientDownPath;

		/// <summary>
		/// 생성자 : 기준 Search Path Set
		/// </summary>
		static ScreenLoader()
		{
			basePath = Application.StartupPath;
			// Down Path (IFC\Down)
			clientDownPath = basePath + "\\Down";
			// Path 없으면 작성, 있으면 Clear
			if (!Directory.Exists(clientDownPath))
			{
				Directory.CreateDirectory(clientDownPath);
			}
			else
			{
				foreach (string FileName in Directory.GetFiles(clientDownPath))
				{
					try
					{
						File.Delete(FileName);
					}
					catch {}
				}
				foreach (string DirName in Directory.GetDirectories(clientDownPath))
				{
					try
					{
						Directory.Delete(DirName, true);
					}
					catch {}
				}
			}
		}

		/// <summary>
		/// Pgm Load
		/// </summary>
		/// <param name="upperSystemName"> 상위업무시스템명 (외래간호의 MyMenu에서 병동간호 call시에 외래간호시스템명) </param>
		/// <param name="pgmInfo"></param>
		/// <param name="asmVer"></param>
		/// <returns></returns>
		public static object Load(object opener, ScreenInfo screenInfo, OpenCommand openCommand, CommonItemCollection openParam, out string asmVer)
		{
			asmVer = "";
			object obj = null;
			AsmLoadRet ret;
			/* Load 순서
			 * 최초 시스템 실행시 해당 시스템의 Main.exe와 BGL, BSL, BSA 다운로드
			 * 다른 시스템의 화면을 열면 다른 시스템의 BGL,BSL,BSA 다운로드
			 */
			string msg = "";
			string title = XMsg.GetMsg("M025"); // 파일수신에러
			//if (EnvironInfo.CurrSystemID != screenInfo.PgmSystemID)
			//{
				//1.서버와 버전 비교 파일 DownLoad (성공시 Local에서 Load, 실패시 계속여부 확인후 처리)
				VersionResult result = DownloadFromServer(screenInfo);
				if (result == VersionResult.DownError) //다운로드 실패
				{
					msg = XMsg.GetMsg("M026") + "\n"  //파일을 다운로드하는데 실패하였습니다.
						+ XMsg.GetMsg("M027") + "\n"  //프로그램 종료후에 다시 한번 실행해 주십시오.
						+ XMsg.GetMsg("M028");        //계속 다운로드가 실패하면 전산실로 문의하시기 바랍니다.
					XMessageBox.Show(msg, title);
					return null;
				}
				else if (result == VersionResult.DeleteFail) //기존에 있던 Dummy파일 삭제실패
				{
					// 파일 Copy실패시 어떻게 처리할 것인가 결정필요함(일단 실행불가)
					msg = XMsg.GetMsg("M029") + "\n"  //다운로드 디렉토리에 있는 파일을 삭제하지 못했습니다.
						+ XMsg.GetMsg("M027") + "\n"  //프로그램 종료후에 다시 한번 실행해 주십시오.
						+ XMsg.GetMsg("M028");        //계속 다운로드가 실패하면 전산실로 문의하시기 바랍니다.
					XMessageBox.Show(msg, title);
					return null;
				}
				else if (result == VersionResult.CopyError) //현재 Load되어서  Copy 실패시 메세지 확인
				{
					msg = XMsg.GetMsg("M030") + "\n"  //화면이 업데이트되었습니다.
						+ XMsg.GetMsg("M027") + "\n"  //프로그램 종료후에 다시 한번 실행해 주십시오.
						+ XMsg.GetMsg("M028");        //계속 다운로드가 실패하면 전산실로 문의하시기 바랍니다.
					XMessageBox.Show(msg, title);
					return null;
				}
				else if (result == VersionResult.AlreadyLoaded) //이미 AppDomain에 Load된 경우
				{
					msg = XMsg.GetMsg("M030") + "\n"  //화면이 업데이트되었습니다.
						+ XMsg.GetMsg("M027") + "\n"  //프로그램 종료후에 다시 한번 실행해 주십시오.
						+ XMsg.GetMsg("M028");        //계속 다운로드가 실패하면 전산실로 문의하시기 바랍니다.
					XMessageBox.Show(msg, title);
					return null;
				}
			//}

			//다운로드 받은 파일로 Local에서 Load
			ret = LoadFromLocal(opener, screenInfo, openCommand, openParam, out asmVer, out obj);
			if (ret == AsmLoadRet.Success)  // 성공이면 화면 Object Return
				return obj;
			else
				return null;
		}

		private static VersionResult DownloadFromServer(ScreenInfo screenInfo)
		{
			//2006.11.08 Config 파일에 정의된 어셈블리 다운로드여부에 따라 다운로드 처리
			if (!Service.IsAssemblyDownLoad)
				return VersionResult.Success;

			DownloadManager loader = new DownloadManager(screenInfo);
			return loader.DownloadFiles();
		}

		/// <summary>
		/// Local에서 Assembly Load
		/// </summary>
		/// <param name="systemId"></param>
		/// <param name="pgmId"></param>
		/// <param name="download"></param>
		/// <param name="pgmVer"></param>
		/// <param name="asmVer"></param>
		/// <param name="obj"></param>
		/// <returns></returns>
		private static AsmLoadRet LoadFromLocal(object opener, ScreenInfo screenInfo, OpenCommand openCommand, CommonItemCollection openParam, out string asmVer, out object obj)
		{
			asmVer = "";
			obj = null;

			string msg = "";
			//<미확정>어셈블리이름은 시스템ID.화면ID (어셈블리명 협의후 반영필요함)
			string	asmName = screenInfo.PgmSystemID + "." + screenInfo.PgmID;
			
			//이미 Load된 어셈블리인지 확인
			Assembly	asm = LoadedAssembly(asmName);
			
			//<미확정>화면의 Naming은 IHIS.시스템ID.화면ID로 정의한다.
			string	typeName = EnvironInfo.Product + "." + screenInfo.PgmSystemID + "."  + screenInfo.PgmID;

			string	assemblyFullName = "";

			// Assembly가 Load되지 않은 경우만 새로 Load한다.
			if (asm == null)
			{
				/* 해당 화면이 다른 AppDomain에서 쓰고 있어 다운로드를 하지 못한 경우에는 IFC/Temp/현재시스템ID/화면시스템ID/화면dll 다운로드함.
				 * 따라서, 현재시스템과 화면시스템이 다른경우 DownloadManager.ScreenCopyToTemp 가 true이면 Temp Dir에서 화면을 Load함
				 * 이때 이 화면이 참조하는 BGL,BSL이 같은 Dir에 없는 경우는 AssemblyResolve Event가 발생하고 이를 OnAssemblyResolve
				 * 에서 handling하여 원래 Dir의 BGL,BSL을 Load하도록 처리함.
				 */

				//어셈블리FullName = basePath + 시스템ID\ + 어셈블리명.dll
				if (EnvironInfo.CurrSystemID != screenInfo.PgmSystemID)
				{
					if (DownloadManager.ScreenCopyToTemp)  //Temp Dir에 화면이 Copy되었으면
						assemblyFullName = basePath + "\\Temp\\" + EnvironInfo.CurrSystemID + "\\" + screenInfo.PgmSystemID + "\\" + asmName + ".dll";
					else
						assemblyFullName = basePath + "\\" + screenInfo.PgmSystemID + "\\" + asmName + ".dll";
				}
				else
					assemblyFullName = basePath + "\\" + screenInfo.PgmSystemID + "\\" + asmName + ".dll";

				// File 존재여부 확인
				if (!File.Exists(assemblyFullName))
				{
					return AsmLoadRet.NotFound;
				}

				// Version 확인 (Local File의 Version과 화면정보의 버전 비교)
				Version asmVersion = GetFileVersion(assemblyFullName);
				if (asmVersion == null)
				{
					return AsmLoadRet.NotFound;
				}
				Version objVersion ;
				try
				{
					objVersion = new Version(screenInfo.Version);
				}
				catch
				{
					objVersion = asmVersion;
				}

				// Assembly Load
				try
				{
					asm = Assembly.LoadFrom(assemblyFullName);
				}
				catch (FileNotFoundException e)
				{
					msg = XMsg.GetMsg("M031", e); // 해당 화면을 찾을 수 없습니다.
					SetMsg(msg);
					return AsmLoadRet.NotFound;
				}
				catch (FileLoadException e)
				{
					msg = XMsg.GetMsg("M032", e); // 해당 화면을 Load할 수 없습니다.[" + e.Message + "]"
					SetMsg(msg);
					return AsmLoadRet.Others;
				}
				
				//Version정보 out SET
				asmVer = asmVersion.ToString();
			}
			else
			{
				// 이미 Assembly가 Load된 경우
				// Version 확인
				Version asmVersion = asm.GetName().Version;

				asmVer = asmVersion.ToString();
			}

			// Assembly로부터 객체생성
			try
			{
				//2006.02.27 생성전 전달된 OpenArg Set -> XScreen 생성자에서 OpenArg Read Set
				//생성완료후 Reset
				OpenArg.SetOpenArg(opener, screenInfo, openParam, openCommand);
				obj = CreateInstance(asm, typeName);
			}
			catch
			{
				obj = null;
				return AsmLoadRet.Others;
			}
			finally
			{
				//OpenArg Clear
				OpenArg.ResetOpenArg();
			}

			return AsmLoadRet.Success;
		}

		/// <summary>
		/// 해당 Assembly가 AppDomain에 이미 load되었으면, Load된 Assembly를 return한다.
		/// </summary>
		/// <param name="asmName"></param>
		/// <returns></returns>
		private static Assembly LoadedAssembly(string asmName)
		{
			Assembly[] asms = AppDomain.CurrentDomain.GetAssemblies();

			foreach (Assembly asm in asms)
			{
				if (asm.GetName().Name.ToLower() == asmName.ToLower())
					return asm;
			}

			return null;
		}

        public static bool IsLoadedAssembly(string asmName, out Version asmVersion)
        {
            //Out Reset
            asmVersion = null;
            Assembly[] asms = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly asm in asms)
            {
                if (asm.GetName().Name.ToLower() == asmName.ToLower())
                {
                    asmVersion = asm.GetName().Version;
                    return true;
                }
            }

            return false;
        }

        #region 2013.09.09 LKH
        // 다른 directory 에서 load 된 dll 은 download 대상으로 처리한다. 
        // Version.xml 에 실제 download 했을 때만 기록한다면 불필요하지만
        // Version.xml 에 정보가 등록되고 파일이 (새로이) download 안된 
        // 경우가 있어서 있어서 여기서는 download 대상으로 만든다.
        public static bool IsLoadedAssembly(string asmName, string asmLocation, out Version asmVersion)
        {
            //Out Reset
            asmVersion = null;
            Assembly[] asms = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly asm in asms)
            {
                if (asm.GetName().Name.ToLower() == asmName.ToLower())
                {
                    if (asm.Location.ToLower() == asmLocation.ToLower())
                    {
                        asmVersion = asm.GetName().Version;
                        return true;
                    }
                }
                /*
                if ((asm.GetName().Name.ToLower() == asmName.ToLower())
                     && (asm.Location.ToLower() == asmLocation.ToLower())
                   )
                {
                    asmVersion = asm.GetName().Version;
                    return true;
                }
                */
            }

            return false;
        }
        #endregion 2013.09.09 LKH

        /// <summary>
		/// File Version Return
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		private static Version GetFileVersion(string fileName)
		{
			// Version 확인
			FileVersionInfo fileVersionInfo;
			try
			{
				fileVersionInfo = FileVersionInfo.GetVersionInfo(fileName);
			}
			catch
			{
				return null;
			}
			Version fileVersion = new Version(fileVersionInfo.FileMajorPart, fileVersionInfo.FileMinorPart, fileVersionInfo.FileBuildPart, fileVersionInfo.FilePrivatePart);

			return fileVersion;
		}



		/// <summary>
		/// Assembly로부터 객체생성
		/// </summary>
		/// <returns></returns>
		private static object CreateInstance(Assembly asm, string typeName)
		{
			Type pgmType;
			string msg = "";
			try
			{
				pgmType = asm.GetType(typeName, true);
			}
            //catch (Exception e)
  			catch
            {
				msg = XMsg.GetMsg("M031"); // 해당 화면을 찾을 수 없습니다.
				SetMsg(msg);
				return null;
			}
			
			object obj;
			try
			{
				obj = Activator.CreateInstance(pgmType);
			}
            //catch (Exception e)
            catch
			{
                msg = msg = XMsg.GetMsg("M033"); // 해당 화면의 객체를 생성할 수 없습니다.[" + e.Message + "]"
				SetMsg(msg);
				return null;
			}

			return obj;
		}
		private static void SetMsg(string msg)
		{
			//미확정 메세지박스로 보여줄지, 아니면 StatusBar에 보여줄지 확정후 반영
			XMessageBox.Show(msg, XMsg.GetMsg("M034"));  //화면 로드
		}
	}
}
