using System;
using System.Xml;
using System.Text;
using System.Collections;
using System.IO;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace IHIS.Framework
{
	public enum VersionResult //Version Check 결과
	{
		CopyError,   //다운로드후에 파일 Copy시에 에러(시스템 재시작 필요)
		NotChanged,  //변경사항 없음
		DownError,  //다운로드시 에러 발생
		Success,    //다운로드및 Version Check 성공
		DeleteFail,  //Down\bin에 있는 Dummy파일 삭제 실패(IHIS 다시 기동필요함)
		AlreadyLoaded  //이미 어셈블리가 현재 AppDomain에서 Load되어 Copy가 불가능한 경우
	}

	public enum DownFileType
	{
		/// <summary>
		/// dll File
		/// </summary>
		DLLFile,
		/// <summary>
		/// Report File (UbReport파일, pbd File)
		/// </summary>
		RPTFile
	}
	public struct DownFileInfo
	{
		public string FileName;
		public string DownPath;
		public string FileVersion;
		public DownFileType FileType ;
		public string EssentialVersion; //사용해야할 어셈블리의 필수 Version
		public DownFileInfo(string fileName, string downPath, string fileVersion, string essentialVersion, DownFileType fileType)
		{
			FileName = fileName;
			DownPath = downPath;
			FileVersion = fileVersion;
			EssentialVersion = essentialVersion;
			FileType = fileType;
		}
	}

	/// <summary>
	/// DownloadManager에 대한 요약 설명입니다.
	/// </summary>
	internal class DownloadManager
	{
		#region static Fields
		const string VERSION_FILE = "Version.xml";
		const string FTP_USERID = "ihisdown";
		const string FTP_PSWD = "ihisdown";
		private static Encoding kscEncoding = Service.BaseEncoding;
		private static string	basePath;
		private static string	binPath;
		private static string	downPath;
		private static string	serverIP = "172.16.21.130";
		private static string   pgmSystemID = "";  //현재 다운로드한 시스템의 ID
		private static bool		screenCopyToTemp = false; //해당 화면이 Temp Dir로 Copy되었는지 여부
		#endregion

		#region Fields
		private SocketTransferClient transferClient = null;  //By TCP
		private DownloadProgressForm downloadForm = null;
		private XFTPWorker ftpWorker = null;  //By FTP
		private ArrayList	downFileList = new ArrayList();
		private ArrayList   serverFileList = new ArrayList();
		private ScreenInfo screenInfo = null;
		private int		totalCount = 0;
		private string copyPath = "";      //Download후에 Copy할 path(ADM OR OCS ...)
		private XmlDocument xmlDoc = new XmlDocument();
		private XmlElement filesElement = null;
		private string versionFileName = "";
		private bool isDummyFileRemoveSuccess = true;  //Down에 Move하지 못하고 남아 있는 파일 삭제처리여부, 실패시 IFC 재기동 필요함
		private string ftpRootPath = "";  //FTP 최초 접속후 Root Dir (절대 PATH ROOT)
		private string ftpPathDelim = "/";  //FTP Server가 UNIX이면 /, Window이면 \(?)로 구분됨, RootDir의 맨처음 값으로 SET(Window에서는 TEST 필요), 같다면 고정
		#endregion

		#region static Properties
		public static string BinPath
		{
			get { return binPath; }
		}

		public static string DownPath
		{
			get { return downPath; }
		}
		public static string ServerIP
		{
			get { return serverIP;}
		}
		public static string PgmSystemID
		{
			get { return pgmSystemID;}
		}
		public static bool ScreenCopyToTemp
		{
			get { return screenCopyToTemp;}
		}
		#endregion

		#region static 생성자
		/// <summary>
		/// Static 생성자 : Path Set
		/// </summary>
		static DownloadManager()
		{
			// bin Path
			binPath = Application.StartupPath;
			// Base Path
			basePath = Directory.GetParent(binPath).FullName;
			// Down Path
			downPath = basePath + "\\Down";
		}
		#endregion

		#region 생성자
		/// <summary>
		/// 생성자
		/// </summary>
		public DownloadManager(ScreenInfo screenInfo)
		{
			// DownPath 없으면 작성
			if (!Directory.Exists(DownloadManager.downPath))
			{
				Directory.CreateDirectory(DownloadManager.downPath);
			}
			//DownPath에 있는 File Delete
			foreach (string fileName in Directory.GetFiles(DownloadManager.downPath))
			{
				try
				{
					File.Delete(fileName);
				}
				catch(Exception xe)
				{
					//Down\bin에 있는 Dummy파일 삭제실패
					this.isDummyFileRemoveSuccess = false;
					Logs.WriteLog("DownloadLog", "Down\bin에 있는 파일삭제실패 파일명=" + fileName + ",에러=" + xe.Message);
				}
			}
			//DownPath에 있는 bin, Images Path외에 다른 Dir 삭제
			foreach (string dirName in Directory.GetDirectories(DownloadManager.downPath))
			{
				try
				{
					Directory.Delete(dirName, true);
				}
				catch {}
			}
			
			//Instance SET
			this.screenInfo = screenInfo;
			//CopyPath = 화면의 시스템ID
			this.copyPath = screenInfo.PgmSystemID;

			//Version.xml File Load
			LoadVersionFile();

			//Download ServerIP Get
			serverIP = EnvironInfo.GetDownloadServerIP();

			//ADM0400(어셈블리 정보 조회하여 다운받을 파일 List 생성 
			SetDownLibraryList();  

		}
		#endregion

		#region LoadVersionFile
		private void LoadVersionFile()
		{
			//IHIS/bin/Version.xml
			versionFileName = DownloadManager.basePath + "\\" + this.copyPath + "\\" + VERSION_FILE;

			//verion File Path가 없으면 먼저 Create
			string filePath = DownloadManager.basePath + "\\" + this.copyPath;
			if (!Directory.Exists(filePath))
				Directory.CreateDirectory(filePath);
			
			try
			{
				if (File.Exists(versionFileName))
				{
					TextReader textReader = new StreamReader(versionFileName, kscEncoding);
					XmlReader xmlReader = new XmlTextReader(textReader);
					xmlDoc.Load(xmlReader);
					filesElement = xmlDoc.DocumentElement;
					xmlReader.Close();
					textReader.Close();
				}
				else
				{
					//XmlFile생성
					xmlDoc.RemoveAll(); //모든 자식Node제거
					//files Element 생성
					filesElement = xmlDoc.CreateElement("files");
					xmlDoc.AppendChild(filesElement);
					TextWriter textWriter = new StreamWriter(versionFileName, false, kscEncoding);
					xmlDoc.Save(textWriter);
					textWriter.Close();
				}
			}
			catch
			{
				//사용자가 XmlFile을 조작하여 Load가 불가능할때 다시 XmlFile을 생성함
				//XmlFile생성
				xmlDoc.RemoveAll(); //모든 자식Node제거
				//files Element 생성
				filesElement = xmlDoc.CreateElement("files");
				xmlDoc.AppendChild(filesElement);
				TextWriter textWriter = new StreamWriter(versionFileName, false, kscEncoding);
				xmlDoc.Save(textWriter);
				textWriter.Close();
			}
		}
		private void SaveVersionFile()
		{
			try
			{
				TextWriter textWriter = new StreamWriter(versionFileName, false, kscEncoding);
				xmlDoc.Save(textWriter);
				textWriter.Close();
			}
			catch(Exception xe)
			{
				Debug.WriteLine("DownloadManager::SaveVersionFile Error=" + xe.Message);
			}
		}
		#endregion
		
		#region SetDownLibraryList
		/* 해당 화면의 화면정보를 조회하여 다운로드 받을 리스트를 생성
		 * excludeScreen은 화면이 아닌 BGL, BSL(Business System Library)만 Download할지 여부
		*/
		private void SetDownLibraryList()
		{
			string cmdText = "";
			string fileName, downPath, version, essVersion;
			DownFileType fileType = DownFileType.DLLFile;
			DownFileInfo fInfo;

			//해당 그룹, 시스템의 BGL.Group Lib, BSL.System Lib와 해당 화면과 해당화면 Report 받기
			cmdText
				//= "SELECT ASM_NAME, ASM_PATH, ASM_VER, ASM_ESS_VER FROM ADM0400"
				//+ " WHERE (   (ASM_TYPE = 'BGL' AND GRP_ID ='" + screenInfo.PgmGroupID + "')"
				//+ "        OR (ASM_TYPE = 'BSL' AND SYS_ID ='" + screenInfo.PgmSystemID + "')"
				//+ "        OR (ASM_TYPE = 'BSA' AND LOWER(ASM_NAME) LIKE LOWER('" + screenInfo.PgmSystemID + "." + screenInfo.PgmID + "')||'%'))";

                = "SELECT A.ASM_NAME, A.ASM_PATH, A.ASM_VER, A.ASM_ESS_VER "
                + "  FROM ADM0200 B, ADM0400 A "
                + " WHERE B.SYS_ID        = '" + screenInfo.PgmSystemID + "' "
                + "   AND (   (A.ASM_TYPE = 'BGL' AND A.GRP_ID = B.GRP_ID ) "
                + "        OR (A.ASM_TYPE = 'BSL' AND A.SYS_ID = '" + screenInfo.PgmSystemID + "')"
                + "        OR (A.ASM_TYPE = 'BSA' AND LOWER(A.ASM_NAME) LIKE LOWER('" + screenInfo.PgmSystemID + "." + screenInfo.PgmID + "')||'%')"
                + "       ) "
                ;
            
            DataTable table = Service.ExecuteDataTable(cmdText);
			if (table != null)  //조회 성공
			{
				foreach (DataRow dtRow in table.Rows)
				{
					fileName = dtRow[0].ToString();
					downPath = dtRow[1].ToString();
					version	 = dtRow[2].ToString();
					essVersion = dtRow[3].ToString();
					fileType = this.GetDownFileType(version);
					fInfo = new DownFileInfo(fileName, downPath, version, essVersion, fileType);
					this.serverFileList.Add(fInfo);
				}
			}
		}
		#endregion

		#region 파일 다운로드 여부 판단(ToBeDownLibrary)
		//dll 다운로드 여부
		private bool ToBeDownLibrary(DownFileInfo dInfo)
		{
			string fullName = "";
			bool isDown = false;
			bool isFound = false;

			if (dInfo.FileType == DownFileType.DLLFile)  //dll File은 파일의 Version 비교
			{
				// fullName = 처음기동시는 IFC/bin, 화면 기동시는 IFC/업무시스템ID
				//XML에 저장된 버전과 파일의 버전 비교
				try
				{
					fullName = DownloadManager.basePath + "\\" + this.copyPath + "\\" + dInfo.FileName;
					//파일이 존재하지 않으면 다운로드
					if (!File.Exists(fullName))
					{
						isDown = true;
						//Version List에 name과 Version SET
						foreach (XmlNode node in this.filesElement.ChildNodes)
						{
							if (node.Attributes["name"] != null)
							{
								if (node.Attributes["name"].Value == dInfo.FileName)
								{
									if (node.Attributes["version"] != null)
										node.Attributes["version"].Value = dInfo.FileVersion;
									else
										((XmlElement)node).SetAttribute("version", dInfo.FileVersion);
									isFound = true;
									break;
								}
							}
						}
						//Xml에 해당 File의 정보가 없으면 정보 설정
						if (!isFound)
						{
							//file Element 생성, Name과 Version Set
							XmlElement element = xmlDoc.CreateElement("file");
							element.SetAttribute("name", dInfo.FileName);
							element.SetAttribute("version", dInfo.FileVersion);
							filesElement.AppendChild(element);
						}
					}
					else  //이미 파일이 존재하면 xml Version과 dInfo의 버전 비교
					{
						//files List에서 해당 파일명을 가진 Node GET하여 Version 비교
						foreach (XmlNode node in this.filesElement.ChildNodes)
						{
							if (node.Attributes["name"] != null)
							{
								if (node.Attributes["name"].Value == dInfo.FileName)
								{
									//Version은 1.0.0.0 형태로 Version 비교
									Version attrVersion = null;
									Version fileVersion = null;
									try
									{
										attrVersion = new Version(node.Attributes["version"].Value);
										fileVersion = new Version(dInfo.FileVersion);
									}
									catch
									{
										attrVersion = new Version("1.0.0.0");
										fileVersion = new Version("2.0.0.0");
									}
									//버전 비교하여 DB Version이 더 크면 다운로드
									if (fileVersion.CompareTo(attrVersion) > 0)
									{
										isDown = true;
										//Version SET
										node.Attributes["version"].Value = fileVersion.ToString();
									}
									else
									{
										isDown = false;
									}
									isFound = true;
									break;
								}
							}
							else
							{
								isDown = true;
							}
						}
						//Xml에 해당 PBD File의 정보가 없으면 정보 설정
						if (!isFound)
						{
							//file Element 생성, Name과 Version Set
							XmlElement element = xmlDoc.CreateElement("file");
							element.SetAttribute("name", dInfo.FileName);
							element.SetAttribute("version", dInfo.FileVersion);
							filesElement.AppendChild(element);
							//파일에 File명이 없으면 Download
							isDown = true;
						}
					}
				}
				catch(Exception xe)
				{
					isDown = true;
					Debug.WriteLine("DownloadManager::ToBeFileDown FileName=" + dInfo.FileName + ",Error=" + xe.Message);
				}
				return isDown;

			}
			else if (dInfo.FileType == DownFileType.RPTFile)  //JRF File은 DB의 Version과 JRF VersionFile과 비교
			{
				try
				{
					fullName = DownloadManager.binPath + "\\" + dInfo.FileName;

                    String fullName2 = DownloadManager.basePath + "\\" + this.copyPath + "\\" + dInfo.FileName;

                    //if (!File.Exists(fullName))
                    if (!(File.Exists(fullName) || File.Exists(fullName2)))
                    {
						isDown = true;
						//PBDVersion List에 name과 Version SET
						foreach (XmlNode node in this.filesElement.ChildNodes)
						{
							if (node.Attributes["name"] != null)
							{
								if (node.Attributes["name"].Value == dInfo.FileName)
								{
									if (node.Attributes["version"] != null)
										node.Attributes["version"].Value = dInfo.FileVersion;
									else
										((XmlElement)node).SetAttribute("version", dInfo.FileVersion);
									isFound = true;
									break;
								}
							}
						}
						//Xml에 해당 PBD File의 정보가 없으면 정보 설정
						if (!isFound)
						{
							//file Element 생성, Name과 Version Set
							XmlElement element = xmlDoc.CreateElement("file");
							element.SetAttribute("name", dInfo.FileName);
							element.SetAttribute("version", dInfo.FileVersion);
							filesElement.AppendChild(element);
						}
					}
					else
					{
						//files List에서 해당 파일명을 가진 Node GET하여 Version 비교
						foreach (XmlNode node in this.filesElement.ChildNodes)
						{
							if (node.Attributes["name"] != null)
							{
								if (node.Attributes["name"].Value == dInfo.FileName)
								{
									//Version은 Number로 UpLoad시에 1증가
									int attrVersion = 0;
									int fileVersion = 0;
									try
									{
										attrVersion = Int32.Parse(node.Attributes["version"].Value);
										fileVersion = Int32.Parse(dInfo.FileVersion);
									}
									catch
									{
										attrVersion = -1;
										fileVersion = 0;
									}

									if (attrVersion < fileVersion)
									{
										isDown = true;
										//Version SET
										node.Attributes["version"].Value = fileVersion.ToString();
									}
									else
									{
										isDown = false;
									}
									isFound = true;
									break;
								}
							}
							else
							{
								isDown = true;
							}
						}
						//Xml에 해당 PBD File의 정보가 없으면 정보 설정
						if (!isFound)
						{
							//file Element 생성, Name과 Version Set
							XmlElement element = xmlDoc.CreateElement("file");
							element.SetAttribute("name", dInfo.FileName);
							element.SetAttribute("version", dInfo.FileVersion);
							filesElement.AppendChild(element);
							//파일에 File명이 없으면 Download
							isDown = true;
						}
					}
				}
				catch(Exception xe)
				{
					isDown = true;
					Debug.WriteLine("DownloadManager::ToBeFileDown Error=" + xe.Message);
					Logs.WriteLog("DownloadLog", "DownloadManager::ToBeFileDown FileName=" + dInfo.FileName + ",Error=" + xe.Message);
				}
				return isDown;
			}

			return false;
		}
		#endregion

		#region SetDownList
		/// <summary>
		/// Download 대상 File List 작성
		/// </summary>
		/// <returns></returns>
		private int SetDownList(out bool isAlreadyLoaded)
		{
			/* 다운로드 정책
			 * 이미 해당 BGL,BSL,화면이 업무시스템의 AppDomain에서 Load된 경우는 Download를 하더라도 Copy할 수 없다.
			 * 이 경우는 VersionResult를 AlreadyLoaded로 주어 다시 실행하도록 경고창을 띄운다.
			 * B 업무시스템이 기동되어 있어 A의 AppDomain에서는 Load되지 않았으나 Copy가 불가능
			 * Copy를 IFC/Temp/A시스템ID/B시스템ID Dir에 Copy하고 이 어셈블리를 Load한다.
			*/

			isAlreadyLoaded = false; //이미 이 AppDomain에서 Load되었으며 필수 Version보다 Loaded된 버전이 작은지 여부

			//comLibFileList에 저장된 Lib List 검색하여 downFileList에 Add
			foreach (DownFileInfo dInfo in this.serverFileList)
			{

				//Version.xml과 비교하여 Download해야 할지 여부 확인
				if (ToBeDownLibrary(dInfo))
				{
					//어셈블리의 Loaded 여부 확인
					if (dInfo.FileType == DownFileType.DLLFile)
					{
                        #region 2013.09.09 LKH
                        string asmName = dInfo.FileName.Replace(".dll",""); //어셈블리명으로 변경
                        String asmLocation = DownloadManager.basePath + "\\" + this.copyPath + "\\" + dInfo.FileName;
                        
                        //2006.04.06 이미 Loaded된 어셈블리에 대한 다운로드 정책
						//이미 Load된 어셈블리일때 필수 Version이 있고, 필수Version이 현재 File의 Version보다 크면 에러처리
						//없거나, 작으면 다운로드 하지 않음.
                        //2013.09.09 정책변경
                        //dll location 이 다르면 대상으로 처리
						Version asmVersion = null;
                        //if (ScreenLoader.IsLoadedAssembly(asmName, out asmVersion))  //이미 이 AppDomain에 Load 되어 있으면
                        if (ScreenLoader.IsLoadedAssembly(asmName, asmLocation, out asmVersion))  //이미 이 AppDomain에 Load 되어 있으면
                        {
							if (dInfo.EssentialVersion.Trim() != "")
							{
								Version essVersion = null;
								try
								{
									essVersion  = new Version(dInfo.EssentialVersion);
								}
								catch  //Version 정보가 이상하면 에러로 처리함.
								{
									isAlreadyLoaded = true;
									return 0;
								}
								//현재 Load된 Version이 필수 Version보다 작으면 에러처리, 크면 다운받지 않음)
								if (asmVersion.CompareTo(essVersion) < 0)
								{
									isAlreadyLoaded = true;
									return 0;
								}
							}
						}
						else //아니면 다운로드 List에 Add
						{
							downFileList.Add(dInfo);
							totalCount++;  //File수 증가
						}
                        #endregion 2013.09.09 LKH
                    }
					else
					{
						downFileList.Add(dInfo);
						totalCount++;  //File수 증가
					}
				}
			}

			return downFileList.Count;
		}
		#endregion

		#region DownloadByTCP, DownloadByFTP
		/// <summary>
		/// 대상 File List Download
		/// </summary>
		/// <returns> 성공시 true, 실패시 false </returns>
		private bool DownloadByTCP()
		{
            //2011.03.20 mins test
            //return true;

			string	serverDownpath = "";
			bool result = true;
			//현재 Dir을 DownPath로 설정
			Directory.SetCurrentDirectory(DownloadManager.downPath);

			// Progress Bar 초기화
			// Progress Bar 초기화
			if (downloadForm == null)
				downloadForm = new DownloadProgressForm();
			downloadForm.SetTotalCount(totalCount);
			downloadForm.Show();
			downloadForm.Refresh();

			try
			{
				foreach (DownFileInfo fInfo in downFileList)
				{
					//SeverDownPath가 다르면 Sever Dir change
					if (serverDownpath != fInfo.DownPath)
					{
						//Server Dir 변경실패시 DownError
						if (!transferClient.ChDir(fInfo.DownPath)) 
						{
							Logs.WriteLog("DownloadLog", "VersionManager::Download 서버 Dir 변경 에러, DownPath=" + fInfo.DownPath + ",FileName=" + fInfo.FileName);
							return false;
						}
					}

					//현재 Down중인 FileName Set
					downloadForm.SetFileName(fInfo.FileName);

					//아 파일의 Size를 가져옴
					long totalBytes = transferClient.GetFileSize(fInfo.FileName);
					
					//DownLoad
					transferClient.Download(fInfo.FileName, fInfo.FileName, totalBytes);
					
					//DownLoad Count 증가
					downloadForm.IncreaseDownCount();

					serverDownpath = fInfo.DownPath;
				}
			}
			catch(Exception xe)
			{
				Logs.WriteLog("DownloadLog", "DownloadManager::Download Error=" + xe.Message);
				result = false;
			}

			downloadForm.Close();
			return result;
		}

		private bool DownloadByFTP()
		{
            //2011.03.20 mins test
            //return true;

			string serverDownpath = "";
			bool result = true;
			//현재 Dir을 DownPath로 설정
			Directory.SetCurrentDirectory(DownloadManager.downPath);

			// Progress Form Show
			ProgressForm dlg = new ProgressForm();
			dlg.Init(downFileList.Count, "Assembly Downloading ...");
			dlg.Show();


			try
			{
				int count = 0;
				foreach (DownFileInfo fInfo in downFileList)
				{
					//SeverDownPath가 다르면 Sever Dir change
					if (serverDownpath != fInfo.DownPath)
					{
						//2006.08.07 DownPath는 상대경로이므로 절대경로로 이동처리함.
						//Server Dir 변경실패시 DownError
						if (!ftpWorker.ChangeDir(this.ftpRootPath + ftpPathDelim + fInfo.DownPath))
						{
							Logs.WriteLog("DownloadLog", "VersionManager::Download 서버 Dir 변경 에러, DownPath=" + fInfo.DownPath + ",FileName=" + fInfo.FileName);
							return false;
						}
					}

					//현재 Down중인 FileName, Count  Set
					count++;
					dlg.MoveProgress(count, "Receiving " + fInfo.FileName);

					//DownLoad(실패시 return false)
					if (!ftpWorker.SendFileToClient(fInfo.FileName))
						return false;

					serverDownpath = fInfo.DownPath;
				}
			}
			catch (Exception xe)
			{
				Logs.WriteLog("DownloadLog", "DownloadManager::Download Error=" + xe.Message);
				result = false;
			}
			finally
			{
				if (dlg != null)
					dlg.Close();
				ftpWorker.Close();
			}
            
			return result;
		}
		#endregion

		#region DownloadFiles(외부에는 DownloadFiles() call하고 내부에서 TCP로 할지 , FTP로 할지를 결정)
		public VersionResult DownloadFiles()
		{
			//외부에는 DownloadFiles() call하고 내부에서 TCP로 할지 , FTP로 할지를 결정
			//2006.08.07 TCP를 기본으로 다운로드후 다운로드 에러가 발생시 FTP로 다운로드 처리함.
			VersionResult result = DownloadFilesByTCP();
			if (result == VersionResult.DownError)
				return DownloadFilesByFTP();
			else
				return result;
		}
		#endregion

		#region DownloadFiles(ByTCP)
		/// <summary>
		/// DownLoad할 대상파일을 다운로드하여 실행 Dir에 Copy합니다.
		/// </summary>
		/// <returns></returns>
		private VersionResult DownloadFilesByTCP()
		{
            //2011.03.20 mins test
            //return VersionResult.Success;

			//static 변수 Reset
			DownloadManager.pgmSystemID = this.screenInfo.PgmSystemID;
			DownloadManager.screenCopyToTemp = false;
			bool isCopyToTempDir = false; //다른 시스템에서 사용중이어서 Temp Dir로 다운로드 했는지 여부

			// Download 대상 File List 작성
			bool isAlreadyLoaded = false; //이미 다운로드할 파일이 이 AppDomain에서 Load되었는지 여부
			if (SetDownList(out isAlreadyLoaded) == 0)
			{
				if (isAlreadyLoaded)  //이미 Load 되었으면
					return VersionResult.AlreadyLoaded;
				else
					return VersionResult.NotChanged; //변경사항 없음
			}

			//Download Form Set
			this.downloadForm = new DownloadProgressForm();

			// TCP Client 접속(Ini File에서 IP, HostType GET)
			transferClient = new SocketTransferClient(DownloadManager.serverIP, HostType.UNIX, this.downloadForm);
			if (!transferClient.Connect())
			{
				Logs.WriteLog("DownloadLog", "DownloadFilesByTCP 접속 실패");
				return VersionResult.DownError;
			}

			//Down에 있는 Dummy 파일 삭제 실패시에 Fail Return
			if (!this.isDummyFileRemoveSuccess)
			{
				transferClient.Close();
				return VersionResult.DeleteFail;
			}

			// 대상 File List Download (Fail시에 return
			if (!DownloadByTCP())
			{
				transferClient.Close();
				return VersionResult.DownError;
			}

			transferClient.Close();

			// Down File 실행 Directory로 Move
			// 단, Move 실패시, 프로그램 종료후 재실행한다.
			// 현재 Dir을 재설정
			Directory.SetCurrentDirectory(DownloadManager.binPath);
			string fileName = "";
			string destFileName = "";
			string destFilePath = "";
			VersionResult result = VersionResult.Success;

			string[] downFiles = Directory.GetFiles(DownloadManager.downPath);
			int downFilesCount = downFiles.Length;
			foreach (string fullName in downFiles)
			{
				try
				{
					fileName = fullName.Substring(fullName.LastIndexOf("\\") + 1);
					// 지정한 Dir에 Copy
					destFilePath = DownloadManager.basePath + "\\" + this.copyPath;

					//Copy할 Path에 Dir이 없으면 Dir 생성
					if (!Directory.Exists(destFilePath))
						Directory.CreateDirectory(destFilePath);

					//처음기동시는 IHIS/bin, 화면실행시는 IHIS/업무시스템ID
					destFileName = destFilePath + "\\" + fileName;
					if (File.Exists(destFileName))
						File.Delete(destFileName);
					File.Move(fullName, destFileName);
				}
				catch //어셈블리를 이미 사용중이어서 Move할 수 없을때
				{
					/* 이미 다른 업무시스템에서 이 어셈블리를 쓰고 있어서 Copy를 하지 못하는 경우는 Copy에러를 발생시키지 않고
					 * C:\Temp\현재시스템ID\화면시스템ID 밑에 Copy하여 여기서 화면을 Load하도록 처리함.
					 * 이미 그 Dir에 Copy실패한 파일이 있으면 CopyError로 처리함.
					 */
					destFilePath = DownloadManager.basePath + "\\Temp\\" + EnvironInfo.CurrSystemID + "\\" + this.screenInfo.PgmSystemID;
					//Copy할 Path에 Dir이 없으면 Dir 생성 (ex : C"\IHIS\Temp\OCSI\OCSA)
					if (!Directory.Exists(destFilePath))
						Directory.CreateDirectory(destFilePath);

					fileName = fullName.Substring(fullName.LastIndexOf("\\") + 1);
					destFileName = destFilePath + "\\" + fileName;
					if (File.Exists(destFileName)) //이미 Temp에 다운로드 받았으면 다시 받는 것은 허용안함(이미 Loaded되어 있으므로)
						result = VersionResult.CopyError;  //이미 사용중이어서 파일 Copy 에러 발생

					//Temp에 Copy되는 어셈블리가 화면 어셈블리이면 Flag Set
					if (screenInfo.AsmName.ToUpper().Equals(fileName.ToUpper()))
						DownloadManager.screenCopyToTemp = true;

					//Temp Dir로 File을 Copy함
					isCopyToTempDir = true;

					//Move 실패시는 Copy Error
					try
					{
						File.Move(fullName, destFileName);
					}
					catch
					{
						result = VersionResult.CopyError;
					}
				}
			}

			//Move 실패한 Dummy 파일 Remove
			downFiles = Directory.GetFiles(DownloadManager.downPath);
			foreach (string fullName in downFiles)
			{
				try
				{
					File.Delete(fullName);
				}
				catch(Exception xe)
				{
					Logs.WriteLog("DownloadLog", "파일 Move 에러 파일 삭제에러 fileName=" + fullName + ",에러=" + xe.Message);
				}
			}

			//다운로드 받은 파일이 없으면(어셈블리정보를 잘못 등록하여 DB에는 있으나, 실제 File이 없는 경우) Version파일 저장하지 않음
			//파일 DownLoad 성공시에 Version파일 저장
			if ((downFilesCount > 0) && (result == VersionResult.Success))
			{
				//이미 다른 시스템에서 사용중이어서 Copy에러가 나서 Temp Dir로 파일을 복사한 경우는 Version Update하지 않음
				if (!isCopyToTempDir)
					SaveVersionFile();
			}

			return result;
		}
		#endregion

		#region DownloadFiles(ByFTP)
		/// <summary>
		/// DownLoad할 대상파일을 다운로드하여 실행 Dir에 Copy합니다.
		/// </summary>
		/// <returns></returns>
		private VersionResult DownloadFilesByFTP()
		{
            //2011.03.20 mins test
            //return VersionResult.Success;

			//static 변수 Reset
			DownloadManager.pgmSystemID = this.screenInfo.PgmSystemID;
			DownloadManager.screenCopyToTemp = false;
			bool isCopyToTempDir = false; //다른 시스템에서 사용중이어서 Temp Dir로 다운로드 했는지 여부

			// Download 대상 File List 작성
			bool isAlreadyLoaded = false; //이미 다운로드할 파일이 이 AppDomain에서 Load되었는지 여부
			if (SetDownList(out isAlreadyLoaded) == 0)
			{
				if (isAlreadyLoaded)  //이미 Load 되었으면
					return VersionResult.AlreadyLoaded;
				else
					return VersionResult.NotChanged; //변경사항 없음
			}

			// FTP Client 접속(Ini File에서 IP, HostType GET)
			ftpWorker = new XFTPWorker(FTP_USERID, FTP_PSWD, DownloadManager.serverIP);
			ftpWorker.ShowProgressForm = false; //한 파일씩 Load하는 Form은 보여주지 않음
			if (!ftpWorker.Connected) return VersionResult.DownError;

			//Root Dir SET, PATH 구분자 SET
			this.ftpRootPath = ftpWorker.GetCurrentDir();
			this.ftpPathDelim = ftpRootPath.Substring(0,1);

			//Down에 있는 Dummy 파일 삭제 실패시에 Fail Return
			if (!this.isDummyFileRemoveSuccess)
			{
				ftpWorker.Close();
				return VersionResult.DeleteFail;
			}

			// 대상 File List Download (Fail시에 return
			if (!DownloadByFTP())
			{
				ftpWorker.Close();
				return VersionResult.DownError;
			}

			ftpWorker.Close();

			// Down File 실행 Directory로 Move
			// 단, Move 실패시, 프로그램 종료후 재실행한다.
			// 현재 Dir을 재설정
			Directory.SetCurrentDirectory(DownloadManager.binPath);
			string fileName = "";
			string destFileName = "";
			string destFilePath = "";
			VersionResult result = VersionResult.Success;

			string[] downFiles = Directory.GetFiles(DownloadManager.downPath);
			int downFilesCount = downFiles.Length;
			foreach (string fullName in downFiles)
			{
				try
				{
					fileName = fullName.Substring(fullName.LastIndexOf("\\") + 1);
					// 지정한 Dir에 Copy
					destFilePath = DownloadManager.basePath + "\\" + this.copyPath;

					//Copy할 Path에 Dir이 없으면 Dir 생성
					if (!Directory.Exists(destFilePath))
						Directory.CreateDirectory(destFilePath);

					//처음기동시는 IHIS/bin, 화면실행시는 IHIS/업무시스템ID
					destFileName = destFilePath + "\\" + fileName;
					if (File.Exists(destFileName))
						File.Delete(destFileName);
					File.Move(fullName, destFileName);
				}
				catch //어셈블리를 이미 사용중이어서 Move할 수 없을때
				{
					/* 이미 다른 업무시스템에서 이 어셈블리를 쓰고 있어서 Copy를 하지 못하는 경우는 Copy에러를 발생시키지 않고
					 * C:\Temp\현재시스템ID\화면시스템ID 밑에 Copy하여 여기서 화면을 Load하도록 처리함.
					 * 이미 그 Dir에 Copy실패한 파일이 있으면 CopyError로 처리함.
					 */
					destFilePath = DownloadManager.basePath + "\\Temp\\" + EnvironInfo.CurrSystemID + "\\" + this.screenInfo.PgmSystemID;
					//Copy할 Path에 Dir이 없으면 Dir 생성 (ex : C"\IFC\Temp\OCSI\OCSA)
					if (!Directory.Exists(destFilePath))
						Directory.CreateDirectory(destFilePath);
					
					fileName = fullName.Substring(fullName.LastIndexOf("\\") + 1);
					destFileName = destFilePath + "\\" + fileName;
					if (File.Exists(destFileName)) //이미 Temp에 다운로드 받았으면 다시 받는 것은 허용안함(이미 Loaded되어 있으므로)
						result = VersionResult.CopyError;  //이미 사용중이어서 파일 Copy 에러 발생
					
					//Temp에 Copy되는 어셈블리가 화면 어셈블리이면 Flag Set
					if (screenInfo.AsmName.ToUpper().Equals(fileName.ToUpper()))
						DownloadManager.screenCopyToTemp = true;

					//Temp Dir로 File을 Copy함
					isCopyToTempDir = true;

					//Move 실패시는 Copy Error
					try
					{
						File.Move(fullName, destFileName);
					}
					catch
					{
						result = VersionResult.CopyError;
					}
				}
			}

			//Move 실패한 Dummy 파일 Remove
			downFiles = Directory.GetFiles(DownloadManager.downPath);
			foreach (string fullName in downFiles)
			{
				try
				{
					File.Delete(fullName);
				}
				catch(Exception xe)
				{
					Logs.WriteLog("DownloadLog", "파일 Move 에러 파일 삭제에러 fileName=" + fullName + ",에러=" + xe.Message);
				}
			}

			
			//다운로드 받은 파일이 없으면(어셈블리정보를 잘못 등록하여 DB에는 있으나, 실제 File이 없는 경우) Version파일 저장하지 않음
			//파일 DownLoad 성공시에 Version파일 저장
			if ((downFilesCount > 0) && (result == VersionResult.Success))
			{
				//2006.04.06 이미 다른 시스템에서 사용중이어서 Copy에러가 나서 Temp Dir로 파일을 복사한 경우는 Version Update하지 않음
				if (!isCopyToTempDir)
					SaveVersionFile();
			}

			return result;
		}
		#endregion

		private DownFileType GetDownFileType(string version)
		{
			DownFileType fileType = DownFileType.DLLFile;
			//version이 1.0.0.0 형태로 관리되는 파일은 dll File, 그렇지 않은 파일을 jrf file(파일버전이 없어서 xml로 관리)
			//파일버전이 없는 파일은 숫자형태로 관리됨
			if (version.IndexOf(".") < 0)
				fileType = DownFileType.RPTFile;

			return fileType;
		}
	}
}
