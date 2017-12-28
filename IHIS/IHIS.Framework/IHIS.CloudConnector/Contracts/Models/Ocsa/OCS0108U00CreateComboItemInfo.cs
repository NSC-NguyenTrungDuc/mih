using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0108U00CreateComboItemInfo
	{
		private String _code;
		private String _codeName;
		private String _seq;

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

		public String Seq
		{
			get { return this._seq; }
			set { this._seq = value; }
		}

		public OCS0108U00CreateComboItemInfo() { }

		public OCS0108U00CreateComboItemInfo(String code, String codeName, String seq)
		{
			this._code = code;
			this._codeName = codeName;
			this._seq = seq;
		}

	}
}