using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OcsoOCS1003P01UpdateJubsuArgs : IContractArgs
	{
    protected bool Equals(OcsoOCS1003P01UpdateJubsuArgs other)
    {
        return string.Equals(_naewonYn, other._naewonYn) && string.Equals(_pkNaewonKey, other._pkNaewonKey);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsoOCS1003P01UpdateJubsuArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_naewonYn != null ? _naewonYn.GetHashCode() : 0)*397) ^ (_pkNaewonKey != null ? _pkNaewonKey.GetHashCode() : 0);
        }
    }

    private String _naewonYn;
		private String _pkNaewonKey;

		public String NaewonYn
		{
			get { return this._naewonYn; }
			set { this._naewonYn = value; }
		}

		public String PkNaewonKey
		{
			get { return this._pkNaewonKey; }
			set { this._pkNaewonKey = value; }
		}

		public OcsoOCS1003P01UpdateJubsuArgs() { }

		public OcsoOCS1003P01UpdateJubsuArgs(String naewonYn, String pkNaewonKey)
		{
			this._naewonYn = naewonYn;
			this._pkNaewonKey = pkNaewonKey;
		}

		public IExtensible GetRequestInstance()
		{
			return new OcsoOCS1003P01UpdateJubsuRequest();
		}
	}
}