using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Clis
{
    [Serializable]
    public class CLIS2015U03SearchPatientResult : AbstractContractResult
    {
        private List<CLIS2015U03PatientListInfo> _patientListItem = new List<CLIS2015U03PatientListInfo>();

        public List<CLIS2015U03PatientListInfo> PatientListItem
        {
            get { return this._patientListItem; }
            set { this._patientListItem = value; }
        }

        public CLIS2015U03SearchPatientResult() { }

    }
}