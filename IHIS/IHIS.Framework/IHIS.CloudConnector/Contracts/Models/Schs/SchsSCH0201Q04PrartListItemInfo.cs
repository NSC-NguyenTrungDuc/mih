using System;

namespace IHIS.CloudConnector.Contracts.Models.Schs
{
    [Serializable]
	public class SchsSCH0201Q04PrartListItemInfo
	{
		private String _jundalTable;
		private String _jundalPart;
		private String _jundalPartName;

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

		public String JundalPartName
		{
			get { return this._jundalPartName; }
			set { this._jundalPartName = value; }
		}

		public SchsSCH0201Q04PrartListItemInfo() { }

		public SchsSCH0201Q04PrartListItemInfo(String jundalTable, String jundalPart, String jundalPartName)
		{
			this._jundalTable = jundalTable;
			this._jundalPart = jundalPart;
			this._jundalPartName = jundalPartName;
		}

	}
}