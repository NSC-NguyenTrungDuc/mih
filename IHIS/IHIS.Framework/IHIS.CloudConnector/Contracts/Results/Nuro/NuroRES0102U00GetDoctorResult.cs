using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroRES0102U00GetDoctorResult : AbstractContractResult
	{
		private List<NuroRES0102U00GetDoctorInfo> _doctorItem = new List<NuroRES0102U00GetDoctorInfo>();

		public List<NuroRES0102U00GetDoctorInfo> DoctorItem
		{
			get { return this._doctorItem; }
			set { this._doctorItem = value; }
		}

		public NuroRES0102U00GetDoctorResult() { }

	}
}