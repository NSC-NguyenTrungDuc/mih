using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0301Q09GrdOCS0301Args : IContractArgs
	{
    protected bool Equals(OCS0301Q09GrdOCS0301Args other)
    {
        return string.Equals(_memb, other._memb) && string.Equals(_yaksokCode, other._yaksokCode) && string.Equals(_inputTab, other._inputTab);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0301Q09GrdOCS0301Args) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_memb != null ? _memb.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_yaksokCode != null ? _yaksokCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputTab != null ? _inputTab.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _memb;
		private String _yaksokCode;
		private String _inputTab;

		public String Memb
		{
			get { return this._memb; }
			set { this._memb = value; }
		}

		public String YaksokCode
		{
			get { return this._yaksokCode; }
			set { this._yaksokCode = value; }
		}

		public String InputTab
		{
			get { return this._inputTab; }
			set { this._inputTab = value; }
		}

		public OCS0301Q09GrdOCS0301Args() { }

		public OCS0301Q09GrdOCS0301Args(String memb, String yaksokCode, String inputTab)
		{
			this._memb = memb;
			this._yaksokCode = yaksokCode;
			this._inputTab = inputTab;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0301Q09GrdOCS0301Request();
		}
	}
}