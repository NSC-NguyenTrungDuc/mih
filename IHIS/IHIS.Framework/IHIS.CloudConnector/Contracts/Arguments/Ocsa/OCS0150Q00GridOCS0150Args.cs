using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0150Q00GridOCS0150Args : IContractArgs
	{
    protected bool Equals(OCS0150Q00GridOCS0150Args other)
    {
        return string.Equals(_doctor, other._doctor) && string.Equals(_gwa, other._gwa) && string.Equals(_ioGubun, other._ioGubun) && string.Equals(_orderDate, other._orderDate);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0150Q00GridOCS0150Args) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_doctor != null ? _doctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _doctor;
		private String _gwa;
		private String _ioGubun;
		private String _orderDate;

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String IoGubun
		{
			get { return this._ioGubun; }
			set { this._ioGubun = value; }
		}

		public String OrderDate
		{
			get { return this._orderDate; }
			set { this._orderDate = value; }
		}

		public OCS0150Q00GridOCS0150Args() { }

		public OCS0150Q00GridOCS0150Args(String doctor, String gwa, String ioGubun, String orderDate)
		{
			this._doctor = doctor;
			this._gwa = gwa;
			this._ioGubun = ioGubun;
			this._orderDate = orderDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0150Q00GridOCS0150Request();
		}
	}
}