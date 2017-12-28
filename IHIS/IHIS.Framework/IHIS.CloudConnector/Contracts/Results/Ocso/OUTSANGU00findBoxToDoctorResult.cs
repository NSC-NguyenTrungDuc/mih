using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocso;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OUTSANGU00findBoxToDoctorResult : AbstractContractResult
	{
		private List<OUTSANGU00findBoxToDoctorInfo> _doctorInfo = new List<OUTSANGU00findBoxToDoctorInfo>();

		public List<OUTSANGU00findBoxToDoctorInfo> DoctorInfo
		{
			get { return this._doctorInfo; }
			set { this._doctorInfo = value; }
		}

		public OUTSANGU00findBoxToDoctorResult() { }

	}
}