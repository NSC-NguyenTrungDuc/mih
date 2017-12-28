using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
	public class ComboDoctorGwaArgs : IContractArgs
	{
    protected bool Equals(ComboDoctorGwaArgs other)
    {
        return string.Equals(_memb, other._memb);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((ComboDoctorGwaArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_memb != null ? _memb.GetHashCode() : 0);
    }

    private String _memb;

		public String Memb
		{
			get { return this._memb; }
			set { this._memb = value; }
		}

		public ComboDoctorGwaArgs() { }

		public ComboDoctorGwaArgs(String memb)
		{
			this._memb = memb;
		}

		public IExtensible GetRequestInstance()
		{
			return new ComboDoctorGwaRequest();
		}
	}
}