using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0103U10GrdGeneralInfo
	{
		private String _slipCode;
		private String _slipName;
		private String _hangmogCode;
		private String _hangmogName;
		private String _wonnaeDrgYn;

		public String SlipCode
		{
			get { return this._slipCode; }
			set { this._slipCode = value; }
		}

		public String SlipName
		{
			get { return this._slipName; }
			set { this._slipName = value; }
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

		public String WonnaeDrgYn
		{
			get { return this._wonnaeDrgYn; }
			set { this._wonnaeDrgYn = value; }
		}

		public OCS0103U10GrdGeneralInfo() { }

		public OCS0103U10GrdGeneralInfo(String slipCode, String slipName, String hangmogCode, String hangmogName, String wonnaeDrgYn)
		{
			this._slipCode = slipCode;
			this._slipName = slipName;
			this._hangmogCode = hangmogCode;
			this._hangmogName = hangmogName;
			this._wonnaeDrgYn = wonnaeDrgYn;
		}

	}
}