using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using IHIS.Framework;

namespace IHIS.OCSA
{
	/// <summary>
	/// ImageHelper에 대한 요약 설명입니다.
	/// </summary>
	public class ImageHelper
	{
		const string TITLE = "ImageHelper";
        
		public static bool IsFileDownload(string fileName, DateTime createTime)
		{
			if (!File.Exists(fileName))
				return true;
			FileInfo fInfo = new FileInfo(fileName);
			if (fInfo.LastWriteTime.CompareTo(createTime) < 0)
				return true;
			return false;
		}

		/// <summary>
		/// 이미지 파일을 다운로드 합니다.
		/// </summary>
		/// <param name="imageFileInfoList"> ImageFileInfo를 담은 ArrayList </param>
		/// <param name="isLargeFile"> 대용량 전송 여부 </param>
		/// <returns></returns>
		public static bool DownloadImages(ArrayList imageFileInfoList, bool isLargeFile)
		{
			//서버 정보 GET
			string ip = EnvironInfo.GetImageServerIP(); //"10.15.200.10";//EnvironInfo.GetDownloadServerIP();
			string msg = "";
			int index = 0;
			ProgressForm progForm = new ProgressForm();
			
			
			string origDir = Directory.GetCurrentDirectory();
			try
			{
                XFTPWorker ftpWorker = new XFTPWorker(EnvironInfo.GetImageUserID(), EnvironInfo.GetImageUserPW(), ip);
				ftpWorker.ShowProgressForm = false; //한껀씩 보내는 ProgressBar는 보이지 않고, 여기서 보여줌

				//ProgressBar의 Max값은 Upload갯수
				progForm.Init(imageFileInfoList.Count.ToString(), "Downloading Start....");
				progForm.Show();

				string currentServerDir = ftpWorker.GetCurrentDir();
				string currentClientDir = origDir;  //현재 Client Dir
				foreach (ImageFileInfo info in imageFileInfoList)
				{
					//Client Dir 존재여부 확인 생성
					if (!Directory.Exists(info.ClientPath))
						Directory.CreateDirectory(info.ClientPath);

					// Client의 현재 Dir을 변경
					if (currentClientDir != info.ClientPath)
						Directory.SetCurrentDirectory(info.ClientPath);

					//Server Dir 이 다르면 변경
					if (currentServerDir != info.ServerPath)
					{
						//Dir 변경 실패시 Return (MSG는 ftpWorker에서 뿌려줌)
						if (!ftpWorker.ChangeDir(info.ServerPath))
						{
							msg = (NetInfo.Language == LangMode.Ko ? "디렉토리[" + info.ServerPath + "] 변경에러" : "フォルダ[" + info.ServerPath + "]変更エラー");
							XMessageBox.Show(msg, TITLE);
							return false;
						}
					}
					
					//DownLoad File , 실패시 return
					//DICOM 이미지가 약 700K정도 되므로 대용량이라고 판단될 경우는 비동기식으로 하기(SendLargeFileToClient 사용)
					//비동기식으로 처리하는 경우 파일다운로드 전에 다음 Process가 발생하게 되므로, 처리가 곤란한 경우가 
					//발생함 따라서, 일단은 동기식으로 처리한다.
					//MSG 는 ftpWorker에서 뿌려줌
					if (isLargeFile)  //대용량 파일 전송
					{
						//대용량도 일단은 동기식으로 전송처리함.
						//if (!ftpWorker.SendLargeFileToClient(info.ServerFileName, info.ClientFileName)) return false;
						if (!ftpWorker.SendFileToClient(info.ServerFileName, info.ClientFileName)) return false;
					}
					else
					{
						if (!ftpWorker.SendFileToClient(info.ServerFileName, info.ClientFileName)) return false;
					}
					
					//현재값 다시 설정
					currentServerDir = info.ServerPath;
					currentClientDir = info.ClientPath;

					index++;
					//ProgressForm Set
					progForm.MoveProgress(index, "Transferred " + index.ToString() + " file of " + imageFileInfoList.Count.ToString() + " files (" + info.ServerFileName + ")");

				}
			}
			catch(Exception xe)
			{
				msg = (NetInfo.Language == LangMode.Ko ? "이미지 다운로드 에러[" + xe.Message + "]"
					: "イメージダウンロードエラー[" + xe.Message + "]");
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(msg, TITLE);
				return false;
			}
			finally
			{
				//현재 Dir 복구
				Directory.SetCurrentDirectory(origDir);
				if (progForm != null)
					progForm.Dispose();
			}
			return true;
		}

		/// <summary>
		/// 이미지를 서버로 Upload 합니다.
		/// </summary>
		/// <param name="imageFileInfoList"> ImageFileInfo를 담은 ArrayList </param>
		/// <param name="isLargeFile"> 대용량 전송 여부 </param>
		/// <returns></returns>
		public static bool UploadImages(ArrayList imageFileInfoList, bool isLargeFile)
		{
			//서버 정보 GET
			string ip = EnvironInfo.GetImageServerIP(); //"10.15.200.10";//EnvironInfo.GetDownloadServerIP();
			string msg = "", fullName;
			ProgressForm progForm = new ProgressForm();
			
			string origDir = Directory.GetCurrentDirectory();
			try
			{
                XFTPWorker ftpWorker = new XFTPWorker(EnvironInfo.GetImageUserID(), EnvironInfo.GetImageUserPW(), ip);
				ftpWorker.ShowProgressForm = false; //한껀씩 보내는 ProgressBar는 보이지 않고, 여기서 보여줌
				string currentServerDir = ftpWorker.GetCurrentDir();
				string currentClientDir = origDir;  //현재 Client Dir
				int index = 0;
				//ProgressBar의 Max값은 Upload갯수
				progForm.Init(imageFileInfoList.Count.ToString(), "Uploading Start....");
				progForm.Show();
				foreach (ImageFileInfo info in imageFileInfoList)
				{
					// Client의 현재 Dir을 변경
					if (currentClientDir != info.ClientPath)
						Directory.SetCurrentDirectory(info.ClientPath);
					//Server Dir 이 다르면 변경
					if (currentServerDir != info.ServerPath)
					{
						//Dir 변경 실패시 Return (MSG는 ftpWorker에서 뿌려줌)
						if (!ftpWorker.ChangeDir(info.ServerPath))
						{
                            string[] subPath = info.ServerPath.Split('/');
							string addPath = "";
                            for (int i=1; i<subPath.Length; i++)
                            {
                                addPath += "/" + subPath[i];
                                if (!ftpWorker.ChangeDir(addPath))
                                {
                                    if (!ftpWorker.MakeDir(addPath))
                                    {
                                        XMessageBox.Show("not changed server directory");
                                    }
                                }
                            }
                            

							//서버 Dir이 없어서 변경 실패시는 Dir  생성
							if (!ftpWorker.MakeDir(info.ServerPath))
							{
								msg = (NetInfo.Language == LangMode.Ko ? "디렉토리 생성에러" : "フォルダ生成エラー");
								XMessageBox.Show(msg, TITLE);
								return false;
							}
							else // 다시 ChangeDir
							{
								if (!ftpWorker.ChangeDir(info.ServerPath))
								{
									msg = (NetInfo.Language == LangMode.Ko ? "디렉토리 변경에러" : "フォルダ変更エラー");
									XMessageBox.Show(msg, TITLE);
									return false;
								}
							}
						}
					}
					
					//DownLoad File , 실패시 return
					//DICOM 이미지가 약 700K정도 되므로 대용량이라고 판단될 경우는 비동기식으로 하기(SendLargeFileToClient 사용)
					//MSG 는 ftpWorker에서 뿌려줌
					//비동기식으로 처리하는 경우 파일다운로드 전에 다음 Process가 발생하게 되므로, 처리가 곤란한 경우가 
					//발생함 따라서, 일단은 동기식으로 처리한다.
					fullName = info.ClientPath + "\\" + info.ClientFileName;
					if (isLargeFile)
					{
						//대용량도 동기식으로 처리함.
						//if (!ftpWorker.SendLargeFileToServer(fullName, info.ServerFileName)) return false;
						if (!ftpWorker.SendFileToServer(fullName, info.ServerFileName)) return false;
					}
					else
					{
						if (!ftpWorker.SendFileToServer(fullName, info.ServerFileName)) return false;
					}
					
					//현재값 다시 설정
					currentServerDir = info.ServerPath;
					currentClientDir = info.ClientPath;
					index++;
					//ProgressForm Set
					progForm.MoveProgress(index, "Transferred " + index.ToString() + " file of " + imageFileInfoList.Count.ToString() + " files (" + info.ServerFileName + ")");
				}
			}
			catch(Exception xe)
			{
				msg = (NetInfo.Language == LangMode.Ko ? "이미지 업로드 에러[" + xe.Message + "]"
					: "イメージアップデートエラー[" + xe.Message + "]");
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(msg, TITLE);
				return false;
			}
			finally
			{
				//현재 Dir 복구
				Directory.SetCurrentDirectory(origDir);
				if (progForm != null)
					progForm.Dispose();
			}
			return true;
		}

		public static Image GetImage(string fileName)
		{
			if (!File.Exists(fileName)) return null;
			FileStream fs = new FileStream(fileName, FileMode.Open);
			try
			{
				long byteCount = fs.Seek(0, SeekOrigin.End);
				fs.Seek(0, SeekOrigin.Begin);
				using (BinaryReader br = new BinaryReader(fs))
				{
					byte[] binary = br.ReadBytes((int) byteCount);
					//Image 객체가 Dispose되기 전에는 Stream이 Close 되면 안되므로 using을 쓰지 않고 처리함.
					MemoryStream ms = new MemoryStream(binary, false);
					return Image.FromStream(ms);
//					using (MemoryStream ms = new MemoryStream(binary, false))
//						return Image.FromStream(ms);
				}
			}
			catch
			{
				return null;
			}
			finally
			{
				fs.Close();
			}
		}
		//Image를 지정한 file로 Save
		public static bool SaveImageFile(Image image, string fileName)
		{
			try
			{
				image.Save(fileName, ImageFormat.Jpeg);
			}
			catch(Exception xe)
			{
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show("Image Save Error Message[" + xe.Message + "]");
				//XMessageBox.Show("Image Save Error StackTrace[" + xe.StackTrace + "]");
				//XMessageBox.Show("Image Save Error Source[" + xe.Source + "]");
				//XMessageBox.Show("Image Save Error TargetSite[" + xe.TargetSite + "]");
				return false;
			}
			return true;
		}

		public static string GetImageRoot()
		{
			//Image 저장 Root
			return Directory.GetParent(Application.StartupPath) + "\\CPLImages";
		}

        //기준일자 이전 이미지들 모두 삭제
        public static void DeletePreImage(DateTime baseDate)
        {
            string image_path = @"C:\IHIS\CPLImages\";

            DeleteImage(image_path, baseDate);
        }

        private static void DeleteImage(string image_path, DateTime baseDate)
        {
            try
            {
                if (Directory.Exists(image_path))
                {
                    string[] folder_list = Directory.GetDirectories(image_path);

                    foreach (string delete_directory_path in folder_list)
                    {
                        DeleteImage(delete_directory_path, baseDate);
                    }

                    string[] delete_list = Directory.GetFiles(image_path);
                    foreach (string delete_file_path in delete_list)
                    {
                        DateTime file_create_time = File.GetCreationTime(delete_file_path);
                        if (file_create_time < baseDate)
                            File.Delete(delete_file_path);
                    }

                    delete_list = Directory.GetFiles(image_path);
                    folder_list = Directory.GetDirectories(image_path);
                    
                    if (folder_list.Length == 0 && delete_list.Length == 0)
                    {
                        Directory.Delete(image_path);
                    }
                }
            }
            catch (Exception e)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(e.ToString());
            }
        }
	}
	
	//DICOM 이미지를 Upload, Download할때 쓰이는 파일 정보
	//각 화면에서 이 파일정보를 만들어서 ImageHelper의 Upload, Download를 call할때 사용함
	public class ImageFileInfo
	{
		public string ClientPath = "";   //C:\Bitmapimages\환자번호
		public string ServerPath = "";   // /IMAGE/IHISimage/PFE/ENDO/2006 형식으로 들어감
		public string ClientFileName = "";
		public string ServerFileName = "";
		public string ImageGubun = "D";   //Image 구분, D.Dicom Image, R.Result Image (결과이미지), B.결과기준정보 Image

		public ImageFileInfo(string clientPath, string serverPath, string clientFileName, string serverFileName)
		{
			this.ClientPath = clientPath;
			this.ServerPath = serverPath;
			this.ClientFileName = clientFileName;
			this.ServerFileName = serverFileName;
		}
	}
}
