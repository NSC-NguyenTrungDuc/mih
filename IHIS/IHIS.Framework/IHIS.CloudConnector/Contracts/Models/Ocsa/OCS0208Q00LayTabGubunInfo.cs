using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0208Q00LayTabGubunInfo
	{
		private String _code;
		private String _codeName;
		private String _code3;

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

		public String Code3
		{
			get { return this._code3; }
			set { this._code3 = value; }
		}

		public OCS0208Q00LayTabGubunInfo() { }

		public OCS0208Q00LayTabGubunInfo(String code, String codeName, String code3)
		{
			this._code = code;
			this._codeName = codeName;
			this._code3 = code3;
		}

	}
}