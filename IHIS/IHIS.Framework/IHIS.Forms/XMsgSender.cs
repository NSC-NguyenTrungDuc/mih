using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Text;

namespace IHIS.Framework
{
	/// <summary>
	/// XMsgSender에 대한 요약 설명입니다.
	/// </summary>
	public class XMsgSender
	{
		static UdpMessage udpMsg = null;
		static XMsgSender()
		{
			//udpMsg Set
			udpMsg = new UdpMessage();
		}
		public static bool SendToIHIS(string ip, string msg)
		{
			return SendMsg(UdpMsgType.IMG, ip, "","","", msg);
		}
		public static bool SendToSystem(string ip, string systemID, string command, string msg)
		{
			return SendMsg(UdpMsgType.SMG, ip, systemID,"",command, msg);
		}
		public static bool SendToScreen(string ip, string screenID, string command, string msg)
		{
			return SendMsg(UdpMsgType.SCM, ip, "",screenID,command, msg);
		}
		public static bool SendMsg(UdpMsgType msgType, string ip, string systemID, string screenID, string command, string msg)
		{
			try
			{
				//Property 설정
				udpMsg.Message	= msg;
				udpMsg.SenderID = UserInfo.UserID;
				udpMsg.SenderName = UserInfo.UserName;
				udpMsg.MsgType = msgType;
				udpMsg.SystemID = systemID;
				udpMsg.ScreenID = screenID;
				udpMsg.Command = command;
				byte[] sendBytes = udpMsg.ToByteArray();

				UdpClient udp = new UdpClient();
				IPAddress sendIP = IPAddress.Parse(ip);
				udp.Send(sendBytes, sendBytes.Length, new IPEndPoint(sendIP, EnvironInfo.UdpPort));
				udp.Close();
			}
			catch(Exception xe)
			{
				Logs.WriteLog("XMsgSender::SendMsg ip[" + ip + "] MsgType[" + msgType.ToString() + "]에러=" + xe.Message);
				Logs.WriteLog("XMsgSender::SendMsg StackTrace=" + xe.StackTrace);
				return false;
			}
			return true;
		}
		/// <summary>
		/// ADM0600(IFC메세지관리)에 등록된 MsgID List를 조회하여 등록된 IP로 메세지를 전송합니다.
		/// </summary>
		/// <param name="msgID"> 등록된 MsgID </param>
		/// <param name="msg"> 전송한 메세지 </param>
		/// <param name="command"> 전송할 Command </param>
		public static void SendMsgByMsgID(string msgID, string msg, string command)
		{
			try
			{
				/* 해당 MSG_ID로 등록된 메세지 ID 정보 조회 */
				string cmdText
					= "SELECT IP_ADDR, MSG_TYPE, SYS_ID, PGM_ID"
					+ "  FROM ADM0600"
					+ " WHERE MSG_ID ='" + msgID + "'";
				DataTable table = Service.ExecuteDataTable(cmdText);
				if ((table == null) || (table.Rows.Count < 1)) return; //조회실패거나 데이타 없음
				
				string ip = "";
				UdpMsgType udpMsgType = UdpMsgType.SMG;
				string screenID = "",systemID = "";
				foreach (DataRow dtRow in table.Rows)
				{
					ip = dtRow[0].ToString();
					udpMsgType = (UdpMsgType) Enum.Parse(typeof(UdpMsgType), dtRow[1].ToString().Trim());
					systemID = dtRow[2].ToString();
					screenID = dtRow[3].ToString();

					SendMsg(udpMsgType, ip, systemID, screenID, command, msg);
				}
			}
			catch{}
		}
		
		//동기식으로 TCP Send
		public static bool SendMsgByTCP(string ip, int port, string msg)
		{
			//  Create a TCP/IP  socket.
			Socket socket = new Socket(AddressFamily.InterNetwork,	SocketType.Stream, ProtocolType.Tcp);
			try
			{
				IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(ip), port);
				socket.Connect(remoteEP);
				//SendMsg
				byte[] sendBuffer = Service.BaseEncoding.GetBytes(msg);
				socket.Send(sendBuffer, 0, sendBuffer.Length, SocketFlags.None);
			}
			catch(Exception xe)
			{
				XMessageBox.Show(xe.Message);
				return false;
			}
			finally
			{
				socket.Close();
			}
			return true;
		}
		//비동기식으로 TCP Send
		private static bool SendMsgByTCPAsync(string ip, int port, string msg)
		{
			try
			{
				//  Create a TCP/IP  socket.
				Socket socket = new Socket(AddressFamily.InterNetwork,	SocketType.Stream, ProtocolType.Tcp);

				IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(ip), port);
				// Connect to the remote endpoint.
				socket.BeginConnect(remoteEP, 	new AsyncCallback(ConnectCallback), socket);

				//SendMsg
				byte[] sendBuffer = Service.BaseEncoding.GetBytes(msg);

				// Begin sending the data to the remote device.
				socket.BeginSend(sendBuffer, 0, sendBuffer.Length, SocketFlags.None, new AsyncCallback(SendCallback),socket);
			}
			catch(Exception xe)
			{
				XMessageBox.Show(xe.Message);
				return false;
			}
			return true;
		}
		private static void ConnectCallback(IAsyncResult ar) 
		{
			Socket sock = (Socket) ar.AsyncState;

			// Complete the connection.
			sock.EndConnect(ar);
		}
		private static void SendCallback(IAsyncResult ar) 
		{
			try 
			{
				// Retrieve the socket from the state object.
				Socket socket = (Socket) ar.AsyncState;

				// Complete sending the data to the remote device.
				socket.EndSend(ar);
				//Socket Close
				socket.Close();
			} 
			catch{}
		}

	}
}
