using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0204Q00CreateDoctorComboArgs : IContractArgs
	{
    protected bool Equals(OCS0204Q00CreateDoctorComboArgs other)
    {
        return string.Equals(_gwa, other._gwa);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0204Q00CreateDoctorComboArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_gwa != null ? _gwa.GetHashCode() : 0);
    }

    private String _gwa;

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public OCS0204Q00CreateDoctorComboArgs() { }

		public OCS0204Q00CreateDoctorComboArgs(String gwa)
		{
			this._gwa = gwa;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0204Q00CreateDoctorComboRequest();
		}
	}
}