using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    public class NUR2016U02NuroPatientListResult : AbstractContractResult
    {
        private List<NUR2016U02NuroPatientListItemInfo> _patientListItem = new List<NUR2016U02NuroPatientListItemInfo>();

        public List<NUR2016U02NuroPatientListItemInfo> PatientListItem
        {
            get { return this._patientListItem; }
            set { this._patientListItem = value; }
        }

        public NUR2016U02NuroPatientListResult() { }

    }
}