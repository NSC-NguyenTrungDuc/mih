using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace IHIS
{
	// EventHandler
	/// <summary>
	/// UdpServer로부터 데이타를 Receive시 발생하는 Event를 처리하는 메서드를 나타냅니다.
	/// </summary>
	public delegate void UdpDataReceivedHandler(IPEndPoint remoteEP, byte[] receivedData);

	/// <summary>
	/// UdpServer에 대한 요약 설명입니다.
	/// </summary>
	public class UdpServer
	{
		/// <summary>
		/// UdpServer의 최대 Buffer Size 입니다.
		/// </summary>
		public const int BUFFERSIZE = 102400;	// Max Buffer Size

		private int		portNo;
		private bool	connected = true;
		private	EndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
		private byte[]	buffer = new byte[BUFFERSIZE];
		private byte[]	receivedBytes = null;

		/// <summary>
		/// UdpServer로부터 데이타를 Receive시 발생하는 Event입니다.
		/// </summary>
		public event UdpDataReceivedHandler UdpDataReceived;
		/// <summary>
		/// Port 번호를 가져오거나 설정합니다.
		/// </summary>
		public int PortNo
		{
			get {return portNo;}
			set {portNo = value;}
		}
		/// <summary>
		/// 연결여부를 가져오거나 설정합니다.
		/// </summary>
		public bool Connected
		{
			get {return connected;}
			set {connected = value;}
		}
		/// <summary>
		/// 네트워크 주소를 식별하는 EndPoint를 가져옵니다.
		/// </summary>
		public EndPoint RemoteEP
		{
			get {return remoteEP;}
		}
		/// <summary>
		/// UdpServer로부터 받은 byte[]형식의 Data를 가져옵니다.
		/// </summary>
		public byte[] ReceivedBytes
		{
			get {return receivedBytes;}
		}
		/// <summary>
		/// UdpServer로부터 받은 string형식의 Data를 가져옵니다.
		/// </summary>
		public string ReceivedData
		{
			get
			{
				if (receivedBytes == null)
					return null;
				else
					return Service.BaseEncoding.GetString(receivedBytes);
			}
		}

		/// <summary>
		/// UdpServer 생성자
		/// </summary>
		/// <param name="portNo"> Port 번호 </param>
		public UdpServer(int portNo)
		{
			this.portNo = portNo;
		}
		/// <summary>
		/// 메세지 수신 응답대기를 합니다.
		/// </summary>
		public virtual void Listening()
		{
			try
			{
				// Create a UDP socket.
				Socket soUdp = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
				IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, portNo);
				soUdp.Bind(localEndPoint);

				// Receive operations will timeout of confirmation is not received within 1000 milliseconds.
				soUdp.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 1000);

				while (connected)
				{
					try
					{
						int bytesReceived = 0;
						try
						{
							bytesReceived = soUdp.ReceiveFrom(buffer, ref remoteEP);
						}
						catch (Exception e)
						{
							bool noData = false;
							SocketException se = e as SocketException;
							if (se != null)
							{
								// NoData
								if (se.ErrorCode == 10060)
								{
									noData = true;
									bytesReceived = 0;
									Thread.Sleep(0);
								}
							}
							if (!noData)
								Debug.WriteLine(e.Message);
						}
						if (bytesReceived > 0)
						{
							// Message 수신시 처리
							receivedBytes = new byte[bytesReceived];
							Array.Copy(buffer, 0, receivedBytes, 0, bytesReceived);
							this.OnReceived();
						}
					}
					catch (Exception e)
					{
						Debug.WriteLine("UDP Thread : " + e.Message);
					}
				}
				soUdp.Close();
			}
			catch (Exception e)
			{
				Debug.WriteLine("UDP Thread Error : " + e.Message);
			}
		}

		// 자료수신시 Evnet 호출
		/// <summary>
		/// UdpDataReceived Event를 발생시킵니다.
		/// </summary>
		protected virtual void OnReceived()
		{
			if (UdpDataReceived != null)
				UdpDataReceived((IPEndPoint)remoteEP, receivedBytes);
		}
	}
}