using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
	public class XRT0201U00LoadScreenArgs : IContractArgs
	{
    protected bool Equals(XRT0201U00LoadScreenArgs other)
    {
        return string.Equals(_queryDate, other._queryDate) && string.Equals(_ioGubun, other._ioGubun) && string.Equals(_actGubun, other._actGubun) && string.Equals(_jundalTableCode, other._jundalTableCode) && string.Equals(_jundalPart, other._jundalPart) && string.Equals(_bunho, other._bunho) && string.Equals(_fromDate, other._fromDate) && string.Equals(_toDate, other._toDate);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT0201U00LoadScreenArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_queryDate != null ? _queryDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_actGubun != null ? _actGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jundalTableCode != null ? _jundalTableCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jundalPart != null ? _jundalPart.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fromDate != null ? _fromDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_toDate != null ? _toDate.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _queryDate;
		private String _ioGubun;
		private String _actGubun;
		private String _jundalTableCode;
		private String _jundalPart;
		private String _bunho;
		private String _fromDate;
		private String _toDate;

		public String QueryDate
		{
			get { return this._queryDate; }
			set { this._queryDate = value; }
		}

		public String IoGubun
		{
			get { return this._ioGubun; }
			set { this._ioGubun = value; }
		}

		public String ActGubun
		{
			get { return this._actGubun; }
			set { this._actGubun = value; }
		}

		public String JundalTableCode
		{
			get { return this._jundalTableCode; }
			set { this._jundalTableCode = value; }
		}

		public String JundalPart
		{
			get { return this._jundalPart; }
			set { this._jundalPart = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
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

		public XRT0201U00LoadScreenArgs() { }

		public XRT0201U00LoadScreenArgs(String queryDate, String ioGubun, String actGubun, String jundalTableCode, String jundalPart, String bunho, String fromDate, String toDate)
		{
			this._queryDate = queryDate;
			this._ioGubun = ioGubun;
			this._actGubun = actGubun;
			this._jundalTableCode = jundalTableCode;
			this._jundalPart = jundalPart;
			this._bunho = bunho;
			this._fromDate = fromDate;
			this._toDate = toDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new XRT0201U00LoadScreenRequest();
		}
	}
}