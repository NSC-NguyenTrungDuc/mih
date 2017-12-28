using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OcsoOCS1003Q05GrdRowFocusChangedArgs : IContractArgs
	{
    protected bool Equals(OcsoOCS1003Q05GrdRowFocusChangedArgs other)
    {
        return string.Equals(_genericYn, other._genericYn) && string.Equals(_pkOrder, other._pkOrder) && string.Equals(_inputTab, other._inputTab) && string.Equals(_inputGubun, other._inputGubun) && string.Equals(_telYn, other._telYn) && string.Equals(_bunho, other._bunho) && string.Equals(_jubsuNo, other._jubsuNo) && string.Equals(_kijun, other._kijun) && string.Equals(_naewonDate, other._naewonDate) && string.Equals(_gwa, other._gwa) && string.Equals(_doctor, other._doctor) && string.Equals(_ioGubun, other._ioGubun) && string.Equals(_naewonType, other._naewonType);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsoOCS1003Q05GrdRowFocusChangedArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_genericYn != null ? _genericYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_pkOrder != null ? _pkOrder.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputTab != null ? _inputTab.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputGubun != null ? _inputGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_telYn != null ? _telYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jubsuNo != null ? _jubsuNo.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_kijun != null ? _kijun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_naewonType != null ? _naewonType.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _genericYn;
		private String _pkOrder;
		private String _inputTab;
		private String _inputGubun;
		private String _telYn;
		private String _bunho;
		private String _jubsuNo;
		private String _kijun;
		private String _naewonDate;
		private String _gwa;
		private String _doctor;
		private String _ioGubun;
		private String _naewonType;

		public String GenericYn
		{
			get { return this._genericYn; }
			set { this._genericYn = value; }
		}

		public String PkOrder
		{
			get { return this._pkOrder; }
			set { this._pkOrder = value; }
		}

		public String InputTab
		{
			get { return this._inputTab; }
			set { this._inputTab = value; }
		}

		public String InputGubun
		{
			get { return this._inputGubun; }
			set { this._inputGubun = value; }
		}

		public String TelYn
		{
			get { return this._telYn; }
			set { this._telYn = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String JubsuNo
		{
			get { return this._jubsuNo; }
			set { this._jubsuNo = value; }
		}

		public String Kijun
		{
			get { return this._kijun; }
			set { this._kijun = value; }
		}

		public String NaewonDate
		{
			get { return this._naewonDate; }
			set { this._naewonDate = value; }
		}

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

		public String IoGubun
		{
			get { return this._ioGubun; }
			set { this._ioGubun = value; }
		}

		public String NaewonType
		{
			get { return this._naewonType; }
			set { this._naewonType = value; }
		}

		public OcsoOCS1003Q05GrdRowFocusChangedArgs() { }

		public OcsoOCS1003Q05GrdRowFocusChangedArgs(String genericYn, String pkOrder, String inputTab, String inputGubun, String telYn, String bunho, String jubsuNo, String kijun, String naewonDate, String gwa, String doctor, String ioGubun, String naewonType)
		{
			this._genericYn = genericYn;
			this._pkOrder = pkOrder;
			this._inputTab = inputTab;
			this._inputGubun = inputGubun;
			this._telYn = telYn;
			this._bunho = bunho;
			this._jubsuNo = jubsuNo;
			this._kijun = kijun;
			this._naewonDate = naewonDate;
			this._gwa = gwa;
			this._doctor = doctor;
			this._ioGubun = ioGubun;
			this._naewonType = naewonType;
		}

		public IExtensible GetRequestInstance()
		{
			return new OcsoOCS1003Q05GrdRowFocusChangedRequest();
		}
	}
}