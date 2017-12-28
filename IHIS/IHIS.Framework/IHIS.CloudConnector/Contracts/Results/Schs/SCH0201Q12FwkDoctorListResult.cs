using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SCH0201Q12FwkDoctorListResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _fwkDoctorItem = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> FwkDoctorItem
		{
			get { return this._fwkDoctorItem; }
			set { this._fwkDoctorItem = value; }
		}

		public SCH0201Q12FwkDoctorListResult() { }

	}
}