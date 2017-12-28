using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
	public class SchsSCH0201Q04GetMonthReserListInfoArgs : IContractArgs
	{
    protected bool Equals(SchsSCH0201Q04GetMonthReserListInfoArgs other)
    {
        return string.Equals(_month, other._month) && string.Equals(_jundalTable, other._jundalTable) && string.Equals(_jundalPart, other._jundalPart);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SchsSCH0201Q04GetMonthReserListInfoArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_month != null ? _month.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jundalTable != null ? _jundalTable.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jundalPart != null ? _jundalPart.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _month;
		private String _jundalTable;
		private String _jundalPart;

		public String Month
		{
			get { return this._month; }
			set { this._month = value; }
		}

		public String JundalTable
		{
			get { return this._jundalTable; }
			set { this._jundalTable = value; }
		}

		public String JundalPart
		{
			get { return this._jundalPart; }
			set { this._jundalPart = value; }
		}

		public SchsSCH0201Q04GetMonthReserListInfoArgs() { }

		public SchsSCH0201Q04GetMonthReserListInfoArgs(String month, String jundalTable, String jundalPart)
		{
			this._month = month;
			this._jundalTable = jundalTable;
			this._jundalPart = jundalPart;
		}

		public IExtensible GetRequestInstance()
		{
			return new SchsSCH0201Q04GetMonthReserListInfoRequest();
		}
	}
}