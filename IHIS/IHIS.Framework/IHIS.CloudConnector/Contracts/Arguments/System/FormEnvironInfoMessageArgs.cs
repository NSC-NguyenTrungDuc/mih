using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
	public class FormEnvironInfoMessageArgs : IContractArgs
	{
    protected bool Equals(FormEnvironInfoMessageArgs other)
    {
        return string.Equals(_msgNum, other._msgNum);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((FormEnvironInfoMessageArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_msgNum != null ? _msgNum.GetHashCode() : 0);
    }

    private String _msgNum;

		public String MsgNum
		{
			get { return this._msgNum; }
			set { this._msgNum = value; }
		}

		public FormEnvironInfoMessageArgs() { }

		public FormEnvironInfoMessageArgs(String msgNum)
		{
			this._msgNum = msgNum;
		}

		public IExtensible GetRequestInstance()
		{
			return new FormEnvironInfoMessageRequest();
		}
	}
}