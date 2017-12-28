using IHIS.CloudConnector.Contracts.Models.Nuro;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class RES1001U00ReservationScheduleListGroupedResult : AbstractContractResult
	{
		private List<NuroRES1001U00ReservationScheduleConditionListItemInfo> _resScheduleConditionListItem = new List<NuroRES1001U00ReservationScheduleConditionListItemInfo>();
		private List<NuroRES1001U00AverageTimeListItemInfo> _avgTimeListItem = new List<NuroRES1001U00AverageTimeListItemInfo>();
		private List<NuroRES1001U00ReservationScheduleListItemInfo> _resScheduleAmListItem = new List<NuroRES1001U00ReservationScheduleListItemInfo>();
		private List<NuroRES1001U00ReservationScheduleListItemInfo> _resSchedulePmListItem = new List<NuroRES1001U00ReservationScheduleListItemInfo>();

		public List<NuroRES1001U00ReservationScheduleConditionListItemInfo> ResScheduleConditionListItem
		{
			get { return this._resScheduleConditionListItem; }
			set { this._resScheduleConditionListItem = value; }
		}

		public List<NuroRES1001U00AverageTimeListItemInfo> AvgTimeListItem
		{
			get { return this._avgTimeListItem; }
			set { this._avgTimeListItem = value; }
		}

		public List<NuroRES1001U00ReservationScheduleListItemInfo> ResScheduleAmListItem
		{
			get { return this._resScheduleAmListItem; }
			set { this._resScheduleAmListItem = value; }
		}

		public List<NuroRES1001U00ReservationScheduleListItemInfo> ResSchedulePmListItem
		{
			get { return this._resSchedulePmListItem; }
			set { this._resSchedulePmListItem = value; }
		}

		public RES1001U00ReservationScheduleListGroupedResult() { }

	}
}