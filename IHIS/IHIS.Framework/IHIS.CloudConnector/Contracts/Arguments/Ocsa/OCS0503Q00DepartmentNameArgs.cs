using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0503Q00DepartmentNameArgs : IContractArgs
	{
    protected bool Equals(OCS0503Q00DepartmentNameArgs other)
    {
        return string.Equals(_gwaCode, other._gwaCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0503Q00DepartmentNameArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_gwaCode != null ? _gwaCode.GetHashCode() : 0);
    }

    private String _gwaCode;

		public String GwaCode
		{
			get { return this._gwaCode; }
			set { this._gwaCode = value; }
		}

		public OCS0503Q00DepartmentNameArgs() { }

		public OCS0503Q00DepartmentNameArgs(String gwaCode)
		{
			this._gwaCode = gwaCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0503Q00DepartmentNameRequest();
		}
	}
}