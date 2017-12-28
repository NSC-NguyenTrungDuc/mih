using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0103U12LayDrugTreeInfo
	{
		private String _code;
		private String _codeName;
		private String _code1;
		private String _codeName1;

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

		public String Code1
		{
			get { return this._code1; }
			set { this._code1 = value; }
		}

		public String CodeName1
		{
			get { return this._codeName1; }
			set { this._codeName1 = value; }
		}

		public OCS0103U12LayDrugTreeInfo() { }

		public OCS0103U12LayDrugTreeInfo(String code, String codeName, String code1, String codeName1)
		{
			this._code = code;
			this._codeName = codeName;
			this._code1 = code1;
			this._codeName1 = codeName1;
		}

	}
}