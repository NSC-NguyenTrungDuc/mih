using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroNUR2001U04DoctorNameResult : AbstractContractResult
	{
		private List<DataStringListItemInfo> _doctorName = new List<DataStringListItemInfo>();

		public List<DataStringListItemInfo> DoctorName
		{
			get { return this._doctorName; }
			set { this._doctorName = value; }
		}

		public NuroNUR2001U04DoctorNameResult() { }

	}
}