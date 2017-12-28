using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0503Q00LoadConsultInfoArgs : IContractArgs
	{
    protected bool Equals(OCS0503Q00LoadConsultInfoArgs other)
    {
        return string.Equals(_gwa, other._gwa) && string.Equals(_doctor, other._doctor) && string.Equals(_fromDate, other._fromDate) && string.Equals(_toDate, other._toDate);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0503Q00LoadConsultInfoArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_gwa != null ? _gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fromDate != null ? _fromDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_toDate != null ? _toDate.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _gwa;
		private String _doctor;
		private String _fromDate;
		private String _toDate;

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

		public String FromDate
		{
			get { return this._fromDate; }
			set { this._fromDate = value; }
		}

		public String ToDate
		{
			get { return this._toDate; }
			set { this._toDate = value; }
		}

		public OCS0503Q00LoadConsultInfoArgs() { }

		public OCS0503Q00LoadConsultInfoArgs(String gwa, String doctor, String fromDate, String toDate)
		{
			this._gwa = gwa;
			this._doctor = doctor;
			this._fromDate = fromDate;
			this._toDate = toDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0503Q00LoadConsultInfoRequest();
		}
	}
}