using System;
using System.Collections;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
//
using IHIS.Framework;

namespace IHIS
{
	/// <summary>
	/// HostType enum (DownLoad Server의 Type)
	/// </summary>
	public enum HostType
	{
		/// <summary>
		/// Unix Server
		/// </summary>
		UNIX,
		/// <summary>
		/// Window Server
		/// </summary>
		Windows
	}
	/// <summary>
	/// Download 결과 enum
	/// </summary>
	internal enum DownloadResult
	{
		/// <summary>
		/// Download 성공
		/// </summary>
		Success,
		/// <summary>
		/// 파일 없음
		/// </summary>
		FileNotFound,
		/// <summary>
		/// Download 실패
		/// </summary>
		DownloadError
	}

	/// <summary>
	/// SocketTransferClient class (Socket 이용 JIT Download)
	/// </summary>
	internal class SocketTransferClient : IDisposable
	{
		//IFC는 15020, IHIS는 16020
        //private static int DEFAULT_PORT = 16020;
        private static int DEFAULT_PORT = 15020;
        // 기본 Encoding
		private Encoding encoding = Service.BaseEncoding;
		private string remoteHost, remotePath;
		private HostType remoteHostType;
		private int remotePort;
		private Socket clientSocket;
		private FrameworkDownForm downForm = null;

		private bool connected;

		/// <summary>
		/// SocketTransferClient 생성자
		/// </summary>
		public SocketTransferClient(string host, int port, HostType hostType, FrameworkDownForm downForm)
		{
			remoteHost  = host;
			remoteHostType = hostType;
			remotePath  = ".";
			remotePort  = port;
			connected     = false;
			this.downForm = downForm;
		}
		
		/// <summary>
		/// CustomTransferClient 소멸자
		/// </summary>
		~SocketTransferClient()
		{
			Dispose();
		}
		/// <summary>
		/// 리소스를 해제합니다. (connected 시에 Socket Close)
		/// </summary>
		public void Dispose()
		{
			if (connected)
				Close();
		}

		/// <summary>
		/// CustomTransferClient 생성자 Overload
		/// </summary>
		public SocketTransferClient(string host, HostType hostType, FrameworkDownForm downForm)
			: this(host, DEFAULT_PORT, hostType, downForm)
		{
		}

		/// <summary>
		/// CustomTransferClient 생성자 Overload
		/// </summary>
		public SocketTransferClient()
			: this("localhost", DEFAULT_PORT, HostType.UNIX, null)
		{
		}

		/// <summary>
		/// Server Name(Host Name)을 가져오거나 설정합니다.
		/// </summary>
		public string RemoteHost
		{
			get { return remoteHost; }
			set { remoteHost = value; }
		}

		// Port number
		/// <summary>
		/// Port Number를 가져오거나 설정합니다.
		/// </summary>
		public int RemotePort
		{
			get { return remotePort; }
			set { remotePort = value; }
		}

		// The remote directory path
		/// <summary>
		/// Host의 Directory path를 가져오거나 설정합니다.
		/// </summary>
		public string RemotePath
		{
			get { return remotePath; }
			set { remotePath = RemotePathCnvt(value); }
		}

		// Remote Host Type
		/// <summary>
		/// DownLoad Server의 Type(Unix, Windows)을 가져오거나 설정합니다.
		/// </summary>
		public HostType RemoteHostType
		{
			get { return remoteHostType; }
			set { remoteHostType = value; }
		}
		/// <summary>
		/// Host와의 연결여부를 가져옵니다.
		/// </summary>
		public bool Connected
		{
			get { return connected; }
		}

		/// <summary>
		/// Remote server에 Connect합니다.
		/// </summary>
		public bool Connect()
		{
			clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			IPEndPoint ep = new IPEndPoint(IPAddress.Parse(remoteHost), remotePort);

			try
			{
				//수신대기시간, 송신대기시간 5Sec
				clientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 5000);
				clientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 5000);
			}
			catch(Exception e)
			{
				Logs.WriteLog("DownloadLog", "SocketTransferClient::Connect SetSocketOption Error=" + e.Message);
				Debug.WriteLine(e.Message);
				return false;
			}

			try
			{
				clientSocket.Connect(ep);
			}
			catch(Exception e)
			{
				Logs.WriteLog("DownloadLog", "SocketTransferClient::Connect clientSocket.Connect Error=" + e.Message);
				Debug.WriteLine(e.Message);
				Cleanup();
				return false;
			}

			connected = true;

			if (remotePath != "")
				ChDir(remotePath);
			
			return true;

		}

		/// <summary>
		/// Server로부터 FileList 가져옵니다.
		/// </summary>
		/// <param name="mask"> 특정파일 지정시 mask, 전체는 * </param>
		/// <returns> fileList Array(string[]) </returns>
		public string[] GetFileList(string mask)
		{
			return GetFileList(mask, false);
		}

		/// <summary>
		/// Server로부터 FileList 가져옵니다.
		/// </summary>
		/// <param name="mask"> 특정파일 지정시 mask, 전체는 * </param>
		/// <param name="fullInfo"> 전체정보여부 </param>
		/// <returns> fileList Array(string[]) </returns>
		public string[] GetFileList(string mask, bool fullInfo) 
		{
			if (!connected) 
				Connect();

			ArrayList fileList = new ArrayList();
			Send("FLQ" + mask);
			while(true)
			{
				string data = RecvString();
				string[] files = data.Substring(3).Split(new char[] {'\n'});
				//\n으로 Spilt하면 마지막에 ""값이 들어감, 따라서 마지막 ""는 제외하고 List에 Add
				if (fullInfo)
				{
					foreach (string file in files)
					{
						if (file != "")
							fileList.Add(file);
					}
				}
				else
				{
					foreach (string file in files)
					{
						if (file != "")
						{
							string[] fileInfos = file.Split(new Char[] {'\t'});
							if (fileInfos.Length > 0)
								fileList.Add(fileInfos[0]);
						}
					}
				}
				if (data.Substring(0,3) == "LED")
					break;
				Send("FLC");
			}
			return (string[])fileList.ToArray(typeof(string));
		}

		/// <summary>
		/// File 전체정보에서 FileName, File Size 및 수정일자를 가져옵니다.
		/// </summary>
		/// <param name="fileInfo"> file 정보 </param>
		/// <param name="fileName"> ref file이름 </param>
		/// <param name="size">ref file Size </param>
		/// <param name="mDate"> ref file 수정일자</param>
		/// <returns> 성공시 true, 실패시 false </returns>
		public bool ParseFileInfo(string fileInfo, ref string fileName, ref long size, ref DateTime mDate)
		{
			string[] items = fileInfo.Split(new char[] {'\t'});
			if (items.Length < 3)
				return false;
			fileName = items[0];
			size = long.Parse(items[1]);
			mDate = new DateTime(int.Parse(items[2].Substring(0,4)), int.Parse(items[2].Substring(4,2)), int.Parse(items[2].Substring(6,2)),
				int.Parse(items[2].Substring(8,2)), int.Parse(items[2].Substring(10,2)), int.Parse(items[2].Substring(12,2)));

			return true;
		}

		/// <summary>
		///  파일이름으로 size 및 수정일자를 가져옵니다.
		/// </summary>
		/// <param name="fileName"> 파일이름 </param>
		/// <param name="size"> ref file Size </param>
		/// <param name="mDate"> ref file 수정일자 </param>
		public void GetFileInfo(string fileName, ref long size, ref DateTime mDate)
		{
			string	dummy = "";
			string[] fileList = GetFileList(fileName, true);
			if (fileList.Length < 1)
				return;
			string	fileInfo = fileList[0];
			ParseFileInfo(fileInfo, ref dummy, ref size, ref mDate);
		}

		/// <summary>
		/// file 이름으로 파일 size를 가져옵니다.
		/// </summary>
		/// <param name="fileName"> 파일이름 </param>
		/// <returns> 파일 Size </returns>
		public long GetFileSize(string fileName) 
		{
			if (!connected) 
				Connect();

			Send("FSZ" + fileName);
			string data = RecvString();
			return long.Parse(data);
		}

		/// <summary>
		/// 서버 파일명으로 File을 DownLoad 합니다.
		/// </summary>
		/// <param name="remFileName"> 서버파일명 </param>
		/// <param name="locFileName"> Local 파일명 </param>
		/// <returns> DownloadResult enum (Success,FileNotFound,DownloadError) </returns>
		public DownloadResult Download(string remoteFileName, string localFileName, long totalBytes)
		{
			FileStream output = null;
			try
			{
				remoteFileName = RemotePathCnvt(remoteFileName);

				if (!connected)
					Connect();

				if (localFileName.Equals(""))
					localFileName = remoteFileName;

				if (!File.Exists(localFileName))
				{
					FileInfo fi = new FileInfo(localFileName);
					// Directory가 없으면 작성
					if (!fi.Directory.Exists)
					{
						Directory.CreateDirectory(fi.DirectoryName);
					}

					Stream st = File.Create(localFileName);
					st.Close();
				}

				output = new FileStream(localFileName, FileMode.Create, FileAccess.Write, FileShare.Write);

				byte[] dataBytes;
				long recvBytesCount = 0;

				Send("FDQ" + remoteFileName);
				bool isError = false;
				while(true)
				{
					dataBytes = Recv();
					if (dataBytes == null)
					{
						Logs.WriteLog("DownloadLog", "SocketTransferClient::Download Error dataBytes == null,remoteFileName=" + remoteFileName);
						isError = true;
						break;
					}
					else if (dataBytes.Length == 0)
					{
						Logs.WriteLog("DownloadLog", "SocketTransferClient::Download Error dataBytes.Length == 0,remoteFileName=" + remoteFileName);
						isError = true;
						break;
					}
					else if (dataBytes.Length == 3)
					{
						if (encoding.GetString(dataBytes) == "FNF")
						{
							Logs.WriteLog("DownloadLog", "SocketTransferClient::Download Error String FNF remoteFileName=" + remoteFileName);
							output.Close();
							//앞에서 생성한 File Delete (삭제하지 않으면 0byte의 File이 생성되어 Copy됨)
							File.Delete(localFileName);
							return DownloadResult.FileNotFound;
						}
						if (encoding.GetString(dataBytes) == "END")
							break;
					}
					if (this.downForm != null)
					{
						recvBytesCount += dataBytes.LongLength;
						try
						{
							string msg = "Received  " + recvBytesCount + " of " + totalBytes + " bytes";
							downForm.SetByteString(msg);
							downForm.SetRecvBytes(((int) (recvBytesCount*100/totalBytes)));
						}
						catch{}
					}
					output.Write(dataBytes, 0, dataBytes.Length);
				}
				output.Close();

				if(isError)
				{
					//잘못된 파일 삭제
					File.Delete(localFileName);
					return DownloadResult.DownloadError;
				}

				return DownloadResult.Success;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				Logs.WriteLog("DownloadLog", "SocketTransferClient::Download remoteFileName=" + remoteFileName + ",Error=" + ex.Message);
				Logs.WriteLog("DownloadLog", "SocketTransferClient::Download StackTrace=" + ex.StackTrace);
				output.Close();
				//앞에서 생성한 File Delete (정상적인 File이 아님)
				File.Delete(localFileName);
				return DownloadResult.DownloadError;
			}
		}

		/// <summary>
		/// 서버의 Path를 변경합니다.
		/// </summary>
		/// <param name="dirName"> 변경 Path명 </param>
		/// <returns> 성공시 true, 실패시 false </returns>
		public bool ChDir(string dirName)
		{
			dirName = RemotePathCnvt(dirName);
			if (dirName.Equals(".") || dirName.Equals(""))
				return true;

			Send("CHD" + dirName);
			string retString = RecvString();
			if (retString != "DOK")
			{
				Logs.WriteLog("DownloadLog", "SocketTransferClient::ChDir 에러 dirName=" + dirName + ",retString=" + retString);
				return false;
			}
			this.remotePath = dirName;
			return true;
		}
		/// <summary>
		/// 연결을 종료합니다.
		/// </summary>
		public void Close()
		{
			try
			{
				Send("TOK");
			}
			catch{}
			Cleanup();
		}

		private int Send(string data)
		{
			return Send(encoding.GetBytes(data));
		}

		private int Send(byte[] dataBytes)
		{
			if (clientSocket == null)
				return -1;
			byte[] buffer = new byte[dataBytes.Length + 5];
			encoding.GetBytes(dataBytes.Length.ToString().PadLeft(5, '0'), 0, 5, buffer, 0);
			Array.Copy(dataBytes, 0, buffer, 5, dataBytes.Length);
			return clientSocket.Send(buffer, buffer.Length, 0) - 5;
		}

		private byte[] Recv()
		{
			if (clientSocket == null)
				return null;

			byte[] lenBuffer = new byte[5];
			int len = 0;
			int offset = 0;
			int loopCnt = 0;
			int size = 5;
			//DownServer에 Network 성능, PC성능에 따라 특정 Case에는 5byte를 받지 못하고 4byte만 받는 경우가 발생함.
			//이경우 보통은 2번정도 LOOP에서 처리가 가능하나, 일단 10번 LOOP까지 허용하고 LOOP를 돌며 5byte를 받음
			//10번 LOOP를 돌아도 SIZE 가 줄어들지 않으면 문제임
			while ((size > 0) && (loopCnt < 10))
			{
				try
				{
					len = clientSocket.Receive(lenBuffer, offset, size, SocketFlags.None);
				}
				catch(Exception e)
				{
					Logs.WriteLog("DownloadLog", "SocketTransferClient::Recv Receive에러=" + e.Message);
					SocketException se = e as SocketException;
					if (se != null)
					{
						Logs.WriteLog("DownloadLog", "SocketTransferClient::Recv Receive Socket ErrCode=" + se.ErrorCode.ToString());
						//호스트로부터 응답이 없어서 연결이 끊김, Receive시에 TimeOut 발생
						//TimeOut 발생시는 DisConnect하고 종료
						if (se.ErrorCode == 10060)
							this.Cleanup();
						return null;
					}
				}
				offset += len;
				size -= len;
				loopCnt++;
			}
			if (size > 0)
			{
				Logs.WriteLog("DownloadLog", "SocketTransferClient::Recv 에러 size > 0, size=" + size.ToString() + ",loopCnt=" + loopCnt.ToString() + ",lenBuffSTr=" + encoding.GetString(lenBuffer));
				return null;
			}

			size = 0;
			if (TypeCheck.IsInt(encoding.GetString(lenBuffer)))
				size = int.Parse(encoding.GetString(lenBuffer));
			else
			{
				Logs.WriteLog("DownloadLog", "SocketTransferClient::Recv 에러 sizeStr=" + encoding.GetString(lenBuffer));
				return null;
			}

			if (size == 0)
			{
				Logs.WriteLog("DownloadLog", "SocketTransferClient::Recv 에러 size == 0");
				return null;
			}

			byte[] buffer = new byte[size];
			offset = 0;
			loopCnt = 0;
			//무한 LOOP방지 5000번까지만 허용
			while ((size > 0) && (loopCnt < 5000))
			{
				try
				{
					len = clientSocket.Receive(buffer, offset, size, SocketFlags.None);
				}
				catch(Exception xe)
				{
					Logs.WriteLog("DownloadLog", "SocketTransferClient::Recv in loop Receive 에러=" + xe.Message);
					SocketException se = xe as SocketException;
					if (se != null)
					{
						Logs.WriteLog("DownloadLog", "SocketTransferClient::Recv in loop Receive Socket ErrCode=" + se.ErrorCode.ToString());
						//호스트로부터 응답이 없어서 연결이 끊김, Receive시에 TimeOut 발생
						//TimeOut 발생시는 DisConnect하고 종료
						if (se.ErrorCode == 10060)
							this.Cleanup();
					}
					return null;
				}
				offset += len;
				size -= len;
				loopCnt++;
			}
			//5000번을 돈 후에도 Size가 > 0 이면 에러
			if (size > 0)
			{
				Logs.WriteLog("DownloadLog", "SocketTransferClient::Recv after 5000 loop size > 0");
				return null;
			}
			return buffer;
		}

		private string RecvString()
		{
			byte[] dataBytes = Recv();
			if ((dataBytes != null) && (dataBytes.Length > 0))
				return encoding.GetString(dataBytes);
			else
				return string.Empty;
		}

		private void Cleanup()
		{
			if (clientSocket!=null)
			{
				clientSocket.Close();
				clientSocket = null;
			}
			connected = false;
		}
		/// <summary>
		/// 경로명을 HostType에 맞추어 변경합니다.
		/// </summary>
		/// <param name="path"> 경로명 </param>
		/// <returns> 변경된 경로명 </returns>
		public string RemotePathCnvt(string path) 
		{
			if (remoteHostType == HostType.Windows)
			{
				return pathUNIX2Win(path);
			}
			else
			{
				return pathWin2UNIX(path);
			}
		}

		private string pathWin2UNIX(string path) 
		{
			string cnvtPath = path.Replace(@"\", "/");
			return cnvtPath;
		}

		private string pathUNIX2Win(string path) 
		{
			string cnvtPath = path.Replace("/", @"\");
			return cnvtPath;
		}
	}
}
