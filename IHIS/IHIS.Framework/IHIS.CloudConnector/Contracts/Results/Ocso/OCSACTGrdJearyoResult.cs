using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
    public class OCSACTGrdJearyoResult : AbstractContractResult
    {
        private List<OCSACTGrdJearyoInfo> _grdJearyoLst = new List<OCSACTGrdJearyoInfo>();

        public List<OCSACTGrdJearyoInfo> GrdJearyoLst
        {
            get { return this._grdJearyoLst; }
            set { this._grdJearyoLst = value; }
        }

        public OCSACTGrdJearyoResult() { }

    }
}