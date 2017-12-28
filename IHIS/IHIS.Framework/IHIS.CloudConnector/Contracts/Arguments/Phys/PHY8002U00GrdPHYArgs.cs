using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{[Serializable]
	public class PHY8002U00GrdPHYArgs : IContractArgs
	{
    protected bool Equals(PHY8002U00GrdPHYArgs other)
    {
        return string.Equals(_fkOcs, other._fkOcs) && string.Equals(_kanjaNo, other._kanjaNo) && string.Equals(_fkOcsIrai, other._fkOcsIrai);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY8002U00GrdPHYArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_fkOcs != null ? _fkOcs.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_kanjaNo != null ? _kanjaNo.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fkOcsIrai != null ? _fkOcsIrai.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _fkOcs;
		private String _kanjaNo;
		private String _fkOcsIrai;

		public String FkOcs
		{
			get { return this._fkOcs; }
			set { this._fkOcs = value; }
		}

		public String KanjaNo
		{
			get { return this._kanjaNo; }
			set { this._kanjaNo = value; }
		}

		public String FkOcsIrai
		{
			get { return this._fkOcsIrai; }
			set { this._fkOcsIrai = value; }
		}

		public PHY8002U00GrdPHYArgs() { }

		public PHY8002U00GrdPHYArgs(String fkOcs, String kanjaNo, String fkOcsIrai)
		{
			this._fkOcs = fkOcs;
			this._kanjaNo = kanjaNo;
			this._fkOcsIrai = fkOcsIrai;
		}

		public IExtensible GetRequestInstance()
		{
			return new PHY8002U00GrdPHYRequest();
		}
	}
}