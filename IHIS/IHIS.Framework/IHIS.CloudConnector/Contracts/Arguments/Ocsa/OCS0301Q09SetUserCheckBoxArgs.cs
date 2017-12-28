using System;
using ProtoBuf;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0301Q09SetUserCheckBoxArgs : IContractArgs
	{
    protected bool Equals(OCS0301Q09SetUserCheckBoxArgs other)
    {
        return string.Equals(_memb, other._memb) && string.Equals(_gwa, other._gwa) && Equals(_gwaAllName, other._gwaAllName) && Equals(_gwaDoctorName, other._gwaDoctorName) && Equals(_userIdName, other._userIdName);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0301Q09SetUserCheckBoxArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_memb != null ? _memb.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwaAllName != null ? _gwaAllName.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwaDoctorName != null ? _gwaDoctorName.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userIdName != null ? _userIdName.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _memb;
		private String _gwa;
		private LoadColumnCodeNameInfo _gwaAllName;
		private LoadColumnCodeNameInfo _gwaDoctorName;
		private LoadColumnCodeNameInfo _userIdName;

		public String Memb
		{
			get { return this._memb; }
			set { this._memb = value; }
		}

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public LoadColumnCodeNameInfo GwaAllName
		{
			get { return this._gwaAllName; }
			set { this._gwaAllName = value; }
		}

		public LoadColumnCodeNameInfo GwaDoctorName
		{
			get { return this._gwaDoctorName; }
			set { this._gwaDoctorName = value; }
		}

		public LoadColumnCodeNameInfo UserIdName
		{
			get { return this._userIdName; }
			set { this._userIdName = value; }
		}

		public OCS0301Q09SetUserCheckBoxArgs() { }

		public OCS0301Q09SetUserCheckBoxArgs(String memb, String gwa, LoadColumnCodeNameInfo gwaAllName, LoadColumnCodeNameInfo gwaDoctorName, LoadColumnCodeNameInfo userIdName)
		{
			this._memb = memb;
			this._gwa = gwa;
			this._gwaAllName = gwaAllName;
			this._gwaDoctorName = gwaDoctorName;
			this._userIdName = userIdName;
		}

		public IExtensible GetRequestInstance()
		{
			return new IHIS.CloudConnector.Messaging.OCS0301Q09SetUserCheckBoxRequest();
		}
	}
}