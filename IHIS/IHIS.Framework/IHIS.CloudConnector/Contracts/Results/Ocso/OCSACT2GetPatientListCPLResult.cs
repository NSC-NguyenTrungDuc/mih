using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    public class OCSACT2GetPatientListCPLResult : AbstractContractResult
    {
        private List<OCSACT2GetPatientListCPLInfo> _patCplItem = new List<OCSACT2GetPatientListCPLInfo>();

        public List<OCSACT2GetPatientListCPLInfo> PatCplItem
        {
            get { return this._patCplItem; }
            set { this._patCplItem = value; }
        }

        public OCSACT2GetPatientListCPLResult() { }

    }
}