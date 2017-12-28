using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    [Serializable]
	public class DRG0140U00GrdColumnChangedInfo
	{
		private String _code;
		private String _code1;

		public String Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public String Code1
		{
			get { return this._code1; }
			set { this._code1 = value; }
		}

		public DRG0140U00GrdColumnChangedInfo() { }

		public DRG0140U00GrdColumnChangedInfo(String code, String code1)
		{
			this._code = code;
			this._code1 = code1;
		}

	}
}