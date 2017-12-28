using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Nuts
{
    [Serializable]
	public class NUT0001U00LoadDoctorGwaResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _doctorGwaInfo = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> DoctorGwaInfo
		{
			get { return this._doctorGwaInfo; }
			set { this._doctorGwaInfo = value; }
		}

		public NUT0001U00LoadDoctorGwaResult() { }

	}
}