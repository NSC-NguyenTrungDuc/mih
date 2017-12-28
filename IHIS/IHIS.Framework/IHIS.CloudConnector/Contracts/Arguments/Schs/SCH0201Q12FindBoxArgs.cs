using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
	public class SCH0201Q12FindBoxArgs : IContractArgs
	{
    protected bool Equals(SCH0201Q12FindBoxArgs other)
    {
        return string.Equals(_gwa, other._gwa) && string.Equals(_doctor, other._doctor);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SCH0201Q12FindBoxArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_gwa != null ? _gwa.GetHashCode() : 0)*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
        }
    }

    private String _gwa;
		private String _doctor;

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public SCH0201Q12FindBoxArgs() { }

		public SCH0201Q12FindBoxArgs(String gwa, String doctor)
		{
			this._gwa = gwa;
			this._doctor = doctor;
		}

		public IExtensible GetRequestInstance()
		{
			return new SCH0201Q12FindBoxRequest();
		}
	}
}