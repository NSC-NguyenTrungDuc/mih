using System;

namespace IHIS.CloudConnector.Contracts.Models.Schs
{
    [Serializable]
	public class SCH0109U00GrdDetailInfo
	{
		private String _codeType;
		private String _code;
		private String _codeName;
		private String _codeName2;
		private String _code2;
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

		public String CodeName2
		{
			get { return this._codeName2; }
			set { this._codeName2 = value; }
		}

		public String Code2
		{
			get { return this._code2; }
			set { this._code2 = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public SCH0109U00GrdDetailInfo() { }

		public SCH0109U00GrdDetailInfo(String codeType, String code, String codeName, String codeName2, String code2, String dataRowState)
		{
			this._codeType = codeType;
			this._code = code;
			this._codeName = codeName;
			this._codeName2 = codeName2;
			this._code2 = code2;
			this._dataRowState = dataRowState;
		}

	}
}