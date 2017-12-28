using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
	public class BAS0210U00grdBAS0210GridColumnChangedItemInfo
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

		public BAS0210U00grdBAS0210GridColumnChangedItemInfo() { }

		public BAS0210U00grdBAS0210GridColumnChangedItemInfo(String code, String codeName)
		{
			this._code = code;
			this._codeName = codeName;
		}

	}
}