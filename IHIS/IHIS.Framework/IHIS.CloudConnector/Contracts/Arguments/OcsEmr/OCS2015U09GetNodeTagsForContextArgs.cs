using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{[Serializable]
	public class OCS2015U09GetNodeTagsForContextArgs : IContractArgs
	{
    protected bool Equals(OCS2015U09GetNodeTagsForContextArgs other)
    {
        return string.Equals(_fParentTagCode, other._fParentTagCode) && string.Equals(_fUserId, other._fUserId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2015U09GetNodeTagsForContextArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_fParentTagCode != null ? _fParentTagCode.GetHashCode() : 0)*397) ^ (_fUserId != null ? _fUserId.GetHashCode() : 0);
        }
    }

    private String _fParentTagCode;
		private String _fUserId;

		public String FParentTagCode
		{
			get { return this._fParentTagCode; }
			set { this._fParentTagCode = value; }
		}

		public String FUserId
		{
			get { return this._fUserId; }
			set { this._fUserId = value; }
		}

		public OCS2015U09GetNodeTagsForContextArgs() { }

		public OCS2015U09GetNodeTagsForContextArgs(String fParentTagCode, String fUserId)
		{
			this._fParentTagCode = fParentTagCode;
			this._fUserId = fUserId;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS2015U09GetNodeTagsForContextRequest();
		}
	}
}