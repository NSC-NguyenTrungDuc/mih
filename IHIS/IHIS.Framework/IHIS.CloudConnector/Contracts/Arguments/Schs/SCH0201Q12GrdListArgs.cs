using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
	public class SCH0201Q12GrdListArgs : IContractArgs
	{
    protected bool Equals(SCH0201Q12GrdListArgs other)
    {
        return string.Equals(_gwa, other._gwa) && string.Equals(_doctor, other._doctor) && string.Equals(_reserGubun, other._reserGubun) && string.Equals(_statFlg, other._statFlg) && string.Equals(_naewonDate, other._naewonDate) && string.Equals(_bunho, other._bunho);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SCH0201Q12GrdListArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_gwa != null ? _gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_reserGubun != null ? _reserGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_statFlg != null ? _statFlg.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _gwa;
		private String _doctor;
		private String _reserGubun;
		private String _statFlg;
		private String _naewonDate;
		private String _bunho;

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

		public String ReserGubun
		{
			get { return this._reserGubun; }
			set { this._reserGubun = value; }
		}

		public String StatFlg
		{
			get { return this._statFlg; }
			set { this._statFlg = value; }
		}

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

		public SCH0201Q12GrdListArgs() { }

		public SCH0201Q12GrdListArgs(String gwa, String doctor, String reserGubun, String statFlg, String naewonDate, String bunho)
		{
			this._gwa = gwa;
			this._doctor = doctor;
			this._reserGubun = reserGubun;
			this._statFlg = statFlg;
			this._naewonDate = naewonDate;
			this._bunho = bunho;
		}

		public IExtensible GetRequestInstance()
		{
			return new SCH0201Q12GrdListRequest();
		}
	}
}