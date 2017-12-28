using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
	public class BAS0101U04GrdDetailInfo
	{
		private String _codeType;
		private String _code;
		private String _codeName;
		private String _groupKey;
		private String _remark;
		private String _sortKey;
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

		public String GroupKey
		{
			get { return this._groupKey; }
			set { this._groupKey = value; }
		}

		public String Remark
		{
			get { return this._remark; }
			set { this._remark = value; }
		}

		public String SortKey
		{
			get { return this._sortKey; }
			set { this._sortKey = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public BAS0101U04GrdDetailInfo() { }

		public BAS0101U04GrdDetailInfo(String codeType, String code, String codeName, String groupKey, String remark, String sortKey, String dataRowState)
		{
			this._codeType = codeType;
			this._code = code;
			this._codeName = codeName;
			this._groupKey = groupKey;
			this._remark = remark;
			this._sortKey = sortKey;
			this._dataRowState = dataRowState;
		}

	}
}