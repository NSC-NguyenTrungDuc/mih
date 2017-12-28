using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NUR2016Q00GrdPatientListResult : AbstractContractResult
    {
        private List<NUR2016Q00GrdPatientListInfo> _grdPatListItem = new List<NUR2016Q00GrdPatientListInfo>();

        public List<NUR2016Q00GrdPatientListInfo> GrdPatListItem
        {
            get { return this._grdPatListItem; }
            set { this._grdPatListItem = value; }
        }

        public NUR2016Q00GrdPatientListResult() { }

    }
}