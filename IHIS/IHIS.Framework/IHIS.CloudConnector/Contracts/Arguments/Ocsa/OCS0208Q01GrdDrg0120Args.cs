using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0208Q01GrdDrg0120Args : IContractArgs
	{
    protected bool Equals(OCS0208Q01GrdDrg0120Args other)
    {
        return string.Equals(_chiryoGubun, other._chiryoGubun) && string.Equals(_banghyang, other._banghyang) && string.Equals(_jaeryoCode, other._jaeryoCode) && string.Equals(_useYn, other._useYn) && string.Equals(_bogyongGubun, other._bogyongGubun);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0208Q01GrdDrg0120Args) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_chiryoGubun != null ? _chiryoGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_banghyang != null ? _banghyang.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jaeryoCode != null ? _jaeryoCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_useYn != null ? _useYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bogyongGubun != null ? _bogyongGubun.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _chiryoGubun;
		private String _banghyang;
		private String _jaeryoCode;
		private String _useYn;
		private String _bogyongGubun;

		public String ChiryoGubun
		{
			get { return this._chiryoGubun; }
			set { this._chiryoGubun = value; }
		}

		public String Banghyang
		{
			get { return this._banghyang; }
			set { this._banghyang = value; }
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

		public String BogyongGubun
		{
			get { return this._bogyongGubun; }
			set { this._bogyongGubun = value; }
		}

		public OCS0208Q01GrdDrg0120Args() { }

		public OCS0208Q01GrdDrg0120Args(String chiryoGubun, String banghyang, String jaeryoCode, String useYn, String bogyongGubun)
		{
			this._chiryoGubun = chiryoGubun;
			this._banghyang = banghyang;
			this._jaeryoCode = jaeryoCode;
			this._useYn = useYn;
			this._bogyongGubun = bogyongGubun;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0208Q01GrdDrg0120Request();
		}
	}
}