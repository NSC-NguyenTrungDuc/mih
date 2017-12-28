using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OcsoOCS1003P01CheckUsedSangArgs : IContractArgs
	{
    protected bool Equals(OcsoOCS1003P01CheckUsedSangArgs other)
    {
        return string.Equals(_fkOutSang, other._fkOutSang) && string.Equals(_dataKubun, other._dataKubun);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsoOCS1003P01CheckUsedSangArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_fkOutSang != null ? _fkOutSang.GetHashCode() : 0)*397) ^ (_dataKubun != null ? _dataKubun.GetHashCode() : 0);
        }
    }

    private String _fkOutSang;
		private String _dataKubun;

		public String FkOutSang
		{
			get { return this._fkOutSang; }
			set { this._fkOutSang = value; }
		}

		public String DataKubun
		{
			get { return this._dataKubun; }
			set { this._dataKubun = value; }
		}

		public OcsoOCS1003P01CheckUsedSangArgs() { }

		public OcsoOCS1003P01CheckUsedSangArgs(String fkOutSang, String dataKubun)
		{
			this._fkOutSang = fkOutSang;
			this._dataKubun = dataKubun;
		}

		public IExtensible GetRequestInstance()
		{
			return new OcsoOCS1003P01CheckUsedSangRequest();
		}
	}
}