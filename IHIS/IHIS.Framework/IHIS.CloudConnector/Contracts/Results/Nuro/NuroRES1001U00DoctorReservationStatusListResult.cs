using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroRES1001U00DoctorReservationStatusListResult : AbstractContractResult
	{
		private List<NuroRES1001U00DoctorReservationStatusListItemInfo> _doctorResStatusListItem = new List<NuroRES1001U00DoctorReservationStatusListItemInfo>();

		public List<NuroRES1001U00DoctorReservationStatusListItemInfo> DoctorResStatusListItem
		{
			get { return this._doctorResStatusListItem; }
			set { this._doctorResStatusListItem = value; }
		}

		public NuroRES1001U00DoctorReservationStatusListResult() { }

	}
}