using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0208Q01GrdChiryoGubunArgs : IContractArgs
	{
    protected bool Equals(OCS0208Q01GrdChiryoGubunArgs other)
    {
        return string.Equals(_bogyongGubun, other._bogyongGubun) && string.Equals(_jaeryoCode, other._jaeryoCode) && string.Equals(_useYn, other._useYn);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0208Q01GrdChiryoGubunArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_bogyongGubun != null ? _bogyongGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jaeryoCode != null ? _jaeryoCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_useYn != null ? _useYn.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _bogyongGubun;
		private String _jaeryoCode;
		private String _useYn;

		public String BogyongGubun
		{
			get { return this._bogyongGubun; }
			set { this._bogyongGubun = value; }
		}

		public String JaeryoCode
		{
			get { return this._jaeryoCode; }
			set { this._jaeryoCode = value; }
		}

		public String UseYn
		{
			get { return this._useYn; }
			set { this._useYn = value; }
		}

		public OCS0208Q01GrdChiryoGubunArgs() { }

		public OCS0208Q01GrdChiryoGubunArgs(String bogyongGubun, String jaeryoCode, String useYn)
		{
			this._bogyongGubun = bogyongGubun;
			this._jaeryoCode = jaeryoCode;
			this._useYn = useYn;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0208Q01GrdChiryoGubunRequest();
		}
	}
}