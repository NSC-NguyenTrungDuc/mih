using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
	public class SCH3001U00GrdSCH0001Args : IContractArgs
	{
    protected bool Equals(SCH3001U00GrdSCH0001Args other)
    {
        return string.Equals(_jundalTable, other._jundalTable);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SCH3001U00GrdSCH0001Args) obj);
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

		public SCH3001U00GrdSCH0001Args() { }

		public SCH3001U00GrdSCH0001Args(String jundalTable)
		{
			this._jundalTable = jundalTable;
		}

		public IExtensible GetRequestInstance()
		{
			return new SCH3001U00GrdSCH0001Request();
		}
	}
}