using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
	public class XRT0000Q00LayPacsInfoListItemInfo
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

		public XRT0000Q00LayPacsInfoListItemInfo() { }

		public XRT0000Q00LayPacsInfoListItemInfo(String code, String codeName, String codeValue)
		{
			this._code = code;
			this._codeName = codeName;
			this._codeValue = codeValue;
		}

	}
}