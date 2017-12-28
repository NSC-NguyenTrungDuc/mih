using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0108U00grdOCS0103ItemInfo
	{
		private String _slipCode;
		private String _hangmogCode;
		private String _hangmogName;
		private String _sunabDanui;
		private String _sunabDanuiName;
		private String _subulDanui;
		private String _subulDanuiName;
		private String _hangmogStartDate;

		public String SlipCode
		{
			get { return this._slipCode; }
			set { this._slipCode = value; }
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

		public String SunabDanui
		{
			get { return this._sunabDanui; }
			set { this._sunabDanui = value; }
		}

		public String SunabDanuiName
		{
			get { return this._sunabDanuiName; }
			set { this._sunabDanuiName = value; }
		}

		public String SubulDanui
		{
			get { return this._subulDanui; }
			set { this._subulDanui = value; }
		}

		public String SubulDanuiName
		{
			get { return this._subulDanuiName; }
			set { this._subulDanuiName = value; }
		}

		public String HangmogStartDate
		{
			get { return this._hangmogStartDate; }
			set { this._hangmogStartDate = value; }
		}

		public OCS0108U00grdOCS0103ItemInfo() { }

		public OCS0108U00grdOCS0103ItemInfo(String slipCode, String hangmogCode, String hangmogName, String sunabDanui, String sunabDanuiName, String subulDanui, String subulDanuiName, String hangmogStartDate)
		{
			this._slipCode = slipCode;
			this._hangmogCode = hangmogCode;
			this._hangmogName = hangmogName;
			this._sunabDanui = sunabDanui;
			this._sunabDanuiName = sunabDanuiName;
			this._subulDanui = subulDanui;
			this._subulDanuiName = subulDanuiName;
			this._hangmogStartDate = hangmogStartDate;
		}

	}
}