using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroPatientInsuranceListResult : AbstractContractResult
	{
		private List<NuroPatientInsuranceListItemInfo> _patientInsurListItem = new List<NuroPatientInsuranceListItemInfo>();

		public List<NuroPatientInsuranceListItemInfo> PatientInsurListItem
		{
			get { return this._patientInsurListItem; }
			set { this._patientInsurListItem = value; }
		}

		public NuroPatientInsuranceListResult() { }

	}
}
