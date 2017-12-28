using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OcsaOCS0304U00GetDoctorYaksokOpenIdArgs : IContractArgs
	{
    protected bool Equals(OcsaOCS0304U00GetDoctorYaksokOpenIdArgs other)
    {
        return string.Equals(_doctor, other._doctor);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsaOCS0304U00GetDoctorYaksokOpenIdArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_doctor != null ? _doctor.GetHashCode() : 0);
    }

    private String _doctor;

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public OcsaOCS0304U00GetDoctorYaksokOpenIdArgs() { }

		public OcsaOCS0304U00GetDoctorYaksokOpenIdArgs(String doctor)
		{
			this._doctor = doctor;
		}

		public IExtensible GetRequestInstance()
		{
			return new OcsaOCS0304U00GetDoctorYaksokOpenIdRequest();
		}
	}
}