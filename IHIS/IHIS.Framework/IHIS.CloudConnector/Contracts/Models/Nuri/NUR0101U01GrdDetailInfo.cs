using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuri
{
    [Serializable]
	public class NUR0101U01GrdDetailInfo
	{
		private String _codeType;
		private String _code;
		private String _codeName;
		private String _sortKey;
		private String _key;
		private String _dataRowState;

		public String CodeType
		{
			get { return this._codeType; }
			set { this._codeType = value; }
		}

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

		public String Key
		{
			get { return this._key; }
			set { this._key = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public NUR0101U01GrdDetailInfo() { }

		public NUR0101U01GrdDetailInfo(String codeType, String code, String codeName, String sortKey, String key, String dataRowState)
		{
			this._codeType = codeType;
			this._code = code;
			this._codeName = codeName;
			this._sortKey = sortKey;
			this._key = key;
			this._dataRowState = dataRowState;
		}

	}
}