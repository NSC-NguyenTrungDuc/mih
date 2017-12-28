using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    public class OCSACT2GetPatientListOCSResult : AbstractContractResult
    {
        private List<OCSACT2GetPatientListOCSInfo> _patOcsItem = new List<OCSACT2GetPatientListOCSInfo>();

        public List<OCSACT2GetPatientListOCSInfo> PatOcsItem
        {
            get { return this._patOcsItem; }
            set { this._patOcsItem = value; }
        }

        public OCSACT2GetPatientListOCSResult() { }

    }
}