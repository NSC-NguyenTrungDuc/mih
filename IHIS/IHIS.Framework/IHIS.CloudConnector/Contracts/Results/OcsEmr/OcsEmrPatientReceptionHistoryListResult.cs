using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
    public class OcsEmrPatientReceptionHistoryListResult : AbstractContractResult
	{
		private List<OcsEmrPatientReceptionHistoryListItemInfo> _patientReceptionHistoryListItem = new List<OcsEmrPatientReceptionHistoryListItemInfo>();

		public List<OcsEmrPatientReceptionHistoryListItemInfo> PatientReceptionHistoryListItem
		{
			get { return this._patientReceptionHistoryListItem; }
			set { this._patientReceptionHistoryListItem = value; }
		}

		public OcsEmrPatientReceptionHistoryListResult() { }

	}
}