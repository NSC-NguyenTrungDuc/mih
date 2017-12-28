using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OcsaOCS0204U00FindWorkerListArgs : IContractArgs
	{
    protected bool Equals(OcsaOCS0204U00FindWorkerListArgs other)
    {
        return string.Equals(_find1, other._find1);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsaOCS0204U00FindWorkerListArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_find1 != null ? _find1.GetHashCode() : 0);
    }

    private String _find1;

		public String Find1
		{
			get { return this._find1; }
			set { this._find1 = value; }
		}

		public OcsaOCS0204U00FindWorkerListArgs() { }

		public OcsaOCS0204U00FindWorkerListArgs(String find1)
		{
			this._find1 = find1;
		}

		public IExtensible GetRequestInstance()
		{
			return new OcsaOCS0204U00FindWorkerListRequest();
		}
	}
}