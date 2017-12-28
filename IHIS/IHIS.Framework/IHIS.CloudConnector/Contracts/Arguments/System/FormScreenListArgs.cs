using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
	public class FormScreenListArgs : IContractArgs
	{
    protected bool Equals(FormScreenListArgs other)
    {
        return string.Equals(_screenId, other._screenId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((FormScreenListArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_screenId != null ? _screenId.GetHashCode() : 0);
    }

    private String _screenId;

		public String ScreenId
		{
			get { return this._screenId; }
			set { this._screenId = value; }
		}

		public FormScreenListArgs() { }

		public FormScreenListArgs(String screenId)
		{
			this._screenId = screenId;
		}

		public IExtensible GetRequestInstance()
		{
			return new FormScreenListRequest();
		}
	}
}