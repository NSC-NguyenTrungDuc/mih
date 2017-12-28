using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
    public class OCS2015U40EmrHistoryMedicalRecordResult : AbstractContractResult
    {
        private List<OCS2015U40EmrHistoryMedicalRecordInfo> _emrHistoryMedicalRecordItem = new List<OCS2015U40EmrHistoryMedicalRecordInfo>();

        public List<OCS2015U40EmrHistoryMedicalRecordInfo> EmrHistoryMedicalRecordItem
        {
            get { return this._emrHistoryMedicalRecordItem; }
            set { this._emrHistoryMedicalRecordItem = value; }
        }

        public OCS2015U40EmrHistoryMedicalRecordResult() { }

    }
}