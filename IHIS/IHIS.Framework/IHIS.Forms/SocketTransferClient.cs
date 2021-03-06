using System;
using System.Collections;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace IHIS.Framework
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
        private static int DEFAULT_PORT = 15020;
        //private static int DEFAULT_PORT = 16020;
        // 한글 Encoding
		private Encoding encoding = Service.BaseEncoding;
		private string remoteHost, remotePath;
		private HostType remoteHostType;
		private int remotePort;
		private Socket clientSocket;
		private DownloadProgressForm downForm = null;

		private bool connected;

		/// <summary>
		/// SocketTransferClient 생성자
		/// </summary>
		public SocketTransferClient(string host, int port, HostType hostType, DownloadProgressForm downForm)
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
		/// SocketTransferClient 생성자 Overload
		/// </summary>
		public SocketTransferClient(string host, HostType hostType, DownloadProgressForm downForm)
			: this(host, DEFAULT_PORT, hostType, downForm)
		{
		}

		/// <summary>
		/// SocketTransferClient 생성자 Overload
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
				clientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 1000);
				clientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 1000);
			}
			catch(Exception e)
			{
				Debug.WriteLine(e.Message);
				return false;
			}

			try
			{
				clientSocket.Connect(ep);
			}
			catch(Exception e)
			{
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
				if (fullInfo)
					fileList.AddRange(files);
				else
					foreach (string file in fileList)
					{
						string[] fileInfos = file.Split(new Char[] {'\t'});
						fileList.Add(fileInfos[0]);
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
		public DownloadResult Download(string remFileName, string locFileName, long totalBytes)
		{
			FileStream output = null;
			try
			{
				remFileName = RemotePathCnvt(remFileName);

				if (!connected)
					Connect();

				if (locFileName.Equals(""))
					locFileName = remFileName;

				if (!File.Exists(locFileName))
				{
					FileInfo fi = new FileInfo(locFileName);
					// Directory가 없으면 작성
					if (!fi.Directory.Exists)
					{
						Directory.CreateDirectory(fi.DirectoryName);
					}

					Stream st = File.Create(locFileName);
					st.Close();
				}

				output = new FileStream(locFileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);

				byte[] dataBytes;
				long recvBytesCount = 0;

				Send("FDQ" + remFileName);
				while(true)
				{
					dataBytes = Recv();
					if (dataBytes.Length == 0)
						break;
					if (dataBytes.Length == 3)
					{
						if (encoding.GetString(dataBytes) == "FNF")
						{
							output.Close();
							//앞에서 생성한 File Delete (삭제하지 않으면 0byte의 File이 생성되어 Copy됨)
							File.Delete(locFileName);
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

				return DownloadResult.Success;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				output.Close();
				//앞에서 생성한 File Delete (정상적인 File이 아님)
				File.Delete(locFileName);
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
				return false;
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
			int len = clientSocket.Receive(lenBuffer, 0, lenBuffer.Length, SocketFlags.None);
			if (len < 5)
				return null;
			int size = int.Parse(encoding.GetString(lenBuffer));
			byte[] buffer = new byte[size];
			int offset = 0;
			while (size > 0)
			{
				len = clientSocket.Receive(buffer, offset, size, SocketFlags.None);
				offset += len;
				size -= len;
			}
			return buffer;
		}

		private string RecvString()
		{
			byte[] dataBytes = Recv();
			return encoding.GetString(dataBytes);
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
