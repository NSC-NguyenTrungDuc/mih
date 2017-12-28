using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroPatientListResult : AbstractContractResult
    {
        private List<NuroPatientListItemInfo> _patientListItem = new List<NuroPatientListItemInfo>();

        public List<NuroPatientListItemInfo> PatientListItem
        {
            get { return _patientListItem; }
            set { _patientListItem = value; }
        }

        public NuroPatientListResult()
        {
        }
    }
}
