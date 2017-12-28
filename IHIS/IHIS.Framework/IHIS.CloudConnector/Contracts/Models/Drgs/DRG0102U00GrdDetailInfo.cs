using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    [Serializable]
	public class DRG0102U00GrdDetailInfo
	{
		private String _codeType;
		private String _code;
		private String _codeName;
		private String _codeValue;
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

		public String CodeValue
		{
			get { return this._codeValue; }
			set { this._codeValue = value; }
		}

		public String RowState
		{
			get { return this._rowState; }
			set { this._rowState = value; }
		}

		public DRG0102U00GrdDetailInfo() { }

		public DRG0102U00GrdDetailInfo(String codeType, String code, String codeName, String codeValue, String rowState)
		{
			this._codeType = codeType;
			this._code = code;
			this._codeName = codeName;
			this._codeValue = codeValue;
			this._rowState = rowState;
		}

	}
}