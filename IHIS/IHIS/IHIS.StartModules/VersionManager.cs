using System;
using System.Xml;
using System.Text;
using System.Collections;
using System.IO;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
//
using IHIS.Framework;

namespace IHIS
{
	public enum VersionResult //Version Check 결과
	{
		CopyError,   //다운로드후에 파일 Copy시에 에러(시스템 재시작 필요)
		NotChanged,  //변경사항 없음
		DownError,  //다운로드시 에러 발생
		Success,    //다운로드및 Version Check 성공
		DeleteFail  //Down dir에 있는 Dummy파일 삭제 실패(IHIS 다시 기동필요함)
	}

	public enum DownFileType
	{
		/// <summary>
		/// dll File
		/// </summary>
		DLLFile,
		/// <summary>
		/// Report File 
		/// </summary>
		RPTFile,
		/// <summary>
		/// Image
		/// </summary>
		ImageFile,
		/// <summary>
		/// IHIS 환경파일(IHIS.config)
		/// </summary>
		ConfigFile,
		/// <summary>
		/// BarCode Font File
		/// </summary>
		BarCodeFile

	}
	public struct DownFileInfo
	{
		public string FileName;
		public string DownPath;
		public string FileVersion;
		public DownFileType FileType ;
		public DownFileInfo(string fileName, string downPath, string fileVersion, DownFileType fileType)
		{
			FileName = fileName;
			DownPath = downPath;
			FileVersion = fileVersion;
			FileType = fileType;
		}
	}

	/// <summary>
	/// VersionManager에 대한 요약 설명입니다.
	/// </summary>
	public class VersionManager
	{
		#region static Fields
		const string COMM_STR = "STA"; //IHIS 시작 다운로드 groupID, systemID
		const string BIN_DIR = "BIN";
		const string IMAGE_DIR = "Images";
		const string COMMON_EXE_FILE_NAME = "IHIS.Common.exe";
		const string CONFIG_FILE_NAME = "IHIS.config";
		const string FTP_USERID = "ihisdown";
		const string FTP_PSWD = "ihisdown";
		private static Encoding kscEncoding = Service.BaseEncoding;
		private static string	basePath;
		private static string	binPath;
		private static string   imagePath;
		private static string	downPath;
		private static string	downImagePath;
		private static string	serverIP = "222.106.127.76";
		private static bool		configFileDownloaded = false;  //IHIS환경파일 Download 여부
		const string	VERSION_FILE_NAME = "Version.xml";
		//BarCode File 관련(2006.06.15 Font Download 추가)
		const string	BARCODE_FONT_FILE = "3OF9_NEW.TTF"; //BarCode 출력 FONT File명
		const string	FONT_DIR = "Font";  //BarCode Font가 있는 서버의 Dir 명
		private static string downFontPath = "";   //Font를 Download 받을 dir
		private static bool fontDownloaded = false; //BarCode Font Down load 여부
		public static string BasePath
		{
			get { return basePath;}
		}
		public static string BinPath
		{
			get { return binPath;}
		}
		public static string ImagePath
		{
			get { return imagePath; }
		}
		public static string DownPath
		{
			get { return downPath;}
		}
		public static string DownImagePath
		{
			get { return downPath;}
		}
		public static bool ConfigFileDownloaded
		{
			get { return configFileDownloaded;}
		}
		//2006.06.15 BarCode 관련 속성
		public static string BarCodeFontFile
		{
			get { return BARCODE_FONT_FILE;}
		}
		public static bool FontDownloaded
		{
			get { return fontDownloaded;}
		}
		#endregion

		#region Fields
		private SocketTransferClient transferClient = null;  //By TCP
		private FrameworkDownForm downloadForm = null;
		private XFTPWorker ftpWorker = null;  //By FTP
		private ArrayList	downFileList = new ArrayList();
		private ArrayList   serverFileList = new ArrayList();
		private int		totalCount = 0;
		private bool isFirstOpen = false;  //최초 IHIS 진입여부
		private string groupID = "";
		private string systemID = "";
		private string libCopyPath = "";
		private string versionFileName = "";
		private XmlDocument xmlDoc = new XmlDocument();
		private XmlElement filesElement = null;
		private bool isDummyFileRemoveSuccess = true;  //Down에 Move하지 못하고 남아 있는 파일 삭제처리여부, 실패시 IHIS 재기동 필요함
		private string ftpRootPath = "";  //FTP 최초 접속후 Root Dir (절대 PATH ROOT)
		private string ftpPathDelim = "/";  //FTP Server가 UNIX이면 /, Window이면 \(?)로 구분됨, RootDir의 맨처음 값으로 SET(Window에서는 TEST 필요), 같다면 고정
		#endregion
		
		#region static 생성자
		/// <summary>
		/// Static 생성자 : Path Set
		/// </summary>
		static VersionManager()
		{
			// bin Path
			binPath = Application.StartupPath;
			// Base Path
			basePath = Directory.GetParent(binPath).FullName;
			//Image Path
			imagePath = basePath + "\\" + "Images";
			// Down Path
			downPath = basePath + "\\Down";
			// DownImage Path
			downImagePath = basePath + "\\DownImage";
			//DownFont Path
			downFontPath = basePath + "\\DownFont";
		}
		#endregion

		#region 생성자
		public VersionManager(string groupID, string systemID, string copyPath)
		{
			//Image Path 설정
			if (!Directory.Exists(VersionManager.imagePath))
			{
				Directory.CreateDirectory(VersionManager.imagePath);
			}
			// Path 없으면 작성, 있으면 Clear
			if (!Directory.Exists(VersionManager.downPath))
			{
				Directory.CreateDirectory(VersionManager.downPath);
			}
			//DownImagePath가 없으면 작성
			if (!Directory.Exists(VersionManager.downImagePath))
			{
				Directory.CreateDirectory(VersionManager.downImagePath);
			}
			//2006.06.16 DownFont Path 생성
			if (!Directory.Exists(VersionManager.downFontPath))
			{
				Directory.CreateDirectory(VersionManager.downFontPath);
			}
		
			foreach (string FileName in Directory.GetFiles(VersionManager.downPath))
			{
				try
				{
					File.Delete(FileName);
				}
				catch(Exception xe)
				{
					//Down\bin에 있는 Dummy파일 삭제실패
					this.isDummyFileRemoveSuccess = false;
					Logs.WriteLog("DownloadLog", "Down\bin에 있는 파일삭제실패 파일명=" + FileName + ",에러=" + xe.Message);
				}
			}
			//downImagePath에 있는 File Delete
			foreach (string fileName in Directory.GetFiles(VersionManager.downImagePath))
			{
				try
				{
					File.Delete(fileName);
				}
				catch{}
			}

			foreach (string DirName in Directory.GetDirectories(VersionManager.downPath))
			{
				try
				{
					Directory.Delete(DirName, true);
				}
				catch {}
			}

			// COMM,COMM (최초 IHIS진입시는 Image도 DownLoad 필요함)
			if ((groupID == COMM_STR) && (systemID == COMM_STR))
				this.isFirstOpen = true;
		
			//Instance SET
			this.groupID = groupID;
			this.systemID = systemID;
			this.libCopyPath = copyPath;

			//Version.xml File Load
			LoadVersionFile();

			//Download ServerIP Get
			GetServerIP();

			//Framework File 다운로드 List 생성
			SetDownLibraryList();
		}
		#endregion

		#region SetDownLibraryList (어셈블리 정보 조회), GetServerIP

		//미확정 Tuxedo에서 정보조회(어셈블리 Table)하여 다운로드할 리스트 생성
		//onlyBSL은 화면이 아닌 BSL(Business System Library)만 Download할지 여부
		private void SetDownLibraryList()
		{	
			/* 다운로드 받을 Library 리스트 조회
			   최초실행시는 FWL, Framework Lib, 업무시스템 실행시는 해당 업무시스템의 BGL.Group Lib, BSL.System Lib, BSA.업무화면 전부
			   Main.exe는 BSM.Main Exe가 있으면 해당 exe로 없으면 IHIS.Common.exe를 Rename하여 사용함.
			*/
			string cmdText = "";
			bool isExistBSM = false;
			string msg = "";
			if (this.isFirstOpen)  //최초 실행
			{
				//FWL에서 IHIS.Common.exe는 제외
				cmdText 
					= "SELECT ASM_NAME, ASM_PATH, ASM_VER FROM ADM0400 " 
					+ " WHERE ASM_TYPE = 'FWL' "
					+ "   AND ASM_NAME <> '" + VersionManager.COMMON_EXE_FILE_NAME + "'"
					+ " ORDER BY ASM_NAME";
			}
			else //해당 업무시스템 실행
			{
				//해당 업무시스템의 BSM. Main exe 존재여부 확인, 없으면 IHIS.Common.exe를 변환함
				cmdText = "SELECT COUNT(1) FROM ADM0400 WHERE ASM_TYPE = 'BSM' AND SYS_ID ='" + this.systemID + "'";
				object retVal = Service.ExecuteScalar(cmdText);
				if (retVal == null)
				{
					msg = XMsg.GetMsg("M004") + "\n[" + Service.ErrMsg + "]"; // 버젼정보 조회 에러\n" + "[" + Service.ErrMsg + "]"
					//XMessageBox.Show(msg, "IHIS");
                    XMessageBox.Show(msg, "KCCK");
					return;
				}
				//BSM 존재여부 SET
				isExistBSM = (Int32.Parse(retVal.ToString()) > 0 ? true : false);

				cmdText 
					= "SELECT ASM_NAME, ASM_PATH, ASM_VER FROM ADM0400"
					+ " WHERE ASM_TYPE IN ('BGL','BSM', 'BSL','BSA') "
					+ "   AND (   (ASM_TYPE = 'BGL' AND GRP_ID = '" + this.groupID + "') "
					+ "        OR (ASM_TYPE IN ('BSM','BSL','BSA') AND SYS_ID = '" + this.systemID + "'))";
			}
			DataTable table = Service.ExecuteDataTable(cmdText);
			if (table == null) //에러 : 어셈블리정보가 하나도 없음.
			{
				//msg = XMsg.GetMsg("M004") + "\n[" + Service.ErrMsg + "]"; // 버젼정보 조회 에러\n" + "[" + Service.ErrMsg + "]"
				//XMessageBox.Show(msg, "IHIS");
				return;
			}

			DownFileType fType = DownFileType.DLLFile;
			DownFileInfo fInfo;
			string fileName, version, downPath;
			foreach (DataRow dtRow in table.Rows)
			{
				fileName = dtRow[0].ToString();
				downPath = dtRow[1].ToString();
				version  = dtRow[2].ToString();
				fType = this.GetDownFileType(version);
				fInfo = new DownFileInfo(fileName, downPath, version, fType);
				this.serverFileList.Add(fInfo);
			}

			//업무시스템 실행일때 BSM이 존재하지 않으면 IHIS.Common.exe 정보 조회
			if (!this.isFirstOpen && !isExistBSM)
			{
				cmdText = "SELECT ASM_NAME, ASM_PATH, ASM_VER FROM ADM0400 WHERE ASM_NAME ='" + COMMON_EXE_FILE_NAME + "'";
				table = Service.ExecuteDataTable(cmdText);
				if ((table == null) || (table.Rows.Count < 1))
				{
					msg = XMsg.GetMsg("M004") + "\n[" + Service.ErrMsg + "]"; // 버젼정보 조회 에러\n" + "[" + Service.ErrMsg + "]"
					//XMessageBox.Show(msg, "IHIS");
                    XMessageBox.Show(msg, "KCCK");
					return;
				}
				fileName = table.Rows[0][0].ToString();
				downPath = table.Rows[0][1].ToString();
				version  = table.Rows[0][2].ToString();
				fType = this.GetDownFileType(version);
				fInfo = new DownFileInfo(fileName, downPath, version, fType);
				this.serverFileList.Add(fInfo);
			}

		}
		private void GetServerIP()
		{
			VersionManager.serverIP = Service.GetConfigString("SERVER", "IP", "222.106.127.66");
		}
		#endregion

		#region SetDownListByTCP (TCP로 다운로드 정보조회)
		private int SetDownListByTCP()
		{
			// 최초 진입시 Image Down 필요시
			if (this.isFirstOpen)
			{
				string fileName = "";
				long fileSize = 0;
				DateTime fileDate = DateTime.MinValue;
				DownFileInfo fInfo ;

				//최초진입시에 config File 변경여부 확인
				//bin Dir로 Change
				//2006.08.07 TCP가 Connect는 되었으나, ChDir 등 내부 함수에서 오류가 발생하면 -1로 Return하여 Download Error로 처리함.
				if (!transferClient.ChDir(VersionManager.BIN_DIR))
					return -1;

				string[] fInfos = transferClient.GetFileList(VersionManager.CONFIG_FILE_NAME, true);
				foreach (string fileInfo in fInfos)
				{
					if (transferClient.ParseFileInfo(fileInfo, ref fileName, ref fileSize, ref fileDate))
					{
						if (fileName == VersionManager.CONFIG_FILE_NAME)
						{
							if (ToBeDownFile(fileName, (int)fileSize, fileDate))
							{
								fInfo = new DownFileInfo(fileName, VersionManager.BIN_DIR ,"", DownFileType.ConfigFile);
								downFileList.Add(fInfo);
								totalCount++;  //File수 증가
								//환경파일 Download여부 SET
								VersionManager.configFileDownloaded = true;
							}
						}
					}
				}


				//Server Change Dir (Images)
				//2006.08.07 TCP가 Connect는 되었으나, ChDir 등 내부 함수에서 오류가 발생하면 -1로 Return하여 Download Error로 처리함.
				if (!transferClient.ChDir(VersionManager.IMAGE_DIR))
					return -1;

				string[] fileInfos = transferClient.GetFileList("*", true);
				foreach (string fileInfo in fileInfos)
				{
					if (transferClient.ParseFileInfo(fileInfo, ref fileName, ref fileSize, ref fileDate))
					{
						// Client File과 Size 및 Date 비교
						if (ToBeDownFile(fileName, (int)fileSize, fileDate))
						{
							fInfo = new DownFileInfo(fileName, IMAGE_DIR,"", DownFileType.ImageFile);
							downFileList.Add(fInfo);
							totalCount++;  //File수 증가
						}
					}
				}

				//BarCode 출력 FONT(Windows\Fonts\BARCODE_FONT_FILE이 없으면 Load
				fileName = Directory.GetParent(Environment.SystemDirectory).FullName + "\\Fonts\\" + BARCODE_FONT_FILE;
				if (!File.Exists(fileName))
				{
					fInfo = new DownFileInfo(BARCODE_FONT_FILE, VersionManager.FONT_DIR, "", DownFileType.BarCodeFile);
					downFileList.Add(fInfo);
					totalCount++;  //File수 증가
				}
			}

			//serverFileList에 저장된 Lib List 검색하여 downFileList에 Add
			foreach (DownFileInfo dInfo in this.serverFileList)
			{
				if (ToBeDownLibrary(dInfo))
				{
					downFileList.Add(dInfo);
					totalCount++;  //File수 증가
				}
			}

			return downFileList.Count;
		}
		#endregion

		#region SetDownListByFTP (FTP로 ConfigFile, Image 정보 조회)
		private int SetDownListByFTP()
		{
			// 최초 진입시 Image Down 필요시
			if (this.isFirstOpen)
			{
				DownFileInfo fInfo ;
				ArrayList fileList = null;

				//2006.04.06 tmax.env File Down load 추가
				//최초진입시에 tux.env File 변경여부 확인
				//bin Dir로 Change
				//2006.08.07 FTP가 Connect는 되었으나, ChangeDir 등 내부 함수에서 오류가 발생하면 -1로 Return하여 Download Error로 처리함.
				if (!ftpWorker.ChangeDir(this.ftpRootPath + this.ftpPathDelim + VersionManager.BIN_DIR))
					return -1;

				fileList = ftpWorker.GetDirList(false);

				//List에는 DirItems가 온다.
				foreach (XFTPWorker.DirItems item in fileList)
				{
					//Env File만 크기비교, 다운로드 처리
					if (item.Filename == VersionManager.CONFIG_FILE_NAME)
					{
						if (ToBeDownFile(item.Filename, Int32.Parse(item.Size)))
						{
							fInfo = new DownFileInfo(item.Filename, VersionManager.BIN_DIR ,"", DownFileType.ConfigFile);
							downFileList.Add(fInfo);
							totalCount++;  //File수 증가
							//환경파일 Download여부 SET
							VersionManager.configFileDownloaded = true;
						}
					}
				}

				//Server Change Dir (Images)
				//2006.08.07 FTP가 Connect는 되었으나, ChangeDir 등 내부 함수에서 오류가 발생하면 -1로 Return하여 Download Error로 처리함.
				if (!ftpWorker.ChangeDir(this.ftpRootPath + ftpPathDelim + VersionManager.IMAGE_DIR))
					return -1;

				fileList = ftpWorker.GetDirList(false);

				//List에는 DirItems가 온다. ImageFile의 Size 비교
				foreach (XFTPWorker.DirItems item in fileList)
				{
					if (ToBeDownFile(item.Filename, Int32.Parse(item.Size)))
					{
						fInfo = new DownFileInfo(item.Filename, VersionManager.IMAGE_DIR ,"", DownFileType.ImageFile);
						downFileList.Add(fInfo);
						totalCount++;  //File수 증가
					}
				}

				//BarCode 출력 FONT(Windows\Fonts\BARCODE_FONT_FILE이 없으면 Load
				string fileName = Directory.GetParent(Environment.SystemDirectory).FullName + "\\Fonts\\" + BARCODE_FONT_FILE;
				if (!File.Exists(fileName))
				{
					fInfo = new DownFileInfo(BARCODE_FONT_FILE, VersionManager.FONT_DIR, "", DownFileType.BarCodeFile);
					downFileList.Add(fInfo);
					totalCount++;  //File수 증가
				}
			}

			//serverFileList에 저장된 Lib List 검색하여 downFileList에 Add
			foreach (DownFileInfo dInfo in this.serverFileList)
			{
				if (ToBeDownLibrary(dInfo))
				{
					downFileList.Add(dInfo);
					totalCount++;  //File수 증가
				}
			}

			return downFileList.Count;
		}
		#endregion

		#region ToBeDownFile, ToBeDownLibrary
		private bool ToBeDownFile(string fileName, int fileSize, DateTime fileDate)
		{
			//TCP로 조회한 Size, 날짜비교
			string fullName = "";
			if (fileName == VersionManager.CONFIG_FILE_NAME)
				fullName = VersionManager.binPath + "\\" + fileName;
			else
				fullName = VersionManager.imagePath + "\\" + fileName;
			
			if (!File.Exists(fullName))
				return true;
			
			FileInfo info = new FileInfo(fullName);
			if (info.Length != (long)fileSize)
				return true;
			if (info.LastWriteTime < fileDate)
				return true;
			return false;
		}
		private bool ToBeDownFile(string fileName, int fileSize)
		{
			//FTP로 조회한 파일 Size 비교 (FTP는 날짜를 정확히 가져올 수 없어 Size만 비교)
			string fullName = "";
			if (fileName == VersionManager.CONFIG_FILE_NAME)
				fullName = VersionManager.binPath + "\\" + fileName;
			else
				fullName = VersionManager.imagePath + "\\" + fileName;
			
			if (!File.Exists(fullName))
				return true;
			
			FileInfo info = new FileInfo(fullName);
			if (info.Length != (long)fileSize)
				return true;
			return false;
		}
		
		//Version.xml과 비교하여 Version관리하기
		private bool ToBeDownLibrary(DownFileInfo dInfo)
		{
			string fullName = "";
			bool isDown = false;
			bool isFound = false;

			if (dInfo.FileType == DownFileType.DLLFile)  //dll File은 파일의 Version 비교
			{
				// fullName = IHIS\bin\aaa.dll  
				//XML에 저장된 버전과 파일의 버전 비교
				try
				{
					fullName = VersionManager.basePath + "\\" + this.libCopyPath + "\\" + dInfo.FileName;

					//IHIS.Common.exe는 시스템ID.exe와 비교
					if (!this.isFirstOpen && (dInfo.FileName == VersionManager.COMMON_EXE_FILE_NAME))
					{
						fullName = VersionManager.basePath + "\\" + this.libCopyPath + "\\" + this.systemID + ".exe";
					}

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
					Debug.WriteLine("VersionManager::ToBeDownLibrary FileName=" + dInfo.FileName + ",Error=" + xe.Message);
				}
				return isDown;

			}
			else if (dInfo.FileType == DownFileType.RPTFile)  //JRF File은 DB의 Version과 JRF VersionFile과 비교
			{
				try
				{
					fullName = VersionManager.basePath + "\\" + this.libCopyPath + "\\" + dInfo.FileName;

					if (!File.Exists(fullName))
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
					Debug.WriteLine("VersionManager::ToBeDownLibrary Error=" + xe.Message);
					Logs.WriteLog("DownloadLog", "VersionManager::ToBeDownLibrary FileName=" + dInfo.FileName + ",Error=" + xe.Message);
				}
				return isDown;
			}

			return false;
		}
		#endregion

		#region DownloadByTCP
		private bool DownloadByTCP()
		{
			bool result = true;
			//현재 Dir을 DownPath로 설정
			Directory.SetCurrentDirectory(VersionManager.downPath);

			// Progress Bar 초기화
			if (downloadForm == null)
				downloadForm = new FrameworkDownForm();
			downloadForm.SetTotalCount(totalCount);
			downloadForm.Show();
			downloadForm.Refresh();

			string	serverDownpath = "";
			string downDir = "";
			DownloadResult downResult = DownloadResult.Success;
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
					
					//2006.06.15 DownFont Dir로 변경추가 (Image -> DownImage, Font -> DownFont, dll -> Down)
					if (fInfo.FileType == DownFileType.ImageFile)
						downDir = VersionManager.downImagePath;
					else if (fInfo.FileType == DownFileType.BarCodeFile)
						downDir = VersionManager.downFontPath;
					else
						downDir = VersionManager.downPath;

					//현재 Dir이 다를 경우 Dir 변경
					if (Directory.GetCurrentDirectory() != downDir)
					{
						Directory.SetCurrentDirectory(downDir);
					}

					//현재 Down중인 FileName Set
					downloadForm.SetFileName(fInfo.FileName);
					
					//아 파일의 Size를 가져옴
					long totalBytes = transferClient.GetFileSize(fInfo.FileName);
					//DownLoad
					downResult = transferClient.Download(fInfo.FileName, fInfo.FileName, totalBytes);
					//한개의 파일이라도 Download 실패하면 실패로 간주하여 return
					if (downResult == DownloadResult.DownloadError)
					{
						downloadForm.Close();
						return false;
					}
					
					//Server DownPath Set
					serverDownpath = fInfo.DownPath;

					//DownLoad Count 증가
					downloadForm.IncreaseDownCount();
				}
			}
			catch(Exception xe)
			{
				Logs.WriteLog("DownloadLog", "VersionManager::Download Error=" + xe.Message);
				//Tmax환경파일 Download Flag Reset
				VersionManager.configFileDownloaded = false;
				result = false;
			}

			downloadForm.Close();
			downloadForm = null;
			return result;
		}
		#endregion

		#region DownloadByFTP
		private bool DownloadByFTP()
		{
			//현재 Dir을 DownPath로 설정
			Directory.SetCurrentDirectory(VersionManager.downPath);

			// Progress Form Show
			ProgressForm dlg = new ProgressForm();
			dlg.Init(downFileList.Count.ToString(), "Assembly Downloading ...");
			dlg.Show();

			string	serverDownpath = "";
			string downDir = "";
			try
			{
				int count = 0;

				foreach (DownFileInfo fInfo in downFileList)
				{
					//SeverDownPath가 다르면 Sever Dir change
					if (serverDownpath != fInfo.DownPath)
					{
						//Server Dir 변경실패시 DownError
						//2006.08.07 DownPath는 상대경로이므로 절대경로로 이동처리함.
						if (!ftpWorker.ChangeDir(this.ftpRootPath + this.ftpPathDelim + fInfo.DownPath)) 
						{
							Logs.WriteLog("DownloadLog", "VersionManager::DownloadByFTP 서버 Dir 변경 에러, DownPath=" + fInfo.DownPath + ",FileName=" + fInfo.FileName);
							return false;
						}
					}
					
					//2006.06.15 DownFont Dir로 변경추가 (Image -> DownImage, Font -> DownFont, dll -> Down)
					if (fInfo.FileType == DownFileType.ImageFile)
						downDir = VersionManager.downImagePath;
					else if (fInfo.FileType == DownFileType.BarCodeFile)
						downDir = VersionManager.downFontPath;
					else
						downDir = VersionManager.downPath;

					//현재 Dir이 다를 경우 Dir 변경
					if (Directory.GetCurrentDirectory() != downDir)
					{
						Directory.SetCurrentDirectory(downDir);
					}

					//현재 Down중인 FileName, Count  Set
					count++;
					dlg.MoveProgress(count, "Receiving " + fInfo.FileName);

					//DownLoad(실패시 return false)
					if (!ftpWorker.SendFileToClient(fInfo.FileName))
						return false;
					
					//Server DownPath Set
					serverDownpath = fInfo.DownPath;

				}
			}
			catch(Exception xe)
			{
				Logs.WriteLog("DownloadLog", "VersionManager::Download Error=" + xe.Message);
				//Tmax환경파일 Download Flag Reset
				VersionManager.configFileDownloaded = false;
				return false;
			}
			finally
			{
				if (dlg != null)
					dlg.Close();
				ftpWorker.Close();
			}
			return true;

		}
		#endregion
		

		#region DownloadFiles
		public VersionResult DownloadFiles()
		{
			//외부에는 DownloadFiles() call하고 내부에서 TCP, FTP로 분기
			//2006.08.07 TCP를 기본으로 다운로드후 다운로드 에러가 발생시 FTP로 다운로드 처리함.
			VersionResult result = DownloadFilesByTCP();
			if (result == VersionResult.DownError)
				return DownloadFilesByFTP();
			else
				return result;
		}
		#endregion


		#region DownloadFilesByTCP
		/// <summary>
		/// 성공시 true, 실패시 false
		/// </summary>
		/// <returns></returns>
		private VersionResult DownloadFilesByTCP()
		{
			//VersionFile Save 여부, IHIS최초 기동시는 File Copy실패시하더라도, IHIS.exe Version Update함.
			//그외 업무시스템 실행시는 File Copy실패시에 Version File Update하지 않음
			bool isSaveVersionFile = true;
			
			//Download Form Set
			this.downloadForm = new FrameworkDownForm();

			// FTP Client 접속(Ini File에서 IP, HostType GET)
			transferClient = new SocketTransferClient(VersionManager.serverIP, HostType.UNIX, this.downloadForm);
			if (!transferClient.Connect()) return VersionResult.DownError;

			int ret = SetDownListByTCP();
			if (ret == -1)
			{
				transferClient.Close();
				return VersionResult.DownError;
			}
			else if (ret == 0)
			{
				transferClient.Close();
				return VersionResult.NotChanged; //변경사항 없음
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
				return VersionResult.DownError; //다운로드 에러
			}

			transferClient.Close();

			// Down File 실행 Directory로 Move
			// 단, Move 실패시, 프로그램 종료후 재실행한다.
			// 현재 Dir을 재설정
			Directory.SetCurrentDirectory(VersionManager.binPath);

			VersionResult result = VersionResult.Success;
			string fileName = "";
			string destFileName = "";
			string destFilePath = "";
			
			//최초 진입시 재실행 조건 (Application.EnableVisualStyle(true)로 XP Style을 적용하게 되면,
			//DownLoad후에 계속 실행시에 다운Load에 의해 변경된 Image가 제대로 적용이 안됨(.NET Bug)
			//이를 해결하기 위해 DownLoad한 Image나 dll이 있으면 Copy성공여부에 관계없이 재실행처리

			//최초 진입시 다운받은 Image를 Images Dir로 옮김
			if (this.isFirstOpen)
			{
				string[] imageFiles = Directory.GetFiles(VersionManager.downImagePath);

				foreach (string fullName in imageFiles)
				{
					try
					{
						fileName = fullName.Substring(fullName.LastIndexOf("\\") + 1);
						destFileName = VersionManager.imagePath + "\\" + fileName;
						if (File.Exists(destFileName))
						{
							File.Delete(destFileName);
						}
						File.Move(fullName, destFileName);
					}
					catch (Exception e)
					{
						Debug.WriteLine(e.Message);
					}
				}

				//2006.06.15 BarFont Font Windos\Fonts\로 이동 추가
				string[] fontFiles = Directory.GetFiles(VersionManager.downFontPath);
				foreach (string fullName in fontFiles)
				{
					try
					{
						//BARCODE_FONT_FILE은 Windows\Fonts\로 Move
						if (fullName.IndexOf(BARCODE_FONT_FILE) >= 0)
						{
							//C:\Windows\Fonts\BARCODE_FONT_FILE
							destFileName = Directory.GetParent(Environment.SystemDirectory).FullName + "\\Fonts\\" + BARCODE_FONT_FILE;
							if (!File.Exists(destFileName))  //Font가 존재하지 않으면 Move
							{
								File.Move(fullName, destFileName);
								//Font 다운로드 Flag Set
								VersionManager.fontDownloaded = true;
							}
						}
					}
					catch (Exception e)
					{
						Debug.WriteLine(e.Message);
					}
				}

			}

			string[] libFiles = Directory.GetFiles(VersionManager.downPath);
			
			//업무시스템 실행시 Dir은 업무시스템 Dir로 설정
			if (!this.isFirstOpen)
				Directory.SetCurrentDirectory(VersionManager.basePath + "\\" + this.libCopyPath);

			foreach (string fullName in libFiles)
			{
				try
				{
					fileName = fullName.Substring(fullName.LastIndexOf("\\") + 1);
					// 최초진입시는 IHIS의 공용 Libs를 binPath에 Copy
					// 업무시스템 진입시는 지정한 Dir에 Copy
					if(this.isFirstOpen)
						destFilePath = VersionManager.binPath;
					else
						destFilePath = VersionManager.basePath + "\\" + this.libCopyPath;

					//Copy할 Path에 Dir이 없으면 Dir 생성
					if (!Directory.Exists(destFilePath))
						Directory.CreateDirectory(destFilePath);

					destFileName = destFilePath + "\\" + fileName;

					//2004.5.7 업무시스템의 Main exe File이 없어서 IHIS.Commmon.exe를 다운로드 한 경우
					//IHIS.Common.exe -> SystemID.exe로 Rename하여 Move
					if (fileName == VersionManager.COMMON_EXE_FILE_NAME)
					{
						string renameFileName = destFilePath + "\\" + this.systemID + ".exe";
						if (File.Exists(renameFileName))
							File.Delete(renameFileName);
						File.Move(fullName, renameFileName);
					}
					else
					{
						if (File.Exists(destFileName))
							File.Delete(destFileName);
						File.Move(fullName, destFileName);
					}
				}
				catch (Exception e)
				{
					result = VersionResult.CopyError;
					Logs.WriteLog("DownloadLog", "파일 Move 에러, sourceFile=" + fullName + ",TargetFile=" + destFileName + ",에러=" + e.Message);
					//업무시스템 실행시에 File Copy 에러발생하면 Version 파일 Save하지 않음
					isSaveVersionFile = false;
					Debug.WriteLine(e.Message);
				}
			}

			//최초 기동이 아닐때 IHIS\Down에 Copy못한 파일이 있으면 파일삭제처리 (Dummy파일이 IHIS\bin으로 Copy되는 것 방지)
			//최초 기동시는 IHIS\Down에서 복사실패한 파일(FWM파일)을 IHIS\bin으로 이동해야함.
			//IHIS기동시가 아닌 업무시스템 실행시에 다운받은 파일이 없으면 Version파일 저장하지 않음
			if (!this.isFirstOpen && (libFiles.Length < 1))
				isSaveVersionFile = false;

			//Version 저장 (IHIS기동시는 File Copy실패여부에 관계없이 Save, 업무시스템 실행시는 File Copy실패시에 Save하지 않음
			if (this.isFirstOpen)
				this.SaveVersionFile();
			else if (isSaveVersionFile)
				this.SaveVersionFile();

			if (!this.isFirstOpen)
			{
				libFiles = Directory.GetFiles(VersionManager.downPath);
				foreach (string fullName in libFiles)
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
			}
			return result;
		}
		#endregion

		#region DownloadFilesByFTP
		/// <summary>
		/// 성공시 true, 실패시 false
		/// </summary>
		/// <returns></returns>
		private VersionResult DownloadFilesByFTP()
		{
			//VersionFile Save 여부, IHIS최초 기동시는 File Copy실패시하더라도, IHIS.exe Version Update함.
			//그외 업무시스템 실행시는 File Copy실패시에 Version File Update하지 않음
			bool isSaveVersionFile = true;
			
			// FTP Client 접속(Ini File에서 IP, HostType GET)
			ftpWorker = new XFTPWorker(FTP_USERID, FTP_PSWD, VersionManager.serverIP);
			ftpWorker.ShowProgressForm = false; //한 파일씩 Load하는 Form은 보여주지 않음
			if (!ftpWorker.Connected) return VersionResult.DownError;

			//Root Dir SET, PATH 구분자 SET
			this.ftpRootPath = ftpWorker.GetCurrentDir();
			this.ftpPathDelim = ftpRootPath.Substring(0,1);


			// Download 대상 File List 작성
			// 2006.08.07 -1 Return은 TCP로 다운로드 목록을 제대로 받지 못한 것이므로 DownError Return
			int ret = SetDownListByFTP();
			if (ret == -1)
			{
				ftpWorker.Close();
				return VersionResult.DownError;
			}
			else if (ret == 0)
			{
				ftpWorker.Close();
				return VersionResult.NotChanged; //변경사항 없음
			}

			//Down에 있는 Dummy 파일 삭제 실패시에 Fail Return
			if (!this.isDummyFileRemoveSuccess)
			{
				transferClient.Close();
				return VersionResult.DeleteFail;
			}
			
			// 대상 File List Download (Fail시에 return
			if (!DownloadByFTP())
			{
				ftpWorker.Close();
				return VersionResult.DownError; //다운로드 에러
			}

			ftpWorker.Close();

			// Down File 실행 Directory로 Move
			// 단, Move 실패시, 프로그램 종료후 재실행한다.
			// 현재 Dir을 재설정
			Directory.SetCurrentDirectory(VersionManager.binPath);

			VersionResult result = VersionResult.Success;
			string fileName = "";
			string destFileName = "";
			string destFilePath = "";
			
			//최초 진입시 재실행 조건 (Application.EnableVisualStyle(true)로 XP Style을 적용하게 되면,
			//DownLoad후에 계속 실행시에 다운Load에 의해 변경된 Image가 제대로 적용이 안됨(.NET Bug)
			//이를 해결하기 위해 DownLoad한 Image나 dll이 있으면 Copy성공여부에 관계없이 재실행처리

			//최초 진입시 다운받은 Image를 Images Dir로 옮김
			if (this.isFirstOpen)
			{
				string[] imageFiles = Directory.GetFiles(VersionManager.downImagePath);

				foreach (string fullName in imageFiles)
				{
					try
					{
						fileName = fullName.Substring(fullName.LastIndexOf("\\") + 1);
						destFileName = VersionManager.imagePath + "\\" + fileName;
						if (File.Exists(destFileName))
						{
							File.Delete(destFileName);
						}
						File.Move(fullName, destFileName);
					}
					catch (Exception e)
					{
						Debug.WriteLine(e.Message);
					}
				}

				//2006.06.15 BarFont Font Windos\Fonts\로 이동 추가
				string[] fontFiles = Directory.GetFiles(VersionManager.downFontPath);
				foreach (string fullName in fontFiles)
				{
					try
					{
						//BARCODE_FONT_FILE은 Windows\Fonts\로 Move
						if (fullName.IndexOf(BARCODE_FONT_FILE) >= 0)
						{
							//C:\Windows\Fonts\BARCODE_FONT_FILE
							destFileName = Directory.GetParent(Environment.SystemDirectory).FullName + "\\Fonts\\" + BARCODE_FONT_FILE;
							if (!File.Exists(destFileName))  //Font가 존재하지 않으면 Move
							{
								File.Move(fullName, destFileName);
								//Font 다운로드 Flag Set
								VersionManager.fontDownloaded = true;
							}
						}
					}
					catch (Exception e)
					{
						Debug.WriteLine(e.Message);
					}
				}

			}

			string[] libFiles = Directory.GetFiles(VersionManager.downPath);
			
			//업무시스템 실행시 Dir은 업무시스템 Dir로 설정
			if (!this.isFirstOpen)
				Directory.SetCurrentDirectory(VersionManager.basePath + "\\" + this.libCopyPath);

			foreach (string fullName in libFiles)
			{
				try
				{
					fileName = fullName.Substring(fullName.LastIndexOf("\\") + 1);
					// 최초진입시는 IHIS의 공용 Libs를 binPath에 Copy
					// 업무시스템 진입시는 지정한 Dir에 Copy
					if(this.isFirstOpen)
						destFilePath = VersionManager.binPath;
					else
						destFilePath = VersionManager.basePath + "\\" + this.libCopyPath;

					//Copy할 Path에 Dir이 없으면 Dir 생성
					if (!Directory.Exists(destFilePath))
						Directory.CreateDirectory(destFilePath);

					destFileName = destFilePath + "\\" + fileName;

					//2004.5.7 업무시스템의 Main exe File이 없어서 IHIS.Commmon.exe를 다운로드 한 경우
					//IHIS.Common.exe -> SystemID.exe로 Rename하여 Move
					if (fileName == VersionManager.COMMON_EXE_FILE_NAME)
					{
						string renameFileName = destFilePath + "\\" + this.systemID + ".exe";
						if (File.Exists(renameFileName))
							File.Delete(renameFileName);
						File.Move(fullName, renameFileName);
					}
					else
					{
						if (File.Exists(destFileName))
							File.Delete(destFileName);
						File.Move(fullName, destFileName);
					}
				}
				catch (Exception e)
				{
					result = VersionResult.CopyError;
					Logs.WriteLog("DownloadLog", "파일 Move 에러, sourceFile=" + fullName + ",TargetFile=" + destFileName + ",에러=" + e.Message);
					//업무시스템 실행시에 File Copy 에러발생하면 Version 파일 Save하지 않음
					isSaveVersionFile = false;
					Debug.WriteLine(e.Message);
				}
			}

			//최초 기동이 아닐때 IHIS\Down에 Copy못한 파일이 있으면 파일삭제처리 (Dummy파일이 IHIS\bin으로 Copy되는 것 방지)
			//최초 기동시는 IHIS\Down에서 복사실패한 파일(FWM파일)을 IHIS\bin으로 이동해야함.
			//IHIS기동시가 아닌 업무시스템 실행시에 다운받은 파일이 없으면 Version파일 저장하지 않음
			if (!this.isFirstOpen && (libFiles.Length < 1))
				isSaveVersionFile = false;

			//Version 저장 (IHIS기동시는 File Copy실패여부에 관계없이 Save, 업무시스템 실행시는 File Copy실패시에 Save하지 않음
			if (this.isFirstOpen)
				this.SaveVersionFile();
			else if (isSaveVersionFile)
				this.SaveVersionFile();

			if (!this.isFirstOpen)
			{
				libFiles = Directory.GetFiles(VersionManager.downPath);
				foreach (string fullName in libFiles)
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
			}
			return result;
		}
		#endregion


		#region Version파일 관련
		private void LoadVersionFile()
		{
			versionFileName = VersionManager.basePath + "\\" + this.libCopyPath + "\\" + VERSION_FILE_NAME;

			//Version File Path 가 없으면 먼저 Create
			string filePath = VersionManager.basePath + "\\" + this.libCopyPath;
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
				Debug.WriteLine("VersionManager::SaveVersionFile Error=" + xe.Message);
			}
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
    
        #region LogWrite
        public static void WriteLog(string msg)
        {
            Logs.WriteLog("DownloadLog", msg);
            /*
            try
            {
                string str = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + "]";
                str += msg;
                // Write the string to a file.
                System.IO.StreamWriter file = new System.IO.StreamWriter(Application.StartupPath + "\\DownloadLog.txt", true);
                file.WriteLine(str);
                file.Close();
            }
            catch { }
            */
        }
        #endregion
    }
}
