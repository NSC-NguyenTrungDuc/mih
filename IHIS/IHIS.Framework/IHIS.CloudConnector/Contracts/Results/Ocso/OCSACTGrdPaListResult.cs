using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
    public class OCSACTGrdPaListResult : AbstractContractResult
    {
        private List<OCSACTGrdPaListInfo> _grdPaLst = new List<OCSACTGrdPaListInfo>();

        public List<OCSACTGrdPaListInfo> GrdPaLst
        {
            get { return this._grdPaLst; }
            set { this._grdPaLst = value; }
        }

        public OCSACTGrdPaListResult() { }

    }
}