using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
	public class BAS0001U00FbxDodobuHyeunDataValidatingInfo
	{
		private String _codeName;
		private String _sortKey;

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

		public BAS0001U00FbxDodobuHyeunDataValidatingInfo() { }

		public BAS0001U00FbxDodobuHyeunDataValidatingInfo(String codeName, String sortKey)
		{
			this._codeName = codeName;
			this._sortKey = sortKey;
		}

	}
}