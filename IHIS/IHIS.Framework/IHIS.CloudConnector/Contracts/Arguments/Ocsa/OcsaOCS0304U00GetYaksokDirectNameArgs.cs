using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OcsaOCS0304U00GetYaksokDirectNameArgs : IContractArgs
	{
    protected bool Equals(OcsaOCS0304U00GetYaksokDirectNameArgs other)
    {
        return string.Equals(_membGubun, other._membGubun) && string.Equals(_code, other._code) && string.Equals(_doctor, other._doctor);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsaOCS0304U00GetYaksokDirectNameArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_membGubun != null ? _membGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_code != null ? _code.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _membGubun;
		private String _code;
		private String _doctor;

		public String MembGubun
		{
			get { return this._membGubun; }
			set { this._membGubun = value; }
		}

		public String Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public OcsaOCS0304U00GetYaksokDirectNameArgs() { }

		public OcsaOCS0304U00GetYaksokDirectNameArgs(String membGubun, String code, String doctor)
		{
			this._membGubun = membGubun;
			this._code = code;
			this._doctor = doctor;
		}

		public IExtensible GetRequestInstance()
		{
			return new OcsaOCS0304U00GetYaksokDirectNameRequest();
		}
	}
}