using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
	public class SchsSCH0201Q01ReserListCboArgs : IContractArgs
	{
    protected bool Equals(SchsSCH0201Q01ReserListCboArgs other)
    {
        return string.Equals(_fromDate, other._fromDate) && string.Equals(_toDate, other._toDate) && string.Equals(_jundalTable, other._jundalTable) && string.Equals(_jundalPart, other._jundalPart) && _chkchecked.Equals(other._chkchecked) && _isSelectedGumsa.Equals(other._isSelectedGumsa);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SchsSCH0201Q01ReserListCboArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_fromDate != null ? _fromDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_toDate != null ? _toDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jundalTable != null ? _jundalTable.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jundalPart != null ? _jundalPart.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ _chkchecked.GetHashCode();
            hashCode = (hashCode*397) ^ _isSelectedGumsa.GetHashCode();
            return hashCode;
        }
    }

    private String _fromDate;
		private String _toDate;
		private String _jundalTable;
		private String _jundalPart;
		private Boolean _chkchecked;
		private Boolean _isSelectedGumsa;

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

		public Boolean Chkchecked
		{
			get { return this._chkchecked; }
			set { this._chkchecked = value; }
		}

		public Boolean IsSelectedGumsa
		{
			get { return this._isSelectedGumsa; }
			set { this._isSelectedGumsa = value; }
		}

		public SchsSCH0201Q01ReserListCboArgs() { }

		public SchsSCH0201Q01ReserListCboArgs(String fromDate, String toDate, String jundalTable, String jundalPart, Boolean chkchecked, Boolean isSelectedGumsa)
		{
			this._fromDate = fromDate;
			this._toDate = toDate;
			this._jundalTable = jundalTable;
			this._jundalPart = jundalPart;
			this._chkchecked = chkchecked;
			this._isSelectedGumsa = isSelectedGumsa;
		}

		public IExtensible GetRequestInstance()
		{
			return new SchsSCH0201Q01ReserListCboRequest();
		}
	}
}