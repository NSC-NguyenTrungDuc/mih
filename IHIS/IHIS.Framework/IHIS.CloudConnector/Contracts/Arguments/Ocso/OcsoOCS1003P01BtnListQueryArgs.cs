using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OcsoOCS1003P01BtnListQueryArgs : IContractArgs
	{
    protected bool Equals(OcsoOCS1003P01BtnListQueryArgs other)
    {
        return string.Equals(_bunho, other._bunho) && string.Equals(_gwa, other._gwa) && string.Equals(_naewonDate, other._naewonDate) && string.Equals(_fkout1001, other._fkout1001) && string.Equals(_queryGubun, other._queryGubun) && string.Equals(_inputGubun, other._inputGubun) && string.Equals(_bunho2, other._bunho2) && string.Equals(_naewonDate2, other._naewonDate2);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsoOCS1003P01BtnListQueryArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fkout1001 != null ? _fkout1001.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_queryGubun != null ? _queryGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputGubun != null ? _inputGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho2 != null ? _bunho2.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_naewonDate2 != null ? _naewonDate2.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _bunho;
		private String _gwa;
		private String _naewonDate;
		private String _fkout1001;
		private String _queryGubun;
		private String _inputGubun;
		private String _bunho2;
		private String _naewonDate2;

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

		public String NaewonDate
		{
			get { return this._naewonDate; }
			set { this._naewonDate = value; }
		}

		public String Fkout1001
		{
			get { return this._fkout1001; }
			set { this._fkout1001 = value; }
		}

		public String QueryGubun
		{
			get { return this._queryGubun; }
			set { this._queryGubun = value; }
		}

		public String InputGubun
		{
			get { return this._inputGubun; }
			set { this._inputGubun = value; }
		}

		public String Bunho2
		{
			get { return this._bunho2; }
			set { this._bunho2 = value; }
		}

		public String NaewonDate2
		{
			get { return this._naewonDate2; }
			set { this._naewonDate2 = value; }
		}

		public OcsoOCS1003P01BtnListQueryArgs() { }

		public OcsoOCS1003P01BtnListQueryArgs(String bunho, String gwa, String naewonDate, String fkout1001, String queryGubun, String inputGubun, String bunho2, String naewonDate2)
		{
			this._bunho = bunho;
			this._gwa = gwa;
			this._naewonDate = naewonDate;
			this._fkout1001 = fkout1001;
			this._queryGubun = queryGubun;
			this._inputGubun = inputGubun;
			this._bunho2 = bunho2;
			this._naewonDate2 = naewonDate2;
		}

		public IExtensible GetRequestInstance()
		{
			return new OcsoOCS1003P01BtnListQueryRequest();
		}
	}
}