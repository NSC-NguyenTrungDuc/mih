using System;

namespace IHIS.CloudConnector.Contracts.Models.Schs
{
    [Serializable]
	public class SCH3001U00GrdJukyongDateInfo
	{
		private String _jukyongDate;
		private String _jundalTable;
		private String _jundalPart;
		private String _gumsaja;
		private String _oldJukyongDate;
		private String _monDay;
		private String _tueDay;
		private String _wedDay;
		private String _thuDay;
		private String _friDay;
		private String _staDay;
		private String _sunDay;
		private String _dataRowState;

		public String JukyongDate
		{
			get { return this._jukyongDate; }
			set { this._jukyongDate = value; }
		}

		public String JundalTable
		{
			get { return this._jundalTable; }
			set { this._jundalTable = value; }
		}

		public String JundalPart
		{
			get { return this._jundalPart; }
			set { this._jundalPart = value; }
		}

		public String Gumsaja
		{
			get { return this._gumsaja; }
			set { this._gumsaja = value; }
		}

		public String OldJukyongDate
		{
			get { return this._oldJukyongDate; }
			set { this._oldJukyongDate = value; }
		}

		public String MonDay
		{
			get { return this._monDay; }
			set { this._monDay = value; }
		}

		public String TueDay
		{
			get { return this._tueDay; }
			set { this._tueDay = value; }
		}

		public String WedDay
		{
			get { return this._wedDay; }
			set { this._wedDay = value; }
		}

		public String ThuDay
		{
			get { return this._thuDay; }
			set { this._thuDay = value; }
		}

		public String FriDay
		{
			get { return this._friDay; }
			set { this._friDay = value; }
		}

		public String StaDay
		{
			get { return this._staDay; }
			set { this._staDay = value; }
		}

		public String SunDay
		{
			get { return this._sunDay; }
			set { this._sunDay = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public SCH3001U00GrdJukyongDateInfo() { }

		public SCH3001U00GrdJukyongDateInfo(String jukyongDate, String jundalTable, String jundalPart, String gumsaja, String oldJukyongDate, String monDay, String tueDay, String wedDay, String thuDay, String friDay, String staDay, String sunDay, String dataRowState)
		{
			this._jukyongDate = jukyongDate;
			this._jundalTable = jundalTable;
			this._jundalPart = jundalPart;
			this._gumsaja = gumsaja;
			this._oldJukyongDate = oldJukyongDate;
			this._monDay = monDay;
			this._tueDay = tueDay;
			this._wedDay = wedDay;
			this._thuDay = thuDay;
			this._friDay = friDay;
			this._staDay = staDay;
			this._sunDay = sunDay;
			this._dataRowState = dataRowState;
		}

	}
}