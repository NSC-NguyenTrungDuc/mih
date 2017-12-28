using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
	public class UdpHelperSendInfo
	{
		private String _senderId;
		private String _msgTitle;
		private String _msgContents;
		private String _recverId;
		private String _ipAddr;

		public String SenderId
		{
			get { return this._senderId; }
			set { this._senderId = value; }
		}

		public String MsgTitle
		{
			get { return this._msgTitle; }
			set { this._msgTitle = value; }
		}

		public String MsgContents
		{
			get { return this._msgContents; }
			set { this._msgContents = value; }
		}

		public String RecverId
		{
			get { return this._recverId; }
			set { this._recverId = value; }
		}

		public String IpAddr
		{
			get { return this._ipAddr; }
			set { this._ipAddr = value; }
		}

		public UdpHelperSendInfo() { }

		public UdpHelperSendInfo(String senderId, String msgTitle, String msgContents, String recverId, String ipAddr)
		{
			this._senderId = senderId;
			this._msgTitle = msgTitle;
			this._msgContents = msgContents;
			this._recverId = recverId;
			this._ipAddr = ipAddr;
		}

	}
}