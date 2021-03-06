using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;

namespace IHIS.Framework
{
	/// <summary>
	/// Summary description for XFTPWorker.
	/// </summary>
	public class XFTPWorker
	{
		#region structs
		private struct ResponseStruct 
		{
			public  int     ResponseCode;
			public  string  ResponseMessage;
		}

		public struct DirItems
		{
			public string	Filename;
			public bool		IsFile;  //File인지 Dir인지 여부 (File이면 true, Dir이면 false)
			public string	Permission ;
			public string	Size ;
		}
		#endregion

		#region Fields and Properties
		private bool connected = false;
		private Socket s ;
		private ResponseStruct resp_struct ;
		private Encoding DEFAULT_ENCODING = Encoding.Default;
		const int TRANSFER_BUFFER_SIZE = 10*1024;
		const int READ_BUFFER_SIZE = 512 ;
		const string MSG_TITLE = "FTP Worker";
		private DataAsyncSocket dataAsyncSocket;  //대용량 데이타 전송 AsyncSocket
		private ProgressForm prog_Form = null;
		private bool showProgressForm = true; //Upload시에 ProgressForm을 보여줄지 여부를 지정합니다.
        private HostType serverType = HostType.Windows;

		public bool Connected
		{
			get { return connected; }
		}
		[DefaultValue(true)]
		public bool ShowProgressForm
		{
			get { return showProgressForm;}
			set { showProgressForm = value;}
		}
		#endregion

		#region Event (대량 데이타 전송 완료시 발생하는 이벤트)
		public event DataTransferCompletedEventHandler DataTransferCompleted;
		protected virtual void OnDataTransferCompleted(DataTransferCompletedEventArgs e)
		{
			if (DataTransferCompleted != null)
				DataTransferCompleted(this, e);
		}
		#endregion

		#region 생성자, 소멸자
		public XFTPWorker(string user, string pswd, string serverIP)
            : this(user, pswd, serverIP, HostType.UNIX) { }
        public XFTPWorker(string user, string pswd, string serverIP, HostType serverType)
        {
            this.serverType = serverType;

			resp_struct = new ResponseStruct();
			try
			{
				s = new Socket(AddressFamily.InterNetwork , SocketType.Stream, ProtocolType.Tcp);	
				IPEndPoint iep = new IPEndPoint(IPAddress.Parse(serverIP) , 21);
				s.Connect(iep);
				Response();

				LoginUser(user);
				resp_struct = AuthenticateUser(pswd);
				//성공 230, 실패 530
				if (resp_struct.ResponseCode != 230)
				{
					string msg = XMsg.GetMsg("M057"); // FTP 서버에 접속하지 못했습니다.[사용자,비밀번호 확인]
					XMessageBox.Show(msg, MSG_TITLE);
					return;
				}
				connected = true;
			}
			catch(Exception xe)
			{
				XMessageBox.Show(xe.Message , MSG_TITLE);
				connected = false;
				return ;
			}
		}

		~XFTPWorker()
		{
			if (s != null)
				s.Close();
		}
		public void Close()
		{
			try
			{
				if (s != null)
				{
					s.Close();
					s = null;
				}
			}
			catch { }
		}
		#endregion

		#region Private Methods
		private void LoginUser(string user)
		{
			string command = "USER " + user + "\r\n";
			byte[] sBytes = DEFAULT_ENCODING.GetBytes(command);
			s.Send(sBytes, sBytes.Length, 0);
			Response();
		}

		private ResponseStruct AuthenticateUser(string pswd)
		{
			string command = "PASS " + pswd + "\r\n" ;
			byte[] sBytes = DEFAULT_ENCODING.GetBytes(command);
			s.Send(sBytes, sBytes.Length, 0);
			return Response();
		}

		private ResponseStruct Response()
		{
			ResponseStruct  response;
			Byte[] readBytes;

			bool ret = s.Poll(3000, SelectMode.SelectRead);
			
			string serverMessage="";
			int sizeReceived=0;

			do 
			{
				readBytes = new Byte[512];
				sizeReceived  = s.Receive(readBytes);

				if ( sizeReceived == 0 ) break;
				serverMessage  += DEFAULT_ENCODING.GetString(readBytes, 0, sizeReceived);
			}
			while( sizeReceived == readBytes.Length );

		
			if ( serverMessage == "" ) return (new ResponseStruct()) ;


			System.Diagnostics.Debug.WriteLine( "Response Message: " + serverMessage );


			bool foundLastLine ;
			response.ResponseCode = Convert.ToInt32(serverMessage.Substring(0,3));
			if (serverMessage[3] == '-' & serverMessage.IndexOf("\r\n"+ response.ResponseCode + ' ') == -1) 
			{
				do 
				{
					readBytes = new Byte[512];
					sizeReceived  = s.Receive(readBytes);
					serverMessage  += DEFAULT_ENCODING.GetString(readBytes, 0, sizeReceived);

					foundLastLine = serverMessage.IndexOf("\r\n"+ response.ResponseCode + ' ') > 0;
				}
				while (!foundLastLine | !serverMessage.EndsWith("\r\n")); // Go back for more if necessary
			}

			// Extract the code and message
			response.ResponseCode    = Convert.ToInt32(serverMessage.Substring(0,3));
			response.ResponseMessage = serverMessage.Substring(4,serverMessage.Length-6); // Ignore the <CRLF>

			return response ;
		}
		private void ChangeMode(string param)
		{
			string command ="";
			command = "TYPE " + param ;
			command +="\r\n" ;
			byte[] sBytes = DEFAULT_ENCODING.GetBytes(command);
			s.Send(sBytes, sBytes.Length, 0);
			Response();
		}

		private void SystemInfo()
		{
			string command = "SYST";
			command +="\r\n" ;
			byte[] sBytes = DEFAULT_ENCODING.GetBytes(command);
			s.Send(sBytes, sBytes.Length, 0);
			Response();
		}
		private Socket GetDataSocket () 
		{
			try
			{
				Socket pasvSocket;  
				string  command = "PASV";
				command += "\r\n";
				byte[] sBytes = DEFAULT_ENCODING.GetBytes(command);
				s.Send(sBytes, sBytes.Length, 0);
				ResponseStruct response = Response();

				// Get host and port address
				string fullAddress = response.ResponseMessage;
				fullAddress = fullAddress.Remove(0, fullAddress.IndexOf('(') + 1);
				fullAddress = fullAddress.Substring(0, fullAddress.IndexOf(')'));
				string[] addressParts = fullAddress.Split(',');
				string pasvAddress = addressParts[0] + "." + addressParts[1] + "." + addressParts[2] + "." + addressParts[3];
				int    pasvPort    = Convert.ToInt32(addressParts[4]) * 256 + Convert.ToInt32(addressParts[5]);
	
  
				// Open the Data socket
				pasvSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				pasvSocket.Connect(new IPEndPoint(IPAddress.Parse(pasvAddress), pasvPort));

				return pasvSocket;
			}
			catch(Exception xe)
			{
				Debug.WriteLine("XFTPWorker::GetDataSocket Error=" + xe.Message);
			}

			return null;
			
		}
		//대용량 전송 AsyncSocket Get
		private DataAsyncSocket GetDataAsyncSocket()
		{
			try
			{
				string  command = "PASV";
				command += "\r\n";
				byte[] sBytes = DEFAULT_ENCODING.GetBytes(command);
				s.Send(sBytes, sBytes.Length, 0);
				ResponseStruct response = Response();

				// Get host and port address
				string fullAddress = response.ResponseMessage;
				fullAddress = fullAddress.Remove(0, fullAddress.IndexOf('(') + 1);
				fullAddress = fullAddress.Substring(0, fullAddress.IndexOf(')'));
				string[] addressParts = fullAddress.Split(',');
				string pasvIP = addressParts[0] + "." + addressParts[1] + "." + addressParts[2] + "." + addressParts[3];
				int    pasvPort  = Convert.ToInt32(addressParts[4]) * 256 + Convert.ToInt32(addressParts[5]);
				DataAsyncSocket socket = new DataAsyncSocket(this);
				socket.Connect(pasvIP, pasvPort);
				return socket;
			}
			catch(Exception xe)
			{
				Debug.WriteLine("XFTPWorker::GetDataAsyncSocket Error=" + xe.Message);
			}
			return null;

		}
		private void TransferData(bool isDownload, string clientFileName, string serverFileName, int fileSize) 
		{
			try
			{
				// Open the Data socket
				dataAsyncSocket.ClientFileName = clientFileName;
				dataAsyncSocket.ServerFileName = serverFileName;
				dataAsyncSocket.FileSize = fileSize;
				if (isDownload)
					dataAsyncSocket.DataCommand = 1;  //Download
				else
					dataAsyncSocket.DataCommand = 2; //Upload
				dataAsyncSocket.TransferData();
			}
			catch(Exception xe)
			{
				Debug.WriteLine("XFTPWorker::TransferData Error=" + xe.Message);
			}
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// 현재 Server의 Dir을 가져옵니다.
		/// </summary>
		/// <returns></returns>
		public string GetCurrentDir()
		{
			try
			{
				string command ="";
				command = "PWD\r\n" ;
				byte[] sBytes = DEFAULT_ENCODING.GetBytes(command);
				s.Send(sBytes, sBytes.Length, 0);
				resp_struct = Response();
				string[] mItems = resp_struct.ResponseMessage.Split('"');
				return mItems[1];
			}
			catch
			{
				return string.Empty;
			}
		}

		public bool ChangeDir(string mDir)
		{
			try
			{
				string command = "CWD " + mDir ;
				command +="\r\n" ;
				byte[] sBytes = DEFAULT_ENCODING.GetBytes(command);
				s.Send(sBytes, sBytes.Length, 0);
				resp_struct = Response();
				// error : 550, normal : 250
				if (resp_struct.ResponseCode == 250)
					return true;
				else
					return false;
			}
			catch(Exception xe)
			{
				string msg = XMsg.GetMsg("M058",xe); // 디렉토리 변경에러[" + xe.Message + "]"
				XMessageBox.Show(msg, MSG_TITLE);
				return false;
			}
		}
		
		public ArrayList GetDirList(bool upperDirDisplay)
		{
			try
			{

				string command ="";
				Socket sss = GetDataSocket ();
				command = "LIST";
				command +="\r\n" ;
				byte[] sBytes = DEFAULT_ENCODING.GetBytes(command);
				s.Send(sBytes, sBytes.Length, 0);

				Response();
	
				Byte[] readBytes;
				int sizeReceived;
				string serverMessage = "";
				do 
				{
					readBytes       = new Byte[READ_BUFFER_SIZE];
					sizeReceived    = sss.Receive(readBytes, readBytes.Length, SocketFlags.None);
					serverMessage  += DEFAULT_ENCODING.GetString(readBytes, 0, sizeReceived);
					if ( sizeReceived == 0 ) break ; 
				}
				while (true);  //sizeReceived == readBytes.Length & !serverMessage.EndsWith("\r\n")); // Go back for more if necessary
				
				//DataSocket을 닫고 Response를 해야 Lock 발생하지 않음
				sss.Close();

				//sss.Close()를 뒤에 쓰면 Response에서 Receive()에서 Lock 발생
				Response();
				
				
				
				//Parsing Message
				ArrayList iList = new ArrayList();
				string[] filelist = serverMessage.Split('\n');
				int nTotal = filelist.Length;
				DirItems newItem;

				
				if (nTotal <= 0) return iList;
			
				//FTP Data로는 상위 Dir(..)이 보이지 않으므로 ..으로 설정
				if (upperDirDisplay)
				{
					newItem = new DirItems();
					newItem.Filename = "..";
					newItem.IsFile = false;
					newItem.Permission = "";
					newItem.Size = "0";
					iList.Add(newItem);  //List Add
				}
                if (this.serverType == HostType.Windows)  //Window
                {
                    for (int cnt = 0; cnt < nTotal; cnt++)
                    {
                        string mWork = filelist[cnt];
                        if (mWork == "") continue;

                        if (mWork.IndexOf('\r') > 0)
                            mWork = mWork.Substring(0, mWork.Length - 1);
                        ArrayList ItemList = new ArrayList();
                        string smk = mWork;
                        while (true)
                        {
                            int pos = smk.IndexOf("  ");
                            if (pos < 0) break;
                            string leftstr = smk.Substring(0, pos);
                            string rightstr = smk.Substring(pos + 1);
                            smk = leftstr + rightstr;
                        }
                        mWork = smk;
                        string[] tmpList = mWork.Split(' ');

                        /*mWork의 형태는 
                         * 09-22-06  11:35AM       <DIR>          ADM
                         * 09-07-06  05:29PM                24576 ADM.ADMRegDictionary.dll
                         * tmpList는 총 4개
                        */
                        if (tmpList.Length < 4)
                            continue;

                        ItemList.Add(tmpList[0]); //날짜
                        ItemList.Add(tmpList[1]); //시간
                        ItemList.Add(tmpList[2]); //<DIR> Directory, 파일은 File Size
                        ItemList.Add(tmpList[3]);

                        //Dir 정보 생성
                        newItem = new DirItems();

                        newItem.Filename = ItemList[ItemList.Count - 1].ToString();
                        newItem.IsFile = (ItemList[2].ToString() == "<DIR>" ? false : true);
                        newItem.Size = ItemList[2].ToString();

                        iList.Add(newItem);
                    }
                }
                else
                {
                    for (int cnt = 0; cnt < nTotal; cnt++)
                    {
                        string mWork = filelist[cnt];
                        if (mWork == "") continue;

                        if (mWork.IndexOf('\r') > 0)
                            mWork = mWork.Substring(0, mWork.Length - 1);
                        ArrayList ItemList = new ArrayList();
                        string smk = mWork;
                        while (true)
                        {
                            int pos = smk.IndexOf("  ");
                            if (pos < 0) break;
                            string leftstr = smk.Substring(0, pos);
                            string rightstr = smk.Substring(pos + 1);
                            smk = leftstr + rightstr;
                        }
                        mWork = smk;
                        string[] tmpList = mWork.Split(' ');

						if (tmpList.Length < 6) // ** Dummy Data 이므로 처리하지 않음
							continue;

                        /*mWork의 형태는
                        drwxrwxrwx   3 issdown    medinfo         96 10월 21일 15:12 ADM
                        drwxrwxrwx   3 issdown    medinfo         96 2004.05.25   EXAM
                        -rw-rw-rw-   1 issdown    medinfo     983040 11월 18일 17:53 Pbshr100.dll
                        [0] = permission, [1] = 1이면 file, 그외는 Dir, [2] owner, [3] = group [4] = size, [마지막] = name 날짜는 좀 애매함
                        현재 Server의 날짜 형식이 여러가지라서 정확한 Parsing이 안됨 (한글도 깨어짐)
                         0월 21일 15:12, 2004.05.25 , 등 여러가지라서 tmpList의 갯수가 9개, 7개로 둘쑥날쑥함.
                        */

                        ItemList.Add(tmpList[0]);
                        ItemList.Add(tmpList[1]);
                        ItemList.Add(tmpList[2]);
                        ItemList.Add(tmpList[3]);
                        ItemList.Add(tmpList[4]);
                        ItemList.Add(tmpList[5]);
                        if (tmpList.Length > 6)   //tmpList의 Length가 가변적이므로 Length Check
                            ItemList.Add(tmpList[6]);
                        if (tmpList.Length > 7)
                            ItemList.Add(tmpList[7]);
                        if (tmpList.Length > 8)
                        {
                            string listStr = "";
                            for (int i = 8; i < tmpList.Length; i++)
                                listStr += tmpList[i] + " ";
                            ItemList.Add(listStr.TrimEnd());
                        }

                        //Dir 정보 생성
                        newItem = new DirItems();

                        newItem.Filename = ItemList[ItemList.Count - 1].ToString();
                        newItem.IsFile = ItemList[1].ToString() == "1" ? true : false;
                        newItem.Permission = ItemList[0].ToString();
                        newItem.Size = ItemList[4].ToString();

                        iList.Add(newItem);
                    }
                }
				return iList;
			}
			catch(Exception xe)
			{
				string msg = XMsg.GetMsg("M059") + "\n\nError[" + xe.Message + "]";  // 서버 리스트를 구성하는데 실패하였습니다." + "\r\n" + "에러[" + xe.Message + "]"
				XMessageBox.Show(msg, MSG_TITLE);
				return new ArrayList();
			}
		}
		
		public bool SendFileToServer(string clientFullName, string serverFileName)
		{
			string msg = "";
			try
			{
				if (!File.Exists(clientFullName))
				{
					msg = XMsg.GetMsg("M060") + "[" + clientFullName + "]";  //파일이 존재하지 않습니다.[ + clientFullName + ]
					XMessageBox.Show(msg, MSG_TITLE);
					return false;
				}

				//전송모드 설정
				ChangeMode("I");

				FileStream oFileStream = new FileStream(clientFullName, FileMode.Open);

				Socket sss = GetDataSocket ();
				if (this.showProgressForm)
					prog_Form = new ProgressForm();
				string command ="";
				command = "STOR " + serverFileName;
				command +="\r\n" ;
				byte[] sBytes = DEFAULT_ENCODING.GetBytes(command);
				s.Send(sBytes, sBytes.Length, 0);
				Response();

				Byte[] readBytes;
				int sizeReceived;
				ArrayList byteArray = new ArrayList();
				int bytesRead;
				FileInfo fi = new FileInfo(clientFullName);
				if (this.showProgressForm)
				{
					prog_Form.Init((int) fi.Length, "Sending " + clientFullName);
					prog_Form.Show();
				}
				int ntotalBytes = 0 ;

				do 
				{
					readBytes       = new Byte[TRANSFER_BUFFER_SIZE];
					bytesRead		= oFileStream.Read(readBytes , 0  , readBytes.Length);
					if ( bytesRead == 0 ) break ; 
					sizeReceived    = sss.Send(readBytes, 0, bytesRead, SocketFlags.None);
					ntotalBytes += bytesRead;
					if (this.showProgressForm)
						prog_Form.MoveProgress(ntotalBytes, "Transferred  " + ntotalBytes + " of " + fi.Length + " bytes (" + clientFullName + ")" );
				}
				while ( true);


				if (prog_Form != null)
					prog_Form.Dispose();
				oFileStream.Close();
				sss.Close();

				Response();
				
			}
			catch(Exception xe)
			{
				if (prog_Form != null)
					prog_Form.Dispose();
				msg = XMsg.GetMsg("M061", xe); //파일전송에러[" + xe.Message + "]"
				XMessageBox.Show(msg , MSG_TITLE);
				return false;
			}
			return true;
		}
		
		//대용량 데이타 Upload
		public bool SendLargeFileToServer(string clientFullName, string serverFileName)
		{
			string msg = "";
			try
			{
				if (!File.Exists(clientFullName))
				{
					msg = XMsg.GetMsg("M060") + "[" + clientFullName + "]";  //파일이 존재하지 않습니다.[ + clientFullName + ]
					XMessageBox.Show(msg, MSG_TITLE);
					return false;
				}

				//전송모드 설정
				ChangeMode("I");

				//Data 전송 AsyncSocket Get 실패시 return
				this.dataAsyncSocket = GetDataAsyncSocket();
				
				if (dataAsyncSocket == null) return false;
				if (this.showProgressForm)
					prog_Form = new ProgressForm();

				string command ="";
				command = "STOR " + serverFileName;
				command +="\r\n" ;
				byte[] sBytes = DEFAULT_ENCODING.GetBytes(command);
				s.Send(sBytes, sBytes.Length, 0);
				Response();

				FileInfo fi = new FileInfo(clientFullName);
				
				if (this.showProgressForm)
				{
					prog_Form.Init((int) fi.Length, "Sending " + clientFullName);
					prog_Form.Show();
				}

				//데이타 전송 ASyncSocket으로 데이타 Upload
				this.TransferData(false, clientFullName, serverFileName, (int)fi.Length);
			}
			catch(Exception xe)
			{
				msg = XMsg.GetMsg("M061", xe); //파일전송에러[" + xe.Message + "]"
				XMessageBox.Show(msg , MSG_TITLE);
				return false;
			}
			return true;
		}

		public bool SendFileToClient(string serverFileName, string clientFileName)
		{
			string msg = "";
			try
			{
				string command ="";

				command = "SIZE " + serverFileName + "\r\n";
				byte[] sBytes = DEFAULT_ENCODING.GetBytes(command);
				s.Send(sBytes, sBytes.Length, 0);
				resp_struct = Response();
				//서버파일 잘못 지정
				if (resp_struct.ResponseCode == 550) //No such file or directory
				{
					msg = XMsg.GetMsg("M062") + "[" + serverFileName + "]";   //"서버파일[" + serverFileName + "]을 잘못 지정하였습니다."
					XMessageBox.Show(msg , MSG_TITLE);
					return false;
				}
				long filesize = 0;
				try
				{
					//SIZE에 정확히 응답했으면 Msg에 Size가 오는데, 그외의 경우에는 에러처리함
					filesize = long.Parse(resp_struct.ResponseMessage);
				}
				catch
				{
					msg = XMsg.GetMsg("M062") + "[" + serverFileName + "]";   //"서버파일[" + serverFileName + "]을 잘못 지정하였습니다."
					XMessageBox.Show(msg , MSG_TITLE);
					return false;
				}

				//전송모드 설정
				ChangeMode("I");
				
				//현재 Dir에 DownLoad
				string targetFile = Directory.GetCurrentDirectory() + "\\" + clientFileName;
				FileStream oFileStream = new FileStream(targetFile , FileMode.Create);

				Socket sss = GetDataSocket ();
				if (this.showProgressForm)
					prog_Form = new ProgressForm();
				command = "RETR " + serverFileName ;
				command +="\r\n" ;
				sBytes = DEFAULT_ENCODING.GetBytes(command);
				s.Send(sBytes, sBytes.Length, 0);
				Response();

				Byte[] readBytes;
				int sizeReceived;
				ArrayList byteArray = new ArrayList();
				int totalBytes = 0;

				if (this.showProgressForm)
				{
					prog_Form.Init((int) filesize, "Receiving " + targetFile);
					prog_Form.Show();
				}
				int count = 0;
				do 
				{
					readBytes       = new Byte[TRANSFER_BUFFER_SIZE];
					sizeReceived  = sss.Receive(readBytes, readBytes.Length, SocketFlags.None);
					//serverMessage  += DEFAULT_ENCODING.GetString(readBytes, 0, sizeReceived);
					oFileStream.Write(readBytes,0,sizeReceived);
					totalBytes = totalBytes + sizeReceived;
					if ( sizeReceived == 0) break;
					if (this.showProgressForm)
						prog_Form.MoveProgress(totalBytes, "Received  " + totalBytes + " of " + filesize + " bytes (" + serverFileName + ")");
					count++;
				}
				while (true); // Go back for more if necessary

				if (prog_Form != null)
					prog_Form.Dispose();
				oFileStream.Close();
				sss.Close();
				Response();
			}
			catch(Exception xe)
			{
				if (prog_Form != null)
					prog_Form.Dispose();
				msg = XMsg.GetMsg("M063",xe); // "파일수신에러[" + xe.Message + "]"
				XMessageBox.Show(msg , MSG_TITLE);
				return false;
			}
			return true;
		}
		public bool SendFileToClient(string serverFileName)
		{
			return SendFileToClient(serverFileName, serverFileName);
		}
		
		public bool SendLargeFileToClient(string serverFileName)
		{
			return SendLargeFileToClient(serverFileName, serverFileName);
		}
		//대용량 데이타 Download
		public bool SendLargeFileToClient(string serverFileName, string clientFileName)
		{
			string msg = "";
			try
			{
				string command ="";

				command = "SIZE " + serverFileName + "\r\n";
				byte[] sBytes = DEFAULT_ENCODING.GetBytes(command);
				s.Send(sBytes, sBytes.Length, 0);
				resp_struct = Response();
				//서버파일 잘못 지정
				if (resp_struct.ResponseCode == 550) //No such file or directory
				{
					msg = XMsg.GetMsg("M062") + "[" + serverFileName + "]";   //"서버파일[" + serverFileName + "]을 잘못 지정하였습니다."
					XMessageBox.Show(msg , MSG_TITLE);
					return false;
				}
				int filesize = 0;
				try
				{
					//SIZE에 정확히 응답했으면 Msg에 Size가 오는데, 그외의 경우에는 에러처리함
					filesize = int.Parse(resp_struct.ResponseMessage);
				}
				catch
				{
					msg = XMsg.GetMsg("M062") + "[" + serverFileName + "]";   //"서버파일[" + serverFileName + "]을 잘못 지정하였습니다."
					XMessageBox.Show(msg , MSG_TITLE);
					return false;
				}

				//전송모드 설정
				ChangeMode("I");

				//Data 전송 IP와 Port 가져오기 실패시 return
				this.dataAsyncSocket = GetDataAsyncSocket();
				
				if (dataAsyncSocket == null) return false;
				if (this.showProgressForm)
					prog_Form = new ProgressForm();

				command = "RETR " + serverFileName ;
				command +="\r\n" ;
				sBytes = DEFAULT_ENCODING.GetBytes(command);
				s.Send(sBytes, sBytes.Length, 0);
				Response();

				if (this.showProgressForm)
				{
					prog_Form.Init(filesize, "Recieving " + Directory.GetCurrentDirectory() + "\\" + clientFileName);
					prog_Form.Show();
				}

				this.TransferData(true, clientFileName, serverFileName, filesize);

			}
			catch(Exception xe)
			{
				if (prog_Form != null)
					prog_Form.Close();
				msg = XMsg.GetMsg("M063",xe); // "파일수신에러[" + xe.Message + "]"
				XMessageBox.Show(msg , MSG_TITLE);
				return false;
			}
			return true;
		}

		public bool DeleteFile(string fileName)
		{
			try
			{
				string command ="";
				command = "DELE " + fileName ;
				command +="\r\n" ;
				byte[] sBytes = DEFAULT_ENCODING.GetBytes(command);
				s.Send(sBytes, sBytes.Length, 0);
				Response();
			}
			catch(Exception xe)
			{
				string msg = XMsg.GetMsg("M064",xe); // 파일삭제에러[" + xe.Message + "]"
				XMessageBox.Show(msg , MSG_TITLE);
				return false;
			}
			return true;
		}
		public bool MakeDir(string dirName)
		{
			try
			{
				string command = "MKD " + dirName  + "\r\n";
				byte[] sBytes = DEFAULT_ENCODING.GetBytes(command);
				s.Send(sBytes, sBytes.Length, 0);
				Response();
			}
			catch(Exception xe)
			{
				string msg = XMsg.GetMsg("M065",xe); // 디렉토리생성에러[" + xe.Message + "]"
				XMessageBox.Show(msg , MSG_TITLE);
				return false;
			}
			return true;
		}
		public bool DeleteDir(string dirName)
		{
			try
			{
				string command = "RMD " + dirName  + "\r\n";
				byte[] sBytes = DEFAULT_ENCODING.GetBytes(command);
				s.Send(sBytes, sBytes.Length, 0);
				Response();
			}
			catch(Exception xe)
			{
				string msg = XMsg.GetMsg("M066",xe); // 디렉토리삭제에러[" + xe.Message + "]"
				XMessageBox.Show(msg , MSG_TITLE);
				return false;
			}
			return true;
		}
		public bool Rename(string oldName, string newName)
		{	
			try
			{
				string command ="";
				command = "RNFR " + oldName + "\r\n" ;
				byte[] sBytes = DEFAULT_ENCODING.GetBytes(command);
				s.Send(sBytes, sBytes.Length, 0);
				Response();

				command = "RNTO " + newName + "\r\n" ;
				sBytes = DEFAULT_ENCODING.GetBytes(command);
				s.Send(sBytes, sBytes.Length, 0);
				Response();
			}
			catch(Exception xe)
			{
				string msg = XMsg.GetMsg("M067",xe); // 파일명변경에러[" + xe.Message + "]"
				XMessageBox.Show(msg , MSG_TITLE);
				return false;
			}
			return true;
		}
		public bool ExistFile(string fileName)
		{
			try
			{
				string command ="";
				command = "RETR " + fileName + "\r\n" ;
				byte[] sBytes = DEFAULT_ENCODING.GetBytes(command);
				s.Send(sBytes, sBytes.Length, 0);
				ResponseStruct resp = Response();
				//550 File Not Exist
				if (resp.ResponseCode == 550)
					return false;
			}
			catch
			{
				return false;
			}
			return true;
		}
		#endregion

		#region TranferCompleted, SetTranferRate (대량 데이타 전송 관련)
		internal void TranferCompleted(int cmdMode)
		{
			//
			if (this.dataAsyncSocket != null)
				this.dataAsyncSocket.Disconnect();

			//응답처리 (전송완료 Msg Get)
			Response();

			//Progress Form Close
			if (prog_Form != null && prog_Form.Visible)
			{
				prog_Form.Close();
				prog_Form = null;
			}

			//전송완료 Event Call
			OnDataTransferCompleted(new	DataTransferCompletedEventArgs((cmdMode == 1)));
		}
		internal void SetTranferRate(int cmdMode, string fileName, int totalBytes, int sendBytes)
		{
			//cmdMode 1.Download, 2.Upload
			if (this.prog_Form != null && prog_Form.Visible)
			{
				string msg = "";
				if (cmdMode == 1)  //Download
					msg = "Recieved  " + sendBytes + " of " + totalBytes + " bytes (" + fileName + ")";
				else  //Upload
					msg = "Transferred " + sendBytes + " of " + totalBytes + " bytes (" + fileName + ")";
				prog_Form.MoveProgress(sendBytes, msg);
			}
	
		}
		#endregion
	}

	#region DataTransferCompletedEventHandler
	/// <summary>
	/// 데이타의 유효성 검사를 하는 발생 이벤트를 처리하는 메서드를 나타냅니다.
	/// </summary>
	[Serializable]
	public delegate void DataTransferCompletedEventHandler(object sender, DataTransferCompletedEventArgs e);
	
	/// <summary>
	/// 대량 데이타 전송완료시 발생하는 이벤트의 Argument
	/// </summary>
	public class DataTransferCompletedEventArgs : EventArgs
	{
		bool isDownload;
		/// <summary>
		/// DownLoad 완료인지, Upload 완료인지 여부
		/// </summary>
		public bool IsDownload
		{
			get { return isDownload; }
		}
		/// <summary>
		/// ValidateEventArgs 생성자
		/// </summary>
		/// <param name="cancel"> Event 취소여부 </param>
		/// <param name="dataValue"> 데이타 값 </param>
		public DataTransferCompletedEventArgs(bool isDownload)
		{
			this.isDownload = isDownload;
		}
	}
	#endregion


	#region DataAsyncSocket (대량 데이타 전송 Socket)
	internal class DataAsyncSocket
	{
		#region DataStateObject
		// State object for receiving data from remote device.
		private class DataStateObject 
		{
			public Socket WorkSocket = null;               // Client socket.
			public const int BUFFER_SIZE = 100*1024;       // Size of receive buffer.
			public byte[] DownloadBuffer = new byte[BUFFER_SIZE];  // Receive buffer.
			public FileStream FStream = null;			  // File Stream Input / Output
			public int BytesTransfered = 0;				  // Nb bytes transfered
			public byte[] UploadBuffer;					  //Upload Buffer
		}
		#endregion

		#region Fields and Property
		private int dataCommand = 0;
		private Socket dataSocket;
		private string clientFileName;
		private string serverFileName;
		private long fileSize;
		private XFTPWorker ftpWorker;

		public string ClientFileName
		{
			get { return clientFileName;}
			set { clientFileName = value;}
		}
		public string ServerFileName
		{
			get { return serverFileName;}
			set { serverFileName = value;}
		}

		public long FileSize
		{
			get	{return fileSize;}
			set { fileSize = value;}
		}
		public int DataCommand
		{
			get	{return dataCommand;}
			set	{dataCommand = value;}
		}
		#endregion

		#region 생성자
		public DataAsyncSocket(XFTPWorker ftpWorker)
		{
			this.ftpWorker = ftpWorker;
		}
		#endregion
		
		#region Connect, TransferData, DisConnect
		public void Connect(string serverIP, int port)
		{
			IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(serverIP), port);

			//  Create a TCP/IP  socket.
			dataSocket = new Socket(AddressFamily.InterNetwork,	SocketType.Stream, ProtocolType.Tcp);

			// Connect to the remote endpoint.
			dataSocket.BeginConnect( remoteEP, 	new AsyncCallback(ConnectCallback), dataSocket);
		}
		private void ConnectCallback(IAsyncResult ar) 
		{
			Socket sock = (Socket) ar.AsyncState;

			// Complete the connection.
			sock.EndConnect(ar);
		}

		//DataSocket Close
		public void Disconnect()
		{
			dataSocket.Close();
		}

		public void TransferData()
		{
			//Data 전송 (Upload, Download)
			if (dataCommand == 1)  //Download
				ReceiveFile();
			else if (dataCommand == 2) //Upload
				SendFile();
		}

		

		private void ReceiveFile()
		{
			DataStateObject state = new DataStateObject();
			state.WorkSocket = dataSocket;
			state.FStream = new FileStream(clientFileName, FileMode.Create);
			state.BytesTransfered = 0;
			//Async Receive Start
			dataSocket.BeginReceive(state.DownloadBuffer, 0, DataStateObject.BUFFER_SIZE, 0,
				new AsyncCallback(ReceiveFileCallback), state);
		}
		private void ReceiveFileCallback( IAsyncResult ar ) 
		{
			DataStateObject state = (DataStateObject) ar.AsyncState;
			Socket sock = state.WorkSocket;

			// Read data from the remote device.
			int bytesRead = sock.EndReceive(ar);

			// There might be more data, so store the data received so far.
			state.FStream.Write(state.DownloadBuffer, 0, bytesRead);
			state.BytesTransfered  += bytesRead;

			if ((state.BytesTransfered >= fileSize) || (bytesRead == 0))
			{
				sock.Close();
				state.FStream.Close();
				ftpWorker.TranferCompleted(1);  //ftpWorker에 Download 완료 SET
			}
			else 
			{
				//ftpWorker에 전송 byte를 알림
				ftpWorker.SetTranferRate(1, this.clientFileName, (int)this.fileSize, state.BytesTransfered);
				//  Get the rest of the data.
				sock.BeginReceive(state.DownloadBuffer,0, DataStateObject.BUFFER_SIZE,0,
					new AsyncCallback(ReceiveFileCallback), state);
			}
		}

		private void SendFile()
		{
			DataStateObject state = new DataStateObject();
			state.WorkSocket = dataSocket;
			state.FStream = new FileStream(clientFileName, FileMode.Open);
			state.BytesTransfered = 0;

			fileSize = (int)state.FStream.Length;
			//Upload는 전송할 Stream 전체 buffer size로 설정하여 Read하여 한번에 전송
			//전송할 Stream 전체를 메모리를 할당하면 Memory 사용이 많아 진다. 따라서, BUFFER_SIZE단위로 
			//여러번 전송한다.
			int length = (int) Math.Min(fileSize, DataStateObject.BUFFER_SIZE);
			state.UploadBuffer = new byte[length];

			state.FStream.Read(state.UploadBuffer, 0, length);
			//다음 Stream 위치로 이동
			state.FStream.Seek(length, SeekOrigin.Begin);

			// Begin sending the data.
			dataSocket.BeginSend( state.UploadBuffer, 0, length, 0,
				new AsyncCallback(SendFileCallback), state);
		}

		private void SendFileCallback(IAsyncResult ar) 
		{
			// Retrieve the socket from the state object.
			DataStateObject state = (DataStateObject) ar.AsyncState;
			Socket sock = state.WorkSocket;

			// Complete sending the data to the remote device.
			int bytesSent = sock.EndSend(ar);

			state.BytesTransfered  += bytesSent;

			int length = 0;
			//전송한 Size가 FileSize보다 작으면 다음 Stream 전송
			if (state.BytesTransfered < fileSize)
			{
				//보낼 길이는 보낼값과 기본값중 작은값
				length = (int) Math.Min(fileSize - state.BytesTransfered, DataStateObject.BUFFER_SIZE);
				state.UploadBuffer = new byte[length];
				state.FStream.Read(state.UploadBuffer, 0, length);
				//다음 Stream 위치로 이동
				state.FStream.Seek(state.BytesTransfered + length, SeekOrigin.Begin);

			}

			//전송완료
			if ((state.BytesTransfered >= fileSize) || (bytesSent == 0))
			{
				sock.Close();
				state.FStream.Close();
				ftpWorker.TranferCompleted(2);  //Upload 완료 SET
			}
			else 
			{	
				ftpWorker.SetTranferRate(2, this.clientFileName, (int) this.fileSize, state.BytesTransfered);

				//나머지 전송
				dataSocket.BeginSend(state.UploadBuffer, 0, length, 0,
					new AsyncCallback(SendFileCallback), state);
			}
		}
		#endregion
	}
	#endregion
}
