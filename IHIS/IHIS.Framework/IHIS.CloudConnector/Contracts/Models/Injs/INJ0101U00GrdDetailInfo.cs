using System;

namespace IHIS.CloudConnector.Contracts.Models.Injs
{
    [Serializable]
	public class INJ0101U00GrdDetailInfo
	{
		private String _codeType;
		private String _code;
		private String _codeName;
		private String _rowState;

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

		public String RowState
		{
			get { return this._rowState; }
			set { this._rowState = value; }
		}

		public INJ0101U00GrdDetailInfo() { }

		public INJ0101U00GrdDetailInfo(String codeType, String code, String codeName, String rowState)
		{
			this._codeType = codeType;
			this._code = code;
			this._codeName = codeName;
			this._rowState = rowState;
		}

	}
}