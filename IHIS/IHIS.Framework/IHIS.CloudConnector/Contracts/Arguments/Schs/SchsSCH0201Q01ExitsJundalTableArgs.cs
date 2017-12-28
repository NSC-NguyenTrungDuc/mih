using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
	public class SchsSCH0201Q01ExitsJundalTableArgs : IContractArgs
	{
    protected bool Equals(SchsSCH0201Q01ExitsJundalTableArgs other)
    {
        return string.Equals(_hangmogCode, other._hangmogCode) && string.Equals(_jundalTable, other._jundalTable);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SchsSCH0201Q01ExitsJundalTableArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_hangmogCode != null ? _hangmogCode.GetHashCode() : 0)*397) ^ (_jundalTable != null ? _jundalTable.GetHashCode() : 0);
        }
    }

    private String _hangmogCode;
		private String _jundalTable;

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public String JundalTable
		{
			get { return this._jundalTable; }
			set { this._jundalTable = value; }
		}

		public SchsSCH0201Q01ExitsJundalTableArgs() { }

		public SchsSCH0201Q01ExitsJundalTableArgs(String hangmogCode, String jundalTable)
		{
			this._hangmogCode = hangmogCode;
			this._jundalTable = jundalTable;
		}

		public IExtensible GetRequestInstance()
		{
			return new SchsSCH0201Q01ExitsJundalTableRequest();
		}
	}
}