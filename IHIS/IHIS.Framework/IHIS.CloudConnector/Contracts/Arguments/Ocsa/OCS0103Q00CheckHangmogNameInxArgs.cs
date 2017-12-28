using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0103Q00CheckHangmogNameInxArgs : IContractArgs
	{
    protected bool Equals(OCS0103Q00CheckHangmogNameInxArgs other)
    {
        return string.Equals(_hangmogNameInx, other._hangmogNameInx);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103Q00CheckHangmogNameInxArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_hangmogNameInx != null ? _hangmogNameInx.GetHashCode() : 0);
    }

    private String _hangmogNameInx;

		public String HangmogNameInx
		{
			get { return this._hangmogNameInx; }
			set { this._hangmogNameInx = value; }
		}

		public OCS0103Q00CheckHangmogNameInxArgs() { }

		public OCS0103Q00CheckHangmogNameInxArgs(String hangmogNameInx)
		{
			this._hangmogNameInx = hangmogNameInx;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0103Q00CheckHangmogNameInxRequest();
		}
	}
}