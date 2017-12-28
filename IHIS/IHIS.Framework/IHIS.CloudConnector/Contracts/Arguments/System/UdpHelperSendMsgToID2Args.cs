using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocs.Lib
{[Serializable]
	public class UdpHelperSendMsgToID2Args : IContractArgs
	{
    protected bool Equals(UdpHelperSendMsgToID2Args other)
    {
        return string.Equals(_senderId, other._senderId) && string.Equals(_sendSeq, other._sendSeq);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((UdpHelperSendMsgToID2Args) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_senderId != null ? _senderId.GetHashCode() : 0)*397) ^ (_sendSeq != null ? _sendSeq.GetHashCode() : 0);
        }
    }

    private String _senderId;
		private String _sendSeq;

		public String SenderId
		{
			get { return this._senderId; }
			set { this._senderId = value; }
		}

		public String SendSeq
		{
			get { return this._sendSeq; }
			set { this._sendSeq = value; }
		}

		public UdpHelperSendMsgToID2Args() { }

		public UdpHelperSendMsgToID2Args(String senderId, String sendSeq)
		{
			this._senderId = senderId;
			this._sendSeq = sendSeq;
		}

		public IExtensible GetRequestInstance()
		{
			return new UdpHelperSendMsgToID2Request();
		}
	}
}