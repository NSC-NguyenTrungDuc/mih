using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0221Q01GrdOCS0222Args : IContractArgs
	{
    protected bool Equals(OCS0221Q01GrdOCS0222Args other)
    {
        return string.Equals(_memb, other._memb) && string.Equals(_seq, other._seq);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0221Q01GrdOCS0222Args) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_memb != null ? _memb.GetHashCode() : 0)*397) ^ (_seq != null ? _seq.GetHashCode() : 0);
        }
    }

    private String _memb;
		private String _seq;

		public String Memb
		{
			get { return this._memb; }
			set { this._memb = value; }
		}

		public String Seq
		{
			get { return this._seq; }
			set { this._seq = value; }
		}

		public OCS0221Q01GrdOCS0222Args() { }

		public OCS0221Q01GrdOCS0222Args(String memb, String seq)
		{
			this._memb = memb;
			this._seq = seq;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0221Q01GrdOCS0222Request();
		}
	}
}