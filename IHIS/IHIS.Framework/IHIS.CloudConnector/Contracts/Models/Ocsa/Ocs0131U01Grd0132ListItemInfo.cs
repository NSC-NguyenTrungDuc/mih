using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class Ocs0131U01Grd0132ListItemInfo
	{
		private String _code;
		private String _codeName;
		private String _sortKey;
		private String _groupKey;
		private String _ment;
		private String _valuePoint;
		private String _userId;
		private String _codeType;
		private String _dataRowState;

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

		public String GroupKey
		{
			get { return this._groupKey; }
			set { this._groupKey = value; }
		}

		public String Ment
		{
			get { return this._ment; }
			set { this._ment = value; }
		}

		public String ValuePoint
		{
			get { return this._valuePoint; }
			set { this._valuePoint = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public String CodeType
		{
			get { return this._codeType; }
			set { this._codeType = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public Ocs0131U01Grd0132ListItemInfo() { }

		public Ocs0131U01Grd0132ListItemInfo(String code, String codeName, String sortKey, String groupKey, String ment, String valuePoint, String userId, String codeType, String dataRowState)
		{
			this._code = code;
			this._codeName = codeName;
			this._sortKey = sortKey;
			this._groupKey = groupKey;
			this._ment = ment;
			this._valuePoint = valuePoint;
			this._userId = userId;
			this._codeType = codeType;
			this._dataRowState = dataRowState;
		}

	}
}