using System;

namespace IHIS.CloudConnector.Contracts.Models.Chts
{
    [Serializable]
	public class CHT0117Q00DloCHT0117Info
	{
		private String _startDate;
		private String _endDate;
		private String _buwi;
		private String _buwiName;

		public String StartDate
		{
			get { return this._startDate; }
			set { this._startDate = value; }
		}

		public String EndDate
		{
			get { return this._endDate; }
			set { this._endDate = value; }
		}

		public String Buwi
		{
			get { return this._buwi; }
			set { this._buwi = value; }
		}

		public String BuwiName
		{
			get { return this._buwiName; }
			set { this._buwiName = value; }
		}

		public CHT0117Q00DloCHT0117Info() { }

		public CHT0117Q00DloCHT0117Info(String startDate, String endDate, String buwi, String buwiName)
		{
			this._startDate = startDate;
			this._endDate = endDate;
			this._buwi = buwi;
			this._buwiName = buwiName;
		}

	}
}