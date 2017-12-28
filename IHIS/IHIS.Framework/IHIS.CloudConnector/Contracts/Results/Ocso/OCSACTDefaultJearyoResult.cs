using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
    public class OCSACTDefaultJearyoResult : AbstractContractResult
    {
        private List<OCSACTDefaultJearyoInfo> _defaultJearyoLst = new List<OCSACTDefaultJearyoInfo>();

        public List<OCSACTDefaultJearyoInfo> DefaultJearyoLst
        {
            get { return this._defaultJearyoLst; }
            set { this._defaultJearyoLst = value; }
        }

        public OCSACTDefaultJearyoResult() { }

    }
}