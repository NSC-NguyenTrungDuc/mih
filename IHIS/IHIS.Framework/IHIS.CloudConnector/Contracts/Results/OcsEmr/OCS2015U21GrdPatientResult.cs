using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    public class OCS2015U21GrdPatientResult : AbstractContractResult
    {
        private List<OCS2015U21GrdPatientListItemInfo> _grdPatientList = new List<OCS2015U21GrdPatientListItemInfo>();
        private String _cntValue;

        public List<OCS2015U21GrdPatientListItemInfo> GrdPatientList
        {
            get { return this._grdPatientList; }
            set { this._grdPatientList = value; }
        }

        public String CntValue
        {
            get { return this._cntValue; }
            set { this._cntValue = value; }
        }

        public OCS2015U21GrdPatientResult() { }

    }
}