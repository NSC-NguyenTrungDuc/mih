using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
	public class NuroRES1001U00ReservationScheduleConditionListItemInfo
	{
		private String _amStartTime;
		private String _amEndTime;
		private String _pmStartTime;
		private String _pmEndTime;

		public String AmStartTime
		{
			get { return this._amStartTime; }
			set { this._amStartTime = value; }
		}

		public String AmEndTime
		{
			get { return this._amEndTime; }
			set { this._amEndTime = value; }
		}

		public String PmStartTime
		{
			get { return this._pmStartTime; }
			set { this._pmStartTime = value; }
		}

		public String PmEndTime
		{
			get { return this._pmEndTime; }
			set { this._pmEndTime = value; }
		}

		public NuroRES1001U00ReservationScheduleConditionListItemInfo() { }

		public NuroRES1001U00ReservationScheduleConditionListItemInfo(String amStartTime, String amEndTime, String pmStartTime, String pmEndTime)
		{
			this._amStartTime = amStartTime;
			this._amEndTime = amEndTime;
			this._pmStartTime = pmStartTime;
			this._pmEndTime = pmEndTime;
		}

	}
}