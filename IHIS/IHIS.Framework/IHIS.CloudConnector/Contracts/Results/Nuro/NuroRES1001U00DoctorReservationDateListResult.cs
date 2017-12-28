using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroRES1001U00DoctorReservationDateListResult : AbstractContractResult
	{
		private List<NuroRES1001U00DoctorReservationDateListItemInfo> _doctorResDateListItem = new List<NuroRES1001U00DoctorReservationDateListItemInfo>();

		public List<NuroRES1001U00DoctorReservationDateListItemInfo> DoctorResDateListItem
		{
			get { return this._doctorResDateListItem; }
			set { this._doctorResDateListItem = value; }
		}

		public NuroRES1001U00DoctorReservationDateListResult() { }

	}
}