using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroRES0102U00GridDoctorResult : AbstractContractResult
	{
		private List<NuroRES0102U00GridDoctorInfo> _doctorItem = new List<NuroRES0102U00GridDoctorInfo>();

		public List<NuroRES0102U00GridDoctorInfo> DoctorItem
		{
			get { return this._doctorItem; }
			set { this._doctorItem = value; }
		}

		public NuroRES0102U00GridDoctorResult() { }

	}
}