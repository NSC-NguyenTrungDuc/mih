using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
    public class EMRDisplayBookmarkHistoryResult : AbstractContractResult
    {
        private List<PatientInfo> _patientListItem = new List<PatientInfo>();
        private List<NuroPatientReceptionHistoryListItemInfo> _historyListItem = new List<NuroPatientReceptionHistoryListItemInfo>();

        public List<PatientInfo> PatientListItem
        {
            get { return this._patientListItem; }
            set { this._patientListItem = value; }
        }

        public List<NuroPatientReceptionHistoryListItemInfo> HistoryListItem
        {
            get { return this._historyListItem; }
            set { this._historyListItem = value; }
        }

        public EMRDisplayBookmarkHistoryResult() { }

    }
}