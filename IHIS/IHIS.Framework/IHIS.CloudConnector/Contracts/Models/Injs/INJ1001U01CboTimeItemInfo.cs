using System;

namespace IHIS.CloudConnector.Contracts.Models.Injs
{
    [Serializable]
	public class INJ1001U01CboTimeItemInfo
	{
		private String _code;
		private String _codeName;

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

		public INJ1001U01CboTimeItemInfo() { }

		public INJ1001U01CboTimeItemInfo(String code, String codeName)
		{
			this._code = code;
			this._codeName = codeName;
		}

	}
}