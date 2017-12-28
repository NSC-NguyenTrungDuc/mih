using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
	public class SchsSCH0201U99GetJundalPartNameArgs : IContractArgs
	{
    protected bool Equals(SchsSCH0201U99GetJundalPartNameArgs other)
    {
        return string.Equals(_ioGubun, other._ioGubun) && string.Equals(_jundalPart, other._jundalPart) && string.Equals(_today, other._today);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SchsSCH0201U99GetJundalPartNameArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jundalPart != null ? _jundalPart.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_today != null ? _today.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _ioGubun;
		private String _jundalPart;
		private String _today;

		public String IoGubun
		{
			get { return this._ioGubun; }
			set { this._ioGubun = value; }
		}

		public String JundalPart
		{
			get { return this._jundalPart; }
			set { this._jundalPart = value; }
		}

		public String Today
		{
			get { return this._today; }
			set { this._today = value; }
		}

		public SchsSCH0201U99GetJundalPartNameArgs() { }

		public SchsSCH0201U99GetJundalPartNameArgs(String ioGubun, String jundalPart, String today)
		{
			this._ioGubun = ioGubun;
			this._jundalPart = jundalPart;
			this._today = today;
		}

		public IExtensible GetRequestInstance()
		{
			return new SchsSCH0201U99GetJundalPartNameRequest();
		}
	}
}