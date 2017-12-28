using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS3003Q10GrdOrderArgs : IContractArgs
	{
    protected bool Equals(OCS3003Q10GrdOrderArgs other)
    {
        return string.Equals(_naewonDate, other._naewonDate) && string.Equals(_ioGubun, other._ioGubun) && string.Equals(_orderGubun, other._orderGubun) && string.Equals(_bunho, other._bunho) && string.Equals(_pkOcskey, other._pkOcskey) && string.Equals(_jubsuNo, other._jubsuNo) && string.Equals(_gwa, other._gwa) && string.Equals(_doctor, other._doctor);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS3003Q10GrdOrderArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_orderGubun != null ? _orderGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_pkOcskey != null ? _pkOcskey.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jubsuNo != null ? _jubsuNo.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _naewonDate;
		private String _ioGubun;
		private String _orderGubun;
		private String _bunho;
		private String _pkOcskey;
		private String _jubsuNo;
		private String _gwa;
		private String _doctor;

		public String NaewonDate
		{
			get { return this._naewonDate; }
			set { this._naewonDate = value; }
		}

		public String IoGubun
		{
			get { return this._ioGubun; }
			set { this._ioGubun = value; }
		}

		public String OrderGubun
		{
			get { return this._orderGubun; }
			set { this._orderGubun = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String PkOcskey
		{
			get { return this._pkOcskey; }
			set { this._pkOcskey = value; }
		}

		public String JubsuNo
		{
			get { return this._jubsuNo; }
			set { this._jubsuNo = value; }
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

		public OCS3003Q10GrdOrderArgs() { }

		public OCS3003Q10GrdOrderArgs(String naewonDate, String ioGubun, String orderGubun, String bunho, String pkOcskey, String jubsuNo, String gwa, String doctor)
		{
			this._naewonDate = naewonDate;
			this._ioGubun = ioGubun;
			this._orderGubun = orderGubun;
			this._bunho = bunho;
			this._pkOcskey = pkOcskey;
			this._jubsuNo = jubsuNo;
			this._gwa = gwa;
			this._doctor = doctor;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS3003Q10GrdOrderRequest();
		}
	}
}