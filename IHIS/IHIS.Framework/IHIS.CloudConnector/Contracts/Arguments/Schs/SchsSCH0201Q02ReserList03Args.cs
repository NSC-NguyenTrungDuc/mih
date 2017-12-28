using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
	public class SchsSCH0201Q02ReserList03Args : IContractArgs
	{
    protected bool Equals(SchsSCH0201Q02ReserList03Args other)
    {
        return string.Equals(_fromDate, other._fromDate) && string.Equals(_toDate, other._toDate) && string.Equals(_gwa, other._gwa);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SchsSCH0201Q02ReserList03Args) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_fromDate != null ? _fromDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_toDate != null ? _toDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _fromDate;
		private String _toDate;
		private String _gwa;

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

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public SchsSCH0201Q02ReserList03Args() { }

		public SchsSCH0201Q02ReserList03Args(String fromDate, String toDate, String gwa)
		{
			this._fromDate = fromDate;
			this._toDate = toDate;
			this._gwa = gwa;
		}

		public IExtensible GetRequestInstance()
		{
			return new SchsSCH0201Q02ReserList03Request();
		}
	}
}