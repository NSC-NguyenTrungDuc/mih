using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
	public class LayConstantInfo
	{
		private String _code;
		private String _codeName;
		private String _codeValue;

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

		public LayConstantInfo() { }

		public LayConstantInfo(String code, String codeName, String codeValue)
		{
			this._code = code;
			this._codeName = codeName;
			this._codeValue = codeValue;
		}

	}
}