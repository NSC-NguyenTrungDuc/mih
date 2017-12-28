using System;

namespace IHIS.CloudConnector.Contracts.Models.Injs
{
    [Serializable]
	public class INJ1002R01LayQueryListItemInfo
	{
		private String _gwa;
		private String _buseoName;
		private String _actingDate;
		private String _hangmogCode;
		private String _hangmogName;
		private String _ordDanui;
		private String _inwonCnt;
		private String _subulSuryang;

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String BuseoName
		{
			get { return this._buseoName; }
			set { this._buseoName = value; }
		}

		public String ActingDate
		{
			get { return this._actingDate; }
			set { this._actingDate = value; }
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

		public String OrdDanui
		{
			get { return this._ordDanui; }
			set { this._ordDanui = value; }
		}

		public String InwonCnt
		{
			get { return this._inwonCnt; }
			set { this._inwonCnt = value; }
		}

		public String SubulSuryang
		{
			get { return this._subulSuryang; }
			set { this._subulSuryang = value; }
		}

		public INJ1002R01LayQueryListItemInfo() { }

		public INJ1002R01LayQueryListItemInfo(String gwa, String buseoName, String actingDate, String hangmogCode, String hangmogName, String ordDanui, String inwonCnt, String subulSuryang)
		{
			this._gwa = gwa;
			this._buseoName = buseoName;
			this._actingDate = actingDate;
			this._hangmogCode = hangmogCode;
			this._hangmogName = hangmogName;
			this._ordDanui = ordDanui;
			this._inwonCnt = inwonCnt;
			this._subulSuryang = subulSuryang;
		}

	}
}