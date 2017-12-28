using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
    public class EMRSetDataForTvExamHistResult : AbstractContractResult
    {
        private List<PatientInfo> _patientListItem = new List<PatientInfo>();
        private List<OcsEmrPatientReceptionHistoryListItemInfo> _emrHistoryListItem = new List<OcsEmrPatientReceptionHistoryListItemInfo>();

        public List<PatientInfo> PatientListItem
        {
            get { return this._patientListItem; }
            set { this._patientListItem = value; }
        }

        public List<OcsEmrPatientReceptionHistoryListItemInfo> EmrHistoryListItem
        {
            get { return this._emrHistoryListItem; }
            set { this._emrHistoryListItem = value; }
        }

        public EMRSetDataForTvExamHistResult() { }

    }
}