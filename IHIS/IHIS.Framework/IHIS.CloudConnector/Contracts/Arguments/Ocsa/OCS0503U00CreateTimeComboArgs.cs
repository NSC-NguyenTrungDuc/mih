using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0503U00CreateTimeComboArgs : IContractArgs
	{
    protected bool Equals(OCS0503U00CreateTimeComboArgs other)
    {
        return string.Equals(_doctor, other._doctor) && string.Equals(_date, other._date) && string.Equals(_intweek, other._intweek);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0503U00CreateTimeComboArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_doctor != null ? _doctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_date != null ? _date.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_intweek != null ? _intweek.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _doctor;
		private String _date;
		private String _intweek;

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String Date
		{
			get { return this._date; }
			set { this._date = value; }
		}

		public String Intweek
		{
			get { return this._intweek; }
			set { this._intweek = value; }
		}

		public OCS0503U00CreateTimeComboArgs() { }

		public OCS0503U00CreateTimeComboArgs(String doctor, String date, String intweek)
		{
			this._doctor = doctor;
			this._date = date;
			this._intweek = intweek;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0503U00CreateTimeComboRequest();
		}
	}
}