using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
	public class XRT0201U00GrdOrderArgs : IContractArgs
	{
    protected bool Equals(XRT0201U00GrdOrderArgs other)
    {
        return string.Equals(_ioGubun, other._ioGubun) && string.Equals(_actGubun, other._actGubun) && string.Equals(_reserYn, other._reserYn) && string.Equals(_orderDate, other._orderDate) && string.Equals(_fromDate, other._fromDate) && string.Equals(_toDate, other._toDate) && string.Equals(_naewonKey, other._naewonKey) && string.Equals(_emergency, other._emergency) && string.Equals(_jundalTableCode, other._jundalTableCode) && string.Equals(_jundalPart, other._jundalPart) && string.Equals(_bunho, other._bunho) && string.Equals(_doctor, other._doctor);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT0201U00GrdOrderArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_actGubun != null ? _actGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_reserYn != null ? _reserYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fromDate != null ? _fromDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_toDate != null ? _toDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_naewonKey != null ? _naewonKey.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_emergency != null ? _emergency.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jundalTableCode != null ? _jundalTableCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jundalPart != null ? _jundalPart.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _ioGubun;
		private String _actGubun;
		private String _reserYn;
		private String _orderDate;
		private String _fromDate;
		private String _toDate;
		private String _naewonKey;
		private String _emergency;
		private String _jundalTableCode;
		private String _jundalPart;
		private String _bunho;
		private String _doctor;

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

		public String ReserYn
		{
			get { return this._reserYn; }
			set { this._reserYn = value; }
		}

		public String OrderDate
		{
			get { return this._orderDate; }
			set { this._orderDate = value; }
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

		public String NaewonKey
		{
			get { return this._naewonKey; }
			set { this._naewonKey = value; }
		}

		public String Emergency
		{
			get { return this._emergency; }
			set { this._emergency = value; }
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

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public XRT0201U00GrdOrderArgs() { }

		public XRT0201U00GrdOrderArgs(String ioGubun, String actGubun, String reserYn, String orderDate, String fromDate, String toDate, String naewonKey, String emergency, String jundalTableCode, String jundalPart, String bunho, String doctor)
		{
			this._ioGubun = ioGubun;
			this._actGubun = actGubun;
			this._reserYn = reserYn;
			this._orderDate = orderDate;
			this._fromDate = fromDate;
			this._toDate = toDate;
			this._naewonKey = naewonKey;
			this._emergency = emergency;
			this._jundalTableCode = jundalTableCode;
			this._jundalPart = jundalPart;
			this._bunho = bunho;
			this._doctor = doctor;
		}

		public IExtensible GetRequestInstance()
		{
			return new XRT0201U00GrdOrderRequest();
		}
	}
}