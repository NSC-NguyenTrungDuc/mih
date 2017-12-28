using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroRES1001U00ReservationScheduleListResult : AbstractContractResult
	{
		private List<NuroRES1001U00ReservationScheduleListItemInfo> _resScheduleListItem = new List<NuroRES1001U00ReservationScheduleListItemInfo>();

		public List<NuroRES1001U00ReservationScheduleListItemInfo> ResScheduleListItem
		{
			get { return this._resScheduleListItem; }
			set { this._resScheduleListItem = value; }
		}

		public NuroRES1001U00ReservationScheduleListResult() { }

	}
}