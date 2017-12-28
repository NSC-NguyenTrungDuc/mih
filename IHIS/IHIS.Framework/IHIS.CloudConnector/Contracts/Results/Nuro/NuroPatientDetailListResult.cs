using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroPatientDetailListResult : AbstractContractResult
    {
        private List<NuroPatientDetailListItemInfo> _patientDetailListItem = new List<NuroPatientDetailListItemInfo>();

        public List<NuroPatientDetailListItemInfo> PatientDetailListItem
        {
            get { return this._patientDetailListItem; }
            set { this._patientDetailListItem = value; }
        }

        public NuroPatientDetailListResult() { }

    }
}
