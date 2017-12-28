using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OCS1003GrdOUT1001RowFocusChangedArgs : IContractArgs
	{
    protected bool Equals(OCS1003GrdOUT1001RowFocusChangedArgs other)
    {
        return string.Equals(_bunho, other._bunho) && string.Equals(_naewonDate, other._naewonDate) && string.Equals(_gwa, other._gwa) && string.Equals(_fkout1001, other._fkout1001) && string.Equals(_inputGubun, other._inputGubun) && string.Equals(_queryGubun, other._queryGubun);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS1003GrdOUT1001RowFocusChangedArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fkout1001 != null ? _fkout1001.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputGubun != null ? _inputGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_queryGubun != null ? _queryGubun.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _bunho;
		private String _naewonDate;
		private String _gwa;
		private String _fkout1001;
		private String _inputGubun;
		private String _queryGubun;

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

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String Fkout1001
		{
			get { return this._fkout1001; }
			set { this._fkout1001 = value; }
		}

		public String InputGubun
		{
			get { return this._inputGubun; }
			set { this._inputGubun = value; }
		}

		public String QueryGubun
		{
			get { return this._queryGubun; }
			set { this._queryGubun = value; }
		}

		public OCS1003GrdOUT1001RowFocusChangedArgs() { }

		public OCS1003GrdOUT1001RowFocusChangedArgs(String bunho, String naewonDate, String gwa, String fkout1001, String inputGubun, String queryGubun)
		{
			this._bunho = bunho;
			this._naewonDate = naewonDate;
			this._gwa = gwa;
			this._fkout1001 = fkout1001;
			this._inputGubun = inputGubun;
			this._queryGubun = queryGubun;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS1003GrdOUT1001RowFocusChangedRequest();
		}
	}
}