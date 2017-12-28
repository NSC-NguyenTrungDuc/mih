using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0503Q00FdwCommonDoctorResult : AbstractContractResult
	{
		private List<OCS0503Q00DoctorListInfo> _doctorInfo = new List<OCS0503Q00DoctorListInfo>();

		public List<OCS0503Q00DoctorListInfo> DoctorInfo
		{
			get { return this._doctorInfo; }
			set { this._doctorInfo = value; }
		}

		public OCS0503Q00FdwCommonDoctorResult() { }

	}
}