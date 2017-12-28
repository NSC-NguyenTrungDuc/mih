using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{[Serializable]
	public class OCS2015U07GetChildTagOfParentArgs : IContractArgs
	{
    protected bool Equals(OCS2015U07GetChildTagOfParentArgs other)
    {
        return string.Equals(_fParentTag, other._fParentTag);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2015U07GetChildTagOfParentArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_fParentTag != null ? _fParentTag.GetHashCode() : 0);
    }

    private String _fParentTag;

		public String FParentTag
		{
			get { return this._fParentTag; }
			set { this._fParentTag = value; }
		}

		public OCS2015U07GetChildTagOfParentArgs() { }

		public OCS2015U07GetChildTagOfParentArgs(String fParentTag)
		{
			this._fParentTag = fParentTag;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS2015U07GetChildTagOfParentRequest();
		}
	}
}