using System;

namespace IHIS.CloudConnector.Contracts.Models.Injs
{
    [Serializable]
	public class INJ1001U01XEditGridCell89ItemInfo
	{
		private String _code;
		private String _codeName;
		private String _sortKey;

		public String Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public String CodeName
		{
			get { return this._codeName; }
			set { this._codeName = value; }
		}

		public String SortKey
		{
			get { return this._sortKey; }
			set { this._sortKey = value; }
		}

		public INJ1001U01XEditGridCell89ItemInfo() { }

		public INJ1001U01XEditGridCell89ItemInfo(String code, String codeName, String sortKey)
		{
			this._code = code;
			this._codeName = codeName;
			this._sortKey = sortKey;
		}

	}
}