using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    public class OCSACT2GetPatientListINJResult : AbstractContractResult
    {
        private List<OCSACT2GetPatientListINJInfo> _patInjItem = new List<OCSACT2GetPatientListINJInfo>();

        public List<OCSACT2GetPatientListINJInfo> PatInjItem
        {
            get { return this._patInjItem; }
            set { this._patInjItem = value; }
        }

        public OCSACT2GetPatientListINJResult() { }

    }
}