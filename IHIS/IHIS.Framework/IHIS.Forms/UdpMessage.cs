using System;
using System.Net;
using System.Text;
using System.ComponentModel;

namespace IHIS.Framework
{
	public enum UdpMsgType
	{
		/// <summary>
		/// IHIS 전체 공지 (AMIS Message)
		/// </summary>
		IMG,
		/// <summary>
		/// 시스템 메세지(System Message)
		/// </summary>
		SMG,
		/// <summary>
		/// 특정화면에 공지(Screen Message)
		/// </summary>
		SCM
	}
	/// <summary>
	/// UDP Message Layout
	/// </summary>
	public class UdpMessage : ICloneable
	{
		#region Fields
		const int	HeadLen = 84;				// Header Length
		private UdpMsgType	msgType = UdpMsgType.IMG;  //3자리
		private string	senderIP = "";  //15자리
		private string	senderID = "";	//12자리
		private string	senderName = ""; //20자리
		private string	systemID = "";  //4자리
		private string	screenID = "";	//20자리
		private string	command = "";	 //10자리
		private byte[]	messageBinary = null;
		private Encoding encoding = Service.BaseEncoding;
		#endregion

		#region Properties
		public UdpMsgType MsgType
		{
			get { return msgType; }
			set { msgType = value; }
		}
		public string SystemID
		{
			get { return systemID; }
			set { systemID = value; }
		}

		public string ScreenID
		{
			get { return screenID; }
			set { screenID = value; }
		}
		public string SenderID
		{
			get { return senderID; }
			set { senderID = value; }
		}

		public string SenderName
		{
			get { return senderName; }
			set { senderName = value; }
		}

		public string SenderIP
		{
			get { return senderIP; }
			set { senderIP = value; }
		}

		public string Command
		{
			get { return command; }
			set { command = value; }
		}

		public string Message
		{
			get
			{
				if (messageBinary == null)
					return "";
				// data에 NULL이 있으면 NULL전까지만
				byte	byteNull = 0;
				int pos = Array.IndexOf(messageBinary, byteNull);
				int	strLen = ((pos > 0) ? pos : messageBinary.Length);
				return encoding.GetString(messageBinary, 0, strLen);
			}
			set { messageBinary = encoding.GetBytes(value); }
		}

		public byte[] MessageBinary
		{
			get { return messageBinary; }
			set { messageBinary = value; }
		}
		#endregion

		#region Constructor
		public UdpMessage()
		{
            this.senderIP = "UnKnown";
			//IP는 PC의 IP Set
			try
			{
				//IP 2개이상 지정된 PC의 경우 최종  IP가 사용하는 IP임
                IPAddress[] ipList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;

                if (ipList.Length > 0)
                {
                    foreach (IPAddress ipa in ipList)
                    {
                        if (ipa.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            this.senderIP = ipa.ToString();
                        }
                    }
                }
                //if (ipList.Length > 0)
                //    this.senderIP = ipList[ipList.Length -1].ToString();
                //else
                //    this.senderIP = "UnKnown";
			}
			catch
			{
				this.senderIP = "UnKnown";
			}
		}

		public UdpMessage(byte[]	messageBinary)
			: this()
		{
			this.messageBinary = messageBinary;
		}

		public UdpMessage(string message)
			: this()
		{
			if (message != null)
				messageBinary = encoding.GetBytes(message);
		}
		#endregion

		#region ToByteArray
		/// <summary>
		/// Object를 Byte Array로 Serialize합니다.
		/// </summary>
		/// <returns></returns>
		public byte[] ToByteArray()
		{
			byte[]	msgTypeArray = encoding.GetBytes(msgType.ToString());
			byte[]	senderIPArray = encoding.GetBytes(senderIP);
			byte[]	systemIDArray = encoding.GetBytes(systemID);
			byte[]	screenIDArray = encoding.GetBytes(screenID);
			byte[]	senderIDArray = encoding.GetBytes(senderID);
			byte[]	senderNameArray = encoding.GetBytes(senderName);
			byte[]	commandArray = encoding.GetBytes(command);

			byte[]	byteArray = new byte[HeadLen + messageBinary.Length];
			
			// Fill Space (Head)
			for (int i = 0; i < HeadLen; i++)
				byteArray[i] = 0x20;

			Array.Copy(msgTypeArray,	0, byteArray,  0, msgTypeArray.Length);
			Array.Copy(senderIPArray,	0, byteArray,  3, senderIPArray.Length);
			Array.Copy(senderIDArray,	0, byteArray, 18, senderIDArray.Length);
			Array.Copy(senderNameArray,	0, byteArray, 30, senderNameArray.Length);
			Array.Copy(systemIDArray,	0, byteArray, 50, systemIDArray.Length);
			Array.Copy(screenIDArray,	0, byteArray, 54, screenIDArray.Length);
			Array.Copy(commandArray,	0, byteArray, 74, commandArray.Length);
			Array.Copy(messageBinary,	0, byteArray, HeadLen, messageBinary.Length);

			return byteArray;
		}
		#endregion

		#region FromByteArray
		/// <summary>
		/// Object를 Byte Array로부터 Deserialize합니다.
		/// </summary>
		/// <param name="byteArray">
		/// 수신된 Raw Data입니다.
		/// </param>
		/// <returns></returns>
		public bool FromByteArray(byte[] byteArray)
		{
			try
			{
				msgType = (UdpMsgType) Enum.Parse(typeof(UdpMsgType), encoding.GetString(byteArray, 0, 3).Trim());
			}
			catch
			{
				msgType = UdpMsgType.IMG;
			}
			senderIP	= encoding.GetString(byteArray, 3, 15).Trim();
			senderID	= encoding.GetString(byteArray, 18, 12).Trim();
			senderName	= encoding.GetString(byteArray, 30, 20).Trim();
			systemID	= encoding.GetString(byteArray, 50, 4).Trim();
			screenID	= encoding.GetString(byteArray, 54, 20).Trim();
			command		= encoding.GetString(byteArray, 74, 10).Trim();

			int	dataLen = byteArray.Length - HeadLen;
			messageBinary = new byte[dataLen];
			Array.Copy(byteArray, HeadLen, messageBinary, 0, dataLen);

			return true;
		}
		#endregion

		#region Clone
		/// <summary>
		/// Object의 복사본을 return합니다.
		/// </summary>
		/// <returns></returns>
		public object Clone()
		{
			return this.MemberwiseClone();
		}
		#endregion

		#region ToString
		public override string ToString()
		{
			//byteArray를 string으로 변환하여 Return
			return encoding.GetString(this.ToByteArray());
		}
		#endregion

		#region Static FromReceivedMessage
		/// <summary>
		/// 수신전문으로부터 객체를 생성합니다.
		/// </summary>
		/// <param name="byteArray">
		/// 수신된 Message Raw Data입니다.
		/// </param>
		/// <returns>
		/// UdpMessage객체를 Return합니다.
		/// </returns>
		public static UdpMessage FromReceivedMessage(byte[] byteArray)
		{
			UdpMessage msg = new UdpMessage();
			msg.FromByteArray(byteArray);
			return msg;
		}
		#endregion

		#region Static BinaryReplace
		/// <summary>
		/// Byte Array에서 구성 Byte를 치환합니다..
		/// </summary>
		/// <param name="byteArray">
		/// 치환할 Byte Array입니다.
		/// </param>
		/// <param name="oldValue">
		/// 치환대상 값입니다.
		/// </param>
		/// <param name="newValue">
		/// 치환할 값입니다.
		/// </param>
		/// <returns>
		/// 치환이 완료된 Byte Array입니다.
		/// </returns>
		public static byte[] Replace(byte[] byteArray, byte oldValue, byte newValue)
		{
			if (byteArray == null)
				return null;

			byte[] newArray = (byte[])byteArray.Clone();
			for (int i = 0; i < newArray.Length; i++)
			{
				if (newArray[i] == oldValue)
					newArray[i] = newValue;

			}

			return newArray;
		}
		#endregion
	}
}
