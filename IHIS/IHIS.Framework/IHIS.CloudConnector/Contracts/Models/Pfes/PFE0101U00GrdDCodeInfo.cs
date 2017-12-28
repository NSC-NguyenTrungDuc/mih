using System;

namespace IHIS.CloudConnector.Contracts.Models.Pfes
{
    [Serializable]
	public class PFE0101U00GrdDCodeInfo
	{
		private String _codeType;
		private String _code;
		private String _codeName;
		private String _codeNameRe;
		private String _codeValue;

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

		public String CodeNameRe
		{
			get { return this._codeNameRe; }
			set { this._codeNameRe = value; }
		}

		public String CodeValue
		{
			get { return this._codeValue; }
			set { this._codeValue = value; }
		}

		public PFE0101U00GrdDCodeInfo() { }

		public PFE0101U00GrdDCodeInfo(String codeType, String code, String codeName, String codeNameRe, String codeValue)
		{
			this._codeType = codeType;
			this._code = code;
			this._codeName = codeName;
			this._codeNameRe = codeNameRe;
			this._codeValue = codeValue;
		}

	}
}