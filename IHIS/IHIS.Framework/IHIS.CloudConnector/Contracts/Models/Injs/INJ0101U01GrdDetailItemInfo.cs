using System;

namespace IHIS.CloudConnector.Contracts.Models.Injs
{
    [Serializable]
	public class INJ0101U01GrdDetailItemInfo
	{
		private String _codeType;
		private String _code;
		private String _codeName;
		private String _remark;
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

		public String Remark
		{
			get { return this._remark; }
			set { this._remark = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public INJ0101U01GrdDetailItemInfo() { }

		public INJ0101U01GrdDetailItemInfo(String codeType, String code, String codeName, String remark, String dataRowState)
		{
			this._codeType = codeType;
			this._code = code;
			this._codeName = codeName;
			this._remark = remark;
			this._dataRowState = dataRowState;
		}

	}
}