using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
	public class FindPatientFromResult : AbstractContractResult
    {
		private List<FindPatientInfo> patientInfoItem = new List<FindPatientInfo>();

	    public FindPatientFromResult()
	    {
	    }

	    public List<FindPatientInfo> PatientInfoItem
		{
			get { return this.patientInfoItem; }
			set { this.patientInfoItem = value; }
		}

	}
}
