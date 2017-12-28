using System;

namespace IHIS.CloudConnector.Contracts.Models.Phys
{
    [Serializable]
	public class PHY0001U00GrdRehaSinryouryouCodeInfo
	{
		private String _code;
		private String _hangmogCode;
		private String _hangmogName;
		private String _rowState;

		public String Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public String HangmogName
		{
			get { return this._hangmogName; }
			set { this._hangmogName = value; }
		}

		public String RowState
		{
			get { return this._rowState; }
			set { this._rowState = value; }
		}

		public PHY0001U00GrdRehaSinryouryouCodeInfo() { }

		public PHY0001U00GrdRehaSinryouryouCodeInfo(String code, String hangmogCode, String hangmogName, String rowState)
		{
			this._code = code;
			this._hangmogCode = hangmogCode;
			this._hangmogName = hangmogName;
			this._rowState = rowState;
		}

	}
}