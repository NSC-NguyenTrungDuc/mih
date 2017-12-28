using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0503Q00DoctorNameArgs : IContractArgs
	{
    protected bool Equals(OCS0503Q00DoctorNameArgs other)
    {
        return string.Equals(_gwa, other._gwa) && string.Equals(_doctorCode, other._doctorCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0503Q00DoctorNameArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_gwa != null ? _gwa.GetHashCode() : 0)*397) ^ (_doctorCode != null ? _doctorCode.GetHashCode() : 0);
        }
    }

    private String _gwa;
		private String _doctorCode;

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String DoctorCode
		{
			get { return this._doctorCode; }
			set { this._doctorCode = value; }
		}

		public OCS0503Q00DoctorNameArgs() { }

		public OCS0503Q00DoctorNameArgs(String gwa, String doctorCode)
		{
			this._gwa = gwa;
			this._doctorCode = doctorCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0503Q00DoctorNameRequest();
		}
	}
}