using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0103U12FbxJusaFindClickArgs : IContractArgs
	{
    protected bool Equals(OCS0103U12FbxJusaFindClickArgs other)
    {
        return string.Equals(_ioGubun, other._ioGubun) && string.Equals(_find1, other._find1);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U12FbxJusaFindClickArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_ioGubun != null ? _ioGubun.GetHashCode() : 0)*397) ^ (_find1 != null ? _find1.GetHashCode() : 0);
        }
    }

    private String _ioGubun;
		private String _find1;

		public String IoGubun
		{
			get { return this._ioGubun; }
			set { this._ioGubun = value; }
		}

		public String Find1
		{
			get { return this._find1; }
			set { this._find1 = value; }
		}

		public OCS0103U12FbxJusaFindClickArgs() { }

		public OCS0103U12FbxJusaFindClickArgs(String ioGubun, String find1)
		{
			this._ioGubun = ioGubun;
			this._find1 = find1;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0103U12FbxJusaFindClickRequest();
		}
	}
}