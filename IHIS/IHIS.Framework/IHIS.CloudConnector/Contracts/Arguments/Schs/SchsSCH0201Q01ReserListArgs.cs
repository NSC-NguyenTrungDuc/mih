using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
	public class SchsSCH0201Q01ReserListArgs : IContractArgs
	{
    protected bool Equals(SchsSCH0201Q01ReserListArgs other)
    {
        return string.Equals(_fromDate, other._fromDate) && string.Equals(_toDate, other._toDate) && string.Equals(_jundalTable, other._jundalTable) && string.Equals(_jundalPart, other._jundalPart) && _checked.Equals(other._checked);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SchsSCH0201Q01ReserListArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_fromDate != null ? _fromDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_toDate != null ? _toDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jundalTable != null ? _jundalTable.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jundalPart != null ? _jundalPart.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ _checked.GetHashCode();
            return hashCode;
        }
    }

    private String _fromDate;
		private String _toDate;
		private String _jundalTable;
		private String _jundalPart;
		private Boolean _checked;

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

		public String JundalTable
		{
			get { return this._jundalTable; }
			set { this._jundalTable = value; }
		}

		public String JundalPart
		{
			get { return this._jundalPart; }
			set { this._jundalPart = value; }
		}

		public Boolean ChkChecked
		{
			get { return this._checked; }
			set { this._checked = value; }
		}

		public SchsSCH0201Q01ReserListArgs() { }

		public SchsSCH0201Q01ReserListArgs(String fromDate, String toDate, String jundalTable, String jundalPart, Boolean chkChecked)
		{
			this._fromDate = fromDate;
			this._toDate = toDate;
			this._jundalTable = jundalTable;
			this._jundalPart = jundalPart;
			this._checked = chkChecked;
		}

		public IExtensible GetRequestInstance()
		{
			return new SchsSCH0201Q01ReserListRequest();
		}
	}
}