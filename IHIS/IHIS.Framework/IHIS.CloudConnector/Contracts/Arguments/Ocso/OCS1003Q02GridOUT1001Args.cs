using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OCS1003Q02GridOUT1001Args : IContractArgs
	{
    protected bool Equals(OCS1003Q02GridOUT1001Args other)
    {
        return string.Equals(_naewonDate, other._naewonDate) && string.Equals(_bunho, other._bunho) && string.Equals(_gwa, other._gwa) && string.Equals(_doctor, other._doctor) && string.Equals(_naewonYn, other._naewonYn);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS1003Q02GridOUT1001Args) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_naewonYn != null ? _naewonYn.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _naewonDate;
		private String _bunho;
		private String _gwa;
		private String _doctor;
		private String _naewonYn;

		public String NaewonDate
		{
			get { return this._naewonDate; }
			set { this._naewonDate = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
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

		public String NaewonYn
		{
			get { return this._naewonYn; }
			set { this._naewonYn = value; }
		}

		public OCS1003Q02GridOUT1001Args() { }

		public OCS1003Q02GridOUT1001Args(String naewonDate, String bunho, String gwa, String doctor, String naewonYn)
		{
			this._naewonDate = naewonDate;
			this._bunho = bunho;
			this._gwa = gwa;
			this._doctor = doctor;
			this._naewonYn = naewonYn;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS1003Q02GridOUT1001Request();
		}
	}
}