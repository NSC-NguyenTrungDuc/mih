using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0113U00GrdOCS0103ListItemInfo
	{
		private String _slipCode;
		private String _hangmongCode;
		private String _hangmogName;

		public String SlipCode
		{
			get { return this._slipCode; }
			set { this._slipCode = value; }
		}

		public String HangmongCode
		{
			get { return this._hangmongCode; }
			set { this._hangmongCode = value; }
		}

		public String HangmogName
		{
			get { return this._hangmogName; }
			set { this._hangmogName = value; }
		}

		public OCS0113U00GrdOCS0103ListItemInfo() { }

		public OCS0113U00GrdOCS0103ListItemInfo(String slipCode, String hangmongCode, String hangmogName)
		{
			this._slipCode = slipCode;
			this._hangmongCode = hangmongCode;
			this._hangmogName = hangmogName;
		}

	}
}