using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0304U00GrdOCS0306Args : IContractArgs
	{
    protected bool Equals(OCS0304U00GrdOCS0306Args other)
    {
        return string.Equals(_doctor, other._doctor) && string.Equals(_yaksokDirectCode, other._yaksokDirectCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0304U00GrdOCS0306Args) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_doctor != null ? _doctor.GetHashCode() : 0)*397) ^ (_yaksokDirectCode != null ? _yaksokDirectCode.GetHashCode() : 0);
        }
    }

    private String _doctor;
		private String _yaksokDirectCode;

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String YaksokDirectCode
		{
			get { return this._yaksokDirectCode; }
			set { this._yaksokDirectCode = value; }
		}

		public OCS0304U00GrdOCS0306Args() { }

		public OCS0304U00GrdOCS0306Args(String doctor, String yaksokDirectCode)
		{
			this._doctor = doctor;
			this._yaksokDirectCode = yaksokDirectCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0304U00GrdOCS0306Request();
		}
	}
}