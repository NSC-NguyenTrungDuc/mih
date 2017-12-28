using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroPatientReceptionHistoryListResult : AbstractContractResult
	{
		private List<NuroPatientReceptionHistoryListItemInfo> _patientReceptionHistoryListItem = new List<NuroPatientReceptionHistoryListItemInfo>();

		public List<NuroPatientReceptionHistoryListItemInfo> PatientReceptionHistoryListItem
		{
			get { return this._patientReceptionHistoryListItem; }
			set { this._patientReceptionHistoryListItem = value; }
		}

		public NuroPatientReceptionHistoryListResult() { }

	}
}

