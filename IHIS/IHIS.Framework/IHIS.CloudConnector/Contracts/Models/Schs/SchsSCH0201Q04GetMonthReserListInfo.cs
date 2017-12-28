using System;

namespace IHIS.CloudConnector.Contracts.Models.Schs
{
    [Serializable]
	public class SchsSCH0201Q04GetMonthReserListInfo
	{
		private String _holiDay;
		private String _reserCnt;
		private String _inwonCnt;

		public String HoliDay
		{
			get { return this._holiDay; }
			set { this._holiDay = value; }
		}

		public String ReserCnt
		{
			get { return this._reserCnt; }
			set { this._reserCnt = value; }
		}

		public String InwonCnt
		{
			get { return this._inwonCnt; }
			set { this._inwonCnt = value; }
		}

		public SchsSCH0201Q04GetMonthReserListInfo() { }

		public SchsSCH0201Q04GetMonthReserListInfo(String holiDay, String reserCnt, String inwonCnt)
		{
			this._holiDay = holiDay;
			this._reserCnt = reserCnt;
			this._inwonCnt = inwonCnt;
		}

	}
}