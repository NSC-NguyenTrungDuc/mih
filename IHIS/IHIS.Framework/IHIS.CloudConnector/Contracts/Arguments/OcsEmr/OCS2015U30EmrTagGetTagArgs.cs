using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{[Serializable]
	public class OCS2015U30EmrTagGetTagArgs : IContractArgs
	{
    protected bool Equals(OCS2015U30EmrTagGetTagArgs other)
    {
        return string.Equals(_tagLevel, other._tagLevel) && string.Equals(_sysId, other._sysId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2015U30EmrTagGetTagArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_tagLevel != null ? _tagLevel.GetHashCode() : 0)*397) ^ (_sysId != null ? _sysId.GetHashCode() : 0);
        }
    }

    private String _tagLevel;
		private String _sysId;

		public String TagLevel
		{
			get { return this._tagLevel; }
			set { this._tagLevel = value; }
		}

		public String SysId
		{
			get { return this._sysId; }
			set { this._sysId = value; }
		}

		public OCS2015U30EmrTagGetTagArgs() { }

		public OCS2015U30EmrTagGetTagArgs(String tagLevel, String sysId)
		{
			this._tagLevel = tagLevel;
			this._sysId = sysId;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS2015U30EmrTagGetTagRequest();
		}
	}
}