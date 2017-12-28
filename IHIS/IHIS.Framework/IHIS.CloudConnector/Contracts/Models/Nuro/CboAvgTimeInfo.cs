using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
	public class CboAvgTimeInfo
	{
		private String _timeTerm;
		private String _timeTerm2;

		public String TimeTerm
		{
			get { return this._timeTerm; }
			set { this._timeTerm = value; }
		}

		public String TimeTerm2
		{
			get { return this._timeTerm2; }
			set { this._timeTerm2 = value; }
		}

		public CboAvgTimeInfo() { }

		public CboAvgTimeInfo(String timeTerm, String timeTerm2)
		{
			this._timeTerm = timeTerm;
			this._timeTerm2 = timeTerm2;
		}

	}
}