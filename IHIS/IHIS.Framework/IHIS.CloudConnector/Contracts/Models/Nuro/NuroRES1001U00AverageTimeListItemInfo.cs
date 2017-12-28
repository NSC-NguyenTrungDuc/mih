using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
	public class NuroRES1001U00AverageTimeListItemInfo
	{
		private String _avgTime;
		private String _docResLimit;

		public String AvgTime
		{
			get { return this._avgTime; }
			set { this._avgTime = value; }
		}

		public String DocResLimit
		{
			get { return this._docResLimit; }
			set { this._docResLimit = value; }
		}

		public NuroRES1001U00AverageTimeListItemInfo() { }

		public NuroRES1001U00AverageTimeListItemInfo(String avgTime, String docResLimit)
		{
			this._avgTime = avgTime;
			this._docResLimit = docResLimit;
		}

	}
}