using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0208Q01GrdOCS0208Args : IContractArgs
	{
    protected bool Equals(OCS0208Q01GrdOCS0208Args other)
    {
        return string.Equals(_doctor, other._doctor);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0208Q01GrdOCS0208Args) obj);
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

		public OCS0208Q01GrdOCS0208Args() { }

		public OCS0208Q01GrdOCS0208Args(String doctor)
		{
			this._doctor = doctor;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0208Q01GrdOCS0208Request();
		}
	}
}