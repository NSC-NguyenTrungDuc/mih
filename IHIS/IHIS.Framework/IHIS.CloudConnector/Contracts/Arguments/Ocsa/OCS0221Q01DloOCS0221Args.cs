using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0221Q01DloOCS0221Args : IContractArgs
	{
    protected bool Equals(OCS0221Q01DloOCS0221Args other)
    {
        return string.Equals(_categoryGubun, other._categoryGubun) && string.Equals(_memb, other._memb);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0221Q01DloOCS0221Args) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_categoryGubun != null ? _categoryGubun.GetHashCode() : 0)*397) ^ (_memb != null ? _memb.GetHashCode() : 0);
        }
    }

    private String _categoryGubun;
		private String _memb;

		public String CategoryGubun
		{
			get { return this._categoryGubun; }
			set { this._categoryGubun = value; }
		}

		public String Memb
		{
			get { return this._memb; }
			set { this._memb = value; }
		}

		public OCS0221Q01DloOCS0221Args() { }

		public OCS0221Q01DloOCS0221Args(String categoryGubun, String memb)
		{
			this._categoryGubun = categoryGubun;
			this._memb = memb;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0221Q01DloOCS0221Request();
		}
	}
}