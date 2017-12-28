using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OCS1003DloCheckLayoutArgs : IContractArgs
	{
    protected bool Equals(OCS1003DloCheckLayoutArgs other)
    {
        return string.Equals(_bunho, other._bunho) && string.Equals(_naewonDate, other._naewonDate) && string.Equals(_gwa, other._gwa) && string.Equals(_inputGubun, other._inputGubun) && string.Equals(_telYn, other._telYn);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS1003DloCheckLayoutArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputGubun != null ? _inputGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_telYn != null ? _telYn.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _bunho;
		private String _naewonDate;
		private String _gwa;
		private String _inputGubun;
		private String _telYn;

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

		public OCS1003DloCheckLayoutArgs() { }

		public OCS1003DloCheckLayoutArgs(String bunho, String naewonDate, String gwa, String inputGubun, String telYn)
		{
			this._bunho = bunho;
			this._naewonDate = naewonDate;
			this._gwa = gwa;
			this._inputGubun = inputGubun;
			this._telYn = telYn;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS1003DloCheckLayoutRequest();
		}
	}
}