using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OUTSANGU00GetDoctorNameArgs : IContractArgs
	{
    protected bool Equals(OUTSANGU00GetDoctorNameArgs other)
    {
        return string.Equals(_gwa, other._gwa) && string.Equals(_find1, other._find1) && string.Equals(_startDate, other._startDate);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OUTSANGU00GetDoctorNameArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_gwa != null ? _gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_find1 != null ? _find1.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_startDate != null ? _startDate.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _gwa;
		private String _find1;
		private String _startDate;

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String Find1
		{
			get { return this._find1; }
			set { this._find1 = value; }
		}

		public String StartDate
		{
			get { return this._startDate; }
			set { this._startDate = value; }
		}

		public OUTSANGU00GetDoctorNameArgs() { }

		public OUTSANGU00GetDoctorNameArgs(String gwa, String find1, String startDate)
		{
			this._gwa = gwa;
			this._find1 = find1;
			this._startDate = startDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new OUTSANGU00GetDoctorNameRequest();
		}
	}
}