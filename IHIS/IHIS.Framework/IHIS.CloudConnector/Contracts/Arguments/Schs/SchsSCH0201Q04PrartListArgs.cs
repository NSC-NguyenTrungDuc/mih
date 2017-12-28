using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
	public class SchsSCH0201Q04PrartListArgs : IContractArgs
	{
    protected bool Equals(SchsSCH0201Q04PrartListArgs other)
    {
        return string.Equals(_jundalTable, other._jundalTable);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SchsSCH0201Q04PrartListArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_jundalTable != null ? _jundalTable.GetHashCode() : 0);
    }

    private String _jundalTable;

		public String JundalTable
		{
			get { return this._jundalTable; }
			set { this._jundalTable = value; }
		}

		public SchsSCH0201Q04PrartListArgs() { }

		public SchsSCH0201Q04PrartListArgs(String jundalTable)
		{
			this._jundalTable = jundalTable;
		}

		public IExtensible GetRequestInstance()
		{
			return new SchsSCH0201Q04PrartListRequest();
		}
	}
}