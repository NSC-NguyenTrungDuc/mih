using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OUTSANGU00InitializeArgs : IContractArgs
	{
    protected bool Equals(OUTSANGU00InitializeArgs other)
    {
        return string.Equals(_bunho, other._bunho) && string.Equals(_gwa, other._gwa) && string.Equals(_ioGubun, other._ioGubun) && string.Equals(_allSangYn, other._allSangYn) && string.Equals(_gijunDate, other._gijunDate);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OUTSANGU00InitializeArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_allSangYn != null ? _allSangYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gijunDate != null ? _gijunDate.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _bunho;
		private String _gwa;
		private String _ioGubun;
		private String _allSangYn;
		private String _gijunDate;

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

		public String IoGubun
		{
			get { return this._ioGubun; }
			set { this._ioGubun = value; }
		}

		public String AllSangYn
		{
			get { return this._allSangYn; }
			set { this._allSangYn = value; }
		}

		public String GijunDate
		{
			get { return this._gijunDate; }
			set { this._gijunDate = value; }
		}

		public OUTSANGU00InitializeArgs() { }

		public OUTSANGU00InitializeArgs(String bunho, String gwa, String ioGubun, String allSangYn, String gijunDate)
		{
			this._bunho = bunho;
			this._gwa = gwa;
			this._ioGubun = ioGubun;
			this._allSangYn = allSangYn;
			this._gijunDate = gijunDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new OUTSANGU00InitializeRequest();
		}
	}
}