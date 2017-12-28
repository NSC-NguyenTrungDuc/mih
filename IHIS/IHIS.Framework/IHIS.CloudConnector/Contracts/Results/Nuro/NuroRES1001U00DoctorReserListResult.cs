using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroRES1001U00DoctorReserListResult : AbstractContractResult
	{
		private List<NuroRES1001U00DoctorReserListItemInfo> _doctorReserListItem = new List<NuroRES1001U00DoctorReserListItemInfo>();

		public List<NuroRES1001U00DoctorReserListItemInfo> DoctorReserListItem
		{
			get { return this._doctorReserListItem; }
			set { this._doctorReserListItem = value; }
		}

		public NuroRES1001U00DoctorReserListResult() { }

	}
}