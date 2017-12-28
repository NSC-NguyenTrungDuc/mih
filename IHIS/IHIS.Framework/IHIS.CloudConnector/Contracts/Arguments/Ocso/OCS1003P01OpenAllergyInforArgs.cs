using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OCS1003P01OpenAllergyInforArgs : IContractArgs
	{
    protected bool Equals(OCS1003P01OpenAllergyInforArgs other)
    {
        return string.Equals(_doctor, other._doctor) && string.Equals(_gwa, other._gwa) && string.Equals(_keyword, other._keyword) && string.Equals(_ioGubun, other._ioGubun) && string.Equals(_bunho, other._bunho) && string.Equals(_naewonDate, other._naewonDate);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS1003P01OpenAllergyInforArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_doctor != null ? _doctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_keyword != null ? _keyword.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _doctor;
		private String _gwa;
		private String _keyword;
		private String _ioGubun;
		private String _bunho;
		private String _naewonDate;

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

		public String Keyword
		{
			get { return this._keyword; }
			set { this._keyword = value; }
		}

		public String IoGubun
		{
			get { return this._ioGubun; }
			set { this._ioGubun = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String NaewonDate
		{
			get { return this._naewonDate; }
			set { this._naewonDate = value; }
		}

		public OCS1003P01OpenAllergyInforArgs() { }

		public OCS1003P01OpenAllergyInforArgs(String doctor, String gwa, String keyword, String ioGubun, String bunho, String naewonDate)
		{
			this._doctor = doctor;
			this._gwa = gwa;
			this._keyword = keyword;
			this._ioGubun = ioGubun;
			this._bunho = bunho;
			this._naewonDate = naewonDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS1003P01OpenAllergyInforRequest();
		}
	}
}