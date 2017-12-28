using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroRES1001U00ReservationScheduleConditionListResult : AbstractContractResult
	{
		private List<NuroRES1001U00ReservationScheduleConditionListItemInfo> _resScheduleListItem = new List<NuroRES1001U00ReservationScheduleConditionListItemInfo>();

		public List<NuroRES1001U00ReservationScheduleConditionListItemInfo> ResScheduleListItem
		{
			get { return this._resScheduleListItem; }
			set { this._resScheduleListItem = value; }
		}

		public NuroRES1001U00ReservationScheduleConditionListResult() { }

	}
}