using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
	public class SCH0109U00GrdDetailArgs : IContractArgs
	{
    protected bool Equals(SCH0109U00GrdDetailArgs other)
    {
        return string.Equals(_codeType, other._codeType);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SCH0109U00GrdDetailArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_codeType != null ? _codeType.GetHashCode() : 0);
    }

    private String _codeType;

		public String CodeType
		{
			get { return this._codeType; }
			set { this._codeType = value; }
		}

		public SCH0109U00GrdDetailArgs() { }

		public SCH0109U00GrdDetailArgs(String codeType)
		{
			this._codeType = codeType;
		}

		public IExtensible GetRequestInstance()
		{
			return new SCH0109U00GrdDetailRequest();
		}
	}
}